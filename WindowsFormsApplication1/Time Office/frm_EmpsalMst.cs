using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using WindowsFormsApplication1;

namespace BNPL.Forms_Master
{
    public partial class frm_EmpsalMst : XtraForm
    {
        public bool IsUpdate { get; set; }

        private string EmpCode;
        private string EmpMonth;

        public frm_EmpsalMst()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                using (var FMRA = new frm_EmpSalAddUpdate() { IsUpdate = false })
                {
                    var P = ProjectFunctions.GetPositionInForm(this);
                    FMRA.Location = new Point(P.X + (ClientSize.Width / 2 - FMRA.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FMRA.Size.Height / 2));
                    FMRA.ShowDialog();
                }
            }
            else
            {
                XtraMessageBox.Show("You have No permission .", "!Error");
            }
            fillGrid();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var Dr = DocMGRGrid.GetFocusedDataRow();
            EmpCode = Dr["EmpCode"].ToString();
            EmpMonth = Dr["MonthYear"].ToString();
            if (btnEdit.Enabled)
            {
                if (DocMGRGrid.DataSource != null)
                {
                    if (DocMGRGrid.RowCount > 0)
                    {
                        DataSet ds = ProjectFunctions.GetDataSet("Select * from PayFinal Where MonthYear='" + EmpMonth + "' And EmpCode='" + EmpCode + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["EmpSalLocTag"].ToString().Trim() == "Y")
                            {
                                XtraMessageBox.Show("Salary Has Been Locked");
                            }
                            else
                            {
                                using (var FMRU = new frm_EmpSalAddUpdate() { IsUpdate = true, MMDocNo = EmpCode, MMDocNo1 = EmpMonth })
                                {
                                    var P = ProjectFunctions.GetPositionInForm(this);
                                    FMRU.Location = new Point(P.X + (ClientSize.Width / 2 - FMRU.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FMRU.Size.Height / 2));
                                    FMRU.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            using (var FMRU = new frm_EmpSalAddUpdate() { IsUpdate = true, MMDocNo = EmpCode, MMDocNo1 = EmpMonth })
                            {
                                var P = ProjectFunctions.GetPositionInForm(this);
                                FMRU.Location = new Point(P.X + (ClientSize.Width / 2 - FMRU.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FMRU.Size.Height / 2));
                                FMRU.ShowDialog();
                            }
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("No Records to Edit", "!Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("No Datasource, Or Unable to fetch Data.", "!Error");
                }
            }
            else
            {
                XtraMessageBox.Show("You have No permission.", "!Error");
            }
            fillGrid();
        }

        private void frm_EmpsalMst_Load(object sender, EventArgs e)
        {
            SetMyControls();


        }

        private void SetMyControls()
        {
            //panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            //ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            //ProjectFunctions.DatePickerVisualize(panelControl1);
            //ProjectFunctions.GroupCtrlVisualize(panelControl1);
            //ProjectFunctions.TextBoxVisualize(panelControl1);
            //ProjectFunctions.ButtonVisualize(panelControl1);

            DtStartDate.EditValue = DateTime.Now.Date;

            DocMGRGrid.OptionsBehavior.Editable = true;
            fillGrid();

            var Query4Controls = String.Format("SELECT     ProgAdd_F, ProgUpd_F, ProgDel_F, ProgRep_p, ProgRep_p,ProgSpl_U FROM         UserProgAccess WHERE     (ProgActive is Null or progActive= 'Y') AND (ProgCode = N'{1}') AND (UserName = N'{0}'); ", GlobalVariables.CurrentUser, GlobalVariables.ProgCode);
            using (var Tempds = ProjectFunctions.GetDataSet(Query4Controls))
            {
                if (Tempds != null)
                {
                    if (Tempds.Tables[0].Rows.Count > 0)
                    {
                        if (Tempds.Tables[0].Rows[0]["ProgAdd_F"].ToString() == "-1")
                        {
                            btnAdd.Enabled = true;
                        }
                        if (Tempds.Tables[0].Rows[0]["ProgUpd_F"].ToString() == "-1")
                        {
                            btnEdit.Enabled = true;
                        }
                        if (Tempds.Tables[0].Rows[0]["ProgDel_F"].ToString() == "-1")
                        {
                            btnDelete.Enabled = true;
                        }
                        if (Tempds.Tables[0].Rows[0]["ProgRep_p"].ToString() == "-1")
                        {
                            btnPrint.Enabled = true;
                        }
                    }
                }
            }
        }

        private void Btn_RefreshGridData_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void fillGrid()
        {
            try
            {
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                //SplashScreenManager.Default.SetWaitFormDescription("Fetching Data");
                var strsql = String.Format("sp_EmpSalMst '{0}{1}'", DtStartDate.Text.Substring(0, 2), DtStartDate.Text.Substring(DtStartDate.Text.Length - 2, 2));

                using (var ds = ProjectFunctions.GetDataSet(strsql))
                {

                    ds.Tables[0].Columns.Add("Select", typeof(bool));
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["Select"] = false;
                    }
                    DocumentMGRGrid.DataSource = ds.Tables[0];
                    DocMGRGrid.BestFitColumns();
                }
                //SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }



        private void DocumentMGRGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEdit.PerformClick();
            }
        }

        private void btnLoadAdvance_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription("Processing Salary");
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((DocumentMGRGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            for (int i = 0; i < MaxRow; i++)
            {
                var currentrow = DocMGRGrid.GetDataRow(i);

                if (currentrow["Select"].ToString().ToUpper() == "TRUE")
                {
                    SplashScreenManager.Default.SetWaitFormDescription("Loading  Loan/Advances " + i.ToString());
                    Decimal LoanAmt = 0;

                    EmpCode = currentrow["EmpCode"].ToString();
                    EmpMonth = currentrow["MonthYear"].ToString();

                    string str = "sp_LoadLoanBal '" + EmpCode + "'";
                    DateTime TempDate = Convert.ToDateTime("20" + EmpMonth.ToString().Substring(2, 2) + "-" + EmpMonth.ToString().Substring(0, 2) + "-" + DateTime.DaysInMonth(Convert.ToInt32("20" + EmpMonth.ToString().Substring(2, 2)), Convert.ToInt32(EmpMonth.ToString().Substring(0, 2))) + string.Empty);

                    DataSet ds = ProjectFunctions.GetDataSet(str);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["LoanBal"]) >= Convert.ToDecimal(ds.Tables[0].Rows[0]["LoanInstlmnt"]))
                        {
                            LoanAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["LoanInstlmnt"]);
                        }
                        else
                        {
                            LoanAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["LoanBal"]);
                        }
                        if (LoanAmt < 0)
                        {
                            LoanAmt = 0;
                        }

                    }
                    else
                    {
                        LoanAmt = 0;
                    }


                    Decimal Advance = 0;

                    DateTime TempAdvanveDate = Convert.ToDateTime("20" + EmpMonth.ToString().Substring(2, 2) + "-" + EmpMonth.ToString().Substring(0, 2) + "-01");
                    DataSet dsAdvance = ProjectFunctions.GetDataSet("select  ISNULL(sum(ExAmt),0) as Advance from ExMst where ExEmpCode='" + EmpCode + "'  And  DATEPART(MM,ExMst.ExDatePost)='" + TempAdvanveDate.Date.ToString("MM") + "' And  DATEPART(yyyy,ExMst.ExDatePost)='" + TempAdvanveDate.Date.ToString("yyyy") + "'");
                    if (dsAdvance.Tables.Count > 0)
                    {
                        if (dsAdvance.Tables[0].Rows.Count > 0)
                        {
                            Advance = Advance + Convert.ToDecimal(dsAdvance.Tables[0].Rows[0][0]);
                        }
                        else
                        {
                            Advance = 0;
                        }
                    }
                    DataSet dsCheckAgain = ProjectFunctions.GetDataSet("Select * from PayFinal Where MonthYear='" + EmpMonth + "' And EmpCode='" + EmpCode + "'");
                    if (dsCheckAgain.Tables[0].Rows.Count > 0)
                    {
                        if (dsCheckAgain.Tables[0].Rows[0]["EmpSalLocTag"].ToString().Trim() == "Y")
                        {

                        }
                        else
                        {
                            DataSet dsUpdate = ProjectFunctions.GetDataSet("update AtnData set EmpAdvAmt='" + Advance + "',EmpLoanAmt='" + LoanAmt + "' Where EmpCode='" + EmpCode + "' And MonthYear='" + EmpMonth + "'");
                        }
                    }
                    else
                    {
                        DataSet dsUpdate = ProjectFunctions.GetDataSet("update AtnData set EmpAdvAmt='" + Advance + "',EmpLoanAmt='" + LoanAmt + "' Where EmpCode='" + EmpCode + "' And MonthYear='" + EmpMonth + "'");
                    }
                }
            }
            fillGrid();
            SplashScreenManager.CloseForm();

        }

        private void btnSelectALL_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                var MaxRow = ((DocumentMGRGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                if (btnSelectALL.Checked == true)
                {
                    for (var i = 0; i < MaxRow; i++)
                    {
                        DocMGRGrid.SetRowCellValue(i, "Select", "True");
                    }
                }
                if (btnSelectALL.Checked == false)
                {
                    for (var i = 0; i < MaxRow; i++)
                    {
                        DocMGRGrid.SetRowCellValue(i, "Select", "False");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}

