namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmLoanMst
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoanMst));
            this.Btn_RefreshGridData = new DevExpress.XtraEditors.SimpleButton();
            this.DtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.DtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.EmployeeGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnView = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_RefreshGridData
            // 
            this.Btn_RefreshGridData.Location = new System.Drawing.Point(265, 52);
            this.Btn_RefreshGridData.Name = "Btn_RefreshGridData";
            this.Btn_RefreshGridData.Size = new System.Drawing.Size(93, 20);
            this.Btn_RefreshGridData.TabIndex = 196;
            this.Btn_RefreshGridData.Text = "&Refresh";
            this.Btn_RefreshGridData.Click += new System.EventHandler(this.Btn_RefreshGridData_Click);
            // 
            // DtEndDate
            // 
            this.DtEndDate.EditValue = null;
            this.DtEndDate.EnterMoveNextControl = true;
            this.DtEndDate.Location = new System.Drawing.Point(162, 52);
            this.DtEndDate.Name = "DtEndDate";
            this.DtEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DtEndDate.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtEndDate.Properties.Appearance.Options.UseBorderColor = true;
            this.DtEndDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue;
            this.DtEndDate.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DodgerBlue;
            this.DtEndDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DtEndDate.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.DtEndDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.DtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.DtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtEndDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.DtEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DtEndDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.DtEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DtEndDate.Properties.Mask.BeepOnError = true;
            this.DtEndDate.Properties.Mask.EditMask = "dd/MM/yy";
            this.DtEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DtEndDate.Size = new System.Drawing.Size(84, 20);
            this.DtEndDate.TabIndex = 195;
            // 
            // DtStartDate
            // 
            this.DtStartDate.EditValue = null;
            this.DtStartDate.EnterMoveNextControl = true;
            this.DtStartDate.Location = new System.Drawing.Point(54, 52);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DtStartDate.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtStartDate.Properties.Appearance.Options.UseBorderColor = true;
            this.DtStartDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue;
            this.DtStartDate.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DodgerBlue;
            this.DtStartDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DtStartDate.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.DtStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.DtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.DtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtStartDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.DtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DtStartDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.DtStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DtStartDate.Properties.Mask.BeepOnError = true;
            this.DtStartDate.Properties.Mask.EditMask = "dd/MM/yy";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DtStartDate.Size = new System.Drawing.Size(84, 20);
            this.DtStartDate.TabIndex = 194;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 193;
            this.labelControl1.Text = "From";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(144, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(13, 13);
            this.labelControl2.TabIndex = 192;
            this.labelControl2.Text = "To";
            // 
            // EmployeeGrid
            // 
            this.EmployeeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeGrid.Location = new System.Drawing.Point(0, 108);
            this.EmployeeGrid.LookAndFeel.SkinName = "Seven Classic";
            this.EmployeeGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.EmployeeGrid.MainView = this.gridView3;
            this.EmployeeGrid.Name = "EmployeeGrid";
            this.EmployeeGrid.Size = new System.Drawing.Size(804, 491);
            this.EmployeeGrid.TabIndex = 191;
            this.EmployeeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.EmployeeGrid.DoubleClick += new System.EventHandler(this.EmployeeGrid_DoubleClick);
            this.EmployeeGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmployeeGrid_KeyDown);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn6});
            this.gridView3.GridControl = this.EmployeeGrid;
            this.gridView3.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView3.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsDetail.EnableDetailToolTip = true;
            this.gridView3.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView3.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView3.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView3.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.gridView3.OptionsView.ShowDetailButtons = false;
            this.gridView3.OptionsView.ShowFooter = true;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "UnitName";
            this.gridColumn3.FieldName = "UnitName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "LoanANo";
            this.gridColumn4.FieldName = "LoanANo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LoanANo", "{0}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "LoanADate";
            this.gridColumn5.FieldName = "LoanADate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "EmpCode";
            this.gridColumn1.FieldName = "EmpCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "EmpName";
            this.gridColumn7.FieldName = "EmpName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "LoanAmt";
            this.gridColumn2.FieldName = "LoanAmt";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LoanAmt", "{0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.btnDelete,
            this.btnEdit,
            this.btnAdd,
            this.btnView});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 26);
            this.Menu_ToolStrip.TabIndex = 194;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnPrint.Size = new System.Drawing.Size(48, 23);
            this.btnPrint.Text = "Print";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnDelete.Size = new System.Drawing.Size(59, 23);
            this.btnDelete.Text = "Delete";
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnAdd.Size = new System.Drawing.Size(43, 23);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnView
            // 
            this.btnView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnView.Size = new System.Drawing.Size(49, 23);
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 26);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(804, 82);
            this.splitter1.TabIndex = 196;
            this.splitter1.TabStop = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "LoanInstlmnt";
            this.gridColumn6.FieldName = "LoanInstlmnt";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // frmLoanMst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 599);
            this.ControlBox = false;
            this.Controls.Add(this.EmployeeGrid);
            this.Controls.Add(this.Btn_RefreshGridData);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.DtEndDate);
            this.Controls.Add(this.DtStartDate);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLoanMst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoanMst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl EmployeeGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton Btn_RefreshGridData;
        private DevExpress.XtraEditors.DateEdit DtEndDate;
        private DevExpress.XtraEditors.DateEdit DtStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ToolStripButton btnView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}