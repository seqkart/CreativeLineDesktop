namespace WindowsFormsApplication1
{
    partial class frmVehicleAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleAddEdit));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtRegNo = new DevExpress.XtraEditors.TextEdit();
            this.txtVehicleDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtVehicleCode = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCrates = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrates.Properties)).BeginInit();
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(519, 25);
            this.Menu_ToolStrip.TabIndex = 202;
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
            // txtRegNo
            // 
            this.txtRegNo.Location = new System.Drawing.Point(114, 107);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegNo.Size = new System.Drawing.Size(87, 20);
            this.txtRegNo.TabIndex = 3;
            // 
            // txtVehicleDesc
            // 
            this.txtVehicleDesc.Location = new System.Drawing.Point(114, 76);
            this.txtVehicleDesc.Name = "txtVehicleDesc";
            this.txtVehicleDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVehicleDesc.Size = new System.Drawing.Size(383, 20);
            this.txtVehicleDesc.TabIndex = 2;
            // 
            // txtVehicleCode
            // 
            this.txtVehicleCode.Enabled = false;
            this.txtVehicleCode.Location = new System.Drawing.Point(114, 46);
            this.txtVehicleCode.Name = "txtVehicleCode";
            this.txtVehicleCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVehicleCode.Size = new System.Drawing.Size(87, 20);
            this.txtVehicleCode.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 199;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 198;
            this.label2.Text = "Regn No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 197;
            this.label1.Text = "Code";
            // 
            // txtCrates
            // 
            this.txtCrates.Location = new System.Drawing.Point(410, 107);
            this.txtCrates.Name = "txtCrates";
            this.txtCrates.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCrates.Size = new System.Drawing.Size(87, 20);
            this.txtCrates.TabIndex = 203;
            this.txtCrates.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrates_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 204;
            this.label4.Text = "No Of Crates";
            // 
            // frmVehicleAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 152);
            this.ControlBox = false;
            this.Controls.Add(this.txtCrates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtRegNo);
            this.Controls.Add(this.txtVehicleDesc);
            this.Controls.Add(this.txtVehicleCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmVehicleAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmVehicleAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVehicleAddEdit_KeyDown);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrates.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtRegNo;
        private DevExpress.XtraEditors.TextEdit txtVehicleDesc;
        private DevExpress.XtraEditors.TextEdit txtVehicleCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtCrates;
        private System.Windows.Forms.Label label4;
    }
}