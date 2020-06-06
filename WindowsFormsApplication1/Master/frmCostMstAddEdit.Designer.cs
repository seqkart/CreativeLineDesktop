namespace WindowsFormsApplication1
{
    partial class frmCostMstAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostMstAddEdit));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtCGrpDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtCSGrpCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCSGrpDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtCGrpCode = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGrpDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSGrpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSGrpDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGrpCode.Properties)).BeginInit();
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(588, 25);
            this.Menu_ToolStrip.TabIndex = 250;
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
            // txtCGrpDesc
            // 
            this.txtCGrpDesc.Location = new System.Drawing.Point(189, 113);
            this.txtCGrpDesc.Name = "txtCGrpDesc";
            this.txtCGrpDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCGrpDesc.Properties.MaxLength = 50;
            this.txtCGrpDesc.Size = new System.Drawing.Size(364, 20);
            this.txtCGrpDesc.TabIndex = 244;
            this.txtCGrpDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCGrpDesc_KeyPress);
            // 
            // txtCSGrpCode
            // 
            this.txtCSGrpCode.Location = new System.Drawing.Point(189, 86);
            this.txtCSGrpCode.Name = "txtCSGrpCode";
            this.txtCSGrpCode.Properties.MaxLength = 4;
            this.txtCSGrpCode.Size = new System.Drawing.Size(71, 20);
            this.txtCSGrpCode.TabIndex = 243;
            this.txtCSGrpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCSGrpCode_KeyPress);
            this.txtCSGrpCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCSGrpCode_KeyUp);
            // 
            // txtCSGrpDesc
            // 
            this.txtCSGrpDesc.Location = new System.Drawing.Point(189, 139);
            this.txtCSGrpDesc.Name = "txtCSGrpDesc";
            this.txtCSGrpDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCSGrpDesc.Properties.MaxLength = 50;
            this.txtCSGrpDesc.Size = new System.Drawing.Size(364, 20);
            this.txtCSGrpDesc.TabIndex = 245;
            this.txtCSGrpDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCGrpDesc_KeyPress);
            // 
            // txtCGrpCode
            // 
            this.txtCGrpCode.Location = new System.Drawing.Point(189, 60);
            this.txtCGrpCode.Name = "txtCGrpCode";
            this.txtCGrpCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCGrpCode.Properties.MaxLength = 4;
            this.txtCGrpCode.Size = new System.Drawing.Size(71, 20);
            this.txtCGrpCode.TabIndex = 242;
            this.txtCGrpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCGrpCode_KeyDown);
            this.txtCGrpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCSGrpCode_KeyPress);
            this.txtCGrpCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCGrpCode_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 249;
            this.label9.Text = "Cost Group Desc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 248;
            this.label8.Text = "Cost Sub Group Desc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 247;
            this.label3.Text = "Cost Sub Group Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 246;
            this.label1.Text = "Cost Group Code";
            // 
            // frmCostMstAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 196);
            this.ControlBox = false;
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtCGrpDesc);
            this.Controls.Add(this.txtCSGrpCode);
            this.Controls.Add(this.txtCSGrpDesc);
            this.Controls.Add(this.txtCGrpCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmCostMstAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmCostMstAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCostMstAddEdit_KeyDown);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGrpDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSGrpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCSGrpDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGrpCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtCGrpDesc;
        private DevExpress.XtraEditors.TextEdit txtCSGrpCode;
        private DevExpress.XtraEditors.TextEdit txtCSGrpDesc;
        private DevExpress.XtraEditors.TextEdit txtCGrpCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}