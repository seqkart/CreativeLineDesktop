using Dapper;
using DevExpress.DataProcessing;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using SeqKartLibrary;
using SeqKartLibrary.HelperClass;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmEmloyeeMstAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String EmpCode { get; set; }
        public frmEmloyeeMstAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.TextBoxVisualize(panelControl2);
            ProjectFunctions.TextBoxVisualize(panelControl3);
            ProjectFunctions.TextBoxVisualize(panelControl4);
            ProjectFunctions.DatePickerVisualize(this);
            //ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            lblFilename.Text = null;

            txtEmpCode.Enabled = false;
        }
        
        private bool ValidateData()
        {
            if (txtEmpCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Emp Code", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEmpCode.Focus();
                return false;
            }
            if (txtEmpName.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Emp Name", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEmpName.Focus();
                return false;
            }
            if (txtDeptCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Department Code", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDeptCode.Focus();
                return false;
            }
            if (txtDeptDesc.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Department Description", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDeptCode.Focus();
                return false;
            }
            if (txtDesgCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Designation Code", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDesgCode.Focus();
                return false;
            }
            if (txtDesgDesc.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Designation Dscription", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDesgCode.Focus();
                return false;
            }

            if (txtUnitCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Unit Code", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtUnitCode.Focus();
                return false;
            }
            if (txtUnitDesc.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Unit Name", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtUnitDesc.Focus();
                return false;
            }


            //var inTime_First = Convert.ToDateTime(timeEdit_Time_In_First.EditValue);
            //var outTime_First = Convert.ToDateTime(timeEdit_Time_Out_First.EditValue);
            ////var totalHours = Convert.ToDateTime(inTime).TimeOfDay.Subtract(outTime);
            //var totalHrs_First = (outTime_First - inTime_First).TotalHours;
            //totalWorkingHours_Text.Text = totalHrs_First.ToString();



            //Action showMethod = delegate () {
            //    MessageBox.Show("Please Enter TimeIn");
            //};
            //timeEdit_Time_In_First.EditValue.IfNull(showMethod);

            //if (timeEdit_Time_In_First.EditValue.Equals(""))
            //{
            //    XtraMessageBox.Show("Please ENter TimeIn", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    timeEdit_Time_In_First.Focus();
            //    return false;
            //}


            if (txtHealthInsurance.Text.Trim().Length == 0)
            {
                txtHealthInsurance.Text = "0";
            }
            if (txtTDS.Text.Trim().Length == 0)
            {
                txtTDS.Text = "0";
            }
            if (txtMiscDed.Text.Trim().Length == 0)
            {
                txtMiscDed.Text = "0";
            }

            return true;
        }

        //private string GetNewEmpCode()
        //{
        //    string sql = SQL_QUERIES._frm_Employee_Mst_Add_Edit._GetNewEmpCode();

        //    String s2 = String.Empty;
        //    DataSet ds = ProjectFunctions.GetDataSet(sql);//"select isnull(max(Cast(EmpCode as int)),00000) from EmpMst"
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        s2 = ds.Tables[0].Rows[0][0].ToString();
        //        //s2 = (Convert.ToInt32(s2) + 1).ToString();
        //    }
        //    return s2;
        //}
        private bool form_loaded = false;
        private void frmEmloyeeMstAddEdit_Load(object sender, EventArgs e)
        {            
            employeeFormData_Load();
        }
        //string fileName1 = "";
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //Read image file //JPEG|*.jpg
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName1 = ofd.FileName;
                    lblFilename.Text = Path.GetFileName(fileName1);
                    pictureBox1.Image = Image.FromFile(fileName1);
                }
            }
        }

        //Convert image to binary
        byte[] ConvertImageToBinary(Image img)
        {
            try
            {
                if (img != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }
            }
            catch(Exception ex)
            {
                PrintLogWin.PrintLog(ex);

            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Properties.Resources.profile_icon.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                PrintLogWin.PrintLog(ex);

            }

            return null;
        }
        //Convert binary to image
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void Page_Load1()
        {
            DataSet ds = GetData();
            SqlConnection con = new SqlConnection(@"data source=.\sqlserver; user id=sa; password=123; database=Sample;");
            SqlBulkCopy bulk = new SqlBulkCopy(con);

            
            bulk.DestinationTableName = "tblStudents";
            foreach (DataColumn col in ds.Tables[0].Columns)
                bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            con.Open();
            bulk.WriteToServer(ds.Tables[0]);
            con.Close();
        }

        DataSet GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID", typeof(int));
            dt.Columns.Add("StudentName", typeof(string));
            dt.Columns.Add("RollNumber", typeof(int));
            dt.Columns.Add("TotalMarks", typeof(int));
            dt.Rows.Add(1, "Jame's", 101, 900);
            dt.Rows.Add(2, "Steave Smith", 105, 820);
            dt.Rows.Add(3, "Mark Waugh", 109, 850);
            dt.Rows.Add(4, "Steave Waugh", 110, 950);
            dt.Rows.Add(5, "Smith", 111, 910);
            dt.Rows.Add(6, "Williams", 115, 864);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        private void employeeFormData_Load()
        {

            SetMyControls();
            if (s1 == "&Add")
            {
                txtEmpName.Select();
                txtEmpCode.Text = ProjectFunctionsUtils.GetNewEmpCode();//.PadLeft(5, '0');
                form_loaded = true;
            }
            if (s1 == "Edit")
            {
                RepList<EmployeeMasterModel> lista = new RepList<EmployeeMasterModel>();
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpCode", EmpCode);

                EmployeeMasterModel empData = lista.returnClass_SP(SQL_QUERIES._frmEmployeeMstAddEdit.sp_LoadEmpMstFEditing(), param);

               
                //PrintLogWin.PrintLog("**************** =========> Line 120 => listData => " + listData.Count + "");
                if (empData != null)
                {
                    txtEmpCode.Text = empData.EmpCode;// ds.Tables[0].Rows[0]["EmpCode"].ToString();
                    txtEmpName.Text = empData.EmpName;
                    txtRelationTag.Text = empData.EmpFHRelationTag;//ds.Tables[0].Rows[0]["EmpFHRelationTag"].ToString();
                    txtFHName.Text = empData.EmpFHName;//ds.Tables[0].Rows[0]["EmpFHName"].ToString();
                    txtDeptCode.Text = empData.EmpDeptCode;//ds.Tables[0].Rows[0]["EmpDeptCode"].ToString();
                    txtDeptDesc.Text = empData.DeptDesc;//ds.Tables[0].Rows[0]["DeptDesc"].ToString();
                    txtDesgCode.Text = empData.EmpDesgCode;//ds.Tables[0].Rows[0]["EmpDesgCode"].ToString();
                    txtDesgDesc.Text = empData.DesgDesc;//ds.Tables[0].Rows[0]["DesgDesc"].ToString();
                    
                    txtUnitCode.Text = empData.UnitCode;//ds.Tables[0].Rows[0]["EmpDesgCode"].ToString();
                    txtUnitDesc.Text = empData.UnitName;//ds.Tables[0].Rows[0]["DesgDesc"].ToString();

                    txtEmpSex.Text = empData.EmpSex;//ds.Tables[0].Rows[0]["EmpSex"].ToString();
                    if (empData.EmpDOJ.ToString() == string.Empty)
                    {

                    }
                    else
                    {
                        txtDOJ.EditValue = Convert.ToDateTime(empData.EmpDOJ);
                    }
                    if (empData.EmpDOL.ToString() == string.Empty)
                    {

                    }
                    else
                    {
                        txtDOL.EditValue = Convert.ToDateTime(empData.EmpDOL);
                    }

                    txtEPFTag.Text = empData.EmpPFDTag;//ds.Tables[0].Rows[0]["EmpPFDTag"].ToString();
                    txtESIDTag.Text = empData.EmpESIDTag;//ds.Tables[0].Rows[0]["EmpESIDTag"].ToString();
                    txtEPFNo.Text = empData.EmpPFno;//ds.Tables[0].Rows[0]["EmpPFno"].ToString();
                    txtESICNo.Text = empData.EmpESIno;//ds.Tables[0].Rows[0]["EmpESIno"].ToString();

                    txtTDS.Text = empData.EmpTDS.ToString();//ds.Tables[0].Rows[0]["EmpTDS"].ToString();
                    txtEmpLeft.Text = empData.EmpLeft;//ds.Tables[0].Rows[0]["EmpLeft"].ToString();
                    txtRemarks.Text = empData.EmpRemarks;//ds.Tables[0].Rows[0]["EmpRemarks"].ToString();
                    txtMotherName.Text = empData.EmpMotherNm;//ds.Tables[0].Rows[0]["EmpMotherNm"].ToString();

                    txtState.Text = empData.EmpPerState;//ds.Tables[0].Rows[0]["EmpPerState"].ToString();
                    txtState.Text = empData.EmpPerCountry;//ds.Tables[0].Rows[0]["EmpPerCountry"].ToString();

                    txtNationality.Text = empData.EmpNationality;//ds.Tables[0].Rows[0]["EmpNationality"].ToString();
                    txtEmail.Text = empData.EmpEmail;//ds.Tables[0].Rows[0]["EmpEmail"].ToString();
                    txtCategoryCode.Text = empData.EmpCategory;//ds.Tables[0].Rows[0]["EmpCategory"].ToString();

                    txtCategoryDesc.Text = empData.CatgDesc;//ds.Tables[0].Rows[0]["CatgDesc"].ToString();

                    txtDOB.EditValue = Convert.ToDateTime(empData.EmpDoB);
                    txtPanNo.Text = empData.EmpPanNo;//ds.Tables[0].Rows[0]["EmpPanNo"].ToString();
                    txtPassPortNo.Text = empData.EmpPassportNo;//ds.Tables[0].Rows[0]["EmpPassportNo"].ToString();


                    txtEmployeeReligion.Text = empData.EmpReligion;//ds.Tables[0].Rows[0]["EmpReligion"].ToString();
                    txtMaritalStatus.Text = empData.EmpMaritalStatus;//ds.Tables[0].Rows[0]["EmpMaritalStatus"].ToString();
                    txtPaymentMode.Text = empData.EmpPymtMode;//ds.Tables[0].Rows[0]["EmpPymtMode"].ToString();
                    txtIfscCode.Text = empData.EmpBankIFSCode;//ds.Tables[0].Rows[0]["EmpBankIFSCode"].ToString();
                    txtBankAccountNo.Text = empData.EmpBankAcNo;//ds.Tables[0].Rows[0]["EmpBankAcNo"].ToString();
                    txtBankName.Text = empData.EmpBankName;//ds.Tables[0].Rows[0]["EmpBankName"].ToString();
                    txtNomineeName.Text = empData.EmpNominee;//ds.Tables[0].Rows[0]["EmpNominee"].ToString();
                    txtNomineeRelation.Text = empData.EmpNomineeRelation;//ds.Tables[0].Rows[0]["EmpNomineeRelation"].ToString();
                    if (empData.EmpNomineeDOB.ToString() == string.Empty)
                    {

                    }
                    else
                    {
                        txtNomineeDOB.EditValue = Convert.ToDateTime(empData.EmpNomineeDOB);
                    }



                    txtAdharCardNo.Text = empData.EmpAdharCardNo;//ds.Tables[0].Rows[0]["EmpAdharCardNo"].ToString();

                    txtHealthInsurance.Text = empData.EmpGHISDed.ToString();//ds.Tables[0].Rows[0]["EmpGHISDed"].ToString();

                    txtMiscDed.Text = empData.EmpMscD1.ToString();//ds.Tables[0].Rows[0]["EmpMscD1"].ToString();

                    txtAddress1.Text = empData.EmpAddress1;//ds.Tables[0].Rows[0]["EmpAddress1"].ToString();
                    txtAddress2.Text = empData.EmpAddress2;//ds.Tables[0].Rows[0]["EmpAddress2"].ToString();
                    txtAddress3.Text = empData.EmpAddress3;//ds.Tables[0].Rows[0]["EmpAddress3"].ToString();

                    txtState.Text = empData.EmpState;//ds.Tables[0].Rows[0]["EmpState"].ToString();
                    txtCountry.Text = empData.EmpCountry;//ds.Tables[0].Rows[0]["EmpCountry"].ToString();

                    txtEFPFTag.Text = empData.EmpFpfDTag;//ds.Tables[0].Rows[0]["EmpFpfDTag"].ToString();

                    //NULL Exception
                    //txtUANNo.Text = ds.Tables[0].Rows[0]["EmpUANNo"].ToString();
                    //txtUnitCode.Text = ds.Tables[0].Rows[0]["UnitCode"].ToString();
                    //txtUnitName.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    //txtAccCode.Text = ds.Tables[0].Rows[0]["EmpPartyCode"].ToString();
                    //txtBankBranchCode.Text = ds.Tables[0].Rows[0]["EmpBankBranchCode"].ToString();
                    txtCategoryCode.Focus();

                    timeEdit_Time_In_First.EditValue = empData.TimeInFirst.ToString();
                    timeEdit_Time_Out_First.EditValue = empData.TimeOutFirst.ToString();
                    timeEdit_Time_In_Last.EditValue = empData.TimeInLast.ToString();
                    timeEdit_Time_Out_Last.EditValue = empData.TimeOutLast.ToString();
                    totalWorkingHours_Text.EditValue = empData.WorkingHours;
                    pictureBox1.Image = ConvertBinaryToImage(empData.EmpImage);
                }

                form_loaded = true;

                txtEmpName.Enabled = false;
                PrintLogWin.PrintLog("frmEmloyeeMstAddEdit_Load =========> Line 131 => sp_LoadEmpMstFEditing '" + EmpCode + "'");

                var dsResult = ProjectFunctionsUtils.GetDataSet_T("sp_LoadEmpMstFEditing '" + EmpCode + "'");
                if (dsResult.Item1)
                {
                    DataSet ds = dsResult.Item2;

                    if (ds.Tables[0].Rows.Count > 10000)
                    {

                        txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                        txtRelationTag.Text = ds.Tables[0].Rows[0]["EmpFHRelationTag"].ToString();
                        txtFHName.Text = ds.Tables[0].Rows[0]["EmpFHName"].ToString();
                        txtDeptCode.Text = ds.Tables[0].Rows[0]["EmpDeptCode"].ToString();
                        txtDeptDesc.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();
                        txtDesgCode.Text = ds.Tables[0].Rows[0]["EmpDesgCode"].ToString();
                        txtDesgDesc.Text = ds.Tables[0].Rows[0]["DesgDesc"].ToString();
                        txtEmpSex.Text = ds.Tables[0].Rows[0]["EmpSex"].ToString();
                        if (ds.Tables[0].Rows[0]["EmpDOJ"].ToString() == string.Empty)
                        {

                        }
                        else
                        {
                            txtDOJ.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["EmpDOJ"]);
                        }
                        if (ds.Tables[0].Rows[0]["EmpDOL"].ToString() == string.Empty)
                        {

                        }
                        else
                        {
                            txtDOL.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["EmpDOL"]);
                        }

                        txtEPFTag.Text = ds.Tables[0].Rows[0]["EmpPFDTag"].ToString();
                        txtESIDTag.Text = ds.Tables[0].Rows[0]["EmpESIDTag"].ToString();
                        txtEPFNo.Text = ds.Tables[0].Rows[0]["EmpPFno"].ToString();
                        txtESICNo.Text = ds.Tables[0].Rows[0]["EmpESIno"].ToString();
                        
                        txtTDS.Text = ds.Tables[0].Rows[0]["EmpTDS"].ToString();
                        txtEmpLeft.Text = ds.Tables[0].Rows[0]["EmpLeft"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["EmpRemarks"].ToString();
                        txtMotherName.Text = ds.Tables[0].Rows[0]["EmpMotherNm"].ToString();

                        txtState.Text = ds.Tables[0].Rows[0]["EmpPerState"].ToString();
                        txtState.Text = ds.Tables[0].Rows[0]["EmpPerCountry"].ToString();

                        txtNationality.Text = ds.Tables[0].Rows[0]["EmpNationality"].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0]["EmpEmail"].ToString();
                        txtCategoryCode.Text = ds.Tables[0].Rows[0]["EmpCategory"].ToString();

                        txtCategoryDesc.Text = ds.Tables[0].Rows[0]["CatgDesc"].ToString();

                        txtDOB.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["EmpDoB"]);
                        txtPanNo.Text = ds.Tables[0].Rows[0]["EmpPanNo"].ToString();
                        txtPassPortNo.Text = ds.Tables[0].Rows[0]["EmpPassportNo"].ToString();

                       
                        txtEmployeeReligion.Text = ds.Tables[0].Rows[0]["EmpReligion"].ToString();
                        txtMaritalStatus.Text = ds.Tables[0].Rows[0]["EmpMaritalStatus"].ToString();
                        txtPaymentMode.Text = ds.Tables[0].Rows[0]["EmpPymtMode"].ToString();
                        txtIfscCode.Text = ds.Tables[0].Rows[0]["EmpBankIFSCode"].ToString();
                        txtBankAccountNo.Text = ds.Tables[0].Rows[0]["EmpBankAcNo"].ToString();
                        txtBankName.Text = ds.Tables[0].Rows[0]["EmpBankName"].ToString();
                        txtNomineeName.Text = ds.Tables[0].Rows[0]["EmpNominee"].ToString();
                        txtNomineeRelation.Text = ds.Tables[0].Rows[0]["EmpNomineeRelation"].ToString();
                        if (ds.Tables[0].Rows[0]["EmpNomineeDOB"].ToString() == string.Empty)
                        {

                        }
                        else
                        {
                            txtNomineeDOB.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["EmpNomineeDOB"]);
                        }



                        txtAdharCardNo.Text = ds.Tables[0].Rows[0]["EmpAdharCardNo"].ToString();

                        txtHealthInsurance.Text = ds.Tables[0].Rows[0]["EmpGHISDed"].ToString();

                        txtMiscDed.Text = ds.Tables[0].Rows[0]["EmpMscD1"].ToString();

                        txtAddress1.Text = ds.Tables[0].Rows[0]["EmpAddress1"].ToString();
                        txtAddress2.Text = ds.Tables[0].Rows[0]["EmpAddress2"].ToString();
                        txtAddress3.Text = ds.Tables[0].Rows[0]["EmpAddress3"].ToString();
                       
                        txtState.Text = ds.Tables[0].Rows[0]["EmpState"].ToString();
                        txtCountry.Text = ds.Tables[0].Rows[0]["EmpCountry"].ToString();

                        txtEFPFTag.Text = ds.Tables[0].Rows[0]["EmpFpfDTag"].ToString();
                        
                        //NULL Exception
                        //txtUANNo.Text = ds.Tables[0].Rows[0]["EmpUANNo"].ToString();
                        //txtUnitCode.Text = ds.Tables[0].Rows[0]["UnitCode"].ToString();
                        //txtUnitName.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                        //txtAccCode.Text = ds.Tables[0].Rows[0]["EmpPartyCode"].ToString();
                        //txtBankBranchCode.Text = ds.Tables[0].Rows[0]["EmpBankBranchCode"].ToString();
                        txtCategoryCode.Focus();
                    }
                }

                
            }
        }

        private void frmEmloyeeMstAddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid_DoubleClick(null, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                HelpGrid.Visible = false;
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);

            if (HelpGrid.Text == "txtDesgCode")
            {
                txtDesgCode.Text = row["DesgCode"].ToString();
                txtDesgDesc.Text = row["DesgDesc"].ToString();
                HelpGrid.Visible = false;
                txtRemarks.Focus();
            }
            if (HelpGrid.Text == "txtDeptCode")
            {
                txtDeptCode.Text = row["DeptCode"].ToString();
                txtDeptDesc.Text = row["DeptDesc"].ToString();
                HelpGrid.Visible = false;
                txtDesgCode.Focus();
            }
            if (HelpGrid.Text == "txtCategoryCode")
            {
                txtCategoryCode.Text = row["CatgCode"].ToString();
                txtCategoryDesc.Text = row["CatgDesc"].ToString();
                HelpGrid.Visible = false;
                txtDOJ.Focus();
            }
            if (HelpGrid.Text == "txtUnitCode")
            {
                txtUnitCode.Text = row["UnitCode"].ToString();
                txtUnitDesc.Text = row["UnitName"].ToString();
                HelpGrid.Visible = false;
                txtDOJ.Focus();
            }

        }

        private void txtDeptCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDeptDesc.Text = string.Empty;
        }

        private void txtDesgCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDesgDesc.Text = string.Empty;
        }

        private void txtUnitCode_EditValueChanged(object sender, EventArgs e)
        {
            txtUnitDesc.Text = string.Empty;
        }

        private void txtDeptCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select DeptCode,DeptDesc from DeptMst", " Where DeptCode", txtDeptCode, txtDeptDesc, txtDesgDesc, HelpGrid, HelpGridView, e);
        }

        private void txtDesgCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select DesgCode,DesgDesc from DesgMst", " Where DesgCode", txtDesgCode, txtDesgDesc, txtUnitCode, HelpGrid, HelpGridView, e);
        }

        private void txtUnitCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select UnitCode, UnitName from UNITS", " Where UnitCode", txtUnitCode, txtUnitDesc, txtRemarks, HelpGrid, HelpGridView, e);
        }

        private void saveEmployeeData()
        {
            string sql = "";
            if (ValidateData())
            {
                using (var sqlcon = new SqlConnection(ProjectFunctions.GetConnection()))
                {
                    sqlcon.Open();
                    var sqlcom = sqlcon.CreateCommand();
                    var transaction = sqlcon.BeginTransaction("SaveTransaction");
                    sqlcom.Connection = sqlcon;
                    sqlcom.Transaction = transaction;
                    sqlcom.CommandType = CommandType.Text;
                    try
                    {
                        if (s1 == "&Add")
                        {
                            string empCode_SQL = "(SELECT RIGHT('0000' + CAST((ISNULL(MAX(CAST(EmpCode AS INT)), 0) + 1) AS VARCHAR(4)), 4) FROM EmpMst)";// SQL_QUERIES._frmEmployeeMstAddEdit._GetNewEmpCode(hasRtnCol:false);

                            sql = " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  Begin Transaction "
                                                 + " Insert into EmpMst"
                                                 + " (EmpCode,EmpName,EmpFHRelationTag,EmpFHName, UnitCode, EmpDeptCode,EmpDesgCode,EmpCategory,"
                                                 + " EmpSex,EmpDOJ,EmpDOL,EmpPFDTag,"
                                                 + " EmpESIDTag,EmpPFno,EmpESIno,EmpBasic,EmpHRA,EmpConv,"
                                                 + " EmpPET,EmpTDS,EmpLeft,EmpRemarks,EmpMotherNm,"
                                                 + " EmpNationality,EmpEmail,EmpDoB,EmpPanNo,"
                                                 + " EmpPassportNo                           ,"
                                                 + " EmpSplAlw,EmpReligion,EmpMaritalStatus,EmpPymtMode,EmpBankIFSCode,"
                                                 + " EmpBankAcNo,EmpBankName,EmpNominee,EmpNomineeRelation,EmpNomineeDOB,EmpAdharCardNo,EmpGHISDed,EmpFPFDTag,EmpMscD1,EmpAddress1,EmpAddress2,EmpAddress3,EmpDistCity,EmpState,EmpCountry,EmpUANNo,EmpBankBranchCode," +
                                                 "" +
                                                 "   TimeInFirst, TimeOutFirst, TimeInLast, TimeOutLast, WorkingHours, EmpImage)"
                                                 + " values(" + empCode_SQL + ",@EmpName,@EmpFHRelationTag,@EmpFHName, @UnitCode, @EmpDeptCode,@EmpDesgCode,@EmpCategory,"
                                                 + " @EmpSex,@EmpDOJ,@EmpDOL,@EmpPFDTag,"
                                                 + " @EmpESIDTag,@EmpPFno,@EmpESIno,@EmpBasic,@EmpHRA,@EmpConv,"
                                                 + " @EmpPET,@EmpTDS,@EmpLeft,@EmpRemarks,@EmpMotherNm,"
                                                 + " @EmpNationality,@EmpEmail,@EmpDoB,@EmpPanNo,"
                                                 + " @EmpPassportNo,"
                                                 + " @EmpSplAlw,@EmpReligion,@EmpMaritalStatus,@EmpPymtMode,@EmpBankIFSCode,"
                                                 + " @EmpBankAcNo,@EmpBankName,@EmpNominee,@EmpNomineeRelation,@EmpNomineeDOB,@EmpAdharCardNo,@EmpGHISDed,@EmpFPFDTag,@EmpMscD1,@EmpAddress1,@EmpAddress2,@EmpAddress3,@EmpDistCity,@EmpState,@EmpCountry,@EmpUANNo,@EmpBankBranchCode," +
                                                    "@TimeInFirst, @TimeOutFirst, @TimeInLast, @TimeOutLast, @WorkingHours, @EmpImage)"
                                                 + " Commit ";
                            sqlcom.CommandText = sql;

                            PrintLogWin.PrintLog(sql);
                        }
                        if (s1 == "Edit")
                        {
                            sql= " UPDATE EmpMst SET "
                                                + " EmpFHRelationTag=@EmpFHRelationTag,EmpFHName=@EmpFHName, UnitCode=@UnitCode, EmpDeptCode=@EmpDeptCode,EmpDesgCode=@EmpDesgCode,EmpCategory=@EmpCategory, "
                                                + " EmpSex=@EmpSex,EmpDOJ=@EmpDOJ,EmpDOL=@EmpDOL,EmpPFDTag=@EmpPFDTag, "
                                                + " EmpESIDTag=@EmpESIDTag,EmpPFno=@EmpPFno,EmpESIno=@EmpESIno,EmpBasic=@EmpBasic,EmpHRA=@EmpHRA,EmpConv=@EmpConv, "
                                                + " EmpPET=@EmpPET,EmpTDS=@EmpTDS,EmpLeft=@EmpLeft,EmpRemarks=@EmpRemarks,EmpMotherNm=@EmpMotherNm,EmpNationality=@EmpNationality, "
                                                + " EmpEmail=@EmpEmail,EmpDoB=@EmpDoB,EmpPanNo=@EmpPanNo,EmpPassportNo=@EmpPassportNo,EmpSplAlw=@EmpSplAlw,"
                                                + " EmpReligion=@EmpReligion,EmpMaritalStatus=@EmpMaritalStatus,EmpPymtMode=@EmpPymtMode,EmpBankIFSCode=@EmpBankIFSCode, "
                                                + " EmpBankAcNo=@EmpBankAcNo,EmpBankName=@EmpBankName,EmpNominee=@EmpNominee,EmpNomineeRelation=@EmpNomineeRelation,EmpNomineeDOB=@EmpNomineeDOB, "
                                                + " EmpAdharCardNo=@EmpAdharCardNo,EmpGHISDed=@EmpGHISDed,EmpFPFDTag=@EmpFPFDTag,EmpMscD1=@EmpMscD1,EmpAddress1=@EmpAddress1,EmpAddress2=@EmpAddress2,EmpAddress3=@EmpAddress3,EmpDistCity=@EmpDistCity,EmpState=@EmpState,EmpCountry=@EmpCountry ,EmpUANNo=@EmpUANNo,EmpBankBranchCode=@EmpBankBranchCode, " +
                                                "   TimeInFirst = @TimeInFirst," +
                                                "   TimeOutFirst = @TimeOutFirst," +
                                                "   TimeInLast = @TimeInLast," +
                                                "   TimeOutLast = @TimeOutLast," +
                                                "   WorkingHours = @WorkingHours, " +
                                                "   EmpImage = @EmpImage" +
                                                "   Where EmpCode=@EmpCode";

                            sqlcom.CommandText = sql;

                            PrintLogWin.PrintLog(sql);
                        }

                        sqlcom.Parameters.AddWithValue("@EmpCode", txtEmpCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpName", txtEmpName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpFHRelationTag", txtRelationTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpFHName", txtFHName.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@UnitCode", txtUnitCode.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@EmpDeptCode", txtDeptCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpDesgCode", txtDesgCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpCategory", txtCategoryCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpSex", txtEmpSex.Text.Trim());

                        if (txtDOJ.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDOJ", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDOJ", ConvertTo.DateTimeVal(txtDOJ.Text));
                        }
                        if (txtDOL.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDOL", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDOL", ConvertTo.DateTimeVal(txtDOL.Text));
                        }
                        sqlcom.Parameters.AddWithValue("@EmpPFDTag", txtEPFTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpESIDTag", txtESIDTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpPFno", txtEPFNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpESIno", txtESICNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpBasic", 0);
                        sqlcom.Parameters.AddWithValue("@EmpHRA", 0);
                        sqlcom.Parameters.AddWithValue("@EmpConv", 0);
                        sqlcom.Parameters.AddWithValue("@EmpPET", 0);
                        sqlcom.Parameters.AddWithValue("@EmpTDS", ConvertTo.DecimalVal(txtTDS.Text));
                        sqlcom.Parameters.AddWithValue("@EmpLeft", txtEmpLeft.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpRemarks", txtRemarks.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpMotherNm", txtMotherName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpNationality", txtNationality.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpEmail", txtEmail.Text.Trim());
                        if (txtDOB.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDoB", ConvertTo.DateTimeVal(txtDOB.Text));
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDoB", ConvertTo.DateTimeVal(txtDOB.Text));
                        }
                        sqlcom.Parameters.AddWithValue("@EmpPanNo", txtPanNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpPassportNo", txtPassPortNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpSplAlw", 0);
                        sqlcom.Parameters.AddWithValue("@EmpReligion", txtEmployeeReligion.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpMaritalStatus", txtMaritalStatus.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpPymtMode", txtPaymentMode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpBankIFSCode", txtIfscCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpBankAcNo", txtBankAccountNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpBankName", txtBankName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpNominee", txtNomineeName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpNomineeRelation", txtNomineeRelation.Text.Trim());
                        if (txtNomineeDOB.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@EmpNomineeDOB", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@EmpNomineeDOB", ConvertTo.DateTimeVal(txtNomineeDOB.Text));
                        }
                        sqlcom.Parameters.AddWithValue("@EmpAdharCardNo", txtAdharCardNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpGHISDed", ConvertTo.DecimalVal(txtHealthInsurance.Text));
                        sqlcom.Parameters.AddWithValue("@EmpFPFDTag", txtEFPFTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpMscD1", ConvertTo.DecimalVal(txtMiscDed.Text));
                        sqlcom.Parameters.AddWithValue("@EmpAddress1", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpAddress2", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpAddress3", txtAddress3.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@EmpDistCity", string.Empty);

                        sqlcom.Parameters.AddWithValue("@EmpState", txtState.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpCountry", txtCountry.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpUANNo", txtUANNo.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@EmpBankBranchCode", txtBankBranchCode.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@TimeInFirst", ConvertTo.DateTimeVal(timeEdit_Time_In_First.Text.ToString().Trim()));
                        sqlcom.Parameters.AddWithValue("@TimeOutFirst", ConvertTo.DateTimeVal(timeEdit_Time_Out_First.Text.ToString().Trim()));
                        sqlcom.Parameters.AddWithValue("@TimeInLast", ConvertTo.DateTimeVal(timeEdit_Time_In_Last.Text.ToString().Trim()));
                        sqlcom.Parameters.AddWithValue("@TimeOutLast", ConvertTo.DateTimeVal(timeEdit_Time_Out_Last.Text.ToString().Trim()));
                        sqlcom.Parameters.AddWithValue("@WorkingHours", ConvertTo.IntVal(totalWorkingHours_Text.Text.ToString().Trim()));

                        byte[] byteEmpty = null;

                        
                        if (ComparisonUtilsWin.PictureBox_IsNullOrEmpty(pictureBox1))
                        {
                            sqlcom.Parameters.AddWithValue("@EmpImage", byteEmpty);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@EmpImage", ConvertImageToBinary(pictureBox1.Image));
                        }
                        

                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        //XtraMessageBox.Show("Data Saved Successfully");
                        ProjectFunctions.SpeakError("Data Saved Successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        PrintLogWin.PrintLog(sql);


                        PrintLogWin.PrintLog("Line 663 : " + ex);
                        XtraMessageBox.Show("Something Wrong. \n I am going to Roll Back." + ex.Message, ex.GetType().ToString());
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            XtraMessageBox.Show("Something Wrong. \n Roll Back Failed." + ex2.Message, ex2.GetType().ToString());
                        }
                    }
                }
            }
        }

        private void txtCategory_EditValueChanged(object sender, EventArgs e)
        {
            txtCategoryDesc.Text = string.Empty;
        }

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select CatgCode,CatgDesc from CatgMst", " Where CatgCode", txtCategoryCode, txtCategoryDesc, txtDOJ, HelpGrid, HelpGridView, e);
        }

        private void txtEmpLeft_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEmpLeft.Text == "Y" || txtEmpLeft.Text == "N")
            {
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Valid Values are Y,N", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEmpLeft.Focus();
            }
        }

        private void txtEmpSex_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEmpSex.Text == "M" || txtEmpSex.Text == "F")
            {
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Valid Values are Male-M,Female-F", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEmpSex.Focus();
            }
        }

        private void txtRelationTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtRelationTag.Text == "F" || txtRelationTag.Text == "H")
            {
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Valid Values are Father-F,Husband-H", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtRelationTag.Focus();
            }
        }

        private void txtEPFTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEPFTag.Text == "Y" || txtEPFTag.Text == "N")
            {
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Valid Values are Y,N", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEPFTag.Focus();
            }
        }

        private void txtESIDTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtESIDTag.Text == "Y" || txtESIDTag.Text == "N")
            {
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Valid Values are Y,N", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtESIDTag.Focus();
            }
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();

            switch (tag)
            {
                case "save":
                    /* Navigate to page A */
                    saveEmployeeData();
                    break;
                case "save_close":
                    /* Navigate to page B */
                    
                    break;
                case "save_new":
                    /* Navigate to page C*/                    

                    break;
                case "reset":
                    /* Navigate to page D */
                    if (XtraMessageBox.Show("Do you want to reset the form?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        form_loaded = false;
                        employeeFormData_Load();

                    }
                        break;
                case "add_new":
                    /* Navigate to page C*/

                    

                    break;
                case "close":
                    /* Navigate to page E */
                    this.Close();

                    break;
            }
        }

        private void timeEdit_Time_In_First_EditValueChanged(object sender, EventArgs e)
        {
            CalculateDUtyHours();
        }

        private void timeEdit_Time_Out_First_EditValueChanged(object sender, EventArgs e)
        {
            CalculateDUtyHours();

        }
        private void timeEdit_Time_In_Last_EditValueChanged(object sender, EventArgs e)
        {
            CalculateDUtyHours();
        }

        private void timeEdit_Time_Out_Last_EditValueChanged(object sender, EventArgs e)
        {
            CalculateDUtyHours();
        }

        private void CalculateDUtyHours()
        {
            //DateTime.ParseExact(Eval("aeStart").ToString(), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToShortTimeString()
            int shift_id = 1;

            PrintLogWin.PrintLog("************* CalculateDUtyHours => CalculateDUtyHours");

            try
            {

                PrintLogWin.PrintLog("************* form_loaded => " + form_loaded + "");

                PrintLogWin.PrintLog("************* timeEdit_Time_In_First.EditValue => " + timeEdit_Time_In_First.EditValue + "");
                PrintLogWin.PrintLog("************* timeEdit_Time_Out_First.EditValue => " + timeEdit_Time_Out_First.EditValue + "");
                PrintLogWin.PrintLog("************* timeEdit_Time_In_Last.EditValue => " + timeEdit_Time_In_Last.EditValue + "");
                PrintLogWin.PrintLog("************* timeEdit_Time_Out_Last.EditValue => " + timeEdit_Time_Out_Last.EditValue + "");


                if (!form_loaded)
                {

                }
                else
                {
                    double totalHrs_First = 0;
                    double totalHrs_Last = 0;

                    if (timeEdit_Time_In_First.EditValue != null && timeEdit_Time_Out_First.EditValue != null)
                    {
                        DateTime dateTime_In_2 = ConvertTo.TimeToDate(timeEdit_Time_In_First.Text + "");
                        DateTime dateTime_Out_2 = ConvertTo.TimeToDate(timeEdit_Time_Out_First.Text + "");

                        if (dateTime_Out_2 < dateTime_In_2)
                        {
                            if (s1 == "Edit")
                            {
                                ProjectFunctions.SpeakError("Time Out First cannot be less than Time In First in Day Shift");
                                timeEdit_Time_Out_First.EditValue = null;
                            }                                
                        }
                        else
                        {
                            totalHrs_First = (dateTime_Out_2 - dateTime_In_2).TotalHours;
                            if (totalHrs_First < 0)
                            {
                                totalHrs_First = totalHrs_First * -1;
                            }
                        }
                    }

                    if (timeEdit_Time_In_Last.EditValue != null && timeEdit_Time_Out_Last.EditValue != null)
                    {
                        DateTime dateTime_In_Last = ConvertTo.TimeToDate(timeEdit_Time_In_Last.Text + "");
                        DateTime dateTime_Out_Last = ConvertTo.TimeToDate(timeEdit_Time_Out_Last.Text + "");
                        if (timeEdit_Time_Out_First.EditValue != null)
                        {
                            DateTime dateTime_Out_1 = ConvertTo.TimeToDate(timeEdit_Time_Out_First.Text + "");

                            if (dateTime_In_Last < dateTime_Out_1)
                            {
                                if (s1 == "Edit")
                                {
                                    ProjectFunctions.SpeakError("Time In Last cannot be less than Time Out First in Day Shift");
                                    timeEdit_Time_In_Last.EditValue = null;
                                }                                    
                            }
                            else
                            {
                                if (dateTime_Out_Last < dateTime_In_Last)
                                {
                                    if (s1 == "Edit")
                                    {
                                        ProjectFunctions.SpeakError("Time Out Last cannot be less than Time In Last in Day Shift");
                                        timeEdit_Time_Out_Last.EditValue = null;
                                    }                                        
                                }
                                else
                                {
                                    totalHrs_Last = (dateTime_Out_Last - dateTime_In_Last).TotalHours;
                                    if (totalHrs_Last < 0)
                                    {
                                        totalHrs_Last = totalHrs_Last * -1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dateTime_Out_Last < dateTime_In_Last)
                            {
                                if (s1 == "Edit")
                                {
                                    ProjectFunctions.SpeakError("Time Out Last cannot be less than Time In Last in Day Shift");
                                    timeEdit_Time_Out_Last.EditValue = null;
                                } 
                            }
                            else
                            {
                                totalHrs_Last = (dateTime_Out_Last - dateTime_In_Last).TotalHours;
                                if (totalHrs_Last < 0)
                                {
                                    totalHrs_Last = totalHrs_Last * -1;
                                }
                            }
                        }

                    }

                    double totalHrs_FullDay = totalHrs_First + totalHrs_Last;

                    totalWorkingHours_Text.Text = (totalHrs_FullDay).ToString();                   
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(timeEdit_Time_In_First.EditValue + "\n\n" + ex + "");
            }
            /*
            try
            {


                if (!form_loaded)
                {

                }
                else
                {
                    //string time_In = timeEdit_Time_In_First.Text + "";
                    //PrintLogWin.PrintLog("1a => " + time_In + "");
                    //TimeSpan timeSpan_In = TimeSpan.Parse(time_In);
                    //DateTime dateTime_In = DateTime.Today.Add(timeSpan_In);
                    DateTime dateTime_In = ConvertTo.TimeToDate(timeEdit_Time_In_First.Text + "");

                    PrintLogWin.PrintLog("4a => " + dateTime_In + "");
                    ///////////////////////////////////
                    //string time_Out = timeEdit_Time_Out_First.Text + "";
                    //PrintLogWin.PrintLog("1b => " + time_Out + "");
                    //TimeSpan timeSpan_Out = TimeSpan.Parse(time_Out);
                    //DateTime dateTime_Out = DateTime.Today.Add(timeSpan_Out);
                    DateTime dateTime_Out = ConvertTo.TimeToDate(timeEdit_Time_Out_First.Text + "");

                    PrintLogWin.PrintLog("4b => " + dateTime_Out + "");

                    if (shift_id == 1)
                    {
                        if (dateTime_Out < dateTime_In)
                        {
                            ProjectFunctions.SpeakError("Time Out First cannot be less than Time In First in Day Shift");
                            return;
                        }
                    }

                    double totalHrs_First = (dateTime_Out - dateTime_In).TotalHours;
                    if (totalHrs_First < 0)
                    {
                        totalHrs_First = totalHrs_First * -1;
                    }
                    PrintLogWin.PrintLog("5 => " + totalHrs_First + "");
                    //double sinc(DateTime xIn, DateTime yOut) => (xIn - yOut).TotalHours < 0.0 ? (xIn - yOut).TotalHours * -1 : (xIn - yOut).TotalHours;

                    ////////////////////////////////////

                    //string time_In_Last = timeEdit_Time_In_Last.Text + "";
                    //PrintLogWin.PrintLog("2a => " + time_In_Last + "");
                    //TimeSpan timeSpan_In_Last = TimeSpan.Parse(time_In_Last);
                    //DateTime dateTime_In_Last = DateTime.Today.Add(timeSpan_In_Last);
                    DateTime dateTime_In_Last = ConvertTo.TimeToDate(timeEdit_Time_In_Last.Text + "");

                    if (shift_id == 1)
                    {
                        if (dateTime_In_Last < dateTime_Out)
                        {
                            ProjectFunctions.SpeakError("Time In Last cannot be less than Time Out First in Day Shift");
                            return;
                        }
                    }

                    PrintLogWin.PrintLog("8a => " + dateTime_In_Last + "");
                    /////////////////////////////////////

                    //string time_Out_Last = timeEdit_Time_Out_Last.Text + "";
                    //PrintLogWin.PrintLog("2a => " + time_Out_Last + "");
                    //TimeSpan timeSpan_Out_Last = TimeSpan.Parse(time_Out_Last);
                    //DateTime dateTime_Out_Last = DateTime.Today.Add(timeSpan_Out_Last);
                    DateTime dateTime_Out_Last = ConvertTo.TimeToDate(timeEdit_Time_Out_Last.Text + "");

                    if (shift_id == 1)
                    {
                        if (dateTime_Out_Last < dateTime_In_Last)
                        {
                            ProjectFunctions.SpeakError("Time Out Last cannot be less than Time In Last in Day Shift");
                            return;
                        }
                    }

                    PrintLogWin.PrintLog("8a => " + dateTime_Out_Last + "");

                    var totalHrs_Last = (dateTime_Out_Last - dateTime_In_Last).TotalHours;
                    if (totalHrs_Last < 0)
                    {
                        totalHrs_Last = totalHrs_Last * -1;
                    }
                    PrintLogWin.PrintLog("10 => " + totalHrs_Last + "");
                    /////////////////////////////////////
                   
                    totalWorkingHours_Text.Text = (totalHrs_First + totalHrs_Last).ToString();


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(timeEdit_Time_In_First.EditValue + "\n\n" + ex + "");
            }
            */





            //TimeSpan timeSpan_Out = TimeSpan.Parse(timeEdit_Time_Out_First.EditValue + "");
            //DateTime dateTime_Out = DateTime.Today.Add(timeSpan_Out);

            //string displayTime = time.ToString("hh:mm:ss");

            //string time = "10:48:00";
            //DateTime dateTime_In = DateTime.ParseExact(timeEdit_Time_In_First.EditValue.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
            //DateTime dateTime_Out = DateTime.ParseExact(timeEdit_Time_Out_First.EditValue.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
            //Console.WriteLine(dateTime.ToShortTimeString());

            //var inTime_First = Convert.ToDateTime(timeEdit_Time_In_First.EditValue);
            //var outTime_First = Convert.ToDateTime(timeEdit_Time_Out_First.EditValue);
            //var totalHours = Convert.ToDateTime(inTime).TimeOfDay.Subtract(outTime);


            //var totalHrs_First = (dateTime_Out - dateTime_In).TotalHours;
            //totalWorkingHours_Text.Text = totalHrs_First.ToString();
        }
    }
}
