using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmMainScreen : DevExpress.XtraEditors.XtraForm
    {
#pragma warning disable CS0169 // The field 'frmMainScreen.aTimer' is never used
        private static System.Timers.Timer aTimer;
#pragma warning restore CS0169 // The field 'frmMainScreen.aTimer' is never used
        private RibbonControl _mainRibbon;
#pragma warning disable CS0169 // The field 'frmMainScreen._Dr' is never used
        private DataRow _Dr;
#pragma warning restore CS0169 // The field 'frmMainScreen._Dr' is never used
        private PanelControl _WorkAreaPanel = new PanelControl();
#pragma warning disable CS0169 // The field 'frmMainScreen.selected_Record' is never used
        private int selected_Record;
#pragma warning restore CS0169 // The field 'frmMainScreen.selected_Record' is never used
        private RibbonGalleryBarItem SkinOptions;
        private RibbonPageGroup skinsRibbonPageGroup;
        private BackgroundWorker backgroundWorker1;
        private int width = 0;
#pragma warning disable CS0169 // The field 'frmMainScreen.ThisRecord' is never used
        private DataRow ThisRecord;
#pragma warning restore CS0169 // The field 'frmMainScreen.ThisRecord' is never used
        public frmMainScreen()
        {
            InitializeComponent();
            IntitializeTheme();
            backgroundWorker1 = new BackgroundWorker();
        }
        public void frmMain()
        {
            Controls.Clear();
            InitializeComponent();
            IntitializeTheme();
            backgroundWorker1 = new BackgroundWorker();
            frmMainScreenList_Load(null, null);


        }

        private void frmMainScreenList_Load(object sender, EventArgs e)
        {

        }
        private void ProgramInMenu()
        {
            _mainRibbon = new RibbonControl();
            SkinOptions = new RibbonGalleryBarItem() { Caption = "Skin", Id = 67, Name = "SkinOptions" };
            _mainRibbon.Dock = DockStyle.Top;
            _mainRibbon.ExpandCollapseItem.Id = 1;
            _mainRibbon.ExpandCollapseItem.Name = string.Empty;
            _mainRibbon.Items.AddRange(new BarItem[] { _mainRibbon.ExpandCollapseItem, SkinOptions });
            _mainRibbon.Location = new Point(0, 0);
            _mainRibbon.MaxItemId = 110;
            _mainRibbon.Name = "MainRibbon";
            _mainRibbon.RibbonStyle = RibbonControlStyle.MacOffice;
            _mainRibbon.Size = new Size(1100, 142);
            _mainRibbon.ShowCategoryInCaption = false;
            Controls.Add(_mainRibbon);


            skinsRibbonPageGroup = new RibbonPageGroup();
            skinsRibbonPageGroup.ItemLinks.Add(SkinOptions);
            skinsRibbonPageGroup.Name = "skinsRibbonPageGroup";
            skinsRibbonPageGroup.ShowCaptionButton = false;
            skinsRibbonPageGroup.Text = "Skins";

            SkinHelper.InitSkinGallery(SkinOptions, true);

            try
            {
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
                            var ItemPage = new RibbonPage() { Text = NameItemPage.ToString() };
                            _mainRibbon.Pages.Add(ItemPage);
                            if (ItemPage.Text.ToUpper() == "UTILITY")
                            {
                                ItemPage.Groups.Add(skinsRibbonPageGroup);
                                var group = new RibbonPageGroup("Goto") { ShowCaptionButton = false, Text = string.Empty };
                                ItemPage.Groups.Add(group);
                                var GoToBtn = new BarButtonItem() { Caption = "GoTo" };
                                group.ItemLinks.Add(GoToBtn);
                                _mainRibbon.Toolbar.ItemLinks.Add(GoToBtn);
                            }
                            var ProginMenuGroup = (from DataRow dRow in MyTempTable.Select("ProginMenu='" + ItemPage.Text + "'")
                                                   select dRow["ProginMenuGroup"].ToString().ToUpper()).Distinct();
                            foreach (var NameSubItem in ProginMenuGroup)
                            {
                                var group = new RibbonPageGroup(NameSubItem.ToUpper()) { ShowCaptionButton = false, Text = string.Empty };
                                ItemPage.Groups.Add(group);
                                var container = new BarLinkContainerItem
                                {
                                    Caption = NameSubItem
                                };
                                group.ItemLinks.Add(container);
                                var Drs = MyTempTable.Select(String.Format("ProginMenu='{0}' and ProginMenuGroup='{1}'", ItemPage.Text, NameSubItem));
                                foreach (DataRow R in Drs)
                                {
                                    var Kc = new KeysConverter();
                                    BarButtonItem button;
                                    button = new BarButtonItem() { Caption = R["ProgDesc"].ToString(), Name = R["ProgCode"].ToString() };
                                    container.AddItem(button);
                                    button.ItemClick += new ItemClickEventHandler(button_ItemClick);

                                }
                            }
                        }
                        MyTempTable.Dispose();
                    }
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _mainRibbon.Minimized = true;
            _mainRibbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
        }
        private void RunProg(string myitem)
        {
            GlobalVariables.ProgCode = myitem;
            switch (myitem)
            {
                case "PROG1":
                    var PROG1 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    _WorkAreaPanel.Controls.Add(PROG1);
                    PROG1.Show();
                    PROG1.BringToFront();
                    break;
                case "PROG2":
                    var PROG2 = new frm_Chng_Pswd();
                    _WorkAreaPanel.Controls.Add(PROG2);
                    PROG2.Show();
                    PROG2.BringToFront();
                    break;
                case "PROG3":
                    var PROG3 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    _WorkAreaPanel.Controls.Add(PROG3);
                    PROG3.Show();
                    PROG3.BringToFront();
                    break;
                case "PROG4":
                    var PROG4 = new frmUserFinancialYearAddition() { TopLevel = false };
                    _WorkAreaPanel.Controls.Add(PROG4);
                    PROG4.Show();
                    PROG4.BringToFront();
                    break;
                case "PROG5":
                    var PROG5 = new frmWorkAllocation() { Dock = DockStyle.Fill, TopLevel = false };
                    _WorkAreaPanel.Controls.Add(PROG5);
                    PROG5.Show();
                    PROG5.BringToFront();
                    break;
                case "PROG6":
                    var PROG6 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    _WorkAreaPanel.Controls.Add(PROG6);
                    PROG6.Show();
                    PROG6.BringToFront();
                    break;

                case "PROG7":
                    var PROG7 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG7";
                    _WorkAreaPanel.Controls.Add(PROG7);
                    PROG7.Show();
                    PROG7.BringToFront();
                    break;
                case "PROG8":
                    var PROG8 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG8";
                    _WorkAreaPanel.Controls.Add(PROG8);
                    PROG8.Show();
                    PROG8.BringToFront();
                    break;
                case "PROG9":
                    var PROG9 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG9";
                    _WorkAreaPanel.Controls.Add(PROG9);
                    PROG9.Show();
                    PROG9.BringToFront();
                    break;
                case "PROG10":
                    var PROG10 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG10";
                    _WorkAreaPanel.Controls.Add(PROG10);
                    PROG10.Show();
                    PROG10.BringToFront();
                    break;
                case "PROG11":
                    var PROG11 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG11";
                    _WorkAreaPanel.Controls.Add(PROG11);
                    PROG11.Show();
                    PROG11.BringToFront();
                    break;
                case "PROG12":
                    var PROG12 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG12";
                    _WorkAreaPanel.Controls.Add(PROG12);
                    PROG12.Show();
                    PROG12.BringToFront();
                    break;
                case "PROG13":
                    var PROG13 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG13";
                    _WorkAreaPanel.Controls.Add(PROG13);
                    PROG13.Show();
                    PROG13.BringToFront();
                    break;

                case "PROG14":
                    var PROG14 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG14";
                    _WorkAreaPanel.Controls.Add(PROG14);
                    PROG14.Show();
                    PROG14.BringToFront();
                    break;

                case "PROG15":
                    var PROG15 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG15";
                    _WorkAreaPanel.Controls.Add(PROG15);
                    PROG15.Show();
                    PROG15.BringToFront();
                    break;


                case "PROG16":
                    var PROG16 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG16";
                    _WorkAreaPanel.Controls.Add(PROG16);
                    PROG16.Show();
                    PROG16.BringToFront();
                    break;


                case "PROG17":
                    var PROG17 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG17";
                    _WorkAreaPanel.Controls.Add(PROG17);
                    PROG17.Show();
                    PROG17.BringToFront();
                    break;

                case "PROG18":
                    var PROG18 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG18";
                    _WorkAreaPanel.Controls.Add(PROG18);
                    PROG18.Show();
                    PROG18.BringToFront();
                    break;


                case "PROG19":
                    var PROG19 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG19";
                    _WorkAreaPanel.Controls.Add(PROG19);
                    PROG19.Show();
                    PROG19.BringToFront();
                    break;
                case "PROG20":
                    var PROG20 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG20";
                    _WorkAreaPanel.Controls.Add(PROG20);
                    PROG20.Show();
                    PROG20.BringToFront();
                    break;

                case "PROG21":
                    var PROG21 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG21";
                    _WorkAreaPanel.Controls.Add(PROG21);
                    PROG21.Show();
                    PROG21.BringToFront();
                    break;

                case "PROG22":
                    var PROG22 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG22";
                    _WorkAreaPanel.Controls.Add(PROG22);
                    PROG22.Show();
                    PROG22.BringToFront();
                    break;

                case "PROG23":
                    var PROG23 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG23";
                    _WorkAreaPanel.Controls.Add(PROG23);
                    PROG23.Show();
                    PROG23.BringToFront();
                    break;
                case "PROG24":
                    var PROG24 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG24";
                    _WorkAreaPanel.Controls.Add(PROG24);
                    PROG24.Show();
                    PROG24.BringToFront();
                    break;

                case "PROG25":
                    var PROG25 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG25";
                    _WorkAreaPanel.Controls.Add(PROG25);
                    PROG25.Show();
                    PROG25.BringToFront();
                    break;

                case "PROG26":
                    var PROG26 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG26";
                    _WorkAreaPanel.Controls.Add(PROG26);
                    PROG26.Show();
                    PROG26.BringToFront();
                    break;
                case "PROG27":
                    var PROG27 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG27";
                    _WorkAreaPanel.Controls.Add(PROG27);
                    PROG27.Show();
                    PROG27.BringToFront();
                    break;
                case "PROG28":
                    var PROG28 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG28";
                    _WorkAreaPanel.Controls.Add(PROG28);
                    PROG28.Show();
                    PROG28.BringToFront();
                    break;
                case "PROG29":
                    var PROG29 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG29";
                    _WorkAreaPanel.Controls.Add(PROG29);
                    PROG29.Show();
                    PROG29.BringToFront();
                    break;
                case "PROG30":
                    var PROG30 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG30";
                    _WorkAreaPanel.Controls.Add(PROG30);
                    PROG30.Show();
                    PROG30.BringToFront();
                    break;
                case "PROG31":
                    var PROG31 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG31";
                    _WorkAreaPanel.Controls.Add(PROG31);
                    PROG31.Show();
                    PROG31.BringToFront();
                    break;
                case "PROG32":
                    var PROG32 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG32";
                    _WorkAreaPanel.Controls.Add(PROG32);
                    PROG32.Show();
                    PROG32.BringToFront();
                    break;
                case "PROG33":
                    var PROG33 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG33";
                    _WorkAreaPanel.Controls.Add(PROG33);
                    PROG33.Show();
                    PROG33.BringToFront();
                    break;
                case "PROG34":
                    var PROG34 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG34";
                    _WorkAreaPanel.Controls.Add(PROG34);
                    PROG34.Show();
                    PROG34.BringToFront();
                    break;
                case "PROG35":
                    var PROG35 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG35";
                    _WorkAreaPanel.Controls.Add(PROG35);
                    PROG35.Show();
                    PROG35.BringToFront();
                    break;
                case "PROG49":
                    var PROG49 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG49";
                    _WorkAreaPanel.Controls.Add(PROG49);
                    PROG49.Show();
                    PROG49.BringToFront();
                    break;
                case "PROG43":
                    var PROG43 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG43";
                    _WorkAreaPanel.Controls.Add(PROG43);
                    PROG43.Show();
                    PROG43.BringToFront();
                    break;
                case "PROG42":
                    var PROG42 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG42";
                    _WorkAreaPanel.Controls.Add(PROG42);
                    PROG42.Show();
                    PROG42.BringToFront();
                    break;
                case "PROG36":
                    //var PROG36 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false };
                    //GlobalVariables.ProgCode = "PROG36";
                    //_WorkAreaPanel.Controls.Add(PROG36);
                    //PROG36.Show();
                    //PROG36.BringToFront();
                    break;
                case "PROG52":
                    var PROG52 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG52";
                    _WorkAreaPanel.Controls.Add(PROG52);
                    PROG52.Show();
                    PROG52.BringToFront();
                    break;
                case "PROG50":
                    var PROG50 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG50";
                    _WorkAreaPanel.Controls.Add(PROG50);
                    PROG50.Show();
                    PROG50.BringToFront();
                    break;
                case "PROG48":
                    var PROG48 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG48";
                    _WorkAreaPanel.Controls.Add(PROG48);
                    PROG48.Show();
                    PROG48.BringToFront();
                    break;
                case "PROG44":
                    //var PROG44 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false };
                    //GlobalVariables.ProgCode = "PROG44";
                    //_WorkAreaPanel.Controls.Add(PROG44);
                    //PROG44.Show();
                    //PROG44.BringToFront();
                    break;
                case "PROG38":
                    var PROG38 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG38";
                    _WorkAreaPanel.Controls.Add(PROG38);
                    PROG38.Show();
                    PROG38.BringToFront();
                    break;
                case "PROG40":
                    //var PROG40 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false };
                    //GlobalVariables.ProgCode = "PROG40";
                    //_WorkAreaPanel.Controls.Add(PROG40);
                    //PROG40.Show();
                    //PROG40.BringToFront();
                    break;
                case "PROG54":
                    var PROG54 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG54";
                    _WorkAreaPanel.Controls.Add(PROG54);
                    PROG54.Show();
                    PROG54.BringToFront();
                    break;
                case "PROG58":
                    var PROG58 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG58";
                    _WorkAreaPanel.Controls.Add(PROG58);
                    PROG58.Show();
                    PROG58.BringToFront();
                    break;
                case "PROG59":
                    var PROG59 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG59";
                    _WorkAreaPanel.Controls.Add(PROG59);
                    PROG59.Show();
                    PROG59.BringToFront();
                    break;
                case "PROG60":
                    var PROG60 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG60";
                    _WorkAreaPanel.Controls.Add(PROG60);
                    PROG60.Show();
                    PROG60.BringToFront();
                    break;
                case "PROG61":
                    //var PROG61 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false };
                    //GlobalVariables.ProgCode = "PROG61";
                    //_WorkAreaPanel.Controls.Add(PROG61);
                    //PROG61.Show();
                    //PROG61.BringToFront();
                    break;
                case "PROG63":
                    //var PROG63 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false };
                    //GlobalVariables.ProgCode = "PROG63";
                    //_WorkAreaPanel.Controls.Add(PROG63);
                    //PROG63.Show();
                    //PROG63.BringToFront();
                    break;
                case "PROG64":
                    //var PROG64 = new frmHariomReports() { Dock = DockStyle.Fill, TopLevel = false };
                    //GlobalVariables.ProgCode = "PROG64";
                    //_WorkAreaPanel.Controls.Add(PROG64);
                    //PROG64.Show();
                    //PROG64.BringToFront();
                    break;
                case "PROG55":
                    var PROG55 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG55";
                    _WorkAreaPanel.Controls.Add(PROG55);
                    PROG55.Show();
                    PROG55.BringToFront();

                    break;
                case "PROG87":
                    var PROG87 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG87";
                    _WorkAreaPanel.Controls.Add(PROG87);
                    PROG87.Show();
                    PROG87.BringToFront();

                    break;
                case "PROG89":
                    var PROG89 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG89";
                    _WorkAreaPanel.Controls.Add(PROG89);
                    PROG89.Show();
                    PROG89.BringToFront();

                    break;
                case "PROG91":
                    var PROG91 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG91";
                    _WorkAreaPanel.Controls.Add(PROG91);
                    PROG91.Show();
                    PROG91.BringToFront();

                    break;
                case "PROG56":
                    var PROG56 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG56";
                    _WorkAreaPanel.Controls.Add(PROG56);
                    PROG56.Show();
                    PROG56.BringToFront();

                    break;
                case "PROG65":
                    var PROG65 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG65";
                    _WorkAreaPanel.Controls.Add(PROG65);
                    PROG65.Show();
                    PROG65.BringToFront();
                    break;
                case "PROG37":
                    var PROG37 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG37";
                    _WorkAreaPanel.Controls.Add(PROG37);
                    PROG37.Show();
                    PROG37.BringToFront();
                    break;
                case "PROG66":
                    var PROG66 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG66";
                    _WorkAreaPanel.Controls.Add(PROG66);
                    PROG66.Show();
                    PROG66.BringToFront();
                    break;
                case "PROG67":
                    var PROG67 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG67";
                    _WorkAreaPanel.Controls.Add(PROG67);
                    PROG67.Show();
                    PROG67.BringToFront();
                    break;
                case "PROG68":
                    var PROG68 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG68";
                    _WorkAreaPanel.Controls.Add(PROG68);
                    PROG68.Show();
                    PROG68.BringToFront();
                    break;
                case "PROG71":
                    var PROG71 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG71";
                    _WorkAreaPanel.Controls.Add(PROG71);
                    PROG71.Show();
                    PROG71.BringToFront();
                    break;
                case "PROG72":
                    var PROG72 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG72";
                    _WorkAreaPanel.Controls.Add(PROG72);
                    PROG72.Show();
                    PROG72.BringToFront();
                    break;
                case "PROG69":
                    var PROG69 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG69";
                    _WorkAreaPanel.Controls.Add(PROG69);
                    PROG69.Show();
                    PROG69.BringToFront();
                    break;
                case "PROG70":
                    var PROG70 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG70";
                    _WorkAreaPanel.Controls.Add(PROG70);
                    PROG70.Show();
                    PROG70.BringToFront();
                    break;
                case "PROG73":
                    var PROG73 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG73";
                    _WorkAreaPanel.Controls.Add(PROG73);
                    PROG73.Show();
                    PROG73.BringToFront();
                    break;
                case "PROG74":
                    var PROG74 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG74";
                    _WorkAreaPanel.Controls.Add(PROG74);
                    PROG74.Show();
                    PROG74.BringToFront();
                    break;
                case "PROG75":
                    var PROG75 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG75";
                    _WorkAreaPanel.Controls.Add(PROG75);
                    PROG75.Show();
                    PROG75.BringToFront();
                    break;
                case "PROG76":
                    var PROG76 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG76";
                    _WorkAreaPanel.Controls.Add(PROG76);
                    PROG76.Show();
                    PROG76.BringToFront();
                    break;
                case "PROG77":
                    var PROG77 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG77";
                    _WorkAreaPanel.Controls.Add(PROG77);
                    PROG77.Show();
                    PROG77.BringToFront();
                    break;
                case "PROG78":
                    var PROG78 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG78";
                    _WorkAreaPanel.Controls.Add(PROG78);
                    PROG78.Show();
                    PROG78.BringToFront();
                    break;
                case "PROG79":
                    var PROG79 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG79";
                    _WorkAreaPanel.Controls.Add(PROG79);
                    PROG79.Show();
                    PROG79.BringToFront();
                    break;
                case "PROG57":
                    var PROG57 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG57";
                    _WorkAreaPanel.Controls.Add(PROG57);
                    PROG57.Show();
                    PROG57.BringToFront();
                    break;
                case "PROG46":
                    var PROG46 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG46";
                    _WorkAreaPanel.Controls.Add(PROG46);
                    PROG46.Show();
                    PROG46.BringToFront();
                    break;
                case "PROG80":
                    var PROG80 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG80";
                    _WorkAreaPanel.Controls.Add(PROG80);
                    PROG80.Show();
                    PROG80.BringToFront();
                    break;
                case "PROG102":
                    var PROG102 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG102";
                    _WorkAreaPanel.Controls.Add(PROG102);
                    PROG102.Show();
                    PROG102.BringToFront();
                    break;
                case "PROG104":
                    var PROG104 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG104";
                    _WorkAreaPanel.Controls.Add(PROG104);
                    PROG104.Show();
                    PROG104.BringToFront();
                    break;
                case "PROG105":
                    var PROG105 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG105";
                    _WorkAreaPanel.Controls.Add(PROG105);
                    PROG105.Show();
                    PROG105.BringToFront();
                    break;
                case "PROG103":
                    var PROG103 = new frmProcessSMCommission() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG103";
                    _WorkAreaPanel.Controls.Add(PROG103);
                    PROG103.Show();
                    PROG103.BringToFront();
                    break;
                case "PROG90":
                    var PROG90 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG90";
                    _WorkAreaPanel.Controls.Add(PROG90);
                    PROG90.Show();
                    PROG90.BringToFront();
                    break;
                case "PROG101":
                    var PROG101 = new frmTransaction() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG101";
                    _WorkAreaPanel.Controls.Add(PROG101);
                    PROG101.Show();
                    PROG101.BringToFront();
                    break;

                case "PROG106":
                    var PROG106 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG106";
                    _WorkAreaPanel.Controls.Add(PROG106);
                    PROG106.Show();
                    PROG106.BringToFront();
                    break;
                case "PROG107":
                    var PROG107 = new frmMaster() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG107";
                    _WorkAreaPanel.Controls.Add(PROG107);
                    PROG107.Show();
                    PROG107.BringToFront();
                    break;
                case "PROG108":
                    var PROG108 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG108";
                    _WorkAreaPanel.Controls.Add(PROG108);
                    PROG108.Show();
                    PROG108.BringToFront();
                    break;

                case "PROG109":
                    var PROG109 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG109";
                    _WorkAreaPanel.Controls.Add(PROG109);
                    PROG109.Show();
                    PROG109.BringToFront();
                    break;
                case "PROG110":
                    var PROG110 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG110";
                    _WorkAreaPanel.Controls.Add(PROG110);
                    PROG110.Show();
                    PROG110.BringToFront();
                    break;
                case "PROG111":
                    var PROG111 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG111";
                    _WorkAreaPanel.Controls.Add(PROG111);
                    PROG111.Show();
                    PROG111.BringToFront();
                    break;
                case "PROG112":
                    var PROG112 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG112";
                    _WorkAreaPanel.Controls.Add(PROG112);
                    PROG112.Show();
                    PROG112.BringToFront();
                    break;
                case "PROG113":
                    var PROG113 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
                    GlobalVariables.ProgCode = "PROG113";
                    _WorkAreaPanel.Controls.Add(PROG113);
                    PROG113.Show();
                    PROG113.BringToFront();
                    break;
                default:


                    break;
            }
        }

        void button_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProjectFunctions.EventTracker("Program Started");
            RunProg(e.Item.Name);
        }
        private void IntitializeTheme()
        {
            _WorkAreaPanel.Dock = DockStyle.Fill;
            _WorkAreaPanel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            _WorkAreaPanel.Appearance.Options.UseBackColor = true;
            _WorkAreaPanel.Appearance.Options.UseImage = true;
            _WorkAreaPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            _WorkAreaPanel.Location = new Point(0, 142);
            _WorkAreaPanel.LookAndFeel.UseDefaultLookAndFeel = false;
            _WorkAreaPanel.Name = "WorkArea";
            _WorkAreaPanel.Size = new Size(1100, 527);
            _WorkAreaPanel.TabIndex = 1;
            //_WorkAreaPanel.ControlAdded += WorkArea_ControlAdded;
            Controls.Add(_WorkAreaPanel);
        }
        private void LoadLayoutForms()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProgCode", typeof(String));
            dt.Columns.Add("LayoutName", typeof(String));
            String Address = String.Format(@"{0}\Layouts\{1}\", GlobalVariables.LayoutLocation, GlobalVariables.CurrentUser);
            String[] Dir = System.IO.Directory.GetDirectories(Address);
            foreach (String StrDir in Dir)
            {

                String[] DirFiles = System.IO.Directory.GetFiles(StrDir);
                foreach (String StrFiles in DirFiles)
                {
                    DataRow dr = dt.NewRow();
                    dr["ProgCode"] = StrDir.Replace(Address, string.Empty);
                    dr["LayoutName"] = StrFiles.Replace(StrDir, string.Empty).Replace(@"\", string.Empty);
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                HelpGrid.DataSource = dt;
                HelpGrid.Visible = true;
                HelpGridView.BestFitColumns();
                HelpGrid.BringToFront();
                HelpGrid.Focus();
            }



        }
        private void frmMainScreen_Load(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync();


            ProgramInMenu();


            width = _mainRibbon.Bounds.Width;
        }

        private void frmMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
            {
                LoadLayoutForms();
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow currentrow = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);

            FormReports.frmPivotGridReports PROG109 = new FormReports.frmPivotGridReports() { Dock = DockStyle.Fill, TopLevel = false };
            PROG109.LayoutName = currentrow["LayoutName"].ToString();
            GlobalVariables.ProgCode = currentrow["ProgCode"].ToString();
            _WorkAreaPanel.Controls.Add(PROG109);
            PROG109.Show();
            PROG109.BringToFront();
            HelpGrid.Visible = false;
        }
    }
}