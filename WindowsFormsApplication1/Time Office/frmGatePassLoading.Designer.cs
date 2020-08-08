
namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmGatePassLaoding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGatePassLaoding));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnAdd2 = new System.Windows.Forms.ToolStripButton();
            this.SFeedingGrid = new DevExpress.XtraGrid.GridControl();
            this.SFeedingGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gridView_AttendanceData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl_AttendanceData = new DevExpress.XtraGrid.GridControl();
            this.btnLoad_Data = new DevExpress.XtraEditors.SimpleButton();
            this.DtStartDate = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtEmpCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_AttendanceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_AttendanceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.btnSave,
            this.toolStripButton1,
            this.btnRefresh,
            this.btnLoad,
            this.btnAdd,
            this.btnAdd2});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 27);
            this.Menu_ToolStrip.TabIndex = 200;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnQuit.Size = new System.Drawing.Size(45, 24);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnSave.Size = new System.Drawing.Size(48, 24);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.toolStripButton1.Size = new System.Drawing.Size(65, 24);
            this.toolStripButton1.Text = "Validate";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnRefresh.Size = new System.Drawing.Size(65, 24);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnLoad.Size = new System.Drawing.Size(47, 24);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnAdd.Size = new System.Drawing.Size(59, 24);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.btnAdd2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnAdd2.Size = new System.Drawing.Size(66, 24);
            this.btnAdd2.Text = "Add2";
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // SFeedingGrid
            // 
            this.SFeedingGrid.Location = new System.Drawing.Point(349, 172);
            this.SFeedingGrid.MainView = this.SFeedingGridView;
            this.SFeedingGrid.Name = "SFeedingGrid";
            this.SFeedingGrid.Size = new System.Drawing.Size(428, 293);
            this.SFeedingGrid.TabIndex = 11;
            this.SFeedingGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SFeedingGridView,
            this.gridView3});
            this.SFeedingGrid.Visible = false;
            // 
            // SFeedingGridView
            // 
            this.SFeedingGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.SFeedingGridView.GridControl = this.SFeedingGrid;
            this.SFeedingGridView.Name = "SFeedingGridView";
            this.SFeedingGridView.OptionsBehavior.Editable = false;
            this.SFeedingGridView.OptionsView.ColumnAutoWidth = false;
            this.SFeedingGridView.OptionsView.ShowFooter = true;
            this.SFeedingGridView.OptionsView.ShowGroupPanel = false;
            this.SFeedingGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "MonthYear";
            this.gridColumn1.FieldName = "MonthYear";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "EmpCode";
            this.gridColumn2.FieldName = "EmpCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "EmpName";
            this.gridColumn3.FieldName = "EmpName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "EmpDW";
            this.gridColumn4.FieldName = "EmpDW";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "EmpPH";
            this.gridColumn5.FieldName = "EmpPH";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "EmpEL";
            this.gridColumn6.FieldName = "EmpEL";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "EmpCL";
            this.gridColumn7.FieldName = "EmpCL";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "EmpSL";
            this.gridColumn8.FieldName = "EmpSL";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "EmpPymtMode";
            this.gridColumn9.FieldName = "EmpPymtMode";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.SFeedingGrid;
            this.gridView3.Name = "gridView3";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // gridView_AttendanceData
            // 
            this.gridView_AttendanceData.GridControl = this.gridControl_AttendanceData;
            this.gridView_AttendanceData.Name = "gridView_AttendanceData";
            // 
            // gridControl_AttendanceData
            // 
            this.gridControl_AttendanceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_AttendanceData.Location = new System.Drawing.Point(0, 102);
            this.gridControl_AttendanceData.MainView = this.gridView_AttendanceData;
            this.gridControl_AttendanceData.Name = "gridControl_AttendanceData";
            this.gridControl_AttendanceData.Size = new System.Drawing.Size(804, 375);
            this.gridControl_AttendanceData.TabIndex = 352;
            this.gridControl_AttendanceData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_AttendanceData});
            this.gridControl_AttendanceData.DoubleClick += new System.EventHandler(this.gridControl_AttendanceData_DoubleClick);
            // 
            // btnLoad_Data
            // 
            this.btnLoad_Data.Location = new System.Drawing.Point(395, 52);
            this.btnLoad_Data.Name = "btnLoad_Data";
            this.btnLoad_Data.Size = new System.Drawing.Size(95, 20);
            this.btnLoad_Data.TabIndex = 3;
            this.btnLoad_Data.Text = "Load";
            this.btnLoad_Data.Click += new System.EventHandler(this.btnLoad_Data_Click);
            // 
            // DtStartDate
            // 
            this.DtStartDate.Location = new System.Drawing.Point(110, 52);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.EditFormat.FormatString = "MM-yyyy";
            this.DtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtStartDate.Properties.Mask.EditMask = "MM-yyyy";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.DtStartDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtStartDate.Properties.MaxLength = 6;
            this.DtStartDate.Size = new System.Drawing.Size(90, 20);
            this.DtStartDate.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 357;
            this.label13.Text = "Select Month/Year";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 27);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(804, 75);
            this.splitter1.TabIndex = 196;
            this.splitter1.TabStop = false;
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.EnterMoveNextControl = true;
            this.txtEmpCode.Location = new System.Drawing.Point(285, 52);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpCode.Properties.MaxLength = 6;
            this.txtEmpCode.Size = new System.Drawing.Size(90, 20);
            this.txtEmpCode.TabIndex = 2;
            this.txtEmpCode.EditValueChanged += new System.EventHandler(this.txtEmpCode_EditValueChanged);
            this.txtEmpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 359;
            this.label1.Text = "EmpCode";
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(285, 76);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(359, 160);
            this.HelpGrid.TabIndex = 360;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView});
            this.HelpGrid.Visible = false;
            this.HelpGrid.Click += new System.EventHandler(this.HelpGrid_Click);
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
            // frmGatePassLaoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 477);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.gridControl_AttendanceData);
            this.Controls.Add(this.btnLoad_Data);
            this.Controls.Add(this.DtStartDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.SFeedingGrid);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGatePassLaoding";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGatePassLaoding_Load);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_AttendanceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_AttendanceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private DevExpress.XtraGrid.GridControl SFeedingGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView SFeedingGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnAdd2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_AttendanceData;
        private DevExpress.XtraGrid.GridControl gridControl_AttendanceData;
        private DevExpress.XtraEditors.SimpleButton btnLoad_Data;
        private DevExpress.XtraEditors.TextEdit DtStartDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraEditors.TextEdit txtEmpCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
    }
}