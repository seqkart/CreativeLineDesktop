using System;
using System.Data;
using System.Data.SqlClient;

#pragma warning disable CS0105 // The using directive for 'System.Data' appeared previously in this namespace
#pragma warning restore CS0105 // The using directive for 'System.Data' appeared previously in this namespace

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmBankMarking : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public String AccCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public frmBankMarking()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fillGrid()
        {
            var str = " SELECT       VutID,VutNo,VutType, VutDate,  VutNart,(case when VutAmt < 0 then -VutAmt  END ) as Credit, ";
            str = str + "(case when VutAmt > 0 then VutAmt  END ) as Debit,vutChqClearDt";
            str = str + " FROM            vuData Where VutACode='" + AccCode + "' And VutDate Between '" + StartDate.Date.ToString("yyyy-MM-dd") + "' And '" + EndDate.Date.ToString("yyyy-MM-dd") + "' ORDER BY vutChqClearDt ,DEBIT ,CREDIT";
            DataSet ds = ProjectFunctions.GetDataSet(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                InvoiceGrid.DataSource = dt;
                InvoiceGridView.BestFitColumns();
            }
            else
            {
                InvoiceGrid.DataSource = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ProjectFunctions.GetConnection()))
            {
                con.Open();
                var cmd = new SqlCommand
                {
                    Connection = con
                };
                var transaction = con.BeginTransaction("SaveTransaction");
                cmd.Transaction = transaction;
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var str = string.Empty;
                        if (dr["vutChqClearDt"].ToString() == string.Empty)
                        {
                            str = string.Format("Update vuData set vutChqClearDt={0} Where VutID='{1}'", System.Data.SqlTypes.SqlDateTime.Null, dr["VutID"].ToString());
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = str;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }

                        else
                        {
                            str = string.Format("Update vuData set vutChqClearDt='{0}' Where VutID='{1}'", Convert.ToDateTime(dr["vutChqClearDt"]).ToString("yyyy-MM-dd"), dr["VutID"].ToString());
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = str;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                    transaction.Commit();
                    fillGrid();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    transaction.Rollback();
                }
            }

        }

        private void frmBankMarking_Load(object sender, EventArgs e)
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            fillGrid();
        }
    }
}