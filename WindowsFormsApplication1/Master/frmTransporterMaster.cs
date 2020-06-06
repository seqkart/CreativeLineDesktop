using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmTransporterMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String TRPRSYSID { get; set; }
        public frmTransporterMaster()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtTransporterName.Properties.MaxLength = 155;
            txtAddress1.Properties.MaxLength = 255;
            txtAddress2.Properties.MaxLength = 255;
            txtCityCode.Properties.MaxLength = 32;
            txtState.Properties.MaxLength = 32;
            txtContactPerson.Properties.MaxLength = 32;
            txtEmailId.Properties.MaxLength = 55;
            txtWebSite.Properties.MaxLength = 55;
            txtLandlineNo.Properties.MaxLength = 12;
            txtMobileNo.Properties.MaxLength = 12;
            txtTransporterCode.Enabled = false;

        }
        private void FrmTransporterMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtTransporterName.Focus();
            }
            if (s1 == "Edit")
            {
                txtTransporterCode.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadTransporterMstEFdit '" + TRPRSYSID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTransporterCode.Text = ds.Tables[0].Rows[0]["TRPRSYSID"].ToString();
                    txtTransporterName.Text = ds.Tables[0].Rows[0]["TRPRNAME"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["TRPRADD"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["TRPRADD1"].ToString();
                    txtCityCode.Text = ds.Tables[0].Rows[0]["TRPRCITY"].ToString();
                    txtCityName.Text = ds.Tables[0].Rows[0]["CTNAME"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["STNAME"].ToString();
                    txtCountry.Text = ds.Tables[0].Rows[0]["UNDERRG"].ToString();
                    txtContactPerson.Text = ds.Tables[0].Rows[0]["TRPRCONTPRSN"].ToString();
                    txtLandlineNo.Text = ds.Tables[0].Rows[0]["TRPRLANDLINO"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["TRPRMOBNO"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["TRPREMAILID"].ToString();
                    txtWebSite.Text = ds.Tables[0].Rows[0]["TRPRWEBSITE"].ToString();

                }
                txtTransporterName.Focus();
            }
        }
        private bool ValidateData()
        {
            if (txtTransporterName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Transporter Name");
                txtTransporterName.Focus();
                return false;
            }
            if (txtAddress2.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid x Address");
                txtAddress2.Focus();
                return false;
            }

            if (txtContactPerson.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Transporter Contact Person");
                txtContactPerson.Focus();
                return false;
            }
            if (txtMobileNo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Transporter Mobile No");
                txtMobileNo.Focus();
                return false;
            }
            if (txtCityCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Transporter City");
                txtCityCode.Focus();
                return false;
            }
            if (txtState.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Transporter State");
                txtState.Focus();
                return false;
            }

            return true;
        }
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTransporterMaster_KeyDown(object sender, KeyEventArgs e)
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
                            sqlcom.CommandText = " Insert into TRANSPORTMASTER"
                                                 + " (TRPRNAME,TRPRADD, TRPRADD1, TRPRCITY, TRPRSTATE,"
                                                 + " TRPRCONTPRSN, TRPRLANDLINO, TRPRMOBNO, TRPREMAILID, TRPRWEBSITE)"
                                                 + " values(@TRPRNAME,@TRPRADD, @TRPRADD1, @TRPRCITY, @TRPRSTATE,"
                                                 + " @TRPRCONTPRSN, @TRPRLANDLINO, @TRPRMOBNO, @TRPREMAILID, @TRPRWEBSITE)";


                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE TRANSPORTMASTER SET "
                                                + " TRPRNAME=@TRPRNAME,TRPRADD=@TRPRADD,TRPRADD1=@TRPRADD1,TRPRCITY=@TRPRCITY,TRPRSTATE=@TRPRSTATE, "
                                                + " TRPRCONTPRSN=@TRPRCONTPRSN,TRPRLANDLINO=@TRPRLANDLINO,TRPRMOBNO=@TRPRMOBNO,TRPREMAILID=@TRPREMAILID, "
                                                + " TRPRWEBSITE=@TRPRWEBSITE"
                                                + " Where TRPRSYSID=@TRPRSYSID";
                            sqlcom.Parameters.AddWithValue("@TRPRSYSID", txtTransporterCode.Text.Trim());
                        }

                        sqlcom.Parameters.AddWithValue("@TRPRNAME", txtTransporterName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRADD", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRADD1", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRCITY", txtCityCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRSTATE", txtState.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRCONTPRSN", txtContactPerson.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRLANDLINO", txtLandlineNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRMOBNO", txtMobileNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPREMAILID", txtEmailId.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TRPRWEBSITE", txtWebSite.Text.Trim());

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

        private void TxtCity_EditValueChanged(object sender, EventArgs e)
        {
            txtCityName.Text = String.Empty;
            txtState.Text = String.Empty;
            txtCountry.Text = String.Empty;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtContactPerson_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void TxtCityCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForFourBoxes("SELECT        CITYMASTER.CTSYSID, CITYMASTER.CTNAME,STATEMASTER.STNAME,STATEMASTER.UNDERRG FROM CITYMASTER INNER JOIN STATEMASTER ON CITYMASTER.UNDERSTID = STATEMASTER.STSYSID", " Where CTSYSID", txtCityCode, txtCityName, txtState, txtCountry, txtContactPerson, HelpGrid, HelpGridView, e);
        }

        private void HelpGrid_Click(object sender, EventArgs e)
        {

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
            if (HelpGrid.Text == "txtCityCode")
            {
                txtCityCode.Text = row["CTSYSID"].ToString();
                txtCityName.Text = row["CTNAME"].ToString();
                txtState.Text = row["STNAME"].ToString();
                txtCountry.Text = row["UNDERRG"].ToString();
                HelpGrid.Visible = false;
                txtContactPerson.Focus();
            }

        }
    }
}