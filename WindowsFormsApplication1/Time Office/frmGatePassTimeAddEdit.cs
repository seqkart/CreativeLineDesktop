﻿using Dapper;
using SeqKartLibrary;
using SeqKartLibrary.Repository;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using WindowsFormsApplication1;
namespace BNPL.Forms_Transaction
{
    public partial class frmGatePassTimeAddEdit : DevExpress.XtraEditors.XtraForm
    {


#pragma warning disable CS0414 // The field 'frmGatePassTimeAddEdit.VoucehrNo' is assigned but its value is never used
        string VoucehrNo = string.Empty;
#pragma warning restore CS0414 // The field 'frmGatePassTimeAddEdit.VoucehrNo' is assigned but its value is never used
#pragma warning disable CS0169 // The field 'frmGatePassTimeAddEdit.VoucherDate' is never used
        DateTime VoucherDate;
#pragma warning restore CS0169 // The field 'frmGatePassTimeAddEdit.VoucherDate' is never used
#pragma warning disable CS0414 // The field 'frmGatePassTimeAddEdit.VoucherType' is assigned but its value is never used
        string VoucherType = string.Empty;
#pragma warning restore CS0414 // The field 'frmGatePassTimeAddEdit.VoucherType' is assigned but its value is never used



        public string s1 { get; set; }
        public int serial_id { get; set; }
        public frmGatePassTimeAddEdit()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetMyControls()
        {
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
        }


        //private void GetBasicDetail()
        //{
        //    string sql = "Select"
        //    + " (isnull(EmpBasic,0) "
        //    + " + isnull(EmpHRA,0) "
        //    + " + isnull(EmpConv,0) "
        //    + " + isnull(EmpPET,0) "
        //    + " + isnull(EmpMscA1,0) "
        //    + " + isnull(EmpMscA2,0) "
        //    + " + isnull(EmpCHstlAlw,0) "
        //    + " + isnull(EmpProDevAlw,0) "
        //    + " + isnull(EmpNewsPapAlw,0) "
        //    + " + isnull(EmpMedAlw,0) "
        //    + " + isnull(EmpUnformAlw,0) "
        //    + " + isnull(EmpSplAlw,0)) as EmpSalary"
        //    + " , isnull(EmpxBasic,0) as EmpSalaryC"
        //    + " , EmpDummy"
        //    + " , EmpDOL from EmpMst Where EmpCode='" + txtEmpCode.Text + "'";

        //    //DataSet ds = ProjectFunctions.GetDataSet("Select  isnull(EmpBasic,0) + isnull(EmpHRA,0) +isnull(EmpConv,0) +isnull(EmpPET,0) +isnull(EmpMscA1,0) +isnull(EmpMscA2,0) +isnull(EmpCHstlAlw,0) +isnull(EmpProDevAlw,0) +isnull(EmpNewsPapAlw,0) +isnull(EmpMedAlw,0) +isnull(EmpUnformAlw,0) +isnull(EmpSplAlw,0) as EmpSalary,isnull(EmpxBasic,0) as EmpSalaryC ,EmpDummy,EmpDOL from EmpMst Where EmpCode='" + txtEmpCode.Text + "'");
        //    //DataSet ds = ProjectFunctions.GetDataSet(sql);
        //    //txtSalary.Text = ds.Tables[0].Rows[0][0].ToString();
        //}

