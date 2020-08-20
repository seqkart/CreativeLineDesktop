using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frmEmployeeMDataPassing : DevExpress.XtraEditors.XtraForm
    {
        public frmEmployeeMDataPassing()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            //panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.TextBoxVisualize(this);
            //ProjectFunctions.DatePickerVisualize(panelControl1);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            //ProjectFunctions.GroupCtrlVisualize(panelControl1);
            ProjectFunctions.XtraFormVisualize(this);
            //ProjectFunctions.ButtonVisualize(panelControl1);

            ProjectFunctions.GirdViewVisualize(InvoiceGridView);
        }


        private void fillGrid()
        {
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            //SplashScreenManager.Default.SetWaitFormDescription("Fetching Data");
            var ds = new DataSet();
            var str = " sp_LoadEmployeeMDataMst '" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "', '" + Convert.ToDateTime(DtEndDate.Text).ToString("yyyy-MM-dd") + "'";
            ds = ProjectFunctions.GetDataSet(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                InvoiceGrid.DataSource = ds.Tables[0];
                InvoiceGridView.BestFitColumns();
            }
            else
            {
                InvoiceGrid.DataSource = null;
                InvoiceGridView.BestFitColumns();
            }
            //SplashScreenManager.CloseForm();
        }
        private void frmEmployeeMDataPassing_Load(object sender, EventArgs e)
        {
            SetMyControls();
            DtStartDate.EditValue = DateTime.Now.AddMonths(-1);
            DtEndDate.EditValue = DateTime.Now;
            fillGrid();
        }

        private void Btn_RefreshGridData_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void InvoiceGrid_DoubleClick(object sender, EventArgs e)
        {
            var row = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
            var frm = new frmEmployeeMDataPAddEdit();
            var P = ProjectFunctions.GetPositionInForm(this);
            frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
            frm.Text = "Employee Salary Passing";
            frm.empcode = row["EmpCode"].ToString();
            frm.empdate = row["EmpDDate"].ToString();
            frm.ShowDialog();
            fillGrid();
        }

        private void InvoiceGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InvoiceGrid_DoubleClick(null, e);
            }
        }
    }
}