using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
namespace WindowsFormsApplication1.Transaction
{
    public partial class frmIndentPassing : DevExpress.XtraEditors.XtraForm
    {
        public String IndentNo { get; set; }
        public DateTime IndentDate { get; set; }
        public frmIndentPassing()
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

        private void frmIndentPassing_Load(object sender, EventArgs e)
        {
            SetMyControls();
            DataSet ds = ProjectFunctions.GetDataSet("sp_LoadIndDataFPassing '" + IndentNo + "','" + IndentDate.Date.ToString("yyyy-MM-dd") + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("PassUnPass", typeof(bool));

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["IndPassTag"].ToString().ToUpper() == "Y")
                    {
                        dr["PassUnPass"] = true;
                    }
                    else
                    {
                        dr["PassUnPass"] = false;
                    }
                }

                HelpGrid.DataSource = ds.Tables[0];
                HelpGrid.Visible = true;
                HelpGrid.Focus();
                HelpGridView.BestFitColumns();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HelpGridView.CloseEditor();
            HelpGridView.UpdateCurrentRow();
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((HelpGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            for (int i = 0; i < MaxRow; i++)
            {
                DataRow CurrentRow = HelpGridView.GetDataRow(i);
                if (CurrentRow["PassUnPass"].ToString().ToUpper() == "TRUE")
                {

                    String Query = "update  IndData Set ";
                    Query = Query + " IndPassTag='Y',IndPassDt='" + DateTime.Now.ToString("yyyy-MM-dd") + "',IndDItemQtyPass='" + Convert.ToDecimal(CurrentRow["PassQty"]) + "' Where IndID='" + CurrentRow["IndID"] + "'";

                    ProjectFunctions.GetDataSet(Query);
                }
                else
                {
                    DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from POData Where POIndId='" + CurrentRow["IndID"] + "'");
                    if (dsCheck.Tables[0].Rows.Count > 0)
                    {
                        ProjectFunctions.SpeakError("Purchase Order Has Already Been Generated Against This Indent");
                    }
                    else
                    {
                        String Query = "update  IndData Set IndDItemQtyPass=0,";
                        Query = Query + " IndPassTag=null,IndPassDt=null Where IndID='" + CurrentRow["IndID"] + "'";

                        ProjectFunctions.GetDataSet(Query);
                    }


                }
            }
            this.Close();
        }
    }
}