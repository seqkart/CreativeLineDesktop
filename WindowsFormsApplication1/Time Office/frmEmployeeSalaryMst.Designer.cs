namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmEmployeeSalaryMst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeSalaryMst));
            this.EmployeeGrid = new DevExpress.XtraGrid.GridControl();
            this.EmployeeGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGridView)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeGrid
            // 
            this.EmployeeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeGrid.Location = new System.Drawing.Point(0, 26);
            this.EmployeeGrid.LookAndFeel.SkinName = "Seven Classic";
            this.EmployeeGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.EmployeeGrid.MainView = this.EmployeeGridView;
            this.EmployeeGrid.Name = "EmployeeGrid";
            this.EmployeeGrid.Size = new System.Drawing.Size(804, 552);
            this.EmployeeGrid.TabIndex = 191;
            this.EmployeeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.EmployeeGridView});
            this.EmployeeGrid.DoubleClick += new System.EventHandler(this.EmployeeGrid_DoubleClick);
            this.EmployeeGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmployeeGrid_KeyDown);
            // 
            // EmployeeGridView
            // 
            this.EmployeeGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.EmployeeGridView.GridControl = this.EmployeeGrid;
            this.EmployeeGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.EmployeeGridView.Name = "EmployeeGridView";
            this.EmployeeGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.EmployeeGridView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.EmployeeGridView.OptionsBehavior.Editable = false;
            this.EmployeeGridView.OptionsDetail.EnableDetailToolTip = true;
            this.EmployeeGridView.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.EmployeeGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.EmployeeGridView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.EmployeeGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.EmployeeGridView.OptionsView.ShowDetailButtons = false;
            this.EmployeeGridView.OptionsView.ShowFooter = true;
            this.EmployeeGridView.OptionsView.ShowGroupPanel = false;
            this.EmployeeGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "UnitName";
            this.gridColumn6.FieldName = "UnitName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Emp Code";
            this.gridColumn1.FieldName = "EmpCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmpCode", "Count={0}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 82;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Emp Name";
            this.gridColumn2.FieldName = "EmpName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 185;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Emp Father Name";
            this.gridColumn3.FieldName = "EmpFHName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 152;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Dept";
            this.gridColumn4.FieldName = "DeptDesc";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 92;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Date Of Leaving";
            this.gridColumn5.FieldName = "EmpDOL";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 92;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnAdd,
            this.btnRefresh});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 26);
            this.Menu_ToolStrip.TabIndex = 194;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnEdit.Size = new System.Drawing.Size(42, 23);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnAdd.Size = new System.Drawing.Size(43, 23);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnRefresh.Size = new System.Drawing.Size(65, 23);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmEmployeeSalaryMst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 578);
            this.ControlBox = false;
            this.Controls.Add(this.EmployeeGrid);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmployeeSalaryMst";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeeSalaryMst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGridView)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl EmployeeGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView EmployeeGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}