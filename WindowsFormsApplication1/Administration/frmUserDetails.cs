using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmUserDetails : XtraForm
    {
        public String s1 { get; set; }
        public String UserName { get; set; }
        private void SetMyControls()
        {
            try
            {
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ButtonVisualize(this);
                ProjectFunctions.XtraFormVisualize(this);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        public frmUserDetails()
        {
            InitializeComponent();
        }
        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                if (s1 == "&Add")
                {

                    var str = string.Empty;

                    DataSet ds = ProjectFunctions.GetDataSet("select distinct Login_As from usermaster");
                    cmbLoginAs.DataSource = ds.Tables[0];
                    cmbLoginAs.DisplayMember = "Login_As";
                    cmbLoginAs.Focus();
                    cmbLoginAs.SelectedIndex = 0;
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT    RoleCode, UserName, Login_As, UserPwd, UserActive FROM UserMaster Where UserName='" + UserName + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cmbLoginAs.Enabled = false;
                        txtUserName.Enabled = false;
                        cmbLoginAs.Text = ds.Tables[0].Rows[0]["Login_As"].ToString();
                        txtstatusTag.Text = ds.Tables[0].Rows[0]["UserActive"].ToString();
                        txtPassword.Text = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                        txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                        txtRoleCode.Text = ds.Tables[0].Rows[0]["RoleCode"].ToString();
                        txtstatusTag.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtstatusTag_Validating(object sender, CancelEventArgs e)
        {
            if (txtstatusTag.Text == "N" || txtstatusTag.Text == "Y")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Y/N");
                txtstatusTag.Text = string.Empty;
                txtstatusTag.Focus();
            }
        }
        private bool ValidateData()
        {
            try
            {
                if (cmbLoginAs.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid LogIn As");
                    cmbLoginAs.Focus();
                    return false;
                }
                if (txtUserName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid User Name");
                    txtUserName.Focus();
                    return false;
                }
                if (txtPassword.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Password");
                    txtPassword.Focus();
                    return false;
                }
                if (txtstatusTag.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Status Tag");
                    txtstatusTag.Focus();
                    return false;
                }
                if (txtstatusTag.Text == "N" || txtstatusTag.Text == "Y")
                {

                }
                else
                {
                    ProjectFunctions.SpeakError("Valid Values are Y/N");
                    txtstatusTag.Text = string.Empty;
                    txtstatusTag.Focus();
                }
                return true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                return false;
            }
        }
        private void frmUserDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateData()
        {
            try
            {
                DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from ProgramMaster Where (Select RoleCode from UserMaster Where UserName = '" + txtUserName.Text.Trim() + "') like('%' + rolecode + '%') ");
                foreach (DataRow dr in dsCheck.Tables[0].Rows)
                {
                    DataSet dsInner = ProjectFunctions.GetDataSet("Select * from UserProgAccess Where UserName='" + txtUserName.Text.Trim() + "' And ProgCode='" + dr["ProgCode"].ToString() + "'");
                    if (dsInner.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        ProjectFunctions.GetDataTable("Insert into UserProgAccess(UserName,ProgCode,SelectField,ProgAdd_F)values('" + txtUserName.Text.Trim() + "','" + dr["ProgCode"].ToString() + "','-1','-1')");
                    }
                }

                ProjectFunctions.GetDataSet(" Delete from UserProgAccess Where UserName='" + txtUserName.Text.Trim() + "' And ProgCode in (  Select ProgCode from ProgramMaster Where (Select RoleCode from UserMaster Where UserName = '" + txtUserName.Text.Trim() + "') not like('%' + rolecode + '%') )");
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (s1 == "&Add")
                {
                    if (ValidateData())
                    {
                        if (txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
                        {
                            DataSet ds = ProjectFunctions.GetDataSet("select UserName from UserMaster where UserName='" + txtUserName.Text.Trim() + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ProjectFunctions.SpeakError("User Already Exists");
                            }
                            else
                            {
                                var strQry = string.Empty;
                                strQry = " Insert into UserMaster";
                                strQry = strQry + " (UserName,Login_As,UserPwd,UserActive,RoleCode)";
                                strQry = strQry + " values(";
                                strQry = strQry + "'" + txtUserName.Text.Trim() + "',";
                                strQry = strQry + "'" + cmbLoginAs.Text.Trim() + "',";
                                strQry = strQry + "'" + txtPassword.Text.Trim() + "',";
                                strQry = strQry + "'" + txtstatusTag.Text.Trim() + "',";
                                strQry = strQry + "'" + txtRoleCode.Text.Trim() + "')";
                                ProjectFunctions.GetDataSet(strQry);
                                ProjectFunctions.SpeakError("Entry Added Successfully");
                                UpdateData();
                                this.Close();
                            }
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("Password Mismatch");
                        }
                    }
                }
                if (s1 == "Edit")
                {
                    if (Validate())
                    {
                        var strQry = string.Empty;
                        strQry = " UPDATE    UserMaster";
                        strQry = strQry + " SET  ";
                        strQry = strQry + "UserName ='" + txtUserName.Text.Trim() + "',";
                        strQry = strQry + "Login_As ='" + cmbLoginAs.Text.Trim() + "',";
                        strQry = strQry + "UserPwd ='" + txtPassword.Text.Trim() + "',";
                        strQry = strQry + "RoleCode ='" + txtRoleCode.Text.Trim() + "',";
                        strQry = strQry + "UserActive ='" + txtstatusTag.Text.Trim() + "'";
                        strQry = strQry + " Where UserName='" + UserName + "'";
                        ProjectFunctions.GetDataSet(strQry);
                        ProjectFunctions.SpeakError("Entry Updated Successfully");
                        UpdateData();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
    }
}
