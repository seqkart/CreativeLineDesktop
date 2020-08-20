using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frm_EmpSalAddUpdate : XtraForm
    {
#pragma warning disable CS0414 // The field 'frm_EmpSalAddUpdate.EmpDummy' is assigned but its value is never used
        String EmpDummy = string.Empty;
#pragma warning restore CS0414 // The field 'frm_EmpSalAddUpdate.EmpDummy' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'frm_EmpSalAddUpdate.BankName' is assigned but its value is never used
        String BankName = string.Empty;
#pragma warning restore CS0414 // The field 'frm_EmpSalAddUpdate.BankName' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'frm_EmpSalAddUpdate.BankIfscCode' is assigned but its value is never used
        String BankIfscCode = string.Empty;
#pragma warning restore CS0414 // The field 'frm_EmpSalAddUpdate.BankIfscCode' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'frm_EmpSalAddUpdate.BankAccNo' is assigned but its value is never used
        String BankAccNo = string.Empty;
#pragma warning restore CS0414 // The field 'frm_EmpSalAddUpdate.BankAccNo' is assigned but its value is never used

        private string CurrentControl = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FinancialYear { get; set; }
        public string CurrentUser { get; set; }
        public string Company { get; set; }
        public DateTime CFinStart { get; set; }
        public DateTime CFinEnd { get; set; }
        public string CAdd { get; set; }
        public string CCode { get; set; }

        public string MMDocNo { get; set; }
        public string MMDocNo1 { get; set; }
        public bool IsUpdate { get; set; }
        public string sql1 = string.Empty;
        public int DaysInMonth { get; set; }

        public frm_EmpSalAddUpdate()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void dorestrict()
        {
            var Dt = Convert.ToDateTime(TextMonth.EditValue);
            DaysInMonth = DateTime.DaysInMonth(Dt.Year, Dt.Month);
        }
        private void TotalDays()
        {
            if (TextWorked.Text.Length == 0)
            {
                TextWorked.Text = "0";
            }
            if (TextPaidHolidays.Text.Length == 0)
            {
                TextPaidHolidays.Text = "0";
            }
            if (TextEarned.Text.Length == 0)
            {
                TextEarned.Text = "0";
            }
            if (TextCasual.Text.Length == 0)
            {
                TextCasual.Text = "0";
            }
            if (TextSick.Text.Length == 0)
            {
                TextSick.Text = "0";
            }


            txtTotalDays.Text = (Convert.ToDecimal(TextWorked.Text) + Convert.ToDecimal(TextPaidHolidays.Text) + Convert.ToDecimal(TextEarned.Text) + Convert.ToDecimal(TextCasual.Text) + Convert.ToDecimal(TextSick.Text)).ToString("0.00");
        }
        private void frm_EmpSalAddUpdate_Load(object sender, EventArgs e)
        {
            txtTotalDays.Enabled = false;
            SetMyControls();
            foreach (Control c in panelControl1.Controls)
            {
                if (c.GetType() == typeof(TextEdit) || c.GetType() == typeof(CalcEdit))
                {
                    var thiscontrol = (TextEdit)c;
                    if (thiscontrol.Properties.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric)
                    {
                        thiscontrol.Properties.Mask.EditMask = "N2";
                    }
                }
            }
            foreach (Control c in panelControl5.Controls)
            {
                if (c.GetType() == typeof(TextEdit) || c.GetType() == typeof(CalcEdit))
                {
                    var thiscontrol = (TextEdit)c;
                    if (thiscontrol.Properties.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric)
                    {
                        thiscontrol.Properties.Mask.EditMask = "N0";
                    }
                }
            }
            foreach (Control c in panelControl3.Controls)
            {
                if (c.GetType() == typeof(TextEdit) || c.GetType() == typeof(CalcEdit))
                {
                    var thiscontrol = (TextEdit)c;
                    if (thiscontrol.Properties.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric)
                    {
                        thiscontrol.Properties.Mask.EditMask = "N2";
                    }
                }
            }
            foreach (Control c in panelControl4.Controls)
            {
                if (c.GetType() == typeof(TextEdit) || c.GetType() == typeof(CalcEdit))
                {
                    var thiscontrol = (TextEdit)c;
                    if (thiscontrol.Properties.Mask.MaskType == DevExpress.XtraEditors.Mask.MaskType.Numeric)
                    {
                        thiscontrol.Properties.Mask.EditMask = "N0";
                    }
                }
            }
            TextMonth.EditValue = DateTime.Now.Date;
            if (IsUpdate)
            {
                var sql = "SELECT        DeptMst.DeptDesc, empmst.EmpName, AtnData.EmpCode, CAST('20' +Right(MonthYear,2)+Left(MonthYear,2) +'01' As Datetime)As MonthYear, AtnData.EmpDW, AtnData.EmpPH, AtnData.EmpEL,  "
                                 + " AtnData.EmpCL, AtnData.EmpSL, AtnData.EmpOT, AtnData.EmpAdvAmt, AtnData.EmpLoanAmt, AtnData.EmpTdsAmt, AtnData.EmpMiscDed1,AtnData.EmpMiscDed2,  "
                                 + "  AtnData.EmpMiscAlw1, AtnData.EmpMiscAlw2, AtnData.EmpMiscAlw3, AtnData.EmpLockTag, AtnData.EmpPrePaidSal, AtnData.EmpEntryNo,AtnData.EmpML,AtnData.EmpPymtMode "
                                 + " FROM            empmst INNER JOIN  "
                                 + " AtnData ON empmst.EmpCode = AtnData.EmpCode Inner Join"
                                 + " DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode "
                                 + "   where AtnData.EmpCode='" + MMDocNo + "' and AtnData.MonthYear='" + MMDocNo1 + "'";


                using (var DS = ProjectFunctions.GetDataSet(sql))
                {
                    if (DS.Tables[0] != null)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                TextMonth.EditValue = Convert.ToDateTime(DS.Tables[0].Rows[0]["MonthYear"]).Date;
                                TextMonth.Enabled = false;
                                TextCode.Text = DS.Tables[0].Rows[0]["EmpCode"].ToString();
                                TextCode.Enabled = false;
                                TextCodeDesc.Text = DS.Tables[0].Rows[0]["EmpName"].ToString();
                                TextDepartment.Text = DS.Tables[0].Rows[0]["DeptDesc"].ToString();
                                TextWorked.Text = DS.Tables[0].Rows[0]["EmpDW"].ToString();
                                TextPaidHolidays.EditValue = DS.Tables[0].Rows[0]["EmpPH"].ToString();
                                TextOverTime.Text = DS.Tables[0].Rows[0]["EmpOT"].ToString();
                                TextEarned.EditValue = DS.Tables[0].Rows[0]["EmpEL"].ToString();
                                TextCasual.EditValue = DS.Tables[0].Rows[0]["EmpCL"].ToString();
                                TextSick.EditValue = DS.Tables[0].Rows[0]["EmpSL"].ToString();
                                TextMisc1.Text = DS.Tables[0].Rows[0]["EmpMiscAlw1"].ToString();
                                TextMisc2.Text = DS.Tables[0].Rows[0]["EmpMiscAlw2"].ToString();
                                TextMisc3.Text = DS.Tables[0].Rows[0]["EmpMiscAlw3"].ToString();
                                TextAdvances.Text = DS.Tables[0].Rows[0]["EmpAdvAmt"].ToString();
                                TextLoanAmt.Text = DS.Tables[0].Rows[0]["EmpLoanAmt"].ToString();
                                TextDeducMisc.Text = DS.Tables[0].Rows[0]["EmpMiscDed1"].ToString();
                                TextTdsAmt.Text = DS.Tables[0].Rows[0]["EmpTdsAmt"].ToString();
                                TextPrePaidTag.Text = DS.Tables[0].Rows[0]["EmpPrePaidSal"].ToString();
                                txtMaternityLeave.Text = DS.Tables[0].Rows[0]["EmpML"].ToString();
                                //txtFood.Text = DS.Tables[0].Rows[0]["EmpFoodAlw"].ToString();
                                txtMiscDedNew.Text = DS.Tables[0].Rows[0]["EmpMiscDed2"].ToString();
                                txtPaymentMode.Text = DS.Tables[0].Rows[0]["EmpPymtMode"].ToString();
                                //TextFlexiAlw.Text = DS.Tables[0].Rows[0]["EmpFlexiAlw"].ToString();



                            }
                            catch
                            {
                                XtraMessageBox.Show("!Error");
                            }
                        }
                    }
                }
            }
            dorestrict();
            TotalDays();



        }

        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.DatePickerVisualize(panelControl1);
            ProjectFunctions.TextBoxVisualize(panelControl2);
            ProjectFunctions.DatePickerVisualize(panelControl2);
            ProjectFunctions.TextBoxVisualize(panelControl3);
            ProjectFunctions.DatePickerVisualize(panelControl3);
            ProjectFunctions.TextBoxVisualize(panelControl4);
            ProjectFunctions.DatePickerVisualize(panelControl4);
            ProjectFunctions.TextBoxVisualize(panelControl5);
            ProjectFunctions.DatePickerVisualize(panelControl5);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.ButtonVisualize(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {





#pragma warning disable CS0618 // 'DXValidationProvider.InvalidControls' is obsolete: 'Use the GetInvalidControls method instead'
            if (MyValidationProvider.InvalidControls.Count > 0)
#pragma warning restore CS0618 // 'DXValidationProvider.InvalidControls' is obsolete: 'Use the GetInvalidControls method instead'
            {
                XtraMessageBox.Show("There is Some Error.", "Validation Failed");
                TextCode.Focus();
                return;
            }
            if (TextCode.Text == string.Empty)
            {
                XtraMessageBox.Show("Code can not be blank.", "Validation Failed");
                TextCode.Focus();
                return;
            }
            else
            {
                if (TextWorked.Text == string.Empty)
                {
                    XtraMessageBox.Show("Worked Days can not be Blank.", "Validation Failed");
                    TextWorked.Focus();
                    return;
                }

                else
                {
                    if (Convert.ToDecimal(TextPaidHolidays.EditValue) > 7)
                    {
                        XtraMessageBox.Show("Paid hoildays cannot be greater tahn 7", "Validation Failed");
                        TextPaidHolidays.Focus();
                        return;
                    }
                    else
                    {
                        if ((Convert.ToDecimal(TextWorked.EditValue) + Convert.ToDecimal(TextPaidHolidays.EditValue) + Convert.ToDecimal(TextEarned.EditValue) + Convert.ToDecimal(TextCasual.EditValue) + Convert.ToDecimal(TextSick.EditValue)) > DaysInMonth)
                        {
                            XtraMessageBox.Show("Total Days can not be Exceed.", "Validation Failed");
                            TextWorked.Focus();
                            return;
                        }
                        else
                        {
                            using (var Connection = new SqlConnection(ProjectFunctions.ConnectionString))
                            {



                                var cmd = Connection.CreateCommand();
                                cmd.Connection = Connection;
                                var sql = string.Empty;
                                if (IsUpdate)
                                {

                                    sql = "UPDATE [AtnData] SET [MonthYear] = @MonthYear,[EmpCode] = @EmpCode,[EmpDW] = @EmpDW,[EmpPH] = @EmpPH,[EmpEL] = @EmpEL,[EmpCL] = @EmpCL,[EmpSL] = @EmpSL,[EmpOT] = @EmpOT,[EmpAdvAmt] = @EmpAdvAmt,[EmpLoanAmt] = @EmpLoanAmt,[EmpTdsAmt] = @EmpTdsAmt,[EmpMiscDed1] = @EmpMiscDed1,[EmpMiscAlw1] = @EmpMiscAlw1,[EmpMiscAlw2] = @EmpMiscAlw2,[EmpMiscAlw3] = @EmpMiscAlw3,[EmpPrePaidSal] = @EmpPrePaidSal,EmpML=@EmpML ,EmpMiscDed2=@EmpMiscDed2,EmpPymtMode=@EmpPymtMode"
                                    + " WHERE [EmpCode] = @EmpCode and [MonthYear] = @MonthYear";
                                }
                                else
                                {
                                    sql = " INSERT INTO [AtnData]([MonthYear],[EmpCode],[EmpDW],[EmpPH],[EmpEL],[EmpCL],[EmpSL],[EmpOT],[EmpAdvAmt],[EmpLoanAmt],[EmpTdsAmt],[EmpMiscDed1],[EmpMiscAlw1],[EmpMiscAlw2],[EmpMiscAlw3],[EmpLockTag],[EmpPrePaidSal],EmpML,EmpMiscDed2,EmpPymtMode)"
                                    + "VALUES" +
                                    "(@MonthYear,@EmpCode,@EmpDW,@EmpPH,@EmpEL,@EmpCL ,@EmpSL ,@EmpOT ,@EmpAdvAmt ,@EmpLoanAmt ,@EmpTdsAmt ,@EmpMiscDed1 ,@EmpMiscAlw1 ,@EmpMiscAlw2 ,@EmpMiscAlw3 ,@EmpLockTag,@EmpPrePaidSal,@EmpML,@EmpMiscDed2,@EmpPymtMode)";
                                }
                                Connection.Open();
                                cmd.CommandText = sql;
                                var month = TextMonth.Text.Substring(0, 2) + TextMonth.Text.ToString().Substring(TextMonth.Text.ToString().Length - 2, 2);
                                cmd.Parameters.AddWithValue("@MonthYear", TextMonth.Text).Value = month;
                                cmd.Parameters.AddWithValue("@EmpCode", TextCode.Text);
                                cmd.Parameters.AddWithValue("@EmpDW", SqlDbType.Decimal).Value = Convert.ToDecimal(TextWorked.Text);
                                if (TextPaidHolidays.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpPH", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpPH", SqlDbType.Decimal).Value = Convert.ToDecimal(TextPaidHolidays.Text);
                                }
                                if (TextEarned.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpEL", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpEL", SqlDbType.Decimal).Value = Convert.ToDecimal(TextEarned.Text);
                                }
                                if (TextCasual.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpCL", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpCL", SqlDbType.Decimal).Value = Convert.ToDecimal(TextCasual.Text);
                                }
                                if (TextSick.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpSL", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpSL", SqlDbType.Decimal).Value = Convert.ToDecimal(TextSick.Text);
                                }
                                if (TextOverTime.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpOT", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpOT", SqlDbType.Decimal).Value = Convert.ToDecimal(TextOverTime.Text);
                                }
                                if (TextAdvances.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpAdvAmt", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpAdvAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextAdvances.Text);
                                }
                                if (TextLoanAmt.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpLoanAmt", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpLoanAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextLoanAmt.Text);
                                }
                                if (TextTdsAmt.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpTdsAmt", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpTdsAmt", SqlDbType.Decimal).Value = Convert.ToDecimal(TextTdsAmt.Text);
                                }




                                if (TextDeducMisc.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscDed1", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscDed1", SqlDbType.Decimal).Value = Convert.ToDecimal(TextDeducMisc.Text);
                                }
                                if (TextMisc1.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscAlw1", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscAlw1", SqlDbType.Decimal).Value = Convert.ToDecimal(TextMisc1.Text);
                                }
                                if (TextMisc2.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscAlw2", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscAlw2", SqlDbType.Decimal).Value = Convert.ToDecimal(TextMisc2.Text);
                                }
                                if (TextMisc3.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscAlw3", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscAlw3", SqlDbType.Decimal).Value = Convert.ToDecimal(TextMisc3.Text);
                                }




                                if (txtMaternityLeave.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpML", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpML", SqlDbType.Decimal).Value = Convert.ToDecimal(txtMaternityLeave.Text);
                                }


                                cmd.Parameters.AddWithValue("@EmpLockTag", DBNull.Value);
                                if (IsUpdate)
                                {
                                    cmd.Parameters.AddWithValue("@EmpPrePaidSal", TextPrePaidTag.Text);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpPrePaidSal", DBNull.Value);
                                }



                                if (txtMiscDedNew.Text == string.Empty)
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscDed2", SqlDbType.Decimal).Value = "0";
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@EmpMiscDed2", SqlDbType.Decimal).Value = Convert.ToDecimal(txtMiscDedNew.Text);
                                }

                                cmd.Parameters.AddWithValue("@EmpPymtMode", SqlDbType.Decimal).Value = txtPaymentMode.Text;
                                cmd.ExecuteNonQuery();

                                if (Convert.ToDecimal(TextWorked.Text) == 0)
                                {
                                    ProjectFunctions.GetDataSet("Delete from payfinal where monthyear='" + month + "' And EmpCode='" + TextCode.Text.Trim() + "'");
                                    ProjectFunctions.GetDataSet("Delete from Paytestf where monthyear='" + month + "' And EmpCode='" + TextCode.Text.Trim() + "'");

                                }
                                using (var Conn = new SqlConnection(ProjectFunctions.ConnectionString))
                                {
                                    var month2 = TextMonth.Text.Substring(0, 2) + TextMonth.Text.ToString().Substring(TextMonth.Text.ToString().Length - 2, 2);
                                    var str1 = string.Empty;

                                    TextMonth.Focus();









                                }
                            }
                            //BaseFunctions.GetDataSet(" Update exmst set ExLoadTag='1',ExLoadedDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where ExEmpCode='" + TextCode.Text + "'  And  DATEPART(MM,ExMst.ExDatePost)='" + Convert.ToDateTime(TextMonth.Text).ToString("MM") + "' And  DATEPART(yyyy,ExMst.ExDatePost)='" + Convert.ToDateTime(TextMonth.Text).ToString("yyyy") + "' And ExLoadTag is null");





                            TextCode.Text = string.Empty;
                            TextCodeDesc.Text = string.Empty;
                            TextDepartment.EditValue = string.Empty;
                            TextWorked.Text = "0";
                            TextPaidHolidays.Text = "0";
                            TextOverTime.Text = "0";
                            TextEarned.Text = "0";
                            TextCasual.Text = "0";
                            TextSick.EditValue = "0";
                            TextMisc1.EditValue = "0";
                            TextMisc2.Text = "0";
                            TextMisc3.Text = "0";
                            TextFlexiAlw.Text = "0";
                            TextAdvances.Text = "0";
                            TextLoanAmt.EditValue = "0";
                            TextDeducMisc.Text = "5";
                            TextTdsAmt.Text = "0";
                            txtMaternityLeave.Text = "0";
                            txtFood.Text = "0";

                            TextPrePaidTag.Text = string.Empty;

                            txtTotalDays.Text = "0";

                            txtMiscDedNew.Text = "0";
                            TextMonth.Focus();
                            if (IsUpdate)
                            {
                                //XtraMessageBox.Show("Data Saved", "Success");
                                Close();
                                Dispose();
                            }
                        }
                    }
                }
            }
        }






        private void TextCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                using (var connection = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    CurrentControl = "TextCode";
                    var month = string.Empty;
                    if (TextMonth.Text.Length == 7)
                    {
                        month = TextMonth.Text.Substring(0, 2) + TextMonth.Text.ToString().Substring(TextMonth.Text.ToString().Length - 2, 2);
                    }
                    else
                    {
                        TextMonth.Focus();
                        return;
                    }
                    var Query = "SELECT empmst.EmpCode, empmst.EmpName, EmpFhName, DeptMst.DeptDesc,EmpMst.EmpPymtMode "
                                         + " FROM            empmst INNER JOIN"
                                         + " DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode "
                                         + " Where EmpMst.EmpCode Not In (Select EmpCode From AtnData Where MonthYear='" + month + "')  And EmpMst.EmpDOL is null  Order By EmpName";
                    if (TextCode.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                    }
                    else
                    {
                        var query = String.Format("SELECT  empmst.EmpCode, empmst.EmpName, DeptMst.DeptDesc,EmpMst.EmpPymtMode"
                                       + " FROM            empmst Inner Join"
                                       + " DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode where empmst.EmpCode='{0}' ", TextCode.Text.Trim());

                        var ds = new DataSet();
                        var dap = new SqlDataAdapter(query, connection);
                        dap.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            TextCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                            TextCodeDesc.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                            TextDepartment.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();
                            txtPaymentMode.Text = ds.Tables[0].Rows[0]["EmpPymtMode"].ToString();


                            TextWorked.Focus();
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
        }

        private void ShowHelpWindow(string Query)
        {
            try
            {
                HelpGridCtrl.DataSource = null;
                HelpGrid.Columns.Clear();
                HelpGridCtrl.RefreshDataSource();
                HelpGridCtrl.Visible = true;
                HelpGridCtrl.Focus();
                HelpGridCtrl.DataSource = ProjectFunctions.GetDataSet(Query).Tables[0];

                HelpGrid.Columns[0].BestFit();
                HelpGrid.Columns[1].BestFit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to fetch Data please Contact IT Department.\n" + ex.Message, "!Error");
            }
        }

        private void HelpGridCtrl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = HelpGrid.GetDataRow(HelpGrid.FocusedRowHandle);
                switch (CurrentControl)
                {
                    case "TextCode":
                        TextCode.Text = row["EmpCode"].ToString();
                        TextCodeDesc.Text = row["EmpName"].ToString();
                        TextDepartment.Text = row["DeptDesc"].ToString();
                        txtPaymentMode.Text = row["EmpPymtMode"].ToString();


                        TextWorked.Focus();
                        break;
                }

                HelpGridCtrl.Visible = false;
            }
            catch (Exception)
            {
            }
        }

        private void HelpGridCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
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
                case "TextCode":
                    TextWorked.Focus();
                    break;

                default:
                    CurrentControl = string.Empty;
                    break;
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

        private void TextPrePaidTag_EditValueChanged(object sender, EventArgs e)
        {
            TextWorked.Focus();
        }

        private void TextMonth_EditValueChanged(object sender, EventArgs e)
        {
            dorestrict();
        }

        private void TextSick_Leave(object sender, EventArgs e)
        {
            var thiscontrol = (TextEdit)sender;

            if (thiscontrol.Text == string.Empty)
            {
                thiscontrol.EditValue = 0;
            }
            if ((Convert.ToDecimal(thiscontrol.EditValue)) == 0)
            {
                return;
            }
            var y = (Convert.ToInt32((Convert.ToDecimal(thiscontrol.EditValue) % 1) * 100));
            if (y == 50 || y == 0)
            {
                Error.Clear();
                Error.Dispose();
            }
            else
            {
                Error.SetError(thiscontrol, "Either .00 or .50");
                thiscontrol.Focus();
            }
            TotalDays();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Control))
            {
                btnSave.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TextWorked_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDecimal(TextWorked.Text) > 0) { TextDeducMisc.Text = "5"; }
            else
            {
                TextDeducMisc.Text = "0";
            }
            if (Convert.ToDecimal(TextWorked.Text) >= 0 && Convert.ToDecimal(TextWorked.Text) <= DaysInMonth)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {

        }

        private void TextSick_Leave_1(object sender, EventArgs e)
        {
            TotalDays();
        }

        private void TextOverTime_Leave(object sender, EventArgs e)
        {
            if (TextOverTime.Text.Length == 0)
            {
                TextOverTime.Text = "0";
            }
            if (Convert.ToDecimal(TextOverTime.Text) > 20)
            {
                XtraMessageBox.Show("Xtra Days cannot be more than 20");
                TextOverTime.Focus();
            }
        }


        private void TextCode_EditValueChanged(object sender, EventArgs e)
        {
            txtPaymentMode.Text = string.Empty;
        }
    }
}