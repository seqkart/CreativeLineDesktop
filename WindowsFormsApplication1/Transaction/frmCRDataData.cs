using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmCRDataData : DevExpress.XtraEditors.XtraForm
    {
        public DateTime CDate { get; set; }
        public String CNo { get; set; }

        public string s1 { get; set; }
        public frmCRDataData()
        {
            InitializeComponent();
        }
        private bool ValidateDataForSaving()
        {

            if (txtSMCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Salesman");
                txtSMCode.Focus();
                return false;
            }
            if (txtSMName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Salesman");
                txtSMCode.Focus();
                return false;
            }
            if (txtDebitPartyCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Debit Party");
                txtDebitPartyCode.Focus();
                return false;
            }
            if (txtDebitPartyName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Debit Party");
                txtDebitPartyCode.Focus();
                return false;
            }

            if (txtTotal.Text.Trim().Length == 0)
            {
                txtTotal.Text = "0";
            }
            if (Convert.ToDecimal(txtTotal.Text) < 0)
            {
                ProjectFunctions.SpeakError("Amount Cannot Be Zero");
                txtDebitPartyCode.Focus();
                return false;
            }
            return true;
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(CNo as int)),000000) from CRData Where CDate='" + dtInvoiceDate.DateTime.Date.ToString("yyyy-MM-dd") + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private void frmCRDataData_Load(object sender, EventArgs e)
        {
            SetMyControls();

            if (s1 == "&Add")
            {
                txtSMCode.Focus();
                dtInvoiceDate.EditValue = DateTime.Now;
                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');


            }
            if (s1 == "Edit")
            {
                dtInvoiceDate.Enabled = false;
                txtDebitPartyCode.Enabled = false;
                txtDebitPartyName.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadCRDataFEditing] '" + CDate.Date.ToString("yyyy-MM-dd") + "','" + CNo + "'");
                txtSerialNo.Text = ds.Tables[0].Rows[0]["CNo"].ToString();
                dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["CDate"]);
                txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["CPartyCode"].ToString();
                txtDebitPartyName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                txtSMCode.Text = ds.Tables[0].Rows[0]["CSalesManCode"].ToString();
                txtSMName.Text = ds.Tables[0].Rows[0]["SalesManName"].ToString();
                txtTotal.Text = ds.Tables[0].Rows[0]["CAmt"].ToString();
                txt500.Text = ds.Tables[0].Rows[0]["C500"].ToString();
                txt50.Text = ds.Tables[0].Rows[0]["C50"].ToString();
                txt5.Text = ds.Tables[0].Rows[0]["C5"].ToString();
                txt2000.Text = ds.Tables[0].Rows[0]["C2000"].ToString();
                txt20.Text = ds.Tables[0].Rows[0]["C20"].ToString();
                txt2.Text = ds.Tables[0].Rows[0]["C2"].ToString();
                txt1000.Text = ds.Tables[0].Rows[0]["C1000"].ToString();
                txt100.Text = ds.Tables[0].Rows[0]["C100"].ToString();
                txt10.Text = ds.Tables[0].Rows[0]["C10"].ToString();
                txt1.Text = ds.Tables[0].Rows[0]["C1"].ToString();
                txtSMCode.Focus();
            }
        }
        private void Calculate()
        {
            if (txt1.Text.Trim().Length == 0)
            {
                txt1.Text = "0";
            }
            if (txt2.Text.Trim().Length == 0)
            {
                txt2.Text = "0";
            }
            if (txt5.Text.Trim().Length == 0)
            {
                txt5.Text = "0";
            }
            if (txt10.Text.Trim().Length == 0)
            {
                txt10.Text = "0";
            }
            if (txt20.Text.Trim().Length == 0)
            {
                txt20.Text = "0";
            }
            if (txt50.Text.Trim().Length == 0)
            {
                txt50.Text = "0";
            }
            if (txt100.Text.Trim().Length == 0)
            {
                txt100.Text = "0";
            }
            if (txt500.Text.Trim().Length == 0)
            {
                txt500.Text = "0";
            }
            if (txt1000.Text.Trim().Length == 0)
            {
                txt1000.Text = "0";
            }
            if (txt2000.Text.Trim().Length == 0)
            {
                txt2000.Text = "0";
            }


            Decimal Total = 0;
            Total = Total + Convert.ToDecimal(txt1.Text);
            Total = Total + (2 * Convert.ToDecimal(txt2.Text));
            Total = Total + (5 * Convert.ToDecimal(txt5.Text));
            Total = Total + (10 * Convert.ToDecimal(txt10.Text));
            Total = Total + (20 * Convert.ToDecimal(txt20.Text));
            Total = Total + (50 * Convert.ToDecimal(txt50.Text));
            Total = Total + (100 * Convert.ToDecimal(txt100.Text));
            Total = Total + (500 * Convert.ToDecimal(txt500.Text));
            Total = Total + (1000 * Convert.ToDecimal(txt1000.Text));
            Total = Total + (2000 * Convert.ToDecimal(txt2000.Text));
            txtTotal.Text = Total.ToString("0.00");
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txt2_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtDebitPartyCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDebitPartyName.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDataForSaving())
            {
                Calculate();
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
                                                    + " Insert into CRData"
                                                    + " (CNo,CDate,CPartyCode,CSalesmanCode,CAmt,C1000,C500,C100,C50,C20,C10,C5,C2,C1,C2000)"
                                                    + " values((SELECT RIGHT('00000'+ CAST( ISNULL( max(Cast(CNo as int)),0)+1 AS VARCHAR(5)),5)from CRData),@CDate,@CPartyCode,@CSalesmanCode,@CAmt,@C1000,@C500,@C100,@C50,@C20,@C10,@C5,@C2,@C1,@C2000)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE  CRData    Set  "
                                                + " CNo=@CNo,CDate=@CDate,CPartyCode=@CPartyCode,CSalesmanCode=@CSalesmanCode,CAmt=@CAmt,C1000=@C1000,C500=@C500,C100=@C100,C50=@C50,C20=@C20,C10=@C10,C5=@C5,C2=@C2,C1=@C1,C2000=@C2000 "
                                                + " Where CNo=@CNo And CDate=@CDate";

                        }
                        sqlcom.Parameters.AddWithValue("@CNo", txtSerialNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CDate", Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@CPartyCode", txtDebitPartyCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CSalesmanCode", txtSMCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAmt", Convert.ToDecimal(txtTotal.Text));
                        sqlcom.Parameters.AddWithValue("@C1000", Convert.ToDecimal(txt1000.Text));
                        sqlcom.Parameters.AddWithValue("@C500", Convert.ToDecimal(txt500.Text));
                        sqlcom.Parameters.AddWithValue("@C100", Convert.ToDecimal(txt100.Text));
                        sqlcom.Parameters.AddWithValue("@C50", Convert.ToDecimal(txt50.Text));
                        sqlcom.Parameters.AddWithValue("@C20", Convert.ToDecimal(txt20.Text));
                        sqlcom.Parameters.AddWithValue("@C10", Convert.ToDecimal(txt10.Text));
                        sqlcom.Parameters.AddWithValue("@C5", Convert.ToDecimal(txt5.Text));
                        sqlcom.Parameters.AddWithValue("@C2", Convert.ToDecimal(txt2.Text));
                        sqlcom.Parameters.AddWithValue("@C1", Convert.ToDecimal(txt1.Text));
                        sqlcom.Parameters.AddWithValue("@C2000", Convert.ToDecimal(txt2000.Text));

                        sqlcom.ExecuteNonQuery();



                        transaction.Commit();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Cash Received Data Saved Successfully");

                        txtDebitPartyCode.Text = string.Empty;
                        txtDebitPartyName.Text = string.Empty;
                        txtTotal.Text = string.Empty;
                        txt500.Text = string.Empty;
                        txt50.Text = string.Empty;
                        txt5.Text = string.Empty;
                        txt2000.Text = string.Empty;
                        txt20.Text = string.Empty;
                        txt2.Text = string.Empty;
                        txt1000.Text = string.Empty;
                        txt100.Text = string.Empty;
                        txt10.Text = string.Empty;
                        txt1.Text = string.Empty;

                        txtDebitPartyCode.Focus();

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
        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtDebitPartyCode")
            {
                txtDebitPartyCode.Text = row["AccCode"].ToString().Trim();
                txtDebitPartyName.Text = row["AccName"].ToString().Trim();
                HelpGrid.Visible = false;
                txt2000.Focus();
            }
            if (HelpGrid.Text == "txtSMCode")
            {
                txtSMCode.Text = row["AccCode"].ToString();
                txtSMName.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtDebitPartyCode.Focus();
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

        private void txtDebitPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst Where AccLedger='0001'", " And AccCode", txtDebitPartyCode, txtDebitPartyName, txt2000, HelpGrid, HelpGridView, e);

        }

        private void frmCRDataData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave.PerformClick();
            }
        }

        private void TxtSMCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSMName.Text = string.Empty;
        }

        private void TxtSMCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst Where  AccLedger='0003'", " And AccCode", txtSMCode, txtSMName, txtDebitPartyCode, HelpGrid, HelpGridView, e);
        }
    }
}