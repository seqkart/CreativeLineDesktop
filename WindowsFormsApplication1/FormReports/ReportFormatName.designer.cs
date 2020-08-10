namespace WindowsFormsApplication1.FormReports
{
    partial class ReportFormatName
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
            this.quitBtn = new DevExpress.XtraEditors.SimpleButton();
            this.FileName = new DevExpress.XtraEditors.TextEdit();
            this.SaveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Title = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.FileName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // quitBtn
            // 
            this.quitBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.quitBtn.Appearance.Options.UseFont = true;
            this.quitBtn.Location = new System.Drawing.Point(306, 1);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(23, 23);
            this.quitBtn.TabIndex = 0;
            this.quitBtn.Text = "X";
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(9, 60);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(234, 20);
            this.FileName.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(262, 60);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(56, 20);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "&Save";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Layout Name";
            // 
            // Title
            // 
            this.Title.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Title.Appearance.Options.UseFont = true;
            this.Title.Location = new System.Drawing.Point(3, 5);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(76, 14);
            this.Title.TabIndex = 3;
            this.Title.Text = "Save Layout";
            // 
            // ReportFormatName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Title);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.quitBtn);
            this.Name = "ReportFormatName";
            this.Size = new System.Drawing.Size(332, 101);
            ((System.ComponentModel.ISupportInitialize)(this.FileName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton quitBtn;
        private DevExpress.XtraEditors.TextEdit FileName;
        private DevExpress.XtraEditors.SimpleButton SaveBtn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl Title;
    }
}
