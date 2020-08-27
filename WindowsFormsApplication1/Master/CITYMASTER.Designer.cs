namespace WindowsFormsApplication1.Master
{
    partial class CITYMASTER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CITYMASTER));
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBackup.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBackup.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Appearance.Options.UseBackColor = true;
            this.btnBackup.Appearance.Options.UseFont = true;
            this.btnBackup.Appearance.Options.UseForeColor = true;
            this.btnBackup.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBackup.ImageOptions.SvgImage")));
            this.btnBackup.Location = new System.Drawing.Point(42, 104);
            this.btnBackup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnBackup.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(83, 39);
            this.btnBackup.TabIndex = 57;
            this.btnBackup.Text = "BackUp";
            // 
            // CITYMASTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 268);
            this.Controls.Add(this.btnBackup);
            this.Name = "CITYMASTER";
            this.Text = "CITYMASTER";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBackup;
    }
}