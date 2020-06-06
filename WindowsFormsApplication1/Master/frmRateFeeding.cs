using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Linq;
namespace WindowsFormsApplication1.Master
{
    public partial class frmRateFeeding : DevExpress.XtraEditors.XtraForm
    {
        public String DealerCode { get; set; }
        public frmRateFeeding()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRateFeeding_Load(object sender, EventArgs e)
        {
            SetMyControls();
            DataSet ds = ProjectFunctions.GetDataSet("sp_LoadRates '" + DealerCode + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HelpGrid.DataSource = ds.Tables[0];
                HelpGrid.Visible = true;
                HelpGrid.Focus();
                HelpGridView.BestFitColumns();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((HelpGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            ProjectFunctions.GetDataSet("Delete From DealerRateMaster Where DrDealerCode='" + DealerCode + "'");
            for (int i = 0; i < MaxRow; i++)
            {
                DataRow CurrentRow = HelpGridView.GetDataRow(i);
                String Query = "Insert Into DealerRateMaster(drPrdcode,drDealerCode,drPrdRate,drPrdRDC,drPrdRDC1)values(";
                Query = Query + "'" + Convert.ToDecimal(CurrentRow["PrdCode"]) + "',";
                Query = Query + "'" + DealerCode + "',";
                Query = Query + "'" + Convert.ToDecimal(CurrentRow["Rate"]) + "',";
                Query = Query + "'" + Convert.ToDecimal(CurrentRow["Disc"]) + "',";
                Query = Query + "'" + Convert.ToDecimal(CurrentRow["DiscO"]) + "')";
                ProjectFunctions.GetDataSet(Query);
            }
            this.Close();
        }
    }
}