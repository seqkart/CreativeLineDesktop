namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmLoanMonthlyDateMst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoanMonthlyDateMst));
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Quit = new System.Windows.Forms.ToolStripButton();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btn_Edit = new System.Windows.Forms.ToolStripButton();
            this.btn_Add = new System.Windows.Forms.ToolStripButton();
            this.vRLMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtaid = new DevExpress.XtraEditors.TextEdit();
            this.LoanGrid = new DevExpress.XtraGrid.GridControl();
            this.vRLMstBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.LoanGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.GroupControl();
            this.DtStartDate = new DevExpress.XtraEditors.TextEdit();
            this.Btn_RefreshRateL = new DevExpress.XtraEditors.SimpleButton();
            this.vRLMstBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vRLMstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoanGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRLMstBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoanGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRLMstBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "MonthYear";
            this.gridColumn3.FieldName = "MonthYear";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "From";
            // 
            // btn_Quit
            // 
            this.btn_Quit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Quit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Quit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.ForeColor = System.Drawing.Color.White;
            this.btn_Quit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Quit.Image")));
            this.btn_Quit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(35, 22);
            this.btn_Quit.Text = "&Quit";
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Quit,
            this.btn_Edit,
            this.btn_Add});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 25);
            this.Menu_ToolStrip.TabIndex = 10;
            this.Menu_ToolStrip.Text = "toolStrip1";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Edit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Edit.Image")));
            this.btn_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(32, 22);
            this.btn_Edit.Text = "&Edit";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(33, 22);
            this.btn_Add.Text = "&Add";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // vRLMstBindingSource
            // 
            this.vRLMstBindingSource.DataMember = "V_RLMst";
            // 
            // txtaid
            // 
            this.txtaid.Location = new System.Drawing.Point(740, 385);
            this.txtaid.Name = "txtaid";
            this.txtaid.Size = new System.Drawing.Size(10, 20);
            this.txtaid.TabIndex = 4;
            // 
            // LoanGrid
            // 
            this.LoanGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoanGrid.DataSource = this.vRLMstBindingSource2;
            this.LoanGrid.Location = new System.Drawing.Point(14, 79);
            this.LoanGrid.MainView = this.LoanGridView;
            this.LoanGrid.Name = "LoanGrid";
            this.LoanGrid.Size = new System.Drawing.Size(736, 326);
            this.LoanGrid.TabIndex = 3;
            this.LoanGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.LoanGridView});
            this.LoanGrid.DoubleClick += new System.EventHandler(this.LoanGrid_DoubleClick);
            // 
            // vRLMstBindingSource2
            // 
            this.vRLMstBindingSource2.DataMember = "V_RLMst";
            // 
            // LoanGridView
            // 
            this.LoanGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn5});
            this.LoanGridView.GridControl = this.LoanGrid;
            this.LoanGridView.Name = "LoanGridView";
            this.LoanGridView.OptionsView.ShowFooter = true;
            this.LoanGridView.OptionsView.ShowGroupPanel = false;
            this.LoanGridView.OptionsView.ShowIndicator = false;
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
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "EmpName";
            this.gridColumn6.FieldName = "EmpName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "LoanInstlmnt";
            this.gridColumn2.FieldName = "LoanInstlmnt";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TransID";
            this.gridColumn5.FieldName = "TransID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.DtStartDate);
            this.panelControl1.Controls.Add(this.txtaid);
            this.panelControl1.Controls.Add(this.LoanGrid);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.Btn_RefreshRateL);
            this.panelControl1.Location = new System.Drawing.Point(12, 38);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(768, 424);
            this.panelControl1.TabIndex = 11;
            this.panelControl1.Text = "Loan Monthly Data Mst";
            // 
            // DtStartDate
            // 
            this.DtStartDate.Location = new System.Drawing.Point(55, 38);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.EditFormat.FormatString = "MM-yyyy";
            this.DtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtStartDate.Properties.Mask.EditMask = "MM-yyyy";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.DtStartDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtStartDate.Properties.MaxLength = 6;
            this.DtStartDate.Size = new System.Drawing.Size(84, 20);
            this.DtStartDate.TabIndex = 45;
            // 
            // Btn_RefreshRateL
            // 
            this.Btn_RefreshRateL.Location = new System.Drawing.Point(145, 38);
            this.Btn_RefreshRateL.Name = "Btn_RefreshRateL";
            this.Btn_RefreshRateL.Size = new System.Drawing.Size(75, 21);
            this.Btn_RefreshRateL.TabIndex = 2;
            this.Btn_RefreshRateL.Text = "Refresh";
            this.Btn_RefreshRateL.Click += new System.EventHandler(this.Btn_RefreshRateL_Click);
            this.Btn_RefreshRateL.DoubleClick += new System.EventHandler(this.Btn_RefreshRateL_DoubleClick);
            // 
            // vRLMstBindingSource1
            // 
            this.vRLMstBindingSource1.DataMember = "V_RLMst";
            // 
            // frmLoanMonthlyDateMst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 516);
            this.ControlBox = false;
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLoanMonthlyDateMst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoanMonthlyDateMst_Load);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vRLMstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoanGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRLMstBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoanGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRLMstBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStripButton btn_Quit;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btn_Edit;
        private System.Windows.Forms.ToolStripButton btn_Add;
        private System.Windows.Forms.BindingSource vRLMstBindingSource;
        private DevExpress.XtraEditors.TextEdit txtaid;
        private DevExpress.XtraGrid.GridControl LoanGrid;
        private System.Windows.Forms.BindingSource vRLMstBindingSource2;
        private DevExpress.XtraGrid.Views.Grid.GridView LoanGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.GroupControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_RefreshRateL;
        private System.Windows.Forms.BindingSource vRLMstBindingSource1;
        private DevExpress.XtraEditors.TextEdit DtStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}