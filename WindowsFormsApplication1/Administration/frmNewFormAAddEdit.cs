using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmNewFormAAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String ProgCode { get; set; }
        public frmNewFormAAddEdit()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetMyControls()
        {
            try
            {
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.DatePickerVisualize(this);
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ButtonVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void frmNewFormAAddEdit_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                if (s1 == "&Add")
                {
                    txtFormCode.Focus();
                }
                if (s1 == "Edit")
                {
                    txtFormCode.Enabled = false;
                    txtFormName.Enabled = false;
                    txtstatusTag.Focus();
                    DataSet ds = ProjectFunctions.GetDataSet(String.Format(" sp_LoadProgMstFEdit '" + ProgCode + "'"));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtFormCode.Text = ds.Tables[0].Rows[0]["ProgCode"].ToString();
                        txtFormName.Text = ds.Tables[0].Rows[0]["ProgFormLink"].ToString();
                        txtFormDesc.Text = ds.Tables[0].Rows[0]["ProgDesc"].ToString();
                        txtstatusTag.Text = ds.Tables[0].Rows[0]["ProgActive"].ToString();
                        txtNfaTag.Text = ds.Tables[0].Rows[0]["ProgNFA"].ToString();
                        txtMenuName.Text = ds.Tables[0].Rows[0]["ProgInMenu"].ToString();
                        txtSMenuName.Text = ds.Tables[0].Rows[0]["ProgInMenuGroup"].ToString();
                        txtProcName.Text = ds.Tables[0].Rows[0]["ProgProcName"].ToString();
                        txtRoleCode.Text = ds.Tables[0].Rows[0]["RoleCode"].ToString();
                        txtRoleDesc.Text = ds.Tables[0].Rows[0]["RoleDesc"].ToString();
                        txtOrderBy.Text = ds.Tables[0].Rows[0]["OrderBy"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void txtMenuName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ProjectFunctions.CreatePopUpForOneBox(" Select Distinct ProgInMenu as Description from ProgramMaster", " Where ProgInMenu", txtMenuName, txtSMenuName, HelpGrid, HelpGridView);
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtSMenuName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ProjectFunctions.CreatePopUpForOneBox("select Distinct ProgInMenuGroup as Description from ProgramMaster Where ProgInMenu='" + txtMenuName.Text + "'", " And ProgInMenuGroup", txtSMenuName, txtNfaTag, HelpGrid, HelpGridView);
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
                if (HelpGrid.Text == "txtMenuName")
                {
                    txtMenuName.Text = row["Description"].ToString();
                    HelpGrid.Visible = false;
                    txtSMenuName.Focus();
                }
                if (HelpGrid.Text == "txtSMenuName")
                {
                    txtSMenuName.Text = row["Description"].ToString();
                    HelpGrid.Visible = false;
                    txtNfaTag.Focus();
                }
                if (HelpGrid.Text == "txtRoleCode")
                {
                    txtRoleCode.Text = row["RoleCode"].ToString();
                    txtRoleDesc.Text = row["RoleDesc"].ToString();
                    HelpGrid.Visible = false;
                    txtRoleCode.Focus();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    HelpGrid_DoubleClick(null, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    HelpGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtMenuName_EditValueChanged(object sender, EventArgs e)
        {
            txtSMenuName.Text = string.Empty;
        }
        private bool ValidateData()
        {
            try
            {
                if (txtFormCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Form Code");
                    txtFormCode.Focus();
                    return false;
                }
                if (txtFormDesc.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Form Desc Name");
                    txtFormDesc.Focus();
                    return false;
                }
                if (txtFormName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Form Name");
                    txtFormName.Focus();
                    return false;
                }
                if (txtMenuName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Sub Menu");
                    txtMenuName.Focus();
                    return false;
                }
                if (txtSMenuName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Sub Menu Name ");
                    txtSMenuName.Focus();
                    return false;
                }
                if (txtstatusTag.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Status Tag");
                    txtstatusTag.Focus();
                    return false;
                }
                if (txtNfaTag.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid NFA Tag");
                    txtNfaTag.Focus();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (s1 == "&Add")
                {
                    DataSet ds = ProjectFunctions.GetDataSet(String.Format("Select ProgCode From ProgramMaster Where ProgCode='" + txtFormCode.Text.Trim() + "'"));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ProjectFunctions.SpeakError("Program Code Already Used For Some Other Form");
                    }
                    else
                    {
                        if (ValidateData())
                        {
                            var str = "Insert Into ProgramMaster(OrderBy,RoleCode,ProgCode,ProgDesc,ProgFormLink,ProgInMenu,ProgInMenuGroup,ProgActive,ProgNFA,ProgProcName)values(";
                            str = str + "'" + ProjectFunctions.SqlString(txtOrderBy.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtRoleCode.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtFormCode.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtFormDesc.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtFormName.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtMenuName.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtSMenuName.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtstatusTag.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtNfaTag.Text.Trim()) + "',";
                            str = str + "'" + ProjectFunctions.SqlString(txtProcName.Text.Trim()) + "')";
                            ProjectFunctions.GetDataSet(str);
                            ProjectFunctions.SpeakError("Entry Added Successfully");
                        }
                    }
                }
                if (s1 == "Edit")
                {
                    if (ValidateData())
                    {
                        var str = " UPDATE    ProgramMaster";
                        str = str + " SET  ";
                        str = str + "OrderBy ='" + ProjectFunctions.SqlString(txtOrderBy.Text.Trim()) + "',";
                        str = str + "RoleCode ='" + ProjectFunctions.SqlString(txtRoleCode.Text.Trim()) + "',";
                        str = str + "ProgCode ='" + ProjectFunctions.SqlString(txtFormCode.Text.Trim()) + "',";
                        str = str + "ProgDesc ='" + ProjectFunctions.SqlString(txtFormDesc.Text.Trim()) + "',";
                        str = str + "ProgFormLink ='" + ProjectFunctions.SqlString(txtFormName.Text.Trim()) + "',";
                        str = str + "ProgInMenu ='" + ProjectFunctions.SqlString(txtMenuName.Text.Trim()) + "',";
                        str = str + "ProgInMenuGroup ='" + ProjectFunctions.SqlString(txtSMenuName.Text.Trim()) + "',";
                        str = str + "ProgActive ='" + ProjectFunctions.SqlString(txtstatusTag.Text.Trim()) + "',";
                        str = str + "ProgNFA ='" + ProjectFunctions.SqlString(txtNfaTag.Text.Trim()) + "',";
                        str = str + "ProgProcName ='" + ProjectFunctions.SqlString(txtProcName.Text.Trim()) + "'";
                        str = str + " Where ProgCode='" + ProgCode + "'";
                        ProjectFunctions.GetDataSet(str);
                        ProjectFunctions.SpeakError("Entry Updated Successfully");
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void frmNewFormAAddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtNfaTag_Validating(object sender, CancelEventArgs e)
        {
            if (txtNfaTag.Text.ToUpper() == "Y" || (txtNfaTag.Text.ToUpper() == "N"))
            {
                txtNfaTag.Text = txtNfaTag.Text.ToUpper();
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Value Are Y/N");
                txtNfaTag.Focus();
            }
        }

        private void txtstatusTag_Validating(object sender, CancelEventArgs e)
        {
            if (txtstatusTag.Text.ToUpper() == "Y" || (txtstatusTag.Text.ToUpper() == "N"))
            {
                txtstatusTag.Text = txtstatusTag.Text.ToUpper();
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Value Are Y/N");
                txtstatusTag.Focus();
            }
        }

        private void TxtRoleCode_EditValueChanged(object sender, EventArgs e)
        {
            txtRoleDesc.Text = String.Empty;
        }

        private void TxtRoleCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select RoleCode,RoleDesc from RoleMst ", " Where RoleCode ", txtRoleCode, txtRoleDesc, txtRoleCode, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
    }
}