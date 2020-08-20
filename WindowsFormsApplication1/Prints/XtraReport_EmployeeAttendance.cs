using DevExpress.XtraReports.UI;
using SeqKartLibrary.HelperClass;

namespace WindowsFormsApplication1.Prints
{
    public partial class XtraReport_EmployeeAttendance : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_EmployeeAttendance()
        {
            InitializeComponent();
        }

        private void xrLabel_All_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (label.Text.Length > 0)
            {
                label.Text = label.Text.Replace("-", "\r\n");// "address line 1" + Environment.NewLine + "address line 2";
            }

        }

        private void xrLabel_Date_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            label.Text = ConvertTo.DateFormatApp(label.Text);
        }

        private void xrLabel_DateMonthYear_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            label.Text = ConvertTo.DateFormatMonthYear(label.Text);
        }

        private void xrLabel_MinutesToHours_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            //
            label.Text = ConvertTo.MinutesToHours(label.Text);
        }

        private void xrLabel_TimeIn_Out_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            label.Text = ConvertTo.TimeSpanString(label.Text);
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //try
            //{
            //    //byte[] bytes = (byte[])presupCab[0]?.Firma?.Firma;
            //    byte[] bytes = (byte[])GetCurrentColumnValue("EmpImage");
            //    MemoryStream mem = new MemoryStream(bytes);
            //    Bitmap bmp = new Bitmap(mem);
            //    Image img = bmp;

            //    XRPictureBox pictureBox = (XRPictureBox)sender;
            //    pictureBox.ImageSource = new ImageSource(img);
            //}
            //catch(Exception ex)
            //{
            //    PrintLogWinForms.PrintLog("XtraReport_EmployeeAttendance => Exception : " + ex);
            //}
        }
    }
}