        private void frmGatePassTimeAddEdit_Load(object sender, EventArgs e)
        {
            SetMyControls();
            if (s1 == "Add")
            {
                DtDate.Enabled = false;
                DtDate.EditValue = DateTime.Now;
                //DtDateforMonth.EditValue = DateTime.Now;
                //txtAdvanceNo.Text = getNewLoanPassNo().PadLeft(6, '0');
                //txtStatusCode.Text = "A";
                txtEmpCode.Focus();
            }
            if (s1 == "Edit")
            {
                //DtDateforMonth.Enabled = false;
                DtDate.Enabled = false;
                txtStatusCode.Enabled = false;

                //string str = "SELECT "
                //+ " ExMst.ExPostHead, "
                //+ " ExMst.ExVoucherType, "
                //+ " ExMst.ExVoucherNo, "
                //+ " ExMst.ExVoucherDt, "
                //+ " ExMst.ExNo, "
                //+ " ExMst.ExId, "
                //+ " ExMst.ExDate, "
                //+ " ExMst.ExEmpCode, "
                //+ " ExMst.ExAmt, "
                //+ " ExMst.ExTag, "
                //+ " ExMst.ExDatePost, "
                //+ " ExMst.ExLoadTag, "
                //+ " ExMst.ExEmpCCode, "
                //+ " ExMst.ExFedDate, "
                //+ " ExMst.ExLoadedDate, "
                //+ " empmst.EmpName, "                
                //+ " actmst.AccName "
                //+ " FROM ExMst "
                //+ " LEFT OUTER JOIN EmpMST ON ExMst.ExEmpCode = empmst.EmpCode "                
                //+ " LEFT OUTER JOIN ActMst ON ExMst.ExPostHead = actmst.AccCode "
                //+ " WHERE ExId='" + ExId + "';" +
                //"";

                string str = "sp_GatePassData_Single " + serial_id + "";

                PrintLogWin.PrintLog(str);

                var ds = ProjectFunctionsUtils.GetDataSet(str);
                
                try
                {
                    //txtAdvanceNo.Text = ds.Tables[0].Rows[0]["ExNo"].ToString();
                    DtDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["AttendanceDate"]);
                    //DtDateforMonth.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ExDatePost"]);
                    txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                    txtEmpCodeDesc.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    txtStatusCode.Text = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                    txtStatusCodeDesc.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                }
                catch(Exception ex)
                {
                    PrintLogWin.PrintLog(ex);
                }

                //GetBasicDetail();

            }
        }
        private bool ValidateData()
        {

            if (DtDate.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Invalid Date", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DtDate.Focus();
                return false;
            }
            
            if (txtEmpCode.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Invalid EmpName", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEmpCode.Focus();
                return false;
            }
            if (txtEmpCodeDesc.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Invalid EmpName", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEmpCode.Focus();
                return false;
            }

            if (txtStatusCode.Text.Trim().Length == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Invalid Status", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtStatusCode.Focus();
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {



                var str = "sp_GatePassData_AddEdit";
                RepGen reposGen = new RepGen();
                DynamicParameters param = new DynamicParameters();
                param.Add("@serial_id", serial_id);
                param.Add("@entry_date", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd"));
                param.Add("@status_id", txtStatusCode.Text);
                param.Add("@employee_code", txtEmpCode.Text);
                param.Add("@attendance_date", Convert.ToDateTime(DtDate.Text).ToString("yyyy-MM-dd"));
                param.Add("@attendance_out", timeEdit_Time_Out.Text);
                param.Add("@attendance_in", timeEdit_Time_In.Text);
                param.Add("@gate_pass_time", 1);                

                string intResult = reposGen.executeNonQuery_SP(str, param);
                if (intResult.Equals("0"))
                {
                    ProjectFunctions.SpeakError("Record has been saved");
                }
                else
                {
                    ProjectFunctions.SpeakError("Error in save record.");
                    PrintLogWin.PrintLog(intResult);
                }
                this.Close();
            }
            catch(Exception ex)
            {
                ProjectFunctions.SpeakError("Error in save record.");
                PrintLogWin.PrintLog(ex);
            }
        }
        private void btnSave1_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                if (s1 == "Add")
                {
                    if (ValidateData())
                    {
                        String DocNo = getNewLoanPassNo().PadLeft(6, '0');
                        var str = "Insert into ExMst(ExDate,ExEmpCode,ExAmt,ExTag,ExDatePost,ExFedDate,ExNo";
                        str = str + ")values(";
                        str = str + "'" + Convert.ToDateTime(DtDate.Text).ToString("yyyy-MM-dd") + "',";
                        str = str + "'" + txtEmpCode.Text.Trim() + "',";
                        str = str + "'" + Convert.ToDecimal(txtAmount.Text) + "',";
                        str = str + "'" + txtStatus.Text.Trim() + "',";
                        str = str + "'" + Convert.ToDateTime(DtDateforMonth.Text).ToString("yyyy-MM-dd") + "',";
                        str = str + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DocNo + "')";
                                               

                        using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(str, sqlcon);
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();

                            sqlcon.Close();
                            //clear();
                        }
                        ProjectFunctions.SpeakError("Data has been saved.");
                        this.Close();
                    }
                }
                if (s1 == "Edit")
                {
                    if (ValidateData())
                    {
                        var str = " UPDATE    ExMst";
                        str = str + " SET  ";
                        str = str + " ExEmpCode='" + txtEmpCode.Text.Trim() + "',";
                        str = str + " ExAmt='" + Convert.ToDecimal(txtAmount.Text) + "',";
                        str = str + " ExTag='" + txtStatus.Text.Trim() + "',";

                        str = str + " ExFedDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where ExId='" + serial_id + "'";
                        using (var sqlcon = new SqlConnection(ProjectFunctions.ConnectionString))
                        {
                            sqlcon.Open();
                            var sqlcom = new SqlCommand(str, sqlcon);
                            sqlcom.CommandType = CommandType.Text;
                            sqlcom.ExecuteNonQuery();
                            sqlcom.Parameters.Clear();


                            sqlcon.Close();
                            //clear();
                        }
                        ProjectFunctions.SpeakError("Data has been saved.");
                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private string getNewLoanPassNo()
        {
            var s2 = string.Empty;

            var strsql = string.Empty;
            var ds = new DataSet();
            strsql = strsql + "select isnull(max(Cast(ExNo as int)),00000) from ExMst";

            ds = ProjectFunctionsUtils.GetDataSet(strsql);
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
            //txtAmount.Text = string.Empty;
            //txtSalary.Text = string.Empty;
            //txtType.Text = string.Empty;
            s1 = "Add";
            txtEmpCode.Focus();
            Text = "GatePass Time Addition";
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtOthersGiven_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProjectFunctions.NumericWithDecimal(e);
        }

        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpCodeDesc.Text = string.Empty;
        }

        private void txtStatusCode_EditValueChanged(object sender, EventArgs e)
        {
            txtStatusCodeDesc.Text = string.Empty;
        }





        private void PrepareEmpGrid()
        {
            HelpGridView.Columns.Clear();
            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[0].Visible = true;
            HelpGridView.Columns[0].Caption = "Description";
            HelpGridView.Columns[0].FieldName = "Description";
            HelpGridView.Columns[0].OptionsColumn.AllowEdit = false;
            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[1].Visible = true;
            HelpGridView.Columns[1].Caption = "EmpFHName";
            HelpGridView.Columns[1].FieldName = "EmpFHName";
            HelpGridView.Columns[1].OptionsColumn.AllowEdit = false;
            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[2].Visible = true;
            HelpGridView.Columns[2].Caption = "Code";
            HelpGridView.Columns[2].FieldName = "Code";
            HelpGridView.Columns[2].OptionsColumn.AllowEdit = false;
        }


        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                PrepareEmpGrid();
                var strQry = string.Empty;
                HelpGrid.Text = "txtEmpCode";
                var ds = new DataSet();
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtEmpCode.Text.Length == 0)
                    {
                        strQry = strQry + "select Empcode as Code,Empname as Description,EmpFHName from EmpMst  order by Empname";
                        ds = ProjectFunctions.GetDataSet(strQry);
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGridView.BestFitColumns();
                        HelpGrid.Show();
                        HelpGrid.Focus();
                    }
                    else
                    {
                        strQry = strQry + "select empcode as Code,empname as Description,EmpFHName from EmpMst wHERE  empcode= '" + txtEmpCode.Text.ToString().Trim() + "' ";

                        ds = ProjectFunctions.GetDataSet(strQry);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtEmpCode.Text = ds.Tables[0].Rows[0]["Code"].ToString().Trim().ToUpper();
                            txtEmpCodeDesc.Text = ds.Tables[0].Rows[0]["Description"].ToString().Trim().ToUpper();
                            txtStatusCode.Focus();
                            
                        }
                        else
                        {
                            var strQry1 = string.Empty;
                            strQry1 = strQry1 + "select empcode as Code,empname as Description,EmpFHName from EmpMst  order by Empname";
                            var ds1 = ProjectFunctions.GetDataSet(strQry1);
                            HelpGrid.DataSource = ds1.Tables[0];
                            HelpGridView.BestFitColumns();
                            HelpGrid.Show();
                            HelpGrid.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            e.Handled = true;
        }

        private void txtStatusCode_KeyDown(object sender, KeyEventArgs e)
        {
            ProjectFunctions.CreatePopUpForTwoBoxes("Select status_code AS Code,status AS Description from GatePassStatus", " Where status_code", txtStatusCode, txtStatusCodeDesc, txtStatusCode, HelpGrid, HelpGridView, e);
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
                txtEmpCode.Text = row["Code"].ToString().Trim();
                txtEmpCodeDesc.Text = row["Description"].ToString().Trim();
                HelpGrid.Visible = false;
                txtStatusCode.Focus();
            }
            if (HelpGrid.Text == "txtStatusCode")
            {
                txtStatusCode.Text = row["Code"].ToString().Trim();
                txtStatusCodeDesc.Text = row["Description"].ToString().Trim();
                HelpGrid.Visible = false;
                timeEdit_Time_Out.Focus();
            }
            //if (HelpGrid.Text == "ERMCode")
            //{
            //    txtContCode.Text = row["ERMCode"].ToString().Trim();
            //    txtContCodeDesc.Text = row["ERMDesc"].ToString().Trim();
            //    HelpGrid.Visible = false;
            //    txtEmpCode.Focus();
            //}

        }

