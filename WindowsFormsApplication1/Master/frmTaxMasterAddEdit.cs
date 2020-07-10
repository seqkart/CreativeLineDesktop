using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmTaxMasterAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String TaxCode { get; set; }
        public frmTaxMasterAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtTaxCode.Enabled = false;

            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxMasterAddEdit));

            //btnSave.Image = resources. //Bitmap.FromFile("c:\\NewItem.bmp");
            btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //btnSave.Name = "toolStripButton1";
            //btnSave.Text = "&New";
            btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }
        private string GetNewTaxCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(TaxCode as int)),0000) from TaxMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }

        private void frmTaxMasterAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtTaxDesc.Focus();
                txtTaxCode.Text = GetNewTaxCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtTaxDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadTaxMstFEditng '" + TaxCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTaxCode.Text = ds.Tables[0].Rows[0]["TaxCode"].ToString();
                    txtTaxDesc.Text = ds.Tables[0].Rows[0]["TaxDesc"].ToString();
                    txtLCType.Text = ds.Tables[0].Rows[0]["TaxLC"].ToString().Trim();
                    txtCGSTRate.Text = ds.Tables[0].Rows[0]["TaxCGSTRate"].ToString();
                    txtSGSTRate.Text = ds.Tables[0].Rows[0]["TaxSGSTRate"].ToString();
                    txtIGSTRate.Text = ds.Tables[0].Rows[0]["TaxIGSTRate"].ToString();
                    txtAboveAmount.Text = ds.Tables[0].Rows[0]["TaxAboveAmount"].ToString();
                    txtAboveCGSTRate.Text = ds.Tables[0].Rows[0]["TaxAboveCGSTRate"].ToString();
                    txtAboveSGSTRate.Text = ds.Tables[0].Rows[0]["TaxAboveSGSTRate"].ToString();
                    txtAboveIGSTRate.Text = ds.Tables[0].Rows[0]["TaxAboveIGSTRate"].ToString();
                    txtMessage.Text = ds.Tables[0].Rows[0]["TaxMessage"].ToString();
                    txtSGSTPostingCode.Text = ds.Tables[0].Rows[0]["TaxSGSTPost"].ToString();
                    txtSGSTPostingDesc.Text = ds.Tables[0].Rows[0]["Expr1"].ToString();
                    txtCGSTPostingCode.Text = ds.Tables[0].Rows[0]["TaxCGSTPost"].ToString();
                    txtCGSTPostingDesc.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                    txtIGSTPostingCode.Text = ds.Tables[0].Rows[0]["TaxIGSTPost"].ToString();
                    txtIGSTPostingDesc.Text = ds.Tables[0].Rows[0]["Expr2"].ToString();
                    txtSalePostCode.Text = ds.Tables[0].Rows[0]["TaxSalePost"].ToString();
                    txtSalePostDesc.Text = ds.Tables[0].Rows[0]["Expr3"].ToString();
                    txtCGSTRate.Focus();
                }

            }
        }
        private bool ValidateData()
        {
            if (txtTaxCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Tax Code");
                txtTaxCode.Focus();
                return false;
            }
            if (txtTaxDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Tax Description");
                txtTaxDesc.Focus();
                return false;
            }
            if (txtMessage.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Tax Message");
                txtMessage.Focus();
                return false;
            }
            if (txtLCType.Text == "L")
            {

            }
            else
            {
                if (txtLCType.Text == "C")
                {
                }
                else
                {
                    ProjectFunctions.SpeakError("Valid Vaules Are L-Local,C-Central");
                    txtLCType.Focus();
                    return false;
                }
            }
            if (txtCGSTRate.Text.Trim().Length == 0)
            {
                txtCGSTRate.Text = "0";
            }
            if (txtSGSTRate.Text.Trim().Length == 0)
            {
                txtSGSTRate.Text = "0";
            }
            if (txtIGSTRate.Text.Trim().Length == 0)
            {
                txtIGSTRate.Text = "0";
            }
            if (txtAboveAmount.Text.Trim().Length == 0)
            {
                txtAboveAmount.Text = "0";
            }
            if (txtAboveCGSTRate.Text.Trim().Length == 0)
            {
                txtAboveCGSTRate.Text = "0";
            }
            if (txtAboveIGSTRate.Text.Trim().Length == 0)
            {
                txtAboveIGSTRate.Text = "0";
            }
            if (txtAboveSGSTRate.Text.Trim().Length == 0)
            {
                txtAboveSGSTRate.Text = "0";
            }
            return true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaxMasterAddEdit_KeyDown(object sender, KeyEventArgs e)
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

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtCGSTPostingCode")
            {
                txtCGSTPostingCode.Text = row["AccCode"].ToString();
                txtCGSTPostingDesc.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtSGSTPostingCode.Focus();
            }
            if (HelpGrid.Text == "txtSGSTPostingCode")
            {
                txtSGSTPostingCode.Text = row["AccCode"].ToString();
                txtSGSTPostingDesc.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtIGSTPostingCode.Focus();
            }
            if (HelpGrid.Text == "txtIGSTPostingCode")
            {
                txtIGSTPostingCode.Text = row["AccCode"].ToString();
                txtIGSTPostingDesc.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtMessage.Focus();
            }
            if (HelpGrid.Text == "txtSalePostCode")
            {
                txtSalePostCode.Text = row["AccCode"].ToString();
                txtSalePostDesc.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtSalePostCode.Focus();
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
                                                    + " Insert into TaxMst"
                                                    + " (TaxCode,TaxDesc,TaxLC,TaxCGSTRate,TaxSGSTRate,TaxIGSTRate,TaxCGSTPost,TaxSGSTPost,TaxIGSTPost,TaxMessage,TaxSalePost,TaxAboveAmount,TaxAboveCGSTRate,TaxAboveSGSTRate,TaxAboveIGSTRate)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(TaxCode as int)),0)+1 AS VARCHAR(4)),4)from TaxMst),@TaxDesc,@TaxLC,@TaxCGSTRate,@TaxSGSTRate,@TaxIGSTRate,@TaxCGSTPost,@TaxSGSTPost,@TaxIGSTPost,@TaxMessage,@TaxSalePost,@TaxAboveAmount,@TaxAboveCGSTRate,@TaxAboveSGSTRate,@TaxAboveIGSTRate)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE TaxMst SET "
                                                + " TaxDesc=@TaxDesc,TaxLC=@TaxLC,TaxCGSTRate=@TaxCGSTRate,TaxSGSTRate=@TaxSGSTRate,TaxIGSTRate=@TaxIGSTRate,TaxCGSTPost=@TaxCGSTPost,TaxSGSTPost=@TaxSGSTPost,TaxIGSTPost=@TaxIGSTPost,TaxMessage=@TaxMessage,TaxSalePost=@TaxSalePost, "
                                                + " TaxAboveAmount=@TaxAboveAmount,TaxAboveCGSTRate=@TaxAboveCGSTRate,TaxAboveSGSTRate=@TaxAboveSGSTRate,TaxAboveIGSTRate=@TaxAboveIGSTRate Where TaxCode=@TaxCode";
                        }
                        sqlcom.Parameters.AddWithValue("@TaxCode", txtTaxCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxDesc", txtTaxDesc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxLC", txtLCType.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxCGSTRate", Convert.ToDecimal(txtCGSTRate.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TaxSGSTRate", Convert.ToDecimal(txtSGSTRate.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TaxIGSTRate", Convert.ToDecimal(txtIGSTRate.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TaxCGSTPost", txtCGSTPostingCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxSGSTPost", txtSGSTPostingCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxIGSTPost", txtIGSTPostingCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxMessage", txtMessage.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxSalePost", txtSalePostCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TaxAboveAmount", Convert.ToDecimal(txtAboveAmount.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TaxAboveCGSTRate", Convert.ToDecimal(txtAboveCGSTRate.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TaxAboveSGSTRate", Convert.ToDecimal(txtAboveSGSTRate.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TaxAboveIGSTRate", Convert.ToDecimal(txtAboveIGSTRate.Text.Trim()));
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

        private void txtSalePostingCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst ", " Where AccCode", txtCGSTPostingCode, txtCGSTPostingDesc, txtSGSTPostingCode, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void txtTaxPostingCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst ", " Where AccCode", txtSGSTPostingCode, txtSGSTPostingDesc, txtIGSTPostingCode, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void txtSurPostingCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst ", " Where AccCode", txtIGSTPostingCode, txtCGSTPostingDesc, txtMessage, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void txtSalePostingCode_EditValueChanged(object sender, EventArgs e)
        {
            txtCGSTPostingDesc.Text = string.Empty;
        }

        private void txtTaxPostingCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSGSTPostingDesc.Text = string.Empty;
        }

        private void txtSurPostingCode_EditValueChanged(object sender, EventArgs e)
        {
            txtIGSTPostingDesc.Text = string.Empty;
        }

        private void txtLCType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtLCType.Text == "L")
            {

            }
            else
            {
                if (txtLCType.Text == "C")
                {
                }
                else
                {
                    ProjectFunctions.SpeakError("Valid Vaules Are L-Local,C-Central");
                    txtLCType.Focus();
                }
            }
        }

        private void txtSalePostingCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTaxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtSalePostCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSalePostDesc.Text = string.Empty;
        }

        private void txtSalePostCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst ", " where AccCode", txtSalePostCode, txtSalePostDesc, txtSalePostCode, HelpGrid, HelpGridView, e);

        }
    }
}