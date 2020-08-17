namespace WindowsFormsApplication1
{
    partial class frmTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransaction));
            this.InvoiceGrid = new DevExpress.XtraGrid.GridControl();
            this.InvoiceGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.lbl = new System.Windows.Forms.ToolStripLabel();
            this.PrintOutGrid = new DevExpress.XtraGrid.GridControl();
            this.PrintOutGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOutGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOutGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // InvoiceGrid
            // 
            this.InvoiceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceGrid.Location = new System.Drawing.Point(0, 26);
            this.InvoiceGrid.MainView = this.InvoiceGridView;
            this.InvoiceGrid.Name = "InvoiceGrid";
            this.InvoiceGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.InvoiceGrid.Size = new System.Drawing.Size(937, 464);
            this.InvoiceGrid.TabIndex = 200;
            this.InvoiceGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InvoiceGridView});
            this.InvoiceGrid.Click += new System.EventHandler(this.InvoiceGrid_Click);
            this.InvoiceGrid.DoubleClick += new System.EventHandler(this.InvoiceGrid_DoubleClick);
            this.InvoiceGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InvoiceGrid_KeyDown);
            // 
            // InvoiceGridView
            // 
            this.InvoiceGridView.GridControl = this.InvoiceGrid;
            this.InvoiceGridView.Name = "InvoiceGridView";
            this.InvoiceGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.InvoiceGridView.OptionsBehavior.Editable = false;
            this.InvoiceGridView.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.SegmentedFade;
            this.InvoiceGridView.OptionsPrint.EnableAppearanceEvenRow = true;
            this.InvoiceGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.InvoiceGridView.OptionsView.ShowFooter = true;
            this.InvoiceGridView.OptionsView.ShowGroupPanel = false;
            this.InvoiceGridView.OptionsView.ShowIndicator = false;
            this.InvoiceGridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.InvoiceGridView_PopupMenuShowing);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnAdd,
            this.lbl});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(937, 26);
            this.Menu_ToolStrip.TabIndex = 199;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
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
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnAdd.Size = new System.Drawing.Size(43, 23);
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbl
            // 
            this.lbl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(26, 23);
            this.lbl.Text = "dsd";
            // 
            // PrintOutGrid
            // 
            this.PrintOutGrid.Location = new System.Drawing.Point(111, 140);
            this.PrintOutGrid.MainView = this.PrintOutGridView;
            this.PrintOutGrid.Name = "PrintOutGrid";
            this.PrintOutGrid.Size = new System.Drawing.Size(462, 227);
            this.PrintOutGrid.TabIndex = 201;
            this.PrintOutGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PrintOutGridView});
            this.PrintOutGrid.Visible = false;
            this.PrintOutGrid.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.PrintOutGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintOutGrid_KeyDown);
            // 
            // PrintOutGridView
            // 
            this.PrintOutGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.PrintOutGridView.GridControl = this.PrintOutGrid;
            this.PrintOutGridView.Name = "PrintOutGridView";
            this.PrintOutGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CopyText";
            this.gridColumn1.FieldName = "CopyText";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Select";
            this.gridColumn2.FieldName = "Select";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 490);
            this.ControlBox = false;
            this.Controls.Add(this.PrintOutGrid);
            this.Controls.Add(this.InvoiceGrid);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTransaction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOutGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOutGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl InvoiceGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView InvoiceGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripLabel lbl;
        private DevExpress.XtraGrid.GridControl PrintOutGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView PrintOutGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}