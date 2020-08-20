using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frm_JournalNBankVoucher : XtraForm
    {

        DataTable dt = new DataTable();


        public String s1 { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CurrentControl { get; set; }
        public int LocalNoOfRecords { get; set; }
        public string VoucherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherType { get; set; }
        public string BnkChgsCode { get; set; }
        public bool isupdate { get; set; }
#pragma warning disable CS0169 // The field 'frm_JournalNBankVoucher.AccCode' is never used
        private string AccCode;
#pragma warning restore CS0169 // The field 'frm_JournalNBankVoucher.AccCode' is never used
#pragma warning disable CS0414 // The field 'frm_JournalNBankVoucher.AuthenticateFlag' is assigned but its value is never used
        private bool AuthenticateFlag = false;
#pragma warning restore CS0414 // The field 'frm_JournalNBankVoucher.AuthenticateFlag' is assigned but its value is never used
        private string BuCode = "NA#";
        private string BuHOAcode = "NA#";
        private string BuSelfACode = "NA#";
        private string DeletedId;
#pragma warning disable CS0414 // The field 'frm_JournalNBankVoucher.Flag' is assigned but its value is never used
        private bool Flag = false;
#pragma warning restore CS0414 // The field 'frm_JournalNBankVoucher.Flag' is assigned but its value is never used
        private string Paramater;
        private string path;
        private int UId;
        private string VarCostId;

        public frm_JournalNBankVoucher()
        {
            InitializeComponent();
            dt.Columns.Add("AccCode", typeof(String));
            dt.Columns.Add("AccName", typeof(String));
            dt.Columns.Add("Narration", typeof(String));
            dt.Columns.Add("Credit", typeof(Decimal));
            dt.Columns.Add("Debit", typeof(Decimal));
            dt.Columns.Add("SplInf", typeof(String));
            dt.Columns.Add("RefMethod", typeof(String));
            dt.Columns.Add("CDlrCode", typeof(String));
            dt.Columns.Add("CDlrNm", typeof(String));
            dt.Columns.Add("ExpCode", typeof(String));
            dt.Columns.Add("ExpDesc", typeof(String));
            dt.Columns.Add("CostCode", typeof(String));
            dt.Columns.Add("CostDesc", typeof(String));
            dt.Columns.Add("CostSubcode", typeof(String));
            dt.Columns.Add("CostSubDesc", typeof(String));
            dt.Columns.Add("InstType", typeof(String));
            dt.Columns.Add("InstNo", typeof(String));
            dt.Columns.Add("VutCostHeadID", typeof(Int64));
            dt.Columns.Add("vutChqClearDt", typeof(DateTime));

        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void frm_JournalNBankVoucher_Load(object sender, EventArgs e)
        {
            path = String.Format(@"C:\Application\VU_CMN_{0}.Xlsx", GlobalVariables.CurrentUser);
            DtVoucher.EditValue = (DateTime.Now.Date >= GlobalVariables.FinYearStartDate && DateTime.Now.Date <= GlobalVariables.FinYearEndDate) ? DateTime.Now : GlobalVariables.FinYearEndDate.Date;
            SetMyControls();
            if (isupdate)
            {
                Settings4Update();
                Text = "Journal and Bank Vouchers Update";
            }
            else
            {
                DefaultValueAttribute();
                Text = "Journal and Bank Vouchers Add";
                DtVoucher.EditValue = (DateTime.Now.Date >= GlobalVariables.FinYearStartDate && DateTime.Now.Date <= GlobalVariables.FinYearEndDate) ? DateTime.Now : GlobalVariables.FinYearEndDate.Date;
            }
        }

        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(panelControl2);
            ProjectFunctions.ButtonVisualize(panelControl2);
            //ProjectFunctions.TextBoxVisualize(SubPanel);
            ProjectFunctions.TextBoxVisualize(this);
            //ProjectFunctions.GirdViewVisualize(HelpGrid);
            //ProjectFunctions.GirdViewVisualize(EntryInfo_Grid);
            DtVoucher.EditValue = (DateTime.Now.Date >= GlobalVariables.FinYearStartDate && DateTime.Now.Date <= GlobalVariables.FinYearEndDate) ? DateTime.Now : GlobalVariables.FinYearEndDate.Date;
            ProjectFunctions.DatePickerVisualize(this);

            ProjectFunctions.TextBoxVisualize(CNGroupCtrl);
            ProjectFunctions.GroupCtrlVisualize(CNGroupCtrl);

            TextAmount.Properties.Mask.EditMask = "N2";
        }

        private void EntryInfo_GridCtrl_DoubleClick(object sender, EventArgs e)
        {
            Save.Enabled = false;
            BtnDelete.Enabled = true;
            BtnUndo.Enabled = true;
            BtnOk.Enabled = false;
            BtnOk.Text = "&Update";
            var Dr = EntryInfo_Grid.GetFocusedDataRow();
            TextAcCode.Text = Dr["AccCode"].ToString();
            TextAcName.Text = Dr["AccName"].ToString();
            TextNarration.Text = Dr["Narration"].ToString();
            TextAmount.EditValue = Convert.ToDecimal((Dr["SplInf"].ToString().StartsWith("C") ? Dr["Credit"].ToString() : Dr["Debit"].ToString()));
            TextSplInfo.Text = Dr["SplInf"].ToString().StartsWith("C") ? "CR" : "DR";

            TextDlrCode.Text = Dr["CDlrCode"].ToString();
            //if (Paramater == "A")
            //    TextDlrCode.Text = TextDlrCode.Text.PadLeft(6, '0');
            //else if (Paramater == "E")
            //    TextDlrCode.Text = TextDlrCode.Text.PadLeft(5, '0');
            TextDlrDesc.Text = Dr["CDlrNm"].ToString();
            TextExpHeadDesc.Text = Dr["ExpDesc"].ToString();
            TextExpHeadCode.Text = Dr["ExpCode"].ToString();
            TextCostCode.Text = Dr["CostCode"].ToString();
            TextCostDesc.Text = Dr["CostDesc"].ToString();
            TextCostSubCode.Text = Dr["CostSubcode"].ToString();
            TextCostSubCodeDesc.Text = Dr["CostSubDesc"].ToString();
            VarCostId = Dr["VutCostHeadID"].ToString();
            UId = EntryInfo_Grid.FocusedRowHandle;
            DtClear.EditValue = Dr["vutChqClearDt"].ToString() == string.Empty ? DtVoucher.DateTime.Date : Convert.ToDateTime(Dr["vutChqClearDt"]);
            TextAcCode.Focus();
        }

        private void EntryInfo_GridCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EntryInfo_GridCtrl_DoubleClick(null, null);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //if (TextAcCode.Text.Length < 4)
            //    {
            //    TextAcCode.Text = TextAcCode.Text.PadLeft(4, '0');
            //    }
            //if ((TextVoucherType.Text.ToUpper() == "BR" || TextVoucherType.Text.ToUpper() == "BP") && ProjectFunctions.User.ToUpper() != "RAGHAVG" && ProjectFunctions.User.ToUpper() != "ANILK")
            //    {
            //    var a = new int[] { 141, 1898, 3462, 1907, 2434, 7954, 84, 5844, 557, 140, 7646, 8500, 8206, 7700, 9392, 6580, 6581, 8110, 8180, 8999, 9061, 2475, 2700, 9128, 2800, 7100, 6780, 4826, 9417, 3195 };
            //    var b = new int[] { 141, 1898, 3462, 1907, 84, 5844, 557, 140, 7646, 8500, 8206, 7700, 9392, 6580, 6581, 8110, 8180, 8999, 9061, 2475, 2700, 9128, 2800, 7100, 6780, 4826, 9417, 3195 };
            //    if (ProjectFunctions.ConnectionString.ToLower().Contains("gendatabonnaligarh"))
            //        {
            //        if (b.Contains(Convert.ToInt16(TextAcCode.Text)))
            //            {
            //            ProjectFunctions.SpeakError("You Can't use this Party in case of BP or BR.\n Incase any Problem kindly contact 766.");
            //            return;
            //            }
            //        }
            //    else
            //        {
            //        if (a.Contains(Convert.ToInt16(TextAcCode.Text)))
            //            {
            //            ProjectFunctions.SpeakError("You Can't use this Party in case of BP or BR.\n Incase any Problem kindly contact 766.");
            //            return;
            //            }
            //        }
            //    }

            if (TextVoucherType.Text == "CP" && TextAcCode.Text == GlobalVariables.CashCode)
            {
                TextSplInfo.Text = "CR";
            }
            else
            {
                if (TextVoucherType.Text == "CR" && TextAcCode.Text == GlobalVariables.CashCode)
                {
                    TextSplInfo.Text = "DR";
                }
            }
            if (TextVoucherType.Text == "CP" && TextAcCode.Text != GlobalVariables.CashCode)
            {
                TextSplInfo.Text = "DR";
            }
            if (TextVoucherType.Text == "CR" && TextAcCode.Text != GlobalVariables.CashCode)
            {
                TextSplInfo.Text = "CR";
            }
            if (TextAcCode.Text == string.Empty)
            {
                Msg.Text += "Account Code can't be blank.";
                TextAcCode.Focus();
                return;
            }
            else
            {
                if (Convert.ToDecimal(TextAmount.EditValue) <= 0)
                {
                    Msg.Text += "Amount can't be zero or less than zero.";
                    TextAmount.Focus();
                    return;
                }
            }
            using (var ds = ProjectFunctions.GetDataSet(String.Format("Select [AccName],[AccCode],[AccSplInfo]  FROM [dbo].[ActMst] where  [AccCode]='{0}' ;", TextAcCode.Text)))
            {
                if (!(ds.Tables[0].Rows.Count > 0))
                {
                    TextAcCode.Focus();
                    return;
                }
            }

            //using (DataSet ds = ProjectFunctions.GetDataSet(String.Format("Select [AccName],[AccCode],AccAdvPymtTag FROM [dbo].[ActMstAddInf] where  [AccCode]='{0}' ;", TextAcCode.Text.PadLeft(4, '0'))))
            //{


            //    if (ds.Tables[0].Rows.Count > 0 && Txt_AdvTag.Text.ToUpper() == "N")
            //    {
            //        if (ds.Tables[0].Rows[0]["AccAdvPymtTag"].ToString().ToUpper() == "Y")
            //        {
            //            if (ProjectFunctions.SpeakError("Do you want to mark this payment as advance payment", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                Txt_AdvTag.Text = "Y";
            //            }
            //        }
            //    }

            //}

            if (BtnOk.Text == "&Ok")
            {

                var dr = dt.NewRow();

                dr["AccCode"] = TextAcCode.Text;
                dr["AccName"] = TextAcName.Text;
                dr["Narration"] = TextNarration.Text;
                dr["Credit"] = Math.Round(Convert.ToDecimal((TextSplInfo.Text == "CR") ? TextAmount.Text : "0"), 2, MidpointRounding.AwayFromZero);
                dr["Debit"] = Math.Round(Convert.ToDecimal((TextSplInfo.Text == "DR") ? TextAmount.Text : "0"), 2, MidpointRounding.AwayFromZero);
                ;
                dr["SplInf"] = TextSplInfo.Text;
                dr["RefMethod"] = "On Account";

                dr["CDlrCode"] = (string.IsNullOrEmpty(TextDlrCode.Text) ? "0000" : TextDlrCode.Text);

                dr["CDlrNm"] = (string.IsNullOrEmpty(TextDlrCode.Text) ? "0000" : TextDlrCode.Text); ;
                dr["ExpCode"] = (string.IsNullOrEmpty(TextExpHeadCode.Text) ? "0000" : TextExpHeadCode.Text);

                dr["ExpDesc"] = (string.IsNullOrEmpty(TextExpHeadDesc.Text) ? "0000" : TextExpHeadDesc.Text);
                dr["CostCode"] = (string.IsNullOrEmpty(TextCostCode.Text) ? "0000" : TextCostCode.Text);
                dr["CostDesc"] = (string.IsNullOrEmpty(TextCostDesc.Text) ? "0000" : TextCostDesc.Text);
                dr["CostSubcode"] = (string.IsNullOrEmpty(TextCostSubCode.Text) ? "0000" : TextCostSubCode.Text);
                dr["CostSubDesc"] = (string.IsNullOrEmpty(TextCostSubCodeDesc.Text) ? "0000" : TextCostSubCodeDesc.Text);
                dr["InstType"] = TextInstrumentType.Text;
                dr["InstNo"] = TextInstrumentNo.Text;
                dr["InstType"] = Txt_AdvTag.Text;
                dr["VutCostHeadID"] = string.IsNullOrEmpty(VarCostId) ? "0" : VarCostId;
                dr["vutChqClearDt"] = DtClear.DateTime.Date;
                dt.Rows.Add(dr);
                if (dt.Rows.Count > 0)
                {
                    EntryInfo_GridCtrl.DataSource = dt;
                    EntryInfo_Grid.BestFitColumns();
                }

                TextAcCode.Text = string.Empty;
                TextAcName.Text = string.Empty;
                TextAmount.EditValue = Math.Abs(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue));
                if (TextSplInfo.Enabled)
                {
                    TextSplInfo.Text = (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue)) < 0 ? "CR" : "DR";
                }
                TextDlrCode.Text = string.Empty;
                TextDlrDesc.Text = string.Empty;
                TextExpHeadDesc.Text = string.Empty;
                TextExpHeadCode.Text = string.Empty;
                TextCostCode.Text = string.Empty;
                TextCostDesc.Text = string.Empty;
                TextCostSubCode.Text = string.Empty;
                TextCostSubCodeDesc.Text = string.Empty;
                //if (TextSplInfo.Text.StartsWith("C"))
                //{
                //    TextNarration.Text = "BY " + TextNarration.Text.Remove(0, 2);
                //}
                //else
                //{
                //    TextNarration.Text = "TO " + TextNarration.Text.Remove(0, 2);
                //}
                TextAcCode.Focus();
                BtnOk.Enabled = false;


                EntryInfo_Grid.UpdateCurrentRow();
                EntryInfo_Grid.UpdateTotalSummary();
                EntryInfo_Grid.RefreshData();
                EntryInfo_GridCtrl.ExportToXlsx(path);
                TextAcCode.Focus();
            }
            else
            {
                var rowHandle = UId;
                EntryInfo_Grid.BeginDataUpdate();
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[0], TextAcCode.Text);
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[1], TextAcName.Text);
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[2], TextNarration.Text);
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[3], Math.Round(Convert.ToDecimal((TextSplInfo.Text == "CR") ? TextAmount.Text : "0"), 2, MidpointRounding.AwayFromZero));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[4], Math.Round(Convert.ToDecimal((TextSplInfo.Text == "DR") ? TextAmount.Text : "0"), 2, MidpointRounding.AwayFromZero));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[5], TextSplInfo.Text);
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[6], "On Account");
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[7], (string.IsNullOrEmpty(TextDlrCode.Text) ? "0000" : TextDlrCode.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[8], (string.IsNullOrEmpty(TextDlrCode.Text) ? "0000" : TextDlrDesc.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[9], (string.IsNullOrEmpty(TextExpHeadCode.Text) ? "0000" : TextExpHeadCode.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[10], (string.IsNullOrEmpty(TextExpHeadCode.Text) ? "0000" : TextExpHeadDesc.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[11], (string.IsNullOrEmpty(TextCostCode.Text) ? "0000" : TextCostCode.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[12], (string.IsNullOrEmpty(TextCostCode.Text) ? "0000" : TextCostDesc.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[13], (string.IsNullOrEmpty(TextCostSubCode.Text) ? "0000" : TextCostSubCode.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[14], (string.IsNullOrEmpty(TextCostSubCode.Text) ? "0000" : TextCostSubCodeDesc.Text));
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[15], TextInstrumentType.Text);
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[16], TextInstrumentNo.Text);
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[17], VarCostId == string.Empty ? "0" : VarCostId);
                EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns[19], DtClear.DateTime.Date);

                EntryInfo_Grid.EndDataUpdate();
                EntryInfo_Grid.UpdateSummary();
                EntryInfo_Grid.UpdateCurrentRow();
                EntryInfo_Grid.UpdateTotalSummary();
                EntryInfo_Grid.RefreshData();
                EntryInfo_GridCtrl.ExportToXlsx(path);
                TextAcCode.Text = string.Empty;
                TextAcName.Text = string.Empty;

                TextDlrCode.Text = string.Empty;
                TextDlrDesc.Text = string.Empty;
                TextExpHeadDesc.Text = string.Empty;
                TextExpHeadCode.Text = string.Empty;
                TextCostCode.Text = string.Empty;
                TextCostDesc.Text = string.Empty;
                TextCostSubCode.Text = string.Empty;
                TextCostSubCodeDesc.Text = string.Empty;

                TextAcCode.Focus();
                BtnOk.Text = "&Ok";
                BtnOk.Enabled = false;
            }

            Msg.Text = "Diff. is" + (Math.Round(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero) - Math.Round(Convert.ToDecimal(colDebit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero));
            if (TextSplInfo.Enabled)
            {
                TextSplInfo.Text = (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue)) < 0 ? "CR" : "DR";
                if (TextSplInfo.Text.StartsWith("C"))
                {
                    TextNarration.Text = "BY " + TextNarration.Text.Remove(0, 2);
                }
                else
                {
                    TextNarration.Text = "TO " + TextNarration.Text.Remove(0, 2);
                }
                TextAmount.EditValue = Math.Abs(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue));
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            EntryInfo_Grid.UpdateSummary();
            EntryInfo_Grid.UpdateCurrentRow();
            EntryInfo_Grid.UpdateTotalSummary();

            TextAcCode.Text = string.Empty;
            TextAcName.Text = string.Empty;

            TextDlrCode.Text = string.Empty;
            TextDlrDesc.Text = string.Empty;
            TextExpHeadDesc.Text = string.Empty;
            TextExpHeadCode.Text = string.Empty;
            TextCostCode.Text = string.Empty;
            TextCostDesc.Text = string.Empty;
            TextCostSubCode.Text = string.Empty;
            TextCostSubCodeDesc.Text = string.Empty;

            TextAcCode.Focus();
            BtnOk.Text = "&Ok";
            BtnOk.Enabled = false;
            BtnDelete.Enabled = false;
            BtnUndo.Enabled = false;
            UId = -1;
            Msg.Text = "Diff. is" + (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue));
            if (TextSplInfo.Enabled)
            {
                TextSplInfo.Text = (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue)) < 0 ? "CR" : "DR";
                if (TextSplInfo.Text.StartsWith("C"))
                {
                    TextNarration.Text = "BY " + TextNarration.Text.Remove(0, 2);
                }
                else
                {
                    TextNarration.Text = "TO " + TextNarration.Text.Remove(0, 2);
                }
                TextAmount.EditValue = Math.Abs(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue));
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            EntryInfo_Grid.DeleteRow(UId);
            EntryInfo_Grid.UpdateSummary();
            EntryInfo_Grid.UpdateCurrentRow();
            EntryInfo_Grid.UpdateTotalSummary();

            BtnOk.Text = "&Ok";
            BtnOk.Enabled = false;
            BtnDelete.Enabled = false;
            ;
            BtnUndo.Enabled = false;
            UId = -1;
            TextAcCode.Text = string.Empty;
            TextAcName.Text = string.Empty;

            TextDlrCode.Text = string.Empty;
            TextDlrDesc.Text = string.Empty;
            TextExpHeadDesc.Text = string.Empty;
            TextExpHeadCode.Text = string.Empty;
            TextCostCode.Text = string.Empty;
            TextCostDesc.Text = string.Empty;
            TextCostSubCode.Text = string.Empty;
            TextCostSubCodeDesc.Text = string.Empty;

            TextAcCode.Focus();
            Msg.Text = "Diff. is" + (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue));
            if (TextSplInfo.Enabled)
            {
                TextSplInfo.Text = (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue)) < 0 ? "CR" : "DR";
                if (TextSplInfo.Text.StartsWith("C"))
                {
                    TextNarration.Text = "BY " + TextNarration.Text.Remove(0, 2);
                }
                else
                {
                    TextNarration.Text = "TO " + TextNarration.Text.Remove(0, 2);
                }
                TextAmount.EditValue = Math.Abs(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue));
            }
        }

        private void BtnShowLedger_Click(object sender, EventArgs e)
        {
        }

        private void TextVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextVoucherType";
                    string Query = "SELECT  [VouCode],[VouDesc]  FROM  dbo.VoucherType  Order By VouCode;";

                    if (TextVoucherType.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                        e.Handled = true;
                    }
                    else
                    {
                        var query = String.Format("SELECT  [VouCode],[VouDesc]  FROM  [VoucherType]  where  VouCode='{0}' Order By VouCode;", TextVoucherType.Text);
                        var ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            TextVoucherType.Text = ds.Tables[0].Rows[0]["VouCode"].ToString();
                            TextVoucherDesc.Text = ds.Tables[0].Rows[0]["VouDesc"].ToString();
                            if (TextVoucherType.Text == "BP" || TextVoucherType.Text == "BR")
                            {
                                CurrentControl = string.Empty;
                                HelpGridCtrl.Visible = false;
                                ShowSubPanel(TextVoucherType.Text);
                            }
                            else
                            {
                                if (TextVoucherType.Text == "DN" || TextVoucherType.Text == "CN")
                                {
                                    CurrentControl = string.Empty;
                                    HelpGridCtrl.Visible = false;
                                    ShowGrpCtrl(TextVoucherType.Text);
                                }
                                else
                                {
                                    TextAcCode.Focus();
                                }
                            }
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
                            if (CurrentControl == "TextVoucherType")
                            {
                                HelpGridCtrl.Visible = true;
                                HelpGridCtrl.Focus();
                                HelpGridCtrl.DataSource = ds.Tables[0];
                            }
                            else
                            {
                                HelpGridCtrl.Visible = true;
                                HelpGridCtrl.Focus();
                                HelpGridCtrl.DataSource = ds.Tables[0];
                            }
                            if (CurrentControl == "TextBill_Ref_No")
                            {
                                HelpGridCtrl.Location = new System.Drawing.Point(305, 27);
                                HelpGridCtrl.Size = new System.Drawing.Size(510, 323);
                                HelpGrid.Columns["MmDocNo"].Visible = false;
                                HelpGrid.Columns["MmDocDate"].Visible = false;
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
                            HelpGridCtrl.BringToFront();
                            ProjectFunctions.GirdViewVisualize(HelpGrid);
                            HelpGrid.Columns[0].BestFit();
                            HelpGridCtrl.Focus();
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
                        switch (TextVoucherType.Text)
                        {
                            case "CP":
                                TextSplInfo.Text = "DR";
                                TextSplInfo.Enabled = false;
                                break;
                            case "CR":
                                TextSplInfo.Text = "CR";
                                TextSplInfo.Enabled = false;
                                break;
                            case "BP":
                                TextSplInfo.Text = "DR";
                                TextSplInfo.Enabled = false;
                                break;
                            case "BR":
                                TextSplInfo.Text = "CR";
                                TextSplInfo.Enabled = false;
                                break;
                            default:
                                (EntryInfo_GridCtrl.DataSource as DataTable).Clear();
                                EntryInfo_GridCtrl.RefreshDataSource();
                                TextSplInfo.Enabled = true;
                                TextSplInfo.Text = "CR";
                                break;
                        }
                        if (TextVoucherType.Text == "BP" || TextVoucherType.Text == "BR")
                        {
                            CurrentControl = string.Empty;
                            HelpGridCtrl.Visible = false;
                            ShowSubPanel(TextVoucherType.Text);
                        }
                        else
                        {
                            if (TextVoucherType.Text == "DN" || TextVoucherType.Text == "CN")
                            {
                                CurrentControl = string.Empty;
                                HelpGridCtrl.Visible = false;
                                ShowGrpCtrl(TextVoucherType.Text);
                            }
                            else
                            {
                                TextAcCode.Focus();
                            }
                        }
                        break;

                    case "TextBankCode":
                        TextBankCode.Text = row["AccCode"].ToString();
                        TextBankDesc.Text = row["AccName"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextInstrumentType.Focus();
                        break;

                    case "TextAcCode":
                        TextAcCode.Text = row["AccCode"].ToString();

                        TextAcName.Text = row["AccName"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        ShowSubPanel(row["AccSplInfo"].ToString());
                        //getBal();
                        break;

                    case "TextCostCode":
                        TextCostCode.Text = row["CostCode"].ToString();
                        TextCostDesc.Text = row["CostDesc"].ToString();
                        TextCostSubCodeDesc.Text = row["CostSubDesc"].ToString();
                        TextCostSubCode.Text = row["CostSubCode"].ToString();
                        VarCostId = row["ID"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextExpHeadCode.Focus();
                        break;

                    case "TextExpHeadCode":
                        TextExpHeadCode.Text = row["ExpHeadCode"].ToString();
                        TextExpHeadDesc.Text = row["ExpHeadDesc"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        SubPanel.Hide();
                        //getBal();
                        TextAmount.Focus();
                        break;
                    //case "TextDlrCode":

                    //    TextDlrCode.Text = row["Code"].ToString();
                    //    TextDlrDesc.Text = row["Name"].ToString();
                    //    if (TextAcCode.Text == "17170")
                    //    {
                    //        DataSet Dsx = ProjectFunctions.GetDataSet("Select AccCode,AccName From DealerMaster inner join ActMSt on AccCode=DealerAcCode Where DealerCode='" + TextDlrCode.Text + "'");
                    //        if (Dsx.Tables[0].Rows.Count > 0)
                    //        {
                    //            TextAcCode.Text = Dsx.Tables[0].Rows[0][0].ToString();
                    //            TextAcName.Text = Dsx.Tables[0].Rows[0][1].ToString();
                    //        }
                    //    }
                    //    CurrentControl = "";
                    //    HelpGridCtrl.Visible = false;
                    //    SubPanel.Hide();
                    //    getBal();
                    //    TextAmount.Focus();
                    //    break;
                    case "TextInstrumentType":
                        TextInstrumentType.Text = row["Type"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextInstrumentNo.Focus();
                        break;
                    default:
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        CurrentControl = string.Empty;
                        break;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Either No Record or Unable to Fetch Data. " + ex.Message);
                HelpGridCtrl.Visible = false;
                RestoreFocus();
            }
        }

        private void HelpGridCtrl_KeyDown(object sender, KeyEventArgs e)
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

        private void RestoreFocus()
        {
            switch (CurrentControl)
            {
                case "TextVoucherType":
                    TextVoucherType.Focus();
                    break;
                case "TextAcCode":
                    TextAcCode.Focus();
                    break;
                case "TextCostCode":
                    TextCostCode.Focus();
                    break;
                //case "TextDlrCode":
                //    TextDlrCode.Focus();
                //    break;
                case "TextExpHeadCode":
                    TextExpHeadCode.Focus();
                    break;
                default:
                    break;
            }
            CurrentControl = string.Empty;
        }

        //private void getBal()
        //    {
        //    using (var Dt = ProjectFunctions.GetDataTable(string.Format("SELECT    OPBal{0}.OpBal + ISNULL(SUM(vuData.VutAmt), 0) AS CurBal " +
        //                            "FROM vuData INNER JOIN OPBal{0} ON vuData.VutACode = OPBal{0}.AccCode " +
        //                            "Where (vuData.VutACode = '{1}') And (vuData.VutFYear = '{2}') GROUP BY OPBal{0}.OpBal, vuData.VutFYear", ((ProjectFunctions.GlobalVariables.FinYearStartDate < new DateTime(2014, 04, 01).Date) ? ProjectFunctions.ClipFYear(FinancialYear) : ProjectFunctions.ClipFYearN(FinancialYear)), TextAcCode.Text, ProjectFunctions.ClipFYear(FinancialYear))))
        //        {
        //        if (Dt != null && Dt.Rows.Count > 0)
        //            {
        //            TextAcBal.EditValue = Convert.ToDecimal(Dt.Rows[0][0]);
        //            }
        //        }
        //    }

        private void TextAcCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextAcCode";
                    var Query = string.Format("Select [AccName],[AccCode],[AccSplInfo]  FROM [dbo].[{0}ActMst]  order by AccName  ;", (Cost_CmBx.Text == "NA#") ? string.Empty : Cost_CmBx.Text);
                    if (TextAcCode.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                    }
                    else
                    {
                        var query = String.Format("Select [AccName],[AccCode],[AccSplInfo]  FROM [dbo].[{2}ActMst] where  [AccCode]={0} {1};", TextAcCode.Text, (TextVoucherType.Text == "CP" || TextVoucherType.Text == "CR") ? "And AccCode<>'" + GlobalVariables.CashCode + "'" : string.Empty, (Cost_CmBx.Text == "NA#") ? string.Empty : Cost_CmBx.Text);
                        var ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextAcCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                            if (TextAcCode.Text.Length < 4)
                            {
                                TextAcCode.Text = TextAcCode.Text;
                            }
                            TextAcName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                            ShowSubPanel(ds.Tables[0].Rows[0]["AccSplInfo"].ToString());
                            //getBal();
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void TextCostCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextCostCode";
                    const string Query = "SELECT CostCode, CostDesc,  CostSubDesc ,CostSubCode,ID from CostMst  WHERE (((CostMst.CostSubcode)<>'' And (CostMst.CostSubcode) Is Not Null)) ORDER BY CostDesc  ;";
                    ShowHelpWindow(Query);
                    e.Handled = true;
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

        private void TextDlrCode_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //    {
            //    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
            //        {
            //        CurrentControl = "TextDlrCode";
            //        string Query="";
            //        if (Paramater == "R")
            //        { Query = "Select RtrCode Code, RtrName As Name, RtrTelNo As Info From RetailerMst ORDER BY 2;"; }
            //        else if(Paramater=="A")
            //        { Query = "Select AssetCode Code, AssetDesc As Name, AssetRegNo As Info From AssetMst ORDER BY 2;"; }
            //        else if ((Paramater == "D" || Paramater == "G" || Paramater=="P")&& !CheckCB.Checked)
            //            Query= "SELECT      dealerCode As Code, dealerName As Name, dealerStation As DlrStn From dealerMaster ORDER BY DealerName;";
            //        else if ((Paramater == "D" || Paramater == "G" || Paramater == "P")&& CheckCB.Checked && Cost_CmBx.Text=="NA#")
            //            Query = string.Format("SELECT      dealerCode As Code, dealerName As Name, dealerStation As DlrStn From dealerMaster Where DealerCode In (Select VutAACode From VuData WHere (VutDate Between '{0:yyyy-MM-dd}' And '{1:yyyy-MM-dd}') And VutACode='{2}' And IsNull(VutSplTagOV,'N')='B') ORDER BY DealerName;", DtVoucher.DateTime.Date.AddDays(-30), DtVoucher.DateTime.Date, TextAcCode.Text);
            //        else if ((Paramater == "D" || Paramater == "G" || Paramater == "P") && CheckCB.Checked && Cost_CmBx.Text != "NA#")
            //            Query = string.Format("SELECT      dealerCode As Code, dealerName As Name, dealerStation As DlrStn From dealerMaster Where DealerCode In (Select VutAACode From VuDataPost WHere (VutDate Between '{0:yyyy-MM-dd}' And '{1:yyyy-MM-dd}') And VutACode='{2}' And VutCostHead='{3}') ORDER BY DealerName;", DtVoucher.DateTime.Date.AddDays(-30), DtVoucher.DateTime.Date, TextAcCode.Text,Cost_CmBx.Text);

            //        else
            //            if(ProjectFunctions.AllEmp)
            //                Query = "SELECT      EmpCode As Code, EmpName As Name, EmpFHName As [Father_Husband] From EmpMst  ORDER BY EmpName";
            //            else
            //                Query = "SELECT      EmpCode As Code, EmpName As Name, EmpFHName As [Father_Husband] From EmpMst where isnull(empLeft,'N')='N' ORDER BY EmpName";
            //        if (TextDlrCode.Text.Trim().Length == 0)
            //            {
            //            ShowHelpWindow(Query);
            //            }
            //        else
            //            {
            //            string query="";
            //            if (Paramater == "R")
            //            { query = String.Format("Select RtrCode Code, RtrName As Name, RtrTelNo As Info From RetailerMst where RtrCode='{0}';", TextDlrCode.Text.PadLeft(6, '0')); }
            //            else if (Paramater == "A")
            //            { query = String.Format("Select AssetCode Code, AssetDesc As Name, AssetRegNo As Info From AssetMst where AssetCode='{0}';", TextDlrCode.Text.PadLeft(6, '0')); }
            //            else if ((Paramater == "D" || Paramater == "G" || Paramater == "P") && !CheckCB.Checked)
            //                query = String.Format("SELECT     dealerCode As Code, dealerName As Name, dealerStation As DlrStn From dealerMaster  where  [dealerCode]='{0}' ;", TextDlrCode.Text.PadLeft(4, '0'));
            //            else if ((Paramater == "D" || Paramater == "G" || Paramater == "P") && CheckCB.Checked && Cost_CmBx.Text == "NA#")
            //                query = string.Format("SELECT      dealerCode As Code, dealerName As Name, dealerStation As DlrStn From dealerMaster  where  [dealerCode]='{3}' And DealerCode In (Select VutAACode From VuData WHere (VutDate Between '{0:yyyy-MM-dd}' And '{1:yyyy-MM-dd}') And VutACode='{2}' And IsNull(VutSplTagOV,'N')='B') ORDER BY DealerName;", DtVoucher.DateTime.Date.AddDays(-30), DtVoucher.DateTime.Date, TextAcCode.Text, TextDlrCode.Text.PadLeft(4, '0'));
            //            else if ((Paramater == "D" || Paramater == "G" || Paramater == "P") && CheckCB.Checked && Cost_CmBx.Text != "NA#")
            //                query = string.Format("SELECT      dealerCode As Code, dealerName As Name, dealerStation As DlrStn From dealerMaster Where [dealerCode]='{4}' And DealerCode In (Select VutAACode From VuDataPost WHere (VutDate Between '{0:yyyy-MM-dd}' And '{1:yyyy-MM-dd}') And VutACode='{2}' And VutCostHead='{3}') ORDER BY DealerName;", DtVoucher.DateTime.Date.AddDays(-30), DtVoucher.DateTime.Date, TextAcCode.Text, Cost_CmBx.Text, TextDlrCode.Text.PadLeft(4, '0'));

            //            else
            //                if (ProjectFunctions.AllEmp)
            //                    query = String.Format("SELECT     EmpCode As Code, EmpName As Name From EmpMst where [Empcode]='{0}' ;", TextDlrCode.Text.PadLeft(5, '0'));
            //                else
            //                    query = String.Format("SELECT     EmpCode As Code, EmpName As Name From EmpMst where isnull(empLeft,'N')='N' And  [Empcode]='{0}' ;", TextDlrCode.Text.PadLeft(5, '0'));

            //            var ds = ProjectFunctions.GetDataSet(query);
            //            if (ds.Tables[0].Rows.Count > 0)
            //                {
            //                    TextDlrCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
            //                    TextDlrDesc.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //                    if (TextAcCode.Text == "17170")
            //                    {
            //                        DataSet Dsx = ProjectFunctions.GetDataSet("Select AccCode,AccName From DealerMaster inner join ActMSt on AccCode=DealerAcCode Where DealerCode='" + TextDlrCode.Text + "'");
            //                        if (Dsx.Tables[0].Rows.Count > 0)
            //                        {
            //                            TextAcCode.Text = Dsx.Tables[0].Rows[0][0].ToString();
            //                            TextAcName.Text = Dsx.Tables[0].Rows[0][1].ToString();
            //                        }
            //                    }

            //                SubPanel.Hide();
            //                getBal();
            //                TextAmount.Focus();
            //                }
            //            else
            //                {
            //                ShowHelpWindow(Query);
            //                }
            //            }
            //        e.Handled = true;
            //        }
            //    if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            //        {
            //        e.SuppressKeyPress = true;
            //        SelectNextControl(ActiveControl, false, true, true, true);
            //        }
            //    }
            //catch (Exception ex)
            //    {
            //    }
        }

        private void TextExpHeadCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    CurrentControl = "TextExpHeadCode";
                    const string Query = "SELECT ExpHeadDesc,ExpHeadCode from ExpHeadMst;";
                    if (TextExpHeadCode.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                    }
                    else
                    {
                        var query = String.Format("SELECT ExpHeadDesc,ExpHeadCode from ExpHeadMst  where  [ExpHeadCode]={0} ;", TextExpHeadCode.Text.Trim());
                        using (var ds = ProjectFunctions.GetDataSet(query))
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                TextExpHeadCode.Text = ds.Tables[0].Rows[0]["ExpHeadCode"].ToString();
                                TextExpHeadDesc.Text = ds.Tables[0].Rows[0]["ExpHeadDesc"].ToString();
                                SubPanel.Hide();
                                //getBal();
                                TextAmount.Focus();
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
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void ShowSubPanel(string param1)
        {
            TextDlrCode.Visible = false;
            TextDlrDesc.Visible = false;
            DlrLbl.Visible = false;
            banklbl.Visible = false;
            TextBankCode.Visible = false;
            TextBankDesc.Visible = false;
            TextCostCode.Visible = false;
            TextCostDesc.Visible = false;
            TextCostSubCode.Visible = false;
            TextCostSubCodeDesc.Visible = false;
            ExpLbl.Visible = false;
            TextExpHeadCode.Visible = false;
            TextExpHeadDesc.Visible = false;
            switch (param1)
            {
                case "C":
                    SubPanel.Show();
                    TextDlrCode.Visible = false;
                    TextDlrDesc.Visible = false;
                    DlrLbl.Visible = false;
                    TextCostCode.Visible = true;
                    TextCostDesc.Visible = true;
                    TextCostSubCode.Visible = true;
                    TextCostSubCodeDesc.Visible = true;
                    ExpLbl.Visible = true;
                    TextExpHeadCode.Visible = true;
                    TextExpHeadDesc.Visible = true;
                    GrpLbl.Visible = true;
                    SubGrpLbl.Visible = true;
                    labelControl6.Visible = false;
                    labelControl7.Visible = false;
                    labelControl4.Visible = false;
                    TextInstrumentType.Visible = false;
                    TextInstrumentNo.Visible = false;
                    DtClear.Visible = false;
                    TextCostCode.Focus();
                    break;
                case "G":
                case "P":
                    if (TextVoucherType.Text == "BP" || TextVoucherType.Text == "BR")
                    {
                        Flag = true;
                        Paramater = param1;
                        SubPanel.BringToFront();
                        SubPanel.Show();
                        TextDlrCode.Visible = true;
                        TextDlrDesc.Visible = true;
                        DlrLbl.Visible = true;
                        if (Paramater == "A")
                            DlrLbl.Text = "Asset Code";
                        if (Paramater == "E")
                            DlrLbl.Text = "Emp Code";
                        TextDlrCode.Focus();
                        TextCostCode.Visible = false;
                        TextCostDesc.Visible = false;
                        TextCostSubCode.Visible = false;
                        TextCostSubCodeDesc.Visible = false;
                        ExpLbl.Visible = false;
                        TextExpHeadCode.Visible = false;
                        TextExpHeadDesc.Visible = false;
                        labelControl6.Visible = false;
                        labelControl7.Visible = false;
                        labelControl4.Visible = false;
                        TextInstrumentType.Visible = false;
                        TextInstrumentNo.Visible = false;
                        DtClear.Visible = false;
                    }
                    else
                    {
                        TextDlrCode.Text = string.Empty;
                        TextDlrDesc.Text = string.Empty;
                        TextCostCode.Text = string.Empty;
                        TextCostDesc.Text = string.Empty;
                        TextCostSubCode.Text = string.Empty;
                        TextCostSubCodeDesc.Text = string.Empty;
                        TextExpHeadCode.Text = string.Empty;
                        TextExpHeadDesc.Text = string.Empty;
                        labelControl6.Visible = false;
                        labelControl7.Visible = false;
                        labelControl4.Visible = false;
                        TextInstrumentType.Visible = false;
                        TextInstrumentNo.Visible = false;
                        DtClear.Visible = false;
                        SubPanel.Hide();
                        //getBal();
                        TextAmount.Focus();

                    }
                    break;
                case "A":
                case "E":
                case "D":
                case "R":
                    Flag = true;
                    Paramater = param1;
                    SubPanel.BringToFront();
                    SubPanel.Show();
                    TextDlrCode.Visible = true;
                    TextDlrDesc.Visible = true;
                    DlrLbl.Visible = true;
                    if (Paramater == "R")
                        DlrLbl.Text = "Retailer";
                    if (Paramater == "A")
                        DlrLbl.Text = "Asset Code";
                    if (Paramater == "E")
                        DlrLbl.Text = "Emp Code";
                    TextDlrCode.Focus();
                    TextCostCode.Visible = false;
                    TextCostDesc.Visible = false;
                    TextCostSubCode.Visible = false;
                    TextCostSubCodeDesc.Visible = false;
                    ExpLbl.Visible = false;
                    TextExpHeadCode.Visible = false;
                    TextExpHeadDesc.Visible = false;
                    labelControl6.Visible = false;
                    labelControl7.Visible = false;
                    labelControl4.Visible = false;
                    TextInstrumentType.Visible = false;
                    TextInstrumentNo.Visible = false;
                    DtClear.Visible = false;
                    break;
                case "BR":
                    SubPanel.Show();
                    TextDlrCode.Visible = false;
                    TextDlrDesc.Visible = false;
                    DlrLbl.Visible = false;
                    banklbl.Visible = true;
                    TextBankCode.Visible = true;
                    TextBankDesc.Visible = true;
                    TextBankCode.Focus();
                    TextCostCode.Visible = false;
                    TextCostDesc.Visible = false;
                    TextCostSubCode.Visible = false;
                    TextCostSubCodeDesc.Visible = false;

                    labelControl6.Visible = true;
                    labelControl7.Visible = true;
                    labelControl4.Visible = true;
                    TextInstrumentType.Visible = true;
                    TextInstrumentNo.Visible = true;
                    DtClear.Visible = true;

                    ExpLbl.Visible = false;
                    TextExpHeadCode.Visible = false;
                    TextExpHeadDesc.Visible = false;
                    break;
                case "BP":
                    SubPanel.Show();
                    TextDlrCode.Visible = false;
                    TextDlrDesc.Visible = false;
                    DlrLbl.Visible = false;
                    banklbl.Visible = true;
                    TextBankCode.Visible = true;
                    TextBankDesc.Visible = true;
                    TextBankCode.Focus();
                    TextCostCode.Visible = false;
                    TextCostDesc.Visible = false;
                    TextCostSubCode.Visible = false;
                    TextCostSubCodeDesc.Visible = false;
                    ExpLbl.Visible = false;
                    TextExpHeadCode.Visible = false;
                    TextExpHeadDesc.Visible = false;
                    labelControl6.Visible = true;
                    labelControl7.Visible = true;
                    labelControl4.Visible = true;
                    TextInstrumentType.Visible = true;
                    TextInstrumentNo.Visible = true;
                    DtClear.Visible = true;
                    break;
                default:
                    TextDlrCode.Text = string.Empty;
                    TextDlrDesc.Text = string.Empty;
                    TextCostCode.Text = string.Empty;
                    TextCostDesc.Text = string.Empty;
                    TextCostSubCode.Text = string.Empty;
                    TextCostSubCodeDesc.Text = string.Empty;
                    TextExpHeadCode.Text = string.Empty;
                    TextExpHeadDesc.Text = string.Empty;
                    labelControl6.Visible = false;
                    labelControl7.Visible = false;
                    labelControl4.Visible = false;
                    TextInstrumentType.Visible = false;
                    TextInstrumentNo.Visible = false;
                    DtClear.Visible = false;
                    SubPanel.Hide();
                    //getBal();
                    TextAmount.Focus();
                    break;
            }
        }

        private void ShowGrpCtrl(string text)
        {
            CNGroupCtrl.Visible = true;
            CNGroupCtrl.Text = (text == "CN") ? "Credit Note Detail" : "Debit Note Detail";
            lblDn.Text = (text == "CN") ? "Credit Note No." : "Debit Note No.";
            using (var Ds = ProjectFunctions.GetDataTable(string.Format("select right('0000000'+Cast(isNull(max(DcNo),0)+1 As Varchar),7) as fldDCno from DCdata where DcType='{0}' and DcFyear='{1}'", text, ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear))))
            {
                if (Ds != null)
                {
                    if (Ds.Rows.Count > 0)
                    {
                        TextDNNo.Text = Ds.Rows[0][0].ToString();
                    }
                }
            }
            TextAmt.Focus();
        }

        private void TextInstrumentType_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextInstrumentType.Text.StartsWith("C", StringComparison.CurrentCultureIgnoreCase))
            {
                TextInstrumentType.Text = "CH";
            }
            else
            {
                if (TextInstrumentType.Text.StartsWith("D", StringComparison.CurrentCultureIgnoreCase))
                {
                    TextInstrumentType.Text = "DD";
                }
                else
                {
                    if (TextInstrumentType.Text.StartsWith("N", StringComparison.CurrentCultureIgnoreCase))
                    {
                        TextInstrumentType.Text = "NEFT";
                    }
                    else
                    {
                        if (TextInstrumentType.Text.StartsWith("R", StringComparison.CurrentCultureIgnoreCase))
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
                    TextBankCode.Focus();
                }
                e.Handled = true;
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void TextSplInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
            {
                switch (TextSplInfo.Text.ToUpper())
                {
                    case "D":
                        TextSplInfo.Text = "DR";
                        TextNarration.Focus();
                        break;
                    case "DR":
                        TextSplInfo.Text = "DR";
                        TextNarration.Focus();
                        break;
                    case "C":
                        TextSplInfo.Text = "CR";
                        TextNarration.Focus();
                        break;
                    case "CR":
                        TextSplInfo.Text = "CR";
                        TextNarration.Focus();
                        break;
                    default:
                        TextSplInfo.Focus();
                        break;
                }

                e.Handled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                TextAmount.Focus();
            }
            e.Handled = true;
        }

        private void TextNarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
            {
                BtnOk.Enabled = true;
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                if (TextSplInfo.Enabled)
                {
                    TextSplInfo.Focus();
                }
                else
                {
                    TextAmount.Focus();
                }
            }
        }

        private void DtVoucher_Validated(object sender, EventArgs e)
        {
        }

        private void DtVoucher_Enter(object sender, EventArgs e)
        {
            DtVoucher.SelectAll();
        }

        private void Settings4Update()
        {
            TextVoucherNo.Text = VoucherNo;
            TextVoucherType.Text = VoucherType;
            DtVoucher.EditValue = VoucherDate.Date;
            TextVoucherNo.Enabled = false;


            using (var Ds1 = ProjectFunctions.GetDataSet(string.Format("Select VumBcode,VuMst.VumInstType, VuMst.VumInstNo,AccName From VuMst inner join ActMst On AccCode=VumBcode Where  (VuMst.VumDate = '{0:yyyy-MM-dd}') AND (VuMst.VumType = '{1}') AND (VuMst.VumNo = '{2}'); SELECT  [VouCode],[VouDesc]  FROM  [VoucherType]  where voucode  in ('CP','CR','JL','BR','BP','CN','DN') And  VouCode='{1}' Order By VouCode;Select ISNULL(VuMst.VumAdvAmtTag,'N') AS VumAdvAmtTag From VuMst  Where  (VuMst.VumDate = '{0:yyyy-MM-dd}') AND (VuMst.VumType = '{1}') AND (VuMst.VumNo = '{2}')", VoucherDate.Date, VoucherType, VoucherNo)))
            {
                if (Ds1.Tables[0].Rows.Count > 0)
                {
                    TextBankCode.Text = Ds1.Tables[0].Rows[0][0] != DBNull.Value ? (string)Ds1.Tables[0].Rows[0][0] : string.Empty;
                    TextInstrumentNo.Text = Ds1.Tables[0].Rows[0][2] != DBNull.Value ? (string)Ds1.Tables[0].Rows[0][2] : string.Empty;
                    TextInstrumentType.Text = Ds1.Tables[0].Rows[0][1] != DBNull.Value ? (string)Ds1.Tables[0].Rows[0][1] : string.Empty;
                    TextBankDesc.Text = Ds1.Tables[0].Rows[0][3] != DBNull.Value ? (string)Ds1.Tables[0].Rows[0][3] : string.Empty;
                }
                if (Ds1.Tables[1].Rows.Count > 0)
                {
                    TextVoucherType.Text = Ds1.Tables[1].Rows[0]["VouCode"].ToString();
                    TextVoucherDesc.Text = Ds1.Tables[1].Rows[0]["VouDesc"].ToString();
                }
                if (Ds1.Tables[2].Rows.Count > 0)
                {
                    Txt_AdvTag.Text = Ds1.Tables[2].Rows[0]["VumAdvAmtTag"].ToString();

                }

            }

            try
            {
                var Query = String.Format("SELECT     AccCode, AccName, Narration, Credit, Debit, SplInf, RefMethod, CDlrCode, CDlrNm, ExpCode, ExpDesc, CostCode, " +
                    "CostDesc, CostSubcode, CostSubDesc, InstType, InstNo,VutCostHeadID, VutID,vutChqClearDt,VutCostHead FROM V_VuData4CMN WHERE     " +
                    "(VutDate = '{0:yyyy-MM-dd}') AND (VutType = '{1}') AND (VutNo = '{2}')", VoucherDate.Date, VoucherType, VoucherNo);
                using (var Ds = ProjectFunctions.GetDataSet(Query))
                {
                    if (Ds != null)
                    {
                        Cost_CmBx.EditValue = (Ds.Tables[0].Rows[0]["VutCostHead"].ToString() == string.Empty || Ds.Tables[0].Rows[0]["VutCostHead"].ToString() == "LDHHO") ? "NA#" : Ds.Tables[0].Rows[0]["VutCostHead"].ToString();
                        if (TextVoucherType.Text == "BP" || TextVoucherType.Text == "BR")
                        {
                            var Delrw = Ds.Tables[0].Select("AccCode='" + TextBankCode.Text + "'")[0];
                            DeletedId = Delrw["VutID"].ToString();
                            Ds.Tables[0].Rows.Remove(Delrw);

                        }
                        if (TextVoucherType.Text == "CP" || TextVoucherType.Text == "CR")
                        {
                            var Delrw = Ds.Tables[0].Select("AccCode=" + GlobalVariables.CashCode)[0];
                            DeletedId = Delrw["VutID"].ToString();
                            Ds.Tables[0].Rows.Remove(Delrw);

                        }
                        dt = Ds.Tables[0];
                        EntryInfo_GridCtrl.DataSource = dt;
                    }
                    EntryInfo_Grid.ClearSorting();
                }

                if (TextVoucherType.Text == "DN" || TextVoucherType.Text == "CN")
                {
                    Query = string.Format(" Select * from V_DCData Where (DcVhtDt = '{0:yyyy-MM-dd}') AND (DcType = '{1}') AND (DcVhtNo = '{2}')", VoucherDate.Date, VoucherType, VoucherNo);
                    using (var Ds = ProjectFunctions.GetDataSet(Query))
                    {
                        if (Ds != null)
                        {
                            CNGroupCtrl.Visible = true;
                            CNGroupCtrl.Text = (TextVoucherType.Text == "CN") ? "Credit Note Detail" : "Debit Note Detail";
                            lblDn.Text = (TextVoucherType.Text == "CN") ? "Credit Note No." : "Debit Note No.";
                            TextDNNo.Text = Ds.Tables[0].Rows[0]["DcNo"].ToString();
                            TextNar1.Text = Ds.Tables[0].Rows[0]["DcNar1"].ToString();
                            TextNar2.Text = Ds.Tables[0].Rows[0]["DcNar2"].ToString();
                            TextNar3.Text = Ds.Tables[0].Rows[0]["DcNar3"].ToString();
                            TextNar4.Text = Ds.Tables[0].Rows[0]["DcNar4"].ToString();
                            TextNar5.Text = Ds.Tables[0].Rows[0]["DcNar5"].ToString();
                            TextNar6.Text = Ds.Tables[0].Rows[0]["DcNar6"].ToString();
                            TextAmt.Text = Ds.Tables[0].Rows[0]["DcVhtAmt"].ToString();
                        }
                    }
                }
                DtVoucher.Enabled = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Enable to Load Data.\n" + ex.Message);
            }
        }

        private void DefaultValueAttribute()
        {
            try
            {
                using (var Ds = ProjectFunctions.GetDataSet(String.Format("SELECT     AccCode, AccName, Narration, Credit, Debit, SplInf, RefMethod, CDlrCode, CDlrNm, ExpCode, ExpDesc, CostCode, " +
                    "CostDesc, CostSubcode, CostSubDesc, InstType, InstNo,VutCostHeadID, VutID,vutChqClearDt FROM V_VuData4CMN WHERE     " +
                    "(VutDate = '{0:yyyy-MM-dd}') AND (VutType = '{1}') AND (VutNo = '{2}')", VoucherDate.Date, VoucherType, VoucherNo)))
                {
                    if (Ds != null)
                    {
                        EntryInfo_GridCtrl.DataSource = Ds.Tables[0];
                    }
                    EntryInfo_Grid.ClearSorting();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Enable to Load Data.\n" + ex.Message);
            }
        }

        private void EntryInfo_Grid_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (TextAcCode.Text == string.Empty || Convert.ToDecimal(TextAmount.Text) == 0)
            {
                TextAcCode.Focus();
            }
            else
            {
                var View = sender as ColumnView;
                View.SetRowCellValue(e.RowHandle, View.Columns[0], TextAcCode.Text);
                View.SetRowCellValue(e.RowHandle, View.Columns[1], TextAcName.Text);
                View.SetRowCellValue(e.RowHandle, View.Columns[2], TextNarration.Text);
                View.SetRowCellValue(e.RowHandle, View.Columns[3], Math.Round(Convert.ToDecimal((TextSplInfo.Text == "CR") ? TextAmount.Text : "0"), 2, MidpointRounding.AwayFromZero));
                View.SetRowCellValue(e.RowHandle, View.Columns[4], Math.Round(Convert.ToDecimal((TextSplInfo.Text == "DR") ? TextAmount.Text : "0"), 2, MidpointRounding.AwayFromZero));
                View.SetRowCellValue(e.RowHandle, View.Columns[5], TextSplInfo.Text);
                View.SetRowCellValue(e.RowHandle, View.Columns[6], "On Account");
                View.SetRowCellValue(e.RowHandle, View.Columns[7], (string.IsNullOrEmpty(TextDlrCode.Text) ? "0000" : TextDlrCode.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[8], (string.IsNullOrEmpty(TextDlrCode.Text) ? "0000" : TextDlrDesc.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[9], (string.IsNullOrEmpty(TextExpHeadCode.Text) ? "0000" : TextExpHeadCode.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[10], (string.IsNullOrEmpty(TextExpHeadCode.Text) ? "0000" : TextExpHeadDesc.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[11], (string.IsNullOrEmpty(TextCostCode.Text) ? "0000" : TextCostCode.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[12], (string.IsNullOrEmpty(TextCostCode.Text) ? "0000" : TextCostDesc.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[13], (string.IsNullOrEmpty(TextCostSubCode.Text) ? "0000" : TextCostSubCode.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[14], (string.IsNullOrEmpty(TextCostSubCode.Text) ? "0000" : TextCostSubCodeDesc.Text));
                View.SetRowCellValue(e.RowHandle, View.Columns[15], TextInstrumentType.Text);
                View.SetRowCellValue(e.RowHandle, View.Columns[16], TextInstrumentNo.Text);
                View.SetRowCellValue(e.RowHandle, View.Columns[17], VarCostId == string.Empty ? "0" : VarCostId);
                View.SetRowCellValue(e.RowHandle, View.Columns[19], DtClear.DateTime.Date);
                View.SetRowCellValue(e.RowHandle, View.Columns[18], Convert.ToInt32("0"));

                View.EndInit();
                TextAcCode.Text = string.Empty;
                TextAcName.Text = string.Empty;
                TextAmount.EditValue = Math.Abs(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue));
                if (TextSplInfo.Enabled)
                {
                    TextSplInfo.Text = (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue)) < 0 ? "CR" : "DR";
                }
                TextDlrCode.Text = string.Empty;
                TextDlrDesc.Text = string.Empty;
                TextExpHeadDesc.Text = string.Empty;
                TextExpHeadCode.Text = string.Empty;
                TextCostCode.Text = string.Empty;
                TextCostDesc.Text = string.Empty;
                TextCostSubCode.Text = string.Empty;
                TextCostSubCodeDesc.Text = string.Empty;
                if (TextSplInfo.Text.StartsWith("C"))
                {
                    TextNarration.Text = "BY " + TextNarration.Text.Remove(0, 2);
                }
                else
                {
                    TextNarration.Text = "TO " + TextNarration.Text.Remove(0, 2);
                }
                TextAcCode.Focus();
                BtnOk.Enabled = false;
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                if (e.IsGetData && e.Column.FieldName == "LId")
                {
                    e.Value = e.ListSourceRowIndex + 1;
                }
                EntryInfo_Grid.RefreshData();
            }
            catch (Exception) { }
        }

        private void TextAmount_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(TextAmount.Text) < 0)
            {
                TextAmount.Focus();
            }
            else
            {
                if (TextSplInfo.Enabled)
                {
                    TextSplInfo.Focus();
                }
                else
                {
                    TextInstrumentType.Focus();
                }
            }
        }

        private void Validate_Click(object sender, EventArgs e)
        {
            using (var ds = ProjectFunctions.GetDataSet(String.Format("SELECT  [VouCode],[VouDesc]  FROM  [VoucherType]  where   VouCode='{0}' Order By VouCode;", TextVoucherType.Text)))
            {
                if (!(ds.Tables[0].Rows.Count > 0))
                {
                    TextVoucherType.Focus();
                    return;
                }
            }
            if (EntryInfo_Grid.RowCount <= 0)
            {
                return;
            }
            if (!TextSplInfo.Enabled && (Math.Round(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(colDebit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero)))
            {
                var rowHandle = -99;
                switch (TextVoucherType.Text)
                {
                    case "BR":
                        rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "AccCode", TextBankCode.Text);
                        if (rowHandle > -1)
                        {
                            EntryInfo_Grid.DeleteRow(rowHandle);
                        }
                        TextAcCode.Text = TextBankCode.Text;
                        TextAcName.Text = TextBankDesc.Text;
                        TextAmount.EditValue = Math.Abs(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue));
                        TextSplInfo.Text = "DR";
                        TextDlrCode.Text = string.Empty;
                        TextDlrDesc.Text = string.Empty;
                        TextExpHeadDesc.Text = string.Empty;
                        TextExpHeadCode.Text = string.Empty;
                        TextCostCode.Text = string.Empty;
                        TextCostDesc.Text = string.Empty;
                        TextCostSubCode.Text = string.Empty;
                        TextCostSubCodeDesc.Text = string.Empty;
                        VarCostId = "0";
                        TextNarration.Focus();
                        break;
                    case "BP":
                        rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "AccCode", TextBankCode.Text);
                        if (rowHandle > -1)
                        {
                            EntryInfo_Grid.DeleteRow(rowHandle);
                        }
                        TextAcCode.Text = TextBankCode.Text;
                        TextAcName.Text = TextBankDesc.Text;
                        TextAmount.EditValue = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
                        TextSplInfo.Text = "CR";
                        TextDlrCode.Text = string.Empty;
                        TextDlrDesc.Text = string.Empty;
                        TextExpHeadDesc.Text = string.Empty;
                        TextExpHeadCode.Text = string.Empty;
                        TextCostCode.Text = string.Empty;
                        TextCostDesc.Text = string.Empty;
                        TextCostSubCode.Text = string.Empty;
                        TextCostSubCodeDesc.Text = string.Empty;
                        VarCostId = "0";
                        TextNarration.Focus();
                        break;
                    case "CP":
                        rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "AccCode", GlobalVariables.CashCode);
                        while (rowHandle > -1)
                        {
                            EntryInfo_Grid.DeleteRow(rowHandle);
                            rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "AccCode", GlobalVariables.CashCode);
                        }
                        TextAcCode.Text = GlobalVariables.CashCode;
                        TextAcName.Text = "Cash";
                        TextAmount.EditValue = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
                        TextSplInfo.Text = "CR";
                        TextDlrCode.Text = string.Empty;
                        TextDlrDesc.Text = string.Empty;
                        TextExpHeadDesc.Text = string.Empty;
                        TextExpHeadCode.Text = string.Empty;
                        TextCostCode.Text = string.Empty;
                        TextCostDesc.Text = string.Empty;
                        TextCostSubCode.Text = string.Empty;
                        TextCostSubCodeDesc.Text = string.Empty;
                        VarCostId = "0";
                        TextNarration.Focus();
                        break;
                    case "CR":
                        rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "AccCode", GlobalVariables.CashCode);
                        while (rowHandle > -1)
                        {
                            EntryInfo_Grid.DeleteRow(rowHandle);
                            rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "AccCode", GlobalVariables.CashCode);
                        }
                        TextAcCode.Text = GlobalVariables.CashCode;
                        TextAcName.Text = "Cash";
                        TextAmount.EditValue = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
                        TextSplInfo.Text = "DR";
                        TextDlrCode.Text = string.Empty;
                        TextDlrDesc.Text = string.Empty;
                        TextExpHeadDesc.Text = string.Empty;
                        TextExpHeadCode.Text = string.Empty;
                        TextCostCode.Text = string.Empty;
                        TextCostDesc.Text = string.Empty;
                        TextCostSubCode.Text = string.Empty;
                        TextCostSubCodeDesc.Text = string.Empty;
                        VarCostId = "0";
                        TextNarration.Focus();
                        break;
                    default:
                        break;
                }
                TextNarration.Text = ((TextVoucherType.Text == "BP" || TextVoucherType.Text == "BR") ? ((TextSplInfo.Text == "DR") ? (String.Format("TO {0} FAV. {1}", EntryInfo_Grid.GetDataRow(0)["Narration"].ToString().Trim().Remove(0, 2), EntryInfo_Grid.GetDataRow(0)["AccName"])) : ("BY " + EntryInfo_Grid.GetDataRow(0)["Narration"].ToString().Trim().Remove(0, 2) + " FAV. " + EntryInfo_Grid.GetDataRow(0)["AccName"])) : ((TextVoucherType.Text == "CP" || TextVoucherType.Text == "CR") ? ((TextSplInfo.Text == "DR") ? ("TO " + EntryInfo_Grid.GetDataRow(0)["Narration"].ToString().Trim().Remove(0, 2)) : ("BY " + EntryInfo_Grid.GetDataRow(0)["Narration"].ToString().Trim().Remove(0, 2))) : ((TextSplInfo.Text == "DR") ? "TO " : "BY ")));
            }
            if (Math.Round(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(colDebit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero))
            {
                Msg.Text = "Diff. " + (Math.Round(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero) - Math.Round(Convert.ToDecimal(colDebit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero));
                if (TextVoucherType.Text == "CN" || TextVoucherType.Text == "DN")
                {
                    if (Math.Round(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(TextAmt.EditValue), 2, MidpointRounding.AwayFromZero))
                    {
                        Msg.Text = "CN/DN Diff. " + (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(TextAmt.EditValue));
                    }
                }
            }
            else
            {

                if (!isupdate)
                {
                    var query = String.Format("select dbo.DoPadd((SELECT  isnull(cast(max(VumNo)as int),0)  as 'Value' FROM VuMst WHERE UnitCode='" + GlobalVariables.CUnitID + "' And VumType='" + TextVoucherType.Text + "' And VumFYear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "' )+1) as Value;");
                    var ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextVoucherNo.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                    }
                }
                Save.Enabled = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (TextVoucherNo.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("You are Cheating. Plz Enter Valid Date Or Password.");
                DtVoucher.Focus();
                return;
            }
            try
            {
                if (EntryInfo_GridCtrl.DataSource != null)
                {
                    if (EntryInfo_Grid.RowCount > 0)
                    {
                        if (Math.Round(Convert.ToDecimal(EntryInfo_Grid.Columns["Credit"].SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero) == Math.Round(Convert.ToDecimal(EntryInfo_Grid.Columns["Debit"].SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero))
                        {
                            using (var con = new SqlConnection(ProjectFunctions.ConnectionString))
                            {
                                con.Open();
                                var command = con.CreateCommand();
                                var transaction = con.BeginTransaction("SaveTransaction");
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.CommandText = "[dbo].[Sp_Ins_UpdVuMst4CMNN]";
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.Add("@VumDate", SqlDbType.SmallDateTime).Value = DtVoucher.DateTime.Date;
                                command.Parameters.Add("@VumNo", SqlDbType.VarChar, 7).Value = TextVoucherNo.Text;
                                command.Parameters.Add("@VumType", SqlDbType.VarChar, 2).Value = TextVoucherType.Text;
                                command.Parameters.Add("@VumNoRcd", SqlDbType.Int).Value = Convert.ToUInt32(colAccCode.SummaryItem.SummaryValue);
                                command.Parameters.Add("@VumAmt", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue), 2, MidpointRounding.AwayFromZero);
                                command.Parameters.Add("@VumBCode", SqlDbType.VarChar, 6).Value = (TextVoucherType.Text == "CP" || TextVoucherType.Text == "CR") ? GlobalVariables.CashCode : ((TextVoucherType.Text == "BP" || TextVoucherType.Text == "BR") ? TextBankCode.Text : string.Empty);
                                command.Parameters.Add("@IsUpdate", SqlDbType.Char, 1).Value = isupdate ? "Y" : "N";
                                command.Parameters.Add("@Vumid", SqlDbType.BigInt).Value = 0;
                                command.Parameters.Add("@VumFYear", SqlDbType.Char, 2).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                command.Parameters.Add("@VumUser", SqlDbType.VarChar, 8).Value = GlobalVariables.CurrentUser;
                                command.Parameters.Add("@VumDfDt", SqlDbType.SmallDateTime).Value = DateTime.Now;
                                command.Parameters.Add("@BuCode", SqlDbType.VarChar, 20).Value = BuCode;
                                command.Parameters.Add("@UnitCode", SqlDbType.VarChar, 20).Value = GlobalVariables.CUnitID;
                                command.Parameters["@Vumid"].Direction = ParameterDirection.InputOutput;
                                command.Parameters["@VumNo"].Direction = ParameterDirection.InputOutput;


                                try
                                {
                                    command.ExecuteNonQuery();
                                    TextVoucherNo.Text = command.Parameters["@VumNo"].Value.ToString();
                                    var Id = command.Parameters["@Vumid"].Value.ToString();

                                    if (TextVoucherType.Text == "DN" || TextVoucherType.Text == "CN")
                                    {
                                        var rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "SplInf", "DR");
                                        command.Parameters.Clear();
                                        command.CommandText = "[dbo].[Dc_Ins_Upd]";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Add("@DcType", SqlDbType.NVarChar, 2).Value = TextVoucherType.Text;
                                        command.Parameters.Add("@DcNo", SqlDbType.NVarChar, 7).Value = TextDNNo.Text;
                                        command.Parameters.Add("@DcVumID", SqlDbType.Int).Value = Id;
                                        command.Parameters.Add("@DcVhtDt", SqlDbType.SmallDateTime).Value = DtVoucher.DateTime.Date;
                                        command.Parameters.Add("@DcVhtNo", SqlDbType.NVarChar, 7).Value = TextVoucherNo.Text;
                                        command.Parameters.Add("@DcVhtAmt", SqlDbType.Decimal).Value = TextAmt.Text;
                                        command.Parameters.Add("@DcNar1", SqlDbType.NVarChar, 100).Value = TextNar1.Text;
                                        command.Parameters.Add("@DcNar2", SqlDbType.NVarChar, 100).Value = TextNar2.Text;
                                        command.Parameters.Add("@DcNar3", SqlDbType.NVarChar, 100).Value = TextNar3.Text;
                                        command.Parameters.Add("@DcNar4", SqlDbType.NVarChar, 100).Value = TextNar4.Text;
                                        command.Parameters.Add("@DcNar5", SqlDbType.NVarChar, 100).Value = TextNar5.Text;
                                        command.Parameters.Add("@DcNar6", SqlDbType.NVarChar, 100).Value = TextNar6.Text;
                                        command.Parameters.Add("@DcVhrStr", SqlDbType.NVarChar, 20).Value = TextVoucherNo.Text + DtVoucher.DateTime.Date;
                                        command.Parameters.Add("@DcUser", SqlDbType.VarChar, 8).Value = GlobalVariables.CurrentUser;
                                        command.Parameters.Add("@DcAccCode", SqlDbType.NVarChar, 6).Value = EntryInfo_Grid.GetRowCellValue(rowHandle, colAccCode).ToString();
                                        command.Parameters.Add("@DcFyear", SqlDbType.VarChar, 2).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                        command.Parameters.Add("@IsUpdate", SqlDbType.Char, 1).Value = isupdate ? "Y" : "N";
                                        command.Parameters.Add("@UnitCode", SqlDbType.VarChar, 2).Value = GlobalVariables.CUnitID;

                                        command.ExecuteNonQuery();
                                    }

                                    var Query = String.Format(" Delete From VuData Where VutNo='{0}' And VutDate='{1}' And VutType='{2}'  And UnitCode='" + GlobalVariables.CUnitID + "';", TextVoucherNo.Text, DtVoucher.DateTime.Date.ToString("yyyy-MM-dd"), TextVoucherType.Text);
                                    command.Parameters.Clear();
                                    command.CommandText = Query;
                                    command.CommandType = CommandType.Text;
                                    command.ExecuteNonQuery();


                                    foreach (DataRow Dr in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
                                    {
                                        command.Parameters.Clear();
                                        command.CommandText = "[dbo].[Sp_Ins_VuData4CMNN]";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Add("@VutDate", SqlDbType.SmallDateTime).Value = DtVoucher.DateTime.Date;
                                        command.Parameters.Add("@VutNo", SqlDbType.VarChar, 7).Value = TextVoucherNo.Text;
                                        command.Parameters.Add("@VutType", SqlDbType.VarChar, 2).Value = TextVoucherType.Text;
                                        command.Parameters.Add("@VutACode", SqlDbType.VarChar, 6).Value = Dr["AccCode"].ToString();
                                        command.Parameters.Add("@VutAmt", SqlDbType.Decimal).Value = ((Dr["SplInf"].ToString() == "CR" || Dr["SplInf"].ToString() == "C") ? Convert.ToDecimal(Dr["Credit"]) * -1 : Convert.ToDecimal(Dr["Debit"]));
                                        command.Parameters.Add("@VutCrDr", SqlDbType.Char, 1).Value = Dr["SplInf"].ToString();
                                        if (Dr["Narration"].ToString().Length > 185)
                                        {
                                            Dr["Narration"] = Dr["Narration"].ToString().Substring(0, 185) + "AND MANY MORE.";
                                        }
                                        command.Parameters.Add("@VutNart", SqlDbType.VarChar, 200).Value = Dr["Narration"];
                                        command.Parameters.Add("@VutRefType", SqlDbType.VarChar, 20).Value = Dr["RefMethod"].ToString();
                                        command.Parameters.Add("@VutRef", SqlDbType.VarChar, 10).Value = Dr["InstType"].ToString();
                                        command.Parameters.Add("@VutUserID", SqlDbType.VarChar, 8).Value = GlobalVariables.CurrentUser;
                                        command.Parameters.Add("@VutFDt", SqlDbType.SmallDateTime).Value = DateTime.Now;
                                        command.Parameters.Add("@VutFYear", SqlDbType.Char, 10).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                        command.Parameters.Add("@VutChqDDRcptNo", SqlDbType.VarChar, 30).Value = Dr["InstNo"].ToString();
                                        command.Parameters.Add("@vutChqClearDt", SqlDbType.DateTime).Value = Convert.ToDateTime((Dr["vutChqClearDt"] == DBNull.Value) ? DateTime.Now.Date : Dr["vutChqClearDt"]);
                                        command.Parameters.Add("@VutCostHeadID", SqlDbType.VarChar, 6).Value = Dr["VutCostHeadID"].ToString() == string.Empty ? "0000" : Dr["VutCostHeadID"].ToString();
                                        command.Parameters.Add("@VutEXpHeadCode", SqlDbType.VarChar, 6).Value = Dr["ExpCode"].ToString();
                                        command.Parameters.Add("@VutAACode", SqlDbType.VarChar, 6).Value = Dr["CDlrCode"].ToString();
                                        command.Parameters.Add("@VutTotalAmt ", SqlDbType.Decimal).Value = ((Dr["SplInf"].ToString() == "CR" || Dr["SplInf"].ToString() == "C") ? Convert.ToDecimal(Dr["Credit"]) * -1 : Convert.ToDecimal(Dr["Debit"]));
                                        command.Parameters.Add("@IsUpdate", SqlDbType.VarChar, 1).Value = "I";
                                        command.Parameters.Add("@CostHead", SqlDbType.VarChar, 20).Value = Cost_CmBx.Text;
                                        command.Parameters.Add("@VutID", SqlDbType.Decimal).Value = Convert.ToDecimal("0");
                                        command.Parameters.Add("@UnitCode", SqlDbType.VarChar, 20).Value = GlobalVariables.CUnitID;
                                        if (Cost_CmBx.Text == "NA#" && (TextVoucherType.Text != "BP" || TextVoucherType.Text != "BR"))
                                        {
                                            BuCode = "NA#";
                                            TextAcCode.Focus();
                                        }
                                        else
                                        {
                                            var Ds = ProjectFunctions.GetDataSet(String.Format("SELECT      BuCode, BuSelfACode, BuHOAcode FROM BUMst Where BuCode='{0}'", Cost_CmBx.Text));
                                            BuCode = Ds.Tables[0].Rows[0][0].ToString();
                                            BuSelfACode = Ds.Tables[0].Rows[0][1].ToString();
                                            BuHOAcode = Ds.Tables[0].Rows[0][2].ToString();
                                        }
                                        command.Parameters.Add("@BuCode", SqlDbType.VarChar, 20).Value = BuCode;
                                        command.Parameters.Add("@BuSelfACode", SqlDbType.VarChar, 8).Value = BuSelfACode;
                                        command.Parameters.Add("@BuHOAcode", SqlDbType.VarChar, 8).Value = BuHOAcode;
                                        command.ExecuteNonQuery();
                                    }




                                    transaction.Commit();
                                    if (!(isupdate))
                                    {
                                        VoucherNo = TextVoucherNo.Text;
                                        VoucherType = TextVoucherType.Text;
                                        VoucherDate = DtVoucher.DateTime.Date;
                                        SaveMsg.Text = "Last Saved Entry's Amt. : " + Math.Abs(Convert.ToDecimal(colCredit.SummaryItem.SummaryValue));
                                        TextVoucherNo.Text = string.Empty;
                                        TextVoucherType.Text = string.Empty;
                                        Cost_CmBx.Enabled = true;
                                        using (var Ds = ProjectFunctions.GetDataSet("SELECT     AccCode, AccName, Narration, Credit, Debit, SplInf, RefMethod, CDlrCode, CDlrNm, ExpCode, ExpDesc, CostCode, " + "CostDesc, CostSubcode, CostSubDesc, InstType, InstNo,VutCostHeadID, VutID,vutChqClearDt FROM V_VuData4CMN WHERE 1=2    "))
                                        {
                                            if (Ds != null)
                                            {
                                                EntryInfo_GridCtrl.DataSource = Ds.Tables[0];
                                            }
                                            EntryInfo_Grid.ClearSorting();
                                        }
                                        TextAcCode.Text = string.Empty;
                                        TextAcName.Text = string.Empty;
                                        TextNarration.Text = string.Empty;
                                        TextAmount.Text = "0.00";
                                        TextSplInfo.Text = string.Empty;
                                        TextDlrCode.Text = string.Empty;
                                        TextDlrDesc.Text = string.Empty;
                                        TextExpHeadDesc.Text = string.Empty;
                                        TextExpHeadCode.Text = string.Empty;
                                        TextCostCode.Text = string.Empty;
                                        TextCostDesc.Text = string.Empty;
                                        TextCostSubCode.Text = string.Empty;
                                        TextCostSubCodeDesc.Text = string.Empty;
                                        TextInstrumentType.Text = "OTH";
                                        TextInstrumentNo.Text = string.Empty;

                                        dt.Clear();
                                        EntryInfo_GridCtrl.DataSource = null;
                                        DtVoucher.EditValue = VoucherDate.Date;
                                        DtVoucher.Focus();
                                    }
                                    else
                                    {
                                        ProjectFunctions.SpeakError("Data Saved");
                                        Dispose();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    try
                                    {
                                        transaction.Rollback();
                                        ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);
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
                            ProjectFunctions.SpeakError("Diff Amount." + (Convert.ToDecimal(colCredit.SummaryItem.SummaryValue) - Convert.ToDecimal(colDebit.SummaryItem.SummaryValue)).ToString());
                            TextAmount.Focus();
                        }
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Grid has No Record.");
                        TextAcCode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Something Wrong." + ex.Message);
            }
        }

        private void TextVoucherType_EditValueChanged(object sender, EventArgs e)
        {
            TextSplInfo.Enabled = true;
            switch (TextVoucherType.Text)
            {
                case "CP":
                    TextSplInfo.Text = "DR";
                    Cost_CmBx.Enabled = false;
                    TextSplInfo.Enabled = false;
                    break;
                case "CR":
                    Cost_CmBx.Enabled = false;
                    TextSplInfo.Text = "CR";
                    TextSplInfo.Enabled = false;
                    break;
                case "BP":
                    TextSplInfo.Text = "DR";
                    TextSplInfo.Enabled = false;
                    Cost_CmBx.Enabled = true;
                    break;
                case "BR":
                    TextSplInfo.Text = "CR";
                    TextSplInfo.Enabled = false;
                    Cost_CmBx.Enabled = true;
                    break;
                default:
                    Cost_CmBx.Enabled = false;
                    TextSplInfo.Enabled = true;
                    TextSplInfo.Text = "CR";
                    break;
            }
        }

        private void DtVoucher_EditValueChanged(object sender, EventArgs e)
        {
            if (VoucherDate.Date != DtVoucher.DateTime.Date)
            {
                AuthenticateFlag = false;
            }
            Save.Enabled = false;
        }

        private void TextSplInfo_Leave(object sender, EventArgs e)
        {
            switch (TextSplInfo.Text.ToUpper())
            {
                case "D":
                    TextSplInfo.Text = "DR";
                    TextInstrumentType.Focus();
                    break;
                case "DR":
                    TextSplInfo.Text = "DR";
                    TextInstrumentType.Focus();
                    break;
                case "C":
                    TextSplInfo.Text = "CR";
                    TextInstrumentType.Focus();
                    break;
                case "CR":
                    TextSplInfo.Text = "CR";
                    TextInstrumentType.Focus();
                    break;
                default:
                    TextSplInfo.Focus();
                    break;
            }
        }

        private void TextBankCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    const string Query = "SELECT      AccName, AccCode, AccLedger FROM         ActMst WHERE     (AccBankTag = N'Y') Order by AccName;";
                    CurrentControl = "TextBankCode";
                    if (TextBankCode.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                        e.Handled = true;
                    }

                    else
                    {
                        var query = string.Empty;
                        if (TextVoucherType.Text == "BR" || TextVoucherType.Text == "BP")
                        {
                            query = string.Format("SELECT      AccName,AccCode, AccLedger FROM         ActMst WHERE     (AccBankTag = N'Y') and AccCode='{0}' Order by AccName;", TextBankCode.Text.Trim());
                        }
                        using (var ds = ProjectFunctions.GetDataSet(query))
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                TextBankCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                                TextBankDesc.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                                CurrentControl = string.Empty;
                                HelpGridCtrl.Visible = false;
                                TextInstrumentType.Focus();
                            }
                            else
                            {
                                ShowHelpWindow(Query);
                            }
                        }
                        e.Handled = true;
                    }
                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    SubPanel.Visible = false;
                    TextVoucherType.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void TextAmt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(TextAmt.Text) <= 0)
                {
                    TextAmt.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void TextNar6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (Convert.ToDecimal(TextAmt.Text) <= 0)
                    {
                        TextAmt.Focus();
                    }
                    else
                    {
                        if (TextNar1.Text == string.Empty)
                        {
                            TextNar1.Focus();
                        }
                        else
                        {
                            if (TextDNNo.Text == string.Empty)
                            {
                                ProjectFunctions.SpeakError("NO No.");
                            }
                            else
                            {
                                CNGroupCtrl.Visible = false;
                            }
                        }
                    }
                    e.Handled = true;
                }
                catch (Exception)
                {
                }
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
            e.Handled = true;
        }

        private void TextNar5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void BtnLoadFrmXls_Click(object sender, EventArgs e)
        {
            //var Dt = ProjectFunctions.ImportExcelXLS(path, true).Tables[0];
            //if (Dt.Rows.Count > 0)
            //{
            //    EntryInfo_GridCtrl.DataSource = null;

            //    EntryInfo_GridCtrl.DataSource = Dt;
            //    foreach (DataRow Dr in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
            //    {
            //        Dr.SetAdded();
            //    }
            //}
            //EntryInfo_GridCtrl.Refresh();
            //EntryInfo_Grid.UpdateTotalSummary();
            //EntryInfo_Grid.UpdateCurrentRow();
        }

        private void TextAuthenticate_KeyDown(object sender, KeyEventArgs e)
        {
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.P | Keys.Control))
        //    {
        //        using (var Ds = ProjectFunctions.GetDataSet(String.Format("Select * From V_PrintCMN WHERE (((VutDate)='{0:yyyy-MM-dd}') AND ((VutType)='{1}')  AND ((VutNo)='{2}')) {3}", VoucherDate.Date, VoucherType, VoucherNo, ((VoucherType == "CP" || VoucherType == "CR") ? "And VutAcode<>'"+GlobalVariables.CashCode+"'" : string.Empty))))
        //        {
        //            if (Ds != null)
        //            {
        //                if (Ds.Tables[0].Rows.Count > 0)
        //                {
        //                    if (VoucherType == "CP" || VoucherType == "CR")
        //                    {
        //                        var rowToRemove = Ds.Tables[0].Select("VutAcode=" + GlobalVariables.CashCode).FirstOrDefault();
        //                        if (rowToRemove != null)
        //                        {
        //                            Ds.Tables[0].Rows.Remove(rowToRemove);
        //                        }
        //                    }
        //                    //using (var pt = new ReportPrintTool(new Rpt_VoucherPrint() { DataSource = Ds.Tables[0] }))
        //                    //{
        //                    //    pt.ShowPreviewDialog();
        //                    //}
        //                }
        //                else
        //                {
        //                    ProjectFunctions.SpeakError("Either No Record or Unable To Fetch Data\n Contact IT Department.");
        //                }
        //            }
        //            else
        //            {
        //                ProjectFunctions.SpeakError("Either No Record or Unable To Fetch Data\n Contact IT Department.");
        //            }
        //        }
        //        return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void TextVoucherType_Enter(object sender, EventArgs e)
        {

            if (isupdate)
            {
                TextVoucherType.Properties.ReadOnly = true;
            }
        }

        private void TextVoucherType_Leave(object sender, EventArgs e)
        {

            if (TextVoucherType.IsModified)
            {
                (EntryInfo_GridCtrl.DataSource as DataTable).Clear();
                (EntryInfo_GridCtrl.DataSource as DataTable).AcceptChanges();
            }
        }

        private void DtClear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubPanel.Visible = false;
                panelControl2.Focus();
                BankDesc.Text = String.Format("({0}) {1}", TextBankCode.Text, TextBankDesc.Text);
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                TextInstrumentType.Focus();
            }
        }

        private void TextAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDecimal(TextAmount.EditValue) <= 0)
                {
                    Msg.Text += "\t You should enter Amount Greater than zero.";
                    TextAmount.Focus();
                    e.Handled = true;
                }
                if (TextSplInfo.Enabled)
                {
                    TextSplInfo.Focus();
                }
                else
                {
                    TextNarration.Focus();
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                TextAcCode.Focus();
            }
            e.Handled = true;
        }

        private void DtVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                TextVoucherType.Focus();
            }
            e.Handled = true;
        }

        private void TextNarration_Enter(object sender, EventArgs e)
        {
            if (TextNarration.Text.Length == 0)
            {
                //TextNarration.Text = ((TextVoucherType.Text == "BP" || TextVoucherType.Text == "BR") ? ((TextSplInfo.Text == "DR") ? ("TO " + TextInstrumentType.Text + ". NO. " + TextInstrumentNo.Text) : ("BY " + TextInstrumentType.Text + ". NO. " + TextInstrumentNo.Text)) : ((TextSplInfo.Text == "DR") ? "TO " : "BY "));
                //if (TextAcCode.Text == "9327" || TextAcCode.Text == "0263" || Flag)
                //{
                //    TextNarration.Text += " " + TextDlrDesc.Text; Flag = false;
                //}
            }
        }

        private void TextInstrumentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                DtClear.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                TextInstrumentType.Focus();
            }
            e.Handled = true;
        }

        private void Cost_CmBx_TextChanged(object sender, EventArgs e)
        {
            if (isupdate)
            {
                if ((EntryInfo_GridCtrl.DataSource as DataTable) != null)
                {
                    foreach (DataRow r in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
                    {
                        r.SetModified();
                    }
                }
            }
            else
            {
                EntryInfo_Grid.SelectAll();
                EntryInfo_Grid.DeleteSelectedRows();
            }
        }

        private void TextInstrumentNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (TextInstrumentNo.IsModified)
                {
                    if (EntryInfo_Grid.RowCount == 0)
                    {
                        return;
                    }
                    else
                    {
                        for (var i = 0; i < EntryInfo_Grid.RowCount; i++)
                        {
                            EntryInfo_Grid.SetRowCellValue(i, EntryInfo_Grid.Columns[2], EntryInfo_Grid.GetRowCellValue(i, EntryInfo_Grid.Columns[2]).ToString().Replace((TextInstrumentNo.OldEditValue == null ? string.Empty : TextInstrumentNo.OldEditValue.ToString()), TextInstrumentNo.EditValue.ToString()));
                        }
                    }
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }

        private void Cost_CmBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Cost_CmBx.Text == "NA#" && (TextVoucherType.Text != "BP" || TextVoucherType.Text != "BR"))
            {
                BuCode = "NA#";
                TextAcCode.Focus();
            }
            else
            {
                var Ds = ProjectFunctions.GetDataSet(String.Format("SELECT      BuCode, BuSelfACode, BuHOAcode FROM BUMst Where BuCode='{0}'", Cost_CmBx.Text));
                BuCode = Ds.Tables[0].Rows[0][0].ToString();
                BuSelfACode = Ds.Tables[0].Rows[0][1].ToString();
                BuHOAcode = Ds.Tables[0].Rows[0][2].ToString();
                TextAcCode.Focus();
            }
        }

        private void TextAcCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextAcCode.Text == string.Empty)
            {
                e.Cancel = false;
            }

        }

        private void Cost_CmBx_EditValueChanged(object sender, EventArgs e)
        {
            Cost_CmBx_Validating(null, null);
        }

        private void Cost_CmBx_Leave(object sender, EventArgs e)
        {
            Cost_CmBx_Validating(null, null);
        }

        private void TextVoucherType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(TextVoucherType.Text.ToUpper() == "BP" || TextVoucherType.Text.ToUpper() == "BR"))
            {
                Cost_CmBx.Enabled = false;
                e.Cancel = false;
            }
            else
            {
                Cost_CmBx.Enabled = true;
            }
        }

        private void DtVoucher_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void DtVoucher_Leave(object sender, EventArgs e)
        {
            if (!ProjectFunctions.CheckRange(DtVoucher.DateTime, GlobalVariables.FinYearStartDate.Date, GlobalVariables.FinYearEndDate.Date))
            {
                DtVoucher.Focus();
                XtraMessageBox.Show(DtVoucher, "Date does not fall in Expected Date Range You are crossing FinancialYear Limit ");
                return;
            }


            if (!isupdate)
            {
                var query = String.Format("select dbo.DoPadd((SELECT  isnull(cast(max(VumNo)as int),0)  as 'Value' FROM VuMst WHERE UnitCode='" + GlobalVariables.CUnitID + "' And VumType='" + TextVoucherType.Text + "' And VumFYear='" + ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear) + "' )+1) as Value;");
                var ds = ProjectFunctions.GetDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TextVoucherNo.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                }
            }
        }

        private void LoadSalary_Click(object sender, EventArgs e)
        {

        }

        private void HelpGridCtrl_Click(object sender, EventArgs e)
        {

        }
    }
}
