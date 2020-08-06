namespace BNPL.Forms_Master
{
    partial class frm_EmpsalMst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EmpsalMst));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.TextAuthenticate = new System.Windows.Forms.ToolStripTextBox();
            this.btnSelectALL = new System.Windows.Forms.CheckBox();
            this.btnLoadAdvance = new DevExpress.XtraEditors.SimpleButton();
            this.DocumentMGRGrid = new DevExpress.XtraGrid.GridControl();
            this.DocMGRGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Btn_RefreshGridData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.DtStartDate = new DevExpress.XtraEditors.TextEdit();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentMGRGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocMGRGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.btnPrint,
            this.btnDelete,
            this.btnEdit,
            this.btnAdd,
            this.TextAuthenticate});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 25);
            this.Menu_ToolStrip.TabIndex = 322;
            this.Menu_ToolStrip.Text = "toolStrip1";
            // 
            // btnQuit
            // 
            this.btnQuit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(35, 22);
            this.btnQuit.Text = "&Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(38, 22);
            this.btnPrint.Text = "&Print";
            // 
            // btnDelete
            // 
            this.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 22);
            this.btnDelete.Text = "&Delete";
            // 
            // btnEdit
            // 
            this.btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(32, 22);
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 22);
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // TextAuthenticate
            // 
            this.TextAuthenticate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextAuthenticate.Name = "TextAuthenticate";
            this.TextAuthenticate.Size = new System.Drawing.Size(100, 25);
            // 
            // btnSelectALL
            // 
            this.btnSelectALL.AutoSize = true;
            this.btnSelectALL.Location = new System.Drawing.Point(398, 65);
            this.btnSelectALL.Name = "btnSelectALL";
            this.btnSelectALL.Size = new System.Drawing.Size(15, 14);
            this.btnSelectALL.TabIndex = 318;
            this.btnSelectALL.UseVisualStyleBackColor = true;
            this.btnSelectALL.CheckedChanged += new System.EventHandler(this.btnSelectALL_CheckedChanged);
            // 
            // btnLoadAdvance
            // 
            this.btnLoadAdvance.Location = new System.Drawing.Point(249, 62);
            this.btnLoadAdvance.Name = "btnLoadAdvance";
            this.btnLoadAdvance.Size = new System.Drawing.Size(143, 20);
            this.btnLoadAdvance.TabIndex = 317;
            this.btnLoadAdvance.Text = "Loan / Advance /Coup";
            this.btnLoadAdvance.Click += new System.EventHandler(this.btnLoadAdvance_Click);
            // 
            // DocumentMGRGrid
            // 
            this.DocumentMGRGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentMGRGrid.Location = new System.Drawing.Point(0, 108);
            this.DocumentMGRGrid.MainView = this.DocMGRGrid;
            this.DocumentMGRGrid.Name = "DocumentMGRGrid";
            this.DocumentMGRGrid.Size = new System.Drawing.Size(804, 496);
            this.DocumentMGRGrid.TabIndex = 316;
            this.DocumentMGRGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DocMGRGrid});
            this.DocumentMGRGrid.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            this.DocumentMGRGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DocumentMGRGrid_KeyDown);
            // 
            // DocMGRGrid
            // 
            this.DocMGRGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn20,
            this.gridColumn3,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn18});
            this.DocMGRGrid.GridControl = this.DocumentMGRGrid;
            this.DocMGRGrid.Name = "DocMGRGrid";
            this.DocMGRGrid.OptionsView.ShowFooter = true;
            this.DocMGRGrid.OptionsView.ShowGroupPanel = false;
            this.DocMGRGrid.OptionsView.ShowIndicator = false;
            this.DocMGRGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "UnitName";
            this.gridColumn6.FieldName = "UnitName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "PH";
            this.gridColumn5.FieldName = "EmpPH";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpPH", "{0}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "W/D";
            this.gridColumn4.FieldName = "EmpDW";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpDW", "{0}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 64;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "EmpCode";
            this.gridColumn1.FieldName = "EmpCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmpCode", "{0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 88;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "EmpName";
            this.gridColumn2.FieldName = "EmpName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 151;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "EmpPymtMode";
            this.gridColumn20.FieldName = "EmpPymtMode";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 4;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Department";
            this.gridColumn3.FieldName = "DeptDesc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 148;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Loan Amt";
            this.gridColumn13.FieldName = "EmpLoanAmt";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpLoanAmt", "{0}")});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "AdvAmt";
            this.gridColumn14.FieldName = "EmpAdvAmt";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpAdvAmt", "{0}")});
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "CoupAmt";
            this.gridColumn15.FieldName = "EmpCoupAmt";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EmpCoupAmt", "{0}")});
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 9;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Select";
            this.gridColumn18.FieldName = "Select";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 10;
            // 
            // Btn_RefreshGridData
            // 
            this.Btn_RefreshGridData.Location = new System.Drawing.Point(150, 62);
            this.Btn_RefreshGridData.Name = "Btn_RefreshGridData";
            this.Btn_RefreshGridData.Size = new System.Drawing.Size(93, 20);
            this.Btn_RefreshGridData.TabIndex = 2;
            this.Btn_RefreshGridData.Text = "&Refresh";
            this.Btn_RefreshGridData.Click += new System.EventHandler(this.Btn_RefreshGridData_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 13);
            this.labelControl2.TabIndex = 315;
            this.labelControl2.Text = "Month";
            // 
            // DtStartDate
            // 
            this.DtStartDate.Location = new System.Drawing.Point(53, 62);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.EditFormat.FormatString = "MM-yyyy";
            this.DtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtStartDate.Properties.Mask.EditMask = "MM-yyyy";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.DtStartDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtStartDate.Properties.MaxLength = 6;
            this.DtStartDate.Size = new System.Drawing.Size(91, 20);
            this.DtStartDate.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(804, 83);
            this.splitter1.TabIndex = 324;
            this.splitter1.TabStop = false;
            // 
            // frm_EmpsalMst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 604);
            this.ControlBox = false;
            this.Controls.Add(this.DocumentMGRGrid);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.DtStartDate);
            this.Controls.Add(this.btnSelectALL);
            this.Controls.Add(this.btnLoadAdvance);
            this.Controls.Add(this.Btn_RefreshGridData);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_EmpsalMst";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_EmpsalMst_Load);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentMGRGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocMGRGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripTextBox TextAuthenticate;
        private DevExpress.XtraGrid.GridControl DocumentMGRGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView DocMGRGrid;
        private DevExpress.XtraEditors.SimpleButton Btn_RefreshGridData;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.TextEdit DtStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnLoadAdvance;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private System.Windows.Forms.CheckBox btnSelectALL;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.Splitter splitter1;
    }
}