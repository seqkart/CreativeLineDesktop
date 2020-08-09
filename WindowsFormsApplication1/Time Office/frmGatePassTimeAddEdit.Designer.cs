namespace WindowsFormsApplication1.Forms_Transaction
{
    partial class frmGatePassTimeAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGatePassTimeAddEdit));
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtPassword = new System.Windows.Forms.ToolStripTextBox();
            this.txtStatusCode = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpCode = new DevExpress.XtraEditors.TextEdit();
            this.lblStatusCode = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.lblEmpCode = new DevExpress.XtraEditors.LabelControl();
            this.txtEmpCodeDesc = new DevExpress.XtraEditors.TextEdit();
            this.DtDate = new DevExpress.XtraEditors.DateEdit();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timeEdit_Time_In = new DevExpress.XtraEditors.TimeEdit();
            this.lblTimeIn = new DevExpress.XtraEditors.LabelControl();
            this.lblTimeOut = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit_Time_Out = new DevExpress.XtraEditors.TimeEdit();
            this.txtStatusCodeDesc = new DevExpress.XtraEditors.TextEdit();
            this.gridControl_GatePassData = new DevExpress.XtraGrid.GridControl();
            this.gridView_GatePassData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PrintPrivewButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.DVPrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.DVPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCodeDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_In.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_Out.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCodeDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GatePassData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_GatePassData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu_ToolStrip
            // 
            this.Menu_ToolStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.Menu_ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Menu_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit,
            this.btnSave,
            this.txtPassword});
            this.Menu_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.Menu_ToolStrip.Name = "Menu_ToolStrip";
            this.Menu_ToolStrip.Size = new System.Drawing.Size(558, 25);
            this.Menu_ToolStrip.TabIndex = 16;
            this.Menu_ToolStrip.Text = "toolStrip1";
            // 
            // btnQuit
            // 
            this.btnQuit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(40, 22);
            this.btnQuit.Text = "Close";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(38, 22);
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(100, 25);
            this.txtPassword.Visible = false;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // txtStatusCode
            // 
            this.txtStatusCode.EnterMoveNextControl = true;
            this.txtStatusCode.Location = new System.Drawing.Point(82, 127);
            this.txtStatusCode.Name = "txtStatusCode";
            this.txtStatusCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatusCode.Properties.MaxLength = 6;
            this.txtStatusCode.Size = new System.Drawing.Size(100, 20);
            this.txtStatusCode.TabIndex = 13;
            this.txtStatusCode.EditValueChanged += new System.EventHandler(this.txtStatusCode_EditValueChanged);
            this.txtStatusCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStatusCode_KeyDown);
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.EnterMoveNextControl = true;
            this.txtEmpCode.Location = new System.Drawing.Point(82, 98);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Properties.MaxLength = 6;
            this.txtEmpCode.Size = new System.Drawing.Size(100, 20);
            this.txtEmpCode.TabIndex = 11;
            this.txtEmpCode.EditValueChanged += new System.EventHandler(this.txtEmpCode_EditValueChanged);
            this.txtEmpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpCode_KeyDown);
            // 
            // lblStatusCode
            // 
            this.lblStatusCode.Location = new System.Drawing.Point(42, 131);
            this.lblStatusCode.Name = "lblStatusCode";
            this.lblStatusCode.Size = new System.Drawing.Size(32, 13);
            this.lblStatusCode.TabIndex = 29;
            this.lblStatusCode.Text = "Status";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(50, 72);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(24, 13);
            this.lblDate.TabIndex = 30;
            this.lblDate.Text = "Date";
            // 
            // lblEmpCode
            // 
            this.lblEmpCode.Location = new System.Drawing.Point(22, 101);
            this.lblEmpCode.Name = "lblEmpCode";
            this.lblEmpCode.Size = new System.Drawing.Size(52, 13);
            this.lblEmpCode.TabIndex = 27;
            this.lblEmpCode.Text = "Emp Code";
            // 
            // txtEmpCodeDesc
            // 
            this.txtEmpCodeDesc.Enabled = false;
            this.txtEmpCodeDesc.Location = new System.Drawing.Point(188, 98);
            this.txtEmpCodeDesc.Name = "txtEmpCodeDesc";
            this.txtEmpCodeDesc.Properties.MaxLength = 6;
            this.txtEmpCodeDesc.Size = new System.Drawing.Size(200, 20);
            this.txtEmpCodeDesc.TabIndex = 12;
            this.txtEmpCodeDesc.TabStop = false;
            // 
            // DtDate
            // 
            this.DtDate.EditValue = null;
            this.DtDate.EnterMoveNextControl = true;
            this.DtDate.Location = new System.Drawing.Point(82, 69);
            this.DtDate.Name = "DtDate";
            this.DtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.DtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.DtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.DtDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DtDate.Size = new System.Drawing.Size(100, 20);
            this.DtDate.TabIndex = 10;
            this.DtDate.EditValueChanged += new System.EventHandler(this.DtDate_EditValueChanged);
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(27, 222);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(391, 197);
            this.HelpGrid.TabIndex = 368;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView,
            this.gridView4,
            this.gridView5});
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
            // timeEdit_Time_In
            // 
            this.timeEdit_Time_In.EditValue = "00:00";
            this.timeEdit_Time_In.Location = new System.Drawing.Point(256, 155);
            this.timeEdit_Time_In.Name = "timeEdit_Time_In";
            this.timeEdit_Time_In.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.timeEdit_Time_In.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.timeEdit_Time_In.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.timeEdit_Time_In.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeEdit_Time_In.Properties.Appearance.Options.UseBackColor = true;
            this.timeEdit_Time_In.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_Time_In.Properties.Appearance.Options.UseForeColor = true;
            this.timeEdit_Time_In.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_Time_In.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEdit_Time_In.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_In.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEdit_Time_In.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_In.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_Time_In.Size = new System.Drawing.Size(100, 20);
            this.timeEdit_Time_In.TabIndex = 16;
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTimeIn.Appearance.Options.UseFont = true;
            this.lblTimeIn.Location = new System.Drawing.Point(210, 158);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(38, 13);
            this.lblTimeIn.TabIndex = 370;
            this.lblTimeIn.Text = "Time In";
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTimeOut.Appearance.Options.UseFont = true;
            this.lblTimeOut.Location = new System.Drawing.Point(27, 158);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(47, 13);
            this.lblTimeOut.TabIndex = 371;
            this.lblTimeOut.Text = "Time Out";
            // 
            // timeEdit_Time_Out
            // 
            this.timeEdit_Time_Out.EditValue = "00:00";
            this.timeEdit_Time_Out.Location = new System.Drawing.Point(82, 155);
            this.timeEdit_Time_Out.Name = "timeEdit_Time_Out";
            this.timeEdit_Time_Out.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.timeEdit_Time_Out.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.timeEdit_Time_Out.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.timeEdit_Time_Out.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.timeEdit_Time_Out.Properties.Appearance.Options.UseBackColor = true;
            this.timeEdit_Time_Out.Properties.Appearance.Options.UseFont = true;
            this.timeEdit_Time_Out.Properties.Appearance.Options.UseForeColor = true;
            this.timeEdit_Time_Out.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit_Time_Out.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEdit_Time_Out.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_Out.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEdit_Time_Out.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeEdit_Time_Out.Properties.NullText = "00:00";
            this.timeEdit_Time_Out.Properties.NullValuePrompt = "00:00";
            this.timeEdit_Time_Out.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.timeEdit_Time_Out.Size = new System.Drawing.Size(100, 20);
            this.timeEdit_Time_Out.TabIndex = 15;
            // 
            // txtStatusCodeDesc
            // 
            this.txtStatusCodeDesc.Enabled = false;
            this.txtStatusCodeDesc.Location = new System.Drawing.Point(188, 127);
            this.txtStatusCodeDesc.Name = "txtStatusCodeDesc";
            this.txtStatusCodeDesc.Properties.MaxLength = 6;
            this.txtStatusCodeDesc.Size = new System.Drawing.Size(200, 20);
            this.txtStatusCodeDesc.TabIndex = 14;
            this.txtStatusCodeDesc.TabStop = false;
            // 
            // gridControl_GatePassData
            // 
            this.gridControl_GatePassData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl_GatePassData.Location = new System.Drawing.Point(0, 245);
            this.gridControl_GatePassData.MainView = this.gridView_GatePassData;
            this.gridControl_GatePassData.Name = "gridControl_GatePassData";
            this.gridControl_GatePassData.Size = new System.Drawing.Size(558, 303);
            this.gridControl_GatePassData.TabIndex = 374;
            this.gridControl_GatePassData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_GatePassData});
            this.gridControl_GatePassData.DoubleClick += new System.EventHandler(this.gridControl_GatePassData_DoubleClick);
            // 
            // gridView_GatePassData
            // 
            this.gridView_GatePassData.GridControl = this.gridControl_GatePassData;
            this.gridView_GatePassData.Name = "gridView_GatePassData";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 375;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ErrorImage = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.profile_icon;
            this.pictureBox1.InitialImage = global::WindowsFormsApplication1.Properties.Resources.Previous;
            this.pictureBox1.Location = new System.Drawing.Point(406, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 376;
            this.pictureBox1.TabStop = false;
            // 
            // PrintPrivewButton
            // 
            this.PrintPrivewButton.Image = global::WindowsFormsApplication1.Properties.Resources.Preview_16x16;
            this.PrintPrivewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintPrivewButton.Location = new System.Drawing.Point(236, 193);
            this.PrintPrivewButton.Name = "PrintPrivewButton";
            this.PrintPrivewButton.Size = new System.Drawing.Size(73, 23);
            this.PrintPrivewButton.TabIndex = 377;
            this.PrintPrivewButton.Text = "Preview";
            this.PrintPrivewButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintPrivewButton.UseVisualStyleBackColor = true;
            this.PrintPrivewButton.Click += new System.EventHandler(this.PrintPrivewButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Image = global::WindowsFormsApplication1.Properties.Resources.Print_16x16;
            this.PrintButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintButton.Location = new System.Drawing.Point(329, 193);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(59, 23);
            this.PrintButton.TabIndex = 378;
            this.PrintButton.Text = "Print";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // DVPrintPreviewDialog
            // 
            this.DVPrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.DVPrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.DVPrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.DVPrintPreviewDialog.Enabled = true;
            this.DVPrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("DVPrintPreviewDialog.Icon")));
            this.DVPrintPreviewDialog.Name = "DVPrintPreviewDialog";
            this.DVPrintPreviewDialog.Visible = false;
            // 
            // DVPrintDocument
            // 
            this.DVPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.DVPrintDocument_PrintPage);
            // 
            // frmGatePassTimeAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 548);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.PrintPrivewButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl_GatePassData);
            this.Controls.Add(this.txtStatusCodeDesc);
            this.Controls.Add(this.timeEdit_Time_In);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.timeEdit_Time_Out);
            this.Controls.Add(this.DtDate);
            this.Controls.Add(this.txtStatusCode);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.txtEmpCodeDesc);
            this.Controls.Add(this.lblStatusCode);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblEmpCode);
            this.Controls.Add(this.Menu_ToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmGatePassTimeAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmGatePassTimeAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGatePassTimeAddEdit_KeyDown);
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpCodeDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_In.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Time_Out.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatusCodeDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GatePassData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_GatePassData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripTextBox txtPassword;
        private DevExpress.XtraEditors.TextEdit txtStatusCode;
        private DevExpress.XtraEditors.TextEdit txtEmpCode;
        private DevExpress.XtraEditors.LabelControl lblStatusCode;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl lblEmpCode;
        private DevExpress.XtraEditors.TextEdit txtEmpCodeDesc;
        private DevExpress.XtraEditors.DateEdit DtDate;
        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.TimeEdit timeEdit_Time_In;
        private DevExpress.XtraEditors.LabelControl lblTimeIn;
        private DevExpress.XtraEditors.LabelControl lblTimeOut;
        private DevExpress.XtraEditors.TimeEdit timeEdit_Time_Out;
        private DevExpress.XtraEditors.TextEdit txtStatusCodeDesc;
        private DevExpress.XtraGrid.GridControl gridControl_GatePassData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_GatePassData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PrintPrivewButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.PrintPreviewDialog DVPrintPreviewDialog;
        private System.Drawing.Printing.PrintDocument DVPrintDocument;
    }
}