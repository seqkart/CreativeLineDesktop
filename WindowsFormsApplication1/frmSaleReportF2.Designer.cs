namespace WindowsFormsApplication1
{
    partial class frmSaleReportF2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleReportF2));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmpGrid = new DevExpress.XtraGrid.GridControl();
            this.CmpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CmpUnitGrid = new DevExpress.XtraGrid.GridControl();
            this.CmpUnitGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.InfoGrid = new DevExpress.XtraGrid.GridControl();
            this.InfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblAverageBillSale = new System.Windows.Forms.Label();
            this.lblNoOfBills = new System.Windows.Forms.Label();
            this.lblTotalSaleQty = new System.Windows.Forms.Label();
            this.lblTotalSale = new System.Windows.Forms.Label();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpUnitGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpUnitGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(694, 26);
            this.Menu_ToolStrip.TabIndex = 686;
            this.Menu_ToolStrip.Text = "Options";
            this.Menu_ToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ToolStrip_ItemClicked);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(512, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 692;
            this.label1.Text = "TOTAL SALE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(512, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 693;
            this.label2.Text = "TOTAL QTY SOLD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(512, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 694;
            this.label3.Text = "AVERAGE SALE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(512, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 695;
            this.label4.Text = "TOTAL BILLS";
            // 
            // CmpGrid
            // 
            this.CmpGrid.Location = new System.Drawing.Point(12, 38);
            this.CmpGrid.MainView = this.CmpGridView;
            this.CmpGrid.Name = "CmpGrid";
            this.CmpGrid.Size = new System.Drawing.Size(251, 228);
            this.CmpGrid.TabIndex = 691;
            this.CmpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CmpGridView});
            // 
            // CmpGridView
            // 
            this.CmpGridView.GridControl = this.CmpGrid;
            this.CmpGridView.Name = "CmpGridView";
            this.CmpGridView.OptionsView.ShowGroupPanel = false;
            this.CmpGridView.OptionsView.ShowIndicator = false;
            // 
            // CmpUnitGrid
            // 
            this.CmpUnitGrid.Location = new System.Drawing.Point(269, 38);
            this.CmpUnitGrid.MainView = this.CmpUnitGridView;
            this.CmpUnitGrid.Name = "CmpUnitGrid";
            this.CmpUnitGrid.Size = new System.Drawing.Size(234, 228);
            this.CmpUnitGrid.TabIndex = 696;
            this.CmpUnitGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CmpUnitGridView});
            // 
            // CmpUnitGridView
            // 
            this.CmpUnitGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2});
            this.CmpUnitGridView.GridControl = this.CmpUnitGrid;
            this.CmpUnitGridView.Name = "CmpUnitGridView";
            this.CmpUnitGridView.OptionsView.ShowGroupPanel = false;
            this.CmpUnitGridView.OptionsView.ShowIndicator = false;
            this.CmpUnitGridView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.CmpUnitGridView_ValidatingEditor);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "UNITNAME";
            this.gridColumn1.FieldName = "UNITNAME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "UNITID";
            this.gridColumn3.FieldName = "UNITID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Select";
            this.gridColumn2.FieldName = "Select";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // InfoGrid
            // 
            this.InfoGrid.Location = new System.Drawing.Point(12, 274);
            this.InfoGrid.MainView = this.InfoGridView;
            this.InfoGrid.Name = "InfoGrid";
            this.InfoGrid.Size = new System.Drawing.Size(677, 206);
            this.InfoGrid.TabIndex = 697;
            this.InfoGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InfoGridView});
            this.InfoGrid.Click += new System.EventHandler(this.InfoGrid_Click);
            // 
            // InfoGridView
            // 
            this.InfoGridView.GridControl = this.InfoGrid;
            this.InfoGridView.Name = "InfoGridView";
            this.InfoGridView.OptionsView.ShowGroupPanel = false;
            this.InfoGridView.OptionsView.ShowIndicator = false;
            // 
            // lblAverageBillSale
            // 
            this.lblAverageBillSale.AutoSize = true;
            this.lblAverageBillSale.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.lblAverageBillSale.ForeColor = System.Drawing.Color.Green;
            this.lblAverageBillSale.Location = new System.Drawing.Point(512, 230);
            this.lblAverageBillSale.Name = "lblAverageBillSale";
            this.lblAverageBillSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAverageBillSale.Size = new System.Drawing.Size(30, 33);
            this.lblAverageBillSale.TabIndex = 698;
            this.lblAverageBillSale.Text = "0";
            this.lblAverageBillSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNoOfBills
            // 
            this.lblNoOfBills.AutoSize = true;
            this.lblNoOfBills.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.lblNoOfBills.ForeColor = System.Drawing.Color.Green;
            this.lblNoOfBills.Location = new System.Drawing.Point(512, 173);
            this.lblNoOfBills.Name = "lblNoOfBills";
            this.lblNoOfBills.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoOfBills.Size = new System.Drawing.Size(30, 33);
            this.lblNoOfBills.TabIndex = 698;
            this.lblNoOfBills.Text = "0";
            this.lblNoOfBills.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSaleQty
            // 
            this.lblTotalSaleQty.AutoSize = true;
            this.lblTotalSaleQty.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalSaleQty.ForeColor = System.Drawing.Color.Green;
            this.lblTotalSaleQty.Location = new System.Drawing.Point(512, 117);
            this.lblTotalSaleQty.Name = "lblTotalSaleQty";
            this.lblTotalSaleQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalSaleQty.Size = new System.Drawing.Size(30, 33);
            this.lblTotalSaleQty.TabIndex = 698;
            this.lblTotalSaleQty.Text = "0";
            this.lblTotalSaleQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSale
            // 
            this.lblTotalSale.AutoSize = true;
            this.lblTotalSale.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalSale.ForeColor = System.Drawing.Color.Green;
            this.lblTotalSale.Location = new System.Drawing.Point(512, 61);
            this.lblTotalSale.Name = "lblTotalSale";
            this.lblTotalSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalSale.Size = new System.Drawing.Size(30, 33);
            this.lblTotalSale.TabIndex = 698;
            this.lblTotalSale.Text = "0";
            this.lblTotalSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSaleReportF2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 488);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalSale);
            this.Controls.Add(this.lblTotalSaleQty);
            this.Controls.Add(this.lblNoOfBills);
            this.Controls.Add(this.lblAverageBillSale);
            this.Controls.Add(this.InfoGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmpUnitGrid);
            this.Controls.Add(this.CmpGrid);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmSaleReportF2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSaleReportF2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaleReportF2_KeyDown);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpUnitGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpUnitGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl CmpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView CmpGridView;
        private DevExpress.XtraGrid.GridControl CmpUnitGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView CmpUnitGridView;
        private DevExpress.XtraGrid.GridControl InfoGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView InfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label lblAverageBillSale;
        private System.Windows.Forms.Label lblNoOfBills;
        private System.Windows.Forms.Label lblTotalSaleQty;
        private System.Windows.Forms.Label lblTotalSale;
    }
}