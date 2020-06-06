using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmLedgerAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String LgrCode { get; set; }
        public frmLedgerAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtLedgerDesc.Properties.MaxLength = 30;
            txtLedgerCode.Enabled = false;
        }
        private void frmLedgerAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtLedgerDesc.Focus();
                txtLedgerCode.Text = GetNewVehicleCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtLedgerDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT LgrCode,LgrDesc FROM LgrMst Where LgrCode='" + LgrCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtLedgerCode.Text = ds.Tables[0].Rows[0]["LgrCode"].ToString();
                    txtLedgerDesc.Text = ds.Tables[0].Rows[0]["LgrDesc"].ToString();
                    txtLedgerType.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtLedgerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Ledger Code");
                txtLedgerCode.Focus();
                return false;
            }
            if (txtLedgerDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Ledger Description");
                txtLedgerDesc.Focus();
                return false;
            }
            return true;
        }
        private string GetNewVehicleCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(LgrCode as int)),00000) from LgrMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmLedgerAddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave_Click(null, e);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  Begin Transaction "
                                                    + " Insert into LgrMst"
                                                    + " (LgrCode,LgrDesc)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(LgrCode as int)),0)+1 AS VARCHAR(4)),4)from LgrMst),@LgrDesc )"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE LgrMst SET "
                                                + " LgrDesc=@LgrDesc "
                                                + " Where LgrCode=@LgrCode";

                        }
                        sqlcom.Parameters.AddWithValue("@LgrCode", txtLedgerCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@LgrDesc", txtLedgerDesc.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Data Saved Successfully");
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