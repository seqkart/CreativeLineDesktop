namespace WindowsFormsApplication1.Transaction
{
    partial class frmUpdateTimings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateTimings));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.dtInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.txtserial = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebitPartyName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDebitPartyCode = new DevExpress.XtraEditors.TextEdit();
            this.txtOutTime = new DevExpress.XtraEditors.TimeEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInTime = new DevExpress.XtraEditors.TimeEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtserial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInTime.Properties)).BeginInit();
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(583, 26);
            this.Menu_ToolStrip.TabIndex = 286;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnQuit.Size = new System.Drawing.Size(45, 23);
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 23);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.EditValue = null;
            this.dtInvoiceDate.Enabled = false;
            this.dtInvoiceDate.Location = new System.Drawing.Point(110, 59);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtInvoiceDate.Properties.Mask.EditMask = "";
            this.dtInvoiceDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtInvoiceDate.Size = new System.Drawing.Size(79, 20);
            this.dtInvoiceDate.TabIndex = 280;
            this.dtInvoiceDate.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 281;
            this.label2.Text = "Date";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(385, 60);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(148, 20);
            this.txtSerialNo.TabIndex = 283;
            this.txtSerialNo.TabStop = false;
            // 
            // txtserial
            // 
            this.txtserial.Enabled = false;
            this.txtserial.Location = new System.Drawing.Point(345, 60);
            this.txtserial.Name = "txtserial";
            this.txtserial.Size = new System.Drawing.Size(34, 20);
            this.txtserial.TabIndex = 282;
            this.txtserial.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 279;
            this.label1.Text = "CCI No";
            // 
            // txtDebitPartyName
            // 
            this.txtDebitPartyName.EnterMoveNextControl = true;
            this.txtDebitPartyName.Location = new System.Drawing.Point(210, 86);
            this.txtDebitPartyName.Name = "txtDebitPartyName";
            this.txtDebitPartyName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitPartyName.Properties.ReadOnly = true;
            this.txtDebitPartyName.Size = new System.Drawing.Size(322, 20);
            this.txtDebitPartyName.TabIndex = 284;
            this.txtDebitPartyName.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 287;
            this.label6.Text = "Debit Code";
            // 
            // txtDebitPartyCode
            // 
            this.txtDebitPartyCode.Enabled = false;
            this.txtDebitPartyCode.Location = new System.Drawing.Point(109, 87);
            this.txtDebitPartyCode.Name = "txtDebitPartyCode";
            this.txtDebitPartyCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitPartyCode.Properties.MaxLength = 6;
            this.txtDebitPartyCode.Size = new System.Drawing.Size(78, 20);
            this.txtDebitPartyCode.TabIndex = 285;
            // 
            // txtOutTime
            // 
            this.txtOutTime.EditValue = new System.DateTime(2017, 6, 28, 0, 0, 0, 0);
            this.txtOutTime.Location = new System.Drawing.Point(421, 122);
            this.txtOutTime.Name = "txtOutTime";
            this.txtOutTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOutTime.Size = new System.Drawing.Size(100, 20);
            this.txtOutTime.TabIndex = 433;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 432;
            this.label3.Text = "Out Time";
            // 
            // txtInTime
            // 
            this.txtInTime.EditValue = new System.DateTime(2017, 6, 28, 0, 0, 0, 0);
            this.txtInTime.Location = new System.Drawing.Point(109, 122);
            this.txtInTime.Name = "txtInTime";
            this.txtInTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtInTime.Size = new System.Drawing.Size(80, 20);
            this.txtInTime.TabIndex = 431;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 430;
            this.label5.Text = "In Time";
            // 
            // frmUpdateTimings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 199);
            this.ControlBox = false;
            this.Controls.Add(this.txtOutTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.txtserial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDebitPartyName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDebitPartyCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmUpdateTimings";
            this.Load += new System.EventHandler(this.frmUpdateTimings_Load);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtserial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.DateEdit dtInvoiceDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private DevExpress.XtraEditors.TextEdit txtserial;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtDebitPartyName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDebitPartyCode;
        private DevExpress.XtraEditors.TimeEdit txtOutTime;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TimeEdit txtInTime;
        private System.Windows.Forms.Label label5;

    }
}