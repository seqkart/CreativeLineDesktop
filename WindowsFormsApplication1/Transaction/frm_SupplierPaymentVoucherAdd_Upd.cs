using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frm_SupplierPaymentVoucherAdd_Upd : DevExpress.XtraEditors.XtraForm
    {



        public string CurrentControl { get; set; }
        public int LocalNoOfRecords { get; set; }
        public string VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherType { get; set; }
        public string BnkChgsCode { get; set; }
        public bool isupdate { get; set; }
        private bool AuthenticateFlag = false;
        private int CurrentDataBId;
        private string lastAmt;
        private string OldVoucherNo = string.Empty;
        private int CurrentMstRecord = 0;
        private int CurrentDataCId = 0;
        private int CurrentDataDId = 0;
        private string MMValue = string.Empty;
        private DataSet DS4GridOrignal;
        private DataTable Record;
        private DataRow ThisRecord;
        private int id;
        private string VarDCNO;
        private string VarVumId4DCData;
        private DateTime FStartDate;

        public frm_SupplierPaymentVoucherAdd_Upd()
        {
            InitializeComponent();
        }

        private void frm_PaymentVoucherInfo_Load(object sender, EventArgs e)
        {
            Record = new DataTable();
            SetMyControls();
            if (isupdate)
            {
                SettingForUpdation();
                Text = "Supplier Payment Updation Module";
            }
            else
            {
                FStartDate = DateTime.Today;
                DtVoucher.EditValue = (DateTime.Now.Date >= GlobalVariables.FinYearStartDate && DateTime.Now.Date <= GlobalVariables.FinYearEndDate) ? DateTime.Now : GlobalVariables.FinYearEndDate.Date;
                DtVoucher.Focus();
            }
        }

        private void SetMyControls()
        {
            try
            {
                ProjectFunctions.XtraFormVisualize(this);
                ProjectFunctions.GirdViewVisualize(EntryInfo_Grid);
                ProjectFunctions.GirdViewVisualize(EntryInfo_Grid);
                ProjectFunctions.GirdViewVisualize(HelpGrid);
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ButtonVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                BtnDelete.Enabled = false;
                BnkChgsCode = "0044";

                Record.Columns.Add("AcName", typeof(string));
                Record.Columns.Add("Method", typeof(string));
                Record.Columns.Add("RefPayment", typeof(Decimal));
                Record.Columns.Add("BillRefNo", typeof(string));
                Record.Columns.Add("BillRefDate", typeof(DateTime));
                Record.Columns.Add("BillRefAmount", typeof(Decimal));
                Record.Columns.Add("BillRefBalance", typeof(Decimal));
                Record.Columns.Add("MmBillPassID", typeof(string));
                Record.Columns.Add("MmDocNo", typeof(string));
                Record.Columns.Add("MmDocDate", typeof(DateTime));
                Record.Columns.Add("EntryId", typeof(int)).AutoIncrement = true;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void SettingForUpdation()
        {
            try
            {
                using (var ds = ProjectFunctions.GetDataSet(String.Format("SP_GETDATA4Party2PAyMENT '{0}', '{1}', '{2:yyyy-MM-dd}'", VoucherNo, VoucherType, VoucherDate)))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow Dr in ds.Tables[0].Rows)
                        {
                            CurrentMstRecord = int.Parse(Dr["VumID"].ToString());
                            if (Convert.ToDecimal(Dr["VutAmt"]) >= 0)
                            {
                                TextDNNarr1.Text = Dr[15].ToString().Substring(3);
                                if (!Dr["DebitAc"].ToString().Equals(BnkChgsCode))
                                {
                                    CurrentDataDId = int.Parse(Dr["VutID"].ToString());
                                    TextDebitAc.Text = Dr["DebitAc"].ToString();
                                    TextDebitAcName.Text = Dr["DebitAcName"].ToString();
                                    TextPaymentToLoad.Text = Dr["VutAmt"].ToString();
                                }
                                else
                                {
                                    CurrentDataBId = int.Parse(Dr["VutID"].ToString());
                                    TextBnkChgs.Text = Dr["VutAmt"].ToString();
                                }
                            }
                            if (Convert.ToDecimal(Dr["VutAmt"]) <= 0)
                            {
                                TextCreditAc.Text = Dr["DebitAc"].ToString();
                                TextCreditAcName.Text = Dr["DebitAcName"].ToString();
                                CurrentDataCId = int.Parse(Dr["VutID"].ToString());
                                TextVouchNarration.Text = Dr["VutNart"].ToString().Substring(3);
                            }
                            DtVoucher.EditValue = Convert.ToDateTime(Dr["VumDate"]);
                            TextVoucherType.Text = Dr["VumType"].ToString();
                            TextVoucherDesc.Text = Dr["VouDesc"].ToString();
                            TextVoucherNo.Text = Dr["VumNo"].ToString();
                            OldVoucherNo = Dr["VumNo"].ToString();
                            TextInstrumentType.Text = Dr["VumInstType"].ToString();
                            TextInstrumentNo.Text = Dr["VumInstNo"].ToString();
                            TextDNNarr2.Text = Dr["DcNar2"].ToString();
                            TextDNNarr3.Text = Dr["DcNar3"].ToString();
                            TextDNNarr4.Text = Dr["DcNar4"].ToString();
                            TextDNNarr5.Text = Dr["DcNar5"].ToString();
                            VarVumId4DCData = Dr["VumID"].ToString();
                            VarDCNO = Dr["DcNo"].ToString();
                            LocalNoOfRecords = int.Parse(Dr["VumNoRcd"].ToString());
                        }
                        TextDebitAc.Enabled = false;
                    }

                    DS4GridOrignal = ds;
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow Dr in ds.Tables[1].Rows)
                        {
                            Record.Rows.Add(Dr["AcName"].ToString(), Dr["Method"].ToString(), Convert.ToDecimal(Dr["RefPayment"].ToString()), string.IsNullOrEmpty(Dr["BillRefNo"].ToString()) ? "999999" : Dr["BillRefNo"].ToString(), string.IsNullOrEmpty(Dr["BillRefDate"].ToString()) ? DateTime.Now.Date : DateTime.Parse(Dr["BillRefDate"].ToString()), string.IsNullOrEmpty(Dr["BillRefAmount"].ToString()) ? Convert.ToDecimal("9999999999") : Convert.ToDecimal(Dr["BillRefAmount"].ToString()), string.IsNullOrEmpty(Dr["BillRefBalance"].ToString()) ? Convert.ToDecimal("999999999") : Convert.ToDecimal(Dr["BillRefBalance"].ToString()), Dr["MmBillPassID"].ToString(), string.IsNullOrEmpty(Dr["MmDocNo"].ToString()) ? "999999" : Dr["MmDocNo"].ToString(), string.IsNullOrEmpty(Dr["MmDocDate"].ToString()) ? DateTime.Now.Date.ToString("yyyy-MM-dd") : Convert.ToDateTime(Dr["MmDocDate"]).ToString("yyyy-MM-dd"));
                        }
                    }
                }
                EntryInfo_GridCtrl.DataSource = Record;
                TextCreditAc.Focus();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Verify Whether there is Records in Grid or not." + ex.Message);
            }
            DtVoucher.Enabled = false;
        }

        private void DtVoucher_Enter(object sender, EventArgs e)
        {
            DtVoucher.SelectAll();
        }

        private void DtVoucher_Validated(object sender, EventArgs e)
        {
            //if (!ProjectFunctions.CheckRange(DtVoucher.DateTime, GlobalVariables.FinYearStartDate.Date, DateTime.Today.AddDays(3650)))
            //    {
            //    DtVoucher.Focus();
            //    Error.SetError(DtVoucher, "Date does not fall in Expected Range. Either You are crossign FinancialYear Limit or Crossing Today Limit.");
            //    return;
            //    }

            if (DtVoucher.DateTime.Date == DateTime.Now.Date || AuthenticateFlag)
            {
                if (!isupdate)
                {
                    Error.Dispose();
                    var query = String.Format("select dbo.DoPadd((SELECT     isnull(max(cast(VumNo as int)),0) as 'Value' FROM VuMst WHERE     (VumType <> 'SL') and (VumType <> 'SR')and VumDate='{0}')+1) as Value;", DtVoucher.DateTime.ToString("yyyy-MM-dd"));
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextVoucherNo.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                        Error.Dispose();
                    }
                }
            }
            else
            {
                TextAuthenticate.Visible = true;
                TextAuthenticate.Focus();
            }
        }

        private void TextVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextVoucherType";
                    const string Query = "SELECT  [VouCode],[VouDesc]  FROM  [VoucherType]  where VouCode in ('JL','BP','DN','CP') Order By VouCode;";
                    if (TextVoucherType.Text.Trim().Length == 0)
                    {
                        TextVouchNarration.Enabled = false;
                        ShowHelpWindow(Query);
                        e.Handled = true;
                    }
                    else
                    {
                        var query = String.Format("SELECT  [VouCode],[VouDesc]  FROM  [VoucherType]  where (VouCode in ('JL','BP','DN','CP')) AND VouCode='{0}' Order By VouCode;", TextVoucherType.Text);
                        var ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextVoucherType.Text = ds.Tables[0].Rows[0]["VouCode"].ToString();
                            TextVoucherDesc.Text = ds.Tables[0].Rows[0]["VouDesc"].ToString();
                            TextCreditAc.Focus();
                        }

                        else
                        {
                            ShowHelpWindow(Query);
                        }
                    }
                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }
                e.Handled = true;

            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void HelpGridCtrl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = HelpGrid.GetDataRow(HelpGrid.FocusedRowHandle);
                switch (CurrentControl)
                {
                    case "TextVoucherType":
                        TextVoucherType.Text = row["VouCode"].ToString();
                        TextVoucherDesc.Text = row["VouDesc"].ToString();
                        HelpGridCtrl.Visible = false;
                        TextCreditAc.Focus();
                        break;

                    case "TextCreditAc":
                        TextCreditAc.Text = row["AccCode"].ToString();
                        TextCreditAcName.Text = row["AccName"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextInstrumentType.Focus();
                        Error.Dispose();
                        break;

                    case "TextDebitAc":
                        TextDebitAc.Text = row["AccCode"].ToString();
                        TextDebitAcName.Text = row["AccName"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextPaymentMethod.Focus();
                        Error.Dispose();
                        break;
                    case "TextInstrumentType":
                        TextInstrumentType.Text = row["Type"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextInstrumentNo.Focus();
                        Error.Dispose();
                        break;
                    case "TextPaymentMethod":
                        TextPaymentMethod.Text = row["Description"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextBill_Ref_No.Focus();
                        Error.Dispose();
                        break;
                    case "TextBill_Ref_No":
                        var dt = new DateTime();
                        TextBill_Ref_No.Text = row["MmRDocNo"].ToString();
                        DateTime.TryParse(row["MmRDocdate"].ToString(), out dt);
                        DtBillRef.DateTime = dt;
                        TextBill_Ref_Amt.Text = Math.Round(float.Parse(row["MmPassedAmt"].ToString()), 2).ToString();

                        TextRefBalance.Text = Math.Round(float.Parse(row["mmBillBalAmt"].ToString()), 2).ToString();
                        TextMMDocNo.Text = row["MmDocNo"].ToString();
                        TextMmBillPassID.Text = row["MmBillPassID"].ToString();
                        DateTime.TryParse(row["MmDocDate"].ToString(), out dt);
                        DtMMDoc.DateTime = dt;
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextRefPayment.Focus();
                        Error.Dispose();
                        break;
                    default:
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        CurrentControl = string.Empty;
                        Error.Dispose();
                        break;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Either No Record or Unable to Fetch Data. " + ex.Message);
                CurrentControl = string.Empty;
                HelpGridCtrl.Visible = false;
                TextDebitAc.Focus();
            }
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton)
            {
                HelpGridCtrl_DoubleClick(sender, e);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                HelpGridCtrl.Visible = false;
                RestoreFocus();
                e.Handled = true;
            }
        }

        private void HelpGridCtrl_Leave(object sender, EventArgs e)
        {
            HelpGridCtrl_DoubleClick(sender, e);
        }

        private void RestoreFocus()
        {
            if (CurrentControl == "TextCreditAc")
            {
                TextInstrumentType.Focus();
            }
        }

        private void ShowHelpWindow(string Query)
        {
            try
            {
                HelpGridCtrl.DataSource = null;
                HelpGrid.Columns.Clear();
                HelpGridCtrl.RefreshDataSource();

                using (var ds = ProjectFunctions.GetDataSet(Query))
                {
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            HelpGridCtrl.Visible = true;
                            HelpGridCtrl.Focus();
                            HelpGridCtrl.DataSource = ds.Tables[0];
                            if (CurrentControl == "TextBill_Ref_No")
                            {
                                //HelpGridCtrl.Location = new System.Drawing.Point(305, 27);
                                //HelpGridCtrl.Size = new System.Drawing.Size(510, 323);
                                HelpGrid.Columns["MmDocNo"].Visible = false;
                                HelpGrid.Columns["MmRDocdate"].Visible = false;
                                HelpGrid.Columns["MmDocType"].Visible = false;
                                HelpGrid.Columns["MmPartyCode"].Visible = false;
                                HelpGrid.Columns["MmBillPassID"].Visible = false;
                                HelpGrid.Columns["MmRDocdate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                                HelpGrid.Columns["MmRDocdate"].DisplayFormat.FormatString = "dd/MM/yyyy";
                                HelpGridCtrl.Refresh();
                            }
                            else
                            {
                                HelpGrid.OptionsView.ColumnAutoWidth = true;
                            }
                            HelpGrid.Columns[0].BestFit();
                        }
                        else
                        {
                            HelpGridCtrl.Visible = false;
                            ProjectFunctions.SpeakError("No Record.");
                        }
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Unable to fetch Data or No Record.");
                        HelpGridCtrl.Visible = false;
                    }
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                ProjectFunctions.SpeakError("Unable to fetch Data or No Record.");
                HelpGridCtrl.Visible = false;
            }
        }

        private void TextCreditAc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    var Query = string.Empty;
                    CurrentControl = "TextCreditAc";
                    switch (TextVoucherType.Text)
                    {
                        case "BP":
                            Query = "SELECT      AccName, AccCode, AccLedger FROM         ActMst WHERE     (AccBankTag = N'Y') Order by AccName;";
                            break;
                        case "CP":
                            Query = "SELECT     AccName,  AccCode, AccLedger FROM ActMst WHERE (AccCode = N'" + GlobalVariables.CashCode + "')  Order by AccName;";
                            break;
                        default:
                            Query = "SELECT     AccName,  AccCode, AccLedger FROM ActMst ";
                            break;
                    }

                    if (TextCreditAc.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                        e.Handled = true;
                    }

                    else
                    {
                        var query = string.Empty;
                        if (TextVoucherType.Text == "BP" || TextVoucherType.Text == "CP" || TextVoucherType.Text == "DN" || TextVoucherType.Text == "JL")
                        {
                            CurrentControl = "SubMenu";
                            switch (TextVoucherType.Text)
                            {
                                case "BP":
                                    query = string.Format("SELECT      AccName,AccCode, AccLedger FROM         ActMst WHERE     (AccBankTag = N'Y') and AccCode='{0}' Order by AccName;", TextCreditAc.Text.Trim());
                                    break;
                                case "CP":
                                    query = "SELECT      AccName, AccCode,AccLedger FROM ActMst WHERE (AccCode = N'0099')  Order by AccName;";
                                    break;

                                default:
                                    query = string.Format("SELECT      AccName, AccCode,AccLedger FROM ActMst WHERE AccCode='{0}' Order by AccName;", TextCreditAc.Text.Trim());

                                    break;
                            }
                        }

                        var ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextCreditAc.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                            TextCreditAcName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                            TextInstrumentType.Focus();
                        }
                        else
                        {
                            ShowHelpWindow(Query);
                        }
                        e.Handled = true;
                    }
                    if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                    {
                        e.SuppressKeyPress = true;
                        SelectNextControl(ActiveControl, false, true, true, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TextInstrumentType_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextInstrumentType.Text.StartsWith("C", StringComparison.CurrentCultureIgnoreCase) && TextPaymentMethod.Text.Length <= 3)
            {
                TextInstrumentType.Text = "CQ";
            }
            else
            {
                if (TextInstrumentType.Text.StartsWith("D", StringComparison.CurrentCultureIgnoreCase) && TextPaymentMethod.Text.Length <= 3)
                {
                    TextInstrumentType.Text = "DD";
                }
                else
                {
                    if (TextInstrumentType.Text.StartsWith("N", StringComparison.CurrentCultureIgnoreCase) && TextPaymentMethod.Text.Length <= 3)
                    {
                        TextInstrumentType.Text = "NEFT";
                    }
                    else
                    {
                        if (TextInstrumentType.Text.StartsWith("R", StringComparison.CurrentCultureIgnoreCase) && TextPaymentMethod.Text.Length <= 3)
                        {
                            TextInstrumentType.Text = "RTGS";
                        }
                    }
                }
            }
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextInstrumentType";
                    const string Query = "SELECT [Type],[Description] FROM  [TempTable] where Id='IT' order by [Type]";
                    if (TextInstrumentType.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                    }
                    else
                    {
                        var query = String.Format("SELECT [Type],[Description] FROM  [TempTable] where Id='IT' and [Type]='{0}'  order by [Type] ;", TextInstrumentType.Text.Trim());
                        var ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextInstrumentType.Text = ds.Tables[0].Rows[0]["Type"].ToString();
                            TextInstrumentNo.Focus();
                        }
                        else
                        {
                            ShowHelpWindow(Query);
                        }
                    }
                    e.Handled = true;
                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TextInstrumentType_Validated(object sender, EventArgs e)
        {
            if (TextInstrumentType.Text.Trim().Equals("DD") || TextInstrumentType.Text.Trim().Equals("CQ") || TextInstrumentType.Text.Trim().Equals("NEFT"))
            {
                Error.Dispose();
            }
        }

        private void TextDebitAc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextDebitAc";
                    const string Query = "Select [AccName],[AccCode],[CurBal]  FROM [dbo].[V_PartyWithCurBal] order by 1 ;";
                    if (TextDebitAc.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                    }
                    else
                    {
                        var query = String.Format("Select [AccName],[AccCode],[CurBal]  FROM [dbo].[V_PartyWithCurBal] where  [AccCode]={0} ;", TextDebitAc.Text.Trim());
                        var ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextDebitAc.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                            TextDebitAcName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();

                            TextPaymentMethod.Focus();
                        }
                        else
                        {
                            ShowHelpWindow(Query);
                        }
                    }
                    e.Handled = true;
                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TextPaymentMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextPaymentMethod.Text.StartsWith("R", StringComparison.CurrentCultureIgnoreCase) && TextPaymentMethod.Text.Length <= 3)
            {
                TextPaymentMethod.Text = "RPMT";
            }
            else
            {
                if (TextPaymentMethod.Text.StartsWith("O", StringComparison.CurrentCultureIgnoreCase) && TextPaymentMethod.Text.Length <= 3)
                {
                    TextPaymentMethod.Text = "ONAC";
                }
            }
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextPaymentMethod";
                    const string Query = "SELECT [Type],[Description] FROM  [TempTable] where Id='PM' order by [Description]";
                    if (TextInstrumentType.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                    }
                    else
                    {
                        using (var ds = ProjectFunctions.GetDataSet(String.Format("SELECT [Type],[Description] FROM  [TempTable] where Id='PM' and [TYPE]='{0}';", TextPaymentMethod.Text.Trim())))
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                TextPaymentMethod.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                                TextBill_Ref_No.Focus();
                            }
                            else
                            {
                                ShowHelpWindow(Query);
                            }
                        }
                    }
                    e.Handled = true;
                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TextBill_Ref_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    if (!TextPaymentMethod.Text.Equals("On Account"))
                    {
                        CurrentControl = "TextBill_Ref_No";
                        var Query = "SELECT  BilltoPass.MmRDocNo,   BilltoPass.MmDocNo, BilltoPass.MmDocDate, BilltoPass.MmDocType, BilltoPass.MmPartyCode,   ";
                        Query += "      BilltoPass.MmRDocNetAmt, BilltoPass.MmRDocdate,BilltoPass.MmDNAmt, BilltoPass.MmPassedAmt,  BilltoPass.MmJLAmt, BilltoPass.MmPymtAmt, BilltoPass.MmBillPassID, ";
                        Query += "  BilltoPass.MmRDocNetAmt - ISNULL(BilltoPass.MmDNAmt, 0) - ISNULL(BilltoPass.MmJLAmt, 0) - ISNULL(BilltoPass.MmPymtAmt, 0)  AS mmBillBalAmt ";
                        Query += "FROM         BilltoPass INNER JOIN ";
                        Query += "ActMst ON BilltoPass.MmPartyCode = ActMst.AccCode ";
                        Query += String.Format("WHERE   BilltoPass.MmPassedAmt is not null and   (BilltoPass.MmDocDate >= CONVERT(DATETIME, '2015-04-01', 102)) AND (BilltoPass.MmPartyCode = N'{0}') AND ", TextDebitAc.Text);
                        Query += "(BilltoPass.MmRDocNetAmt - ISNULL(BilltoPass.MmDNAmt, 0) - ISNULL(BilltoPass.MmJLAmt, 0) - ISNULL(BilltoPass.MmPymtAmt, 0) > 0) ";
                        if (BtnOk.Text != "&Ok")
                        {
                            Query += String.Format(" Or ((MmDocDate>'20140101') And (BilltoPass.MmRDocNo='{0}'))", TextBill_Ref_No.Text);
                        }
                        Query += " ORDER BY MMDOCDATE;";
                        if (TextBill_Ref_No.Text.Trim().Length == 0)
                        {
                            ShowHelpWindow(Query);
                        }
                        else
                        {
                            var query = "SELECT   BilltoPass.MmRDocNo,   BilltoPass.MmDocNo, BilltoPass.MmDocDate, BilltoPass.MmDocType, BilltoPass.MmPartyCode,  BilltoPass.MmPassedAmt, ";
                            query += "     BilltoPass.MmRDocdate, BilltoPass.MmRDocNetAmt, BilltoPass.MmDNAmt, BilltoPass.MmPymtAmt, BilltoPass.MmBillPassID, ";
                            query += "  BilltoPass.MmRDocNetAmt - ISNULL(BilltoPass.MmDNAmt, 0) - ISNULL(BilltoPass.MmJLAmt, 0) - ISNULL(BilltoPass.MmPymtAmt, 0)  AS mmBillBalAmt ";
                            query += "FROM         BilltoPass INNER JOIN ";
                            query += "ActMst ON BilltoPass.MmPartyCode = ActMst.AccCode ";
                            query += String.Format("WHERE  BilltoPass.MmPassedAmt is not null AND (BilltoPass.MmPartyCode = N'{1}') and    (BilltoPass.MmDocDate >= CONVERT(DATETIME, '" + GlobalVariables.FinYearStartDate.ToString("yyyy-MM-dd") + "', 102)) AND  BilltoPass.MmRDocNo='{0}' ;", TextBill_Ref_No.Text.Trim(), TextDebitAc.Text);

                            var ds = ProjectFunctions.GetDataSet(query);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                var dt = new DateTime();
                                TextBill_Ref_No.Text = ds.Tables[0].Rows[0]["MmRDocNo"].ToString();
                                DateTime.TryParse(ds.Tables[0].Rows[0]["MmRDocdate"].ToString(), out dt);
                                DtBillRef.DateTime = dt;
                                TextBill_Ref_Amt.Text = Math.Round(float.Parse(ds.Tables[0].Rows[0]["MmPassedAmt"].ToString()), 2).ToString();
                                if (lastAmt == null)
                                {
                                    lastAmt = "0";
                                }
                                if (lastAmt == string.Empty)
                                {
                                    lastAmt = "0";
                                }

                                TextRefBalance.Text = Math.Round(float.Parse(lastAmt) + float.Parse(ds.Tables[0].Rows[0]["mmBillBalAmt"].ToString()), 2).ToString();
                                TextMMDocNo.Text = ds.Tables[0].Rows[0]["MmDocNo"].ToString();
                                TextMmBillPassID.Text = ds.Tables[0].Rows[0]["MmBillPassID"].ToString();
                                DateTime.TryParse(ds.Tables[0].Rows[0]["MmDocDate"].ToString(), out dt);
                                DtMMDoc.DateTime = dt;
                                TextRefPayment.Focus();
                            }
                            else
                            {
                                ShowHelpWindow(Query);
                            }
                        }
                        e.Handled = true;
                    }
                    else
                    {
                        TextBill_Ref_No.Text = "999999";
                        DtBillRef.DateTime = DateTime.Now.Date;
                        TextBill_Ref_Amt.Text = "999999999";
                        TextRefBalance.Text = "999999999";
                        TextMMDocNo.Text = "999999";
                        TextMmBillPassID.Text = "999999";
                        DtMMDoc.DateTime = DateTime.Now.Date;
                    }
                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void TextPaymentToLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void TextPaymentToLoad_Validated(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextPaymentToLoad.Text.Trim()))
                {
                    Error.SetError(TextPaymentToLoad, "Please Enter Valid Amount.");
                    TextPaymentToLoad.Focus();
                }
                else
                {
                    if (EntryInfo_Grid.DataSource != null)
                    {
                        var LoadedAmt = 0f;
                        var Result = 0f;
                        if (float.TryParse(gridColumn11.SummaryItem.SummaryValue.ToString(), out Result))
                        {
                            float.TryParse(TextPaymentToLoad.Text, out LoadedAmt);
                            var diff = (LoadedAmt - Result);
                            if (Math.Round(diff, 2) >= 0)
                            {
                                TextBalanceLeft.Text = diff.ToString();
                                if (!TextDebitAc.IsAccessible)
                                {
                                    TextPaymentMethod.Focus();
                                }
                                Error.Dispose();
                            }
                            else
                            {
                                Error.SetError(TextPaymentToLoad, "Hurrah!");
                                TextPaymentToLoad.Focus();
                            }
                        }
                    }
                    else
                    {
                        if (float.Parse(TextPaymentToLoad.Text) > 0)
                        {
                            TextBalanceLeft.Text = TextPaymentToLoad.Text;
                            Error.Dispose();
                        }
                        else
                        {
                            Error.SetError(TextPaymentToLoad, "Hurrah!");
                            TextPaymentToLoad.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SetError(TextPaymentToLoad, "Something false!" + ex.Message);
                TextPaymentToLoad.Focus();
            }
        }

        private void TextRefPayment_Enter(object sender, EventArgs e)
        {
            try
            {
                TextRefPayment.Text = Math.Round(float.Parse(TextRefBalance.Text), 2) > Math.Round(float.Parse(TextBalanceLeft.Text), 2) ? TextBalanceLeft.Text : TextRefBalance.Text;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void TextRefPayment_Validated(object sender, EventArgs e)
        {
            try
            {
                var Flag = Math.Round(float.Parse(TextRefPayment.Text), 2) > Math.Round(float.Parse(TextBalanceLeft.Text), 2) ? false : true;

                if (Flag)
                {
                    Flag = Math.Round(float.Parse(TextRefPayment.Text), 2) > Math.Round(float.Parse(TextRefBalance.Text), 2) ? false : true;
                    if (Flag)
                    {
                        if (float.Parse(TextRefPayment.Text) >= 0)
                        {
                            Error.Dispose();
                            BtnOk.Enabled = true;
                            BtnOk.Focus();
                        }
                        else
                        {
                            Error.SetError(TextRefPayment, "Hurrah!");

                            BtnOk.Enabled = false;
                        }
                    }
                    else
                    {
                        BtnOk.Enabled = false;
                        Error.SetError(TextRefPayment, "Please Enter Valid Amount");
                    }
                }
                else
                {
                    BtnOk.Enabled = false;
                    Error.SetError(TextRefPayment, "Please Enter Valid Amount");
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                BtnOk.Enabled = false;
                Error.SetError(TextRefPayment, "Please Enter Valid Amount");
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            TextRefPayment_Validated(sender, e);
            if (BtnOk.Text == "&Ok")
            {
                try
                {
                    var rowHandle = 0;
                    if (Record.Rows.Count > 0)
                    {
                        rowHandle = (ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "MmBillPassID", TextMmBillPassID.Text) >= 0) ? -1 : 0;
                    }
                    if (TextPaymentMethod.Text == "On Account")
                    {
                        rowHandle = 0;
                    }
                    if (rowHandle == 0)
                    {
                        Record.Rows.Add(TextDebitAcName.Text, TextPaymentMethod.Text, Convert.ToDecimal(TextRefPayment.EditValue), TextBill_Ref_No.Text,
                        DtBillRef.DateTime.Date, Convert.ToDecimal(TextBill_Ref_Amt.EditValue), Convert.ToDecimal(TextRefBalance.EditValue),
                        TextMmBillPassID.Text, TextMMDocNo.Text, DtMMDoc.DateTime.Date);

                        TextRefPayment.Text = "0.00";
                        TextBill_Ref_No.Text = string.Empty;
                        DtBillRef.Text = string.Empty;
                        TextBill_Ref_Amt.Text = "0.00";
                        TextRefBalance.Text = "0.00";
                        TextMmBillPassID.Text = string.Empty;
                        TextMMDocNo.Text = string.Empty;
                        DtMMDoc.Text = string.Empty;
                        EntryInfo_GridCtrl.DataSource = Record;
                        TextPaymentMethod.Focus();
                        if (EntryInfo_Grid.DataSource != null)
                        {
                            var LoadedAmt = 0f;
                            var Result = 0f;
                            if (float.TryParse(gridColumn11.SummaryItem.SummaryValue.ToString(), out Result))
                            {
                                float.TryParse(TextPaymentToLoad.Text, out LoadedAmt);
                                var diff = (LoadedAmt - Result);
                                TextBalanceLeft.Text = diff.ToString();
                            }
                        }
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Sir You are going to pay for same Entry Again. Please Save Money!");
                        TextPaymentMethod.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ProjectFunctions.SpeakError("Oops! What the Hell is Going On. Please Contact It Department with Message." + ex.Message);
                }
            }
            if (BtnOk.Text == "&Update")
            {
                try
                {
                    var rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "EntryId", id);
                    var firstrow = EntryInfo_Grid.FocusedRowHandle;
                    var secondRow = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "MmBillPassID", TextMmBillPassID.Text);
                    if (firstrow == secondRow)
                    {
                        EntryInfo_Grid.BeginDataUpdate();
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["Method"], TextPaymentMethod.Text.Trim());
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["RefPayment"], Convert.ToDecimal(TextRefPayment.EditValue));
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["BillRefNo"], TextBill_Ref_No.Text.Trim());
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["BillRefDate"], DtBillRef.DateTime.Date);
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["BillRefAmount"], Convert.ToDecimal(TextBill_Ref_Amt.EditValue));
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["BillRefBalance"], Convert.ToDecimal(TextRefBalance.EditValue) - Convert.ToDecimal(TextRefPayment.EditValue));
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["MmBillPassID"], TextMmBillPassID.Text.Trim());
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["MmDocNo"], TextMMDocNo.Text.Trim());
                        EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["MmDocDate"], DtMMDoc.DateTime.Date);

                        TextPaymentMethod.Text = string.Empty;
                        TextRefPayment.Text = "0.00";
                        TextBill_Ref_No.Text = string.Empty;
                        DtBillRef.Text = string.Empty;
                        TextBill_Ref_Amt.Text = "0.00";
                        TextRefBalance.Text = "0.00";
                        TextMmBillPassID.Text = string.Empty;
                        TextMMDocNo.Text = string.Empty;
                        DtMMDoc.Text = string.Empty;
                        EntryInfo_Grid.EndDataUpdate();
                        EntryInfo_Grid.UpdateSummary();

                        if (EntryInfo_Grid.DataSource != null)
                        {
                            var LoadedAmt = 0f;
                            var Result = 0f;
                            if (float.TryParse(gridColumn11.SummaryItem.SummaryValue.ToString(), out Result))
                            {
                                float.TryParse(TextPaymentToLoad.Text, out LoadedAmt);
                                var diff = (LoadedAmt - Result);
                                TextBalanceLeft.Text = diff.ToString();
                            }
                        }
                        Record = EntryInfo_GridCtrl.DataSource as DataTable;

                        EntryInfo_GridCtrl.RefreshDataSource();
                        TextPaymentMethod.Focus();

                        BtnOk.Text = "&Ok";
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Sir You are going to pay for same Entry Again. Please Save Money!");
                        TextPaymentMethod.Focus();
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    ProjectFunctions.SpeakError("Unable To Update, Please Contact IT Department");
                }
                TextBill_Ref_No.Enabled = true;
            }

            BtnDelete.Enabled = false;
            BtnOk.Enabled = false;
            var MultorNo = string.Empty;
            foreach (DataRow RowRecord in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
            {
                MultorNo += String.Format("{0},", RowRecord["BillRefNo"]);
            }
            var ki = MultorNo.LastIndexOf(',');
            MultorNo = MultorNo.Substring(0, ki);
            TextVouchNarration.Text = string.Empty;
            var Narration = string.Empty;
            switch (TextInstrumentType.Text)
            {
                case "RTGS":
                    Narration = String.Format("AMT. OF RTGS TFD. {0} To {1}", ((EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? (" AGST Bills " + (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo)) : (" ")), TextDebitAcName.Text);
                    break;
                case "NEFT":
                    Narration = String.Format("AMT. OF NEFT TFD. {0} To {1}", ((EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? (" AGST Bills " + (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo)) : (" ")), TextDebitAcName.Text);
                    break;
                case "CH":
                    Narration = (EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? String.Format(" Ch. NO {0} IN FAV. OF {1} AGST Bills {2} {3}", TextInstrumentNo.Text, TextDebitAcName.Text, (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo), TextVouchNarration.Text) : TextVouchNarration.Text;
                    break;
                case "OTH":
                    Narration = String.Format("AMT. OF BANK TFD. {0} To {1}", ((EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? (" AGST Bills " + (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo)) : (" ")), TextDebitAcName.Text);
                    break;
                default:
                    Narration = TextVouchNarration.Text;
                    break;
            }
            if (Narration.Length > 185)
            {
                Narration = Narration.Substring(0, 185) + "AND MANY MORE.";
            }
            TextVouchNarration.Text = Narration;

            switch (TextInstrumentType.Text)
            {
                case "RTGS":
                    Narration = String.Format("AMT. OF RTGS TFD. FROM {0} {1}", TextCreditAcName.Text, ((EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? (" AGST Bills " + (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo)) : (" ")));
                    break;
                case "NEFT":
                    Narration = String.Format("AMT. OF NEFT TFD. FROM {0} {1}", TextCreditAcName.Text, ((EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? (" AGST Bills " + (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo)) : (" ")));
                    break;
                case "CH":
                    Narration = (EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? String.Format(" Ch. NO {0}  AGST Bills {2} {3}", TextInstrumentNo.Text, TextDebitAcName.Text, (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo), string.Empty) : string.Empty;
                    break;
                case "OTH":
                    Narration = String.Format("AMT. OF BANK TFD. FROM {0} {1}", TextCreditAcName.Text, ((EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"].ToString() == "Ref. Payment" ? (" AGST Bills " + (MultorNo.EndsWith(",") ? MultorNo.Remove(MultorNo.Length - 1) : MultorNo)) : (" ")));
                    break;
                default:
                    Narration = TextVouchNarration.Text;
                    break;
            }
            if (Narration.Length > 185)
            {
                Narration = Narration.Substring(0, 185) + "AND MANY MORE.";
            }
            TextDNNarr1.Text = Narration;
        }

        private void EntryInfo_Grid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                id = int.Parse(EntryInfo_Grid.GetRowCellValue(e.FocusedRowHandle, EntryInfo_Grid.Columns["EntryId"]).ToString());
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void EntryInfo_GridCtrl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selRows = EntryInfo_Grid.GetSelectedRows();
                var selRow = (DataRowView)(EntryInfo_Grid.GetRow(selRows[0]));
                ThisRecord = selRow.Row;



                TextPaymentMethod.Text = ThisRecord["Method"].ToString();
                TextRefPayment.Text = ThisRecord["RefPayment"].ToString();
                TextBill_Ref_No.Text = ThisRecord["BillRefNo"].ToString();
                DtBillRef.Text = ThisRecord["BillRefDate"].ToString();
                TextBill_Ref_Amt.Text = ThisRecord["BillRefAmount"].ToString();
                TextRefBalance.Text = (Convert.ToDecimal(TextRefPayment.Text) + Convert.ToDecimal(ThisRecord["BillRefBalance"])).ToString();
                TextMmBillPassID.Text = ThisRecord["MmBillPassID"].ToString();
                TextMMDocNo.Text = ThisRecord["MmDocNo"].ToString();
                DtMMDoc.Text = ThisRecord["MmDocDate"].ToString();

                TextBalanceLeft.Text = (Math.Round(float.Parse(TextPaymentToLoad.Text), 2) - (Math.Round(float.Parse(EntryInfo_Grid.Columns["RefPayment"].SummaryItem.SummaryValue.ToString()), 2) - Math.Round(float.Parse(ThisRecord["RefPayment"].ToString()), 2))).ToString();

                BtnOk.Text = "&Update";
                TextDebitAc.Enabled = false;

                TextPaymentMethod.Focus();


                BtnDelete.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void EntryInfo_GridCtrl_DataSourceChanged(object sender, EventArgs e)
        {
            if (EntryInfo_GridCtrl.DataSource != null)
            {
                if (EntryInfo_Grid.RowCount > 0)
                {
                    TextDebitAc.Enabled = false;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (EntryInfo_GridCtrl.DataSource != null)
                {
                    if (EntryInfo_Grid.RowCount > 0)
                    {
                        if (Math.Round(float.Parse(EntryInfo_Grid.Columns["RefPayment"].SummaryItem.SummaryValue.ToString()), 2) == Math.Round(float.Parse(TextPaymentToLoad.Text), 2))
                        {
                            if (TextVoucherType.Text.Equals("JL"))
                            {
                                MMValue = "MmJLAmt";
                            }
                            else
                            {
                                if (TextVoucherType.Text.Equals("DN"))
                                {
                                    MMValue = "MmDNAmt";
                                }
                                else
                                {
                                    MMValue = "MmPymtAmt";
                                }
                            }
                            var MultorNo = string.Empty;

                            foreach (DataRow RowRecord in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
                            {
                                MultorNo += String.Format("{0},", RowRecord["BillRefNo"]);
                            }
                            using (var con = new SqlConnection(ProjectFunctions.ConnectionString))
                            {
                                con.Open();
                                var command = con.CreateCommand();
                                var transaction = con.BeginTransaction("SaveTransaction");
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.Parameters.Clear();
                                command.CommandText = "[dbo].[SP_InsVuMst_VuData4SuppPayment_t]";
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.Add("@VumDate", SqlDbType.SmallDateTime).Value = DtVoucher.DateTime.Date;
                                command.Parameters.Add("@VumNo", SqlDbType.NVarChar, 7).Value = TextVoucherNo.Text;
                                command.Parameters.Add("@VumType", SqlDbType.NVarChar, 4).Value = TextVoucherType.Text;
                                command.Parameters.Add("@VumNoRcd", SqlDbType.NVarChar, 10).Value = EntryInfo_Grid.Columns["BillRefDate"].SummaryItem.SummaryValue;
                                command.Parameters.Add("@VumAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextPaymentToLoad.EditValue);
                                command.Parameters.Add("@VumFYear", SqlDbType.NVarChar, 4).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                command.Parameters.Add("@VumUser", SqlDbType.VarChar, 8).Value = GlobalVariables.CurrentUser;
                                command.Parameters.Add("@VumAcode", SqlDbType.NVarChar, 6).Value = TextCreditAc.Text;
                                command.Parameters.Add("@VumInstType", SqlDbType.NVarChar, 6).Value = TextInstrumentType.Text;
                                command.Parameters.Add("@VumInstNo", SqlDbType.NVarChar, 15).Value = TextInstrumentNo.Text;
                                command.Parameters.Add("@VumDfDt", SqlDbType.DateTime).Value = DateTime.Now;
                                command.Parameters.Add("@VutNart", SqlDbType.NVarChar, 200).Value = TextVouchNarration.Text;
                                command.Parameters.Add("@VutNartD", SqlDbType.NVarChar, 200).Value = TextDNNarr1.Text;
                                command.Parameters.Add("@VutRefType", SqlDbType.NVarChar, 15).Value = (EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"];
                                command.Parameters.Add("@VutFrmId", SqlDbType.VarChar, 50).Value = Name;
                                command.Parameters.Add("@VumDcode", SqlDbType.NVarChar, 6).Value = TextDebitAc.Text;
                                command.Parameters.Add("@IsUpdate", SqlDbType.Char, 1).Value = isupdate ? "Y" : "N";

                                command.Parameters["@VumNo"].Direction = ParameterDirection.InputOutput;

                                try
                                {
                                    command.ExecuteNonQuery();
                                    TextVoucherNo.Text = command.Parameters["@VumNo"].Value.ToString();
                                    command.Parameters.Clear();
                                    var query = string.Empty;

                                    if (float.Parse(TextBnkChgs.Text) > 0)
                                    {
                                        if (isupdate)
                                        {
                                            query += " UPDATE  [vuData]";
                                            query += String.Format(" SET       [VutDate] = '{0}' ", DtVoucher.DateTime.Date.ToString("yyyy-MM-dd"));
                                            query += String.Format(" ,[VutNo] = '{0}' ", TextVoucherNo.Text);
                                            query += String.Format(" ,[VutType] = '{0}' ", TextVoucherType.Text);
                                            query += String.Format(" ,[VutACode] = '{0}' ", BnkChgsCode);
                                            query += String.Format(" ,[VutAmt] = '{0}' ", Convert.ToDecimal(TextBnkChgs.EditValue));
                                            query += " ,[VutCrDr] = 'D' ";
                                            query += String.Format(" ,[VutNart] = 'TO {0}' ", TextVouchNarration.Text.StartsWith("BY") ? TextVouchNarration.Text.Remove(0, 2) : TextVouchNarration.Text);
                                            query += String.Format(" ,[VutRefType] ='{0}' ", (EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"]);
                                            query += String.Format(" ,[VutUserID] = '{0}' ", GlobalVariables.CurrentUser);
                                            query += String.Format(",[VutFDt] = '{0}'", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                                            query += String.Format(" ,[VutFYear] = '{0}' ", ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear));
                                            query += String.Format(" ,[VutFrmId] = '{0}' ", Name);

                                            query += String.Format(" WHERE [VutDate] = '{1}' and [VutType]='{2}' and VutNo='{3}' and ([VutACode]='{0}'); ", BnkChgsCode, DtVoucher.DateTime.Date.ToString("yyyy-MM-dd"), TextVoucherType.Text, TextVoucherNo.Text);
                                        }
                                        else
                                        {
                                            query += "INSERT INTO [dbo].[vuData] ([VutDate],[VutNo],[VutType],[VutACode],[VutAmt],[VutCrDr],[VutNart],[VutRefType],[VutFDt],[VutFrmId],[VutUserID],[VutFYear]) ";
                                            query += String.Format("VALUES( '{0}','" + TextVoucherNo.Text + "','{1}','{2}','{3}','D','TO AMT OF {4} NO {5} FAV. of Bank Charges  AGST BillS {6}', '{7}','{8}','{9}','{10}','{11}');", DtVoucher.DateTime.ToString("yyyy-MM-dd"), TextVoucherType.Text, BnkChgsCode, TextBnkChgs.Text, TextInstrumentType.Text, TextInstrumentNo.Text, MultorNo.Remove(MultorNo.Length - 1), (EntryInfo_GridCtrl.DataSource as DataTable).Rows[0]["Method"], DateTime.Now.Date.ToString("yyyy-MM-dd"), Name, GlobalVariables.CurrentUser, ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear));
                                        }
                                    }

                                    if (query.Length > 10)
                                    {
                                        command.CommandType = CommandType.Text;
                                        command.CommandText = query;
                                        command.ExecuteNonQuery();
                                        command.Parameters.Clear();
                                    }
                                    if (isupdate)
                                    {
                                        if (DS4GridOrignal.Tables[1].Rows.Count > 0)
                                        {
                                            foreach (DataRow Dr in DS4GridOrignal.Tables[1].Rows)
                                            {
                                                command.Parameters.Clear();
                                                var DelTagNBill2PassRevQuery = "  Delete From [VuDetail] ";
                                                DelTagNBill2PassRevQuery += string.Format(" WHERE VutRefDate='{0}' and VutRef='{1}' and vutRefNo='MRI'; ", Convert.ToDateTime(Dr["MmDocDate"]).Date.ToString("yyyy-MM-dd"), Dr["MmDocNo"]);
                                                DelTagNBill2PassRevQuery += "  UPDATE  [BilltoPass]";

                                                DelTagNBill2PassRevQuery += string.Format("  SET [{2}] = (select(SELECT  {2} FROM BilltoPass WHERE (MmBillPassID = '{0}'))-'{1}')", Dr["MmBillPassID"], Dr["RefPayment"], MMValue);
                                                DelTagNBill2PassRevQuery += string.Format("   WHERE (MmBillPassID = '{0}'); ", Dr["MmBillPassID"]);
                                                command.CommandText = DelTagNBill2PassRevQuery;
                                                command.CommandType = CommandType.Text;
                                                command.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                    foreach (DataRow Dr in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
                                    {
                                        var Query = String.Format("update [BilltoPass] set  [{3}]=(isnull((SELECT [{3}] FROM [BilltoPass] where MmPartyCode='{4}' And MmBillPassID='{0}'),0)+'{1}')      where MmPartyCode='{4}' And MmBillPassID='{2}'; ", Dr["MmBillPassID"], Dr["RefPayment"], Dr["MmBillPassID"], MMValue, TextDebitAc.Text);
                                        Query += "INSERT INTO [VuDetail] ([VutDate],[VutNo],[VutType],[VutACode],[VutAmt],[VutCrDr]";
                                        Query += ",[VutNart],[VutRefNo],[VutRefType],[VutRef],[VutRefDate]";
                                        Query += ",[VutUserID],[VutFDt],[VutUpTag],[VutFYear],[VutFrmId])";
                                        Query += String.Format("VALUES ('{0}','{1}','{2}','{3}','{4}','D','", DtVoucher.DateTime.ToString("yyyy-MM-dd"), TextVoucherNo.Text, TextVoucherType.Text, TextDebitAc.Text, Dr["RefPayment"]);
                                        Query += String.Format("{0}','{5}','{2}','{3}','{4}',", TextDNNarr1.Text.Replace("'", string.Empty), TextDebitAcName.Text, Dr["Method"], Dr["MmDocNo"], Convert.ToDateTime(Dr["MmDocDate"]).ToString("yyyy-MM-dd"), Dr["BillRefNo"].ToString().Equals("BF") ? "ORI" : "MRI");
                                        Query += String.Format("'" + GlobalVariables.CurrentUser + "',GetDate(),'A','" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "','{0}');", Name);
                                        command.CommandType = CommandType.Text;
                                        command.CommandText = Query;
                                        command.ExecuteNonQuery();
                                    }
                                    if (TextVoucherType.Text == "DN" || TextVoucherType.Text == "CN")
                                    {
                                        command.Parameters.Clear();
                                        command.CommandText = string.Format("Delete From DcData Where DcVhtDt='{0:yyyy-MM-dd}' And DcVhtNo='{1}'", DtVoucher.DateTime.Date, TextVoucherNo.Text);
                                        command.CommandType = CommandType.Text;
                                        command.ExecuteNonQuery();

                                        command.Parameters.Clear();
                                        command.CommandText = "[dbo].[Dc_Ins_Upd]";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Add("@DcType", SqlDbType.NVarChar, 2).Value = TextVoucherType.Text;
                                        command.Parameters.Add("@DcNo", SqlDbType.NVarChar, 7).Value = "0000";
                                        command.Parameters.Add("@DcVumID", SqlDbType.Int).Value = 0;
                                        command.Parameters.Add("@DcVhtDt", SqlDbType.SmallDateTime).Value = DtVoucher.DateTime.Date;
                                        command.Parameters.Add("@DcVhtNo", SqlDbType.NVarChar, 7).Value = TextVoucherNo.Text;
                                        command.Parameters.Add("@DcVhtAmt", SqlDbType.Decimal).Value = TextPaymentToLoad.Text;
                                        command.Parameters.Add("@DcNar1", SqlDbType.NVarChar, 100).Value = TextDNNarr1.Text;
                                        command.Parameters.Add("@DcNar2", SqlDbType.NVarChar, 100).Value = TextDNNarr2.Text;
                                        command.Parameters.Add("@DcNar3", SqlDbType.NVarChar, 100).Value = TextDNNarr3.Text;
                                        command.Parameters.Add("@DcNar4", SqlDbType.NVarChar, 100).Value = TextDNNarr4.Text;
                                        command.Parameters.Add("@DcNar5", SqlDbType.NVarChar, 100).Value = TextDNNarr5.Text;
                                        command.Parameters.Add("@DcNar6", SqlDbType.NVarChar, 100).Value = string.Empty;
                                        command.Parameters.Add("@DcVhrStr", SqlDbType.NVarChar, 20).Value = TextVoucherNo.Text + DtVoucher.DateTime.Date;
                                        command.Parameters.Add("@DcUser", SqlDbType.VarChar, 8).Value = GlobalVariables.CurrentUser;
                                        command.Parameters.Add("@DcAccCode", SqlDbType.NVarChar, 6).Value = TextDebitAc.Text;
                                        command.Parameters.Add("@DcFyear", SqlDbType.VarChar, 2).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                        command.Parameters.Add("@IsUpdate", SqlDbType.Char, 1).Value = isupdate ? 'Y' : 'N';
                                        command.ExecuteNonQuery();
                                    }

                                    transaction.Commit();
                                    if (isupdate)
                                    {
                                        ProjectFunctions.SpeakError("Data Saved. ");
                                        Dispose();
                                    }
                                    else
                                    {
                                        savemsg.Text = "Last Saved Entry's Amt. : " + Math.Abs(Convert.ToDecimal(TextPaymentToLoad.Text));
                                        var dT = DtVoucher.DateTime.Date;
                                        ResetControls(this);
                                        TextDebitAc.Enabled = true;
                                        TextBnkChgs.Text = "0.00";
                                        TextPaymentToLoad.Text = "0.00";
                                        TextRefBalance.Text = "0.00";
                                        TextRefPayment.Text = "0.00";
                                        TextRefBalance.Text = "0.00";
                                        BtnOk.Text = "&Ok";
                                        EntryInfo_GridCtrl.DataSource = null;
                                        EntryInfo_Grid.RefreshData();
                                        Record = new DataTable();
                                        SetMyControls();
                                        FStartDate = DateTime.Today;
                                        DtVoucher.EditValue = dT.Date;
                                        DtVoucher.Focus();
                                        Save.Enabled = false;
                                    }
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
                        else
                        {
                            ProjectFunctions.SpeakError("Payment To Load Value Doesn't Match Grid Total Amount.");
                            TextPaymentToLoad.Focus();
                        }
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Grid has No Record.");
                        TextPaymentToLoad.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Something Wrong." + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (EntryInfo_Grid.DataSource != null)
                {
                    var rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "EntryId", id);
                    EntryInfo_Grid.DeleteRow(rowHandle);
                    TextRefPayment.Text = "0.00";
                    TextBill_Ref_No.Text = string.Empty;
                    DtBillRef.Text = string.Empty;
                    TextBill_Ref_Amt.Text = "0.00";
                    TextRefBalance.Text = "0.00";
                    TextMmBillPassID.Text = string.Empty;
                    TextMMDocNo.Text = string.Empty;
                    DtMMDoc.Text = string.Empty;
                    EntryInfo_Grid.UpdateSummary();
                    Record = EntryInfo_GridCtrl.DataSource as DataTable;
                    EntryInfo_GridCtrl.DataSource = Record;
                    EntryInfo_GridCtrl.RefreshDataSource();
                    TextPaymentMethod.Focus();
                    BtnOk.Text = "&Ok";
                    BtnDelete.Enabled = false;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            TextRefPayment.Text = "0.00";
            TextBill_Ref_No.Text = string.Empty;
            DtBillRef.Text = string.Empty;
            TextBill_Ref_Amt.Text = "0.00";
            TextRefBalance.Text = "0.00";
            TextMmBillPassID.Text = string.Empty;
            TextMMDocNo.Text = string.Empty;
            DtMMDoc.Text = string.Empty;
            TextPaymentMethod.Focus();
            BtnDelete.Enabled = false;
        }

        private void PartyPaymentModule_Tab_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextVoucherType_Validated(object sender, EventArgs e)
        {
            if (TextVoucherType.Text.Equals("JL"))
            {
                MMValue = "MmJLAmt";
            }
            else
            {
                if (TextVoucherType.Text.Equals("DN"))
                {
                    MMValue = "MmDNAmt";
                }
                else
                {
                    MMValue = "MmPymtAmt";
                }
            }
        }

        private void TextInstrumentNo_Validated(object sender, EventArgs e)
        {
            try
            {
                if (TextInstrumentType.Text == "CQ")
                {
                    if (ProjectFunctions.GetDataSet(String.Format("Select * from [ChqControlData] where [CCDChqNo]='{0}' and [CCDBankCode]='{1}' and [CCSplTag] is null;", TextInstrumentNo.Text.Trim(), TextCreditAc.Text)).Tables[0].Rows.Count <= 0)
                    {
                        Error.SetError(TextInstrumentNo, "Correct instrument No.");
                        TextInstrumentNo.Focus();
                    }
                    else
                    {
                        Error.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private static void ResetControls(Control C)
        {
            foreach (Control ctrl in C.Controls)
            {
                if (ctrl.GetType() == typeof(TextEdit))
                {
                    ctrl.ResetText();
                }
            }
        }

        private void TextVoucherType_TextChanged(object sender, EventArgs e)
        {
            switch (TextVoucherType.Text)
            {
                case "JL":
                    TextVouchNarration.Enabled = true;
                    break;
                default:
                    TextVouchNarration.Enabled = true;
                    TextDNNarr1.Enabled = true;
                    TextDNNarr2.Enabled = false;
                    TextDNNarr3.Enabled = false;
                    TextDNNarr4.Enabled = false;
                    TextDNNarr5.Enabled = false;
                    break;
            }
        }


        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void TextAuthenticate_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Validate_Click(object sender, EventArgs e)
        {
            if (!(TextVoucherType.Text == "BP" || TextVoucherType.Text == "CP" || TextVoucherType.Text == "JL" || TextVoucherType.Text == "DN"))
            {
                ProjectFunctions.SpeakError("Voucher Type Must be BP/JL/CP/DN.");
                TextVoucherType.Focus();
                return;
            }

            if (TextDebitAc.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Acount Code can not be blank.");
                TextDebitAc.Focus();
                return;
            }
            if (TextDebitAcName.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Acount Name can not be blank.");
                TextDebitAc.Focus();
                return;
            }
            if (TextCreditAc.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Acount Code can not be blank.");
                TextDebitAc.Focus();
                return;
            }
            if (TextCreditAcName.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Acount Name can not be blank.");
                TextCreditAc.Focus();
                return;
            }

            if (TextInstrumentType.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Instrument Type can not be blank.");
                TextInstrumentType.Focus();
                return;
            }
            else
            {
                if (!(TextInstrumentType.Text == "CH" || TextInstrumentType.Text == "DD" || TextInstrumentType.Text == "NEFT" || TextInstrumentType.Text == "OTH" || TextInstrumentType.Text == "RTGS"))
                {
                    ProjectFunctions.SpeakError("Instrument Type can be CH Cheque/ DD Demand Draft/ NEFT/ OTH other/ RTGS.");
                    TextInstrumentType.Focus();
                    return;
                }
            }

            if (Convert.ToDecimal(TextPaymentToLoad.Text) <= 0)
            {
                TextPaymentToLoad.Focus();
                ProjectFunctions.SpeakError("Payment To Load Field Can not zero or less than zero");
                return;
            }
            if (EntryInfo_Grid.RowCount == 0)
            {
                TextPaymentToLoad.Focus();
                ProjectFunctions.SpeakError("You have not paid to any one.");
                return;
            }

            //if (AuthenticateFlag)
            //{
            Save.Enabled = true;
            //}
            //else
            //{
            //    Save.Enabled = false;
            //    ProjectFunctions.SpeakError("You have entered Wrong Password.");
            //    TextAuthenticate.Visible = true;
            //    TextAuthenticate.Focus();
            //    return;
            //}
        }

        private void DtVoucher_EditValueChanged(object sender, EventArgs e)
        {
            Save.Enabled = false;
            AuthenticateFlag = false;
        }

        private void DtVoucher_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (!ProjectFunctions.CheckRange(DtVoucher.DateTime, GlobalVariables.FinYearStartDate.Date, DateTime.Today.AddDays(3650)))
            //    {
            //    DtVoucher.Focus();
            //    Error.SetError(DtVoucher, "Date does not fall in Expected Range. Either You are crossign FinancialYear Limit or Crossing Today Limit.");
            //    return;
            //    }

            if (DtVoucher.DateTime.Date == DateTime.Now.Date || AuthenticateFlag)
            {
                if (!isupdate)
                {
                    Error.Dispose();
                    var query = String.Format("select dbo.DoPadd((SELECT     isnull(max(cast(VumNo as int)),0) as 'Value' FROM VuMst WHERE     (VumType <> 'SL') and (VumType <> 'SR')and VumDate='{0}')+1) as Value;", DtVoucher.DateTime.ToString("yyyy-MM-dd"));
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextVoucherNo.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                        Error.Dispose();
                    }
                }
            }
            else
            {
                TextAuthenticate.Visible = true;
                TextAuthenticate.Focus();
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EntryInfo_GridCtrl_Click(object sender, EventArgs e)
        {

        }

        private void TextDNNarr1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}