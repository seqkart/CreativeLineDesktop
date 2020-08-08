using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmMaster : DevExpress.XtraEditors.XtraForm
    {
        public frmMaster()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FillGrid()
        {
            PrintLogWin.PrintLog("FillGrid ******************** " + GlobalVariables.ProgCode);

            try
            {
                DataSet ds = ProjectFunctions.GetDataSet("Select ProgProcName,ProgDesc from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'");
                string ProcedureName = ds.Tables[0].Rows[0]["ProgProcName"].ToString();


                PrintLogWin.PrintLog("FillGrid => ProcedureName ******************** " + ProcedureName
                    );

                ProjectFunctions.BindMasterFormToGrid(ProcedureName, InvoiceGrid, InvoiceGridView);
                lbl.Text = ds.Tables[0].Rows[0]["ProgDesc"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox_Debug.ShowBox("frmMaster => FillGrid() => " + ex);
            }

            
        }
        private void InvoiceGrid_Load(object sender, EventArgs e)
        {

            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.GirdViewVisualize(InvoiceGridView);
            FillGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                if (GlobalVariables.ProgCode == "PROG170")
                {
                    Master.frmMeasurementMappingWithArt frm = new Master.frmMeasurementMappingWithArt() { s1 = btnAdd.Text, Text = "Measurement Mapping With Art Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG169")
                {
                    Master.frmMeasurementMapping frm = new Master.frmMeasurementMapping() { s1 = btnAdd.Text, Text = "Measurement Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG135")
                {
                    Transaction.Pos.Schemesetup frm = new Transaction.Pos.Schemesetup() { s1 = btnAdd.Text, Text = "Scheme Setup Addition" };

                    frm.StartPosition = FormStartPosition.CenterScreen;

                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG127")
                {
                    frmWorkerMaster frm = new frmWorkerMaster() { s1 = btnAdd.Text, Text = "Worker Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }

                if (GlobalVariables.ProgCode == "PROG126")
                {
                    frmProductMstAddEdit frm = new frmProductMstAddEdit() { s1 = btnAdd.Text, Text = "Item Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }

                if (GlobalVariables.ProgCode == "PROG125")
                {
                    frmArticleMst frm = new frmArticleMst() { s1 = btnAdd.Text, Text = "User Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }

                if (GlobalVariables.ProgCode == "PROG122")
                {
                    frmBrand frm = new frmBrand() { s1 = btnAdd.Text, Text = "Brand Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG124")
                {
                    frmSizeMMaster frm = new frmSizeMMaster() { s1 = btnAdd.Text, Text = "M Size Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }

                if (GlobalVariables.ProgCode == "PROG123")
                {
                    frmColors frm = new frmColors() { s1 = btnAdd.Text, Text = "Colors Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG121")
                {
                    frmCustomerMst frm = new frmCustomerMst() { s1 = btnAdd.Text, Text = "Customer Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG120")
                {
                    frmCompanyMaster frm = new frmCompanyMaster() { s1 = btnAdd.Text, Text = "Company Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG119")
                {
                    frmTransporterMaster frm = new frmTransporterMaster() { s1 = btnAdd.Text, Text = "Transporter Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG118")
                {
                    frmAddressBook frm = new frmAddressBook() { s1 = btnAdd.Text, Text = "Address Book Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG117")
                {
                    frmAddressBookGroup frm = new frmAddressBookGroup() { s1 = btnAdd.Text, Text = "Address Book Groups Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG115")
                {
                    Administration.frmRoleMst frm = new Administration.frmRoleMst() { s1 = btnAdd.Text, Text = "Role Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG106")
                {
                    frmBomMstAddEdit frm = new frmBomMstAddEdit() { s1 = btnAdd.Text, Text = "Bill Of Material Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (ComparisonUtils.IsEqualTo_String(GlobalVariables.ProgCode, WIN_APP_TABS._frmNewFormAAddEdit))                    
                {
                    frmNewFormAAddEdit frm = new frmNewFormAAddEdit() { s1 = btnAdd.Text, Text = "Program Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    
                }
                if (ComparisonUtils.IsEqualTo_String(GlobalVariables.ProgCode, WIN_APP_TABS._frmUserDetails))               
                {
                    frmUserDetails frm = new frmUserDetails() { s1 = btnAdd.Text, Text = "User Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG6")
                //{
                //    frmVehicleAddEdit frm = new frmVehicleAddEdit() { s1 = btnAdd.Text, Text = "Vehicle Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG8")
                {
                    frmAccountMstAddEdit frm = new frmAccountMstAddEdit() { s1 = btnAdd.Text, Text = "Account Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG9")
                {
                    frmDepartmentAddUpdate frm = new frmDepartmentAddUpdate() { s1 = btnAdd.Text, Text = "Department Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG10")
                {
                    frmDesignationAddEdit frm = new frmDesignationAddEdit() { s1 = btnAdd.Text, Text = "Desgination Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG11")
                //{
                //    frmExpenseHeadAddEdit frm = new frmExpenseHeadAddEdit() { s1 = btnAdd.Text, Text = "Expense Head Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG12")
                {
                    frmLedgerAddEdit frm = new frmLedgerAddEdit() { s1 = btnAdd.Text, Text = "Ledger Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG13")
                //{
                //    frmRouteMstAddEdit frm = new frmRouteMstAddEdit() { s1 = btnAdd.Text, Text = "Route Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG14")
                {
                    frmUOMAddEdit frm = new frmUOMAddEdit() { s1 = btnAdd.Text, Text = "Unit Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG15")
                //{

                //    frmCostMstAddEdit frm = new frmCostMstAddEdit() { s1 = btnAdd.Text, Text = "Cost Head Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG16")
                {
                    frmGroupMstAddEdit frm = new frmGroupMstAddEdit() { s1 = btnAdd.Text, Text = "Group Head Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG17")
                {
                    frmTdsAddEdit frm = new frmTdsAddEdit() { s1 = btnAdd.Text, Text = "TDS Group Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG18")
                {
                    frmTaxMasterAddEdit frm = new frmTaxMasterAddEdit() { s1 = btnAdd.Text, Text = "Tax Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG19")
                //{
                //    frmDealerMstAddEdit frm = new frmDealerMstAddEdit() { s1 = btnAdd.Text, Text = "Dealer Master Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG20")
                {
                    frmProductMstAddEdit frm = new frmProductMstAddEdit() { s1 = btnAdd.Text, Text = "Product Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG21")
                {
                    frmEmloyeeMstAddEdit frm = new frmEmloyeeMstAddEdit() { s1 = btnAdd.Text, Text = "Employee Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG29")
                {
                    Master.frmCategoryMst frm = new Master.frmCategoryMst() { s1 = btnAdd.Text, Text = "Category Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG30")
                {
                    frmEmloyeeMstAddEdit frm = new frmEmloyeeMstAddEdit() { s1 = btnAdd.Text, Text = "Employee Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG34")
                {
                    Master.frmBalanceSheetHeads frm = new Master.frmBalanceSheetHeads() { s1 = btnAdd.Text, Text = "Balance Sheet Head Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG66")
                //{
                //    Master.frmSupplierMaster frm = new Master.frmSupplierMaster() { s1 = btnAdd.Text, Text = "Supplier Head Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
              //  }
                //if (GlobalVariables.ProgCode == "PROG67")
                //{
                //    Master.frmRetailerMaster frm = new Master.frmRetailerMaster() { s1 = btnAdd.Text, Text = "Retailer Head Addition" };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG160")
                {
                    frmEmloyeeMstAddEdit frm = new frmEmloyeeMstAddEdit() { s1 = btnAdd.Text, Text = "Employee Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG155")
                {
                    Master.frmCategoryMst frm = new Master.frmCategoryMst() { s1 = btnAdd.Text, Text = "Category Master Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG156")
                {
                    frmDepartmentAddUpdate frm = new frmDepartmentAddUpdate() { s1 = btnAdd.Text, Text = "Department Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG157")
                {
                    frmDesignationAddEdit frm = new frmDesignationAddEdit() { s1 = btnAdd.Text, Text = "Desgination Addition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
            }
            FillGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled)
            {
                if (GlobalVariables.ProgCode == "PROG170")
                {
                    Master.frmMeasurementMappingWithArt frm = new Master.frmMeasurementMappingWithArt() { s1 = btnEdit.Text, Text = "Measurement Mapping With Art Edition" };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG169")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Master.frmMeasurementMapping frm = new Master.frmMeasurementMapping() { s1 = btnEdit.Text, Text = "Measurement Edition", MCode = CurrentRow["MCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG135")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    Transaction.Pos.Schemesetup frm = new Transaction.Pos.Schemesetup() { s1 = btnEdit.Text, Text = "Scheme Setup Edition", SchemeID = CurrentRow["SchmID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG127")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmWorkerMaster frm = new frmWorkerMaster() { s1 = btnEdit.Text, Text = "Worker Addition", WRKSYSID = CurrentRow["WRKSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG126")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmProductMstAddEdit frm = new frmProductMstAddEdit() { s1 = btnEdit.Text, Text = "Item Master Edition", PrdCode = CurrentRow["PrdCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG125")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmArticleMst frm = new frmArticleMst() { s1 = btnEdit.Text, Text = "Article Edition", PrdCode = CurrentRow["ARTSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG122")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmBrand frm = new frmBrand() { s1 = btnEdit.Text, Text = "Brand Edition", BrandCode = CurrentRow["BRSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG124")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmSizeMMaster frm = new frmSizeMMaster() { s1 = btnEdit.Text, Text = "M Size Edition", SZSYSID = CurrentRow["SZSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG123")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmColors frm = new frmColors() { s1 = btnEdit.Text, Text = "Colors Edition", COLSYSID = CurrentRow["COLSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG121")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmCustomerMst frm = new frmCustomerMst() { s1 = btnEdit.Text, Text = "Customer Edition", CAFSYSID = CurrentRow["CAFSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG120")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmCompanyMaster frm = new frmCompanyMaster() { s1 = btnEdit.Text, Text = "Company Editing", COMSYSID = CurrentRow["COMSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG119")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmTransporterMaster frm = new frmTransporterMaster() { s1 = btnEdit.Text, Text = "Transporter Edition", TRPRSYSID = CurrentRow["TRPRSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                    FillGrid();
                }
                if (GlobalVariables.ProgCode == "PROG118")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmAddressBook frm = new frmAddressBook() { s1 = btnEdit.Text, Text = "Address Book Edition", AddressBookCode = CurrentRow["ADBSYSID"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG117")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmAddressBookGroup frm = new frmAddressBookGroup() { s1 = btnEdit.Text, Text = "Address Book Groups Edition", AddressBookGroupCode = CurrentRow["AddressBookGroupCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (ComparisonUtils.IsEqualTo_String(GlobalVariables.ProgCode, WIN_APP_TABS._frmRoleMst))                
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);

                    Administration.frmRoleMst frm = new Administration.frmRoleMst() { s1 = btnEdit.Text, Text = "Role Addition", RoleCode = CurrentRow["RoleCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG106")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmBomMstAddEdit frm = new frmBomMstAddEdit() { s1 = btnEdit.Text, Text = "Bill Of Material Editing", bomno = CurrentRow["bomNo"].ToString(), bomPrdId = CurrentRow["bomPrdId"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG1")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmNewFormAAddEdit frm = new frmNewFormAAddEdit() { s1 = btnEdit.Text, Text = "Program Editing", ProgCode = CurrentRow["ProgCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //*******************//
                //This Code Moved To XtraForm_UserMaster
                if (GlobalVariables.ProgCode == WIN_APP_TABS._frmUserDetails)
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmUserDetails frm = new frmUserDetails() { s1 = btnEdit.Text, Text = "User Editing", UserName = CurrentRow["UserName"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    /////
                    ///frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG6")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    frmVehicleAddEdit frm = new frmVehicleAddEdit() { s1 = btnEdit.Text, Text = "Vehicle Editing", VehicleCode = CurrentRow["VehicleCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG8")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmAccountMstAddEdit frm = new frmAccountMstAddEdit() { s1 = btnEdit.Text, Text = "Account Editing", AccCode = CurrentRow["AccCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG9")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmDepartmentAddUpdate frm = new frmDepartmentAddUpdate() { s1 = btnEdit.Text, Text = "Department Editing", DeptCode = CurrentRow["DeptCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG10")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmDesignationAddEdit frm = new frmDesignationAddEdit() { s1 = btnEdit.Text, Text = "Desgination Editing", DesgCode = CurrentRow["DesgCode"].ToString() };
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }

                //if (GlobalVariables.ProgCode == "PROG11")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    frmExpenseHeadAddEdit frm = new frmExpenseHeadAddEdit() { s1 = btnEdit.Text, Text = "Expense Head  Editing", ExpHeadCode = CurrentRow["ExpHeadCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG12")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmLedgerAddEdit frm = new frmLedgerAddEdit() { s1 = btnEdit.Text, Text = "Ledger  Editing", LgrCode = CurrentRow["LgrCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG13")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    frmRouteMstAddEdit frm = new frmRouteMstAddEdit() { s1 = btnEdit.Text, Text = "Route  Editing", RouteCode = CurrentRow["RouteCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG14")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmUOMAddEdit frm = new frmUOMAddEdit() { s1 = btnEdit.Text, Text = "Unit  Editing", UomCode = CurrentRow["UomCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG15")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    frmCostMstAddEdit frm = new frmCostMstAddEdit() { s1 = btnEdit.Text, Text = "Cost Head  Editing", CostCode = CurrentRow["CostCode"].ToString(), CostSubCode = CurrentRow["CostSubCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG16")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmGroupMstAddEdit frm = new frmGroupMstAddEdit() { s1 = btnEdit.Text, Text = "Group Head Editing", GrpCode = CurrentRow["GrpCode"].ToString(), SubGrpCode = CurrentRow["GrpSubCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG17")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmTdsAddEdit frm = new frmTdsAddEdit() { s1 = btnEdit.Text, Text = "TDS Group Editing", TdsCode = CurrentRow["TdsCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG18")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmTaxMasterAddEdit frm = new frmTaxMasterAddEdit() { s1 = btnEdit.Text, Text = "Tax Master Editing", TaxCode = CurrentRow["TaxCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVar
                iables.ProgCode == "PROG19")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    frmDealerMstAddEdit frm = new frmDealerMstAddEdit() { s1 = btnEdit.Text, Text = "Dealer Master Editing", DealerCode = CurrentRow["DealerCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG20")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmProductMstAddEdit frm = new frmProductMstAddEdit() { s1 = btnEdit.Text, Text = "Dealer Master Editing", PrdCode = CurrentRow["PrdCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG22")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmEmloyeeMstAddEdit frm = new frmEmloyeeMstAddEdit() { s1 = btnEdit.Text, Text = "Employee Master Editing", EmpCode = CurrentRow["EmpCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG29")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Master.frmCategoryMst frm = new Master.frmCategoryMst() { s1 = btnEdit.Text, Text = "Category Master Editing", CatgCode = CurrentRow["CatgCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG30")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmEmloyeeMstAddEdit frm = new frmEmloyeeMstAddEdit() { s1 = btnEdit.Text, Text = "Employee Master Editing", EmpCode = CurrentRow["EmpCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG34")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Master.frmBalanceSheetHeads frm = new Master.frmBalanceSheetHeads() { s1 = btnEdit.Text, Text = "Balance Sheet Head  Editing", BSCode = CurrentRow["BSCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                //if (GlobalVariables.ProgCode == "PROG66")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Master.frmSupplierMaster frm = new Master.frmSupplierMaster() { s1 = btnEdit.Text, Text = "Supplier Head  Editing", SCode = CurrentRow["SCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                //if (GlobalVariables.ProgCode == "PROG67")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Master.frmRetailerMaster frm = new Master.frmRetailerMaster() { s1 = btnEdit.Text, Text = "Retailer Head  Editing", RCode = CurrentRow["RCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                //if (GlobalVariables.ProgCode == "PROG69")
                //{
                //    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                //    Master.frmRateFeeding frm = new Master.frmRateFeeding() { Text = "DealerRate Editing", DealerCode = CurrentRow["DealerCode"].ToString() };
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    //var P = ProjectFunctions.GetPositionInForm(this);
                //    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                //    frm.ShowDialog(Parent);
                //}
                if (GlobalVariables.ProgCode == "PROG156")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmDepartmentAddUpdate frm = new frmDepartmentAddUpdate() { s1 = btnEdit.Text, Text = "Department Editing", DeptCode = CurrentRow["DeptCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG157")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmDesignationAddEdit frm = new frmDesignationAddEdit() { s1 = btnEdit.Text, Text = "Desgination Editing", DesgCode = CurrentRow["DesgCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG160")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    frmEmloyeeMstAddEdit frm = new frmEmloyeeMstAddEdit() { s1 = btnEdit.Text, Text = "Employee Master Editing", EmpCode = CurrentRow["EmpCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    
                    frm.ShowDialog(Parent);
                }
                if (GlobalVariables.ProgCode == "PROG155")
                {
                    DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                    Master.frmCategoryMst frm = new Master.frmCategoryMst() { s1 = btnEdit.Text, Text = "Category Master Editing", CatgCode = CurrentRow["CatgCode"].ToString() };
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //var P = ProjectFunctions.GetPositionInForm(this);
                    //frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                    frm.ShowDialog(Parent);
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

        private void InvoiceGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                var formatRulesMenu = new DXPopupMenu();
                var view = sender as GridView;

                DXMenuItem Copy;
#pragma warning disable CS0168 // The variable 'Print' is declared but never used
                DXMenuItem Print;
#pragma warning restore CS0168 // The variable 'Print' is declared but never used
                DXMenuItem SAR;
#pragma warning disable CS0168 // The variable 'ExportSource' is declared but never used
                DXMenuItem ExportSource;
#pragma warning restore CS0168 // The variable 'ExportSource' is declared but never used
                DXMenuItem Collapse;
                DXMenuItem Expand;
                DXMenuItem FixLeft;
                DXMenuItem FixRight;
                DXMenuItem UnFix;
                DXMenuItem PartyAccount;

                DataRow CurrentRow = InvoiceGridView.GetDataRow(InvoiceGridView.FocusedRowHandle);
                PartyAccount = new DXMenuItem("View Party Account", (o1, e1) =>
                {
                    DataSet ds = ProjectFunctions.GetDataSet("[sp_ZoomPartyAct] '2019-01-01','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + CurrentRow["AccCode"].ToString() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FormReports.frmPartyAccounts frm = new FormReports.frmPartyAccounts() { Text = "Zoom Party Account - [" + CurrentRow["AccName"].ToString() + " - " + CurrentRow["AccCode"].ToString() + " ]", dsGetData = ds };
                        var P = ProjectFunctions.GetPositionInForm(this);
                        frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                        frm.ShowDialog(Parent);
                    }
                });
                Copy = new DXMenuItem("Copy", (o1, e1) =>
                {
                    view.OptionsSelection.MultiSelect = true;
                    view.CopyToClipboard();
                });
                SAR = new DXMenuItem("Select All Records", (o1, e1) =>
                {
                    view.OptionsSelection.MultiSelect = true;
                    view.SelectAll();
                });
                Expand = new DXMenuItem("Expand All", (o1, e1) =>
                {
                    InvoiceGridView.ExpandAllGroups();
                });
                Collapse = new DXMenuItem("Collapse All", (o1, e1) =>
                {
                    InvoiceGridView.CollapseAllGroups();
                });
                FixLeft = new DXMenuItem("Fix Column Left", (o1, e1) =>
                {
                    InvoiceGridView.OptionsView.ColumnAutoWidth = false;
                    var hitInfo = InvoiceGridView.CalcHitInfo(InvoiceGrid.PointToClient(Control.MousePosition));
                    if (hitInfo.InRowCell)
                    {
                        int rowHandle = hitInfo.RowHandle;
                        DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                        column = hitInfo.Column;
                        column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    }
                });
                FixRight = new DXMenuItem("Fix Column Right", (o1, e1) =>
                {
                    InvoiceGridView.OptionsView.ColumnAutoWidth = false;
                    var hitInfo = InvoiceGridView.CalcHitInfo(InvoiceGrid.PointToClient(Control.MousePosition));
                    if (hitInfo.InRowCell)
                    {
                        int rowHandle = hitInfo.RowHandle;
                        DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                        column = hitInfo.Column;
                        column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
                    }
                });
                UnFix = new DXMenuItem("Unfix Column", (o1, e1) =>
                {
                    InvoiceGridView.OptionsView.ColumnAutoWidth = false;
                    var hitInfo = InvoiceGridView.CalcHitInfo(InvoiceGrid.PointToClient(Control.MousePosition));
                    if (hitInfo.InRowCell)
                    {
                        int rowHandle = hitInfo.RowHandle;
                        DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                        column = hitInfo.Column;
                        column.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                    }
                });
                e.Menu.Items.Add(Copy);
                e.Menu.Items.Add(SAR);
                e.Menu.Items.Add(Collapse);
                e.Menu.Items.Add(Expand);
                e.Menu.Items.Add(FixLeft);
                e.Menu.Items.Add(FixRight);
                e.Menu.Items.Add(UnFix);
                if (GlobalVariables.ProgCode == "PROG8")
                {
                    e.Menu.Items.Add(PartyAccount);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
            }

        }

        private void InvoiceGrid_Click(object sender, EventArgs e)
        {


        }

        private void FrmMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmSaleReportF2 frm = new frmSaleReportF2() { Text = "Sale Report", WorkingTag = "Today" };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(Parent);
            }
            if (e.KeyCode == Keys.F4)
            {
                frmSaleReportF2 frm = new frmSaleReportF2() { Text = "Sale Report", WorkingTag = "Month" };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(Parent);
            }
            if (e.KeyCode == Keys.F6)
            {
                frmSaleReportF2 frm = new frmSaleReportF2() { Text = "Sale Report", WorkingTag = "Year" };
                var P = ProjectFunctions.GetPositionInForm(this);
                frm.Location = new Point(P.X + (ClientSize.Width / 2 - frm.Size.Width / 2), P.Y + (ClientSize.Height / 2 - frm.Size.Height / 2));
                frm.ShowDialog(Parent);
            }
        }

        private void Menu_ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}