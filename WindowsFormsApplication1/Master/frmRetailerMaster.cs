using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Master
{
    public partial class frmRetailerMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String RCode { get; set; }

        public frmRetailerMaster()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtSCode.Enabled = false;
        }
        private string GetNewCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(RCode as int)),000000) from RetailerMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private bool ValidateData()
        {
            if (txtSCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Retailer");
                txtSCode.Focus();
                return false;
            }
            if (txtSName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Retailer");
                txtSName.Focus();
                return false;
            }
            if (txtDealerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Supplier");
                txtDealerCode.Focus();
                return false;
            }
            if (txtDealerName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Supplier");
                txtDealerCode.Focus();
                return false;
            }

            return true;
        }

        private void frmRetailerMaster_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtSName.Focus();
                txtSCode.Text = GetNewCode().PadLeft(6, '0');
            }
            if (s1 == "Edit")
            {
                txtSName.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadRetailerMstFEdit @RCode='" + RCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSCode.Text = ds.Tables[0].Rows[0]["RCode"].ToString();
                    txtSName.Text = ds.Tables[0].Rows[0]["RName"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["RAddress1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["RAddress2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["RAddress3"].ToString();
                    txtTel.Text = ds.Tables[0].Rows[0]["RContactNo"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["REmailId"].ToString();
                    txtDealerCode.Text = ds.Tables[0].Rows[0]["SupplierCode"].ToString();
                    txtDealerName.Text = ds.Tables[0].Rows[0]["SName"].ToString();

                    txtAddress1.Focus();
                }
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
                            sqlcom.CommandText = " SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  Begin Transaction "
                                                    + " Insert into RetailerMst"
                                                    + " (RCode,RName,RAddress1,RAddress2,RAddress3,RContactNo,REmailId,SupplierCode)"
                                                    + " values((SELECT RIGHT('000000'+ CAST( ISNULL( max(Cast(RCode as int)),0)+1 AS VARCHAR(6)),6)from RetailerMst),@RName,@RAddress1,@RAddress2,@RAddress3,@RContactNo,@REmailId,@SupplierCode )"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE RetailerMst SET "
                                                + " RCode=@RCode,RName=@RName ,RAddress1=@RAddress1,RAddress2=@RAddress2,RAddress3=@RAddress3,RContactNo=@RContactNo,REmailId=@REmailId,SupplierCode=@SupplierCode"
                                                + " Where RCode=@RCode";

                        }
                        sqlcom.Parameters.AddWithValue("@RCode", txtSCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@RName", txtSName.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@RAddress1", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@RAddress2", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@RAddress3", txtAddress3.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@RContactNo", txtTel.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@REmailId", txtEmail.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SupplierCode", txtDealerCode.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtxtDealerCode_EditValueChanged(object sender, EventArgs e)
        {
            txtDealerName.Text = string.Empty;

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
            if (HelpGrid.Text == "txtDealerCode")
            {
                txtDealerCode.Text = row["SCode"].ToString();
                txtDealerName.Text = row["SName"].ToString();
                HelpGrid.Visible = false;
                txtDealerCode.Focus();
            }
        }

        private void txtDealerCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select SCode,SName from SupplierMst ", " Where  SCode ", txtDealerCode, txtDealerName, txtDealerCode, HelpGrid, HelpGridView, e);

        }

        private void frmRetailerMaster_KeyDown(object sender, KeyEventArgs e)
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
    }
}