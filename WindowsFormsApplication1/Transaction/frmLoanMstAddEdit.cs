using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmLoanMstAddEdit : DevExpress.XtraEditors.XtraForm
    {

        public String Ms1yProperty { get; set; }
        public String LoanNo { get; set; }
        public DateTime LoanADate { get; set; }
        public String s1 { get; set; }

        public frmLoanMstAddEdit()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetMyControls()
        {
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }

        private bool ValidateData()
        {


            if (txtEmpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid EmpCode");
                txtEmpCode.Focus();
                return false;
            }
            if (txtEmpName.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid EmpName");
                txtEmpCode.Focus();
                return false;
            }
            if (txtLoanAmount.Text.Trim().Length == 0)
            {
                txtLoanAmount.Text = "0";
            }
            if (txtLoanInstlmnt.Text.Trim().Length == 0)
            {
                txtLoanInstlmnt.Text = "0";
            }

            if (Convert.ToDecimal(txtLoanInstlmnt.Text) > Convert.ToDecimal(txtLoanAmount.Text))
            {
                ProjectFunctions.SpeakError("Please Adjust Loan Amount Or Installment Amount");
                txtLoanInstlmnt.Focus();
                return false;
            }
            return true;
        }


        private void frmLoanMstAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtEmpCode.Focus();
                txtLoanDate.EditValue = Convert.ToDateTime(DateTime.Now);
                txtLoanNo.Text = getNewLoanNo().PadLeft(5, '0');
            }
            if (s1 == "Edit")
            {
                txtEmpCode.Focus();

                var ds = ProjectFunctions.GetDataSet(string.Format("SELECT     LoanMST.LoanADate, LoanMST.LoanANo, LoanMST.LoanID, LoanMST.EmpCode,  LoanMST.LoanAmt,LoanMST.LoanInstlmnt, empmst.EmpName, DeptMst.DeptDesc FROM         LoanMST LEFT OUTER JOIN  empmst ON LoanMST.EmpCode = empmst.EmpCode LEFT OUTER JOIN DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode  Where LoanANo='" + LoanNo + "' And LoanADate='" + Convert.ToDateTime(LoanADate).ToString("yyyy-MM-dd") + "'"));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtLoanNo.Text = ds.Tables[0].Rows[0]["LoanANo"].ToString();
                    txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                    txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    txtLoanAmount.Text = ds.Tables[0].Rows[0]["LoanAmt"].ToString();
                    txtLoanInstlmnt.Text = ds.Tables[0].Rows[0]["LoanInstlmnt"].ToString();
                    txtLoanDate.Text = ds.Tables[0].Rows[0]["LoanADate"].ToString();
                }
            }
        }

        private void txtLoanAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtLoanInstlmnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private string getNewLoanNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(LoanANo as int)),000000) from LoanMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
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
                                                    + " Insert into LoanMst"
                                                    + " (LoanANo,LoanAmt,LoanInstlmnt,EmpCode,LoanADate)"
                                                    + " values((SELECT RIGHT('000000'+ CAST( ISNULL( max(Cast(LoanANo as int)),0)+1 AS VARCHAR(6)),6)from LoanMst),@LoanAmt,@LoanInstlmnt,@EmpCode,@LoanADate)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE LoanMst SET "
                                                + " LoanAmt=@LoanAmt,LoanInstlmnt=@LoanInstlmnt,EmpCode=@EmpCode "
                                                + " Where LoanANo=@LoanANo";

                        }
                        sqlcom.Parameters.AddWithValue("@LoanANo", txtLoanNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@LoanADate", Convert.ToDateTime(txtLoanDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@LoanAmt", Convert.ToDecimal(txtLoanAmount.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@LoanInstlmnt", Convert.ToDecimal(txtLoanInstlmnt.Text.Trim()));
                        sqlcom.Parameters.AddWithValue("@EmpCode", txtEmpCode.Text.Trim());
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


        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpName.Text = string.Empty;
        }

        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select EmpMst.EmpCode,EmpMst.EmpName from EmpMst", " Where EmpMst.EmpCode", txtEmpCode, txtEmpName, txtLoanAmount, HelpGrid, HelpGridView, e);
        }
        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtEmpCode")
            {
                txtEmpCode.Text = row["EmpCode"].ToString();
                txtEmpName.Text = row["EmpName"].ToString();
                HelpGrid.Visible = false;
                txtLoanAmount.Focus();
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