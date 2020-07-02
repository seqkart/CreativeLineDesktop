namespace WindowsFormsApplication1
{
    partial class frmDepartmentAddUpdate
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
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtDeptCode = new DevExpress.XtraEditors.TextEdit();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Image = global::WindowsFormsApplication1.Properties.Resources.Close;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(56, 22);
            this.btnQuit.Text = "Close";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(362, 25);
            this.Menu_ToolStrip.TabIndex = 203;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.EnterMoveNextControl = true;
            this.txtDesc.Location = new System.Drawing.Point(90, 60);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc.Properties.MaxLength = 40;
            this.txtDesc.Size = new System.Drawing.Size(209, 20);
            this.txtDesc.TabIndex = 198;
            // 
            // txtDeptCode
            // 
            this.txtDeptCode.Location = new System.Drawing.Point(90, 34);
            this.txtDeptCode.Name = "txtDeptCode";
            this.txtDeptCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDeptCode.Size = new System.Drawing.Size(70, 20);
            this.txtDeptCode.TabIndex = 197;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemarks.Location = new System.Drawing.Point(90, 88);
            this.txtRemarks.MaxLength = 60;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(209, 96);
            this.txtRemarks.TabIndex = 199;
            this.txtRemarks.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 201;
            this.label2.Text = "Remarks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "Code";
            // 
            // frmDepartmentAddUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 227);
            this.ControlBox = false;
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtDeptCode);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmDepartmentAddUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmDepartmentAddUpdate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDepartmentAddUpdate_KeyDown);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeptCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtDesc;
        private DevExpress.XtraEditors.TextEdit txtDeptCode;
        private System.Windows.Forms.RichTextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}