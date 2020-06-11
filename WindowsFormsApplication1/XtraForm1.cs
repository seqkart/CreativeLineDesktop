using BNPL.Crystal_Reports;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Data;

using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Administration;
using WindowsFormsApplication1.FormReports;

namespace WindowsFormsApplication1
{
    public partial class 
        XtraForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {

            // DevExpress.Utils.AppearanceObject.DefaultFont = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.FontFamily.Name, 10);
            this.Text = GlobalVariables.CurrentUser + " has Logged In ";
            CreateMenuType1();


            var str = String.Format("[sp_LoadUserAllocatedWork2] '" + GlobalVariables.CurrentUser + "'");
            using (var ds = ProjectFunctions.GetDataSet(str))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var MyTempTable = ds.Tables[0];
                    var ProgInMenu = (from DataRow dRow in MyTempTable.Rows
                                      select dRow["ProginMenu"]).Distinct();
                    foreach (var NameItemPage in ProgInMenu)
                    {
                        DevExpress.XtraBars.Navigation.AccordionControlElement OuterElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
                        OuterElement.Text = NameItemPage.ToString();
                        accordionControl1.Elements.Add(OuterElement);

                        var ProginMenuGroup = (from DataRow dRow in MyTempTable.Select("ProginMenu='" + OuterElement.Text + "'")
                                               select dRow["ProginMenuGroup"].ToString().ToUpper()).Distinct();
                        foreach (var NameSubItem in ProginMenuGroup)
                        {
                            DevExpress.XtraBars.Navigation.AccordionControlElement InnerElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
                            InnerElement.Text = NameSubItem.ToUpper();
                            OuterElement.Elements.Add(InnerElement);

                            var Drs = MyTempTable.Select(String.Format("ProginMenu='{0}' and ProginMenuGroup='{1}'", OuterElement.Text, NameSubItem));
                            foreach (DataRow R in Drs)
                            {
                                DevExpress.XtraBars.Navigation.AccordionControlElement InnerMostElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
                                InnerMostElement.Text = R["ProgDesc"].ToString();
                                InnerMostElement.Name = R["ProgCode"].ToString();
                                InnerElement.Elements.Add(InnerMostElement);
                                InnerMostElement.Click += InnerMostElement_Click;

                            }
                        }
                    }
                    MyTempTable.Dispose();
                }
                Refresh();
            }



            _ribbonControl.Minimized = true;


            DevExpress.XtraTab.XtraTabPage Page = new DevExpress.XtraTab.XtraTabPage();

            Page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;


            //xtraTabControl1.TabPages.Add(Page);

            //Page.Text = "Default DashBoard";





            //var PROG1 = new frmMainDashBoard() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
            //PROG1.Show();
            //PROG1.BringToFront();
            //PROG1.Parent = Page;
            //xtraTabControl1.SelectedTabPage = Page;


            DataSet dsUserTheme = ProjectFunctions.GetDataSet("select isnull(UserTheme,'') as UserTheme from UserMaster where UserName='" + GlobalVariables.CurrentUser + "'");
            if (dsUserTheme.Tables[0].Rows[0][0].ToString().Length > 0)
            {
                defaultLookAndFeel1.LookAndFeel.SkinName = dsUserTheme.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                defaultLookAndFeel1.LookAndFeel.SkinName = "The Bezier";
            }
        }

        private void XtraForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
        }



        private void xtraTabControl1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                //MessageBox.Show(String.IsNullOrEmpty(xtraTabControl1.SelectedTabPage.Name) ? "0":"1");
                if (!String.IsNullOrEmpty(xtraTabControl1.SelectedTabPage.Name))
                {
                    GlobalVariables.ProgCode = xtraTabControl1.SelectedTabPage.Name;
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                
                //MessageBox.Show(ex.Message);
            }
        }
        private void RunProgAccordin(string myitem, string itemcaption)
        {

            GlobalVariables.ProgCode = myitem;
            GlobalVariables.ProgDesc = itemcaption;



            foreach (DevExpress.XtraTab.XtraTabPage p in xtraTabControl1.TabPages)
            {
                if (p.Text.ToUpper() == GlobalVariables.ProgDesc.ToUpper())
                {
                    xtraTabControl1.SelectedTabPage = p;
                    return;
                }
            }
            DevExpress.XtraTab.XtraTabPage Page = new DevExpress.XtraTab.XtraTabPage();

            Page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;


            xtraTabControl1.TabPages.Add(Page);

            Page.Text = GlobalVariables.ProgDesc;
            Page.Name = GlobalVariables.ProgCode;

            //MessageBox.Show(myitem);
            Console.WriteLine("WriteLine ********** " + myitem);
            PrintLogWin.PrintLog("Write ********** " + myitem);

            switch (myitem)
            {

                case WIN_APP_TABS._frmNewFormAAddEdit:
                    var PROG1 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG1.Show();
                    PROG1.BringToFront();
                    PROG1.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case WIN_APP_TABS._frm_Chng_Pswd:
                    var PROG2 = new frm_Chng_Pswd() { Dock = DockStyle.Fill };
                    PROG2.Show();
                    PROG2.BringToFront();
                    PROG2.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                //USER MASTER




                case WIN_APP_TABS._frmUserDetails:
                    //var PROG3 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    var PROG3 = new XtraForm_UserMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG3.Show();
                    PROG3.BringToFront();
                    PROG3.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case WIN_APP_TABS._frmUserFinancialYearAddition:
                    var PROG4 = new frmUserFinancialYearAddition() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG4.Show();
                    PROG4.BringToFront();
                    PROG4.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case WIN_APP_TABS._frmWorkAllocation:
                    var PROG5 = new frmWorkAllocation() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };

                    PROG5.Show();
                    PROG5.BringToFront();
                    PROG5.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG6":
                    var PROG6 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };

                    PROG6.Show();
                    PROG6.BringToFront();
                    PROG6.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG7":
                    var PROG7 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG7";

                    PROG7.Show();
                    PROG7.BringToFront();
                    PROG7.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG8":
                    var PROG8 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG8";

                    PROG8.Show();
                    PROG8.BringToFront();
                    PROG8.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG9":
                    var PROG9 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG9";

                    PROG9.Show();
                    PROG9.BringToFront();
                    PROG9.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG10":
                    var PROG10 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG10";

                    PROG10.Show();
                    PROG10.BringToFront();
                    PROG10.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG11":
                    var PROG11 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG11";

                    PROG11.Show();
                    PROG11.BringToFront();
                    PROG11.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG12":
                    var PROG12 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG12";

                    PROG12.Show();
                    PROG12.BringToFront();
                    PROG12.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG13":
                    var PROG13 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG13";

                    PROG13.Show();
                    PROG13.BringToFront();
                    PROG13.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG14":
                    var PROG14 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG14";

                    PROG14.Show();
                    PROG14.BringToFront();
                    PROG14.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG15":
                    var PROG15 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG15";

                    PROG15.Show();
                    PROG15.BringToFront();
                    PROG15.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;


                case "PROG16":
                    var PROG16 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG16";

                    PROG16.Show();
                    PROG16.BringToFront();
                    PROG16.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;


                case "PROG17":
                    var PROG17 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG17";

                    PROG17.Show();
                    PROG17.BringToFront();
                    PROG17.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG18":
                    var PROG18 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG18";

                    PROG18.Show();
                    PROG18.BringToFront();
                    PROG18.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;


                case "PROG19":
                    var PROG19 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG19";

                    PROG19.Show();
                    PROG19.BringToFront();
                    PROG19.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG20":
                    var PROG20 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG20";

                    PROG20.Show();
                    PROG20.BringToFront();
                    PROG20.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG21":
                    var PROG21 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG21";

                    PROG21.Show();
                    PROG21.BringToFront();
                    PROG21.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG22":
                    var PROG22 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG22";

                    PROG22.Show();
                    PROG22.BringToFront();
                    PROG22.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG23":
                    var PROG23 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG23";

                    PROG23.Show();
                    PROG23.BringToFront();
                    PROG23.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG24":
                    var PROG24 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG24";

                    PROG24.Show();
                    PROG24.BringToFront();
                    PROG24.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG25":
                    var PROG25 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG25";

                    PROG25.Show();
                    PROG25.BringToFront();
                    PROG25.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG26":
                    var PROG26 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG26";

                    PROG26.Show();
                    PROG26.BringToFront();
                    PROG26.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG27":
                    var PROG27 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG27";

                    PROG27.Show();
                    PROG27.BringToFront();
                    PROG27.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG28":
                    var PROG28 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG28";

                    PROG28.Show();
                    PROG28.BringToFront();
                    PROG28.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG29":
                    var PROG29 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG29";

                    PROG29.Show();
                    PROG29.BringToFront();
                    PROG29.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG30":
                    var PROG30 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG30";

                    PROG30.Show();
                    PROG30.BringToFront();
                    PROG30.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG31":
                    var PROG31 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG31";

                    PROG31.Show();
                    PROG31.BringToFront();
                    PROG31.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG32":
                    var PROG32 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG32";

                    PROG32.Show();
                    PROG32.BringToFront();
                    PROG32.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG33":
                    var PROG33 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG33";

                    PROG33.Show();
                    PROG33.BringToFront();
                    PROG33.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG34":
                    var PROG34 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG34";

                    PROG34.Show();
                    PROG34.BringToFront();
                    PROG34.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG35":
                    var PROG35 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG35";

                    PROG35.Show();
                    PROG35.BringToFront();
                    PROG35.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG49":
                    var PROG49 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG49";

                    PROG49.Show();
                    PROG49.BringToFront();
                    PROG49.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG43":
                    var PROG43 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG43";

                    PROG43.Show();
                    PROG43.BringToFront();
                    PROG43.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG42":
                    var PROG42 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG42";

                    PROG42.Show();
                    PROG42.BringToFront();
                    PROG42.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG36":
                    //var PROG36 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    //GlobalVariables.ProgCode = "PROG36";

                    //PROG36.Show();
                    //PROG36.BringToFront();
                    //PROG36.Parent = Page;
                    //xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG52":
                    var PROG52 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG52";

                    PROG52.Show();
                    PROG52.BringToFront();
                    PROG52.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG50":
                    var PROG50 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG50";

                    PROG50.Show();
                    PROG50.BringToFront();
                    PROG50.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG48":
                    var PROG48 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG48";

                    PROG48.Show();
                    PROG48.BringToFront();
                    PROG48.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG44":
                    //var PROG44 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    //GlobalVariables.ProgCode = "PROG44";

                    //PROG44.Show();
                    //PROG44.BringToFront();
                    //PROG44.Parent = Page;
                    //xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG38":
                    var PROG38 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG38";

                    PROG38.Show();
                    PROG38.BringToFront();
                    PROG38.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG40":
                    //var PROG40 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    //GlobalVariables.ProgCode = "PROG40";

                    //PROG40.Show();
                    //PROG40.BringToFront();
                    //PROG40.Parent = Page;
                    //xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG54":
                    var PROG54 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG54";

                    PROG54.Show();
                    PROG54.BringToFront();
                    PROG54.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG58":
                    var PROG58 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG58";

                    PROG58.Show();
                    PROG58.BringToFront();
                    PROG58.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG59":
                    var PROG59 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG59";

                    PROG59.Show();
                    PROG59.BringToFront();
                    PROG59.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG60":
                    var PROG60 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG60";

                    PROG60.Show();
                    PROG60.BringToFront();
                    PROG60.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG61":
                    //var PROG61 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    //GlobalVariables.ProgCode = "PROG61";
                    //PROG61.Show();
                    //PROG61.BringToFront();
                    //PROG61.Parent = Page;
                    //xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG63":
                    //var PROG63 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    //GlobalVariables.ProgCode = "PROG63";

                    //PROG63.Show();
                    //PROG63.BringToFront();
                    //PROG63.Parent = Page;
                    //xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG64":
                    //var PROG64 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    //GlobalVariables.ProgCode = "PROG64";

                    //PROG64.Show();
                    //PROG64.BringToFront();
                    //PROG64.Parent = Page;
                    //xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG55":
                    var PROG55 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG55";

                    PROG55.Show();
                    PROG55.BringToFront();
                    PROG55.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG87":
                    var PROG87 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG87";

                    PROG87.Show();
                    PROG87.BringToFront();
                    PROG87.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG89":
                    var PROG89 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG89";

                    PROG89.Show();
                    PROG89.BringToFront();
                    PROG89.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG91":
                    var PROG91 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG91";

                    PROG91.Show();
                    PROG91.BringToFront();
                    PROG91.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;

                    break;
                case "PROG56":
                    var PROG56 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG56";

                    PROG56.Show();
                    PROG56.BringToFront();
                    PROG56.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;

                    break;
                case "PROG65":
                    var PROG65 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG65";

                    PROG65.Show();
                    PROG65.BringToFront();
                    PROG65.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG37":
                    var PROG37 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG37";

                    PROG37.Show();
                    PROG37.BringToFront();
                    PROG37.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG66":
                    var PROG66 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG66";

                    PROG66.Show();
                    PROG66.BringToFront();
                    PROG66.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG67":
                    var PROG67 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG67";
                    PROG67.Show();
                    PROG67.BringToFront();
                    PROG67.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG68":
                    var PROG68 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG68";

                    PROG68.Show();
                    PROG68.BringToFront();
                    PROG68.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG71":
                    var PROG71 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG71";

                    PROG71.Show();
                    PROG71.BringToFront();
                    PROG71.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG72":
                    var PROG72 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG72";

                    PROG72.Show();
                    PROG72.BringToFront();
                    PROG72.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG69":
                    var PROG69 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG69";

                    PROG69.Show();
                    PROG69.BringToFront();
                    PROG69.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;

                    break;
                case "PROG70":
                    var PROG70 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG70";

                    PROG70.Show();
                    PROG70.BringToFront();
                    PROG70.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG73":
                    var PROG73 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG73";

                    PROG73.Show();
                    PROG73.BringToFront();
                    PROG73.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG74":
                    var PROG74 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG74";

                    PROG74.Show();
                    PROG74.BringToFront();
                    PROG74.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG75":
                    var PROG75 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG75";

                    PROG75.Show();
                    PROG75.BringToFront();
                    PROG75.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG76":
                    var PROG76 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG76";

                    PROG76.Show();
                    PROG76.BringToFront();
                    PROG76.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG77":
                    var PROG77 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG77";

                    PROG77.Show();
                    PROG77.BringToFront();
                    PROG77.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG78":
                    var PROG78 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG78";

                    PROG78.Show();
                    PROG78.BringToFront();
                    PROG78.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG79":
                    var PROG79 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG79";

                    PROG79.Show();
                    PROG79.BringToFront();
                    PROG79.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG57":
                    var PROG57 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG57";

                    PROG57.Show();
                    PROG57.BringToFront();
                    PROG57.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG46":
                    var PROG46 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG46";

                    PROG46.Show();
                    PROG46.BringToFront();
                    PROG46.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG80":
                    var PROG80 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG80";

                    PROG80.Show();
                    PROG80.BringToFront();
                    PROG80.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG102":
                    var PROG102 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG102";

                    PROG102.Show();
                    PROG102.BringToFront();
                    PROG102.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG104":
                    var PROG104 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG104";

                    PROG104.Show();
                    PROG104.BringToFront();
                    PROG104.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG105":
                    var PROG105 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG105";

                    PROG105.Show();
                    PROG105.BringToFront();
                    PROG105.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG103":
                    var PROG103 = new frmProcessSMCommission() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG103";

                    PROG103.Show();
                    PROG103.BringToFront();
                    PROG103.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG90":
                    var PROG90 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG90";

                    PROG90.Show();
                    PROG90.BringToFront();
                    PROG90.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG101":
                    var PROG101 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG101";

                    PROG101.Show();
                    PROG101.BringToFront();
                    PROG101.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG106":
                    var PROG106 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG106";

                    PROG106.Show();
                    PROG106.BringToFront();
                    PROG106.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG107":
                    var PROG107 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG107";

                    PROG107.Show();
                    PROG107.BringToFront();
                    PROG107.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG108":
                    var PROG108 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG108";

                    PROG108.Show();
                    PROG108.BringToFront();
                    PROG108.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG109":
                    var PROG109 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG109";

                    PROG109.Show();
                    PROG109.BringToFront();
                    PROG109.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG110":
                    var PROG110 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG110";

                    PROG110.Show();
                    PROG110.BringToFront();
                    PROG110.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG111":
                    var PROG111 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG111";

                    PROG111.Show();
                    PROG111.BringToFront();
                    PROG111.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG112":
                    var PROG112 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG112";

                    PROG112.Show();
                    PROG112.BringToFront();
                    PROG112.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG113":
                    var PROG113 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    GlobalVariables.ProgCode = "PROG113";

                    PROG113.Show();
                    PROG113.BringToFront();
                    PROG113.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case WIN_APP_TABS._frmRoleMst:
                    var PROG115 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG115.Show();
                    PROG115.BringToFront();
                    PROG115.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG116":
                    var PROG116 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG116.Show();
                    PROG116.BringToFront();
                    PROG116.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG117":
                    var PROG117 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG117.Show();
                    PROG117.BringToFront();
                    PROG117.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG118":
                    var PROG118 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG118.Show();
                    PROG118.BringToFront();
                    PROG118.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG119":
                    var PROG119 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG119.Show();
                    PROG119.BringToFront();
                    PROG119.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG120":
                    var PROG120 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG120.Show();
                    PROG120.BringToFront();
                    PROG120.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG121":
                    var PROG121 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG121.Show();
                    PROG121.BringToFront();
                    PROG121.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG122":
                    var PROG122 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG122.Show();
                    PROG122.BringToFront();
                    PROG122.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG123":
                    var PROG123 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG123.Show();
                    PROG123.BringToFront();
                    PROG123.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG124":
                    var PROG124 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG124.Show();
                    PROG124.BringToFront();
                    PROG124.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG125":
                    var PROG125 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG125.Show();
                    PROG125.BringToFront();
                    PROG125.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG126":
                    var PROG126 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG126.Show();
                    PROG126.BringToFront();
                    PROG126.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG127":
                    var PROG127 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG127.Show();
                    PROG127.BringToFront();
                    PROG127.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG128":
                    var PROG128 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG128.Show();
                    PROG128.BringToFront();
                    PROG128.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG129":
                    var PROG129 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG129.Show();
                    PROG129.BringToFront();
                    PROG129.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG130":
                    var PROG130 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG130.Show();
                    PROG130.BringToFront();
                    PROG130.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG131":
                    var PROG131 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };

                    PROG131.Show();
                    PROG131.BringToFront();
                    PROG131.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG132":
                    var PROG132 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG132.Show();
                    PROG132.BringToFront();
                    PROG132.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG133":
                    var PROG133 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG133.Show();
                    PROG133.BringToFront();
                    PROG133.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG134":
                    var PROG134 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG134.Show();
                    PROG134.BringToFront();
                    PROG134.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG135":
                    var PROG135 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG135.Show();
                    PROG135.BringToFront();
                    PROG135.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG136":
                    var PROG136 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG136.Show();
                    PROG136.BringToFront();
                    PROG136.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG137":
                    var PROG137 = new FormReports.frmPrintReportDesigner() { StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG137.Show();
                    PROG137.BringToFront();


                    break;
                case "PROG138":
                    var PROG138 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG138.Show();
                    PROG138.BringToFront();
                    PROG138.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG139":


                    ProjectFunctions.GetDataSet("sp_SinkDCOWithOnline");
                    XtraMessageBox.Show("Data Uploaded");

                    break;
                case "PROG140":


                    ProjectFunctions.GetDataSet("sp_DownloadDCOFromOnline");
                    XtraMessageBox.Show("Data Downloaded");

                    break;
                case "PROG141":
                    var PROG141 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG141.Show();
                    PROG141.BringToFront();
                    PROG141.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG142":
                    var PROG142 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG142.Show();
                    PROG142.BringToFront();
                    PROG142.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG143":
                    var PROG143 = new CommonTemplate() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG143.Show();
                    PROG143.BringToFront();
                    PROG143.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG144":
                    var PROG144 = new CommonTemplate() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG144.Show();
                    PROG144.BringToFront();
                    PROG144.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG145":
                    var PROG145 = new CommonTemplate() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG145.Show();
                    PROG145.BringToFront();
                    PROG145.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG147":
                    var PROG147 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG147.Show();
                    PROG147.BringToFront();
                    PROG147.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG148":
                    var PROG148 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG148.Show();
                    PROG148.BringToFront();
                    PROG148.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG149":
                    var PROG149 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG149.Show();
                    PROG149.BringToFront();
                    PROG149.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG150":
                    var PROG150 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG150.Show();
                    PROG150.BringToFront();
                    PROG150.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG151":
                    var PROG151 = new CommonTemplate() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG151.Show();
                    PROG151.BringToFront();
                    PROG151.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG156":
                    var PROG156 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG156.Show();
                    PROG156.BringToFront();
                    PROG156.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG157":
                    var PROG157 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG157.Show();
                    PROG157.BringToFront();
                    PROG157.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG160":
                    var PROG160 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG160.Show();
                    PROG160.BringToFront();
                    PROG160.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG155":
                    var PROG155 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG155.Show();
                    PROG155.BringToFront();
                    PROG155.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;

                case "PROG164":
                    var PROG164 = new BNPL.Forms_Master.frmEmployeeMDataPassing() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG164.Show();
                    PROG164.BringToFront();
                    PROG164.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG163":
                    var PROG163 = new BNPL.Forms_Master.frmEmployeeSalaryMst() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG163.Show();
                    PROG163.BringToFront();
                    PROG163.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG162":
                    var PROG162 = new BNPL.Forms_Transaction.frmProcessSalary() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG162.Show();
                    PROG162.BringToFront();
                    PROG162.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG161":
                    var PROG161 = new BNPL.Forms_Master.frmLoanMst() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG161.Show();
                    PROG161.BringToFront();
                    PROG161.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG159":
                    var PROG159 = new BNPL.Forms_Master.frmExcelStructureLoading() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG159.Show();
                    PROG159.BringToFront();
                    PROG159.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG154":
                    var PROG154 = new BNPL.Forms_Master.frm_EmpsalMst() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG154.Show();
                    PROG154.BringToFront();
                    PROG154.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG153":
                    var PROG153 = new BNPL.Forms_Master.frmAttendenceLaoding() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG153.Show();
                    PROG153.BringToFront();
                    PROG153.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG152":
                    var PROG152 = new BNPL.Forms_Transaction.frmAdvanceMst() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG152.Show();
                    PROG152.BringToFront();
                    PROG152.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG165":
                    var PROG165 = new CommonTemplate() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG165.Show();
                    PROG165.BringToFront();
                    PROG165.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG166":
                    var PROG166 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG166.Show();
                    PROG166.BringToFront();
                    PROG166.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG167":
                    var PROG167 = new frmPartyAccounts() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG167.Show();
                    PROG167.BringToFront();
                    PROG167.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG168":
                    var PROG168 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG168.Show();
                    PROG168.BringToFront();
                    PROG168.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG169":
                    var PROG169 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG169.Show();
                    PROG169.BringToFront();
                    PROG169.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG170":
                    var PROG170 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG170.Show();
                    PROG170.BringToFront();
                    PROG170.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                case "PROG171":
                    var PROG171 = new Transaction.frmBarPrinting() { Dock = DockStyle.Fill, TopLevel = false, StartPosition = FormStartPosition.Manual, WindowState = System.Windows.Forms.FormWindowState.Normal };
                    PROG171.Show();
                    PROG171.BringToFront();
                    PROG171.Parent = Page;
                    xtraTabControl1.SelectedTabPage = Page;
                    break;
                default:


                    break;
            }
        }
        private void InnerMostElement_Click(object sender, EventArgs e)
        {
            RunProgAccordin((sender as DevExpress.XtraBars.Navigation.AccordionControlElement).Name, (sender as DevExpress.XtraBars.Navigation.AccordionControlElement).Text);
        }


        private void skinRibbonGalleryBarItem_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            ProjectFunctions.GetDataSet("Update UserMaster Set UserTheme='" + e.Item.Caption + "' Where UserName='" + GlobalVariables.CurrentUser + "'");
        }

        private void CreateMenuType1()
        {
            //var str = String.Format("[sp_LoadUserAllocatedWork2] '" + GlobalVariables.CurrentUser + "'");
            //using (var ds = ProjectFunctions.GetDataSet(str))
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        var MyTempTable = ds.Tables[0];
            //        var ProgInMenu = (from DataRow dRow in MyTempTable.Rows
            //                          select dRow["ProginMenu"]).Distinct();
            //        foreach (var NameItemPage in ProgInMenu)
            //        {
            //            var ItemPage = new RibbonPage() { Text = NameItemPage.ToString() };
            //            _ribbonControl.Pages.Add(ItemPage);

            //            var ProginMenuGroup = (from DataRow dRow in MyTempTable.Select("ProginMenu='" + ItemPage.Text + "'")
            //                                   select dRow["ProginMenuGroup"].ToString().ToUpper()).Distinct();
            //            foreach (var NameSubItem in ProginMenuGroup)
            //            {
            //                var group = new RibbonPageGroup(NameSubItem.ToUpper()) { ShowCaptionButton = false, Text = string.Empty };
            //                ItemPage.Groups.Add(group);
            //                var container = new BarLinkContainerItem();
            //                ((BarLinkContainerItem)container).Caption = NameSubItem;
            //                group.ItemLinks.Add(((BarLinkContainerItem)container));
            //                var Drs = MyTempTable.Select(String.Format("ProginMenu='{0}' and ProginMenuGroup='{1}'", ItemPage.Text, NameSubItem));
            //                foreach (DataRow R in Drs)
            //                {
            //                    var Kc = new KeysConverter();
            //                    BarButtonItem button;
            //                    button = new BarButtonItem() { Caption = R["ProgDesc"].ToString(), Name = R["ProgCode"].ToString() };
            //                    ((BarLinkContainerItem)container).AddItem(button);
            //                    button.ItemClick += new ItemClickEventHandler(Button_ItemClick);
            //                }
            //            }
            //        }
            //        MyTempTable.Dispose();
            //    }
            //    Refresh();
            //}




            //var str = String.Format("[VPL_HR_FillMenu2] '" + GlobalVariables.CurrentUser + "'");
            //using (var ds = ProjectFunctions.GetDataSet(str))
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        DataTable MyTempTable = new DataTable();
            //        MyTempTable = ds.Tables[0].Clone();
            //        foreach (DataRow dr in ds.Tables[0].Rows)
            //        {
            //            if (dr["ParentID"].ToString() == "0" || dr["Access"].ToString().ToUpper() == "Y")
            //            {
            //                MyTempTable.ImportRow(dr);
            //            }
            //        }

            //        foreach (DataRow drOuterMost in MyTempTable.Rows)
            //        {
            //            if (Convert.ToInt32(drOuterMost["ParentID"]) == 0)
            //            {
            //                RibbonPage ItemGroup = new RibbonPage();
            //                ItemGroup.Text = drOuterMost["Text"].ToString();
            //                ItemGroup.Name = drOuterMost["Text"].ToString();
            //                _ribbonControl.Pages.Add(ItemGroup);
            //                var group = new RibbonPageGroup(drOuterMost["Text"].ToString()) { ShowCaptionButton = false, Text = drOuterMost["Text"].ToString() };
            //                ItemGroup.Groups.Add(group);
            //                foreach (DataRow drInnerMost in MyTempTable.Rows)
            //                {
            //                    if (Convert.ToInt32(drInnerMost["ParentID"]) > 0 && drOuterMost["MenuID"].ToString() == drInnerMost["ParentID"].ToString())
            //                    {
            //                        BarButtonItem button = new BarButtonItem();
            //                        button.Caption = drInnerMost["Text"].ToString();
            //                        button.Name = "A" + drInnerMost["MenuID"].ToString();
            //                        button.ItemClick += Button_ItemClick;
            //                        _ribbonControl.Items.Add(button);
            //                        group.ItemLinks.Add(button);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            _ribbonControl.Minimized = true;
        }




        private void XtraForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Do You Really Want To Log Off", "Log Off", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void XtraForm1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void XtraForm1_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.SalePopUPForAllWindows(this, e);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenu1.ShowPopup(new System.Drawing.Point(200, 200));
        }
    }
}