using System;
using System.Linq;
using System.Windows.Forms;

namespace SEQKARTBIO
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Boolean mOpenFlag;
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            String lpszIPAddress;
            //		Dim vRet As Boolean

            Program.gMachineNumber = Convert.ToInt32(cmbMachineNumber.Text);

            lpszIPAddress = txtIPAddress.Text;
            String lpszDevId = txtDevId.Text;
            if (lpszDevId.Length == 16)
            {
                int nError = 0;
                Program.gMachineNumber = SBXPC1.ConnectP2p(ref lpszDevId, ref lpszIPAddress, Convert.ToInt32(txtPortNo.Text), Convert.ToInt32(txtPassword.Text), ref nError);
                if (Program.gMachineNumber != 0)
                {
                    mOpenFlag = true;
                    cmdOpen.Enabled = false;

                    cmdClose.Enabled = true;

                    cmdLogData.Enabled = true;

                    if (nError == 4)
                        MessageBox.Show("Relayed Connection!");
                    else if (nError == 5)
                        MessageBox.Show("Direct Local Connection!");
                }
                else
                {
                    if (nError == 1)
                        MessageBox.Show("Cannot Connect To Server!");
                    else if (nError == 2)
                        MessageBox.Show("Device Not Found!");
                    else if (nError == 3)
                        MessageBox.Show("Password Mismatched!");
                    else
                        MessageBox.Show("Unknown Error!");
                }
            }
            else
            {
                if (SBXPC1.ConnectTcpip(Program.gMachineNumber, ref lpszIPAddress, Convert.ToInt32(txtPortNo.Text), Convert.ToInt32(txtPassword.Text)))
                {
                    mOpenFlag = true;
                    cmdOpen.Enabled = false;

                    cmdClose.Enabled = true;

                    cmdLogData.Enabled = true;

                }
            }
            MessageBox.Show("Bio-Machine Linked Successfully");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            lblIPAddress.Enabled = true;
            txtIPAddress.Enabled = true;
            lblPortNo.Enabled = true;
            txtPortNo.Enabled = true;
            lblPassword.Enabled = true;
            txtPassword.Enabled = true;

            cmdOpen.Enabled = true;
            cmdClose.Enabled = false;

            cmdLogData.Enabled = false;
            mOpenFlag = false;
            cmbMachineNumber.Text = Convert.ToString(1);
            SBXPC1.DotNET();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (mOpenFlag == true)
            {
                SBXPC1.Disconnect();
                mOpenFlag = false;
                cmdOpen.Enabled = true;
                cmdClose.Enabled = false;

                cmdLogData.Enabled = false;

            }
        }

        private void optNetworkDevice_CheckedChanged(object sender, EventArgs e)
        {
            String lpszIPAddress;

            lblIPAddress.Enabled = false;
            txtIPAddress.Enabled = false;
            lblPortNo.Enabled = false;
            txtPortNo.Enabled = false;
            lblPassword.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void cmdLogData_Click(object sender, EventArgs e)
        {
            frmLog frm_log = new frmLog();
            frm_log.Activate();
            frm_log.Visible = true;
            this.Visible = false;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}