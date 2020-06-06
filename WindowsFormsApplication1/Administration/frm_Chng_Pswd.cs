using DevExpress.XtraEditors;
using System;
using System.Linq;
namespace WindowsFormsApplication1
{
    public partial class frm_Chng_Pswd : XtraUserControl
    {
        public frm_Chng_Pswd()
        {
            InitializeComponent();
        }

        private void Btn_Chnge_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtNew1.Text != txtnew2.Text))
                {
                    ProjectFunctions.SpeakError("Password doesn't Match.");
                    txtoldPswd.Focus();
                    return;
                }
                ProjectFunctions.GetDataSet(String.Format("Update UserMaster Set UserPwd='{0}' where username='{1}'", txtnew2.Text, GlobalVariables.CurrentUser));
                GlobalVariables.UserPwd = txtnew2.Text;
                ProjectFunctions.SpeakError("Password Changed.");
                Dispose();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void frm_Chng_Pswd_Load(object sender, EventArgs e)
        {
            try
            {
                txtoldPswd.Focus();
                ProjectFunctions.TextBoxVisualize(groupControl1);
                ProjectFunctions.ButtonVisualize(groupControl1);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}