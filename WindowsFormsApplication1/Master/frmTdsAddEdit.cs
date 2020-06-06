using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmTdsAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String TdsCode { get; set; }
        public frmTdsAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtTdsCode.Enabled = false;
        }

        private void frmTdsAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtTdsDesc.Focus();
                txtTdsCode.Text = GetNewTDSCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtTdsDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT     TdsMst.TdsCode, TdsMst.TdsDesc, TdsMst.TdsRate, TdsMst.TdsSRate, TdsMst.TdsUS, TdsMst.TdsPostingCode, ActMst.AccName FROM         TdsMst INNER JOIN ActMst ON TdsMst.TdsPostingCode = ActMst.AccCode Where TdsCode='" + TdsCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTdsCode.Text = ds.Tables[0].Rows[0]["TdsCode"].ToString();
                    txtTdsDesc.Text = ds.Tables[0].Rows[0]["TdsDesc"].ToString();
                    txtRate.Text = ds.Tables[0].Rows[0]["TdsRate"].ToString();
                    txtSurcRate.Text = ds.Tables[0].Rows[0]["TdsSRate"].ToString();
                    txtUnderSec.Text = ds.Tables[0].Rows[0]["TdsUS"].ToString();
                    txtAcPostingCode.Text = ds.Tables[0].Rows[0]["TdsPostingCode"].ToString();
                    txtAcPostingdesc.Text = ds.Tables[0].Rows[0]["AccName"].ToString();
                    txtUnderSec.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtTdsCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid TDS Code");
                txtTdsCode.Focus();
                return false;
            }
            if (txtTdsDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid TDS Description");
                txtTdsDesc.Focus();
                return false;
            }
            if (txtUnderSec.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid TDS Under Section");
                txtUnderSec.Focus();
                return false;
            }
            if (txtAcPostingCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid TDS Account Posting");
                txtAcPostingCode.Focus();
                return false;
            }
            if (txtAcPostingdesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid TDS Account Posting");
                txtAcPostingCode.Focus();
                return false;
            }
            if (txtRate.Text.Trim().Length == 0)
            {
                txtRate.Text = "0";
            }
            if (txtSurcRate.Text.Trim().Length == 0)
            {
                txtSurcRate.Text = "0";
            }
            return true;
        }
        private string GetNewTDSCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(TdsCode as int)),0000) from TdsMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmTdsAddEdit_KeyDown(object sender, KeyEventArgs e)
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                                                    + " Insert into TdsMst"
                                                    + " (TdsCode,TdsDesc,TdsRate,TdsSRate,TdsUS,TdsPostingCode)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(TdsCode as int)),0)+1 AS VARCHAR(4)),4)from TdsMst),@TdsDesc,@TdsRate,@TdsSRate,@TdsUS,@TdsPostingCode)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE TdsMst SET "
                                                + " TdsDesc=@TdsDesc,TdsRate=@TdsRate,TdsSRate=@TdsSRate,TdsUS=@TdsUS,TdsPostingCode=@TdsPostingCode "
                                                + " Where TdsCode=@TdsCode";
                        }
                        sqlcom.Parameters.AddWithValue("@TdsCode", txtTdsCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TdsDesc", txtTdsDesc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TdsRate", Convert.ToDecimal(txtRate.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TdsSRate", Convert.ToDecimal(txtSurcRate.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@TdsUS", txtUnderSec.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@TdsPostingCode", txtAcPostingCode.Text.Trim());
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

        private void txtAcPostingCode_EditValueChanged(object sender, EventArgs e)
        {
            txtAcPostingdesc.Text = string.Empty;
        }

        private void txtAcPostingCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProjectFunctions.CreatePopUpForTwoBoxes("Select AccCode,AccName from ActMst", " Where AccCode", txtAcPostingCode, txtAcPostingdesc, txtRate, HelpGrid, HelpGridView, e);
            }
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtAcPostingCode")
            {
                txtAcPostingCode.Text = row["AccCode"].ToString();
                txtAcPostingdesc.Text = row["AccName"].ToString();
                HelpGrid.Visible = false;
                txtRate.Focus();
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
    }
}