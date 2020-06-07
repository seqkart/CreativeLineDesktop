using DevExpress.XtraEditors;
#pragma warning disable CS0105 // The using directive for 'System' appeared previously in this namespace
using System;

#pragma warning restore CS0105 // The using directive for 'System' appeared previously in this namespace

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmDealerMstAddEdit : XtraForm
    {
        public String s1 { get; set; }
        public String DealerCode { get; set; }
        public frmDealerMstAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.TextBoxVisualize(panelControl2);
            ProjectFunctions.TextBoxVisualize(panelControl1);
            ProjectFunctions.ButtonVisualize(this);
            ProjectFunctions.XtraFormVisualize(this);
        }
        private string GetNewDealerCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(DealerCode as int)),0000) from DealerMaster");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmDealerMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtStatusTag.Focus();
                txtDealerCode.Text = GetNewDealerCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtDName.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadDealerMstFEdit @DealerCode='" + DealerCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDealerCode.Text = ds.Tables[0].Rows[0]["dealerCode"].ToString();
                    txtDName.Text = ds.Tables[0].Rows[0]["dealerName"].ToString();
                    txtDStation.Text = ds.Tables[0].Rows[0]["dealerStation"].ToString();
                    txtDAddress1.Text = ds.Tables[0].Rows[0]["dealerAddress1"].ToString();
                    txtDAddress2.Text = ds.Tables[0].Rows[0]["dealerAddress2"].ToString();
                    txtDAddress3.Text = ds.Tables[0].Rows[0]["dealerAddress3"].ToString();
                    txtTelNo.Text = ds.Tables[0].Rows[0]["dealerTelNos"].ToString();
                    txtDPanCardNo.Text = ds.Tables[0].Rows[0]["dealerPanNo"].ToString();
                    txtContactPerson.Text = ds.Tables[0].Rows[0]["dealerContactPerson"].ToString();
                    txtDLCTag.Text = ds.Tables[0].Rows[0]["dealerTagLC"].ToString();
                    txtStatusTag.Text = ds.Tables[0].Rows[0]["dealerActive"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["DealerEmail"].ToString();
                    txtDBAccountNo.Text = ds.Tables[0].Rows[0]["DealerBankAcc"].ToString();
                    txtDBName.Text = ds.Tables[0].Rows[0]["DealerBank"].ToString();
                    txtDRtgs.Text = ds.Tables[0].Rows[0]["DealerRTGSCode"].ToString();
                    txtRouteCode.Text = ds.Tables[0].Rows[0]["DealerRouteCd"].ToString();
                    txtRouteName.Text = ds.Tables[0].Rows[0]["RouteDesc"].ToString();
                    txtCityCodeNew.Text = ds.Tables[0].Rows[0]["CityCode"].ToString();
                    txtDistCodeNew.Text = ds.Tables[0].Rows[0]["DistCode"].ToString();
                    txtStateCodeNew.Text = ds.Tables[0].Rows[0]["StateCode"].ToString();
                    txtCityDescNew.Text = ds.Tables[0].Rows[0]["CityDesc"].ToString();
                    txtDistDescNew.Text = ds.Tables[0].Rows[0]["DistDesc"].ToString();
                    txtStateDescNew.Text = ds.Tables[0].Rows[0]["StateDesc"].ToString();
                    txtFLNo.Text = ds.Tables[0].Rows[0]["DealerFSSAI"].ToString();
                    txtBAName.Text = ds.Tables[0].Rows[0]["DealerNameAsInBank"].ToString();
                    txtStatusTag.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtDealerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Code");
                txtDealerCode.Focus();
                return false;
            }
            if (txtCityCodeNew.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid City Code");
                txtCityCodeNew.Focus();
                return false;
            }
            if (txtCityDescNew.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid City Code");
                txtCityCodeNew.Focus();
                return false;
            }
            if (txtDName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer Desc");
                txtDName.Focus();
                return false;
            }
            if (txtRouteCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route Code");
                txtRouteCode.Focus();
                return false;
            }
            if (txtRouteName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Route Code");
                txtRouteCode.Focus();
                return false;
            }
            if (txtDLCTag.Text == "L" || txtDLCTag.Text == "C")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Local(L),Central(C)");
                txtDLCTag.Focus();
                return false;
            }
            return true;
        }
        private void frmDealerMstAddEdit_KeyDown(object sender, KeyEventArgs e)
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

        private void HelpGrid_DoubleClick(object sender, System.EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtRouteCode")
            {
                txtRouteCode.Text = row["RouteCode"].ToString();
                txtRouteName.Text = row["RouteDesc"].ToString();
                HelpGrid.Visible = false;
                txtTelNo.Focus();
            }
            if (HelpGrid.Text == "txtCityCodeNew")
            {
                txtCityCodeNew.Text = row["CityCode"].ToString();
                txtCityDescNew.Text = row["CityDesc"].ToString();
                txtStateCodeNew.Text = row["StateCode"].ToString();
                txtStateDescNew.Text = row["StateDesc"].ToString();
                txtDistCodeNew.Text = row["DistCode"].ToString();
                txtDistDescNew.Text = row["DistDesc"].ToString();
                HelpGrid.Visible = false;
            }
        }

        private void txtRouteCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select RouteCode,RouteDesc from RouteMst", " Where RouteCode", txtRouteCode, txtRouteName, txtTelNo, HelpGrid, HelpGridView, e);
            }
            e.Handled = true;
        }

        private void txtCityCodeNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "txtCityCodeNew";
                DataSet ds = ProjectFunctions.GetDataSet("Select StateCode,DistCode,CityCode,StateDesc,DistDesc,CityDesc from StateMst");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGrid.Visible = true;
                    HelpGrid.Focus();
                    HelpGridView.BestFitColumns();
                }
                else
                {
                    ProjectFunctions.SpeakError("No Records To Display");
                }
            }
            e.Handled = true;
        }

        private void txtRouteCode_EditValueChanged(object sender, System.EventArgs e)
        {
            txtRouteName.Text = string.Empty;
        }

        private void txtCityCodeNew_EditValueChanged(object sender, System.EventArgs e)
        {
            txtStateCodeNew.Text = string.Empty;
            txtStateDescNew.Text = string.Empty;
            txtDistCodeNew.Text = string.Empty;
            txtDistDescNew.Text = string.Empty;
            txtCityDescNew.Text = string.Empty;
        }

        private void btnQuit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
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
                                                    + " Insert into dealerMaster"
                                                    + " (dealerCode,dealerName,dealerStation,dealerAddress1,dealerAddress2,dealerAddress3,dealerTelNos,dealerPanNo,"
                                                    + " dealerContactPerson,dealerTagLC,dealerActive,DealerEmail,DealerBank,DealerRTGSCode,DealerFSSAI,DealerRouteCd,"
                                                    + " DealerStateCd,DealerDistCd,DealerCityCd,DealerNameAsInBank,DealerBankAcc)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(dealerCode as int)),0)+1 AS VARCHAR(4)),4)from dealerMaster),@dealerName,@dealerStation,@dealerAddress1,@dealerAddress2,@dealerAddress3,@dealerTelNos,@dealerPanNo,"
                                                    + " @dealerContactPerson,@dealerTagLC,@dealerActive,@DealerEmail,@DealerBank,@DealerRTGSCode,@DealerFSSAI,@DealerRouteCd,"
                                                    + " @DealerStateCd,@DealerDistCd,@DealerCityCd,@DealerNameAsInBank.@DealerBankAcc)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE dealerMaster SET "
                                                + " dealerStation=@dealerStation,dealerAddress1=@dealerAddress1,dealerAddress2=@dealerAddress2,dealerAddress3=@dealerAddress3, "
                                                + " dealerTelNos=@dealerTelNos,dealerPanNo=@dealerPanNo,dealerContactPerson=@dealerContactPerson,dealerTagLC=@dealerTagLC, "
                                                + " dealerActive=@dealerActive,DealerEmail=@DealerEmail,DealerBank=@DealerBank,DealerRTGSCode=@DealerRTGSCode,DealerFSSAI=@DealerFSSAI, "
                                                + " DealerRouteCd=@DealerRouteCd,DealerStateCd=@DealerStateCd,DealerDistCd=@DealerDistCd,DealerCityCd=@DealerCityCd,DealerNameAsInBank=@DealerNameAsInBank,DealerBankAcc=@DealerBankAcc "
                                                + " Where dealerCode=@dealerCode";
                        }
                        sqlcom.Parameters.AddWithValue("@dealerCode", txtDealerCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerName", txtDName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerStation", txtDStation.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerAddress1", txtDAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerAddress2", txtDAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerAddress3", txtDAddress3.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerTelNos", txtTelNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerPanNo", txtDPanCardNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerContactPerson", txtContactPerson.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerTagLC", txtDLCTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@dealerActive", txtStatusTag.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerEmail", txtEmailId.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerBank", txtDBName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerRTGSCode", txtDRtgs.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerFSSAI", txtFLNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerRouteCd", txtRouteCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerStateCd", txtStateCodeNew.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerDistCd", txtDistCodeNew.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerCityCd", txtCityCodeNew.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerNameAsInBank", txtBAName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DealerBankAcc", txtDBAccountNo.Text.Trim());
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

        private void txtDLCTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtDLCTag.Text == "L" || txtDLCTag.Text == "C")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Local(L),Central(C)");
                txtDLCTag.Focus();
            }
        }

        private void txtStatusTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtStatusTag.Text == "Y" || txtStatusTag.Text == "N")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Y,N");
                txtStatusTag.Focus();
            }
        }
    }
}