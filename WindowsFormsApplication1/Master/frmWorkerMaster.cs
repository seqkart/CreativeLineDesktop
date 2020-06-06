using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmWorkerMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String WRKSYSID { get; set; }
        public frmWorkerMaster()
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
            txtWorkerCode.Properties.MaxLength = 150;
            txtWorkerName.Properties.MaxLength = 32;
            txtContractorCode.Properties.MaxLength = 150;
            txtContractorDesc.Properties.MaxLength = 55;
            txtFloorCode.Properties.MaxLength = 5;
            txtIDNo.Properties.MaxLength = 25;
            txtIDType.Properties.MaxLength = 32;
            txtMobileNo.Properties.MaxLength = 12;
            txtOtherNo.Properties.MaxLength = 12;
            txtEMailId.Properties.MaxLength = 55;
            txtWorkerCode.Enabled = false;

        }
        private void FrmWorkerMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtContractorCode.Focus();
            }
            if (s1 == "Edit")
            {
                txtWorkerCode.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadWorkerMstFEdit '" + WRKSYSID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtContractorCode.Text = ds.Tables[0].Rows[0]["WRKCONTID"].ToString();
                    txtContractorDesc.Text = ds.Tables[0].Rows[0]["CNTNAME"].ToString();
                    txtWorkerCode.Text = ds.Tables[0].Rows[0]["WRKSYSID"].ToString();
                    txtWorkerName.Text = ds.Tables[0].Rows[0]["WRKNAME"].ToString();
                    txtFloorCode.Text = ds.Tables[0].Rows[0]["WRKFLOORID"].ToString();
                    txtEMailId.Text = ds.Tables[0].Rows[0]["WRKEMAILID"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["WRKMOBNO"].ToString();
                    txtOtherNo.Text = ds.Tables[0].Rows[0]["WRKALTMOBNO"].ToString();
                    txtIDType.Text = ds.Tables[0].Rows[0]["WRKIDTYPE"].ToString();
                    txtIDNo.Text = ds.Tables[0].Rows[0]["WRKIDNO"].ToString();

                }
                txtContractorCode.Focus();
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private bool ValidateData()
        {
            if (txtContractorCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Contractor");
                txtContractorCode.Focus();
                return false;
            }
            if (txtContractorDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Contractor");
                txtContractorDesc.Focus();
                return false;
            }

            if (txtWorkerName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Worker Name");
                txtWorkerName.Focus();
                return false;
            }
            if (txtMobileNo.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Mobile No ");
                txtMobileNo.Focus();
                return false;
            }
            if (txtIDType.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Id Type ");
                txtIDType.Focus();
                return false;
            }

            return true;
        }

        private void TxtContractorCode_EditValueChanged(object sender, EventArgs e)
        {
            txtContractorDesc.Text = String.Empty;
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtContractorCode")
            {
                txtContractorCode.Text = row["CNTSYSID"].ToString();
                txtContractorDesc.Text = row["CNTNAME"].ToString();
                HelpGrid.Visible = false;
                txtWorkerName.Focus();
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
                            sqlcom.CommandText = " Insert into WORKER"
                                                 + " (WRKCONTID,WRKNAME, WRKFLOORID,"
                                                 + "WRKMOBNO, WRKALTMOBNO, WRKEMAILID, WRKIDTYPE, WRKIDNO)"
                                                 + " values(@WRKCONTID,@WRKNAME, @WRKFLOORID,"
                                                 + "@WRKMOBNO, @WRKALTMOBNO, @WRKEMAILID, @WRKIDTYPE, @WRKIDNO)";



                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE WORKER SET "
                                                + " WRKCONTID=@WRKCONTID,WRKNAME=@WRKNAME,WRKFLOORID=@WRKFLOORID,WRKMOBNO=@WRKMOBNO,WRKALTMOBNO=@WRKALTMOBNO, "
                                                + " WRKEMAILID=@WRKEMAILID,WRKIDTYPE=@WRKIDTYPE,WRKIDNO=@WRKIDNO "
                                                + " Where WRKSYSID=@WRKSYSID";
                            sqlcom.Parameters.AddWithValue("@WRKSYSID", txtWorkerCode.Text.Trim());
                        }

                        sqlcom.Parameters.AddWithValue("@WRKCONTID", txtContractorCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@WRKNAME", txtWorkerName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@WRKFLOORID", txtFloorCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@WRKMOBNO", txtMobileNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@WRKALTMOBNO", txtOtherNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@WRKEMAILID", txtEMailId.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@WRKIDTYPE", txtIDType.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@WRKIDNO", txtIDNo.Text.Trim());


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

        private void FrmWorkerMaster_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtContractorCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select CNTSYSID,CNTNAME from CONTRACTOR", " Where CNTSYSID", txtContractorCode, txtContractorDesc, txtWorkerName, HelpGrid, HelpGridView, e);
        }
    }
}