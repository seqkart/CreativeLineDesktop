using DevExpress.XtraEditors;
using System;

namespace WindowsFormsApplication1
{
    public partial class RangeSelector : XtraUserControl
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RangeSelector()
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
    }
}
