using DevExpress.XtraEditors;
using SeqKartLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frmDepartmentAddUpdate : DevExpress.XtraEditors.XtraForm
    {
        public String s1 { get; set; }
        public String DeptCode { get; set; }
        public frmDepartmentAddUpdate()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            txtDesc.Properties.MaxLength = 40;

            txtDeptCode.Enabled = false;
        }
        //private string GetNewDeptCode()
        //{
        //    string sql = "SELECT"
        //    + " CASE"
        //    + " WHEN (isnull(max(Cast(REPLACE(DeptCode, 'dp', '') as int)), 00000) + 1) < 10 THEN ('dp0'+CAST(isnull(max(Cast(REPLACE(DeptCode, 'dp', '') as int)), 00000) + 1 as varchar(10)))"
        //    + " ELSE ('dp'+CAST(isnull(max(Cast(REPLACE(DeptCode, 'dp', '') as int)), 00000) + 1 as varchar(10)))"
        //    + " END AS NewDeptCode"
        //    + " FROM DeptMSt;";
        //    //"select isnull(max(Cast(DeptCode as int)),00000) from DeptMSt"
        //    String s2 = String.Empty;
        //    DataSet ds = ProjectFunctions.GetDataSet(sql);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        s2 = ds.Tables[0].Rows[0][0].ToString();
        //        //s2 = (Convert.ToInt32(s2) + 1).ToString();
        //    }
        //    return s2;
        //}
        private void frmDepartmentAddUpdate_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtDesc.Focus();
                txtDeptCode.Text = ProjectFunctionsUtils.GetNewDeptCode();//.PadLeft(4, '0');
            }
            if (s1 == "Edit")
            {
                //txtDesc.Enabled = false;
                DataSet ds = ProjectFunctions.GetDataSet("SELECT DeptCode,DeptDesc,Remarks FROM DeptMst Where DeptCode='" + DeptCode + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDeptCode.Text = ds.Tables[0].Rows[0]["DeptCode"].ToString();
                    txtDesc.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    txtDesc.Focus();
                }
            }
        }
        private bool ValidateData()
        {
            if (txtDeptCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Department Code", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDeptCode.Focus();
                return false;
            }
            if (txtDesc.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Invalid Department Description", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtDesc.Focus();
                return false;
            }

            return true;
        }

        private void frmDepartmentAddUpdate_KeyDown(object sender, KeyEventArgs e)
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
                                                    + " Insert into DeptMst"
                                                    + " (DeptCode,DeptDesc,Remarks)"
                                                    + " values((SELECT RIGHT('0000'+ CAST( ISNULL( max(Cast(DeptCode as int)),0)+1 AS VARCHAR(4)),4)from DeptMst),@DeptDesc,@Remarks)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE DeptMst SET "
                                                + " DeptDesc=@DeptDesc,Remarks=@Remarks "
                                                + " Where DeptCode=@DeptCode";

                        }
                        sqlcom.Parameters.AddWithValue("@DeptCode", txtDeptCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@DeptDesc", txtDesc.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                        sqlcom.ExecuteNonQuery();
                        transaction.Commit();
                        sqlcon.Close();
                        ProjectFunctions.SpeakError("Data Saved Successfully");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Something Wrong. \n I am going to Roll Back." + ex.Message, ex.GetType().ToString());
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            XtraMessageBox.Show("Something Wrong. \n Roll Back Failed." + ex2.Message, ex2.GetType().ToString());
                        }
                    }
                }
            }
        }
    }
}
