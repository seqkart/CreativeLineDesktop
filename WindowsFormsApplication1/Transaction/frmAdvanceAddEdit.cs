using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class frmAdvanceAddEdit : DevExpress.XtraEditors.XtraForm
    {

        public string s1 { get; set; }
        public string ExId { get; set; }
        public frmAdvanceAddEdit()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        private void frmAdvanceAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                DtDate.Enabled = false;
                DtDate.EditValue = DateTime.Now;
                DtDateforMonth.EditValue = DateTime.Now;
                txtAdvanceNo.Text = getNewLoanPassNo().PadLeft(6, '0');
                txtType.Text = "A";
                DtDateforMonth.Focus();
            }
            if (s1 == "Edit")
            {
                DtDate.Enabled = false;
                txtType.Enabled = false;
                txtEmpCode.Focus();
                var ds = ProjectFunctions.GetDataSet(" SELECT     ExMst.ExNo, ExMst.ExId, ExMst.ExDate, ExMst.ExEmpCode, ExMst.ExAmt, ExMst.ExTag, ExMst.ExDatePost, empmst.EmpName FROM ExMst LEFT OUTER JOIN empmst ON ExMst.ExEmpCode = empmst.EmpCode WHERE ExId='" + ExId + "'");
                txtAdvanceNo.Text = ds.Tables[0].Rows[0]["ExNo"].ToString();
                DtDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ExDate"]);
                DtDateforMonth.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ExDatePost"]);
                txtEmpCode.Text = ds.Tables[0].Rows[0]["ExEmpCode"].ToString();
                txtEmpCodeDesc.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                txtType.Text = ds.Tables[0].Rows[0]["ExTag"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["ExAmt"].ToString();
            }
        }
        private bool ValidateData()
        {
            if (DtDate.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Date");
                DtDate.Focus();
                return false;
            }
            if (DtDateforMonth.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Date Of Month");
                DtDateforMonth.Focus();
                return false;
            }
            if (txtEmpCode.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid EmpName");
                txtEmpCode.Focus();
                return false;
            }
            if (txtEmpCodeDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid EmpName");
                txtEmpCode.Focus();
                return false;
            }

            if (txtAmount.Text.Length == 0)
            {
                txtAmount.Text = "0";
            }

            if (txtType.Text == "A" || txtType.Text == "C" || txtType.Text == "F")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Advance(A),Fine(F),Coupon(C)");
                txtType.Focus();
                return false;
            }
            return true;
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
                                                    + " Insert into ExMst"
                                                    + " (ExNo,ExDate,ExEmpCode,ExAmt,ExTag,ExDatePost)"
                                                    + " values((SELECT RIGHT('00000'+ CAST( ISNULL( max(Cast(ExNo as int)),0)+1 AS VARCHAR(5)),5)from ExMst),@ExDate,@ExEmpCode,@ExAmt,@ExTag,@ExDatePost)"
                                                    + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE  ExMst Set  "
                                                + " ExEmpCode=@ExEmpCode,ExAmt=@ExAmt,ExTag=@ExTag,ExDatePost=@ExDatePost "
                                                + " Where ExNo=@ExNo";

                        }
                        sqlcom.Parameters.AddWithValue("@ExNo", txtAdvanceNo.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ExDate", Convert.ToDateTime(DtDate.Text).ToString("yyyy-MM-dd"));
                        sqlcom.Parameters.AddWithValue("@ExEmpCode", txtEmpCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ExAmt", Convert.ToDecimal(txtAmount.Text));
                        sqlcom.Parameters.AddWithValue("@ExTag", txtType.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@ExDatePost", Convert.ToDateTime(DtDateforMonth.Text).ToString("yyyy-MM-dd"));
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


        private string getNewLoanPassNo()
        {
            var s2 = string.Empty;
            DataSet ds = ProjectFunctions.GetDataSet("select isnull(max(Cast(ExNo as int)),000000) from ExMst");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s2 = ds.Tables[0].Rows[0][0].ToString().Trim();
                s2 = (Convert.ToInt32(s2) + 1).ToString().Trim();
            }
            return s2;
        }


        private void clear()
        {
            txtEmpCode.Text = string.Empty;
            txtEmpCodeDesc.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtType.Text = string.Empty;
            s1 = "&Add";
            txtEmpCode.Focus();
            Text = "Time Office Payment Addition";
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }


        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpCodeDesc.Text = string.Empty;
        }



        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select EmpCode,EmpName from EmpMst", " Where EmpCode", txtEmpCode, txtEmpCodeDesc, txtType, HelpGrid, HelpGridView, e);
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
            var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtEmpCode")
            {
                txtEmpCode.Text = row["EmpCode"].ToString().Trim();
                txtEmpCodeDesc.Text = row["EmpName"].ToString().Trim();
                HelpGrid.Visible = false;
                txtType.Focus();
            }
        }


        private void frmAdvanceAddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtType.Text == "A" || txtType.Text == "C" || txtType.Text == "F")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Advance(A),Fine(F),Coupon(C)");
                txtType.Focus();
            }
        }
    }
}
