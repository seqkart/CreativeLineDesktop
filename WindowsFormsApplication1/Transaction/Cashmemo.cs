using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1.Transaction
{
    public partial class Cashmemo : DevExpress.XtraEditors.XtraForm
    {
        public String ProgCode { get; set; }
        public String s1 { get; set; }

        String SaleTag = "SALE";

        String HoldTag = String.Empty;
        DataTable dt = new DataTable();
        int rowindex;
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        public String ImSeries { get; set; }
#pragma warning disable CS0414 // The field 'Cashmemo.AccMRPMarkDown' is assigned but its value is never used
        Decimal AccMRPMarkDown = 0;
#pragma warning restore CS0414 // The field 'Cashmemo.AccMRPMarkDown' is assigned but its value is never used
#pragma warning disable CS0169 // The field 'Cashmemo.SearchField' is never used
        String SearchField;
#pragma warning restore CS0169 // The field 'Cashmemo.SearchField' is never used
        DataSet dsPopUps = new DataSet();
        public Cashmemo()
        {
            InitializeComponent();
            dt.Columns.Add("SIDBARCODE", typeof(String));
            dt.Columns.Add("SIDARTNO", typeof(String));
            dt.Columns.Add("SIDARTDESC", typeof(String));
            dt.Columns.Add("SIDCOLN", typeof(String));
            dt.Columns.Add("SIDSIZN", typeof(String));
            dt.Columns.Add("SIDSCANQTY", typeof(Decimal));
            dt.Columns.Add("SIDARTMRP", typeof(Decimal));
            dt.Columns.Add("SIDARTWSP", typeof(Decimal));
            dt.Columns.Add("SIDITMDISCPRCN", typeof(Decimal));
            dt.Columns.Add("SIDITMDISCAMT", typeof(Decimal));
            dt.Columns.Add("SIDITMNETAMT", typeof(Decimal));
            dt.Columns.Add("SIDBOXQTY", typeof(Decimal));
            dt.Columns.Add("SIDBOXMRPVAL", typeof(Decimal));
            dt.Columns.Add("SIDBOXWSPVAL", typeof(Decimal));
            dt.Columns.Add("SIDARTID", typeof(String));
            dt.Columns.Add("SIDCOLID", typeof(String));
            dt.Columns.Add("SIDSIZID", typeof(String));
            dt.Columns.Add("SIDPSDATE", typeof(DateTime));
            dt.Columns.Add("SIDPSID", typeof(String));
            dt.Columns.Add("SIDPSNO", typeof(String));
            dt.Columns.Add("SIDSGSTAMT", typeof(Decimal));
            dt.Columns.Add("SIDCGSTAMT", typeof(Decimal));
            dt.Columns.Add("SIDIGSTAMT", typeof(Decimal));
            dt.Columns.Add("SIDCGSTPER", typeof(Decimal));
            dt.Columns.Add("SIDSGSTPER", typeof(Decimal));
            dt.Columns.Add("SIDIGSTPER", typeof(Decimal));
            dt.Columns.Add("ARTMARGIN", typeof(Decimal));
            dt.Columns.Add("TAXCODE", typeof(String));
        }
        private void SetMyControls()
        {
            //ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.TextBoxVisualize(groupControl1);
            ProjectFunctions.TextBoxVisualize(groupControl2);
            ProjectFunctions.TextBoxVisualize(groupControl3);
            ProjectFunctions.TextBoxVisualize(groupControl4);
            ProjectFunctions.TextBoxVisualize(groupControl5);
            ProjectFunctions.TextBoxVisualize(groupControl6);

            ProjectFunctions.ButtonVisualize(this);
            txtItemDiscPer.Enabled = false;
            txtItemMRP.Enabled = false;
            txtItemFlatRate.Enabled = false;
            txtItemDiscAMount.Enabled = false;
        }

        private void LoadBillForEdit(String BillNo, DateTime BillDate, String BillSeries)
        {
            try

            {
                DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadCashMemoFEDit] '" + BillDate.Date.ToString("yyyy-MM-dd") + "','" + BillNo + "','" + BillSeries + "','" + GlobalVariables.CUnitID + "'");

                lblCashMemoDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"]).ToString("yyyy-MM-dd");
                lblCashMemoNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                lblNetPayable.Text = ds.Tables[0].Rows[0]["SIMSUBTOTVAL"].ToString();
                txtMainDisc.Text = ds.Tables[0].Rows[0]["SIMDISCPRCN"].ToString();
                txtMainDiscVal.Text = ds.Tables[0].Rows[0]["SIMDISCAMT"].ToString();
                txtRoundOff.Text = ds.Tables[0].Rows[0]["SIMROFFAMT"].ToString();
                lblNetPayable.Text = ds.Tables[0].Rows[0]["SIMGRANDTOT"].ToString();

                txtCustMobileNo.Text = ds.Tables[0].Rows[0]["CAFMOBILE"].ToString();
                txtCustCode.Text = ds.Tables[0].Rows[0]["CustCode"].ToString();
                txtCustName.Text = ds.Tables[0].Rows[0]["CAFFNAME"].ToString();
                txtCustDetails.Text = ds.Tables[0].Rows[0]["CAFADD"].ToString();
                txtAlterCharges.Text = ds.Tables[0].Rows[0]["SIMAlterCharges"].ToString();
                txtOtherCharges.Text = ds.Tables[0].Rows[0]["SIMAlterCharges"].ToString();
                if (ds.Tables[0].Rows[0]["SIMINVTAXTYPE"].ToString().ToUpper() == "Y")
                {
                    chExclusive.Checked = true;
                    chInclusive.Checked = false;
                }
                else
                {
                    chExclusive.Checked = false;
                    chInclusive.Checked = true;
                }


                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
                InfoGridView.BestFitColumns();
                txtCustMobileNo.Focus();


                calculation();
                GetPartyBalances();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void TxtCustMobileNo_EditValueChanged(object sender, EventArgs e)
        {
            txtCustCode.Text = String.Empty;
            txtCustDetails.Text = String.Empty;
            txtCustName.Text = String.Empty;
            txtLastVisitedOn.Text = String.Empty;
            txtBalance.Text = String.Empty;
        }
        private void GetPartyBalances()
        {
            DataSet dsPartyLedgerBal = ProjectFunctions.GetDataSet("sp_PartyLedgerBalCustWise '" + txtCustCode.Text + "'");
            if (dsPartyLedgerBal.Tables[0].Rows.Count > 0)
            {
                txtBalance.Text = dsPartyLedgerBal.Tables[0].Rows[0]["Balance"].ToString();
            }
        }
        private bool ValidateDataForSaving()
        {

            if (InfoGrid.DataSource == null)
            {
                ProjectFunctions.SpeakError("Blank Bill Cannot Be Saved");
                txtCustMobileNo.Focus();
                return false;

            }
            else
            {

            }

            if (txtCustMobileNo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cust Mobile No");
                txtCustMobileNo.Focus();
                return false;
            }
            if (txtCustName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Cust Name");
                txtCustName.Focus();
                return false;
            }


            if (txtBalance.Text.Length == 0)
            {
                txtBalance.Text = "0";
            }
            if (txtAlterCharges.Text.Length == 0)
            {
                txtAlterCharges.Text = "0";
            }
            if (txtOtherCharges.Text.Length == 0)
            {
                txtOtherCharges.Text = "0";
            }
            if (txtRoundOff.Text.Length == 0)
            {
                txtRoundOff.Text = "0";
            }
            if (txtSubTotal.Text.Length == 0)
            {
                txtSubTotal.Text = "0";
            }
            if (txtTotalTax.Text.Length == 0)
            {
                txtTotalTax.Text = "0";
            }
            if (lblNetPayable.Text.Length == 0)
            {
                lblNetPayable.Text = "0";
            }
            if (lblPAyBack.Text.Length == 0)
            {
                lblPAyBack.Text = "0";
            }
            if (lblTotalCGST.Text.Length == 0)
            {
                lblTotalCGST.Text = "0";
            }
            if (lblTotalIGST.Text.Length == 0)
            {
                lblTotalIGST.Text = "0";
            }
            if (lblTotalQtyReturned.Text.Length == 0)
            {
                lblTotalQtyReturned.Text = "0";
            }
            if (lblTotalQtySold.Text.Length == 0)
            {
                lblTotalQtySold.Text = "0";
            }
            if (lblTotalSGST.Text.Length == 0)
            {
                lblTotalSGST.Text = "0";
            }
            if (lblTotalTaxExclusive.Text.Length == 0)
            {
                lblTotalTaxExclusive.Text = "0";
            }
            if (lblTotalTaxInclusive.Text.Length == 0)
            {
                lblTotalTaxInclusive.Text = "0";
            }
            if (lblTotalValueAterDisc.Text.Length == 0)
            {
                lblTotalValueAterDisc.Text = "0";
            }
            if (lblTotalValueBeforDisc.Text.Length == 0)
            {
                lblTotalValueBeforDisc.Text = "0";
            }
            if (lblTotalValueDisc.Text.Length == 0)
            {
                lblTotalValueDisc.Text = "0";
            }

            return true;
        }
        private void TxtCustMobileNo_KeyDown(object sender, KeyEventArgs e)
        {

            try

            {
                if (e.KeyCode == Keys.Enter)
                {
                    HelpGridView.Columns.Clear();
                    HelpGrid.Text = "txtCustMobileNo";
                    if (txtCustMobileNo.Text.Trim().Length == 0)
                    {
                        frmCustomerMst frm = new frmCustomerMst() { s1 = "&Add", Text = "Customer Addition", CustMobileNo = txtCustMobileNo.Text };
                        var P = ProjectFunctions.GetPositionInForm(this);
                        frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                        frm.ShowDialog(Parent);
                        if (GlobalVariables.GlobalCustWindowCount == 0)
                        {
                            SendKeys.Send("{Enter}");
                        }


                    }
                    else
                    {
                        DataSet ds = ProjectFunctions.GetDataSet(" select CAFSYSID,CAFFNAME+' '+ CAFMNAME+' '+ CAFLNAME as CAFFNAME, CAFADD+', '+CAFADD1+', '+CAFADD2 as CAFADD,CAFMOBILE from CAFINFO Where  CAFMOBILE='" + txtCustMobileNo.Text.Trim() + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtCustMobileNo.Text = ds.Tables[0].Rows[0]["CAFMOBILE"].ToString();
                            txtCustCode.Text = ds.Tables[0].Rows[0]["CAFSYSID"].ToString();
                            txtCustName.Text = ds.Tables[0].Rows[0]["CAFFNAME"].ToString();
                            txtCustDetails.Text = ds.Tables[0].Rows[0]["CAFADD"].ToString();
                            txtBarCode.Focus();

                            CheckHoldEnable();


                        }

                        else
                        {

                            frmCustomerMst frm = new frmCustomerMst() { s1 = "&Add", Text = "Customer Addition", CustMobileNo = txtCustMobileNo.Text };
                            var P = ProjectFunctions.GetPositionInForm(this);
                            frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                            frm.ShowDialog(Parent);
                            if (GlobalVariables.GlobalCustWindowCount == 0)
                            {
                                SendKeys.Send("{Enter}");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            e.Handled = true;
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
                if (HelpGrid.Text == "Load")
                {
                    foreach (DataRow dr in (HelpGrid.DataSource as DataTable).Rows)
                    {
                        if (dr["Select"].ToString().ToUpper() == "TRUE")
                        {
                            DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSKUdetForCashMemo '" + dr["SIDBARCODE"].ToString() + "','" + GlobalVariables.CUnitID + "'");
                            if (dt.Rows.Count == 0)
                            {
                                dt = ds.Tables[0];
                            }
                            else
                            {
                                dt.Merge(ds.Tables[0]);
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        InfoGrid.DataSource = dt;
                        InfoGridView.BestFitColumns();
                    }
                    else
                    {
                        InfoGrid.DataSource = null;
                    }
                    HelpGrid.Visible = false;
                    calculation();
                }
                if (HelpGrid.Text == "txtCustMobileNo")
                {
                    txtCustMobileNo.Text = row["CAFMOBILE"].ToString();
                    txtCustCode.Text = row["CAFSYSID"].ToString();
                    txtCustName.Text = row["CAFFNAME"].ToString();
                    txtCustDetails.Text = row["CAFADD"].ToString();
                    GetPartyBalances();

                    HelpGrid.Visible = false;
                    txtBarCode.Focus();
                    CheckHoldEnable();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F12)
                {
                    if (SaleTag == "SALE")
                    {
                        SaleTag = "RETURN";
                        labelControl17.Text = "Return";
                        txtBarCode.BackColor = Color.Red;
                        txtBarCode.ForeColor = Color.White;
                    }
                    else
                    {
                        SaleTag = "SALE";
                        labelControl17.Text = "BarCode";
                        txtBarCode.BackColor = Color.White;
                        txtBarCode.ForeColor = Color.Black;
                    }
                }


                if (e.KeyCode == Keys.F3)
                {
                    HelpGridView.Columns.Clear();
                    HelpGrid.Text = "Load";
                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSFDet_F3 '" + GlobalVariables.CUnitID + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds.Tables[0].Columns.Add("Select", typeof(bool));
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dr["Select"] = false;
                        }
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGrid.Show();
                        HelpGrid.Focus();
                        HelpGridView.BestFitColumns();

                        HelpGridView.OptionsBehavior.Editable = true;
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in HelpGridView.Columns)
                        {
                            if (col.FieldName == "Select")
                            {
                                col.VisibleIndex = 0;
                                col.OptionsColumn.AllowEdit = true;
                            }
                            else
                            {
                                col.OptionsColumn.AllowEdit = false;
                            }
                        }
                    }

                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (SaleTag == "SALE")
                    {
                        DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDataFromSKUdetUsingBarCode '" + txtBarCode.Text + "','" + GlobalVariables.CUnitID + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            if (ds.Tables[0].Rows[0]["Used"].ToString().ToUpper() == "Y")
                            {
                                ProjectFunctions.SpeakError("BarCode Already Used In Some Other Document");
                                return;
                            }
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["SIDBARCODE"].ToString().ToUpper() == txtBarCode.Text.Trim())
                                {
                                    ProjectFunctions.SpeakError("BarCode Already Loaded In This Document");
                                    return;
                                }
                            }
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTMRP"]) != Convert.ToDecimal(ds.Tables[0].Rows[0]["ARTMRP"]))
                            {
                                ProjectFunctions.SpeakError("Difference In MRP( MRP In Articel is - " + ds.Tables[0].Rows[0]["ARTMRP"].ToString() + ")");
                            }



                            if (dt.Rows.Count == 0)
                            {
                                dt = ds.Tables[0];
                            }
                            else
                            {
                                dt.Merge(ds.Tables[0]);
                            }

                            ShowImage(Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTID"]).ToString());
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("NO BarCode Found");
                            return;
                        }
                        if (dt.Rows.Count > 0)
                        {
                            InfoGrid.DataSource = dt;
                            InfoGridView.BestFitColumns();
                        }
                        else
                        {
                            InfoGrid.DataSource = null;
                        }
                        txtBarCode.Text = String.Empty;
                        txtBarCode.Focus();
                        calculation();
                    }
                    else
                    {
                        DataSet ds = ProjectFunctions.GetDataSet("sp_LoadCashMemoForReturn '" + txtBarCode.Text + "','" + GlobalVariables.CUnitID + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (dt.Rows.Count == 0)
                            {
                                dt = ds.Tables[0];
                            }
                            else
                            {
                                dt.Merge(ds.Tables[0]);
                            }

                            ShowImage(Convert.ToDecimal(ds.Tables[0].Rows[0]["SIDARTID"]).ToString());
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("NO BarCode Found");
                            return;
                        }
                        if (dt.Rows.Count > 0)
                        {
                            InfoGrid.DataSource = dt;
                            InfoGridView.BestFitColumns();
                        }
                        else
                        {
                            InfoGrid.DataSource = null;
                        }
                        txtBarCode.Text = String.Empty;
                        txtBarCode.Focus();
                        calculation();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
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
                txtBarCode.Focus();
            }
        }
        private void ShowImage(String ArticleID)
        {
            try
            {
                DataSet dsImage = ProjectFunctions.GetDataSet("Select ARTIMAGE from ARTICLE Where ARTSYSID='" + ArticleID + "'");
                if (dsImage.Tables[0].Rows[0]["ARTIMAGE"].ToString().Trim() != string.Empty)
                {
                    Byte[] MyData = new byte[0];
                    MyData = (Byte[])dsImage.Tables[0].Rows[0]["ARTIMAGE"];
                    MemoryStream stream = new MemoryStream(MyData)
                    {
                        Position = 0
                    };

                    ArticleImageBox.Image = System.Drawing.Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void TxtSMCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSMName.Text = String.Empty;
        }



        private void ChExclusive_CheckedChanged(object sender, EventArgs e)
        {
            if (chExclusive.Checked)
            {
                chInclusive.Checked = false;
                calculation();
            }
        }
        private void calculation()
        {
            try
            {
                InfoGridView.CloseEditor();
                InfoGridView.UpdateCurrentRow();
                BeginInvoke(new MethodInvoker(delegate
                {
                    InfoGridView.PostEditor();
                    InfoGridView.UpdateCurrentRow();
                }));

                if (txtMainDisc.Text.Length == 0)
                {
                    txtMainDisc.Text = "0";
                }


                if (chExclusive.Checked)
                {
                    Exclusive();
                }
                else
                {
                    Inclusive();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }


        }


        private void Inclusive()
        {

            try

            {
                Decimal MainDiscAmount = 0;
                Decimal ValueOfGoods = 0;
                Decimal SumValueOfGoods = 0;
                Decimal SumRowDiscAmount = 0;
                Decimal SumCGSTAmount = 0;
                Decimal SumSGSTAmount = 0;
                Decimal SumIGSTAmount = 0;
                Decimal TotalSaleQty = 0;
                Decimal TotalReturnQty = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToDecimal(dr["SIDSCANQTY"]) > 0)
                    {

                        var str = "Exec [sp_LoadTaxMstFInvoice] @PrdCode='" + dr["SIDARTID"].ToString() + "',";
                        str = str + "@LCTag='L',@ValueOfGoods='" + Convert.ToDecimal(dr["SIDARTMRP"]) + "'";

                        DataSet ds = ProjectFunctions.GetDataSet(str);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dr["SIDCGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxCGSTRate"]);
                            dr["SIDSGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSGSTRate"]);
                            dr["SIDIGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxIGSTRate"]);
                        }


                        Decimal NetRate = 0;

                        Decimal TaxRate = Convert.ToDecimal(dr["SIDCGSTPER"]) + Convert.ToDecimal(dr["SIDSGSTPER"]) + Convert.ToDecimal(dr["SIDIGSTPER"]);
                        if (NetRate == 0)
                        {
                            NetRate = Convert.ToDecimal(dr["SIDARTMRP"]) - ((Convert.ToDecimal(dr["SIDARTMRP"]) * TaxRate) / (100 + TaxRate));
                        }
                        else
                        {
                            NetRate = NetRate - ((NetRate * TaxRate) / (100 + TaxRate));
                        }

                        DataSet dsCheckDate = ProjectFunctions.GetDataSet("sp_GetSchemeData '" + dr["SIDBARCODE"].ToString() + "','" + Convert.ToDateTime(lblCashMemoDate.Text).ToString("yyyy-MM-dd") + "'");
                        if (dsCheckDate.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToDecimal(dsCheckDate.Tables[0].Rows[0]["FlatRate"]) > 0)
                            {
                                dr["SIDITMDISCPRCN"] = 100 - ((Convert.ToDecimal(dsCheckDate.Tables[0].Rows[0]["FlatRate"]) / Convert.ToDecimal(dr["SIDARTMRP"])) * 100);
                            }
                            else
                            {
                                dr["SIDITMDISCPRCN"] = Convert.ToDecimal(dsCheckDate.Tables[0].Rows[0]["TotalDiscPer"]);
                            }
                        }

                        dr["SIDARTWSP"] = Convert.ToDecimal("0");

                        Decimal TempValueOfGoods = 0;
                        Decimal RowDiscAmount = (Convert.ToDecimal(dr["SIDSCANQTY"]) * ((Convert.ToDecimal(dr["SIDARTMRP"]) * Convert.ToDecimal(dr["SIDITMDISCPRCN"])) / 100));

                        TempValueOfGoods = ((Convert.ToDecimal(dr["SIDSCANQTY"]) * (Convert.ToDecimal(dr["SIDARTMRP"])) - RowDiscAmount));

                        Decimal TempMainDisc = (TempValueOfGoods * Convert.ToDecimal(txtMainDisc.Text)) / 100;


                        MainDiscAmount = MainDiscAmount + TempMainDisc;
                        ValueOfGoods = TempValueOfGoods - TempMainDisc;




                        SumRowDiscAmount = SumRowDiscAmount + RowDiscAmount;
                        dr["SIDITMDISCAMT"] = RowDiscAmount;



                        Decimal CGSTAmount = 0;
                        Decimal SGSTAmount = 0;
                        Decimal IGSTAmount = 0;


                        if (Convert.ToDecimal(dr["SIDITMDISCAMT"]) > 0 || Convert.ToDecimal(txtMainDisc.Text) > 0)
                        {
                            var str2 = "Exec [sp_LoadTaxMstFInvoice] @PrdCode='" + dr["SIDARTID"].ToString() + "',";
                            str2 = str2 + "@LCTag='L',@ValueOfGoods='" + ValueOfGoods + "'";

                            DataSet dsNew = ProjectFunctions.GetDataSet(str2);
                            if (dsNew.Tables[0].Rows.Count > 0)
                            {
                                dr["SIDCGSTPER"] = Convert.ToDecimal(dsNew.Tables[0].Rows[0]["TaxCGSTRate"]);
                                dr["SIDSGSTPER"] = Convert.ToDecimal(dsNew.Tables[0].Rows[0]["TaxSGSTRate"]);
                                dr["SIDIGSTPER"] = Convert.ToDecimal(dsNew.Tables[0].Rows[0]["TaxIGSTRate"]);
                            }
                        }


                        SumValueOfGoods = SumValueOfGoods + ValueOfGoods;


                        Decimal TaxRateFinal = Convert.ToDecimal(dr["SIDCGSTPER"]) + Convert.ToDecimal(dr["SIDSGSTPER"]) + Convert.ToDecimal(dr["SIDIGSTPER"]);
                        Decimal Tax = ValueOfGoods * TaxRateFinal / (100 + TaxRateFinal);
                        if (Convert.ToDecimal(dr["SIDCGSTPER"]) > 0 || Convert.ToDecimal(dr["SIDSGSTPER"]) > 0)
                        {
                            CGSTAmount = Tax / 2;
                            SGSTAmount = Tax / 2;
                        }
                        else
                        {
                            IGSTAmount = Tax;
                        }


                        dr["SIDITMNETAMT"] = Math.Round(ValueOfGoods, 2);


                        SumCGSTAmount = SumCGSTAmount + CGSTAmount;
                        SumSGSTAmount = SumSGSTAmount + SGSTAmount;
                        SumIGSTAmount = SumIGSTAmount + IGSTAmount;

                        dr["SIDCGSTAMT"] = CGSTAmount;
                        dr["SIDSGSTAMT"] = SGSTAmount;
                        dr["SIDIGSTAMT"] = IGSTAmount;

                    }
                    else
                    {
                        SumValueOfGoods = SumValueOfGoods + Convert.ToDecimal(dr["SIDITMNETAMT"]);
                        SumCGSTAmount = SumCGSTAmount + Convert.ToDecimal(dr["SIDCGSTAMT"]);
                        SumSGSTAmount = SumSGSTAmount + Convert.ToDecimal(dr["SIDSGSTAMT"]);
                        SumIGSTAmount = SumIGSTAmount + Convert.ToDecimal(dr["SIDIGSTAMT"]);


                        dr["SIDITMDISCPRCN"] = (100 - ((Convert.ToDecimal(dr["SIDITMNETAMT"]) / Convert.ToDecimal(dr["SIDARTMRP"])) * 100));
                        dr["SIDITMDISCAMT"] = (Convert.ToDecimal(dr["SIDARTMRP"]) * Convert.ToDecimal(dr["SIDITMDISCPRCN"])) / 100;
                    }

                    if (Convert.ToDecimal(dr["SIDSCANQTY"]) > 0)
                    {
                        TotalSaleQty = TotalSaleQty + Convert.ToDecimal(dr["SIDSCANQTY"]);
                    }
                    else
                    {
                        TotalReturnQty = TotalReturnQty + Convert.ToDecimal(dr["SIDSCANQTY"]);
                    }

                }

                lblTotalCGST.Text = SumCGSTAmount.ToString("0.00");
                lblTotalSGST.Text = SumSGSTAmount.ToString("0.00");
                lblTotalIGST.Text = SumIGSTAmount.ToString("0.00");

                txtTotalTax.Text = (SumCGSTAmount + SumSGSTAmount + SumIGSTAmount).ToString("0.00");
                lblTotalTaxInclusive.Text = txtTotalTax.Text;

                txtMainDiscVal.Text = MainDiscAmount.ToString("0.00");


                txtSubTotal.Text = SumValueOfGoods.ToString("0.00");
                lblTotalDisc.Text = SumRowDiscAmount.ToString("0.00");
                Decimal TempNetPayable = 0;

                TempNetPayable = SumValueOfGoods + Convert.ToDecimal(txtAlterCharges.Text) + Convert.ToDecimal(txtOtherCharges.Text);
                lblNetPayable.Text = Math.Round(TempNetPayable, 0).ToString("0.00");

                txtRoundOff.Text = (Convert.ToDecimal(lblNetPayable.Text) - TempNetPayable).ToString("0.00");


                lblTotalQtySold.Text = TotalSaleQty.ToString("0");
                lblTotalQtyReturned.Text = (-TotalReturnQty).ToString("0");
                lblTotalValueBeforDisc.Text = Convert.ToDecimal(gridColumn7.SummaryItem.SummaryValue).ToString("0.00");
                lblTotalValueAterDisc.Text = Convert.ToDecimal(gridColumn13.SummaryItem.SummaryValue).ToString("0.00");
                lblTotalValueDisc.Text = txtMainDiscVal.Text;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void Exclusive()
        {
            try
            {
                Decimal MainDiscAmount = 0;
                Decimal ValueOfGoods = 0;
                Decimal SumValueOfGoods = 0;
                Decimal SumRowDiscAmount = 0;
                Decimal SumCGSTAmount = 0;
                Decimal SumSGSTAmount = 0;
                Decimal SumIGSTAmount = 0;
                Decimal TotalSaleQty = 0;
                Decimal TotalReturnQty = 0;
                foreach (DataRow dr in dt.Rows)
                {

                    if (Convert.ToDecimal(dr["SIDSCANQTY"]) > 0)
                    {



                        Decimal NetRate = 0;
                        DataSet dsCheckDate = ProjectFunctions.GetDataSet("sp_GetSchemeData '" + dr["SIDBARCODE"].ToString() + "','" + Convert.ToDateTime(lblCashMemoDate.Text).ToString("yyyy-MM-dd") + "'");
                        if (dsCheckDate.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToDecimal(dsCheckDate.Tables[0].Rows[0]["FlatRate"]) > 0)
                            {
                                NetRate = Convert.ToDecimal(dsCheckDate.Tables[0].Rows[0]["FlatRate"]);
                                dr["SIDITMDISCPRCN"] = 100 - ((NetRate / Convert.ToDecimal(dr["SIDARTMRP"])) * 100);
                            }
                            else
                            {
                                dr["SIDITMDISCPRCN"] = Convert.ToDecimal(dsCheckDate.Tables[0].Rows[0]["TotalDiscPer"]);
                            }
                        }
                        else
                        {
                            NetRate = Convert.ToDecimal(dr["SIDARTMRP"]);
                        }


                        dr["SIDARTWSP"] = Convert.ToDecimal("0");

                        Decimal TempValueOfGoods = 0;
                        Decimal RowDiscAmount = (Convert.ToDecimal(dr["SIDSCANQTY"]) * ((Convert.ToDecimal(dr["SIDARTMRP"]) * Convert.ToDecimal(dr["SIDITMDISCPRCN"])) / 100));

                        TempValueOfGoods = ((Convert.ToDecimal(dr["SIDSCANQTY"]) * Convert.ToDecimal(Convert.ToDecimal(dr["SIDARTMRP"]))) - RowDiscAmount);

                        Decimal TempMainDisc = (TempValueOfGoods * Convert.ToDecimal(txtMainDisc.Text)) / 100;


                        MainDiscAmount = MainDiscAmount + TempMainDisc;
                        ValueOfGoods = TempValueOfGoods - TempMainDisc;

                        SumRowDiscAmount = SumRowDiscAmount + RowDiscAmount;
                        dr["SIDITMDISCAMT"] = RowDiscAmount;



                        Decimal CGSTAmount = 0;
                        Decimal SGSTAmount = 0;
                        Decimal IGSTAmount = 0;


                        SumValueOfGoods = SumValueOfGoods + ValueOfGoods;
                        CGSTAmount = ((ValueOfGoods * Convert.ToDecimal(dr["SIDCGSTPER"])) / 100);
                        SGSTAmount = ((ValueOfGoods * Convert.ToDecimal(dr["SIDSGSTPER"])) / 100);
                        IGSTAmount = ((ValueOfGoods * Convert.ToDecimal(dr["SIDIGSTPER"])) / 100);

                        dr["SIDITMNETAMT"] = Math.Round(ValueOfGoods + CGSTAmount + SGSTAmount + IGSTAmount, 2);


                        SumCGSTAmount = SumCGSTAmount + CGSTAmount;
                        SumSGSTAmount = SumSGSTAmount + SGSTAmount;
                        SumIGSTAmount = SumIGSTAmount + IGSTAmount;

                        dr["SIDCGSTAMT"] = CGSTAmount;
                        dr["SIDSGSTAMT"] = SGSTAmount;
                        dr["SIDIGSTAMT"] = IGSTAmount;
                    }
                    else
                    {
                        SumValueOfGoods = SumValueOfGoods + Convert.ToDecimal(dr["SIDITMNETAMT"]);
                        SumCGSTAmount = SumCGSTAmount + Convert.ToDecimal(dr["SIDCGSTAMT"]);
                        SumSGSTAmount = SumSGSTAmount + Convert.ToDecimal(dr["SIDSGSTAMT"]);
                        SumIGSTAmount = SumIGSTAmount + Convert.ToDecimal(dr["SIDIGSTAMT"]);
                        Decimal TempAmount = 0;
                        TempAmount = Convert.ToDecimal(dr["SIDITMNETAMT"]) - Convert.ToDecimal(dr["SIDCGSTAMT"]) - Convert.ToDecimal(dr["SIDSGSTAMT"]) - Convert.ToDecimal(dr["SIDIGSTAMT"]);
                        dr["SIDITMDISCPRCN"] = (100 + ((TempAmount / Convert.ToDecimal(dr["SIDARTMRP"])) * 100));
                        dr["SIDITMDISCAMT"] = -(Convert.ToDecimal(dr["SIDARTMRP"]) * Convert.ToDecimal(dr["SIDITMDISCPRCN"])) / 100;
                    }



                    if (Convert.ToDecimal(dr["SIDSCANQTY"]) > 0)
                    {
                        TotalSaleQty = TotalSaleQty + Convert.ToDecimal(dr["SIDSCANQTY"]);
                    }
                    else
                    {
                        TotalReturnQty = TotalReturnQty + Convert.ToDecimal(dr["SIDSCANQTY"]);
                    }
                }





                lblTotalCGST.Text = SumCGSTAmount.ToString("0.00");
                lblTotalSGST.Text = SumSGSTAmount.ToString("0.00");
                lblTotalIGST.Text = SumIGSTAmount.ToString("0.00");

                txtTotalTax.Text = (SumCGSTAmount + SumSGSTAmount + SumIGSTAmount).ToString("0.00");




                lblTotalTaxExclusive.Text = txtTotalTax.Text;

                txtMainDiscVal.Text = MainDiscAmount.ToString("0.00");


                txtSubTotal.Text = SumValueOfGoods.ToString("0.00");
                lblTotalDisc.Text = SumRowDiscAmount.ToString("0.00");
                Decimal TempNetPayable = 0;

                TempNetPayable = SumValueOfGoods + SumCGSTAmount + SumSGSTAmount + SumIGSTAmount + Convert.ToDecimal(txtAlterCharges.Text) + Convert.ToDecimal(txtOtherCharges.Text);
                lblNetPayable.Text = Math.Round(TempNetPayable, 0).ToString("0.00");

                txtRoundOff.Text = (Convert.ToDecimal(lblNetPayable.Text) - TempNetPayable).ToString("0.00");


                lblTotalQtySold.Text = TotalSaleQty.ToString("0");
                lblTotalQtyReturned.Text = (-TotalReturnQty).ToString("0");
                lblTotalValueBeforDisc.Text = Convert.ToDecimal(gridColumn7.SummaryItem.SummaryValue).ToString("0.00");
                lblTotalValueAterDisc.Text = Convert.ToDecimal(gridColumn13.SummaryItem.SummaryValue).ToString("0.00");
                lblTotalValueDisc.Text = txtMainDiscVal.Text;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void ChInclusive_CheckedChanged(object sender, EventArgs e)
        {
            if (chInclusive.Checked)
            {
                chExclusive.Checked = false;
                calculation();
            }
        }

        private void XtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SaveInvoice()
        {
            if (ValidateDataForSaving())
            {
                String Series = String.Empty;
                if (Convert.ToDecimal(lblNetPayable.Text) >= 0)
                {
                    Series = "S";
                }
                else
                {
                    Series = "N";
                }

                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    var MaxRow = ((InfoGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    sqlcom.Connection = sqlcon;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            String BillNo = String.Empty;

                            BillNo = ProjectFunctions.GetDataSet("select isnull(max(SIMNO),0)+1 from SALEINVMAIN where SIMSERIES='" + Series + "' And SIMFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'").Tables[0].Rows[0][0].ToString();
                            lblCashMemoNo.Text = BillNo;
                            sqlcom.CommandText = "Insert into SALEINVMAIN(SIMSYSDATE,SIMFNYR,SIMDATE,SIMNO,SIMSERIES,SIMPartyC," +
                                "SIMINVTAXTYPE,SIMSUBTOTVAL,SIMDISCPRCN,SIMDISCAMT, " +
                                "SIMROFFAMT,SIMGRANDTOT,CustCode,UnitCode,SIMAlterCharges,SIMOtherCharges  )values(" +
                                "@SIMSYSDATE,@SIMFNYR,@SIMDATE,@SIMNO,@SIMSERIES,@SIMPartyC," +
                                "@SIMINVTAXTYPE,@SIMSUBTOTVAL,@SIMDISCPRCN,@SIMDISCAMT, " +
                                "@SIMROFFAMT,@SIMGRANDTOT,@CustCode,@UnitCode,@SIMAlterCharges,@SIMOtherCharges)";
                            sqlcom.Parameters.Add("@SIMSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIMFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIMDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(lblCashMemoDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIMNO", SqlDbType.NVarChar).Value = lblCashMemoNo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMSERIES", SqlDbType.NVarChar).Value = Series;
                            sqlcom.Parameters.Add("@SIMPartyC", SqlDbType.NVarChar).Value = "148";



                            if (chExclusive.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "N";
                            }

                            sqlcom.Parameters.Add("@SIMSUBTOTVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblNetPayable.Text);
                            sqlcom.Parameters.Add("@SIMDISCPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDisc.Text);
                            sqlcom.Parameters.Add("@SIMDISCAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDiscVal.Text);
                            sqlcom.Parameters.Add("@SIMROFFAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtRoundOff.Text);
                            sqlcom.Parameters.Add("@SIMGRANDTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblNetPayable.Text);
                            sqlcom.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = txtCustCode.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.Parameters.Add("@SIMAlterCharges", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtAlterCharges.Text);
                            sqlcom.Parameters.Add("@SIMOtherCharges", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtOtherCharges.Text);



                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "Update SALEINVMAIN Set SIMSYSDATE=@SIMSYSDATE,SIMFNYR=@SIMFNYR,SIMDATE=@SIMDATE,SIMNO=@SIMNO," +
                                " SIMSERIES=@SIMSERIES,SIMPartyC=@SIMPartyC,SIMINVTAXTYPE=@SIMINVTAXTYPE,SIMSUBTOTVAL=@SIMSUBTOTVAL," +
                                " SIMDISCPRCN=@SIMDISCPRCN,SIMDISCAMT=@SIMDISCAMT,SIMROFFAMT=@SIMROFFAMT,SIMGRANDTOT=@SIMGRANDTOT,CustCode=@CustCode,UnitCode=@UnitCode,SIMAlterCharges=@SIMAlterCharges,SIMOtherCharges=@SIMOtherCharges Where SIMDATE='" + Convert.ToDateTime(ImDate).ToString("yyyy-MM-dd") + "' And SIMNO='" + ImNo + "' And SIMSERIES='" + ImSeries + "' And UnitCode='" + GlobalVariables.CUnitID + "'";

                            sqlcom.Parameters.Add("@SIMSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIMFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIMDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(lblCashMemoDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIMNO", SqlDbType.NVarChar).Value = lblCashMemoNo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMSERIES", SqlDbType.NVarChar).Value = Series;
                            sqlcom.Parameters.Add("@SIMPartyC", SqlDbType.NVarChar).Value = "148";



                            if (chExclusive.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "N";
                            }

                            sqlcom.Parameters.Add("@SIMSUBTOTVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblNetPayable.Text);
                            sqlcom.Parameters.Add("@SIMDISCPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDisc.Text);
                            sqlcom.Parameters.Add("@SIMDISCAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDiscVal.Text);
                            sqlcom.Parameters.Add("@SIMROFFAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtRoundOff.Text);
                            sqlcom.Parameters.Add("@SIMGRANDTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(lblNetPayable.Text);
                            sqlcom.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = txtCustCode.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.Parameters.Add("@SIMAlterCharges", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtAlterCharges.Text);
                            sqlcom.Parameters.Add("@SIMOtherCharges", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtOtherCharges.Text);
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from SALEINVDET Where SIDSERIES=@SIDSERIES And SIDNO=@SIDNO And SIDDATE=@SIDDATE And UnitCode='" + GlobalVariables.CUnitID + "'";
                            sqlcom.Parameters.Add("@SIDSERIES", SqlDbType.NVarChar).Value = ImSeries;
                            sqlcom.Parameters.Add("@SIDNO", SqlDbType.NVarChar).Value = ImNo;
                            sqlcom.Parameters.Add("@SIDDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(ImDate).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into SALEINVDET "
                                                        + " (SIDSYSDATE,SIDFNYR,SIDDATE,SIDNO,SIDSERIES,SIDPartyC,"
                                                        + " SIDBOXNO,SIDBARCODE,SIDARTNO,SIDARTID,SIDCOLID,"
                                                        + " SIDSIZID,SIDSCANQTY,SIDARTMRP,SIDARTWSP,SIDITMDISCPRCN,"
                                                        + "SIDITMDISCAMT,SIDITMNETAMT,SIDSGSTPRCN,SIDSGSTAMT,SIDCGSTPRCN,SIDCGSTAMT,SIDIGSTPRCN,SIDIGSTAMT,CustCode,UnitCode  )"
                                                        + " values(@SIDSYSDATE,@SIDFNYR,@SIDDATE,@SIDNO,@SIDSERIES,@SIDPartyC,"
                                                        + " @SIDBOXNO,@SIDBARCODE,@SIDARTNO,@SIDARTID,@SIDCOLID,"
                                                        + " @SIDSIZID,@SIDSCANQTY,@SIDARTMRP,@SIDARTWSP,@SIDITMDISCPRCN,@SIDITMDISCAMT,"
                                                        + " @SIDITMNETAMT,@SIDSGSTPRCN,@SIDSGSTAMT,@SIDCGSTPRCN,@SIDCGSTAMT,@SIDIGSTPRCN,@SIDIGSTAMT,@CustCode,@UnitCode)";
                            sqlcom.Parameters.Add("@SIDSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIDFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIDDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(lblCashMemoDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIDNO", SqlDbType.NVarChar).Value = lblCashMemoNo.Text.Trim(); ;
                            sqlcom.Parameters.Add("@SIDSERIES", SqlDbType.NVarChar).Value = Series;
                            sqlcom.Parameters.Add("@SIDPartyC", SqlDbType.NVarChar).Value = "248";
                            sqlcom.Parameters.Add("@SIDBOXNO", SqlDbType.NVarChar).Value = "0";
                            sqlcom.Parameters.Add("@SIDBARCODE", SqlDbType.NVarChar).Value = currentrow["SIDBARCODE"].ToString();
                            sqlcom.Parameters.Add("@SIDARTNO", SqlDbType.NVarChar).Value = currentrow["SIDARTNO"].ToString();
                            sqlcom.Parameters.Add("@SIDARTID", SqlDbType.NVarChar).Value = currentrow["SIDARTID"].ToString();
                            sqlcom.Parameters.Add("@SIDCOLID", SqlDbType.NVarChar).Value = currentrow["SIDCOLID"].ToString();
                            sqlcom.Parameters.Add("@SIDSIZID", SqlDbType.NVarChar).Value = currentrow["SIDSIZID"].ToString();
                            sqlcom.Parameters.Add("@SIDSCANQTY", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDSCANQTY"]);
                            sqlcom.Parameters.Add("@SIDARTMRP", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDARTMRP"]);
                            sqlcom.Parameters.Add("@SIDARTWSP", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDARTWSP"]);
                            sqlcom.Parameters.Add("@SIDITMDISCPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDITMDISCPRCN"]);
                            sqlcom.Parameters.Add("@SIDITMDISCAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDITMDISCAMT"]);
                            sqlcom.Parameters.Add("@SIDITMNETAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDITMNETAMT"]);
                            sqlcom.Parameters.Add("@SIDSGSTPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDSGSTPER"]);
                            sqlcom.Parameters.Add("@SIDSGSTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDSGSTAMT"]);
                            sqlcom.Parameters.Add("@SIDCGSTPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDCGSTPER"]);
                            sqlcom.Parameters.Add("@SIDCGSTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDCGSTAMT"]);
                            sqlcom.Parameters.Add("@SIDIGSTPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDIGSTPER"]);
                            sqlcom.Parameters.Add("@SIDIGSTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDIGSTAMT"]);
                            sqlcom.Parameters.Add("@CustCode", SqlDbType.NVarChar).Value = txtCustCode.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            if (Convert.ToDecimal(currentrow["SIDSCANQTY"]) > 0)
                            {
                                ProjectFunctions.GetDataSet("Update SFDET Set Used='Y' Where SFDBARCODE='" + currentrow["SIDBARCODE"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                            }
                            else
                            {
                                ProjectFunctions.GetDataSet("Update SFDET Set Used='N' Where SFDBARCODE='" + currentrow["SIDBARCODE"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                            }

                        }

                        if (Series == "S")
                        {
                            if (HoldTag.ToUpper() == "UNHOLD")
                            {
                                File.Delete(Application.StartupPath + @"\" + txtCustMobileNo.Text + ".xml");
                            }
                            else
                            {
                                HoldTag = String.Empty;
                            }

                            XtraMessageBox.Show("Cash Memo Saved Successfully");

                        }
                        else
                        {
                            File.Delete(Application.StartupPath + @"\" + txtCustMobileNo.Text + ".xml");



                        }

                        sqlcon.Close();
                        //this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void Cashmemo_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                btnUnhold.Visible = false;
                if (s1 == "&Add")
                {
                    this.Location = new Point(0, 0);
                    this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                    txtCustMobileNo.Focus();
                    lblCashMemoDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    chInclusive.Checked = true;
                    lblCashMemoNo.Text = ProjectFunctions.GetDataSet("select isnull(max(SIMNO),0)+1 from SALEINVMAIN where SIMSERIES='S' And SIMFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'").Tables[0].Rows[0][0].ToString();
                }
                if (s1 == "Edit")
                {


                    LoadBillForEdit(ImNo, ImDate, "S");




                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SimpleButton16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SimpleButton13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void BtnInvoiceConfig_Click(object sender, EventArgs e)
        {
            if (chExclusive.Checked)
            {
                chInclusive.Checked = true;
                chExclusive.Checked = false;
                calculation();
            }
            else
            {
                chExclusive.Checked = true;
                chInclusive.Checked = false;
                calculation();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //s1 = "&Add";
            //Cashmemo_Load(null, e);
        }

        private void BtnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerMst frm = new frmCustomerMst() { s1 = "Edit", Text = "Customer Edition", CAFSYSID = txtCustCode.Text };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(this.Parent);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnAddCashMemo_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                s1 = "&Add";
                Text = "Cash Memo Addition";
                Cashmemo_Load(null, e);
                calculation();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnTopBill_Click(object sender, EventArgs e)
        {
            try

            {
                DataSet dsGetData = ProjectFunctions.GetDataSet("Select SIMDATE,SIMNO,SIMSERIES from SALEINVMAIN  Where SIMSERIES='S' And  SIMNO='1' And SIMFNYR='" + GlobalVariables.FinancialYear + "' ANd UnitCode='" + GlobalVariables.CUnitID + "'");
                if (dsGetData.Tables[0].Rows.Count > 0)
                {
                    s1 = "Edit";
                    Text = "Cash Memo Edition";
                    ImDate = Convert.ToDateTime(dsGetData.Tables[0].Rows[0]["SIMDATE"]);
                    ImNo = dsGetData.Tables[0].Rows[0]["SIMNO"].ToString();
                    ImSeries = "S";
                    Cashmemo_Load(null, e);
                }
                else
                {
                    ProjectFunctions.SpeakError("No Bill Found");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnBottomBill_Click(object sender, EventArgs e)
        {
            DataSet dsGetData = ProjectFunctions.GetDataSet("Select SIMDATE,SIMNO,SIMSERIES from SALEINVMAIN  Where SIMSERIES='S' And  SIMNO=(Select max(SIMNO) from SALEINVMAIN Where SIMSERIES='S' And  SIMFNYR='" + GlobalVariables.FinancialYear + "' ANd UnitCode='" + GlobalVariables.CUnitID + "') And SIMFNYR='" + GlobalVariables.FinancialYear + "' ANd UnitCode='" + GlobalVariables.CUnitID + "'");
            if (dsGetData.Tables[0].Rows.Count > 0)
            {
                s1 = "Edit";
                Text = "Cash Memo Edition";
                ImDate = Convert.ToDateTime(dsGetData.Tables[0].Rows[0]["SIMDATE"]);
                ImNo = dsGetData.Tables[0].Rows[0]["SIMNO"].ToString();
                ImSeries = "S";
                Cashmemo_Load(null, e);
            }
            else
            {
                ProjectFunctions.SpeakError("No Bill Found");
            }
        }

        private void BtnNextBill_Click(object sender, EventArgs e)
        {
            try

            {
                DataSet dsGetData = ProjectFunctions.GetDataSet("Select SIMDATE,SIMNO,SIMSERIES from SALEINVMAIN  Where SIMSERIES='S' And  SIMNO='" + (Convert.ToInt64(lblCashMemoNo.Text) + 1) + "' And SIMFNYR='" + GlobalVariables.FinancialYear + "' ANd UnitCode='" + GlobalVariables.CUnitID + "'");
                if (dsGetData.Tables[0].Rows.Count > 0)
                {
                    s1 = "Edit";
                    Text = "Cash Memo Edition";
                    ImDate = Convert.ToDateTime(dsGetData.Tables[0].Rows[0]["SIMDATE"]);
                    ImNo = dsGetData.Tables[0].Rows[0]["SIMNO"].ToString();
                    ImSeries = "S";
                    Cashmemo_Load(null, e);
                }
                else
                {
                    ProjectFunctions.SpeakError("No Bill Found");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnPreviousBill_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet dsGetData = ProjectFunctions.GetDataSet("Select SIMDATE,SIMNO,SIMSERIES from SALEINVMAIN  Where SIMSERIES='S' And  SIMNO='" + (Convert.ToInt64(lblCashMemoNo.Text) - 1) + "' And SIMFNYR='" + GlobalVariables.FinancialYear + "' ANd UnitCode='" + GlobalVariables.CUnitID + "'");
                if (dsGetData.Tables[0].Rows.Count > 0)
                {
                    s1 = "Edit";
                    Text = "Cash Memo Edition";
                    ImDate = Convert.ToDateTime(dsGetData.Tables[0].Rows[0]["SIMDATE"]);
                    ImNo = dsGetData.Tables[0].Rows[0]["SIMNO"].ToString();
                    ImSeries = "S";
                    Cashmemo_Load(null, e);
                }
                else
                {
                    ProjectFunctions.SpeakError("No Bill Found");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                SaveInvoice();

                s1 = "Edit";
                Text = "Cash Memo Edition";
                ImDate = Convert.ToDateTime(lblCashMemoDate.Text);
                ImNo = lblCashMemoNo.Text;
                ImSeries = "S";
                Cashmemo_Load(null, e);


                //Transaction.Cashmemo frm = new Transaction.Cashmemo() {,  , , };
                //var P = ProjectFunctions.GetPositionInForm(this);
                //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //frm.ShowDialog(Parent);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TxtCustCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtCustName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtCustDetails_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void GroupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtMainDisc_EditValueChanged(object sender, EventArgs e)
        {
            calculation();
        }

        private void BtnCard_Click(object sender, EventArgs e)
        {
            try
            {
                SaveInvoice();
                s1 = "Edit";
                Text = "Cash Memo Edition";
                ImDate = Convert.ToDateTime(lblCashMemoDate.Text);
                ImNo = lblCashMemoNo.Text;
                ImSeries = "S";
                Cashmemo_Load(null, e);
                Pos.Card frm = new Pos.Card() { MemoNo = lblCashMemoNo.Text, MemoDate = Convert.ToDateTime(lblCashMemoDate.Text), TotalMemoAmount = Convert.ToDecimal(lblNetPayable.Text) };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(this.Parent);


                dt.Clear();
                s1 = "&Add";
                Text = "Cash Memo Addition";
                Cashmemo_Load(null, e);
                calculation();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnCash_Click(object sender, EventArgs e)
        {
            try
            {
                SaveInvoice();
                s1 = "Edit";
                Text = "Cash Memo Edition";
                ImDate = Convert.ToDateTime(lblCashMemoDate.Text);
                ImNo = lblCashMemoNo.Text;
                ImSeries = "S";
                Cashmemo_Load(null, e);
                WindowsFormsApplication1.Transaction.CashTender frm = new WindowsFormsApplication1.Transaction.CashTender() { MemoNo = lblCashMemoNo.Text, MemoDate = Convert.ToDateTime(lblCashMemoDate.Text), TotalMemoAmount = Convert.ToDecimal(lblNetPayable.Text) };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(this.Parent);

                dt.Clear();
                s1 = "&Add";
                Text = "Cash Memo Addition";
                Cashmemo_Load(null, e);
                calculation();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void BtnPG_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerMst frm = new frmCustomerMst() { s1 = "Edit", Text = "Customer Edition", CAFSYSID = txtCustCode.Text };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(this.Parent);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void HyperlinkLabelControl2_Click(object sender, EventArgs e)
        {

        }

        private void InfoGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F9)
                {

                    if (txtItemDiscPer.Enabled)
                    {
                        txtItemDiscPer.Enabled = false;
                        labelControl19.BackColor = Color.Transparent;

                    }
                    else
                    {
                        txtItemDiscPer.Enabled = true;
                        labelControl19.BackColor = Color.Green;
                    }

                    txtItemDiscPer.Focus();


                }



                if (e.KeyCode == Keys.F11)
                {

                    if (txtItemFlatRate.Enabled)
                    {
                        txtItemFlatRate.Enabled = false;
                        labelControl22.BackColor = Color.Transparent;

                    }
                    else
                    {
                        txtItemFlatRate.Enabled = true;
                        labelControl22.BackColor = Color.Green;
                    }

                    txtItemFlatRate.Focus();


                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        private void InfoGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (InfoGrid.DataSource != null)
                {
                    DataRow currentrow = InfoGridView.GetDataRow(InfoGridView.FocusedRowHandle);

                    rowindex = InfoGridView.FocusedRowHandle;
                    txtItemMRP.EditValue = currentrow["SIDARTMRP"];
                    txtItemDiscAMount.EditValue = currentrow["SIDITMDISCAMT"];
                    txtItemDiscPer.EditValue = currentrow["SIDITMDISCPRCN"];

                    txtItemFlatRate.EditValue = currentrow["SIDITMNETAMT"];

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void txtItemDiscPer_EditValueChanged(object sender, EventArgs e)
        {
            if (txtItemDiscPer.Enabled && Convert.ToDecimal(txtItemDiscPer.Text) > 0)
            {
                txtItemDiscAMount.EditValue = ((Convert.ToDecimal(txtItemMRP.Text) * Convert.ToDecimal(txtItemDiscPer.Text)) / 100);
                txtItemFlatRate.EditValue = Convert.ToDecimal(txtItemMRP.Text) - Convert.ToDecimal(txtItemDiscAMount.Text);
            }
        }

        private void txtItemDiscPer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDITMDISCAMT"], Convert.ToDecimal(txtItemDiscAMount.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDITMDISCPRCN"], Convert.ToDecimal(txtItemDiscPer.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDARTMRP"], Convert.ToDecimal(txtItemMRP.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDITMNETAMT"], Convert.ToDecimal(txtItemFlatRate.Text));
                    calculation();

                    InfoGridView.Focus();

                    txtItemDiscAMount.EditValue = Convert.ToDecimal("0");
                    txtItemDiscPer.EditValue = Convert.ToDecimal("0");
                    txtItemMRP.EditValue = Convert.ToDecimal("0");
                    txtItemFlatRate.EditValue = Convert.ToDecimal("0");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void txtItemFlatRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDITMDISCAMT"], Convert.ToDecimal(txtItemDiscAMount.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDITMDISCPRCN"], Convert.ToDecimal(txtItemDiscPer.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDARTMRP"], Convert.ToDecimal(txtItemMRP.Text));
                    InfoGridView.SetRowCellValue(rowindex, InfoGridView.Columns["SIDITMNETAMT"], Convert.ToDecimal(txtItemFlatRate.Text));
                    calculation();

                    InfoGridView.Focus();





                    txtItemDiscAMount.EditValue = Convert.ToDecimal("0");
                    txtItemDiscPer.EditValue = Convert.ToDecimal("0");
                    txtItemMRP.EditValue = Convert.ToDecimal("0");
                    txtItemFlatRate.EditValue = Convert.ToDecimal("0");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void txtItemFlatRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtItemFlatRate.Enabled && Convert.ToDecimal(txtItemFlatRate.Text) > 0)
                {
                    txtItemDiscAMount.EditValue = (Convert.ToDecimal(txtItemMRP.Text) - Convert.ToDecimal(txtItemFlatRate.Text));
                    txtItemDiscPer.EditValue = 100 - ((Convert.ToDecimal(txtItemFlatRate.Text) / Convert.ToDecimal(txtItemMRP.Text)) * 100);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void InfoGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete Current Record", (o1, e1) =>
                {
                    ProjectFunctions.DeleteCurrentRowOnRightClick(InfoGrid, InfoGridView);
                    dt.AcceptChanges();
                    calculation();
                    if (dt.Rows.Count == 0)
                    {
                        InfoGrid.DataSource = null;
                    }
                }));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void TxtCustMobileNo_Enter(object sender, EventArgs e)
        {
            if (txtCustMobileNo.Text.Length == 0)
            {
                txtCustMobileNo.Text = "0000000000";
                DataSet ds = ProjectFunctions.GetDataSet(" select CAFSYSID,CAFFNAME+' '+ CAFMNAME+' '+ CAFLNAME as CAFFNAME, CAFADD+', '+CAFADD1+', '+CAFADD2 as CAFADD,CAFMOBILE from CAFINFO Where  CAFMOBILE='" + txtCustMobileNo.Text.Trim() + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustMobileNo.Text = ds.Tables[0].Rows[0]["CAFMOBILE"].ToString();
                    txtCustCode.Text = ds.Tables[0].Rows[0]["CAFSYSID"].ToString();
                    txtCustName.Text = ds.Tables[0].Rows[0]["CAFFNAME"].ToString();
                    txtCustDetails.Text = ds.Tables[0].Rows[0]["CAFADD"].ToString();

                    txtBarCode.Focus();
                }
                CheckHoldEnable();
            }
        }

        private void HelpGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Card Grid View", ((o1, e1) =>
            {
                DevExpress.XtraGrid.Views.Card.CardView View1 = new DevExpress.XtraGrid.Views.Card.CardView();
                HelpGrid.MainView = View1;
                View1.GridControl = HelpGrid;
                View1.Name = "HelpGridView";
                View1.OptionsBehavior.Editable = false;

            })));
            e.Menu.Items.Add(new DXMenuItem("Window Explorer View", ((o1, e1) =>
            {
                DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView View1 = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
                HelpGrid.MainView = View1;
                View1.GridControl = HelpGrid;
                View1.Name = "HelpGridView";
                View1.OptionsBehavior.Editable = false;

            })));
            e.Menu.Items.Add(new DXMenuItem("Tile View", ((o1, e1) =>
            {
                DevExpress.XtraGrid.Views.Tile.TileView View1 = new DevExpress.XtraGrid.Views.Tile.TileView();
                HelpGrid.MainView = View1;
                View1.GridControl = HelpGrid;
                View1.Name = "HelpGridView";
                View1.OptionsBehavior.Editable = false;

            })));
            e.Menu.Items.Add(new DXMenuItem("Layout View", ((o1, e1) =>
            {
                DevExpress.XtraGrid.Views.Layout.LayoutView View1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
                HelpGrid.MainView = View1;
                View1.GridControl = HelpGrid;
                View1.Name = "HelpGridView";
                View1.OptionsBehavior.Editable = false;

            })));
            e.Menu.Items.Add(new DXMenuItem("Grid View", ((o1, e1) =>
            {
                DevExpress.XtraGrid.Views.Grid.GridView View1 = new DevExpress.XtraGrid.Views.Grid.GridView();
                HelpGrid.MainView = View1;
                View1.GridControl = HelpGrid;
                View1.Name = "HelpGridView";
                View1.OptionsBehavior.Editable = false;

            })));

            e.Menu.Items.Add(new DXMenuItem("Banded Grid View", ((o1, e1) =>
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridView View1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
                HelpGrid.MainView = View1;
                View1.GridControl = HelpGrid;
                View1.Name = "HelpGridView";
                View1.OptionsBehavior.Editable = false;

            })));

        }

        private void BtnHold_Click(object sender, EventArgs e)
        {
            dt.WriteXml(Application.StartupPath + @"\" + txtCustMobileNo.Text + ".xml");
        }

        private void CheckHoldEnable()
        {
            if (File.Exists(Application.StartupPath + @"\" + txtCustMobileNo.Text + ".xml"))
            {
                btnUnhold.Visible = true;
            }
            else
            {
                btnUnhold.Visible = false;
            }
        }


        private void BtnUnhold_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\" + txtCustMobileNo.Text + ".xml"))
            {
                HoldTag = "Unhold";
                XmlReader xmlFile;
                xmlFile = XmlReader.Create(Application.StartupPath + @"\" + txtCustMobileNo.Text + ".xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    InfoGrid.DataSource = dt;
                    InfoGridView.BestFitColumns();
                }
                else
                {
                    InfoGrid.DataSource = null;
                    InfoGridView.BestFitColumns();
                }

            }
        }

        private void Cashmemo_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.SalePopUPForAllWindows(this, e);
        }
    }
}
