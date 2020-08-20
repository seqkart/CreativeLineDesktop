using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frm_MaterialReciept_Add_Update_GST : XtraForm, IDisposable
    {

        public string CurrentControl { get; set; }
        public DateTime MMDocDate { get; set; }
        public string MMDocNo { get; set; }
        public int MMID { get; set; }
        public DateTime FStartDate { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsUpdate_View { get; set; }
        public string _MRI { get; set; }
#pragma warning disable CS0169 // The field 'frm_MaterialReciept_Add_Update_GST.DocID' is never used
        private string DocID;
#pragma warning restore CS0169 // The field 'frm_MaterialReciept_Add_Update_GST.DocID' is never used
#pragma warning disable CS0169 // The field 'frm_MaterialReciept_Add_Update_GST.DocLoc' is never used
        private string DocLoc;
#pragma warning restore CS0169 // The field 'frm_MaterialReciept_Add_Update_GST.DocLoc' is never used

        private string oldtDocNum;
        DataTable Record = new DataTable();
        string currentprodCode = string.Empty;
#pragma warning disable CS0169 // The field 'frm_MaterialReciept_Add_Update_GST.selected_Record' is never used
        private int selected_Record;
#pragma warning restore CS0169 // The field 'frm_MaterialReciept_Add_Update_GST.selected_Record' is never used

        DataRow ThisRecord;
        int id = 0;
        bool Errorflag = true;
        private DateTime VarOldDOCDt;
        private string VarOldDocNo;
        private string VarOldDocType;
        private bool AuthenticateFlag = false;


        private int __rohandle;
        private decimal oldPOqntyord;
        private decimal oldPOqntyRcvd;
#pragma warning disable CS0649 // Field 'frm_MaterialReciept_Add_Update_GST.oldprodpono' is never assigned to, and will always have its default value null
        private string oldprodpono;
#pragma warning restore CS0649 // Field 'frm_MaterialReciept_Add_Update_GST.oldprodpono' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'frm_MaterialReciept_Add_Update_GST.oldprdqnty' is never assigned to, and will always have its default value 0
        private decimal oldprdqnty;
#pragma warning restore CS0649 // Field 'frm_MaterialReciept_Add_Update_GST.oldprdqnty' is never assigned to, and will always have its default value 0
#pragma warning disable CS0414 // The field 'frm_MaterialReciept_Add_Update_GST.X' is assigned but its value is never used
        private bool X;
#pragma warning restore CS0414 // The field 'frm_MaterialReciept_Add_Update_GST.X' is assigned but its value is never used
        private bool Flag;
        private string VarCostId;
        private bool xtraflag;


        public frm_MaterialReciept_Add_Update_GST()
        {
            InitializeComponent();
        }

#pragma warning disable CS0108 // 'frm_MaterialReciept_Add_Update_GST.Dispose()' hides inherited member 'Component.Dispose()'. Use the new keyword if hiding was intended.
        public void Dispose()
#pragma warning restore CS0108 // 'frm_MaterialReciept_Add_Update_GST.Dispose()' hides inherited member 'Component.Dispose()'. Use the new keyword if hiding was intended.
        {
            //if (DT4GridOrignal != null)
            //{
            //    DT4GridOrignal.Dispose();
            //    if (Record != null)
            //        Record.Dispose();
            //    Dispose(true);
            //}
        }

        private void SetMyControls()
        {

            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.GirdViewVisualize(EntryInfo_Grid);
            ProjectFunctions.GirdViewVisualize(HelpGrid);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            // ProjectFunctions.TextBoxVisualize(Basic_Info_GrpCtrl);
            ProjectFunctions.TextBoxVisualize(panelControl2);
            // ProjectFunctions.ButtonVisualize(Basic_Info_GrpCtrl);
            ProjectFunctions.ButtonVisualize(panelControl2);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            (TextAuthenticate.Control as TextBox).UseSystemPasswordChar = true;
            // ProjectFunctions.GroupCtrlVisualize(Basic_Info_GrpCtrl);


        }

        private void SetMyValidations()
        {
            ConditionValidationRule FinancialYearCondition = new ConditionValidationRule() { ConditionOperator = ConditionOperator.Between, ErrorText = "Either You are Crossing the FinancialYear Limit or CurrentDate Limit .", Value1 = GlobalVariables.FinYearStartDate, Value2 = (DateTime.Now >= GlobalVariables.FinYearStartDate && DateTime.Now <= GlobalVariables.FinYearEndDate) ? DateTime.Now.Date : GlobalVariables.FinYearEndDate.Date };
            MyValidationProvider.SetValidationRule(DtEntry, FinancialYearCondition);
            ConditionValidationRule IsBlank = new ConditionValidationRule() { ConditionOperator = ConditionOperator.IsNotBlank, ErrorText = "Party Code Can't be Blank." };
            MyValidationProvider.SetValidationRule(TextSuppCode, IsBlank);
            ConditionValidationRule IsCash = new ConditionValidationRule() { ConditionOperator = ConditionOperator.AnyOf, ErrorText = "This value is not valid" };
            IsCash.Values.Add("I");
            IsCash.Values.Add("P");
            IsCash.Values.Add("C");
            MyValidationProvider.SetValidationRule(TextIsCash, IsCash);
            MyValidationProvider.SetValidationRule(TextDocNumber, IsBlank);
            ConditionValidationRule MoreThanZero = new ConditionValidationRule() { ConditionOperator = ConditionOperator.Greater, ErrorText = "This value is not valid", Value1 = new decimal(new int[] { 0, 0, 0, 131072 }) };
            MyValidationProvider.SetValidationRule(TextValueOfGoods, MoreThanZero);
            MyValidationProvider.SetValidationRule(TextInvAmount, MoreThanZero);
        }

        private void Setting4Updation()
        {
            try
            {
                string Query = string.Format("Sp_GetData4MRR_MRI_UPDGST '{0}','{1:yyyy-MM-dd}','" + _MRI + "';", MMDocNo, MMDocDate);
                using (DataSet ds = ProjectFunctions.GetDataSet(Query))
                    if (ds != null)
                    {
                        //Do Data binding
                        BindMyData.DataSource = ds.Tables[0];

                        TextEntryDocType.DataBindings.Add("EditValue", BindMyData, "MmDocType");
                        DtEntry.DataBindings.Add("EditValue", BindMyData, "MmDocDate");
                        TextDoc_NO.DataBindings.Add("EditValue", BindMyData, "MmDocNo");
                        VarOldDocNo = TextDoc_NO.Text;
                        VarOldDOCDt = DtEntry.DateTime.Date;
                        VarOldDocType = TextEntryDocType.Text;
                        TextBehalfOf.DataBindings.Add("EditValue", BindMyData, "MmBehalfOfTag");
                        TextSuppCode.DataBindings.Add("EditValue", BindMyData, "MmAccCode");
                        TextSuppDesc.DataBindings.Add("EditValue", BindMyData, "AccName");
                        TextDocType.DataBindings.Add("EditValue", BindMyData, "MmRDocType");
                        TextDocNumber.DataBindings.Add("EditValue", BindMyData, "MmRDocNo");
                        PurchaseType.DataBindings.Add("EditValue", BindMyData, "MMPartyType");
                        TextISLC.DataBindings.Add("EditValue", BindMyData, "MmMrType");
                        TextChoiceRCO.DataBindings.Add("EditValue", BindMyData, "MmSplTag");
                        //TextIsCash.DataBindings.Add("EditValue", BindMyData, "MmCashTag");

                        //TextCreditCode.DataBindings.Add("EditValue", BindMyData, "MmCPartyCode");
                        TextAsPerBill.DataBindings.Add("EditValue", BindMyData, "MmGrsAmtasb");
                        TextSuppGST.DataBindings.Add("EditValue", BindMyData, "MMSuppGSTNo");

                        TextPackingChgs.DataBindings.Add("EditValue", BindMyData, "MMDiscAmt");
                        TextSGSTAmt.DataBindings.Add("EditValue", BindMyData, "MMSGSTAmt");
                        TextCGSTAmt.DataBindings.Add("EditValue", BindMyData, "MMCGSTAmt");
                        TextIGSTAmt.DataBindings.Add("EditValue", BindMyData, "MMIGSTAmt");


                        DtDocDate.DataBindings.Add("EditValue", BindMyData, "MmRDocdate");
                        TextValueOfGoods.DataBindings.Add("EditValue", BindMyData, "MmRDocGrsAmt");
                        TextTaxableAmt.DataBindings.Add("EditValue", BindMyData, "MmRDocTxbAmt");

                        TextInvAmount.DataBindings.Add("EditValue", BindMyData, "MmRDocNetAmt");
                        TextFrtCode.DataBindings.Add("EditValue", BindMyData, "MmFrtPost");
                        TextFreightAmt.DataBindings.Add("EditValue", BindMyData, "MmFreightAmt");
                        TextRemarks.DataBindings.Add("EditValue", BindMyData, "MmRemarks");
                        TextRound.DataBindings.Add("EditValue", BindMyData, "MmOtherAmt");
                        TextDescGoods.DataBindings.Add("EditValue", BindMyData, "MmMatItemDesc");
                        TextTransName.DataBindings.Add("EditValue", BindMyData, "MmTransName");
                        TextGrNo.DataBindings.Add("EditValue", BindMyData, "MmGRNo");
                        TextVehNo.DataBindings.Add("EditValue", BindMyData, "MmVehNo");
                        oldtDocNum = ds.Tables[0].Rows[0]["MmRDocNo"].ToString();

                        if (ds.Tables[0].Rows[0]["MmCashTag"].ToString().Equals("I") || ds.Tables[0].Rows[0]["MmCashTag"].ToString().Equals("C"))
                        {
                            TextIsCash.DataBindings.Add("EditValue", BindMyData, "MmCashTag");
                            TextCreditCode.Enabled = true;

                            TextCreditCode.DataBindings.Add("EditValue", BindMyData, "MmCPartyCode");
                            TextCreditDesc.DataBindings.Add("EditValue", BindMyData, "CreditAcName");
                        }
                        else
                        {
                            TextIsCash.Text = "P";
                            TextCreditCode.Enabled = false;
                        }

                        try
                        {
                            EntryInfo_GridCtrl.DataSource = ds.Tables[1];
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        // TextSuppCode.Enabled = false;
                        DtEntry.Enabled = false;
                        TextChoiceRCO.Focus();
                        Text = "Material Receipt Updation";
                    }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Either No Record or Unable to Fetch Data.\n" + ex.Message);
            }
        }

        private void frm_MaterialRecieptInfo_Load(object sender, EventArgs e)
        {
            SetMyControls();
            SetMyValidations();
            // TODO: This line of code loads data into the 'tr.V_MrDataPurchase' table. You can move, or remove it, as needed.
            TextEntryDocType.Text = _MRI;
            if (_MRI == "SVC")
            {
                labelControl34.Visible = false;
                labelControl6.Visible = false;
                labelControl38.Visible = false;
                labelControl35.Visible = false;
                labelControl54.Visible = false;
                // labelControl17.Visible = false;
                labelControl40.Visible = false;
                labelControl36.Visible = false;
                TextChoiceRCO.Text = "O";
                TextChoiceRCO.Visible = false;
                TextBehalfOf.Visible = false;
                TxtFrtDesc.Visible = false;
                TextFrtCode.Visible = false;
                TextGrNo.Visible = false;
                TextTransName.Visible = false;
                TextVehNo.Visible = false;
                TextDescGoods.Visible = false;
                // TextRemarks.Visible=false;

                labelControl7.Text = "SVC Code";
                labelControl28.Visible = false;
                labelControl49.Visible = false;
                labelControl10.Visible = false;
                labelControl11.Visible = false;
                labelControl39.Visible = false;
                labelControl13.Text = "SA Code";
                labelControl8.Text = "   Qty.";
                Pend_Po_Btn.Visible = false;
                TextPOStock.Visible = false;
                TextUOM.Visible = false;
                textEdit1.Visible = false;
                TextProdPONO.Visible = false;
                BtnZoomPrd.Visible = false;
                TextStockInHand.Visible = false;
                TextProdAsgnCode.Visible = false;
                this.TextProdQnty.Properties.Mask.EditMask = "N2";
                this.TextProdRate.Properties.Mask.EditMask = "N2";

            }

            DtEntry.EditValue = (DateTime.Now >= GlobalVariables.FinYearStartDate && DateTime.Now <= GlobalVariables.FinYearEndDate) ? DateTime.Now.Date : GlobalVariables.FinYearEndDate.Date;
            DtDocDate.EditValue = (DateTime.Now >= GlobalVariables.FinYearStartDate && DateTime.Now <= GlobalVariables.FinYearEndDate) ? DateTime.Now.Date : GlobalVariables.FinYearEndDate.Date;
            //FStartDate = new DateTime(2013, 04, 01);
            this.Text = _MRI == "SVC" ? "Service Receipt Addition" : "Material Receipt Addition";
            if (!IsUpdate)
            { EntryInfo_GridCtrl.DataSource = ProjectFunctions.GetDataSet("Select * From V_MrDataPurchase Where 1=2").Tables[0]; }
            if (IsUpdate) { Setting4Updation(); }
            if (IsUpdate_View)
            {
                //    Menu_ToolStrip.Enabled = false; 
                TextAuthenticate.Enabled = false;
                Validate.Enabled = false;
                Print.Enabled = false; Save.Enabled = false;
            }
        }

        private void TextSuppCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Down)
            {
                MyValidationProvider.ValidationMode = ValidationMode.Manual;
                MyValidationProvider.RemoveControlError(TextSuppCode);
                CurrentControl = "TextSuppCode";
                string Query = string.Empty;

                Query = "Select * From (SELECT ActMst.[AccName] as 'Supplier Name', ActMst.[AccCode] as 'Supplier Code',AccLcTag Tag, IsNull(ActMst.AccGSTType,'URGD') PurchaseType ,IsNull(AccGSTNo,'') AccGSTNo  FROM  [ActMst] Inner Join ActMStAddInf on ActMSt.AccCode=ActMStAddInf.AccCode  Union All";
                Query += " SELECT         AccName as 'Supplier Name', AccCode  as 'Supplier Code',  AccLcTag Tag,   IsNull(AccGSTType,'URGD') PurchaseType ,IsNull(AccGSTNo,'') AccGSTNo  FROM            ActMstSvc) as X";

                if (TextSuppCode.Text.Trim().Length == 0)
                    ShowHelpWindow(Query);
                else
                {
                    string query = string.Empty;

                    query = String.Format("Select * from (SELECT ActMst.[AccName] as 'Supplier Name', ActMst.[AccCode] as 'Supplier Code',AccLcTag Tag, IsNull(ActMst.AccGSTType,'URGD') PurchaseType ,IsNull(AccGSTNo,'') AccGSTNo FROM  [ActMst] Inner Join ActMStAddInf on ActMSt.AccCode=ActMStAddInf.AccCode   Union All ", TextSuppCode.Text.Trim());
                    query += "SELECT         AccName as 'Supplier Name', AccCode  as 'Supplier Code', AccLcTag Tag,   IsNull(AccGSTType,'URGD') PurchaseType ,IsNull(AccGSTNo,'') AccGSTNo  FROM            ActMstSvc Where AccCode='" + TextSuppCode.Text.Trim() + "') as X";

                    DataSet ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextSuppCode.Text = ds.Tables[0].Rows[0]["Supplier Code"].ToString();
                        TextSuppDesc.Text = ds.Tables[0].Rows[0]["Supplier Name"].ToString();
                        TextSuppGST.Text = ds.Tables[0].Rows[0]["AccGSTNo"].ToString();
                        TextISLC.Text = ds.Tables[0].Rows[0]["Tag"].ToString();
                        PurchaseType.Text = ds.Tables[0].Rows[0]["PurchaseType"].ToString();
                        if (PurchaseType.Text == "URGD")
                        {
                            TextSGSTAmt.Text = "0.00";
                            TextCGSTAmt.Text = "0.00";
                            TextIGSTAmt.Text = "0.00";
                            TextIGSTAmt.EditValue = "0.00";
                            TextCGSTAmt.EditValue = "0.00";
                            TextSGSTAmt.EditValue = "0.00";
                            TextSGSTAmt.Properties.ReadOnly = true;
                            TextCGSTAmt.Properties.ReadOnly = true;
                            TextIGSTAmt.Properties.ReadOnly = true;
                        }
                        else if (TextISLC.Text == "L")
                        {
                            TextIGSTAmt.Text = "0.00";
                            TextIGSTAmt.EditValue = "0.00";
                            TextSGSTAmt.Properties.ReadOnly = false;
                            TextCGSTAmt.Properties.ReadOnly = false;
                            TextIGSTAmt.Properties.ReadOnly = true;
                        }
                        else if (TextISLC.Text == "C")
                        {
                            TextSGSTAmt.Text = "0.00";
                            TextCGSTAmt.Text = "0.00";
                            TextCGSTAmt.EditValue = "0.00";
                            TextSGSTAmt.EditValue = "0.00";
                            TextSGSTAmt.Properties.ReadOnly = true;
                            TextCGSTAmt.Properties.ReadOnly = true;
                            TextIGSTAmt.Properties.ReadOnly = false;
                        }
                        TextDocType.Focus();
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
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }

        }

        private void TextCreditCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
            {
                CurrentControl = "TextCreditCode";
                const string Query = "SELECT [AccName] as 'Credit Description', [AccCode] as 'Credit Code'  FROM  [ActMst]   Order By AccCode;";
                if (TextCreditCode.Text.Trim().Length == 0)
                {
                    //Display Help Window
                    ShowHelpWindow(Query);
                }

                else
                {
                    //Checking whether Value  is Existing or not!
                    string query = String.Format("SELECT [AccName] as 'Credit Description', [AccCode] as 'Credit Code'  FROM  [ActMst]  where    [AccCode]='{0}'  Order By AccCode;", TextCreditCode.Text.Trim());

                    DataSet ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextCreditCode.Text = ds.Tables[0].Rows[0]["Credit Code"].ToString();
                        TextCreditDesc.Text = ds.Tables[0].Rows[0]["Credit Description"].ToString();
                        TextSuppCode.Focus();
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
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }

        }


        private void TextProdCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
                {
                    //    HelpGridCtrl.Width = 400;

                    CurrentControl = "TextProdCode";
                    const string PQuery = "SELECT     PrdMst.PrdName AS 'Product Name', PrdMst.PrdCode AS 'Code', PrdMst.PrdAsgnCode AS 'Assigned Code', uOmMst.UomDesc AS 'UOM',PrdMst.PrdRate AS 'Rate', PrdHSNCode  FROM   PrdMst LEFT OUTER JOIN uOmMst ON PrdMst.PrdUOM = uOmMst.UomCode Where ISNull(PrdHSNItemType,'G')<>'S' ORDER BY PrdMst.PrdName; ";
                    const string SQuery = "SELECT     PrdMst.PrdName AS 'Product Name', PrdMst.PrdCode AS 'Code', PrdMst.PrdAsgnCode AS 'Assigned Code', uOmMst.UomDesc AS 'UOM',PrdMst.PrdRate AS 'Rate', PrdHSNCode  FROM   PrdMst LEFT OUTER JOIN uOmMst ON PrdMst.PrdUOM = uOmMst.UomCode  Where ISNull(PrdHSNItemType,'G')='S' ORDER BY PrdMst.PrdName; ";

                    if (TextProdCode.Text.Trim().Length == 0)
                    {
                        TextPrdHSNCd.Enabled = false;
                        if (_MRI == "SVC")
                            ShowHelpWindow(SQuery);
                        else
                            ShowHelpWindow(PQuery);
                    }

                    else
                    {

                        try
                        {
                            //Checking whether Value  is Existing or not!
                            string Pquery = String.Format("SELECT     PrdMst.PrdName AS 'Product Name', PrdMst.PrdCode AS 'Code', PrdMst.PrdAsgnCode AS 'Assigned Code', uOmMst.UomDesc AS 'UOM',PrdMst.PrdRate AS 'Rate', PrdHSNCode FROM         PrdMst LEFT OUTER JOIN uOmMst ON PrdMst.PrdUOM = uOmMst.UomCode  where   [PrdCode]='{0}' And ISNull(PrdHSNItemType,'G')<>'S' ORDER BY PrdMst.PrdName;", int.Parse(TextProdCode.Text.Trim()));
                            string Squery = String.Format("SELECT     PrdMst.PrdName AS 'Product Name', PrdMst.PrdCode AS 'Code', PrdMst.PrdAsgnCode AS 'Assigned Code', uOmMst.UomDesc AS 'UOM',PrdMst.PrdRate AS 'Rate', PrdHSNCode FROM         PrdMst LEFT OUTER JOIN uOmMst ON PrdMst.PrdUOM = uOmMst.UomCode  where   [PrdCode]='{0}' And ISNull(PrdHSNItemType,'G')='S' ORDER BY PrdMst.PrdName;", int.Parse(TextProdCode.Text.Trim()));
                            DataSet ds = ProjectFunctions.GetDataSet(_MRI == "SVC" ? Squery : Pquery);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                TextProdCode.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                                TextProdDesc.Text = ds.Tables[0].Rows[0]["Product Name"].ToString();
                                TextProdAsgnCode.Text = ds.Tables[0].Rows[0]["Assigned Code"].ToString();
                                TextUOM.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                                // TextProdRate.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
                                TextPrdHSNCd.Text = ds.Tables[0].Rows[0]["PrdHSNCode"].ToString();
                                GetHSN();

                                if (TextPrdHSNCd.Text == string.Empty)
                                {
                                    TextPrdHSNCd.Focus();
                                }

                            }
                            else
                            {
                                // Display Help Window
                                if (_MRI == "SVC")
                                    ShowHelpWindow(SQuery);
                                else
                                    ShowHelpWindow(PQuery);
                            }

                        }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                        catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                        {
                            Error.SetError(TextProdCode, "Enter Valid Prod Code");
                        }


                    }
                    e.Handled = true;
                }

                if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
                {
                    TextRemarks.Focus();

                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }

        }

        private void CheckService()
        {
            using (DataSet Dsx = ProjectFunctions.GetDataSet("Select IsNull(AccSplInfo,'') From ActMst where AccCode='" + TextAcPostingCode.Text + "'"))
            {
                if (Dsx.Tables[0].Rows[0][0].ToString() == "C")
                {
                    xtraflag = true;
                    SubPanel.Show();
                    TextCostCode.Focus();
                }
                else
                {
                    xtraflag = false;
                    TextProdQnty.Text = "1";
                    TextProdRate.Text = TextValueOfGoods.Text;
                    TextProdQnty.Focus();
                }
            }
        }

        private void GetHSN()
        {
            if (Flag)
                return;
            else if (TextPrdHSNCd.Text == string.Empty)
            {
                Flag = true;
                // ProjectFunctions.SpeakError("Dear Sir, Kindly Update Information for this HSN Code");
                HelpGridCtrl.Visible = false;
                TextPrdHSNCd.Enabled = true;
                TextPrdHSNCd.Properties.ReadOnly = false;
                TextPrdHSNCd.Focus();
                return;
            }
            else
            {
                string query = String.Format("SELECT GSTCode, GSTDesc, IsNull(GSTSGSTRate,0) SGSTRate, ISNull(GSTCGSTRate,0)CGSTRate, IsNull(GSTIGSTRate,0) as IGST,GSTPurPost,GSTPurPostIS,GSTRateOpenTag, GSTSalePost, GSTSalePostIS FROM GSTMst Where GstCode='{0}' ", TextPrdHSNCd.Text);
                DataSet ds = ProjectFunctions.GetDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Flag = false;
                    TextPrdSGSTRate.Text = ds.Tables[0].Rows[0][2].ToString();
                    TextPrdCGSTRate.Text = ds.Tables[0].Rows[0][3].ToString();
                    TextPrdIGSTRate.Text = ds.Tables[0].Rows[0][4].ToString();
                    if (PurchaseType.Text == "COMP")
                    {
                        TextPrdSGSTRate.Text = "0.00";
                        TextPrdCGSTRate.Text = "0.00";
                        TextPrdIGSTRate.Text = "0.00";
                    }
                    var x = ds.Tables[0].Rows[0][7].ToString().Trim();
                    if (x == "N")
                    {
                        TextPrdSGSTRate.Properties.ReadOnly = true;
                        TextPrdCGSTRate.Properties.ReadOnly = true;
                        TextPrdIGSTRate.Properties.ReadOnly = true;
                        TextPrdSGSTAmt.Properties.ReadOnly = true;
                        TextPrdCGSTAmt.Properties.ReadOnly = true;
                        TextPrdIGSTAmt.Properties.ReadOnly = true;
                    }
                    else
                    {
                        TextPrdSGSTRate.Properties.ReadOnly = false;
                        TextPrdCGSTRate.Properties.ReadOnly = false;
                        TextPrdIGSTRate.Properties.ReadOnly = false;
                        TextPrdSGSTAmt.Properties.ReadOnly = false;
                        TextPrdCGSTAmt.Properties.ReadOnly = false;
                        TextPrdIGSTAmt.Properties.ReadOnly = false;
                    }
                    if (TextISLC.Text == "C")
                    {
                        if (TextSuppGST.Text.Trim().Length > 0)
                        {
                            TextPrdSGSTRate.Text = TextPrdCGSTRate.Text = "0";
                            if (BtnOK.Text != "&Update")
                                TextAcPostingCode.Text = ds.Tables[0].Rows[0][6].ToString();
                        }
                        else
                        {
                            TextPrdSGSTRate.Text = TextPrdCGSTRate.Text = "0";
                            if (BtnOK.Text != "&Update")
                                TextAcPostingCode.Text = ds.Tables[0].Rows[0][9].ToString();
                        }
                    }
                    else
                    {
                        if (TextSuppGST.Text.Trim().Length > 0)
                        {
                            TextPrdIGSTRate.Text = "0";
                            if (BtnOK.Text != "&Update")
                                TextAcPostingCode.Text = ds.Tables[0].Rows[0][5].ToString();
                        }
                        else
                        {
                            TextPrdIGSTRate.Text = "0";
                            if (BtnOK.Text != "&Update")
                                TextAcPostingCode.Text = ds.Tables[0].Rows[0][8].ToString();
                        }
                    }
                    TextPrdHSNCd.Enabled = false;
                    TextAcPostingCode.Focus();
                }
                else
                {
                    Flag = true;
                    // ProjectFunctions.SpeakError("Dear Sir, Kindly Update Information for this HSN Code");
                    HelpGridCtrl.Visible = false;
                    TextPrdHSNCd.Enabled = true;
                    TextPrdHSNCd.Properties.ReadOnly = false;
                    TextPrdHSNCd.Focus();
                    return;
                }
            }
        }

        private void TextRemarks_KeyDown(object sender, KeyEventArgs e)
        {

            if (((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up) && _MRI == "MRI" && ((TextEdit)sender).Name == "TextInvAmount")
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
            else
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Down)
            {
                TextProdCode.Focus();
                e.Handled = true;
            }
            else
                    if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }

        }

        private void MoveBackOrForward(object sender, KeyEventArgs e)
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

        private void ShowHelpWindow(string Query)
        {
            //  Save.Enabled = false;
            try
            {
                Print.Enabled = false;

                HelpGridCtrl.DataSource = null;
                HelpGrid.Columns.Clear();
                HelpGridCtrl.RefreshDataSource();
                HelpGridCtrl.Visible = true;
                HelpGridCtrl.Focus();
                HelpGridCtrl.DataSource = ProjectFunctions.GetDataSet(Query).Tables[0];
                ProjectFunctions.GirdViewVisualize(HelpGrid);
                HelpGrid.Columns[0].BestFit();
                if (CurrentControl.Equals(TextProdCode.Name))
                {
                    HelpGrid.Columns["Product Name"].Width = 110;
                    HelpGrid.Columns["Assigned Code"].Visible = false;

                    HelpGrid.Columns["UOM"].Visible = false;
                    HelpGrid.Columns["Rate"].Visible = false;
                    //HelpGrid.Columns["Ac Code"].Visible = false;
                    //HelpGrid.Columns["Ac Name"].Visible = false;

                }
                if (CurrentControl.Equals(BtnZoomPrd.Name))
                {
                    HelpGridCtrl.Location = new System.Drawing.Point(0, 29);
                    HelpGridCtrl.Size = new System.Drawing.Size(766, 347);
                    HelpGrid.OptionsView.ColumnAutoWidth = false;
                    HelpGrid.Columns["Nart."].BestFit();
                    HelpGrid.Columns["Issue"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    HelpGrid.Columns["Issue"].DisplayFormat.FormatString = "f";
                    HelpGrid.Columns["Receipt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    HelpGrid.Columns["Receipt"].DisplayFormat.FormatString = "f";
                    HelpGrid.Columns["SIssue"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    HelpGrid.Columns["SIssue"].DisplayFormat.FormatString = "f";
                    HelpGrid.Columns["RTN"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    HelpGrid.Columns["RTN"].DisplayFormat.FormatString = "f";
                    HelpGrid.CustomColumnDisplayText += (o, e) =>
                    {
                        if (e.Column.FieldName == "Issue" || e.Column.FieldName == "Receipt" || e.Column.FieldName == "SIssue" || e.Column.FieldName == "RTN")
                            if (Convert.ToDecimal(e.Value) == 0) e.DisplayText = string.Empty;
                        ;
                    };
                }
                else
                {
                    HelpGridCtrl.Location = new System.Drawing.Point(208, 29);
                    HelpGridCtrl.Size = new System.Drawing.Size(558, 347);
                    HelpGrid.OptionsView.ColumnAutoWidth = true;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Unable to fetch Data please Contact IT Department.\n" + ex.Message);
            }

        }

        private void HelpGridCtrl_DoubleClick(object sender, EventArgs e)
        {

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
                                TextProdQnty.Text = "1.00";
                                TextProdRate.Text = TextValueOfGoods.Text;
                                TextProdQnty.Focus();

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

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton)
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
            switch (CurrentControl)
            {
                case "TextSuppCode":
                    TextSuppCode.Focus();
                    break;

                case "TextCreditCode":
                    TextCreditCode.Focus();
                    break;

                case "TextProdCode":
                    TextProdCode.Focus();
                    break;
                case "TextAcPostingCode":
                    TextAcPostingCode.Focus();
                    break;
                default:
                    break;
            }

        }

        private void TextProdRate_Validated(object sender, EventArgs e)
        {
            try
            {
                TextProdAmount.Text = (Convert.ToDecimal(TextProdQnty.Text) * Convert.ToDecimal(TextProdRate.Text)).ToString();
                TextProdAmount.Focus();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                TextProdQnty.Focus(); Errorflag = false;
                Error.SetError(TextProdQnty, "Enter Valid Values.");
            }
        }



        private void DtDocDate_Validated(object sender, EventArgs e)
        {
            try
            {
                string s = DtDocDate.DateTime.ToString("dd/MM/yyyy");
                s = s.Replace('-', '/');
                string query = String.Format("SELECT [MmRDocNo] FROM [dbo].[MrMst]  where MMdocType='" + _MRI + "' And MmFinYear='{4}'  and MmAccCode='{1}'  and MmRDocNo='{3}'  and MmRDocNo<>'{6}'; ", s, TextSuppCode.Text.Trim(), string.Empty, TextDocNumber.Text.Trim(), ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear), TextDocType.Text, !IsUpdate ? "0" : oldtDocNum);

                using (DataSet ds = ProjectFunctions.GetDataSet(query))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Error.SetError(TextDocNumber, "The DocNo. for this Party at the given Date might be Duplicate.");
                        TextDocNumber.Focus();
                    }
                    else
                        Error.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.SetError(DtDocDate, " Please Check Or Contact IT Department.\n" + ex.Message);
                DtDocDate.Focus();
            }

        }

        private void TextProdQnty_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextProdQnty.Text.Trim()) && Convert.ToDecimal(TextProdQnty.Text) > 0)
                {
                    if (!TextProdPONO.Visible)
                        return;

                    if (BtnOK.Text == "&Update")
                    {
                        DataSet Ds = ProjectFunctions.GetDataSet(String.Format("select [Qnty. Ord.], [Qnty. Rcvd.] from [{2}] where [PO No]= '{0}'and [Sub No.]='{1}'", TextProdPONO.Text, textEdit1.Text, (TextChoiceRCO.Text == "R" ? "V_Pending_PO" : "V_Pending_Indent")));
                        if (Ds != null)
                        {
                            DataTable Dt = Ds.Tables[0];
                            oldPOqntyord = Convert.ToDecimal(Dt.Rows[0][0].ToString());
                            oldPOqntyRcvd = Convert.ToDecimal(Dt.Rows[0][1].ToString());
                            if (oldprodpono == TextProdPONO.Text + textEdit1.Text)
                            {
                                if (TextAuthenticate.Text.Equals("0123") || (oldPOqntyord - oldPOqntyRcvd) + oldprdqnty >= Convert.ToDecimal(TextProdQnty.Text))
                                {

                                    Error.Dispose();
                                }
                                else
                                {
                                    TextAuthenticate.Focus(); Errorflag = false;
                                    ProjectFunctions.SpeakError("Use Pwd 0123 Or Adjust Value.");
                                }

                            }
                            else
                            {
                                if (TextAuthenticate.Text.Equals("0123") || (Convert.ToDecimal(TextProdQnty.Text) <= (oldPOqntyord - oldPOqntyRcvd)))
                                {

                                    Error.Dispose();
                                }
                                else
                                {
                                    TextAuthenticate.Focus(); Errorflag = false;
                                    ProjectFunctions.SpeakError("Use Pwd 0123 Or Adjust Value.");
                                }

                            }
                        }
                    }
                    else
                    {
                        //ProjectFunctions.SpeakError("Unable to Find This PONO.");
                        //TextProdPONO.Focus();
                    }

                }
                else
                {
                    Error.SetError(TextProdQnty, "Not a Valid Value.");
                    TextProdQnty.Focus(); Errorflag = false;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TextIsCash_Validated(object sender, EventArgs e)
        {
            if (TextIsCash.Text.ToUpper() == "P")
            {
                TextCreditCode.Enabled = false;
                TextCreditCode.Text = string.Empty;
                TextCreditDesc.Text = string.Empty;
                TextSuppCode.Focus();
            }
            else if (TextIsCash.Text.ToUpper() == "C")
            {
                TextCreditCode.Enabled = false;
                TextCreditCode.Text = GlobalVariables.CashCode;
                TextCreditDesc.Text = ProjectFunctions.GetDataSet("Select AccName From ActMSt where AccCode='" + TextCreditCode.Text + "'").Tables[0].Rows[0][0].ToString();
                TextSuppCode.Focus();
            }
            else if (TextIsCash.Text.ToUpper() == "I")
            {
                TextCreditCode.Enabled = true;
                //TextCreditCode.Text = "";
                //TextCreditDesc.Text = "";
                TextCreditCode.Focus();
            }
        }

        private void TextCreditCode_Validated(object sender, EventArgs e)
        {
            if (TextIsCash.Text.Trim().Equals("I") || TextIsCash.Text.Trim().Equals("C"))
            {
                if (TextCreditCode.Text.Length == 0)
                {
                    if (!HelpGridCtrl.Visible)
                    {
                        Errorflag = false;
                        TextCreditDesc.Text = string.Empty;
                        Error.SetError(TextCreditCode, "Enter Valid Value.");
                        TextCreditCode.Focus();
                    }
                }
                else
                    Error.Dispose();
            }
        }

        private void DtDocDate_Enter(object sender, EventArgs e)
        {
            DtDocDate.SelectAll();
        }

        private void EntryInfo_Grid_EndGrouping(object sender, EventArgs e)
        {
            EntryInfo_Grid.ExpandAllGroups();
        }

        private void EntryInfo_GridCtrl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                __rohandle = EntryInfo_Grid.FocusedRowHandle;
                int[] selRows = EntryInfo_Grid.GetSelectedRows();
                DataRowView selRow = (DataRowView)(EntryInfo_Grid.GetRow(selRows[0]));
                ThisRecord = selRow.Row;
                //Fill Whole Data
                currentprodCode = ThisRecord["MdPrdCode"].ToString();
                TextProdCode.Text = ThisRecord["MdPrdCode"].ToString();
                TextProdAsgnCode.Text = ThisRecord["PrdAsgnCode"].ToString();
                TextProdDesc.Text = ThisRecord["PrdName"].ToString();
                TextProdPONO.Text = ThisRecord["MdPrdPoNo"].ToString();
                textEdit1.Text = ThisRecord["MdPrdPoSNO"].ToString();
                TextUOM.Text = ThisRecord["MdPrdUOM"].ToString();
                TextPrdHSNCd.Text = ThisRecord["MdPrdHSNCd"].ToString();

                TextAcPostingCode.Text = ThisRecord["MdPrdAcode"].ToString();
                TextAcPostDesc.Text = ThisRecord["AccName"].ToString();
                TextProdQnty.Text = ThisRecord["MdPrdQty"].ToString();

                TextProdRate.Text = ThisRecord["MdPrdRate"].ToString();
                TextProdAmount.Text = ThisRecord["MdPrdAmt"].ToString();
                TextPrdPackingAmt.Text = ThisRecord["MdDiscAmt"].ToString();
                TextProdTotalAmt.Text = ThisRecord["MdPrdNAmt"].ToString();
                TextMdPrdTxbAmt.Text = ThisRecord["MdTxblAmt"].ToString();
                TextPrdCGSTRate.Text = ThisRecord["MdCGSTRate"].ToString();
                TextPrdCGSTAmt.Text = ThisRecord["MdCGSTAmt"].ToString();
                TextPrdSGSTRate.Text = ThisRecord["MdSGSTRate"].ToString();
                TextPrdSGSTAmt.Text = ThisRecord["MdSGSTAmt"].ToString();
                TextPrdIGSTRate.Text = ThisRecord["MdIGSTRate"].ToString();
                TextPrdIGSTAmt.Text = ThisRecord["MdIGSTAmt"].ToString();
                TextPrdPlusAmt.Text = ThisRecord["MdPlusAmt"].ToString();

                VarCostId = ThisRecord["ID"].ToString();
                TextCostCode.Text = ThisRecord["CostCode"].ToString();
                TextCostSubCode.Text = ThisRecord["CostSubCode"].ToString();
                TextCostDesc.Text = ThisRecord["CostDesc"].ToString();
                TextCostSubCodeDesc.Text = ThisRecord["CostSubDesc"].ToString();
                TextExpHeadCode.Text = ThisRecord["ExpHeadCode"].ToString();
                TextExpHeadDesc.Text = ThisRecord["ExpHeadDesc"].ToString();

                BtnOK.Enabled = true;
                BtnUndo.Enabled = true;
                BtnDelete.Enabled = true;
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
                id = int.Parse(EntryInfo_Grid.GetRowCellValue(e.FocusedRowHandle, EntryInfo_Grid.Columns["Id"]).ToString());
                //  currentprodCode = EntryInfo_Grid.GetRowCellValue(e.FocusedRowHandle, EntryInfo_Grid.Columns["Code"]).ToString();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            TextSGSTAmt.DoValidate();
            TextTaxableAmt.DoValidate();
            TextPrdPlusAmt.DoValidate();
            TextPrdHSNCd.DoValidate();
            if (TextDoc_NO.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("DocNo Field blank");
                TextDoc_NO.Focus();
                return;
            }

            else if (TextSuppCode.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Party Code Field blank");
                TextSuppCode.Focus();
                return;
            }
            else if (TextPrdHSNCd.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("HSN Code Field blank");
                TextProdCode.Focus();
                return;
            }
            else if (TextProdCode.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Product code Field blank.");
                TextProdCode.Focus();
                return;
            }
            else if (TextProdDesc.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Product Name Field blank.");
                TextProdCode.Focus();
                return;
            }
            else if (Convert.ToDecimal(TextProdQnty.EditValue) <= 0)
            {
                ProjectFunctions.SpeakError("Qty Field cannot be zero or less than zero.");
                TextProdQnty.Focus();
                return;
            }

            else if (TextUOM.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Insert valid Unit of Measurment");
                TextUOM.Focus();
                return;
            }
            else if (Convert.ToDecimal(TextProdRate.Text) == 0)
            {
                ProjectFunctions.SpeakError("Insert valid Rate");
                TextProdRate.Focus();
                return;
            }
            else if (_MRI == "SVC")
            {
                using (DataSet Dsx = ProjectFunctions.GetDataSet("Select IsNull(PrdSplTag,'') From PrdMst where PrdCode='" + TextProdCode.Text + "'"))
                {
                    if (Dsx.Tables[0].Rows[0][0].ToString() == "S")
                    {
                        if (TextCostCode.Text == string.Empty)
                        {
                            CheckService();
                            if (xtraflag)
                                return;
                        }
                    }
                    else
                    {

                    }
                }
            }

            else if (!IsUpdate && !(TextProdDesc.Text.ToUpper().Contains("FREIGHT") || _MRI == "SVC"))
            {
                using (DataSet Dsx = ProjectFunctions.GetDataSet(String.Format("SELECT         [PO Date], PrdCode, PrdName, [Qnty. Ord.], [Qnty. Rcvd.], Party, Rate, PartyCode FROM " + (TextChoiceRCO.Text == "R" ? "V_Pending_PO" : "V_Pending_Indent") + " WHERE        (PrdCode = '{0}') And [PO No]='{1}' And [Sub No.]='{2}'", TextProdCode.Text, TextProdPONO.Text, textEdit1.Text)))
                {
                    if (Dsx.Tables[0].Rows.Count == 0)
                    {
                        ProjectFunctions.SpeakError("Po NO. does not Exists.");
                        TextProdPONO.Focus();
                        return;
                    }
                }
            }
            else if (TextProdPONO.Text.Length < 8)
            {
                ProjectFunctions.SpeakError("Po NO. can not be less than 8 digits.");
                TextProdPONO.Focus();
                return;
            }
            else if (textEdit1.Text.Length < 1)
            {
                ProjectFunctions.SpeakError("Po Sub NO. can not be less than 1 digits.");
                textEdit1.Focus();
                return;
            }


            else if (Convert.ToDecimal(TextProdRate.EditValue) <= 0)
            {
                ProjectFunctions.SpeakError("Product Rate can not be zero or less than zero.");
                TextProdRate.Focus();
                return;
            }

            else if (Convert.ToDecimal(TextProdAmount.EditValue) <= 0)
            {
                ProjectFunctions.SpeakError("Product Amount can not be zero or less than zero.");
                TextProdAmount.Focus();
                return;
            }
            TextProdQnty_Validating_1(null, null);

            //&& (TextAuthenticate.Text=="0123"||(Convert.ToDecimal(TextProdQnty.Text)>=OldPassQty) || ((Convert.ToDecimal(TextProdQnty.Text)< OldPassQty) && Convert.ToDecimal(TextStockInHand.Text)>=Convert.ToDecimal(TextProdQnty.Text)))
            if (BtnOK.Text == "&Ok")
            {
                try
                {
                    var rowHandle = 0;
                    if (Record.Rows.Count > 0)
                    {
                        // MmBillPassID is Unique
                        //rowHandle = (ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "MdPrdCode", TextProdCode.Text) >= 0) ? -1 : 0;

                    }
                    if (rowHandle == 0)
                    {
                        EntryInfo_Grid.AddNewRow();
                        EntryInfo_Grid.RefreshData();
                        EntryInfo_Grid.UpdateCurrentRow();
                        EntryInfo_Grid.UpdateTotalSummary();
                        ResetMyPrd();
                        TextProdCode.Focus();
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Sir You are going to Enter same Entry Again!");
                        TextProdCode.Focus();
                        // BtnOK.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    ProjectFunctions.SpeakError("Sir there is Some problem, Contact IT Department!\n" + ex.Message);
                    TextProdCode.Focus();
                }
            }


            if (BtnOK.Text == "&Update")
            {
                try
                {
                    int rowHandle = __rohandle;


                    // Do the particular stuff 
                    EntryInfo_Grid.BeginDataUpdate();
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdCode, TextProdCode.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colPrdAsgnCode, TextProdAsgnCode.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colPrdName, TextProdDesc.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdPoNo, TextProdPONO.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdPoSNO, textEdit1.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdUOM, TextUOM.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdHSNCd, TextPrdHSNCd.Text);

                    EntryInfo_Grid.SetRowCellValue(rowHandle, gridColumn1, TextAcPostingCode.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, gridColumn2, TextAcPostDesc.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdQty, TextProdQnty.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdDiscAmt, TextPrdPackingAmt.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdRate, TextProdRate.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdAmt, TextProdAmount.Text);

                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdNAmt, Convert.ToDecimal(TextProdTotalAmt.Text));
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdNRate, Convert.ToDecimal(TextProdTotalAmt.Text) / Convert.ToDecimal(TextProdQnty.Text));

                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdTxblAmt, TextMdPrdTxbAmt.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdCGSTRate, TextPrdCGSTRate.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdCGSTAmt, TextPrdCGSTAmt.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdSGSTRate, TextPrdSGSTRate.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdSGSTAmt, TextPrdSGSTAmt.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdIGSTRate, TextPrdIGSTRate.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdIGSTAmt, TextPrdIGSTAmt.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPlusAmt, TextPrdPlusAmt.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdNAmt1, Convert.ToDecimal(TextProdTotalAmt.Text) - Convert.ToDecimal(TextPrdPlusAmt.Text));
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colMdPrdNRate1, (Convert.ToDecimal(TextProdTotalAmt.Text) - Convert.ToDecimal(TextPrdPlusAmt.Text)) / Convert.ToDecimal(TextProdQnty.Text));

                    EntryInfo_Grid.SetRowCellValue(rowHandle, colID, VarCostId);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colCostCode, TextCostCode.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colCostSubCode, TextCostSubCode.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colExpHeadCode, TextExpHeadCode.Text);

                    EntryInfo_Grid.SetRowCellValue(rowHandle, colCostDesc, TextCostCode.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colCostSubDesc, TextCostSubCode.Text);
                    EntryInfo_Grid.SetRowCellValue(rowHandle, colExpHeadDesc, TextExpHeadDesc.Text);


                    EntryInfo_Grid.EndDataUpdate();
                    EntryInfo_Grid.UpdateCurrentRow();
                    EntryInfo_Grid.UpdateSummary();
                    ResetMyPrd();
                    TextProdCode.Focus();
                    currentprodCode = string.Empty;
                    BtnOK.Text = "&Ok";
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                //EntryInfo_Grid.AddNewRow();
            }

            Status.Text = "Taxable Amt. is : " + TextTaxableAmt.Text + " and Grid Taxable Amt. is :" + colMdTxblAmt.SummaryItem.SummaryValue;
        }

        private void ResetMyPrd()
        {
            TextProdCode.Text = string.Empty;
            TextProdAsgnCode.Text = string.Empty;
            TextUOM.Text = string.Empty;
            TextPrdCGSTAmt.Text = "0";
            TextPrdIGSTAmt.Text = "0";
            TextPrdIGSTRate.Text = "0";
            TextPrdSGSTRate.Text = "0";
            TextPrdCGSTRate.Text = "0";
            TextProdDesc.Text = string.Empty;
            TextProdQnty.Text = "0";
            TextAcPostDesc.Text = string.Empty;
            TextAcPostingCode.Text = string.Empty;
            TextCostCode.Text = string.Empty;
            TextCostSubCodeDesc.Text = string.Empty;
            TextCostSubCode.Text = string.Empty;
            TextCostDesc.Text = string.Empty;
            TextExpHeadDesc.Text = string.Empty;
            TextExpHeadCode.Text = string.Empty;
            TextPrdSGSTAmt.Text = string.Empty;
            TextProdRate.Text = "0";
            TextProdAmount.Text = "0";
            TextMdPrdTxbAmt.Text = "0";

            TextPrdSGSTAmt.Text = "0";
            TextPrdPackingAmt.Text = "0";
            TextPrdPlusAmt.Text = "0";

            BtnOK.Enabled = false;
            TextProdTotalAmt.Text = string.Empty;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int rowHandle = -1;

                if (EntryInfo_Grid.RowCount > 0)
                    rowHandle = __rohandle;

                EntryInfo_Grid.DeleteRow(rowHandle);
                EntryInfo_Grid.RefreshData();
                ResetMyPrd();
                TextProdCode.Focus();
                EntryInfo_Grid.UpdateSummary();
                Status.Text = "Taxable Amt. is : " + TextTaxableAmt.Text + " and Grid Taxable Amt. is :" + colMdTxblAmt.SummaryItem.SummaryValue;
                BtnOK.Text = "&Ok";
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                ResetMyPrd();
                EntryInfo_Grid.UpdateSummary();
                Status.Text = "Taxable Amt. is : " + TextTaxableAmt.Text + " and Grid Taxable Amt. is :" + colMdTxblAmt.SummaryItem.SummaryValue;
                BtnOK.Text = "&Ok";
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void OnlyNumericwithdigit(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void Validate_Click(object sender, EventArgs e)
        {
            Errorflag = true;
            //Do Validation
            if (TextDoc_NO.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Document No field blank.");
                TextDoc_NO.Focus();
                Errorflag = false;
                return;
            }

            else if (TextIsCash.Text == "I" || TextIsCash.Text == "C")
            {
                if (TextCreditCode.Text == string.Empty)
                {
                    ProjectFunctions.SpeakError("Cash Party Code Field blank");
                    TextCreditCode.Focus();
                    Errorflag = false;
                    return;
                }
            }
            else if (Convert.ToDecimal(TextInvAmount.Text) != Convert.ToDecimal(TextAsPerBill.Text))
            {
                ProjectFunctions.SpeakError("Amount as Per Bill doesn't Match With Invoice AMount");
                TextInvAmount.Focus();
                Errorflag = false;
                return;
            }

            else if (TextChoiceRCO.Text == string.Empty || (!(TextChoiceRCO.Text == "C") && !(TextChoiceRCO.Text == "R") && !(TextChoiceRCO.Text == "O")))
            {
                Error.SetError(TextChoiceRCO, "Value Should be R/C/O");
                TextChoiceRCO.Focus();
                Errorflag = false;
                return;
            }
            else if (TextSuppCode.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Party Code Field blank");
                TextSuppCode.Focus(); Errorflag = false;
                return;
            }
            else if (Convert.ToDecimal(TextAsPerBill.Text) != Convert.ToDecimal(TextInvAmount.Text))
            {
                ProjectFunctions.SpeakError("Inv Amount Mismatch");
                TextInvAmount.Focus(); Errorflag = false;
                return;
            }
            else if (TextDocType.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Document type Field blank.");
                TextDocType.Focus(); Errorflag = false;
                return;
            }
            else if (!(TextDocType.Text == "B") && !(TextDocType.Text == "I"))
            {
                ProjectFunctions.SpeakError("Document type  : B - BILL   I - INVOICE ");
                TextDocType.Focus(); Errorflag = false;
                return;
            }
            else if (TextDocNumber.Text == string.Empty)
            {
                ProjectFunctions.SpeakError("Receipt Document No Field blank.");
                TextDocNumber.Focus(); Errorflag = false;
                return;
            }

            else if (Convert.ToDecimal(TextValueOfGoods.EditValue) <= 0)
            {
                ProjectFunctions.SpeakError("Gross Amount Field blank.");
                TextValueOfGoods.Focus(); Errorflag = false;
                return;
            }

            else if (Convert.ToDecimal(TextInvAmount.EditValue) <= 0)
            {
                ProjectFunctions.SpeakError("Net Amount Field blank.");
                TextInvAmount.Focus(); Errorflag = false;
                return;
            }


            try
            {


                EntryInfo_Grid.UpdateTotalSummary();
                if (Math.Round(Convert.ToDecimal(colMdTxblAmt.SummaryItem.SummaryValue.ToString()), 2, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(TextTaxableAmt.Text), 2, MidpointRounding.AwayFromZero))
                {
                    Error.SetError(TextValueOfGoods, "Taxable Amt. Diff." + (-Math.Round(Convert.ToDecimal(TextTaxableAmt.Text), 2, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDecimal(colMdTxblAmt.SummaryItem.SummaryValue.ToString()), 2, MidpointRounding.AwayFromZero)).ToString());
                    TextValueOfGoods.Focus(); Errorflag = false;
                    return;
                }
                if (PurchaseType.Text.ToUpper() != "URGD")
                {

                    if (Math.Round(Convert.ToDecimal(colMdSGSTAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(TextSGSTAmt.Text), 0, MidpointRounding.AwayFromZero))
                    {
                        Error.SetError(TextSGSTAmt, "SGST Amt. Diff." + (-Math.Round(Convert.ToDecimal(TextSGSTAmt.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDecimal(colMdSGSTAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero)).ToString());
                        TextSGSTAmt.Focus(); Errorflag = false;
                        return;
                    }
                    if (Math.Round(Convert.ToDecimal(colMdCGSTAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(TextCGSTAmt.Text), 0, MidpointRounding.AwayFromZero))
                    {
                        Error.SetError(TextCGSTAmt, "CGST Amt. Diff." + (-Math.Round(Convert.ToDecimal(TextCGSTAmt.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDecimal(colMdCGSTAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero)).ToString());
                        TextCGSTAmt.Focus(); Errorflag = false;
                        return;
                    }
                    if (Math.Round(Convert.ToDecimal(colMdIGSTAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(TextIGSTAmt.Text), 0, MidpointRounding.AwayFromZero))
                    {
                        Error.SetError(TextIGSTAmt, "IGST Amt. Diff." + (-Math.Round(Convert.ToDecimal(TextIGSTAmt.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDecimal(colMdIGSTAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero)).ToString());
                        TextIGSTAmt.Focus(); Errorflag = false;
                        return;
                    }
                    if (Math.Round(Convert.ToDecimal(colMdPrdNAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero) != Math.Round(Convert.ToDecimal(TextInvAmount.Text), 0, MidpointRounding.AwayFromZero))
                    {
                        Error.SetError(TextInvAmount, "Net Amt. Diff." + (-Math.Round(Convert.ToDecimal(TextInvAmount.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDecimal(colMdPrdNAmt.SummaryItem.SummaryValue.ToString()), 0, MidpointRounding.AwayFromZero)).ToString());
                        TextInvAmount.Focus(); Errorflag = false;
                        return;
                    }
                }
                if (DtEntry.DateTime.Date.Equals(DateTime.Now.Date))
                {
                    AuthenticateFlag = true;
                    MyValidationProvider.Validate();
                    if (MyValidationProvider.GetInvalidControls().Count > 0)
                        Errorflag = false;
                    if (EntryInfo_Grid.RowCount == 0)
                        Errorflag = false;

                }

                //if (!AuthenticateFlag)
                //{
                //    string authenticate = String.Format("dbo.Sp_Authenticate '{0:yyyy-MM-dd}', '{1}', '{2}','{3}'", DtEntry.DateTime.Date, GlobalVariables.CurrentUser, TextAuthenticate.Text.Trim(), IsUpdate ? Name + "_Y" : Name);
                //    using (DataSet Ds = ProjectFunctions.GetDataSet(authenticate))
                //        if (Ds.Tables[0].Rows[0][0].ToString().Equals("Y"))
                //        {
                //            AuthenticateFlag = true;
                //            Errorflag = true;
                //            MyValidationProvider.Validate();
                //            if (MyValidationProvider.GetInvalidControls().Count > 0)
                //                Errorflag = false;
                //            if (EntryInfo_Grid.RowCount == 0)
                //                Errorflag = false;

                //        }
                //        else
                //        {
                //            AuthenticateFlag = false;
                //            Errorflag = false;
                //            ProjectFunctions.SpeakError("You have Entered Wrong Password.");
                //            TextAuthenticate.Visible = true;
                //            TextAuthenticate.Focus();
                //        }
                //}

                //if (Errorflag && AuthenticateFlag)
                //    Save.Enabled = true;
                //else
                Save.Enabled = true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                Save.Enabled = false;
            }
            Status.Text = "Taxable Amt. is : " + TextTaxableAmt.Text + " and Grid Taxable Amt. is :" + colMdTxblAmt.SummaryItem.SummaryValue;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (DoPrint Dp = new DoPrint())
            //        Dp.PrintMrn(TextDoc_NO.Text, DtEntry.DateTime.Date, GlobalVariables.CurrentUser, true);
            //}
            //catch (Exception ex)
            //{
            //    ProjectFunctions.SpeakError("Unable Find Printer Contact IT Department.");
            //}
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Do Stuffs to Save
            Validate.PerformClick();
            try
            {
                if (EntryInfo_GridCtrl.DataSource != null)
                    if (EntryInfo_Grid.RowCount > 0)
                    {
                        (EntryInfo_GridCtrl.DataSource as DataTable).AcceptChanges();
                        if (TextEntryDocType.Text == "MRI")
                        {
                            foreach (DataRow Dr in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
                            {
                                using (DataSet Dsx = ProjectFunctions.GetDataSet("Select PrdCode from PrdMst Where PrdAsgnCode =(Select PrdEAsgnCode From PrdMst where IsNull(PrdEAsgnCode,'0')<>'0' and PrdCode ='" + Dr["MdPrdCode"] + "')"))
                                {
                                    if (Dsx.Tables[0].Rows.Count > 0)
                                        Dr["MdPrdCode"] = Dsx.Tables[0].Rows[0][0];
                                }
                            }
                        }
                        if (!Errorflag) return;
                        else
                        {
                            using (SqlConnection con = new SqlConnection(ProjectFunctions.ConnectionString))
                            {
                                con.Open();
                                SqlCommand command = con.CreateCommand();
                                SqlTransaction transaction = con.BeginTransaction("SaveTransaction");
                                command.Connection = con;
                                command.Transaction = transaction;
                                command.Parameters.Clear();
                                command.CommandText = "[dbo].[SP_Insupd_MrMst4MtrRcptGST]";
                                command.CommandType = CommandType.StoredProcedure;
                                command.Parameters.Add("@MmDocNo", SqlDbType.NVarChar, 4).Value = TextDoc_NO.Text;
                                command.Parameters["@MmDocNo"].Direction = ParameterDirection.InputOutput;

                                command.Parameters.Add("@MmDocDate", SqlDbType.SmallDateTime).Value = DtEntry.DateTime.Date;
                                command.Parameters.Add("@MmDocType", SqlDbType.VarChar, 3).Value = TextEntryDocType.Text;
                                command.Parameters.Add("@MmAccCode", SqlDbType.VarChar, 6).Value = TextSuppCode.Text;
                                command.Parameters.Add("@MmRDocType", SqlDbType.VarChar, 3).Value = TextDocType.Text;
                                command.Parameters.Add("@MmMrType", SqlDbType.VarChar, 3).Value = TextISLC.Text;
                                command.Parameters.Add("@MMPartyType", SqlDbType.VarChar, 4).Value = PurchaseType.Text;
                                command.Parameters.Add("@MmBehalfOfTag", SqlDbType.VarChar, 5).Value = TextBehalfOf.Text;
                                command.Parameters.Add("@MmRegNo", SqlDbType.VarChar, 6).Value = string.Empty;
                                command.Parameters.Add("@MmSplTag", SqlDbType.VarChar, 1).Value = TextChoiceRCO.Text;
                                command.Parameters.Add("@MmCashTag", SqlDbType.VarChar, 1).Value = TextIsCash.Text;
                                command.Parameters.Add("@MmCPartyCode", SqlDbType.VarChar, 6).Value = TextCreditCode.Text;
                                command.Parameters.Add("@MmDivCode", SqlDbType.VarChar, 3).Value = "OTH";
                                command.Parameters.Add("@MmUnitCode", SqlDbType.VarChar, 5).Value = "OTH";
                                command.Parameters.Add("@MmGrsAmtasb", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(TextAsPerBill.Text), 2);

                                command.Parameters.Add("@MMSuppGSTNo", SqlDbType.VarChar, 20).Value = TextSuppGST.Text;
                                //command.Parameters.Add("@MmRDocNetAmtRO", SqlDbType.Decimal).Value = , 
                                command.Parameters.Add("@MMDiscAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextPackingChgs.Text);
                                command.Parameters.Add("@MMSGSTAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextSGSTAmt.Text);
                                command.Parameters.Add("@MMCGSTAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextCGSTAmt.Text);
                                command.Parameters.Add("@MMIGSTAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextIGSTAmt.Text);

                                command.Parameters.Add("@MMSGSTAmtR", SqlDbType.Decimal).Value = Convert.ToDecimal(colMdSGSTAmt.SummaryItem.SummaryValue);
                                command.Parameters.Add("@MMCGSTAmtR", SqlDbType.Decimal).Value = Convert.ToDecimal(colMdCGSTAmt.SummaryItem.SummaryValue);
                                command.Parameters.Add("@MMIGSTAmtR", SqlDbType.Decimal).Value = Convert.ToDecimal(colMdIGSTAmt.SummaryItem.SummaryValue);

                                command.Parameters.Add("@MmRDocNo", SqlDbType.VarChar, 10).Value = TextDocNumber.Text;
                                command.Parameters.Add("@MmRDocdate", SqlDbType.Date).Value = DtDocDate.DateTime.Date;
                                command.Parameters.Add("@MmRDocGrsAmt", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(TextValueOfGoods.Text), 2);
                                command.Parameters.Add("@MmRDocTxbAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(string.IsNullOrEmpty(TextTaxableAmt.Text.ToString()) ? "0" : TextTaxableAmt.Text);
                                command.Parameters.Add("@MmRDocNetAmt", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(TextInvAmount.Text), 2);
                                command.Parameters.Add("@MmFrtPost", SqlDbType.VarChar, 6).Value = TextFrtCode.Text;
                                command.Parameters.Add("@MmFreightAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextFreightAmt.Text);

                                command.Parameters.Add("@MmRemarks", SqlDbType.VarChar, 100).Value = TextRemarks.Text;
                                command.Parameters.Add("@MmNoRs", SqlDbType.Int).Value = EntryInfo_Grid.Columns["PrdName"].SummaryItem.SummaryValue;

                                command.Parameters.Add("@MmMatItemDesc", SqlDbType.NVarChar, 25).Value = TextDescGoods.Text;
                                command.Parameters.Add("@MmTotalQty", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(EntryInfo_Grid.Columns["MdPrdQty"].SummaryItem.SummaryValue.ToString()), 2);
                                command.Parameters.Add("@vMmFinYear", SqlDbType.VarChar, 4).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                command.Parameters.Add("@MmOtherAmt", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(TextRound.Text), 2);
                                command.Parameters.Add("@MmGRDt", SqlDbType.Date).Value = DtDocDate.DateTime.Date;
                                command.Parameters.Add("@vMmDescofGoods", SqlDbType.NVarChar, 30).Value = TextDescGoods.Text;
                                command.Parameters.Add("@MmTptName", SqlDbType.NVarChar, 30).Value = TextTransName.Text;
                                command.Parameters.Add("@vMmGRNo", SqlDbType.NVarChar, 15).Value = TextGrNo.Text;
                                command.Parameters.Add("@MmVehNo", SqlDbType.VarChar, 12).Value = TextVehNo.Text;
                                command.Parameters.Add("@MmACTcRTag", SqlDbType.VarChar, 2).Value = "Y";

                                command.Parameters.Add("@vMmActcBy", SqlDbType.NVarChar, 15).Value = GlobalVariables.CurrentUser;
                                command.Parameters.Add("@vMmActcDt", SqlDbType.DateTime).Value = DateTime.Now;
                                command.Parameters.Add("@MmUpby", SqlDbType.NVarChar, 15).Value = GlobalVariables.CurrentUser;
                                command.Parameters.Add("@MmUpDt", SqlDbType.DateTime).Value = DateTime.Now;
                                command.Parameters.Add("@IsUpdate", SqlDbType.Char, 1).Value = IsUpdate ? "Y" : "N";

                                try
                                {
                                    command.ExecuteNonQuery();
                                    TextDoc_NO.Text = command.Parameters["@MmDocNo"].Value.ToString();
                                    //if (TextIsCash.Text.Equals("N"))
                                    //{


                                    //}
                                    if (IsUpdate)
                                    {
                                        if ((EntryInfo_GridCtrl.DataSource as DataTable).Rows.Count > 0)
                                        {
                                            string Q = string.Format("Delete FROM MrData where MdDocNo='{0}' and MdDocDate='{1:yyyy-MM-dd}' and MdDocType='{2}'", VarOldDocNo, VarOldDOCDt.Date, VarOldDocType);
                                            command.Parameters.Clear();
                                            command.CommandText = Q;
                                            command.CommandType = CommandType.Text;
                                            command.ExecuteNonQuery();

                                            //transaction.Rollback();
                                        }
                                    }
                                    int id = 0;
                                    foreach (DataRow Dr in (EntryInfo_GridCtrl.DataSource as DataTable).Rows)
                                    {
                                        command.Parameters.Clear();
                                        command.CommandText = "[dbo].[Sp_InsUpdMrData4MTRRcptGST]";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.AddWithValue("@colMdPrdCode", Dr["MdPrdCode"]);
                                        command.Parameters.AddWithValue("@colPrdAsgnCode", Dr["PrdAsgnCode"]);

                                        command.Parameters.AddWithValue("@colMdPrdPoNo", Dr["MdPrdPoNo"]);
                                        command.Parameters.AddWithValue("@colMdPrdPoSNO", Dr["MdPrdPoSNO"]);
                                        command.Parameters.AddWithValue("@colMdPrdUOM", Dr["MdPrdUOM"]);
                                        command.Parameters.AddWithValue("@colMdPrdHSNCd", Dr["MdPrdHSNCd"]);
                                        command.Parameters.AddWithValue("@colMdPrdAcode", Dr["MdPrdAcode"]);
                                        command.Parameters.AddWithValue("@colMdPrdQty", Dr["MdPrdQty"]);
                                        command.Parameters.AddWithValue("@colMdDiscAmt", Dr["MdDiscAmt"]);
                                        command.Parameters.AddWithValue("@colMdPrdRate", Dr["MdPrdRate"]);
                                        command.Parameters.AddWithValue("@colMdPrdAmt", Dr["MdPrdAmt"]);
                                        command.Parameters.AddWithValue("@colMdPrdNAmt", Dr["MdPrdNAmt"]);
                                        command.Parameters.AddWithValue("@colMdPrdNRate", Dr["MdPrdNRate"]);
                                        command.Parameters.AddWithValue("@colMdTxblAmt", Dr["MdTxblAmt"]);
                                        command.Parameters.AddWithValue("@colMdCGSTRate", Dr["MdCGSTRate"]);
                                        command.Parameters.AddWithValue("@colMdCGSTAmt", Dr["MdCGSTAmt"]);
                                        command.Parameters.AddWithValue("@colMdSGSTRate", Dr["MdSGSTRate"]);
                                        command.Parameters.AddWithValue("@colMdSGSTAmt", Dr["MdSGSTAmt"]);
                                        command.Parameters.AddWithValue("@colMdIGSTRate", Dr["MdIGSTRate"]);
                                        command.Parameters.AddWithValue("@colMdIGSTAmt", Dr["MdIGSTAmt"]);
                                        command.Parameters.AddWithValue("@colMdPlusAmt", Dr["MdPlusAmt"]);
                                        command.Parameters.AddWithValue("@colMdPrdNAmt1", Dr["MdPrdNAmt1"]);
                                        command.Parameters.AddWithValue("@colMdPrdNRate1", Dr["MdPrdNRate1"]);
                                        command.Parameters.AddWithValue("@IsRevChgs", PurchaseType.Text.ToUpper() == "URGD" ? 1 : 0);
                                        command.Parameters.Add("@MdBehalfOfTag", SqlDbType.Char, 3).Value = TextBehalfOf.Text;
                                        command.Parameters.Add("@MdUnitCode", SqlDbType.Char, 5).Value = "OTH";
                                        command.Parameters.Add("@vMdDocNo", SqlDbType.NVarChar, 4).Value = TextDoc_NO.Text;
                                        command.Parameters.Add("@vMdDocDate", SqlDbType.SmallDateTime).Value = DtEntry.DateTime.Date;
                                        command.Parameters.Add("@vMdDocType", SqlDbType.NVarChar, 3).Value = TextEntryDocType.Text;
                                        command.Parameters.Add("@vMdAccCode", SqlDbType.NVarChar, 6).Value = TextSuppCode.Text;
                                        command.Parameters.Add("@vMdTxnCd", SqlDbType.NVarChar, 1).Value = TextDocType.Text;
                                        command.Parameters.Add("@vMdNart", SqlDbType.NVarChar, 120).Value = String.Format("Received from {0} against {1}-{2} Dt. {3:dd/MM/yyyy}'", TextSuppDesc.Text, TextDocType.Text, TextDocNumber.Text, DtDocDate.DateTime);
                                        command.Parameters.Add("@vMdUserId", SqlDbType.NVarChar, 15).Value = GlobalVariables.CurrentUser;
                                        command.Parameters.Add("@vMdFyear", SqlDbType.NVarChar, 4).Value = ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear);
                                        command.Parameters.Add("@vMdEntrySrNo", SqlDbType.SmallInt).Value = id;
                                        command.Parameters.Add("@vMdSplTag", SqlDbType.NVarChar, 1).Value = TextChoiceRCO.Text;
                                        command.Parameters.Add("@vMdFedDt", SqlDbType.SmallDateTime).Value = DateTime.Now;
                                        command.Parameters.Add("@IsUpdate", SqlDbType.Char, 1).Value = "N";
                                        command.Parameters.Add("@MdCostHeadId", SqlDbType.Int).Value = Dr.IsNull("ID") ? 0 : Convert.ToInt32(Dr["ID"]);
                                        command.Parameters.Add("@MdExpHead", SqlDbType.VarChar, 10).Value = Dr.IsNull("ExpHeadCode") ? string.Empty : Dr["ExpHeadCode"].ToString();
                                        command.Parameters.Add("@vMdId", SqlDbType.Int).Value = 0;
                                        command.ExecuteNonQuery(); id++;
                                    }

                                    command.Parameters.Clear();
                                    command.CommandText = "[dbo].[Sp_InsUpdBilltoPass4MtrRcptGST]";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Add("@vMmDocNo", SqlDbType.NVarChar, 4).Value = TextDoc_NO.Text;
                                    command.Parameters.Add("@vMmCashPurchase", SqlDbType.NVarChar, 1).Value = TextIsCash.Text;
                                    command.Parameters.Add("@vMmDocDate", SqlDbType.SmallDateTime).Value = DtEntry.DateTime.Date;
                                    command.Parameters.Add("@vMmDocType", SqlDbType.NVarChar, 3).Value = TextEntryDocType.Text;
                                    command.Parameters.Add("@vMmPartyCode", SqlDbType.NVarChar, 6).Value = TextSuppCode.Text;
                                    command.Parameters.Add("@vMmRDocType", SqlDbType.NVarChar, 3).Value = TextDocType.Text;
                                    command.Parameters.Add("@vMmRDocNo", SqlDbType.NVarChar, 10).Value = TextDocNumber.Text;
                                    command.Parameters.Add("@vMmRDocdate", SqlDbType.SmallDateTime).Value = DtDocDate.DateTime.Date;
                                    command.Parameters.Add("@vMmRDocNetAmt", SqlDbType.Decimal).Value = Math.Round(Convert.ToDecimal(TextInvAmount.Text), 2);
                                    command.Parameters.Add("@vMmRemarks", SqlDbType.NVarChar, 100).Value = TextRemarks.Text;
                                    command.Parameters.Add("@vMmBillPassed", SqlDbType.NVarChar, 1).Value = "0";
                                    command.Parameters.Add("@vMmCPartyCode", SqlDbType.NVarChar, 6).Value = TextCreditCode.Text;
                                    command.Parameters.Add("@MmBehalfOfTag", SqlDbType.VarChar, 4).Value = TextBehalfOf.Text;
                                    command.Parameters.Add("@MmUnitCode", SqlDbType.VarChar, 6).Value = "OTH";
                                    command.Parameters.Add("@IsUpdate", SqlDbType.Char, 1).Value = IsUpdate ? "Y" : "N";
                                    command.ExecuteNonQuery();

                                    transaction.Commit();
                                    X = true;

                                }
                                catch (Exception ex)
                                {
                                    X = false;
                                    ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);

                                    // Attempt to roll back the transaction. 
                                    try
                                    {
                                        transaction.Rollback();
                                    }
                                    catch (Exception ex2)
                                    {
                                        // This catch block will handle any errors that may have occurred 
                                        // on the server that would cause the rollback to fail, such as 
                                        // a closed connection.
                                        ProjectFunctions.SpeakError("Something Wrong. \n Roll Back Failed." + ex2.Message);
                                    }
                                }

                            }

                        }

                    }
                    else
                        ProjectFunctions.SpeakError("Grid has no Record.");
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Something Wrong." + ex.Message);
            }
            finally { DtEntry.Focus(); }
        }



        private static void ResetControls(Control C)
        {
            foreach (Control ctrl in C.Controls)
                if (ctrl.GetType() == typeof(TextEdit))
                    ctrl.ResetText();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MaterialRecp_TabCtrl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
        }

        private void TextRegNo_Validated(object sender, EventArgs e)
        {
            if (!TextSuppCode.Enabled)
                TextIsCash.Focus();
        }

        private void BtnAttach_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void Attachments_GridCtrl_DoubleClick(object sender, EventArgs e)
        {
        }

        private void Attachments_Grid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnAttachDel_Click(object sender, EventArgs e)
        {
        }

        private void Pend_Po_Btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextProdCode.Text.Trim()))
            {
                CurrentControl = "Pen_Po_BTn";
                ShowHelpWindow(String.Format("Select * from {2} where PrdCode='{0}' " + (TextChoiceRCO.Text == "R" ? "and PartyCode='{1}' " : string.Empty) + " ;", TextProdCode.Text, TextSuppCode.Text, (TextChoiceRCO.Text == "R" ? "V_Pending_PO" : "V_Pending_Indent")));
            }
        }

        private void TextRemarks_Enter(object sender, EventArgs e)
        {
            TextRemarks.Text = "BEING PURC. OF ";
        }

        private void BtnZoomPrd_Click(object sender, EventArgs e)
        {

        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("calc.exe");
        }

        private void TextProdRate_Enter(object sender, EventArgs e)
        {
            if (_MRI == "MRI")
                TextProdRate.Properties.Mask.EditMask = "N5";

        }

        private void textEdit1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (DtEntry.DateTime.Date > Convert.ToDateTime("2015-03-31"))
                    using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("select [Qnty. Ord.], [Qnty. Rcvd.] from [{2}] where [PO No]= '{0}'and [Sub No.]='{1}'; Select prdgrpcode from PrdMst where PrdCode='" + TextProdCode.Text + "'", TextProdPONO.Text, textEdit1.Text, (TextChoiceRCO.Text == "R" ? "V_Pending_PO" : "V_Pending_Indent"))))
                        if (Ds != null)
                        {
                            using (DataTable Dt1 = Ds.Tables[1])
                            {
                                DataTable Dt = Ds.Tables[0];
                                if (!(Dt.Rows.Count > 0))
                                {
                                    ProjectFunctions.SpeakError("Unable to Find This PONO.");
                                    TextProdPONO.Focus();
                                    return;
                                }
                                oldPOqntyord = Convert.ToDecimal(Dt.Rows[0][0].ToString());
                                oldPOqntyRcvd = Convert.ToDecimal(Dt.Rows[0][1].ToString());
                                Decimal Qntys = 0;
                                if (IsUpdate && BtnOK.Text == "&Update")
                                {
                                    int rowHandle = ProjectFunctions.GetRowHandleByColumnValue(EntryInfo_Grid, "Id", id);
                                    Qntys += Convert.ToDecimal(EntryInfo_Grid.GetRowCellValue(rowHandle, EntryInfo_Grid.Columns["MdPrdQty"]));

                                }
                                TextPOStock.EditValue = ((oldPOqntyord * Convert.ToDecimal(1.05) - oldPOqntyRcvd)) + Qntys;
                            }
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("Unable to Find This PONO.");
                            TextProdPONO.Focus();
                        }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
        }

        private void DtEntry_EditValueChanged(object sender, EventArgs e)
        {
            AuthenticateFlag = false;
        }

        private void CaptureChanges(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Save.Enabled = false;
        }

        private void TextAuthenticate_Leave(object sender, EventArgs e)
        {
            string authenticate = String.Format("dbo.Sp_Authenticate '{0:yyyy-MM-dd}', '{1}', '{2}','{3}'", DtEntry.DateTime.Date, GlobalVariables.CurrentUser, TextAuthenticate.Text.Trim(), IsUpdate ? Name + "_Y" : Name);
            using (DataSet Ds = ProjectFunctions.GetDataSet(authenticate))
            {
                if (Ds.Tables[0].Rows[0][0].ToString().Equals("Y"))
                {
                    if (!IsUpdate)
                    {
                        string query = String.Format("SELECT isnull(MAX([MmDocNo]),0000) as Value FROM MrMst WHERE MMDocType='{0}' AND MmDocDate='{1}' and MmFinYear='{2}';", TextEntryDocType.Text.Trim(), DtEntry.DateTime.ToString("yyyy-MM-dd"), ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear));

                        DataSet ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextDoc_NO.Text = (int.Parse((ds.Tables[0].Rows[0]["Value"].ToString())) + 1).ToString().PadLeft(4, '0');
                            Error.Dispose();
                            TextChoiceRCO.Focus();
                            AuthenticateFlag = true;
                            //DtEntry.Focus();
                            TextAuthenticate.Visible = false;
                        }
                    }
                    else
                    {
                        Error.Dispose();
                        TextChoiceRCO.Focus();
                        AuthenticateFlag = true;
                        //DtEntry.Focus();
                        TextAuthenticate.Visible = false;
                    }
                }
                else
                {
                    //ProjectFunctions.SpeakError("You have Entered Wrong Password.");
                    TextAuthenticate.Visible = true;
                    TextAuthenticate.Focus();
                }

            }
        }

        private void TextDocNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                string s = DtDocDate.DateTime.ToString("dd/MM/yyyy");
                s = s.Replace('-', '/');
                string query = String.Format("SELECT [MmRDocNo] FROM [dbo].[MrMst]  where MMDocType='" + _MRI + "' And MmFinYear='{4}'  and MmAccCode='{1}'  and MmRDocNo='{3}'  and MmRDocNo<>'{6}'; ", s, TextSuppCode.Text.Trim(), string.Empty, TextDocNumber.Text.Trim(), ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear), TextDocType.Text, !IsUpdate ? "0" : oldtDocNum);

                using (DataSet ds = ProjectFunctions.GetDataSet(query))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Error.SetError(TextDocNumber, "The DocNo. for this Party at the given Date might be Duplicate.");
                        TextDocNumber.Focus();
                    }
                    else
                        Error.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.SetError(DtDocDate, " Please Check Or Contact IT Department.\n" + ex.Message);
                DtDocDate.Focus();
            }
        }

        private void TextAuthenticate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string authenticate = String.Format("dbo.Sp_Authenticate '{0:yyyy-MM-dd}', '{1}', '{2}','{3}'", DtEntry.DateTime.Date, GlobalVariables.CurrentUser, TextAuthenticate.Text.Trim(), IsUpdate ? Name + "_Y" : Name);
                using (DataSet Ds = ProjectFunctions.GetDataSet(authenticate))
                {
                    if (Ds.Tables[0].Rows[0][0].ToString().Equals("Y"))
                    {
                        if (!IsUpdate)
                        {
                            string query = String.Format("SELECT isnull(MAX([MmDocNo]),0000) as Value FROM MrMst WHERE MMDocType='{0}' AND MmDocDate='{1}' and MmFinYear='{2}';", TextEntryDocType.Text.Trim(), DtEntry.DateTime.ToString("yyyy-MM-dd"), ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear));

                            DataSet ds = ProjectFunctions.GetDataSet(query);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                TextDoc_NO.Text = (int.Parse((ds.Tables[0].Rows[0]["Value"].ToString())) + 1).ToString().PadLeft(4, '0');
                                Error.Dispose();
                                TextChoiceRCO.Focus();
                                AuthenticateFlag = true;
                                //DtEntry.Focus();
                                TextAuthenticate.Visible = false;
                            }
                        }
                        else
                        {
                            Error.Dispose();
                            TextChoiceRCO.Focus();
                            AuthenticateFlag = true;
                            //DtEntry.Focus();
                            TextAuthenticate.Visible = false;
                        }
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("You have Entered Wrong Password.");
                        TextAuthenticate.Visible = true;
                        TextAuthenticate.Focus();
                    }

                }
            }
        }

        private void TextProdAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextMdPrdTxbAmt.Text = (Convert.ToDecimal(TextProdAmount.Text) + Convert.ToDecimal(TextPrdPackingAmt.Text) + Convert.ToDecimal(TextPrdPlusAmt.Text) + (Convert.ToDecimal(TextPrdSGSTAmt.Text)) + Convert.ToDecimal(TextPrdCGSTAmt.Text) + (Convert.ToDecimal(TextPrdIGSTAmt.Text))).ToString();
        }

        private void TextProdRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(TextProdRate.Text) <= 0)
                    e.Cancel = true;
            }
            catch (Exception) { e.Cancel = true; }
        }

        private void TextFrtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Convert.ToDecimal(TextFreightAmt.Text) != 0) && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Escape))
            {
                //  HelpGridCtrl.Width = 400;
                CurrentControl = "TextFrtCode";
                string Query = "SELECT     ActMst.AccName as 'AC Name', ActMst.AccCode as 'AC Code' FROM  ActMst  order by ActMst.AccName ;";
                if (TextFrtCode.Text.Trim().Length == 0)
                {
                    //Display Help Window
                    ShowHelpWindow(Query);
                }
                else
                {
                    //Checking whether Value  is Existing or not!
                    string query = String.Format("SELECT     ActMst.AccName as 'AC Name', ActMst.AccCode as 'AC Code' FROM  ActMst where ActMst.AccCode='{0}' order by ActMst.AccName ;", TextFrtCode.Text.Trim());
                    DataSet ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TxtFrtDesc.Text = ds.Tables[0].Rows[0]["AC Name"].ToString();
                        TextFrtCode.Text = ds.Tables[0].Rows[0]["AC Code"].ToString();
                        TextFreightAmt.Focus();
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
                TextFreightAmt.Focus();
            }
        }

        private void TextFreightAmt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (Convert.ToDecimal(TextFreightAmt.Text) < 0)
            //    e.Cancel = true;
            if (Convert.ToDecimal(TextFreightAmt.Text) > 0)
            {
                e.Cancel = false;
                TextFrtCode.Focus();
            }
        }

        private void EntryInfo_Grid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Base.ColumnView View = sender as DevExpress.XtraGrid.Views.Base.ColumnView;

            View.SetRowCellValue(e.RowHandle, colMdPrdCode, TextProdCode.Text);
            View.SetRowCellValue(e.RowHandle, colPrdAsgnCode, TextProdAsgnCode.Text);
            View.SetRowCellValue(e.RowHandle, colPrdName, TextProdDesc.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdPoNo, TextProdPONO.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdPoSNO, textEdit1.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdUOM, TextUOM.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdHSNCd, TextPrdHSNCd.Text);

            View.SetRowCellValue(e.RowHandle, gridColumn1, TextAcPostingCode.Text);
            View.SetRowCellValue(e.RowHandle, gridColumn2, TextAcPostDesc.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdQty, TextProdQnty.Text);

            View.SetRowCellValue(e.RowHandle, colMdPrdRate, TextProdRate.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdAmt, TextProdAmount.Text);
            View.SetRowCellValue(e.RowHandle, colMdDiscAmt, TextPrdPackingAmt.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdNAmt, Convert.ToDecimal(TextProdTotalAmt.Text));
            View.SetRowCellValue(e.RowHandle, colMdPrdNRate, Convert.ToDecimal(TextProdTotalAmt.Text) / Convert.ToDecimal(TextProdQnty.Text));

            View.SetRowCellValue(e.RowHandle, colID, VarCostId);
            View.SetRowCellValue(e.RowHandle, colCostCode, TextCostCode.Text);
            View.SetRowCellValue(e.RowHandle, colCostSubCode, TextCostSubCode.Text);
            View.SetRowCellValue(e.RowHandle, colExpHeadCode, TextExpHeadCode.Text);

            View.SetRowCellValue(e.RowHandle, colCostDesc, TextCostDesc.Text);
            View.SetRowCellValue(e.RowHandle, colCostSubDesc, TextCostSubCodeDesc.Text);
            View.SetRowCellValue(e.RowHandle, colExpHeadDesc, TextExpHeadDesc.Text);

            View.SetRowCellValue(e.RowHandle, colMdTxblAmt, TextMdPrdTxbAmt.Text);
            View.SetRowCellValue(e.RowHandle, colMdCGSTRate, TextPrdCGSTRate.Text);
            View.SetRowCellValue(e.RowHandle, colMdCGSTAmt, TextPrdCGSTAmt.Text);
            View.SetRowCellValue(e.RowHandle, colMdSGSTRate, TextPrdSGSTRate.Text);
            View.SetRowCellValue(e.RowHandle, colMdSGSTAmt, TextPrdSGSTAmt.Text);
            View.SetRowCellValue(e.RowHandle, colMdIGSTRate, TextPrdIGSTRate.Text);
            View.SetRowCellValue(e.RowHandle, colMdIGSTAmt, TextPrdIGSTAmt.Text);
            View.SetRowCellValue(e.RowHandle, colMdPlusAmt, TextPrdPlusAmt.Text);
            View.SetRowCellValue(e.RowHandle, colMdPrdNAmt1, Convert.ToDecimal(TextProdTotalAmt.Text) - Convert.ToDecimal(TextPrdPlusAmt.Text));
            View.SetRowCellValue(e.RowHandle, colMdPrdNRate1, (Convert.ToDecimal(TextProdTotalAmt.Text) - Convert.ToDecimal(TextPrdPlusAmt.Text)) / Convert.ToDecimal(TextProdQnty.Text));

            View.EndInit();
        }

        private void TextPlusAmt_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                TextMdPrdTxbAmt.Text = (Convert.ToDecimal(TextProdAmount.Text) + Convert.ToDecimal(TextPrdPackingAmt.Text) + Convert.ToDecimal(TextPrdPlusAmt.Text) + (Convert.ToDecimal(TextPrdSGSTAmt.Text)) + Convert.ToDecimal(TextPrdCGSTAmt.Text) + (Convert.ToDecimal(TextPrdIGSTAmt.Text))).ToString();
            }
            catch (Exception) { e.Cancel = true; }


        }

        private void TextProdTotalAmt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //TextProdTotalAmt.Text = (Convert.ToDecimal(TextMdPrdTxbAmt.Text) + Convert.ToDecimal(TextMdPrdTaxAmt.Text) + Convert.ToDecimal(TextPrdSTaxAmt.Text)).ToString();
        }

        private void TextAsPerBill_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal((sender as TextEdit).Text) <= 0)
                { (sender as TextEdit).ErrorText = "Amount As Per Bill."; e.Cancel = true; }
            }
            catch (Exception) { e.Cancel = true; }
        }

        private void TextChoiceRCO_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (!((sender as TextEdit).Text == "R" || (sender as TextEdit).Text == "C" || (sender as TextEdit).Text == "O"))
                {
                    (sender as TextEdit).ErrorText = "Valid Values are R/C/O";
                    e.Cancel = true;
                }
            }
            catch (Exception) { e.Cancel = true; }
        }




        private void TextInvAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Convert.ToDecimal(TextInvAmount.Text) != Convert.ToDecimal(TextAsPerBill.Text))
            {
                ProjectFunctions.SpeakError("Diff. " + (Convert.ToDecimal(TextInvAmount.Text) - Convert.ToDecimal(TextAsPerBill.Text)));
                TextFreightAmt.Text = (Convert.ToDecimal(TextFreightAmt.Text) + (Convert.ToDecimal(TextInvAmount.Text) - Convert.ToDecimal(TextAsPerBill.Text))).ToString();
                TextFreightAmt.Focus();
            }
        }

        private void TextInvAmount_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Decimal temp = 0;
            decimal.TryParse(TextValueOfGoods.Text, out temp);
            TextValueOfGoods.Text = temp.ToString();

            temp = 0;
            decimal.TryParse(TextPackingChgs.Text, out temp);
            TextPackingChgs.Text = temp.ToString();

            temp = 0;
            decimal.TryParse(TextFreightAmt.Text, out temp);
            TextFreightAmt.Text = temp.ToString();

            TextTaxableAmt.Text = (Convert.ToDecimal(TextFreightAmt.Text) + Convert.ToDecimal(TextValueOfGoods.Text) + Convert.ToDecimal(TextPackingChgs.Text)).ToString();

            temp = 0;
            decimal.TryParse(TextSGSTAmt.Text, out temp);
            TextSGSTAmt.Text = temp.ToString();

            temp = 0;
            decimal.TryParse(TextCGSTAmt.Text, out temp);
            TextCGSTAmt.Text = temp.ToString();

            temp = 0;
            decimal.TryParse(TextIGSTAmt.Text, out temp);
            TextIGSTAmt.Text = temp.ToString();

            TextTotalAmt.Text = (Convert.ToDecimal(TextTaxableAmt.Text) + Convert.ToDecimal(TextSGSTAmt.Text) + Convert.ToDecimal(TextCGSTAmt.Text) + Convert.ToDecimal(TextIGSTAmt.Text)).ToString();

            temp = 0;
            decimal.TryParse(TextRound.Text, out temp);
            TextRound.Text = temp.ToString();


            TextInvAmount.Text = (Convert.ToDecimal(TextRound.Text) + Convert.ToDecimal(TextTotalAmt.Text)).ToString();


        }

        private void TextTotalAmt_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TextAcPostingCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Escape)
            {
                //  HelpGridCtrl.Width = 400;
                CurrentControl = "TextAcPostingCode";
                string Query = "SELECT     ActMst.AccName as 'AC Name', ActMst.AccCode as 'AC Code' FROM  ActMst  order by ActMst.AccName ;";
                if (TextAcPostingCode.Text.Trim().Length == 0)
                {
                    //Display Help Window
                    //TextProdCode.Focus();
                    ShowHelpWindow(Query);
                }
                else
                {
                    //Checking whether Value  is Existing or not!
                    TextAcPostingCode.Text = TextAcPostingCode.Text.PadLeft(4, '0');
                    string query = String.Format("SELECT     ActMst.AccName as 'AC Name', ActMst.AccCode as 'AC Code' FROM  ActMst where ActMst.AccCode='{0}' order by ActMst.AccName ;", TextAcPostingCode.Text.Trim());
                    DataSet ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TextAcPostDesc.Text = ds.Tables[0].Rows[0]["AC Name"].ToString();
                        TextAcPostingCode.Text = ds.Tables[0].Rows[0]["AC Code"].ToString();
                        BtnOK.Enabled = true;
                        if (_MRI == "SVC")
                        {
                            CheckService();

                        }
                        else
                            TextProdQnty.Focus();
                    }
                    else
                    {
                        // Display Help Window
                        TextProdCode.Focus();
                        // ShowHelpWindow(Query);
                    }
                }
                e.Handled = true;
            }

            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                BtnOK.Focus();
            }

        }

        private void TextProdQnty_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal xd = Math.Round(Convert.ToDecimal(100.00), 2);
            Decimal temp = 0;
            decimal.TryParse(TextProdQnty.Text, out temp);
            TextProdQnty.Text = temp.ToString();

            temp = 0;
            decimal.TryParse(TextProdRate.Text, out temp);
            TextProdRate.Text = temp.ToString();

            TextProdAmount.Text = Math.Round((Convert.ToDecimal(TextProdRate.Text) * Convert.ToDecimal(TextProdQnty.Text)), 2).ToString();

            temp = 0;
            decimal.TryParse(TextPrdPackingAmt.Text, out temp);
            TextPrdPackingAmt.Text = temp.ToString();

            TextMdPrdTxbAmt.Text = Math.Round((Convert.ToDecimal(TextProdAmount.Text) - Convert.ToDecimal(TextPrdPackingAmt.Text)), 2).ToString();

            temp = 0;
            decimal.TryParse(TextPrdCGSTRate.Text, out temp);
            TextPrdCGSTRate.Text = temp.ToString();

            if (Convert.ToDecimal(TextPrdCGSTAmt.Text) == 0)
                TextPrdCGSTAmt.Text = Math.Round((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdCGSTRate.Text)) / xd, 2).ToString();
            else
            {
                temp = 0;
                decimal.TryParse(TextPrdCGSTAmt.Text, out temp);
                decimal x = ((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdCGSTRate.Text)) / xd) - (((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdCGSTRate.Text)) / xd) % 1);
                if (Math.Abs(temp - x) <= 1)
                {

                }
                else { TextPrdCGSTAmt.Text = Math.Round((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdCGSTRate.Text)) / xd, 2).ToString(); }

            }

            temp = 0;
            decimal.TryParse(TextPrdSGSTRate.Text, out temp);
            TextPrdSGSTRate.Text = temp.ToString();

            if (Convert.ToDecimal(TextPrdSGSTAmt.Text) == 0)
                TextPrdSGSTAmt.Text = Math.Round((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdSGSTRate.Text)) / xd, 2).ToString();
            else
            {
                temp = 0;
                decimal.TryParse(TextPrdSGSTAmt.Text, out temp);
                decimal x = ((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdSGSTRate.Text)) / xd) - ((((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdSGSTRate.Text)) / xd)) % 1);
                if (Math.Abs(temp - x) <= 1)
                {

                }
                else { TextPrdSGSTAmt.Text = Math.Round((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdSGSTRate.Text)) / xd, 2).ToString(); }

            }

            temp = 0;
            decimal.TryParse(TextPrdIGSTRate.Text, out temp);
            TextPrdIGSTRate.Text = temp.ToString();

            if (Convert.ToDecimal(TextPrdIGSTAmt.Text) == 0)
                TextPrdIGSTAmt.Text = Math.Round((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdIGSTRate.Text)) / xd, 2).ToString();
            else
            {
                temp = 0;
                decimal.TryParse(TextPrdIGSTAmt.Text, out temp);
                decimal x = ((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdIGSTRate.Text)) / xd) - (((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdIGSTRate.Text)) / xd) % 1);
                if (Math.Abs(temp - x) <= 1)
                {

                }
                else { TextPrdIGSTAmt.Text = Math.Round((Convert.ToDecimal(TextMdPrdTxbAmt.Text) * Convert.ToDecimal(TextPrdIGSTRate.Text)) / xd, 2).ToString(); }

            }

            temp = 0;
            decimal.TryParse(TextPrdPlusAmt.Text, out temp);
            TextPrdPlusAmt.Text = temp.ToString();

            TextProdTotalAmt.Text = (Convert.ToDecimal(TextMdPrdTxbAmt.Text) + Convert.ToDecimal(TextPrdCGSTAmt.Text) +
                Convert.ToDecimal(TextPrdSGSTAmt.Text) + Convert.ToDecimal(TextPrdIGSTAmt.Text) + Convert.ToDecimal(TextPrdPlusAmt.Text)).ToString();

        }

        private void TextProdTotalAmt_Validated(object sender, EventArgs e)
        {
            BtnOK.Enabled = true;
            BtnOK.Focus();
        }

        private void DtEntry_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateEdit x = (sender as DateEdit);
            if (!(x.DateTime.Date >= GlobalVariables.FinYearStartDate.Date && x.DateTime.Date <= GlobalVariables.FinYearEndDate.Date))
            {
                e.Cancel = true;
            }
            Print.Enabled = false;
            Save.Enabled = false;
            try
            {
                //i have to correct it
                if (!ProjectFunctions.CheckRange(DtEntry.DateTime, GlobalVariables.FinYearStartDate.Date, (DateTime.Now >= GlobalVariables.FinYearStartDate && DateTime.Now <= GlobalVariables.FinYearEndDate) ? DateTime.Now.Date : GlobalVariables.FinYearEndDate.Date))
                {
                    DtEntry.Focus();
                    Error.SetError(DtEntry, "Date does not fall in Expected Range. Either You are crossign FinancialYear Limit or Crossing Today Limit.");
                    return;
                }
                else
                {
                    if ((DtEntry.DateTime.Date == DateTime.Now.Date || AuthenticateFlag) && !IsUpdate)
                    {
                        string query = String.Format("SELECT isnull(MAX([MmDocNo]),0000) as Value FROM MrMst WHERE MMDocType='{0}' AND MmDocDate='{1}' and MmFinYear='{2}';", TextEntryDocType.Text.Trim(), DtEntry.DateTime.ToString("yyyy-MM-dd"), ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear));

                        DataSet ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextDoc_NO.Text = (int.Parse((ds.Tables[0].Rows[0]["Value"].ToString())) + 1).ToString().PadLeft(4, '0');
                            Error.Dispose();
                            TextChoiceRCO.Focus();
                            //DtEntry.Focus();
                            TextAuthenticate.Visible = false;
                        }
                    }
                    else
                    {
                        TextAuthenticate.Visible = true;
                        TextAuthenticate.Focus();
                    }

                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //Error.SetError(DtEntry);
            }
            Print.Enabled = false;
            Save.Enabled = false;
            try
            {
                //i have to correct it
                if (!ProjectFunctions.CheckRange(DtEntry.DateTime, GlobalVariables.FinYearStartDate.Date, (DateTime.Now >= GlobalVariables.FinYearStartDate && DateTime.Now <= GlobalVariables.FinYearEndDate) ? DateTime.Now.Date : GlobalVariables.FinYearEndDate.Date))
                {
                    DtEntry.Focus();
                    Error.SetError(DtEntry, "Date does not fall in Expected Range. Either You are crossign FinancialYear Limit or Crossing Today Limit.");
                    return;
                }
                else
                {
                    if ((DtEntry.DateTime.Date == DateTime.Now.Date || AuthenticateFlag) && !IsUpdate)
                    {
                        string query = String.Format("SELECT isnull(MAX([MmDocNo]),0000) as Value FROM MrMst WHERE MMDocType='{0}' AND MmDocDate='{1}' and MmFinYear='{2}';", TextEntryDocType.Text.Trim(), DtEntry.DateTime.ToString("yyyy-MM-dd"), ProjectFunctions.ClipFYearN(GlobalVariables.FinancialYear));

                        DataSet ds = ProjectFunctions.GetDataSet(query);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextDoc_NO.Text = (int.Parse((ds.Tables[0].Rows[0]["Value"].ToString())) + 1).ToString().PadLeft(4, '0');
                            Error.Dispose();
                            TextChoiceRCO.Focus();
                            //DtEntry.Focus();
                            TextAuthenticate.Visible = false;
                        }
                    }
                    else
                    {
                        TextAuthenticate.Visible = true;
                        TextAuthenticate.Focus();
                    }

                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //Error.SetError(DtEntry);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //new SVC_Form().ShowDialog(this);
        }

        private void TextPrdHSNCd_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (TextProdCode.Text.Length > 0)
            //    if (TextPrdHSNCd.Text.Trim().Length >= 4)
            //    {
            //        if (ProjectFunctions.GetDataSet("Select GSTCode,GSTDesc From GstMst Where GSTCode like '" + TextPrdHSNCd.Text + "%'").Tables[0].Rows.Count > 0)
            //        {
            //            CurrentControl = "TextPrdHSNCd";
            //            ShowHelpWindow("Select GSTCode,GSTDesc From GstMst Where GSTCode like '" + TextPrdHSNCd.Text + "%' Union All Select 'X', 'Add New';");
            //        }
            //        else
            //        {
            //            HelpGridCtrl.Visible = false;

            //        }
            //    }
        }

        private void TextCostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || e.KeyCode == Keys.LButton || e.KeyCode == Keys.LButton || e.KeyCode == Keys.Escape)
            {
                //  HelpGridCtrl.Width = 400;
                CurrentControl = "TextCostCode";
                const string Query = "SELECT CostCode, CostDesc,  CostSubDesc ,CostSubCode,ID from CostMst  WHERE (((CostMst.CostSubcode)<>'' And (CostMst.CostSubcode) Is Not Null)) ORDER BY CostDesc  ;";
                if (TextCostCode.Text.Trim().Length == 0)
                {
                    //Display Help Window
                    //TextProdCode.Focus();
                    ShowHelpWindow(Query);
                }
                else
                {
                    //Checking whether Value  is Existing or not!
                    string query = String.Format("SELECT CostCode, CostDesc,  CostSubDesc ,CostSubCode,ID from CostMst  WHERE  (((CostMst.Costcode)='{0}' And IsNull(CostMst.CostSubcode,'') ='{1}')) ORDER BY CostDesc  ;", TextCostCode.Text.Trim(), TextCostSubCode.Text);
                    DataSet ds = ProjectFunctions.GetDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        var row = ds.Tables[0].Rows[0];
                        TextCostCode.Text = row["CostCode"].ToString();
                        TextCostDesc.Text = row["CostDesc"].ToString();
                        TextCostSubCodeDesc.Text = row["CostSubDesc"].ToString();
                        TextCostSubCode.Text = row["CostSubCode"].ToString();
                        VarCostId = row["ID"].ToString();
                        CurrentControl = string.Empty;
                        HelpGridCtrl.Visible = false;
                        TextExpHeadCode.Focus();
                    }
                    else
                    {
                        // Display Help Window
                        TextProdCode.Focus();
                        // ShowHelpWindow(Query);
                    }
                }
                e.Handled = true;
            }

            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                BtnOK.Focus();
            }

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}