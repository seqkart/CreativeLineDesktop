namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmExcelStructureLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcelStructureLoading));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.SFeedingGrid = new DevExpress.XtraGrid.GridControl();
            this.SFeedingGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UnitCodesss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
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
            this.btnLoad});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 26);
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
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnSave.Size = new System.Drawing.Size(48, 23);
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
            this.toolStripButton1.Size = new System.Drawing.Size(66, 23);
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
            this.btnRefresh.Size = new System.Drawing.Size(65, 23);
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
            this.btnLoad.Size = new System.Drawing.Size(47, 23);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // SFeedingGrid
            // 
            this.SFeedingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFeedingGrid.Location = new System.Drawing.Point(0, 26);
            this.SFeedingGrid.MainView = this.SFeedingGridView;
            this.SFeedingGrid.Name = "SFeedingGrid";
            this.SFeedingGrid.Size = new System.Drawing.Size(804, 451);
            this.SFeedingGrid.TabIndex = 11;
            this.SFeedingGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SFeedingGridView,
            this.gridView3});
            // 
            // SFeedingGridView
            // 
            this.SFeedingGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn23,
            this.UnitCodesss,
            this.gridColumn24,
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
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22});
            this.SFeedingGridView.GridControl = this.SFeedingGrid;
            this.SFeedingGridView.Name = "SFeedingGridView";
            this.SFeedingGridView.OptionsBehavior.Editable = false;
            this.SFeedingGridView.OptionsView.ColumnAutoWidth = false;
            this.SFeedingGridView.OptionsView.ShowFooter = true;
            this.SFeedingGridView.OptionsView.ShowGroupPanel = false;
            this.SFeedingGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "EmpPartyCode";
            this.gridColumn25.FieldName = "EmpPartyCode";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 0;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "AccName";
            this.gridColumn23.FieldName = "AccName";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            // 
            // UnitCodesss
            // 
            this.UnitCodesss.Caption = "UnitCode";
            this.UnitCodesss.FieldName = "UnitCode";
            this.UnitCodesss.Name = "UnitCodesss";
            this.UnitCodesss.Visible = true;
            this.UnitCodesss.VisibleIndex = 2;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "UnitName";
            this.gridColumn24.FieldName = "UnitName";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "EmpCode";
            this.gridColumn1.FieldName = "EmpCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "EmpName";
            this.gridColumn2.FieldName = "EmpName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmpName", "{0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "EmpFHRelationTag";
            this.gridColumn3.FieldName = "EmpFHRelationTag";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "EmpFHName";
            this.gridColumn4.FieldName = "EmpFHName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "EmpDeptCode";
            this.gridColumn5.FieldName = "EmpDeptCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DeptDesc";
            this.gridColumn6.FieldName = "DeptDesc";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "EmpDesgCode";
            this.gridColumn7.FieldName = "EmpDesgCode";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "DesgDesc";
            this.gridColumn8.FieldName = "DesgDesc";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 11;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "EmpDOJ";
            this.gridColumn9.FieldName = "EmpDOJ";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "EmpPFno";
            this.gridColumn10.FieldName = "EmpPFno";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 13;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "EmpUANNo";
            this.gridColumn11.FieldName = "EmpUANNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 14;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "EmpBasic";
            this.gridColumn12.FieldName = "EmpBasic";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 15;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "EmpHRA";
            this.gridColumn13.FieldName = "EmpHRA";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 16;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "EmpConv";
            this.gridColumn14.FieldName = "EmpConv";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 17;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "EmpPET";
            this.gridColumn15.FieldName = "EmpPET";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 18;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "EmpSplAlw";
            this.gridColumn16.FieldName = "EmpSplAlw";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 19;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "EmpTDS";
            this.gridColumn17.FieldName = "EmpTDS";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 20;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "EmpMscD1";
            this.gridColumn18.FieldName = "EmpMscD1";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 21;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "EmpPanNo";
            this.gridColumn19.FieldName = "EmpPanNo";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 22;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "EmpAdharCardNo";
            this.gridColumn20.FieldName = "EmpAdharCardNo";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 23;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "EmpBankIFSCode";
            this.gridColumn21.FieldName = "EmpBankIFSCode";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 24;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "EmpBankAcNo";
            this.gridColumn22.FieldName = "EmpBankAcNo";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 25;
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
            // frmExcelStructureLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 477);
            this.ControlBox = false;
            this.Controls.Add(this.SFeedingGrid);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmExcelStructureLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExcelDataLoading_Load);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFeedingGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn UnitCodesss;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
    }
}