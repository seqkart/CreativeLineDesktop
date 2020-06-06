namespace WindowsFormsApplication1.Transaction
{
    partial class frmProductionData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionData));
            this.label51 = new System.Windows.Forms.Label();
            this.txtInvoiceType = new DevExpress.XtraEditors.TextEdit();
            this.dtInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.InfoGrid = new DevExpress.XtraGrid.GridControl();
            this.InfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtPlant = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtShift = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrdAsgnCode = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductName = new DevExpress.XtraEditors.TextEdit();
            this.txtPrdCode = new DevExpress.XtraEditors.TextEdit();
            this.BtnUndo = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtBags = new DevExpress.XtraEditors.TextEdit();
            this.txtProduction = new DevExpress.XtraEditors.TextEdit();
            this.txtWastage = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPlantRunHours = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdAsgnCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdCode.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBags.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProduction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWastage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantRunHours.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(220, 53);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(52, 13);
            this.label51.TabIndex = 318;
            this.label51.Text = "Doc Type";
            this.label51.UseWaitCursor = true;
            // 
            // txtInvoiceType
            // 
            this.txtInvoiceType.Enabled = false;
            this.txtInvoiceType.EnterMoveNextControl = true;
            this.txtInvoiceType.Location = new System.Drawing.Point(279, 49);
            this.txtInvoiceType.Name = "txtInvoiceType";
            this.txtInvoiceType.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceType.Size = new System.Drawing.Size(101, 20);
            this.txtInvoiceType.TabIndex = 317;
            this.txtInvoiceType.TabStop = false;
            this.txtInvoiceType.UseWaitCursor = true;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.EditValue = null;
            this.dtInvoiceDate.Location = new System.Drawing.Point(113, 49);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtInvoiceDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dtInvoiceDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInvoiceDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dtInvoiceDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInvoiceDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dtInvoiceDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtInvoiceDate.Size = new System.Drawing.Size(79, 20);
            this.dtInvoiceDate.TabIndex = 314;
            this.dtInvoiceDate.TabStop = false;
            this.dtInvoiceDate.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 316;
            this.label2.Text = "Date";
            this.label2.UseWaitCursor = true;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(649, 48);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(125, 20);
            this.txtSerialNo.TabIndex = 315;
            this.txtSerialNo.TabStop = false;
            this.txtSerialNo.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 313;
            this.label1.Text = "CCI No";
            this.label1.UseWaitCursor = true;
            // 
            // HelpGrid
            // 
            this.HelpGrid.EmbeddedNavigator.UseWaitCursor = true;
            this.HelpGrid.Location = new System.Drawing.Point(223, 35);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(564, 362);
            this.HelpGrid.TabIndex = 408;
            this.HelpGrid.TabStop = false;
            this.HelpGrid.UseWaitCursor = true;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView,
            this.gridView1});
            this.HelpGrid.Visible = false;
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
            // gridView1
            // 
            this.gridView1.GridControl = this.HelpGrid;
            this.gridView1.Name = "gridView1";
            // 
            // InfoGrid
            // 
            this.InfoGrid.EmbeddedNavigator.UseWaitCursor = true;
            this.InfoGrid.Location = new System.Drawing.Point(12, 189);
            this.InfoGrid.MainView = this.InfoGridView;
            this.InfoGrid.Name = "InfoGrid";
            this.InfoGrid.Size = new System.Drawing.Size(766, 203);
            this.InfoGrid.TabIndex = 409;
            this.InfoGrid.TabStop = false;
            this.InfoGrid.UseWaitCursor = true;
            this.InfoGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InfoGridView,
            this.gridView4});
            this.InfoGrid.Click += new System.EventHandler(this.InfoGrid_Click);
            this.InfoGrid.DoubleClick += new System.EventHandler(this.InfoGrid_DoubleClick);
            // 
            // InfoGridView
            // 
            this.InfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.InfoGridView.CustomizationFormBounds = new System.Drawing.Rectangle(580, 341, 216, 178);
            this.InfoGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.InfoGridView.GridControl = this.InfoGrid;
            this.InfoGridView.Name = "InfoGridView";
            this.InfoGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.InfoGridView.OptionsBehavior.Editable = false;
            this.InfoGridView.OptionsPrint.PrintFooter = false;
            this.InfoGridView.OptionsPrint.PrintGroupFooter = false;
            this.InfoGridView.OptionsView.ShowFooter = true;
            this.InfoGridView.OptionsView.ShowGroupPanel = false;
            this.InfoGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "PrdAsgnCode";
            this.gridColumn6.FieldName = "PrdAsgnCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PrdAsgnCode", "{0}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PrdCode";
            this.gridColumn1.FieldName = "PrdCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "PrdName";
            this.gridColumn2.FieldName = "PrdName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bags";
            this.gridColumn3.FieldName = "Bags";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bags", "SUM={0:0.##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Production";
            this.gridColumn4.FieldName = "Production";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Production", "SUM={0:0.##}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Wastage";
            this.gridColumn5.FieldName = "Wastage";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Wastage", "SUM={0:0.##}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.InfoGrid;
            this.gridView4.Name = "gridView4";
            // 
            // txtPlant
            // 
            this.txtPlant.EnterMoveNextControl = true;
            this.txtPlant.Location = new System.Drawing.Point(113, 75);
            this.txtPlant.Name = "txtPlant";
            this.txtPlant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPlant.Properties.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G"});
            this.txtPlant.Size = new System.Drawing.Size(79, 20);
            this.txtPlant.TabIndex = 400;
            // 
            // txtShift
            // 
            this.txtShift.EnterMoveNextControl = true;
            this.txtShift.Location = new System.Drawing.Point(279, 76);
            this.txtShift.Name = "txtShift";
            this.txtShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtShift.Properties.Items.AddRange(new object[] {
            "D",
            "N"});
            this.txtShift.Size = new System.Drawing.Size(101, 20);
            this.txtShift.TabIndex = 401;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 412;
            this.label3.Text = "Plant";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 413;
            this.label4.Text = "Shift";
            this.label4.UseWaitCursor = true;
            // 
            // txtPrdAsgnCode
            // 
            this.txtPrdAsgnCode.EnterMoveNextControl = true;
            this.txtPrdAsgnCode.Location = new System.Drawing.Point(113, 103);
            this.txtPrdAsgnCode.Name = "txtPrdAsgnCode";
            this.txtPrdAsgnCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdAsgnCode.Properties.MaxLength = 8;
            this.txtPrdAsgnCode.Size = new System.Drawing.Size(79, 20);
            this.txtPrdAsgnCode.TabIndex = 403;
            this.txtPrdAsgnCode.EditValueChanged += new System.EventHandler(this.txtPrdAsgnCode_EditValueChanged);
            this.txtPrdAsgnCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrdAsgnCode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 415;
            this.label7.Text = "Product Code";
            // 
            // txtProductName
            // 
            this.txtProductName.EnterMoveNextControl = true;
            this.txtProductName.Location = new System.Drawing.Point(223, 104);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductName.Properties.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(420, 20);
            this.txtProductName.TabIndex = 416;
            this.txtProductName.TabStop = false;
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Location = new System.Drawing.Point(649, 104);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdCode.Properties.MaxLength = 4;
            this.txtPrdCode.Properties.ReadOnly = true;
            this.txtPrdCode.Size = new System.Drawing.Size(129, 20);
            this.txtPrdCode.TabIndex = 417;
            this.txtPrdCode.TabStop = false;
            // 
            // BtnUndo
            // 
            this.BtnUndo.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnUndo.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.BtnUndo.Appearance.ForeColor = System.Drawing.Color.White;
            this.BtnUndo.Appearance.Options.UseBackColor = true;
            this.BtnUndo.Appearance.Options.UseFont = true;
            this.BtnUndo.Appearance.Options.UseForeColor = true;
            this.BtnUndo.Location = new System.Drawing.Point(647, 130);
            this.BtnUndo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.BtnUndo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(63, 23);
            this.BtnUndo.TabIndex = 420;
            this.BtnUndo.Text = "&Undo";
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Appearance.Options.UseBackColor = true;
            this.BtnDelete.Appearance.Options.UseFont = true;
            this.BtnDelete.Appearance.Options.UseForeColor = true;
            this.BtnDelete.Location = new System.Drawing.Point(713, 131);
            this.BtnDelete.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.BtnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(71, 21);
            this.BtnDelete.TabIndex = 419;
            this.BtnDelete.Text = "De&lete";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnOK.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.BtnOK.Appearance.ForeColor = System.Drawing.Color.White;
            this.BtnOK.Appearance.Options.UseBackColor = true;
            this.BtnOK.Appearance.Options.UseFont = true;
            this.BtnOK.Appearance.Options.UseForeColor = true;
            this.BtnOK.Location = new System.Drawing.Point(585, 131);
            this.BtnOK.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.BtnOK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(58, 22);
            this.BtnOK.TabIndex = 408;
            this.BtnOK.Text = "&Ok";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(787, 26);
            this.Menu_ToolStrip.TabIndex = 421;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnQuit.Size = new System.Drawing.Size(45, 23);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 23);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBags
            // 
            this.txtBags.EnterMoveNextControl = true;
            this.txtBags.Location = new System.Drawing.Point(113, 132);
            this.txtBags.Name = "txtBags";
            this.txtBags.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBags.Properties.MaxLength = 8;
            this.txtBags.Size = new System.Drawing.Size(79, 20);
            this.txtBags.TabIndex = 404;
            this.txtBags.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduction_KeyPress);
            // 
            // txtProduction
            // 
            this.txtProduction.EnterMoveNextControl = true;
            this.txtProduction.Location = new System.Drawing.Point(279, 132);
            this.txtProduction.Name = "txtProduction";
            this.txtProduction.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProduction.Properties.MaxLength = 8;
            this.txtProduction.Size = new System.Drawing.Size(101, 20);
            this.txtProduction.TabIndex = 405;
            this.txtProduction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduction_KeyPress);
            // 
            // txtWastage
            // 
            this.txtWastage.EnterMoveNextControl = true;
            this.txtWastage.Location = new System.Drawing.Point(476, 134);
            this.txtWastage.Name = "txtWastage";
            this.txtWastage.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWastage.Properties.MaxLength = 8;
            this.txtWastage.Size = new System.Drawing.Size(79, 20);
            this.txtWastage.TabIndex = 407;
            this.txtWastage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduction_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 425;
            this.label5.Text = "Bags";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 426;
            this.label6.Text = "Production";
            this.label6.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 427;
            this.label8.Text = "Wastage";
            this.label8.UseWaitCursor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(554, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 429;
            this.label9.Text = "Plant Run Hours";
            // 
            // txtPlantRunHours
            // 
            this.txtPlantRunHours.EnterMoveNextControl = true;
            this.txtPlantRunHours.Location = new System.Drawing.Point(649, 74);
            this.txtPlantRunHours.Name = "txtPlantRunHours";
            this.txtPlantRunHours.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlantRunHours.Properties.MaxLength = 8;
            this.txtPlantRunHours.Size = new System.Drawing.Size(125, 20);
            this.txtPlantRunHours.TabIndex = 402;
            this.txtPlantRunHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduction_KeyPress);
            // 
            // frmProductionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 409);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPlantRunHours);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWastage);
            this.Controls.Add(this.txtProduction);
            this.Controls.Add(this.txtBags);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.BtnUndo);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.txtPrdCode);
            this.Controls.Add(this.txtPrdAsgnCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShift);
            this.Controls.Add(this.txtPlant);
            this.Controls.Add(this.InfoGrid);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.txtInvoiceType);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProductionData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmProductionData_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductionData_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdAsgnCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdCode.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBags.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProduction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWastage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlantRunHours.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label51;
        private DevExpress.XtraEditors.TextEdit txtInvoiceType;
        private DevExpress.XtraEditors.DateEdit dtInvoiceDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl InfoGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView InfoGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.ComboBoxEdit txtPlant;
        private DevExpress.XtraEditors.ComboBoxEdit txtShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.TextEdit txtPrdAsgnCode;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtProductName;
        private DevExpress.XtraEditors.TextEdit txtPrdCode;
        private DevExpress.XtraEditors.SimpleButton BtnUndo;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private DevExpress.XtraEditors.SimpleButton BtnOK;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtBags;
        private DevExpress.XtraEditors.TextEdit txtProduction;
        private DevExpress.XtraEditors.TextEdit txtWastage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtPlantRunHours;
    }
}