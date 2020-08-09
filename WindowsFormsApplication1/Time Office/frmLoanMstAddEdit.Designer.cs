namespace WindowsFormsApplication1.Forms_Master
{
    partial class frmLoanMstAddEdit
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
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtEmpCode = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpName = new DevExpress.XtraEditors.TextEdit();
            this.txtDept = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoanAmount = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoanInstlmnt = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtMonthYear = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoanNo = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLoanDate = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPreviousInstlmnt = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanInstlmnt.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousInstlmnt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(67, 29);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(359, 160);
            this.HelpGrid.TabIndex = 256;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView});
            this.HelpGrid.Visible = false;
            this.HelpGrid.Click += new System.EventHandler(this.HelpGrid_Click);
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
            // txtEmpCode
            // 
            this.txtEmpCode.EnterMoveNextControl = true;
            this.txtEmpCode.Location = new System.Drawing.Point(85, 71);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpCode.Properties.MaxLength = 6;
            this.txtEmpCode.Size = new System.Drawing.Size(64, 20);
            this.txtEmpCode.TabIndex = 1;
            this.txtEmpCode.EditValueChanged += new System.EventHandler(this.txtEmpCode_EditValueChanged);
            this.txtEmpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpCode_KeyDown);
            // 
            // txtEmpName
            // 
            this.txtEmpName.Enabled = false;
            this.txtEmpName.EnterMoveNextControl = true;
            this.txtEmpName.Location = new System.Drawing.Point(155, 71);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmpName.Properties.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(250, 20);
            this.txtEmpName.TabIndex = 2;
            this.txtEmpName.TabStop = false;
            // 
            // txtDept
            // 
            this.txtDept.Enabled = false;
            this.txtDept.EnterMoveNextControl = true;
            this.txtDept.Location = new System.Drawing.Point(85, 97);
            this.txtDept.Name = "txtDept";
            this.txtDept.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept.Properties.MaxLength = 30;
            this.txtDept.Size = new System.Drawing.Size(320, 20);
            this.txtDept.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 253;
            this.label2.Text = "EmpName";
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.EnterMoveNextControl = true;
            this.txtLoanAmount.Location = new System.Drawing.Point(85, 123);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLoanAmount.Properties.MaxLength = 30;
            this.txtLoanAmount.Size = new System.Drawing.Size(68, 20);
            this.txtLoanAmount.TabIndex = 5;
            this.txtLoanAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanAmount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 259;
            this.label4.Text = "LoanAmt";
            // 
            // txtLoanInstlmnt
            // 
            this.txtLoanInstlmnt.EnterMoveNextControl = true;
            this.txtLoanInstlmnt.Location = new System.Drawing.Point(85, 154);
            this.txtLoanInstlmnt.Name = "txtLoanInstlmnt";
            this.txtLoanInstlmnt.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLoanInstlmnt.Properties.MaxLength = 30;
            this.txtLoanInstlmnt.Size = new System.Drawing.Size(68, 20);
            this.txtLoanInstlmnt.TabIndex = 7;
            this.txtLoanInstlmnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoanInstlmnt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 263;
            this.label1.Text = "Loan Instlmnt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 268;
            this.label8.Text = "Dept";
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(426, 27);
            this.Menu_ToolStrip.TabIndex = 269;
            this.Menu_ToolStrip.Text = "Options";
            this.Menu_ToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ToolStrip_ItemClicked);
            // 
            // btnQuit
            // 
            this.btnQuit.Image = global::WindowsFormsApplication1.Properties.Resources.Close;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnQuit.Size = new System.Drawing.Size(66, 24);
            this.btnQuit.Text = "Close";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.btnSave.Size = new System.Drawing.Size(64, 24);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMonthYear
            // 
            this.txtMonthYear.EnterMoveNextControl = true;
            this.txtMonthYear.Location = new System.Drawing.Point(85, 41);
            this.txtMonthYear.Name = "txtMonthYear";
            this.txtMonthYear.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMonthYear.Properties.DisplayFormat.FormatString = "MM-yyyy";
            this.txtMonthYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMonthYear.Properties.EditFormat.FormatString = "MM-yyyy";
            this.txtMonthYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMonthYear.Properties.Mask.EditMask = "MM-yyyy";
            this.txtMonthYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtMonthYear.Properties.MaxLength = 30;
            this.txtMonthYear.Size = new System.Drawing.Size(64, 20);
            this.txtMonthYear.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 271;
            this.label9.Text = "MonthYear";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.Enabled = false;
            this.txtLoanNo.Location = new System.Drawing.Point(337, 41);
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLoanNo.Properties.MaxLength = 30;
            this.txtLoanNo.Size = new System.Drawing.Size(68, 20);
            this.txtLoanNo.TabIndex = 272;
            this.txtLoanNo.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(285, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 273;
            this.label10.Text = "Loan No";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLoanDate
            // 
            this.txtLoanDate.EnterMoveNextControl = true;
            this.txtLoanDate.Location = new System.Drawing.Point(220, 41);
            this.txtLoanDate.Name = "txtLoanDate";
            this.txtLoanDate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLoanDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.txtLoanDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtLoanDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.txtLoanDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtLoanDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.txtLoanDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.txtLoanDate.Properties.MaxLength = 30;
            this.txtLoanDate.Size = new System.Drawing.Size(64, 20);
            this.txtLoanDate.TabIndex = 274;
            this.txtLoanDate.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(155, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 275;
            this.label11.Text = "Loan Date";
            // 
            // txtPreviousInstlmnt
            // 
            this.txtPreviousInstlmnt.Enabled = false;
            this.txtPreviousInstlmnt.EnterMoveNextControl = true;
            this.txtPreviousInstlmnt.Location = new System.Drawing.Point(337, 153);
            this.txtPreviousInstlmnt.Name = "txtPreviousInstlmnt";
            this.txtPreviousInstlmnt.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPreviousInstlmnt.Properties.MaxLength = 30;
            this.txtPreviousInstlmnt.Size = new System.Drawing.Size(68, 20);
            this.txtPreviousInstlmnt.TabIndex = 390;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(236, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 391;
            this.label13.Text = "Previous Instlmnt";
            // 
            // frmLoanMstAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 194);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.txtPreviousInstlmnt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtLoanDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtLoanNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMonthYear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLoanInstlmnt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoanAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLoanMstAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmLoanMstAddEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanInstlmnt.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreviousInstlmnt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraEditors.TextEdit txtEmpCode;
        private DevExpress.XtraEditors.TextEdit txtEmpName;
        private DevExpress.XtraEditors.TextEdit txtDept;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtLoanAmount;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtLoanInstlmnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtMonthYear;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtLoanNo;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtLoanDate;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtPreviousInstlmnt;
        private System.Windows.Forms.Label label13;
    }
}