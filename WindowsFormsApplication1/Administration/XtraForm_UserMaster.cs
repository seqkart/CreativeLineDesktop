using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using DataBindings;
using DevExpress.XtraGrid.Views.Base;
using SeqKartLibrary;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using System.IO;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Administration
{
    public partial class XtraForm_UserMaster : DevExpress.XtraEditors.XtraForm
    {
        
        public XtraForm_UserMaster()
        {
            InitializeComponent();
        }

        private void XtraForm_UserMaster_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();

                

            }
            catch
            {

            }
        }

        private void SetMyControls()
        {
            ProjectFunctions.GirdViewVisualize(gridView_UserMaster);
            
            


        }

        private void AddRepository()
        {
            RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit();
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            edit.ButtonClick += edit_ButtonClick;
            edit.Buttons[0].Caption = "Edit";
            edit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            edit.Buttons[0].Appearance.BackColor = Color.Red;
            edit.Buttons[0].Appearance.Options.UseBackColor = true;
            edit.Buttons[0].Appearance.BorderColor = Color.Transparent;


            gridView_UserMaster.Columns["Action"].ColumnEdit = edit;
        }

        void edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //MessageBox.Show("The button from the " + gridView_UserMaster.FocusedRowHandle + " row has been clicked!");
            btnEdit_Click(null, e);

        }

        private void AddUnboundColumn()
        {
            GridColumn unbColumn = gridView_UserMaster.Columns.AddField("Action");
            unbColumn.VisibleIndex = gridView_UserMaster.Columns.Count;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
        }

        private void FillTable(DataSet dsMaster)
        {
            gridView_UserMaster.Columns.Clear();
            BindingList<UserInfo> list = new BindingList<UserInfo>();
            foreach (DataRow dr in dsMaster.Tables[0].Rows)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.UserName = dr[SQL_COLUMNS.USER_MASTER._UserName] + "";
                userInfo.Login_As = dr[SQL_COLUMNS.USER_MASTER._LoginAs] + "";
                userInfo.UserActive = dr[SQL_COLUMNS.USER_MASTER._UserActive] + "";

                
                list.Add(userInfo);
            }
            gridControl_UserMaster.DataSource = list;
        }

        private void FillGrid()
        {
            PrintLogWin.PrintLog("FillGrid ******************** " + GlobalVariables.ProgCode);

            try
            {
                DataSet ds = ProjectFunctions.GetDataSet("Select ProgProcName,ProgDesc from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'");
                string ProcedureName = ds.Tables[0].Rows[0]["ProgProcName"].ToString();


                PrintLogWin.PrintLog("FillGrid => ProcedureName ******************** " + ProcedureName
                    );


                //ProjectFunctions.BindMasterFormToGrid(ProcedureName, gridControl_UserMaster, gridView_UserMaster);

                DataSet dsMaster = ProjectFunctions.GetDataSet(ProcedureName);
                FillTable(dsMaster);
                AddUnboundColumn();                
                AddRepository();

                
                //userMasterBindingSource.DataSource = Binding_DataHelper.GetData(dsMaster);

                //RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
                //pictureEdit.SizeMode = PictureSizeMode.Zoom;
                //pictureEdit.NullText = " ";
                //pictureEdit.Padding = new Padding(1);

                //pictureEdit.Click += gridControl_UserMaster_Click
                //    ;







                //gridControl_UserMaster.DataSource = CreateData(dsMaster);
                //gridView_UserMaster.Columns["Edit_Link"].ColumnEdit = pictureEdit                    ;
                //gridView_UserMaster.Columns["Edit_Link"].Visible = false;
                //GridColumn col = gridView_UserMaster.Columns.AddVisible("Edit", "Edit_Link");
                //col.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                //col.ColumnEdit = pictureEdit;// repositoryItemPictureEdit1;


                //gridView_UserMaster.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;


                toolStrip_lbl.Text = ds.Tables[0].Rows[0]["ProgDesc"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox_Debug.ShowBox("frmMaster => FillGrid() => " + ex);
            }


        }

        void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Edit")
            {
                //string gender = gridView_UserMaster.GetListSourceRowCellValue(e.ListSourceRowIndex, gridView_UserMaster.Columns["Edit"]).ToString();
                
                e.Value = SystemIcons.Information.ToBitmap();
            }
        }

        private DataTable CreateData(DataSet dsMaster)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(SQL_COLUMNS.USER_MASTER._UserName, typeof(string
                ));
            dt.Columns.Add(SQL_COLUMNS.USER_MASTER._LoginAs, typeof(string));
            dt.Columns.Add(SQL_COLUMNS.USER_MASTER._UserActive, typeof(char));
            //dt.Columns.Add("Edit_Link" + "", typeof(Image));

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("WindowsFormsApplication1.Resources.edit_icon.png" +
                "");
            Bitmap bmp = new Bitmap(myStream);
            bmp.Tag = "edit_link" +
                "";

            foreach (DataRow dr in dsMaster.Tables[0].Rows)
            {



                //pictureEdit.Click += gridControl_UserMaster_DoubleClick;

                dt.Rows.Add(dr[SQL_COLUMNS.USER_MASTER._UserName], dr[SQL_COLUMNS.USER_MASTER._LoginAs], dr[SQL_COLUMNS.USER_MASTER._UserActive]);
                
            }            

            return dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                if (ComparisonUtils.IsEqualTo_String(GlobalVariables.ProgCode, WIN_APP_TABS._frmUserDetails))
                {
                    frmUserDetails frm = new frmUserDetails() { s1 = btnAdd.Text, Text = "User Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    

                    frm.ShowDialog(Parent);
                }
            }

            FillGrid();
        }        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                if (ComparisonUtils.IsEqualTo_String(GlobalVariables.ProgCode, WIN_APP_TABS._frmUserDetails))
                {
                    //DataRow CurrentRow = gridView_UserMaster.GetDataRow(gridView_UserMaster.FocusedRowHandle);
                    //gridControl_UserMaster.Ge

                    //ColumnView detailView = (ColumnView)gridControl_UserMaster.FocusedView;
                    //
                    //int foundIndex = detailView.GetDataSourceRowIndex(detailView.FocusedRowHandle);

                    //DataRow CurrentRow = detailView.GetDataRow(detailView.FocusedRowHandle);

                    int row = (gridControl_UserMaster.FocusedView as ColumnView).FocusedRowHandle;

                    ColumnView detailView = (ColumnView)gridControl_UserMaster.FocusedView;
                    string cellValue_UserName = detailView.GetRowCellValue(row, "UserName").ToString();
                    PrintLogWin.PrintLog(cellValue_UserName
                        );


                    //int foundIndex = userMasterBindingSource.Find("clients_id", cellValue);
                    //userMasterBindingSource.Position = foundIndex;

                    frmUserDetails frm = new frmUserDetails() { s1 = btnEdit.Text, Text = "User Editing", UserName = cellValue_UserName };
                    frm.StartPosition = FormStartPosition.CenterScreen;

                    frm.ShowDialog(Parent);
                }
            }

            FillGrid();
        }

        private void gridControl_UserMaster_Load(object sender, EventArgs e)
        {

            //ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.GirdViewVisualize(gridView_UserMaster);
            FillGrid();
        }

        private void gridControl_UserMaster_Click(object sender, EventArgs e)
        {
            int row = (gridControl_UserMaster.FocusedView as ColumnView).FocusedRowHandle;

            ColumnView detailView = (ColumnView)gridControl_UserMaster.FocusedView;
            Bitmap cellValue_Edit_Link = (Bitmap)detailView.GetFocusedRowCellValue("Edit_Link");//.GetRowCellValue(row, "Edit_Link").ToString();
            PrintLogWin.PrintLog("%%%%%%%%%%%%%%%%" + cellValue_Edit_Link.Tag);
            PrintLogWin.PrintLog("%%%%%%%%%%%%%%%%" + row
                );

            if (ComparisonUtils.IsEqualTo_String(cellValue_Edit_Link.Tag, "edit_link"))
            {
                btnEdit_Click(null, e);

            }

            //if (sender..Column.FieldName == "Edit_Link")
            //{
            //    //string gender = gridView_UserMaster.GetListSourceRowCellValue(e.ListSourceRowIndex, gridView_UserMaster.Columns["Edit"]).ToString();

            //    e.Value = SystemIcons.Information.ToBitmap();
            //}
            //btnEdit_Click(null, e);

        }

        private void button_delete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            btnEdit_Click(null, e);

            PrintLogWin.PrintLog("================= button_delete_ButtonClick" +
                "");

        }

        private void gridControl_UserMaster_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, e);
        }

        private void gridControl_UserMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEdit_Click(null, e);
            }
        }

        private void gridView_UserMaster_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                var formatRulesMenu = new DXPopupMenu();
                var view = sender as GridView;

                DXMenuItem Copy;
