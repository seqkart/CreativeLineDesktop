using System;

namespace WindowsFormsApplication1.Transaction
{
    public partial class frmDayClose : DevExpress.XtraEditors.XtraForm
    {
        public frmDayClose()
        {
            InitializeComponent();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProjectFunctions.GetDataSet("sp_ShowRoomDayClose " + DateTime.Now.ToString("yyyy-MM-dd"));
            ProjectFunctions.SpeakError("Reports Generated");
        }
    }
}