        //private void txtType_Validating(object sender, CancelEventArgs e)
        //{
        //    if (txtStatusCode.Text == "A" || txtStatusCode.Text == "C" || txtStatusCode.Text == "F" || txtStatusCode.Text == "L" || txtStatusCode.Text == "T")
        //    {
        //    }
        //    else
        //    {
        //        DevExpress.XtraEditors.XtraMessageBox.Show("Valid Values are Advance(a),Fine(F),Coupon(C),Telephone(T),Lunch(L)", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //        txtStatusCode.Focus();
        //    }
        //}

        private void frmGatePassTimeAddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up)
                {
                    System.Windows.Forms.SendKeys.Send("+{TAB}");
                }

                if (e.Control && e.KeyCode == Keys.S)
                {
                    btnSave.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtContCode_EditValueChanged(object sender, EventArgs e)
        {
            //txtContCodeDesc.Text = string.Empty;
        }
        private void PrepareContGrid()
        {
            HelpGridView.Columns.Clear();
            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[0].Visible = true;
            HelpGridView.Columns[0].Caption = "ERMDesc";
            HelpGridView.Columns[0].FieldName = "ERMDesc";
            HelpGridView.Columns[0].OptionsColumn.AllowEdit = false;
            HelpGridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
            HelpGridView.Columns[1].Visible = true;
            HelpGridView.Columns[1].Caption = "ERMCode";
            HelpGridView.Columns[1].FieldName = "ERMCode";
            HelpGridView.Columns[1].OptionsColumn.AllowEdit = false;
        }


        private void txtContCode_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    PrepareContGrid();
            //    var strQry = string.Empty;
            //    HelpGrid.Text = "ERMCode";
            //    var ds = new DataSet();
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (txtContCode.Text.Length == 0)
            //        {
            //            strQry = strQry + "select * from EmpEmplrRef ";
            //            ds = ProjectFunctions.GetDataSet(strQry);
            //            HelpGrid.DataSource = ds.Tables[0];
            //            HelpGridView.BestFitColumns();
            //            HelpGrid.Show();
            //            HelpGrid.Focus();
            //        }
            //        else
            //        {
            //            strQry = strQry + "select * from EmpEmplrRef  wHERE  ERMCode= '" + txtContCode.Text.ToString().Trim() + "'";

            //            ds = ProjectFunctions.GetDataSet(strQry);
            //            if (ds.Tables[0].Rows.Count > 0)
            //            {
            //                txtContCode.Text = ds.Tables[0].Rows[0]["ERMCode"].ToString().Trim();
            //                txtContCodeDesc.Text = ds.Tables[0].Rows[0]["ERMDesc"].ToString().Trim();
            //                txtEmpCode.Focus();
            //            }
            //            else
            //            {
            //                var strQry1 = string.Empty;
            //                strQry1 = strQry1 + "select * from EmpEmplrRef ";
            //                var ds1 = ProjectFunctions.GetDataSet(strQry1);
            //                HelpGrid.DataSource = ds1.Tables[0];
            //                HelpGridView.BestFitColumns();
            //                HelpGrid.Show();
            //                HelpGrid.Focus();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //e.Handled = true;
        }

        private void txtPostHeadCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPostHeadCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                HelpGridView.Columns.Clear();
                var strQry = string.Empty;
                HelpGrid.Text = "POST";
                var ds = new DataSet();
                if (e.KeyCode == Keys.Enter)
                {
                    strQry = strQry + "SELECT   AccCode, ActMst.AccName from ActMst ";
                    ds = ProjectFunctions.GetDataSet(strQry);
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGridView.BestFitColumns();
                    HelpGrid.Show();
                    HelpGrid.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            e.Handled = true;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (s1 == "Add")
            {
                if (txtPassword.Text == "ADV123")
                {
                    DtDate.Enabled = true;
                }
            }
        }

        private void txtEmpCode_Leave(object sender, EventArgs e)
        {
        }

        private void txtEmpCode_Enter(object sender, EventArgs e)
        {

        }

        private void txtType_Leave(object sender, EventArgs e)
        {

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null, e);
            }
        }
    }
}