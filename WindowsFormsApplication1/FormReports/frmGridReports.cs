using System;
using System.Drawing;

namespace WindowsFormsApplication1.FormReports
{
    public partial class frmGridReports : DevExpress.XtraEditors.XtraForm
    {
        RangeSelector _RangeSelector = new RangeSelector() { StartDate = GlobalVariables.FinYearStartDate, EndDate = GlobalVariables.FinYearEndDate };
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public frmGridReports()
        {
            InitializeComponent();
        }

        private void MasterGridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Select Report Data Range", (o1, e1) =>
            {
                Controls.Add(_RangeSelector);
                _RangeSelector.BtnLoad.Click += new EventHandler(BtnLoad_Click);
                _RangeSelector.BringToFront();
                _RangeSelector.Location = new Point(e.Point.X + 20, e.Point.Y + 20);
                _RangeSelector.Show();
                _RangeSelector.DtFrom.Focus();
            }));
        }

        void BtnLoad_Click(object sender, EventArgs e)
        {
            ProjectFunctions.BindReportToGrid(ProjectFunctions.GetDataSet("Select ProgProcName from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProgProcName"].ToString(), _RangeSelector.DtFrom.DateTime.Date, _RangeSelector.DtEnd.DateTime.Date, MasterGrid, MasterGridView);
            _RangeSelector.Visible = false;
        }

        private void frmGridReports_Load(object sender, EventArgs e)
        {
            ProjectFunctions.GirdViewVisualize(MasterGridView);
        }
    }
}