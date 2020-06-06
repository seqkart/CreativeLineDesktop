namespace WindowsFormsApplication1
{
    partial class frm_Chng_Pswd
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.txtNew1 = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Chnge = new DevExpress.XtraEditors.SimpleButton();
            this.txtnew2 = new DevExpress.XtraEditors.TextEdit();
            this.txtoldPswd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.MyValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtNew1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnew2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtoldPswd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNew1
            // 
            this.txtNew1.EnterMoveNextControl = true;
            this.txtNew1.Location = new System.Drawing.Point(128, 74);
            this.txtNew1.Name = "txtNew1";
            this.txtNew1.Properties.UseSystemPasswordChar = true;
            this.txtNew1.Properties.ValidateOnEnterKey = true;
            this.txtNew1.Size = new System.Drawing.Size(156, 20);
            toolTipTitleItem1.Text = "Password";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Enter Password";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.txtNew1.SuperTip = superToolTip1;
            this.txtNew1.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.Btn_Chnge);
            this.groupControl1.Controls.Add(this.txtnew2);
            this.groupControl1.Controls.Add(this.txtNew1);
            this.groupControl1.Controls.Add(this.txtoldPswd);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(321, 199);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Change Password";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(301, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(20, 19);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "X";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Btn_Chnge
            // 
            this.Btn_Chnge.Location = new System.Drawing.Point(209, 147);
            this.Btn_Chnge.Name = "Btn_Chnge";
            this.Btn_Chnge.Size = new System.Drawing.Size(75, 34);
            this.Btn_Chnge.TabIndex = 3;
            this.Btn_Chnge.Text = "Change";
            this.Btn_Chnge.Click += new System.EventHandler(this.Btn_Chnge_Click);
            // 
            // txtnew2
            // 
            this.txtnew2.EnterMoveNextControl = true;
            this.txtnew2.Location = new System.Drawing.Point(128, 110);
            this.txtnew2.Name = "txtnew2";
            this.txtnew2.Properties.UseSystemPasswordChar = true;
            this.txtnew2.Properties.ValidateOnEnterKey = true;
            this.txtnew2.Size = new System.Drawing.Size(156, 20);
            toolTipTitleItem2.Text = "Password";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Enter Password";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.txtnew2.SuperTip = superToolTip2;
            this.txtnew2.TabIndex = 2;
            compareAgainstControlValidationRule1.Control = this.txtNew1;
            compareAgainstControlValidationRule1.ErrorText = "This value is not Matched.";
            this.MyValidationProvider.SetValidationRule(this.txtnew2, compareAgainstControlValidationRule1);
            // 
            // txtoldPswd
            // 
            this.txtoldPswd.EnterMoveNextControl = true;
            this.txtoldPswd.Location = new System.Drawing.Point(128, 38);
            this.txtoldPswd.Name = "txtoldPswd";
            this.txtoldPswd.Properties.UseSystemPasswordChar = true;
            this.txtoldPswd.Properties.ValidateOnEnterKey = true;
            this.txtoldPswd.Size = new System.Drawing.Size(156, 20);
            toolTipTitleItem3.Text = "Password";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Enter Password";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.txtoldPswd.SuperTip = superToolTip3;
            this.txtoldPswd.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 113);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Confirm Password";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "New Password";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Old Password";
            // 
            // MyValidationProvider
            // 
            this.MyValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // frm_Chng_Pswd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "frm_Chng_Pswd";
            this.Size = new System.Drawing.Size(321, 199);
            this.Load += new System.EventHandler(this.frm_Chng_Pswd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNew1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnew2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtoldPswd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Chnge;
        private DevExpress.XtraEditors.TextEdit txtnew2;
        private DevExpress.XtraEditors.TextEdit txtNew1;
        private DevExpress.XtraEditors.TextEdit txtoldPswd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider MyValidationProvider;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
