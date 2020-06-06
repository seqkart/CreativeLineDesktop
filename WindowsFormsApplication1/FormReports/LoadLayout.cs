using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using System;
using System.IO;

namespace WindowsFormsApplication1.FormReports
{
    public partial class LoadLayout : XtraUserControl
    {
        public string CurrentUser { get; set; }
        public string ReportName { get; set; }
        private string Address;
        public PivotGridControl PGC { get; set; }
        public bool isGrid { get; set; }

        public LoadLayout()
        {
            InitializeComponent();
        }

        private void LoadLayout_Load(object sender, EventArgs e)
        {
            try
            {
                Address = String.Format(@"{0}\Layouts\{1}\{2}", GlobalVariables.LayoutLocation, GlobalVariables.CurrentUser, ReportName);
                if (Directory.Exists(Address))
                {
                    var df = new DirectoryInfo(Address);
                    var fl = df.GetFiles("*.xml");
                    foreach (FileInfo f in fl)
                    {
                        FileName.Properties.Items.Add(f.Name);
                    }
                    if (FileName.Properties.Items.Count == 0)
                    {
                        ProjectFunctions.SpeakError("No Saved Layouts.");
                    }
                }
                ProjectFunctions.EventTracker("Load Report Layout Process Ended");
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Unable to Load Layouts.\n" + ex.Message);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileName.EditValue.ToString() != string.Empty)
                {
                    if (FileName.EditValue.ToString().Contains(".xml"))
                    {
                        Address = String.Format(@"{0}\Layouts\{1}\{2}\{3}", GlobalVariables.LayoutLocation, GlobalVariables.CurrentUser, ReportName, FileName.EditValue);
                    }
                    else
                    {
                        Address = String.Format(@"{0}\Layouts\{1}\{2}\{3}.xml", GlobalVariables.LayoutLocation, GlobalVariables.CurrentUser, ReportName, FileName.EditValue);
                    }
                    PGC.RestoreLayoutFromXml(Address);
                    Hide();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Error While Loading Layout.\n" + ex.Message);
            }
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}