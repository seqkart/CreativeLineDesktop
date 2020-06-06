using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmInvoiceMstAdd : DevExpress.XtraEditors.XtraForm
    {
        public String ProgCode { get; set; }
        public String s1 { get; set; }
        DataTable dt = new DataTable();
        DataTable dtWeight = new DataTable();
        public String ImNo { get; set; }
        public DateTime ImDate { get; set; }
        public String ImSeries { get; set; }
        String StkTransfer = String.Empty;
        Decimal AccMRPMarkDown = 0;
#pragma warning disable CS0169 // The field 'frmInvoiceMstAdd.SearchField' is never used
        String SearchField;
#pragma warning restore CS0169 // The field 'frmInvoiceMstAdd.SearchField' is never used
        DataSet dsPopUps = new DataSet();
        public frmInvoiceMstAdd()
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
            dt.Columns.Add("GRPHSNCODE", typeof(String));
            dsPopUps = ProjectFunctions.GetDataSet("sp_LoadBarPrintPopUps");
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.TextBoxVisualize(groupControl1);
            ProjectFunctions.TextBoxVisualize(groupControl10);
            ProjectFunctions.TextBoxVisualize(groupControl2);
            ProjectFunctions.TextBoxVisualize(groupControl3);
            ProjectFunctions.TextBoxVisualize(groupControl4);
            ProjectFunctions.TextBoxVisualize(groupControl5);
            ProjectFunctions.TextBoxVisualize(groupControl6);
            ProjectFunctions.TextBoxVisualize(groupControl7);
            ProjectFunctions.TextBoxVisualize(groupControl8);
            ProjectFunctions.TextBoxVisualize(groupControl9);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.GirdViewVisualize(InfoGridView);
            ProjectFunctions.GirdViewVisualize(HelpGridView);
            ProjectFunctions.GirdViewVisualize(PSGridView);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateDataForSaving()
        {

            if (InfoGrid.DataSource == null)
            {
                ProjectFunctions.SpeakError("Blank Bill Cannot Be Saved");
                txtDebitPartyCode.Focus();
                return false;

            }
            else
            {

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

            if (txtDebitPartyName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Debit Party");
                txtDebitPartyCode.Focus();
                return false;
            }
            if (txtActualWeight.Text.Length == 0)
            {
                txtActualWeight.Text = "0";
            }
            if (txtAmountDue.Text.Length == 0)
            {
                txtAmountDue.Text = "0";
            }
            if (txtBuiltyAmount.Text.Length == 0)
            {
                txtBuiltyAmount.Text = "0";
            }
            if (txtCHGWeight.Text.Length == 0)
            {
                txtCHGWeight.Text = "0";
            }
            if (txtCreditLimit.Text.Length == 0)
            {
                txtCreditLimit.Text = "0";
            }
            if (txtInsuranceAmount.Text.Length == 0)
            {
                txtInsuranceAmount.Text = "0";
            }
            if (txtInsurancePer.Text.Length == 0)
            {
                txtInsurancePer.Text = "0";
            }
            if (txtLedgerBalance.Text.Length == 0)
            {
                txtLedgerBalance.Text = "0";
            }
            if (txtMainDisc.Text.Length == 0)
            {
                txtMainDisc.Text = "0";
            }
            if (txtMainDiscVal.Text.Length == 0)
            {
                txtMainDiscVal.Text = "0";
            }
            if (txtNetAmount.Text.Length == 0)
            {
                txtNetAmount.Text = "0";
            }
            if (txtOctoriAmount.Text.Length == 0)
            {
                txtOctoriAmount.Text = "0";
            }
            if (txtPKGFrt.Text.Length == 0)
            {
                txtPKGFrt.Text = "0";
            }
            if (txtRNetAmount.Text.Length == 0)
            {
                txtRNetAmount.Text = "0";
            }
            if (txtRoundOffAmount.Text.Length == 0)
            {
                txtRoundOffAmount.Text = "0";
            }
            if (txtTotalDisc.Text.Length == 0)
            {
                txtTotalDisc.Text = "0";
            }
            if (txtTotalTaxAmount.Text.Length == 0)
            {
                txtTotalTaxAmount.Text = "0";
            }
            if (txtValueOfGoods.Text.Length == 0)
            {
                txtValueOfGoods.Text = "0";
            }
            if (txtActualWeight.Text.Length == 0)
            {
                txtActualWeight.Text = "0";
            }
            if (txtTotalBoxes.Text.Length == 0)
            {
                txtTotalBoxes.Text = "0";
            }
            return true;
        }


        private void PrepareDirectInvoice()
        {
            if (chDirect.Checked)
            {
                InfoGridView.Columns["SIDBARCODE"].Visible = false;
                InfoGridView.Columns["SIDCOLN"].Visible = false;
                InfoGridView.Columns["SIDSIZN"].Visible = false;
                InfoGridView.Columns["SIDBOXQTY"].Visible = false;
                InfoGridView.Columns["SIDBOXMRPVAL"].Visible = false;
                InfoGridView.Columns["SIDBOXWSPVAL"].Visible = false;
                InfoGridView.Columns["SIDARTID"].Visible = false;
                InfoGridView.Columns["SIDCOLID"].Visible = false;
                InfoGridView.Columns["SIDSIZID"].Visible = false;
                InfoGridView.Columns["SIDPSDATE"].Visible = false;
                InfoGridView.Columns["SIDPSID"].Visible = false;
                InfoGridView.Columns["SIDPSNO"].Visible = false;
                //InfoGridView.Columns["TAXCODE"].Visible = false;
                //InfoGridView.Columns["GRPHSNCODE"].Visible = false;
            }
        }


        private void calculation()
        {
            InfoGridView.CloseEditor();
            InfoGridView.UpdateCurrentRow();
            BeginInvoke(new MethodInvoker(delegate
            {
                InfoGridView.PostEditor();
                InfoGridView.UpdateCurrentRow();
            }));

            String LCTag = ProjectFunctions.GetDataSet("Select AccLcTag from ActMst Where AccCode='" + txtDebitPartyCode.Text + "'").Tables[0].Rows[0]["AccLcTag"].ToString();

#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
            int i = 0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used

            DataSet ds = new DataSet();
            Decimal MainDiscAmount = 0;
            Decimal ValueOfGoods = 0;
            Decimal SumValueOfGoods = 0;
            Decimal SumRowDiscAmount = 0;
            Decimal SumCGSTAmount = 0;
            Decimal SumSGSTAmount = 0;
            Decimal SumIGSTAmount = 0;
            foreach (DataRow dr in dt.Rows)
            {


                Decimal WSP = 0;
                if (chInclusive.Checked)
                {
                    Decimal TaxRate = Convert.ToDecimal(dr["SIDCGSTPER"]) + Convert.ToDecimal(dr["SIDSGSTPER"]) + Convert.ToDecimal(dr["SIDIGSTPER"]);
                    WSP = Convert.ToDecimal(dr["SIDARTMRP"]) - ((Convert.ToDecimal(dr["SIDARTMRP"]) * TaxRate) / (100 + TaxRate));
                }

                else
                {
                    WSP = (Convert.ToDecimal(dr["SIDARTMRP"]));
                }



                if (AccMRPMarkDown > 0)
                {
                    WSP = WSP - ((WSP * AccMRPMarkDown) / 100);
                }
                else
                {
                    WSP = WSP - ((WSP * Convert.ToDecimal(dr["ARTMARGIN"])) / 100);

                }
                dr["SIDARTWSP"] = Math.Round(WSP, 2);

                if (StkTransfer.ToString().ToUpper() == "Y")
                {
                    foreach (DataRow drTax in dt.Rows)
                    {

                        dr["SIDARTWSP"] = dr["SIDARTMRP"];
                    }
                }
                if (Convert.ToDecimal(dr["SIDITMDISCPRCN"]) > 0)
                {
                    dr["SIDITMDISCPRCN"] = Convert.ToDecimal(dr["SIDITMDISCPRCN"]) - Convert.ToDecimal(txtMainDisc.Text);
                }


                Decimal RowDiscAmount = Math.Round((Convert.ToDecimal(dr["SIDSCANQTY"]) * ((Convert.ToDecimal(dr["SIDARTWSP"]) * Convert.ToDecimal(dr["SIDITMDISCPRCN"])) / 100)), 2);
                Decimal TempValueOfGoods = Math.Round(((Convert.ToDecimal(dr["SIDSCANQTY"]) * Convert.ToDecimal(dr["SIDARTWSP"])) - RowDiscAmount), 2);
                Decimal TempMainDisc = Math.Round((TempValueOfGoods * Convert.ToDecimal(txtMainDisc.Text)) / 100, 2);


                MainDiscAmount = Math.Round(MainDiscAmount + TempMainDisc, 2);
                ValueOfGoods = Math.Round(TempValueOfGoods - TempMainDisc, 2);

                SumRowDiscAmount = Math.Round(SumRowDiscAmount + RowDiscAmount, 2);
                dr["SIDITMDISCAMT"] = (RowDiscAmount + TempMainDisc) * Convert.ToDecimal(dr["SIDSCANQTY"]);
                dr["SIDITMNETAMT"] = ValueOfGoods;
                if (Convert.ToDecimal(dr["SIDITMDISCAMT"]) > 0)
                {
                    dr["SIDITMDISCPRCN"] = 100 - ((Convert.ToDecimal(dr["SIDITMNETAMT"]) / Convert.ToDecimal(dr["SIDARTWSP"])) * 100);
                }
                else
                {
                    dr["SIDITMDISCPRCN"] = 0;
                }
                Decimal CGSTAmount = 0;
                Decimal SGSTAmount = 0;
                Decimal IGSTAmount = 0;


                //if (i == 0)
                //{
                var str = "Exec [sp_LoadTaxMstFInvoice] @PrdCode='" + dr["SIDARTID"].ToString() + "',";
                str = str + "@LCTag='" + LCTag + "',@ValueOfGoods='" + ValueOfGoods / Convert.ToDecimal(dr["SIDSCANQTY"]) + "'";

                ds = ProjectFunctions.GetDataSet(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr["SIDCGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxCGSTRate"]);
                    dr["SIDSGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSGSTRate"]);
                    dr["SIDIGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxIGSTRate"]);
                }
                //    i++;
                //}
                //else
                //{
                //    dr["SIDCGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxCGSTRate"]);
                //    dr["SIDSGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSGSTRate"]);
                //    dr["SIDIGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxIGSTRate"]);
                //}


                if (StkTransfer.ToString().ToUpper() == "Y")
                {
                    foreach (DataRow drTax in dt.Rows)
                    {
                        drTax["SIDCGSTPER"] = Convert.ToDecimal("0");
                        drTax["SIDSGSTPER"] = Convert.ToDecimal("0");
                        drTax["SIDIGSTPER"] = Convert.ToDecimal("0");
                        //dr["SIDARTWSP"] = dr["SIDARTMRP"];
                    }
                }

                CGSTAmount = Math.Round(((ValueOfGoods * Convert.ToDecimal(dr["SIDCGSTPER"])) / 100), 2);
                SGSTAmount = Math.Round(((ValueOfGoods * Convert.ToDecimal(dr["SIDSGSTPER"])) / 100), 2);
                IGSTAmount = Math.Round(((ValueOfGoods * Convert.ToDecimal(dr["SIDIGSTPER"])) / 100), 2);

                SumCGSTAmount = SumCGSTAmount + CGSTAmount;
                SumSGSTAmount = SumSGSTAmount + SGSTAmount;
                SumIGSTAmount = SumIGSTAmount + IGSTAmount;
                SumValueOfGoods = SumValueOfGoods + ValueOfGoods;
                dr["SIDCGSTAMT"] = CGSTAmount;
                dr["SIDSGSTAMT"] = SGSTAmount;
                dr["SIDIGSTAMT"] = IGSTAmount;



            }


            txtTotalTaxAmount.Text = (SumCGSTAmount + SumSGSTAmount + SumIGSTAmount).ToString("0.00");
            txtMainDiscVal.Text = MainDiscAmount.ToString("0.00");
            txtValueOfGoods.Text = SumValueOfGoods.ToString("0.00");
            txtTotalDisc.Text = SumRowDiscAmount.ToString("0.00");
            txtInsuranceAmount.Text = ((Convert.ToDecimal(txtValueOfGoods.Text) * Convert.ToDecimal(txtInsurancePer.Text)) / 100).ToString("0.00");
            txtNetAmount.Text = (SumValueOfGoods + SumCGSTAmount + SumSGSTAmount + SumIGSTAmount + Convert.ToDecimal(txtInsuranceAmount.Text) + Convert.ToDecimal(txtPKGFrt.Text) + Convert.ToDecimal(txtOctoriAmount.Text)).ToString("0.00");
            txtRNetAmount.Text = Math.Round(Convert.ToDecimal(txtNetAmount.Text), 0).ToString("0.00");

            txtRoundOffAmount.Text = (Convert.ToDecimal(txtRNetAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)).ToString("0.00");



            TaxCodeWiseSummary();
            HSNWiseSummary();
        }


        private void TaxCodeWiseSummary()
        {
            DataTable dtTax1 = new DataTable();

            dtTax1.Columns.Add("SIDSCANQTY", typeof(Decimal));
            dtTax1.Columns.Add("SIDITMNETAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDSGSTAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDCGSTAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDIGSTAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDCGSTPER", typeof(Decimal));
            dtTax1.Columns.Add("SIDSGSTPER", typeof(Decimal));
            dtTax1.Columns.Add("SIDIGSTPER", typeof(Decimal));
            dtTax1.Columns.Add("TAXCODE", typeof(String));
            var distinctRows = (from DataRow dRow in dt.Rows
                                select (Convert.ToDecimal(dRow["SIDCGSTPER"]) + Convert.ToDecimal(dRow["SIDSGSTPER"]) + Convert.ToDecimal(dRow["SIDIGSTPER"]))).Distinct();
            foreach (var v in distinctRows)
            {
                Decimal SIDSCANQTY = 0;
                Decimal SIDITMNETAMT = 0;
                Decimal SIDSGSTAMT = 0;
                Decimal SIDCGSTAMT = 0;
                Decimal SIDIGSTAMT = 0;
                Decimal SIDCGSTPER = 0;
                Decimal SIDSGSTPER = 0;
                Decimal SIDIGSTPER = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    if ((Convert.ToDecimal(dr["SIDCGSTPER"]) + Convert.ToDecimal(dr["SIDSGSTPER"]) + Convert.ToDecimal(dr["SIDIGSTPER"])).ToString("0.00") == Convert.ToDecimal(v).ToString("0.00"))
                    {
                        SIDSCANQTY = SIDSCANQTY + Convert.ToDecimal(dr["SIDSCANQTY"]);
                        SIDITMNETAMT = SIDITMNETAMT + Convert.ToDecimal(dr["SIDITMNETAMT"]);
                        SIDSGSTAMT = SIDSGSTAMT + Convert.ToDecimal(dr["SIDSGSTAMT"]);
                        SIDCGSTAMT = SIDCGSTAMT + Convert.ToDecimal(dr["SIDCGSTAMT"]);
                        SIDIGSTAMT = SIDIGSTAMT + Convert.ToDecimal(dr["SIDIGSTAMT"]);
                        SIDCGSTPER = Convert.ToDecimal(dr["SIDCGSTPER"]);
                        SIDSGSTPER = Convert.ToDecimal(dr["SIDSGSTPER"]);
                        SIDIGSTPER = Convert.ToDecimal(dr["SIDIGSTPER"]);
                    }
                }

                DataRow newrow1 = dtTax1.NewRow();
                newrow1["TAXCODE"] = v.ToString();
                newrow1["SIDSCANQTY"] = SIDSCANQTY;
                newrow1["SIDITMNETAMT"] = SIDITMNETAMT;
                newrow1["SIDSGSTAMT"] = SIDSGSTAMT;
                newrow1["SIDCGSTAMT"] = SIDCGSTAMT;
                newrow1["SIDIGSTAMT"] = SIDIGSTAMT;
                newrow1["SIDCGSTPER"] = SIDCGSTPER;
                newrow1["SIDSGSTPER"] = SIDSGSTPER;
                newrow1["SIDIGSTPER"] = SIDIGSTPER;
                dtTax1.Rows.Add(newrow1);
            }

            if (dtTax1.Rows.Count > 0)
            {
                TaxCodeGrid.DataSource = dtTax1;
                gridView3.BestFitColumns();
            }
            else
            {
                TaxCodeGrid.DataSource = null;
            }
        }
        private void HSNWiseSummary()
        {
            DataTable dtTax1 = new DataTable();

            dtTax1.Columns.Add("SIDSCANQTY", typeof(Decimal));
            dtTax1.Columns.Add("SIDITMNETAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDSGSTAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDCGSTAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDIGSTAMT", typeof(Decimal));
            dtTax1.Columns.Add("SIDCGSTPER", typeof(Decimal));
            dtTax1.Columns.Add("SIDSGSTPER", typeof(Decimal));
            dtTax1.Columns.Add("SIDIGSTPER", typeof(Decimal));
            dtTax1.Columns.Add("GRPHSNCODE", typeof(String));


            var distinctRows = (from DataRow dRow in dt.Rows
                                select (Convert.ToDecimal(dRow["SIDCGSTPER"]) + Convert.ToDecimal(dRow["SIDSGSTPER"]) + Convert.ToDecimal(dRow["SIDIGSTPER"])).ToString("0.00") + dRow["GRPHSNCODE"]).Distinct();
            foreach (var v in distinctRows)

            {
                Decimal SIDSCANQTY = 0;
                Decimal SIDITMNETAMT = 0;
                Decimal SIDSGSTAMT = 0;
                Decimal SIDCGSTAMT = 0;
                Decimal SIDIGSTAMT = 0;
                Decimal SIDCGSTPER = 0;
                Decimal SIDSGSTPER = 0;
                Decimal SIDIGSTPER = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    if (((Convert.ToDecimal(dr["SIDCGSTPER"]) + Convert.ToDecimal(dr["SIDSGSTPER"]) + Convert.ToDecimal(dr["SIDIGSTPER"])).ToString("0.00") + dr["GRPHSNCODE"]) == v.ToString())
                    {
                        SIDSCANQTY = SIDSCANQTY + Convert.ToDecimal(dr["SIDSCANQTY"]);
                        SIDITMNETAMT = SIDITMNETAMT + Convert.ToDecimal(dr["SIDITMNETAMT"]);
                        SIDSGSTAMT = SIDSGSTAMT + Convert.ToDecimal(dr["SIDSGSTAMT"]);
                        SIDCGSTAMT = SIDCGSTAMT + Convert.ToDecimal(dr["SIDCGSTAMT"]);
                        SIDIGSTAMT = SIDIGSTAMT + Convert.ToDecimal(dr["SIDIGSTAMT"]);
                        SIDCGSTPER = Convert.ToDecimal(dr["SIDCGSTPER"]);
                        SIDSGSTPER = Convert.ToDecimal(dr["SIDSGSTPER"]);
                        SIDIGSTPER = Convert.ToDecimal(dr["SIDIGSTPER"]);
                    }
                }

                DataRow newrow1 = dtTax1.NewRow();
                newrow1["GRPHSNCODE"] = v.ToString();
                newrow1["SIDSCANQTY"] = SIDSCANQTY;
                newrow1["SIDITMNETAMT"] = SIDITMNETAMT;
                newrow1["SIDSGSTAMT"] = SIDSGSTAMT;
                newrow1["SIDCGSTAMT"] = SIDCGSTAMT;
                newrow1["SIDIGSTAMT"] = SIDIGSTAMT;
                newrow1["SIDCGSTPER"] = SIDCGSTPER;
                newrow1["SIDSGSTPER"] = SIDSGSTPER;
                newrow1["SIDIGSTPER"] = SIDIGSTPER;
                dtTax1.Rows.Add(newrow1);
            }

            if (dtTax1.Rows.Count > 0)
            {
                HSNGrid.DataSource = dtTax1;
                gridView3.BestFitColumns();
            }
            else
            {
                HSNGrid.DataSource = null;
            }
        }

        private bool ValidateData()
        {

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


            return true;
        }
        private void ShowPendingPSlips()
        {
            DataSet dsPS = ProjectFunctions.GetDataSet("sp_LoadPackingSlipMstFInvoice '" + txtDebitPartyCode.Text + "'");
            if (dsPS.Tables[0].Rows.Count > 0)
            {
                dsPS.Tables[0].Columns.Add("Select", typeof(bool));
                foreach (DataRow dr in dsPS.Tables[0].Rows)
                {
                    dr["Select"] = false;
                }


                if (s1 == "Edit")
                {
                    DataSet dsPSEdit = ProjectFunctions.GetDataSet("sp_LoadPackingSlipMstFInvoiceEdit '" + txtSerialNo.Text + "','" + Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd") + "','" + txtserial.Text + "','" + GlobalVariables.CUnitID + "','" + GlobalVariables.FinancialYear + "'");
                    if (dsPSEdit.Tables[0].Rows.Count > 0)
                    {
                        dsPSEdit.Tables[0].Columns.Add("Select", typeof(bool));
                        foreach (DataRow dr in dsPSEdit.Tables[0].Rows)
                        {
                            dr["Select"] = true;
                        }
                        dsPS.Tables[0].Merge(dsPSEdit.Tables[0]);
                    }
                }
                PSGrid.DataSource = dsPS.Tables[0];
                PSGridView.BestFitColumns();
            }
            else
            {

                if (s1 == "&Add")
                {

                    ProjectFunctions.SpeakError("No Packing Slips Pending");
                    PSGrid.DataSource = null;
                }
                else
                {
                    if (s1 == "Edit")
                    {
                        DataSet dsPSEdit = ProjectFunctions.GetDataSet("sp_LoadPackingSlipMstFInvoiceEdit '" + txtSerialNo.Text + "','" + Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd") + "','" + txtserial.Text + "','" + GlobalVariables.CUnitID + "','" + GlobalVariables.FinancialYear + "'");
                        if (dsPSEdit.Tables[0].Rows.Count > 0)
                        {
                            dsPSEdit.Tables[0].Columns.Add("Select", typeof(bool));
                            foreach (DataRow dr in dsPSEdit.Tables[0].Rows)
                            {
                                dr["Select"] = true;
                            }
                            PSGrid.DataSource = dsPSEdit.Tables[0];
                        }
                        else
                        {
                            PSGrid.DataSource = null;
                        }
                    }
                }
            }
        }
        private void frmInvoiceMstAdd_Load(object sender, EventArgs e)
        {
            SetMyControls();

            if (s1 == "&Add")
            {
                txtDebitPartyCode.Focus();
                txtserial.Text = string.Empty;
                txtTempInvoiceSeries.Text = txtserial.Text;
                txtTempInvoiceNo.Text = txtSerialNo.Text;
                dtInvoiceDate.EditValue = DateTime.Now;
                txtTempInvoiceDate.EditValue = Convert.ToDateTime(dtInvoiceDate.EditValue).ToString("dd-MM-yyyy");
                chPackingSlip.Checked = true;
                panelControl1.Visible = false;
                chRegular.Checked = true;
                chExclusive.Checked = true;

            }
            if (s1 == "Edit")
            {

                DataSet ds = ProjectFunctions.GetDataSet("[sp_LoadInvoiceMstFEDit] '" + ImDate.Date.ToString("yyyy-MM-dd") + "','" + ImNo + "','" + ImSeries + "','" + GlobalVariables.CUnitID + "','" + GlobalVariables.FinancialYear + "'");



                StkTransfer = ds.Tables[0].Rows[0]["AccStkTrf"].ToString();

                dtInvoiceDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"]).ToString("yyyy-MM-dd");
                txtSerialNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                txtserial.Text = ds.Tables[0].Rows[0]["BillSeries"].ToString();
                txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["SIMPartyC"].ToString();
                txtDebitPartyName.Text = ds.Tables[0].Rows[0]["DebitPartyName"].ToString();
                txtBillingAddress1.Text = ds.Tables[0].Rows[0]["DebitPartyAddress1"].ToString();
                txtBillingAddress2.Text = ds.Tables[0].Rows[0]["DebitPartyAddress2"].ToString();
                txtBillingAddress3.Text = ds.Tables[0].Rows[0]["DebitPartyAddress3"].ToString();
                txtBillingCity.Text = ds.Tables[0].Rows[0]["DebitPartyCity"].ToString();
                txtBillingState.Text = ds.Tables[0].Rows[0]["DebitStateName"].ToString();
                txtBillingZip.Text = ds.Tables[0].Rows[0]["DebitPartyZipCode"].ToString();


                txtTempInvoiceDate.Text = dtInvoiceDate.Text;
                txtTempInvoiceNo.Text = txtSerialNo.Text;
                txtTempInvoiceSeries.Text = txtserial.Text;
                txtTempPartyCode.Text = txtDebitPartyCode.Text;
                txtTempPartyName.Text = txtDebitPartyName.Text;
                txtTempState.Text = txtBillingState.Text;
                txtTempCity.Text = txtBillingCity.Text;

                txtDANo.Text = ds.Tables[0].Rows[0]["SIMPartyDANO"].ToString();
                txtOrderNo.Text = ds.Tables[0].Rows[0]["SIMPartyORDNO"].ToString();
                txtPONo.Text = ds.Tables[0].Rows[0]["SIMPartyPONO"].ToString();
                txtTransporterCode.Text = ds.Tables[0].Rows[0]["SIMTRANSPORTERID"].ToString();
                txtTransporterName.Text = ds.Tables[0].Rows[0]["TRPRNAME"].ToString();
                txtTransporterKey.Text = ds.Tables[0].Rows[0]["SIMTRANSPORTERKEY"].ToString();
                txtGRNo.Text = ds.Tables[0].Rows[0]["SIMGRNRRNO"].ToString();
                if (ds.Tables[0].Rows[0]["SIMGRNRRDATE"].ToString().Trim().Length == 0)
                {


                }
                else
                {
                    txtGRDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["SIMGRNRRDATE"]);
                }
                if (ds.Tables[0].Rows[0]["SIMBUILTYPAID"].ToString().ToUpper() == "Y")
                {
                    chPaid.Checked = true;

                }
                else
                {
                    chPaid.Checked = false;
                }
                txtBuiltyAmount.Text = ds.Tables[0].Rows[0]["SIMBUILTYPAIDAMT"].ToString();
                txtGateEntryNo.Text = ds.Tables[0].Rows[0]["SIMGATENTRYNO"].ToString();
                if (ds.Tables[0].Rows[0]["SIMGATENTRYDATE"].ToString().Trim().Length == 0)
                {


                }
                else
                {
                    txtEntryDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["SIMGATENTRYDATE"]);
                }
                txtBankName.Text = ds.Tables[0].Rows[0]["SIMBANKN"].ToString();
                txtBankAccNo.Text = ds.Tables[0].Rows[0]["SIMBANKADD"].ToString();

                if (ds.Tables[0].Rows[0]["SIMINVDIRECT"].ToString().ToUpper() == "Y")
                {
                    chDirect.Checked = true;

                }
                else
                {
                    chPackingSlip.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["SIMINVLOT"].ToString().ToUpper() == "Y")
                {
                    chLot.Checked = true;

                }
                else
                {
                    chRegular.Checked = true;
                }

                txtTotalBoxes.Text = ds.Tables[0].Rows[0]["SIMTOTBOXES"].ToString();
                txtNetAmount.Text = ds.Tables[0].Rows[0]["SIMSUBTOTVAL"].ToString();
                cmbTradeDisc.Text = ds.Tables[0].Rows[0]["SIMDISCTYPE"].ToString();
                txtMainDisc.Text = ds.Tables[0].Rows[0]["SIMDISCPRCN"].ToString();
                txtMainDiscVal.Text = ds.Tables[0].Rows[0]["SIMDISCAMT"].ToString();
                txtInsurancePer.Text = ds.Tables[0].Rows[0]["SIMINSURPRCN"].ToString();
                txtInsuranceAmount.Text = ds.Tables[0].Rows[0]["SIMINSURANCEAMT"].ToString();
                txtPKGFrt.Text = ds.Tables[0].Rows[0]["SIMFREIGHTAMT"].ToString();
                txtOctoriAmount.Text = ds.Tables[0].Rows[0]["SIMOCTORIAMT"].ToString();
                txtRoundOffAmount.Text = ds.Tables[0].Rows[0]["SIMROFFAMT"].ToString();
                txtRNetAmount.Text = ds.Tables[0].Rows[0]["SIMGRANDTOT"].ToString();
                txtCHGWeight.Text = ds.Tables[0].Rows[0]["SIMCHRGWEIGHT"].ToString();
                txtDelieveryCode.Text = ds.Tables[0].Rows[0]["SIMDISPPCODE"].ToString();
                txtDelieveryName.Text = ds.Tables[0].Rows[0]["DelieveryPartyName"].ToString();
                txtDelieveryAddress1.Text = ds.Tables[0].Rows[0]["DelieveryPartyAddress1"].ToString();
                txtDelieveryAddress2.Text = ds.Tables[0].Rows[0]["DelieveryPartyAddress2"].ToString();
                txtDelieveryAddress3.Text = ds.Tables[0].Rows[0]["DelieveryPartyAddress3"].ToString();
                txtDelieveryCity.Text = ds.Tables[0].Rows[0]["DelieveryPartyCity"].ToString();
                txtDelieveryState.Text = ds.Tables[0].Rows[0]["DelieveryPartyState"].ToString();
                txtDelieveryZipCode.Text = ds.Tables[0].Rows[0]["DelieveryPartyZipCode"].ToString();
                txtGSTNo.Text = ds.Tables[0].Rows[0]["AccGSTNo"].ToString();
                txtCreditLimit.Text = ds.Tables[0].Rows[0]["AccCrLimit"].ToString();
                txtAgentBroker.Text = ds.Tables[0].Rows[0]["AgentName"].ToString();
                txtEWayBillNO.Text = ds.Tables[0].Rows[0]["SIMTRDPRMWYBLNO"].ToString();
                txtActualWeight.Text = ds.Tables[0].Rows[0]["SIMTOTWEIGHT"].ToString();

                AccMRPMarkDown = Convert.ToDecimal(ds.Tables[0].Rows[0]["AccMRPMarkDown"]);
                groupControl8.Select();

                if (ds.Tables[0].Rows[0]["SIMINVTAXTYPE"].ToString().ToUpper() == "Y")
                {
                    chExclusive.Checked = true;
                    chInclusive.Checked = false;

                }
                else
                {
                    chInclusive.Checked = true;
                    chExclusive.Checked = false;
                }
                dt = ds.Tables[1];
                InfoGrid.DataSource = dt;
                InfoGridView.BestFitColumns();
                txtDebitPartyCode.Focus();

                GetPartyBalances();



                btnRecalculate_Click(null, e);
                ShowPendingPSlips();
            }
        }







        private void SaveInvoice()
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
                    sqlcom.Connection = sqlcon;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            String BillNo = String.Empty;
                            if (StkTransfer.ToUpper() == "Y")
                            {
                                BillNo = ProjectFunctions.GetDataSet("select isnull(max(SIMNO),0)+1 from SALEINVMAIN where SIMSERIES='DCO' And SIMFNYR='" + GlobalVariables.FinancialYear + "'").Tables[0].Rows[0][0].ToString();
                                txtSerialNo.Text = BillNo;
                                txtserial.Text = "DCO";
                            }
                            else
                            {
                                BillNo = ProjectFunctions.GetDataSet("select isnull(max(SIMNO),0)+1 from SALEINVMAIN where SIMSERIES='GST' And SIMFNYR='" + GlobalVariables.FinancialYear + "'").Tables[0].Rows[0][0].ToString();
                                txtSerialNo.Text = BillNo;
                                txtserial.Text = "GST";
                            }
                            sqlcom.CommandText = "Insert into SALEINVMAIN(SIMSYSDATE,SIMFNYR,SIMDATE,SIMNO,SIMSERIES,SIMPartyC," +
                                "SIMPartyDANO,SIMPartyORDNO,SIMTRANSPORTERID,SIMPartyPONO,SIMTRANSPORTERKEY,SIMGRNRRNO,SIMGRNRRDATE," +
                                "SIMBUILTYPAID,SIMBUILTYPAIDAMT,SIMGATENTRYNO,SIMGATENTRYDATE,SIMBANKN,SIMBANKADD,SIMINVDIRECT,SIMINVLOT," +
                                "SIMINVTAXTYPE,SIMTOTBOXES,SIMSUBTOTVAL,SIMDISCTYPE,SIMDISCPRCN,SIMDISCAMT,SIMINSURPRCN,SIMINSURANCEAMT, " +
                                "SIMFREIGHTAMT,SIMOCTORIAMT,SIMROFFAMT,SIMGRANDTOT,SIMTOTWEIGHT,SIMCHRGWEIGHT,SIMDISPPCODE,UnitCode ,SIMTRDPRMWYBLNO )values(" +
                                "@SIMSYSDATE,@SIMFNYR,@SIMDATE,@SIMNO,@SIMSERIES,@SIMPartyC," +
                                "@SIMPartyDANO,@SIMPartyORDNO,@SIMTRANSPORTERID,@SIMPartyPONO,@SIMTRANSPORTERKEY,@SIMGRNRRNO,@SIMGRNRRDATE," +
                                "@SIMBUILTYPAID,@SIMBUILTYPAIDAMT,@SIMGATENTRYNO,@SIMGATENTRYDATE,@SIMBANKN,@SIMBANKADD,@SIMINVDIRECT,@SIMINVLOT," +
                                "@SIMINVTAXTYPE,@SIMTOTBOXES,@SIMSUBTOTVAL,@SIMDISCTYPE,@SIMDISCPRCN,@SIMDISCAMT,@SIMINSURPRCN,@SIMINSURANCEAMT, " +
                                "@SIMFREIGHTAMT,@SIMOCTORIAMT,@SIMROFFAMT,@SIMGRANDTOT,@SIMTOTWEIGHT,@SIMCHRGWEIGHT,@SIMDISPPCODE,@UnitCode,@SIMTRDPRMWYBLNO)";
                            sqlcom.Parameters.Add("@SIMSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIMFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIMDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIMNO", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMSERIES", SqlDbType.NVarChar).Value = txtserial.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyC", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyDANO", SqlDbType.NVarChar).Value = txtDANo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyORDNO", SqlDbType.NVarChar).Value = txtOrderNo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyPONO", SqlDbType.NVarChar).Value = txtPONo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMTRANSPORTERID", SqlDbType.NVarChar).Value = txtTransporterCode.Text.Trim();
                            sqlcom.Parameters.Add("@SIMTRANSPORTERKEY", SqlDbType.NVarChar).Value = txtTransporterKey.Text.Trim();
                            sqlcom.Parameters.Add("@SIMTRDPRMWYBLNO", SqlDbType.NVarChar).Value = txtEWayBillNO.Text.Trim();
                            sqlcom.Parameters.Add("@SIMGRNRRNO", SqlDbType.NVarChar).Value = txtGRNo.Text;
                            if (txtGRDate.Text.Trim().Length == 0)
                            {
                                sqlcom.Parameters.Add("@SIMGRNRRDATE", SqlDbType.NVarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;

                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMGRNRRDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtGRDate.Text).ToString("yyyy-MM-dd");

                            }
                            if (chPaid.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMBUILTYPAID", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMBUILTYPAID", SqlDbType.NVarChar).Value = "N";
                            }



                            sqlcom.Parameters.Add("@SIMBUILTYPAIDAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtBuiltyAmount.Text);
                            sqlcom.Parameters.Add("@SIMGATENTRYNO", SqlDbType.NVarChar).Value = txtGateEntryNo.Text;
                            if (txtEntryDate.Text.Trim().Length == 0)
                            {
                                sqlcom.Parameters.Add("@SIMGATENTRYDATE", SqlDbType.NVarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;

                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMGATENTRYDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtEntryDate.Text).ToString("yyyy-MM-dd");

                            }
                            sqlcom.Parameters.Add("@SIMBANKN", SqlDbType.NVarChar).Value = txtBankName.Text;
                            sqlcom.Parameters.Add("@SIMBANKADD", SqlDbType.NVarChar).Value = txtBankAccNo.Text;
                            if (chDirect.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVDIRECT", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVDIRECT", SqlDbType.NVarChar).Value = "N";
                            }
                            if (chLot.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVLOT", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVLOT", SqlDbType.NVarChar).Value = "N";
                            }
                            if (chExclusive.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "N";
                            }
                            sqlcom.Parameters.Add("@SIMTOTBOXES", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtTotalBoxes.Text);
                            sqlcom.Parameters.Add("@SIMSUBTOTVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtNetAmount.Text);
                            sqlcom.Parameters.Add("@SIMDISCTYPE", SqlDbType.NVarChar).Value = cmbTradeDisc.Text.Trim();
                            sqlcom.Parameters.Add("@SIMDISCPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDisc.Text);
                            sqlcom.Parameters.Add("@SIMDISCAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDiscVal.Text);
                            sqlcom.Parameters.Add("@SIMINSURPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtInsurancePer.Text);
                            sqlcom.Parameters.Add("@SIMINSURANCEAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtInsuranceAmount.Text);
                            sqlcom.Parameters.Add("@SIMFREIGHTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtPKGFrt.Text);
                            sqlcom.Parameters.Add("@SIMOCTORIAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtOctoriAmount.Text);
                            sqlcom.Parameters.Add("@SIMROFFAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtRoundOffAmount.Text);
                            sqlcom.Parameters.Add("@SIMGRANDTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtRNetAmount.Text);
                            sqlcom.Parameters.Add("@SIMTOTWEIGHT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtActualWeight.Text);
                            sqlcom.Parameters.Add("@SIMCHRGWEIGHT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCHGWeight.Text);
                            sqlcom.Parameters.Add("@SIMDISPPCODE", SqlDbType.NVarChar).Value = txtDelieveryCode.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = "Update SALEINVMAIN Set SIMSYSDATE=@SIMSYSDATE,SIMFNYR=@SIMFNYR,SIMDATE=@SIMDATE,SIMNO=@SIMNO,SIMSERIES=@SIMSERIES,SIMPartyC=@SIMPartyC," +
                                "SIMPartyDANO=@SIMPartyDANO,SIMPartyORDNO=@SIMPartyORDNO,SIMPartyPONO=@SIMPartyPONO,SIMTRANSPORTERID=@SIMTRANSPORTERID,SIMTRANSPORTERKEY=@SIMTRANSPORTERKEY,SIMGRNRRNO=@SIMGRNRRNO,SIMGRNRRDATE=@SIMGRNRRDATE," +
                                "SIMBUILTYPAID=@SIMBUILTYPAID,SIMBUILTYPAIDAMT=@SIMBUILTYPAIDAMT,SIMGATENTRYNO=@SIMGATENTRYNO,SIMGATENTRYDATE=@SIMGATENTRYDATE,SIMBANKN=@SIMBANKN,SIMBANKADD=@SIMBANKADD,SIMINVDIRECT=@SIMINVDIRECT,SIMINVLOT=@SIMINVLOT,SIMINVTAXTYPE=@SIMINVTAXTYPE," +
                                "SIMTOTBOXES=@SIMTOTBOXES,SIMSUBTOTVAL=@SIMSUBTOTVAL,SIMDISCTYPE=@SIMDISCTYPE,SIMDISCPRCN=@SIMDISCPRCN,SIMDISCAMT=@SIMDISCAMT,SIMINSURPRCN=@SIMINSURPRCN,SIMINSURANCEAMT=@SIMINSURANCEAMT, " +
                                "SIMFREIGHTAMT=@SIMFREIGHTAMT,SIMOCTORIAMT=@SIMOCTORIAMT,SIMROFFAMT=@SIMROFFAMT,SIMGRANDTOT=@SIMGRANDTOT,SIMTOTWEIGHT=@SIMTOTWEIGHT,SIMCHRGWEIGHT=@SIMCHRGWEIGHT,SIMDISPPCODE=@SIMDISPPCODE,UnitCode=@UnitCode,SIMTRDPRMWYBLNO=@SIMTRDPRMWYBLNO Where SIMDATE='" + Convert.ToDateTime(ImDate).ToString("yyyy-MM-dd") + "' And SIMNO='" + ImNo + "' And SIMSERIES='" + ImSeries + "' And UnitCode='" + GlobalVariables.CUnitID + "' And SIMFNYR='" + GlobalVariables.FinancialYear + "'";

                            sqlcom.Parameters.Add("@SIMSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIMFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIMDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIMNO", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMSERIES", SqlDbType.NVarChar).Value = txtserial.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyC", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyDANO", SqlDbType.NVarChar).Value = txtDANo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyORDNO", SqlDbType.NVarChar).Value = txtOrderNo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMPartyPONO", SqlDbType.NVarChar).Value = txtPONo.Text.Trim();
                            sqlcom.Parameters.Add("@SIMTRANSPORTERID", SqlDbType.NVarChar).Value = txtTransporterCode.Text.Trim();
                            sqlcom.Parameters.Add("@SIMTRANSPORTERKEY", SqlDbType.NVarChar).Value = txtTransporterKey.Text.Trim();
                            sqlcom.Parameters.Add("@SIMTRDPRMWYBLNO", SqlDbType.NVarChar).Value = txtEWayBillNO.Text.Trim();

                            sqlcom.Parameters.Add("@SIMGRNRRNO", SqlDbType.NVarChar).Value = txtGRNo.Text;
                            if (txtGRDate.Text.Trim().Length == 0)
                            {
                                sqlcom.Parameters.Add("@SIMGRNRRDATE", SqlDbType.NVarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;

                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMGRNRRDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtGRDate.Text).ToString("yyyy-MM-dd");

                            }
                            if (chPaid.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMBUILTYPAID", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMBUILTYPAID", SqlDbType.NVarChar).Value = "N";
                            }



                            sqlcom.Parameters.Add("@SIMBUILTYPAIDAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtBuiltyAmount.Text);
                            sqlcom.Parameters.Add("@SIMGATENTRYNO", SqlDbType.NVarChar).Value = txtGateEntryNo.Text;
                            if (txtEntryDate.Text.Trim().Length == 0)
                            {
                                sqlcom.Parameters.Add("@SIMGATENTRYDATE", SqlDbType.NVarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;

                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMGATENTRYDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(txtEntryDate.Text).ToString("yyyy-MM-dd");

                            }
                            sqlcom.Parameters.Add("@SIMBANKN", SqlDbType.NVarChar).Value = txtBankName.Text;
                            sqlcom.Parameters.Add("@SIMBANKADD", SqlDbType.NVarChar).Value = txtBankAccNo.Text;
                            if (chDirect.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVDIRECT", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVDIRECT", SqlDbType.NVarChar).Value = "N";
                            }
                            if (chLot.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVLOT", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVLOT", SqlDbType.NVarChar).Value = "N";
                            }
                            if (chExclusive.Checked)
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "Y";
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIMINVTAXTYPE", SqlDbType.NVarChar).Value = "N";
                            }
                            sqlcom.Parameters.Add("@SIMTOTBOXES", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtTotalBoxes.Text);
                            sqlcom.Parameters.Add("@SIMSUBTOTVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtNetAmount.Text);
                            sqlcom.Parameters.Add("@SIMDISCTYPE", SqlDbType.NVarChar).Value = cmbTradeDisc.Text.Trim();
                            sqlcom.Parameters.Add("@SIMDISCPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDisc.Text);
                            sqlcom.Parameters.Add("@SIMDISCAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtMainDiscVal.Text);
                            sqlcom.Parameters.Add("@SIMINSURPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtInsurancePer.Text);
                            sqlcom.Parameters.Add("@SIMINSURANCEAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtInsuranceAmount.Text);
                            sqlcom.Parameters.Add("@SIMFREIGHTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtPKGFrt.Text);
                            sqlcom.Parameters.Add("@SIMOCTORIAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtOctoriAmount.Text);
                            sqlcom.Parameters.Add("@SIMROFFAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtRoundOffAmount.Text);
                            sqlcom.Parameters.Add("@SIMGRANDTOT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtRNetAmount.Text);
                            sqlcom.Parameters.Add("@SIMTOTWEIGHT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtActualWeight.Text);
                            sqlcom.Parameters.Add("@SIMCHRGWEIGHT", SqlDbType.NVarChar).Value = Convert.ToDecimal(txtCHGWeight.Text);
                            sqlcom.Parameters.Add("@SIMDISPPCODE", SqlDbType.NVarChar).Value = txtDelieveryCode.Text;
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.CommandText = "Delete from SALEINVDET Where SIDSERIES=@SIDSERIES And SIDNO=@SIDNO And SIDDATE=@SIDDATE  And SIDFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'";
                            sqlcom.Parameters.Add("@SIDSERIES", SqlDbType.NVarChar).Value = txtserial.Text.Trim();
                            sqlcom.Parameters.Add("@SIDNO", SqlDbType.NVarChar).Value = txtSerialNo.Text.Trim();
                            sqlcom.Parameters.Add("@SIDDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        for (var i = 0; i < MaxRow; i++)
                        {
                            sqlcom.CommandType = CommandType.Text;
                            var currentrow = InfoGridView.GetDataRow(i);
                            sqlcom.CommandText = " Insert into SALEINVDET "
                                                        + " (SIDSYSDATE,SIDFNYR,SIDDATE,SIDNO,SIDSERIES,SIDPartyC,"
                                                        + " SIDPSNO,SIDBOXNO,SIDBARCODE,SIDARTNO,SIDARTID,SIDCOLID,"
                                                        + " SIDSIZID,SIDSCANQTY,SIDARTMRP,SIDARTWSP,SIDBOXQTY,SIDBOXMRPVAL,SIDBOXWSPVAL,SIDITMDISCPRCN,"
                                                        + "SIDITMDISCAMT,SIDITMNETAMT,SIDPONO,SIDSGSTPRCN,SIDSGSTAMT,SIDCGSTPRCN,SIDCGSTAMT,SIDIGSTPRCN,SIDIGSTAMT,TAXCODE,UnitCode  )"
                                                        + " values(@SIDSYSDATE,@SIDFNYR,@SIDDATE,@SIDNO,@SIDSERIES,@SIDPartyC,"
                                                        + " @SIDPSNO,@SIDBOXNO,@SIDBARCODE,@SIDARTNO,@SIDARTID,@SIDCOLID,"
                                                        + " @SIDSIZID,@SIDSCANQTY,@SIDARTMRP,@SIDARTWSP,@SIDBOXQTY,@SIDBOXMRPVAL,@SIDBOXWSPVAL,@SIDITMDISCPRCN,@SIDITMDISCAMT,"
                                                        + " @SIDITMNETAMT,@SIDPONO,@SIDSGSTPRCN,@SIDSGSTAMT,@SIDCGSTPRCN,@SIDCGSTAMT,@SIDIGSTPRCN,@SIDIGSTAMT,@TAXCODE,@UnitCode)";
                            sqlcom.Parameters.Add("@SIDSYSDATE", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlcom.Parameters.Add("@SIDFNYR", SqlDbType.NVarChar).Value = GlobalVariables.FinancialYear;
                            sqlcom.Parameters.Add("@SIDDATE", SqlDbType.NVarChar).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                            sqlcom.Parameters.Add("@SIDNO", SqlDbType.NVarChar).Value = txtSerialNo.Text;

                            sqlcom.Parameters.Add("@SIDSERIES", SqlDbType.NVarChar).Value = txtserial.Text.Trim();
                            sqlcom.Parameters.Add("@SIDPartyC", SqlDbType.NVarChar).Value = txtDebitPartyCode.Text.Trim();
                            sqlcom.Parameters.Add("@SIDPSNO", SqlDbType.NVarChar).Value = currentrow["SIDPSNO"].ToString();
                            sqlcom.Parameters.Add("@SIDBOXNO", SqlDbType.NVarChar).Value = "0";
                            sqlcom.Parameters.Add("@SIDBARCODE", SqlDbType.NVarChar).Value = currentrow["SIDBARCODE"].ToString();
                            sqlcom.Parameters.Add("@SIDARTNO", SqlDbType.NVarChar).Value = currentrow["SIDARTNO"].ToString();
                            sqlcom.Parameters.Add("@SIDARTID", SqlDbType.NVarChar).Value = currentrow["SIDARTID"].ToString();
                            sqlcom.Parameters.Add("@SIDCOLID", SqlDbType.NVarChar).Value = currentrow["SIDCOLID"].ToString();
                            sqlcom.Parameters.Add("@SIDSIZID", SqlDbType.NVarChar).Value = currentrow["SIDSIZID"].ToString();
                            sqlcom.Parameters.Add("@SIDSCANQTY", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDSCANQTY"]);
                            sqlcom.Parameters.Add("@SIDARTMRP", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDARTMRP"]);
                            sqlcom.Parameters.Add("@SIDARTWSP", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDARTWSP"]);

                            if (currentrow["SIDBOXQTY"].ToString() == string.Empty)
                            {
                                sqlcom.Parameters.Add("@SIDBOXQTY", SqlDbType.NVarChar).Value = Convert.ToDecimal("0");
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIDBOXQTY", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDBOXQTY"]);
                            }



                            if (currentrow["SIDBOXMRPVAL"].ToString() == string.Empty)
                            {
                                sqlcom.Parameters.Add("@SIDBOXMRPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal("0");
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIDBOXMRPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDBOXMRPVAL"]);
                            }

                            if (currentrow["SIDBOXWSPVAL"].ToString() == string.Empty)
                            {
                                sqlcom.Parameters.Add("@SIDBOXWSPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal("0");
                            }
                            else
                            {
                                sqlcom.Parameters.Add("@SIDBOXWSPVAL", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDBOXWSPVAL"]);
                            }



                            sqlcom.Parameters.Add("@SIDITMDISCPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDITMDISCPRCN"]);
                            sqlcom.Parameters.Add("@SIDITMDISCAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDITMDISCAMT"]);
                            sqlcom.Parameters.Add("@SIDITMNETAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDITMNETAMT"]);
                            sqlcom.Parameters.Add("@SIDPONO", SqlDbType.NVarChar).Value = txtPONo.Text.Trim();

                            sqlcom.Parameters.Add("@SIDSGSTPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDSGSTPER"]);
                            sqlcom.Parameters.Add("@SIDSGSTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDSGSTAMT"]);
                            sqlcom.Parameters.Add("@SIDCGSTPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDCGSTPER"]);
                            sqlcom.Parameters.Add("@SIDCGSTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDCGSTAMT"]);
                            sqlcom.Parameters.Add("@SIDIGSTPRCN", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDIGSTPER"]);
                            sqlcom.Parameters.Add("@SIDIGSTAMT", SqlDbType.NVarChar).Value = Convert.ToDecimal(currentrow["SIDIGSTAMT"]);
                            sqlcom.Parameters.Add("@TAXCODE", SqlDbType.NVarChar).Value = currentrow["TAXCODE"].ToString();
                            sqlcom.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = GlobalVariables.CUnitID;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();
                        }
                        PackingSlipUpdations();


                        //sqlcom.CommandType = CommandType.StoredProcedure;
                        //sqlcom.CommandText = "SP_SLVPosting";
                        //sqlcom.Parameters.Add("@DocNo", SqlDbType.VarChar).Value = txtSerialNo.Text.Trim();
                        //sqlcom.Parameters.Add("@DocDate", SqlDbType.DateTime).Value = Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd");
                        //sqlcom.ExecuteNonQuery();
                        //sqlcom.Parameters.Clear();
                        if (StkTransfer.ToUpper() == "Y")
                        {
                            ProjectFunctions.GetDataSet("sp_SinkDCOWithOnline");
                        }
                        ProjectFunctions.SpeakError("Invoice Data Saved Successfully");
                        sqlcon.Close();

                        this.Close();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        this.Close();
                    }
                }
            }
        }




        private void PackingSlipUpdations()
        {

            foreach (DataRow dr in (PSGrid.DataSource as DataTable).Rows)
            {
                ProjectFunctions.GetDataSet("Update PSWSLMAIN Set Used='N'  Where PSWSNO='" + dr["PSWSNO"].ToString() + "' And PSWSFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
            }


            var distinctRows = (from DataRow dRow in dt.Rows
                                select dRow["SIDPSNO"]).Distinct();
            foreach (var v in distinctRows)
            {
                ProjectFunctions.GetDataSet("Update PSWSLMAIN Set Used='Y'  Where PSWSNO='" + v.ToString() + "' And PSWSFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
            }



            foreach (DataRow dr in dtWeight.Rows)
            {
                ProjectFunctions.GetDataSet("Update PSWSLMAIN Set PSWEIGHT='" + Convert.ToDecimal(dr["Weight"]) + "' Where PSWSNO='" + dr["PSWSNO"].ToString() + "' And PSWSTOTBOXES='" + dr["BoxNo"].ToString() + "' And PSWSFNYR='" + GlobalVariables.FinancialYear + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveInvoice();
        }



        private void frmInvoiceMstAdd_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.SalePopUPForAllWindows(this, e);
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtDebitPartyCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDebitPartyName.Text = String.Empty;
            txtBillingAddress1.Text = String.Empty;
            txtBillingAddress2.Text = String.Empty;
            txtBillingAddress3.Text = String.Empty;
            txtBillingState.Text = String.Empty;
            txtBillingCity.Text = String.Empty;
            txtBillingZip.Text = String.Empty;
            txtDelieveryCode.Text = String.Empty;
            txtDelieveryName.Text = String.Empty;
            txtDelieveryAddress1.Text = String.Empty;
            txtDelieveryAddress2.Text = String.Empty;
            txtDelieveryAddress3.Text = String.Empty;
            txtDelieveryState.Text = String.Empty;
            txtDelieveryCity.Text = String.Empty;
            txtDelieveryZipCode.Text = String.Empty;
            txtBankName.Text = String.Empty;
            txtBankAccNo.Text = String.Empty;
            txtGSTNo.Text = String.Empty;
            txtBankAccNo.Text = String.Empty;
            txtCreditLimit.Text = String.Empty;
        }


        private void PrepareActMstHelpGrid()
        {
            HelpGridView.Columns.Clear();
            DevExpress.XtraGrid.Columns.GridColumn col1 = new DevExpress.XtraGrid.Columns.GridColumn();
            col1.FieldName = "AccName";
            col1.Visible = true;
            col1.VisibleIndex = 0;
            HelpGridView.Columns.Add(col1);

            DevExpress.XtraGrid.Columns.GridColumn col2 = new DevExpress.XtraGrid.Columns.GridColumn();
            col2.FieldName = "AccCode";
            col2.Visible = true;
            col2.VisibleIndex = 1;
            HelpGridView.Columns.Add(col2);

            DevExpress.XtraGrid.Columns.GridColumn col3 = new DevExpress.XtraGrid.Columns.GridColumn();
            col3.FieldName = "AccAddress1";
            col3.Visible = false;
            //col3.VisibleIndex = 2;
            HelpGridView.Columns.Add(col3);

            DevExpress.XtraGrid.Columns.GridColumn col4 = new DevExpress.XtraGrid.Columns.GridColumn();
            col4.FieldName = "AccAddress2";
            col4.Visible = false;
            //col4.VisibleIndex = 3;
            HelpGridView.Columns.Add(col4);

            DevExpress.XtraGrid.Columns.GridColumn col5 = new DevExpress.XtraGrid.Columns.GridColumn();
            col5.FieldName = "AccAddress3";
            col5.Visible = false;
            //col5.VisibleIndex = 4;
            HelpGridView.Columns.Add(col5);


            DevExpress.XtraGrid.Columns.GridColumn col6 = new DevExpress.XtraGrid.Columns.GridColumn();
            col6.FieldName = "CTNAME";
            col6.Visible = false;
            //col6.VisibleIndex = 5;
            HelpGridView.Columns.Add(col6);

        }


        private void txtDebitPartyCode_KeyDown(object sender, KeyEventArgs e)
        {




            if (e.KeyCode == Keys.Enter)
            {

                PrepareActMstHelpGrid();

                //HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtDebitPartyCode";
                if (txtDebitPartyCode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadActMstHelp");
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
                    DataSet ds = ProjectFunctions.GetDataSet(" sp_LoadActMstHelpWithCode '" + txtDebitPartyCode.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtDebitPartyCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        txtDebitPartyName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        txtBillingAddress1.Text = ds.Tables[0].Rows[0]["AccAddress1"].ToString();
                        txtBillingAddress2.Text = ds.Tables[0].Rows[0]["AccAddress2"].ToString();
                        txtBillingAddress3.Text = ds.Tables[0].Rows[0]["AccAddress3"].ToString();
                        txtBillingState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                        txtBillingCity.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                        txtBillingZip.Text = ds.Tables[0].Rows[0]["AccZipCode"].ToString();
                        txtDelieveryCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        txtDelieveryName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        txtDelieveryAddress1.Text = ds.Tables[0].Rows[0]["AccAddress1"].ToString();
                        txtDelieveryAddress2.Text = ds.Tables[0].Rows[0]["AccAddress2"].ToString();
                        txtDelieveryAddress3.Text = ds.Tables[0].Rows[0]["AccAddress3"].ToString();
                        txtDelieveryState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                        txtDelieveryCity.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                        txtDelieveryZipCode.Text = ds.Tables[0].Rows[0]["AccZipCode"].ToString();
                        txtBankName.Text = ds.Tables[0].Rows[0]["AccAcinBankName"].ToString();
                        txtBankAccNo.Text = ds.Tables[0].Rows[0]["AccBankAccNo"].ToString();
                        txtGSTNo.Text = ds.Tables[0].Rows[0]["AccGSTNo"].ToString();
                        txtBankAccNo.Text = ds.Tables[0].Rows[0]["AccBankAccNo"].ToString();
                        txtCreditLimit.Text = ds.Tables[0].Rows[0]["AccCrLimit"].ToString();
                        txtTempPartyCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        txtTempPartyName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        txtTempState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                        txtTempCity.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                        AccMRPMarkDown = Convert.ToDecimal(ds.Tables[0].Rows[0]["AccMrpMarkDown"]);
                        txtAgentBroker.Text = ds.Tables[0].Rows[0]["AgentName"].ToString();
                        StkTransfer = ds.Tables[0].Rows[0]["AccStkTrf"].ToString();
                        ShowPendingPSlips();
                        GetPartyBalances();
                        txtDelieveryCode.Focus();

                        if (StkTransfer.ToUpper() == "Y")
                        {
                            txtserial.Text = "DCO";
                            txtTempInvoiceSeries.Text = txtserial.Text;
                        }
                        else
                        {
                            txtserial.Text = "GST";
                            txtTempInvoiceSeries.Text = txtserial.Text;
                        }
                    }

                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("sp_LoadActMstHelp");
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


        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            HelpGridView.CloseEditor();
            HelpGridView.UpdateCurrentRow();
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "WEIGHT")
            {
                Decimal Weight = 0;
                Int32 Count = 0;
                foreach (DataRow dr in (HelpGrid.DataSource as DataTable).Rows)
                {
                    Count = Count + 1;
                    Weight = Weight + Convert.ToDecimal(dr["Weight"]);
                }

                txtActualWeight.Text = Weight.ToString("0.00");
                txtTotalBoxes.Text = Count.ToString("0");


                HelpGrid.Visible = false;
                txtGRNo.Focus();
            }
            if (HelpGrid.Text == "txtTransporterCode")
            {
                txtTransporterCode.Text = row["TRPRSYSID"].ToString();
                txtTransporterName.Text = row["TRPRNAME"].ToString();
                HelpGrid.Visible = false;
                //txtArticlSysID.Focus();
            }
            if (HelpGrid.Text == "txtDelieveryCode")
            {
                txtDelieveryCode.Text = row["AccCode"].ToString();
                txtDelieveryName.Text = row["AccName"].ToString();
                txtDelieveryAddress1.Text = row["AccAddress1"].ToString();
                txtDelieveryAddress2.Text = row["AccAddress2"].ToString();
                txtDelieveryAddress3.Text = row["AccAddress3"].ToString();
                txtDelieveryState.Text = row["STNAME"].ToString();
                txtDelieveryCity.Text = row["CTNAME"].ToString();
                txtDelieveryZipCode.Text = row["AccZipCode"].ToString();
                HelpGrid.Visible = false;
                txtDANo.Focus();
            }
            if (HelpGrid.Text == "txtDebitPartyCode")
            {
                txtDebitPartyCode.Text = row["AccCode"].ToString();
                txtDebitPartyName.Text = row["AccName"].ToString();
                txtBillingAddress1.Text = row["AccAddress1"].ToString();
                txtBillingAddress2.Text = row["AccAddress2"].ToString();
                txtBillingAddress3.Text = row["AccAddress3"].ToString();
                txtBillingState.Text = row["STNAME"].ToString();
                txtBillingCity.Text = row["CTNAME"].ToString();
                txtBillingZip.Text = row["AccZipCode"].ToString();
                txtDelieveryCode.Text = row["AccCode"].ToString();
                txtDelieveryName.Text = row["AccName"].ToString();
                txtDelieveryAddress1.Text = row["AccAddress1"].ToString();
                txtDelieveryAddress2.Text = row["AccAddress2"].ToString();
                txtDelieveryAddress3.Text = row["AccAddress3"].ToString();
                txtDelieveryState.Text = row["STNAME"].ToString();
                txtDelieveryCity.Text = row["CTNAME"].ToString();
                txtDelieveryZipCode.Text = row["AccZipCode"].ToString();
                txtBankName.Text = row["AccAcinBankName"].ToString();
                txtBankAccNo.Text = row["AccBankAccNo"].ToString();
                txtGSTNo.Text = row["AccGSTNo"].ToString();
                txtBankAccNo.Text = row["AccBankAccNo"].ToString();
                txtCreditLimit.Text = row["AccCrLimit"].ToString();

                txtTempPartyCode.Text = row["AccCode"].ToString();
                txtTempPartyName.Text = row["AccName"].ToString();
                txtTempState.Text = row["STNAME"].ToString();
                txtTempCity.Text = row["CTNAME"].ToString();
                AccMRPMarkDown = Convert.ToDecimal(row["AccMrpMarkDown"]);
                txtAgentBroker.Text = row["AgentName"].ToString();
                StkTransfer = row["AccStkTrf"].ToString();

                if (StkTransfer.ToUpper() == "Y")
                {
                    txtserial.Text = "DCO";
                    txtTempInvoiceSeries.Text = txtserial.Text;
                }
                else
                {
                    txtserial.Text = "GST";
                    txtTempInvoiceSeries.Text = txtserial.Text;
                }




                ShowPendingPSlips();
                GetPartyBalances();
                HelpGrid.Visible = false;
                txtDelieveryCode.Focus();
            }
            if (HelpGrid.Text == "txtProductACode")
            {
                // txtArticlSysID.Text = row["ARTSYSID"].ToString();
                //  txtProductName.Text = row["ARTDESC"].ToString();
                //  txtArticleNo.Text = row["ARTNO"].ToString();
                HelpGrid.Visible = false;

                // txtProductQty.Focus();
            }
            if (HelpGrid.Text == "btnLoadOrder")
            {
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

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            //HelpGridView.Columns.Clear();
            //HelpGrid.Text = "btnLoadOrder";
            //DataSet ds = new DataSet();

            //ds = ProjectFunctions.GetDataSet("SELECT DISTINCT DealerOrderMst.OrdNo, DealerOrderMst.OrdDate, DealerOrderMst.OrdDealerCode, ActMst.AccName, ActMst.AccLcTag FROM         DealerOrderMst INNER JOIN ActMst ON DealerOrderMst.OrdDealerCode = ActMst.AccCode Where OrdForDate ='" + Convert.ToDateTime(dtInvoiceDate.Text).ToString("yyyy-MM-dd") + "' And  DealerOrderMst.ImPassTag='Y' And DealerOrderMst.OrdNo not in (Select Distinct ImOrderNo from InvoiceMst Where ImOrderNo<>'' and ImOrderNo is not null )");

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    HelpGrid.DataSource = ds.Tables[0];
            //    HelpGrid.Visible = true;
            //    HelpGrid.Focus();
            //    HelpGridView.BestFitColumns();

            //}
            //else
            //{
            //    ProjectFunctions.SpeakError("No Order To Load");
            //}
        }

        private void TxtTransporterCode_EditValueChanged(object sender, EventArgs e)
        {
            txtTransporterName.Text = String.Empty;
        }

        private void TxtTransporterCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("select TRPRSYSID,TRPRNAME,TRPRADD from TRANSPORTMASTER", " Where AccCode", txtTransporterCode, txtTransporterName, txtTransporterKey, HelpGrid, HelpGridView, e);
        }

        private void TxtProductRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void ChDirect_CheckedChanged(object sender, EventArgs e)
        {
            if (chDirect.Checked)
            {
                chPackingSlip.Checked = false;
                dt.Clear();
                PrepareDirectInvoice();
                PSGrid.DataSource = null;
                groupControl10.Visible = false;
            }
        }

        private void ChPackingSlip_CheckedChanged(object sender, EventArgs e)
        {
            if (chPackingSlip.Checked)
            {
                chDirect.Checked = false;
                groupControl10.Visible = true;
                //ShowPendingPSlips();
                dt.Clear();
            }
        }

        private void InfoGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                GridControlView1.Columns.Clear();
                DataRow currentrow = InfoGridView.GetDataRow(InfoGridView.FocusedRowHandle);

                if (e.KeyCode != Keys.Up)
                {
                    if (e.KeyCode != Keys.Down)
                    {
                        if (e.KeyCode != Keys.Left)
                        {
                            if (e.KeyCode != Keys.Right)
                            {
                                if (e.KeyCode != Keys.F12)
                                {
                                    if (e.KeyCode != Keys.Enter)
                                    {
                                        if (InfoGridView.FocusedColumn.FieldName == "SIDARTNO")
                                        {
                                            if (currentrow == null)
                                            {


                                                GridControl1.Text = "SIDARTNO";
                                                txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                panelControl1.Visible = true;
                                                panelControl1.Select();
                                                txtSearchBox.Focus();
                                                txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                txtSearchBox.SelectionLength = 0;

                                            }
                                            else
                                            {
                                                DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from ARTICLE where ARTNO='" + ProjectFunctions.CheckNull(currentrow["SIDARTNO"].ToString()) + "'");
                                                if (dsCheck.Tables[0].Rows.Count > 0)
                                                {
                                                    InfoGridView.FocusedColumn = InfoGridView.Columns["SKUCOLN"];
                                                    return;
                                                }
                                                else
                                                {
                                                    GridControl1.Text = "SIDARTNO";
                                                    txtSearchBox.Text = txtSearchBox.Text + ProjectFunctions.ValidateKeysForSearchBox(e);
                                                    panelControl1.Visible = true;
                                                    panelControl1.Select();
                                                    txtSearchBox.Focus();
                                                    txtSearchBox.SelectionStart = txtSearchBox.Text.Length;
                                                    txtSearchBox.SelectionLength = 0;
                                                }
                                            }
                                        }

                                        if (InfoGridView.FocusedColumn.FieldName == "SIDSCANQTY")
                                        {
                                            InfoGridView.Focus();
                                            InfoGridView.MoveLastVisible();
                                            InfoGridView.FocusedColumn = InfoGridView.Columns["SIDARTNO"];
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }


        }

        private void GridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try

            {
                if (e.KeyCode == Keys.Enter)
                {
                    GridControl1_DoubleClick(null, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    panelControl1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void GridControl1_DoubleClick(object sender, EventArgs e)
        {
            try

            {
                if (GridControlView1.RowCount > 0)
                {
                    DataRow row = GridControlView1.GetDataRow(GridControlView1.FocusedRowHandle);

                    if (GridControl1.Text == "SIDARTNO")
                    {
                        DataRow dtNewRow = dt.NewRow();
                        dtNewRow["SIDARTNO"] = row["ARTNO"].ToString();
                        dtNewRow["SIDARTDESC"] = row["ARTDESC"].ToString();
                        dtNewRow["SIDARTMRP"] = row["ARTMRP"].ToString();
                        dtNewRow["SIDARTWSP"] = row["ARTWSP"].ToString();
                        dtNewRow["SIDSCANQTY"] = Convert.ToDecimal("1");
                        dtNewRow["SIDARTID"] = row["ARTSYSID"].ToString();
                        dtNewRow["SIDITMDISCPRCN"] = Convert.ToDecimal("0");
                        dtNewRow["ARTMARGIN"] = row["ARTMARGIN"].ToString();
                        var str = "Exec [sp_LoadTaxMstFInvoice] @PrdCode='" + row["ARTSYSID"].ToString() + "',";
                        str = str + "@LCTag='" + ProjectFunctions.GetDataSet("Select AccLcTag from ActMst Where AccCode='" + txtDebitPartyCode.Text + "'").Tables[0].Rows[0]["AccLcTag"] + "',@ValueOfGoods='0'";

                        DataSet ds = ProjectFunctions.GetDataSet(str);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dtNewRow["SIDCGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxCGSTRate"]);
                            dtNewRow["SIDSGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSGSTRate"]);
                            dtNewRow["SIDIGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxIGSTRate"]);
                        }
                        dtNewRow["TAXCODE"] = ds.Tables[0].Rows[0]["TAXCODE"].ToString();
                        dtNewRow["GRPHSNCODE"] = ds.Tables[0].Rows[0]["GRPHSNCODE"].ToString();
                        dtNewRow["SIDPSDATE"] = Convert.ToDateTime("2001-01-01");
                        dt.Rows.Add(dtNewRow);
                        if (dt.Rows.Count > 0)
                        {
                            InfoGrid.DataSource = dt;
                            InfoGridView.BestFitColumns();
                        }
                        panelControl1.Visible = false;
                        InfoGridView.Focus();
                        InfoGridView.MoveLast();
                        InfoGridView.FocusedColumn = InfoGridView.Columns["SIDSCANQTY"];
                        txtSearchBox.Text = String.Empty;
                        btnRecalculate_Click(null, e);

                        //ShowImage(row["ARTSYSID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void ShowImage(String ArticleID)
        {
            DataSet dsImage = ProjectFunctions.GetDataSet("Select ARTIMAGE from ARTICLE Where ARTSYSID='" + ArticleID + "'");
            if (dsImage.Tables[0].Rows[0]["ARTIMAGE"].ToString().Trim() != string.Empty)
            {
                Byte[] MyData = new byte[0];
                MyData = (Byte[])dsImage.Tables[0].Rows[0]["ARTIMAGE"];
                MemoryStream stream = new MemoryStream(MyData);
                stream.Position = 0;

                ArticleImageBox.Image = System.Drawing.Image.FromStream(stream);
            }
        }
        private void TxtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            try

            {
                GridControlView1.CloseEditor();
                GridControlView1.UpdateCurrentRow();
                if (e.KeyCode == Keys.Enter)
                {
                    GridControl1_DoubleClick(null, e);
                }
                if (e.KeyCode == Keys.Down)
                {
                    GridControl1.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    panelControl1.Visible = false;
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }

        }

        private void TxtSearchBox_EditValueChanged(object sender, EventArgs e)
        {

            if (GridControl1.Text == "SIDARTNO")
            {
                DataTable dtNew = dsPopUps.Tables[0].Clone();
                DataRow[] dtRow = dsPopUps.Tables[0].Select("ARTNO like '" + txtSearchBox.Text + "%'");
                foreach (DataRow dr in dtRow)
                {
                    DataRow NewRow = dtNew.NewRow();
                    NewRow["ARTNO"] = dr["ARTNO"];
                    NewRow["ARTDESC"] = dr["ARTDESC"];
                    NewRow["ARTMRP"] = dr["ARTMRP"];
                    NewRow["ARTWSP"] = dr["ARTWSP"];
                    NewRow["ARTSYSID"] = dr["ARTSYSID"];
                    NewRow["ARTMARGIN"] = dr["ARTMARGIN"];
                    dtNew.Rows.Add(NewRow);
                }
                if (dtNew.Rows.Count > 0)
                {
                    GridControl1.DataSource = dtNew;
                    GridControlView1.BestFitColumns();
                }
                else
                {
                    GridControl1.DataSource = null;
                    GridControlView1.BestFitColumns();
                }
            }
        }



        private void InfoGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            btnRecalculate_Click(null, e);

        }



        private void TxtMainDisc_EditValueChanged(object sender, EventArgs e)
        {

            //calculation();
        }

        private void ChExclusive_CheckedChanged(object sender, EventArgs e)
        {
            if (chExclusive.Checked)
            {
                chInclusive.Checked = false;
                //calculation();
            }
        }

        private void ChInclusive_CheckedChanged(object sender, EventArgs e)
        {
            if (chInclusive.Checked)
            {
                chExclusive.Checked = false;



                //calculation();
            }
        }



        private void PSGrid_DoubleClick(object sender, EventArgs e)
        {
            dt.Clear();
            PSGridView.CloseEditor();
            PSGridView.UpdateCurrentRow();

            DataSet ds = new DataSet();
#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
            int i = 0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used

            String LCTag = ProjectFunctions.GetDataSet("Select AccLcTag from ActMst Where AccCode='" + txtDebitPartyCode.Text + "'").Tables[0].Rows[0][0].ToString();

            foreach (DataRow drOuter in (PSGrid.DataSource as DataTable).Rows)
            {
                if (drOuter["Select"].ToString().ToUpper() == "TRUE")
                {
                    DataSet dsData = ProjectFunctions.GetDataSet("sp_LoadPackingSlipData '" + drOuter["PSWSNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "'");
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsData.Tables[0].Rows)
                        {
                            DataRow dtNewRow = dt.NewRow();
                            dtNewRow["SIDBARCODE"] = dr["SIDBARCODE"];
                            dtNewRow["SIDARTNO"] = dr["SIDARTNO"];
                            dtNewRow["SIDARTDESC"] = dr["SIDARTDESC"];
                            dtNewRow["SIDARTMRP"] = dr["SIDARTMRP"];
                            dtNewRow["SIDARTWSP"] = dr["SIDARTWSP"];
                            dtNewRow["SIDCOLN"] = dr["SIDCOLN"];
                            dtNewRow["SIDSIZN"] = dr["SIDSIZN"];
                            dtNewRow["SIDSCANQTY"] = dr["SIDSCANQTY"];
                            dtNewRow["SIDITMDISCPRCN"] = Convert.ToDecimal("0");
                            dtNewRow["SIDITMDISCAMT"] = dr["SIDITMDISCAMT"];
                            dtNewRow["SIDITMNETAMT"] = dr["SIDITMNETAMT"];
                            dtNewRow["SIDBOXQTY"] = dr["SIDBOXQTY"];
                            dtNewRow["SIDBOXMRPVAL"] = dr["SIDBOXMRPVAL"];
                            dtNewRow["SIDBOXWSPVAL"] = dr["SIDBOXWSPVAL"];
                            dtNewRow["SIDARTID"] = dr["SIDARTID"];
                            dtNewRow["SIDCOLID"] = dr["SIDCOLID"];
                            dtNewRow["SIDSIZID"] = dr["SIDSIZID"];
                            dtNewRow["SIDPSID"] = dr["SIDPSID"];
                            dtNewRow["SIDPSNO"] = dr["SIDPSNO"];
                            dtNewRow["SIDSGSTAMT"] = dr["SIDSGSTAMT"];
                            dtNewRow["SIDCGSTAMT"] = dr["SIDCGSTAMT"];
                            dtNewRow["SIDIGSTAMT"] = dr["SIDIGSTAMT"];
                            dtNewRow["ARTMARGIN"] = dr["ARTMARGIN"];




                            //if (i == 0)
                            //{
                            var str = "Exec [sp_LoadTaxMstFInvoice] @PrdCode='" + dr["SIDARTID"].ToString() + "',";
                            str = str + "@LCTag='" + LCTag + "',@ValueOfGoods='" + Convert.ToDecimal(dr["SIDARTMRP"]) + "'";
                            ds = ProjectFunctions.GetDataSet(str);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                dtNewRow["SIDCGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxCGSTRate"]);
                                dtNewRow["SIDSGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSGSTRate"]);
                                dtNewRow["SIDIGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxIGSTRate"]);
                            }
                            //    i++;
                            //}
                            //else
                            //{
                            //    dtNewRow["SIDCGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxCGSTRate"]);
                            //    dtNewRow["SIDSGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxSGSTRate"]);
                            //    dtNewRow["SIDIGSTPER"] = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxIGSTRate"]);
                            //}


                            dtNewRow["SIDPSDATE"] = Convert.ToDateTime("2001-01-01");
                            dtNewRow["TAXCODE"] = ds.Tables[0].Rows[0]["TAXCODE"].ToString();
                            dtNewRow["GRPHSNCODE"] = ds.Tables[0].Rows[0]["GRPHSNCODE"].ToString();
                            dt.Rows.Add(dtNewRow);
                        }
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

            calculation();
        }

        private void TxtDelieveryCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtDelieveryCode";
                if (txtDelieveryCode.Text.Trim().Length == 0)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT        ActMst.AccCode, ActMst.AccName, ActMst.AccGSTNo, ActMstAddInf.AccBankAccNo, ActMstAddInf.AccAcinBankName, ActMstAddInf.AccAddress1, ActMstAddInf.AccAddress2, ActMstAddInf.AccAddress3, ActMstAddInf.AccZipCode,  CITYMASTER.CTNAME, STATEMASTER.STNAME,ActMst.AccCrLimit,ActMstAddInf.AccMrpMarkDown FROM  ActMst INNER JOIN ActMstAddInf ON ActMst.AccCode = ActMstAddInf.AccCode INNER JOIN CITYMASTER ON ActMstAddInf.AccCityCode = CITYMASTER.CTSYSID INNER JOIN STATEMASTER ON CITYMASTER.UNDERSTID = STATEMASTER.STSYSID");
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
                    DataSet ds = ProjectFunctions.GetDataSet("SELECT        ActMst.AccCode, ActMst.AccName, ActMst.AccGSTNo, ActMstAddInf.AccBankAccNo, ActMstAddInf.AccAcinBankName, ActMstAddInf.AccAddress1, ActMstAddInf.AccAddress2, ActMstAddInf.AccAddress3, ActMstAddInf.AccZipCode,  CITYMASTER.CTNAME, STATEMASTER.STNAME,ActMst.AccCrLimit,ActMstAddInf.AccMrpMarkDown FROM  ActMst INNER JOIN ActMstAddInf ON ActMst.AccCode = ActMstAddInf.AccCode INNER JOIN CITYMASTER ON ActMstAddInf.AccCityCode = CITYMASTER.CTSYSID INNER JOIN STATEMASTER ON CITYMASTER.UNDERSTID = STATEMASTER.STSYSID Where ActMst.AccCode='" + txtDelieveryCode.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        txtDelieveryCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                        txtDelieveryName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                        txtDelieveryAddress1.Text = ds.Tables[0].Rows[0]["AccAddress1"].ToString();
                        txtDelieveryAddress2.Text = ds.Tables[0].Rows[0]["AccAddress2"].ToString();
                        txtDelieveryAddress3.Text = ds.Tables[0].Rows[0]["AccAddress3"].ToString();
                        txtDelieveryState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                        txtDelieveryCity.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                        txtDelieveryZipCode.Text = ds.Tables[0].Rows[0]["AccZipCode"].ToString();
                        txtDANo.Focus();
                    }

                    else
                    {
                        DataSet ds1 = ProjectFunctions.GetDataSet("SELECT        ActMst.AccCode, ActMst.AccName, ActMst.AccGSTNo, ActMstAddInf.AccBankAccNo, ActMstAddInf.AccAcinBankName, ActMstAddInf.AccAddress1, ActMstAddInf.AccAddress2, ActMstAddInf.AccAddress3, ActMstAddInf.AccZipCode,  CITYMASTER.CTNAME, STATEMASTER.STNAME,ActMst.AccCrLimit,ActMstAddInf.AccMrpMarkDown FROM  ActMst INNER JOIN ActMstAddInf ON ActMst.AccCode = ActMstAddInf.AccCode INNER JOIN CITYMASTER ON ActMstAddInf.AccCityCode = CITYMASTER.CTSYSID INNER JOIN STATEMASTER ON CITYMASTER.UNDERSTID = STATEMASTER.STSYSID");
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

        private void TxtDelieveryCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDelieveryName.Text = String.Empty;
            txtDelieveryAddress1.Text = String.Empty;
            txtDelieveryAddress2.Text = String.Empty;
            txtDelieveryAddress3.Text = String.Empty;
            txtDelieveryCity.Text = String.Empty;
            txtDelieveryZipCode.Text = String.Empty;
            txtDelieveryState.Text = String.Empty;

        }
        private void GetPartyBalances()
        {
            if (txtCreditLimit.Text.Length == 0)
            {
                txtCreditLimit.Text = "0";
            }
            DataSet dsPartyLedgerBal = ProjectFunctions.GetDataSet("sp_PartyLedgerBal '" + txtDebitPartyCode.Text + "'");
            if (dsPartyLedgerBal.Tables[0].Rows.Count > 0)
            {
                txtLedgerBalance.Text = dsPartyLedgerBal.Tables[0].Rows[0]["Balance"].ToString();
                txtAmountDue.Text = (Convert.ToDecimal(txtLedgerBalance.Text) - Convert.ToDecimal(txtCreditLimit.Text)).ToString("0.00");
            }
        }


        private void BTBXWT_Click(object sender, EventArgs e)
        {
            HelpGridView.Columns.Clear();
            dtWeight.Clear();
            PSGridView.CloseEditor();
            PSGridView.UpdateCurrentRow();
            foreach (DataRow drOuter in (PSGrid.DataSource as DataTable).Rows)
            {
                if (drOuter["Select"].ToString().ToUpper() == "TRUE")
                {
                    DataSet dsWeight = ProjectFunctions.GetDataSet("sp_LoadPackingSlipMstFWeight '" + drOuter["PSWSNO"].ToString() + "','" + GlobalVariables.CUnitID + "','" + GlobalVariables.FinancialYear + "'");
                    if (dtWeight.Rows.Count == 0)
                    {
                        dtWeight = dsWeight.Tables[0];
                    }
                    else
                    {
                        dtWeight.Merge(dsWeight.Tables[0]);
                    }

                }
            }


            if (dtWeight.Rows.Count > 0)
            {
                HelpGrid.Text = "WEIGHT";
                HelpGrid.DataSource = dtWeight;
                HelpGridView.BestFitColumns();
                HelpGrid.Show();
                HelpGrid.Focus();
            }
            else
            {
                HelpGrid.DataSource = null;
            }
            HelpGridView.OptionsBehavior.Editable = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in HelpGridView.Columns)
            {
                if (col.FieldName.ToUpper() == "WEIGHT")
                {
                    col.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    col.OptionsColumn.AllowEdit = false;
                }
            }
        }

        private void ChPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (chPaid.Checked)
            {
                chToPay.Checked = false;
            }

        }

        private void ChToPay_CheckedChanged(object sender, EventArgs e)
        {
            if (chToPay.Checked)
            {
                chPaid.Checked = false;
                txtBuiltyAmount.Text = String.Empty;
            }
        }

        private void ChRegular_CheckedChanged(object sender, EventArgs e)
        {
            if (chRegular.Checked)
            {
                chLot.Checked = false;
                dt.Clear();
            }

        }

        private void ChLot_CheckedChanged(object sender, EventArgs e)
        {
            if (chLot.Checked)
            {
                chRegular.Checked = false;
                dt.Clear();
            }
        }

        private void btnRecalculate_Click(object sender, EventArgs e)
        {
            String LCTag = ProjectFunctions.GetDataSet("Select AccLcTag from ActMst Where AccCode='" + txtDebitPartyCode.Text + "'").Tables[0].Rows[0]["AccLcTag"].ToString();

            foreach (DataRow dr in (InfoGrid.DataSource as DataTable).Rows)
            {

                var str = "Exec [sp_LoadTaxMstFInvoice] @PrdCode='" + dr["SIDARTID"].ToString() + "',";
                str = str + "@LCTag='" + LCTag + "',@ValueOfGoods='" + Convert.ToDecimal(dr["SIDARTMRP"]) + "'";
                DataSet dsTax = ProjectFunctions.GetDataSet(str);
                if (dsTax.Tables[0].Rows.Count > 0)
                {
                    dr["SIDCGSTPER"] = Convert.ToDecimal(dsTax.Tables[0].Rows[0]["TaxCGSTRate"]);
                    dr["SIDSGSTPER"] = Convert.ToDecimal(dsTax.Tables[0].Rows[0]["TaxSGSTRate"]);
                    dr["SIDIGSTPER"] = Convert.ToDecimal(dsTax.Tables[0].Rows[0]["TaxIGSTRate"]);
                }
            }
            calculation();
        }

        private void txtMainDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRecalculate_Click(null, e);
            }
        }

        private void txtInsurancePer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRecalculate_Click(null, e);
            }
        }

        private void InfoGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (InfoGrid.DataSource != null)
                {
                    if (e.Column.FieldName == "SIDSCANQTY")
                    {
                        InfoGridView.CloseEditor();
                        InfoGridView.UpdateCurrentRow();
                        btnRecalculate_Click(null, e);
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void PSGrid_Click(object sender, EventArgs e)
        {

        }
    }
}