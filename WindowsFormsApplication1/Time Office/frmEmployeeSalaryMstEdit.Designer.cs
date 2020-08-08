namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmEmployeeSalaryMstEdit
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
            this.txtEmpCode = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPetrol1 = new DevExpress.XtraEditors.TextEdit();
            this.txtPetrol = new DevExpress.XtraEditors.TextEdit();
            this.txtConvenyance1 = new DevExpress.XtraEditors.TextEdit();
            this.txtConvenyance = new DevExpress.XtraEditors.TextEdit();
            this.txtHRA1 = new DevExpress.XtraEditors.TextEdit();
            this.txtBasicPay1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHRA = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.txtBasicPay = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFHName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.DtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal2 = new DevExpress.XtraEditors.TextEdit();
            this.txtTotal1 = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEmpSplAlw = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpSplAlw1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPetrol1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPetrol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvenyance1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvenyance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRA1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicPay1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicPay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFHName.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSplAlw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSplAlw1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.EnterMoveNextControl = true;
            this.txtEmpCode.Location = new System.Drawing.Point(95, 70);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpCode.Properties.MaxLength = 5;
            this.txtEmpCode.Properties.ReadOnly = true;
            this.txtEmpCode.Size = new System.Drawing.Size(78, 20);
            this.txtEmpCode.TabIndex = 2;
            this.txtEmpCode.TabStop = false;
            // 
            // txtEmpName
            // 
            this.txtEmpName.EnterMoveNextControl = true;
            this.txtEmpName.Location = new System.Drawing.Point(191, 70);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpName.Properties.MaxLength = 40;
            this.txtEmpName.Properties.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(151, 20);
            this.txtEmpName.TabIndex = 3;
            this.txtEmpName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 228;
            this.label2.Text = "Petrol";
            // 
            // txtPetrol1
            // 
            this.txtPetrol1.EditValue = "0";
            this.txtPetrol1.EnterMoveNextControl = true;
            this.txtPetrol1.Location = new System.Drawing.Point(263, 201);
            this.txtPetrol1.Name = "txtPetrol1";
            this.txtPetrol1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPetrol1.Properties.DisplayFormat.FormatString = "n2";
            this.txtPetrol1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPetrol1.Properties.EditFormat.FormatString = "n2";
            this.txtPetrol1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPetrol1.Properties.Mask.EditMask = "n2";
            this.txtPetrol1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPetrol1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPetrol1.Size = new System.Drawing.Size(75, 20);
            this.txtPetrol1.TabIndex = 14;
            this.txtPetrol1.EditValueChanged += new System.EventHandler(this.txtTotal2_EditValueChanged);
            this.txtPetrol1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPetrol1_KeyPress);
            // 
            // txtPetrol
            // 
            this.txtPetrol.EditValue = "0";
            this.txtPetrol.EnterMoveNextControl = true;
            this.txtPetrol.Location = new System.Drawing.Point(95, 201);
            this.txtPetrol.Name = "txtPetrol";
            this.txtPetrol.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPetrol.Properties.DisplayFormat.FormatString = "n2";
            this.txtPetrol.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPetrol.Properties.EditFormat.FormatString = "n2";
            this.txtPetrol.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPetrol.Properties.Mask.EditMask = "n2";
            this.txtPetrol.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPetrol.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPetrol.Size = new System.Drawing.Size(75, 20);
            this.txtPetrol.TabIndex = 8;
            this.txtPetrol.EditValueChanged += new System.EventHandler(this.txtTotal1_EditValueChanged);
            // 
            // txtConvenyance1
            // 
            this.txtConvenyance1.EditValue = "0";
            this.txtConvenyance1.EnterMoveNextControl = true;
            this.txtConvenyance1.Location = new System.Drawing.Point(263, 175);
            this.txtConvenyance1.Name = "txtConvenyance1";
            this.txtConvenyance1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConvenyance1.Properties.DisplayFormat.FormatString = "n2";
            this.txtConvenyance1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtConvenyance1.Properties.EditFormat.FormatString = "n2";
            this.txtConvenyance1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtConvenyance1.Properties.Mask.EditMask = "n2";
            this.txtConvenyance1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtConvenyance1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtConvenyance1.Size = new System.Drawing.Size(75, 20);
            this.txtConvenyance1.TabIndex = 13;
            this.txtConvenyance1.EditValueChanged += new System.EventHandler(this.txtTotal2_EditValueChanged);
            this.txtConvenyance1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenyance1_KeyPress);
            // 
            // txtConvenyance
            // 
            this.txtConvenyance.EditValue = "0";
            this.txtConvenyance.EnterMoveNextControl = true;
            this.txtConvenyance.Location = new System.Drawing.Point(95, 175);
            this.txtConvenyance.Name = "txtConvenyance";
            this.txtConvenyance.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConvenyance.Properties.DisplayFormat.FormatString = "n2";
            this.txtConvenyance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtConvenyance.Properties.EditFormat.FormatString = "n2";
            this.txtConvenyance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtConvenyance.Properties.Mask.EditMask = "n2";
            this.txtConvenyance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtConvenyance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtConvenyance.Size = new System.Drawing.Size(75, 20);
            this.txtConvenyance.TabIndex = 7;
            this.txtConvenyance.EditValueChanged += new System.EventHandler(this.txtTotal1_EditValueChanged);
            // 
            // txtHRA1
            // 
            this.txtHRA1.EditValue = "0";
            this.txtHRA1.EnterMoveNextControl = true;
            this.txtHRA1.Location = new System.Drawing.Point(263, 149);
            this.txtHRA1.Name = "txtHRA1";
            this.txtHRA1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHRA1.Properties.DisplayFormat.FormatString = "n2";
            this.txtHRA1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHRA1.Properties.EditFormat.FormatString = "n2";
            this.txtHRA1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHRA1.Properties.Mask.EditMask = "n2";
            this.txtHRA1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHRA1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHRA1.Size = new System.Drawing.Size(75, 20);
            this.txtHRA1.TabIndex = 12;
            this.txtHRA1.EditValueChanged += new System.EventHandler(this.txtTotal2_EditValueChanged);
            this.txtHRA1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHRA1_KeyPress);
            // 
            // txtBasicPay1
            // 
            this.txtBasicPay1.AllowDrop = true;
            this.txtBasicPay1.EditValue = "0";
            this.txtBasicPay1.EnterMoveNextControl = true;
            this.txtBasicPay1.Location = new System.Drawing.Point(263, 121);
            this.txtBasicPay1.Name = "txtBasicPay1";
            this.txtBasicPay1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBasicPay1.Properties.DisplayFormat.FormatString = "n2";
            this.txtBasicPay1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBasicPay1.Properties.EditFormat.FormatString = "n2";
            this.txtBasicPay1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBasicPay1.Properties.Mask.EditMask = "n2";
            this.txtBasicPay1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBasicPay1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBasicPay1.Size = new System.Drawing.Size(75, 20);
            this.txtBasicPay1.TabIndex = 11;
            this.txtBasicPay1.EditValueChanged += new System.EventHandler(this.txtTotal2_EditValueChanged);
            this.txtBasicPay1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBasicPay1_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(55, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 233;
            this.labelControl1.Text = "Code";
            // 
            // txtHRA
            // 
            this.txtHRA.EditValue = "0";
            this.txtHRA.EnterMoveNextControl = true;
            this.txtHRA.Location = new System.Drawing.Point(95, 149);
            this.txtHRA.Name = "txtHRA";
            this.txtHRA.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHRA.Properties.DisplayFormat.FormatString = "n2";
            this.txtHRA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHRA.Properties.EditFormat.FormatString = "n2";
            this.txtHRA.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtHRA.Properties.Mask.EditMask = "n2";
            this.txtHRA.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHRA.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHRA.Size = new System.Drawing.Size(75, 20);
            this.txtHRA.TabIndex = 6;
            this.txtHRA.EditValueChanged += new System.EventHandler(this.txtTotal1_EditValueChanged);
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(51, 150);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(31, 13);
            this.labelControl22.TabIndex = 227;
            this.labelControl22.Text = "H.R.A.";
            // 
            // txtBasicPay
            // 
            this.txtBasicPay.EditValue = "0";
            this.txtBasicPay.EnterMoveNextControl = true;
            this.txtBasicPay.Location = new System.Drawing.Point(95, 121);
            this.txtBasicPay.Name = "txtBasicPay";
            this.txtBasicPay.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBasicPay.Properties.DisplayFormat.FormatString = "n2";
            this.txtBasicPay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBasicPay.Properties.EditFormat.FormatString = "n2";
            this.txtBasicPay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBasicPay.Properties.Mask.EditMask = "n2";
            this.txtBasicPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBasicPay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBasicPay.Size = new System.Drawing.Size(75, 20);
            this.txtBasicPay.TabIndex = 5;
            this.txtBasicPay.EditValueChanged += new System.EventHandler(this.txtTotal1_EditValueChanged);
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(37, 122);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(45, 13);
            this.labelControl23.TabIndex = 226;
            this.labelControl23.Text = "Basic Pay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 225;
            this.label1.Text = "Convyance";
            // 
            // txtFHName
            // 
            this.txtFHName.EnterMoveNextControl = true;
            this.txtFHName.Location = new System.Drawing.Point(95, 96);
            this.txtFHName.Name = "txtFHName";
            this.txtFHName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFHName.Properties.MaxLength = 40;
            this.txtFHName.Properties.ReadOnly = true;
            this.txtFHName.Size = new System.Drawing.Size(248, 20);
            this.txtFHName.TabIndex = 4;
            this.txtFHName.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 236;
            this.label3.Text = "F/H Name";
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(359, 25);
            this.Menu_ToolStrip.TabIndex = 237;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnQuit.Image = global::WindowsFormsApplication1.Properties.Resources.Close;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(56, 22);
            this.btnQuit.Text = "Close";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSave.Image = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DtStartDate
            // 
            this.DtStartDate.EditValue = null;
            this.DtStartDate.EnterMoveNextControl = true;
            this.DtStartDate.Location = new System.Drawing.Point(95, 44);
            this.DtStartDate.Name = "DtStartDate";
            this.DtStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DtStartDate.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtStartDate.Properties.Appearance.Options.UseBorderColor = true;
            this.DtStartDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue;
            this.DtStartDate.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DodgerBlue;
            this.DtStartDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DtStartDate.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.DtStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.DtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtStartDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.DtStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtStartDate.Properties.EditFormat.FormatString = "MM-yyyy";
            this.DtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtStartDate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.DtStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DtStartDate.Properties.Mask.BeepOnError = true;
            this.DtStartDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.DtStartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.DtStartDate.Size = new System.Drawing.Size(78, 20);
            this.DtStartDate.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 239;
            this.labelControl3.Text = "Month/Year";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(56, 256);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 13);
            this.labelControl4.TabIndex = 351;
            this.labelControl4.Text = "Total";
            // 
            // txtTotal2
            // 
            this.txtTotal2.EditValue = "0";
            this.txtTotal2.EnterMoveNextControl = true;
            this.txtTotal2.Location = new System.Drawing.Point(264, 253);
            this.txtTotal2.Name = "txtTotal2";
            this.txtTotal2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal2.Properties.DisplayFormat.FormatString = "n2";
            this.txtTotal2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal2.Properties.EditFormat.FormatString = "n2";
            this.txtTotal2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal2.Properties.Mask.EditMask = "n2";
            this.txtTotal2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotal2.Properties.ReadOnly = true;
            this.txtTotal2.Size = new System.Drawing.Size(74, 20);
            this.txtTotal2.TabIndex = 16;
            this.txtTotal2.TabStop = false;
            this.txtTotal2.EditValueChanged += new System.EventHandler(this.txtTotal2_EditValueChanged);
            // 
            // txtTotal1
            // 
            this.txtTotal1.EditValue = "0";
            this.txtTotal1.EnterMoveNextControl = true;
            this.txtTotal1.Location = new System.Drawing.Point(95, 253);
            this.txtTotal1.Name = "txtTotal1";
            this.txtTotal1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal1.Properties.DisplayFormat.FormatString = "n2";
            this.txtTotal1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal1.Properties.EditFormat.FormatString = "n2";
            this.txtTotal1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal1.Properties.Mask.EditMask = "n2";
            this.txtTotal1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotal1.Properties.ReadOnly = true;
            this.txtTotal1.Size = new System.Drawing.Size(74, 20);
            this.txtTotal1.TabIndex = 10;
            this.txtTotal1.TabStop = false;
            this.txtTotal1.EditValueChanged += new System.EventHandler(this.txtTotal1_EditValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 364;
            this.label15.Text = "Spl Allowance";
            // 
            // txtEmpSplAlw
            // 
            this.txtEmpSplAlw.EditValue = "0";
            this.txtEmpSplAlw.EnterMoveNextControl = true;
            this.txtEmpSplAlw.Location = new System.Drawing.Point(95, 227);
            this.txtEmpSplAlw.Name = "txtEmpSplAlw";
            this.txtEmpSplAlw.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpSplAlw.Properties.DisplayFormat.FormatString = "n2";
            this.txtEmpSplAlw.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSplAlw.Properties.EditFormat.FormatString = "n2";
            this.txtEmpSplAlw.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSplAlw.Properties.Mask.EditMask = "n2";
            this.txtEmpSplAlw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEmpSplAlw.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtEmpSplAlw.Size = new System.Drawing.Size(74, 20);
            this.txtEmpSplAlw.TabIndex = 9;
            this.txtEmpSplAlw.EditValueChanged += new System.EventHandler(this.txtTotal1_EditValueChanged);
            // 
            // txtEmpSplAlw1
            // 
            this.txtEmpSplAlw1.EditValue = "0";
            this.txtEmpSplAlw1.EnterMoveNextControl = true;
            this.txtEmpSplAlw1.Location = new System.Drawing.Point(263, 227);
            this.txtEmpSplAlw1.Name = "txtEmpSplAlw1";
            this.txtEmpSplAlw1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpSplAlw1.Properties.DisplayFormat.FormatString = "n2";
            this.txtEmpSplAlw1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSplAlw1.Properties.EditFormat.FormatString = "n2";
            this.txtEmpSplAlw1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpSplAlw1.Properties.Mask.EditMask = "n2";
            this.txtEmpSplAlw1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEmpSplAlw1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtEmpSplAlw1.Size = new System.Drawing.Size(74, 20);
            this.txtEmpSplAlw1.TabIndex = 15;
            this.txtEmpSplAlw1.EditValueChanged += new System.EventHandler(this.txtTotal2_EditValueChanged);
            // 
            // frmEmployeeSalaryMstEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 290);
            this.ControlBox = false;
            this.Controls.Add(this.txtEmpSplAlw1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtEmpSplAlw);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtTotal2);
            this.Controls.Add(this.txtTotal1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.DtStartDate);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtFHName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPetrol1);
            this.Controls.Add(this.txtPetrol);
            this.Controls.Add(this.txtConvenyance1);
            this.Controls.Add(this.txtConvenyance);
            this.Controls.Add(this.txtHRA1);
            this.Controls.Add(this.txtBasicPay1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtHRA);
            this.Controls.Add(this.labelControl22);
            this.Controls.Add(this.txtBasicPay);
            this.Controls.Add(this.labelControl23);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmEmployeeSalaryMstEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmEmployeeSalaryMstEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPetrol1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPetrol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvenyance1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvenyance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRA1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicPay1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicPay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFHName.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSplAlw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpSplAlw1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtEmpCode;
        private DevExpress.XtraEditors.TextEdit txtEmpName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtPetrol1;
        private DevExpress.XtraEditors.TextEdit txtPetrol;
        private DevExpress.XtraEditors.TextEdit txtConvenyance1;
        private DevExpress.XtraEditors.TextEdit txtConvenyance;
        private DevExpress.XtraEditors.TextEdit txtHRA1;
        private DevExpress.XtraEditors.TextEdit txtBasicPay1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtHRA;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.TextEdit txtBasicPay;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtFHName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.DateEdit DtStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTotal2;
        private DevExpress.XtraEditors.TextEdit txtTotal1;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.TextEdit txtEmpSplAlw;
        private DevExpress.XtraEditors.TextEdit txtEmpSplAlw1;
    }
}