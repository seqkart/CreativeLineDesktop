using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmTdsDeductionAddEdit : XtraForm
    {
        public String s1 { get; set; }
        public String TdNo { get; set; }
        public DateTime TdDate { get; set; }


        public frmTdsDeductionAddEdit()
        {
            InitializeComponent();
        }


        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GetNewTDSCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet(String.Format("select isnull(max(Cast(TDNo as int)),00000) from TDSdataMst Where TdDate='{0:yyyy-MM-dd}'", dtTransDate.DateTime.Date));
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private bool ValidateData()
        {
            if (txtPCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Party Code");
                txtPCode.Focus();
                return false;
            }
            if (txtPDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Party Code");
                txtPCode.Focus();
                return false;
            }
            if (txtTDSCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid TDSCode Name");
                txtTDSCode.Focus();
                return false;
            }
            if (txtTDSDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid TDSCode Name");
                txtTDSCode.Focus();
                return false;
            }
            if (txtOnAmount.Text.Trim().Length == 0)
            {
                txtOnAmount.Text = "0";
            }
            if (txtTDSAmount.Text.Trim().Length == 0)
            {
                txtTDSAmount.Text = "0";
            }
            if (txtTDSRate.Text.Trim().Length == 0)
            {
                txtTDSAmount.Text = "0";
            }
            if (txtSurcOnTDS.Text.Trim().Length == 0)
            {
                txtSurcOnTDS.Text = "0";
            }
            if (txtTDSSurcharge.Text.Trim().Length == 0)
            {
                txtTDSSurcharge.Text = "0";
            }
            if (Convert.ToDecimal(txtTDSAmount.EditValue) <= 0 || txtTDSRate.Text.Length == 0)
            {
                txtTDSAmount.Focus();
                ProjectFunctions.SpeakError("Invalid Tds Amount Value");
                return false;
            }

            if (txtRemarks.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Remarks");
                txtRemarks.Focus();
                return false;
            }

            return true;
        }

        private void frmTdsDeductionAddEdit_KeyDown(object sender, KeyEventArgs e)
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

        private void frmTdsDeductionAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtPCode.Focus();
                txtTTNo.Text = GetNewTDSCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadTDSDataFEditing '" + TdDate.Date.ToString("yyyy-MM-dd") + "','" + TdNo + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    dtTransDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["TDDate"]);
                    txtTTNo.Text = ds.Tables[0].Rows[0]["TDNo"].ToString();
                    txtPCode.Text = ds.Tables[0].Rows[0]["TDAcode"].ToString();
                    txtPDesc.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                    txtTDSCode.Text = ds.Tables[0].Rows[0]["TDUScode"].ToString();
                    txtOnAmount.Text = ds.Tables[0].Rows[0]["TDBaseAmt"].ToString();
                    txtTDSRate.Text = ds.Tables[0].Rows[0]["TDTdsRate"].ToString();
                    txtTDSAmount.Text = ds.Tables[0].Rows[0]["TDTdsAmt"].ToString();
                    txtReference.Text = ds.Tables[0].Rows[0]["TDRefInfos"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["TDRemarks"].ToString();
                    txtTDSDesc.Text = ds.Tables[0].Rows[0]["TdsDesc"].ToString();
                    txtTDSSurcharge.Text = ds.Tables[0].Rows[0]["TDTdsSRate"].ToString();
                    txtSurcOnTDS.Text = ds.Tables[0].Rows[0]["TDTdsSAmt"].ToString();
                    txtUnderSection.Text = ds.Tables[0].Rows[0]["TdsUS"].ToString();
                    txtPCode.Focus();
                }
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
                                                    + " Insert into TDSdataMst"
                                                    + " (TDNo,TDDate,TDAcode,TDUScode,TDBaseAmt,TDTdsRate,TDTdsAmt,TDTdsSRate,TDTdsSAmt,TDRefInfos,TDRemarks)"
                                                    + " values((SELECT RIGHT('000000'+ CAST( ISNULL( max(Cast(TDNo as int)),0)+1 AS VARCHAR(7)),7) from TDSdataMst Where TdDate=@TDDate),@TDDate,@TDAcode,@TDUScode,@TDBaseAmt,@TDTdsRate,@TDTdsAmt,@TDTdsSRate,@TDTdsSAmt,@TDRefInfos,@TDRemarks)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE TDSdataMst SET "
                                                + " TDAcode=@TDAcode,TDUScode=@TDUScode,TDBaseAmt=@TDBaseAmt,TDTdsRate=@TDTdsRate,TDTdsAmt=@TDTdsAmt,TDTdsSRate=@TDTdsSRate,TDTdsSAmt=@TDTdsSAmt,"
                                                + " TDRefInfos=@TDRefInfos,TDRemarks=@TDRemarks"
                                                + " Where TDNo=@TDNo And TDDate=@TDDate";
                        }
                        sqlcom.Parameters.Add("@TDDate", SqlDbType.SmallDateTime).Value = dtTransDate.DateTime.Date;
                        sqlcom.Parameters.Add("@TDNo", SqlDbType.NVarChar).Value = txtTTNo.Text.Trim();
                        sqlcom.Parameters.Add("@TDAcode", SqlDbType.NVarChar, 6).Value = txtPCode.Text.Trim();
                        sqlcom.Parameters.Add("@TDUScode", SqlDbType.NVarChar, 6).Value = txtTDSCode.Text.Trim();
                        sqlcom.Parameters.Add("@TDBaseAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtOnAmount.Text);
                        sqlcom.Parameters.Add("@TDTdsRate", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTDSRate.Text);
                        sqlcom.Parameters.Add("@TDTdsAmt", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(txtTDSAmount.Text), 0);
                        sqlcom.Parameters.Add("@TDTdsSRate", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTDSSurcharge.Text);
                        sqlcom.Parameters.Add("@TDTdsSAmt", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(txtSurcOnTDS.Text), 0);
                        sqlcom.Parameters.Add("@TDRefInfos", SqlDbType.NVarChar, 50).Value = txtReference.Text;
                        sqlcom.Parameters.Add("@TDRemarks", SqlDbType.NVarChar, 150).Value = txtRemarks.Text;

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

        private void txtPCode_EditValueChanged(object sender, EventArgs e)
        {
            txtPDesc.Text = string.Empty;
        }

        private void txtPCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst", " Where AccCode=", txtPCode, txtPDesc, txtTDSCode, HelpGrid, HelpGridView, e);
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

        private void txtTDSCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Text = "txtTDSCode";
                if (txtTDSCode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("select TdsCode,TdsDesc,TdsRate,TdsSRate,TdsUS from TdsMst ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGrid.Show();
                        HelpGrid.Focus();
                        HelpGridView.BestFitColumns();
                    }
                }
                else
                {
                    DataSet ds = ProjectFunctions.GetDataSet("select TdsCode,TdsDesc,TdsRate,TdsSRate,TdsUS from TdsMst Where TdsCode='" + txtTDSCode.Text.Trim() + "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTDSCode.Text = ds.Tables[0].Rows[0]["TdsCode"].ToString();
                        txtTDSDesc.Text = ds.Tables[0].Rows[0]["TdsDesc"].ToString();
                        txtTDSRate.Text = ds.Tables[0].Rows[0]["TdsRate"].ToString().Trim();
                        txtTDSSurcharge.Text = ds.Tables[0].Rows[0]["TdsSRate"].ToString();
                        txtUnderSection.Text = ds.Tables[0].Rows[0]["TdsUS"].ToString();
                        if (txtTDSRate.Text == "0")
                        {
                            txtTDSAmount.Enabled = true;
                            txtSurcOnTDS.Enabled = true;
                        }
                        else
                        {
                            txtTDSAmount.Enabled = false;
                            txtSurcOnTDS.Enabled = false;
                        }
                        txtOnAmount.Focus();
                    }
                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("select TdsCode,TdsDesc,TdsRate,TdsSRate,TdsUS from TdsMst ");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            HelpGrid.DataSource = ds1.Tables[0];
                            HelpGrid.Show();
                            HelpGrid.Focus();
                            HelpGridView.BestFitColumns();
                        }
                    }
                }
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtPCode")
            {
                txtPCode.Text = row["AccCode"].ToString().Trim();
                txtPDesc.Text = row["AccName"].ToString().Trim();
                HelpGrid.Visible = false;
                txtTDSCode.Focus();
            }
            if (HelpGrid.Text == "txtPCode")
            {
                txtTDSCode.Text = row["TdsCode"].ToString();
                txtTDSDesc.Text = row["TdsDesc"].ToString();
                txtTDSRate.Text = row["TdsRate"].ToString().Trim();
                txtTDSSurcharge.Text = row["TdsSRate"].ToString();
                txtUnderSection.Text = row["TdsUS"].ToString();
                if (txtTDSRate.Text == "0")
                {
                    txtTDSAmount.Enabled = true;
                    txtSurcOnTDS.Enabled = true;
                }
                else
                {
                    txtTDSAmount.Enabled = false;
                    txtSurcOnTDS.Enabled = false;
                }
                HelpGrid.Visible = false;
                txtOnAmount.Focus();
            }
        }

        private void txtOnAmount_EditValueChanged(object sender, EventArgs e)
        {
            txtTDSAmount.Text = "0";
            txtSurcOnTDS.Text = "0";
        }

        private void txtOnAmount_Leave(object sender, EventArgs e)
        {
            txtTDSAmount.Text = ((Convert.ToDecimal(txtOnAmount.Text) * Convert.ToDecimal(txtTDSRate.Text)) / 100).ToString("0.00");
            txtSurcOnTDS.Text = ((Convert.ToDecimal(txtTDSAmount.Text) * Convert.ToDecimal(txtTDSSurcharge.Text)) / 100).ToString("0.00");
        }

        private void txtReference_Leave(object sender, EventArgs e)
        {
            txtRemarks.Text = string.Empty;
            if (txtTDSRate.Text.Length == 0 || Convert.ToDecimal(txtTDSRate.EditValue) == 0)
            {
                txtRemarks.Text = String.Format("AMT. OF TDS DEDUCTED {1} {0} FROM {2}", txtReference.Text, (Convert.ToDecimal(txtOnAmount.EditValue) > 0 ? ("ON Rs." + txtOnAmount.Text + " AGNST. ") : string.Empty), txtPDesc.Text);
            }
            else
            {
                txtRemarks.Text = String.Format("AMT. OF TDS DEDUCTED ON Rs. {1} @ {2} U/S {3} FROM {4} AGNST. {0}", txtReference.Text, txtOnAmount.Text, txtTDSRate.Text, txtUnderSection.Text, txtPDesc.Text);
            }
        }

        private void txtPCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumberOnly(e);
        }
    }
}