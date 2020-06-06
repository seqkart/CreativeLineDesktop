using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class frm_EmpSalAddUpdate : XtraForm
    {
        public String s1 { get; set; }
        public String MonthYear { get; set; }
        public String EmpCode { get; set; }
        public frm_EmpSalAddUpdate()
        {
            InitializeComponent();
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
                txtEmpCode.Text = row["EmpCode"].ToString();
                txtEmpName.Text = row["EmpName"].ToString();
                HelpGrid.Visible = false;
                txtPrePaidTag.Focus();
            }
        }

        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select EmpMst.EmpCode,EmpMst.EmpName from EmpMst", " Where EmpMst.EmpCode", txtEmpCode, txtEmpName, txtPrePaidTag, HelpGrid, HelpGridView, e);
        }

        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpName.Text = string.Empty;
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
            if (txtDeptDesc.Text.Trim().Length == 0)
            {
                ProjectFunctions.SpeakError("Invalid Department");
                txtEmpCode.Focus();
                return false;
            }
            if (txtCL.Text.Trim().Length == 0)
            {
                txtCL.Text = "0";
            }
            if (txtDW.Text.Trim().Length == 0)
            {
                txtDW.Text = "0";
            }
            if (txtEL.Text.Trim().Length == 0)
            {
                txtEL.Text = "0";
            }
            if (txtLWF.Text.Trim().Length == 0)
            {
                txtLWF.Text = "0";
            }
            if (txtMisc1.Text.Trim().Length == 0)
            {
                txtMisc1.Text = "0";
            }
            if (txtMisc2.Text.Trim().Length == 0)
            {
                txtMisc2.Text = "0";
            }
            if (txtMisc3.Text.Trim().Length == 0)
            {
                txtMisc3.Text = "0";
            }
            if (txtML.Text.Trim().Length == 0)
            {
                txtML.Text = "0";
            }
            if (txtPH.Text.Trim().Length == 0)
            {
                txtPH.Text = "0";
            }
            if (txtSL.Text.Trim().Length == 0)
            {
                txtSL.Text = "0";
            }
            if (txtTDS.Text.Trim().Length == 0)
            {
                txtTDS.Text = "0";
            }
            if (txtMiscDed.Text.Trim().Length == 0)
            {
                txtMiscDed.Text = "0";
            }
            if (txtOT.Text.Trim().Length == 0)
            {
                txtOT.Text = "0";
            }
            return true;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_EmpSalAddUpdate_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "&Add")
            {
                txtEmpCode.Focus();
                dtMonthYear.EditValue = DateTime.Now;
            }
            if (s1 == "Edit")
            {
                txtEmpCode.Focus();
                var ds = ProjectFunctions.GetDataSet(string.Format("sp_LoadAtnDataFEditing  '{0}','{1}'", MonthYear, EmpCode));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                    txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    txtDeptDesc.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();
                    txtDW.Text = ds.Tables[0].Rows[0]["EmpDW"].ToString();
                    txtPH.Text = ds.Tables[0].Rows[0]["EmpPH"].ToString();
                    txtEL.Text = ds.Tables[0].Rows[0]["EmpEL"].ToString();
                    txtCL.Text = ds.Tables[0].Rows[0]["EmpCL"].ToString();
                    txtSL.Text = ds.Tables[0].Rows[0]["EmpSL"].ToString();
                    txtTDS.Text = ds.Tables[0].Rows[0]["EmpTdsAmt"].ToString();
                    txtLWF.Text = ds.Tables[0].Rows[0]["EmpMiscDed1"].ToString();
                    txtMiscDed.Text = ds.Tables[0].Rows[0]["EmpMiscDed2"].ToString();
                    txtMisc1.Text = ds.Tables[0].Rows[0]["EmpMiscAlw1"].ToString();
                    txtMisc2.Text = ds.Tables[0].Rows[0]["EmpMiscAlw2"].ToString();
                    txtMisc3.Text = ds.Tables[0].Rows[0]["EmpMiscAlw3"].ToString();
                }
            }
        }

        private void txtPrePaidTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtPrePaidTag.Text == "Y" || txtPrePaidTag.Text == "N")
            {
            }
            else
            {
                ProjectFunctions.SpeakError("Valid Values are Y,N");
                txtPrePaidTag.Focus();
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
                                                 + " Insert into AtnData"
                                                 + " (MonthYear,EmpCode,EmpDW,EmpPH,EmpEL,EmpCL,EmpSL,EmpOT,EmpTdsAmt,EmpMiscDed1,EmpMiscDed2"
                                                 + " EmpMiscAlw1,EmpMiscAlw2,EmpMiscAlw3,EmpPrePaidSal)values("
                                                 + " values(@MonthYear,@EmpCode,@EmpDW,@EmpPH,@EmpEL,@EmpCL,@EmpSL,@EmpOT,@EmpTdsAmt,@EmpMiscDed1,@EmpMiscDed2,"
                                                 + " @EmpMiscAlw1,@EmpMiscAlw2,@EmpMiscAlw3,@EmpPrePaidSal)"
                                                 + " Commit ";
                        }
                        if (s1 == "Edit")
                        {
                            sqlcom.CommandText = " UPDATE AtnData SET "
                                                + " EmpDW=@EmpDW,EmpPH=@EmpPH,EmpEL=@EmpEL,EmpCL=@EmpCL,EmpSL=@EmpSL, "
                                                + " EmpOT=@EmpOT,EmpTdsAmt=@EmpTdsAmt,EmpMiscDed1=@EmpMiscDed1,EmpMiscDed2=@EmpMiscDed2, "
                                                + " EmpMiscAlw1=@EmpMiscAlw1,EmpMiscAlw2=@EmpMiscAlw2,EmpMiscAlw3=@EmpMiscAlw3,EmpPrePaidSal=@EmpPrePaidSal "
                                                + " Where EmpCode=@EmpCode And MonthYear=@MonthYear ";
                        }

                        sqlcom.Parameters.AddWithValue("@MonthYear", Convert.ToDateTime(dtMonthYear.Text).ToString("MMyy"));
                        sqlcom.Parameters.AddWithValue("@EmpCode", txtEmpCode.Text.Trim());
                        sqlcom.Parameters.AddWithValue("@EmpDW", Convert.ToDecimal(txtDW.Text));
                        sqlcom.Parameters.AddWithValue("@EmpPH", Convert.ToDecimal(txtPH.Text));
                        sqlcom.Parameters.AddWithValue("@EmpEL", Convert.ToDecimal(txtEL.Text));
                        sqlcom.Parameters.AddWithValue("@EmpCL", Convert.ToDecimal(txtCL.Text));
                        sqlcom.Parameters.AddWithValue("@EmpSL", Convert.ToDecimal(txtSL.Text));
                        sqlcom.Parameters.AddWithValue("@EmpOT", Convert.ToDecimal(txtOT.Text));
                        sqlcom.Parameters.AddWithValue("@EmpTdsAmt", Convert.ToDecimal(txtTDS.Text));
                        sqlcom.Parameters.AddWithValue("@EmpMiscDed1", Convert.ToDecimal(txtLWF.Text));
                        sqlcom.Parameters.AddWithValue("@EmpMiscDed2", Convert.ToDecimal(txtMiscDed.Text));
                        sqlcom.Parameters.AddWithValue("@EmpMiscAlw1", Convert.ToDecimal(txtMisc1.Text));
                        sqlcom.Parameters.AddWithValue("@EmpMiscAlw2", Convert.ToDecimal(txtMisc2.Text));
                        sqlcom.Parameters.AddWithValue("@EmpMiscAlw3", Convert.ToDecimal(txtMisc3.Text));
                        sqlcom.Parameters.AddWithValue("@EmpPrePaidSal", txtPrePaidTag.Text.Trim());
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

        private void txtDW_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }
    }
}