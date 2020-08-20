namespace WindowsFormsApplication1.Report
{
    public partial class Rpt_VoucherPrint : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_VoucherPrint()
        {
            InitializeComponent();
        }


        private void Rpt_JL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            LblCmpyNm.Text = GlobalVariables.CompanyName;
            LblCmpyAdd1_2.Text = GlobalVariables.CAddress1;
            CmpyAdd3.Text = GlobalVariables.CAddress2;

        }
    }
}
