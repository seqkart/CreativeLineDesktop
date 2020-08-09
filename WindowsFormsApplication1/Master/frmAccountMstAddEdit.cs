using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmAccountMstAddEdit : XtraForm
    {
        public String s1 { get; set; }
        public String AccCode { get; set; }
        public frmAccountMstAddEdit()
        {
            InitializeComponent();
        }

        private void txtSLCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSLDesc.Text = string.Empty;
        }
        private void SetMyControls()
        {
            try
            {
                txtAcCode.Enabled = false;
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.DatePickerVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.TextBoxVisualize(panelControl2);
                ProjectFunctions.TextBoxVisualize(panelControl3);
                ProjectFunctions.ButtonVisualize(this);
                ProjectFunctions.XtraFormVisualize(this);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void txtBCCode_EditValueChanged(object sender, EventArgs e)
        {
            txtBSDesc.Text = string.Empty;
        }

        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpName.Text = string.Empty;
        }

        private void frmAccountMstAddEdit_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                if (s1 == "&Add")
                {
                    txtAcCategory.Focus();
                    txtAcCode.Text = ProjectFunctions.GetNewTransactionCode("select max(Cast(AccCode as int)) from ActMst");
                }
                if (s1 == "Edit")
                {
                    //txtAcName.Enabled = false;
                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadActMstFEditing '" + AccCode + "'");
                    txtAcCategory.Text = ds.Tables[0].Rows[0]["AccType"].ToString();
                    txtAcCode.Text = ds.Tables[0].Rows[0]["AccCode"].ToString();
                    txtAcName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["AccAddress1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["AccAddress2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["AccAddress3"].ToString();
                    txtBankAccNo.Text = ds.Tables[0].Rows[0]["AccBankAccNo"].ToString();
                    txtBankName.Text = ds.Tables[0].Rows[0]["AccAcinBankName"].ToString();
                    txtBillingName.Text = ds.Tables[0].Rows[0]["BillingName"].ToString();
                    txtBSCode.Text = ds.Tables[0].Rows[0]["AccBSHcode"].ToString();
                    txtBSDesc.Text = ds.Tables[0].Rows[0]["BSDesc"].ToString();
                    txtChequeName.Text = ds.Tables[0].Rows[0]["AccChqName"].ToString();
                    txtContactPerson.Text = ds.Tables[0].Rows[0]["AccContactPerson"].ToString();
                    txtCstPst.Text = ds.Tables[0].Rows[0]["AccPSTCST"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["AccEmail"].ToString();
                    txtEmpCode.Text = ds.Tables[0].Rows[0]["AccEmpCode"].ToString();
                    txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    txtGSTNo.Text = ds.Tables[0].Rows[0]["AccGSTNo"].ToString();
                    txtNameAsOnBankAcc.Text = ds.Tables[0].Rows[0]["AccNameAsInBank"].ToString();
                    txtOBalance.Text = ds.Tables[0].Rows[0]["ActOpBal"].ToString();
                    txtPanNo.Text = ds.Tables[0].Rows[0]["AccPANno"].ToString();
                    txtSLCode.Text = ds.Tables[0].Rows[0]["AccLedger"].ToString();
                    txtSLDesc.Text = ds.Tables[0].Rows[0]["LgrDesc"].ToString();

                    txtStatusTag.Text = ds.Tables[0].Rows[0]["AccAnATag"].ToString();

                    txtTel.Text = ds.Tables[0].Rows[0]["AccTeleFax"].ToString();
                    txtTinNo.Text = ds.Tables[0].Rows[0]["AccTIN"].ToString();
                    txtGSTStateCode.Text = ds.Tables[0].Rows[0]["AccGSTStateCode"].ToString();

                    txtGSTStateDesc.Text = ds.Tables[0].Rows[0]["GSTStateDesc"].ToString();
                    txtGSTType.Text = ds.Tables[0].Rows[0]["AccGSTType"].ToString();


                    txtLCTag.Text = ds.Tables[0].Rows[0]["AccLCTag"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["AccMobNo"].ToString();
                    txtAltMobileNo.Text = ds.Tables[0].Rows[0]["AccAltMobNo"].ToString();
                    txtCityCode.Text = ds.Tables[0].Rows[0]["AccCityCode"].ToString();
                    txtCityName.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                    txtCountry.Text = ds.Tables[0].Rows[0]["UNDERRG"].ToString();
                    txtMRPMarkDown.Text = ds.Tables[0].Rows[0]["AccMrpMarkDown"].ToString();
                    txtAgentCode.Text = ds.Tables[0].Rows[0]["AccBrokerID"].ToString();
                    txtAgentName.Text = ds.Tables[0].Rows[0]["AgentName"].ToString();
                    txtAccDCCode.Text = ds.Tables[0].Rows[0]["AccDCCode"].ToString();
                    txtZipCode.Text = ds.Tables[0].Rows[0]["AccZipCode"].ToString();
                    txtEnableTDS.EditValue = ds.Tables[0].Rows[0]["AccTDSEnable"].ToString();
                    txtStockTransferTag.Text = ds.Tables[0].Rows[0]["AccStkTrf"].ToString();
                    txtFixBArCodeTag.Text = ds.Tables[0].Rows[0]["AccFixBarCodeTag"].ToString();

                    txtUnitCode.Text = ds.Tables[0].Rows[0]["AccUnitCode"].ToString();
                    txtUnitName.Text = ds.Tables[0].Rows[0]["UNITNAME"].ToString();
                    txtAcCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void frmAccountMstAddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                {
                    System.Windows.Forms.SendKeys.Send("+{TAB}");
                }
                if (e.Control && e.KeyCode == Keys.S)
                {
                    btnSave_Click(null, e);
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateData()
        {
            try
            {
                if (txtOBalance.Text.Trim().Length == 0)
                {
                    txtOBalance.Text = "0";
                }
                if (txtAgentCode.Text.Trim().Length == 0)
                {
                    txtAgentCode.Text = "0";
                }
                if (txtZipCode.Text.Trim().Length == 0)
                {
                    txtZipCode.Text = "0";
                }
                if (txtAcCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Account Code");
                    txtAcCode.Focus();
                    return false;
                }
                if (txtAcName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Account Name");
                    txtAcName.Focus();
                    return false;
                }
                if (txtMRPMarkDown.Text.Trim().Length == 0)
                {
                    txtMRPMarkDown.Text = "0";
                }
                //if (txtBSCode.Text.Trim().Length == 0)
                //{
                //    ProjectFunctions.SpeakError("Invalid Balance Sheet Head");
                //    txtBSCode.Focus();
                //    return false;
                //}
                //if (txtBSDesc.Text.Trim().Length == 0)

                //    ProjectFunctions.SpeakError("Invalid Balance Sheet Head");
                //    txtBSCode.Focus();
                //    return false;
                //}
                //if (txtSLCode.Text.Trim().Length == 0)
                //{
                //    ProjectFunctions.SpeakError("Invalid Sub Ledger Code");
                //    txtSLCode.Focus();
                //    return false;
                //}
                //if (txtSLDesc.Text.Trim().Length == 0)
                //{
                //    ProjectFunctions.SpeakError("Invalid Sub Ledger Desc");
                //    txtSLCode.Focus();
                //    return false;
                //}


                if (txtLCTag.Text.ToUpper() == "L" || (txtLCTag.Text.ToUpper() == "C"))
                {
                    txtLCTag.Text = txtLCTag.Text.ToUpper();
                }
                else
                {
                    ProjectFunctions.SpeakError("Valid Vales Are L/C");
                    txtLCTag.Text = string.Empty;
                    return false;
                }

                if (txtGSTStateCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid GST State Desc");
                    txtGSTStateCode.Focus();
                    return false;
                }
                if (txtGSTStateDesc.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid GST State Desc");
                    txtGSTStateCode.Focus();
                    return false;
                }

                //if (txtInTime.Text.Trim().Length == 0)
                //{
                //    ProjectFunctions.SpeakError("Invalid In Time");
                //    txtInTime.Focus();
                //    return false;
                //}
                //if (txtOutTime.Text.Trim().Length == 0)
                //{
                //    ProjectFunctions.SpeakError("Invalid Out Time");
                //    txtOutTime.Focus();
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                return false;
            }
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
                            sqlcom.CommandText = " Insert into ActMst"
                            + " (AccActive,AccCode,AccType,AccName,AccLedger,ActOpBal,AccEmpCode,AccBSHcode,AccGSTNo,AccGSTStateCode,AccLCTag,AccGSTType,AccStkTrf,AccUnitCode,AccFixBarCodeTag)"
                            + " values(@AccActive,@AccCode,@AccType,@AccName,@AccLedger,@ActOpBal,@AccEmpCode,@AccBSHcode,@AccGSTNo,@AccGSTStateCode,@AccLCTag,@AccGSTType,@AccStkTrf,@AccUnitCode,@AccFixBarCodeTag)";
                            txtAcCode.Text = ProjectFunctions.GetNewTransactionCode("select max(Cast(AccCode as int)) from ActMst");
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE    ActMst SET "
                                                     + " AccActive=@AccActive, AccType=@AccType,AccName=@AccName,AccLedger=@AccLedger,ActOpBal=@ActOpBal,"
                                                     + " AccEmpCode=@AccEmpCode,AccBSHcode=@AccBSHcode,AccGSTNo=@AccGSTNo,AccGSTStateCode=@AccGSTStateCode,AccLCTag=@AccLCTag,AccGSTType=@AccGSTType,AccStkTrf=@AccStkTrf,AccUnitCode=@AccUnitCode,AccFixBarCodeTag=@AccFixBarCodeTag"
                                                     + " Where AccCode=@AccCode";


                        }
                        sqlcom.Parameters.AddWithValue("@AccActive", txtStatusTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccCode", txtAcCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccType", txtAcCategory.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccName", txtAcName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccLedger", txtSLCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ActOpBal", Convert.ToDecimal(txtOBalance.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@AccEmpCode", txtEmpCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccBSHcode", txtBSCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccGSTType", txtGSTType.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccGSTNo", txtGSTNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccGSTStateCode", txtGSTStateCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccLCTag", txtLCTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccStkTrf", txtStockTransferTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccUnitCode", txtUnitCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccFixBarCodeTag", txtFixBArCodeTag.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();
                        if (s1 == "&Add")
                        {
                            sqlcom.CommandText = " Insert into ActMstAddInf"
                                                   + " (AccCode,AccName,AccType,AccAddress1,AccAddress2,AccAddress3,AccTeleFax,AccEmail,AccContactPerson,"
                                                   + "AccPSTCST,AccAnATag,AccChqName,AccTIN,AccPANno,"
                                                   + " AccAcinBankName,AccNameAsInBank,AccBankAccNo,"
                                                    + " AccAltMobNo,AccBrokerID,AccMobNo,"
                                                     + " AccZipCode,AccCityCode,AccTDSEnable,AccMrpMarkDown,AccDCCode)"
                                                   + " values(@AccCode,@AccName,@AccType,@AccAddress1,@AccAddress2,@AccAddress3,@AccTeleFax,@AccEmail,@AccContactPerson,"
                                                   + "@AccPSTCST,@AccAnATag,@AccChqName,@AccTIN,@AccPANno,"
                                                   + " @AccAcinBankName,@AccNameAsInBank,@AccBankAccNo,"
                            + " @AccAltMobNo,@AccBrokerID,@AccMobNo,"
                            + " @AccZipCode,@AccCityCode,@AccTDSEnable,@AccMrpMarkDown,@AccDCCode)";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE    ActMstAddInf SET  "
                                                + "AccName=@AccName,AccType=@AccType,AccAddress1=@AccAddress1,AccAddress2=@AccAddress2,"
                                                + "AccAddress3=@AccAddress3,AccTeleFax=@AccTeleFax,AccEmail=@AccEmail,AccContactPerson=@AccContactPerson,"
                                                + "AccPSTCST=@AccPSTCST,"
                                                + "AccAnATag=@AccAnATag,AccChqName=@AccChqName,AccTIN=@AccTIN,"
                                                + "AccPANno=@AccPANno,AccAcinBankName=@AccAcinBankName,AccNameAsInBank=@AccNameAsInBank,"
                                                + "AccBankAccNo=@AccBankAccNo,AccAltMobNo=@AccAltMobNo,AccBrokerID=@AccBrokerID,AccMobNo=@AccMobNo,AccZipCode=@AccZipCode ,AccCityCode=@AccCityCode,AccTDSEnable=@AccTDSEnable,AccMrpMarkDown=@AccMrpMarkDown,AccDCCode=@AccDCCode"
                                                + " Where AccCode=@AccCode";
                        }


                        sqlcom.Parameters.AddWithValue("@AccCode", txtAcCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccName", txtBillingName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccType", txtAcCategory.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccAddress1", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccAddress2", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccAddress3", txtAddress3.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccTeleFax", txtTel.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccEmail", txtEmail.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccContactPerson", txtContactPerson.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccPSTCST", txtCstPst.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccAnATag", txtStatusTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccChqName", txtChequeName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccTIN", txtTinNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccPANno", txtPanNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccAcinBankName", txtBankName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccNameAsInBank", txtNameAsOnBankAcc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccBankAccNo", txtBankAccNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccAltMobNo", txtAltMobileNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccBrokerID", txtAgentCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccMobNo", txtMobileNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccZipCode", txtZipCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccCityCode", txtCityCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccTDSEnable", txtEnableTDS.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@AccMrpMarkDown", Convert.ToDecimal(txtMRPMarkDown.Text));
                        sqlcom.Parameters.AddWithValue("@AccDCCode", txtAccDCCode.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Parameters.Clear();

                        transaction.Commit();
                        ProjectFunctions.SpeakError("Data Saved Successfully");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        ProjectFunctions.SpeakError("Something Wrong. \n I am going to Roll Back." + ex.Message);
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            ProjectFunctions.SpeakError("Something Wrong. \n Roll Back Failed." + ex2.Message);
                        }
                    }
                }
            }
        }
        private void txtSLCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select LgrCode,LgrDesc from LgrMst", " Where LgrCode", txtSLCode, txtSLDesc, txtBSCode, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtBSCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select BSCode,BSDesc from BshMst", " Where BSCode", txtBSCode, txtBSDesc, txtBSCode, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
                if (HelpGrid.Text == "txtSLCode")
                {
                    txtSLCode.Text = row["LgrCode"].ToString();
                    txtSLDesc.Text = row["LgrDesc"].ToString();
                    HelpGrid.Visible = false;
                    txtBSCode.Focus();
                }
                if (HelpGrid.Text == "txtBSCode")
                {
                    txtBSCode.Text = row["BSCode"].ToString();
                    txtBSDesc.Text = row["BSDesc"].ToString();
                    HelpGrid.Visible = false;
                    txtBSCode.Focus();
                }
                if (HelpGrid.Text == "txtEmpCode")
                {
                    txtEmpCode.Text = row["EmpCode"].ToString();
                    txtEmpName.Text = row["EmpName"].ToString();
                    HelpGrid.Visible = false;
                    txtChequeName.Focus();
                }
                if (HelpGrid.Text == "txtGSTStateCode")
                {
                    txtGSTStateCode.Text = row["GSTStateCode"].ToString();
                    txtGSTStateDesc.Text = row["GSTStateDesc"].ToString();
                    HelpGrid.Visible = false;
                    txtChequeName.Focus();
                }
                if (HelpGrid.Text == "txtCityCode")
                {
                    txtCityCode.Text = row["CTSYSID"].ToString();
                    txtCityName.Text = row["CTNAME"].ToString();
                    txtState.Text = row["STNAME"].ToString();
                    txtCountry.Text = row["UNDERRG"].ToString();
                    HelpGrid.Visible = false;
                    txtContactPerson.Focus();
                }
                if (HelpGrid.Text == "txtAgentCode")
                {
                    txtAgentCode.Text = row["AgentCode"].ToString();
                    txtAgentName.Text = row["AgentName"].ToString();
                    HelpGrid.Visible = false;
                    txtAgentCode.Focus();
                }
                if (HelpGrid.Text == "txtUnitCode")
                {
                    txtUnitCode.Text = row["UNITID"].ToString();
                    txtUnitName.Text = row["UNITNAME"].ToString();
                    HelpGrid.Visible = false;
                    txtUnitCode.Focus();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }


        public void HelpGrid_KeyDown(object sender, KeyEventArgs e)
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

        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select EmpCode,EmpName from EmpMst", " Where EmpCode", txtEmpCode, txtEmpName, txtChequeName, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtAcCategory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtAcCategory.Text.ToUpper() == "A" || (txtAcCategory.Text.ToUpper() == "L") || txtAcCategory.Text.ToUpper() == "S" || (txtAcCategory.Text.ToUpper() == "P") || txtAcCategory.Text.ToUpper() == "E" || (txtAcCategory.Text.ToUpper() == "I"))
            {
                txtAcCategory.Text = txtAcCategory.Text.ToUpper();
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Vales Are A/L/E/P/I/S");
                txtAcCategory.Text = string.Empty;
                txtAcCategory.Focus();
            }
        }

        private void txtOBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtEmpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.TextOnly(e);
        }

        private void txtGSTStateCode_EditValueChanged(object sender, EventArgs e)
        {
            txtGSTStateDesc.Text = string.Empty;
        }

        private void txtGSTStateCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select GSTStateCode,GSTStateDesc from GSTStateMst", " Where GSTStateCode", txtGSTStateCode, txtGSTStateDesc, txtGSTStateCode, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TxtCityCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForFourBoxes("SELECT        CITYMASTER.CTSYSID, CITYMASTER.CTNAME,STATEMASTER.STNAME,STATEMASTER.UNDERRG FROM CITYMASTER INNER JOIN STATEMASTER ON CITYMASTER.UNDERSTID = STATEMASTER.STSYSID", " Where CTSYSID", txtCityCode, txtCityName, txtState, txtCountry, txtContactPerson, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TxtAgentCode_EditValueChanged(object sender, EventArgs e)
        {
            txtAgentName.Text = String.Empty;
        }

        private void TxtAgentCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AgentCode,AgentName from AgentMst", " Where AgentCode", txtAgentCode, txtAgentName, txtBSCode, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void TxtUnitCode_EditValueChanged(object sender, EventArgs e)
        {
            txtUnitName.Text = String.Empty;
        }

        private void TxtUnitCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("select  UNITID,UNITNAME from UNITS", " Where UNITID", txtUnitCode, txtUnitName, txtUnitCode, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void txtFixBArCodeTag_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtAcName_EditValueChanged(object sender, EventArgs e)
        {
            txtChequeName.Text = txtAcName.Text;
            txtBillingName.Text = txtAcName.Text;
            txtNameAsOnBankAcc.Text = txtAcName.Text;
        }
    }
}