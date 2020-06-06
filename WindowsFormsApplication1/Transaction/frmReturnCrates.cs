using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Transaction
{
    public partial class frmReturnCrates : DevExpress.XtraEditors.XtraForm
    {
        String AgainstOldInvNo = String.Empty;
        DateTime AgainstOldInvDate;

        public String s1 { get; set; }

        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }

        public frmReturnCrates()
        {
            InitializeComponent();
        }

        private void txtDebitPartyCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDebitPartyName.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtOrderNo.Text = string.Empty;
            txtInvCrates1.Text = string.Empty;
            txtInvCrates2.Text = string.Empty;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            HelpGrid.Text = "Bill";
            DataSet ds = ProjectFunctions.GetDataSet("SELECT     InvoiceMst.ImNo, InvoiceMst.ImDate, InvoiceMst.ImDealerCode, ActMst.AccName,InvoiceMst.ImCrates1,InvoiceMst.ImCrates2 FROM         InvoiceMst INNER JOIN ActMst ON InvoiceMst.ImDealerCode = ActMst.AccCode Where InvoiceMst.ImType='S' And InvoiceMst.ImRetCratesNo is null And ImDate>='" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd") + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HelpGrid.DataSource = ds.Tables[0];
                HelpGrid.Show();
                HelpGrid.Visible = true;
                HelpGrid.Focus();
                HelpGridView.BestFitColumns();
            }

        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow CurrentRow = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtSMCode")
            {
                txtSMCode.Text = CurrentRow["AccCode"].ToString();
                txtSMName.Text = CurrentRow["AccName"].ToString();
                HelpGrid.Visible = false;
                txtDebitPartyCode.Focus();
            }
            if (HelpGrid.Text == "Bill")
            {
                txtDebitPartyCode.Text = CurrentRow["ImDealerCode"].ToString();
                txtDebitPartyName.Text = CurrentRow["AccName"].ToString();
                txtOrderNo.Text = CurrentRow["ImNo"].ToString();
                txtOrderDate.Text = Convert.ToDateTime(CurrentRow["ImDate"]).ToString("yyyy-MM-dd");
                txtInvCrates1.Text = CurrentRow["ImCrates1"].ToString();
                txtInvCrates2.Text = CurrentRow["ImCrates2"].ToString();
                HelpGrid.Visible = false;
            }

        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(cmno as int)),000000) from CratesData Where CmFyear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private bool ValidateData()
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
                ProjectFunctions.SpeakError("Invalid Dealer");
                txtDebitPartyCode.Focus();
                return false;
            }
            if (txtDebitPartyName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer");
                txtDebitPartyCode.Focus();
                return false;
            }
            if (txtOrderNo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Against Inv No");
                txtDebitPartyCode.Focus();
                return false;
            }
            if (txtOrderDate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Against Inv No");
                txtDebitPartyCode.Focus();
                return false;
            }
            if (txtCrates1.Text.Length == 0)
            {
                txtCrates1.Text = "0";
            }
            if (txtCrates2.Text.Length == 0)
            {
                txtCrates2.Text = "0";
            }
            return true;
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
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = "[sp_Ins_CratesData]";
                            sqlcom.Parameters.Add("@CmNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters["@CmNo"].Direction = ParameterDirection.InputOutput;

                            sqlcom.Parameters.Add("@CmFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@CmDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@CmSalesManCode", SqlDbType.NVarChar).Value = txtSMCode.Text.Trim();
                            sqlcom.Parameters.Add("@CmPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@CmCrates1", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCrates1.Text);
                            sqlcom.Parameters.Add("@CmCrates2", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCrates2.Text);
                            sqlcom.Parameters.Add("@CmBillNo", SqlDbType.NVarChar).Value = txtOrderNo.Text.Trim();
                            sqlcom.Parameters.Add("@CmBillDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtOrderDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "&Add";
                            sqlcom.ExecuteNonQuery();

                            txtSerialNo.Text = sqlcom.Parameters["@CmNo"].Value.ToString();
                            sqlcom.Parameters.Clear();

                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "[sp_Ins_CratesData]";
                            sqlcom.Parameters.Add("@CmNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@CmFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@CmDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@CmSalesManCode", SqlDbType.NVarChar).Value = txtSMCode.Text.Trim();
                            sqlcom.Parameters.Add("@CmPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@CmCrates1", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCrates1.Text);
                            sqlcom.Parameters.Add("@CmCrates2", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCrates2.Text);
                            sqlcom.Parameters.Add("@CmBillNo", SqlDbType.NVarChar).Value = txtOrderNo.Text.Trim();
                            sqlcom.Parameters.Add("@CmBillDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtOrderDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.VarChar).Value = "EDIT";
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            sqlcom.CommandType = CommandType.Text;
                            String Query = "Update InvoiceMst Set ImRetCratesNo=null,ImRetCratesDate=null  Where ImNo='" + AgainstOldInvNo + "' And ImDate='" + Convert.ToDateTime(AgainstOldInvDate).ToString("yyyy-MM-dd") + "' And ImType='S'";

                            sqlcom.CommandText = Query;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                        }
                        sqlcom.CommandType = CommandType.Text;
                        String QueryUpdate = "Update InvoiceMst Set ImRetCratesNo='" + txtSerialNo.Text + "',ImRetCratesDate='" + dtInvoiceDate.DateTime.Date.ToString("yyyy-MM-dd") + "' Where ImNo='" + txtOrderNo.Text.Trim() + "' And ImDate='" + Convert.ToDateTime(txtOrderDate.Text).ToString("yyyy-MM-dd") + "' And ImType='S'";
                        sqlcom.CommandText = QueryUpdate;
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();


                        transaction.Commit();
                        ProjectFunctions.SpeakError("Return Crates Data Saved Successfully");

                        if (s1 == "&Add")
                        {
                            txtCrates1.Text = string.Empty;
                            txtCrates2.Text = string.Empty;
                            txtDebitPartyCode.Text = string.Empty;
                            txtDebitPartyName.Text = string.Empty;
                            txtInvCrates1.Text = string.Empty;
                            txtInvCrates2.Text = string.Empty;
                            txtInvoiceType.Text = string.Empty;
                            txtOrderDate.Text = string.Empty;
                            txtSMName.Text = string.Empty;
                            txtSMCode.Text = string.Empty;
                            txtOrderNo.Text = string.Empty;
                            txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                            dtInvoiceDate.EditValue = DateTime.Now;
                            btnLoadOrder.Focus();

                        }
                        else
                        {
                            this.Close();
                        }
                        sqlcon.Close();

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
        private void SetMyControls()
        {
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }

        private void frmReturnCrates_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                dtInvoiceDate.EditValue = DateTime.Now;
                btnLoadOrder.Focus();
            }
            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadReturnCratesDataFEdit '" + ImNo + "','" + ImDate.Date.ToString("yyyy-MM-dd") + "'");
                txtSerialNo.Text = ds.Tables[0].Rows[0]["CmNo"].ToString();
                dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["CmDate"]);
                txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["CmPartyCode"].ToString();
                txtDebitPartyName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                txtSMCode.Text = ds.Tables[0].Rows[0]["CmSalesManCode"].ToString();
                txtSMName.Text = ds.Tables[0].Rows[0]["Expr1"].ToString();
                txtOrderNo.Text = ds.Tables[0].Rows[0]["CmBillNo"].ToString();
                AgainstOldInvNo = ds.Tables[0].Rows[0]["CmBillNo"].ToString();
                txtOrderDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CmBillDate"]).ToString("yyyy-MM-dd");
                AgainstOldInvDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CmBillDate"]);
                txtCrates1.Text = ds.Tables[0].Rows[0]["CmCrates1"].ToString();
                txtCrates2.Text = ds.Tables[0].Rows[0]["CmCrates2"].ToString();



                btnLoadOrder.Focus();


            }


        }


        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid_DoubleClick(null, e);
            }
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Visible = false;
            }
        }

        private void frmReturnCrates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave.PerformClick();
            }
        }

        private void TxtSMCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSMName.Text = String.Empty;
        }

        private void TxtSMCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst Where AccActive='Y' And AccLedger='0003' ", " And AccCode", txtSMCode, txtSMName, txtDebitPartyCode, HelpGrid, HelpGridView, e);
        }
    }
}
