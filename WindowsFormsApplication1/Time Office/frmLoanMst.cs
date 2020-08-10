using DevExpress.XtraEditors;
using SeqKartLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frmLoanMst : DevExpress.XtraEditors.XtraForm
    {

        public string _s1 = null;
        public string _empcode = null;
        public string s1
        {
            get
            {
                return _s1;
            }
            set
            {
                _s1 = value;
            }
        }
        public string empcode
        {
            get
            {
                return _empcode;
            }
            set
            {
                _empcode = value;
            }
        }
        public frmLoanMst()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            //panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            //ProjectFunctions.GroupCtrlVisualize(panelControl1);
            //ProjectFunctions.ButtonVisualize(panelControl1);
            ProjectFunctions.XtraFormVisualize(this);

            ProjectFunctions.GirdViewVisualize(gridView3);

            MainFormButtons.Roles(
                GlobalVariables.ProgCode,
                GlobalVariables.CurrentUser,
                btnAdd, btnEdit, btnDelete, btnPrint);
        }
        private void fillGrid()
        {
            try
            {
                //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                //SplashScreenManager.Default.SetWaitFormDescription("Fetching Data");
                var ds = new DataSet();
                var strsql = string.Empty;
                strsql = strsql + "sp_LoadLoanMst  '" + DtStartDate.DateTime.Date.ToString("yyyy-MM-dd") + "' , '" + DtEndDate.DateTime.Date.ToString("yyyy-MM-dd") + "'";
                ds = ProjectFunctionsUtils.GetDataSet(strsql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    EmployeeGrid.DataSource = ds.Tables[0];

                    btnView.Visible = false;
                    btnView.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnPrint.Enabled = true;
                    //btnView.ForeColor = Color.White;//.FromArgb(255, 255, 255);

                }
                else
                {
                    btnView.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnPrint.Enabled = false;
                    //btnView.ForeColor = Color.WhiteSmoke;//.FromArgb(235, 236, 239);
                }

                //SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString().Trim());
            }
        }
        private void frmLoanMst_Load(object sender, EventArgs e)
        {
            SetMyControls();
            DtEndDate.EditValue = DateTime.Now.Date;
            DtStartDate.EditValue = DateTime.Now.AddYears(-1).Date;
            fillGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                try
                {
                    var frm = new frmLoanMstAddEdit();
                    var P = ProjectFunctions.GetPositionInForm(this);
                    frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    s1 = btnAdd.Text.ToString().Trim();
                    frm.s1 = s1;
                    frm.Text = "Loan Addition";
                    frm.ShowDialog();
                    fillGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                try
                {
                    var row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                    var ds = ProjectFunctions.GetDataSet(string.Format(" select LoanPassedBy from LoanMst Where LoanANo='" + row["LoanANo"].ToString() + "'"));
                    if (ds.Tables[0].Rows[0]["LoanPassedBy"].ToString() == string.Empty)
                    {
                        var frm = new frmLoanMstAddEdit() { LoanNo = row["LoanANo"].ToString(), LoanADate = row["LoanADate"].ToString() };
                        var P = ProjectFunctions.GetPositionInForm(this);
                        frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                        s1 = btnEdit.Text.ToString().Trim();
                        frm.s1 = s1;
                        frm.Text = "Loan Editing";
                        frm.empcode = row["EmpCode"].ToString();
                        frm.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Please UnPass first to perform editing");
                    }
                    fillGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void EmployeeGrid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, e);
        }

        private void EmployeeGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEdit_Click(null, e);
            }
        }
        private void Btn_RefreshGridData_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            try
            {
                var row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                var ds = ProjectFunctions.GetDataSet(string.Format(" select LoanPassedBy from LoanMst Where LoanANo='" + row["LoanANo"].ToString() + "'"));

                var frm = new frmLoanMstAddEdit() { LoanNo = row["LoanANo"].ToString(), LoanADate = row["LoanADate"].ToString() };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                s1 = btnView.Text.ToString().Trim();
                frm.s1 = s1;
                frm.Text = "Loan View";
                frm.empcode = row["EmpCode"].ToString();
                frm.ShowDialog();

                fillGrid();
            }
            catch (Exception ex)
            {
                PrintLogWin.PrintLog(ex);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var row = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            var ds = ProjectFunctions.GetDataSet(string.Format(" select LoanCanceledTag from LoanMst Where LoanANo='" + row["LoanANo"].ToString() + "'"));
            if (ds.Tables[0].Rows[0]["LoanCanceledTag"].ToString().Trim().ToUpper() == "Y")
            {
                ProjectFunctions.GetDataSet("update LoanMst set LoanCanceledTag=null Where LoanANo='" + row["LoanANo"].ToString() + "'");
            }
            else
            {
                ProjectFunctions.GetDataSet("update LoanMst set LoanCanceledTag='Y' Where LoanANo='" + row["LoanANo"].ToString() + "'");
            }

            fillGrid();
        }
    }
}


