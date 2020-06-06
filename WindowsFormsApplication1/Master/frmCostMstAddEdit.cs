using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmCostMstAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public string CostCode { get; set; }
        public string CostSubCode { get; set; }
        public frmCostMstAddEdit()
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
            DataSet ds = ProjectFunctions.GetDataSet(" select isnull(max(cast(CostCode as int)),0000) from CostMst");
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

            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(cast(CostSubCode as int)),0000) from CostMst where CostCode='" + txtCGrpCode.Text.Trim().PadLeft(4, '0') + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }

            return s2;
        }
        private bool ValidateSubGrpData()
        {
            if (txtCGrpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cost Code");

                txtCGrpCode.Focus();
                return false;
            }
            if (txtCSGrpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cost Desc");

                txtCSGrpCode.Focus();
                return false;
            }
            if (txtCGrpDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cost Desc");

                txtCGrpDesc.Focus();
                return false;
            }
            if (txtCSGrpDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cost Group Desc");

                txtCSGrpDesc.Focus();
                return false;
            }
            return true;
        }
        private bool ValidateGrpData()
        {
            if (txtCGrpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cost Code");

                txtCGrpCode.Focus();
                return false;
            }
            if (txtCGrpDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cost Desc");

                txtCGrpDesc.Focus();
                return false;
            }
            return true;
        }
        private void frmCostMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtCGrpCode.Focus();
                txtCGrpDesc.Enabled = false;
                txtCSGrpCode.Enabled = false;
                txtCSGrpDesc.Enabled = false;
                txtCGrpCode.Text = getNewGroupCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                if (CostSubCode == string.Empty)
                {
                    txtCGrpCode.Enabled = false;
                    txtCGrpDesc.Enabled = true;
                    txtCSGrpCode.Enabled = false;
                    txtCSGrpDesc.Enabled = false;
                    txtCGrpDesc.Focus();
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT CostCode,CostDesc FROM CostMSt where CostCode ='" + CostCode + "'");
                    txtCGrpCode.Text = ds.Tables[0].Rows[0]["CostCode"].ToString();
                    txtCGrpDesc.Text = ds.Tables[0].Rows[0]["CostDesc"].ToString();
                }
                if (CostSubCode != string.Empty)
                {
                    txtCGrpCode.Enabled = false;
                    txtCGrpDesc.Enabled = false;
                    txtCSGrpCode.Enabled = false;
                    txtCSGrpDesc.Enabled = true;
                    txtCSGrpDesc.Focus();
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT CostCode,CostDesc,CostSubcode,CostSubDesc FROM CostMSt where CostCode ='" + CostCode + "' And  CostSubcode='" + CostSubCode + "'");
                    txtCGrpCode.Text = ds.Tables[0].Rows[0]["CostCode"].ToString();
                    txtCGrpDesc.Text = ds.Tables[0].Rows[0]["CostDesc"].ToString();
                    txtCSGrpCode.Text = ds.Tables[0].Rows[0]["CostSubcode"].ToString();
                    txtCSGrpDesc.Text = ds.Tables[0].Rows[0]["CostSubDesc"].ToString();
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (s1 == "&Add")
            {
                if (txtCSGrpDesc.Enabled == false)
                {
                    if (ValidateGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " Insert into CostMSt(CostCode,CostDesc)values(";
                        strQry = strQry + "'" + getNewGroupCode().PadLeft(4, '0') + "',";
                        strQry = strQry + "'" + txtCGrpDesc.Text.Trim() + "')";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon);
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
                if (txtCSGrpDesc.Enabled == true)
                {
                    if (ValidateSubGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " Insert into CostMSt(CostCode,CostSubcode,CostDesc,CostSubDesc)values(";
                        strQry = strQry + "'" + txtCGrpCode.Text.Trim().PadLeft(4, '0') + "',";
                        strQry = strQry + "'" + getNewSubGroupCode().PadLeft(4, '0') + "',";
                        strQry = strQry + "'" + txtCGrpDesc.Text.Trim() + "',";
                        strQry = strQry + "'" + txtCSGrpDesc.Text.Trim() + "')";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon);
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
            }
            if (s1 == "Edit")
            {
                if (txtCSGrpDesc.Enabled == false)
                {
                    if (ValidateGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " UPDATE CostMSt SET";
                        strQry = strQry + " CostDesc ='" + txtCGrpDesc.Text.Trim() + "'";
                        strQry = strQry + " Where CostCode='" + CostCode + "'";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon);
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
                if (txtCSGrpDesc.Enabled == true)
                {
                    if (ValidateSubGrpData())
                    {
                        var strQry = string.Empty;
                        strQry = " UPDATE CostMSt SET";
                        strQry = strQry + " CostSubDesc ='" + txtCSGrpDesc.Text.Trim() + "'";
                        strQry = strQry + " Where CostCode='" + CostCode + "'";
                        strQry = strQry + " AND  CostSubcode='" + CostSubCode + "'";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(strQry, sqlcon);
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcon.Close();
                            ProjectFunctions.SpeakError("Data Saved Successfully");
                        }
                    }
                }
            }
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCGrpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumberOnly(e);
        }

        private void txtCSGrpCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtCGrpCode.Focus();
            }
        }

        private void txtCGrpCode_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(txtCGrpCode.Text) > Convert.ToInt32(getNewGroupCode()))
            {
                txtCGrpCode.Text = getNewGroupCode().PadLeft(4, '0');
                txtCGrpDesc.Focus();
            }
        }

        private void txtCGrpDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.TextOnly(e);
        }

        private void txtCSGrpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumberOnly(e);
        }

        private void frmCostMstAddEdit_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCGrpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (s1 == "&Add")
                {
                    if (Convert.ToInt32(txtCGrpCode.Text) < Convert.ToInt32(getNewGroupCode()))
                    {
                        txtCGrpCode.Enabled = false;
                        txtCSGrpDesc.Enabled = true;
                        txtCSGrpDesc.Focus();
                        txtCGrpDesc.Enabled = false;
                        DataSet ds = ProjectFunctions.GetDataSet("Select CostDesc from CostMst Where CostCode='" + txtCGrpCode.Text.Trim().PadLeft(4, '0') + "'");
                        txtCGrpDesc.Text = ds.Tables[0].Rows[0]["CostDesc"].ToString().Trim();
                        txtCSGrpCode.Text = getNewSubGroupCode().PadLeft(4, '0');
                    }
                    if (Convert.ToInt32(txtCGrpCode.Text) == Convert.ToInt32(getNewGroupCode()))
                    {
                        txtCGrpDesc.Focus();
                        txtCGrpDesc.Enabled = true;
                    }
                }
            }
        }
    }
}