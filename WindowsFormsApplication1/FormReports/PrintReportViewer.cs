using DevExpress.XtraReports.UI;
using System;
using WindowsFormsApplication1;
namespace payroll.FormReports
{
    public partial class PrintReportViewer : DevExpress.XtraEditors.XtraForm
    {

        public String pkInstalledPrinters { get; set; }
        public PrintReportViewer()
        {
            InitializeComponent();
        }

        private void PrintReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                pkInstalledPrinters = ProjectFunctions.GetDataSet("Select ProgPrinterName from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProgPrinterName"].ToString();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewBarItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPrint_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                XtraReport rpt = new XtraReport();
                rpt = (XtraReport)documentViewer1.DocumentSource;
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                printTool.Print(pkInstalledPrinters);
                this.Close();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
    }
}