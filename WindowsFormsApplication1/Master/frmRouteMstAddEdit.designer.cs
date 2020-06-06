namespace WindowsFormsApplication1
{
    partial class frmRouteMstAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRouteMstAddEdit));
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRouteCode = new DevExpress.XtraEditors.TextEdit();
            this.txtRouteName = new DevExpress.XtraEditors.TextEdit();
            this.txtLcTag = new DevExpress.XtraEditors.TextEdit();
            this.txtCoverage = new DevExpress.XtraEditors.TextEdit();
            this.Menu_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtRouteCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRouteName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLcTag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverage.Properties)).BeginInit();
            this.Menu_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 215;
            this.label9.Text = "Coverage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 212;
            this.label3.Text = "Route Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 211;
            this.label1.Text = "Code";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(373, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 228;
            this.label12.Text = "L/C Tag";
            // 
            // txtRouteCode
            // 
            this.txtRouteCode.Location = new System.Drawing.Point(102, 46);
            this.txtRouteCode.Name = "txtRouteCode";
            this.txtRouteCode.Size = new System.Drawing.Size(71, 20);
            this.txtRouteCode.TabIndex = 0;
            this.txtRouteCode.TabStop = false;
            // 
            // txtRouteName
            // 
            this.txtRouteName.EnterMoveNextControl = true;
            this.txtRouteName.Location = new System.Drawing.Point(102, 73);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRouteName.Properties.MaxLength = 30;
            this.txtRouteName.Size = new System.Drawing.Size(364, 20);
            this.txtRouteName.TabIndex = 2;
            // 
            // txtLcTag
            // 
            this.txtLcTag.EnterMoveNextControl = true;
            this.txtLcTag.Location = new System.Drawing.Point(423, 99);
            this.txtLcTag.Name = "txtLcTag";
            this.txtLcTag.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLcTag.Properties.MaxLength = 1;
            this.txtLcTag.Size = new System.Drawing.Size(42, 20);
            this.txtLcTag.TabIndex = 8;
            this.txtLcTag.Validated += new System.EventHandler(this.txtLcTag_Validated);
            // 
            // txtCoverage
            // 
            this.txtCoverage.EnterMoveNextControl = true;
            this.txtCoverage.Location = new System.Drawing.Point(102, 99);
            this.txtCoverage.Name = "txtCoverage";
            this.txtCoverage.Size = new System.Drawing.Size(40, 20);
            this.txtCoverage.TabIndex = 3;
            this.txtCoverage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoverage_KeyPress);
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
            this.Menu_ToolStrip.Size = new System.Drawing.Size(515, 25);
            this.Menu_ToolStrip.TabIndex = 243;
            this.Menu_ToolStrip.Text = "Options";
            // 
            // btnQuit
            // 
            this.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnQuit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
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
            // frmRouteMstAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 156);
            this.ControlBox = false;
            this.Controls.Add(this.Menu_ToolStrip);
            this.Controls.Add(this.txtCoverage);
            this.Controls.Add(this.txtLcTag);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.txtRouteCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRouteMstAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmRouteMstAddEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRouteMstAddEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtRouteCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRouteName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLcTag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoverage.Properties)).EndInit();
            this.Menu_ToolStrip.ResumeLayout(false);
            this.Menu_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtRouteCode;
        private DevExpress.XtraEditors.TextEdit txtRouteName;
        private DevExpress.XtraEditors.TextEdit txtLcTag;
        private DevExpress.XtraEditors.TextEdit txtCoverage;
        private System.Windows.Forms.ToolStrip Menu_ToolStrip;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripButton btnSave;
    }
}