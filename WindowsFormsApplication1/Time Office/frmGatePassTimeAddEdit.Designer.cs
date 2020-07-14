namespace BNPL.Forms_Transaction
{
    partial class frmGatePassTimeAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGatePassTimeAddEdit));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtPassword = new System.Windows.Forms.ToolStripTextBox();
            this.txtStatusCode = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpCodeDesc = new DevExpress.XtraEditors.TextEdit();
            this.DtDate = new DevExpress.XtraEditors.DateEdit();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timeEdit_Time_In = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit_Time_Out = new DevExpress.XtraEditors.TimeEdit();
            this.txtStatusCodeDesc = new DevExpress.XtraEditors.TextEdit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCodeDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_In.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_Out.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCodeDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.btnSave,
            this.txtPassword});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.Size = new System.Drawing.Size(471, 25);
            this.Menu_ToolStrip.TabIndex = 16;
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
            this.btnQuit.Size = new System.Drawing.Size(40, 22);
            this.btnQuit.Text = "Close";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 22);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(100, 25);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtStatusCode
            // 
            this.txtStatusCode.EnterMoveNextControl = true;
            this.txtStatusCode.Location = new System.Drawing.Point(82, 127);
            this.txtStatusCode.Name = "txtStatusCode";
            this.txtStatusCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatusCode.Properties.MaxLength = 6;
            this.txtStatusCode.Size = new System.Drawing.Size(100, 20);
            this.txtStatusCode.TabIndex = 10;
            this.txtStatusCode.EditValueChanged += new System.EventHandler(this.txtStatusCode_EditValueChanged);
            this.txtStatusCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStatusCode_KeyDown);
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.EnterMoveNextControl = true;
            this.txtEmpCode.Location = new System.Drawing.Point(82, 98);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Properties.MaxLength = 6;
            this.txtEmpCode.Size = new System.Drawing.Size(100, 20);
            this.txtEmpCode.TabIndex = 8;
            this.txtEmpCode.EditValueChanged += new System.EventHandler(this.txtEmpCode_EditValueChanged);
            this.txtEmpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpCode_KeyDown);
            // 
            // labelControl35
            // 
            this.labelControl35.Location = new System.Drawing.Point(42, 131);
            this.labelControl35.Name = "labelControl35";
            this.labelControl35.Size = new System.Drawing.Size(32, 13);
            this.labelControl35.TabIndex = 29;
            this.labelControl35.Text = "Status";
            // 
            // labelControl33
            // 
            this.labelControl33.Location = new System.Drawing.Point(50, 72);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(24, 13);
            this.labelControl33.TabIndex = 30;
            this.labelControl33.Text = "Date";
            // 
            // labelControl34
            // 
            this.labelControl34.Location = new System.Drawing.Point(22, 101);
            this.labelControl34.Name = "labelControl34";
            this.labelControl34.Size = new System.Drawing.Size(52, 13);
            this.labelControl34.TabIndex = 27;
            this.labelControl34.Text = "Emp Code";
            // 
            // txtEmpCodeDesc
            // 
            this.txtEmpCodeDesc.Enabled = false;
            this.txtEmpCodeDesc.Location = new System.Drawing.Point(188, 98);
            this.txtEmpCodeDesc.Name = "txtEmpCodeDesc";
            this.txtEmpCodeDesc.Properties.MaxLength = 6;
            this.txtEmpCodeDesc.Size = new System.Drawing.Size(200, 20);
            this.txtEmpCodeDesc.TabIndex = 9;
            this.txtEmpCodeDesc.TabStop = false;
            // 
            // DtDate
            // 
            this.DtDate.EditValue = null;
            this.DtDate.EnterMoveNextControl = true;
            this.DtDate.Location = new System.Drawing.Point(82, 69);
            this.DtDate.Name = "DtDate";
            this.DtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.DtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.DtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.DtDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtDate.Size = new System.Drawing.Size(100, 20);
            this.DtDate.TabIndex = 32;
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(80, 328);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(391, 197);
            this.HelpGrid.TabIndex = 368;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView,
            this.gridView4,
            this.gridView5});
            this.HelpGrid.Visible = false;
            this.HelpGrid.DoubleClick += new System.EventHandler(this.HelpGrid_DoubleClick);
            this.HelpGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HelpGrid_KeyDown);
            // 
            // HelpGridView
            // 
            this.HelpGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.HelpGridView.GridControl = this.HelpGrid;
            this.HelpGridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.HelpGridView.Name = "HelpGridView";
            this.HelpGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.HelpGridView.OptionsBehavior.Editable = false;
            this.HelpGridView.OptionsView.ShowGroupPanel = false;
            this.HelpGridView.OptionsView.ShowIndicator = false;
            this.HelpGridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.HelpGrid;
            this.gridView4.Name = "gridView4";
            // 
            // gridView5
            // 
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.GridControl = this.HelpGrid;
            this.gridView5.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsView.ColumnAutoWidth = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            this.gridView5.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // timeEdit_Time_In
            // 
            this.timeEdit_Time_In.EditValue = "00:00";
            this.timeEdit_Time_In.Location = new System.Drawing.Point(256, 155);
            this.timeEdit_Time_In.Name = "timeEdit_Time_In";
            this.timeEdit_Time_In.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.timeEdit_Time_In.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.timeEdit_Time_In.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.timeEdit_Time_In.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeEdit_Time_In.Properties.Appearance.Options.UseBackColor = true;
            this.timeEdit_Time_In.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_Time_In.Properties.Appearance.Options.UseForeColor = true;
            this.timeEdit_Time_In.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_Time_In.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEdit_Time_In.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_In.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEdit_Time_In.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_In.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_Time_In.Size = new System.Drawing.Size(100, 20);
            this.timeEdit_Time_In.TabIndex = 372;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(210, 158);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(38, 13);
            this.labelControl12.TabIndex = 370;
            this.labelControl12.Text = "Time In";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(27, 158);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(47, 13);
            this.labelControl10.TabIndex = 371;
            this.labelControl10.Text = "Time Out";
            // 
            // timeEdit_Time_Out
            // 
            this.timeEdit_Time_Out.EditValue = "00:00";
            this.timeEdit_Time_Out.Location = new System.Drawing.Point(82, 155);
            this.timeEdit_Time_Out.Name = "timeEdit_Time_Out";
            this.timeEdit_Time_Out.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.timeEdit_Time_Out.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.timeEdit_Time_Out.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.timeEdit_Time_Out.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeEdit_Time_Out.Properties.Appearance.Options.UseBackColor = true;
            this.timeEdit_Time_Out.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_Time_Out.Properties.Appearance.Options.UseForeColor = true;
            this.timeEdit_Time_Out.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_Time_Out.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEdit_Time_Out.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_Out.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEdit_Time_Out.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_Out.Properties.NullText = "00:00";
            this.timeEdit_Time_Out.Properties.NullValuePrompt = "00:00";
            this.timeEdit_Time_Out.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_Time_Out.Size = new System.Drawing.Size(100, 20);
            this.timeEdit_Time_Out.TabIndex = 369;
            // 
            // txtStatusCodeDesc
            // 
            this.txtStatusCodeDesc.Enabled = false;
            this.txtStatusCodeDesc.Location = new System.Drawing.Point(188, 127);
            this.txtStatusCodeDesc.Name = "txtStatusCodeDesc";
            this.txtStatusCodeDesc.Properties.MaxLength = 6;
            this.txtStatusCodeDesc.Size = new System.Drawing.Size(200, 20);
            this.txtStatusCodeDesc.TabIndex = 373;
            this.txtStatusCodeDesc.TabStop = false;
            // 
            // frmGatePassTimeAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 548);
            this.ControlBox = false;
            this.Controls.Add(this.txtStatusCodeDesc);
            this.Controls.Add(this.timeEdit_Time_In);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.timeEdit_Time_Out);
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.DtDate);
            this.Controls.Add(this.txtStatusCode);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.txtEmpCodeDesc);
            this.Controls.Add(this.labelControl35);
            this.Controls.Add(this.labelControl33);
            this.Controls.Add(this.labelControl34);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmGatePassTimeAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmGatePassTimeAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGatePassTimeAddEdit_KeyDown);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCodeDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_In.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_Out.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCodeDesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripTextBox txtPassword;
        private DevExpress.XtraEditors.TextEdit txtStatusCode;
        private DevExpress.XtraEditors.TextEdit txtEmpCode;
        private DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraEditors.LabelControl labelControl34;
        private DevExpress.XtraEditors.TextEdit txtEmpCodeDesc;
        private DevExpress.XtraEditors.DateEdit DtDate;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.TimeEdit timeEdit_Time_In;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TimeEdit timeEdit_Time_Out;
        private DevExpress.XtraEditors.TextEdit txtStatusCodeDesc;
    }
}