using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using System;
using System.Drawing;


namespace WindowsFormsApplication1.FormReports
{
    public partial class frmPivotGridReports : DevExpress.XtraEditors.XtraForm
    {

        public String CurrentUser { get; set; }

        RangeSelector _RangeSelector = new RangeSelector() { StartDate = GlobalVariables.FinYearStartDate, EndDate = GlobalVariables.FinYearEndDate };
        private LoadLayout _LoadLayout;
        private ReportFormatName _RepLayout;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String LayoutName = string.Empty;
        CheckEdit ch = new CheckEdit();

        public frmPivotGridReports()
        {
            InitializeComponent();
        }
        void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectFunctions.BindReportToPivotGrid(ProjectFunctions.GetDataSet("Select ProgProcName from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProgProcName"].ToString(), _RangeSelector.DtFrom.DateTime.Date, _RangeSelector.DtEnd.DateTime.Date, PivotGridControl);
                _RangeSelector.Visible = false;
                HelpGrid.Visible = false;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void frmPivotGridReports_Load(object sender, EventArgs e)
        {
            try
            {
                _LoadLayout = new LoadLayout() { CurrentUser = GlobalVariables.CurrentUser, ReportName = GlobalVariables.ProgCode };
                _RepLayout = new ReportFormatName() { CurrentUser = GlobalVariables.CurrentUser, ReportName = GlobalVariables.ProgCode };
                Controls.Add(_RangeSelector);
                Controls.Add(_LoadLayout);
                Controls.Add(_RepLayout);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }



        private void PivotGridControl_PopupMenuShowing(object sender, DevExpress.XtraPivotGrid.PopupMenuShowingEventArgs e)
        {
            try
            {
                e.Menu.Items.Add(new DXMenuItem("Select Range", (o1, e1) =>
                {
                    Controls.Add(_RangeSelector);
                    _RangeSelector.BtnLoad.Click += new EventHandler(BtnLoad_Click);
                    _RangeSelector.BringToFront();
                    _RangeSelector.Location = new Point(e.Point.X + 20, e.Point.Y + 20);
                    _RangeSelector.Show();
                    _RangeSelector.DtFrom.Focus();
                }));
                e.Menu.Items.Add(new DXMenuItem("Print Report", (o1, e1) =>
                {


                    var bp = new FormReports.BasePrint() { ReportName = GlobalVariables.ProgDesc };
                    bp.PrintPivotToReport(PivotGridControl, ProjectFunctions.GetDataSet("select ProCaption from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProCaption"].ToString() + " From " + _RangeSelector.StartDate.Date.ToString("dd-MM-yyyy") + " To " + _RangeSelector.EndDate.Date.ToString("dd-MM-yyyy"));


                }));
                e.Menu.Items.Add(new DXMenuItem("Disable Merging While Printing", (o1, e1) =>
                {

                    PivotGridControl.OptionsPrint.MergeRowFieldValues = false;
                    PivotGridControl.OptionsPrint.MergeColumnFieldValues = false;

                }));

                e.Menu.Items.Add(new DXMenuItem("Enable Merging While Printing", (o1, e1) =>
                {

                    PivotGridControl.OptionsPrint.MergeRowFieldValues = true;
                    PivotGridControl.OptionsPrint.MergeColumnFieldValues = true;

                }));
                e.Menu.Items.Add(new DXMenuItem("Save Report Layout", (o1, e1) =>
                {

                    ProjectFunctions.ButtonVisualize(_RepLayout);
                    _RepLayout.PGC = PivotGridControl;
                    _RepLayout.BringToFront();
                    _RepLayout.Location = new Point(e.Point.X + 20, e.Point.Y + 20);
                    _RepLayout.Show();
                }));

                e.Menu.Items.Add(new DXMenuItem("Load Report Layout", (o1, e1) =>
                {

                    ProjectFunctions.ButtonVisualize(_LoadLayout);
                    _LoadLayout.BringToFront();
                    _LoadLayout.PGC = PivotGridControl;
                    _LoadLayout.Location = new Point(e.Point.X + 20, e.Point.Y + 20);
                    _LoadLayout.Show();
                }));

                e.Menu.Items.Add(new DXMenuItem(PivotGridControl.OptionsView.ShowColumnGrandTotals ? "Hide Grand Totals" : "Show Grand Totals", (o1, e1) =>
                {

                    PivotGridControl.OptionsView.ShowColumnGrandTotals = PivotGridControl.OptionsView.ShowColumnGrandTotals ? false : true;
                    PivotGridControl.OptionsView.ShowColumnGrandTotalHeader = PivotGridControl.OptionsView.ShowColumnGrandTotalHeader ? false : true;

                }));
                e.Menu.Items.Add(new DXMenuItem("Close", (o1, e1) =>
                {

                    this.Close();
                }));
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }

        }



        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpGrid_Click(object sender, EventArgs e)
        {

        }
    }
}