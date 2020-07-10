namespace WindowsFormsApplication1
{
    partial class frmTaxMasterAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxMasterAddEdit));
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCGSTRate = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtTaxDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtTaxCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSGSTRate = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCGSTPostingCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCGSTPostingDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtSGSTPostingDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtSGSTPostingCode = new DevExpress.XtraEditors.TextEdit();
            this.txtIGSTPostingDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtIGSTPostingCode = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMessage = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtIGSTRate = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSalePostDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtSalePostCode = new DevExpress.XtraEditors.TextEdit();
            this.txtLCType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtAboveAmount = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAboveIGSTRate = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAboveSGSTRate = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAboveCGSTRate = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGSTRate.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGSTRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGSTPostingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGSTPostingDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGSTPostingDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGSTPostingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIGSTPostingDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIGSTPostingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIGSTRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePostDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePostCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLCType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveIGSTRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveSGSTRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveCGSTRate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(118, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 222;
            this.label7.Text = "Message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(284, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 221;
            this.label5.Text = "SGST Rate";
            // 
            // txtCGSTRate
            // 
            this.txtCGSTRate.Location = new System.Drawing.Point(183, 124);
            this.txtCGSTRate.Name = "txtCGSTRate";
            this.txtCGSTRate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCGSTRate.Size = new System.Drawing.Size(85, 20);
            this.txtCGSTRate.TabIndex = 3;
            this.txtCGSTRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxRate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(109, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 220;
            this.label3.Text = "CGST Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(141, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 219;
            this.label2.Text = "Desc";
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(638, 25);
            this.Menu_ToolStrip.TabIndex = 218;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(40, 22);
            this.btnQuit.Text = "Close";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 22);
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTaxDesc
            // 
            this.txtTaxDesc.Location = new System.Drawing.Point(183, 98);
            this.txtTaxDesc.Name = "txtTaxDesc";
            this.txtTaxDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxDesc.Properties.MaxLength = 50;
            this.txtTaxDesc.Size = new System.Drawing.Size(425, 20);
            this.txtTaxDesc.TabIndex = 2;
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Location = new System.Drawing.Point(183, 72);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxCode.Size = new System.Drawing.Size(84, 20);
            this.txtTaxCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(140, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 217;
            this.label1.Text = "Code";
            // 
            // txtSGSTRate
            // 
            this.txtSGSTRate.Location = new System.Drawing.Point(350, 124);
            this.txtSGSTRate.Name = "txtSGSTRate";
            this.txtSGSTRate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSGSTRate.Size = new System.Drawing.Size(85, 20);
            this.txtSGSTRate.TabIndex = 4;
            this.txtSGSTRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxRate_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(452, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 225;
            this.label4.Text = "IGST Rate";
            // 
            // txtCGSTPostingCode
            // 
            this.txtCGSTPostingCode.Location = new System.Drawing.Point(183, 202);
            this.txtCGSTPostingCode.Name = "txtCGSTPostingCode";
            this.txtCGSTPostingCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCGSTPostingCode.Properties.MaxLength = 6;
            this.txtCGSTPostingCode.Size = new System.Drawing.Size(85, 20);
            this.txtCGSTPostingCode.TabIndex = 10;
            this.txtCGSTPostingCode.EditValueChanged += new System.EventHandler(this.txtSalePostingCode_EditValueChanged);
            this.txtCGSTPostingCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalePostingCode_KeyDown);
            this.txtCGSTPostingCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalePostingCode_KeyPress);
            // 
            // txtCGSTPostingDesc
            // 
            this.txtCGSTPostingDesc.Location = new System.Drawing.Point(275, 202);
            this.txtCGSTPostingDesc.Name = "txtCGSTPostingDesc";
            this.txtCGSTPostingDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCGSTPostingDesc.Properties.ReadOnly = true;
            this.txtCGSTPostingDesc.Size = new System.Drawing.Size(333, 20);
            this.txtCGSTPostingDesc.TabIndex = 229;
            this.txtCGSTPostingDesc.TabStop = false;
            // 
            // txtSGSTPostingDesc
            // 
            this.txtSGSTPostingDesc.Location = new System.Drawing.Point(275, 228);
            this.txtSGSTPostingDesc.Name = "txtSGSTPostingDesc";
            this.txtSGSTPostingDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSGSTPostingDesc.Properties.ReadOnly = true;
            this.txtSGSTPostingDesc.Size = new System.Drawing.Size(333, 20);
            this.txtSGSTPostingDesc.TabIndex = 231;
            this.txtSGSTPostingDesc.TabStop = false;
            // 
            // txtSGSTPostingCode
            // 
            this.txtSGSTPostingCode.Location = new System.Drawing.Point(183, 228);
            this.txtSGSTPostingCode.Name = "txtSGSTPostingCode";
            this.txtSGSTPostingCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSGSTPostingCode.Properties.MaxLength = 6;
            this.txtSGSTPostingCode.Size = new System.Drawing.Size(85, 20);
            this.txtSGSTPostingCode.TabIndex = 11;
            this.txtSGSTPostingCode.EditValueChanged += new System.EventHandler(this.txtTaxPostingCode_EditValueChanged);
            this.txtSGSTPostingCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaxPostingCode_KeyDown);
            this.txtSGSTPostingCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalePostingCode_KeyPress);
            // 
            // txtIGSTPostingDesc
            // 
            this.txtIGSTPostingDesc.Location = new System.Drawing.Point(275, 254);
            this.txtIGSTPostingDesc.Name = "txtIGSTPostingDesc";
            this.txtIGSTPostingDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIGSTPostingDesc.Properties.ReadOnly = true;
            this.txtIGSTPostingDesc.Size = new System.Drawing.Size(333, 20);
            this.txtIGSTPostingDesc.TabIndex = 233;
            this.txtIGSTPostingDesc.TabStop = false;
            // 
            // txtIGSTPostingCode
            // 
            this.txtIGSTPostingCode.Location = new System.Drawing.Point(183, 254);
            this.txtIGSTPostingCode.Name = "txtIGSTPostingCode";
            this.txtIGSTPostingCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIGSTPostingCode.Properties.MaxLength = 6;
            this.txtIGSTPostingCode.Size = new System.Drawing.Size(85, 20);
            this.txtIGSTPostingCode.TabIndex = 12;
            this.txtIGSTPostingCode.EditValueChanged += new System.EventHandler(this.txtSurPostingCode_EditValueChanged);
            this.txtIGSTPostingCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSurPostingCode_KeyDown);
            this.txtIGSTPostingCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalePostingCode_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(63, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 235;
            this.label10.Text = "SGST Posting Code";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(63, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 236;
            this.label11.Text = "CGST Posting Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(65, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 237;
            this.label9.Text = "IGST Posting Code";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(183, 280);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMessage.Properties.MaxLength = 40;
            this.txtMessage.Size = new System.Drawing.Size(425, 20);
            this.txtMessage.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(149, 310);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 240;
            this.label12.Text = "L/C";
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(501, 75);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(414, 283);
            this.HelpGrid.TabIndex = 243;
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
            // txtIGSTRate
            // 
            this.txtIGSTRate.Location = new System.Drawing.Point(523, 124);
            this.txtIGSTRate.Name = "txtIGSTRate";
            this.txtIGSTRate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIGSTRate.Size = new System.Drawing.Size(85, 20);
            this.txtIGSTRate.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(10, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 13);
            this.label6.TabIndex = 247;
            this.label6.Text = "Sale/Purchase Posting Code";
            // 
            // txtSalePostDesc
            // 
            this.txtSalePostDesc.Location = new System.Drawing.Point(275, 332);
            this.txtSalePostDesc.Name = "txtSalePostDesc";
            this.txtSalePostDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalePostDesc.Properties.ReadOnly = true;
            this.txtSalePostDesc.Size = new System.Drawing.Size(333, 20);
            this.txtSalePostDesc.TabIndex = 246;
            this.txtSalePostDesc.TabStop = false;
            // 
            // txtSalePostCode
            // 
            this.txtSalePostCode.Location = new System.Drawing.Point(183, 332);
            this.txtSalePostCode.Name = "txtSalePostCode";
            this.txtSalePostCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalePostCode.Properties.MaxLength = 6;
            this.txtSalePostCode.Size = new System.Drawing.Size(86, 20);
            this.txtSalePostCode.TabIndex = 15;
            this.txtSalePostCode.EditValueChanged += new System.EventHandler(this.txtSalePostCode_EditValueChanged);
            this.txtSalePostCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalePostCode_KeyDown);
            // 
            // txtLCType
            // 
            this.txtLCType.EnterMoveNextControl = true;
            this.txtLCType.Location = new System.Drawing.Point(183, 306);
            this.txtLCType.Name = "txtLCType";
            this.txtLCType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLCType.Properties.Items.AddRange(new object[] {
            "L",
            "C"});
            this.txtLCType.Size = new System.Drawing.Size(86, 20);
            this.txtLCType.TabIndex = 14;
            // 
            // txtAboveAmount
            // 
            this.txtAboveAmount.Location = new System.Drawing.Point(183, 150);
            this.txtAboveAmount.Name = "txtAboveAmount";
            this.txtAboveAmount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAboveAmount.Size = new System.Drawing.Size(85, 20);
            this.txtAboveAmount.TabIndex = 6;
            this.txtAboveAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxRate_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(84, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 249;
            this.label8.Text = "Above Amount";
            // 
            // txtAboveIGSTRate
            // 
            this.txtAboveIGSTRate.Location = new System.Drawing.Point(523, 176);
            this.txtAboveIGSTRate.Name = "txtAboveIGSTRate";
            this.txtAboveIGSTRate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAboveIGSTRate.Size = new System.Drawing.Size(85, 20);
            this.txtAboveIGSTRate.TabIndex = 9;
            this.txtAboveIGSTRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxRate_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(452, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 255;
            this.label13.Text = "IGST Rate";
            // 
            // txtAboveSGSTRate
            // 
            this.txtAboveSGSTRate.Location = new System.Drawing.Point(350, 176);
            this.txtAboveSGSTRate.Name = "txtAboveSGSTRate";
            this.txtAboveSGSTRate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAboveSGSTRate.Size = new System.Drawing.Size(85, 20);
            this.txtAboveSGSTRate.TabIndex = 8;
            this.txtAboveSGSTRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxRate_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(284, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 254;
            this.label14.Text = "SGST Rate";
            // 
            // txtAboveCGSTRate
            // 
            this.txtAboveCGSTRate.Location = new System.Drawing.Point(183, 176);
            this.txtAboveCGSTRate.Name = "txtAboveCGSTRate";
            this.txtAboveCGSTRate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAboveCGSTRate.Size = new System.Drawing.Size(85, 20);
            this.txtAboveCGSTRate.TabIndex = 7;
            this.txtAboveCGSTRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxRate_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(109, 180);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 253;
            this.label15.Text = "CGST Rate";
            // 
            // frmTaxMasterAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 394);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.txtAboveIGSTRate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAboveSGSTRate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAboveCGSTRate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtAboveAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLCType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSalePostDesc);
            this.Controls.Add(this.txtSalePostCode);
            this.Controls.Add(this.txtIGSTRate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIGSTPostingDesc);
            this.Controls.Add(this.txtIGSTPostingCode);
            this.Controls.Add(this.txtSGSTPostingDesc);
            this.Controls.Add(this.txtSGSTPostingCode);
            this.Controls.Add(this.txtCGSTPostingDesc);
            this.Controls.Add(this.txtCGSTPostingCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSGSTRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCGSTRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtTaxDesc);
            this.Controls.Add(this.txtTaxCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaxMasterAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTaxMasterAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTaxMasterAddEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtCGSTRate.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGSTRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGSTPostingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCGSTPostingDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGSTPostingDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGSTPostingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIGSTPostingDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIGSTPostingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIGSTRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePostDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalePostCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLCType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveIGSTRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveSGSTRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAboveCGSTRate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtCGSTRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtTaxDesc;
        private DevExpress.XtraEditors.TextEdit txtTaxCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSGSTRate;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtCGSTPostingCode;
        private DevExpress.XtraEditors.TextEdit txtCGSTPostingDesc;
        private DevExpress.XtraEditors.TextEdit txtSGSTPostingDesc;
        private DevExpress.XtraEditors.TextEdit txtSGSTPostingCode;
        private DevExpress.XtraEditors.TextEdit txtIGSTPostingDesc;
        private DevExpress.XtraEditors.TextEdit txtIGSTPostingCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtMessage;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraEditors.TextEdit txtIGSTRate;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtSalePostDesc;
        private DevExpress.XtraEditors.TextEdit txtSalePostCode;
        private DevExpress.XtraEditors.ComboBoxEdit txtLCType;
        private DevExpress.XtraEditors.TextEdit txtAboveAmount;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtAboveIGSTRate;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtAboveSGSTRate;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtAboveCGSTRate;
        private System.Windows.Forms.Label label15;
    }
}