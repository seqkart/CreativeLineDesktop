using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmReplMstAdd : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        DataTable dt = new DataTable();
#pragma warning disable CS0169 // The field 'frmReplMstAdd.rowindex' is never used
        int rowindex;
#pragma warning restore CS0169 // The field 'frmReplMstAdd.rowindex' is never used
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }

        public String OldAgainstInvNo = string.Empty;
        public DateTime OldAgainstInvDate { get; set; }

        public String FormValue { get; set; }

        public frmReplMstAdd()
        {
            InitializeComponent();
            dt.Columns.Add("IdPrdCode", typeof(Decimal));
            dt.Columns.Add("IdPrdAsgnCode", typeof(String));
            dt.Columns.Add("PrdName", typeof(String));
            dt.Columns.Add("IdPrdQty", typeof(Decimal));
            dt.Columns.Add("IdPrdQtyF", typeof(Decimal));
            dt.Columns.Add("IdPrdRate", typeof(Decimal));
            dt.Columns.Add("IdDiscRate", typeof(Decimal));
            dt.Columns.Add("IdPrdAmt", typeof(Decimal));
            dt.Columns.Add("IdTxbAmt", typeof(Decimal));
            dt.Columns.Add("IdTaxAmt", typeof(Decimal));
            dt.Columns.Add("IdPrdTaxCode", typeof(String));
            dt.Columns.Add("IdSchmQty", typeof(Decimal));
            dt.Columns.Add("IdSchmQtyF", typeof(Decimal));
            dt.Columns.Add("IdCGSTRate", typeof(Decimal));
            dt.Columns.Add("IdSGSTRate", typeof(Decimal));
            dt.Columns.Add("IdIGSTRate", typeof(Decimal));
            dt.Columns.Add("IdCGSTAmount", typeof(Decimal));
            dt.Columns.Add("IdSGSTAmount", typeof(Decimal));
            dt.Columns.Add("IdIGSTAmount", typeof(Decimal));
            dt.Columns.Add("OrdDNo", typeof(String));

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
        private void calculation()
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                InfoGridView.PostEditor();
                InfoGridView.UpdateCurrentRow();
            }));
            txtValueOfGoods.Text = Convert.ToDecimal(gridColumn18.SummaryItem.SummaryValue).ToString("0.00");
            txtCGST.Text = Convert.ToDecimal(gridColumn18.SummaryItem.SummaryValue).ToString("0.00");
            txtSGST.Text = Convert.ToDecimal(gridColumn19.SummaryItem.SummaryValue).ToString("0.00");
            txtIGST.Text = Convert.ToDecimal(gridColumn21.SummaryItem.SummaryValue).ToString("0.00");
            txtNetAmount.Text = (Convert.ToDecimal(txtCGST.Text) + Convert.ToDecimal(txtSGST.Text) + Convert.ToDecimal(txtIGST.Text)).ToString("0.00");

            txtRNetAmount.Text = Math.Round(Convert.ToDecimal(txtNetAmount.Text), 2).ToString("0.00");
        }



        private void PrepareInfoGrid()
        {
            InfoGridView.Columns.Clear();
            InfoGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            InfoGridView.Columns[0].Visible = true;
            InfoGridView.Columns[0].Caption = "ImNo";
            InfoGridView.Columns[0].FieldName = "ImNo";
            InfoGridView.Columns[0].OptionsColumn.AllowEdit = false;
            InfoGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            InfoGridView.Columns[1].Visible = true;
            InfoGridView.Columns[1].Caption = "ImDate";
            InfoGridView.Columns[1].FieldName = "ImDate";
            InfoGridView.Columns[1].OptionsColumn.AllowEdit = false;

            InfoGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            InfoGridView.Columns[2].Visible = true;
            InfoGridView.Columns[2].Caption = "PartyCode";
            InfoGridView.Columns[2].FieldName = "ImPartyCode";
            InfoGridView.Columns[2].OptionsColumn.AllowEdit = false;

            InfoGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            InfoGridView.Columns[3].Visible = true;
            InfoGridView.Columns[3].Caption = "PartyName";
            InfoGridView.Columns[3].FieldName = "AccName";
            InfoGridView.Columns[3].OptionsColumn.AllowEdit = false;

            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[4].Visible = true;
            HelpGridView.Columns[4].Caption = "DocNo";
            HelpGridView.Columns[4].FieldName = "ImRDocNo";
            HelpGridView.Columns[4].OptionsColumn.AllowEdit = false;

            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[5].Visible = true;
            HelpGridView.Columns[5].Caption = "DocDate";
            HelpGridView.Columns[5].FieldName = "ImRDocDate";
            HelpGridView.Columns[5].OptionsColumn.AllowEdit = false;

            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[6].Visible = true;
            HelpGridView.Columns[6].Caption = "NetAmt";
            HelpGridView.Columns[6].FieldName = "ImNetAmt";
            HelpGridView.Columns[6].OptionsColumn.AllowEdit = false;
        }

        private void PrepareAddEditForm()
        {
            if (FormValue == "S")
            {
                txtAgainstInvDate.Visible = false;
                txtAgainstInvDate.TabStop = false;
                txtAgainstInvNo.Visible = false;
                txtAgainstInvNo.TabStop = false;
                btnLoadOrder.Visible = true;
                txtOrderNo.Visible = true;
                txtOrderNo.Enabled = false;



                txtDebitPartyCode.Enabled = true;

                txtInvoiceType.Enabled = true;


                txtInvoiceType.TabStop = true;


            }
            if (FormValue == "RP")
            {
                txtAgainstInvDate.Visible = true;
                txtAgainstInvDate.TabStop = false;
                txtAgainstInvNo.Visible = true;
                txtAgainstInvNo.TabStop = true;
                btnLoadOrder.Visible = false;
                txtOrderNo.Visible = false;

                txtAgainstInvDate.Enabled = false;

                txtDebitPartyCode.Enabled = false;

                txtInvoiceType.Enabled = false;

            }
            if (FormValue == "US")
            {
                txtAgainstInvDate.Visible = true;
                txtAgainstInvDate.TabStop = false;
                txtAgainstInvNo.Visible = true;
                txtAgainstInvNo.TabStop = true;
                btnLoadOrder.Visible = false;
                txtOrderNo.Visible = false;


                txtAgainstInvDate.Enabled = false;

                txtDebitPartyCode.Enabled = false;

                txtInvoiceType.Enabled = false;

            }
        }
        private void frmReplMstAdd_Load(object sender, EventArgs e)
        {
            SetMyControls();
            PrepareAddEditForm();
            if (FormValue == "RP")
            {
                if (s1 == "&Add")
                {
                    txtAgainstInvNo.Focus();
                    dtInvoiceDate.EditValue = DateTime.Now;
                    txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadRplDataForEditing] '" + ImDate.Date.ToString("yyyy-MM-dd") + "','" + ImNo + "'");
                    txtInvoiceType.Text = ds.Tables[0].Rows[0]["ImInvTypeHead"].ToString();
                    txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
                    dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ImDate"]);
                    txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
                    txtDebitPartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                    txtNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmt"].ToString();
                    txtRNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmtRO"].ToString();
                    txtCGST.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                    txtSGST.Text = ds.Tables[0].Rows[0]["ImTaxAmt"].ToString();
                    txtIGST.Text = ds.Tables[0].Rows[0]["ImSTaxAmt"].ToString();
                    txtValueOfGoods.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                    txtLCTag.Text = ds.Tables[0].Rows[0]["ImLC"].ToString();
                    txtAgainstInvNo.Text = ds.Tables[0].Rows[0]["IminNo"].ToString();
                    txtAgainstInvDate.Text = ds.Tables[0].Rows[0]["IminDate"].ToString();
                    OldAgainstInvDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["IminDate"]);
                    OldAgainstInvNo = ds.Tables[0].Rows[0]["IminNo"].ToString();
                    txtVehicleCode.Text = ds.Tables[0].Rows[0]["ImVehCode"].ToString();
                    txtVehicleDesc.Text = ds.Tables[0].Rows[0]["VehicleRegNo"].ToString();
                    dt = ds.Tables[1];
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                }
            }
            if (FormValue == "US")
            {
                if (s1 == "&Add")
                {
                    txtAgainstInvNo.Focus();
                    dtInvoiceDate.EditValue = DateTime.Now;
                    txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadUnsoldDataForEditing] '" + ImDate.Date.ToString("yyyy-MM-dd") + "','" + ImNo + "'");
                    txtInvoiceType.Text = ds.Tables[0].Rows[0]["ImInvTypeHead"].ToString();
                    txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
                    dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ImDate"]);
                    txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
                    txtDebitPartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                    txtNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmt"].ToString();
                    txtRNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmtRO"].ToString();
                    txtCGST.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                    txtSGST.Text = ds.Tables[0].Rows[0]["ImTaxAmt"].ToString();
                    txtIGST.Text = ds.Tables[0].Rows[0]["ImSTaxAmt"].ToString();
                    txtValueOfGoods.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                    txtLCTag.Text = ds.Tables[0].Rows[0]["ImLC"].ToString();
                    txtAgainstInvNo.Text = ds.Tables[0].Rows[0]["IminNo"].ToString();
                    txtAgainstInvDate.Text = ds.Tables[0].Rows[0]["IminDate"].ToString();
                    OldAgainstInvDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["IminDate"]);
                    OldAgainstInvNo = ds.Tables[0].Rows[0]["IminNo"].ToString();
                    txtVehicleCode.Text = ds.Tables[0].Rows[0]["ImVehCode"].ToString();
                    txtVehicleDesc.Text = ds.Tables[0].Rows[0]["VehicleRegNo"].ToString();
                    dt = ds.Tables[1];
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                }
            }
            if (FormValue == "S")
            {
                if (s1 == "&Add")
                {
                    txtInvoiceType.Focus();
                    dtInvoiceDate.EditValue = DateTime.Now;
                    txtSerialNo.Text = getNewInvoiceDocumentNo().PadLeft(6, '0');
                }
                if (s1 == "Edit")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadInvoiceDataForEditing] '" + ImDate.Date.ToString("yyyy-MM-dd") + "','" + ImNo + "'");
                    txtInvoiceType.Text = ds.Tables[0].Rows[0]["ImInvTypeHead"].ToString();
                    txtSerialNo.Text = ds.Tables[0].Rows[0]["ImNo"].ToString();
                    dtInvoiceDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ImDate"]);
                    txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
                    txtDebitPartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                    txtNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmt"].ToString();
                    txtRNetAmount.Text = ds.Tables[0].Rows[0]["ImNetAmtRO"].ToString();
                    txtCGST.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                    txtSGST.Text = ds.Tables[0].Rows[0]["ImTaxAmt"].ToString();
                    txtIGST.Text = ds.Tables[0].Rows[0]["ImSTaxAmt"].ToString();
                    txtValueOfGoods.Text = ds.Tables[0].Rows[0]["ImTxbAmt"].ToString();
                    txtLCTag.Text = ds.Tables[0].Rows[0]["ImLC"].ToString();
                    txtAgainstInvNo.Text = ds.Tables[0].Rows[0]["IminNo"].ToString();
                    txtAgainstInvDate.Text = ds.Tables[0].Rows[0]["IminDate"].ToString();
                    OldAgainstInvDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["IminDate"]);
                    OldAgainstInvNo = ds.Tables[0].Rows[0]["IminNo"].ToString();

                    txtOrderNo.Text = ds.Tables[0].Rows[0]["ImOrderNo"].ToString();
                    txtVehicleCode.Text = ds.Tables[0].Rows[0]["ImVehCode"].ToString();
                    txtVehicleDesc.Text = ds.Tables[0].Rows[0]["VehicleRegNo"].ToString();
                    dt = ds.Tables[1];
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                }
            }
        }

        private void txtAgainstInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes(" SELECT     InvoiceMst.ImNo, InvoiceMst.ImDate, InvoiceMst.ImDealerCode, dealerMaster.dealerName FROM         InvoiceMst INNER JOIN dealerMaster ON InvoiceMst.ImDealerCode = dealerMaster.dealerCode Where ImDate>='" + Convert.ToDateTime(dtInvoiceDate.Text).AddDays(-10).ToString("yyyy-MM-dd") + "'", string.Empty, txtAgainstInvNo, txtAgainstInvDate, txtAgainstInvNo, HelpGrid, HelpGridView, e);

            }
            e.Handled = true;
        }
        private string getNewInvoiceDocumentNo()
        {
            var s2 = string.Empty;
            DataSet ds = new DataSet();
            if (FormValue == "RP")
            {
                ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from RplDataMst Where ImType='S'  And  ImFyear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "'");
            }
            if (FormValue == "US")
            {
                ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from USDataMst Where ImType='S'  And  ImFyear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "'");
            }
            if (FormValue == "S")
            {
                ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(imno as int)),000000) from InvoiceMst Where ImType='S'  And  ImFyear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "'");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }
        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtAgainstInvNo")
            {
                txtAgainstInvNo.Text = row["ImNo"].ToString();
                txtAgainstInvDate.Text = row["ImDate"].ToString();
                DataSet ds = ProjectFunctions.GetDataSet("SELECT     InvoiceMst.ImSalesManCode, ActMst.AccName AS SalesManName, InvoiceMst.ImPartyCode, ActMst_1.AccName  as PartyName ,  InvoiceMst.ImRouteCode, RouteMst.RouteDesc, InvoiceMst.ImLC, InvoiceMst.ImInvTypeHead, InvoiceMst.ImDealerCode, dealerMaster.dealerName, InvoiceMst.ImCForm,InvoiceMst.ImVRTag FROM         InvoiceMst INNER JOIN ActMst ON InvoiceMst.ImSalesManCode = ActMst.AccCode INNER JOIN ActMst AS ActMst_1 ON InvoiceMst.ImPartyCode = ActMst_1.AccCode INNER JOIN  RouteMst ON InvoiceMst.ImRouteCode = RouteMst.RouteCode INNER JOIN dealerMaster ON InvoiceMst.ImDealerCode = dealerMaster.dealerCode");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["ImPartyCode"].ToString();
                    txtDebitPartyName.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                    txtLCTag.Text = ds.Tables[0].Rows[0]["ImLC"].ToString();
                    txtInvoiceType.Text = ds.Tables[0].Rows[0]["ImInvTypeHead"].ToString();

                    HelpGrid.Visible = false;
                    LoadProducts();
                }
            }

            if (HelpGrid.Text == "txtDebitPartyCode")
            {
                txtDebitPartyCode.Text = row["AccCode"].ToString();
                txtDebitPartyName.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtLCTag.Focus();

            }

            if (HelpGrid.Text == "txtVehicleCode")
            {
                txtVehicleCode.Text = row["VehicleCode"].ToString();
                txtVehicleDesc.Text = row["VehicleRegNo"].ToString();
                HelpGrid.Visible = false;
                txtVehicleCode.Focus();
            }
            if (HelpGrid.Text == "btnLoadOrder")
            {
                txtOrderNo.Text = row["OrdNo"].ToString();
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadOrderInInvoice '" + row["OrdNo"].ToString() + "','" + txtDebitPartyCode.Text.Trim() + "'");
                dt = ds.Tables[0];

                InfoGrid.DataSource = dt;
                InfoGridView.BestFitColumns();
                HelpGrid.Visible = false;
            }
        }


        private void LoadProducts()
        {
            DataSet ds = ProjectFunctions.GetDataSet("SELECT     InvoiceData.IdPrdCode, PrdMst.PrdAsgnCode AS IdPrdAsgnCode, PrdMst.PrdName, InvoiceData.IdPrdQty,0 as IdPrdQtyF,0 as IdPrdQtyR, InvoiceData.IdPrdRate, InvoiceData.IdDiscRate, InvoiceData.IdPrdAmt, InvoiceData.IdTxbAmt, InvoiceData.IdTaxAmt, InvoiceData.IdPrdTaxCode, InvoiceData.IdTaxRate, InvoiceData.IdSTaxAmt, InvoiceData.IdSTaxRate, InvoiceData.IdSchmQty, InvoiceData.IdSchmQtyF,0 as IdNetRateR FROM         InvoiceData INNER JOIN PrdMst ON InvoiceData.IdPrdCode = PrdMst.PrdCode Where IdType='S' And Iddate='" + Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd") + "' and IdNo='000001'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                InfoGrid.DataSource = dt;
                InfoGridView.BestFitColumns();
            }
            else
            {
                ProjectFunctions.SpeakError("No Products To Display");
            }
        }


        private void frmReplMstAdd_KeyDown(object sender, KeyEventArgs e)
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


        private bool ValidateGridDataToSave()
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            for (var i = 0; i < MaxRow; i++)
            {
                var row = InfoGridView.GetDataRow(i);
                if (row["IdPrdQty"].ToString().Trim() == string.Empty)
                {
                    row["IdPrdQty"] = Convert.ToDecimal("0");
                }
                if (row["IdPrdQtyF"].ToString().Trim() == string.Empty)
                {
                    row["IdPrdQtyF"] = Convert.ToDecimal("0");
                }

                if (row["IdPrdRate"].ToString().Trim() == string.Empty)
                {
                    row["IdPrdRate"] = Convert.ToDecimal("0");
                }
                if (row["IdDiscRate"].ToString().Trim() == string.Empty)
                {
                    row["IdDiscRate"] = Convert.ToDecimal("0");
                }
                if (row["IdPrdAmt"].ToString().Trim() == string.Empty)
                {
                    row["IdPrdAmt"] = Convert.ToDecimal("0");
                }
                if (row["IdTxbAmt"].ToString().Trim() == string.Empty)
                {
                    row["IdTxbAmt"] = Convert.ToDecimal("0");
                }
                if (row["IdTaxAmt"].ToString().Trim() == string.Empty)
                {
                    row["IdTaxAmt"] = Convert.ToDecimal("0");
                }


                if (row["IdSchmQty"].ToString().Trim() == string.Empty)
                {
                    row["IdSchmQty"] = Convert.ToDecimal("0");
                }
                if (row["IdSchmQtyF"].ToString().Trim() == string.Empty)
                {
                    row["IdSchmQtyF"] = Convert.ToDecimal("0");
                }
            }
            for (var i = 0; i < MaxRow; i++)
            {
                var row = InfoGridView.GetDataRow(i);
                if (Convert.ToDecimal(row["IdPrdQty"]) == Convert.ToDecimal("0"))
                {
                    ProjectFunctions.SpeakError("Product Quantity Cannot Be Zero");
                    return false;
                }
                if (Convert.ToDecimal(row["IdPrdRate"]) == Convert.ToDecimal("0"))
                {
                    ProjectFunctions.SpeakError("Product Rate Cannot Be Zero");
                    return false;
                }
                if (Convert.ToDecimal(row["IdPrdAmt"]) == Convert.ToDecimal("0"))
                {
                    ProjectFunctions.SpeakError("Product Amount Cannot Be Zero");
                    return false;
                }
                if (Convert.ToDecimal(row["IdTxbAmt"]) == Convert.ToDecimal("0"))
                {
                    ProjectFunctions.SpeakError("Taxable Amount Cannot Be Zero");
                    return false;
                }
                if (row["IdPrdTaxCode"].ToString().Trim() == string.Empty)
                {
                    ProjectFunctions.SpeakError("Invalid Tax Code");
                    return false;
                }


            }
            return true;
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
            //for (var i = 0; i < MaxRow; i++)
            //{
            //    var row = InfoGridView.GetDataRow(i);
            //    var ds = new DataSet();
            //    InfoGrid.RefreshDataSource();
            //    ds = ProjectFunctions.GetDataSet("SP_LoadTaxMstForPrdRateCalc '" + txtInvoiceType.Text.Trim() + "','" + txtLCTag.Text.Trim() + "','" + txtCForm.Text.Trim() + "','" + row["IdPrdCode"].ToString() + "'");
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        var currentrow = InfoGridView.GetDataRow(i);
            //        var TempTaxRate = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]) + (Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]) * Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]) / 100);
            //        var TempTax = Convert.ToDecimal(currentrow["IdPrdRate"]) * TempTaxRate / 100;
            //        var TempRate = Math.Round(Convert.ToDecimal(currentrow["IdPrdRate"]) + TempTax, 2);
            //        var NetRate = ProjectFunctions.NetRateCalculation(Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]), Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]), TempRate);

            //        if (FormValue == "S" || FormValue == "US")
            //        {
            //            Tuple<decimal, decimal, decimal> myresult;
            //            myresult = ProjectFunctions.TaxCalculatioData(Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]), Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]), Convert.ToDecimal(row["IdPrdQty"]), NetRate, Convert.ToDecimal(row["IdDiscRate"]), Convert.ToDecimal("0"), Convert.ToDecimal("0"));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdQtyF"], (Convert.ToDecimal(currentrow["IdPrdQty"]) / Convert.ToDecimal(currentrow["IdSchmQty"])) * Convert.ToDecimal(currentrow["IdSchmQtyF"]));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdAmt"], myresult.Item1);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdTaxCode"], ds.Tables[0].Rows[0]["TaxCode"]);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdTxbAmt"], myresult.Item1);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdTaxAmt"], myresult.Item2);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdRate"], NetRate);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdSTaxAmt"], myresult.Item3);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdSTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdNetRateR"], Convert.ToDecimal("0"));
            //            InfoGridView.RefreshData();
            //        }
            //        if (FormValue == "RP")
            //        {

            //            Tuple<decimal, decimal, decimal, decimal> myresult;
            //            myresult = ProjectFunctions.ReplacementTaxCalculatioData(Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]), Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]), Convert.ToDecimal(row["IdPrdQty"]), NetRate, Convert.ToDecimal(row["IdDiscRate"]), Convert.ToDecimal("0"), Convert.ToDecimal("0"), Convert.ToDecimal(row["IdSchmQty"]), Convert.ToDecimal(row["IdSchmQtyF"]), 0);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdQtyF"], (Convert.ToDecimal(currentrow["IdPrdQty"]) / Convert.ToDecimal(currentrow["IdSchmQty"])) * Convert.ToDecimal(currentrow["IdSchmQtyF"]));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdQtyR"], Convert.ToDecimal("0"));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdAmt"], myresult.Item1);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdTaxCode"], ds.Tables[0].Rows[0]["TaxCode"]);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdTxbAmt"], myresult.Item1);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdTaxAmt"], myresult.Item2);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdPrdRate"], NetRate);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"]));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdSTaxAmt"], myresult.Item3);
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdSTaxRate"], Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSRate"]));
            //            InfoGridView.SetRowCellValue(i, InfoGridView.Columns["IdNetRateR"], myresult.Item4);
            //            InfoGridView.RefreshData();
            //        }
            //    }
            //}
            //calculation();

        }
        private bool ValidateData()
        {
            if (txtSerialNo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Invoice No");
                txtSerialNo.Focus();
                return false;
            }
            if (dtInvoiceDate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Invoice Date");
                dtInvoiceDate.Focus();
                return false;
            }
            if (txtLCTag.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid LCtag Value");
                txtLCTag.Focus();
                return false;
            }
            if (txtDebitPartyCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Debit Party");
                txtLCTag.Focus();
                return false;
            }
            if (txtDebitPartyName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Debit Party");
                txtDebitPartyCode.Focus();
                return false;
            }

            return true;
        }



        private void SaveReplData()
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
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        sqlcom.CommandText = "sp_InsertReplDataMst";
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters["@ImNo"].Direction = ParameterDirection.InputOutput;
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "S";
                        sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                        sqlcom.Parameters.Add("@ImPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                        sqlcom.Parameters.Add("@ImTotQty", SqlDbType.Decimal).Value = Convert.ToDecimal(gridColumn4.SummaryItem.SummaryValue).ToString("0.00");
                        sqlcom.Parameters.Add("@ImVogAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        sqlcom.Parameters.Add("@ImTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        sqlcom.Parameters.Add("@ImTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                        sqlcom.Parameters.Add("@ImSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                        sqlcom.Parameters.Add("@ImNetAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtNetAmount.Text);
                        sqlcom.Parameters.Add("@ImNetAmtRO", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRNetAmount.Text);
                        sqlcom.Parameters.Add("@ImLC", SqlDbType.NVarChar).Value = txtLCTag.Text.Trim();
                        sqlcom.Parameters.Add("@ImInvTypeHead", SqlDbType.NVarChar).Value = txtInvoiceType.Text;
                        sqlcom.Parameters.Add("@IminNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@IminDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImVehCode", SqlDbType.NVarChar).Value = txtVehicleCode.Text.Trim();
                        if (s1 == "&Add")
                        {
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.NVarChar).Value = "&Add";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.NVarChar).Value = "EDIT";
                        }
                        sqlcom.ExecuteNonQuery();
                        txtSerialNo.Text = sqlcom.Parameters["@ImNo"].Value.ToString();
                        sqlcom.Parameters.Clear();


                        sqlcom.CommandType = CommandType.Text;
                        sqlcom.CommandText = "Delete from RplDataData Where IdNo=@IdNo And IdDate=@IdDate And IdType='S'";
                        sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();


                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into RplDataData "
                                                        + " (IdFyear,IdType,IdNo,IdDate,IdPartyCode,"
                                                        + " IdPrdCode,IdPrdAsgnCode,IdPrdQty,IdPrdQtyF,IdPrdQtyR,IdPrdRate,IdDiscRate,IdPrdAmt,"
                                                        + " IdTxbAmt,IdTaxAmt,IdPrdTaxCode,IdTaxRate,IdSTaxAmt,IdSTaxRate,IdNetRateR,IdSchmQty,IdSchmQtyF)"
                                                        + " values(@IdFyear,@IdType,@IdNo,@IdDate,@IdPartyCode,"
                                                        + " @IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdQtyR,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                        + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,@IdSTaxAmt,@IdSTaxRate,@IdNetRateR,@IdSchmQty,@IdSchmQtyF)";


                            sqlcom.Parameters.Add("@IdFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@IdType", SqlDbType.NVarChar).Value = "S";
                            sqlcom.Parameters.Add("@IdCat", SqlDbType.NVarChar).Value = string.Empty;
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IdPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@IdPrdCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdCode"]);
                            sqlcom.Parameters.Add("@IdPrdAsgnCode", SqlDbType.NVarChar).Value = currentrow["IdPrdAsgnCode"].ToString();
                            sqlcom.Parameters.Add("@IdPrdQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQty"]);
                            sqlcom.Parameters.Add("@IdPrdQtyF", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQtyF"]);
                            sqlcom.Parameters.Add("@IdPrdQtyR", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdQtyR"]);
                            sqlcom.Parameters.Add("@IdPrdRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdRate"]);
                            sqlcom.Parameters.Add("@IdDiscRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdDiscRate"]);
                            sqlcom.Parameters.Add("@IdPrdAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdAmt"]);
                            sqlcom.Parameters.Add("@IdTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdTxbAmt"]);
                            sqlcom.Parameters.Add("@IdTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdTaxAmt"]);
                            sqlcom.Parameters.Add("@IdPrdTaxCode", SqlDbType.NVarChar).Value = currentrow["IdPrdTaxCode"].ToString();
                            sqlcom.Parameters.Add("@IdTaxRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdTaxRate"]);
                            sqlcom.Parameters.Add("@IdSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSTaxAmt"]);
                            sqlcom.Parameters.Add("@IdSTaxRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSTaxRate"]);
                            sqlcom.Parameters.Add("@IdNetRateR", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdNetRateR"]);
                            sqlcom.Parameters.Add("@IdSchmQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSchmQty"]);
                            sqlcom.Parameters.Add("@IdSchmQtyF", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSchmQtyF"]);
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        if (OldAgainstInvNo.ToString().Trim().Length > 0)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Update InvoiceMst Set ImTypeA=null,ImNoA=null,ImDateA=null Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = OldAgainstInvNo;
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = OldAgainstInvDate.Date.ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }

                        sqlcom.CommandType = CommandType.Text;
                        sqlcom.CommandText = "Update InvoiceMst Set ImTypeA='RP',ImNoA=@ImNoA,ImDateA=@ImDateA Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                        sqlcom.Parameters.Add("@ImNoA", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDateA", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
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

        private void SaveUnsoldData()
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
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        sqlcom.CommandText = "sp_InsertUSDataMst";
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters["@ImNo"].Direction = ParameterDirection.InputOutput;
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "US";
                        sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                        sqlcom.Parameters.Add("@ImPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                        sqlcom.Parameters.Add("@ImTotQty", SqlDbType.Decimal).Value = Convert.ToDecimal(gridColumn4.SummaryItem.SummaryValue).ToString("0.00");
                        sqlcom.Parameters.Add("@ImVogAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        sqlcom.Parameters.Add("@ImTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        sqlcom.Parameters.Add("@ImTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                        sqlcom.Parameters.Add("@ImSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                        sqlcom.Parameters.Add("@ImNetAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtNetAmount.Text);
                        sqlcom.Parameters.Add("@ImNetAmtRO", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRNetAmount.Text);
                        sqlcom.Parameters.Add("@ImLC", SqlDbType.NVarChar).Value = txtLCTag.Text.Trim();
                        sqlcom.Parameters.Add("@ImInvTypeHead", SqlDbType.NVarChar).Value = txtInvoiceType.Text;
                        sqlcom.Parameters.Add("@IminNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@IminDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImVehCode", SqlDbType.NVarChar).Value = txtVehicleCode.Text.Trim();
                        if (s1 == "&Add")
                        {
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.NVarChar).Value = "&Add";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.Parameters.Add("@AddEditTag", SqlDbType.NVarChar).Value = "EDIT";
                        }
                        sqlcom.ExecuteNonQuery();
                        txtSerialNo.Text = sqlcom.Parameters["@ImNo"].Value.ToString();
                        sqlcom.Parameters.Clear();


                        sqlcom.CommandType = CommandType.Text;
                        sqlcom.CommandText = "Delete from InvoiceData Where IdNo=@IdNo And IdDate=@IdDate And IdType='US'";
                        sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();


                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into InvoiceData "
                                                        + " (IdFyear,IdType,IdNo,IdDate,IdPartyCode,"
                                                        + " IdPrdCode,IdPrdAsgnCode,IdPrdQty,IdPrdQtyF,IdPrdQtyR,IdPrdRate,IdDiscRate,IdPrdAmt,"
                                                        + " IdTxbAmt,IdTaxAmt,IdPrdTaxCode,IdTaxRate,IdSTaxAmt,IdSTaxRate,IdSchmQty,IdSchmQtyF)"
                                                        + " values(@IdFyear,@IdType,@IdNo,@IdDate,@IdPartyCode,"
                                                        + " @IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdQtyR,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                        + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,@IdSTaxAmt,@IdSTaxRate,@IdSchmQty,@IdSchmQtyF)";


                            sqlcom.Parameters.Add("@IdFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@IdType", SqlDbType.NVarChar).Value = "US";
                            sqlcom.Parameters.Add("@IdCat", SqlDbType.NVarChar).Value = string.Empty;
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IdPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@IdPrdCode", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdCode"]);
                            sqlcom.Parameters.Add("@IdPrdAsgnCode", SqlDbType.NVarChar).Value = currentrow["IdPrdAsgnCode"].ToString();
                            sqlcom.Parameters.Add("@IdPrdQty", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["IdPrdQty"]);
                            sqlcom.Parameters.Add("@IdPrdQtyF", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["IdPrdQtyF"]);
                            sqlcom.Parameters.Add("@IdPrdQtyR", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["IdPrdQtyR"]);
                            sqlcom.Parameters.Add("@IdPrdRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdPrdRate"]);
                            sqlcom.Parameters.Add("@IdDiscRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdDiscRate"]);
                            sqlcom.Parameters.Add("@IdPrdAmt", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["IdPrdAmt"]);
                            sqlcom.Parameters.Add("@IdTxbAmt", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["IdTxbAmt"]);
                            sqlcom.Parameters.Add("@IdTaxAmt", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["IdTaxAmt"]);
                            sqlcom.Parameters.Add("@IdPrdTaxCode", SqlDbType.NVarChar).Value = currentrow["IdPrdTaxCode"].ToString();
                            sqlcom.Parameters.Add("@IdTaxRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdTaxRate"]);
                            sqlcom.Parameters.Add("@IdSTaxAmt", SqlDbType.Decimal).Value = -Convert.ToDecimal(currentrow["IdSTaxAmt"]);
                            sqlcom.Parameters.Add("@IdSTaxRate", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSTaxRate"]);
                            sqlcom.Parameters.Add("@IdSchmQty", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSchmQty"]);
                            sqlcom.Parameters.Add("@IdSchmQtyF", SqlDbType.Decimal).Value = Convert.ToDecimal(currentrow["IdSchmQtyF"]);
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        if (OldAgainstInvNo.ToString().Trim().Length > 0)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Update InvoiceMst Set ImTypeA=null,ImNoA=null,ImDateA=null Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                            sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = OldAgainstInvNo;
                            sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = OldAgainstInvDate.Date.ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }

                        sqlcom.CommandType = CommandType.Text;
                        sqlcom.CommandText = "Update InvoiceMst Set ImTypeA='US',ImNoA=@ImNoA,ImDateA=@ImDateA Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                        sqlcom.Parameters.Add("@ImNoA", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDateA", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
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
        private void SaveInvoiceData()
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
                                                    + " (@ImNo,@ImType,@ImFYear,@ImDate,@ImPartyCode,"
                                                    + " @ImTotQty,@ImVogAmt,@ImRcds,@ImTxbAmt,@ImTaxAmt,@ImSTaxAmt,@ImNetAmt,@ImNetAmtRO,"
                                                    + " @ImLC,@ImCForm,@ImInvTypeHead)"
                                                    + " values((SELECT RIGHT('000000'+ CAST( ISNULL( max(Cast(ImNo as int)),0)+1 AS VARCHAR(6)),6) from InvoiceMst),@ImType,@ImFYear,@ImDate,@ImPartyCode,"
                                                    + " @ImTotQty,@ImVogAmt,@ImRcds,@ImTxbAmt,@ImTaxAmt,@ImSTaxAmt,@ImNetAmt,@ImNetAmtRO,"
                                                    + " @ImLC,@ImCForm,@ImInvTypeHead)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE dealerMaster SET "
                                                + " ImFYear=@ImFYear,ImPartyCode=@ImPartyCode,ImTotQty=@ImTotQty, "
                                                + " ImVogAmt=@ImVogAmt,ImRcds=@ImRcds,ImTxbAmt=@ImTxbAmt,ImTaxAmt=@ImTaxAmt, "
                                                + " ImSTaxAmt=@ImSTaxAmt,ImNetAmt=@ImNetAmt,ImNetAmtRO=@ImNetAmtRO,ImLC=@ImLC,ImCForm=@ImCForm, "
                                                + " ImInvTypeHead=@ImInvTypeHead "
                                                + " Where dealerCode=@dealerCode";
                        }
                        sqlcom.Parameters["@ImNo"].Direction = ParameterDirection.InputOutput;
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImType", SqlDbType.NVarChar).Value = "S";
                        sqlcom.Parameters.Add("@ImFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                        sqlcom.Parameters.Add("@ImPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                        sqlcom.Parameters.Add("@ImTotQty", SqlDbType.Decimal).Value = Convert.ToDecimal(gridColumn4.SummaryItem.SummaryValue).ToString("0.00");
                        sqlcom.Parameters.Add("@ImVogAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        sqlcom.Parameters.Add("@ImTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtCGST.Text);
                        sqlcom.Parameters.Add("@ImTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtSGST.Text);
                        sqlcom.Parameters.Add("@ImSTaxAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtIGST.Text);
                        sqlcom.Parameters.Add("@ImNetAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(txtNetAmount.Text);
                        sqlcom.Parameters.Add("@ImNetAmtRO", SqlDbType.Decimal).Value = Convert.ToDecimal(txtRNetAmount.Text);
                        sqlcom.Parameters.Add("@ImLC", SqlDbType.NVarChar).Value = txtLCTag.Text.Trim();
                        sqlcom.Parameters.Add("@ImInvTypeHead", SqlDbType.NVarChar).Value = txtInvoiceType.Text;
                        sqlcom.ExecuteNonQuery();
                        txtSerialNo.Text = sqlcom.Parameters["@ImNo"].Value.ToString();
                        sqlcom.Parameters.Clear();



                        sqlcom.CommandText = "Delete from USDataData Where IdNo=@IdNo And IdDate=@IdDate And IdType='S'";
                        sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@IdDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();


                        for (var i = 0; i < MaxRow; i++)
                        {
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into USDataData "
                                                        + " (@IdFyear,@IdType,@IdNo,@IdDate,@IdPartyCode,"
                                                        + " @IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                        + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,IdSTaxAmt,IdSTaxRate)"
                                                        + " values(@IdFyear,@IdType,@IdNo,@IdDate,@IdSalesManCode,@IdPartyCode,@IdRouteCode,"
                                                        + " @IdDealerCode,@IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                        + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,IdSTaxAmt,IdSTaxRate)";


                            sqlcom.Parameters.Add("@IdFyear", SqlDbType.NVarChar).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            sqlcom.Parameters.Add("@IdType", SqlDbType.NVarChar).Value = "S";
                            sqlcom.Parameters.Add("@IdCat", SqlDbType.NVarChar).Value = string.Empty;
                            sqlcom.Parameters.Add("@IdNo", SqlDbType.NVarChar).Value = txtSerialNo.Text;
                            sqlcom.Parameters.Add("@IdDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("dd-MM-yyyy");
                            sqlcom.Parameters.Add("@IdPartyCode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
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

                        sqlcom.CommandText = "Update InvoiceMst Set ImTypeA='RP',ImNoA=@ImNoA,ImDateA=@ImDateA Where ImNo=@ImNo And ImDate=@ImDate And ImType='S'";
                        sqlcom.Parameters.Add("@ImNoA", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDateA", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();


                        sqlcom.CommandText = "Update USDataData Set IminNo=@IminNo,IminDate=@IminDate  Where USDataMst.ImNo=@ImNo And And USDataMst.ImDate=@ImDate And ImType='S'";
                        sqlcom.Parameters.Add("@IminNo", SqlDbType.NVarChar).Value = txtAgainstInvNo.Text.Trim();
                        sqlcom.Parameters.Add("@IminDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtAgainstInvDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@ImNo", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                        sqlcom.Parameters.Add("@ImDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();








                        DataSet dsDelVoucher = ProjectFunctions.GetDataSet("Select * from VuData Where VutDate='" + Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd") + "' And VutType='SL' And VutNo='" + 'S' + txtSerialNo.Text + "'");
                        if (dsDelVoucher.Tables[0].Rows.Count > 0)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from VuData Where VutDate='" + Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd") + "' And VutType='SL' And VutNo='" + 'S' + txtSerialNo.Text + "'";
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }


                        sqlcom.CommandText = " Insert into USDataData "
                                                       + " (@IdFyear,@IdType,@IdNo,@IdDate,@IdPartyCode,"
                                                       + " @IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                       + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,IdSTaxAmt,IdSTaxRate)"
                                                       + " values(@IdFyear,@IdType,@IdNo,@IdDate,@IdPartyCode,"
                                                       + " @IdPrdCode,@IdPrdAsgnCode,@IdPrdQty,@IdPrdQtyF,@IdPrdRate,@IdDiscRate,@IdPrdAmt,"
                                                       + " @IdTxbAmt,@IdTaxAmt,@IdPrdTaxCode,@IdTaxRate,IdSTaxAmt,IdSTaxRate)";

                        sqlcom.CommandType = CommandType.Text;
                        sqlcom.CommandText = " Insert into Vudata "
                                                      + " (VutDate,VutNo,VutType,VutAcode,VutAACode,VutAmt,VutNart)values("
                                                      + " @VutDate,@VutNo,@VutType,@VutAcode,@VutAACode,@VutAmt,@VutNart)";



                        sqlcom.Parameters.Add("@VutDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd");
                        sqlcom.Parameters.Add("@VutNo", SqlDbType.NVarChar).Value = "S" + txtSerialNo.Text;
                        sqlcom.Parameters.Add("@VutType", SqlDbType.NVarChar).Value = "SL";
                        sqlcom.Parameters.Add("@VutAcode", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text;
                        sqlcom.Parameters.Add("@VutAmt", SqlDbType.NVarChar).Value = txtRNetAmount.Text;
                        sqlcom.Parameters.Add("@VutNart", SqlDbType.NVarChar).Value = "Invoice No. " + txtSerialNo.Text;
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();

                        if ((Convert.ToDecimal(txtRNetAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)) != 0)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = " Insert into Vudata "
                                                          + " (VutDate,VutNo,VutType,VutAcode,VutAmt,VutNart)values("
                                                          + " @VutDate,@VutNo,@VutType,@VutAcode,@VutAmt,@VutNart)";

                            sqlcom.Parameters.Add("@VutDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@VutNo", SqlDbType.NVarChar).Value = "S" + txtSerialNo.Text;
                            sqlcom.Parameters.Add("@VutType", SqlDbType.NVarChar).Value = "SL";
                            sqlcom.Parameters.Add("@VutAcode", SqlDbType.NVarChar).Value = "0016";
                            sqlcom.Parameters.Add("@VutAmt", SqlDbType.NVarChar).Value = (Convert.ToDecimal(txtRNetAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)).ToString("0.00");
                            sqlcom.Parameters.Add("@VutNart", SqlDbType.NVarChar).Value = "Invoice No. " + txtSerialNo.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }




                        var distinctPostingTaxCode = (from DataRow dRow in dt.Rows
                                                      select dRow["IdPrdTaxCode"]).Distinct();


                        foreach (var v in distinctPostingTaxCode)
                        {
                            DataSet dsTaxRates = ProjectFunctions.GetDataSet("Select * from TaxMst Where TaxCode='" + v.ToString() + "'");
                            if (dsTaxRates.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToDecimal(txtCGST.Text) > 0)
                                {
                                    sqlcom.CommandType = CommandType.Text;
                                    sqlcom.CommandText = " Insert into Vudata "
                                                                  + " (VutDate,VutNo,VutType,VutAcode,VutAmt,VutNart)values("
                                                                  + " @VutDate,@VutNo,@VutType,@VutAcode,@VutAmt,@VutNart)";

                                    sqlcom.Parameters.Add("@VutDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd");
                                    sqlcom.Parameters.Add("@VutNo", SqlDbType.NVarChar).Value = "S" + txtSerialNo.Text;
                                    sqlcom.Parameters.Add("@VutType", SqlDbType.NVarChar).Value = "SL";
                                    sqlcom.Parameters.Add("@VutAcode", SqlDbType.NVarChar).Value = dsTaxRates.Tables[0].Rows[0]["TaxSACode"].ToString();
                                    sqlcom.Parameters.Add("@VutAmt", SqlDbType.NVarChar).Value = -Convert.ToDecimal(txtCGST.Text);
                                    sqlcom.Parameters.Add("@VutNart", SqlDbType.NVarChar).Value = "Invoice No. " + txtSerialNo.Text;
                                    sqlcom.ExecuteNonQuery();
                                    sqlcom.Parameters.Clear();
                                }
                                if (Convert.ToDecimal(txtSGST.Text) > 0)
                                {
                                    sqlcom.CommandType = CommandType.Text;
                                    sqlcom.CommandText = " Insert into Vudata "
                                                                  + " (VutDate,VutNo,VutType,VutAcode,VutAmt,VutNart)values("
                                                                  + " @VutDate,@VutNo,@VutType,@VutAcode,@VutAmt,@VutNart)";

                                    sqlcom.Parameters.Add("@VutDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd");
                                    sqlcom.Parameters.Add("@VutNo", SqlDbType.NVarChar).Value = "S" + txtSerialNo.Text;
                                    sqlcom.Parameters.Add("@VutType", SqlDbType.NVarChar).Value = "SL";
                                    sqlcom.Parameters.Add("@VutAcode", SqlDbType.NVarChar).Value = dsTaxRates.Tables[0].Rows[0]["TaxACode"].ToString();
                                    sqlcom.Parameters.Add("@VutAmt", SqlDbType.NVarChar).Value = -Convert.ToDecimal(txtSGST.Text);
                                    sqlcom.Parameters.Add("@VutNart", SqlDbType.NVarChar).Value = "Invoice No. " + txtSerialNo.Text;
                                    sqlcom.ExecuteNonQuery();
                                    sqlcom.Parameters.Clear();

                                }
                                if (Convert.ToDecimal(txtIGST.Text) > 0)
                                {
                                    sqlcom.CommandType = CommandType.Text;
                                    sqlcom.CommandText = " Insert into Vudata "
                                                                  + " (VutDate,VutNo,VutType,VutAcode,VutAmt,VutNart)values("
                                                                  + " @VutDate,@VutNo,@VutType,@VutAcode,@VutAmt,@VutNart)";
                                    sqlcom.Parameters.Add("@VutDate", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("yyyy-MM-dd");
                                    sqlcom.Parameters.Add("@VutNo", SqlDbType.NVarChar).Value = "S" + txtSerialNo.Text;
                                    sqlcom.Parameters.Add("@VutType", SqlDbType.NVarChar).Value = "SL";
                                    sqlcom.Parameters.Add("@VutAcode", SqlDbType.NVarChar).Value = dsTaxRates.Tables[0].Rows[0]["TaxSurACode"].ToString();
                                    sqlcom.Parameters.Add("@VutAmt", SqlDbType.NVarChar).Value = -Convert.ToDecimal(txtSGST.Text);
                                    sqlcom.Parameters.Add("@VutNart", SqlDbType.NVarChar).Value = "Invoice No. " + txtSerialNo.Text;
                                    sqlcom.ExecuteNonQuery();
                                    sqlcom.Parameters.Clear();
                                }
                            }
                        }



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


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateGridDataToSave())
            {
                if (FormValue == "S")
                {
                    SaveInvoiceData();
                }
                if (FormValue == "US")
                {
                    SaveUnsoldData();
                }
                if (FormValue == "RP")
                {
                    SaveReplData();
                }
            }
        }

        private void txtVehicleCode_EditValueChanged(object sender, EventArgs e)
        {
            txtVehicleDesc.Text = string.Empty;
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            HelpGridView.Columns.Clear();
            HelpGrid.Text = "btnLoadOrder";
            DataSet ds = ProjectFunctions.GetDataSet("SELECT DISTINCT DealerOrderMst.OrdNo, DealerOrderMst.OrdDate, DealerOrderMst.OrdDealerCode, ActMst.AccName, ActMst.AccLcTag FROM         DealerOrderMst INNER JOIN ActMst ON DealerOrderMst.OrdDealerCode = ActMst.AccCode Where OrdForDate ='" + Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd") + "' And DealerOrderMst.OrdDealerCode='" + txtDebitPartyCode.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HelpGrid.DataSource = ds.Tables[0];
                HelpGrid.Visible = true;
                HelpGrid.Focus();
                HelpGridView.BestFitColumns();

            }
            else
            {
                ProjectFunctions.SpeakError("No Order To Load");
            }
        }


        private void txtDebitPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst", " Where AccCode", txtDebitPartyCode, txtDebitPartyName, txtDebitPartyCode, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }



        private void txtVehicleCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select VehicleCode,VehicleRegNo from VehicleMst ", " Where VehicleCode", txtVehicleCode, txtVehicleDesc, txtVehicleCode, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
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

        private void HelpGrid_Click(object sender, EventArgs e)
        {

        }

        private void txtInvoiceType_Validating(object sender, CancelEventArgs e)
        {
            if (txtInvoiceType.Text.Trim() == "FG" || txtInvoiceType.Text.Trim() == "I" || txtInvoiceType.Text.Trim() == "FS" || txtInvoiceType.Text.Trim() == "OT" || txtInvoiceType.Text.Trim() == "OT" || txtInvoiceType.Text.Trim() == "RM" || txtInvoiceType.Text.Trim() == "ST" || txtInvoiceType.Text.Trim() == "STR")
            {

            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values Are FG-Finish Goods,I-Institutional,FS-Finished Sample,OT-Other,RM-Raw Material,ST-Stock Transfer,STR-Stock Transfer of Raw Material");
                txtInvoiceType.Text = string.Empty;
                txtInvoiceType.Focus();
            }
        }


        private void txtLCTag_Validating(object sender, CancelEventArgs e)
        {
            if (txtLCTag.Text.Trim() == "L" || txtLCTag.Text.Trim() == "C")
            {

            }
            else
            {
                ProjectFunctions.SpeakError("Valid LCTag Value(C-Central,L-Locaal))");
                txtLCTag.Text = string.Empty;
                txtLCTag.Focus();

            }
        }
    }
}