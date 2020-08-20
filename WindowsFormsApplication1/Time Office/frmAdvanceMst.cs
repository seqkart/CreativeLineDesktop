using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Forms_Transaction
{
    public partial class frmAdvanceMst : DevExpress.XtraEditors.XtraForm
    {


        public frmAdvanceMst()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fillGrid()
        {
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            //SplashScreenManager.Default.SetWaitFormDescription("Fetching Data");
            var qr = " sp_LoadAdvanceMst '" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "', '" + Convert.ToDateTime(DtEndDate.Text).ToString("yyyy-MM-dd") + "'";
            var ds = ProjectFunctions.GetDataSet(qr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReplGrid.DataSource = ds.Tables[0];
                ReplGridView.BestFitColumns();
                btnEdit.Enabled = true;
            }
            else
            {
                ReplGrid.DataSource = null;
                btnEdit.Enabled = false;
            }
            //SplashScreenManager.CloseForm();
        }
        private void Btn_RefreshGridData_Click(object sender, EventArgs e)
        {
            fillGrid();
        }
        private void SetMyControls()
        {
            //var Query4Controls = string.Empty;
            //panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            //ProjectFunctions.GroupCtrlVisualize(panelControl1);


            //ProjectFunctions.DatePickerVisualize(panelControl1);
            //ProjectFunctions.TextBoxVisualize(panelControl1);
            //ProjectFunctions.ButtonVisualize(panelControl1);
            //Query4Controls = String.Format("SELECT     ProgAdd_F, ProgUpd_F, ProgDel_F, ProgRep_p, ProgRep_p,ProgSpl_U FROM         UserProgAccess WHERE     (ProgActive is Null or progActive= 'Y') AND (ProgCode = N'" + GlobalVariables.ProgCode + "') AND (UserName = N'{0}'); ", GlobalVariables.CurrentUser);

            MainFormButtons.Roles(GlobalVariables.ProgCode, GlobalVariables.CurrentUser,
                btnAdd, btnEdit, btnDelete, btnPrint);
            //using (var Tempds = ProjectFunctions.GetDataSet(Query4Controls))
            //{
            //    if (Tempds != null)
            //    {
            //        if (Tempds.Tables[0].Rows.Count > 0)
            //        {
            //            if (Tempds.Tables[0].Rows[0]["ProgAdd_F"].ToString() == "-1")
            //            {
            //                btnAdd.Enabled = true;
            //            }
            //            else
            //            {
            //                btnAdd.Enabled = false;
            //            }
            //            if (Tempds.Tables[0].Rows[0]["ProgUpd_F"].ToString() == "-1")
            //            {
            //                btnEdit.Enabled = true;
            //            }
            //            else
            //            {
            //                btnEdit.Enabled = false;
            //            }
            //            if (Tempds.Tables[0].Rows[0]["ProgDel_F"].ToString() == "-1")
            //            {
            //                btnDelete.Enabled = true;
            //            }
            //            else
            //            {
            //                btnDelete.Enabled = false;
            //            }
            //            if (Tempds.Tables[0].Rows[0]["ProgRep_p"].ToString() == "-1")
            //            {
            //                btnPrint.Enabled = true;
            //            }
            //            else
            //            {
            //                btnPrint.Enabled = false;
            //            }
            //        }
            //    }
            //}
        }
        private void frmAdvanceMst_Load(object sender, EventArgs e)
        {
            SetMyControls();
            DtEndDate.EditValue = DateTime.Now.Date;
            DtStartDate.EditValue = DateTime.Now.AddMonths(-1).Date;
            fillGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                try
                {
                    var frm = new Forms_Transaction.frmAdvanceAddEdit() { s1 = btnAdd.Text };
                    var P = ProjectFunctions.GetPositionInForm(this);
                    frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.Text = "Time Office Payment Addition";

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
                    var row = ReplGridView.GetDataRow(ReplGridView.FocusedRowHandle);
                    var ds = ProjectFunctions.GetDataSet(string.Format("select * from ExMst Where ExId='" + row["ExId"].ToString() + "'"));
                    if (ds.Tables[0].Rows[0]["ExLoadTag"].ToString() == string.Empty)
                    {
                        var frm = new Forms_Transaction.frmAdvanceAddEdit() { s1 = btnEdit.Text };
                        var P = ProjectFunctions.GetPositionInForm(this);
                        frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                        frm.Text = "Time Office Payment Editing";
                        frm.ExId = row["ExId"].ToString();
                        frm.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Entry Has been Loaded");
                    }
                    fillGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ReplGrid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, e);
        }

        private void ReplGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEdit_Click(null, e);
            }
        }

        private void DtStartDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
