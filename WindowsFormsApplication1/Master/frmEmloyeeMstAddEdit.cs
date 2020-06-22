using DevExpress.XtraEditors;
using SeqKartLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
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
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtEmpCode.Enabled = false;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (txtBasicPay.Text.Trim().Length == 0)
            {
                txtBasicPay.Text = "0";
            }
            if (txtHRA.Text.Trim().Length == 0)
            {
                txtHRA.Text = "0";
            }
            if (txtConvenyance.Text.Trim().Length == 0)
            {
                txtConvenyance.Text = "0";
            }
            if (txtPetrol.Text.Trim().Length == 0)
            {
                txtPetrol.Text = "0";
            }
            if (txtEmpSplAlw.Text.Trim().Length == 0)
            {
                txtEmpSplAlw.Text = "0";
            }
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
        private void frmEmloyeeMstAddEdit_Load(object sender, EventArgs e)

        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtEmpName.Select();
                txtEmpCode.Text = ProjectFunctionsUtils.GetNewEmpCode();//.PadLeft(5, '0');
            }
            if (s1 == "Edit")
            {

                txtEmpName.Enabled = false;
                PrintLogWin.PrintLog("frmEmloyeeMstAddEdit_Load =========> Line 131 => sp_LoadEmpMstFEditing '" + EmpCode + "'");

                var dsResult = ProjectFunctionsUtils.GetDataSet_T("sp_LoadEmpMstFEditing '" + EmpCode + "'");
                if (dsResult.Item1)
                {
                    DataSet ds = dsResult.Item2;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
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
                        txtBasicPay.Text = ds.Tables[0].Rows[0]["EmpBasic"].ToString();
                        txtHRA.Text = ds.Tables[0].Rows[0]["EmpHRA"].ToString();
                        txtConvenyance.Text = ds.Tables[0].Rows[0]["EmpConv"].ToString();
                        txtPetrol.Text = ds.Tables[0].Rows[0]["EmpPET"].ToString();
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

                        txtEmpSplAlw.Text = ds.Tables[0].Rows[0]["EmpSplAlw"].ToString();
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
                        txtDistCity.Text = ds.Tables[0].Rows[0]["EmpDistCity"].ToString();
                        txtState.Text = ds.Tables[0].Rows[0]["EmpState"].ToString();
                        txtCountry.Text = ds.Tables[0].Rows[0]["EmpCountry"].ToString();

                        txtEFPFTag.Text = ds.Tables[0].Rows[0]["EmpFpfDTag"].ToString();
                        txtUANNo.Text = ds.Tables[0].Rows[0]["EmpUANNo"].ToString();
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

        }

        private void txtDeptCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDeptDesc.Text = string.Empty;
        }

        private void txtDesgCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDesgDesc.Text = string.Empty;
        }

        private void txtDeptCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select DeptCode,DeptDesc from DeptMst", " Where DeptCode", txtDeptCode, txtDeptDesc, txtDesgDesc, HelpGrid, HelpGridView, e);
        }

        private void txtDesgCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select DesgCode,DesgDesc from DesgMst", " Where DesgCode", txtDesgCode, txtDesgDesc, txtRemarks, HelpGrid, HelpGridView, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
                            sqlcom.CommandText = " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  Begin Transaction "
                                                 + " Insert into EmpMst"
                                                 + " (EmpCode,EmpName,EmpFHRelationTag,EmpFHName,EmpDeptCode,EmpDesgCode,EmpCategory,"
                                                 + " EmpSex,EmpDOJ,EmpDOL,EmpPFDTag,"
                                                 + " EmpESIDTag,EmpPFno,EmpESIno,EmpBasic,EmpHRA,EmpConv,"
                                                 + " EmpPET,EmpTDS,EmpLeft,EmpRemarks,EmpMotherNm,"
                                                 + " EmpNationality,EmpEmail,EmpDoB,EmpPanNo,"
                                                 + " EmpPassportNo                           ,"
                                                 + " EmpSplAlw,EmpReligion,EmpMaritalStatus,EmpPymtMode,EmpBankIFSCode,"
                                                 + " EmpBankAcNo,EmpBankName,EmpNominee,EmpNomineeRelation,EmpNomineeDOB,EmpAdharCardNo,EmpGHISDed,EmpFPFDTag,EmpMscD1,EmpAddress1,EmpAddress2,EmpAddress3,EmpDistCity,EmpState,EmpCountry,EmpUANNo,EmpBankBranchCode)"
                                                 + " values((SELECT RIGHT('00000'+ CAST( ISNULL( max(Cast(EmpCode as int)),0)+1 AS VARCHAR(5)),5)from EmpMst),@EmpName,@EmpFHRelationTag,@EmpFHName,@EmpDeptCode,@EmpDesgCode,@EmpCategory,"
                                                 + " @EmpSex,@EmpDOJ,@EmpDOL,@EmpPFDTag,"
                                                 + " @EmpESIDTag,@EmpPFno,@EmpESIno,@EmpBasic,@EmpHRA,@EmpConv,"
                                                 + " @EmpPET,@EmpTDS,@EmpLeft,@EmpRemarks,@EmpMotherNm,"
                                                 + " @EmpNationality,@EmpEmail,@EmpDoB,@EmpPanNo,"
                                                 + " @EmpPassportNo,"
                                                 + " @EmpSplAlw,@EmpReligion,@EmpMaritalStatus,@EmpPymtMode,@EmpBankIFSCode,"
                                                 + " @EmpBankAcNo,@EmpBankName,@EmpNominee,@EmpNomineeRelation,@EmpNomineeDOB,@EmpAdharCardNo,@EmpGHISDed,@EmpFPFDTag,@EmpMscD1,@EmpAddress1,@EmpAddress2,@EmpAddress3,@EmpDistCity,@EmpState,@EmpCountry,@EmpUANNo,@EmpBankBranchCode)"
                                                 + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE EmpMst SET "
                                                + " EmpFHRelationTag=@EmpFHRelationTag,EmpFHName=@EmpFHName,EmpDeptCode=@EmpDeptCode,EmpDesgCode=@EmpDesgCode,EmpCategory=@EmpCategory, "
                                                + " EmpSex=@EmpSex,EmpDOJ=@EmpDOJ,EmpDOL=@EmpDOL,EmpPFDTag=@EmpPFDTag, "
                                                + " EmpESIDTag=@EmpESIDTag,EmpPFno=@EmpPFno,EmpESIno=@EmpESIno,EmpBasic=@EmpBasic,EmpHRA=@EmpHRA,EmpConv=@EmpConv, "
                                                + " EmpPET=@EmpPET,EmpTDS=@EmpTDS,EmpLeft=@EmpLeft,EmpRemarks=@EmpRemarks,EmpMotherNm=@EmpMotherNm,EmpNationality=@EmpNationality, "
                                                + " EmpEmail=@EmpEmail,EmpDoB=@EmpDoB,EmpPanNo=@EmpPanNo,EmpPassportNo=@EmpPassportNo,EmpSplAlw=@EmpSplAlw,"
                                                + " EmpReligion=@EmpReligion,EmpMaritalStatus=@EmpMaritalStatus,EmpPymtMode=@EmpPymtMode,EmpBankIFSCode=@EmpBankIFSCode, "
                                                + " EmpBankAcNo=@EmpBankAcNo,EmpBankName=@EmpBankName,EmpNominee=@EmpNominee,EmpNomineeRelation=@EmpNomineeRelation,EmpNomineeDOB=@EmpNomineeDOB, "
                                                + " EmpAdharCardNo=@EmpAdharCardNo,EmpGHISDed=@EmpGHISDed,EmpFPFDTag=@EmpFPFDTag,EmpMscD1=@EmpMscD1,EmpAddress1=@EmpAddress1,EmpAddress2=@EmpAddress2,EmpAddress3=@EmpAddress3,EmpDistCity=@EmpDistCity,EmpState=@EmpState,EmpCountry=@EmpCountry ,EmpUANNo=@EmpUANNo,EmpBankBranchCode=@EmpBankBranchCode "
                                                + " Where EmpCode=@EmpCode";
                        }

                        sqlcom.Parameters.AddWithValue("@EmpCode", txtEmpCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpName", txtEmpName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpFHRelationTag", txtRelationTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpFHName", txtFHName.Text.Trim());
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
                            sqlcom.Parameters.AddWithValue("@EmpDOJ", Convert.ToDateTime(txtDOJ.Text));
                        }
                        if (txtDOL.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDOL", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDOL", Convert.ToDateTime(txtDOL.Text));
                        }
                        sqlcom.Parameters.AddWithValue("@EmpPFDTag", txtEPFTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpESIDTag", txtESIDTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpPFno", txtEPFNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpESIno", txtESICNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpBasic", Convert.ToDecimal(txtBasicPay.Text));
                        sqlcom.Parameters.AddWithValue("@EmpHRA", Convert.ToDecimal(txtHRA.Text));
                        sqlcom.Parameters.AddWithValue("@EmpConv", Convert.ToDecimal(txtConvenyance.Text));
                        sqlcom.Parameters.AddWithValue("@EmpPET", Convert.ToDecimal(txtPetrol.Text));
                        sqlcom.Parameters.AddWithValue("@EmpTDS", Convert.ToDecimal(txtTDS.Text));
                        sqlcom.Parameters.AddWithValue("@EmpLeft", txtEmpLeft.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpRemarks", txtRemarks.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpMotherNm", txtMotherName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpNationality", txtNationality.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpEmail", txtEmail.Text.Trim());
                        if (txtDOB.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDoB", Convert.ToDateTime(txtDOB.Text));
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@EmpDoB", Convert.ToDateTime(txtDOB.Text));
                        }
                        sqlcom.Parameters.AddWithValue("@EmpPanNo", txtPanNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpPassportNo", txtPassPortNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpSplAlw", Convert.ToDecimal(txtEmpSplAlw.Text));
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
                            sqlcom.Parameters.AddWithValue("@EmpNomineeDOB", Convert.ToDateTime(txtNomineeDOB.Text));
                        }
                        sqlcom.Parameters.AddWithValue("@EmpAdharCardNo", txtAdharCardNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpGHISDed", Convert.ToDecimal(txtHealthInsurance.Text));
                        sqlcom.Parameters.AddWithValue("@EmpFPFDTag", txtEFPFTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpMscD1", Convert.ToDecimal(txtMiscDed.Text));
                        sqlcom.Parameters.AddWithValue("@EmpAddress1", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpAddress2", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpAddress3", txtAddress3.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpDistCity", txtDistCity.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpState", txtState.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpCountry", txtCountry.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpUANNo", txtUANNo.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@EmpBankBranchCode", txtBankBranchCode.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        XtraMessageBox.Show("Data Saved Successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
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




    }
}
