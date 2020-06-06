using DevExpress.XtraEditors;
using System;
using System.Data;

namespace WindowsFormsApplication1
{
    public partial class RangeSelectorLedger : XtraUserControl
    {

        private string CurrentControl;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RangeSelectorLedger()
        {
            InitializeComponent();

        }
        private void ValidateDates()
        {
            if (Convert.ToDateTime(DtFrom.EditValue) < Convert.ToDateTime(GlobalVariables.FinYearStartDate) || Convert.ToDateTime(DtFrom.EditValue) > Convert.ToDateTime(GlobalVariables.FinYearEndDate))
            {
                ProjectFunctions.SpeakError("From Date Is Out Of The Financial Year");
                DtFrom.Focus();
            }
            if (Convert.ToDateTime(DtEnd.EditValue) < Convert.ToDateTime(GlobalVariables.FinYearStartDate) || Convert.ToDateTime(DtEnd.EditValue) > Convert.ToDateTime(GlobalVariables.FinYearEndDate))
            {
                ProjectFunctions.SpeakError("End Date Is Out Of The Financial Year");
                DtFrom.Focus();
            }
        }


        private void RangeSelector_Load(object sender, EventArgs e)
        {
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            DtFrom.EditValue = StartDate;
            DtEnd.EditValue = EndDate;
            ValidateDates();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void fillPartyGrid()
        {
            DataSet ds = ProjectFunctions.GetDataSet("Select AccCode,AccName from ActMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HelpGrid.DataSource = ds.Tables[0];
                HelpGridView.BestFitColumns();
            }
            else
            {
                HelpGrid.DataSource = null;
                HelpGridView.BestFitColumns();
            }
        }
        private void fillLedgerGrid()
        {
            DataSet ds = ProjectFunctions.GetDataSet("Select LgrCode,LgrDesc from LgrMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HelpGrid.DataSource = ds.Tables[0];
                HelpGridView.BestFitColumns();
            }
            else
            {
                HelpGrid.DataSource = null;
                HelpGridView.BestFitColumns();
            }
        }
        private void fillBSGrid()
        {
            DataSet ds = ProjectFunctions.GetDataSet("Select BSCode,BSDesc from bshmst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HelpGrid.DataSource = ds.Tables[0];
                HelpGridView.BestFitColumns();
            }
            else
            {
                HelpGrid.DataSource = null;
                HelpGridView.BestFitColumns();
            }
        }
        private void chParty_CheckedChanged(object sender, EventArgs e)
        {
            if (chParty.Checked)
            {
                chLedger.Checked = false;
                chBSHead.Checked = false;
                fillPartyGrid();
            }
        }

        private void chBSHead_CheckedChanged(object sender, EventArgs e)
        {
            if (chBSHead.Checked)
            {
                chLedger.Checked = false;
                chParty.Checked = false;
                fillBSGrid();
            }
        }

        private void chLedger_CheckedChanged(object sender, EventArgs e)
        {
            if (chLedger.Checked)
            {
                chBSHead.Checked = false;
                chParty.Checked = false;
                fillLedgerGrid();
            }
        }
    }
}
