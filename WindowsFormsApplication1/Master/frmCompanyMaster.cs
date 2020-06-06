using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmCompanyMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String COMSYSID { get; set; }
        public frmCompanyMaster()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtCmpName.Properties.MaxLength = 55;
            txtCmpAddress.Properties.MaxLength = 55;
            txtCmpAddress1.Properties.MaxLength = 55;
            txtCmpAddress2.Properties.MaxLength = 55;
            txtCmpCity.Properties.MaxLength = 55;
            txtCmpState.Properties.MaxLength = 55;
            txtCmpZip.Properties.MaxLength = 55;
            txtCmpPhoneNo.Properties.MaxLength = 55;
            txtMobile.Properties.MaxLength = 55;
            txtAlternateNo.Properties.MaxLength = 55;
            txtEmailId.Properties.MaxLength = 55;
            txtWebsite.Properties.MaxLength = 55;
            txtCINNo.Properties.MaxLength = 55;
            txtPanNo.Properties.MaxLength = 55;
            txtGSTNo.Properties.MaxLength = 55;
            txtTanNo.Properties.MaxLength = 55;
            txtCSTNo.Properties.MaxLength = 55;
            txtTinNo.Properties.MaxLength = 55;
            txtWard.Properties.MaxLength = 55;
            txtExxiseNo.Properties.MaxLength = 55;
            txtDivission.Properties.MaxLength = 55;
            txtDivState.Properties.MaxLength = 55;
            txtDivCity.Properties.MaxLength = 55;
            txtDivAddress.Properties.MaxLength = 55;
            txtCurrencyCharacter.Properties.MaxLength = 55;
            txtCurrencyString.Properties.MaxLength = 55;
            txtCurrencySubstring.Properties.MaxLength = 55;
            txtCurrencySymbol.Properties.MaxLength = 55;
            txtAlternateNo.Properties.MaxLength = 55;
            txtAlternateNo.Properties.MaxLength = 55;
            txtFont.Properties.MaxLength = 15;
            txtCmpCode.Enabled = false;
        }

        private bool ValidateData()
        {
            if (txtCmpName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Company Name");
                txtCmpName.Focus();
                return false;
            }
            if (txtCmpAddress.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Address");
                txtCmpAddress.Focus();
                return false;
            }
            if (txtCmpState.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid State");
                txtCmpState.Focus();
                return false;
            }
            if (txtCmpCity.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid City");
                txtCmpCity.Focus();
                return false;
            }
            if (txtCmpZip.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Zip");
                txtCmpZip.Focus();
                return false;
            }


            return true;
        }
        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtCmpType.Focus();
            }
            if (s1 == "Edit")
            {
                DataSet ds = ProjectFunctions.GetDataSet("SELECT * FROM COMCONF Where COMSYSID='" + COMSYSID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAlternateNo.Text = ds.Tables[0].Rows[0]["COMALTMOB"].ToString();
                    txtCINNo.Text = ds.Tables[0].Rows[0]["COMCIN"].ToString();
                    txtCmpAddress.Text = ds.Tables[0].Rows[0]["COMADD"].ToString();
                    txtCmpAddress1.Text = ds.Tables[0].Rows[0]["COMADD1"].ToString();
                    txtCmpAddress2.Text = ds.Tables[0].Rows[0]["COMADD2"].ToString();
                    txtCmpCity.Text = ds.Tables[0].Rows[0]["COMCITY"].ToString();
                    txtCmpCode.Text = ds.Tables[0].Rows[0]["COMSYSID"].ToString();
                    txtCmpName.Text = ds.Tables[0].Rows[0]["COMNAME"].ToString();
                    txtCmpPhoneNo.Text = ds.Tables[0].Rows[0]["COMPHONE"].ToString();
                    txtCmpState.Text = ds.Tables[0].Rows[0]["COMSTATE"].ToString();
                    txtCmpType.Text = ds.Tables[0].Rows[0]["COMTYPE"].ToString();
                    txtCmpZip.Text = ds.Tables[0].Rows[0]["COMZIP"].ToString();

                    if (ds.Tables[0].Rows[0]["COMCSTDT"].ToString().Trim() != string.Empty)
                    {
                        txtCSTIssueDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["COMCSTDT"]);
                    }

                    txtCSTNo.Text = ds.Tables[0].Rows[0]["COMCST"].ToString();
                    txtCurrencyCharacter.Text = ds.Tables[0].Rows[0]["COMCURCHAR"].ToString();
                    txtCurrencyString.Text = ds.Tables[0].Rows[0]["COMCURSTRING"].ToString();
                    txtCurrencySubstring.Text = ds.Tables[0].Rows[0]["COMCURSBSTRING"].ToString();
                    txtCurrencySymbol.Text = ds.Tables[0].Rows[0]["COMCURSYMB"].ToString();
                    txtDivAddress.Text = ds.Tables[0].Rows[0]["COMEXSDIVADD"].ToString();
                    txtDivCity.Text = ds.Tables[0].Rows[0]["COMEXSDIVCITY"].ToString();
                    txtDivission.Text = ds.Tables[0].Rows[0]["COMEXSDIV"].ToString();
                    txtDivState.Text = ds.Tables[0].Rows[0]["COMEXSDIVSTATE"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["COMEID"].ToString();
                    txtExxiseNo.Text = ds.Tables[0].Rows[0]["COMEXSNO"].ToString();
                    txtFont.Text = ds.Tables[0].Rows[0]["COMCURFONT"].ToString();
                    if (ds.Tables[0].Rows[0]["COMGSTDT"].ToString().Trim() != string.Empty)
                    {
                        txtGSTIssueDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["COMGSTDT"]);
                    }

                    txtGSTNo.Text = ds.Tables[0].Rows[0]["COMGST"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["COMMOB"].ToString();
                    txtPanNo.Text = ds.Tables[0].Rows[0]["COMPAN"].ToString();
                    txtTanNo.Text = ds.Tables[0].Rows[0]["COMTAN"].ToString();
                    txtTinNo.Text = ds.Tables[0].Rows[0]["COMTIN"].ToString();
                    txtWard.Text = ds.Tables[0].Rows[0]["COMPANWARD"].ToString();
                    txtWebsite.Text = ds.Tables[0].Rows[0]["COMWEBSITE"].ToString();

                    txtCmpType.Focus();
                }
            }
        }

        private void Label18_Click(object sender, EventArgs e)
        {

        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                            sqlcom.CommandText = " Insert into COMCONF"
                                                    + " (COMTYPE,COMNAME,COMADD,COMADD1,COMADD2,COMCITY,COMSTATE,COMZIP,COMPHONE,"
                                                    + " COMMOB,COMALTMOB,COMEID,COMWEBSITE,COMTIN,COMCST,COMCSTDT,COMCIN,COMPAN,"
                                                     + "COMPANWARD,COMTAN,COMGST,COMGSTDT,COMEXSNO,COMEXSDIV,COMEXSDIVADD,COMEXSDIVCITY,"
                                                     + "COMEXSDIVSTATE,COMCURSYMB,COMCURSTRING,COMCURSBSTRING,COMCURFONT,COMCURCHAR )values("
                                                     + "@COMTYPE,@COMNAME,@COMADD,@COMADD1,@COMADD2,@COMCITY,@COMSTATE,@COMZIP,@COMPHONE,"
                                                    + " @COMMOB,@COMALTMOB,@COMEID,@COMWEBSITE,@COMTIN,@COMCST,@COMCSTDT,@COMCIN,@COMPAN,"
                                                     + "@COMPANWARD,@COMTAN,@COMGST,@COMGSTDT,@COMEXSNO,@COMEXSDIV,@COMEXSDIVADD,@COMEXSDIVCITY,"
                                                     + "@COMEXSDIVSTATE,@COMCURSYMB,@COMCURSTRING,@COMCURSBSTRING,@COMCURFONT,@COMCURCHAR)";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE COMCONF SET "
                                                + " COMTYPE=@COMTYPE,COMNAME=@COMNAME,COMADD=@COMADD,COMADD1=@COMADD1,COMADD2=@COMADD2,COMCITY=@COMCITY,COMSTATE=@COMSTATE,COMZIP=@COMZIP,COMPHONE=@COMPHONE,"
                                                    + " COMMOB=@COMMOB,COMALTMOB=@COMALTMOB,COMEID=@COMEID,COMWEBSITE=@COMWEBSITE,COMTIN=@COMTIN,COMCST=@COMCST,COMCSTDT=@COMCSTDT,COMCIN=@COMCIN,COMPAN=@COMPAN,"
                                                     + "COMPANWARD=@COMPANWARD,COMTAN=@COMTAN,COMGST=@COMGST,COMGSTDT=@COMGSTDT,COMEXSNO=@COMEXSNO,COMEXSDIV=@COMEXSDIV,COMEXSDIVADD=@COMEXSDIVADD,COMEXSDIVCITY=@COMEXSDIVCITY,"
                                                     + "COMEXSDIVSTATE=@COMEXSDIVSTATE,COMCURSYMB=@COMCURSYMB,COMCURSTRING=@COMCURSTRING,COMCURSBSTRING=@COMCURSBSTRING,COMCURFONT=@COMCURFONT,COMCURCHAR=@COMCURCHAR"
                                                + " Where COMSYSID=@COMSYSID";
                            sqlcom.Parameters.AddWithValue("@COMSYSID", txtCmpCode.Text.Trim());
                        }
                        sqlcom.Parameters.AddWithValue("@COMTYPE", txtCmpType.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMNAME", txtCmpName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMADD", txtCmpAddress.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMADD1", txtCmpAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMADD2", txtCmpAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMCITY", txtCmpCity.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMSTATE", txtCmpState.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMZIP", txtCmpZip.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMPHONE", txtCmpPhoneNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMMOB", txtMobile.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMALTMOB", txtAlternateNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMEID", txtEmailId.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMWEBSITE", txtWebsite.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMTIN", txtTinNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMCST", txtCSTNo.Text.Trim());
                        if (txtCSTIssueDate.Text.Trim().Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@COMCSTDT", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@COMCSTDT", Convert.ToDateTime(txtCSTIssueDate.Text).ToString("yyyy-MM-dd"));
                        }

                        sqlcom.Parameters.AddWithValue("@COMCIN", txtCINNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMPAN", txtPanNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMPANWARD", txtWard.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMTAN", txtTanNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMGST", txtGSTNo.Text.Trim());
                        if (txtGSTIssueDate.Text.Trim().Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@COMGSTDT", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@COMGSTDT", Convert.ToDateTime(txtGSTIssueDate.Text).ToString("yyyy-MM-dd"));
                        }

                        sqlcom.Parameters.AddWithValue("@COMEXSNO", txtExxiseNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMEXSDIV", txtDivission.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMEXSDIVADD", txtDivAddress.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMEXSDIVCITY", txtDivCity.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMEXSDIVSTATE", txtDivState.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMCURSYMB", txtCurrencySymbol.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMCURSTRING", txtCurrencyString.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMCURSBSTRING", txtCurrencySubstring.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMCURFONT", txtFont.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@COMCURCHAR", txtCurrencyCharacter.Text.Trim());

                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Company Created Successfully");
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

        private void FrmCompanyMaster_KeyDown(object sender, KeyEventArgs e)
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
    }
}