using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmAddressBook : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String AddressBookCode { get; set; }
        public frmAddressBook()
        {
            InitializeComponent();
        }

        private void SetMyControls()
        {
            try
            {
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.DatePickerVisualize(this);
                ProjectFunctions.TextBoxVisualize(this);
                ProjectFunctions.ButtonVisualize(this);
                ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
                txtAddress.Properties.MaxLength = 150;
                txtAddress1.Properties.MaxLength = 150;
                txtAddress2.Properties.MaxLength = 150;
                txtCityCode.Properties.MaxLength = 55;
                txtCompany.Properties.MaxLength = 150;
                txtContactNo.Properties.MaxLength = 12;
                txtEmailId.Properties.MaxLength = 55;
                txtFirstName.Properties.MaxLength = 25;
                txtLandMark.Properties.MaxLength = 150;
                txtLastName.Properties.MaxLength = 25;
                txtState.Properties.MaxLength = 55;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void FrmAddressBook_Load(object sender, EventArgs e)
        {
            try
            {
                SetMyControls();
                if (s1 == "&Add")
                {
                    txtGroupCode.Focus();
                }
                if (s1 == "Edit")
                {
                    txtAddressBookCode.Enabled = false;
                    DataSet ds = ProjectFunctions.GetDataSet("sp_LoadAddressBookFEdit '" + AddressBookCode + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtAddress.Text = ds.Tables[0].Rows[0]["ADBADDRESS"].ToString();
                        txtAddress1.Text = ds.Tables[0].Rows[0]["ADBADDRESS1"].ToString();
                        txtAddress2.Text = ds.Tables[0].Rows[0]["ADBADDRESS2"].ToString();
                        txtAddressBookCode.Text = ds.Tables[0].Rows[0]["ADBSYSID"].ToString();
                        txtCityCode.Text = ds.Tables[0].Rows[0]["ADBCITY"].ToString();
                        txtCityName.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                        txtState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                        txtCountry.Text = ds.Tables[0].Rows[0]["UNDERRG"].ToString();
                        txtCompany.Text = ds.Tables[0].Rows[0]["ADBCOMPANY"].ToString();
                        txtContactNo.Text = ds.Tables[0].Rows[0]["ADBCONTNO"].ToString();
                        txtEmailId.Text = ds.Tables[0].Rows[0]["ADBCONTEMAILID"].ToString();
                        txtFirstName.Text = ds.Tables[0].Rows[0]["ADBFIRSTNAME"].ToString();
                        txtGroupCode.Text = ds.Tables[0].Rows[0]["ADBGroupCode"].ToString();
                        txtGroupDesc.Text = ds.Tables[0].Rows[0]["AddressBookGroupDesc"].ToString();
                        txtLandMark.Text = ds.Tables[0].Rows[0]["ADBADDRLNDMRK"].ToString();
                        txtLastName.Text = ds.Tables[0].Rows[0]["ADBLASTNAME"].ToString();
                        txtState.Text = ds.Tables[0].Rows[0]["ADBSTATE"].ToString();
                        txtTitle.Text = ds.Tables[0].Rows[0]["ADBNTITLE"].ToString();
                    }
                    txtGroupCode.Focus();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
        private bool ValidateData()
        {
            try
            {
                if (txtGroupCode.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Address Group Code");
                    txtGroupCode.Focus();
                    return false;
                }
                if (txtGroupDesc.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Address Group Desc");
                    txtGroupCode.Focus();
                    return false;
                }

                if (txtTitle.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Name Title");
                    txtTitle.Focus();
                    return false;
                }
                if (txtFirstName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid First Name ");
                    txtFirstName.Focus();
                    return false;
                }
                if (txtLastName.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Last Name ");
                    txtLastName.Focus();
                    return false;
                }
                if (txtAddress.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Address ");
                    txtAddress.Focus();
                    return false;
                }
                if (txtContactNo.Text.Trim().Length == 0)
                {
                    ProjectFunctions.SpeakError("Invalid Contact No ");
                    txtContactNo.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
                return false;
            }
        }
        private void FrmAddressBook_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtGroupCode_EditValueChanged(object sender, EventArgs e)
        {
            txtGroupDesc.Text = String.Empty;
        }

        private void TxtGroupCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AddressBookGroupCode,AddressBookGroupDesc from AddressBookGroup", " Where AddressBookGroupCode", txtGroupCode, txtGroupDesc, txtTitle, HelpGrid, HelpGridView, e);
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
                if (HelpGrid.Text == "txtGroupCode")
                {
                    txtGroupCode.Text = row["AddressBookGroupCode"].ToString();
                    txtGroupDesc.Text = row["AddressBookGroupDesc"].ToString();
                    HelpGrid.Visible = false;
                    txtTitle.Focus();
                }
                if (HelpGrid.Text == "txtCityCode")
                {
                    txtCityCode.Text = row["CTSYSID"].ToString();
                    txtCityName.Text = row["CTNAME"].ToString();
                    txtState.Text = row["STNAME"].ToString();
                    txtCountry.Text = row["UNDERRG"].ToString();
                    HelpGrid.Visible = false;
                    txtCompany.Focus();
                }
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
                            sqlcom.CommandText = " Insert into ADDRESSBOOK"
                                                 + " (ADBGROUP,ADBNTITLE,ADBFIRSTNAME,ADBLASTNAME,ADBCONTNO,ADBCONTEMAILID,ADBCITY,"
                                                 + " ADBSTATE,ADBADDRESS,ADBADDRESS1,ADBADDRESS2,"
                                                 + " ADBADDRLNDMRK,ADBCOMPANY,ADBBY,ADBSYSDATE,ADBGroupCode)"
                                                 + " values(@ADBGROUP,@ADBNTITLE,@ADBFIRSTNAME,@ADBLASTNAME,@ADBCONTNO,@ADBCONTEMAILID,@ADBCITY,"
                                                 + " @ADBSTATE,@ADBADDRESS,@ADBADDRESS1,@ADBADDRESS2,"
                                                 + " @ADBADDRLNDMRK,@ADBCOMPANY,@ADBBY,@ADBSYSDATE,@ADBGroupCode)";


                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE ADDRESSBOOK SET "
                                                + " ADBGROUP=@ADBGROUP,ADBNTITLE=@ADBNTITLE,ADBFIRSTNAME=@ADBFIRSTNAME,ADBLASTNAME=@ADBLASTNAME,ADBCONTNO=@ADBCONTNO, "
                                                + " ADBCONTEMAILID=@ADBCONTEMAILID,ADBCITY=@ADBCITY,ADBSTATE=@ADBSTATE,ADBADDRESS=@ADBADDRESS, "
                                                + " ADBADDRESS1=@ADBADDRESS1,ADBADDRESS2=@ADBADDRESS2,ADBADDRLNDMRK=@ADBADDRLNDMRK,ADBCOMPANY=@ADBCOMPANY,ADBBY=@ADBBY, "
                                                + " ADBSYSDATE=@ADBSYSDATE,ADBGroupCode=@ADBGroupCode "
                                                + " Where ADBSYSID=@ADBSYSID";
                            sqlcom.Parameters.AddWithValue("@ADBSYSID", txtAddressBookCode.Text.Trim());
                        }

                        sqlcom.Parameters.AddWithValue("@ADBGROUP", txtGroupDesc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBNTITLE", txtTitle.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBFIRSTNAME", txtFirstName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBLASTNAME", txtLastName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBCONTNO", txtContactNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBCONTEMAILID", txtEmailId.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBCITY", txtCityCode.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@ADBSTATE", txtState.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBADDRESS", txtAddress.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBADDRESS1", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBADDRESS2", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBADDRLNDMRK", txtLandMark.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBCOMPANY", txtCompany.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ADBBY", GlobalVariables.CurrentUser);
                        sqlcom.Parameters.AddWithValue("@ADBSYSDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@ADBGroupCode", txtGroupCode.Text.Trim());

                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();

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

        private void TxtCityCode_EditValueChanged(object sender, EventArgs e)
        {
            txtCityName.Text = String.Empty;
            txtState.Text = String.Empty;
            txtCountry.Text = String.Empty;
        }

        private void TxtCityCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectFunctions.CreatePopUpForFourBoxes("SELECT        CITYMASTER.CTSYSID, CITYMASTER.CTNAME,STATEMASTER.STNAME,STATEMASTER.UNDERRG FROM CITYMASTER INNER JOIN STATEMASTER ON CITYMASTER.UNDERSTID = STATEMASTER.STSYSID", " Where CTSYSID", txtCityCode, txtCityName, txtState, txtCountry, txtCompany, HelpGrid, HelpGridView, e);
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError(ex.Message);
            }
        }
    }
}