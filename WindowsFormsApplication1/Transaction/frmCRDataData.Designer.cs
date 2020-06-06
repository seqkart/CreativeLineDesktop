namespace WindowsFormsApplication1.Transaction
{
    partial class frmCRDataData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCRDataData));
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dtInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebitPartyName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDebitPartyCode = new DevExpress.XtraEditors.TextEdit();
            this.txt2000 = new DevExpress.XtraEditors.TextEdit();
            this.txt500 = new DevExpress.XtraEditors.TextEdit();
            this.txt50 = new DevExpress.XtraEditors.TextEdit();
            this.txt1000 = new DevExpress.XtraEditors.TextEdit();
            this.txt100 = new DevExpress.XtraEditors.TextEdit();
            this.txt20 = new DevExpress.XtraEditors.TextEdit();
            this.txt10 = new DevExpress.XtraEditors.TextEdit();
            this.txt5 = new DevExpress.XtraEditors.TextEdit();
            this.txt2 = new DevExpress.XtraEditors.TextEdit();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt1 = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtSMName = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSMCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt2000.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt500.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt50.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt1000.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt100.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt20.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt1.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(171, 30);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(418, 245);
            this.HelpGrid.TabIndex = 14;
            this.HelpGrid.TabStop = false;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView,
            this.gridView1});
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
            // gridView1
            // 
            this.gridView1.GridControl = this.HelpGrid;
            this.gridView1.Name = "gridView1";
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.EditValue = null;
            this.dtInvoiceDate.Location = new System.Drawing.Point(94, 45);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtInvoiceDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dtInvoiceDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInvoiceDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dtInvoiceDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInvoiceDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dtInvoiceDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtInvoiceDate.Size = new System.Drawing.Size(79, 20);
            this.dtInvoiceDate.TabIndex = 0;
            this.dtInvoiceDate.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 301;
            this.label2.Text = "Date";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(485, 46);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(78, 20);
            this.txtSerialNo.TabIndex = 303;
            this.txtSerialNo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 299;
            this.label1.Text = "CCI No";
            // 
            // txtDebitPartyName
            // 
            this.txtDebitPartyName.EnterMoveNextControl = true;
            this.txtDebitPartyName.Location = new System.Drawing.Point(194, 98);
            this.txtDebitPartyName.Name = "txtDebitPartyName";
            this.txtDebitPartyName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitPartyName.Properties.ReadOnly = true;
            this.txtDebitPartyName.Size = new System.Drawing.Size(369, 20);
            this.txtDebitPartyName.TabIndex = 304;
            this.txtDebitPartyName.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 306;
            this.label6.Text = "Dealer Code";
            // 
            // txtDebitPartyCode
            // 
            this.txtDebitPartyCode.Location = new System.Drawing.Point(93, 99);
            this.txtDebitPartyCode.Name = "txtDebitPartyCode";
            this.txtDebitPartyCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitPartyCode.Properties.MaxLength = 6;
            this.txtDebitPartyCode.Size = new System.Drawing.Size(78, 20);
            this.txtDebitPartyCode.TabIndex = 1;
            this.txtDebitPartyCode.EditValueChanged += new System.EventHandler(this.txtDebitPartyCode_EditValueChanged);
            this.txtDebitPartyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDebitPartyCode_KeyDown);
            // 
            // txt2000
            // 
            this.txt2000.Location = new System.Drawing.Point(93, 125);
            this.txt2000.Name = "txt2000";
            this.txt2000.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt2000.Properties.MaxLength = 6;
            this.txt2000.Size = new System.Drawing.Size(78, 20);
            this.txt2000.TabIndex = 2;
            this.txt2000.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt500
            // 
            this.txt500.Location = new System.Drawing.Point(93, 151);
            this.txt500.Name = "txt500";
            this.txt500.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt500.Properties.MaxLength = 6;
            this.txt500.Size = new System.Drawing.Size(78, 20);
            this.txt500.TabIndex = 4;
            this.txt500.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt50
            // 
            this.txt50.Location = new System.Drawing.Point(93, 177);
            this.txt50.Name = "txt50";
            this.txt50.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt50.Properties.MaxLength = 6;
            this.txt50.Size = new System.Drawing.Size(78, 20);
            this.txt50.TabIndex = 6;
            this.txt50.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt1000
            // 
            this.txt1000.Location = new System.Drawing.Point(485, 124);
            this.txt1000.Name = "txt1000";
            this.txt1000.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt1000.Properties.MaxLength = 6;
            this.txt1000.Size = new System.Drawing.Size(78, 20);
            this.txt1000.TabIndex = 3;
            this.txt1000.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt100
            // 
            this.txt100.Location = new System.Drawing.Point(485, 150);
            this.txt100.Name = "txt100";
            this.txt100.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt100.Properties.MaxLength = 6;
            this.txt100.Size = new System.Drawing.Size(78, 20);
            this.txt100.TabIndex = 5;
            this.txt100.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt20
            // 
            this.txt20.Location = new System.Drawing.Point(485, 176);
            this.txt20.Name = "txt20";
            this.txt20.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt20.Properties.MaxLength = 6;
            this.txt20.Size = new System.Drawing.Size(78, 20);
            this.txt20.TabIndex = 7;
            this.txt20.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt10
            // 
            this.txt10.Location = new System.Drawing.Point(93, 203);
            this.txt10.Name = "txt10";
            this.txt10.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt10.Properties.MaxLength = 6;
            this.txt10.Size = new System.Drawing.Size(78, 20);
            this.txt10.TabIndex = 8;
            this.txt10.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(485, 202);
            this.txt5.Name = "txt5";
            this.txt5.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt5.Properties.MaxLength = 6;
            this.txt5.Size = new System.Drawing.Size(78, 20);
            this.txt5.TabIndex = 9;
            this.txt5.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(95, 229);
            this.txt2.Name = "txt2";
            this.txt2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt2.Properties.MaxLength = 6;
            this.txt2.Size = new System.Drawing.Size(78, 20);
            this.txt2.TabIndex = 10;
            this.txt2.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(95, 255);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Properties.MaxLength = 6;
            this.txtTotal.Size = new System.Drawing.Size(78, 20);
            this.txtTotal.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 318;
            this.label3.Text = "2000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 319;
            this.label4.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 320;
            this.label5.Text = "500";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 321;
            this.label7.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 322;
            this.label8.Text = "50";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(460, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 323;
            this.label9.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 324;
            this.label10.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(460, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 325;
            this.label11.Text = "5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 326;
            this.label12.Text = "2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(458, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 328;
            this.label13.Text = "1";
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(485, 228);
            this.txt1.Name = "txt1";
            this.txt1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt1.Properties.MaxLength = 6;
            this.txt1.Size = new System.Drawing.Size(78, 20);
            this.txt1.TabIndex = 11;
            this.txt1.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 258);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 329;
            this.label14.Text = "Total Amount";
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(589, 26);
            this.Menu_ToolStrip.TabIndex = 330;
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
            // txtSMName
            // 
            this.txtSMName.EnterMoveNextControl = true;
            this.txtSMName.Location = new System.Drawing.Point(194, 72);
            this.txtSMName.Name = "txtSMName";
            this.txtSMName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSMName.Properties.ReadOnly = true;
            this.txtSMName.Size = new System.Drawing.Size(369, 20);
            this.txtSMName.TabIndex = 434;
            this.txtSMName.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 436;
            this.label15.Text = "Salesman";
            // 
            // txtSMCode
            // 
            this.txtSMCode.Location = new System.Drawing.Point(93, 72);
            this.txtSMCode.Name = "txtSMCode";
            this.txtSMCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSMCode.Properties.MaxLength = 6;
            this.txtSMCode.Size = new System.Drawing.Size(80, 20);
            this.txtSMCode.TabIndex = 435;
            this.txtSMCode.EditValueChanged += new System.EventHandler(this.TxtSMCode_EditValueChanged);
            this.txtSMCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSMCode_KeyDown);
            // 
            // frmCRDataData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 317);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.txtSMName);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSMCode);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.txt10);
            this.Controls.Add(this.txt20);
            this.Controls.Add(this.txt100);
            this.Controls.Add(this.txt1000);
            this.Controls.Add(this.txt50);
            this.Controls.Add(this.txt500);
            this.Controls.Add(this.txt2000);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDebitPartyName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDebitPartyCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmCRDataData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmCRDataData_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCRDataData_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt2000.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt500.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt50.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt1000.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt100.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt20.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt1.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit dtInvoiceDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtDebitPartyName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDebitPartyCode;
        private DevExpress.XtraEditors.TextEdit txt2000;
        private DevExpress.XtraEditors.TextEdit txt500;
        private DevExpress.XtraEditors.TextEdit txt50;
        private DevExpress.XtraEditors.TextEdit txt1000;
        private DevExpress.XtraEditors.TextEdit txt100;
        private DevExpress.XtraEditors.TextEdit txt20;
        private DevExpress.XtraEditors.TextEdit txt10;
        private DevExpress.XtraEditors.TextEdit txt5;
        private DevExpress.XtraEditors.TextEdit txt2;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txt1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtSMName;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.TextEdit txtSMCode;
    }
}