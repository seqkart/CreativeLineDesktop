
using DevExpress.XtraEditors;
using SeqKartLibrary.HelperClass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1.Forms_Master
{
    public partial class frmEmployeeSalaryMstEdit : DevExpress.XtraEditors.XtraForm
    {
        public string s1 { get; set; }
        public string empcode { get; set; }

        public frmEmployeeSalaryMstEdit()
        {
            InitializeComponent();
        }
        private void SetMyControls()
        {
            ProjectFunctions.XtraFormVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);

        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeeSalaryMstEdit_Load(object sender, EventArgs e)
        {
            DtStartDate.EditValue = DateTime.Now;
            SetMyControls();
            var ds = ProjectFunctions.GetDataSet("Select * from EmpMst where EmpCode='" + empcode + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                txtFHName.Text = ds.Tables[0].Rows[0]["EmpFHName"].ToString();
                //////////////////////////
                txtBasicPay.Text = ds.Tables[0].Rows[0]["EmpBasic"].ToString();
                txtHRA.Text = ds.Tables[0].Rows[0]["EmpHRA"].ToString();
                txtPetrol.Text = ds.Tables[0].Rows[0]["EmpPET"].ToString();
                txtConvenyance.Text = ds.Tables[0].Rows[0]["EmpConv"].ToString();
                txtEmpSplAlw.Text = ds.Tables[0].Rows[0]["EmpSplAlw"].ToString();


                //////////////////////////
                txtBasicPay1.Text = ds.Tables[0].Rows[0]["EmpBasic"].ToString();
                txtHRA1.Text = ds.Tables[0].Rows[0]["EmpHRA"].ToString();
                txtPetrol1.Text = ds.Tables[0].Rows[0]["EmpPET"].ToString();
                txtConvenyance1.Text = ds.Tables[0].Rows[0]["EmpConv"].ToString();
                txtEmpSplAlw1.Text = ds.Tables[0].Rows[0]["EmpSplAlw"].ToString();


                if (validateData1())
                {
                    txtTotal2.Text = (Convert.ToDecimal(txtBasicPay1.Text) + Convert.ToDecimal(txtHRA1.Text) + Convert.ToDecimal(txtPetrol1.Text) + Convert.ToDecimal(txtConvenyance1.Text) + Convert.ToDecimal(txtEmpSplAlw1.Text)).ToString();
                }
            }
            txtTotal1.Text = (Convert.ToDecimal(txtBasicPay.Text) + Convert.ToDecimal(txtHRA.Text) + Convert.ToDecimal(txtPetrol.Text) + Convert.ToDecimal(txtConvenyance.Text) + Convert.ToDecimal(txtEmpSplAlw.Text)).ToString();

            if (s1 == "Edit")
            {
                DtStartDate.Properties.ReadOnly = true;

                var ds1 = ProjectFunctions.GetDataSet("Select * from  EMPMST_MDATA where EmpCode='" + empcode + "' And DATEPART(yy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtBasicPay1.Text = ds1.Tables[0].Rows[0]["EmpBasic"].ToString();
                    txtHRA1.Text = ds1.Tables[0].Rows[0]["EmpHRA"].ToString();
                    txtPetrol1.Text = ds1.Tables[0].Rows[0]["EmpPET"].ToString();
                    txtConvenyance1.Text = ds1.Tables[0].Rows[0]["EmpConv"].ToString();
                    txtEmpSplAlw1.Text = ds1.Tables[0].Rows[0]["EmpSplAlw"].ToString();
                }
                else
                {
                    btnSave.Visible = false;
                    ProjectFunctions.SpeakError("No Salary Structure Added For This Employee.");
                }
                if (validateData1())
                {
                    txtTotal2.Text = (Convert.ToDecimal(txtBasicPay1.Text) + Convert.ToDecimal(txtHRA1.Text) + Convert.ToDecimal(txtPetrol1.Text) + Convert.ToDecimal(txtConvenyance1.Text) + Convert.ToDecimal(txtEmpSplAlw1.Text)).ToString();
                }

                ///////
                //var ds2 = ProjectFunctions.GetDataSet("Select * from  EmpMst where EmpCode='" + empcode + "' And DATEPART(yy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'");
                var ds2 = ProjectFunctions.GetDataSet("Select * from  EmpMst where EmpCode='" + empcode + "'");
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    txtBasicPay.Text = ds2.Tables[0].Rows[0]["EmpBasic"].ToString();
                    txtHRA.Text = ds2.Tables[0].Rows[0]["EmpHRA"].ToString();
                    txtPetrol.Text = ds2.Tables[0].Rows[0]["EmpPET"].ToString();
                    txtConvenyance.Text = ds2.Tables[0].Rows[0]["EmpConv"].ToString();
                    txtEmpSplAlw.Text = ds2.Tables[0].Rows[0]["EmpSplAlw"].ToString();
                }
                if (validateData())
                {
                    txtTotal1.Text = (Convert.ToDecimal(txtBasicPay.Text) + Convert.ToDecimal(txtHRA.Text) + Convert.ToDecimal(txtPetrol.Text) + Convert.ToDecimal(txtConvenyance.Text) + Convert.ToDecimal(txtEmpSplAlw.Text)).ToString();
                }
            }
        }


        private void txtBasicPay1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtHRA1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtConvenyance1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtPetrol1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtNAllowance11_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtNAllowance21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtNAllowance31_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtNAllowance41_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtMiscAllowance11_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtMiscAllowance21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private bool validateData()
        {
            if (txtBasicPay.Text.Length == 0)
            {
                txtBasicPay.Text = "0";
            }

            if (txtHRA.Text.Length == 0)
            {
                txtHRA.Text = "0";
            }
            if (txtPetrol.Text.Length == 0)
            {
                txtPetrol.Text = "0";
            }
            if (txtConvenyance.Text.Length == 0)
            {
                txtConvenyance.Text = "0";
            }

            if (txtEmpSplAlw.Text.Length == 0)
            {
                txtEmpSplAlw.Text = "0";
            }

            return true;
        }

        private bool validateData1()
        {
            if (txtBasicPay1.Text.Length == 0)
            {
                txtBasicPay1.Text = "0";
            }

            if (txtHRA1.Text.Length == 0)
            {
                txtHRA1.Text = "0";
            }
            if (txtPetrol1.Text.Length == 0)
            {
                txtPetrol1.Text = "0";
            }
            if (txtConvenyance1.Text.Length == 0)
            {
                txtConvenyance1.Text = "0";
            }

            if (txtEmpSplAlw1.Text.Length == 0)
            {
                txtEmpSplAlw1.Text = "0";
            }

            return true;
        }
        private void EditSalary(bool isAdded)
        {
            var ds1 = ProjectFunctions.GetDataSet("Select * from  EMPMST_MDATA where EmpCode='" + empcode + "' And DATEPART(yy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                var Str = "Update EMPMST_MDATA set ";
                Str = Str + " EmpBasic='" + Convert.ToDecimal(txtBasicPay1.Text) + "',";
                Str = Str + " EmpHRA='" + Convert.ToDecimal(txtHRA1.Text) + "',";
                Str = Str + " EmpPET='" + Convert.ToDecimal(txtPetrol1.Text) + "',";
                Str = Str + " EmpConv='" + Convert.ToDecimal(txtConvenyance1.Text) + "',";
                Str = Str + " EmpDUUserID='" + GlobalVariables.CurrentUser + "',";
                Str = Str + " EmDUDt='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "',";
                Str = Str + "EmpSplAlw ='" + Convert.ToDecimal(txtEmpSplAlw1.Text.Trim()) + "'";
                Str = Str + "  where empcode='" + empcode + "' And DATEPART(yy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'";

                if (ConvertTo.IntVal(Convert.ToDecimal(txtBasicPay1.Text)) != 0)
                {
                    using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
                    {
                        sqlcon.Open();
                        var sqlcom = new SqlCommand(Str, sqlcon)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlcom.ExecuteNonQuery();
                    }
                    if (!isAdded)
                    {
                        EditSalary_2(isAdded);
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Salary Structure Updated.");

                    }
                }
                else
                {
                    ProjectFunctions.SpeakError("Basic Pay can not be 0.");
                }
            }
            else
            {
                XtraMessageBox.Show("Entry Dose not Exists For This Month Year");
            }
        }

        private void EditSalary_2(bool isAdded)
        {
            var ds1 = ProjectFunctions.GetDataSet("Select * from  EmpMST where EmpCode='" + empcode + "'");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                var Str = "Update EmpMST set ";
                Str = Str + " EmpBasic='" + Convert.ToDecimal(txtBasicPay.Text) + "',";
                Str = Str + " EmpHRA='" + Convert.ToDecimal(txtHRA.Text) + "',";
                Str = Str + " EmpPET='" + Convert.ToDecimal(txtPetrol.Text) + "',";
                Str = Str + " EmpConv='" + Convert.ToDecimal(txtConvenyance.Text) + "',";
                Str = Str + " EmpDUUserID='" + GlobalVariables.CurrentUser + "',";
                Str = Str + " EmDUDt='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "',";
                Str = Str + " EmpSplAlw ='" + Convert.ToDecimal(txtEmpSplAlw.Text.Trim()) + "'";
                Str = Str + " Where EmpCode='" + empcode + "'";


                if (ConvertTo.IntVal(Convert.ToDecimal(txtBasicPay.Text)) != 0)
                {
                    using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
                    {
                        sqlcon.Open();
                        var sqlcom = new SqlCommand(Str, sqlcon)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlcom.ExecuteNonQuery();
                    }
                    if (!isAdded)
                    {
                        ProjectFunctions.SpeakError("Salary Structure Updated.");
                    }
                    this.Close();

                }
                else
                {
                    ProjectFunctions.SpeakError("Basic Pay can not be 0.");
                }

            }
            else
            {
                XtraMessageBox.Show("Entry Dose not Exists For This Month Year");
            }
        }

        private void AddSalary()
        {
            var ds1 = ProjectFunctions.GetDataSet("Select * from  EMPMST_MDATA where EmpCode='" + empcode + "' And DATEPART(yy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                XtraMessageBox.Show("Entry Already Exists For Same Month Year");
            }
            else
            {
                bool isInsert = false;
                var Str = "INSERT INTO EMPMST_MDATA(EmpCode,EmpBasic,EmpHRA,EmpPET,EmpConv,EmpDDate,EmpDFUserID,EmDFDt,EmpSplAlw)values(";
                Str = Str + "'" + txtEmpCode.Text.Trim() + "',";
                if (ConvertTo.IntVal(Convert.ToDecimal(txtBasicPay1.Text)) != 0)
                {
                    Str = Str + "'" + Convert.ToDecimal(txtBasicPay1.Text) + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtHRA1.Text) + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtPetrol1.Text) + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtConvenyance1.Text) + "',";
                    Str = Str + "'" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "',";
                    Str = Str + "'" + GlobalVariables.CurrentUser + "',";
                    Str = Str + "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM") + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtEmpSplAlw1.Text) + "')";

                    isInsert = true;
                }
                else if (ConvertTo.IntVal(Convert.ToDecimal(txtBasicPay1.Text)) == 0 && ConvertTo.IntVal(Convert.ToDecimal(txtBasicPay.Text)) != 0)
                {
                    Str = Str + "'" + Convert.ToDecimal(txtBasicPay.Text) + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtHRA.Text) + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtPetrol.Text) + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtConvenyance.Text) + "',";
                    Str = Str + "'" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "',";
                    Str = Str + "'" + GlobalVariables.CurrentUser + "',";
                    Str = Str + "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM") + "',";
                    Str = Str + "'" + Convert.ToDecimal(txtEmpSplAlw.Text) + "')";

                    isInsert = true;
                }
                else
                {
                    isInsert = false;
                }
                //PrintLogWin.PrintLog("AddSalary\n" + Str);
                if (isInsert)
                {
                    using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
                    {
                        sqlcon.Open();
                        var sqlcom = new SqlCommand(Str, sqlcon)
                        {
                            CommandType = CommandType.Text
                        };
                        sqlcom.ExecuteNonQuery();
                    }

                    EditSalary_2(isAdded: true);
                }
                else
                {
                    ProjectFunctions.SpeakError("Basic Pay can not be 0.");
                }
            }
        }

        //private void AddSalary_2()
        //{
        //    var ds1 = ProjectFunctions.GetDataSet("Select * from  EmpMst where EmpCode='" + empcode + "' And DATEPART(yy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'");
        //    if (ds1.Tables[0].Rows.Count > 0)
        //    {
        //        XtraMessageBox.Show("Entry Already Exists For Same Month Year");
        //    }
        //    else
        //    {
        //        var Str = "insert into  EmpMst(EmpCode,EmpBasic,EmpHRA,EmpPET,EmpConv,EmpDDate,EmpDFUserID,EmDFDt,EmpSplAlw)values(";
        //        Str = Str + "'" + txtEmpCode.Text.Trim() + "',";
        //        Str = Str + "'" + Convert.ToDecimal(txtBasicPay.Text) + "',";
        //        Str = Str + "'" + Convert.ToDecimal(txtHRA.Text) + "',";
        //        Str = Str + "'" + Convert.ToDecimal(txtPetrol.Text) + "',";
        //        Str = Str + "'" + Convert.ToDecimal(txtConvenyance.Text) + "',";

        //        Str = Str + "'" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy-MM-dd") + "',";
        //        Str = Str + "'" + GlobalVariables.CurrentUser + "',";
        //        Str = Str + "'" + DateTime.Now.ToString("yyyy-MM-dd hh:MM") + "',";

        //        Str = Str + "'" + Convert.ToDecimal(txtEmpSplAlw.Text) + "')";


        //        using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
        //        {
        //            sqlcon.Open();
        //            var sqlcom = new SqlCommand(Str, sqlcon);
        //            sqlcom.CommandType = CommandType.Text;
        //            sqlcom.ExecuteNonQuery();
        //        }
        //    }
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((txtBasicPay.Text) + "");
            //MessageBox.Show((txtBasicPay1.Text) + "");
            //MessageBox.Show(ConvertTo.IntVal(Convert.ToDecimal(txtBasicPay.Text)) + "");
            //MessageBox.Show(ConvertTo.IntVal(Convert.ToDecimal(txtBasicPay1.Text)) + "");

            if (validateData1())
            {
                if (s1 == "Add")
                {
                    AddSalary();
                    //();//Add in EmpMst
                }
                if (s1 == "Edit")
                {
                    var ds = ProjectFunctions.GetDataSet("Select * from  EMPMST_MDATA where empcode='" + empcode + "' And DATEPART(yy, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("yyyy") + "' And DATEPART(MM, EmpDDate)='" + Convert.ToDateTime(DtStartDate.Text).ToString("MM") + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["EmpPassbyUser"].ToString() == string.Empty)
                        {
                            EditSalary(isAdded: false);
                        }
                        else
                        {
                            XtraMessageBox.Show("Entry Has Already Put Effect On Employee Salary");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("A => No Entry exists For This Month Year");
                    }
                }



                //if ((s1 == "Edit") && (txtBasicPay.Text.Length != 0))
                //{
                //    EditSalary_2(isAdded:false);

                //}


            }
        }
        private void frmEmployeeSalaryMstEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{TAB}");
            }
        }


        private void txtEmpLTCalw1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtTotal1_EditValueChanged(object sender, EventArgs e)
        {
            if (validateData())
            {
                txtTotal1.Text = (Convert.ToDecimal(txtBasicPay.Text) + Convert.ToDecimal(txtHRA.Text) + Convert.ToDecimal(txtPetrol.Text) + Convert.ToDecimal(txtConvenyance.Text) + Convert.ToDecimal(txtEmpSplAlw.Text)).ToString();
            }
        }

        private void txtTotal2_EditValueChanged(object sender, EventArgs e)
        {
            if (validateData1())
            {
                txtTotal2.Text = (Convert.ToDecimal(txtBasicPay1.Text) + Convert.ToDecimal(txtHRA1.Text) + Convert.ToDecimal(txtPetrol1.Text) + Convert.ToDecimal(txtConvenyance1.Text) + Convert.ToDecimal(txtEmpSplAlw1.Text)).ToString();
            }
        }


    }
}