#pragma warning disable CS0168 // The variable 'Print' is declared but never used
                DXMenuItem Print;
#pragma warning restore CS0168 // The variable 'Print' is declared but never used
                DXMenuItem SAR;
#pragma warning disable CS0168 // The variable 'ExportSource' is declared but never used
                DXMenuItem ExportSource;
#pragma warning restore CS0168 // The variable 'ExportSource' is declared but never used
                DXMenuItem Collapse;
                DXMenuItem Expand;
                DXMenuItem FixLeft;
                DXMenuItem FixRight;
                DXMenuItem UnFix;
                DXMenuItem PartyAccount;

                DataRow CurrentRow = gridView_UserMaster.GetDataRow(gridView_UserMaster.FocusedRowHandle);
                PartyAccount = new DXMenuItem("View Party Account", (o1, e1) =>
                {
                    DataSet ds = ProjectFunctions.GetDataSet("[sp_ZoomPartyAct] '2019-01-01','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + CurrentRow["AccCode"].ToString() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FormReports.frmPartyAccounts frm = new FormReports.frmPartyAccounts() { Text = "Zoom Party Account - [" + CurrentRow["AccName"].ToString() + " - " + CurrentRow["AccCode"].ToString() + " ]", dsGetData = ds };
                        var P = ProjectFunctions.GetPositionInForm(this);
                        frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                        frm.ShowDialog(Parent);
                    }
                });
                Copy = new DXMenuItem("Copy", (o1, e1) =>
                {
                    view.OptionsSelection.MultiSelect = true;
                    view.CopyToClipboard();
                });
                SAR = new DXMenuItem("Select All Records", (o1, e1) =>
                {
                    view.OptionsSelection.MultiSelect = true;
                    view.SelectAll();
                });
                Expand = new DXMenuItem("Expand All", (o1, e1) =>
                {
                    gridView_UserMaster.ExpandAllGroups();
                });
                Collapse = new DXMenuItem("Collapse All", (o1, e1) =>
                {
                    gridView_UserMaster.CollapseAllGroups();
                });
                FixLeft = new DXMenuItem("Fix Column Left", (o1, e1) =>
                {
                    gridView_UserMaster.OptionsView.ColumnAutoWidth = false;
                    var hitInfo = gridView_UserMaster.CalcHitInfo(gridControl_UserMaster.PointToClient(Control.MousePosition));
                    if (hitInfo.InRowCell)
                    {
                        int rowHandle = hitInfo.RowHandle;
                        DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                        column = hitInfo.Column;
                        column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    }
                });
                FixRight = new DXMenuItem("Fix Column Right", (o1, e1) =>
                {
                    gridView_UserMaster.OptionsView.ColumnAutoWidth = false;
                    var hitInfo = gridView_UserMaster.CalcHitInfo(gridControl_UserMaster.PointToClient(Control.MousePosition));
                    if (hitInfo.InRowCell)
                    {
                        int rowHandle = hitInfo.RowHandle;
                        DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                        column = hitInfo.Column;
                        column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
                    }
                });
                UnFix = new DXMenuItem("Unfix Column", (o1, e1) =>
                {
                    gridView_UserMaster.OptionsView.ColumnAutoWidth = false;
                    var hitInfo = gridView_UserMaster.CalcHitInfo(gridControl_UserMaster.PointToClient(Control.MousePosition));
                    if (hitInfo.InRowCell)
                    {
                        int rowHandle = hitInfo.RowHandle;
                        DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                        column = hitInfo.Column;
                        column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                    }
                });
                e.Menu.Items.Add(Copy);
                e.Menu.Items.Add(SAR);
                e.Menu.Items.Add(Collapse);
                e.Menu.Items.Add(Expand);
                e.Menu.Items.Add(FixLeft);
                e.Menu.Items.Add(FixRight);
                e.Menu.Items.Add(UnFix);
                if (GlobalVariables.ProgCode == "PROG8")
                {
                    e.Menu.Items.Add(PartyAccount);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }

        }

      

    }
}