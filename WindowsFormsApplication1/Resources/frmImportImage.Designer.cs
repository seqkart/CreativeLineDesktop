namespace WindowsFormsApplication1.Resources
{
    partial class frmImportImage
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
            this.ArticleImageBox = new DevExpress.XtraEditors.PictureEdit();
            this.btnSaveImage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ArticleImageBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ArticleImageBox
            // 
            this.ArticleImageBox.Location = new System.Drawing.Point(232, 33);
            this.ArticleImageBox.Name = "ArticleImageBox";
            this.ArticleImageBox.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ArticleImageBox.Size = new System.Drawing.Size(259, 323);
            this.ArticleImageBox.TabIndex = 708;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(562, 245);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveImage.TabIndex = 709;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.Click += new System.EventHandler(this.BtnSaveImage_Click);
            // 
            // frmImportImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 398);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.ArticleImageBox);
            this.Name = "frmImportImage";
            this.Text = "frmImportImage";
            ((System.ComponentModel.ISupportInitialize)(this.ArticleImageBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit ArticleImageBox;
        private DevExpress.XtraEditors.SimpleButton btnSaveImage;
    }
}