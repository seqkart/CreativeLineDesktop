using DevExpress.XtraReports.UI;
using SeqKartLibrary.HelperClass;

namespace WindowsFormsApplication1.Prints
{
    public partial class XtraReport_Salary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_Salary()
        {
            InitializeComponent();
        }

        private void xrLabel_OT_Time_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            label.Text = ConvertTo.MinutesToHours(label.Text);
        }
        /*
        private string FormatHoursForDisplay(Double value)
        {

            Double Hrs = Math.Floor(value);
            Double Mins = (value - Hrs) * 60;

            return String.Format("{0:0}:{1:00}", Hrs, Mins);
        }
        */
    }
}
