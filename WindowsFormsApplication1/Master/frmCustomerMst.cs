using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmCustomerMst : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String CAFSYSID { get; set; }
        public String CustMobileNo { get; set; }
        public frmCustomerMst()
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
            txtAddress1.Properties.MaxLength = 155;
            txtAddress2.Properties.MaxLength = 155;
            txtAddress3.Properties.MaxLength = 155;
            txtCity.Properties.MaxLength = 32;
            txtDiscountType.Properties.MaxLength = 155;
            txtEmail.Properties.MaxLength = 55;
            txtFirstName.Properties.MaxLength = 20;
            txtLoyaltyCardNo.Properties.MaxLength = 55;
            txtMiddleName.Properties.MaxLength = 20;
            txtMobileNo.Properties.MaxLength = 25;
            txtRefBy.Properties.MaxLength = 55;
            txtState.Properties.MaxLength = 32;
            txtSurName.Properties.MaxLength = 20;

            txtCustId.Enabled = false;
        }
        private void FrmCustomerMst_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtFirstName.Focus();
                txtMobileNo.Text = CustMobileNo;
            }
            if (s1 == "Edit")
            {
                txtCustId.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("Select * from CAFINFO Where CAFSYSID= '" + CAFSYSID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAddress1.Text = ds.Tables[0].Rows[0]["CAFADD"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["CAFADD1"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["CAFADD2"].ToString();
                    txtCardExpiryDate.Text = ds.Tables[0].Rows[0]["CAFCARDEXPIRYDT"].ToString();
                    txtCardIssueDate.Text = ds.Tables[0].Rows[0]["CAFCARDISSUEDT"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["CAFCITY"].ToString();
                    txtCustId.Text = ds.Tables[0].Rows[0]["CAFSYSID"].ToString();
                    txtDatefBirth.Text = ds.Tables[0].Rows[0]["CAFDOB"].ToString();
                    txtDiscountType.Text = ds.Tables[0].Rows[0]["CAFDISCTYPE"].ToString();
                    txtDuringEOSS.Text = ds.Tables[0].Rows[0]["CAFEOSSDISC"].ToString();
                    txtDuringNormalSale.Text = ds.Tables[0].Rows[0]["CAFNORMSDISC"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["CAFEMAILID"].ToString();
                    txtFirstName.Text = ds.Tables[0].Rows[0]["CAFFNAME"].ToString();
                    txtLoyaltyCardNo.Text = ds.Tables[0].Rows[0]["CAFCARDNO"].ToString();
                    txtMiddleName.Text = ds.Tables[0].Rows[0]["CAFMNAME"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["CAFMOBILE"].ToString();
                    txtRefBy.Text = ds.Tables[0].Rows[0]["CAFREFERBY"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["CAFSTATE"].ToString();
                    txtSurName.Text = ds.Tables[0].Rows[0]["CAFLNAME"].ToString();
                }
                txtFirstName.Focus();
            }
        }
        private bool ValidateData()
        {
            if (txtFirstName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Customer First Name");
                txtFirstName.Focus();
                return false;
            }
            if (txtSurName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Customer Sur Name");
                txtSurName.Focus();
                return false;
            }
            //if (txtAddress1.Text.Trim().Length == 0)
            //{
            //    ProjectFunctions.SpeakError("Invalid Customer Address");
            //    txtAddress1.Focus();
            //    return false;
            //}
            if (txtState.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Customer State");
                txtState.Focus();
                return false;
            }
            if (txtCity.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Customer Address");
                txtCity.Focus();
                return false;
            }
            //if (txtDatefBirth.Text.Trim().Length == 0)
            //{
            //    ProjectFunctions.SpeakError("Invalid Customer Date Of Birth");
            //    txtDatefBirth.Focus();
            //    return false;
            //}
            if (txtDuringNormalSale.Text.Length == 0)
            {
                txtDuringNormalSale.Text = "0";
            }
            if (txtDuringEOSS.Text.Length == 0)
            {
                txtDuringEOSS.Text = "0";
            }

            return true;
        }
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCustomerMst_KeyDown(object sender, KeyEventArgs e)
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
                            sqlcom.CommandText = " Insert into CAFINFO"
                                                 + " (CAFMOBILE, CAFFNAME, CAFMNAME, CAFLNAME, CAFREFERBY, CAFADD, CAFADD1, CAFADD2, CAFCITY, "
                                               + "CAFSTATE, CAFEMAILID, CAFDOB, CAFDOA, CAFCARDNO, CAFCARDISSUEDT, CAFCARDEXPIRYDT,CAFNORMSDISC, "
                                              + "CAFEOSSDISC, CAFDISCTYPE)"

                                                 + " values(@CAFMOBILE, @CAFFNAME, @CAFMNAME, @CAFLNAME, @CAFREFERBY, @CAFADD, @CAFADD1, @CAFADD2, @CAFCITY, "
                                               + "@CAFSTATE, @CAFEMAILID, @CAFDOB, @CAFDOA, @CAFCARDNO, @CAFCARDISSUEDT, @CAFCARDEXPIRYDT,@CAFNORMSDISC, "
                                              + "@CAFEOSSDISC, @CAFDISCTYPE)";


                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE CAFINFO SET "
                                                + " CAFMOBILE=@CAFMOBILE,CAFFNAME=@CAFFNAME,CAFMNAME=@CAFMNAME,CAFLNAME=@CAFLNAME, "
                                                + " CAFREFERBY=@CAFREFERBY,CAFADD=@CAFADD,CAFADD1=@CAFADD1,CAFADD2=@CAFADD2, "
                                                + " CAFCITY=@CAFCITY,CAFSTATE=@CAFSTATE,CAFEMAILID=@CAFEMAILID,CAFDOB=@CAFDOB,CAFDOA=@CAFDOA, "
                                                + " CAFCARDNO=@CAFCARDNO,CAFCARDISSUEDT=@CAFCARDISSUEDT,CAFCARDEXPIRYDT=@CAFCARDEXPIRYDT,CAFNORMSDISC=@CAFNORMSDISC,CAFEOSSDISC=@CAFEOSSDISC,CAFDISCTYPE=@CAFDISCTYPE "
                                                + " Where CAFSYSID=@CAFSYSID";
                            sqlcom.Parameters.AddWithValue("@CAFSYSID", txtCustId.Text.Trim());
                        }
                        sqlcom.Parameters.AddWithValue("@CAFMOBILE", txtMobileNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFFNAME", txtFirstName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFMNAME", txtMiddleName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFLNAME", txtSurName.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFREFERBY", txtRefBy.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFADD", txtAddress1.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@CAFADD1", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFADD2", txtAddress3.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFCITY", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFSTATE", txtState.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@CAFEMAILID", txtEmail.Text.Trim());
                        if (txtDatefBirth.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@CAFDOB", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@CAFDOB", Convert.ToDateTime(txtDatefBirth.Text).ToString("yyyy-MM-dd"));
                        }

                        sqlcom.Parameters.AddWithValue("@CAFDOA", DateTime.Now.ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@CAFCARDNO", txtLoyaltyCardNo.Text.Trim());


                        if (txtCardIssueDate.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@CAFCARDISSUEDT", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@CAFCARDISSUEDT", Convert.ToDateTime(txtCardIssueDate.Text).ToString("yyyy-MM-dd"));
                        }
                        if (txtCardExpiryDate.Text.Length == 0)
                        {
                            sqlcom.Parameters.AddWithValue("@CAFCARDEXPIRYDT", System.Data.SqlTypes.SqlDateTime.Null);
                        }
                        else
                        {
                            sqlcom.Parameters.AddWithValue("@CAFCARDEXPIRYDT", Convert.ToDateTime(txtCardExpiryDate.Text).ToString("yyyy-MM-dd"));
                        }

                        sqlcom.Parameters.AddWithValue("@CAFNORMSDISC", Convert.ToDecimal(txtDuringNormalSale.Text));
                        sqlcom.Parameters.AddWithValue("@CAFEOSSDISC", Convert.ToDecimal(txtDuringEOSS.Text));
                        sqlcom.Parameters.AddWithValue("@CAFDISCTYPE", txtDiscountType.Text.Trim());

                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        GlobalVariables.GlobalCustWindowCount = 1;
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
    }
}