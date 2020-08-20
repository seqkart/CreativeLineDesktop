using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frmLoanMonthlyData : DevExpress.XtraEditors.XtraForm
    {

        private SqlConnection con = new SqlConnection(ProjectFunctions.ConnectionString);
        private string CurrentControl = string.Empty;
        public string LoanId { get; set; }
        public bool IsUpdate { get; set; }
        public string RAid { get; set; }
        public frmLoanMonthlyData()
        {
            InitializeComponent();
        }
        private bool validate()
        {
            if (txtEmpCode.Text.Length == 0 || txtEmpCode.Text == " ")
            {
                XtraMessageBox.Show("Invalid EmpCode");
                txtEmpCode.Focus();
                return false;
            }

            if (DtMonthYear.EditValue == null)
            {
                XtraMessageBox.Show("Invalid MonthYear");
                DtMonthYear.Focus();
            }

            btn_Save.Enabled = true;
            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                txt.Focus();
                var cmd = con.CreateCommand();
                cmd.Connection = con;
                var str = string.Empty;
                con.Open();
                if (btn_Save.Text == "&Update")
                {
                    str = " UPDATE LoanMonthlyData " +
                    " SET EmpCode = @EmpCode,MonthYear = @MonthYear,LoanInstlmnt = @LoanInstlmnt " +
                    " where EmpCode=" + txtEmpCode.Text + " and TransID=" + LoanId;
                    btn_Save.Enabled = false;
                }
                else
                {
                    str = "INSERT INTO LoanMonthlyData (EmpCode,MonthYear,LoanInstlmnt) " +
                           "  VALUES " +
                            " (@EmpCode,@MonthYear,@LoanInstlmnt)";
                }
                cmd.CommandText = str;
                cmd.Parameters.AddWithValue("@EmpCode", txtEmpCode.Text);
                cmd.Parameters.AddWithValue("@LoanInstlmnt", Convert.ToDecimal(txtLoanInt.Text));

                var month = DtMonthYear.Text.Substring(0, 2) + DtMonthYear.Text.ToString().Substring(DtMonthYear.Text.ToString().Length - 2, 2);
                cmd.Parameters.AddWithValue("@MonthYear", DtMonthYear.Text).Value = month;
                cmd.ExecuteNonQuery();

                con.Close();
                this.Close();
            }
        }

        private void SetMyControls()
        {
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.ButtonVisualize(this);
        }

        private void frmLoanMonthlyData_Load(object sender, EventArgs e)
        {

            SetMyControls();
            txtEmpCode.Focus();
            var str = string.Format("SELECT LoanMonthlyData.MonthYear, LoanMonthlyData.EmpCode, EmpMST.EmpName, EmpMST.EmpFHName, LoanMonthlyData.LoanInstlmnt, LoanMonthlyData.TransID FROM            LoanMonthlyData INNER JOIN EmpMST ON LoanMonthlyData.EmpCode = EmpMST.EmpCode Where TransID='{0}'", LoanId);
            var DS = new DataSet();
            var dap2 = new SqlDataAdapter(str, con);
            dap2.Fill(DS);
            if (DS.Tables[0].Rows.Count > 0)
            {
                btn_Save.Text = "&Update";
                txtEmpCode.Text = DS.Tables[0].Rows[0]["EmpCode"].ToString();
                txtEmpName.Text = DS.Tables[0].Rows[0]["EmpName"].ToString();
                DtMonthYear.EditValue = Convert.ToDateTime("20" + DS.Tables[0].Rows[0]["MonthYear"].ToString().Substring(2, 2) + "-" + DS.Tables[0].Rows[0]["MonthYear"].ToString().Substring(0, 2) + "-" + "01");
                txtLoanInt.Text = DS.Tables[0].Rows[0]["LoanInstlmnt"].ToString();
                txtEmpCode.Enabled = false;
                DtMonthYear.Enabled = false;
                txtLoanInt.Focus();
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoanAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtLoanInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                using (var connection = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    CurrentControl = "EmpCode";
                    var Query = "SELECT EmpCode, EmpName FROM  empmst Order By EmpName";
                    if (txtEmpCode.Text.Trim().Length == 0)
                    {
                        ShowHelpWindow(Query);
                    }
                    else
                    {
                        var query = String.Format("SELECT EmpCode, EmpName FROM  empmst  where EmpCode='{0}'", txtEmpCode.Text.Trim());

                        var ds = new DataSet();
                        var dap = new SqlDataAdapter(query, connection);
                        dap.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                            txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                            txtLoanInt.Focus();
                        }
                        else
                        {
                            ShowHelpWindow(Query);
                        }
                    }
                    e.Handled = true;
                }
            }
            if ((e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift) || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, false, true, true, true);
            }
        }

        private void ShowHelpWindow(string Query)
        {
            try
            {
                HelpGridCtrl.DataSource = null;
                HelpGrid.Columns.Clear();
                HelpGridCtrl.RefreshDataSource();
                HelpGridCtrl.Visible = true;
                HelpGridCtrl.Focus();
                HelpGridCtrl.DataSource = ProjectFunctions.GetDataSet(Query).Tables[0];
                HelpGrid.Columns[0].BestFit();
                HelpGrid.Columns[1].BestFit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Unable to fetch Data please Contact IT Department.\n" + ex.Message, "!Error");
            }
        }

        private void HelpGridCtrl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var row = HelpGrid.GetDataRow(HelpGrid.FocusedRowHandle);
                switch (CurrentControl)
                {
                    case "EmpCode":
                        txtEmpCode.Text = row["EmpCode"].ToString();
                        txtEmpName.Text = row["EmpName"].ToString();
                        txtLoanInt.Focus();
                        break;
                }

                HelpGridCtrl.Visible = false;
            }
            catch (Exception)
            {
            }
        }

        private void HelpGridCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                HelpGridCtrl_DoubleClick(sender, e);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                HelpGridCtrl.Visible = false;

                RestoreFocus();
                e.Handled = true;
            }
        }

        private void RestoreFocus()
        {
            switch (CurrentControl)
            {
                case "EmpCode":
                    txtEmpCode.Focus();
                    break;

                default:
                    CurrentControl = string.Empty;
                    break;
            }
        }

        private void HelpGridCtrl_Click(object sender, EventArgs e)
        {

        }

        private void TxtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpName.Text = String.Empty;
        }
    }
}