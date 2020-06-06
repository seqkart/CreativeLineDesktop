using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmUnsoldMstAdd : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        int rowindex;
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        public String OldAgainstInvNo { get; set; }
        public DateTime OldAgainstInvDate { get; set; }

        public frmUnsoldMstAdd()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
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
            if (txtRouteCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route");
                txtRouteCode.Focus();
                return false;
            }
            if (txtRouteName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route Name");
                txtRouteCode.Focus();
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
            if (txtSmCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid SalesMan Name");
                txtSmCode.Focus();
                return false;
            }
            if (txtSMName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid SalesMan Name");
                txtSmCode.Focus();
                return false;
            }
            if (txtDealerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Name");
                txtDealerCode.Focus();
                return false;
            }
            if (txtDealerName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Name");
                txtDealerCode.Focus();
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
                ProjectFunctions.SpeakError("Please Enter Product Quantity");
                txtProductQty.Focus();
                return false;
            }

            if (txtRdc.Text.Length == 0)
            {
                txtRdc.Text = "0";
            }

            if (txtfree.Text.Length == 0)
            {
                txtfree.Text = "0";
            }
            if (Convert.ToDecimal(txtProductRate.Text) == 0)
            {
                ProjectFunctions.SpeakError("Product Rate Cannot Be Zero");
                txtProductRate.Focus();
                return false; ;
            }
            if (Convert.ToDecimal(txtProductQty.Text) == 0)
            {
                ProjectFunctions.SpeakError("Product Quantity Cannot Be Zero");
                txtProductQty.Focus();
                return false;
            }
            return true;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            //if (ValidateData())
            //{
            //    InfoGrid.RefreshDataSource();
            //    var str = "Exec [sp_LoadTaxMstForPrdRateCalc] @VatInvoice='" + txtInvoiceType.Text.Trim() + "',";
            //    str = str + "@LCtag='" + txtLCTag.Text.Trim() + "',";
            //    str = str + "@CForm='" + txtCForm.Text.Trim() + "',";
            //    str = str + "@ProductCode='" + txtProductCode.Text.Trim() + "'";
            //    DataSet ds = ProjectFunctions.GetDataSet(str);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        Tuple<decimal, decimal, decimal> myresult;
            //        myresult = ProjectFunctions.TaxCalculatioData(Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]), Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]), Convert.ToDecimal(txtProductQty.Text), Convert.ToDecimal(txtProductRate.Text), Convert.ToDecimal(txtRdc.Text), Convert.ToDecimal("0"), Convert.ToDecimal("0"));
            //        if (BtnOK.Text.ToUpper() == "&OK")
            //        {
            //            InfoGrid.RefreshDataSource();
            //            var dr = dt.NewRow();
            //            dr["IdPrdCode"] = Convert.ToDecimal(txtProductCode.Text);
            //            dr["IdPrdAsgnCode"] = txtProductACode.Text;
            //            dr["IdPrdQty"] = Convert.ToDecimal(txtProductQty.Text);
            //            dr["IdPrdRate"] = Convert.ToDecimal(txtProductRate.Text);
            //            dr["IdDiscRate"] = Convert.ToDecimal(txtRdc.Text);
            //            dr["IdPrdAmt"] = myresult.Item1;
            //            dr["IdTxbAmt"] = myresult.Item1;
            //            dr["IdTaxAmt"] = myresult.Item2;
            //            dr["IdPrdTaxCode"] = ds.Tables[0].Rows[0]["TaxCode"].ToString();
            //            dr["IdTaxRate"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]);
            //            dr["IdSTaxAmt"] = myresult.Item3;
            //            dr["IdSTaxRate"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]);
            //            dr["dealerName"] = txtDealerName.Text;
            //            dr["PrdName"] = txtProductName.Text;
            //            dr["IdPrdQtyF"] = Convert.ToDecimal(txtfree.Text);

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
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdDealerCode"], txtDealerCode.Text);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdAsgnCode"], txtProductACode.Text);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["PrdName"], txtProductName.Text);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdQty"], Convert.ToDecimal(txtProductQty.Text));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdQtyF"], Convert.ToDecimal(txtfree.Text));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdDiscRate"], Convert.ToDecimal(txtRdc.Text));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdAmt"], myresult.Item1);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["dealerName"], txtDealerName.Text);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdCode"], Convert.ToDecimal(txtProductCode.Text));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdTaxCode"], ds.Tables[0].Rows[0]["TaxCode"]);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdTxbAmt"], myresult.Item1);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdTaxAmt"], myresult.Item2);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdSTaxAmt"], myresult.Item3);
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdSTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]));
            //            InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["IdPrdRate"], Convert.ToDecimal(txtProductRate.Text));
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
        private void clear()
        {
            BtnOK.Text = "&OK";
            txtProductACode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductQty.Text = string.Empty;
            txtProductRate.Text = string.Empty;
            txtRdc.Text = string.Empty;
            txtfree.Text = string.Empty;
            txtProductACode.Focus();
        }
        private void calculation()
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                InfoGridView.PostEditor();
                InfoGridView.UpdateCurrentRow();
            }));
            txtValueOfGoods.Text = Convert.ToDecimal(gridColumn18.SummaryItem.SummaryValue).ToString("0.00");
            txtTaxableAmount.Text = Convert.ToDecimal(gridColumn18.SummaryItem.SummaryValue).ToString("0.00");
            txtTaxAmount.Text = Convert.ToDecimal(gridColumn19.SummaryItem.SummaryValue).ToString("0.00");
            txtSurcharge.Text = Convert.ToDecimal(gridColumn21.SummaryItem.SummaryValue).ToString("0.00");
            txtNetAmount.Text = (Convert.ToDecimal(txtTaxableAmount.Text) + Convert.ToDecimal(txtTaxAmount.Text) + Convert.ToDecimal(txtSurcharge.Text)).ToString("0.00");

            txtRNetAmount.Text = Math.Round(Convert.ToDecimal(txtNetAmount.Text), 2).ToString("0.00");
        }
        private void txtAgainstInvNo_EditValueChanged(object sender, EventArgs e)
        {
            txtAgainstInvDate.Text = string.Empty;
        }

        private void txtAgainstInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes(" Select ImNo,ImDate from InvoiceMst Where ImDate<='" + Convert.ToDateTime(dtInvoiceDate.Text).AddDays(-10).ToString("yyyy-MM-dd") + "'", string.Empty, txtAgainstInvNo, txtAgainstInvDate, txtProductACode, HelpGrid, HelpGridView, e);

            }
            e.Handled = true;
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
            if (txtRouteCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route");
                txtRouteCode.Focus();
                return false;
            }
            if (txtRouteName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route Name");
                txtRouteCode.Focus();
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
            if (txtSmCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid SalesMan Name");
                txtSmCode.Focus();
                return false;
            }
            if (txtSMName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid SalesMan Name");
                txtSmCode.Focus();
                return false;
            }
            if (txtDealerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Name");
                txtDealerCode.Focus();
                return false;
            }
            if (txtDealerName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Name");
                txtDealerCode.Focus();
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
                ProjectFunctions.SpeakError("Please Enter Product Quantity");
                txtProductQty.Focus();
                return false;
            }


            if (txtRdc.Text.Length == 0)
            {
                txtRdc.Text = "0";
            }

            if (txtfree.Text.Length == 0)
            {
                txtfree.Text = "0";
            }
            if (Convert.ToDecimal(txtProductRate.Text) == 0)
            {
                ProjectFunctions.SpeakError("Product Rate Cannot Be Zero");
                txtProductRate.Focus();
                return false; ;
            }
            if (Convert.ToDecimal(txtProductQty.Text) == 0)
            {
                ProjectFunctions.SpeakError("Product Quantity Cannot Be Zero");
                txtProductQty.Focus();
                return false;
            }
            return true;
        }
        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtAgainstInvNo")
            {
                txtAgainstInvNo.Text = row["ImNo"].ToString();
                txtAgainstInvDate.Text = row["ImDate"].ToString();


                DataSet ds = ProjectFunctions.GetDataSet("SELECT     InvoiceMst.ImSalesManCode, ActMst.AccName AS SalesManName, InvoiceMst.ImPartyCode, ActMst_1.AccName  as PartyName ,  InvoiceMst.ImRouteCode, RouteMst.RouteDesc, InvoiceMst.ImLC, InvoiceMst.ImInvTypeHead, InvoiceMst.ImDealerCode, dealerMaster.dealerName, InvoiceMst.ImCForm FROM         InvoiceMst INNER JOIN ActMst ON InvoiceMst.ImSalesManCode = ActMst.AccCode INNER JOIN ActMst AS ActMst_1 ON InvoiceMst.ImPartyCode = ActMst_1.AccCode INNER JOIN  RouteMst ON InvoiceMst.ImRouteCode = RouteMst.RouteCode INNER JOIN dealerMaster ON InvoiceMst.ImDealerCode = dealerMaster.dealerCode");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSmCode.Text = ds.Tables[0].Rows[0]["ImSalesManCode"].ToString();
                    txtSMName.Text = ds.Tables[0].Rows[0]["SalesManName"].ToString();
                    txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
                    txtDebitPartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                    txtRouteCode.Text = ds.Tables[0].Rows[0]["ImRouteCode"].ToString();
                    txtRouteName.Text = ds.Tables[0].Rows[0]["RouteDesc"].ToString();
                    txtLCTag.Text = ds.Tables[0].Rows[0]["ImLC"].ToString();
                    txtInvoiceType.Text = ds.Tables[0].Rows[0]["ImInvTypeHead"].ToString();
                    txtDealerCode.Text = ds.Tables[0].Rows[0]["ImDealerCode"].ToString();
                    txtDealerName.Text = ds.Tables[0].Rows[0]["dealerName"].ToString();
                    txtCForm.Text = ds.Tables[0].Rows[0]["ImCForm"].ToString();

                }

                HelpGrid.Visible = false;
                txtProductACode.Focus();
            }

            if (HelpGrid.Text == "txtProductACode")
            {
                txtProductACode.Text = row["PrdAsgnCode"].ToString();
                txtProductCode.Text = row["IdPrdCode"].ToString();
                txtProductName.Text = row["PrdName"].ToString();
                txtProductRate.Text = row["IdPrdRate"].ToString();
                txtRdc.Text = row["IdDiscRate"].ToString();
                txtSchmQty.Text = row["IdSchmQty"].ToString();
                txtSchmQtyF.Text = row["IdSchmQtyF"].ToString();
                HelpGrid.Visible = false;
                txtProductQty.Focus();
            }
        }

        private void txtProductACode_EditValueChanged(object sender, EventArgs e)
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtRdc.Text = string.Empty;
            txtfree.Text = string.Empty;
            txtProductRate.Text = string.Empty;
            txtSchmQty.Text = string.Empty;
            txtSchmQtyF.Text = string.Empty;
        }

        private void txtProductACode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid.Text = "txtProductACode";
                if (txtProductACode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT     InvoiceData.IdPrdCode, PrdMst.PrdAsgnCode, PrdMst.PrdName, InvoiceData.IdPrdRate, InvoiceData.IdDiscRate,InvoiceData.IdSchmQty,InvoiceData.IdSchmQtyF FROM         InvoiceData INNER JOIN PrdMst ON InvoiceData.IdPrdCode = PrdMst.PrdCode Where IdType='S' And IdDate='" + Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd") + "' And IdNo='" + txtAgainstInvNo.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGrid.Visible = true;
                        HelpGrid.Focus();
                        HelpGridView.BestFitColumns();
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("No Record To Display");
                        txtProductACode.Focus();
                    }
                }
                else
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT     InvoiceData.IdPrdCode, PrdMst.PrdAsgnCode, PrdMst.PrdName, InvoiceData.IdPrdRate, InvoiceData.IdDiscRate,InvoiceData.IdSchmQty,InvoiceData.IdSchmQtyF FROM         InvoiceData INNER JOIN PrdMst ON InvoiceData.IdPrdCode = PrdMst.PrdCode Where IdType='S' And IdDate='" + Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd") + "' And IdNo='" + txtAgainstInvNo.Text.Trim() + "' And PrdAsgnCode='" + txtProductACode.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtProductACode.Text = ds.Tables[0].Rows[0]["PrdAsgnCode"].ToString();
                        txtProductCode.Text = ds.Tables[0].Rows[0]["IdPrdCode"].ToString();
                        txtProductName.Text = ds.Tables[0].Rows[0]["PrdName"].ToString();
                        txtProductRate.Text = ds.Tables[0].Rows[0]["IdPrdRate"].ToString();
                        txtRdc.Text = ds.Tables[0].Rows[0]["IdDiscRate"].ToString();
                        txtSchmQty.Text = ds.Tables[0].Rows[0]["IdSchmQty"].ToString();
                        txtSchmQtyF.Text = ds.Tables[0].Rows[0]["IdSchmQtyF"].ToString();
                        txtProductQty.Focus();
                    }
                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("SELECT     InvoiceData.IdPrdCode, PrdMst.PrdAsgnCode, PrdMst.PrdName, InvoiceData.IdPrdRate, InvoiceData.IdDiscRate,InvoiceData.IdSchmQty,InvoiceData.IdSchmQtyF FROM         InvoiceData INNER JOIN PrdMst ON InvoiceData.IdPrdCode = PrdMst.PrdCode Where IdType='S' And IdDate='" + Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd") + "' And IdNo='" + txtAgainstInvNo.Text.Trim() + "'");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            HelpGrid.DataSource = ds1.Tables[0];
                            HelpGrid.Visible = true;
                            HelpGrid.Focus();
                            HelpGridView.BestFitColumns();
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("No Record To Display");
                            txtProductACode.Focus();
                        }
                    }
                }
            }
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
                txtProductCode.Text = row["IdPrdCode"].ToString();
                txtProductACode.Text = row["IdPrdAsgnCode"].ToString();
                txtProductName.Text = row["PrdName"].ToString();
                txtProductQty.Text = row["IdPrdQty"].ToString();
                txtfree.Text = row["IdPrdQtyF"].ToString();
                txtRdc.Text = row["IdDiscRate"].ToString();
                txtProductRate.Text = row["IdPrdRate"].ToString();
                txtDealerCode.Focus();
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
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
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {

                            sqlcom.CommandText = " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  Begin Transaction "
                                                    + " Insert into InvoiceMst"
                                                    + " (@ImNo,@ImType,@ImFYear,@ImDate,@ImSalesManCode,@ImPartyCode,@ImRouteCode,"
                                                    + " @ImTotQty,@ImVogAmt,@ImRcds,@ImTxbAmt,@ImTaxAmt,@ImSTaxAmt,@ImNetAmt,@ImNetAmtRO,"
                                                    + " @ImLC,@ImCForm,@ImInvTypeHead)"
                                                    + " values((SELECT RIGHT('000000'+ CAST( ISNULL( max(Cast(ImNo as int)),0)+1 AS VARCHAR(6)),6) from InvoiceMst),@ImType,@ImFYear,@ImDate,@ImSalesManCode,@ImPartyCode,@ImRouteCode,"
                                                    + " @ImTotQty,@ImVogAmt,@ImRcds,@ImTxbAmt,@ImTaxAmt,@ImSTaxAmt,@ImNetAmt,@ImNetAmtRO,"
                                                    + " @ImLC,@ImCForm,@ImInvTypeHead)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE dealerMaster SET "
                                                + " ImFYear=@ImFYear,ImSalesManCode=@ImSalesManCode,ImPartyCode=@ImPartyCode,ImTotQty=@ImTotQty, "
                                                + " ImVogAmt=@ImVogAmt,ImRcds=@ImRcds,ImTxbAmt=@ImTxbAmt,ImTaxAmt=@ImTaxAmt, "
                                                + " ImSTaxAmt=@ImSTaxAmt,ImNetAmt=@ImNetAmt,ImNetAmtRO=@ImNetAmtRO,ImLC=@ImLC,ImCForm=@ImCForm, "
                                                + " ImInvTypeHead=@ImInvTypeHead "
                                                + " Where dealerCode=@dealerCode";
                        }
                        sqlcom.Parameters["@ImNo"].Direction = ParameterDirection.InputOutput;
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "S";
                        sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                        sqlcom.Parameters.Add("@ImSalesManCode", SqlDbType.NVarChar).Value = txtSmCode.Text.Trim();
                        sqlcom.Parameters.Add("@ImPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                        sqlcom.Parameters.Add("@ImRouteCode", SqlDbType.NVarChar).Value = txtRouteCode.Text.Trim();
                        sqlcom.Parameters.Add("@ImTotQty", SqlDbType.Decimal).Value = Convert.ToDecimal(gridColumn4.SummaryItem.SummaryValue).ToString("0.00");
                        sqlcom.Parameters.Add("@ImVogAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxableAmount.Text);
                        sqlcom.Parameters.Add("@ImRcds", SqlDbType.Decimal).Value = Convert.ToDecimal(gridColumn2.SummaryItem.SummaryValue).ToString("0.00");
                        sqlcom.Parameters.Add("@ImTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxableAmount.Text);
                        sqlcom.Parameters.Add("@ImTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTaxAmount.Text);
                        sqlcom.Parameters.Add("@ImSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSurcharge.Text);
                        sqlcom.Parameters.Add("@ImNetAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtNetAmount.Text);
                        sqlcom.Parameters.Add("@ImNetAmtRO", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRNetAmount.Text);
                        sqlcom.Parameters.Add("@ImLC", SqlDbType.NVarChar).Value = txtLCTag.Text.Trim();
                        sqlcom.Parameters.Add("@ImCForm", SqlDbType.NVarChar).Value = txtCForm.Text;
                        sqlcom.Parameters.Add("@ImInvTypeHead", SqlDbType.NVarChar).Value = txtInvoiceType.Text;
                        sqlcom.ExecuteNonQuery();
                        txtSerialNo.Text = sqlcom.Parameters["@ImNo"].Value.ToString();
                        sqlcom.Parameters.Clear();



                        sqlcom.CommandText = "Delete from UsDataData Where IdNo=@IdNo And IdDate=@IdDate And IdType='S'";
                        sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();


                        for (var i = 0; i < MaxRow; i++)
                        {
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into UsDataData "
                                                        + " (@IdFyear,@IdType,@IdNo,@IdDate,@IdSalesManCode,@IdPartyCode,@IdRouteCode,"
                                                        + " @IdDealerCode,@IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                        + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,IdSTaxAmt,IdSTaxRate)"
                                                        + " values(@IdFyear,@IdType,@IdNo,@IdDate,@IdSalesManCode,@IdPartyCode,@IdRouteCode,"
                                                        + " @IdDealerCode,@IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                        + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,IdSTaxAmt,IdSTaxRate)";


                            sqlcom.Parameters.Add("@IdFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@IdType", SqlDbType.NVarChar).Value = "S";
                            sqlcom.Parameters.Add("@IdCat", SqlDbType.NVarChar).Value = string.Empty;
                            sqlcom.Parameters.Add("@IdNoSeries", SqlDbType.NVarChar).Value = txtserial.Text.Trim();
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IdSalesManCode", SqlDbType.NVarChar).Value = txtSmCode.Text.Trim();
                            sqlcom.Parameters.Add("@IdPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@IdRouteCode", SqlDbType.NVarChar).Value = txtRouteCode.Text.Trim();
                            sqlcom.Parameters.Add("@IdDealerCode", SqlDbType.NVarChar).Value = currentrow["IdDealerCode"].ToString();
                            sqlcom.Parameters.Add("@IdPrdCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdCode"]);
                            sqlcom.Parameters.Add("@IdPrdAsgnCode", SqlDbType.NVarChar).Value = currentrow["IdPrdAsgnCode"].ToString();
                            sqlcom.Parameters.Add("@IdPrdQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQty"]);
                            sqlcom.Parameters.Add("@IdPrdQtyF", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQtyF"]);
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
                        if (OldAgainstInvNo.Trim().Length > 0)
                        {
                            sqlcom.CommandText = "Update InvoiceMst Set ImTypeA=null,ImNoA=null,ImDateA=null Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = OldAgainstInvNo;
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = OldAgainstInvDate.Date.ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }

                        sqlcom.CommandText = "Update InvoiceMst Set ImTypeA='US',ImNoA=@ImNoA,ImDateA=@ImDateA Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                        sqlcom.Parameters.Add("@ImNoA", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDateA", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();


                        sqlcom.CommandText = "Update USDataMst Set IminNo=@IminNo,IminDate=@IminDate  Where USDataMst.ImNo=@ImNo And And USDataMst.ImDate=@ImDate And ImType='S'";
                        sqlcom.Parameters.Add("@IminNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@IminDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
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
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from usdatamst Where ImType='S'  And  ImFyear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void frmUnsoldMstAdd_KeyDown(object sender, KeyEventArgs e)
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

        private void frmUnsoldMstAdd_Load(object sender, EventArgs e)
        {
            if (s1 == "&Add")
            {
                txtAgainstInvNo.Focus();
                txtserial.Text = "S";
                txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');

            }
            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet("[LoadUnSoldDataForEditing] @InvDate='" + ImDate.Date.ToString("yyyy-MM-dd") + "',@Imno='" + ImNo + "'");
                txtInvoiceType.Text = ds.Tables[0].Rows[0]["ImInvTypeHead"].ToString();
                dtInvoiceDate.Text = ds.Tables[0].Rows[0]["ImDate"].ToString();
                txtSmCode.Text = ds.Tables[0].Rows[0]["ImSalesManCode"].ToString();
                txtSMName.Text = ds.Tables[0].Rows[0]["SMName"].ToString();
                txtRouteCode.Text = ds.Tables[0].Rows[0]["ImRouteCode"].ToString();
                txtRouteName.Text = ds.Tables[0].Rows[0]["RouteDesc"].ToString();
                txtNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmt"].ToString();
                txtRNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmtRO"].ToString();
                txtTaxableAmount.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                txtTaxAmount.Text = ds.Tables[0].Rows[0]["ImTaxAmt"].ToString();
                txtSurcharge.Text = ds.Tables[0].Rows[0]["ImSTaxAmt"].ToString();
                txtValueOfGoods.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
                txtDebitPartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                txtSUSType.Text = ds.Tables[0].Rows[0]["ImType"].ToString();
                txtserial.Text = ds.Tables[0].Rows[0]["ImNoSeries"].ToString();
                txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
                txtLCTag.Text = ds.Tables[0].Rows[0]["ImLC"].ToString();
                txtCForm.Text = ds.Tables[0].Rows[0]["ImCForm"].ToString();
                txtRouteCode.Text = ds.Tables[0].Rows[0]["ImRouteCode"].ToString();
                txtRouteName.Text = ds.Tables[0].Rows[0]["RouteDesc"].ToString();
                txtVatInvoice.Text = ds.Tables[0].Rows[0]["ImVRTag"].ToString();
                txtAgainstInvNo.Text = ds.Tables[0].Rows[0]["IminNo"].ToString();
                txtAgainstInvDate.Text = ds.Tables[0].Rows[0]["IminDate"].ToString();
                OldAgainstInvDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["IminDate"]);
                OldAgainstInvNo = ds.Tables[0].Rows[0]["IminNo"].ToString();

                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
                InfoGridView.BestFitColumns();
            }
        }
    }
}
