namespace WindowsFormsApplication1.Transaction
{
    partial class frmBarPrinting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarPrinting));
            this.BarCodeGrid = new DevExpress.XtraGrid.GridControl();
            this.BarCodeGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSearchBox = new DevExpress.XtraEditors.TextEdit();
            this.ArticleImageBox = new DevExpress.XtraEditors.PictureEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtBarCode = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.RBBYFLTRT = new System.Windows.Forms.RadioButton();
            this.RBBYDSCPRCN = new System.Windows.Forms.RadioButton();
            this.btnReCalculate = new System.Windows.Forms.Button();
            this.txtOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.txtDeptCode = new DevExpress.XtraEditors.TextEdit();
            this.txtDeptDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtSysID = new DevExpress.XtraEditors.TextEdit();
            this.Label15 = new System.Windows.Forms.Label();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.CBBARTYPE = new System.Windows.Forms.ComboBox();
            this.RBPUR = new System.Windows.Forms.RadioButton();
            this.Label7 = new System.Windows.Forms.Label();
            this.ChkFixedBarCode = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.RBIMPORT = new System.Windows.Forms.RadioButton();
            this.RBBATCH = new System.Windows.Forms.RadioButton();
            this.RBDIRECT = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeGridView)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleImageBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSysID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BarCodeGrid
            // 
            this.BarCodeGrid.Location = new System.Drawing.Point(12, 215);
            this.BarCodeGrid.MainView = this.BarCodeGridView;
            this.BarCodeGrid.Name = "BarCodeGrid";
            this.BarCodeGrid.Size = new System.Drawing.Size(880, 340);
            this.BarCodeGrid.TabIndex = 682;
            this.BarCodeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BarCodeGridView});
            this.BarCodeGrid.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.BarCodeGrid_EditorKeyDown);
            this.BarCodeGrid.Click += new System.EventHandler(this.BarCodeGrid_Click);
            this.BarCodeGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarCodeGrid_KeyDown);
            this.BarCodeGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BarCodeGrid_KeyPress);
            // 
            // BarCodeGridView
            // 
            this.BarCodeGridView.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.BarCodeGridView.Appearance.TopNewRow.Options.UseBorderColor = true;
            this.BarCodeGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn22,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn23});
            this.BarCodeGridView.GridControl = this.BarCodeGrid;
            this.BarCodeGridView.Name = "BarCodeGridView";
            this.BarCodeGridView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.BarCodeGridView.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Slide;
            this.BarCodeGridView.OptionsNavigation.AutoFocusNewRow = true;
            this.BarCodeGridView.OptionsSelection.MultiSelect = true;
            this.BarCodeGridView.OptionsView.ColumnAutoWidth = false;
            this.BarCodeGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.BarCodeGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.BarCodeGridView.OptionsView.ShowFooter = true;
            this.BarCodeGridView.OptionsView.ShowGroupPanel = false;
            this.BarCodeGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.BarCodeGridView.OptionsView.ShowIndicator = false;
            this.BarCodeGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.BarCodeGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.BarCodeGridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.BarCodeGridView_PopupMenuShowing);
            this.BarCodeGridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.BarCodeGridView_InitNewRow);
            this.BarCodeGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.BarCodeGridView_FocusedRowChanged);
            this.BarCodeGridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.BarCodeGridView_FocusedColumnChanged);
            this.BarCodeGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.BarCodeGridView_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ITEM CODE";
            this.gridColumn1.FieldName = "SKUPRODUCTCODE";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SKUPRODUCTCODE", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 90;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ARTICLE NO";
            this.gridColumn2.FieldName = "SKUARTNO";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "DESCRIPTION";
            this.gridColumn3.FieldName = "ARTDESC";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 78;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "COLOUR";
            this.gridColumn4.FieldName = "SKUCOLN";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 67;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "SIZE";
            this.gridColumn5.FieldName = "SKUSIZN";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 67;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "QTY";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "SKUFEDQTY";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SKUFEDQTY", "{0:0.##}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 67;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "MRP";
            this.gridColumn7.FieldName = "SKUMRP";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 67;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "WSP";
            this.gridColumn8.FieldName = "SKUWSP";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 67;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "MRP VAL";
            this.gridColumn9.FieldName = "SKUMRPVAL";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SKUMRPVAL", "{0:0.##}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 67;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "WSP VAL";
            this.gridColumn10.FieldName = "SKUWSPVAL";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SKUWSPVAL", "{0:0.##}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 67;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "SKUARTID";
            this.gridColumn11.FieldName = "SKUARTID";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 13;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "SKUCOLID";
            this.gridColumn12.FieldName = "SKUCOLID";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 14;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "SKUSIZID";
            this.gridColumn13.FieldName = "SKUSIZID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 15;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "SKUARTCOLSET";
            this.gridColumn14.FieldName = "SKUARTCOLSET";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "SKUARTSIZSET";
            this.gridColumn15.FieldName = "SKUARTSIZSET";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "SKUSIZINDX";
            this.gridColumn16.FieldName = "SKUSIZINDX";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "SKUCODE";
            this.gridColumn17.FieldName = "SKUCODE";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "SKUVOUCHNO";
            this.gridColumn18.FieldName = "SKUVOUCHNO";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "SKUFNYR";
            this.gridColumn19.FieldName = "SKUFNYR";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "DISC%";
            this.gridColumn22.FieldName = "DISCPRCN";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 10;
            this.gridColumn22.Width = 67;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "FLAT RATE";
            this.gridColumn20.FieldName = "FLATMRP";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 11;
            this.gridColumn20.Width = 67;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "PUR_PRICE";
            this.gridColumn21.FieldName = "SKUPPRICE";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 12;
            this.gridColumn21.Width = 88;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "GrpHSNCode";
            this.gridColumn23.FieldName = "GrpHSNCode";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 16;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.btnSave});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(904, 26);
            this.Menu_ToolStrip.TabIndex = 685;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnQuit.Size = new System.Drawing.Size(45, 23);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // HelpGrid
            // 
            this.HelpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpGrid.Location = new System.Drawing.Point(2, 22);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(626, 287);
            this.HelpGrid.TabIndex = 245;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView});
            this.HelpGrid.DoubleClick += new System.EventHandler(this.HelpGrid_DoubleClick);
            this.HelpGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HelpGrid_KeyDown);
            // 
            // HelpGridView
            // 
            this.HelpGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.HelpGridView.GridControl = this.HelpGrid;
            this.HelpGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.HelpGridView.Name = "HelpGridView";
            this.HelpGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.HelpGridView.OptionsBehavior.Editable = false;
            this.HelpGridView.OptionsView.ShowGroupPanel = false;
            this.HelpGridView.OptionsView.ShowIndicator = false;
            this.HelpGridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.HelpGrid);
            this.panelControl1.Controls.Add(this.txtSearchBox);
            this.panelControl1.Location = new System.Drawing.Point(142, 215);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(630, 311);
            this.panelControl1.TabIndex = 686;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchBox.EnterMoveNextControl = true;
            this.txtSearchBox.Location = new System.Drawing.Point(2, 2);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchBox.Properties.MaxLength = 400;
            this.txtSearchBox.Size = new System.Drawing.Size(626, 20);
            this.txtSearchBox.TabIndex = 246;
            this.txtSearchBox.EditValueChanged += new System.EventHandler(this.TxtSearchBox_EditValueChanged);
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchBox_KeyDown);
            // 
            // ArticleImageBox
            // 
            this.ArticleImageBox.Location = new System.Drawing.Point(754, 29);
            this.ArticleImageBox.Name = "ArticleImageBox";
            this.ArticleImageBox.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ArticleImageBox.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.ArticleImageBox.Size = new System.Drawing.Size(145, 180);
            this.ArticleImageBox.TabIndex = 708;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl1.CaptionImageOptions.SvgImage")));
            this.groupControl1.Controls.Add(this.btnPrint);
            this.groupControl1.Controls.Add(this.txtBarCode);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.RBBYFLTRT);
            this.groupControl1.Controls.Add(this.RBBYDSCPRCN);
            this.groupControl1.Controls.Add(this.btnReCalculate);
            this.groupControl1.Controls.Add(this.txtOrderNo);
            this.groupControl1.Controls.Add(this.txtDeptCode);
            this.groupControl1.Controls.Add(this.txtDeptDesc);
            this.groupControl1.Controls.Add(this.txtSysID);
            this.groupControl1.Controls.Add(this.Label15);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.CBBARTYPE);
            this.groupControl1.Controls.Add(this.RBPUR);
            this.groupControl1.Controls.Add(this.Label7);
            this.groupControl1.Controls.Add(this.ChkFixedBarCode);
            this.groupControl1.Controls.Add(this.Label1);
            this.groupControl1.Controls.Add(this.RBIMPORT);
            this.groupControl1.Controls.Add(this.RBBATCH);
            this.groupControl1.Controls.Add(this.RBDIRECT);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(12, 29);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(736, 180);
            this.groupControl1.TabIndex = 709;
            this.groupControl1.Text = "Generate Mode";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(329, 158);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 23);
            this.btnPrint.TabIndex = 705;
            this.btnPrint.Text = "Print Duplicate";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.EnterMoveNextControl = true;
            this.txtBarCode.Location = new System.Drawing.Point(93, 155);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarCode.Properties.MaxLength = 40;
            this.txtBarCode.Size = new System.Drawing.Size(217, 20);
            this.txtBarCode.TabIndex = 704;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 703;
            this.label2.Text = "BarCode";
            // 
            // RBBYFLTRT
            // 
            this.RBBYFLTRT.AutoSize = true;
            this.RBBYFLTRT.Location = new System.Drawing.Point(642, 79);
            this.RBBYFLTRT.Name = "RBBYFLTRT";
            this.RBBYFLTRT.Size = new System.Drawing.Size(90, 17);
            this.RBBYFLTRT.TabIndex = 702;
            this.RBBYFLTRT.TabStop = true;
            this.RBBYFLTRT.Text = "BY FLAT RATE";
            this.RBBYFLTRT.UseVisualStyleBackColor = true;
            this.RBBYFLTRT.Visible = false;
            // 
            // RBBYDSCPRCN
            // 
            this.RBBYDSCPRCN.AutoSize = true;
            this.RBBYDSCPRCN.Location = new System.Drawing.Point(642, 57);
            this.RBBYDSCPRCN.Name = "RBBYDSCPRCN";
            this.RBBYDSCPRCN.Size = new System.Drawing.Size(72, 17);
            this.RBBYDSCPRCN.TabIndex = 701;
            this.RBBYDSCPRCN.TabStop = true;
            this.RBBYDSCPRCN.Text = "BY DISC%";
            this.RBBYDSCPRCN.UseVisualStyleBackColor = true;
            this.RBBYDSCPRCN.Visible = false;
            // 
            // btnReCalculate
            // 
            this.btnReCalculate.Location = new System.Drawing.Point(641, 102);
            this.btnReCalculate.Name = "btnReCalculate";
            this.btnReCalculate.Size = new System.Drawing.Size(90, 40);
            this.btnReCalculate.TabIndex = 700;
            this.btnReCalculate.Text = "RE-CALCULATE";
            this.btnReCalculate.UseVisualStyleBackColor = true;
            this.btnReCalculate.Visible = false;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.EnterMoveNextControl = true;
            this.txtOrderNo.Location = new System.Drawing.Point(93, 125);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderNo.Properties.MaxLength = 4;
            this.txtOrderNo.Size = new System.Drawing.Size(217, 20);
            this.txtOrderNo.TabIndex = 697;
            // 
            // txtDeptCode
            // 
            this.txtDeptCode.EnterMoveNextControl = true;
            this.txtDeptCode.Location = new System.Drawing.Point(93, 99);
            this.txtDeptCode.Name = "txtDeptCode";
            this.txtDeptCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDeptCode.Properties.MaxLength = 4;
            this.txtDeptCode.Size = new System.Drawing.Size(79, 20);
            this.txtDeptCode.TabIndex = 694;
            // 
            // txtDeptDesc
            // 
            this.txtDeptDesc.EnterMoveNextControl = true;
            this.txtDeptDesc.Location = new System.Drawing.Point(185, 99);
            this.txtDeptDesc.Name = "txtDeptDesc";
            this.txtDeptDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDeptDesc.Properties.ReadOnly = true;
            this.txtDeptDesc.Size = new System.Drawing.Size(324, 20);
            this.txtDeptDesc.TabIndex = 695;
            this.txtDeptDesc.TabStop = false;
            // 
            // txtSysID
            // 
            this.txtSysID.Enabled = false;
            this.txtSysID.Location = new System.Drawing.Point(104, 38);
            this.txtSysID.Name = "txtSysID";
            this.txtSysID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSysID.Size = new System.Drawing.Size(83, 20);
            this.txtSysID.TabIndex = 699;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(45, 39);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(53, 18);
            this.Label15.TabIndex = 698;
            this.Label15.Text = "SYS ID :";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(52, 103);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(37, 13);
            this.labelControl6.TabIndex = 696;
            this.labelControl6.Text = "Dept(P)";
            // 
            // CBBARTYPE
            // 
            this.CBBARTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBARTYPE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBBARTYPE.FormattingEnabled = true;
            this.CBBARTYPE.Items.AddRange(new object[] {
            "CATE V",
            "CATE P",
            "CATE K"});
            this.CBBARTYPE.Location = new System.Drawing.Point(405, 125);
            this.CBBARTYPE.Name = "CBBARTYPE";
            this.CBBARTYPE.Size = new System.Drawing.Size(104, 21);
            this.CBBARTYPE.TabIndex = 693;
            this.CBBARTYPE.Visible = false;
            // 
            // RBPUR
            // 
            this.RBPUR.AutoSize = true;
            this.RBPUR.Enabled = false;
            this.RBPUR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RBPUR.Location = new System.Drawing.Point(249, 77);
            this.RBPUR.Name = "RBPUR";
            this.RBPUR.Size = new System.Drawing.Size(111, 18);
            this.RBPUR.TabIndex = 691;
            this.RBPUR.TabStop = true;
            this.RBPUR.Text = "THRU PURCHASE";
            this.RBPUR.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label7.Location = new System.Drawing.Point(316, 128);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(83, 14);
            this.Label7.TabIndex = 692;
            this.Label7.Text = "BARCODE TYPE";
            this.Label7.Visible = false;
            // 
            // ChkFixedBarCode
            // 
            this.ChkFixedBarCode.AutoSize = true;
            this.ChkFixedBarCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ChkFixedBarCode.Location = new System.Drawing.Point(606, 29);
            this.ChkFixedBarCode.Name = "ChkFixedBarCode";
            this.ChkFixedBarCode.Size = new System.Drawing.Size(108, 18);
            this.ChkFixedBarCode.TabIndex = 690;
            this.ChkFixedBarCode.Text = "FIXED BARCODE";
            this.ChkFixedBarCode.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(25, 129);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 689;
            this.Label1.Text = "ORDER NO";
            // 
            // RBIMPORT
            // 
            this.RBIMPORT.AutoSize = true;
            this.RBIMPORT.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RBIMPORT.Location = new System.Drawing.Point(178, 77);
            this.RBIMPORT.Name = "RBIMPORT";
            this.RBIMPORT.Size = new System.Drawing.Size(65, 18);
            this.RBIMPORT.TabIndex = 686;
            this.RBIMPORT.TabStop = true;
            this.RBIMPORT.Text = "IMPORT";
            this.RBIMPORT.UseVisualStyleBackColor = true;
            // 
            // RBBATCH
            // 
            this.RBBATCH.AutoSize = true;
            this.RBBATCH.Enabled = false;
            this.RBBATCH.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RBBATCH.Location = new System.Drawing.Point(104, 77);
            this.RBBATCH.Name = "RBBATCH";
            this.RBBATCH.Size = new System.Drawing.Size(58, 18);
            this.RBBATCH.TabIndex = 687;
            this.RBBATCH.TabStop = true;
            this.RBBATCH.Text = "BATCH";
            this.RBBATCH.UseVisualStyleBackColor = true;
            // 
            // RBDIRECT
            // 
            this.RBDIRECT.AutoSize = true;
            this.RBDIRECT.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RBDIRECT.Location = new System.Drawing.Point(30, 77);
            this.RBDIRECT.Name = "RBDIRECT";
            this.RBDIRECT.Size = new System.Drawing.Size(61, 18);
            this.RBDIRECT.TabIndex = 688;
            this.RBDIRECT.TabStop = true;
            this.RBDIRECT.Text = "DIRECT";
            this.RBDIRECT.UseVisualStyleBackColor = true;
            // 
            // frmBarPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 564);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ArticleImageBox);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.BarCodeGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmBarPrinting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FrmBarPrinting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBarPrinting_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeGridView)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleImageBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSysID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl BarCodeGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView BarCodeGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtSearchBox;
        private DevExpress.XtraEditors.PictureEdit ArticleImageBox;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        internal System.Windows.Forms.RadioButton RBBYFLTRT;
        internal System.Windows.Forms.RadioButton RBBYDSCPRCN;
        internal System.Windows.Forms.Button btnReCalculate;
        private DevExpress.XtraEditors.TextEdit txtOrderNo;
        private DevExpress.XtraEditors.TextEdit txtDeptCode;
        private DevExpress.XtraEditors.TextEdit txtDeptDesc;
        private DevExpress.XtraEditors.TextEdit txtSysID;
        internal System.Windows.Forms.Label Label15;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        internal System.Windows.Forms.ComboBox CBBARTYPE;
        internal System.Windows.Forms.RadioButton RBPUR;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.CheckBox ChkFixedBarCode;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.RadioButton RBIMPORT;
        internal System.Windows.Forms.RadioButton RBBATCH;
        internal System.Windows.Forms.RadioButton RBDIRECT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraEditors.TextEdit txtBarCode;
        internal System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}