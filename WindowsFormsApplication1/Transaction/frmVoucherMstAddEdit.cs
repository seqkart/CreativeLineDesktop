using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Transaction
{
    public partial class frmVoucherMstAddEdit : DevExpress.XtraEditors.XtraForm
    {
        int rowindex = 0;
        public String s1 { get; set; }
        public String VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }

        Decimal VoucherAmount = 0;
#pragma warning disable CS0169 // The field 'frmVoucherMstAddEdit.HelpWindowText' is never used
        String HelpWindowText;
#pragma warning restore CS0169 // The field 'frmVoucherMstAddEdit.HelpWindowText' is never used

        DataTable dt = new DataTable();

#pragma warning disable CS0414 // The field 'frmVoucherMstAddEdit.PSplInfo' is assigned but its value is never used
        String PSplInfo = string.Empty;
#pragma warning restore CS0414 // The field 'frmVoucherMstAddEdit.PSplInfo' is assigned but its value is never used

        public frmVoucherMstAddEdit()
        {
            InitializeComponent();
            dt.Columns.Add("AccCode", typeof(String));
            dt.Columns.Add("AccName", typeof(String));
            dt.Columns.Add("Narration", typeof(String));
            dt.Columns.Add("Debit", typeof(Decimal));
            dt.Columns.Add("Credit", typeof(Decimal));
            dt.Columns.Add("CrDr", typeof(String));
            dt.Columns.Add("VutTType", typeof(String));
            dt.Columns.Add("VutChequeNo", typeof(String));
            dt.Columns.Add("VutChequeDate", typeof(DateTime));

        }

        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.ButtonVisualize(this);
        }

        private void frmVoucherMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                dtInvoiceDate.EditValue = DateTime.Now;
                txtVuType.Focus();
            }
            else
            {
                dtInvoiceDate.Enabled = false;
                txtVuType.Enabled = false;
                var str = "[sp_LoadVouDataFEditing] @VumNo='" + VoucherNo + "',@VumDate='" + Convert.ToDateTime(VoucherDate).ToString("yyyy-MM-dd") + "'";
                DataSet ds = ProjectFunctions.GetDataSet(str);
                dtInvoiceDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["VumDate"]).ToString("yyyy-MM-dd");
                txtVuType.Text = ds.Tables[0].Rows[0]["VumType"].ToString();
                txtVuDesc.Text = ds.Tables[0].Rows[0]["VouDesc"].ToString();

                ds.Tables[1].Columns.Add("Credit", typeof(Decimal));
                ds.Tables[1].Columns.Add("Debit", typeof(Decimal));


                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    if (Convert.ToDecimal(dr["Amount"]) < 0)
                    {
                        dr["Credit"] = -Convert.ToDecimal(dr["Amount"]);
                        dr["CrDr"] = "CR";
                        dr["Debit"] = Convert.ToDecimal("0");
                    }
                    if (Convert.ToDecimal(dr["Amount"]) > 0)
                    {
                        dr["Debit"] = Convert.ToDecimal(dr["Amount"]);
                        dr["CrDr"] = "DR";
                        dr["Credit"] = Convert.ToDecimal("0");
                    }
                }


                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
                InfoGridView.BestFitColumns();
                txtAccCode.Focus();
            }
        }
        private void SetCrDrValue()
        {
            if (txtVuType.Text == "CP")
            {
                txtDrCr.Text = "DR";
            }
            if (txtVuType.Text == "CR")
            {
                txtDrCr.Text = "CR";
            }
            if (txtVuType.Text == "JL")
            {
                txtDrCr.Text = "CR";
            }
            if (txtVuType.Text == "DN")
            {
                txtDrCr.Text = "CR";
            }
            if (txtVuType.Text == "CN")
            {
                txtDrCr.Text = "CR";
            }
            if (txtVuType.Text == "BP")
            {
                txtDrCr.Text = "DR";
            }
            if (txtVuType.Text == "BR")
            {
                txtDrCr.Text = "CR";
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtVuType_EditValueChanged(object sender, EventArgs e)
        {
            txtVuDesc.Text = string.Empty;
            InfoGrid.DataSource = null;
            dt.Clear();
            SetCrDrValue();
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            try
            {
                var strsql = string.Empty;
                var ds = new DataSet();
                strsql = strsql + "select isnull(max(Cast(VumNo as int)),0000000) from VuMst Where  VumDate='" + dtInvoiceDate.DateTime.Date.ToString("yyyy-MM-dd") + "'";
                ds = ProjectFunctions.GetDataSet(strsql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                    s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            return s2;
        }
        private bool ValidateData()
        {
            if (txtAccCode.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Account Code");
                txtAccCode.Focus();
                return false;
            }
            if (txtAccName.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Account Name");
                txtAccName.Focus();
                return false;
            }
            if (txtVuType.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid VuType");
                txtVuType.Focus();
                return false;
            }
            if (txtVuDesc.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid VuType");
                txtVuType.Focus();
                return false;
            }
            if (txtDrCr.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Value");
                txtDrCr.Focus();
                return false;
            }
            if (txtDrCr.Text == "CR")
            {

            }
            else
            {
                if (txtDrCr.Text == "DR")
                {
                }
                else
                {
                    ProjectFunctions.SpeakError("Valid Value Are (CR,DR)");
                    txtDrCr.Focus();
                    return false;
                }
            }
            if (txtAmount.Text.Length == 0)
            {
                txtAmount.Text = "0";
            }
            if (Convert.ToDecimal(txtAmount.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Invalid Amount");
                txtAmount.Focus();
                return false;
            }

            return true;
        }
        private bool ValidateDataForSaving()
        {

            if (txtVuType.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid VuType");
                txtVuType.Focus();
                return false;
            }
            if (txtVuDesc.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid VuType");
                txtVuType.Focus();
                return false;
            }
            if (dtInvoiceDate.Text.Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Date");
                dtInvoiceDate.Focus();
                return false;
            }
            Decimal DebitAmt = 0;
            Decimal CreditAmt = 0;
            foreach (DataRow dr in dt.Rows)
            {
                DebitAmt = DebitAmt + Convert.ToDecimal(dr["Debit"]);
                CreditAmt = CreditAmt + Convert.ToDecimal(dr["Credit"]);
            }
            if (DebitAmt == CreditAmt)
            {
                VoucherAmount = DebitAmt;
            }
            else
            {
                ProjectFunctions.SpeakError("Debit Amount Should Be Equal To Credit Amount");
                return false;
            }

            return true;
        }
        private void txtVuType_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select VouCode,VouDesc from VoucherType ", " Where VouCode", txtVuType, txtVuDesc, txtAccCode, HelpGrid, HelpGridView, e);
        }

        private void txtAccCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst ", " Where AccCode", txtAccCode, txtAccName, txtAmount, HelpGrid, HelpGridView, e);

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
            if (HelpGrid.Text == "txtVuType")
            {
                txtVuType.Text = row["VouCode"].ToString();
                txtVuDesc.Text = row["VouDesc"].ToString();
                HelpGrid.Visible = false;
                txtAccCode.Focus();
            }
            if (HelpGrid.Text == "txtAccCode")
            {
                txtAccCode.Text = row["AccCode"].ToString();
                txtAccName.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtAmount.Focus();
            }

        }
        private void AddInvoice()
        {
            using (var con = new SqlConnection(ProjectFunctions.GetConnection()))
            {
                con.Open();
                var cmd = new SqlCommand
                {
                    Connection = con
                };
                var transaction = con.BeginTransaction("SaveTransaction");
                cmd.Transaction = transaction;
                try
                {
                    String DocNo = getNewInvoiceDocumentNo().ToString().PadLeft(7, '0');
                    String str = "Insert Into VuMst(VumNo,VumDate,VumType,VumAmt,VumAutoGen)values(";
                    str = str + "'" + DocNo + "',";
                    str = str + "'" + Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd") + "',";
                    str = str + "'" + txtVuType.Text.Trim() + "',";
                    str = str + "'" + VoucherAmount + "','N')";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();


                    foreach (DataRow dr in dt.Rows)
                    {

                        String str1 = "Insert Into VuData(VutNo,VutDate,VutType,VutAmt,VutACode,VutNart,VutChequeNo,VutChequeDate)values(";
                        str1 = str1 + "'" + DocNo + "',";
                        str1 = str1 + "'" + Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd") + "',";
                        str1 = str1 + "'" + txtVuType.Text.Trim() + "',";
                        if (dr["CrDr"].ToString().ToUpper() == "CR")
                        {
                            str1 = str1 + "'" + -Convert.ToDecimal(dr["Credit"]) + "',";
                        }
                        if (dr["CrDr"].ToString().ToUpper() == "DR")
                        {
                            str1 = str1 + "'" + Convert.ToDecimal(dr["Debit"]) + "',";
                        }
                        str1 = str1 + "'" + dr["AccCode"].ToString() + "',";
                        str1 = str1 + "'" + dr["Narration"].ToString() + "',";
                        str1 = str1 + "'" + dr["VutChequeNo"].ToString() + "',";
                        if (dr["VutChequeDate"].ToString() == string.Empty)
                        {
                            str1 = str1 + string.Empty + SqlDateTime.Null + ")";
                        }
                        else
                        {
                            str1 = str1 + "'" + Convert.ToDateTime(dr["VutChequeDate"]) + "')";
                        }

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = str1;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                    }
                    transaction.Commit();
                    Close();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    transaction.Rollback();
                }
            }
        }


        private void EditInvoice()
        {
            using (var con = new SqlConnection(ProjectFunctions.GetConnection()))
            {
                con.Open();
                var cmd = new SqlCommand
                {
                    Connection = con
                };
                var transaction = con.BeginTransaction("SaveTransaction");
                cmd.Transaction = transaction;
                try
                {

                    String str = "Update VuMst Set ";
                    str = str + " VumAmt='" + VoucherAmount + "'";
                    str = str + " Where VumNo='" + VoucherNo + "' And VumDate='" + Convert.ToDateTime(VoucherDate).ToString("yyyy-MM-dd") + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    var query = "Delete from VuData Where VutNo='" + VoucherNo + "' And VutDate='" + Convert.ToDateTime(VoucherDate).ToString("yyyy-MM-dd") + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();



                    foreach (DataRow dr in dt.Rows)
                    {
                        String str1 = "Insert Into VuData(VutNo,VutDate,VutType,VutAmt,VutACode,VutNart,VutChequeNo,VutChequeDate)values(";
                        str1 = str1 + "'" + VoucherNo + "',";
                        str1 = str1 + "'" + Convert.ToDateTime(VoucherDate).ToString("yyyy-MM-dd") + "',";
                        str1 = str1 + "'" + txtVuType.Text.Trim() + "',";
                        if (dr["CrDr"].ToString().ToUpper() == "CR")
                        {
                            str1 = str1 + "'" + -Convert.ToDecimal(dr["Credit"]) + "',";
                        }
                        if (dr["CrDr"].ToString().ToUpper() == "DR")
                        {
                            str1 = str1 + "'" + Convert.ToDecimal(dr["Debit"]) + "',";
                        }
                        str1 = str1 + "'" + dr["AccCode"].ToString() + "',";
                        str1 = str1 + "'" + dr["Narration"].ToString() + "',";
                        str1 = str1 + "'" + dr["VutChequeNo"].ToString() + "',";
                        if (dr["VutChequeDate"].ToString() == string.Empty)
                        {
                            str1 = str1 + string.Empty + SqlDateTime.Null + ")";
                        }
                        else
                        {
                            str1 = str1 + "'" + Convert.ToDateTime(dr["VutChequeDate"]) + "')";
                        }

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = str1;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                    }
                    transaction.Commit();
                    Close();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    transaction.Rollback();
                }
            }
        }


        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                InfoGrid.RefreshDataSource();
                if (BtnOK.Text.ToUpper() == "&OK")
                {
                    InfoGrid.RefreshDataSource();
                    var dr = dt.NewRow();
                    dr["AccCode"] = txtAccCode.Text.Trim();
                    dr["AccName"] = txtAccName.Text;
                    dr["Narration"] = txtNarration.Text;
                    if (txtDrCr.Text.ToUpper() == "DR")
                    {
                        dr["Debit"] = Convert.ToDecimal(txtAmount.Text);
                    }
                    else
                    {
                        dr["Debit"] = Convert.ToDecimal("0");
                    }
                    if (txtDrCr.Text.ToUpper() == "CR")
                    {
                        dr["Credit"] = Convert.ToDecimal(txtAmount.Text);
                    }
                    else
                    {
                        dr["Credit"] = Convert.ToDecimal("0");
                    }
                    dr["CrDr"] = txtDrCr.Text;
                    dr["VutChequeNo"] = txtChqNo.Text;
                    if (txtChqDate.Text.Length > 0)
                    {
                        dr["VutChequeDate"] = Convert.ToDateTime(txtChqDate.Text).ToString("yyyy-MM-dd");
                    }
                    dt.Rows.Add(dr);
                    if (dt.Rows.Count > 0)
                    {
                        InfoGrid.DataSource = dt;
                        InfoGridView.BestFitColumns();
                    }
                }


                if (BtnOK.Text.ToUpper() == "&UPDATE")
                {
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["AccCode"], txtAccCode.Text.Trim());
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["AccName"], txtAccName.Text);
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Narration"], txtNarration.Text);
                    if (txtDrCr.Text.ToUpper() == "DR")
                    {
                        InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Debit"], Convert.ToDecimal(txtAmount.Text));
                    }
                    else
                    {
                        InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Debit"], Convert.ToDecimal("0"));
                    }
                    if (txtDrCr.Text.ToUpper() == "CR")
                    {
                        InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Credit"], Convert.ToDecimal(txtAmount.Text));
                    }
                    else
                    {
                        InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["Credit"], Convert.ToDecimal("0"));
                    }
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["CrDr"], txtDrCr.Text);
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["VutChequeNo"], txtChqNo.Text);
                    if (txtChqDate.Text.Length > 0)
                    {
                        InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["VutChequeDate"], Convert.ToDateTime(txtChqDate.Text));
                    }
                    InfoGridView.RefreshData();
                    BtnUndo.PerformClick();
                }
            }
        }
        private void clear()
        {
            BtnOK.Text = "&OK";
            txtAccCode.Text = string.Empty;
            txtAccName.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtNarration.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtChqNo.Text = string.Empty;
            txtChqDate.Text = string.Empty;
            txtAccCode.Focus();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            if (MaxRow == 0)
            {
                ProjectFunctions.SpeakError("Invalid Operation");
            }
            else
            {
                InfoGridView.DeleteRow(rowindex);
                InfoGridView.RefreshData();
                dt.AcceptChanges();
                clear();
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void InfoGrid_DoubleClick(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            if (MaxRow == 0)
            {
                ProjectFunctions.SpeakError("Invalid Operation");
            }
            else
            {

                BtnOK.Text = "&Update";
                rowindex = InfoGridView.FocusedRowHandle;
                var row = InfoGridView.GetDataRow(InfoGridView.FocusedRowHandle);
                txtAccCode.Text = row["AccCode"].ToString();
                txtAccName.Text = row["AccName"].ToString();
                if (Convert.ToDecimal(row["Debit"]) > Convert.ToDecimal(row["Credit"]))
                {
                    txtAmount.Text = row["Debit"].ToString();
                }
                else
                {
                    txtAmount.Text = row["Credit"].ToString();
                }

                txtNarration.Text = row["Narration"].ToString();
                txtChqNo.Text = row["VutChequeNo"].ToString();
                if (row["VutChequeDate"].ToString().Trim().Length > 0)
                {
                    txtChqDate.EditValue = Convert.ToDateTime(row["VutChequeDate"]);
                }
                txtDrCr.Text = row["CrDr"].ToString();

                txtAccCode.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDataForSaving())
            {
                if (s1 == "&Add")
                {
                    AddInvoice();
                }
                if (s1 == "Edit")
                {
                    EditInvoice();
                }
            }
        }
    }
}