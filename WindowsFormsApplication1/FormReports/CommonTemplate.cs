using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.Prints.PartyLedger.rpt;
using WindowsFormsApplication1.Prints.Rpt_BankBook.rpt;
using WindowsFormsApplication1.Prints.rpt_BankReco.rpt;
using WindowsFormsApplication1.Prints.rpt_CashBook.rpt;
using WindowsFormsApplication1.Prints.rpt_DayBook.rpt;

namespace WindowsFormsApplication1.Crystal_Reports
{
    public partial class CommonTemplate : XtraForm
    {

        #region Properties
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FinancialYear { get; set; }
        public string CurrentUser { get; set; }
        public string Company { get; set; }
        public DateTime CFinStart { get; set; }
        public DateTime CFinEnd { get; set; }
        public string CAdd { get; set; }
        public string CCode { get; set; }

        #endregion

        private CheckedComboBoxEdit Cmb_LocationsPayRegN;


        string qr = string.Empty;

        public String Title { get; set; }
        public bool IsCrystal { get; set; }
        private readonly object _locker = new object();
        private RangeSelector _RangeSelector;

        private ComboBoxEdit Cmb_EmpPayment;

        private LabelControl Lbl_EmpPayment;

        ReflectorBar reflectorBar;


        CheckEdit Chk_Selected = new CheckEdit();




        public CommonTemplate()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {

            _RangeSelector.BringToFront();
            _RangeSelector.Location = new Point(20, 20);
            _RangeSelector.DtFrom.EditValue = StartDate.Date;
            _RangeSelector.DtEnd.EditValue = EndDate.Date;

            _RangeSelector.Show();
            _RangeSelector.DtFrom.Focus();
        }

