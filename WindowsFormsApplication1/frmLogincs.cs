using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmLogincs : DevExpress.XtraEditors.XtraForm
    {
        public frmLogincs()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool validateData()
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid UserName");
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Password");
                txtPassword.Focus();
                return false;
            }
            DataSet dsGetUser = ProjectFunctions.GetDataSet("Select UserName,UserPwd from UserMaster WHere UserName='" + txtUserName.Text.Trim() + "' And UserPwd='" + txtPassword.Text.Trim() + "'");
            if (dsGetUser.Tables[0].Rows.Count > 0)
            {
                GlobalVariables.CurrentUser = txtUserName.Text;
            }
            else
            {

                ProjectFunctions.SpeakError("Invalid Username or Password");
                txtUserName.Focus();
                return false;
            }
            if (DateTime.Now.Date <= GlobalVariables.LicenseToExpireDate.Date)
            {
                if (DateTime.Now.Date >= Convert.ToDateTime("2020-03-16").Date && DateTime.Now.Date <= Convert.ToDateTime("2020-03-31").Date)
                {
                    ProjectFunctions.SpeakError("Only " + Math.Abs((DateTime.Now.Date - GlobalVariables.LicenseToExpireDate.Date).Days) + " Days Left For Liscense To Expire,Please Recharge Immediately");
                }
                else
                {
                    ProjectFunctions.SpeakError("Unauthorised Access");
                    return false;
                }
            }
            else
            {
                ProjectFunctions.SpeakError("License Has Been Expired");
                return false;
            }

            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try

            {
                if (validateData())
                {
                    DataSet dsCompany = ProjectFunctions.GetDataSet("Select * from COMCONF");
                    GlobalVariables.CAddress1 = dsCompany.Tables[0].Rows[0]["COMADD"].ToString();
                    GlobalVariables.CAddress2 = dsCompany.Tables[0].Rows[0]["COMADD1"].ToString();
                    GlobalVariables.CAddress3 = dsCompany.Tables[0].Rows[0]["COMADD2"].ToString();
                    GlobalVariables.CmpGSTNo = dsCompany.Tables[0].Rows[0]["COMGST"].ToString();
                    GlobalVariables.CompanyName = dsCompany.Tables[0].Rows[0]["COMNAME"].ToString();
                    GlobalVariables.TelNo = dsCompany.Tables[0].Rows[0]["COMPHONE"].ToString();
                    GlobalVariables.CmpEmailID = dsCompany.Tables[0].Rows[0]["COMEID"].ToString();
                    GlobalVariables.CmpZipCode = dsCompany.Tables[0].Rows[0]["COMZIP"].ToString();
                    GlobalVariables.CmpWebSite = dsCompany.Tables[0].Rows[0]["COMWEBSITE"].ToString();
                    DataSet dsFY = ProjectFunctions.GetDataSet("select * from FNYear Where FNYearCode='" + txtFNYear.Text + "' ");
                    GlobalVariables.CUnitID = txtUnit.SelectedValue.ToString().PadLeft(2, '0');

                    GlobalVariables.FinancialYear = dsFY.Tables[0].Rows[0]["FNYearCode"].ToString();
                    GlobalVariables.FinYearStartDate = Convert.ToDateTime(dsFY.Tables[0].Rows[0]["FNStartDate"]).Date;
                    GlobalVariables.FinYearEndDate = Convert.ToDateTime(dsFY.Tables[0].Rows[0]["FNEndDate"]).Date;

                    GlobalVariables.BarCodePreFix = ProjectFunctions.GetDataSet("Select isnull(BarCodePreFix,'V') as BarCodePreFix from UNITS where UNITID='" + GlobalVariables.CUnitID + "'").Tables[0].Rows[0][0].ToString();



                    






                    WindowsFormsApplication1.XtraForm1 frm = new WindowsFormsApplication1.XtraForm1();

                    this.Hide();
                    frm.ShowDialog(this.Parent);
                    frm.BringToFront();

                }
            }

            catch (Exception ex)
            {

            }
        }

        private void frmLogincs_Load(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists("C:\\Application"))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory("C:\\Application");
            }
            if (System.IO.Directory.Exists("C:\\Temp"))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory("C:\\Temp");
            }

            if (System.IO.Directory.Exists(Application.StartupPath + "\\PTFile"))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\PTFile");
            }



            defaultLookAndFeel1.LookAndFeel.SkinName = "McSkin";
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);


            DataSet dsCompany = ProjectFunctions.GetDataSet("SELECT COMSYSID,COMNAME FROM COMCONF ");
            if (dsCompany.Tables[0].Rows.Count > 0)
            {
                txtCompany.DataSource = dsCompany.Tables[0];
                txtCompany.ValueMember = "COMSYSID";
                txtCompany.DisplayMember = "COMNAME";
            }



        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataSet dsGetUser = ProjectFunctions.GetDataSet("Select UserName from UserMaster WHere UserName='" + txtUserName.Text.Trim() + "'");
                if (dsGetUser.Tables[0].Rows.Count > 0)
                {
                    GlobalVariables.CurrentUser = txtUserName.Text;
                    DataSet dsUnit = ProjectFunctions.GetDataSet("SELECT        UNITS.UNITID, UNITS.UNITNAME FROM  UNITS INNER JOIN UserUnitAccess ON UNITS.UNITID = UserUnitAccess.UnitCode Where UserName='" + txtUserName.Text + "'");
                    if (dsUnit.Tables[0].Rows.Count > 0)
                    {
                        txtUnit.DataSource = dsUnit.Tables[0];
                        txtUnit.ValueMember = "UNITID";
                        txtUnit.DisplayMember = "UNITNAME";
                    }
                    DataSet dsFNYear = ProjectFunctions.GetDataSet("SELECT        FNYear.FNYearCode FROM  UserFNAccess INNER JOIN FNYear ON UserFNAccess.FNTransID = FNYear.TransID  Where UserName='" + txtUserName.Text + "'");
                    if (dsFNYear.Tables[0].Rows.Count > 0)
                    {
                        txtFNYear.DataSource = dsFNYear.Tables[0];
                        txtFNYear.ValueMember = "FNYearCode";
                        txtFNYear.DisplayMember = "FNYearCode";
                    }
                }
                else
                {
                    ProjectFunctions.SpeakError("Invalid UserName");
                }
            }
        }

        private void TxtCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtUnit.Focus();
            }
        }

        private void TxtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtFNYear.Focus();
            }
        }

        private void TxtFNYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                btnLogin.Focus();
            }
        }

        private void TxtUserName_DoubleClick(object sender, EventArgs e)
        {

            txtUserName.Text = "HAPPY";
            SendKeys.Send("{Enter}");
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false, true);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Backing Up Initialized");
            if (System.IO.Directory.Exists(@"\\cserver\New Software\Backup\" + DateTime.Now.DayOfWeek.ToString()))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory(@"\\cserver\New Software\Backup\" + DateTime.Now.DayOfWeek.ToString());
            }

            Task.Run(() => ProjectFunctions.GetDataSet("BACKUP DATABASE SEQKARTNew TO DISK ='" + @"\\cserver\New Software\Backup\" + DateTime.Now.DayOfWeek.ToString() + @"\SEQKARTNEW.bak'"));
            SplashScreenManager.CloseForm();
        }
    }
}