namespace WindowsFormsApplication1
{
    partial class frmGroupMstAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupMstAddEdit));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtGrpDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtSGrpCode = new DevExpress.XtraEditors.TextEdit();
            this.txtSGrpDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtGrpCode = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHSNCode = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHSNCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(548, 25);
            this.Menu_ToolStrip.TabIndex = 241;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(35, 22);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGrpDesc
            // 
            this.txtGrpDesc.Location = new System.Drawing.Point(135, 103);
            this.txtGrpDesc.Name = "txtGrpDesc";
            this.txtGrpDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrpDesc.Properties.MaxLength = 50;
            this.txtGrpDesc.Size = new System.Drawing.Size(364, 20);
            this.txtGrpDesc.TabIndex = 3;
            this.txtGrpDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrpDesc_KeyPress);
            this.txtGrpDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtGrpDesc_KeyUp);
            // 
            // txtSGrpCode
            // 
            this.txtSGrpCode.Location = new System.Drawing.Point(135, 77);
            this.txtSGrpCode.Name = "txtSGrpCode";
            this.txtSGrpCode.Properties.MaxLength = 4;
            this.txtSGrpCode.Size = new System.Drawing.Size(71, 20);
            this.txtSGrpCode.TabIndex = 2;
            // 
            // txtSGrpDesc
            // 
            this.txtSGrpDesc.Location = new System.Drawing.Point(135, 129);
            this.txtSGrpDesc.Name = "txtSGrpDesc";
            this.txtSGrpDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSGrpDesc.Properties.MaxLength = 50;
            this.txtSGrpDesc.Size = new System.Drawing.Size(364, 20);
            this.txtSGrpDesc.TabIndex = 4;
            this.txtSGrpDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSGrpDesc_KeyPress);
            // 
            // txtGrpCode
            // 
            this.txtGrpCode.Location = new System.Drawing.Point(135, 51);
            this.txtGrpCode.Name = "txtGrpCode";
            this.txtGrpCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrpCode.Properties.MaxLength = 4;
            this.txtGrpCode.Size = new System.Drawing.Size(71, 20);
            this.txtGrpCode.TabIndex = 1;
            this.txtGrpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrpCode_KeyDown);
            this.txtGrpCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtGrpCode_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 240;
            this.label9.Text = "Group Desc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 239;
            this.label8.Text = "Sub Group Desc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 237;
            this.label3.Text = "Sub Group Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 236;
            this.label1.Text = "Group Code";
            // 
            // txtHSNCode
            // 
            this.txtHSNCode.Location = new System.Drawing.Point(135, 155);
            this.txtHSNCode.Name = "txtHSNCode";
            this.txtHSNCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHSNCode.Properties.MaxLength = 12;
            this.txtHSNCode.Size = new System.Drawing.Size(364, 20);
            this.txtHSNCode.TabIndex = 242;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 243;
            this.label2.Text = "HSNCode";
            // 
            // frmGroupMstAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 191);
            this.ControlBox = false;
            this.Controls.Add(this.txtHSNCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtGrpDesc);
            this.Controls.Add(this.txtSGrpCode);
            this.Controls.Add(this.txtSGrpDesc);
            this.Controls.Add(this.txtGrpCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGroupMstAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmGroupMstAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGroupMstAddEdit_KeyDown);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHSNCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtGrpDesc;
        private DevExpress.XtraEditors.TextEdit txtSGrpCode;
        private DevExpress.XtraEditors.TextEdit txtSGrpDesc;
        private DevExpress.XtraEditors.TextEdit txtGrpCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtHSNCode;
        private System.Windows.Forms.Label label2;
    }
}