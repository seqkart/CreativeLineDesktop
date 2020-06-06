namespace WindowsFormsApplication1
{
    partial class RangeSelectorLedger
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.DtFrom = new DevExpress.XtraEditors.DateEdit();
            this.DtEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.BtnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.MyValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.chParty = new DevExpress.XtraEditors.CheckEdit();
            this.chBSHead = new DevExpress.XtraEditors.CheckEdit();
            this.chLedger = new DevExpress.XtraEditors.CheckEdit();
            this.HelpGrid = new DevExpress.XtraGrid.GridControl();
            this.HelpGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.DtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chParty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBSHead.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chLedger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(101, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(157, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Select Report Data Range";
            // 
            // DtFrom
            // 
            this.DtFrom.EditValue = null;
            this.DtFrom.EnterMoveNextControl = true;
            this.DtFrom.Location = new System.Drawing.Point(76, 44);
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtFrom.Size = new System.Drawing.Size(100, 20);
            this.DtFrom.TabIndex = 1;
            // 
            // DtEnd
            // 
            this.DtEnd.EditValue = null;
            this.DtEnd.EnterMoveNextControl = true;
            this.DtEnd.Location = new System.Drawing.Point(233, 44);
            this.DtEnd.Name = "DtEnd";
            this.DtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DtEnd.Size = new System.Drawing.Size(116, 20);
            this.DtEnd.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "From";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(206, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(13, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "To";
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(381, 41);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(116, 28);
            this.BtnLoad.TabIndex = 3;
            this.BtnLoad.Text = "Load Report";
            // 
            // MyValidationProvider
            // 
            this.MyValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(516, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(20, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "X";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // chParty
            // 
            this.chParty.Location = new System.Drawing.Point(20, 109);
            this.chParty.Name = "chParty";
            this.chParty.Properties.Caption = "Party";
            this.chParty.Size = new System.Drawing.Size(75, 18);
            this.chParty.TabIndex = 6;
            this.chParty.CheckedChanged += new System.EventHandler(this.chParty_CheckedChanged);
            // 
            // chBSHead
            // 
            this.chBSHead.Location = new System.Drawing.Point(101, 109);
            this.chBSHead.Name = "chBSHead";
            this.chBSHead.Properties.Caption = "BSHead";
            this.chBSHead.Size = new System.Drawing.Size(75, 18);
            this.chBSHead.TabIndex = 7;
            this.chBSHead.CheckedChanged += new System.EventHandler(this.chBSHead_CheckedChanged);
            // 
            // chLedger
            // 
            this.chLedger.Location = new System.Drawing.Point(182, 109);
            this.chLedger.Name = "chLedger";
            this.chLedger.Properties.Caption = "Group";
            this.chLedger.Size = new System.Drawing.Size(75, 18);
            this.chLedger.TabIndex = 8;
            this.chLedger.CheckedChanged += new System.EventHandler(this.chLedger_CheckedChanged);
            // 
            // HelpGrid
            // 
            this.HelpGrid.Location = new System.Drawing.Point(20, 147);
            this.HelpGrid.MainView = this.HelpGridView;
            this.HelpGrid.Name = "HelpGrid";
            this.HelpGrid.Size = new System.Drawing.Size(516, 275);
            this.HelpGrid.TabIndex = 205;
            this.HelpGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HelpGridView});
            // 
            // HelpGridView
            // 
            this.HelpGridView.GridControl = this.HelpGrid;
            this.HelpGridView.Name = "HelpGridView";
            this.HelpGridView.OptionsBehavior.AllowIncrementalSearch = true;
            this.HelpGridView.OptionsBehavior.Editable = false;
            this.HelpGridView.OptionsView.ShowGroupPanel = false;
            this.HelpGridView.OptionsView.ShowIndicator = false;
            // 
            // RangeSelectorLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.HelpGrid);
            this.Controls.Add(this.chLedger);
            this.Controls.Add(this.chBSHead);
            this.Controls.Add(this.chParty);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.DtEnd);
            this.Controls.Add(this.DtFrom);
            this.Controls.Add(this.labelControl1);
            this.Name = "RangeSelectorLedger";
            this.Size = new System.Drawing.Size(557, 443);
            this.Load += new System.EventHandler(this.RangeSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chParty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBSHead.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chLedger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.DateEdit DtFrom;
        public DevExpress.XtraEditors.DateEdit DtEnd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.SimpleButton BtnLoad;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider MyValidationProvider;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.CheckEdit chParty;
        public DevExpress.XtraEditors.CheckEdit chBSHead;
        public DevExpress.XtraEditors.CheckEdit chLedger;
        public DevExpress.XtraGrid.GridControl HelpGrid;
        public DevExpress.XtraGrid.Views.Grid.GridView HelpGridView;
    }
}
