using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmExpenseHeadAddEdit : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String ExpHeadCode { get; set; }
        public frmExpenseHeadAddEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);

            txtDesc.Properties.MaxLength = 30;
            txtCode.Enabled = false;
        }
        private void frmExpenseHeadAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtDesc.Focus();
                txtCode.Text = GetNewExpHeadCode().PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                txtDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT ExpHeadCode,ExpHeadDesc,ExpHeadSplTag FROM ExpHeadMst Where ExpHeadCode='" + ExpHeadCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCode.Text = ds.Tables[0].Rows[0]["ExpHeadCode"].ToString();
                    txtDesc.Text = ds.Tables[0].Rows[0]["ExpHeadDesc"].ToString();
                    txtSplTag.Text = ds.Tables[0].Rows[0]["ExpHeadSplTag"].ToString();
                    txtDesc.Focus();
                }
            }
        }

        private bool ValidateData()
        {
            if (txtCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Expense Head Code");
                txtCode.Focus();
                return false;
            }
            if (txtDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Expense Head Description");
                txtDesc.Focus();
                return false;
            }

            return true;
        }
        private string GetNewExpHeadCode()
        {
            String s2 = String.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(ExpHeadCode as int)),00000) from ExpHeadMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString();
                s2 = (Convert.ToInt32(s2) + 1).ToString();
            }
            return s2;
        }
        private void frmExpenseHeadAddEdit_KeyDown(object sender, KeyEventArgs e)
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
                                                    + " Insert into ExpHeadMst"
                                                    + " (ExpHeadCode,ExpHeadDesc,ExpHeadSplTag)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(ExpHeadCode as int)),0)+1 AS VARCHAR(4)),4)from ExpHeadMst),@ExpHeadDesc,@ExpHeadSplTag)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE ExpHeadMst SET "
                                                + " ExpHeadDesc=@ExpHeadDesc,ExpHeadSplTag=@ExpHeadSplTag "
                                                + " Where ExpHeadCode=@ExpHeadCode";

                        }
                        sqlcom.Parameters.AddWithValue("@ExpHeadCode", txtCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ExpHeadDesc", txtDesc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ExpHeadSplTag", txtSplTag.Text.Trim());
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
    }
}
