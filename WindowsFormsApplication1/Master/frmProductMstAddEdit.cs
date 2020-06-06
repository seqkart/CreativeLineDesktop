using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmProductMstAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String PrdCode { get; set; }
        public frmProductMstAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(panelControl1);

        }
        private void frmProductMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtProductAsgnCode.Focus();
                txtPrdCode.Text = GetNewPrdCode();
            }
            if (s1 == "Edit")
            {
                txtProductAsgnCode.Enabled = false;
                //txtPrdName.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadPrdMstFEditing '" + PrdCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPrdCode.Text = ds.Tables[0].Rows[0]["PrdCode"].ToString();
                    txtProductAsgnCode.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                    txtPrdName.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                    txtUMCode.Text = ds.Tables[0].Rows[0]["PrdUOM"].ToString();
                    txtUMDesc.Text = ds.Tables[0].Rows[0]["UomDesc"].ToString();
                    txtSGrpCode.Text = ds.Tables[0].Rows[0]["PrdSubGrpCode"].ToString();
                    txtGrpCode.Text = ds.Tables[0].Rows[0]["PrdGrpCode"].ToString();

                    txtGrpDesc.Text = ds.Tables[0].Rows[0]["GrpDesc"].ToString();
                    txtSGrpDesc.Text = ds.Tables[0].Rows[0]["GrpSubDesc"].ToString();
                    txtOSQty.Text = ds.Tables[0].Rows[0]["PrdOpStock"].ToString();

                    txtTaxCodePC.Text = ds.Tables[0].Rows[0]["PrdTaxCodePC"].ToString();
                    txtTaxCodePCDesc.Text = ds.Tables[0].Rows[0]["Expr1"].ToString();

                    txtTaxCodePL.Text = ds.Tables[0].Rows[0]["PrdTaxCodePL"].ToString();
                    txtTaxCodePLDesc.Text = ds.Tables[0].Rows[0]["TaxDesc"].ToString();
                    txtstatusTag.Text = ds.Tables[0].Rows[0]["PrdActive"].ToString();
                    txtHSNNo.Text = ds.Tables[0].Rows[0]["PrdHSNNo"].ToString();


                    txtstatusTag.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtPrdCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtPrdCode.Focus();
                return false;
            }
            if (txtProductAsgnCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Description");
                txtProductAsgnCode.Focus();
                return false;
            }
            if (txtPrdName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Name");
                txtPrdName.Focus();
                return false;
            }
            if (txtHSNNo.Text.Length < 3)
            {
                ProjectFunctions.SpeakError("Invali GST HSNNo");
                txtHSNNo.Focus();
                return false;
            }
            if (txtSGrpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Sub Group Code");
                txtSGrpCode.Focus();
                return false;
            }
            if (txtSGrpDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Sub Group Code");
                txtSGrpCode.Focus();
                return false;
            }

            if (txtstatusTag.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Category");
                txtstatusTag.Focus();
                return false;
            }
            if (s1 == "&Add")
            {
                DataSet ds = ProjectFunctions.GetDataSet("Select PrdAsgnCode from PrdMst Where PrdAsgnCode='" + txtProductAsgnCode.Text.Trim() + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ProjectFunctions.SpeakError("Product Asgn Code Already Exists");
                    txtProductAsgnCode.Focus();
                }
            }

            if (txtOSQty.Text.Trim().Length == 0)
            {
                txtOSQty.Text = "0";
            }

            return true;
        }
        private void txtUMCode_EditValueChanged(object sender, EventArgs e)
        {
            txtUMDesc.Text = string.Empty;
        }

        private void txtSGrpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSGrpDesc.Text = string.Empty;
            txtGrpCode.Text = string.Empty;
            txtSGrpDesc.Text = string.Empty;
        }



        private void txtTaxST_EditValueChanged(object sender, EventArgs e)
        {
            txtTaxCodePCDesc.Text = string.Empty;
        }

        private void txtSTL_EditValueChanged(object sender, EventArgs e)
        {
            txtTaxCodePLDesc.Text = string.Empty;
        }
        private string GetNewPrdCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(PrdCode as int)),0000) from PrdMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
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

        private void frmProductMstAddEdit_KeyDown(object sender, KeyEventArgs e)
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
                    sqlcom.Connection = sqlcon;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {

                            sqlcom.CommandText = "  Insert into PrdMst"
                                                    + " (PrdCode,PrdAsgnCode,PrdName,PrdUOM,PrdOpStock,PrdActive,PrdGrpCode,PrdSubGrpCode,"
                                                      + " PrdHSNNo,PrdTaxCodePL,PrdTaxCodePC)"
                                                    + " values(@PrdCode,@PrdAsgnCode,@PrdName,@PrdUOM,@PrdOpStock,@PrdActive,@PrdGrpCode,@PrdSubGrpCode,"
                                                     + " @PrdHSNNo,@PrdTaxCodePL,@PrdTaxCodePC)";

                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE PrdMst SET "
                                                + " PrdCode=@PrdCode,PrdAsgnCode=@PrdAsgnCode,PrdName=@PrdName,PrdUOM=@PrdUOM,PrdOpStock=@PrdOpStock,PrdActive=@PrdActive,PrdGrpCode=@PrdGrpCode,PrdSubGrpCode=@PrdSubGrpCode, "
                                                 + " PrdTaxCodePL=@PrdTaxCodePL,PrdTaxCodePC=@PrdTaxCodePC,PrdHSNNo=@PrdHSNNo"
                                                + " Where PrdCode=@PrdCode";
                        }
                        sqlcom.Parameters.AddWithValue("@PrdCode", Convert.ToDecimal(txtPrdCode.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@PrdAsgnCode", txtProductAsgnCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdActive", txtstatusTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdGrpCode", txtGrpCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdSubGrpCode", txtSGrpCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdName", txtPrdName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdUOM", txtUMCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdOpStock", Convert.ToDecimal(txtOSQty.Text.Trim()));

                        sqlcom.Parameters.AddWithValue("@PrdTaxCodePL", txtTaxCodePC.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdTaxCodePC", txtTaxCodePL.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@PrdHSNNo", txtHSNNo.Text.Trim());



                        sqlcom.ExecuteNonQuery();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Data Saved Successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtUMCode")
            {
                txtUMCode.Text = row["UomCode"].ToString();
                txtUMDesc.Text = row["UomDesc"].ToString();
                HelpGrid.Visible = false;
                txtSGrpCode.Focus();
            }

            if (HelpGrid.Text == "txtSTL")
            {
                txtTaxCodePL.Text = row["TaxCode"].ToString();
                txtTaxCodePLDesc.Text = row["TaxDesc"].ToString();
                HelpGrid.Visible = false;
                txtTaxCodePL.Focus();
            }

            if (HelpGrid.Text == "txtTaxST")
            {
                txtTaxCodePC.Text = row["TaxCode"].ToString();
                txtTaxCodePCDesc.Text = row["TaxDesc"].ToString();
                HelpGrid.Visible = false;
                txtTaxCodePL.Focus();
            }
            if (HelpGrid.Text == "txtSGrpCode")
            {
                txtSGrpCode.Text = row["GrpSubCode"].ToString();
                txtSGrpDesc.Text = row["GrpSubDesc"].ToString();
                txtGrpCode.Text = row["GrpCode"].ToString();
                txtGrpDesc.Text = row["GrpDesc"].ToString();
                HelpGrid.Visible = false;

            }

        }






        private void txtTaxST_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select TaxCode,TaxDesc from TaxMst", " Where TaxCode", txtTaxCodePC, txtTaxCodePCDesc, txtTaxCodePL, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void txtSTL_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select TaxCode,TaxDesc from TaxMst", " Where TaxCode", txtTaxCodePL, txtTaxCodePLDesc, txtTaxCodePL, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void txtUMCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select UomCode,UomDesc from UomMst", " Where UomCode", txtUMCode, txtUMDesc, txtSGrpCode, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void txtstatusTag_Validating(object sender, CancelEventArgs e)
        {
            if (txtstatusTag.Text == "Y" || txtstatusTag.Text == "N")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Y,N");
                txtstatusTag.Focus();
            }
        }


        private void txtSGrpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtSGrpCode";
                DataSet ds = ProjectFunctions.GetDataSet("Select GrpCode,GrpSubCode,GrpDesc,GrpSubDesc from GrpMst");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGrid.Visible = true;
                    HelpGrid.Focus();
                    HelpGridView.BestFitColumns();
                }
                else
                {
                    ProjectFunctions.SpeakError("No Records To Display");
                }
            }
            e.Handled = true;
        }

        private void txtProductAsgnCode_Validating(object sender, CancelEventArgs e)
        {
            if (s1 == "&Add")
            {
                DataSet ds = ProjectFunctions.GetDataSet("Select PrdAsgnCode from PrdMst Where PrdAsgnCode='" + txtProductAsgnCode.Text.Trim() + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ProjectFunctions.SpeakError("Product Asgn Code Already Exists");
                    txtProductAsgnCode.Focus();
                }
            }

        }

        private void txtUMCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumberOnly(e);
        }

    }
}