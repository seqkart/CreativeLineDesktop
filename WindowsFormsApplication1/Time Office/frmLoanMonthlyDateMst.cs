using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frmLoanMonthlyDateMst : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection con = new SqlConnection(ProjectFunctions.ConnectionString);

        public DateTime StartDate { get; set; }
        public string ItemC;
        public string LoanId { get; set; }
        public string RAid { get; set; }



        public DateTime EndDate { get; set; }
        public frmLoanMonthlyDateMst()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var FRMA = new frmLoanMonthlyData();
            var P = ProjectFunctions.GetPositionInForm(this);
            FRMA.Location = new Point(P.X + (ClientSize.Width / 2 - FRMA.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FRMA.Size.Height / 2));
            FRMA.Text = "Loan Monthly Addition";
            FRMA.ShowDialog();
            fillGrid();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            var Dr = LoanGridView.GetFocusedDataRow();
            if (btn_Edit.Enabled)
            {
                if (LoanGridView.DataSource != null)
                {
                    if (LoanGridView.RowCount > 0)
                    {
                        using (var FMRU = new frmLoanMonthlyData() { IsUpdate = true, LoanId = Dr["TransID"].ToString() })
                        {
                            var P = ProjectFunctions.GetPositionInForm(this);
                            FMRU.Location = new Point(P.X + (ClientSize.Width / 2 - FMRU.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FMRU.Size.Height / 2));
                            FMRU.Text = "Loan Monthly Editing";

                            FMRU.ShowDialog();
                            fillGrid();
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
        }

        private void LoanGrid_DoubleClick(object sender, EventArgs e)
        {
            btn_Edit.PerformClick();
        }

        private void Btn_RefreshRateL_DoubleClick(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void frmLoanMonthlyDateMst_Load(object sender, EventArgs e)
        {
            SetMyControls();
            fillGrid();
        }
        private void fillGrid()
        {
            String sql = String.Format("SELECT        LoanMonthlyData.MonthYear, LoanMonthlyData.EmpCode, EmpMST.EmpName, EmpMST.EmpFHName, LoanMonthlyData.LoanInstlmnt, LoanMonthlyData.TransID FROM            LoanMonthlyData INNER JOIN EmpMST ON LoanMonthlyData.EmpCode = EmpMST.EmpCode where MonthYear = '{0}{1}'", DtStartDate.Text.Substring(0, 2), DtStartDate.Text.Substring(DtStartDate.Text.Length - 2, 2));
            DataSet ds = ProjectFunctions.GetDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                LoanGrid.DataSource = ds.Tables[0];
                LoanGridView.BestFitColumns();
            }
            else
            {
                LoanGrid.DataSource = null;
            }
        }

        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.DatePickerVisualize(panelControl1);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.GroupCtrlVisualize(panelControl1);
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.DatePickerVisualize(panelControl1);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.ButtonVisualize(panelControl1);
            DtStartDate.EditValue = DateTime.Now;
            panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Width / 2, ClientSize.Height / 2 - panelControl1.Height / 2);
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_RefreshRateL_Click(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}