using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frm_StockIndentPassing : XtraForm
    {


        private string strsql;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public frm_StockIndentPassing()
        {
            InitializeComponent();
            StartDate = DateTime.Now.AddDays(-1);
            EndDate = DateTime.Now;
        }

        private void fillGrid()
        {
            strsql = string.Format("Sp_GetData4IndentPassing '{0:yyyy-MM-dd}','{1:yyyy-MM-dd}';", StartDate, EndDate);
            try
            {
                using (var ds = ProjectFunctions.GetDataSet(strsql))
                {
                    ds.Tables[0].Columns.Add("Pass", Type.GetType("System.Boolean"));
                    foreach (DataRow Dr in ds.Tables[0].Rows)
                    {
                        Dr["Pass"] = false;
                    }
                    InPassGridCtrl.DataSource = null;
                    InPassGridCtrl.RefreshDataSource();
                    InPassGridCtrl.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetMyControls()
        {
            panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.GirdViewVisualize(IndentPassGrd);
            ProjectFunctions.DatePickerVisualize(panelControl1);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(panelControl1);
            ProjectFunctions.GroupCtrlVisualize(panelControl1);
            DtEndDate.EditValue = EndDate.Date;
            DtStartDate.EditValue = StartDate.Date;

            DtIndentPass.EditValue = DateTime.Now.Date;
            fillGrid();
        }

        private void ChoiceSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChoiceSelectAll.Checked)
            {
                foreach (DataRow Dr in (InPassGridCtrl.DataSource as DataTable).Rows)
                {
                    Dr["Pass"] = true;
                }
            }
            else
            {
                foreach (DataRow Dr in (InPassGridCtrl.DataSource as DataTable).Rows)
                {
                    Dr["Pass"] = false;
                }
            }
        }

        private void frm_StockIndentPassing_Load(object sender, EventArgs e)
        {
            SetMyControls();
            IndentPassGrd.OptionsBehavior.Editable = true;
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void Btn_Pass_Selected_Click(object sender, EventArgs e)
        {

            IndentPassGrd.CloseEditor();
            IndentPassGrd.UpdateCurrentRow();
            foreach (DataRow Dr in (InPassGridCtrl.DataSource as DataTable).Select("Pass=True And IndPassTag='N'"))
            {
                ProjectFunctions.GetDataSet(String.Format(" Update indData set IndPassTag='Y',IndPassDt='{0}',IndDItemQtyPass='{1}',IndDPassUser='{3}',IndDPassedDt=GetDate() where IndID={2};", DtIndentPass.DateTime.Date.ToString("yyyy-MM-dd"), Dr["IndDItemQty"], Dr["IndID"], GlobalVariables.CurrentUser));
            }
            fillGrid();
        }

        private void Btn_RefreshGridData_Click(object sender, EventArgs e)
        {
            StartDate = DtStartDate.DateTime.Date;
            EndDate = DtEndDate.DateTime.Date;
            fillGrid();
        }

        private void BtnUnPassSelected_Click(object sender, EventArgs e)
        {

            IndentPassGrd.CloseEditor();
            IndentPassGrd.UpdateCurrentRow();
            foreach (DataRow Dr in (InPassGridCtrl.DataSource as DataTable).Select("Pass=True And IndPassTag='Y'"))
            {
                ProjectFunctions.GetDataSet(String.Format(" Update indData set IndPassTag=Null,IndPassDt=Null,IndDItemQtyPass=Null,IndDPassedDt=GetDate() where IndID={2};", DtIndentPass.DateTime.Date.ToString("yyyy-MM-dd"), Dr["IndDItemQty"], Dr["IndID"]));
            }

            fillGrid();
        }
    }
}