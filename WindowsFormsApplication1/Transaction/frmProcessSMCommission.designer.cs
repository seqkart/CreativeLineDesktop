namespace WindowsFormsApplication1
{
    partial class frmProcessSMCommission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessSMCommission));
            this.panelControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSelectALL = new System.Windows.Forms.CheckBox();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.ReplGrid = new DevExpress.XtraGrid.GridControl();
            this.ReplGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_RefreshGridData = new DevExpress.XtraEditors.SimpleButton();
            this.DtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.DtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.txtPassword = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReplGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSelectALL);
            this.panelControl1.Controls.Add(this.btnProcess);
            this.panelControl1.Controls.Add(this.ReplGrid);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.Btn_RefreshGridData);
            this.panelControl1.Controls.Add(this.DtEndDate);
            this.panelControl1.Controls.Add(this.DtStartDate);
            this.panelControl1.Location = new System.Drawing.Point(46, 53);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(783, 457);
            this.panelControl1.TabIndex = 197;
            this.panelControl1.Text = "Process Salesman Commission";
            // 
            // btnSelectALL
            // 
            this.btnSelectALL.AutoSize = true;
            this.btnSelectALL.Location = new System.Drawing.Point(717, 25);
            this.btnSelectALL.Name = "btnSelectALL";
            this.btnSelectALL.Size = new System.Drawing.Size(15, 14);
            this.btnSelectALL.TabIndex = 288;
            this.btnSelectALL.UseVisualStyleBackColor = true;
            this.btnSelectALL.CheckedChanged += new System.EventHandler(this.btnSelectALL_CheckedChanged);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(668, 45);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(100, 20);
            this.btnProcess.TabIndex = 200;
            this.btnProcess.Text = "Process";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // ReplGrid
            // 
            this.ReplGrid.Location = new System.Drawing.Point(12, 81);
            this.ReplGrid.MainView = this.ReplGridView;
            this.ReplGrid.Name = "ReplGrid";
            this.ReplGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.ReplGrid.Size = new System.Drawing.Size(759, 361);
            this.ReplGrid.TabIndex = 194;
            this.ReplGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ReplGridView});
            // 
            // ReplGridView
            // 
            this.ReplGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.ReplGridView.GridControl = this.ReplGrid;
            this.ReplGridView.Name = "ReplGridView";
            this.ReplGridView.OptionsView.ShowFooter = true;
            this.ReplGridView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "AccCode";
            this.gridColumn1.FieldName = "AccCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "AccName";
            this.gridColumn2.FieldName = "AccName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 193;
            this.labelControl1.Text = "From";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(157, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(13, 13);
            this.labelControl2.TabIndex = 192;
            this.labelControl2.Text = "To";
            // 
            // Btn_RefreshGridData
            // 
            this.Btn_RefreshGridData.Location = new System.Drawing.Point(289, 42);
            this.Btn_RefreshGridData.Name = "Btn_RefreshGridData";
            this.Btn_RefreshGridData.Size = new System.Drawing.Size(75, 20);
            this.Btn_RefreshGridData.TabIndex = 2;
            this.Btn_RefreshGridData.Text = "Refresh";
            this.Btn_RefreshGridData.Click += new System.EventHandler(this.Btn_RefreshGridData_Click);
            // 
            // DtEndDate
            // 
            this.DtEndDate.EditValue = null;
            this.DtEndDate.Location = new System.Drawing.Point(175, 42);
            this.DtEndDate.Name = "DtEndDate";
            this.DtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.DtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtEndDate.Properties.Mask.EditMask = "";
            this.DtEndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DtEndDate.Size = new System.Drawing.Size(81, 20);
            this.DtEndDate.TabIndex = 1;
            // 
            // DtStartDate
            // 
            this.DtStartDate.EditValue = null;
            this.DtStartDate.Location = new System.Drawing.Point(54, 42);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.DtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtStartDate.Properties.Mask.EditMask = "";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DtStartDate.Size = new System.Drawing.Size(81, 20);
            this.DtStartDate.TabIndex = 0;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.txtPassword});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(940, 26);
            this.Menu_ToolStrip.TabIndex = 196;
            this.Menu_ToolStrip.Text = "Options";
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
            this.btnQuit.Text = "&Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 26);
            // 
            // frmProcessSMCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 548);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProcessSMCommission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProcessSMCommission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReplGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReplGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraGrid.GridControl ReplGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView ReplGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton Btn_RefreshGridData;
        private DevExpress.XtraEditors.DateEdit DtEndDate;
        private DevExpress.XtraEditors.DateEdit DtStartDate;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.ToolStripTextBox txtPassword;
        private System.Windows.Forms.CheckBox btnSelectALL;
    }
}