        private void CommonTemplate_Load(object sender, EventArgs e)
        {
            try
            {

                ProgressBarControl progressBar = new ProgressBarControl();
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

                lbl.Text = Title;

                _RangeSelector = new RangeSelector() { StartDate = GlobalVariables.FinYearStartDate, EndDate = GlobalVariables.FinYearEndDate };
                //_RangeSelector.DtFrom.EditValue = GlobalVariables.FinYearStartDate;
                //_RangeSelector.DtEnd.EditValue = GlobalVariables.FinYearEndDate;
                _RangeSelector.BtnLoad.Click += new EventHandler(BtnLoad_Click);
                _RangeSelector.Controls.Add(Chk_Selected);
                Chk_Selected.Text = "Select Party";
                Chk_Selected.CheckedChanged += Chk_Selected_CheckedChanged;
                //RangeSelector.Chk_Selected.CheckedChanged += new EventHandler(Selected_CheckedChanged);
                Controls.Add(_RangeSelector);
                Controls.Add(progressBar);
                progressBar.Dock = DockStyle.Fill;
                _RangeSelector.Hide();
                ProjectFunctions.ButtonVisualize(_RangeSelector.BtnLoad);
                ProjectFunctions.DatePickerVisualize(_RangeSelector);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void Chk_Selected_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Chk_Selected.Checked)
                {
                    DataSet ds = ProjectFunctions.GetDataSet("Select AccCode,AccName from ActMst ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HelpGridCtrl.DataSource = ds.Tables[0];
                        HelpGrid.BestFitColumns();
                        HelpGridCtrl.Show();
                        HelpGridCtrl.Focus();
                        HelpGridCtrl.BringToFront();
                    }
                }
                else
                {
                    HelpGridCtrl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        void Selected_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                StartDate = _RangeSelector.DtFrom.DateTime.Date;
                EndDate = _RangeSelector.DtEnd.DateTime.Date;
                DataRow Currentrow = HelpGrid.GetDataRow(HelpGrid.FocusedRowHandle);


                switch (GlobalVariables.ProgCode)
                {
                    case "PROG143":
                        DataSet Ds = ProjectFunctions.GetDataSet(String.Format("Exec [Sp_CashBookRpt] '{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}'", StartDate.Date, EndDate.Date));
                        rpt_CashBook RptDoc1 = new rpt_CashBook();
                        (RptDoc1.ReportDefinition.ReportObjects["txtCompanyName"] as TextObject).Text = GlobalVariables.CompanyName;
                        (RptDoc1.ReportDefinition.ReportObjects["txtReportHead"] as TextObject).Text = Title;
                        (RptDoc1.ReportDefinition.ReportObjects["txtDateRange"] as TextObject).Text = string.Format("From ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        RptDoc1.SetDataSource(Ds.Tables[0]);
                        lbl.Text = string.Format(Title + " ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        this.crystalReportViewer1.ReportSource = RptDoc1;
                        _RangeSelector.Hide();
                        break;
                    case "PROG144":
                        HelpGrid.CloseEditor();
                        HelpGrid.UpdateCurrentRow();
                        DataSet DsRecoBank = ProjectFunctions.GetDataSet(String.Format("Exec [SP_RecoBank] '{0:yyyy-MM-dd}', '253'", EndDate.Date));
                        rpt_BankReco RptDoc2 = new rpt_BankReco();
                        (RptDoc2.ReportDefinition.ReportObjects["txtCompanyName"] as TextObject).Text = GlobalVariables.CompanyName;
                        (RptDoc2.ReportDefinition.ReportObjects["txtReportName"] as TextObject).Text = "Bank Reco";
                        (RptDoc2.ReportDefinition.ReportObjects["txtDateRange"] as TextObject).Text = string.Format("From ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        RptDoc2.SetDataSource(DsRecoBank.Tables[0]);
                        lbl.Text = string.Format(Title + " ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        this.crystalReportViewer1.ReportSource = RptDoc2;
                        crystalReportViewer1.Show();
                        crystalReportViewer1.BringToFront();
                        _RangeSelector.Hide();
                        HelpGridCtrl.Hide();
                        break;
                    case "PROG145":
                        DataSet dsDayBook = ProjectFunctions.GetDataSet(String.Format("[Sp_PrepareDayBook] '{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}'", StartDate.Date, EndDate.Date));
                        rpt_DayBook RptDoc3 = new rpt_DayBook();
                        (RptDoc3.ReportDefinition.ReportObjects["txtCompanyName"] as TextObject).Text = GlobalVariables.CompanyName;
                        (RptDoc3.ReportDefinition.ReportObjects["txtReportHead"] as TextObject).Text = "Day Book";
                        (RptDoc3.ReportDefinition.ReportObjects["txtDateRange"] as TextObject).Text = string.Format("From ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        RptDoc3.SetDataSource(dsDayBook.Tables[0]);
                        lbl.Text = string.Format(Title + " ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        this.crystalReportViewer1.ReportSource = RptDoc3;
                        crystalReportViewer1.Show();
                        crystalReportViewer1.BringToFront();
                        _RangeSelector.Hide();
                        break;
                    case "PROG147":
                        DataSet ds = ProjectFunctions.GetDataSet(String.Format("[Sp_PrepareBankBook] '{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}'", StartDate.Date, EndDate.Date));
                        Rpt_BankBook RptDoc = new Rpt_BankBook();
                        (RptDoc.Section2.ReportObjects["txtCompanyName"] as TextObject).Text = GlobalVariables.CompanyName;
                        (RptDoc.Section2.ReportObjects["txtReportName"] as TextObject).Text = "Bank Book";
                        (RptDoc.Section2.ReportObjects["txtDateRange"] as TextObject).Text = string.Format("From ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        lbl.Text = string.Format(Title + " ({0} to {1})", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        RptDoc.SetDataSource(ds.Tables[0]);
                        this.crystalReportViewer1.ReportSource = RptDoc;
                        crystalReportViewer1.Show();
                        crystalReportViewer1.BringToFront();
                        _RangeSelector.Hide();
                        break;
                    case "PROG165":
                        DataSet dsLedger = ProjectFunctions.GetDataSet(String.Format("[sp_ZoomPartyAct] '{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}','{2}'", StartDate.Date, EndDate.Date, Currentrow["AccCode"].ToString()));
                        PartyLedger RptLedger = new PartyLedger();
                        (RptLedger.Section2.ReportObjects["txtCompanyName"] as TextObject).Text = GlobalVariables.CompanyName;
                        (RptLedger.Section2.ReportObjects["txtReportName"] as TextObject).Text = "Party Ledger";
                        (RptLedger.Section2.ReportObjects["txtDateRange"] as TextObject).Text = string.Format("From ({0} to {1}) ", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        lbl.Text = string.Format(Title + " ({0} to {1})", StartDate.Date.ToString("dd-MM-yyyy"), EndDate.Date.ToString("dd-MM-yyyy"));
                        RptLedger.SetDataSource(dsLedger.Tables[0]);
                        this.crystalReportViewer1.ReportSource = RptLedger;
                        crystalReportViewer1.Show();
                        crystalReportViewer1.BringToFront();
                        _RangeSelector.Hide();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void HelpGridCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                HelpGridCtrl.Visible = false;

            if (e.KeyCode == Keys.Enter)
                _RangeSelector.BtnLoad.PerformClick();
        }

        private void HelpGridCtrl_DoubleClick(object sender, EventArgs e)
        {
            if ((HelpGridCtrl.DataSource as DataTable).Select("Sel <> False").Length == 1)
                _RangeSelector.BtnLoad.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.D | Keys.Control))
            {
                RefreshBtn.PerformClick();
                return true;
            }

            if (keyData == (Keys.L | Keys.Control))
            {
                _RangeSelector.BtnLoad.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void Email_Click(object sender, EventArgs e)
        {

        }
    }
}