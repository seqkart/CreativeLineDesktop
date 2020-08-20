using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmGroupMstAddEdit : DevExpress.XtraEditors.XtraForm
    {

        public String s1 { get; set; }
        public string GrpCode { get; set; }
        public string SubGrpCode { get; set; }

        public frmGroupMstAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private string getNewGroupCode()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet(" select isnull(max(cast(GrpCode as int)),0000) from GrpMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private string getNewSubGroupCode()
        {
            var s2 = string.Empty;

            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(cast(GrpSubCode as int)),0000) from GrpMst where GrpCode='" + txtGrpCode.Text.Trim().PadLeft(4, '0') + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }

            return s2;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateSubGrpData()
        {
            if (txtGrpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Group Code");

                txtGrpCode.Focus();
                return false;
            }
            if (txtSGrpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid SubGroup Desc");

                txtSGrpCode.Focus();
                return false;
            }
            if (txtGrpDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Group Desc");

                txtGrpDesc.Focus();
                return false;
            }
            if (txtSGrpDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Sub Group Desc");

                txtSGrpDesc.Focus();
                return false;
            }
            return true;
        }
        private bool ValidateGrpData()
        {
            if (txtGrpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Group Code");

                txtGrpCode.Focus();
                return false;
            }
            if (txtGrpDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Group Desc");

                txtGrpDesc.Focus();
                return false;
            }
            return true;
        }

        private void frmGroupMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtGrpCode.Focus();
                txtGrpDesc.Enabled = false;
                txtSGrpCode.Enabled = false;
                txtSGrpDesc.Enabled = false;
                txtGrpCode.Text = getNewGroupCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                if (SubGrpCode == string.Empty)
                {
                    txtGrpCode.Enabled = false;
                    txtGrpDesc.Enabled = true;
                    txtSGrpCode.Enabled = false;
                    txtSGrpDesc.Enabled = false;
                    txtGrpDesc.Focus();
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT GrpCode,GrpDesc FROM GrpMst where GrpCode ='" + GrpCode + "'");
                    txtGrpCode.Text = ds.Tables[0].Rows[0]["GrpCode"].ToString();
                    txtGrpDesc.Text = ds.Tables[0].Rows[0]["GrpDesc"].ToString();
                }
                if (SubGrpCode != string.Empty)
                {
                    txtGrpCode.Enabled = false;
                    txtGrpDesc.Enabled = false;
                    txtSGrpCode.Enabled = false;
                    txtSGrpDesc.Enabled = true;
                    txtSGrpDesc.Focus();
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT GrpCode,GrpDesc,GrpSubCode,GrpSubDesc,GrpHSNCode FROM GrpMst where GrpCode ='" + GrpCode + "' And  GrpSubCode='" + SubGrpCode + "'");
                    txtGrpCode.Text = ds.Tables[0].Rows[0]["GrpCode"].ToString();
                    txtGrpDesc.Text = ds.Tables[0].Rows[0]["GrpDesc"].ToString();
                    txtSGrpCode.Text = ds.Tables[0].Rows[0]["GrpSubCode"].ToString();
                    txtSGrpDesc.Text = ds.Tables[0].Rows[0]["GrpSubDesc"].ToString();
                    txtHSNCode.Text = ds.Tables[0].Rows[0]["GrpHSNCode"].ToString();
                }
            }
        }

        private void txtGrpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (s1 == "&Add")
                {
                    if (Convert.ToInt32(txtGrpCode.Text) < Convert.ToInt32(getNewGroupCode()))
                    {
                        txtGrpCode.Enabled = false;
                        txtSGrpDesc.Enabled = true;
                        txtSGrpDesc.Focus();
                        txtGrpDesc.Enabled = false;
                        DataSet ds = ProjectFunctions.GetDataSet("Select GrpDesc from GrpMst Where GrpCode='" + txtGrpCode.Text.Trim().PadLeft(4, '0') + "'");
                        txtGrpDesc.Text = ds.Tables[0].Rows[0]["GrpDesc"].ToString().Trim();
                        txtSGrpCode.Text = getNewSubGroupCode().PadLeft(4, '0');
                    }
                    if (Convert.ToInt32(txtGrpCode.Text) == Convert.ToInt32(getNewGroupCode()))
                    {
                        txtGrpDesc.Focus();
                        txtGrpDesc.Enabled = true;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (s1 == "&Add")
            {
                if (txtSGrpDesc.Enabled == false)
                {
                    if (ValidateGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " Insert into GrpMst(GrpCode,GrpDesc)values(";
                        strQry = strQry + "'" + getNewGroupCode().PadLeft(4, '0') + "',";
                        strQry = strQry + "'" + txtGrpDesc.Text.Trim() + "')";

                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon)
                            {
                                CommandType = CommandType.Text
                            };
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
                if (txtSGrpDesc.Enabled == true)
                {
                    if (ValidateSubGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " Insert into GrpMst(GrpCode,GrpSubCode,GrpDesc,GrpSubDesc,GrpHSNCode)values(";
                        strQry = strQry + "'" + txtGrpCode.Text.Trim().PadLeft(4, '0') + "',";
                        strQry = strQry + "'" + getNewSubGroupCode().PadLeft(4, '0') + "',";
                        strQry = strQry + "'" + txtGrpDesc.Text.Trim() + "',";
                        strQry = strQry + "'" + txtSGrpDesc.Text.Trim() + "',";
                        strQry = strQry + "'" + txtHSNCode.Text.Trim() + "')";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon)
                            {
                                CommandType = CommandType.Text
                            };
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
            }
            if (s1 == "Edit")
            {
                if (txtSGrpDesc.Enabled == false)
                {
                    if (ValidateGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " UPDATE GrpMst SET";
                        strQry = strQry + " GrpDesc ='" + txtGrpDesc.Text.ToString().Trim() + "'";
                        strQry = strQry + " Where GrpCode='" + GrpCode + "'";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon)
                            {
                                CommandType = CommandType.Text
                            };
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
                if (txtSGrpDesc.Enabled == true)
                {
                    if (ValidateSubGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " UPDATE GrpMst SET";
                        strQry = strQry + " GrpSubDesc ='" + txtSGrpDesc.Text.Trim() + "',";
                        strQry = strQry + " GrpHSNCode ='" + txtHSNCode.Text.Trim() + "'";

                        strQry = strQry + " Where GrpCode='" + GrpCode + "'";
                        strQry = strQry + " AND  GrpSubCode='" + SubGrpCode + "'";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon)
                            {
                                CommandType = CommandType.Text
                            };
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
            }
            this.Close();
        }

        private void txtGrpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumberOnly(e);
        }

        private void txtSGrpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumberOnly(e);
        }

        private void txtGrpCode_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(txtGrpCode.Text) > Convert.ToInt32(getNewGroupCode()))
            {
                txtGrpCode.Text = getNewGroupCode().PadLeft(4, '0');
                txtGrpDesc.Focus();
            }
        }

        private void txtGrpDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtGrpCode.Focus();
            }
        }

        private void frmGroupMstAddEdit_KeyDown(object sender, KeyEventArgs e)
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

        private void txtGrpDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.TextOnly(e);
        }

        private void txtSGrpDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.TextOnly(e);
        }
    }
}
