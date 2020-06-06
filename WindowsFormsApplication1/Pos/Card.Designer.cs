namespace WindowsFormsApplication1.Transaction.Pos
{
    partial class Card
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Card));
            this.Btmaestro = new DevExpress.XtraEditors.SimpleButton();
            this.Btamex = new DevExpress.XtraEditors.SimpleButton();
            this.Btvisa = new DevExpress.XtraEditors.SimpleButton();
            this.Btmaster = new DevExpress.XtraEditors.SimpleButton();
            this.Btdci = new DevExpress.XtraEditors.SimpleButton();
            this.txtCardType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCardNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNameOnCard = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl50 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl49 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl48 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl47 = new DevExpress.XtraEditors.LabelControl();
            this.txtBalanceAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtSLipNo = new DevExpress.XtraEditors.TextEdit();
            this.txtAmountPaid = new DevExpress.XtraEditors.TextEdit();
            this.txtMemoAmount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.lblMemoNo = new DevExpress.XtraEditors.LabelControl();
            this.lblMemoDate = new DevExpress.XtraEditors.LabelControl();
            this.btnRevert = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.txtCardDigits = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveOnly = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameOnCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLipNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountPaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardDigits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Btmaestro
            // 
            this.Btmaestro.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Maestro;
            this.Btmaestro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btmaestro.Location = new System.Drawing.Point(261, 30);
            this.Btmaestro.Name = "Btmaestro";
            this.Btmaestro.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btmaestro.Size = new System.Drawing.Size(111, 64);
            this.Btmaestro.TabIndex = 0;
            this.Btmaestro.Click += new System.EventHandler(this.Btmaestro_Click);
            // 
            // Btamex
            // 
            this.Btamex.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.AMExpress;
            this.Btamex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btamex.Location = new System.Drawing.Point(378, 24);
            this.Btamex.Name = "Btamex";
            this.Btamex.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btamex.Size = new System.Drawing.Size(102, 76);
            this.Btamex.TabIndex = 0;
            this.Btamex.Click += new System.EventHandler(this.Btamex_Click);
            // 
            // Btvisa
            // 
            this.Btvisa.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.VISA;
            this.Btvisa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btvisa.Location = new System.Drawing.Point(25, 31);
            this.Btvisa.Name = "Btvisa";
            this.Btvisa.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btvisa.Size = new System.Drawing.Size(111, 63);
            this.Btvisa.TabIndex = 0;
            this.Btvisa.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Btmaster
            // 
            this.Btmaster.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.MASTERCARD;
            this.Btmaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btmaster.Location = new System.Drawing.Point(144, 30);
            this.Btmaster.Name = "Btmaster";
            this.Btmaster.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btmaster.Size = new System.Drawing.Size(111, 64);
            this.Btmaster.TabIndex = 0;
            this.Btmaster.Click += new System.EventHandler(this.Btmaster_Click);
            // 
            // Btdci
            // 
            this.Btdci.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.DINNER;
            this.Btdci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btdci.Location = new System.Drawing.Point(486, 30);
            this.Btdci.Name = "Btdci";
            this.Btdci.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btdci.Size = new System.Drawing.Size(111, 64);
            this.Btdci.TabIndex = 0;
            this.Btdci.Click += new System.EventHandler(this.Btdci_Click);
            // 
            // txtCardType
            // 
            this.txtCardType.Location = new System.Drawing.Point(128, 123);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.Properties.Appearance.Options.UseFont = true;
            this.txtCardType.Size = new System.Drawing.Size(214, 24);
            this.txtCardType.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(55, 125);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 20);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Card Type";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(64, 190);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 20);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Card No.";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(128, 188);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.Properties.Appearance.Options.UseFont = true;
            this.txtCardNo.Size = new System.Drawing.Size(214, 24);
            this.txtCardNo.TabIndex = 5;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(25, 220);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(100, 20);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Name on Card";
            // 
            // txtNameOnCard
            // 
            this.txtNameOnCard.Location = new System.Drawing.Point(128, 218);
            this.txtNameOnCard.Name = "txtNameOnCard";
            this.txtNameOnCard.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameOnCard.Properties.Appearance.Options.UseFont = true;
            this.txtNameOnCard.Size = new System.Drawing.Size(214, 24);
            this.txtNameOnCard.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl50);
            this.groupControl1.Controls.Add(this.labelControl49);
            this.groupControl1.Controls.Add(this.labelControl48);
            this.groupControl1.Controls.Add(this.labelControl47);
            this.groupControl1.Controls.Add(this.txtBalanceAmount);
            this.groupControl1.Controls.Add(this.txtSLipNo);
            this.groupControl1.Controls.Add(this.txtAmountPaid);
            this.groupControl1.Controls.Add(this.txtMemoAmount);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(348, 106);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(257, 164);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Memo Info";
            // 
            // labelControl50
            // 
            this.labelControl50.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl50.Appearance.Options.UseFont = true;
            this.labelControl50.Location = new System.Drawing.Point(14, 130);
            this.labelControl50.Name = "labelControl50";
            this.labelControl50.Size = new System.Drawing.Size(116, 20);
            this.labelControl50.TabIndex = 4;
            this.labelControl50.Text = "Balance Amount";
            // 
            // labelControl49
            // 
            this.labelControl49.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl49.Appearance.Options.UseFont = true;
            this.labelControl49.Location = new System.Drawing.Point(71, 100);
            this.labelControl49.Name = "labelControl49";
            this.labelControl49.Size = new System.Drawing.Size(54, 20);
            this.labelControl49.TabIndex = 5;
            this.labelControl49.Text = "Slip No.";
            // 
            // labelControl48
            // 
            this.labelControl48.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl48.Appearance.Options.UseFont = true;
            this.labelControl48.Location = new System.Drawing.Point(33, 70);
            this.labelControl48.Name = "labelControl48";
            this.labelControl48.Size = new System.Drawing.Size(92, 20);
            this.labelControl48.TabIndex = 6;
            this.labelControl48.Text = "Amount Paid";
            // 
            // labelControl47
            // 
            this.labelControl47.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl47.Appearance.Options.UseFont = true;
            this.labelControl47.Location = new System.Drawing.Point(18, 40);
            this.labelControl47.Name = "labelControl47";
            this.labelControl47.Size = new System.Drawing.Size(107, 20);
            this.labelControl47.TabIndex = 9;
            this.labelControl47.Text = "Memo Amount";
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.EditValue = "0";
            this.txtBalanceAmount.Location = new System.Drawing.Point(138, 128);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceAmount.Properties.Appearance.Options.UseFont = true;
            this.txtBalanceAmount.Properties.DisplayFormat.FormatString = "n2";
            this.txtBalanceAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBalanceAmount.Properties.EditFormat.FormatString = "n2";
            this.txtBalanceAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBalanceAmount.Properties.Mask.EditMask = "n2";
            this.txtBalanceAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBalanceAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBalanceAmount.Size = new System.Drawing.Size(114, 24);
            this.txtBalanceAmount.TabIndex = 10;
            // 
            // txtSLipNo
            // 
            this.txtSLipNo.Location = new System.Drawing.Point(138, 98);
            this.txtSLipNo.Name = "txtSLipNo";
            this.txtSLipNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLipNo.Properties.Appearance.Options.UseFont = true;
            this.txtSLipNo.Size = new System.Drawing.Size(114, 24);
            this.txtSLipNo.TabIndex = 11;
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.EditValue = "0";
            this.txtAmountPaid.Location = new System.Drawing.Point(138, 68);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPaid.Properties.Appearance.Options.UseFont = true;
            this.txtAmountPaid.Properties.DisplayFormat.FormatString = "n2";
            this.txtAmountPaid.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmountPaid.Properties.EditFormat.FormatString = "n2";
            this.txtAmountPaid.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmountPaid.Properties.Mask.EditMask = "n2";
            this.txtAmountPaid.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmountPaid.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAmountPaid.Size = new System.Drawing.Size(114, 24);
            this.txtAmountPaid.TabIndex = 12;
            this.txtAmountPaid.EditValueChanged += new System.EventHandler(this.TxtAmountPaid_EditValueChanged);
            // 
            // txtMemoAmount
            // 
            this.txtMemoAmount.EditValue = "0";
            this.txtMemoAmount.Location = new System.Drawing.Point(138, 38);
            this.txtMemoAmount.Name = "txtMemoAmount";
            this.txtMemoAmount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemoAmount.Properties.Appearance.Options.UseFont = true;
            this.txtMemoAmount.Properties.DisplayFormat.FormatString = "n2";
            this.txtMemoAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMemoAmount.Properties.EditFormat.FormatString = "n2";
            this.txtMemoAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMemoAmount.Properties.Mask.EditMask = "n2";
            this.txtMemoAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMemoAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMemoAmount.Size = new System.Drawing.Size(114, 24);
            this.txtMemoAmount.TabIndex = 13;
            // 
            // labelControl25
            // 
            this.labelControl25.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl25.Appearance.Options.UseFont = true;
            this.labelControl25.Location = new System.Drawing.Point(164, 4);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(91, 20);
            this.labelControl25.TabIndex = 7;
            this.labelControl25.Text = "Memo Dated";
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl24.Appearance.Options.UseFont = true;
            this.labelControl24.Location = new System.Drawing.Point(25, 4);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(74, 20);
            this.labelControl24.TabIndex = 8;
            this.labelControl24.Text = "Memo No.";
            // 
            // lblMemoNo
            // 
            this.lblMemoNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemoNo.Appearance.Options.UseFont = true;
            this.lblMemoNo.Location = new System.Drawing.Point(105, 4);
            this.lblMemoNo.Name = "lblMemoNo";
            this.lblMemoNo.Size = new System.Drawing.Size(18, 20);
            this.lblMemoNo.TabIndex = 8;
            this.lblMemoNo.Text = "00";
            // 
            // lblMemoDate
            // 
            this.lblMemoDate.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemoDate.Appearance.Options.UseFont = true;
            this.lblMemoDate.Location = new System.Drawing.Point(261, 4);
            this.lblMemoDate.Name = "lblMemoDate";
            this.lblMemoDate.Size = new System.Drawing.Size(86, 20);
            this.lblMemoDate.TabIndex = 8;
            this.lblMemoDate.Text = "00/00/0000";
            // 
            // btnRevert
            // 
            this.btnRevert.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRevert.ImageOptions.SvgImage")));
            this.btnRevert.Location = new System.Drawing.Point(167, 287);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(127, 36);
            this.btnRevert.TabIndex = 9;
            this.btnRevert.Text = "Revert";
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(38, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 36);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save && Print";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // separatorControl1
            // 
            this.separatorControl1.BackColor = System.Drawing.Color.Black;
            this.separatorControl1.Location = new System.Drawing.Point(16, 23);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(591, 4);
            this.separatorControl1.TabIndex = 11;
            // 
            // txtCardDigits
            // 
            this.txtCardDigits.Location = new System.Drawing.Point(128, 153);
            this.txtCardDigits.Name = "txtCardDigits";
            this.txtCardDigits.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardDigits.Properties.Appearance.Options.UseFont = true;
            this.txtCardDigits.Size = new System.Drawing.Size(214, 24);
            this.txtCardDigits.TabIndex = 13;
            this.txtCardDigits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCardDigits_KeyDown);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(48, 154);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(77, 20);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Card Digits";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(348, 292);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(10, 24);
            this.textEdit1.TabIndex = 14;
            this.textEdit1.Enter += new System.EventHandler(this.TextEdit1_Enter);
            this.textEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextEdit1_KeyDown);
            // 
            // btnSaveOnly
            // 
            this.btnSaveOnly.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveOnly.ImageOptions.SvgImage")));
            this.btnSaveOnly.Location = new System.Drawing.Point(300, 287);
            this.btnSaveOnly.Name = "btnSaveOnly";
            this.btnSaveOnly.Size = new System.Drawing.Size(72, 36);
            this.btnSaveOnly.TabIndex = 15;
            this.btnSaveOnly.Text = "Save ";
            this.btnSaveOnly.Click += new System.EventHandler(this.BtnSaveOnly_Click);
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 346);
            this.Controls.Add(this.btnSaveOnly);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.txtCardDigits);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtNameOnCard);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl25);
            this.Controls.Add(this.lblMemoDate);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.lblMemoNo);
            this.Controls.Add(this.labelControl24);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCardType);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Btdci);
            this.Controls.Add(this.Btamex);
            this.Controls.Add(this.Btmaestro);
            this.Controls.Add(this.Btvisa);
            this.Controls.Add(this.Btmaster);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Card";
            this.Text = "Card";
            this.Load += new System.EventHandler(this.Card_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Card_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtCardType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameOnCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalanceAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLipNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountPaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemoAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardDigits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton Btmaster;
        private DevExpress.XtraEditors.SimpleButton Btmaestro;
        private DevExpress.XtraEditors.SimpleButton Btamex;
        private DevExpress.XtraEditors.SimpleButton Btvisa;
        private DevExpress.XtraEditors.SimpleButton Btdci;
        private DevExpress.XtraEditors.TextEdit txtCardType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCardNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNameOnCard;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl50;
        private DevExpress.XtraEditors.LabelControl labelControl49;
        private DevExpress.XtraEditors.LabelControl labelControl48;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl47;
        private DevExpress.XtraEditors.TextEdit txtBalanceAmount;
        private DevExpress.XtraEditors.TextEdit txtSLipNo;
        private DevExpress.XtraEditors.TextEdit txtAmountPaid;
        private DevExpress.XtraEditors.TextEdit txtMemoAmount;
        private DevExpress.XtraEditors.LabelControl lblMemoNo;
        private DevExpress.XtraEditors.LabelControl lblMemoDate;
        private DevExpress.XtraEditors.SimpleButton btnRevert;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.TextEdit txtCardDigits;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnSaveOnly;
    }
}