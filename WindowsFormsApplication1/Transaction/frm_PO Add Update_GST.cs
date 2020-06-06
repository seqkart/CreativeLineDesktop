using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.ComponentModel;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frm_poAddition_GST : XtraForm
    {
        public bool IsUpdate { get; set; }
        public string PoNo { get; set; }
        public string PoId { get; set; }
        public DateTime PoDate { get; set; }
        public string CurrentControl { get; set; }
        public DateTime FStartDate { get; set; }
        private decimal _IndentQty;
        private decimal _LastRec;
        private decimal _POQty;
        private decimal _Sum;
        private int AutoId;
        private DataTable DT4GridOrignal;
        private bool Errorflag;
        private string IndentNo = string.Empty;

        private DateTime OldDt;
        DataTable Record = new DataTable();
        string currentprodCode = string.Empty;
        private int selected_Record;
        private DataTable TacData = new DataTable();
        DataRow ThisRecord;
        int id = 0;
        bool AuthenticateFlag = false;

        public frm_poAddition_GST()
        {
            InitializeComponent();
        }

        private void SetMyControls()
        {
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            //   ProjectFunctions.GirdViewVisualize(Attachments_Grid);
            ProjectFunctions.GirdViewVisualize(EntryInfo_Grid);
            ProjectFunctions.GirdViewVisualize(HelpGrid);
            EntryInfo_Grid.OptionsBehavior.Editable = false;
            HelpGrid.OptionsBehavior.Editable = false;
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            (TextAuthenticate.Control as TextBox).UseSystemPasswordChar = true;

            Record.Columns.Add("DeptCode", typeof(string));
            Record.Columns.Add("DeptName", typeof(string));
            Record.Columns.Add("PrdCode", typeof(string));
            Record.Columns.Add("PrdName", typeof(string));
            Record.Columns.Add("Uom", typeof(string));
            Record.Columns.Add("PrdAsgnCode", typeof(string));
            Record.Columns.Add("Qnty", typeof(float));
            Record.Columns.Add("Rate", typeof(float));
            Record.Columns.Add("DutyRate", typeof(float));
            Record.Columns.Add("TaxRate", typeof(float));
            Record.Columns.Add("DeliveryDate", typeof(DateTime));
            Record.Columns.Add("Discount", typeof(float));
            Record.Columns.Add("CashDisc", typeof(float));
            Record.Columns.Add("Amount", typeof(float));
            Record.Columns.Add("AID", typeof(int));
            Record.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            Record.Columns.Add("Remarks", typeof(string));
            Record.Columns.Add("IndId", typeof(string));
            Record.Columns.Add("IndNo", typeof(Int64));
            Record.Columns.Add("PoSGSTR", typeof(decimal));
            Record.Columns.Add("PoCGSTR", typeof(decimal));
            Record.Columns.Add("PoIGSTR", typeof(decimal));
            if (IsUpdate)
            {
                this.Text = "PO Updation";
                //DtEntry.Enabled = false;
                TextPartyCode.Enabled = false;
                string Query = string.Format("sp_GetData4POUPDGST '{0}','{1:yyyy-MM-dd}';", PoNo, PoDate);
                GetData4Update(Query);
                DtEntry.Focus();
            }
        }

        private void SetMyValidations()
        {
            //ConditionValidationRule FinancialYearCondition = new ConditionValidationRule() { ConditionOperator = ConditionOperator.Between, ErrorText = "Either You are Crossing the FinancialYear Limit or CurrentDate Limit .", Value1 = GlobalVariables.FinYearStartDate, Value2 = (DateTime.Now >= GlobalVariables.FinYearStartDate && DateTime.Now <= GlobalVariables.FinYearEndDate) ? DateTime.Now.Date : GlobalVariables.FinYearEndDate.Date };
            //this.MyValidationProvider.SetValidationRule(DtEntry, FinancialYearCondition);

        }

        private void GetData4Update(string Query)
        {

            using (DataSet ds = ProjectFunctions.GetDataSet(Query))
            {
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        BindMyData.DataSource = ds.Tables[0];
                        DtEntry.DataBindings.Add("EditValue", BindMyData, "PomDate");
                        OldDt = DtEntry.DateTime.Date;
                        TextDoc_NO.DataBindings.Add("EditValue", BindMyData, "PomNo");
                        TextPartyCode.DataBindings.Add("EditValue", BindMyData, "PomAccCode");
                        TextPartyName.DataBindings.Add("EditValue", BindMyData, "AccName");
                        TextRefNo.DataBindings.Add("EditValue", BindMyData, "PomRefno");
                        TextPaymentTerms.DataBindings.Add("EditValue", BindMyData, "PomPymntTerms");
                        TextDeliveryTerms.DataBindings.Add("EditValue", BindMyData, "PomDlryTerms");
                        TextOctroi.DataBindings.Add("EditValue", BindMyData, "PomOctroi");
                        TextFrieght.DataBindings.Add("EditValue", BindMyData, "PomFreight");
                        TextDeliveryAt.DataBindings.Add("EditValue", BindMyData, "PomDeliveryAt");
                        TextInsurance.DataBindings.Add("EditValue", BindMyData, "PomInsurance");
                        TextRemarks.DataBindings.Add("EditValue", BindMyData, "PomRemarks");
                        TextBroker.DataBindings.Add("EditValue", BindMyData, "PomBrokerCd");
                        textEdit1.DataBindings.Add("EditValue", BindMyData, "BName");
                    }

                    try
                    {
                        DT4GridOrignal = ds.Tables[1];
                        if (DT4GridOrignal.Rows.Count > 0)
                        {
                            foreach (DataRow Dr in DT4GridOrignal.Rows)
                            {
                                Record.Rows.Add(Dr[0], Dr[1], Dr[2], Dr[3], Dr[4], Dr[5], Dr[6], Dr[7], Dr[8], Dr[9], Dr[10], Dr[11], Dr[12], Dr[13], Dr[14], Dr[15], Dr["Remarks"], Dr["IndId"], Dr["IndNo"], Dr["PoSGSTR"], Dr["PoCGSTR"], Dr["PoIGSTR"]);
                            }
                        }
                        EntryInfo_GridCtrl.DataSource = Record;
                        //Record = DT4GridOrignal;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            TextAuthenticate.Visible = false;
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void frm_poAddition_Load(object sender, EventArgs e)
        {
            SetMyControls();
            SetMyValidations();
            if (!IsUpdate)
            {
                DtEntry.EditValue = DateTime.Today;
                DtDelivery.EditValue = DateTime.Today;
                //if (IsAutoGenrate)
                //{
                //    GetData4Update(AutoGenQuery);
                //}
                DtEntry.Focus();
            }
        }

        private void HelpGridCtrl_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                System.Data.DataRow row = HelpGrid.GetDataRow(HelpGrid.FocusedRowHandle);
                switch (CurrentControl)
                {
                    case "TextPartyCode":
                        {

                            TextPartyCode.Text = row["Code"].ToString();
                            TextPartyName.Text = row["Party Name"].ToString();

                            HelpGridCtrl.Visible = false;
                            TextDeptCode.Focus();
                            break;
                        }
                    case "TextDeptCode":
                        {

                            TextDeptCode.Text = row["DeptCode"].ToString();
                            TextDeptName.Text = row["DeptDesc"].ToString();
                            HelpGridCtrl.Visible = false;

                            TextProdCode.Focus();
                            break;
                        }

                    case "TextProdCode":
                        TextProdCode.Text = row["Code"].ToString();
                        TextProdDesc.Text = row["Product Name"].ToString();
                        TextProdAsgnCode.Text = row["Assigned Code"].ToString();
                        TextUOM.Text = row["UOM"].ToString();
                        TextProdRate.Text = row["Rate"].ToString();
                        TextRem.Focus();
                        break;
                    case "TextBroker":
                        TextBroker.Text = row["Code"].ToString();
                        textEdit1.Text = row["Agent"].ToString();
                        TextRefNo.Focus();
                        break;
                    case "Pen_Po_BTn":
                        TextIndNo.Text = row["IndDNo"].ToString();
                        IndentNo = row["IndId"].ToString();
                        TextIndNo.Focus();
                        break;

                    default:
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        CurrentControl = string.Empty;

                        break;


                }
                HelpGridCtrl.Visible = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Either No Record or Unable to Fetch Data. " + ex.Message);
                CurrentControl = string.Empty;
                HelpGridCtrl.Visible = false;

            }
            MyValidationProvider.ValidationMode = ValidationMode.Auto;

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

            if (e.Control)
            {
                if (CurrentControl == "Btn_Term")
                {
                    //TacData.Clear();
                    TacData = (HelpGridCtrl.DataSource as DataTable).Copy();
                    HelpGridCtrl.Visible = false;
                    e.Handled = true;
                }
            }
        }

        private void HelpGridCtrl_Leave(object sender, EventArgs e)
        {
            HelpGridCtrl_DoubleClick(sender, e);
        }

        private void RestoreFocus()
        {
            switch (CurrentControl)
            {
                //case "TextSuppCode":
                //    TextSuppCode.Focus();
                //break;

                default:
                    break;
            }

        }

        private void ShowHelpWindow(string Query)
        {
            try
            {
                Print.Enabled = false;
                HelpGridCtrl.DataSource = null;
                HelpGrid.Columns.Clear();
                HelpGridCtrl.RefreshDataSource();
                HelpGridCtrl.Visible = true;
                HelpGridCtrl.Focus();
                using (DataSet Ds = ProjectFunctions.GetDataSet(Query))
                {
                    if (CurrentControl == "Btn_Term")
                    {
                        if (TacData.Rows.Count == 0)
                        {
                            DataTable temp = new DataTable();
                            Ds.Tables[0].Columns.Add("Select", Type.GetType("System.Boolean"));
                            if (Ds.Tables.Count > 1)
                                Ds.Tables[1].Columns.Add("Select", Type.GetType("System.Boolean"));
                            if (IsUpdate)
                            {
                                var diff = Ds.Tables[1].AsEnumerable().Except(Ds.Tables[0].AsEnumerable(),
                                                     DataRowComparer.Default);
                                temp = diff.CopyToDataTable();
                                foreach (DataRow Dr in temp.Rows)
                                {
                                    Dr["Select"] = false;
                                }
                                foreach (DataRow Dr in Ds.Tables[0].Rows)
                                {
                                    Dr["Select"] = true;
                                }
                                Ds.Tables[0].Merge(temp);
                                HelpGridCtrl.DataSource = Ds.Tables[0];
                            }
                            else
                            {
                                foreach (DataRow Dr in Ds.Tables[0].Rows)
                                {
                                    Dr["Select"] = false;
                                }
                                HelpGridCtrl.DataSource = Ds.Tables[0];
                            }
                        }
                        else
                            HelpGridCtrl.DataSource = TacData;

                        ProjectFunctions.GirdViewVisualize(HelpGrid);
                        HelpGrid.OptionsBehavior.Editable = true;
                        this.HelpGrid.Columns[0].OptionsColumn.AllowEdit = false;
                        this.HelpGrid.Columns[0].OptionsColumn.ReadOnly = true;
                        this.HelpGrid.Columns[1].OptionsColumn.AllowEdit = false;
                        this.HelpGrid.Columns[1].OptionsColumn.ReadOnly = true;
                        HelpGrid.Columns[0].Width = 35;
                        HelpGrid.Columns[2].Width = 45;
                    }
                    else
                    {
                        HelpGridCtrl.DataSource = Ds.Tables[0];
                        ProjectFunctions.GirdViewVisualize(HelpGrid);
                        HelpGrid.Columns[1].BestFit();
                    }
                }
                if (CurrentControl.Equals(TextProdCode.Name))
                {
                    HelpGrid.Columns["Product Name"].Width = 110;

                    HelpGrid.Columns["UOM"].Visible = false;
                    HelpGrid.Columns["Rate"].Visible = false;
                    //HelpGrid.Columns["Ac Code"].Visible = false;
                    //HelpGrid.Columns["Ac Name"].Visible = false;

                }
                if (CurrentControl.Equals(TextPartyCode.Name))
                {
                    HelpGrid.Columns["AccPSTCST"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Unable to fetch Data please Contact IT Department.\n" + ex.Message);
            }
        }

        private void TextPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    const string Query = "SELECT    ActMst.AccName AS 'Party Name',ActMst.AccCode as 'Code', ActMstAddInf.AccPSTCST  FROM         ActMstAddInf RIGHT OUTER JOIN ActMst ON ActMstAddInf.AccCode = ActMst.AccCode order by ActMst.AccName";
                    MyValidationProvider.ValidationMode = ValidationMode.Manual;
                    MyValidationProvider.RemoveControlError(TextPartyCode);
                    CurrentControl = "TextPartyCode";

                    if (TextPartyCode.Text.Trim().Length == 0)
                    {
                        //Display Help Window
                        ShowHelpWindow(Query);
                        e.Handled = true;
                    }

                    else
                    {
                        //Checking whether Value  is Existing or not!
                        string query = String.Format("SELECT    ActMst.AccName AS 'Party Name',ActMst.AccCode as Code, ActMstAddInf.AccPSTCST  FROM         ActMstAddInf RIGHT OUTER JOIN ActMst ON ActMstAddInf.AccCode = ActMst.AccCode WHERE     ActMst.AccCode='{0}' order by ActMst.AccName;", TextPartyCode.Text.Trim());
                        DataSet ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextPartyCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                            TextPartyName.Text = ds.Tables[0].Rows[0]["Party Name"].ToString();


                            TextDeptCode.Focus();
                        }
                        else
                            ShowHelpWindow(Query);
                        e.Handled = true;
                    }
                    if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                    {
                        e.SuppressKeyPress = true;
                        SelectNextControl(ActiveControl, false, true, true, true);
                    }

                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }

                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, true, true, true, true);

                }

            }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void TextDeptCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    const string Query = "SELECT     DeptDesc, DeptCode FROM         deptMst order by DeptDesc;";
                    MyValidationProvider.ValidationMode = ValidationMode.Manual;
                    MyValidationProvider.RemoveControlError(TextDeptCode);
                    CurrentControl = "TextDeptCode";

                    if (TextDeptCode.Text.Trim().Length == 0)
                    {
                        //Display Help Window
                        ShowHelpWindow(Query);
                        e.Handled = true;
                    }
                    else
                    {
                        //Checking whether Value  is Existing or not!
                        string query = String.Format("SELECT     DeptDesc, DeptCode FROM         deptMst  where  DeptCode='{0}' order by DeptDesc", TextDeptCode.Text.Trim());
                        DataSet ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextDeptCode.Text = ds.Tables[0].Rows[0]["DeptCode"].ToString();
                            TextDeptName.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();
                            TextProdCode.Focus();
                        }
                        else
                            ShowHelpWindow(Query);
                        e.Handled = true;
                    }
                    if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                    {
                        e.SuppressKeyPress = true;
                        SelectNextControl(ActiveControl, false, true, true, true);
                    }

                }
                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, false, true, true, true);
                }

                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
                {
                    e.SuppressKeyPress = true;
                    SelectNextControl(ActiveControl, true, true, true, true);

                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }


        private void TextProdCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextProdCode";
                var Query = "SELECT   * from V_PrdMst4PO ORDER BY [Product Name]; ";
                if (TextProdCode.Text.Trim().Length == 0)
                {
                    ShowHelpWindow(Query);
                }

                else
                {
                    try
                    {
                        if (!currentprodCode.Equals(TextProdCode.Text))
                        {
                            var query = String.Format("SELECT * from V_PrdMst4PO  where   Code='{0}' ORDER BY [Product Name];", TextProdCode.Text.Trim());

                            var ds = ProjectFunctions.GetDataSet(query);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                TextProdCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                                TextProdDesc.Text = ds.Tables[0].Rows[0]["Product Name"].ToString();
                                TextProdAsgnCode.Text = ds.Tables[0].Rows[0]["Assigned Code"].ToString();
                                TextUOM.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                                TextProdRate.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
                                TextRem.Focus();
                            }
                            else
                            {
                                ShowHelpWindow(Query);
                            }
                        }
                        else
                        {
                            TextProdQnty.Focus();
                        }
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                    }
                }
                e.Handled = true;
            }

            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
            }
        }

        private void TextProdAmount_Enter(object sender, EventArgs e)
        {
            Decimal Amt1 = (decimal.Parse(string.IsNullOrEmpty(TextProdQnty.Text) ? "0.00" : TextProdQnty.Text.Trim()) * decimal.Parse(string.IsNullOrEmpty(TextProdRate.Text) ? "0.00" : TextProdRate.Text.Trim()));

            TextDiscountRate.Text = string.IsNullOrEmpty(TextDiscountRate.Text) ? "0.00" : TextDiscountRate.Text.Trim();
            Decimal Temp1 = Amt1 * (1 - Convert.ToDecimal(TextDiscountRate.Text) / 100);

            Decimal NetAmt = Temp1 * (1 + ((Convert.ToDecimal(SGST.Text) / 100) + (Convert.ToDecimal(CGST.Text) / 100) + (Convert.ToDecimal(IGST.Text) / 100)));


            Decimal NetAmtx = NetAmt * (1 - (Convert.ToDecimal(TextCashDiscRate.Text) / 100));

            TextProdAmount.Text = NetAmtx.ToString();
        }

        private void DtEntry_Validated(object sender, EventArgs e)
        {
            Print.Enabled = false;
            try
            {
                //if (OldDt.Date.Equals(DtEntry.DateTime.Date) && IsUpdate)
                //    if (AuthenticateFlag)
                //        TextDeptCode.Focus();
                //    else
                //    {
                //        TextAuthenticate.Focus();
                //        return;
                //    }
                //else if (!ProjectFunctions.CheckRange(DtEntry.DateTime, GlobalVariables.FinYearStartDate.Date, (DateTime.Now >= GlobalVariables.FinYearStartDate && DateTime.Now <= GlobalVariables.FinYearEndDate) ? DateTime.Now.Date : GlobalVariables.FinYearEndDate.Date))
                //{
                //    DtEntry.Focus();
                //    Error.SetError(DtEntry, "Date does not fall in Expected Range. Either You are crossign FinancialYear Limit or Crossing Today Limit.");
                //    return;
                //}
                //else if (DtEntry.DateTime.Date != DateTime.Now.Date && !AuthenticateFlag)
                //{
                //    TextAuthenticate.Visible = true;
                //    TextAuthenticate.Focus();
                //}
                //else
                //{
                //string query = "select dbo.GetPONO('" + DtEntry.DateTime.Date.ToString("yyyy-MM-dd") + "')";
                //DataSet ds = ProjectFunctions.GetDataSet(query);
                //if (ds.Tables[0].Rows.Count > 0)
                //    TextDoc_NO.Text = ds.Tables[0].Rows[0][0].ToString();
                //TextAuthenticate.Visible = false;
                //TextPartyCode.Focus();
                //}
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //Error.SetError(DtEntry);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (TextDeptCode.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Department Code can not be Empty");
                TextDeptCode.Focus();
                return;
            }
            if (TextDeptName.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Department Name can not be Empty");
                TextDeptCode.Focus();
                return;
            }
            if (TextProdCode.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Product code can not be Empty");
                TextProdCode.Focus();
                return;
            }
            if (Convert.ToDecimal(TextProdQnty.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Product Qnty can not be Zero or less than Zero");
                TextProdQnty.Focus();
                return;
            }
            if (Convert.ToDecimal(TextProdRate.Text) <= 0)
            {
                ProjectFunctions.SpeakError("Product Rate can not be Zero or less than Zero");
                TextProdRate.Focus();
                return;
            }
            //if ((Convert.ToDecimal(TextProdQnty.Text) + _Sum - _LastRec + _POQty) <= _IndentQty)
            //{

            //}
            //else
            //{
            //    TextProdQnty.Focus();
            //    return;
            //}
            if (BtnOK.Text == "&Ok")
            {
                try
                {
                    string val = Record.Compute("MAX(Id)", "Qnty>0").ToString();
                    //IndentNo = TextIndNo.Text;
                    Record.Rows.Add(TextDeptCode.Text, TextDeptName.Text, TextProdCode.Text, TextProdDesc.Text, TextUOM.Text, TextProdAsgnCode.Text, TextProdQnty.EditValue,
                    TextProdRate.EditValue, TextDutyRate.EditValue, TextTaxRate.EditValue, DtDelivery.DateTime.Date, TextDiscountRate.Text, TextCashDiscRate.Text,
                    TextProdAmount.Text, 0, string.IsNullOrEmpty(val) ? 0 : int.Parse(val) + 1, TextRem.Text, IndentNo, TextIndNo.Text, SGST.Text, CGST.Text, IGST.Text);
                    //TextIndNo.Text = "99999";
                    TextProdCode.Text = string.Empty;
                    TextProdAsgnCode.Text = string.Empty;
                    TextUOM.Text = string.Empty;
                    currentprodCode = string.Empty;
                    TextProdDesc.Text = string.Empty;
                    TextProdQnty.EditValue = "0";
                    TextProdRate.EditValue = "0";
                    TextDutyRate.EditValue = "0";
                    TextTaxRate.EditValue = "0";
                    TextDiscountRate.EditValue = "0";
                    TextCashDiscRate.EditValue = "0";
                    TextProdAmount.EditValue = "0";
                    SGST.EditValue = "0";
                    CGST.EditValue = "0";
                    IGST.EditValue = "0";
                    TextRem.Text = string.Empty;
                    DtDelivery.EditValue = DateTime.Now.Date;
                    TextRem.Text = string.Empty;
                    EntryInfo_GridCtrl.DataSource = Record;
                    TextProdCode.Focus();

                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    ProjectFunctions.SpeakError("Sir there is Some problem, Contact IT Department!");
                    TextProdCode.Focus();
                }
            }

            if (BtnOK.Text == "&Update")
            {
                try
                {
                    int rowHandle = EntryInfo_Grid.LocateByDisplayText(0, EntryInfo_Grid.Columns["Id"], id.ToString());
                    // Do the particular stuff 
                    EntryInfo_Grid.BeginDataUpdate();
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["DeptCode"], TextDeptCode.Text.Trim());
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["DeptName"], TextDeptName.Text.Trim());
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["PrdCode"], TextProdCode.Text.Trim());
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["PrdName"], TextProdDesc.Text.Trim());
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["Uom"], TextUOM.Text.Trim());
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["PrdAsgnCode"], TextProdAsgnCode.Text.Trim());
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["Qnty"], TextProdQnty.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["Rate"], TextProdRate.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["DutyRate"], TextDutyRate.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["TaxRate"], TextTaxRate.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["DeliveryDate"], DtDelivery.DateTime.Date);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["Discount"], TextDiscountRate.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["CashDisc"], TextCashDiscRate.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["Amount"], TextProdAmount.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["AID"], EntryInfo_Grid.GetRowCellValue(rowHandle, "AID"));
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["Remarks"], TextRem.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["IndId"], TextIndNo.EditValue);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["IndNo"], IndentNo);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["PoSGSTR"], SGST.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["PoCGSTR"], CGST.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, EntryInfo_Grid.Columns["PoIGSTR"], IGST.Text);
                    EntryInfo_Grid.EndDataUpdate();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    ProjectFunctions.SpeakError("Sir there is Some problem, Contact IT Department!");
                    TextProdCode.Focus();
                }

                TextIndNo.Text = "999999";
                IndentNo = string.Empty;
                TextProdCode.Text = string.Empty;
                TextProdAsgnCode.Text = string.Empty;
                TextUOM.Text = string.Empty;
                currentprodCode = string.Empty;
                TextProdDesc.Text = string.Empty;
                TextProdQnty.EditValue = "0";
                TextProdRate.EditValue = "0";
                TextDutyRate.EditValue = "0";
                TextTaxRate.EditValue = "0";
                TextDiscountRate.EditValue = "0";
                TextCashDiscRate.EditValue = "0";
                TextProdAmount.EditValue = "0";
                TextRem.Text = string.Empty;
                DtDelivery.EditValue = DateTime.Now.Date;
                TextRem.Text = string.Empty;
                SGST.EditValue = "0";
                CGST.EditValue = "0";
                IGST.EditValue = "0";
                EntryInfo_Grid.UpdateSummary();
                BtnDelete.Enabled = false;
                BtnUndo.Enabled = false;

                BtnOK.Text = "&Ok";
                TextProdCode.Focus();

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                EntryInfo_Grid.DeleteRow(selected_Record);
                Record = EntryInfo_GridCtrl.DataSource as DataTable;
                TextDeptCode.Text = string.Empty;
                TextDeptName.Text = string.Empty;
                TextIndNo.Text = "999999";
                IndentNo = string.Empty;
                TextProdCode.Text = string.Empty;
                TextProdAsgnCode.Text = string.Empty;
                TextUOM.Text = string.Empty;
                TextProdDesc.Text = string.Empty;
                TextProdQnty.EditValue = "0";
                TextProdRate.EditValue = "0";
                TextDutyRate.EditValue = "0";
                TextTaxRate.EditValue = "0"; SGST.EditValue = "0";
                CGST.EditValue = "0";
                IGST.EditValue = "0";
                TextDiscountRate.EditValue = "0";
                TextCashDiscRate.EditValue = "0";
                TextProdAmount.EditValue = "0";
                DtDelivery.EditValue = DateTime.Now.Date;
                BtnOK.Text = "&Ok";
                BtnDelete.Enabled = false;
                BtnUndo.Enabled = false;
                TextDeptCode.Focus();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("There is SomeProblem. /n" + ex.Message);
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                TextDeptCode.Text = string.Empty;
                TextDeptName.Text = string.Empty;
                TextIndNo.Text = "999999";
                TextProdCode.Text = string.Empty;
                TextProdAsgnCode.Text = string.Empty;
                TextUOM.Text = string.Empty;
                IndentNo = string.Empty;
                TextProdDesc.Text = string.Empty; SGST.EditValue = "0";
                CGST.EditValue = "0";
                IGST.EditValue = "0";
                TextProdQnty.EditValue = "0";
                TextProdRate.EditValue = "0";
                TextDutyRate.EditValue = "0";
                TextTaxRate.EditValue = "0";
                TextDiscountRate.EditValue = "0";
                TextCashDiscRate.EditValue = "0";
                TextProdAmount.EditValue = "0";
                DtDelivery.EditValue = DateTime.Now.Date;
                BtnOK.Text = "&Ok";
                BtnUndo.Enabled = false;
                BtnDelete.Enabled = false;
                TextDeptCode.Focus();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (EntryInfo_Grid.RowCount > 0)
            {
                using (SqlConnection con = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand() { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[dbo].[SP_INSERT_UPDATE_POMST_GST]" };
                    SqlTransaction transaction = con.BeginTransaction("SaveTransaction");
                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add("@vPomNo", SqlDbType.VarChar, 8).Value = TextDoc_NO.Text;
                    cmd.Parameters.Add("@vPomDate", SqlDbType.SmallDateTime).Value = DtEntry.DateTime.Date;
                    cmd.Parameters.Add("@vPomAccCode", SqlDbType.VarChar, 6).Value = TextPartyCode.Text;
                    cmd.Parameters.Add("@vPomRefno", SqlDbType.VarChar, 20).Value = TextRefNo.Text;
                    cmd.Parameters.Add("@vPomPymntTerms", SqlDbType.VarChar, 100).Value = TextPaymentTerms.Text;
                    cmd.Parameters.Add("@vPomDlryTerms", SqlDbType.VarChar, 100).Value = TextDeliveryTerms.Text;
                    cmd.Parameters.Add("@vPomNors", SqlDbType.Int).Value = int.Parse(EntryInfo_Grid.Columns["PrdCode"].SummaryItem.SummaryValue.ToString());
                    cmd.Parameters.Add("@vPomAprxVal", SqlDbType.Float).Value = Math.Round(float.Parse(EntryInfo_Grid.Columns["Amount"].SummaryItem.SummaryValue.ToString()), 2);
                    cmd.Parameters.Add("@vPomFYear", SqlDbType.VarChar, 4).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                    cmd.Parameters.Add("@vPomOctroi", SqlDbType.VarChar, 50).Value = TextOctroi.EditValue.ToString();
                    cmd.Parameters.Add("@vPomFreight", SqlDbType.VarChar, 40).Value = TextFrieght.EditValue.ToString();
                    cmd.Parameters.Add("@vPomDeliveryAt", SqlDbType.VarChar, 35).Value = TextDeliveryAt.Text;
                    cmd.Parameters.Add("@vPomInsurance", SqlDbType.VarChar, 40).Value = TextInsurance.Text;
                    cmd.Parameters.Add("@vPomRemarks", SqlDbType.VarChar, 50).Value = TextRemarks.Text;
                    cmd.Parameters.Add("@vPomBrokerCD", SqlDbType.VarChar, 6).Value = TextBroker.Text;
                    cmd.Parameters.Add("@vPomDfDate", SqlDbType.SmallDateTime, 50).Value = DateTime.Now;
                    cmd.Parameters.Add("@vPomUserId", SqlDbType.VarChar, 8).Value = GlobalVariables.CurrentUser;
                    cmd.Parameters.Add("@vPomid", SqlDbType.Int).Value = 0;
                    cmd.Parameters["@vPomid"].Direction = ParameterDirection.InputOutput;
                    cmd.Parameters["@vPomNo"].Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.Add("@vIsUpdate", SqlDbType.VarChar, 1).Value = IsUpdate ? "Y" : "N";
                    try
                    {
                        cmd.ExecuteNonQuery();
                        AutoId = int.Parse(cmd.Parameters["@vPomid"].Value.ToString());
                        TextDoc_NO.Text = cmd.Parameters["@vPomNo"].Value.ToString();
                        if (IsUpdate)
                        {
                            String Query = String.Format("delete from  PoData  where PodNo='{0}';", TextDoc_NO.Text);
                            Query += String.Format("delete from  [dbo].[POTacData] WHERE [TacDataPo]='{0}';", TextDoc_NO.Text);
                            cmd.Parameters.Clear();
                            cmd.CommandText = Query;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }
                        Record.AcceptChanges();
                        foreach (DataRow Dr in Record.Rows)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = "[dbo].[SP_INSERT_UPDATE_PODATA_GST]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@vPoDFYear", SqlDbType.VarChar, 4).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                            cmd.Parameters.Add("@vPoDNo", SqlDbType.VarChar, 8).Value = TextDoc_NO.Text;
                            cmd.Parameters.Add("@vPoDSNo", SqlDbType.SmallInt).Value = int.Parse(Dr["Id"].ToString());
                            cmd.Parameters.Add("@vPoDDate", SqlDbType.SmallDateTime).Value = DtEntry.DateTime.Date;
                            cmd.Parameters.Add("@vPoDAccCode", SqlDbType.VarChar, 6).Value = TextPartyCode.Text;
                            cmd.Parameters.Add("@vPoDItemCode", SqlDbType.Int).Value = int.Parse(Dr["PrdCode"].ToString());
                            cmd.Parameters.Add("@vPoDItemQty", SqlDbType.Float).Value = Math.Round(float.Parse(Dr["Qnty"].ToString()), 2);
                            cmd.Parameters.Add("@vPoDItemQtyUom", SqlDbType.VarChar, 4).Value = Dr["UOM"].ToString();
                            cmd.Parameters.Add("@vPoDItemrate", SqlDbType.Float).Value = Math.Round(float.Parse(Dr["Rate"].ToString()), 2);
                            cmd.Parameters.Add("@vPoDItemRateUom", SqlDbType.Float).Value = 0;
                            cmd.Parameters.Add("@vPoDItemAQty", SqlDbType.Float).Value = 0;
                            cmd.Parameters.Add("@vPoDItemAQtyUom", SqlDbType.VarChar, 4).Value = string.Empty;
                            cmd.Parameters.Add("@vPoDItemAQtyRemks", SqlDbType.VarChar, 10).Value = string.Empty;
                            cmd.Parameters.Add("@vPoDItemAtrue", SqlDbType.VarChar, 1).Value = "N";
                            cmd.Parameters.Add("@vPoDItemReqDDate", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(Dr["DeliveryDate"]);
                            cmd.Parameters.Add("@vPoDItemDutyRate", SqlDbType.Float).Value = Math.Round(float.Parse("0"), 2);
                            cmd.Parameters.Add("@vPoDItemTaxRate", SqlDbType.Float).Value = Math.Round(float.Parse("0"), 2);
                            cmd.Parameters.Add("@vPoDItemDiscRate", SqlDbType.Float).Value = Math.Round(float.Parse(Dr["Discount"].ToString()), 2);
                            cmd.Parameters.Add("@vPoDItemCDiscRate", SqlDbType.Float).Value = Math.Round(float.Parse(Dr["CashDisc"].ToString()), 2);

                            cmd.Parameters.Add("@PoSGSTR", SqlDbType.Decimal).Value = Math.Round(decimal.Parse(Dr["PoSGSTR"].ToString()), 2);
                            cmd.Parameters.Add("@PoCGSTR", SqlDbType.Decimal).Value = Math.Round(decimal.Parse(Dr["PoCGSTR"].ToString()), 2);
                            cmd.Parameters.Add("@PoIGSTR", SqlDbType.Decimal).Value = Math.Round(decimal.Parse(Dr["PoIGSTR"].ToString()), 2);

                            cmd.Parameters.Add("@vPoDItemNetrate", SqlDbType.Float).Value = Math.Round((float.Parse(Dr["Amount"].ToString()) / float.Parse(Dr["Qnty"].ToString())), 2);
                            cmd.Parameters.Add("@vPoDItemQtyRcvd", SqlDbType.Float).Value = 0;
                            cmd.Parameters.Add("@vPoUserID", SqlDbType.VarChar, 8).Value = GlobalVariables.CurrentUser;
                            cmd.Parameters.Add("@vPoFdDate", SqlDbType.SmallDateTime).Value = IsUpdate ? DtEntry.DateTime.Date : DateTime.Now.Date;
                            cmd.Parameters.Add("@vPoUpDate", SqlDbType.SmallDateTime).Value = DateTime.Now.Date;
                            cmd.Parameters.Add("@vPoUpTag", SqlDbType.VarChar, 1).Value = "N";
                            if (Dr["IndId"].ToString() == string.Empty)
                            {
                                Dr["IndId"] = 0;
                            }
                            cmd.Parameters.Add("@vPoIndId", SqlDbType.Int).Value = Int32.Parse(Dr["IndId"].ToString());
                            cmd.Parameters.Add("@vPoIndNo", SqlDbType.VarChar, 15).Value = Dr["IndNo"].ToString().PadLeft(5, '0');
                            cmd.Parameters.Add("@vPoIndDeptCode", SqlDbType.VarChar, 6).Value = Dr["DeptCode"].ToString();
                            cmd.Parameters.Add("@vPomID", SqlDbType.Float).Value = Math.Round(float.Parse(AutoId.ToString()));
                            cmd.Parameters.Add("@vPoID", SqlDbType.Int).Value = int.Parse(Dr["AID"].ToString());
                            cmd.Parameters.Add("@vPoRemarks", SqlDbType.VarChar, 120).Value = Dr["Remarks"].ToString();
                            cmd.ExecuteNonQuery();
                        }
                        foreach (DataRow Dr in TacData.Rows)
                        {
                            if (Dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Insert into POTacData(TacDataPo,TacId) values('" + TextDoc_NO.Text + "','" + Dr["TacId"] + "')";
                                cmd.CommandType = CommandType.Text;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        if (!(IsUpdate))
                        {
                            TextPartyCode.Text = string.Empty;
                            TextPartyName.Text = string.Empty;
                            TextDeptCode.Text = string.Empty;
                            TextDeptName.Text = string.Empty;
                            TextIndNo.Text = "999999";
                            TextProdCode.Text = string.Empty;
                            TextProdAsgnCode.Text = string.Empty;
                            TextUOM.Text = string.Empty;
                            TextProdDesc.Text = string.Empty;
                            TextProdQnty.EditValue = "0";
                            TextProdRate.EditValue = "0";
                            TextDutyRate.EditValue = "0";
                            TextTaxRate.EditValue = "0";
                            TextDiscountRate.EditValue = "0";
                            TextCashDiscRate.EditValue = "0";
                            TextProdAmount.EditValue = "0";
                            CGST.Text = "0";
                            SGST.Text = "0";
                            IGST.Text = "0";

                            BtnOK.Text = "&Ok";
                            EntryInfo_GridCtrl.DataSource = null;
                            Record = new DataTable();
                            SetMyControls();
                            BtnDelete.Enabled = false;
                            BtnUndo.Enabled = false;
                            TextAuthenticate.Text = string.Empty;
                            DtEntry.Focus();
                            DtEntry.EditValue = DateTime.Now.Date;
                            DtDelivery.EditValue = DateTime.Now.Date;
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("Data Saved");
                            this.Dispose();

                        }
                    }
                    catch (Exception ex)
                    {
                        ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);

                        // Attempt to roll back the transaction. 
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            ProjectFunctions.SpeakError("Something Wrong. \n Roll Back Failed." + ex2.Message);
                        }
                    }
                    finally { Save.Enabled = false; }
                }
            }
            else
            {
                ProjectFunctions.SpeakError("No Records To Save.");
                Save.Enabled = false;
                Print.Enabled = false;
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

        private void TextDutyRate_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }

            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);

            }
        }

        private void EntryInfo_GridCtrl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                BtnUndo.Enabled = true;
                BtnDelete.Enabled = true;
                int[] selRows = EntryInfo_Grid.GetSelectedRows();
                DataRowView selRow = (DataRowView)(EntryInfo_Grid.GetRow(selRows[0]));
                ThisRecord = selRow.Row;
                //Fill Whole Data
                currentprodCode = ThisRecord["PrdCode"].ToString();
                id = int.Parse(ThisRecord["Id"].ToString());
                TextDeptCode.Text = ThisRecord["DeptCode"].ToString();
                TextDeptName.Text = ThisRecord["DeptName"].ToString();
                TextProdCode.Text = ThisRecord["PrdCode"].ToString();
                TextProdDesc.Text = ThisRecord["PrdName"].ToString();
                TextProdAsgnCode.Text = ThisRecord["PrdAsgnCode"].ToString();
                TextUOM.Text = ThisRecord["Uom"].ToString();
                TextProdQnty.EditValue = ThisRecord["Qnty"].ToString();
                TextProdRate.EditValue = ThisRecord["Rate"].ToString();
                TextDutyRate.EditValue = ThisRecord["DutyRate"].ToString();
                TextTaxRate.EditValue = ThisRecord["TaxRate"].ToString();
                DtDelivery.EditValue = ThisRecord["DeliveryDate"];
                TextDiscountRate.EditValue = ThisRecord["Discount"].ToString();
                TextCashDiscRate.EditValue = ThisRecord["CashDisc"].ToString();
                TextProdAmount.EditValue = ThisRecord["Amount"].ToString();
                TextRem.EditValue = ThisRecord["Remarks"].ToString();
                TextIndNo.Text = ThisRecord["IndId"].ToString();
                IndentNo = ThisRecord["IndNo"].ToString();

                SGST.Text = ThisRecord["PoSGSTR"].ToString();
                CGST.Text = ThisRecord["PoCGSTR"].ToString();
                IGST.Text = ThisRecord["PoIGSTR"].ToString();

                BtnDelete.Enabled = true;
                BtnUndo.Enabled = true;
                BtnOK.Text = "&Update";
                TextProdCode.Focus();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void EntryInfo_Grid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (EntryInfo_GridCtrl.DataSource != null)
                {
                    selected_Record = e.FocusedRowHandle;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void POTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
        }

        private void Validate_Click(object sender, EventArgs e)
        {
            if (DtEntry.DateTime.Date.Equals(DateTime.Now.Date))
            {
                AuthenticateFlag = true;
            }
            Errorflag = true;
            MyValidationProvider.Validate();
            if (MyValidationProvider.GetInvalidControls().Count > 0)
                Errorflag = false;

            //if (TextDoc_NO.Text == "")
            //{
            //    ProjectFunctions.SpeakError("Doc No. can not be blank.");
            //    DtEntry.Focus();
            //    return;
            //}
            if (TextPartyCode.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Party Code can not be blank.");
                TextPartyCode.Focus();
                return;
            }
            if (EntryInfo_Grid.RowCount == 0)
            {
                ProjectFunctions.SpeakError("No Records in Grid.");
                TextPartyCode.Focus();
                return;
            }

            if (!AuthenticateFlag)
            {
                TextAuthenticate.Visible = true;
                TextAuthenticate.Focus();
                return;
            }
            //if (TacData.Rows.Count == 0)
            //{
            //    ProjectFunctions.SpeakError("You have not selected any term and Condition.\n Please Make sure your Information is correct.");
            //    POTabControl.SelectedTabPage = Other_TbPg;
            //    return;
            //}
            //if (TacData.Select("Select<>False").Count() <= 0)
            //{
            //    ProjectFunctions.SpeakError("You have not selected any term and Condition.\n Please Make sure your Information is correct.");
            //    return;
            //}

            //string query = String.Format("SELECT    ActMst.AccName AS 'Party Name',ActMst.AccCode as Code, ActMstAddInf.AccPSTCST  FROM         ActMstAddInf RIGHT OUTER JOIN ActMst ON ActMstAddInf.AccCode = ActMst.AccCode WHERE    ActMst.AccCode='{0}' order by ActMst.AccName;", TextPartyCode.Text.Trim());
            //using (DataSet ds = ProjectFunctions.GetDataSet(query))
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //    }
            //    else
            //    {
            //        ProjectFunctions.SpeakError("Not a Valid Party Code.");
            //        TextPartyCode.Focus();
            //        return;
            //    }
            //}

            //query = String.Format("select BCode as Code, BName as Agent from brokermst where   BCode='{0}' ;", TextBroker.Text.Trim());

            //using (DataSet ds = ProjectFunctions.GetDataSet(query))
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //    }
            //    else
            //    {
            //        ProjectFunctions.SpeakError("Not a Valid Broker/Agent Code.");
            //        TextBroker.Focus();
            //        return;
            //    }



            if (Errorflag && AuthenticateFlag)
                Save.Enabled = true;
            else
                Save.Enabled = false;
        }

        private void Pend_Po_Btn_Click(object sender, EventArgs e)
        {
            CurrentControl = "Pen_Po_BTn";
            ShowHelpWindow(string.Format("sp_PendingIndent '{0}' ", TextProdCode.Text));
        }

        private void TextProdQnty_Enter(object sender, EventArgs e)
        {
            //using (var Ds = ProjectFunctions.GetDataSet(String.Format("[dbo].[sp_StockInHand] '{0}','{1}'", TextProdCode.Text, DateTime.Now.Date.ToString("yyyy-MM-dd"))))
            //{
            //    if (Ds != null)
            //    {
            //        if (Ds.Tables[0].Rows.Count > 0)
            //        {
            //            TxtStock.Text = Ds.Tables[0].Rows[0][0].ToString();
            //        }
            //        else
            //        {
            //            TxtStock.Text = "0";
            //        }
            //    }
            //}
        }

        private void TextAuthenticate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Btn_Term_Click(object sender, EventArgs e)
        {
            CurrentControl = "Btn_Term";
            if (IsUpdate)
                ShowHelpWindow("SELECT     TacMst.TacId, TacMst.TacDesc FROM         TacMst INNER JOIN POTacData ON TacMst.TacId = POTacData.TacId WHERE     (POTacData.TacDataPo = '13198001'); select * from TacMst");
            else
                ShowHelpWindow("Select * from TacMst");

        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void TextBroker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
            {
                //  HelpGridCtrl.Width = 400;

                CurrentControl = "TextBroker";
                string Query = "select BCode as Code, BName as Agent from brokermst; ";
                if (TextBroker.Text.Trim().Length == 0)
                {
                    //Display Help Window
                    //Display Help Window

                    ShowHelpWindow(Query);
                }

                else
                {

                    string query = String.Format("select BCode as Code, BName as Agent from brokermst where   BCode='{0}' ;", TextBroker.Text.Trim());

                    DataSet ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextBroker.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                        textEdit1.Text = ds.Tables[0].Rows[0]["Agent"].ToString();
                        TextRefNo.Focus();
                    }
                    else
                    {
                        // Display Help Window
                        ShowHelpWindow(Query);
                    }
                }
                e.Handled = true;
            }

            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                //MaterialRecp_TabCtrl.SelectedTabPage = DocInfo_TbPg;
                //TextRemarks.Focus();

            }
        }

        private void TextDeptCode_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Save.Enabled = false;
        }

        private void DtEntry_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Save.Enabled = false;
            AuthenticateFlag = false;

        }

        private void TextIndId_Validating(object sender, CancelEventArgs e)
        {
            if (TextIndNo.Text == "999999" || TextIndNo.Text.Trim() == string.Empty)
            {
                Pend_Po_Btn_Click(null, null);
                return;
            }
            else
            {
                using (DataSet Ds = ProjectFunctions.GetDataSet(string.Format("sp_POIndentStock '{0}','{1}'", TextProdCode.Text, TextIndNo.Text)))
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        _Sum = 0;
                        _LastRec = 0;
                        _IndentQty = 0;
                        _POQty = 0;

                        for (int i = 0; i < EntryInfo_Grid.RowCount; i++)
                        {
                            DataRow Dr = EntryInfo_Grid.GetDataRow(i);
                            if (Dr["PrdCode"].ToString() == TextProdCode.Text && Dr["IndId"].ToString() == TextIndNo.Text)
                                _Sum += Convert.ToDecimal(Dr["Qnty"]);
                        }

                        if (BtnOK.Text == "&Update")
                        {
                            _LastRec = Convert.ToDecimal(ThisRecord["Qnty"].ToString());
                        }

                        _IndentQty = Convert.ToDecimal(Ds.Tables[0].Rows[0]["IndentQty"]);
                        _POQty = Convert.ToDecimal(Ds.Tables[0].Rows[0]["POQty"]);


                    }
                    else
                    {
                        Pend_Indent_Btn.PerformClick();
                    }
                }

            }
        }

        private void TextProdQnty_Validating(object sender, CancelEventArgs e)
        {
            if (TextProdQnty.Text == string.Empty)
                e.Cancel = true;

            TextProdRate.Focus();
        }

        private void DtEntry_Validating(object sender, CancelEventArgs e)
        {

        }

        private void POTabControl_Click(object sender, EventArgs e)
        {

        }

        private void TextDeliveryAt_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}