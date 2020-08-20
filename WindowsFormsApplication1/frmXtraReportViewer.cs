using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmXtraReportViewer : DevExpress.XtraEditors.XtraForm
    {
        public frmXtraReportViewer()
        {
            InitializeComponent();
        }

        private void printPreviewRibbonPageGroup2_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {

        }

        private void printPreviewBarItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmXtraReportViewer_Load(object sender, EventArgs e)
        {

            //this.Close();
        }

        private void frmXtraReportViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //printPreviewBarItem8.PerformClick();
        }
    }
}