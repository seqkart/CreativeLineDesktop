using DevExpress.XtraEditors;
using System;

namespace WindowsFormsApplication1.Transaction
{
    public partial class FRMVIEWLEDERS : DevExpress.XtraEditors.XtraForm
    {
        public FRMVIEWLEDERS()
        {
            InitializeComponent();
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(e.Item);
        }

        private void employeesLabelControl_Click(object sender, EventArgs e)
        {

        }

        private void tileBar_Click(object sender, EventArgs e)
        {

        }
    }
}