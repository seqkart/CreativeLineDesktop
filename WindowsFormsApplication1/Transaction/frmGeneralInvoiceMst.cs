using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmGeneralInvoiceMst : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        int rowindex;
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        public frmGeneralInvoiceMst()
        {
            InitializeComponent();

            dt.Columns.Add("IdPrdCode", typeof(Decimal));
            dt.Columns.Add("IdPrdAsgnCode", typeof(String));
            dt.Columns.Add("IdPrdQty", typeof(Decimal));
            dt.Columns.Add("IdPrdRate", typeof(Decimal));
            dt.Columns.Add("IdDiscRate", typeof(Decimal));
            dt.Columns.Add("IdPrdAmt", typeof(Decimal));
            dt.Columns.Add("IdTxbAmt", typeof(Decimal));
            dt.Columns.Add("IdTaxAmt", typeof(Decimal));
            dt.Columns.Add("IdPrdTaxCode", typeof(String));
            dt.Columns.Add("IdTaxRate", typeof(Decimal));
            dt.Columns.Add("IdSTaxAmt", typeof(Decimal));
            dt.Columns.Add("IdSTaxRate", typeof(Decimal));
            dt.Columns.Add("PrdName", typeof(String));
        }

        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void clear()
        {
            BtnOK.Text = "&OK";
            txtProductACode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductQty.Text = string.Empty;
            txtProductRate.Text = string.Empty;
            txtDiscPercentage.Text = string.Empty;
            txtProductACode.Focus();
        }
        private bool ValidateDataForSaving()
        {
            if (txtVatInvoice.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Invoice Tag");
                txtVatInvoice.Focus();
                return false;
            }
            if (txtLCTag.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid LCtag Value");
                txtLCTag.Focus();
                return false;
            }
            if (txtCForm.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid CForm Value");
                txtCForm.Focus();
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
            if (txtVatInvoice.Text == "V" || txtVatInvoice.Text == "R" || txtVatInvoice.Text == "S")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are R-Retail,V-Vat,S-Stock Transfer");
                txtVatInvoice.Focus();
                return false;
            }

            if (txtCForm.Text == "Y" || txtCForm.Text == "N")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Y,N");
                txtCForm.Focus();
                return false;
            }

            if (txtLCTag.Text == "L" || txtLCTag.Text == "C")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are L-Local,C-Central");
                txtLCTag.Focus();
                return false;
            }
            if (txtValueOfGoods.Text.Trim().Length == 0)
            {
                txtValueOfGoods.Text = "0.00";
            }
            if (txtTaxableAmount.Text.Trim().Length == 0)
            {
                txtTaxableAmount.Text = "0.00";
            }
            if (txtTaxAmount.Text.Trim().Length == 0)
            {
                txtTaxAmount.Text = "0.00";
            }
            if (txtNetAmount.Text.Trim().Length == 0)
            {
                txtNetAmount.Text = "0.00";
            }
            if (txtRNetAmount.Text.Trim().Length == 0)
            {
                txtRNetAmount.Text = "0.00";
            }


            if (Convert.ToDecimal(txtRNetAmount.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Invalid Bill Amount");
                return false;
            }
            return true;
        }


        private void calculation()
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                InfoGridView.PostEditor();
                InfoGridView.UpdateCurrentRow();
            }));
            txtValueOfGoods.Text = Convert.ToDecimal(gridColumn6.SummaryItem.SummaryValue).ToString("0.00");
            txtTaxableAmount.Text = Convert.ToDecimal(gridColumn7.SummaryItem.SummaryValue).ToString("0.00");
            txtTaxAmount.Text = Convert.ToDecimal(gridColumn8.SummaryItem.SummaryValue).ToString("0.00");
            txtSurcharge.Text = Convert.ToDecimal(gridColumn11.SummaryItem.SummaryValue).ToString("0.00");
            txtNetAmount.Text = (Convert.ToDecimal(txtTaxableAmount.Text) + Convert.ToDecimal(txtTaxAmount.Text) + Convert.ToDecimal(txtSurcharge.Text)).ToString("0.00");

            txtRNetAmount.Text = Math.Round(Convert.ToDecimal(txtNetAmount.Text), 2).ToString("0.00");
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            //if (ValidateData())
            //{
            //    InfoGrid.RefreshDataSource();
            //    var str = "Exec [sp_LoadTaxMstForPrdRateCalc] @VatInvoice='" + txtVatInvoice.Text.Trim() + "',";
            //    str = str + "@LCtag='" + txtLCTag.Text.Trim() + "',";
            //    str = str + "@CForm='" + txtCForm.Text.Trim() + "',";
            //    str = str + "@ProductCode='" + txtProductCode.Text.Trim() + "'";
            //    DataSet ds = ProjectFunctions.GetDataSet(str);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        Tuple<decimal, decimal, decimal> myresult;
            //        myresult = ProjectFunctions.TaxCalculatioData(Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]), Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]), Convert.ToDecimal(txtProductQty.Text), Convert.ToDecimal(txtProductRate.Text), Convert.ToDecimal(txtDiscPercentage.Text), Convert.ToDecimal("0"), Convert.ToDecimal("0"));
            //        if (BtnOK.Text.ToUpper() == "&OK")
            //        {
            //            InfoGrid.RefreshDataSource();
            //            var dr = dt.NewRow();
            //            dr["IdPrdCode"] = Convert.ToDecimal(txtProductCode.Text);
            //            dr["IdPrdAsgnCode"] = txtProductACode.Text;
            //            dr["IdPrdQty"] = Convert.ToDecimal(txtProductQty.Text).ToString("0.00");
            //            dr["IdPrdRate"] = Convert.ToDecimal(txtProductRate.Text).ToString("0.00");
            //            dr["IdDiscRate"] = Convert.ToDecimal(txtDiscPercentage.Text).ToString("0.00");
            //            dr["IdPrdAmt"] = myresult.Item1.ToString("0.00");
            //            dr["IdTxbAmt"] = myresult.Item1.ToString("0.00");
            //            dr["IdTaxAmt"] = myresult.Item2.ToString("0.00");
            //            dr["IdPrdTaxCode"] = ds.Tables[0].Rows[0]["TaxCode"].ToString();
            //            dr["IdTaxRate"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]).ToString("0.00");
            //            dr["IdSTaxAmt"] = myresult.Item3.ToString("0.00");
            //            dr["IdSTaxRate"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]).ToString("0.00");
            //            dr["PrdName"] = txtProductName.Text;
            //            dt.Rows.Add(dr);
            //            if (dt.Rows.Count > 0)
            //            {
            //                InfoGrid.DataSource = dt;
            //                InfoGridView.BestFitColumns();
            //            }
            //            calculation();
            //            BtnUndo.PerformClick();
            //        }
            //        if (BtnOK.Text.ToUpper() == "&UPDATE")
            //        {
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdAsgnCode"], txtProductACode.Text);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdName"], txtProductName.Text);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdQty"], Convert.ToDecimal(txtProductQty.Text).ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdDiscRate"], Convert.ToDecimal(txtDiscPercentage.Text).ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdAmt"], myresult.Item1.ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdCode"], Convert.ToDecimal(txtProductCode.Text));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdTaxCode"], ds.Tables[0].Rows[0]["TaxCode"]);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdTxbAmt"], myresult.Item1.ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdTaxAmt"], myresult.Item2.ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]).ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdSTaxAmt"], myresult.Item3.ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdSTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]).ToString("0.00"));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdRate"], Convert.ToDecimal(txtProductRate.Text).ToString("0.00"));
            //            InfoGridView.RefreshData();
            //            calculation();
            //            BtnUndo.PerformClick();
            //        }
            //    }
            //    else
            //    {
            //        ProjectFunctions.SpeakError("Tax Posting Code Not Defined in Product Master");
            //    }
            //}
        }

        private bool ValidateData()
        {
            if (txtVatInvoice.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Invoice Tag");
                txtVatInvoice.Focus();
                return false;
            }
            if (txtLCTag.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid LCtag Value");
                txtLCTag.Focus();
                return false;
            }
            if (txtCForm.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid CForm Value");
                txtCForm.Focus();
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

            if (txtProductACode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtProductACode.Focus();
                return false;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Product Code");
                txtProductACode.Focus();
                return false;
            }

            if (txtProductQty.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Please Enter Product Quantity");
                txtProductQty.Focus();
                return false;
            }
            if (txtProductRate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Please Enter Product Rate");
                txtProductQty.Focus();
                return false;
            }

            if (txtDiscPercentage.Text.Length == 0)
            {
                txtDiscPercentage.Text = "0";
            }

            if (Convert.ToDecimal(txtProductRate.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Product Rate Cannot Be Zero");
                txtProductRate.Focus();
                return false; ;
            }
            if (Convert.ToDecimal(txtProductQty.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Product Quantity Cannot Be Zero");
                txtProductQty.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtDiscPercentage.Text) < 0)
            {
                ProjectFunctions.SpeakError("Product Disc Cannot Be  Less Than Zero");
                txtDiscPercentage.Focus();
                return false;
            }
            return true;
        }

        private void frmGeneralInvoiceMst_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtDebitPartyCode.Focus();
                txtserial.Text = "S";
                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                dtInvoiceDate.EditValue = DateTime.Now;

            }
            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadInvoiceDataForEditing] '" + ImDate.Date.ToString("yyyy-MM-dd") + "','" + ImNo + "'");

                dtInvoiceDate.Text = ds.Tables[0].Rows[0]["ImDate"].ToString();
                txtNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmt"].ToString();
                txtRNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmtRO"].ToString();
                txtTaxableAmount.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                txtTaxAmount.Text = ds.Tables[0].Rows[0]["ImTaxAmt"].ToString();
                txtSurcharge.Text = ds.Tables[0].Rows[0]["ImSTaxAmt"].ToString();
                txtValueOfGoods.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
                txtDebitPartyName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                txtserial.Text = ds.Tables[0].Rows[0]["ImType"].ToString();
                txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
                txtLCTag.Text = ds.Tables[0].Rows[0]["ImLC"].ToString();
                txtCForm.Text = ds.Tables[0].Rows[0]["ImCForm"].ToString();
                txtVatInvoice.Text = ds.Tables[0].Rows[0]["ImVRTag"].ToString();

                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
                InfoGridView.BestFitColumns();
            }
        }

        private void txtProductACode_EditValueChanged(object sender, EventArgs e)
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtDiscPercentage.Text = string.Empty;
            txtProductRate.Text = string.Empty;
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
                calculation();
            }
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
                txtProductACode.Text = row["IdPrdAsgnCode"].ToString();
                txtProductCode.Text = row["IdPrdCode"].ToString();

                txtProductName.Text = row["PrdName"].ToString();
                txtProductQty.Text = row["IdPrdQty"].ToString();
                txtDiscPercentage.Text = row["IdDiscRate"].ToString();
                txtProductRate.Text = row["IdPrdRate"].ToString();
                txtProductACode.Focus();
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from InvoiceMst Where ImType='S'  And  ImFyear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }

        private void frmGeneralInvoiceMst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave.PerformClick();
            }
        }

        private void txtDebitPartyCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDebitPartyName.Text = string.Empty;
        }

        private void txtVehicleCode_EditValueChanged(object sender, EventArgs e)
        {
            txtVehicleDesc.Text = string.Empty;
        }

        private void txtVehicleCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select VehicleCode,VehicleRegNo from VehicleMst ", " Where VehicleCode", txtVehicleCode, txtVehicleDesc, txtVehicleCode, HelpGrid, HelpGridView, e);
        }

        private void txtDebitPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst", " Where AccCode", txtDebitPartyCode, txtDebitPartyName, txtVatInvoice, HelpGrid, HelpGridView, e);
        }

        private void txtLCTag_Enter(object sender, EventArgs e)
        {
            if (txtLCTag.Text.Trim().Length == 0)
            {
                txtLCTag.Text = "L";
            }
        }

        private void txtCForm_Enter(object sender, EventArgs e)
        {
            if (txtCForm.Text.Trim().Length == 0)
            {
                txtCForm.Text = "N";
            }
        }

        private void txtVatInvoice_Enter(object sender, EventArgs e)
        {
            if (txtVatInvoice.Text.Trim().Length == 0)
            {
                txtVatInvoice.Text = "R";
            }
        }

        private void txtProductACode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtProductACode";
                if (txtProductACode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("Select PrdCode,PrdAsgnCode,PrdName from PrdMst");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGrid.Show();
                        HelpGrid.Visible = true;
                        HelpGrid.Focus();
                        HelpGridView.BestFitColumns();
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("No Records To Display");
                    }
                }
                else
                {
                    DataSet ds = ProjectFunctions.GetDataSet("Select PrdCode,PrdAsgnCode,PrdName from PrdMst Where  PrdAsgnCode ='" + txtProductACode.Text + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtProductCode.Text = ds.Tables[0].Rows[0]["PrdCode"].ToString();
                        txtProductACode.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                        txtProductName.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                        txtProductQty.Focus();
                    }
                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("Select PrdCode,PrdAsgnCode,PrdName from PrdMst");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            HelpGrid.DataSource = ds.Tables[0];
                            HelpGrid.Show();
                            HelpGrid.Visible = true;
                            HelpGrid.Focus();
                            HelpGridView.BestFitColumns();
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("No Records To Display");
                        }
                    }
                }
            }
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateDataForSaving())
            {
                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    var transaction = sqlcon.BeginTransaction("SaveTransaction");
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;

                    try
                    {
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandType = CommandType.StoredProcedure;
                            sqlcom.CommandText = "sp_InvoiceMstAdd";
                            sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "S";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters["@ImNo"].Direction = ParameterDirection.InputOutput;
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@ImPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@ImVehCode", SqlDbType.NVarChar).Value = txtVehicleCode.Text.Trim();
                            sqlcom.Parameters.Add("@ImVogAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxableAmount.Text);
                            sqlcom.Parameters.Add("@ImTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxableAmount.Text);
                            sqlcom.Parameters.Add("@ImTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxAmount.Text);
                            sqlcom.Parameters.Add("@ImSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSurcharge.Text);
                            sqlcom.Parameters.Add("@ImNetAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtNetAmount.Text);
                            sqlcom.Parameters.Add("@ImNetAmtRO", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRNetAmount.Text);
                            sqlcom.Parameters.Add("@ImLC", SqlDbType.NVarChar).Value = txtLCTag.Text.Trim();
                            sqlcom.Parameters.Add("@ImCForm", SqlDbType.NVarChar).Value = txtCForm.Text;
                            sqlcom.Parameters.Add("@ImVRTag", SqlDbType.NVarChar).Value = txtVatInvoice.Text;
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.NVarChar).Value = "ADDMST";
                            sqlcom.ExecuteNonQuery();
                            txtSerialNo.Text = sqlcom.Parameters["@ImNo"].Value.ToString();
                            sqlcom.Parameters.Clear();






                        }
                        if (s1 == "Edit")
                        {

                            sqlcom.CommandType = CommandType.StoredProcedure;
                            sqlcom.CommandText = "sp_InvoiceMstAdd";
                            sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "S";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@ImPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@ImVehCode", SqlDbType.NVarChar).Value = txtVehicleCode.Text.Trim();
                            sqlcom.Parameters.Add("@ImVogAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxableAmount.Text);
                            sqlcom.Parameters.Add("@ImTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxableAmount.Text);
                            sqlcom.Parameters.Add("@ImTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxAmount.Text);
                            sqlcom.Parameters.Add("@ImSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSurcharge.Text);
                            sqlcom.Parameters.Add("@ImNetAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtNetAmount.Text);
                            sqlcom.Parameters.Add("@ImNetAmtRO", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRNetAmount.Text);
                            sqlcom.Parameters.Add("@ImLC", SqlDbType.NVarChar).Value = txtLCTag.Text.Trim();
                            sqlcom.Parameters.Add("@ImCForm", SqlDbType.NVarChar).Value = txtCForm.Text;
                            sqlcom.Parameters.Add("@ImVRTag", SqlDbType.NVarChar).Value = txtVatInvoice.Text;
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.NVarChar).Value = "EDITMST";
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from InvoiceData Where IdNo=@IdNo And IdDate=@IdDate And IdType='S'";
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }

                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into InvoiceData "
                                                        + " (IdFyear,IdType,IdNo,IdDate,IdPartyCode"
                                                        + " ,IdPrdCode,IdPrdAsgnCode,IdPrdQty,IdPrdRate,IdDiscRate,IdPrdAmt,"
                                                        + " IdTxbAmt,IdTaxAmt,IdPrdTaxCode,IdTaxRate,IdSTaxAmt,IdSTaxRate)"
                                                        + " values(@IdFyear,@IdType,@IdNo,@IdDate,@IdPartyCode,"
                                                        + " @IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                        + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,@IdSTaxAmt,@IdSTaxRate)";


                            sqlcom.Parameters.Add("@IdFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@IdType", SqlDbType.NVarChar).Value = "S";
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IdPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@IdPrdCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdCode"]);
                            sqlcom.Parameters.Add("@IdPrdAsgnCode", SqlDbType.NVarChar).Value = currentrow["IdPrdAsgnCode"].ToString();
                            sqlcom.Parameters.Add("@IdPrdQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQty"]);
                            sqlcom.Parameters.Add("@IdPrdRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdRate"]);
                            sqlcom.Parameters.Add("@IdDiscRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdDiscRate"]);
                            sqlcom.Parameters.Add("@IdPrdAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdAmt"]);
                            sqlcom.Parameters.Add("@IdTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdTxbAmt"]);
                            sqlcom.Parameters.Add("@IdTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdTaxAmt"]);
                            sqlcom.Parameters.Add("@IdPrdTaxCode", SqlDbType.NVarChar).Value = currentrow["IdPrdTaxCode"].ToString();
                            sqlcom.Parameters.Add("@IdTaxRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdTaxRate"]);
                            sqlcom.Parameters.Add("@IdSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSTaxAmt"]);
                            sqlcom.Parameters.Add("@IdSTaxRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSTaxRate"]);
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }

                        if (s1 == "Edit")
                        {
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from InvoiceMstAI Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }

                        var distinctRows = (from DataRow dRow in dt.Rows
                                            select dRow["IdPrdTaxCode"]).Distinct();
                        foreach (var v in distinctRows)
                        {
                            if (v.ToString() != string.Empty)
                            {
                                decimal AiAmount = 0, AiTaxAmount = 0, AiTaxSurcharge = 0;
                                for (var m = 0; m < dt.Rows.Count; m++)
                                {
                                    if (v.ToString() == dt.Rows[m]["IdPrdTaxCode"].ToString())
                                    {
                                        AiAmount = AiAmount + Convert.ToDecimal(dt.Rows[m]["IdTxbAmt"]);
                                        AiTaxAmount = AiTaxAmount + Convert.ToDecimal(dt.Rows[m]["IdTaxAmt"]);
                                        AiTaxSurcharge = AiTaxSurcharge + Convert.ToDecimal(dt.Rows[m]["IdSTaxAmt"]);
                                    }
                                    if (m == dt.Rows.Count - 1)
                                    {
                                        sqlcom.CommandType = CommandType.StoredProcedure;
                                        sqlcom.CommandText = "[sp_InvoiceMstAIAdd]";
                                        sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                        sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "S";
                                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                                        sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                                        sqlcom.Parameters.Add("@ImPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                                        sqlcom.Parameters.Add("@ImTxbAmt", SqlDbType.Decimal).Value = AiAmount;
                                        sqlcom.Parameters.Add("@ImTaxAmt", SqlDbType.Decimal).Value = AiTaxAmount;
                                        sqlcom.Parameters.Add("@ImSTaxAmt", SqlDbType.Decimal).Value = AiTaxSurcharge;
                                        sqlcom.Parameters.Add("@ImTaxCode", SqlDbType.NVarChar).Value = v.ToString();
                                        sqlcom.Parameters.Add("@ImNetAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtNetAmount.Text);
                                        sqlcom.ExecuteNonQuery();
                                        sqlcom.Parameters.Clear();
                                    }
                                }
                            }
                        }



                        sqlcom.CommandType = CommandType.StoredProcedure;
                        sqlcom.CommandText = "SP_SLVPosting";
                        sqlcom.Parameters.Add("@DocNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                        sqlcom.Parameters.Add("@DocDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                        sqlcom.Parameters.Add("@DocType", SqlDbType.NVarChar).Value = "S";
                        sqlcom.Parameters.Add("@ROffCode", SqlDbType.NVarChar).Value = "000001";
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
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
            var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtProductACode")
            {
                txtProductACode.Text = row["PrdAsgnCode"].ToString();
                txtProductCode.Text = row["PrdCode"].ToString();
                txtProductName.Text = row["PrdName"].ToString();
                HelpGrid.Visible = false;
                txtProductQty.Focus();
            }
            if (HelpGrid.Text == "txtDebitPartyCode")
            {
                txtDebitPartyCode.Text = row["AccCode"].ToString();
                txtDebitPartyName.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtVatInvoice.Focus();
            }
            if (HelpGrid.Text == "txtVehicleCode")
            {
                txtVehicleCode.Text = row["VehicleCode"].ToString();
                txtVehicleDesc.Text = row["VehicleRegNo"].ToString();
                HelpGrid.Visible = false;
            }
        }

        private void txtVatInvoice_Validating(object sender, CancelEventArgs e)
        {
            if (txtVatInvoice.Text == "V" || txtVatInvoice.Text == "R" || txtVatInvoice.Text == "S")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are R-Retail,V-Vat,S-Stock Transfer");
                txtVatInvoice.Focus();
            }
        }

        private void txtCForm_Validating(object sender, CancelEventArgs e)
        {
            if (txtCForm.Text == "Y" || txtCForm.Text == "N")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Y,N");
                txtCForm.Focus();
            }
        }

        private void txtLCTag_Validating(object sender, CancelEventArgs e)
        {
            if (txtLCTag.Text == "L" || txtLCTag.Text == "C")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are L-Local,C-Central");
                txtLCTag.Focus();
            }
        }
    }
}