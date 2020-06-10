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
            this.txtNewPass = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Chnge = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmPass = new DevExpress.XtraEditors.TextEdit();
            this.txtOldPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.MyValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewPass
            // 
            this.txtNewPass.EnterMoveNextControl = true;
            this.txtNewPass.Location = new System.Drawing.Point(128, 74);
            this.txtNewPass.Name = "txtNew1";
            // 
            // 
            // 
            this.txtNewPass.Properties.UseSystemPasswordChar = true;
            this.txtNewPass.Properties.ValidateOnEnterKey = true;
            this.txtNewPass.Size = new System.Drawing.Size(156, 20);
            toolTipTitleItem1.Text = "Password";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Enter Password";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.txtNewPass.SuperTip = superToolTip1;
            this.txtNewPass.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.Btn_Chnge);
            this.groupControl1.Controls.Add(this.txtConfirmPass);
            this.groupControl1.Controls.Add(this.txtNewPass);
            this.groupControl1.Controls.Add(this.txtOldPass);
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
            // txtConfirmPass
            // 
            this.txtConfirmPass.EnterMoveNextControl = true;
            this.txtConfirmPass.Location = new System.Drawing.Point(128, 110);
            this.txtConfirmPass.Name = "txtnew2";
            // 
            // 
            // 
            this.txtConfirmPass.Properties.UseSystemPasswordChar = true;
            this.txtConfirmPass.Properties.ValidateOnEnterKey = true;
            this.txtConfirmPass.Size = new System.Drawing.Size(156, 20);
            toolTipTitleItem2.Text = "Password";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Enter Password";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.txtConfirmPass.SuperTip = superToolTip2;
            this.txtConfirmPass.TabIndex = 2;
            compareAgainstControlValidationRule1.Control = this.txtNewPass;
            compareAgainstControlValidationRule1.ErrorText = "This value is not Matched.";
            this.MyValidationProvider.SetValidationRule(this.txtConfirmPass, compareAgainstControlValidationRule1);
            // 
            // txtOldPass
            // 
            this.txtOldPass.EnterMoveNextControl = true;
            this.txtOldPass.Location = new System.Drawing.Point(128, 38);
            this.txtOldPass.Name = "txtoldPswd";
            // 
            // 
            // 
            this.txtOldPass.Properties.UseSystemPasswordChar = true;
            this.txtOldPass.Properties.ValidateOnEnterKey = true;
            this.txtOldPass.Size = new System.Drawing.Size(156, 20);
            toolTipTitleItem3.Text = "Password";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Enter Password";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.txtOldPass.SuperTip = superToolTip3;
            this.txtOldPass.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 113);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(93, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Confirm Password";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "New Password";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Chnge;
        private DevExpress.XtraEditors.TextEdit txtConfirmPass;
        private DevExpress.XtraEditors.TextEdit txtNewPass;
        private DevExpress.XtraEditors.TextEdit txtOldPass;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider MyValidationProvider;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
