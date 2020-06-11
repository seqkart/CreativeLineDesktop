namespace WindowsFormsApplication1.Administration
{
    partial class XtraForm_UserMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm_UserMaster));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.toolStrip_lbl = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.gridControl_UserMaster = new DevExpress.XtraGrid.GridControl();
            this.userMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_UserMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Login_As = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_UserActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_Edit_Link = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button_delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn_Edit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip_lbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_UserMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_UserMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_delete)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_lbl
            // 
            this.toolStrip_lbl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_lbl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.btnAdd});
            this.toolStrip_lbl.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_lbl.Name = "toolStrip_lbl";
            this.toolStrip_lbl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_lbl.Size = new System.Drawing.Size(735, 25);
            this.toolStrip_lbl.TabIndex = 0;
            this.toolStrip_lbl.Text = "toolStrip1";
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleName = "";
            this.btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(31, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 22);
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControl_UserMaster
            // 
            this.gridControl_UserMaster.DataSource = this.userMasterBindingSource;
            this.gridControl_UserMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_UserMaster.Location = new System.Drawing.Point(0, 25);
            this.gridControl_UserMaster.MainView = this.gridView_UserMaster;
            this.gridControl_UserMaster.Name = "gridControl_UserMaster";
            this.gridControl_UserMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.button_delete});
            this.gridControl_UserMaster.Size = new System.Drawing.Size(735, 443);
            this.gridControl_UserMaster.TabIndex = 1;
            this.gridControl_UserMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_UserMaster});
            this.gridControl_UserMaster.Load += new System.EventHandler(this.gridControl_UserMaster_Load);
            this.gridControl_UserMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl_UserMaster_KeyDown);
            // 
            // userMasterBindingSource
            // 
            this.userMasterBindingSource.DataSource = typeof(DataBindings.UserMaster_Data);
            // 
            // gridView_UserMaster
            // 
            this.gridView_UserMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_UserName,
            this.gridColumn_Login_As,
            this.gridColumn_UserActive,
            this.gridColumn_Edit_Link});
            this.gridView_UserMaster.GridControl = this.gridControl_UserMaster;
            this.gridView_UserMaster.Name = "gridView_UserMaster";
            this.gridView_UserMaster.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView_UserMaster_PopupMenuShowing);
            // 
            // gridColumn_UserName
            // 
            this.gridColumn_UserName.Caption = "UserName";
            this.gridColumn_UserName.FieldName = "UserName";
            this.gridColumn_UserName.Name = "gridColumn_UserName";
            this.gridColumn_UserName.OptionsColumn.AllowEdit = false;
            this.gridColumn_UserName.Visible = true;
            this.gridColumn_UserName.VisibleIndex = 0;
            // 
            // gridColumn_Login_As
            // 
            this.gridColumn_Login_As.Caption = "Login_As";
            this.gridColumn_Login_As.FieldName = "Login_As";
            this.gridColumn_Login_As.Name = "gridColumn_Login_As";
            this.gridColumn_Login_As.OptionsColumn.AllowEdit = false;
            this.gridColumn_Login_As.Visible = true;
            this.gridColumn_Login_As.VisibleIndex = 1;
            // 
            // gridColumn_UserActive
            // 
            this.gridColumn_UserActive.Caption = "UserActive";
            this.gridColumn_UserActive.FieldName = "UserActive";
            this.gridColumn_UserActive.Name = "gridColumn_UserActive";
            this.gridColumn_UserActive.OptionsColumn.AllowEdit = false;
            this.gridColumn_UserActive.Visible = true;
            this.gridColumn_UserActive.VisibleIndex = 2;
            // 
            // gridColumn_Edit_Link
            // 
            this.gridColumn_Edit_Link.Caption = "button";
            this.gridColumn_Edit_Link.ColumnEdit = this.button_delete;
            this.gridColumn_Edit_Link.FieldName = "Edit_Link";
            this.gridColumn_Edit_Link.Name = "gridColumn_Edit_Link";
            this.gridColumn_Edit_Link.OptionsColumn.AllowEdit = false;
            this.gridColumn_Edit_Link.Visible = true;
            this.gridColumn_Edit_Link.VisibleIndex = 3;
            // 
            // button_delete
            // 
            this.button_delete.AutoHeight = false;
            this.button_delete.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.button_delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.button_delete.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.button_delete.Name = "button_delete";
            this.button_delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.button_delete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.button_delete_ButtonClick);
            // 
            // gridColumn_Edit
            // 
            this.gridColumn_Edit.Caption = "Edit";
            this.gridColumn_Edit.Name = "gridColumn_Edit";
            this.gridColumn_Edit.Visible = true;
            this.gridColumn_Edit.VisibleIndex = 3;
            // 
            // XtraForm_UserMaster
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 468);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl_UserMaster);
            this.Controls.Add(this.toolStrip_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "XtraForm_UserMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.XtraForm_UserMaster_Load);
            this.toolStrip_lbl.ResumeLayout(false);
            this.toolStrip_lbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_UserMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_UserMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_delete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_lbl;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private DevExpress.XtraGrid.GridControl gridControl_UserMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_UserMaster;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_UserName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Login_As;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_UserActive;
        private System.Windows.Forms.BindingSource userMasterBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Edit_Link;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit button_delete;
    }
}