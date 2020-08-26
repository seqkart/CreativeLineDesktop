using DevExpress.XtraSplashScreen;
using SeqKartLibrary;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmLogincs : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]

        public static extern IntPtr FindWindow(IntPtr ZeroOnly, string lpWindowName);



        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);



        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]

        static extern bool SetForegroundWindow(IntPtr hWnd);


        private bool isDebug = false;
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

            DataSet dsGetUser = ProjectFunctions.GetDataSet(SQL_QUERIES.SQL_USERMASTER(txtUserName.Text.Trim(), txtPassword.Text.Trim()));
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
                if (DateTime.Now.Date >= Convert.ToDateTime("2020-04-1").Date && DateTime.Now.Date <= Convert.ToDateTime("2022-03-31").Date)
                {
                    if (Math.Abs((DateTime.Now.Date - GlobalVariables.LicenseToExpireDate.Date).Days) < 30)

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
                    DataSet dsCompany = ProjectFunctions.GetDataSet(SQL_QUERIES.SQL_COMCONF_ALL());
                    DataRow dr = dsCompany.Tables[0].Rows[0];

                    GlobalVariables.CAddress1 = dr[SQL_COLUMNS.COMCONF._COMADD].ToString();
                    GlobalVariables.CAddress2 = dr[SQL_COLUMNS.COMCONF._COMADD1].ToString();
                    GlobalVariables.CAddress3 = dr[SQL_COLUMNS.COMCONF._COMADD2].ToString();
                    GlobalVariables.CmpGSTNo = dr[SQL_COLUMNS.COMCONF._COMGST].ToString();
                    GlobalVariables.CompanyName = dr[SQL_COLUMNS.COMCONF._COMNAME].ToString();
                    GlobalVariables.TelNo = dr[SQL_COLUMNS.COMCONF._COMPHONE].ToString();
                    GlobalVariables.CmpEmailID = dr[SQL_COLUMNS.COMCONF._COMEID].ToString();
                    GlobalVariables.CmpZipCode = dr[SQL_COLUMNS.COMCONF._COMZIP].ToString();
                    GlobalVariables.CmpWebSite = dr[SQL_COLUMNS.COMCONF._COMWEBSITE].ToString();

                    DataSet dsFY = ProjectFunctions.GetDataSet(SQL_QUERIES.SQL_FN_YEAR(txtFNYear.Text));
                    DataRow drFY = dsFY.Tables[0].Rows[0];

                    GlobalVariables.CUnitID = txtUnit.SelectedValue.ToString().PadLeft(2, '0');

                    GlobalVariables.FinancialYear = drFY[SQL_COLUMNS.FN_YEAR._FNYearCode].ToString();
                    GlobalVariables.FinYearStartDate = Convert.ToDateTime(drFY[SQL_COLUMNS.FN_YEAR._FNStartDate]).Date;
                    GlobalVariables.FinYearEndDate = Convert.ToDateTime(drFY[SQL_COLUMNS.FN_YEAR._FNEndDate]).Date;

                    GlobalVariables.BarCodePreFix = ProjectFunctions.GetDataSet(SQL_QUERIES.SQL_UNITS(GlobalVariables.CUnitID)).Tables[0].Rows[0][0].ToString();


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


            DataSet dsCompany = ProjectFunctionsUtils.GetDataSet(SQL_QUERIES.SQL_COMCONF());
            if (ComparisonUtils.IsNotNull_DataSet(dsCompany))
            {
                txtCompany.DataSource = dsCompany.Tables[0];
                txtCompany.ValueMember = SQL_COLUMNS.COMCONF._COMSYSID;// "COMSYSID";
                txtCompany.DisplayMember = SQL_COLUMNS.COMCONF._COMNAME;// "COMNAME";
            }

            DataSet dsFNYear = ProjectFunctionsUtils.GetDataSet(SQL_QUERIES.SQL_FN_YEAR_ACTIVE("Y"));
            if (ComparisonUtils.IsNotNull_DataSet(dsFNYear))
            {
                txtFNYear.DataSource = dsFNYear.Tables[0];
                txtFNYear.ValueMember = SQL_COLUMNS.FN_YEAR._FNYearCode;
                txtFNYear.DisplayMember = SQL_COLUMNS.FN_YEAR._FNYearCode;
            }
            if (isDebug)
            {
                //MessageBox.Show(dsFNYear.Tables[0].Rows.Count.ToString());
                txtPassword.Text = "123";
                txtUserName.Text = "HAPPY";
                SendKeys.Send("{Enter}");

                txtUserName.Focus();


                txtUserName_KeyDown(null, null);
                btnLogin_Click(null, null);
            }



        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                DataSet dsGetUser = ProjectFunctionsUtils.GetDataSet(SQL_QUERIES.SQL_USERMASTER_BY_USER(txtUserName.Text.Trim()));
                if (ComparisonUtils.IsNotNull_DataSet(dsGetUser))
                {
                    GlobalVariables.CurrentUser = txtUserName.Text;
                    DataSet dsUnit = ProjectFunctionsUtils.GetDataSet(SQL_QUERIES.SQL_UNITS_BY_USER(txtUserName.Text));
                    if (ComparisonUtils.IsNotNull_DataSet(dsUnit))
                    {
                        txtUnit.DataSource = dsUnit.Tables[0];
                        txtUnit.ValueMember = SQL_COLUMNS.UNITS._UNITID;
                        txtUnit.DisplayMember = SQL_COLUMNS.UNITS._UNITNAME;
                    }
                    DataSet dsFNYear = ProjectFunctionsUtils.GetDataSet(SQL_QUERIES.SQL_USER_FN_ACCESS_BY_USER(txtUserName.Text));
                    if (ComparisonUtils.IsNotNull_DataSet(dsFNYear))
                    {
                        txtFNYear.DataSource = dsFNYear.Tables[0];
                        txtFNYear.ValueMember = SQL_COLUMNS.FN_YEAR._FNYearCode;
                        txtFNYear.DisplayMember = SQL_COLUMNS.FN_YEAR._FNYearCode;
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
            if (System.IO.Directory.Exists(Application.StartupPath + "\\Backup" + DateTime.Now.DayOfWeek.ToString()))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Backup" + DateTime.Now.DayOfWeek.ToString());
                // System.IO.Directory.CreateDirectory(@"\\cserver\New Software\Backup\" + DateTime.Now.DayOfWeek.ToString());
            }

            Task.Run(() => ProjectFunctions.GetDataSet("BACKUP DATABASE SEQKARTNew TO DISK ='" + Application.StartupPath + "\\Backup" + DateTime.Now.DayOfWeek.ToString() + @"\SEQKARTNEW.bak'"));
            SplashScreenManager.CloseForm();
        }



        private void txtCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtFNYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFNYear.Text = "2020-2021";
        }
    }
}