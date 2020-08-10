namespace WindowsFormsApplication1.FormReports
{
    partial class LoadLayout
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
            this.Title = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SaveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.quitBtn = new DevExpress.XtraEditors.SimpleButton();
            this.FileName = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.FileName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(3, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(77, 14);
            this.Title.TabIndex = 7;
            this.Title.Text = "Load Layout";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Layout Name";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(262, 59);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(56, 20);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "&Load";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.Appearance.Options.UseFont = true;
            this.quitBtn.Location = new System.Drawing.Point(306, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(23, 23);
            this.quitBtn.TabIndex = 4;
            this.quitBtn.Text = "X";
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(9, 59);
            this.FileName.Name = "FileName";
            this.FileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FileName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.FileName.Size = new System.Drawing.Size(234, 20);
            this.FileName.TabIndex = 5;
            // 
            // LoadLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Title);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.FileName);
            this.Name = "LoadLayout";
            this.Size = new System.Drawing.Size(332, 101);
            this.Load += new System.EventHandler(this.LoadLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FileName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl Title;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton SaveBtn;
        private DevExpress.XtraEditors.SimpleButton quitBtn;
        private DevExpress.XtraEditors.ComboBoxEdit FileName;

    }
}
