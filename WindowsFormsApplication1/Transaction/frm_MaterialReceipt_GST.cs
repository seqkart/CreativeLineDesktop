using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;


namespace WindowsFormsApplication1
{
    public partial class frm_MaterialReceipt_GST : XtraForm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        private DateTime MMDocDate;
        private string MMDocNo;
        private string strsql = String.Empty;
        private DataRow ThisRecord;
        bool AcPost;
        private string MmDocType;
        public string _MRI { get; set; }

        public frm_MaterialReceipt_GST()
        {
            InitializeComponent();
            StartDate = DateTime.Now.AddDays(-1);
            EndDate = DateTime.Now;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void fillGrid()
        {
            strsql = string.Format("Select * from dbo.V_MrMst_ActMst_4_" + _MRI + " where ( MmDocDate BETWEEN '{0:yyyy-MM-dd}' and '{1:yyyy-MM-dd}') ;", StartDate, EndDate);
            try
            {
                using (DataSet ds = ProjectFunctions.GetDataSet(strsql))
                {
                    ds.Tables[0].Columns.Add("Print", Type.GetType("System.Boolean"));
                    foreach (DataRow Dr in ds.Tables[0].Rows)
                        Dr["Print"] = false;
                    MaterialRecieptGrid.DataSource = null;
                    MaterialRecieptGrid.DataSource = ds.Tables[0];
                    MaterialRecptGrid.BeginDataUpdate();
                    try
                    {
                        MaterialRecptGrid.ClearSorting();
                        MaterialRecptGrid.Columns["MmDocDate"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
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
            DtEndDate.DateTime = EndDate.Date;
            DtStartDate.DateTime = StartDate.Date;
            fillGrid();
            MaterialRecptGrid.OptionsBehavior.Editable = true;
            panelControl1.Text = _MRI == "SVC" ? "Service Receipt" : "Material Receipt";

            string Query4Controls = String.Format("SELECT     ProgAdd_F, ProgUpd_F, ProgDel_F, ProgRep_p, ProgRep_p,ProgSpl_U FROM         UserProgAccess WHERE     (ProgActive is Null or progActive= 'Y') AND (ProgCode = N'{1}') AND (UserName = N'{0}'); ", GlobalVariables.GlobalVariables.CurrentUser, ProjectFunctions.ProgCode);
            using (DataSet Tempds = ProjectFunctions.GetDataSet(Query4Controls))
                if (Tempds != null)
                {
                    if (Tempds.Tables[0].Rows.Count > 0)
                    {
                        if (Tempds.Tables[0].Rows[0]["ProgAdd_F"].ToString() == "-1")
                        {
                            btnAdd.Enabled = true;
                        }
                        else
                        {
                            btnAdd.Enabled = false;
                        }
                        if (Tempds.Tables[0].Rows[0]["ProgUpd_F"].ToString() == "-1")
                        {
                            btnEdit.Enabled = true;
                        }
                        else
                        {
                            btnEdit.Enabled = false;
                        }
                        if (Tempds.Tables[0].Rows[0]["ProgDel_F"].ToString() == "-1")
                        {
                            btnDelete.Enabled = true;
                        }
                        else
                        {
                            btnDelete.Enabled = false;
                        }
                    }
                }
        }

        private void SetMyValidations()
        {
            //ConditionValidationRule FinancialYearCondition = new ConditionValidationRule() { ConditionOperator = ConditionOperator.Between, ErrorText = "You are Crossing the FinancialYear Limit.", Value1 = GlobalVariables.FinYearStartDate, Value2 = GlobalVariables.FinYearEndDate };
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
            StartDate = DtStartDate.DateTime.Date;
            EndDate = DtEndDate.DateTime.Date;
            fillGrid();
        }

        private void MaterialRecieptGrid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                using (frm_MaterialReciept_Add_Update_GST FMRA = new frm_MaterialReciept_Add_Update_GST() { _MRI = _MRI, IsUpdate = false })
                {
                    Point P = ProjectFunctions.GetPositionInForm(this);
                    FMRA.Location = new Point(P.X + (ClientSize.Width / 2 - FMRA.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FMRA.Size.Height / 2));
                    FMRA.ShowDialog();
                    fillGrid();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow Dr = MaterialRecptGrid.GetFocusedDataRow();
            MMDocNo = Dr["MmDocNO"].ToString();
            MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);

            if (btnEdit.Enabled)
                if (MaterialRecieptGrid.DataSource != null)
                    if (MaterialRecptGrid.RowCount > 0)
                        using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("Select isNull(MmVhrNo,0) as VhrNo From BillToPass where MmDocNO='{0}' and  MMDocDate='{1:yyyy-MM-dd}' and MmDocType='" + _MRI + "'", MMDocNo, MMDocDate.Date)))
                            if (Ds.Tables[0].Rows[0][0].ToString() == "0" || Ds.Tables[0].Rows[0][0].ToString() == "")
                                using (frm_MaterialReciept_Add_Update_GST FMRU = new frm_MaterialReciept_Add_Update_GST() { _MRI = _MRI, IsUpdate = true, MMDocDate = MMDocDate, MMDocNo = MMDocNo, FinancialYear = FinancialYear, GlobalVariables.GlobalVariables.CurrentUser = GlobalVariables.GlobalVariables.CurrentUser, StartDate = StartDate, EndDate = EndDate, GlobalVariables.FinYearEndDate = GlobalVariables.FinYearEndDate, GlobalVariables.FinYearStartDate = GlobalVariables.FinYearStartDate })
                                {
                                    Point P = ProjectFunctions.GetPositionInForm(this);
                                    FMRU.Location = new Point(P.X + (ClientSize.Width / 2 - FMRU.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FMRU.Size.Height / 2));
                                    FMRU.ShowDialog();
                                }
                            else
                            {
                                XtraMessageBox.Show("Bill has been Passed. Please Unpass it First.\n Please Contact Account Department.", "Error");
                                using (frm_MaterialReciept_Add_Update_GST FMRU = new frm_MaterialReciept_Add_Update_GST() { _MRI = _MRI, IsUpdate_View = true, IsUpdate = true, MMDocDate = MMDocDate, MMDocNo = MMDocNo, FinancialYear = FinancialYear, GlobalVariables.GlobalVariables.CurrentUser = GlobalVariables.GlobalVariables.CurrentUser, StartDate = StartDate, EndDate = EndDate, GlobalVariables.FinYearEndDate = GlobalVariables.FinYearEndDate, GlobalVariables.FinYearStartDate = GlobalVariables.FinYearStartDate })
                                {
                                    Point P = ProjectFunctions.GetPositionInForm(this);
                                    FMRU.Location = new Point(P.X + (ClientSize.Width / 2 - FMRU.Size.Width / 2), P.Y + (ClientSize.Height / 2 - FMRU.Size.Height / 2));
                                    FMRU.ShowDialog();
                                }
                            }
                    else
                        XtraMessageBox.Show("No Records to Edit", "!Error");
                else
                    XtraMessageBox.Show("No Datasource, Or Unable to fetch Data.", "!Error");
            else
                XtraMessageBox.Show("You have No permission .", "!Error");
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
                if (btnPrint.Enabled)
                    if (MaterialRecieptGrid.DataSource != null)
                        if (MaterialRecptGrid.RowCount > 0)
                        {
                            DataRow[] Rows = (MaterialRecieptGrid.DataSource as DataTable).Select("Print <> False");
                            if (Rows.Length > 1)
                                foreach (DataRow Dr in Rows)
                                {
                                    MMDocNo = Dr["MmDocNO"].ToString();
                                    MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);
                                    MmDocType = Convert.ToString(Dr["MMDocType"]);
                                    using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("Sp_MRNPrintGST '{0}','{1:yyyy-MM-dd}','{2}'", MmDocType, MMDocDate, MMDocNo)))
                                    {
                                        BNPL.Crystal_Reports.rpt_MRN RptDoc = new BNPL.Crystal_Reports.rpt_MRN();


                                        RptDoc.SetDataSource(Ds.Tables[0]);
                                        if (Ds.Tables[0].Rows.Count > 4)
                                        {
                                            var margin = RptDoc.PrintOptions.PageMargins;
                                            margin.bottomMargin = margin.topMargin;
                                            RptDoc.PrintOptions.ApplyPageMargins(margin);
                                        }
                                        (RptDoc.ReportDefinition.ReportObjects["Text5"] as TextObject).Text = GlobalVariables.CompanyName;
                                        (RptDoc.ReportDefinition.ReportObjects["Text6"] as TextObject).Text = GlobalVariables.CAddress1 + GlobalVariables.CAddress2 + GlobalVariables.CAddress3;
                                        (RptDoc.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = GlobalVariables.CmpGSTNo;
                                        (RptDoc.ReportDefinition.ReportObjects["Text44"] as TextObject).Text = _MRI == "SVC" ? "MRN - Service" : "MRN - Purchase";

                                        (RptDoc.ReportDefinition.ReportObjects["Picture1"] as PictureObject).ObjectFormat.EnableSuppress = true;

                                        if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMIGSTAmt"]) > 0)
                                        {
                                            (RptDoc.ReportDefinition.ReportObjects["Text28"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMIGSTAmt"]));
                                            (RptDoc.ReportDefinition.ReportObjects["Text14"] as TextObject).Text = "IGST Amount :";

                                            (RptDoc.ReportDefinition.ReportObjects["Text15"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text31"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text22"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text33"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text32"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text20"] as TextObject).Text = "";
                                            if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]) != 0)
                                            {
                                                (RptDoc.ReportDefinition.ReportObjects["Text15"] as TextObject).Text = "Round Off :";
                                                (RptDoc.ReportDefinition.ReportObjects["Text31"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]));
                                            }
                                        }
                                        else if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMSGSTAmt"]) != 0)
                                        {
                                            (RptDoc.ReportDefinition.ReportObjects["Text28"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMSGSTAmt"]));
                                            (RptDoc.ReportDefinition.ReportObjects["Text14"] as TextObject).Text = "SGST Amount :";
                                            (RptDoc.ReportDefinition.ReportObjects["Text31"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMCGSTAmt"]));
                                            (RptDoc.ReportDefinition.ReportObjects["Text15"] as TextObject).Text = "CGST Amount :";
                                            (RptDoc.ReportDefinition.ReportObjects["Text22"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text33"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text32"] as TextObject).Text = "";
                                            (RptDoc.ReportDefinition.ReportObjects["Text20"] as TextObject).Text = "";
                                            if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]) != 0)
                                            {
                                                (RptDoc.ReportDefinition.ReportObjects["Text22"] as TextObject).Text = "Round Off :";
                                                (RptDoc.ReportDefinition.ReportObjects["Text33"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]));
                                            }
                                        }
                                        if (Ds.Tables[0].Rows.Count > 5)
                                        {
                                            var margins = RptDoc.PrintOptions.PageMargins;
                                            margins.bottomMargin = margins.topMargin;
                                            RptDoc.PrintOptions.ApplyPageMargins(margins);
                                            XtraMessageBox.Show("A4 Size paper");
                                        }

                                        RptDoc.PrintToPrinter(1, false, 0, 0);
                                    }
                                }
                            else
                            {
                                MMDocNo = Rows[0]["MmDocNO"].ToString();
                                MMDocDate = Convert.ToDateTime(Rows[0]["MmDocDate"]);
                                MmDocType = Convert.ToString(Rows[0]["MMDocType"]);

                                using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("Sp_MRNPrintGST '{0}','{1:yyyy-MM-dd}','{2}'", MmDocType, MMDocDate, MMDocNo)))
                                {
                                    BNPL.Crystal_Reports.rpt_MRN RptDoc = new BNPL.Crystal_Reports.rpt_MRN();
                                    RptDoc.SetDataSource(Ds.Tables[0]);
                                    if (Ds.Tables[0].Rows.Count > 4)
                                    {
                                        var margin = RptDoc.PrintOptions.PageMargins;
                                        margin.bottomMargin = margin.topMargin;
                                        RptDoc.PrintOptions.ApplyPageMargins(margin);
                                    }
                                    (RptDoc.ReportDefinition.ReportObjects["Text5"] as TextObject).Text = ProjectFunctions.CName2Print;
                                    (RptDoc.ReportDefinition.ReportObjects["Text6"] as TextObject).Text = ProjectFunctions.CAddress1 + ProjectFunctions.CAddress2 + ProjectFunctions.CAddress3;
                                    (RptDoc.ReportDefinition.ReportObjects["Text3"] as TextObject).Text = ProjectFunctions.CmpGSTNo;

                                    (RptDoc.ReportDefinition.ReportObjects["Picture1"] as PictureObject).ObjectFormat.EnableSuppress = true;

                                    if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMIGSTAmt"]) != 0)
                                    {
                                        (RptDoc.ReportDefinition.ReportObjects["Text28"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMIGSTAmt"]));
                                        (RptDoc.ReportDefinition.ReportObjects["Text14"] as TextObject).Text = "IGST Amount :";
                                        (RptDoc.ReportDefinition.ReportObjects["Text15"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text31"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text22"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text33"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text32"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text20"] as TextObject).Text = "";
                                        if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]) != 0)
                                        {
                                            (RptDoc.ReportDefinition.ReportObjects["Text15"] as TextObject).Text = "Round Off :";
                                            (RptDoc.ReportDefinition.ReportObjects["Text31"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]));
                                        }
                                    }
                                    else if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMSGSTAmt"]) != 0)
                                    {
                                        (RptDoc.ReportDefinition.ReportObjects["Text28"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMSGSTAmt"]));
                                        (RptDoc.ReportDefinition.ReportObjects["Text14"] as TextObject).Text = "SGST Amount :";
                                        (RptDoc.ReportDefinition.ReportObjects["Text31"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MMCGSTAmt"]));
                                        (RptDoc.ReportDefinition.ReportObjects["Text15"] as TextObject).Text = "CGST Amount :";
                                        (RptDoc.ReportDefinition.ReportObjects["Text22"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text33"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text32"] as TextObject).Text = "";
                                        (RptDoc.ReportDefinition.ReportObjects["Text20"] as TextObject).Text = "";
                                        if (Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]) != 0)
                                        {
                                            (RptDoc.ReportDefinition.ReportObjects["Text22"] as TextObject).Text = "Round Off :";
                                            (RptDoc.ReportDefinition.ReportObjects["Text33"] as TextObject).Text = string.Format("{0:N2}", Convert.ToDecimal(Ds.Tables[0].Rows[0]["MmOtherAmt"]));
                                        }
                                    }
                                    if ((XtraMessageBox.Show("Do you want to Print. Yes to Print/ No to PDF", "Print", MessageBoxButtons.YesNo) == DialogResult.No))
                                    {
                                        RptDoc.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:\BNPL\" + MmDocType + MMDocNo + ".pdf");
                                        System.Diagnostics.Process.Start(@"C:\BNPL\" + MmDocType + MMDocNo + ".pdf");
                                    }
                                    else
                                    {
                                        if (Ds.Tables[0].Rows.Count > 5)
                                        {
                                            var margins = RptDoc.PrintOptions.PageMargins;
                                            margins.bottomMargin = margins.topMargin;
                                            RptDoc.PrintOptions.ApplyPageMargins(margins);
                                            XtraMessageBox.Show("A4 Size paper");
                                        }
                                        RptDoc.PrintToPrinter(1, false, 0, 0);
                                    }
                                }
                            }
                        }
                        else
                            XtraMessageBox.Show("No Records to print", "!Error");
                    else
                        XtraMessageBox.Show("No Datasource, Or Unable to fetch Data.", "!Error");
                else
                    XtraMessageBox.Show("You have No permission .", "!Error");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to Print Data.\n" + ex.Message, "!Error");
            }
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
                        MaterialRecptGrid.SetRowCellValue(rowHandle, gridColumn10, true);
                }
            else
                for (int i = 0; i < MaterialRecptGrid.RowCount; i++)
                {
                    int rowHandle = MaterialRecptGrid.GetVisibleRowHandle(i);
                    if (MaterialRecptGrid.IsDataRow(rowHandle))
                        MaterialRecptGrid.SetRowCellValue(rowHandle, gridColumn10, false);
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
                            using (var changeAc = new frm_Voucher_Change_AcPosting() { Dock = DockStyle.Fill, TopLevel = true, MMDocDate = MMDocDate, MMDocNo = MMDocNo, isFg = false })
                                changeAc.ShowDialog(this);

                        }));
            }
            catch (Exception) { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MaterialRecieptGrid.DataSource != null)
                {
                    DataRow Dr = MaterialRecptGrid.GetFocusedDataRow();
                    MMDocNo = Dr["MmDocNO"].ToString();
                    MMDocDate = Convert.ToDateTime(Dr["MmDocDate"]);

                }

                using (DataSet Ds = ProjectFunctions.GetDataSet(String.Format("Select isNull(MmVhrNo,'') as VhrNo From BillToPass where MmDocNO='{0}' and  MMDocDate='{1:yyyy-MM-dd}' and MmDocType='" + _MRI + "'", MMDocNo, MMDocDate.Date)))
                    if (Ds.Tables[0].Rows[0][0].ToString() == "")
                        if (TextAuthenticate.Text == "Delme")
                        {
                            string M = String.Format("Do You want to delete:{0}----{1}?", MMDocDate.Date, MMDocNo);
                            if (DialogResult.Yes == XtraMessageBox.Show(M, "??", MessageBoxButtons.YesNo))
                            {
                                string qr = String.Format("delete from mrmst where MmDocNo='{0}' and MmDocDate='{1:yyyy-MM-dd}' and MmDocType='" + _MRI + "'; ", MMDocNo, MMDocDate.Date);
                                qr += String.Format("delete from mrdata where MdDocNo='{0}' and MdDocDate='{1:yyyy-MM-dd}' and MdDocType='" + _MRI + "' ;", MMDocNo, MMDocDate.Date);
                                qr += String.Format("delete from billtopass where MmDocNo='{0}' and MmDocDate='{1:yyyy-MM-dd}' and MmDocType='" + _MRI + "' ;", MMDocNo, MMDocDate.Date);

                                using (SqlConnection conn = new SqlConnection(ProjectFunctions.ConnectionString))
                                {
                                    conn.Open();
                                    SqlCommand cmnd = new SqlCommand(qr, conn);
                                    cmnd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Dear Sir, Your are not Authorized for ", "Error");
                            TextAuthenticate.Visible = true;
                            TextAuthenticate.Focus();
                        }
                    else
                        XtraMessageBox.Show("Bill has been Passed. Please Unpass it First.\n Please Contact Account Department.", "Error");
            }
            catch (Exception ex)
            {

            }
            TextAuthenticate.Text = "";
        }


        private void DtStartDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            DateEdit x = (sender as DateEdit);

            if (!(x.DateTime.Date >= GlobalVariables.FinYearStartDate.Date && x.DateTime.Date <= GlobalVariables.FinYearEndDate.Date))
            {
                e.Cancel = true;
            }
        }
    }
}