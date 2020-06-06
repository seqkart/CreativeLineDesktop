namespace WindowsFormsApplication1
{
    partial class frmColors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColors));
            this.txtColorName = new DevExpress.XtraEditors.TextEdit();
            this.txtSysColorID = new DevExpress.XtraEditors.TextEdit();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtColorCode = new DevExpress.XtraEditors.TextEdit();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.Label7 = new System.Windows.Forms.Label();
            this.LBDEPCODE = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSysColorID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorCode.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtColorName
            // 
            this.txtColorName.EnterMoveNextControl = true;
            this.txtColorName.Location = new System.Drawing.Point(136, 139);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColorName.Size = new System.Drawing.Size(271, 20);
            this.txtColorName.TabIndex = 771;
            // 
            // txtSysColorID
            // 
            this.txtSysColorID.Enabled = false;
            this.txtSysColorID.EnterMoveNextControl = true;
            this.txtSysColorID.Location = new System.Drawing.Point(136, 86);
            this.txtSysColorID.Name = "txtSysColorID";
            this.txtSysColorID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSysColorID.Properties.MaxLength = 8;
            this.txtSysColorID.Size = new System.Drawing.Size(74, 20);
            this.txtSysColorID.TabIndex = 760;
            this.txtSysColorID.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label3.Location = new System.Drawing.Point(53, 115);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 15);
            this.Label3.TabIndex = 757;
            this.Label3.Text = "Color Code :";
            // 
            // txtColorCode
            // 
            this.txtColorCode.EnterMoveNextControl = true;
            this.txtColorCode.Location = new System.Drawing.Point(136, 112);
            this.txtColorCode.Name = "txtColorCode";
            this.txtColorCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColorCode.Size = new System.Drawing.Size(271, 20);
            this.txtColorCode.TabIndex = 765;
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(460, 26);
            this.Menu_ToolStrip.TabIndex = 767;
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
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Label7.Location = new System.Drawing.Point(46, 141);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(79, 15);
            this.Label7.TabIndex = 754;
            this.Label7.Text = "Color Name :";
            // 
            // LBDEPCODE
            // 
            this.LBDEPCODE.AutoSize = true;
            this.LBDEPCODE.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.LBDEPCODE.Location = new System.Drawing.Point(36, 89);
            this.LBDEPCODE.Name = "LBDEPCODE";
            this.LBDEPCODE.Size = new System.Drawing.Size(94, 15);
            this.LBDEPCODE.TabIndex = 756;
            this.LBDEPCODE.Text = "Sys Color Code :";
            // 
            // frmColors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 204);
            this.ControlBox = false;
            this.Controls.Add(this.txtColorName);
            this.Controls.Add(this.txtSysColorID);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtColorCode);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.LBDEPCODE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmColors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FrmColors_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmColors_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSysColorID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorCode.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtColorName;
        private DevExpress.XtraEditors.TextEdit txtSysColorID;
        internal System.Windows.Forms.Label Label3;
        private DevExpress.XtraEditors.TextEdit txtColorCode;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label LBDEPCODE;
    }
}