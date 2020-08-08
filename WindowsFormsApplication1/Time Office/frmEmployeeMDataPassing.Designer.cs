namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmEmployeeMDataPassing
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
            this.Btn_RefreshGridData = new DevExpress.XtraEditors.SimpleButton();
            this.DtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.DtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.InvoiceGrid = new DevExpress.XtraGrid.GridControl();
            this.InvoiceGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_RefreshGridData
            // 
            this.Btn_RefreshGridData.Location = new System.Drawing.Point(300, 53);
            this.Btn_RefreshGridData.Name = "Btn_RefreshGridData";
            this.Btn_RefreshGridData.Size = new System.Drawing.Size(93, 20);
            this.Btn_RefreshGridData.TabIndex = 2;
            this.Btn_RefreshGridData.Text = "&Refresh";
            this.Btn_RefreshGridData.Click += new System.EventHandler(this.Btn_RefreshGridData_Click);
            // 
            // DtEndDate
            // 
            this.DtEndDate.EditValue = null;
            this.DtEndDate.EnterMoveNextControl = true;
            this.DtEndDate.Location = new System.Drawing.Point(178, 53);
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
            this.DtEndDate.Size = new System.Drawing.Size(93, 20);
            this.DtEndDate.TabIndex = 1;
            // 
            // DtStartDate
            // 
            this.DtStartDate.EditValue = null;
            this.DtStartDate.EnterMoveNextControl = true;
            this.DtStartDate.Location = new System.Drawing.Point(61, 53);
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
            this.DtStartDate.Size = new System.Drawing.Size(93, 20);
            this.DtStartDate.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "From";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(160, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(13, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "To";
            // 
            // InvoiceGrid
            // 
            this.InvoiceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceGrid.Location = new System.Drawing.Point(0, 95);
            this.InvoiceGrid.MainView = this.InvoiceGridView;
            this.InvoiceGrid.Name = "InvoiceGrid";
            this.InvoiceGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.InvoiceGrid.Size = new System.Drawing.Size(804, 450);
            this.InvoiceGrid.TabIndex = 5;
            this.InvoiceGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.InvoiceGridView});
            this.InvoiceGrid.DoubleClick += new System.EventHandler(this.InvoiceGrid_DoubleClick);
            this.InvoiceGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InvoiceGrid_KeyDown);
            // 
            // InvoiceGridView
            // 
            this.InvoiceGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn8});
            this.InvoiceGridView.GridControl = this.InvoiceGrid;
            this.InvoiceGridView.Name = "InvoiceGridView";
            this.InvoiceGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.InvoiceGridView.OptionsView.ShowFooter = true;
            this.InvoiceGridView.OptionsView.ShowGroupPanel = false;
            this.InvoiceGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "UnitName";
            this.gridColumn12.FieldName = "UnitName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "EmpDDate";
            this.gridColumn10.FieldName = "EmpDDate";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmpDDate", "{0}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "EmpCode";
            this.gridColumn1.FieldName = "EmpCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "EmpName";
            this.gridColumn2.FieldName = "EmpName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "EmpFHName";
            this.gridColumn3.FieldName = "EmpFHName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "EmpBasic";
            this.gridColumn4.FieldName = "EmpBasic";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "EmpHRA";
            this.gridColumn5.FieldName = "EmpHRA";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Convence";
            this.gridColumn6.FieldName = "EmpConv";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Petrol";
            this.gridColumn7.FieldName = "EmpPET";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Passby";
            this.gridColumn11.FieldName = "EmpPassbyUser";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "EmpSplAlw";
            this.gridColumn8.FieldName = "EmpSplAlw";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
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
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(804, 25);
            this.Menu_ToolStrip.TabIndex = 199;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(804, 70);
            this.splitter1.TabIndex = 201;
            this.splitter1.TabStop = false;
            // 
            // frmEmployeeMDataPassing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 545);
            this.ControlBox = false;
            this.Controls.Add(this.InvoiceGrid);
            this.Controls.Add(this.Btn_RefreshGridData);
            this.Controls.Add(this.DtEndDate);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.DtStartDate);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmployeeMDataPassing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeeMDataPassing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton Btn_RefreshGridData;
        private DevExpress.XtraEditors.DateEdit DtEndDate;
        private DevExpress.XtraEditors.DateEdit DtStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl InvoiceGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView InvoiceGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.Splitter splitter1;
    }
}