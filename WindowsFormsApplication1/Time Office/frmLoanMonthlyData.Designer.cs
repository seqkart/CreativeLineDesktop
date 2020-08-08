namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmLoanMonthlyData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoanMonthlyData));
            this.HelpGridCtrl = new DevExpress.XtraGrid.GridControl();
            this.HelpGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btn_Quit = new System.Windows.Forms.ToolStripButton();
            this.btn_Save = new System.Windows.Forms.ToolStripButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.DtDateOff = new DevExpress.XtraEditors.DateEdit();
            this.txtSplTag = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.txt = new DevExpress.XtraEditors.TextEdit();
            this.txtLoanInt = new DevExpress.XtraEditors.TextEdit();
            this.DtMonthYear = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtDateOff.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDateOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSplTag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanInt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtMonthYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // HelpGridCtrl
            // 
            this.HelpGridCtrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.HelpGridCtrl.Location = new System.Drawing.Point(86, 30);
            this.HelpGridCtrl.MainView = this.HelpGrid;
            this.HelpGridCtrl.Name = "HelpGridCtrl";
            this.HelpGridCtrl.Size = new System.Drawing.Size(313, 119);
            this.HelpGridCtrl.TabIndex = 43;
            this.HelpGridCtrl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGrid});
            this.HelpGridCtrl.Visible = false;
            this.HelpGridCtrl.Click += new System.EventHandler(this.HelpGridCtrl_Click);
            this.HelpGridCtrl.DoubleClick += new System.EventHandler(this.HelpGridCtrl_DoubleClick);
            this.HelpGridCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HelpGridCtrl_KeyDown);
            // 
            // HelpGrid
            // 
            this.HelpGrid.GridControl = this.HelpGridCtrl;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.OptionsView.ShowGroupPanel = false;
            this.HelpGrid.OptionsView.ShowIndicator = false;
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Quit,
            this.btn_Save});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.Size = new System.Drawing.Size(399, 25);
            this.Menu_ToolStrip.TabIndex = 42;
            this.Menu_ToolStrip.Text = "toolStrip2";
            // 
            // btn_Quit
            // 
            this.btn_Quit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Quit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Quit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quit.ForeColor = System.Drawing.Color.White;
            this.btn_Quit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Quit.Image")));
            this.btn_Quit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(35, 22);
            this.btn_Quit.Text = "&Quit";
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(38, 22);
            this.btn_Save.Text = "&Save";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(626, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = "Date Of";
            this.labelControl2.Visible = false;
            // 
            // DtDateOff
            // 
            this.DtDateOff.EditValue = null;
            this.DtDateOff.EnterMoveNextControl = true;
            this.DtDateOff.Location = new System.Drawing.Point(655, 43);
            this.DtDateOff.Name = "DtDateOff";
            this.DtDateOff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtDateOff.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtDateOff.Properties.Mask.EditMask = "";
            this.DtDateOff.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DtDateOff.Size = new System.Drawing.Size(10, 20);
            this.DtDateOff.TabIndex = 35;
            this.DtDateOff.Visible = false;
            // 
            // txtSplTag
            // 
            this.txtSplTag.EditValue = "D";
            this.txtSplTag.Enabled = false;
            this.txtSplTag.EnterMoveNextControl = true;
            this.txtSplTag.Location = new System.Drawing.Point(655, 47);
            this.txtSplTag.Name = "txtSplTag";
            this.txtSplTag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSplTag.Properties.MaxLength = 4;
            this.txtSplTag.Size = new System.Drawing.Size(10, 20);
            this.txtSplTag.TabIndex = 32;
            this.txtSplTag.Visible = false;
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.EditValue = "";
            this.txtEmpCode.EnterMoveNextControl = true;
            this.txtEmpCode.Location = new System.Drawing.Point(86, 80);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpCode.Properties.MaxLength = 5;
            this.txtEmpCode.Size = new System.Drawing.Size(84, 20);
            this.txtEmpCode.TabIndex = 2;
            this.txtEmpCode.EditValueChanged += new System.EventHandler(this.TxtEmpCode_EditValueChanged);
            this.txtEmpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpCode_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 109);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 38;
            this.labelControl3.Text = "LoanInstlmnt";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(32, 83);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(52, 13);
            this.labelControl12.TabIndex = 39;
            this.labelControl12.Text = "Emp Code";
            // 
            // labelControl26
            // 
            this.labelControl26.Location = new System.Drawing.Point(28, 57);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(56, 13);
            this.labelControl26.TabIndex = 37;
            this.labelControl26.Text = "MonthYear";
            // 
            // txt
            // 
            this.txt.EnterMoveNextControl = true;
            this.txt.Location = new System.Drawing.Point(655, 47);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(10, 20);
            this.txt.TabIndex = 36;
            this.txt.Visible = false;
            // 
            // txtLoanInt
            // 
            this.txtLoanInt.EditValue = "";
            this.txtLoanInt.EnterMoveNextControl = true;
            this.txtLoanInt.Location = new System.Drawing.Point(86, 106);
            this.txtLoanInt.Name = "txtLoanInt";
            this.txtLoanInt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLoanInt.Properties.MaxLength = 5;
            this.txtLoanInt.Size = new System.Drawing.Size(84, 20);
            this.txtLoanInt.TabIndex = 4;
            this.txtLoanInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanInt_KeyPress);
            // 
            // DtMonthYear
            // 
            this.DtMonthYear.Location = new System.Drawing.Point(86, 54);
            this.DtMonthYear.Name = "DtMonthYear";
            this.DtMonthYear.Properties.DisplayFormat.FormatString = "MM-yyyy";
            this.DtMonthYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtMonthYear.Properties.EditFormat.FormatString = "MM-yyyy";
            this.DtMonthYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtMonthYear.Properties.Mask.EditMask = "MM-yyyy";
            this.DtMonthYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.DtMonthYear.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtMonthYear.Properties.MaxLength = 6;
            this.DtMonthYear.Size = new System.Drawing.Size(84, 20);
            this.DtMonthYear.TabIndex = 1;
            // 
            // txtEmpName
            // 
            this.txtEmpName.EditValue = "";
            this.txtEmpName.Enabled = false;
            this.txtEmpName.EnterMoveNextControl = true;
            this.txtEmpName.Location = new System.Drawing.Point(190, 80);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtEmpName.Properties.MaxLength = 5;
            this.txtEmpName.Size = new System.Drawing.Size(187, 20);
            this.txtEmpName.TabIndex = 3;
            this.txtEmpName.TabStop = false;
            // 
            // frmLoanMonthlyData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 151);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGridCtrl);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.DtMonthYear);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.DtDateOff);
            this.Controls.Add(this.txtSplTag);
            this.Controls.Add(this.txtLoanInt);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl26);
            this.Controls.Add(this.txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLoanMonthlyData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmLoanMonthlyData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtDateOff.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDateOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSplTag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanInt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtMonthYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl HelpGridCtrl;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGrid;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btn_Quit;
        private System.Windows.Forms.ToolStripButton btn_Save;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit DtDateOff;
        private DevExpress.XtraEditors.TextEdit txtSplTag;
        private DevExpress.XtraEditors.TextEdit txtEmpCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraEditors.TextEdit txt;
        private DevExpress.XtraEditors.TextEdit txtLoanInt;
        private DevExpress.XtraEditors.TextEdit DtMonthYear;
        private DevExpress.XtraEditors.TextEdit txtEmpName;
    }
}