namespace SEQKARTBIO
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdOpen = new System.Windows.Forms.Button();
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain = new System.Windows.Forms.GroupBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdLogData = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lbSubject = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.txtDevId = new System.Windows.Forms.TextBox();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblPortNo = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.Frame4 = new System.Windows.Forms.GroupBox();
            this.cmbMachineNumber = new System.Windows.Forms.ComboBox();
            this.lblMachineNumber = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SBXPC1 = new AxSBXPCLib.AxSBXPC();
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.SuspendLayout();
            this.Frame2.SuspendLayout();
            this.Frame4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SBXPC1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOpen
            // 
            this.cmdOpen.AutoSize = true;
            this.cmdOpen.BackColor = System.Drawing.Color.Transparent;
            this.cmdOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOpen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOpen.Location = new System.Drawing.Point(268, 19);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOpen.Size = new System.Drawing.Size(97, 32);
            this.cmdOpen.TabIndex = 23;
            this.cmdOpen.Text = "CONNECT";
            this.cmdOpen.UseVisualStyleBackColor = false;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain
            // 
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.BackColor = System.Drawing.Color.Transparent;
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Controls.Add(this.cmdExit);
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Controls.Add(this.cmdLogData);
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Location = new System.Drawing.Point(11, 133);
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Name = "frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmM" +
    "ainfrmMainfrmMainfrmMain";
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Padding = new System.Windows.Forms.Padding(0);
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Size = new System.Drawing.Size(522, 75);
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.TabIndex = 21;
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.TabStop = false;
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.Text = "Data Group";
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdExit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdExit.Location = new System.Drawing.Point(257, 29);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdExit.Size = new System.Drawing.Size(236, 32);
            this.cmdExit.TabIndex = 5;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdLogData
            // 
            this.cmdLogData.BackColor = System.Drawing.SystemColors.Control;
            this.cmdLogData.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdLogData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLogData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdLogData.Location = new System.Drawing.Point(16, 29);
            this.cmdLogData.Name = "cmdLogData";
            this.cmdLogData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdLogData.Size = new System.Drawing.Size(236, 32);
            this.cmdLogData.TabIndex = 4;
            this.cmdLogData.Text = "Log Data";
            this.cmdLogData.UseVisualStyleBackColor = false;
            this.cmdLogData.Click += new System.EventHandler(this.cmdLogData_Click);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.AcceptsReturn = true;
            this.txtIPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIPAddress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIPAddress.Location = new System.Drawing.Point(115, 20);
            this.txtIPAddress.MaxLength = 0;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIPAddress.Size = new System.Drawing.Size(113, 27);
            this.txtIPAddress.TabIndex = 8;
            this.txtIPAddress.Text = "192.168.1.150";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Blue;
            this.Label1.Location = new System.Drawing.Point(386, 54);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(163, 22);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "VERSION: V101.1";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.BackColor = System.Drawing.Color.Transparent;
            this.lbSubject.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbSubject.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubject.ForeColor = System.Drawing.Color.Red;
            this.lbSubject.Location = new System.Drawing.Point(144, 23);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbSubject.Size = new System.Drawing.Size(409, 31);
            this.lbSubject.TabIndex = 20;
            this.lbSubject.Text = "SEQKART BIO-MACH LINKER";
            this.lbSubject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsReturn = true;
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Location = new System.Drawing.Point(115, 52);
            this.txtPassword.MaxLength = 0;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(113, 27);
            this.txtPassword.TabIndex = 17;
            this.txtPassword.Text = "12345";
            // 
            // Frame2
            // 
            this.Frame2.BackColor = System.Drawing.Color.Transparent;
            this.Frame2.Controls.Add(this.txtDevId);
            this.Frame2.Controls.Add(this.txtPassword);
            this.Frame2.Controls.Add(this.txtIPAddress);
            this.Frame2.Controls.Add(this.txtPortNo);
            this.Frame2.Controls.Add(this.label2);
            this.Frame2.Controls.Add(this.lblPassword);
            this.Frame2.Controls.Add(this.lblIPAddress);
            this.Frame2.Controls.Add(this.lblPortNo);
            this.Frame2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame2.Location = new System.Drawing.Point(11, 214);
            this.Frame2.Name = "Frame2";
            this.Frame2.Padding = new System.Windows.Forms.Padding(0);
            this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame2.Size = new System.Drawing.Size(522, 94);
            this.Frame2.TabIndex = 22;
            this.Frame2.TabStop = false;
            this.Frame2.Text = "  IP Address";
            // 
            // txtDevId
            // 
            this.txtDevId.AcceptsReturn = true;
            this.txtDevId.BackColor = System.Drawing.SystemColors.Window;
            this.txtDevId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDevId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDevId.Location = new System.Drawing.Point(363, 52);
            this.txtDevId.MaxLength = 0;
            this.txtDevId.Name = "txtDevId";
            this.txtDevId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDevId.Size = new System.Drawing.Size(113, 27);
            this.txtDevId.TabIndex = 17;
            this.txtDevId.Text = "rss1030029868";
            // 
            // txtPortNo
            // 
            this.txtPortNo.AcceptsReturn = true;
            this.txtPortNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPortNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPortNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPortNo.Location = new System.Drawing.Point(363, 20);
            this.txtPortNo.MaxLength = 0;
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPortNo.Size = new System.Drawing.Size(113, 27);
            this.txtPortNo.TabIndex = 7;
            this.txtPortNo.Text = "5005";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(280, 56);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Device ID :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPassword.Location = new System.Drawing.Point(30, 56);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPassword.Size = new System.Drawing.Size(82, 19);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Password :";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblIPAddress.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblIPAddress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIPAddress.Location = new System.Drawing.Point(24, 24);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblIPAddress.Size = new System.Drawing.Size(88, 19);
            this.lblIPAddress.TabIndex = 10;
            this.lblIPAddress.Text = "IP Address :";
            // 
            // lblPortNo
            // 
            this.lblPortNo.AutoSize = true;
            this.lblPortNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPortNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPortNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPortNo.Location = new System.Drawing.Point(253, 24);
            this.lblPortNo.Name = "lblPortNo";
            this.lblPortNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPortNo.Size = new System.Drawing.Size(107, 19);
            this.lblPortNo.TabIndex = 9;
            this.lblPortNo.Text = "Port Number :";
            // 
            // cmdClose
            // 
            this.cmdClose.AutoSize = true;
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdClose.Location = new System.Drawing.Point(378, 19);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdClose.Size = new System.Drawing.Size(124, 32);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Text = "DISCONNECT";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // Frame4
            // 
            this.Frame4.BackColor = System.Drawing.Color.Transparent;
            this.Frame4.Controls.Add(this.cmdOpen);
            this.Frame4.Controls.Add(this.cmdClose);
            this.Frame4.Controls.Add(this.cmbMachineNumber);
            this.Frame4.Controls.Add(this.lblMachineNumber);
            this.Frame4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame4.Location = new System.Drawing.Point(12, 68);
            this.Frame4.Name = "Frame4";
            this.Frame4.Padding = new System.Windows.Forms.Padding(0);
            this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame4.Size = new System.Drawing.Size(524, 61);
            this.Frame4.TabIndex = 27;
            this.Frame4.TabStop = false;
            this.Frame4.Text = "Connect";
            // 
            // cmbMachineNumber
            // 
            this.cmbMachineNumber.BackColor = System.Drawing.SystemColors.Window;
            this.cmbMachineNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbMachineNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachineNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMachineNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMachineNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbMachineNumber.Location = new System.Drawing.Point(156, 22);
            this.cmbMachineNumber.Name = "cmbMachineNumber";
            this.cmbMachineNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbMachineNumber.Size = new System.Drawing.Size(89, 27);
            this.cmbMachineNumber.TabIndex = 20;
            // 
            // lblMachineNumber
            // 
            this.lblMachineNumber.AutoSize = true;
            this.lblMachineNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblMachineNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMachineNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMachineNumber.Location = new System.Drawing.Point(14, 26);
            this.lblMachineNumber.Name = "lblMachineNumber";
            this.lblMachineNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMachineNumber.Size = new System.Drawing.Size(136, 19);
            this.lblMachineNumber.TabIndex = 21;
            this.lblMachineNumber.Text = "Machine Number :";
            // 
            // SBXPC1
            // 
            this.SBXPC1.Enabled = true;
            this.SBXPC1.Location = new System.Drawing.Point(12, 23);
            this.SBXPC1.Name = "SBXPC1";
            this.SBXPC1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SBXPC1.OcxState")));
            this.SBXPC1.Size = new System.Drawing.Size(100, 31);
            this.SBXPC1.TabIndex = 28;
            this.SBXPC1.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SEQKARTBIO.Properties.Resources.login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(696, 357);
            this.Controls.Add(this.SBXPC1);
            this.Controls.Add(this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.Frame2);
            this.Controls.Add(this.Frame4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "BIOMETRIC MACHINE LINKER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain.ResumeLayout(false);
            this.Frame2.ResumeLayout(false);
            this.Frame2.PerformLayout();
            this.Frame4.ResumeLayout(false);
            this.Frame4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SBXPC1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cmdOpen;
        public System.Windows.Forms.GroupBox frmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMainfrmMain;
        public System.Windows.Forms.Button cmdExit;
        public System.Windows.Forms.Button cmdLogData;
        public System.Windows.Forms.TextBox txtIPAddress;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label lbSubject;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.GroupBox Frame2;
        public System.Windows.Forms.TextBox txtPortNo;
        public System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.Label lblIPAddress;
        public System.Windows.Forms.Label lblPortNo;
        public System.Windows.Forms.Button cmdClose;
        public System.Windows.Forms.GroupBox Frame4;
        public System.Windows.Forms.ComboBox cmbMachineNumber;
        public System.Windows.Forms.Label lblMachineNumber;
        public System.Windows.Forms.ToolTip ToolTip1;
        private AxSBXPCLib.AxSBXPC SBXPC1;
        public System.Windows.Forms.TextBox txtDevId;
        public System.Windows.Forms.Label label2;

    }
}

