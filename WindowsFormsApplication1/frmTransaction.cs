using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Import.Import.PRINTS;
using DevExpress.XtraReports.UI;
using SeqKartLibrary;
using SeqKartLibrary.CrudTask;
using SeqKartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmTransaction : DevExpress.XtraEditors.XtraForm
    {
        RangeSelector _RangeSelector = new RangeSelector() { StartDate = DateTime.Now.AddYears(-1), EndDate = DateTime.Now };

        public frmTransaction()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private  async Task FillGrid_1()
        {
            try
            {
                List<EmployeeMasterModel> getEmployeeMasterDataList = await EmployeeData.GetEmployeeMasterDataList_Async("sp_LoadEmpMstFEditing", null);
                MessageBox.Show("getEmployeeMasterDataList : " + getEmployeeMasterDataList.Count);
            }
            catch(Exception ex)
            {
                PrintLogWin.PrintLog("FillGrid_1 => Exception : " + ex);
            }
        }
        private void FillGrid()
        {

            //Task.Run(async () => { await FillGrid_1(); });

            if (_RangeSelector.DtFrom.Text.Length == 0 || _RangeSelector.DtEnd.Text.Length == 0)
            {
                _RangeSelector.DtFrom.EditValue = DateTime.Now.AddYears(-1);
                _RangeSelector.DtEnd.EditValue = DateTime.Now;
            }

            string ProcedureName = ProjectFunctionsUtils.GetDataSet("Select ProgProcName from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProgProcName"].ToString();
            ProcedureName = ProcedureName + "'" + _RangeSelector.DtFrom.DateTime.Date.Date.ToString("yyyy-MM-dd") + "','" + _RangeSelector.DtEnd.DateTime.Date.Date.ToString("yyyy-MM-dd") + "','" + GlobalVariables.CUnitID + "'";
            DataSet dsMaster = ProjectFunctionsUtils.GetDataSet(ProcedureName);

            //ProjectFunctions.BindTransactionDataToGrid(ProjectFunctions.GetDataSet("Select ProgProcName from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProgProcName"].ToString(), _RangeSelector.DtFrom.DateTime.Date, _RangeSelector.DtEnd.DateTime.Date, InvoiceGrid, InvoiceGridView);
            ProjectFunctions.BindTransactionDataToGrid(dsMaster, InvoiceGrid, InvoiceGridView);

            lbl.Text = ProjectFunctionsUtils.GetDataSet("select ProCaption from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProCaption"].ToString() + " From " + _RangeSelector.StartDate.Date.ToString("dd-MM-yyyy") + " To " + _RangeSelector.EndDate.Date.ToString("dd-MM-yyyy");
            PrintLogWin.PrintLog("ProcedureName : " + ProcedureName);
        }
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            PrintLogWin.PrintLog("frmTransaction_Load ********** " + GlobalVariables.ProgCode);

            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.GirdViewVisualize(InvoiceGridView);

            FillGrid();
            if (GlobalVariables.ProgCode == "PROG132")
            {
                Transaction.Cashmemo frm = new Transaction.Cashmemo() { s1 = btnAdd.Text, Text = "Cash Memo Addition" };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(Parent);
            }
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                if (GlobalVariables.ProgCode == "PROG168")
                {
                    WindowsFormsApplication1.frm_Asset_AddUpd frm = new WindowsFormsApplication1.frm_Asset_AddUpd { IsUpdate = false, Text = "Asset Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG166")
                {
                    WindowsFormsApplication1.Transaction.frmGSTPurchase frm = new WindowsFormsApplication1.Transaction.frmGSTPurchase { s1 = btnAdd.Text, Text = "GST Purchase Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG149")
                {
                    WindowsFormsApplication1.frm_poAddition_GST frm = new WindowsFormsApplication1.frm_poAddition_GST { IsUpdate = false, Text = "Purchase Order     Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG148")
                {
                    WindowsFormsApplication1.Transaction.frmIndentMst frm = new WindowsFormsApplication1.Transaction.frmIndentMst { s1 = btnAdd.Text, Text = "Indent Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG141")
                {
                    WindowsFormsApplication1.frmInvoiceMstAddCR frm = new WindowsFormsApplication1.frmInvoiceMstAddCR() { s1 = btnAdd.Text, Text = "Credit Note Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG138")
                {
                    Transaction.frmPurchaseFromHO frm = new Transaction.frmPurchaseFromHO() { s1 = btnAdd.Text, Text = "Purchase From HO" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG134")
                {
                    Transaction.Pos.ApprovaLIssue frm = new Transaction.Pos.ApprovaLIssue() { s1 = btnAdd.Text, Text = "Approval Issue Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG133")
                {
                    Transaction.Pos.ApprovaLReturn frm = new Transaction.Pos.ApprovaLReturn() { s1 = btnAdd.Text, Text = "Approval Return Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG132")
                {
                    Transaction.Cashmemo frm = new Transaction.Cashmemo() { s1 = btnAdd.Text, Text = "Cash Memo Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG131")
                {
                    frmInvoiceMstAdd frm = new frmInvoiceMstAdd() { s1 = btnAdd.Text, Text = "Invoice Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG130")
                {
                    Transaction.frmPackingSlipWholeSale frm = new Transaction.frmPackingSlipWholeSale() { s1 = btnAdd.Text, Text = "Packing Slip Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG129")
                {
                    Transaction.frmBoxAddEdit frm = new Transaction.frmBoxAddEdit() { s1 = btnAdd.Text, Text = "Finware House Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG128")
                {
                    Transaction.frmBarPrinting frm = new Transaction.frmBarPrinting() { s1 = btnAdd.Text, Text = "Bar Printing Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG101")
                {
                    frm_SupplierPaymentVoucherAdd_Upd frm = new frm_SupplierPaymentVoucherAdd_Upd() { isupdate = false, Text = "Supplier Payment Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG90")
                {
                    frm_MaterialReciept_Add_Update_GST frm = new frm_MaterialReciept_Add_Update_GST() { _MRI = "MRI", IsUpdate = false, Text = "Material Receipt Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG91")
                {
                    frm_poAddition_GST frm = new frm_poAddition_GST() { IsUpdate = false, Text = "Purchase Order Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG7")
                {
                    Transaction.frmDealerOrderMaster frm = new Transaction.frmDealerOrderMaster() { s1 = btnAdd.Text, Text = "Order Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }



                //if (GlobalVariables.ProgCode == "PROG26")
                //{
                //    Transaction.frmGeneralInvoiceMst frm = new Transaction.frmGeneralInvoiceMst() { s1 = btnAdd.Text, Text = "Invoice Master" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG87")
                {
                    Transaction.frmIndentMst frm = new Transaction.frmIndentMst() { s1 = btnAdd.Text, Text = "Indent Master" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG27")
                {
                    frmAdvanceAddEdit frm = new frmAdvanceAddEdit() { s1 = btnAdd.Text, Text = "Advance Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG28")
                {
                    frmLoanMstAddEdit frm = new frmLoanMstAddEdit() { s1 = btnAdd.Text, Text = "Loan Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG35")
                {
                    frmTdsDeductionAddEdit frm = new frmTdsDeductionAddEdit() { s1 = btnAdd.Text, Text = "TDS Deduction Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG46")
                {
                    frm_JournalNBankVoucher frm = new frm_JournalNBankVoucher() { s1 = btnAdd.Text, Text = "Voucher Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG55")
                //{
                //    Transaction.frmProductionData frm = new Transaction.frmProductionData() { s1 = btnAdd.Text, Text = "Production Data Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}

                if (GlobalVariables.ProgCode == "PROG58")
                {
                    frmSchemeMstAddEdit frm = new frmSchemeMstAddEdit() { s1 = btnAdd.Text, Text = "Scheme Data Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG56")
                //{
                //    Transaction.frmPackingDespatch frm = new Transaction.frmPackingDespatch() { s1 = btnAdd.Text, Text = "Packing Despatch Data Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                //if (GlobalVariables.ProgCode == "PROG65")
                //{
                //    Transaction.frmReturnCrates frm = new Transaction.frmReturnCrates() { s1 = btnAdd.Text, Text = "Return Crates Data Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                //if (GlobalVariables.ProgCode == "PROG57")
                //{
                //    Transaction.frmStockOutData frm = new Transaction.frmStockOutData() { s1 = btnAdd.Text, Text = "Stock Out Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}

                //if (GlobalVariables.ProgCode == "PROG74")
                //{
                //    Transaction.frmCRDataData frm = new Transaction.frmCRDataData() { s1 = btnAdd.Text, Text = "Cash Receiving" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG142")
                {
                    WindowsFormsApplication1.Transaction.challans.frm_ChallanOutward frm = new WindowsFormsApplication1.Transaction.challans.frm_ChallanOutward { s1 = btnAdd.Text, Text = "Outward Challan Edition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
            }
            FillGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                if (GlobalVariables.ProgCode == "PROG166")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    WindowsFormsApplication1.Transaction.frmGSTPurchase frm = new WindowsFormsApplication1.Transaction.frmGSTPurchase { s1 = btnEdit.Text, Text = "GST Purchase Edition", ImNo = CurrentRow["SIMNO"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["SIMDATE"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG149")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    WindowsFormsApplication1.frm_poAddition_GST frm = new WindowsFormsApplication1.frm_poAddition_GST { IsUpdate = true, Text = "Purchase Order Edition", PoNo = CurrentRow["PONo"].ToString(), PoDate = Convert.ToDateTime(CurrentRow["Date"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG149")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    WindowsFormsApplication1.frm_poAddition_GST frm = new WindowsFormsApplication1.frm_poAddition_GST { IsUpdate = true, Text = "Purchase Order Edition", PoNo = CurrentRow["PONo"].ToString(), PoDate = Convert.ToDateTime(CurrentRow["Date"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG148")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    WindowsFormsApplication1.Transaction.frmIndentMst frm = new WindowsFormsApplication1.Transaction.frmIndentMst { s1 = btnEdit.Text, Text = "Indent Edition", ImNo = CurrentRow["IndentNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["IndentDate"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG142")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    Transaction.challans.frm_ChallanOutward frm = new Transaction.challans.frm_ChallanOutward { s1 = btnEdit.Text, Text = "Challan Outward Edition", ImNo = CurrentRow["CHONO"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["CHODATE"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG141")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    WindowsFormsApplication1.frmInvoiceMstAddCR frm = new WindowsFormsApplication1.frmInvoiceMstAddCR() { s1 = btnEdit.Text, Text = "Credit Note Edition", ImDate = Convert.ToDateTime(CurrentRow["CRDate"]), ImNo = CurrentRow["CRNo"].ToString(), ImSeries = CurrentRow["CRSeries"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG138")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    Transaction.frmPurchaseFromHO frm = new Transaction.frmPurchaseFromHO() { s1 = btnEdit.Text, Text = "Purchase From HO", SFDVNO = CurrentRow["SFDVNO"].ToString(), SFMTOTBOX = CurrentRow["SFDBOXNO"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG134")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    Transaction.Pos.ApprovaLIssue frm = new Transaction.Pos.ApprovaLIssue() { s1 = btnEdit.Text, Text = "Approval Issue Edition", ImDate = Convert.ToDateTime(CurrentRow["BillDate"]), ImNo = CurrentRow["BillNo"].ToString(), ImSeries = CurrentRow["BillSeries"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG133")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    Transaction.Pos.ApprovaLReturn frm = new Transaction.Pos.ApprovaLReturn() { s1 = btnEdit.Text, Text = "Approval Return Edition", ImDate = Convert.ToDateTime(CurrentRow["BillDate"]), ImNo = CurrentRow["BillNo"].ToString(), ImSeries = CurrentRow["BillSeries"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG132")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Transaction.Cashmemo frm = new Transaction.Cashmemo() { s1 = btnEdit.Text, Text = "Cash Memo Edition", ImDate = Convert.ToDateTime(CurrentRow["BillDate"]), ImNo = CurrentRow["BillNo"].ToString(), ImSeries = CurrentRow["BillSeries"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG131")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmInvoiceMstAdd frm = new frmInvoiceMstAdd() { s1 = btnEdit.Text, Text = "Invoice Master Edition", ImDate = Convert.ToDateTime(CurrentRow["BillDate"]), ImNo = CurrentRow["BillNo"].ToString(), ImSeries = CurrentRow["BillSeries"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG130")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Transaction.frmPackingSlipWholeSale frm = new Transaction.frmPackingSlipWholeSale() { s1 = btnEdit.Text, Text = "Packing Slip Edition", PSWSNO = CurrentRow["PSWSNO"].ToString(), PSWSTOTBOXES = CurrentRow["SIDBOXNO"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG129")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Transaction.frmBoxAddEdit frm = new Transaction.frmBoxAddEdit() { s1 = btnEdit.Text, Text = "Finware House Edition", SFDVNO = CurrentRow["SFDVNO"].ToString(), SFMTOTBOX = CurrentRow["SFDBOXNO"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG128")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Transaction.frmBarPrinting frm = new Transaction.frmBarPrinting() { s1 = btnEdit.Text, Text = "Bar Printing Edition", SKUVOUCHNO = CurrentRow["SKUVOUCHNO"].ToString(), Tag = CurrentRow["BarCodeType"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG101")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frm_SupplierPaymentVoucherAdd_Upd frm = new frm_SupplierPaymentVoucherAdd_Upd() { Text = "Supplier Payment", isupdate = true, VoucherDate = Convert.ToDateTime(CurrentRow["Voucher Date"]), VoucherNo = CurrentRow["Voucher No."].ToString(), VoucherType = CurrentRow["Type"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);

                }


                if (GlobalVariables.ProgCode == "PROG90")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frm_MaterialReciept_Add_Update_GST frm = new frm_MaterialReciept_Add_Update_GST() { Text = "Material Receipt Editing", IsUpdate = true, MMDocDate = Convert.ToDateTime(CurrentRow["MMDocDate"]), MMDocNo = CurrentRow["MMDocNo"].ToString(), _MRI = "MRI" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);

                }
                if (GlobalVariables.ProgCode == "PROG91")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frm_poAddition_GST frm = new frm_poAddition_GST() { Text = "Purchase Order Editing", IsUpdate = true, PoNo = CurrentRow["PONO"].ToString(), PoDate = Convert.ToDateTime(CurrentRow["Date"]), PoId = CurrentRow["PomID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);

                }
                if (GlobalVariables.ProgCode == "PROG89")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Transaction.frmIndentPassing frm = new Transaction.frmIndentPassing() { Text = "Indent Editing", IndentNo = CurrentRow["IndentNo"].ToString(), IndentDate = Convert.ToDateTime(CurrentRow["IndentDate"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }

                if (GlobalVariables.ProgCode == "PROG87")
                {

                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    DataSet dsCheck = ProjectFunctions.GetDataSet("Select * from IndData Where IndDDate='" + Convert.ToDateTime(CurrentRow["IndentDate"]).ToString("yyyy-MM-dd") + "' And InddNO='" + CurrentRow["IndentNo"].ToString() + "'");
                    foreach (DataRow dr in dsCheck.Tables[0].Rows)
                    {
                        if (dr["IndPassTag"].ToString().ToUpper() == "Y")
                        {
                            ProjectFunctions.SpeakError("This Indent Has Already Been Passed");
                            return;
                        }
                    }
                    Transaction.frmIndentMst frm = new Transaction.frmIndentMst() { s1 = btnEdit.Text, Text = "indent Editing", ImNo = CurrentRow["IndentNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["IndentDate"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }

                if (GlobalVariables.ProgCode == "PROG7")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    DataSet dsCheckInvoice = ProjectFunctions.GetDataSet("Select ImNo from invoiceMst WHere ImOrderNo='" + CurrentRow["OrdNo"].ToString() + "'");
                    if (dsCheckInvoice.Tables[0].Rows.Count > 0)
                    {
                        ProjectFunctions.SpeakError("Invoice Has Been Generated Against This Bill");
                        return;
                    }
                    else
                    {
                        DataSet dsCheckOrder = ProjectFunctions.GetDataSet("Select ImPassTag from DealerOrderMst WHere OrdNo ='" + CurrentRow["OrdNo"].ToString() + "' And ImPassTag='Y'");
                        if (dsCheckOrder.Tables[0].Rows.Count > 0)
                        {
                            ProjectFunctions.SpeakError("Order Has Been Already Passed");
                            return;
                        }
                        else
                        {
                            Transaction.frmDealerOrderMaster frm = new Transaction.frmDealerOrderMaster() { s1 = btnEdit.Text, Text = "Order Editing", OrderNo = CurrentRow["OrdNo"].ToString() };
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog(Parent);
                        }
                    }
                }

                //if (GlobalVariables.ProgCode == "PROG26")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Transaction.frmGeneralInvoiceMst frm = new Transaction.frmGeneralInvoiceMst() { s1 = btnEdit.Text, Text = "Invoice Editing", ImNo = CurrentRow["BillNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["BillDate"]) };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG27")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmAdvanceAddEdit frm = new frmAdvanceAddEdit() { s1 = btnEdit.Text, Text = "Advance Editing", ExId = CurrentRow["ExId"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG28")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmLoanMstAddEdit frm = new frmLoanMstAddEdit() { s1 = btnEdit.Text, Text = "Loan Editing", LoanNo = CurrentRow["LoanANo"].ToString(), LoanADate = Convert.ToDateTime(CurrentRow["LoanADate"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG35")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmTdsDeductionAddEdit frm = new frmTdsDeductionAddEdit() { s1 = btnEdit.Text, Text = "TDS Deduction Editing", TdNo = CurrentRow["TDNo"].ToString(), TdDate = Convert.ToDateTime(CurrentRow["TDDate"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG46")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frm_JournalNBankVoucher frm = new frm_JournalNBankVoucher() { isupdate = true, s1 = btnEdit.Text, Text = "Voucher Editing", VoucherNo = CurrentRow["Voucher No."].ToString(), VoucherDate = Convert.ToDateTime(CurrentRow["Voucher Date"]), VoucherType = CurrentRow["Type"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG55")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Transaction.frmProductionData frm = new Transaction.frmProductionData() { s1 = btnEdit.Text, Text = "Production Data Editing", ImNo = CurrentRow["ImNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["ImDate"]) };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG58")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmSchemeMstAddEdit frm = new frmSchemeMstAddEdit() { s1 = btnEdit.Text, Text = "Scheme Data Editing", ImNo = CurrentRow["ImNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["ImDate"]) };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG56")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Transaction.frmPackingDespatch frm = new Transaction.frmPackingDespatch() { s1 = btnEdit.Text, Text = "Packing Despatch Data Editing", ImNo = CurrentRow["ImNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["ImDate"]) };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                //if (GlobalVariables.ProgCode == "PROG65")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Transaction.frmReturnCrates frm = new Transaction.frmReturnCrates() { s1 = btnEdit.Text, Text = "Return Crates Data Editing", ImNo = CurrentRow["CmNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["CmDate"]) };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                //if (GlobalVariables.ProgCode == "PROG57")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Transaction.frmStockOutData frm = new Transaction.frmStockOutData() { s1 = btnEdit.Text, Text = "Stock Out Data Editing", ImNo = CurrentRow["MmDocNo"].ToString(), ImDate = Convert.ToDateTime(CurrentRow["MmDocDate"]) };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG37")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Transaction.frmBankMarking frm = new Transaction.frmBankMarking() { Text = "Bank Marking", AccCode = CurrentRow["VutACode"].ToString(), StartDate = _RangeSelector.DtFrom.DateTime.Date, EndDate = _RangeSelector.DtEnd.DateTime.Date };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                }

                if (GlobalVariables.ProgCode == "PROG74")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    DataSet dsCheck = ProjectFunctions.GetDataSet("Select CPassTag from CRData Where CDate='" + Convert.ToDateTime(CurrentRow["CDate"]).ToString("yyyy-MM-dd") + "' And CNo='" + CurrentRow["CNo"].ToString() + "'");
                    if (dsCheck.Tables[0].Rows[0]["CPassTag"].ToString() == "Y")
                    {
                        ProjectFunctions.SpeakError("Please Unpass First");
                    }
                    else
                    {
                        //  Transaction.frmCRDataData frm = new Transaction.frmCRDataData() { s1 = btnEdit.Text, Text = "Cash Receiving ", CNo = CurrentRow["CNo"].ToString(), CDate = Convert.ToDateTime(CurrentRow["CDate"]) };
                        //frm.StartPosition = FormStartPosition.CenterScreen; frm.ShowDialog(Parent);
                    }
                }

            }
            FillGrid();
        }

        private void InvoiceGrid_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, e);
        }

        private void InvoiceGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEdit_Click(null, e);
            }
        }


        private void PrintReport(String PrintType)
        {

        }
        private void InvoiceGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if (GlobalVariables.ProgCode == "PROG142")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Challan", (o1, e1) =>
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CopyText", typeof(String));
                        dt.Columns.Add("Select", typeof(bool));
                        dt.Rows.Add("Party Copy", false);
                        dt.Rows.Add("Gate Copy", false);
                        dt.Rows.Add("Extra Copy", false);
                        PrintOutGrid.DataSource = dt;
                        PrintOutGridView.BestFitColumns();
                        PrintOutGrid.Visible = true;

                    }));
                }
                if (GlobalVariables.ProgCode == "PROG46")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Seletcted Voucher", (o1, e1) =>
                    {
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                using (var Ds = ProjectFunctions.GetDataSet(String.Format("Select * From V_PrintCMN WHERE (((VutDate)='{0:yyyy-MM-dd}') AND ((VutType)='{1}')  AND ((VutNo)='{2}')) {3}", Convert.ToDateTime(dr["Voucher Date"]), dr["Type"].ToString(), dr["Voucher No."].ToString(), ((dr["Type"].ToString() == "CP" || dr["Type"].ToString() == "CR") ? "And VutAcode<>'246'" : string.Empty))))
                                {

                                    if (Ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (dr["Type"].ToString().ToUpper() == "CP" || dr["Type"].ToString().ToUpper() == "CR")
                                        {
                                            var rowToRemove = Ds.Tables[0].Select("VutAcode=246").FirstOrDefault();
                                            if (rowToRemove != null)
                                            {
                                                Ds.Tables[0].Rows.Remove(rowToRemove);
                                            }
                                        }
                                        using (var pt = new ReportPrintTool(new WindowsFormsApplication1.Report.Rpt_VoucherPrint() { DataSource = Ds.Tables[0] }))
                                        {
                                            pt.ShowRibbonPreviewDialog();
                                        }
                                    }
                                }
                            }
                        }
                        FillGrid();
                    }));
                }
                if (GlobalVariables.ProgCode == "PROG131")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Post Invoice", (o1, e1) =>
                    {
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                if (dr["BillSeries"].ToString() == "GST")
                                {
                                    ProjectFunctions.GetDataSet("sp_slvposting '" + dr["BillNo"].ToString() + "','" + Convert.ToDateTime(dr["BillDate"]).ToString("yyyy-MM-dd") + "','GST','" + GlobalVariables.CUnitID + "'");
                                }
                            }
                        }
                        ProjectFunctions.SpeakError("Vouchers Posted Successfully");
                        FillGrid();
                    }));
                }
                if (GlobalVariables.ProgCode == "PROG141")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Post Sale Return", (o1, e1) =>
                    {
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                if (dr["CRSeries"].ToString() == "RG")
                                {
                                    ProjectFunctions.GetDataSet("sp_srvposting '" + dr["CRNo"].ToString() + "','" + Convert.ToDateTime(dr["CRDate"]).ToString("yyyy-MM-dd") + "','RG','" + GlobalVariables.CUnitID + "'");
                                }
                            }
                        }
                        ProjectFunctions.SpeakError("Vouchers Posted Successfully");
                        FillGrid();
                    }));
                }
                if (GlobalVariables.ProgCode == "PROG132")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();

                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Post Cash Memo", (o1, e1) =>
                    {
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                if (dr["BillSeries"].ToString() == "S")
                                {

                                    if (Convert.ToDecimal(dr["CASHAmount"]) > 0)
                                    {
                                        ProjectFunctions.GetDataSet("[SP_CashMemoVoucher] '" + dr["BillNo"].ToString() + "','" + Convert.ToDateTime(dr["BillDate"]).ToString("yyyy-MM-dd") + "','S','" + GlobalVariables.CUnitID + "','CR'");
                                    }
                                    if (Convert.ToDecimal(dr["CATCARDAMT"]) > 0 || Convert.ToDecimal(dr["CATPGAMT"]) > 0)
                                    {
                                        ProjectFunctions.GetDataSet("[SP_CashMemoVoucher] '" + dr["BillNo"].ToString() + "','" + Convert.ToDateTime(dr["BillDate"]).ToString("yyyy-MM-dd") + "','S','" + GlobalVariables.CUnitID + "','BR'");
                                    }
                                }
                            }
                        }
                        ProjectFunctions.SpeakError("Vouchers Posted Successfully");
                        FillGrid();
                    }));
                }
                if (GlobalVariables.ProgCode == "PROG132")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Invoice", (o1, e1) =>
                    {
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                if (dr["BillSeries"].ToString().ToUpper() == "S")
                                {
                                    Prints.CASHMEMO rpt = new Prints.CASHMEMO();
                                    ProjectFunctions.PrintDocument(dr["BillNo"].ToString(), Convert.ToDateTime(dr["BillDate"]), dr["BillSeries"].ToString(), rpt);
                                }
                                if (dr["BillSeries"].ToString().ToUpper() == "N")
                                {
                                    Prints.CASHMEMO rpt = new Prints.CASHMEMO();
                                    rpt.xrLabel9.Text = "Credit Note";
                                    rpt.xrLabel29.Text = "Net Amount";
                                    ProjectFunctions.PrintDocument(dr["BillNo"].ToString(), Convert.ToDateTime(dr["BillDate"]), dr["BillSeries"].ToString(), rpt);
                                }

                            }
                        }
                    }));
                }


                if (GlobalVariables.ProgCode == "PROG134")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Invoice", (o1, e1) =>
                    {
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                if (dr["BillSeries"].ToString().ToUpper() == "AP")
                                {
                                    Prints.APPROVAL rpt = new Prints.APPROVAL();
                                    ProjectFunctions.PrintDocument(dr["BillNo"].ToString(), Convert.ToDateTime(dr["BillDate"]), dr["BillSeries"].ToString(), rpt);
                                }

                            }
                        }
                    }));
                }


                //if (GlobalVariables.ProgCode == "PROG141")
                //{
                //    InvoiceGridView.CloseEditor();
                //    InvoiceGridView.UpdateCurrentRow();
                //    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Credit Note", (o1, e1) =>
                //    {
                //        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                //        {
                //            if (dr["Select"].ToString().ToUpper() == "TRUE")
                //            {
                //                if (dr["BillSeries"].ToString().ToUpper() == "AP")
                //                {
                //                    Prints.APPROVAL rpt = new Prints.APPROVAL();
                //                    ProjectFunctions.PrintDocument(dr["BillNo"].ToString(), Convert.ToDateTime(dr["BillDate"]), dr["BillSeries"].ToString(), rpt);
                //                }

                //            }
                //        }
                //    }));
                //}


                if (GlobalVariables.ProgCode == "PROG131" || GlobalVariables.ProgCode == "PROG141")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Invoice", (o1, e1) =>
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CopyText", typeof(String));
                        dt.Columns.Add("Select", typeof(bool));

                        dt.Rows.Add("Original For Buyer", false);
                        dt.Rows.Add("Office Copy", false);
                        dt.Rows.Add("Transporter Copy", false);
                        dt.Rows.Add("Extra Copy", false);

                        PrintOutGrid.DataSource = dt;
                        PrintOutGridView.BestFitColumns();
                        PrintOutGrid.Visible = true;
                    }));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Generate PT File", (o1, e1) =>
                    {
                        DataRow row = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                        DataSet ds = ProjectFunctions.GetDataSet("SP_PTFile '" + row["BillNo"].ToString() + "','" + GlobalVariables.FinancialYear + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            PrintOutGridView.Columns.Clear();
                            PrintOutGrid.DataSource = ds.Tables[0];
                            PrintOutGridView.BestFitColumns();
                            PrintOutGridView.ExportToCsv(Application.StartupPath + @"\PTFile\" + row["DebitPartyName"].ToString() + "_GST_" + row["BillNo"].ToString() + ".csv");
                            ProjectFunctions.SpeakError("PT File Generated Successfully ");
                            this.Close();
                        }
                        else
                        {
                            ProjectFunctions.SpeakError("Some Error In PT File Generation");
                        }
                    }));
                }

                //if (GlobalVariables.ProgCode == "PROG131")
                //{
                //    InvoiceGridView.CloseEditor();
                //    InvoiceGridView.UpdateCurrentRow();
                //    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Invoice", (o1, e1) =>
                //    {
                //        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                //        {
                //            if (dr["Select"].ToString().ToUpper() == "TRUE")
                //            {
                //                if (dr["BillSeries"].ToString().ToUpper() == "GST")
                //                {
                //                    Prints.GSTINVOICE rpt = new Prints.GSTINVOICE();
                //                    ProjectFunctions.PrintDocument(dr["BillNo"].ToString(), Convert.ToDateTime(dr["BillDate"]), dr["BillSeries"].ToString(), rpt);

                //                }
                //                if (dr["BillSeries"].ToString().ToUpper() == "DCO")
                //                {
                //                    Prints.InvoicePrintBT rpt = new Prints.InvoicePrintBT();
                //                    ProjectFunctions.PrintDocument(dr["BillNo"].ToString(), Convert.ToDateTime(dr["BillDate"]), dr["BillSeries"].ToString(), rpt);
                //                }

                //            }
                //        }
                //    }));
                //}

                if (GlobalVariables.ProgCode == "PROG130")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Packing Slip", (o1, e1) =>
                    {

#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
                        int i = 0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                DataTable dt = new DataTable();
                                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadPackingSLipPrint '" + dr["PSWSNO"].ToString() + "','" + dr["SIDBOXNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "'");
                                ds.Tables[0].WriteXmlSchema("C://Temp//abc.xml");
                                Prints.Packingslip rpt = new Prints.Packingslip();
                                rpt.DataSource = ds.Tables[0];
                                rpt.CreateDocument();

                                payroll.FormReports.PrintReportViewer frm = new payroll.FormReports.PrintReportViewer() { pkInstalledPrinters = @"\\bhupinder-pc\EPSON L210 Series" };
                                frm.documentViewer1.DocumentSource = rpt;
                                frm.ShowDialog(this.Parent);

                            }
                        }
                    }));
                }


                if (GlobalVariables.ProgCode == "PROG129")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Ware House Box", (o1, e1) =>
                    {

#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
                        int i = 0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE")
                            {
                                DataTable dt = new DataTable();
                                DataSet ds = ProjectFunctions.GetDataSet("SP_LoadBoxPrint '" + dr["SFDVNO"].ToString() + "','" + dr["SFDBOXNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "'");
                                ds.Tables[0].WriteXmlSchema("C://Temp//abc.xml");
                                using (var pt = new ReportPrintTool(new Prints.BoxPrinting() { DataSource = ds.Tables[0] }))
                                {
                                    pt.ShowRibbonPreviewDialog();
                                }
                            }
                        }
                    }));
                }

                if (GlobalVariables.ProgCode == "PROG128")
                {
                    InvoiceGridView.CloseEditor();
                    InvoiceGridView.UpdateCurrentRow();
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print BarCode", (o1, e1) =>
                    {

                        int i = 0;
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE" && dr["SKUPrintTag"].ToString().ToUpper() == "N")
                            {
                                DataTable dt = new DataTable();
                                if (dr["BarCodeType"].ToString() == "Unique")
                                {
                                    DataSet ds = ProjectFunctions.GetDataSet("sp_PrintBarCode '" + dr["SKUVOUCHNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "','" + dr["BarCodeType"].ToString() + "'");
                                    if (i == 0)
                                    {
                                        dt = ds.Tables[0];
                                        i++;
                                    }
                                    else
                                    {
                                        dt.Merge(ds.Tables[0]);
                                    }
                                    if (dt.Rows.Count > 0)
                                    {
                                        dt.WriteXmlSchema("C://Temp//abc.xml");
                                        using (var pt = new ReportPrintTool(new Prints.BarPrinting() { DataSource = dt }))
                                        {


                                            pt.ShowRibbonPreviewDialog();
                                            FillGrid();
                                        }
                                    }
                                    ProjectFunctions.GetDataSet("Update sku set SKUPrintTag='Y' Where skuvouchno='" + dr["SKUVOUCHNO"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "' And   SKUFNYR='" + GlobalVariables.FinancialYear + "'");
                                }
                                else
                                {
                                    DataSet ds = ProjectFunctions.GetDataSet("sp_PrintBarCode '" + dr["SKUVOUCHNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "','" + dr["BarCodeType"].ToString() + "'");
                                    if (i == 0)
                                    {
                                        dt = ds.Tables[0];
                                        i++;
                                    }
                                    else
                                    {
                                        dt.Merge(ds.Tables[0]);
                                    }


                                    DataTable dtFinal = new DataTable();
                                    dtFinal = dt.Clone();

                                    foreach (DataRow drFix in dt.Rows)
                                    {
                                        for (int j = 0; j < Convert.ToDecimal(drFix["SKUFEDQTY"]); j++)
                                        {
                                            dtFinal.ImportRow(drFix);
                                        }
                                    }

                                    foreach (DataRow drFinal in dtFinal.Rows)
                                    {
                                        drFinal["SKUFEDQTY"] = Convert.ToDecimal("1");
                                    }
                                    if (dtFinal.Rows.Count > 0)
                                    {
                                        dtFinal.WriteXmlSchema("C://Temp//abc.xml");
                                        using (var pt = new ReportPrintTool(new Prints.BarPrinting() { DataSource = dtFinal }))
                                        {
                                            pt.ShowRibbonPreviewDialog();
                                            FillGrid();
                                        }
                                    }
                                    ProjectFunctions.GetDataSet("Update sku_fix set SKUPrintTag='Y' Where skuvouchno='" + dr["SKUVOUCHNO"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "' And   SKUFNYR='" + GlobalVariables.FinancialYear + "'");
                                }
                            }
                        }


                    }));

                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Print Muffler", (o1, e1) =>
                    {

                        int i = 0;
                        foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                        {
                            if (dr["Select"].ToString().ToUpper() == "TRUE" && dr["SKUPrintTag"].ToString().ToUpper() == "N")
                            {
                                DataTable dt = new DataTable();
                                if (dr["BarCodeType"].ToString() == "Unique")
                                {
                                    DataSet ds = ProjectFunctions.GetDataSet("sp_PrintBarCode '" + dr["SKUVOUCHNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "','" + dr["BarCodeType"].ToString() + "'");
                                    if (i == 0)
                                    {
                                        dt = ds.Tables[0];
                                        i++;
                                    }
                                    else
                                    {
                                        dt.Merge(ds.Tables[0]);
                                    }
                                    if (dt.Rows.Count > 0)
                                    {
                                        dt.WriteXmlSchema("C://Temp//abc.xml");
                                        using (var pt = new ReportPrintTool(new Prints.Mufflerprint() { DataSource = dt }))
                                        {
                                            pt.ShowRibbonPreviewDialog();
                                            FillGrid();
                                        }
                                    }
                                    ProjectFunctions.GetDataSet("Update sku set SKUPrintTag='Y' Where skuvouchno='" + dr["SKUVOUCHNO"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "' And   SKUFNYR='" + GlobalVariables.FinancialYear + "'");
                                }
                                else
                                {
                                    DataSet ds = ProjectFunctions.GetDataSet("sp_PrintBarCode '" + dr["SKUVOUCHNO"].ToString() + "','" + GlobalVariables.FinancialYear + "','" + GlobalVariables.CUnitID + "','" + dr["BarCodeType"].ToString() + "'");
                                    if (i == 0)
                                    {
                                        dt = ds.Tables[0];
                                        i++;
                                    }
                                    else
                                    {
                                        dt.Merge(ds.Tables[0]);
                                    }


                                    DataTable dtFinal = new DataTable();
                                    dtFinal = dt.Clone();

                                    foreach (DataRow drFix in dt.Rows)
                                    {
                                        for (int j = 0; j < Convert.ToDecimal(drFix["SKUFEDQTY"]); j++)
                                        {
                                            dtFinal.ImportRow(drFix);
                                        }
                                    }

                                    foreach (DataRow drFinal in dtFinal.Rows)
                                    {
                                        drFinal["SKUFEDQTY"] = Convert.ToDecimal("1");
                                    }
                                    if (dtFinal.Rows.Count > 0)
                                    {
                                        dtFinal.WriteXmlSchema("C://Temp//abc.xml");
                                        using (var pt = new ReportPrintTool(new Prints.Mufflerprint() { DataSource = dtFinal }))
                                        {
                                            pt.ShowRibbonPreviewDialog();
                                            FillGrid();
                                        }
                                    }
                                    ProjectFunctions.GetDataSet("Update sku_fix set SKUPrintTag='Y' Where skuvouchno='" + dr["SKUVOUCHNO"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "' And   SKUFNYR='" + GlobalVariables.FinancialYear + "'");
                                }
                            }
                        }


                    }));
                }





                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Select Data Range", (o1, e1) =>
            {
                Controls.Add(_RangeSelector);
                _RangeSelector.BtnLoad.Click += new EventHandler(BtnLoad_Click);
                _RangeSelector.BringToFront();
                _RangeSelector.Location = new Point(e.Point.X + 20, e.Point.Y + 20);
                _RangeSelector.Show();
                _RangeSelector.DtFrom.Focus();
            }));
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Select All Records", (o1, e1) =>
                {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    var MaxRow = ((InvoiceGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    for (var i = 0; i < MaxRow; i++)
                    {
                        InvoiceGridView.SetRowCellValue(i, InvoiceGridView.Columns["Select"], true);
                    }
                }));
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("UnSelect All Records", (o1, e1) =>
                {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    var MaxRow = ((InvoiceGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
                    for (var i = 0; i < MaxRow; i++)
                    {
                        InvoiceGridView.SetRowCellValue(i, InvoiceGridView.Columns["Select"], false);
                    }
                }));



                if (GlobalVariables.ProgCode == "PROG87")
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Pass/UnPass Selected Indent Entry", (o1, e1) =>
                    {
                        frm_StockIndentPassing frm = new frm_StockIndentPassing();
                        var P = ProjectFunctions.GetPositionInForm(this);
                        frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                        frm.ShowDialog(Parent);
                    }));
                }
                if (GlobalVariables.ProgCode == "PROG116")
                {

                }
                if (GlobalVariables.ProgCode == "PROG32")
                {

                }
                if (GlobalVariables.ProgCode == "PROG74")
                {

                }

                if (GlobalVariables.ProgCode == "PROG46")
                {
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete Selected Vouchers", (o1, e1) =>
                    {
                        DeleteVouchers();
                        FillGrid();
                    }));
                }
            }

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }
        }
        private void DeleteVouchers()
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((InvoiceGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            for (var i = 0; i < MaxRow; i++)
            {
                DataRow CurrentRow = InvoiceGridView.GetDataRow(i);
                if (CurrentRow["Select"].ToString().ToUpper() == "TRUE")
                {
                    DataSet ds = ProjectFunctions.GetDataSet("Select VumAutoGen from VuMst Where VumNo='" + CurrentRow["Voucher No."].ToString() + "' And   VumDate  ='" + Convert.ToDateTime(CurrentRow["Voucher Date"]).ToString("yyyy-MM-dd") + "' And VumType='" + CurrentRow["Type"].ToString() + "' And UnitCode='" + GlobalVariables.CUnitID + "'");
                    if (ds.Tables[0].Rows[0][0].ToString() == "Y")
                    {
                        ProjectFunctions.SpeakError("An Autogenerated Voucher Cannot Be Deleted");
                    }
                    else
                    {
                        ProjectFunctions.GetDataSet(" sp_DeleteVoucher '" + CurrentRow["Voucher No."].ToString() + "','" + Convert.ToDateTime(CurrentRow["Voucher Date"]).ToString("yyyy-MM-dd") + "','" + CurrentRow["Type"].ToString() + "','" + GlobalVariables.CUnitID + "'");
                    }
                }
            }
        }
        private async void BtnLoad_Click(object sender, EventArgs e)
        {
            _RangeSelector.Visible = false;
            await Task.Delay(10);
            //await TransactionTask();
            FillGrid();
        }

        public async Task TransactionTask()
        {
            await Task.Run(() =>
            {
                string ProcedureName = ProjectFunctionsUtils.GetDataSet("Select ProgProcName from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProgProcName"].ToString();
                DataSet dsMaster = ProjectFunctionsUtils.GetDataSet(ProcedureName + "'" + _RangeSelector.DtEnd.DateTime.Date.ToString("yyyy-MM-dd") + "','" + _RangeSelector.DtEnd.DateTime.Date.ToString("yyyy-MM-dd") + "','" + GlobalVariables.CUnitID + "'");

                ProjectFunctions.BindTransactionDataToGrid(dsMaster, InvoiceGrid, InvoiceGridView);
                lbl.Text = ProjectFunctions.GetDataSet("select ProCaption from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'").Tables[0].Rows[0]["ProCaption"].ToString() + " From " + _RangeSelector.DtFrom.DateTime.Date.ToString("dd-MM-yyyy") + " To " + _RangeSelector.DtEnd.DateTime.Date.ToString("dd-MM-yyyy");

            });
        }

        private void InvoiceGrid_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            PrintOutGridView.CloseEditor();
            PrintOutGridView.UpdateCurrentRow();
            if (GlobalVariables.ProgCode == "PROG142")
            {
                foreach (DataRow dr in (InvoiceGrid.DataSource as DataTable).Rows)
                {
                    if (dr["Select"].ToString().ToUpper() == "TRUE")
                    {

                        for (int i = 0; i < 3; i++)
                        {
                            String CopyText = String.Empty;
                            DataRow CurrentRow = PrintOutGridView.GetDataRow(i);
                            if (CurrentRow["Select"].ToString().ToUpper() == "TRUE")
                            {
                                if (i == 0)
                                {
                                    CopyText = "Party Copy";
                                }
                                if (i == 1)
                                {
                                    CopyText = "Gate Copy";
                                }
                                if (i == 2)
                                {
                                    CopyText = "Extra Copy";
                                }

                                DataTable dt = new DataTable();
                                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadChallanOutPrint '" + dr["CHONO"].ToString() + "','" + Convert.ToDateTime(dr["CHODATE"]).ToString("yyyy-MM-dd") + "','" + GlobalVariables.CUnitID + "'");
                                ds.WriteXmlSchema("C://Temp//abc.xml");
                                challanoutward rpt = new challanoutward();
                                rpt.DataSource = ds.Tables[0];
                                rpt.lblCopy.Text = CopyText;
                                rpt.lblGrossWeight.Text = ds.Tables[1].Rows[0]["GrossWeight"].ToString();
                                rpt.lblNetWeight.Text = ds.Tables[1].Rows[0]["NetWeight"].ToString();
                                using (var pt = new ReportPrintTool(rpt))
                                {
                                    pt.ShowRibbonPreviewDialog();
                                }


                            }
                        }

                    }
                }
            }
            else

            {
                foreach (DataRow drBills in (InvoiceGrid.DataSource as DataTable).Rows)
                {
                    if (drBills["Select"].ToString().ToUpper() == "TRUE")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            String CopyText = String.Empty;
                            DataRow CurrentRow = PrintOutGridView.GetDataRow(i);
                            if (CurrentRow["Select"].ToString().ToUpper() == "TRUE")
                            {
                                if (i == 0)
                                {
                                    CopyText = "Original For Buyer";
                                }
                                if (i == 1)
                                {
                                    CopyText = "Office Copy";
                                }
                                if (i == 2)
                                {
                                    CopyText = "Transporter Copy";
                                }
                                if (i == 3)
                                {
                                    CopyText = "Extra Copy";
                                }
                                if (GlobalVariables.ProgCode == "PROG131")
                                {
                                    if (drBills["BillSeries"].ToString().ToUpper() == "GST")
                                    {
                                        Prints.GSTINVOICE rpt = new Prints.GSTINVOICE();
                                        rpt.lblCopy.Text = CopyText;

                                        ProjectFunctions.PrintDocument(drBills["BillNo"].ToString(), Convert.ToDateTime(drBills["BillDate"]), drBills["BillSeries"].ToString(), rpt);

                                    }
                                    if (drBills["BillSeries"].ToString().ToUpper() == "DCO")
                                    {
                                        Prints.InvoicePrintBT rpt = new Prints.InvoicePrintBT();
                                        rpt.lblCopy.Text = CopyText;
                                        ProjectFunctions.PrintDocument(drBills["BillNo"].ToString(), Convert.ToDateTime(drBills["BillDate"]), drBills["BillSeries"].ToString(), rpt);
                                    }
                                }
                                if (GlobalVariables.ProgCode == "PROG141")
                                {
                                    if (drBills["CRSeries"].ToString().ToUpper() == "RG")
                                    {
                                        Prints.GSTCRINVOICE rpt = new Prints.GSTCRINVOICE();
                                        rpt.lblCopy.Text = CopyText;
                                        ProjectFunctions.CRPrintDocument(drBills["CRNo"].ToString(), Convert.ToDateTime(drBills["CRDate"]), drBills["CRSeries"].ToString(), rpt);
                                    }
                                }
                            }

                        }
                    }
                }
            }
            PrintOutGrid.Visible = false;
        }

        private void PrintOutGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                PrintOutGrid.Visible = false;
            }
        }
    }
}


