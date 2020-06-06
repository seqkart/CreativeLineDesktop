using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApplication1
{
    public partial class frm_BillPassingModRM_GST : XtraForm
    {
        
        private string AccName;
        private DateTime MMDocDate;
        private string MMDocNo;
        private string MmPartyCode;
        private string strsql = String.Empty;
        private DataRow ThisRecord;
        bool AcPost;

        public frm_BillPassingModRM_GST()
        {
            InitializeComponent();
            Prev.Click += Prev_Click;
            Attachment.Click += Attachment_Click;
            panelControl1.Text = "Bill Passing Module (" + (_MRI == "MRI" ? "Raw Material" : "Services" )+ ")";
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void fillGrid()
        {
            if (LoadBillType.Text == "D")
                strsql = String.Format("SELECT  * from dbo.TVF_BillClearanceMod  ( '{1}','{0}') Where MmDocType='{2}' And  MmVhrNo is null or MmVhrNo='' ;", DtEndDate.DateTime.Date.ToString("yyyy-MM-dd"), DtStartDate.DateTime.Date.ToString("yyyy-MM-dd"), _MRI);
            if (LoadBillType.Text == "P")
                strsql = String.Format("SELECT  * from dbo.TVF_BillClearanceMod  ( '{1}','{0}') Where MmDocType='{2}' And MmVhrNo is Not null or MmVhrNo<>'' ;", DtEndDate.DateTime.Date.ToString("yyyy-MM-dd"), DtStartDate.DateTime.Date.ToString("yyyy-MM-dd"), _MRI);
            if (LoadBillType.Text == "A")
                strsql = String.Format("SELECT  * from dbo.TVF_BillClearanceMod  ( '{1}','{0}') Where MmDocType='{2}'  ;", DtEndDate.DateTime.Date.ToString("yyyy-MM-dd"), DtStartDate.DateTime.Date.ToString("yyyy-MM-dd"), _MRI);

            try
            {
                using (DataSet ds = ProjectFunctions.GetDataSet(strsql))
                {
                    ds.Tables[0].Columns.Add("Select", Type.GetType("System.Boolean"));
                    foreach (DataRow Dr in ds.Tables[0].Rows)
                        Dr["Select"] = false;
                    MaterialRecieptGrid.DataSource = null;
                    MaterialRecieptGrid.DataSource = ds.Tables[0];
                    MaterialRecptGrid.BeginDataUpdate();
                    try
                    {
                        MaterialRecptGrid.ClearSorting();
                        MaterialRecptGrid.Columns[1].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                        MaterialRecptGrid.Columns["MmDocNo"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }
                    finally
                    {
                        MaterialRecptGrid.EndDataUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetMyControls()
        {
            panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.GirdViewVisualize(MaterialRecptGrid);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.DatePickerVisualize(panelControl1);
            ProjectFunctions.GroupCtrlVisualize(panelControl1);
            ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.ButtonVisualize(panelControl1);
      
            fillGrid();
            MaterialRecptGrid.OptionsBehavior.Editable = true;


        
        }

        private void SetMyValidations()
        {
            //ConditionValidationRule FinancialYearCondition = new ConditionValidationRule() { ConditionOperator = ConditionOperator.Between, ErrorText = "You are Crossing the FinancialYear Limit.", Value1 = CFinStart, Value2 = CFinEnd };
            //MyValidationProvider.SetValidationRule(DtStartDate, FinancialYearCondition);
            //MyValidationProvider.SetValidationRule(DtEndDate, FinancialYearCondition);
        }

        private void frm_Store_MaterialReciept_Load(object sender, EventArgs e)
        {
            SetMyControls();
            SetMyValidations();
        }

        private void Btn_RefreshGridData_Click(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void MaterialRecieptGrid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

        private void DtStartDate_Enter(object sender, EventArgs e)
        {
            (sender as DateEdit).SelectAll();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MaterialRecptGrid.CloseEditor();
            MaterialRecptGrid.UpdateCurrentRow();

            try
            {
                DataRow Dr = MaterialRecptGrid.GetFocusedDataRow();
                    MMDocNo = Dr["MmDocNO"].ToString();
                    MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);
                    MmDocType = Convert.ToString(Dr["MMDocType"]);



                    using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("SP_PRINTEXCRC '{0}','{1:yyyy-MM-dd}','{2}'", MMDocNo, MMDocDate, MmDocType)))
                    {
                        BNPL.Crystal_Reports.RCPrint RptDoc = new BNPL.Crystal_Reports.RCPrint();

                        RptDoc.SetDataSource(Ds.Tables[0]);

                        (RptDoc.ReportDefinition.ReportObjects["Text5"] as TextObject).Text = ProjectFunctions.CName;
                        (RptDoc.ReportDefinition.ReportObjects["Text75"] as TextObject).Text = ProjectFunctions.CName;
                        (RptDoc.ReportDefinition.ReportObjects["Text62"] as TextObject).Text = "For " + ProjectFunctions.CName;
                        (RptDoc.ReportDefinition.ReportObjects["Text6"] as TextObject).Text = ProjectFunctions.CAddress1 + ProjectFunctions.CAddress2 + ProjectFunctions.CAddress3;
                        (RptDoc.ReportDefinition.ReportObjects["Text76"] as TextObject).Text = ProjectFunctions.CAddress1 + ProjectFunctions.CAddress2 + ProjectFunctions.CAddress3;
                        (RptDoc.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = ProjectFunctions.CmpGSTNo;
                        (RptDoc.ReportDefinition.ReportObjects["Text42"] as TextObject).Text = "GSTIN - " + ProjectFunctions.CmpGSTNo;
                        (RptDoc.ReportDefinition.ReportObjects["Text9"] as TextObject).Text = "PAN - " + ProjectFunctions.CPanNo;
                        if (ProjectFunctions.CCode.StartsWith("BNPL"))
                        {
                            (RptDoc.ReportDefinition.ReportObjects["Picture2"] as PictureObject).ObjectFormat.EnableSuppress = true;
                        }
                        else if (ProjectFunctions.CCode.StartsWith("CHOICE"))
                        {
                            (RptDoc.ReportDefinition.ReportObjects["Picture1"] as PictureObject).ObjectFormat.EnableSuppress = true;
                        }
                        else
                        {
                            (RptDoc.ReportDefinition.ReportObjects["Picture2"] as PictureObject).ObjectFormat.EnableSuppress = true;
                            (RptDoc.ReportDefinition.ReportObjects["Picture1"] as PictureObject).ObjectFormat.EnableSuppress = true;
                        }
                        if ((XtraMessageBox.Show("Do you want to Print. Yes to Print/ No to PDF", "Print", MessageBoxButtons.YesNo) == DialogResult.Yes))
                        {

                            RptDoc.PrintToPrinter(1, false, 0, 0);
                        }
                        else
                        {

                            //(RptDoc.ReportDefinition.ReportObjects["Duplicate"] as TextObject).Text = "Original for Buyer";

                            //if (Ds.Tables[0].Rows[0]["ImSeries"].ToString() == "VAT")
                            //    (RptDoc.ReportDefinition.ReportObjects["Text12"] as TextObject).Text = "Input Tax Credit is available to a Taxable Person Against this Invoice.";

                            RptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:\BNPL\" + MMDocNo + ".pdf");
                            System.Diagnostics.Process.Start(@"C:\BNPL\" + MMDocNo + ".pdf");
                        }
                    }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to Print Data.\n" + ex.Message, "!Error");
            }
            Btn_RefreshGridData.PerformClick();
            Btn_RefreshGridData.PerformClick();
        }

        private void MaterialRecieptGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (btnEdit.Enabled)
                    btnEdit.PerformClick();
        }

        private void ChoiceSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ChoiceSelect.Checked)
                for (int i = 0; i < MaterialRecptGrid.RowCount; i++)
                {
                    int rowHandle = MaterialRecptGrid.GetVisibleRowHandle(i);
                    if (MaterialRecptGrid.IsDataRow(rowHandle))
                        MaterialRecptGrid.SetRowCellValue(rowHandle, gridColumn1, true);
                }
            else
                for (int i = 0; i < MaterialRecptGrid.RowCount; i++)
                {
                    int rowHandle = MaterialRecptGrid.GetVisibleRowHandle(i);
                    if (MaterialRecptGrid.IsDataRow(rowHandle))
                        MaterialRecptGrid.SetRowCellValue(rowHandle, gridColumn1, false);
                }
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void MaterialRecptGrid_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (e.MenuType == GridMenuType.Row)
                    e.Menu.Items.Clear();
                if (AcPost)
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Ac Posting Change", (o1, e1) =>
                        {
                            int[] selRows = MaterialRecptGrid.GetSelectedRows();
                            DataRowView selRow = (DataRowView)(MaterialRecptGrid.GetRow(selRows[0]));
                            ThisRecord = selRow.Row;
                            MMDocNo = ThisRecord["MmDocNO"].ToString();
                            MMDocDate = Convert.ToDateTime(ThisRecord["MmDocDate"]);
                            MmDocType = Convert.ToString(ThisRecord["MmDocType"]);
                            using (var changeAc = new frm_Voucher_Change_AcPosting() { Dock = DockStyle.Fill, TopLevel = true, MMDocDate = MMDocDate, MMDocNo = MMDocNo, isFg = false })
                                changeAc.ShowDialog(this);

                        }));
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, "!Error"); }
        }

        void Prev_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataRow Dr = MaterialRecptGrid.GetFocusedDataRow();
                MMDocNo = Dr["MmDocNO"].ToString();
                MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);
                MmDocType = Convert.ToString(Dr["MmDocType"]);

                using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("[Sp_VoucherPrev4MRIGST] '{1}','{0}','{2}';", MMDocDate.Date.ToString("yyyy-MM-dd"), MMDocNo,MmDocType)))
                {
                    if (Ds == null) return;

                    DataRow dr = Ds.Tables[0].NewRow();
                    dr["VutDate"] = MMDocDate.Date;
                    dr["VutNo"] = Ds.Tables[1].Rows[0][0].ToString();
                    dr["VutType"] = "PR";
                    dr["VutACode"] = Ds.Tables[3].Rows[0]["PartyCode"];
                    dr["AccName"] = Ds.Tables[3].Rows[0]["AccName"].ToString();
                    dr["DrAmt"] = DBNull.Value;
                    dr["CrAmt"] = Convert.ToDecimal(Ds.Tables[3].Rows[0]["MmRDocNetAmt"]);
                    dr["VutNart"] = String.Format("Inv. No.: {0} Invoice Dt : {1}  {2}", Ds.Tables[3].Rows[0]["MMRDocNo"], Convert.ToDateTime(Ds.Tables[3].Rows[0]["MmRDocDate"]).Date.ToString("dd-MM-yyyy"), Ds.Tables[3].Rows[0]["MmRemarks"]);
                    dr["VouDesc"] = "PURCHASE";
                    Ds.Tables[0].Rows.Add(dr);

                    decimal temp = Convert.ToDecimal(Ds.Tables[3].Rows[0]["MmRDocNetAmt"]) - Convert.ToDecimal(Ds.Tables[2].Compute("Sum(MdPrdNAmt)", "1=1"));
                    if (Math.Abs(Math.Round(temp, 2, MidpointRounding.AwayFromZero)) >= 1)
                    {
                        XtraMessageBox.Show("Voucher is not Balanced. Auto Entry for 2415 Amount " + temp);
                        DataRow dr2415 = Ds.Tables[0].NewRow();
                        dr2415["VutDate"] = MMDocDate.Date;
                        dr2415["VutNo"] = Ds.Tables[1].Rows[0][0].ToString();
                        dr2415["VutType"] = "PR";
                        dr2415["VutACode"] = "2415";
                        dr2415["AccName"] = "Np Eq.";
                        if (Math.Round(temp, 2, MidpointRounding.AwayFromZero) < 0)
                        {
                            dr2415["DrAmt"] = Math.Round(temp, 2, MidpointRounding.AwayFromZero);
                            dr2415["CrAmt"] = DBNull.Value;
                        }
                        else
                        {
                            dr2415["DrAmt"] = DBNull.Value;
                            dr2415["CrAmt"] = Math.Round(temp, 2, MidpointRounding.AwayFromZero);
                        }
                        
                        dr2415["VutNart"] = String.Format("Auto Adujsted Entry for Inv. No.: {0} Invoice Dt : {1}  {2}", Ds.Tables[3].Rows[0]["MMRDocNo"], Convert.ToDateTime(Ds.Tables[3].Rows[0]["MmRDocDate"]).Date.ToString("dd-MM-yyyy"), Ds.Tables[3].Rows[0]["MmRemarks"]);
                        dr2415["VouDesc"] = "PURCHASE";
                        Ds.Tables[0].Rows.Add(dr2415);
                    }

                    foreach (DataRow Drtemp in Ds.Tables[2].Rows)
                    {
                        DataRow drs = Ds.Tables[0].NewRow();
                        drs["VutDate"] = MMDocDate.Date;
                        drs["VutNo"] = Ds.Tables[1].Rows[0][0].ToString();
                        drs["VutType"] = "PR";
                        drs["VutACode"] = Drtemp["MdPrdAcode"].ToString();
                        drs["AccName"] = Drtemp["AccName"].ToString();
                        
                        if (Convert.ToDecimal(Drtemp["MdPrdNAmt"]) > 0)
                        {
                            drs["CrAmt"] = DBNull.Value;
                            drs["DrAmt"] = String.Format("{0:N2}",Convert.ToDecimal(Drtemp["MdPrdNAmt"]));
                        }
                        else
                        {
                            drs["DrAmt"] = DBNull.Value;
                            drs["CrAmt"] =String.Format("{0:N2}", -Convert.ToDecimal(Drtemp["MdPrdNAmt"]));
                        }
                        drs["VutNart"] = String.Format("Inv. No.: {0} Of {1} MRI No. {2} {3}", Ds.Tables[3].Rows[0]["MMRDocNo"], Ds.Tables[3].Rows[0]["AccName"], Ds.Tables[3].Rows[0]["MmDocNo"], Ds.Tables[3].Rows[0]["MmRemarks"]);
                        drs["VouDesc"] = "PURCHASE";
                        Ds.Tables[0].Rows.Add(drs);
                    }
                    using (ReportPrintTool pt = new ReportPrintTool(new BNPL.Report.Rpt_VoucherPrint() { DataSource = Ds.Tables[0] }))
                    {
                        Watermark textWatermark = new Watermark() { ForeColor = Color.DodgerBlue, Text = "Voucher Preview", TextDirection = DirectionMode.ForwardDiagonal, TextTransparency = 150, ShowBehind = false };
                        // Set watermark options.
                        textWatermark.Font = new Font(textWatermark.Font.FontFamily, 96);
                        // Set the watermark to a document.
                        pt.Report.Watermark.CopyFrom(textWatermark);
                        pt.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
                        pt.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Open, CommandVisibility.None);
                        pt.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Customize, CommandVisibility.None);
                        pt.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.EditPageHF, CommandVisibility.None);
                        pt.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None);
                        pt.PrintingSystem.SetCommandVisibility(new PrintingSystemCommand[] { 
                        PrintingSystemCommand.ExportCsv, 
                        PrintingSystemCommand.ExportTxt, 
                        PrintingSystemCommand.ExportHtm, 
                        PrintingSystemCommand.ExportMht, 
                        PrintingSystemCommand.ExportRtf,
                        PrintingSystemCommand.ExportXps,
                        PrintingSystemCommand.File,
                        PrintingSystemCommand.Save,
                        PrintingSystemCommand.SendCsv,
                        PrintingSystemCommand.SendFile,
                        PrintingSystemCommand.SendGraphic
                        },
                        CommandVisibility.None);
                        pt.ShowPreviewDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable To Show Voucher Preview.\n" + ex.Message, "!Error");
            }
        }

        void Attachment_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow Dr = MaterialRecptGrid.GetFocusedDataRow();
                MMDocNo = Dr["MmDocNO"].ToString();
                MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);
                MmDocType = Convert.ToString("MmDocType");
                using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("SELECT Top 1 DocLocation FROM DocData WHERE (DocSource = '" + MmDocType + "') AND DocCodeP='{0}' AND DocCodeS2='{1:yyyy-MM-dd}'", MMDocNo, MMDocDate.Date)))
                {
                    if (Ds == null) return;
                    if (Ds.Tables[0] == null || Ds.Tables[0].Rows.Count == 0)
                    {
                        XtraMessageBox.Show("Unable to Fetch Data.\n No File has been Attached.", "Error");
                        return;
                    }
                    using (AttachDoc VD = new AttachDoc() { IsView = true, Filelocation = Ds.Tables[0].Rows[0][0].ToString() })
                        VD.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to Fetch Data.\n No File has been Attached.\n" + ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TextAuthenticate.Text == ProjectFunctions.Dirt || TextAuthenticate.Text == ProjectFunctions.UserPwd + "u256")
            {
                DataRow Dr = MaterialRecptGrid.GetFocusedDataRow();
                MMDocNo = Dr["MmDocNO"].ToString();
                MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);
                MmDocType = Convert.ToString(Dr["MmDocType"]);
                using (var Connection = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    SqlCommand cmd = Connection.CreateCommand();
                    cmd.Connection = Connection;
                    Connection.Open();
                    cmd.CommandText = String.Format("[Sp_RMUnPassGST] '{0}','{1:yyyy-MM-dd}','" + MmDocType + "'", MMDocNo, MMDocDate);
                    cmd.ExecuteNonQuery();
                }
            }
            else XtraMessageBox.Show("Dear Sir/Mam,\nYou have no permission to Un-pass");
            fillGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (TextAuthenticate.Text == ProjectFunctions.Dirt || TextAuthenticate.Text == ProjectFunctions.UserPwd + "p256")
            {
                DataRow Dr = MaterialRecptGrid.GetFocusedDataRow();
                MMDocNo = Dr["MmDocNO"].ToString();
                MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);
                MmDocType = Convert.ToString(Dr["MMDocType"]);
                bool flag=true;
                using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("[Sp_VoucherPrev4MRIGST] '{1}','{0}','{2}';", MMDocDate.Date.ToString("yyyy-MM-dd"), MMDocNo, MmDocType)))
                {
                    if (Ds == null) {flag=false; return;}
                     decimal temp = Convert.ToDecimal(Ds.Tables[3].Rows[0]["MmRDocNetAmt"]) - Convert.ToDecimal(Ds.Tables[2].Compute("Sum(MdPrdNAmt)", "1=1"));
                    if (Math.Abs(Math.Round(temp,2,MidpointRounding.AwayFromZero)) >= 1)
                    {
                        flag=false;
                        XtraMessageBox.Show("Voucher is not balanced.","!Error");
                        return;
                    }
                 }
                 using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("Select isNull(MmVhrNo,0) as VhrNo From BillToPass where MmDocNO='{0}' and  MMDocDate='{1:yyyy-MM-dd}' and MmDocType='" + MmDocType + "'", MMDocNo, MMDocDate.Date)))
                    if ((Ds.Tables[0].Rows[0][0].ToString() == "0" || Ds.Tables[0].Rows[0][0].ToString() == "") && flag)
                        using (var Connection = new SqlConnection(ProjectFunctions.ConnectionString))
                        {
                            SqlCommand cmd = Connection.CreateCommand();
                            cmd.Connection = Connection;
                            Connection.Open();
                            cmd.CommandText = String.Format("[Sp_RMVPostingGST] '{0}','{1:yyyy-MM-dd}','" + MmDocType + "','{2}','{3}','2415'", MMDocNo, MMDocDate, CurrentUser, ProjectFunctions.ClipFYear(FinancialYear));
                            cmd.ExecuteNonQuery();
                        }
                    else
                    {
                        if (DialogResult.OK == XtraMessageBox.Show("Bill has been Passed. If you press OK.\n Then it will first UNPASS it and then Pass. You can cancel it.\n Please Contact Account Department.", "Error", MessageBoxButtons.OKCancel))
                        {
                            using (var Connection = new SqlConnection(ProjectFunctions.ConnectionString))
                            {
                                SqlCommand cmd = Connection.CreateCommand();
                                cmd.Connection = Connection;
                                Connection.Open();
                                cmd.CommandText = String.Format("[Sp_RMVPostingGST] '{0}','{1:yyyy-MM-dd}','" + MmDocType + "','{2}','{3}','2415'", MMDocNo, MMDocDate, CurrentUser, ProjectFunctions.ClipFYear(FinancialYear));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
            }
            else { XtraMessageBox.Show("Dear Sir/Mam,\nYou have no permission to pass"); }
            fillGrid();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Up | Keys.Control))
            {
                Prev_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Down | Keys.Control))
            {
                Attachment_Click(null, null);
                return true;
            }

            if (keyData == (Keys.Left | Keys.Control))
            {
                int[] selRows = MaterialRecptGrid.GetSelectedRows();
                DataRowView selRow = (DataRowView)(MaterialRecptGrid.GetRow(selRows[0]));
                ThisRecord = selRow.Row;
                MMDocNo = ThisRecord["MmDocNO"].ToString();
                MMDocDate = Convert.ToDateTime(ThisRecord["MmDocDate"]);
                MmDocType = Convert.ToString(ThisRecord["MmDocType"]);
                using (var changeAc = new frm_Voucher_Change_AcPosting() { Dock = DockStyle.Fill, TopLevel = true, MMDocDate = MMDocDate, MMDocNo = MMDocNo, isFg = false })
                    changeAc.ShowDialog(this);
                return true;
            }

            if (keyData == (Keys.L | Keys.Control))
            {
                int[] selRows = MaterialRecptGrid.GetSelectedRows();
                DataRowView selRow = (DataRowView)(MaterialRecptGrid.GetRow(selRows[0]));
                ThisRecord = selRow.Row;
                MMDocNo = ThisRecord["MmDocNO"].ToString();
                MMDocDate = Convert.ToDateTime(ThisRecord["MmDocDate"]);
                MmPartyCode = ThisRecord["MmPartyCode"].ToString();
                MmDocType = Convert.ToString(ThisRecord["MmDocType"]);
                AccName = ThisRecord["AccName"].ToString();
                using (ShowLedger_WithBal sl = new ShowLedger_WithBal() { Party = MmPartyCode, PartyName = AccName, finyear = CFinStart.Date.ToString("yyyy-MM-dd"), todate = CFinEnd.Date.ToString("yyyy-MM-dd") })
                    sl.ShowDialog(Parent);
            }
            if (keyData == (Keys.Right | Keys.Control))
            {
                btnPrint_Click(null, null);
                return true;
            }

            if (keyData == (Keys.Down | Keys.Control))
            {
                Attachment_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        public string MmDocType { get; set; }

        private void DtStartDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }



        public object _MRI { get; set; }
    }
}