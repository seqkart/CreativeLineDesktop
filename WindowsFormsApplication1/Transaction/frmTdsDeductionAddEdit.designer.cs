namespace WindowsFormsApplication1
{
    partial class frmTdsDeductionAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTdsDeductionAddEdit));
            this.txtReference = new DevExpress.XtraEditors.TextEdit();
            this.txtTDSDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtOnAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtTTNo = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPCode = new DevExpress.XtraEditors.TextEdit();
            this.txtPDesc = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTDSCode = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTDSRate = new DevExpress.XtraEditors.TextEdit();
            this.txtTDSSurcharge = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.TextAuthenticate = new System.Windows.Forms.ToolStripTextBox();
            this.dtTransDate = new DevExpress.XtraEditors.DateEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTDSAmount = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSurcOnTDS = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnderSection = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.MyValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSSurcharge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTransDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTransDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurcOnTDS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnderSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // txtReference
            // 
            this.txtReference.EnterMoveNextControl = true;
            this.txtReference.Location = new System.Drawing.Point(315, 140);
            this.txtReference.Name = "txtReference";
            this.txtReference.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReference.Size = new System.Drawing.Size(397, 20);
            this.txtReference.TabIndex = 6;
            this.txtReference.Leave += new System.EventHandler(this.txtReference_Leave);
            // 
            // txtTDSDesc
            // 
            this.txtTDSDesc.Enabled = false;
            this.txtTDSDesc.Location = new System.Drawing.Point(252, 108);
            this.txtTDSDesc.Name = "txtTDSDesc";
            this.txtTDSDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTDSDesc.Properties.ReadOnly = true;
            this.txtTDSDesc.Size = new System.Drawing.Size(459, 20);
            this.txtTDSDesc.TabIndex = 208;
            // 
            // txtOnAmount
            // 
            this.txtOnAmount.EnterMoveNextControl = true;
            this.txtOnAmount.Location = new System.Drawing.Point(121, 140);
            this.txtOnAmount.Name = "txtOnAmount";
            this.txtOnAmount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOnAmount.Properties.Mask.BeepOnError = true;
            this.txtOnAmount.Properties.Mask.EditMask = "N2";
            this.txtOnAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOnAmount.Size = new System.Drawing.Size(110, 20);
            this.txtOnAmount.TabIndex = 5;
            this.txtOnAmount.EditValueChanged += new System.EventHandler(this.txtOnAmount_EditValueChanged);
            this.txtOnAmount.Leave += new System.EventHandler(this.txtOnAmount_Leave);
            // 
            // txtTTNo
            // 
            this.txtTTNo.EnterMoveNextControl = true;
            this.txtTTNo.Location = new System.Drawing.Point(121, 46);
            this.txtTTNo.Name = "txtTTNo";
            this.txtTTNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTTNo.Properties.ReadOnly = true;
            this.txtTTNo.Size = new System.Drawing.Size(110, 20);
            this.txtTTNo.TabIndex = 0;
            this.txtTTNo.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(249, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 215;
            this.label13.Text = "Reference";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 214;
            this.label3.Text = "TDS Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 213;
            this.label2.Text = "On Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 212;
            this.label1.Text = "Transction No";
            // 
            // txtPCode
            // 
            this.txtPCode.Location = new System.Drawing.Point(121, 78);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCode.Properties.MaxLength = 6;
            this.txtPCode.Size = new System.Drawing.Size(110, 20);
            this.txtPCode.TabIndex = 3;
            this.txtPCode.EditValueChanged += new System.EventHandler(this.txtPCode_EditValueChanged);
            this.txtPCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPCode_KeyDown);
            this.txtPCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPCode_KeyPress);
            // 
            // txtPDesc
            // 
            this.txtPDesc.Enabled = false;
            this.txtPDesc.Location = new System.Drawing.Point(252, 78);
            this.txtPDesc.Name = "txtPDesc";
            this.txtPDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPDesc.Properties.ReadOnly = true;
            this.txtPDesc.Size = new System.Drawing.Size(459, 20);
            this.txtPDesc.TabIndex = 220;
            this.txtPDesc.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 221;
            this.label4.Text = "Party";
            // 
            // txtTDSCode
            // 
            this.txtTDSCode.Location = new System.Drawing.Point(121, 108);
            this.txtTDSCode.Name = "txtTDSCode";
            this.txtTDSCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTDSCode.Properties.MaxLength = 4;
            this.txtTDSCode.Size = new System.Drawing.Size(110, 20);
            this.txtTDSCode.TabIndex = 4;
            this.txtTDSCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTDSCode_KeyDown);
            this.txtTDSCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPCode_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 223;
            this.label5.Text = "TDS Code";
            // 
            // txtTDSRate
            // 
            this.txtTDSRate.Enabled = false;
            this.txtTDSRate.Location = new System.Drawing.Point(593, 204);
            this.txtTDSRate.Name = "txtTDSRate";
            this.txtTDSRate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTDSRate.Size = new System.Drawing.Size(118, 20);
            this.txtTDSRate.TabIndex = 8;
            // 
            // txtTDSSurcharge
            // 
            this.txtTDSSurcharge.Enabled = false;
            this.txtTDSSurcharge.Location = new System.Drawing.Point(593, 236);
            this.txtTDSSurcharge.Name = "txtTDSSurcharge";
            this.txtTDSSurcharge.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTDSSurcharge.Properties.NullText = "0";
            this.txtTDSSurcharge.Properties.NullValuePrompt = "0";
            this.txtTDSSurcharge.Size = new System.Drawing.Size(118, 20);
            this.txtTDSSurcharge.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(506, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 225;
            this.label6.Text = "TDS Surcharge";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 228;
            // 
            // txtRemarks
            // 
            this.txtRemarks.EnterMoveNextControl = true;
            this.txtRemarks.Location = new System.Drawing.Point(121, 268);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemarks.Size = new System.Drawing.Size(592, 20);
            this.txtRemarks.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 230;
            this.label8.Text = "Remarks";
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Menu_ToolStrip.CanOverflow = false;
            this.Menu_ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.btnSave,
            this.TextAuthenticate});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Menu_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu_ToolStrip.Size = new System.Drawing.Size(760, 25);
            this.Menu_ToolStrip.TabIndex = 231;
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
            // TextAuthenticate
            // 
            this.TextAuthenticate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TextAuthenticate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextAuthenticate.Name = "TextAuthenticate";
            this.TextAuthenticate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextAuthenticate.Size = new System.Drawing.Size(100, 25);
            // 
            // dtTransDate
            // 
            this.dtTransDate.EditValue = null;
            this.dtTransDate.EnterMoveNextControl = true;
            this.dtTransDate.Location = new System.Drawing.Point(614, 46);
            this.dtTransDate.Name = "dtTransDate";
            this.dtTransDate.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtTransDate.Properties.Appearance.Options.UseBorderColor = true;
            this.dtTransDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue;
            this.dtTransDate.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dtTransDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dtTransDate.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.dtTransDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dtTransDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTransDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtTransDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dtTransDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtTransDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dtTransDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtTransDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.dtTransDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtTransDate.Properties.Mask.BeepOnError = true;
            this.dtTransDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dtTransDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtTransDate.Size = new System.Drawing.Size(98, 20);
            this.dtTransDate.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(578, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 233;
            this.label9.Text = "Date";
            // 
            // txtTDSAmount
            // 
            this.txtTDSAmount.Enabled = false;
            this.txtTDSAmount.Location = new System.Drawing.Point(121, 204);
            this.txtTDSAmount.Name = "txtTDSAmount";
            this.txtTDSAmount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTDSAmount.Properties.Mask.BeepOnError = true;
            this.txtTDSAmount.Properties.Mask.EditMask = "N0";
            this.txtTDSAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTDSAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTDSAmount.Properties.NullText = "0";
            this.txtTDSAmount.Properties.NullValuePrompt = "0";
            this.txtTDSAmount.Size = new System.Drawing.Size(110, 20);
            this.txtTDSAmount.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 235;
            this.label10.Text = "TDS Amount";
            // 
            // txtSurcOnTDS
            // 
            this.txtSurcOnTDS.Enabled = false;
            this.txtSurcOnTDS.Location = new System.Drawing.Point(121, 236);
            this.txtSurcOnTDS.Name = "txtSurcOnTDS";
            this.txtSurcOnTDS.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSurcOnTDS.Properties.Mask.BeepOnError = true;
            this.txtSurcOnTDS.Properties.Mask.EditMask = "N0";
            this.txtSurcOnTDS.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSurcOnTDS.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSurcOnTDS.Properties.NullText = "0";
            this.txtSurcOnTDS.Properties.NullValuePrompt = "0";
            this.txtSurcOnTDS.Size = new System.Drawing.Size(110, 20);
            this.txtSurcOnTDS.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 237;
            this.label11.Text = "Surchare on TDS ";
            // 
            // txtUnderSection
            // 
            this.txtUnderSection.Enabled = false;
            this.txtUnderSection.EnterMoveNextControl = true;
            this.txtUnderSection.Location = new System.Drawing.Point(121, 172);
            this.txtUnderSection.Name = "txtUnderSection";
            this.txtUnderSection.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnderSection.Size = new System.Drawing.Size(591, 20);
            this.txtUnderSection.TabIndex = 295;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 296;
            this.label12.Text = "Under Section";
            // 
            // MyValidationProvider
            // 
            this.MyValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(252, 28);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(508, 296);
            this.HelpGrid.TabIndex = 369;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView,
            this.gridView4,
            this.gridView5});
            this.HelpGrid.Visible = false;
            this.HelpGrid.DoubleClick += new System.EventHandler(this.HelpGrid_DoubleClick);
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
            // gridView4
            // 
            this.gridView4.GridControl = this.HelpGrid;
            this.gridView4.Name = "gridView4";
            // 
            // gridView5
            // 
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.GridControl = this.HelpGrid;
            this.gridView5.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsView.ColumnAutoWidth = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.OptionsView.ShowIndicator = false;
            this.gridView5.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // frmTdsDeductionAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 324);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.txtUnderSection);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSurcOnTDS);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTDSAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtTransDate);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTDSSurcharge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTDSRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTDSCode);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.txtPDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.txtTDSDesc);
            this.Controls.Add(this.txtOnAmount);
            this.Controls.Add(this.txtTTNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmTdsDeductionAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmTdsDeductionAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTdsDeductionAddEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSSurcharge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTransDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTransDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDSAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurcOnTDS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnderSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtReference;
        private DevExpress.XtraEditors.TextEdit txtTDSDesc;
        private DevExpress.XtraEditors.TextEdit txtOnAmount;
        private DevExpress.XtraEditors.TextEdit txtTTNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtPCode;
        private DevExpress.XtraEditors.TextEdit txtPDesc;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtTDSCode;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtTDSRate;
        private DevExpress.XtraEditors.TextEdit txtTDSSurcharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.DateEdit dtTransDate;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtTDSAmount;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtSurcOnTDS;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtUnderSection;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider MyValidationProvider;
        private System.Windows.Forms.ToolStripTextBox TextAuthenticate;
        private System.Windows.Forms.ErrorProvider Error;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
    }
}