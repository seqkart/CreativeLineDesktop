namespace WindowsFormsApplication1
{
    partial class frmProductMstAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductMstAddEdit));
            this.label2 = new System.Windows.Forms.Label();
            this.txtHSNNo = new DevExpress.XtraEditors.TextEdit();
            this.txtTaxCodePLDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtTaxCodePCDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtTaxCodePL = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTaxCodePC = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.PDTab = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtUMDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtUMCode = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGrpDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtGrpCode = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSGrpDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtSGrpCode = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOSQty = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.ProductTabCtrl = new DevExpress.XtraTab.XtraTabControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtPrdName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtProductAsgnCode = new DevExpress.XtraEditors.TextEdit();
            this.txtPrdCode = new DevExpress.XtraEditors.TextEdit();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtstatusTag = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHSNNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePLDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePCDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePC.Properties)).BeginInit();
            this.PDTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUMDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUMCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOSQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductTabCtrl)).BeginInit();
            this.ProductTabCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdName.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductAsgnCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstatusTag.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 340;
            this.label2.Text = "Prd HSNNo";
            // 
            // txtHSNNo
            // 
            this.txtHSNNo.EnterMoveNextControl = true;
            this.txtHSNNo.Location = new System.Drawing.Point(109, 142);
            this.txtHSNNo.Name = "txtHSNNo";
            this.txtHSNNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHSNNo.Properties.MaxLength = 8;
            this.txtHSNNo.Size = new System.Drawing.Size(69, 20);
            this.txtHSNNo.TabIndex = 339;
            // 
            // txtTaxCodePLDesc
            // 
            this.txtTaxCodePLDesc.Enabled = false;
            this.txtTaxCodePLDesc.Location = new System.Drawing.Point(190, 195);
            this.txtTaxCodePLDesc.Name = "txtTaxCodePLDesc";
            this.txtTaxCodePLDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxCodePLDesc.Properties.ReadOnly = true;
            this.txtTaxCodePLDesc.Size = new System.Drawing.Size(422, 20);
            this.txtTaxCodePLDesc.TabIndex = 333;
            this.txtTaxCodePLDesc.TabStop = false;
            // 
            // txtTaxCodePCDesc
            // 
            this.txtTaxCodePCDesc.Enabled = false;
            this.txtTaxCodePCDesc.Location = new System.Drawing.Point(190, 168);
            this.txtTaxCodePCDesc.Name = "txtTaxCodePCDesc";
            this.txtTaxCodePCDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxCodePCDesc.Properties.ReadOnly = true;
            this.txtTaxCodePCDesc.Size = new System.Drawing.Size(422, 20);
            this.txtTaxCodePCDesc.TabIndex = 332;
            this.txtTaxCodePCDesc.TabStop = false;
            // 
            // txtTaxCodePL
            // 
            this.txtTaxCodePL.EnterMoveNextControl = true;
            this.txtTaxCodePL.Location = new System.Drawing.Point(109, 195);
            this.txtTaxCodePL.Name = "txtTaxCodePL";
            this.txtTaxCodePL.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxCodePL.Properties.MaxLength = 6;
            this.txtTaxCodePL.Size = new System.Drawing.Size(69, 20);
            this.txtTaxCodePL.TabIndex = 38;
            this.txtTaxCodePL.EditValueChanged += new System.EventHandler(this.txtSTL_EditValueChanged);
            this.txtTaxCodePL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSTL_KeyDown);
            this.txtTaxCodePL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUMCode_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 328;
            this.label6.Text = "Purchase Local";
            // 
            // txtTaxCodePC
            // 
            this.txtTaxCodePC.EnterMoveNextControl = true;
            this.txtTaxCodePC.Location = new System.Drawing.Point(109, 168);
            this.txtTaxCodePC.Name = "txtTaxCodePC";
            this.txtTaxCodePC.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxCodePC.Properties.MaxLength = 6;
            this.txtTaxCodePC.Size = new System.Drawing.Size(69, 20);
            this.txtTaxCodePC.TabIndex = 37;
            this.txtTaxCodePC.EditValueChanged += new System.EventHandler(this.txtTaxST_EditValueChanged);
            this.txtTaxCodePC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaxST_KeyDown);
            this.txtTaxCodePC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUMCode_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 327;
            this.label7.Text = "Purchase Central";
            // 
            // PDTab
            // 
            this.PDTab.Controls.Add(this.panelControl1);
            this.PDTab.Name = "PDTab";
            this.PDTab.Size = new System.Drawing.Size(702, 271);
            this.PDTab.Text = "Product Details";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtUMDesc);
            this.panelControl1.Controls.Add(this.txtUMCode);
            this.panelControl1.Controls.Add(this.txtHSNNo);
            this.panelControl1.Controls.Add(this.label13);
            this.panelControl1.Controls.Add(this.txtGrpDesc);
            this.panelControl1.Controls.Add(this.txtTaxCodePLDesc);
            this.panelControl1.Controls.Add(this.txtTaxCodePCDesc);
            this.panelControl1.Controls.Add(this.txtGrpCode);
            this.panelControl1.Controls.Add(this.label15);
            this.panelControl1.Controls.Add(this.txtTaxCodePL);
            this.panelControl1.Controls.Add(this.txtSGrpDesc);
            this.panelControl1.Controls.Add(this.txtSGrpCode);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.label14);
            this.panelControl1.Controls.Add(this.txtOSQty);
            this.panelControl1.Controls.Add(this.txtTaxCodePC);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(702, 271);
            this.panelControl1.TabIndex = 5;
            // 
            // txtUMDesc
            // 
            this.txtUMDesc.Enabled = false;
            this.txtUMDesc.Location = new System.Drawing.Point(190, 54);
            this.txtUMDesc.Name = "txtUMDesc";
            this.txtUMDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUMDesc.Properties.ReadOnly = true;
            this.txtUMDesc.Size = new System.Drawing.Size(422, 20);
            this.txtUMDesc.TabIndex = 338;
            this.txtUMDesc.TabStop = false;
            // 
            // txtUMCode
            // 
            this.txtUMCode.EnterMoveNextControl = true;
            this.txtUMCode.Location = new System.Drawing.Point(109, 54);
            this.txtUMCode.Name = "txtUMCode";
            this.txtUMCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUMCode.Properties.MaxLength = 3;
            this.txtUMCode.Size = new System.Drawing.Size(69, 20);
            this.txtUMCode.TabIndex = 15;
            this.txtUMCode.EditValueChanged += new System.EventHandler(this.txtUMCode_EditValueChanged);
            this.txtUMCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUMCode_KeyDown);
            this.txtUMCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUMCode_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 339;
            this.label13.Text = "Unit Of Measure";
            // 
            // txtGrpDesc
            // 
            this.txtGrpDesc.Enabled = false;
            this.txtGrpDesc.Location = new System.Drawing.Point(190, 83);
            this.txtGrpDesc.Name = "txtGrpDesc";
            this.txtGrpDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrpDesc.Properties.ReadOnly = true;
            this.txtGrpDesc.Size = new System.Drawing.Size(422, 20);
            this.txtGrpDesc.TabIndex = 336;
            this.txtGrpDesc.TabStop = false;
            // 
            // txtGrpCode
            // 
            this.txtGrpCode.Enabled = false;
            this.txtGrpCode.EnterMoveNextControl = true;
            this.txtGrpCode.Location = new System.Drawing.Point(109, 87);
            this.txtGrpCode.Name = "txtGrpCode";
            this.txtGrpCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrpCode.Properties.MaxLength = 4;
            this.txtGrpCode.Size = new System.Drawing.Size(69, 20);
            this.txtGrpCode.TabIndex = 16;
            this.txtGrpCode.TabStop = false;
            this.txtGrpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUMCode_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(67, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 337;
            this.label15.Text = "Group";
            // 
            // txtSGrpDesc
            // 
            this.txtSGrpDesc.Enabled = false;
            this.txtSGrpDesc.Location = new System.Drawing.Point(190, 113);
            this.txtSGrpDesc.Name = "txtSGrpDesc";
            this.txtSGrpDesc.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSGrpDesc.Properties.ReadOnly = true;
            this.txtSGrpDesc.Size = new System.Drawing.Size(423, 20);
            this.txtSGrpDesc.TabIndex = 334;
            this.txtSGrpDesc.TabStop = false;
            // 
            // txtSGrpCode
            // 
            this.txtSGrpCode.EnterMoveNextControl = true;
            this.txtSGrpCode.Location = new System.Drawing.Point(109, 113);
            this.txtSGrpCode.Name = "txtSGrpCode";
            this.txtSGrpCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSGrpCode.Properties.MaxLength = 4;
            this.txtSGrpCode.Size = new System.Drawing.Size(69, 20);
            this.txtSGrpCode.TabIndex = 17;
            this.txtSGrpCode.EditValueChanged += new System.EventHandler(this.txtSGrpCode_EditValueChanged);
            this.txtSGrpCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSGrpCode_KeyDown);
            this.txtSGrpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUMCode_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 335;
            this.label14.Text = "Sub Group";
            // 
            // txtOSQty
            // 
            this.txtOSQty.EnterMoveNextControl = true;
            this.txtOSQty.Location = new System.Drawing.Point(109, 28);
            this.txtOSQty.Name = "txtOSQty";
            this.txtOSQty.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOSQty.Size = new System.Drawing.Size(69, 20);
            this.txtOSQty.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 326;
            this.label8.Text = "OP. Stock Qty";
            // 
            // ProductTabCtrl
            // 
            this.ProductTabCtrl.Location = new System.Drawing.Point(12, 108);
            this.ProductTabCtrl.Name = "ProductTabCtrl";
            this.ProductTabCtrl.SelectedTabPage = this.PDTab;
            this.ProductTabCtrl.Size = new System.Drawing.Size(704, 294);
            this.ProductTabCtrl.TabIndex = 4;
            this.ProductTabCtrl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PDTab});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 262;
            this.label5.Text = "Asgn Code";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(553, 47);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(60, 13);
            this.label27.TabIndex = 260;
            this.label27.Text = "Status Tag";
            // 
            // txtPrdName
            // 
            this.txtPrdName.EnterMoveNextControl = true;
            this.txtPrdName.Location = new System.Drawing.Point(96, 70);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdName.Properties.MaxLength = 50;
            this.txtPrdName.Size = new System.Drawing.Size(574, 20);
            this.txtPrdName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 258;
            this.label3.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 257;
            this.label1.Text = "Code";
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(706, 25);
            this.Menu_ToolStrip.TabIndex = 263;
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
            // txtProductAsgnCode
            // 
            this.txtProductAsgnCode.EnterMoveNextControl = true;
            this.txtProductAsgnCode.Location = new System.Drawing.Point(245, 41);
            this.txtProductAsgnCode.Name = "txtProductAsgnCode";
            this.txtProductAsgnCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductAsgnCode.Properties.MaxLength = 15;
            this.txtProductAsgnCode.Size = new System.Drawing.Size(73, 20);
            this.txtProductAsgnCode.TabIndex = 1;
            this.txtProductAsgnCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtProductAsgnCode_Validating);
            // 
            // txtPrdCode
            // 
            this.txtPrdCode.Enabled = false;
            this.txtPrdCode.EnterMoveNextControl = true;
            this.txtPrdCode.Location = new System.Drawing.Point(96, 41);
            this.txtPrdCode.Name = "txtPrdCode";
            this.txtPrdCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdCode.Size = new System.Drawing.Size(73, 20);
            this.txtPrdCode.TabIndex = 0;
            this.txtPrdCode.TabStop = false;
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(244, 28);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(458, 374);
            this.HelpGrid.TabIndex = 400;
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
            // txtstatusTag
            // 
            this.txtstatusTag.EnterMoveNextControl = true;
            this.txtstatusTag.Location = new System.Drawing.Point(618, 44);
            this.txtstatusTag.Name = "txtstatusTag";
            this.txtstatusTag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtstatusTag.Properties.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.txtstatusTag.Size = new System.Drawing.Size(51, 20);
            this.txtstatusTag.TabIndex = 2;
            // 
            // frmProductMstAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 414);
            this.ControlBox = false;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.txtstatusTag);
            this.Controls.Add(this.txtPrdCode);
            this.Controls.Add(this.txtProductAsgnCode);
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductTabCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductMstAddEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmProductMstAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductMstAddEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtHSNNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePLDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePCDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCodePC.Properties)).EndInit();
            this.PDTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUMDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUMCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSGrpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOSQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductTabCtrl)).EndInit();
            this.ProductTabCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdName.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductAsgnCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstatusTag.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabPage PDTab;
        private DevExpress.XtraTab.XtraTabControl ProductTabCtrl;
        
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label27;
        private DevExpress.XtraEditors.TextEdit txtPrdName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtProductAsgnCode;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtGrpDesc;
        private DevExpress.XtraEditors.TextEdit txtGrpCode;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.TextEdit txtSGrpDesc;
        private DevExpress.XtraEditors.TextEdit txtSGrpCode;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtOSQty;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtTaxCodePLDesc;
        private DevExpress.XtraEditors.TextEdit txtTaxCodePCDesc;
        private DevExpress.XtraEditors.TextEdit txtTaxCodePL;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtTaxCodePC;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtPrdCode;

        private DevExpress.XtraGrid.GridControl HelpGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtHSNNo;
        private DevExpress.XtraEditors.TextEdit txtUMDesc;
        private DevExpress.XtraEditors.TextEdit txtUMCode;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.ComboBoxEdit txtstatusTag;
    }
}