using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Master
{
    public partial class frmSupplierMaster : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String SCode { get; set; }

        public frmSupplierMaster()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtSCode.Enabled = false;
        }

        private bool ValidateData()
        {
            if (txtSCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Supplier");
                txtSCode.Focus();
                return false;
            }
            if (txtSName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Supplier");
                txtSName.Focus();
                return false;
            }
            if (txtDealerCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer");
                txtDealerCode.Focus();
                return false;
            }
            if (txtDealerName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Dealer");
                txtDealerCode.Focus();
                return false;
            }

            return true;
        }
        private void txtAcCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string GetNewCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(SCode as int)),000000) from SupplierMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmSupplierMaster_KeyDown(object sender, KeyEventArgs e)
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

        private void frmSupplierMaster_Load(object sender, EventArgs e)
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
                DataSet ds = ProjectFunctions.GetDataSet("sp_LoadSupplierMstFEdit @SCode='" + SCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSCode.Text = ds.Tables[0].Rows[0]["SCode"].ToString();
                    txtSName.Text = ds.Tables[0].Rows[0]["SName"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["SAddress1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["SAddress2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["SAddress3"].ToString();
                    txtTel.Text = ds.Tables[0].Rows[0]["SContactNo"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["SEmailId"].ToString();
                    txtDealerCode.Text = ds.Tables[0].Rows[0]["SDealerCode"].ToString();
                    txtDealerName.Text = ds.Tables[0].Rows[0]["AccName"].ToString();

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
                                                    + " Insert into SupplierMst"
                                                    + " (SCode,SName,SAddress1,SAddress2,SAddress3,SContactNo,SEmailId,SDealerCode)"
                                                    + " values((SELECT RIGHT('000000'+ CAST( ISNULL( max(Cast(SCode as int)),0)+1 AS VARCHAR(6)),6)from SupplierMst),@SName,@SAddress1,@SAddress2,@SAddress3,@SContactNo,@SEmailId,@SDealerCode )"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE SupplierMst SET "
                                                + " SCode=@SCode,SName=@SName ,SAddress1=@SAddress1,SAddress2=@SAddress2,SAddress3=@SAddress3,SContactNo=@SContactNo,SEmailId=@SEmailId,SDealerCode=@SDealerCode"
                                                + " Where SCode=@SCode";

                        }
                        sqlcom.Parameters.AddWithValue("@SCode", txtSCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SName", txtSName.Text.Trim());

                        sqlcom.Parameters.AddWithValue("@SAddress1", txtAddress1.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SAddress2", txtAddress2.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SAddress3", txtAddress3.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SContactNo", txtTel.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SEmailId", txtEmail.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@SDealerCode", txtDealerCode.Text.Trim());
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

        private void txtDealerCode_EditValueChanged(object sender, EventArgs e)
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
                txtDealerCode.Text = row["AccCode"].ToString();
                txtDealerName.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtDealerCode.Focus();
            }
        }

        private void txtDealerCode_KeyDown(object sender, KeyEventArgs e)
        {

            ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst Where AccActive='Y'", " And AccCode ", txtDealerCode, txtDealerName, txtDealerCode, HelpGrid, HelpGridView, e);
        }
    }
}