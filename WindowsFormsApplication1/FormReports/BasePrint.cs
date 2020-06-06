using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Drawing.Printing;


namespace WindowsFormsApplication1.FormReports
{
    internal class BasePrint
    {

        public string ReportName { get; set; }
        public bool IsMail { get; set; }
        public string format { get; set; }
        public string Password { get; set; }
        private PrintingSystem PS;
        private PrintableComponentLink PCL;
#pragma warning disable CS0169 // The field 'BasePrint.tempflag' is never used
        private bool tempflag;
#pragma warning restore CS0169 // The field 'BasePrint.tempflag' is never used

        public BasePrint()
        {
            PS = new PrintingSystem();
            PCL = new PrintableComponentLink();
            PS.Links.AddRange(new object[] { PCL });
#pragma warning disable CS1717 // Assignment made to same variable; did you mean to assign something else?
            GlobalVariables.CurrentUser = GlobalVariables.CurrentUser;
#pragma warning restore CS1717 // Assignment made to same variable; did you mean to assign something else?
        }

        public void PrintPivotToReport(PivotGridControl PGC, string HeaderMiddle)
        {
            PGC.OptionsPrint.PrintHeadersOnEveryPage = true;
            PGC.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            PGC.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            PGC.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            PGC.OptionsPrint.UsePrintAppearance = true;
            PS.ClearContent();
            PGC.RefreshData();
            PCL.Component = PGC;
            PCL.PageHeaderFooter = new PageHeaderFooter(new PageHeaderArea(new string[] {
                "Printed At:-[Date Printed] [Time Printed]", String.Format("{0}\r\n{1}",  GlobalVariables.CompanyName, HeaderMiddle),
                "[Page # of Pages #]" }, new Font("Arial Narrow", 10.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), BrickAlignment.Near), new PageFooterArea(new string[] {
                string.Empty,
                string.Empty,
                string.Empty }, new Font("Arial Narrow", 10.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), BrickAlignment.Near));
            PCL.PaperKind = PaperKind.CSheet;
            PCL.PaperName = "Internal Report";
            PCL.Landscape = true;
            PCL.Margins = new Margins(15, 15, 100, 100);
            PCL.MinMargins = new Margins(15, 15, 30, 30);
            ConfigurePrintingSystem(PS);

            PCL.PrintingSystemBase = PS;
            PCL.CreateDocument();
            var autoFit = PCL.PrintingSystemBase.Document.AutoFitToPagesWidth;
            if (!IsMail)
            {
                if (PCL.PrintingSystemBase.Document.ScaleFactor > 1)
                {
                    PCL.PrintingSystemBase.Document.AutoFitToPagesWidth = autoFit;
                }
                else
                {
                    PCL.PrintingSystemBase.Document.AutoFitToPagesWidth = 1;
                }
            }
            PCL.ShowPreview();
        }



        public void PrintGridToReport(DevExpress.XtraGrid.GridControl PGC, string HeaderMiddle)
        {
            (PGC.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView).AppearancePrint.RestoreLayoutFromXml(System.Windows.Forms.Application.StartupPath + @"\PrintLayOut.xml");
            PS.ClearContent();
            PGC.RefreshDataSource();
            PCL.Component = PGC;
            PCL.PageHeaderFooter = new PageHeaderFooter(new PageHeaderArea(new string[] {
                 "Printed At:-[Date Printed] [Time Printed]", String.Format("{0}\r\n{1}", GlobalVariables.CompanyName, HeaderMiddle),
                "[Page # of Pages #]" }, new Font("Arial Narrow", 10.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), BrickAlignment.Near), new PageFooterArea(new string[] {
                string.Empty,
                string.Empty,
                string.Empty }, new Font("Arial Narrow", 10.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), BrickAlignment.Near));
            PCL.PaperKind = PaperKind.A3;
            PCL.PaperName = "Internal Report";
            PCL.Landscape = true;
            PCL.Margins = new Margins(15, 15, 100, 100);
            PCL.MinMargins = new Margins(15, 15, 10, 10);
            ConfigurePrintingSystem(PS);
            PCL.PrintingSystemBase = PS;
            PCL.CreateDocument();
            var autoFit = PCL.PrintingSystemBase.Document.AutoFitToPagesWidth;
            PCL.PrintingSystemBase.Document.AutoFitToPagesWidth = 1;
            if (PCL.PrintingSystemBase.Document.ScaleFactor > 1)
            {
                PCL.PrintingSystemBase.Document.AutoFitToPagesWidth = autoFit;
            }

            PCL.ShowPreview();
        }
        private void ConfigurePrintingSystem(PrintingSystemBase printingSystem)
        {
            SetPdfOptions(printingSystem.ExportOptions.Pdf, ReportName);
            SetXlsOptions(printingSystem.ExportOptions.Xls, ReportName);
        }

        private static void SetXlsOptions(XlsExportOptions xlsExportOptions, string SheetName)
        {
            xlsExportOptions.SheetName = String.IsNullOrEmpty(SheetName) ? "Document" : SheetName;
            xlsExportOptions.ShowGridLines = true;
            xlsExportOptions.TextExportMode = TextExportMode.Value;
            xlsExportOptions.Suppress65536RowsWarning = true;
        }

        private void SetPdfOptions(PdfExportOptions pdfExportOptions, string SheetName)
        {
            pdfExportOptions.PasswordSecurityOptions.OpenPassword = Password;
            pdfExportOptions.DocumentOptions.Title = SheetName;
            pdfExportOptions.ImageQuality = PdfJpegImageQuality.Low;
        }

        private void SetExportOption_GetUserAccess(PrintingSystemBase printingSystem, string User)
        {
            printingSystem.SetCommandVisibility(new PrintingSystemCommand[] { PrintingSystemCommand.ExportXls, PrintingSystemCommand.ExportXlsx }, CommandVisibility.None);
            printingSystem.SetCommandVisibility(new PrintingSystemCommand[] { PrintingSystemCommand.ExportPdf }, CommandVisibility.None);
            printingSystem.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
            printingSystem.SetCommandVisibility(PrintingSystemCommand.Open, CommandVisibility.None);
            printingSystem.SetCommandVisibility(PrintingSystemCommand.Customize, CommandVisibility.None);
            printingSystem.SetCommandVisibility(PrintingSystemCommand.EditPageHF, CommandVisibility.None);
            printingSystem.SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None);
            printingSystem.SetCommandVisibility(new PrintingSystemCommand[] { PrintingSystemCommand.ExportCsv,
                PrintingSystemCommand.ExportTxt,
                PrintingSystemCommand.ExportHtm,
                PrintingSystemCommand.ExportMht,
                PrintingSystemCommand.ExportRtf,
                PrintingSystemCommand.ExportXps,
                PrintingSystemCommand.File,


                PrintingSystemCommand.Save,
                PrintingSystemCommand.SendCsv,
                PrintingSystemCommand.SendFile,
                PrintingSystemCommand.SendGraphic
                },
             CommandVisibility.None);
        }
    }
}