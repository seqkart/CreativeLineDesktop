using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmUpdateTimings : DevExpress.XtraEditors.XtraForm
    {
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        public frmUpdateTimings()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private bool ValidateData()
        {

            if (txtInTime.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid In Time");
                txtInTime.Focus();
                return false;
            }
            if (txtOutTime.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Out Time");
                txtOutTime.Focus();
                return false;
            }
            return true;
        }
        private void frmUpdateTimings_Load(object sender, EventArgs e)
        {
            SetMyControls();
            DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadInvoiceDataForEditing] '" + ImDate.Date.ToString("yyyy-MM-dd") + "','" + ImNo + "'");
            dtInvoiceDate.Text = ds.Tables[0].Rows[0]["ImDate"].ToString();
            txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
            txtDebitPartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
            txtserial.Text = ds.Tables[0].Rows[0]["ImType"].ToString();
            txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
            if (ds.Tables[0].Rows[0]["ImInTime"].ToString() == string.Empty)
            {
            }
            else
            {

                txtInTime.EditValue = ds.Tables[0].Rows[0]["ImInTime"];
            }
            if (ds.Tables[0].Rows[0]["ImOutTime"].ToString() == string.Empty)
            {
            }
            else
            {
                txtOutTime.EditValue = ds.Tables[0].Rows[0]["ImOutTime"];
            }

            txtInTime.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    var transaction = sqlcon.BeginTransaction("SaveTransaction");
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {

                        sqlcom.CommandText = " UPDATE    InvoiceMst SET "
                                                 + " ImInTime=@ImInTime,ImOutTime=@ImOutTime"
                                                 + " Where ImDate=@ImDate And ImNo=@ImNo And Imtype='S'";

                        sqlcom.Parameters.AddWithValue("@ImInTime", Convert.ToDateTime(txtInTime.Text).ToString("HH:mm:ss"));
                        sqlcom.Parameters.AddWithValue("@ImOutTime", Convert.ToDateTime(txtOutTime.Text).ToString("HH:mm:ss"));

                        sqlcom.Parameters.AddWithValue("@ImDate", Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@ImNo", txtSerialNo.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                        transaction.Commit();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            ProjectFunctions.SpeakError("Something Wrong. \n Roll Back Failed." + ex2.Message);
                        }
                    }
                }
            }
        }
    }
}