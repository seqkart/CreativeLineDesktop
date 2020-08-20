using System;

namespace WindowsFormsApplication1.FormReports
{
    public partial class frmPrintReportDesigner : DevExpress.XtraEditors.XtraForm
    {
        public frmPrintReportDesigner()
        {
            InitializeComponent();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}