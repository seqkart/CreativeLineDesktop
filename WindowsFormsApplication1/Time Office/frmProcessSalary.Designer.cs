namespace WindowsFormsApplication1.Forms_Transaction
{
    partial class frmProcessSalary
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessSalary));
            this.btnLock = new DevExpress.XtraEditors.SimpleButton();
            this.ChoiceSelect = new DevExpress.XtraEditors.CheckEdit();
            this.DtStartDate = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.SalaryGrid = new DevExpress.XtraGrid.GridControl();
            this.SalaryGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gridControl_SalaryProcess = new DevExpress.XtraGrid.GridControl();
            this.gridView_SalaryProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnProcessSalary = new DevExpress.XtraEditors.SimpleButton();
            this.salaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrintPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.salaryInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExportXsls = new DevExpress.XtraEditors.SimpleButton();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryGridView)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SalaryProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SalaryProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLock
            // 
            this.btnLock.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLock.ImageOptions.SvgImage")));
            this.btnLock.Location = new System.Drawing.Point(606, 0);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(95, 25);
            this.btnLock.TabIndex = 351;
            this.btnLock.Text = "Lock";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // ChoiceSelect
            // 
            this.ChoiceSelect.Location = new System.Drawing.Point(709, 69);
            this.ChoiceSelect.Name = "ChoiceSelect";
            this.ChoiceSelect.Properties.Caption = "Select &All";
            this.ChoiceSelect.Size = new System.Drawing.Size(75, 20);
            this.ChoiceSelect.TabIndex = 349;
            this.ChoiceSelect.Visible = false;
            this.ChoiceSelect.CheckedChanged += new System.EventHandler(this.ChoiceSelect_CheckedChanged);
            // 
            // DtStartDate
            // 
            this.DtStartDate.Location = new System.Drawing.Point(103, 36);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtStartDate.Properties.Appearance.Options.UseFont = true;
            this.DtStartDate.Properties.EditFormat.FormatString = "MM-yyyy";
            this.DtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtStartDate.Properties.Mask.EditMask = "MMMM-yyyy";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.DtStartDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtStartDate.Properties.MaxLength = 15;
            this.DtStartDate.Size = new System.Drawing.Size(102, 24);
            this.DtStartDate.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(4, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 347;
            this.label13.Text = "Select Month/Year";
            // 
            // btnLoad
            // 
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.ImageOptions.Image")));
            this.btnLoad.Location = new System.Drawing.Point(208, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(116, 32);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // SalaryGrid
            // 
            this.SalaryGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalaryGrid.Location = new System.Drawing.Point(467, 393);
            this.SalaryGrid.LookAndFeel.SkinName = "Seven Classic";
            this.SalaryGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.SalaryGrid.MainView = this.SalaryGridView;
            this.SalaryGrid.Name = "SalaryGrid";
            this.SalaryGrid.Size = new System.Drawing.Size(325, 199);
            this.SalaryGrid.TabIndex = 2;
            this.SalaryGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SalaryGridView});
            // 
            // SalaryGridView
            // 
            this.SalaryGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn10});
            this.SalaryGridView.GridControl = this.SalaryGrid;
            this.SalaryGridView.Name = "SalaryGridView";
            this.SalaryGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.SalaryGridView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.SalaryGridView.OptionsBehavior.Editable = false;
            this.SalaryGridView.OptionsDetail.EnableDetailToolTip = true;
            this.SalaryGridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.SalaryGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.SalaryGridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.SalaryGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.SalaryGridView.OptionsView.ShowDetailButtons = false;
            this.SalaryGridView.OptionsView.ShowFooter = true;
            this.SalaryGridView.OptionsView.ShowGroupPanel = false;
            this.SalaryGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "UnitName";
            this.gridColumn11.FieldName = "UnitName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "UnitName", "{0}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "DeptDesc";
            this.gridColumn1.FieldName = "DeptDesc";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DeptDesc", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 160;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "EmpCode";
            this.gridColumn2.FieldName = "EmpCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 97;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "EmpName";
            this.gridColumn3.FieldName = "EmpName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 158;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "\'F/H\'";
            this.gridColumn4.FieldName = "F/H";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 53;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "\'F/H Name\'";
            this.gridColumn5.FieldName = "F/H Name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 147;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "NetPaid";
            this.gridColumn9.FieldName = "EmpNetPaid";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpNetPaid", "{0:0.##}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 84;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IsLock";
            this.gridColumn6.FieldName = "IsLock";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 85;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sel";
            this.gridColumn7.FieldName = "Sel";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 45;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Locked";
            this.gridColumn8.FieldName = "Locked";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 112;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Pymt Mode";
            this.gridColumn10.FieldName = "EmpPymtMode";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 144;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 25);
            this.Menu_ToolStrip.TabIndex = 194;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Enabled = false;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnAdd.Size = new System.Drawing.Size(63, 23);
            this.btnAdd.Text = "&Process";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.White;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(804, 75);
            this.splitter1.TabIndex = 196;
            this.splitter1.TabStop = false;
            // 
            // gridControl_SalaryProcess
            // 
            this.gridControl_SalaryProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_SalaryProcess.Location = new System.Drawing.Point(0, 100);
            this.gridControl_SalaryProcess.MainView = this.gridView_SalaryProcess;
            this.gridControl_SalaryProcess.Name = "gridControl_SalaryProcess";
            this.gridControl_SalaryProcess.Size = new System.Drawing.Size(804, 504);
            this.gridControl_SalaryProcess.TabIndex = 352;
            this.gridControl_SalaryProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_SalaryProcess});
            this.gridControl_SalaryProcess.DoubleClick += new System.EventHandler(this.gridControl_SalaryProcess_DoubleClick);
            // 
            // gridView_SalaryProcess
            // 
            this.gridView_SalaryProcess.GridControl = this.gridControl_SalaryProcess;
            this.gridView_SalaryProcess.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView_SalaryProcess.Name = "gridView_SalaryProcess";
            this.gridView_SalaryProcess.OptionsEditForm.BindingMode = DevExpress.XtraGrid.Views.Grid.EditFormBindingMode.Direct;
            this.gridView_SalaryProcess.OptionsView.ShowFooter = true;
            this.gridView_SalaryProcess.OptionsView.ShowGroupPanel = false;
            this.gridView_SalaryProcess.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_SalaryProcess_CustomDrawCell);
            this.gridView_SalaryProcess.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView_SalaryProcess_CustomDrawFooterCell);
            this.gridView_SalaryProcess.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_SalaryProcess_RowCellStyle);
            this.gridView_SalaryProcess.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_SalaryProcess_RowStyle);
            this.gridView_SalaryProcess.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gridView_SalaryProcess_CustomSummaryCalculate);
            this.gridView_SalaryProcess.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView_SalaryProcess_ShowingEditor);
            this.gridView_SalaryProcess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_SalaryProcess_KeyDown);
            this.gridView_SalaryProcess.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView_SalaryProcess_ValidatingEditor);
            // 
            // btnProcessSalary
            // 
            this.btnProcessSalary.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessSalary.Appearance.Options.UseFont = true;
            this.btnProcessSalary.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessSalary.ImageOptions.Image")));
            this.btnProcessSalary.Location = new System.Drawing.Point(324, 32);
            this.btnProcessSalary.Name = "btnProcessSalary";
            this.btnProcessSalary.Size = new System.Drawing.Size(117, 32);
            this.btnProcessSalary.TabIndex = 353;
            this.btnProcessSalary.Text = "Process Salary";
            this.btnProcessSalary.Click += new System.EventHandler(this.btnProcessSalary_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreview.Appearance.Options.UseFont = true;
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            this.btnPrintPreview.Location = new System.Drawing.Point(441, 32);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(116, 32);
            this.btnPrintPreview.TabIndex = 354;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Appearance.Options.UseFont = true;
            this.btnPrintReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.ImageOptions.Image")));
            this.btnPrintReport.Location = new System.Drawing.Point(557, 32);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(116, 32);
            this.btnPrintReport.TabIndex = 355;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnExportXsls
            // 
            this.btnExportXsls.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportXsls.Appearance.Options.UseFont = true;
            this.btnExportXsls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportXsls.ImageOptions.Image")));
            this.btnExportXsls.Location = new System.Drawing.Point(673, 32);
            this.btnExportXsls.Name = "btnExportXsls";
            this.btnExportXsls.Size = new System.Drawing.Size(116, 32);
            this.btnExportXsls.TabIndex = 356;
            this.btnExportXsls.Text = "Export To XLS";
            this.btnExportXsls.Click += new System.EventHandler(this.btnExportXsls_Click);
            // 
            // frmProcessSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 604);
            this.ControlBox = false;
            this.Controls.Add(this.btnExportXsls);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.btnProcessSalary);
            this.Controls.Add(this.gridControl_SalaryProcess);
            this.Controls.Add(this.SalaryGrid);
            this.Controls.Add(this.ChoiceSelect);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.DtStartDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmProcessSalary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProcessSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryGridView)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SalaryProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SalaryProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl SalaryGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView SalaryGridView;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit DtStartDate;
        private DevExpress.XtraEditors.CheckEdit ChoiceSelect;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnLock;
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
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraGrid.GridControl gridControl_SalaryProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_SalaryProcess;
        private DevExpress.XtraEditors.SimpleButton btnProcessSalary;
        private System.Windows.Forms.BindingSource salaryBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnPrintPreview;
        private DevExpress.XtraEditors.SimpleButton btnPrintReport;
        private System.Windows.Forms.BindingSource salaryInfoBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnExportXsls;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}