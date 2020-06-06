using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Master
{
    public partial class frmBalanceSheetHeads : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String BSCode { get; set; }
        public frmBalanceSheetHeads()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            try
            {
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

                txtBSDesc.Properties.MaxLength = 60;
                txtBSCode.Enabled = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateData()
        {
            try
            {
                if (txtBSCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Balance Sheet  Code");
                    txtBSCode.Focus();
                    return false;
                }
                if (txtBSDesc.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Balance Sheet  Description");
                    txtBSDesc.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                return false;
            }
        }
        private void frmBalanceSheetHeads_KeyDown(object sender, KeyEventArgs e)
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
        private string GetNewBSCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(BSCode as int)),0000) from BshMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmBalanceSheetHeads_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                if (s1 == "&Add")
                {
                    txtBSDesc.Focus();
                    txtBSCode.Text = GetNewBSCode().PadLeft(4, '0');
                }
                if (s1 == "Edit")
                {
                    txtBSDesc.Enabled = false;
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT BSCode,BSDesc FROM BshMst Where BSCode='" + BSCode + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtBSCode.Text = ds.Tables[0].Rows[0]["BSCode"].ToString();
                        txtBSDesc.Text = ds.Tables[0].Rows[0]["BSDesc"].ToString();
                        txtBSDesc.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
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
                                                    + " Insert into BshMst"
                                                    + " (BSCode,BSDesc)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(BSCode as int)),0)+1 AS VARCHAR(4)),4)from BshMst),@BSDesc )"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE BshMst SET "
                                                + " BSDesc=@BSDesc "
                                                + " Where BSCode=@BSCode";

                        }
                        sqlcom.Parameters.AddWithValue("@BSCode", txtBSCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@BSDesc", txtBSDesc.Text.Trim());
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