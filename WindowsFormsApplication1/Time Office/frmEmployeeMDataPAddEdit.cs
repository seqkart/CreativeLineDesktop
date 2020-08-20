using System;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frmEmployeeMDataPAddEdit : DevExpress.XtraEditors.XtraForm
    {


        public string _empcode = null;

        public string empcode
        {
            get
            {
                return _empcode;
            }
            set
            {
                _empcode = value;
            }
        }
        public string _empdate = null;

        public string empdate
        {
            get
            {
                return _empdate;
            }
            set
            {
                _empdate = value;
            }
        }

        private void SetMyControls()
        {
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }
        public frmEmployeeMDataPAddEdit()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeeMDataPAddEdit_Load(object sender, EventArgs e)
        {


            DtStartDate.EditValue = empdate;
            SetMyControls();
            var ds = ProjectFunctions.GetDataSet("Select * from EmpMST where EmpCode='" + empcode + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                txtFHName.Text = ds.Tables[0].Rows[0]["EmpFHName"].ToString();

                txtBasicPay.Text = ds.Tables[0].Rows[0]["EmpBasic"].ToString();
                txtHRA.Text = ds.Tables[0].Rows[0]["EmpHRA"].ToString();
                txtPetrol.Text = ds.Tables[0].Rows[0]["EmpPET"].ToString();
                txtConvenyance.Text = ds.Tables[0].Rows[0]["EmpConv"].ToString();
                txtEmpSplAlw.Text = ds.Tables[0].Rows[0]["EmpSplAlw"].ToString();
            }
            txtTotal1.Text = (Convert.ToDecimal(txtBasicPay.Text) + Convert.ToDecimal(txtHRA.Text) + Convert.ToDecimal(txtPetrol.Text) + Convert.ToDecimal(txtConvenyance.Text) + Convert.ToDecimal(txtEmpSplAlw.Text)).ToString();
            DtStartDate.Properties.ReadOnly = true;
            var ds1 = ProjectFunctions.GetDataSet("Select * from  EMPMST_MDATA where empcode='" + empcode + "' And DATEPART(yyyy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtBasicPay1.Text = ds1.Tables[0].Rows[0]["EmpBasic"].ToString();
                txtHRA1.Text = ds1.Tables[0].Rows[0]["EmpHRA"].ToString();
                txtPetrol1.Text = ds1.Tables[0].Rows[0]["EmpPET"].ToString();
                txtConvenyance1.Text = ds1.Tables[0].Rows[0]["EmpConv"].ToString();
                txtEmpSplAlw1.Text = ds1.Tables[0].Rows[0]["EmpSplAlw"].ToString();

                txtTotal2.Text = (Convert.ToDecimal(txtBasicPay1.Text) + Convert.ToDecimal(txtHRA1.Text) + Convert.ToDecimal(txtPetrol1.Text) + Convert.ToDecimal(txtConvenyance1.Text) + Convert.ToDecimal(txtEmpSplAlw1.Text)).ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var Str1 = "Update EmpMst set ";
            Str1 = Str1 + " EmpBasic='" + Convert.ToDecimal(txtBasicPay1.Text) + "',";
            Str1 = Str1 + " EmpHRA='" + Convert.ToDecimal(txtHRA1.Text) + "',";
            Str1 = Str1 + " EmpPET='" + Convert.ToDecimal(txtPetrol1.Text) + "',";
            Str1 = Str1 + " EmpConv='" + Convert.ToDecimal(txtConvenyance1.Text) + "',";
            Str1 = Str1 + " EmpSplAlw ='" + Convert.ToDecimal(txtEmpSplAlw1.Text.Trim()) + "',";
            Str1 = Str1 + " EmpGrossPay='" + Convert.ToDecimal(txtTotal2.Text.Trim()) + "' where EmpCode='" + empcode.ToString() + "'";
            using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
            {
                sqlcon.Open();
                var sqlcom = new SqlCommand(Str1, sqlcon)
                {
                    CommandType = CommandType.Text
                };
                sqlcom.ExecuteNonQuery();
            }
            var Str2 = "Update EMPMST_MDATA set EmpPassbyUser='" + GlobalVariables.CurrentUser + "',EmpPassbyOn='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "' Where EmpCode='" + empcode + "' And EmpDDate='" + Convert.ToDateTime(empdate).ToString("yyyy-MM-dd") + "'";
            using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
            {
                sqlcon.Open();
                var sqlcom = new SqlCommand(Str2, sqlcon)
                {
                    CommandType = CommandType.Text
                };
                sqlcom.ExecuteNonQuery();
            }
            ProjectFunctions.SpeakError("Salary Structure Has Been Passed");
            Close();
        }
    }
}
