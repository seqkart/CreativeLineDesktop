namespace WindowsFormsApplication1
{
    partial class frmWorkerMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkerMaster));
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.LBDEPNAME = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.LBDEPCODE = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtWorkerCode = new DevExpress.XtraEditors.TextEdit();
            this.txtEMailId = new DevExpress.XtraEditors.TextEdit();
            this.txtMobileNo = new DevExpress.XtraEditors.TextEdit();
            this.txtContractorDesc = new DevExpress.XtraEditors.TextEdit();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtWorkerName = new DevExpress.XtraEditors.TextEdit();
            this.txtContractorCode = new DevExpress.XtraEditors.TextEdit();
            this.txtOtherNo = new DevExpress.XtraEditors.TextEdit();
            this.txtFloorCode = new DevExpress.XtraEditors.TextEdit();
            this.txtIDType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtIDNo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMailId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractorDesc.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label2.Location = new System.Drawing.Point(45, 104);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 15);
            this.Label2.TabIndex = 628;
            this.Label2.Text = "CONTRACTOR :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label4.Location = new System.Drawing.Point(321, 154);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 15);
            this.Label4.TabIndex = 605;
            this.Label4.Text = "OTHER NO :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label3.Location = new System.Drawing.Point(72, 181);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(62, 15);
            this.Label3.TabIndex = 597;
            this.Label3.Text = "EMAIL ID :";
            // 
            // LBDEPNAME
            // 
            this.LBDEPNAME.AutoSize = true;
            this.LBDEPNAME.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LBDEPNAME.Location = new System.Drawing.Point(86, 131);
            this.LBDEPNAME.Name = "LBDEPNAME";
            this.LBDEPNAME.Size = new System.Drawing.Size(48, 15);
            this.LBDEPNAME.TabIndex = 32;
            this.LBDEPNAME.Text = "NAME :";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label7.Location = new System.Drawing.Point(44, 209);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(90, 15);
            this.Label7.TabIndex = 32;
            this.Label7.Text = "ID TYPE && NO. :";
            // 
            // LBDEPCODE
            // 
            this.LBDEPCODE.AutoSize = true;
            this.LBDEPCODE.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LBDEPCODE.Location = new System.Drawing.Point(90, 79);
            this.LBDEPCODE.Name = "LBDEPCODE";
            this.LBDEPCODE.Size = new System.Drawing.Size(44, 15);
            this.LBDEPCODE.TabIndex = 32;
            this.LBDEPCODE.Text = "CODE :";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label6.Location = new System.Drawing.Point(57, 156);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(77, 15);
            this.Label6.TabIndex = 32;
            this.Label6.Text = "MOBILE NO :";
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(144, 22);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(470, 261);
            this.HelpGrid.TabIndex = 744;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView});
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
            // txtWorkerCode
            // 
            this.txtWorkerCode.Enabled = false;
            this.txtWorkerCode.EnterMoveNextControl = true;
            this.txtWorkerCode.Location = new System.Drawing.Point(144, 77);
            this.txtWorkerCode.Name = "txtWorkerCode";
            this.txtWorkerCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWorkerCode.Properties.MaxLength = 8;
            this.txtWorkerCode.Size = new System.Drawing.Size(74, 20);
            this.txtWorkerCode.TabIndex = 718;
            this.txtWorkerCode.TabStop = false;
            // 
            // txtEMailId
            // 
            this.txtEMailId.EnterMoveNextControl = true;
            this.txtEMailId.Location = new System.Drawing.Point(144, 180);
            this.txtEMailId.Name = "txtEMailId";
            this.txtEMailId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEMailId.Size = new System.Drawing.Size(410, 20);
            this.txtEMailId.TabIndex = 726;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.EnterMoveNextControl = true;
            this.txtMobileNo.Location = new System.Drawing.Point(144, 154);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMobileNo.Size = new System.Drawing.Size(171, 20);
            this.txtMobileNo.TabIndex = 725;
            // 
            // txtContractorDesc
            // 
            this.txtContractorDesc.Enabled = false;
            this.txtContractorDesc.EnterMoveNextControl = true;
            this.txtContractorDesc.Location = new System.Drawing.Point(224, 103);
            this.txtContractorDesc.Name = "txtContractorDesc";
            this.txtContractorDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContractorDesc.Properties.MaxLength = 8;
            this.txtContractorDesc.Size = new System.Drawing.Size(330, 20);
            this.txtContractorDesc.TabIndex = 720;
            this.txtContractorDesc.TabStop = false;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.btnSave});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(614, 26);
            this.Menu_ToolStrip.TabIndex = 745;
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
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.EnterMoveNextControl = true;
            this.txtWorkerName.Location = new System.Drawing.Point(144, 128);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWorkerName.Size = new System.Drawing.Size(306, 20);
            this.txtWorkerName.TabIndex = 724;
            // 
            // txtContractorCode
            // 
            this.txtContractorCode.EnterMoveNextControl = true;
            this.txtContractorCode.Location = new System.Drawing.Point(144, 103);
            this.txtContractorCode.Name = "txtContractorCode";
            this.txtContractorCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContractorCode.Properties.MaxLength = 8;
            this.txtContractorCode.Size = new System.Drawing.Size(74, 20);
            this.txtContractorCode.TabIndex = 719;
            this.txtContractorCode.EditValueChanged += new System.EventHandler(this.TxtContractorCode_EditValueChanged);
            this.txtContractorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtContractorCode_KeyDown);
            // 
            // txtOtherNo
            // 
            this.txtOtherNo.EnterMoveNextControl = true;
            this.txtOtherNo.Location = new System.Drawing.Point(397, 153);
            this.txtOtherNo.Name = "txtOtherNo";
            this.txtOtherNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtherNo.Size = new System.Drawing.Size(157, 20);
            this.txtOtherNo.TabIndex = 749;
            // 
            // txtFloorCode
            // 
            this.txtFloorCode.EnterMoveNextControl = true;
            this.txtFloorCode.Location = new System.Drawing.Point(456, 129);
            this.txtFloorCode.Name = "txtFloorCode";
            this.txtFloorCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFloorCode.Size = new System.Drawing.Size(98, 20);
            this.txtFloorCode.TabIndex = 750;
            // 
            // txtIDType
            // 
            this.txtIDType.Location = new System.Drawing.Point(144, 207);
            this.txtIDType.Name = "txtIDType";
            this.txtIDType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtIDType.Properties.Items.AddRange(new object[] {
            "N/A",
            "AADHAR ID",
            "VOTER ID",
            "PASSPORT",
            "OTHER ID",
            "LISCENSE"});
            this.txtIDType.Size = new System.Drawing.Size(171, 20);
            this.txtIDType.TabIndex = 751;
            // 
            // txtIDNo
            // 
            this.txtIDNo.EnterMoveNextControl = true;
            this.txtIDNo.Location = new System.Drawing.Point(397, 207);
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDNo.Size = new System.Drawing.Size(157, 20);
            this.txtIDNo.TabIndex = 752;
            // 
            // frmWorkerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 286);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.txtIDNo);
            this.Controls.Add(this.txtIDType);
            this.Controls.Add(this.txtFloorCode);
            this.Controls.Add(this.txtOtherNo);
            this.Controls.Add(this.txtWorkerCode);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtEMailId);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.txtContractorDesc);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtWorkerName);
            this.Controls.Add(this.txtContractorCode);
            this.Controls.Add(this.LBDEPNAME);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.LBDEPCODE);
            this.Controls.Add(this.Label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmWorkerMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FrmWorkerMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmWorkerMaster_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMailId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobileNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractorDesc.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContractorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label LBDEPNAME;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label LBDEPCODE;
        internal System.Windows.Forms.Label Label6;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraEditors.TextEdit txtWorkerCode;
        private DevExpress.XtraEditors.TextEdit txtEMailId;
        private DevExpress.XtraEditors.TextEdit txtMobileNo;
        private DevExpress.XtraEditors.TextEdit txtContractorDesc;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtWorkerName;
        private DevExpress.XtraEditors.TextEdit txtContractorCode;
        private DevExpress.XtraEditors.TextEdit txtOtherNo;
        private DevExpress.XtraEditors.TextEdit txtFloorCode;
        private DevExpress.XtraEditors.ComboBoxEdit txtIDType;
        private DevExpress.XtraEditors.TextEdit txtIDNo;
    }
}