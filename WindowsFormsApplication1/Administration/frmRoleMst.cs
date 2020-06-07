using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Administration
{
    public partial class frmRoleMst : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String RoleCode { get; set; }
        public frmRoleMst()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            try
            {
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                txtRoleDesc.Properties.MaxLength = 40;

                txtRoleCode.Enabled = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private string GetNewDeptCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(RoleCode as int)),0000) from RoleMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private bool ValidateData()
        {
            try
            {
                if (txtRoleCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Role Code");
                    txtRoleCode.Focus();
                    return false;
                }
                if (txtRoleDesc.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Role Description");
                    txtRoleDesc.Focus();
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
        private void FrmRoleMst_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                if (s1 == "&Add")
                {
                    txtRoleDesc.Focus();
                    txtRoleCode.Text = GetNewDeptCode().PadLeft(4, '0');
                }
                if (s1 == "Edit")
                {
                    txtRoleDesc.Enabled = false;
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT RoleCode,RoleDesc FROM RoleMst Where RoleCode='" + RoleCode + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtRoleCode.Text = ds.Tables[0].Rows[0]["RoleCode"].ToString();
                        txtRoleDesc.Text = ds.Tables[0].Rows[0]["RoleDesc"].ToString();

                        txtRoleDesc.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void FrmRoleMst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                BtnSave_Click(null, e);
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
                                                    + " Insert into RoleMst"
                                                    + " (RoleCode,RoleDesc)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(RoleCode as int)),0)+1 AS VARCHAR(4)),4)from RoleMst),@RoleDesc)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE RoleMst SET "
                                                + " RoleDesc=@RoleDesc "
                                                + " Where RoleCode=@RoleCode";

                        }
                        sqlcom.Parameters.AddWithValue("@RoleCode", txtRoleCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@RoleDesc", txtRoleDesc.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
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