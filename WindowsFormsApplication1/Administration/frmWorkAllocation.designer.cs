namespace WindowsFormsApplication1
{
    partial class frmWorkAllocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkAllocation));
            this.cmbSelectUser = new System.Windows.Forms.ComboBox();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSaveOpts = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.OptionsGrid = new DevExpress.XtraGrid.GridControl();
            this.OptionsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.WorkAllocationGrid = new DevExpress.XtraGrid.GridControl();
            this.UserGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkAllocationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSelectUser
            // 
            this.cmbSelectUser.FormattingEnabled = true;
            this.cmbSelectUser.Location = new System.Drawing.Point(124, 31);
            this.cmbSelectUser.Name = "cmbSelectUser";
            this.cmbSelectUser.Size = new System.Drawing.Size(121, 21);
            this.cmbSelectUser.TabIndex = 313;
            this.cmbSelectUser.SelectedIndexChanged += new System.EventHandler(this.cmbSelectUser_SelectedIndexChanged);
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(933, 25);
            this.Menu_ToolStrip.TabIndex = 314;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(35, 22);
            this.btnQuit.Text = "&Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 315;
            this.label1.Text = "Select User";
            // 
            // panelControl1
            // 
            this.panelControl1.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.panelControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Gray;
            this.panelControl1.AppearanceCaption.Options.UseFont = true;
            this.panelControl1.AppearanceCaption.Options.UseForeColor = true;
            this.panelControl1.Controls.Add(this.btnSaveOpts);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.btnCancle);
            this.panelControl1.Controls.Add(this.cmbSelectUser);
            this.panelControl1.Controls.Add(this.OptionsGrid);
            this.panelControl1.Controls.Add(this.WorkAllocationGrid);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(15);
            this.panelControl1.Size = new System.Drawing.Size(933, 595);
            this.panelControl1.TabIndex = 317;
            this.panelControl1.Text = "Work Allocation";
            // 
            // btnSaveOpts
            // 
            this.btnSaveOpts.Location = new System.Drawing.Point(727, 29);
            this.btnSaveOpts.Name = "btnSaveOpts";
            this.btnSaveOpts.Size = new System.Drawing.Size(75, 23);
            this.btnSaveOpts.TabIndex = 319;
            this.btnSaveOpts.Text = "Save";
            this.btnSaveOpts.Click += new System.EventHandler(this.btnSaveOpts_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(808, 29);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 318;
            this.btnCancle.Text = "Cancel";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // OptionsGrid
            // 
            this.OptionsGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsGrid.Location = new System.Drawing.Point(14, 72);
            this.OptionsGrid.MainView = this.OptionsGridView;
            this.OptionsGrid.Name = "OptionsGrid";
            this.OptionsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.OptionsGrid.Size = new System.Drawing.Size(866, 389);
            this.OptionsGrid.TabIndex = 318;
            this.OptionsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.OptionsGridView});
            this.OptionsGrid.Click += new System.EventHandler(this.OptionsGrid_Click);
            this.OptionsGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsGrid_KeyDown);
            // 
            // OptionsGridView
            // 
            this.OptionsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn18,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn29,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34});
            this.OptionsGridView.GridControl = this.OptionsGrid;
            this.OptionsGridView.Name = "OptionsGridView";
            this.OptionsGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.OptionsGridView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.OptionsGridView.OptionsDetail.EnableDetailToolTip = true;
            this.OptionsGridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.OptionsGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.OptionsGridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.OptionsGridView.OptionsView.ShowDetailButtons = false;
            this.OptionsGridView.OptionsView.ShowFooter = true;
            this.OptionsGridView.OptionsView.ShowGroupPanel = false;
            this.OptionsGridView.OptionsView.ShowIndicator = false;
            this.OptionsGridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.OptionsGridView_RowCellStyle);
            this.OptionsGridView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.OptionsGridView_ValidatingEditor);
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "ProgCode";
            this.gridColumn18.FieldName = "ProgCode";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProgCode", "Count={0}")});
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 0;
            this.gridColumn18.Width = 92;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Username";
            this.gridColumn35.FieldName = "UserName";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 1;
            this.gridColumn35.Width = 76;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "ACCESS";
            this.gridColumn36.FieldName = "SELECTFIELD";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 2;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "&Add";
            this.gridColumn37.FieldName = "&Add";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 4;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "EDIT";
            this.gridColumn22.FieldName = "EDIT";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 3;
            this.gridColumn22.Width = 36;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "DEL";
            this.gridColumn23.FieldName = "DELETE";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 5;
            this.gridColumn23.Width = 35;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "SPL_Rts.";
            this.gridColumn29.FieldName = "SPLRIGHTS";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 6;
            this.gridColumn29.Width = 58;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "M";
            this.gridColumn31.FieldName = "MASTER";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 7;
            this.gridColumn31.Width = 29;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "T";
            this.gridColumn32.FieldName = "TRANSACTION";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 8;
            this.gridColumn32.Width = 26;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "R";
            this.gridColumn33.FieldName = "REPORT";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 9;
            this.gridColumn33.Width = 23;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "A";
            this.gridColumn34.FieldName = "ADMIN";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 10;
            this.gridColumn34.Width = 20;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // WorkAllocationGrid
            // 
            this.WorkAllocationGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkAllocationGrid.Location = new System.Drawing.Point(14, 72);
            this.WorkAllocationGrid.MainView = this.UserGridView;
            this.WorkAllocationGrid.Name = "WorkAllocationGrid";
            this.WorkAllocationGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.WorkAllocationGrid.Size = new System.Drawing.Size(866, 418);
            this.WorkAllocationGrid.TabIndex = 317;
            this.WorkAllocationGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UserGridView});
            this.WorkAllocationGrid.DoubleClick += new System.EventHandler(this.WorkAllocationGrid_DoubleClick);
            // 
            // UserGridView
            // 
            this.UserGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn17,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.UserGridView.GridControl = this.WorkAllocationGrid;
            this.UserGridView.Name = "UserGridView";
            this.UserGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.UserGridView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.UserGridView.OptionsDetail.EnableDetailToolTip = true;
            this.UserGridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.UserGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.UserGridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.UserGridView.OptionsView.ShowDetailButtons = false;
            this.UserGridView.OptionsView.ShowFooter = true;
            this.UserGridView.OptionsView.ShowGroupPanel = false;
            this.UserGridView.OptionsView.ShowIndicator = false;
            this.UserGridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.UserGridView_RowCellStyle);
            this.UserGridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.UserGridView_CellValueChanging);
            this.UserGridView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.UserGridView_ValidatingEditor);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ProgCode";
            this.gridColumn1.FieldName = "ProgCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ProgCode", "Count={0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 74;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ProgDesc";
            this.gridColumn2.FieldName = "ProgDesc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 103;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ACCESS";
            this.gridColumn3.FieldName = "SELECTFIELD";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 51;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "&Add";
            this.gridColumn4.FieldName = "&Add";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 33;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "EDIT";
            this.gridColumn5.FieldName = "EDIT";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 37;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DEL";
            this.gridColumn6.FieldName = "DELETE";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 30;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "SPLR";
            this.gridColumn17.FieldName = "SPLRIGHTS";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
            this.gridColumn17.Width = 35;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "M";
            this.gridColumn8.FieldName = "MASTER";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 20;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "T";
            this.gridColumn9.FieldName = "TRANSACTION";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 20;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "R";
            this.gridColumn10.FieldName = "REPORT";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 20;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "A";
            this.gridColumn11.FieldName = "ADMIN";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 20;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmWorkAllocation
            // 
            this.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 620);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmWorkAllocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWorkAllocation_Load);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkAllocationGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelectUser;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl panelControl1;
        private DevExpress.XtraGrid.GridControl WorkAllocationGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView UserGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.GridControl OptionsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView OptionsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnSaveOpts;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
    }
}