namespace WindowsFormsApplication1
{
    partial class frm_StockIndentPassing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StockIndentPassing));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.BtnQuit = new System.Windows.Forms.ToolStripButton();
            this.BtnUnPassSelected = new System.Windows.Forms.ToolStripButton();
            this.Btn_Pass_Selected = new System.Windows.Forms.ToolStripButton();
            this.TextAuthenticate = new System.Windows.Forms.ToolStripTextBox();
            this.BtnCalc = new System.Windows.Forms.ToolStripButton();
            this.InPassGridCtrl = new DevExpress.XtraGrid.GridControl();
            this.IndentPassGrd = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChoiceSelectAll = new DevExpress.XtraEditors.CheckEdit();
            this.DtIndentPass = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_RefreshGridData = new DevExpress.XtraEditors.SimpleButton();
            this.DtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.DtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InPassGridCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndentPassGrd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceSelectAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtIndentPass.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtIndentPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Est. Cost";
            this.gridColumn13.FieldName = "IndEstAmt";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            this.gridColumn13.Width = 76;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnQuit,
            this.BtnUnPassSelected,
            this.Btn_Pass_Selected,
            this.TextAuthenticate,
            this.BtnCalc});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(947, 26);
            this.Menu_ToolStrip.TabIndex = 64;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // BtnQuit
            // 
            this.BtnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnQuit.ForeColor = System.Drawing.Color.White;
            this.BtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuit.Image")));
            this.BtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.BtnQuit.Size = new System.Drawing.Size(45, 23);
            this.BtnQuit.Text = "&Quit";
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // BtnUnPassSelected
            // 
            this.BtnUnPassSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnUnPassSelected.ForeColor = System.Drawing.Color.White;
            this.BtnUnPassSelected.Image = ((System.Drawing.Image)(resources.GetObject("BtnUnPassSelected.Image")));
            this.BtnUnPassSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUnPassSelected.Name = "BtnUnPassSelected";
            this.BtnUnPassSelected.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.BtnUnPassSelected.Size = new System.Drawing.Size(63, 23);
            this.BtnUnPassSelected.Text = "Un Pass";
            this.BtnUnPassSelected.Click += new System.EventHandler(this.BtnUnPassSelected_Click);
            // 
            // Btn_Pass_Selected
            // 
            this.Btn_Pass_Selected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Btn_Pass_Selected.ForeColor = System.Drawing.Color.White;
            this.Btn_Pass_Selected.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Pass_Selected.Image")));
            this.Btn_Pass_Selected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Pass_Selected.Name = "Btn_Pass_Selected";
            this.Btn_Pass_Selected.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Btn_Pass_Selected.Size = new System.Drawing.Size(44, 23);
            this.Btn_Pass_Selected.Text = "Pass";
            this.Btn_Pass_Selected.Click += new System.EventHandler(this.Btn_Pass_Selected_Click);
            // 
            // TextAuthenticate
            // 
            this.TextAuthenticate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TextAuthenticate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextAuthenticate.Name = "TextAuthenticate";
            this.TextAuthenticate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextAuthenticate.Size = new System.Drawing.Size(100, 26);
            // 
            // BtnCalc
            // 
            this.BtnCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnCalc.ForeColor = System.Drawing.Color.White;
            this.BtnCalc.Image = ((System.Drawing.Image)(resources.GetObject("BtnCalc.Image")));
            this.BtnCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCalc.Name = "BtnCalc";
            this.BtnCalc.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.BtnCalc.Size = new System.Drawing.Size(76, 23);
            this.BtnCalc.Text = "&Calculator";
            // 
            // InPassGridCtrl
            // 
            this.InPassGridCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InPassGridCtrl.Location = new System.Drawing.Point(2, 69);
            this.InPassGridCtrl.MainView = this.IndentPassGrd;
            this.InPassGridCtrl.Name = "InPassGridCtrl";
            this.InPassGridCtrl.Size = new System.Drawing.Size(943, 328);
            this.InPassGridCtrl.TabIndex = 199;
            this.InPassGridCtrl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.IndentPassGrd});
            // 
            // IndentPassGrd
            // 
            this.IndentPassGrd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn11,
            this.gridColumn14});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.gridColumn13;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Between;
            styleFormatCondition1.Value1 = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            styleFormatCondition1.Value2 = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.gridColumn13;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Between;
            styleFormatCondition2.Value1 = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            styleFormatCondition2.Value2 = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.gridColumn13;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Greater;
            styleFormatCondition3.Value1 = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.IndentPassGrd.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
            this.IndentPassGrd.GridControl = this.InPassGridCtrl;
            this.IndentPassGrd.Name = "IndentPassGrd";
            this.IndentPassGrd.OptionsView.ColumnAutoWidth = false;
            this.IndentPassGrd.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "IndID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ind. No.";
            this.gridColumn2.FieldName = "IndDNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 56;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Date";
            this.gridColumn3.FieldName = "IndDDate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 88;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Item Code";
            this.gridColumn4.FieldName = "IndDItemCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Item";
            this.gridColumn5.FieldName = "PrdName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 157;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Qty.";
            this.gridColumn6.FieldName = "IndDItemQty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 62;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Remarks";
            this.gridColumn7.FieldName = "IndDRemarks";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 111;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Target Dt.";
            this.gridColumn8.FieldName = "IndDItemReqDDate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 69;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Status";
            this.gridColumn9.FieldName = "IndPassTag";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 51;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Pass Dt.";
            this.gridColumn10.FieldName = "IndPassDt";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 80;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Pass Qty.";
            this.gridColumn12.FieldName = "IndDItemQtyPass";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            this.gridColumn12.Width = 47;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Po No";
            this.gridColumn11.FieldName = "IndPoMadeNo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Width = 61;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Pass";
            this.gridColumn14.FieldName = "Pass";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 11;
            // 
            // ChoiceSelectAll
            // 
            this.ChoiceSelectAll.Location = new System.Drawing.Point(864, 34);
            this.ChoiceSelectAll.Name = "ChoiceSelectAll";
            this.ChoiceSelectAll.Properties.Caption = "Select All";
            this.ChoiceSelectAll.Size = new System.Drawing.Size(75, 19);
            this.ChoiceSelectAll.TabIndex = 200;
            this.ChoiceSelectAll.CheckedChanged += new System.EventHandler(this.ChoiceSelectAll_CheckedChanged);
            // 
            // DtIndentPass
            // 
            this.DtIndentPass.EditValue = null;
            this.DtIndentPass.Location = new System.Drawing.Point(737, 34);
            this.DtIndentPass.Name = "DtIndentPass";
            this.DtIndentPass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtIndentPass.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtIndentPass.Properties.Mask.EditMask = "";
            this.DtIndentPass.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DtIndentPass.Size = new System.Drawing.Size(100, 20);
            this.DtIndentPass.TabIndex = 195;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(630, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(97, 13);
            this.labelControl3.TabIndex = 197;
            this.labelControl3.Text = "Indent Passing Date";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 205;
            this.labelControl1.Text = "From";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(165, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 204;
            this.labelControl2.Text = "To";
            // 
            // Btn_RefreshGridData
            // 
            this.Btn_RefreshGridData.Location = new System.Drawing.Point(314, 33);
            this.Btn_RefreshGridData.Name = "Btn_RefreshGridData";
            this.Btn_RefreshGridData.Size = new System.Drawing.Size(75, 20);
            this.Btn_RefreshGridData.TabIndex = 203;
            this.Btn_RefreshGridData.Text = "Refresh";
            this.Btn_RefreshGridData.Click += new System.EventHandler(this.Btn_RefreshGridData_Click);
            // 
            // DtEndDate
            // 
            this.DtEndDate.EditValue = null;
            this.DtEndDate.Location = new System.Drawing.Point(183, 34);
            this.DtEndDate.Name = "DtEndDate";
            this.DtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtEndDate.Properties.Mask.EditMask = "";
            this.DtEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DtEndDate.Size = new System.Drawing.Size(100, 20);
            this.DtEndDate.TabIndex = 202;
            // 
            // DtStartDate
            // 
            this.DtStartDate.EditValue = null;
            this.DtStartDate.Location = new System.Drawing.Point(37, 34);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtStartDate.Properties.Mask.EditMask = "";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DtStartDate.Size = new System.Drawing.Size(100, 20);
            this.DtStartDate.TabIndex = 201;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.InPassGridCtrl);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.DtIndentPass);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.Btn_RefreshGridData);
            this.panelControl1.Controls.Add(this.ChoiceSelectAll);
            this.panelControl1.Controls.Add(this.DtEndDate);
            this.panelControl1.Controls.Add(this.DtStartDate);
            this.panelControl1.Location = new System.Drawing.Point(0, 49);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(947, 399);
            this.panelControl1.TabIndex = 206;
            this.panelControl1.Text = "Passing Indent Items for Purchase Order...";
            // 
            // frm_StockIndentPassing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 447);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_StockIndentPassing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frm_StockIndentPassing_Load);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InPassGridCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndentPassGrd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoiceSelectAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtIndentPass.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtIndentPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton BtnQuit;
        private System.Windows.Forms.ToolStripButton Btn_Pass_Selected;
        private System.Windows.Forms.ToolStripTextBox TextAuthenticate;
        private System.Windows.Forms.ToolStripButton BtnCalc;
        private DevExpress.XtraGrid.GridControl InPassGridCtrl;
        private DevExpress.XtraGrid.Views.Grid.GridView IndentPassGrd;
        private DevExpress.XtraEditors.CheckEdit ChoiceSelectAll;
        private DevExpress.XtraEditors.DateEdit DtIndentPass;
        private DevExpress.XtraEditors.LabelControl labelControl3;
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
        private System.Windows.Forms.ToolStripButton BtnUnPassSelected;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton Btn_RefreshGridData;
        private DevExpress.XtraEditors.DateEdit DtEndDate;
        private DevExpress.XtraEditors.DateEdit DtStartDate;
        private DevExpress.XtraEditors.GroupControl panelControl1;
    }
}