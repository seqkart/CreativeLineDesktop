using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using System;
using System.IO;

namespace WindowsFormsApplication1.FormReports
{
    public partial class ReportFormatName : XtraUserControl
    {
        public string CurrentUser { get; set; }
        public string ReportName { get; set; }
        private string Address;
        public PivotGridControl PGC { get; set; }

        public ReportFormatName()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileName.Text == string.Empty)
                {
                    ProjectFunctions.SpeakError("Please Enter Layout Name to Proceed");
                    return;
                }

                Address = String.Format(@"{0}\Layouts\{1}\{2}", GlobalVariables.LayoutLocation, GlobalVariables.CurrentUser, ReportName);
                if (!Directory.Exists(Address))
                {
                    Directory.CreateDirectory(Address);
                }
                Address = String.Format(@"{0}\Layouts\{1}\{2}\{3}.xml", GlobalVariables.LayoutLocation, GlobalVariables.CurrentUser, ReportName, FileName.Text);
                PGC.SaveLayoutToXml(Address);
                ProjectFunctions.EventTracker("Save Report Layout Process Ended");
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Unable to Save Layout.\n" + ex.Message);
            }
            Hide();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}