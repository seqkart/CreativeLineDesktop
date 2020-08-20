using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SeqKartLibrary;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Administration
{
    public partial class XtraForm_UserMaster : DevExpress.XtraEditors.XtraForm
    {

        public XtraForm_UserMaster()
        {
            InitializeComponent();


            //gridView_UserMaster.OptionsBehavior.Editable = false;
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
            GridEvents();
        }

        void edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //MessageBox.Show("The button from the " + gridView_UserMaster.FocusedRowHandle + " row has been clicked!");
            btnEdit_Click(null, e);
        }


        private void FillTable(DataSet dsMaster)
        {
            gridView_UserMaster.Columns.Clear();
            BindingList<UserInfo> list = new BindingList<UserInfo>();
            foreach (DataRow dr in dsMaster.Tables[0].Rows)
            {
                UserInfo userInfo = new UserInfo
                {
                    UserName = dr[SQL_COLUMNS.USER_MASTER._UserName] + string.Empty,
                    Login_As = dr[SQL_COLUMNS.USER_MASTER._LoginAs] + string.Empty,
                    UserActive = dr[SQL_COLUMNS.USER_MASTER._UserActive] + string.Empty
                };


                list.Add(userInfo);
            }
            gridControl_UserMaster.DataSource = list;
        }

        private void AddUnboundColumn()
        {
            GridColumn unbColumn = gridView_UserMaster.Columns.AddField("Action");
            unbColumn.VisibleIndex = gridView_UserMaster.Columns.Count;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
        }

        private void GridEvents()
        {
            //In Non-Editable Mode
            gridView_UserMaster.ShowingEditor += gridView_UserMaster_ShowingEditor;
            //gridView_UserMaster.DoubleClick += gridView_DoubleClick;

            gridControl_UserMaster.DoubleClick += gridControl_UserMaster_DoubleClick;
        }

        private void AddButtonToGrid()
        {


            //In Editable Mode
            //gridView_UserMaster.ShownEditor += gridView_ShownEditor;

            RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit
            {
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            };
            edit.ButtonClick += edit_ButtonClick;
            edit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

            EditorButton button = edit.Buttons[0];

            button.ImageOptions.Image = WindowsFormsApplication1.Properties.Resources.Edit_16x16;
            button.ImageOptions.Location = ImageLocation.MiddleCenter;
            button.Caption = "Edit";
            button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            button.Appearance.BackColor = Color.Red;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.BorderColor = Color.Transparent;
            //edit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            button.Appearance.Options.UseBackColor = true;
            button.Appearance.BackColor = Color.Transparent;

            GridColumn actionColumn = gridView_UserMaster.Columns["Action"];
            actionColumn.ColumnEdit = edit;
            actionColumn.OptionsColumn.AllowEdit = true;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }
        }

        //https://supportcenter.devexpress.com/ticket/details/a2934/how-to-handle-a-double-click-on-a-grid-row-or-cell
        void gridView_UserMaster_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView_UserMaster.FocusedColumn == gridView_UserMaster.Columns["Action"])
            {
                PrintLogWin.PrintLog("********************* A ");
                return;
            }
            if (gridView_UserMaster.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                PrintLogWin.PrintLog("********************* B ");
                e.Cancel = false;
            }
            else
            {
                PrintLogWin.PrintLog("********************* C ");
                e.Cancel = true;
            }
        }

        BaseEdit editor;
        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            editor = view.ActiveEditor;
            editor.DoubleClick += editor_DoubleClick;
        }

        void gridView_HiddenEditor(object sender, EventArgs e)
        {
            editor.DoubleClick -= editor_DoubleClick;
            editor = null;
        }

        void editor_DoubleClick(object sender, EventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            GridControl grid = editor.Parent as GridControl;
            GridView view = grid.FocusedView as GridView;
            Point pt = grid.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }
        }

        private void FillDataToGrid()
        {
            PrintLogWin.PrintLog("FillGrid ******************** " + GlobalVariables.ProgCode);
            try
            {
                DataSet ds = ProjectFunctions.GetDataSet("Select ProgProcName,ProgDesc from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'");
                string ProcedureName = ds.Tables[0].Rows[0]["ProgProcName"].ToString();

                PrintLogWin.PrintLog("FillGrid => ProcedureName ******************** " + ProcedureName);

                //ProjectFunctions.BindMasterFormToGrid(ProcedureName, gridControl_UserMaster, gridView_UserMaster);

                DataSet dsMaster = ProjectFunctionsUtils.GetDataSet(ProcedureName);
                FillTable(dsMaster);
                AddUnboundColumn();
                AddButtonToGrid();

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
string.Empty);
            Bitmap bmp = new Bitmap(myStream)
            {
                Tag = "edit_link" +
string.Empty
            };

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

            FillDataToGrid();
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

            FillDataToGrid();
        }

        private void gridControl_UserMaster_Load(object sender, EventArgs e)
        {

            //ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            //ProjectFunctions.GirdViewVisualize(gridView_UserMaster);
            FillDataToGrid();
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
string.Empty);

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