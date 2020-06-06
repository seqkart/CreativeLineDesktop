namespace WindowsFormsApplication1.Transaction
{
    partial class frmReturnCrates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnCrates));
            this.label51 = new System.Windows.Forms.Label();
            this.txtInvoiceType = new DevExpress.XtraEditors.TextEdit();
            this.dtInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebitPartyName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDebitPartyCode = new DevExpress.XtraEditors.TextEdit();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.txtOrderDate = new DevExpress.XtraEditors.TextEdit();
            this.btnLoadOrder = new DevExpress.XtraEditors.SimpleButton();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvCrates1 = new DevExpress.XtraEditors.TextEdit();
            this.txtInvCrates2 = new DevExpress.XtraEditors.TextEdit();
            this.txtSMName = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSMCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCrates2 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCrates1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyCode.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCrates1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCrates2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrates2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrates1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(255, 64);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(52, 13);
            this.label51.TabIndex = 324;
            this.label51.Text = "Doc Type";
            this.label51.UseWaitCursor = true;
            // 
            // txtInvoiceType
            // 
            this.txtInvoiceType.Enabled = false;
            this.txtInvoiceType.EnterMoveNextControl = true;
            this.txtInvoiceType.Location = new System.Drawing.Point(325, 61);
            this.txtInvoiceType.Name = "txtInvoiceType";
            this.txtInvoiceType.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoiceType.Size = new System.Drawing.Size(101, 20);
            this.txtInvoiceType.TabIndex = 323;
            this.txtInvoiceType.TabStop = false;
            this.txtInvoiceType.UseWaitCursor = true;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.EditValue = null;
            this.dtInvoiceDate.Location = new System.Drawing.Point(92, 61);
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
            this.dtInvoiceDate.Size = new System.Drawing.Size(94, 20);
            this.dtInvoiceDate.TabIndex = 320;
            this.dtInvoiceDate.TabStop = false;
            this.dtInvoiceDate.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 322;
            this.label2.Text = "Date";
            this.label2.UseWaitCursor = true;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.Location = new System.Drawing.Point(536, 61);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(68, 20);
            this.txtSerialNo.TabIndex = 321;
            this.txtSerialNo.TabStop = false;
            this.txtSerialNo.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 319;
            this.label1.Text = "CCI No";
            this.label1.UseWaitCursor = true;
            // 
            // txtDebitPartyName
            // 
            this.txtDebitPartyName.EnterMoveNextControl = true;
            this.txtDebitPartyName.Location = new System.Drawing.Point(192, 121);
            this.txtDebitPartyName.Name = "txtDebitPartyName";
            this.txtDebitPartyName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitPartyName.Properties.ReadOnly = true;
            this.txtDebitPartyName.Size = new System.Drawing.Size(412, 20);
            this.txtDebitPartyName.TabIndex = 326;
            this.txtDebitPartyName.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 327;
            this.label6.Text = "Dealer Code";
            // 
            // txtDebitPartyCode
            // 
            this.txtDebitPartyCode.Location = new System.Drawing.Point(91, 122);
            this.txtDebitPartyCode.Name = "txtDebitPartyCode";
            this.txtDebitPartyCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitPartyCode.Properties.MaxLength = 6;
            this.txtDebitPartyCode.Size = new System.Drawing.Size(93, 20);
            this.txtDebitPartyCode.TabIndex = 325;
            this.txtDebitPartyCode.EditValueChanged += new System.EventHandler(this.txtDebitPartyCode_EditValueChanged);
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(630, 26);
            this.Menu_ToolStrip.TabIndex = 328;
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
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(15, 147);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(67, 13);
            this.lblOrder.TabIndex = 415;
            this.lblOrder.Text = "Against  Inv";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.EnterMoveNextControl = true;
            this.txtOrderNo.Location = new System.Drawing.Point(91, 149);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderNo.Properties.ReadOnly = true;
            this.txtOrderNo.Size = new System.Drawing.Size(94, 20);
            this.txtOrderNo.TabIndex = 414;
            this.txtOrderNo.TabStop = false;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.EnterMoveNextControl = true;
            this.txtOrderDate.Location = new System.Drawing.Point(513, 149);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderDate.Properties.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(91, 20);
            this.txtOrderDate.TabIndex = 413;
            this.txtOrderDate.TabStop = false;
            // 
            // btnLoadOrder
            // 
            this.btnLoadOrder.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLoadOrder.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadOrder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLoadOrder.Appearance.Options.UseBackColor = true;
            this.btnLoadOrder.Appearance.Options.UseFont = true;
            this.btnLoadOrder.Appearance.Options.UseForeColor = true;
            this.btnLoadOrder.Location = new System.Drawing.Point(407, 147);
            this.btnLoadOrder.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnLoadOrder.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLoadOrder.Name = "btnLoadOrder";
            this.btnLoadOrder.Size = new System.Drawing.Size(85, 23);
            this.btnLoadOrder.TabIndex = 412;
            this.btnLoadOrder.Text = "Load Invoices";
            this.btnLoadOrder.Click += new System.EventHandler(this.btnLoadOrder_Click);
            // 
            // HelpGrid
            // 
            this.HelpGrid.EmbeddedNavigator.UseWaitCursor = true;
            this.HelpGrid.Location = new System.Drawing.Point(200, 29);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(438, 222);
            this.HelpGrid.TabIndex = 416;
            this.HelpGrid.TabStop = false;
            this.HelpGrid.UseWaitCursor = true;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 423;
            this.label5.Text = "Crates";
            // 
            // txtInvCrates1
            // 
            this.txtInvCrates1.EnterMoveNextControl = true;
            this.txtInvCrates1.Location = new System.Drawing.Point(92, 175);
            this.txtInvCrates1.Name = "txtInvCrates1";
            this.txtInvCrates1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvCrates1.Properties.ReadOnly = true;
            this.txtInvCrates1.Size = new System.Drawing.Size(94, 20);
            this.txtInvCrates1.TabIndex = 422;
            this.txtInvCrates1.TabStop = false;
            // 
            // txtInvCrates2
            // 
            this.txtInvCrates2.EnterMoveNextControl = true;
            this.txtInvCrates2.Location = new System.Drawing.Point(514, 175);
            this.txtInvCrates2.Name = "txtInvCrates2";
            this.txtInvCrates2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvCrates2.Properties.ReadOnly = true;
            this.txtInvCrates2.Size = new System.Drawing.Size(91, 20);
            this.txtInvCrates2.TabIndex = 421;
            this.txtInvCrates2.TabStop = false;
            // 
            // txtSMName
            // 
            this.txtSMName.EnterMoveNextControl = true;
            this.txtSMName.Location = new System.Drawing.Point(192, 96);
            this.txtSMName.Name = "txtSMName";
            this.txtSMName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSMName.Properties.ReadOnly = true;
            this.txtSMName.Size = new System.Drawing.Size(413, 20);
            this.txtSMName.TabIndex = 431;
            this.txtSMName.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 433;
            this.label11.Text = "Salesman";
            // 
            // txtSMCode
            // 
            this.txtSMCode.Location = new System.Drawing.Point(91, 96);
            this.txtSMCode.Name = "txtSMCode";
            this.txtSMCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSMCode.Properties.MaxLength = 6;
            this.txtSMCode.Size = new System.Drawing.Size(95, 20);
            this.txtSMCode.TabIndex = 432;
            this.txtSMCode.EditValueChanged += new System.EventHandler(this.TxtSMCode_EditValueChanged);
            this.txtSMCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSMCode_KeyDown);
            // 
            // txtCrates2
            // 
            this.txtCrates2.Location = new System.Drawing.Point(514, 202);
            this.txtCrates2.Name = "txtCrates2";
            this.txtCrates2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCrates2.Properties.MaxLength = 6;
            this.txtCrates2.Size = new System.Drawing.Size(90, 20);
            this.txtCrates2.TabIndex = 419;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 418;
            this.label3.Text = "Crates";
            // 
            // txtCrates1
            // 
            this.txtCrates1.Location = new System.Drawing.Point(91, 202);
            this.txtCrates1.Name = "txtCrates1";
            this.txtCrates1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCrates1.Properties.MaxLength = 6;
            this.txtCrates1.Size = new System.Drawing.Size(95, 20);
            this.txtCrates1.TabIndex = 417;
            // 
            // frmReturnCrates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 249);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.txtSMName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSMCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInvCrates1);
            this.Controls.Add(this.txtInvCrates2);
            this.Controls.Add(this.txtCrates2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCrates1);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.btnLoadOrder);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtDebitPartyName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDebitPartyCode);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.txtInvoiceType);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmReturnCrates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmReturnCrates_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReturnCrates_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitPartyCode.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCrates1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCrates2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrates2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrates1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label51;
        private DevExpress.XtraEditors.TextEdit txtInvoiceType;
        private DevExpress.XtraEditors.DateEdit dtInvoiceDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtDebitPartyName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDebitPartyCode;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label lblOrder;
        private DevExpress.XtraEditors.TextEdit txtOrderNo;
        private DevExpress.XtraEditors.TextEdit txtOrderDate;
        private DevExpress.XtraEditors.SimpleButton btnLoadOrder;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtInvCrates1;
        private DevExpress.XtraEditors.TextEdit txtInvCrates2;
        private DevExpress.XtraEditors.TextEdit txtSMName;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtSMCode;
        private DevExpress.XtraEditors.TextEdit txtCrates2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtCrates1;
    }
}