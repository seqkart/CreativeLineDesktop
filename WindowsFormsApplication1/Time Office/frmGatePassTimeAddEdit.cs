using Dapper;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using SeqKartLibrary;
using SeqKartLibrary.HelperClass;
using SeqKartLibrary.Repository;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.FormReports;

namespace WindowsFormsApplication1.Forms_Transaction
{
    public partial class frmGatePassTimeAddEdit : DevExpress.XtraEditors.XtraForm
    {
#pragma warning restore CS0414 // The field 'frmGatePassTimeAddEdit.VoucherType' is assigned but its value is never used



        public string s1 { get; set; }
        public string employee_code { get; set; }
        public string attendance_date { get; set; }

        private string securityPassword = string.Empty;


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

            ProjectFunctions.GirdViewVisualize(gridView_GatePassData);


        }

        //private DataSet dsMain;
        private void frmGatePassTimeAddEdit_Load(object sender, EventArgs e)
        {
            securityPassword = ProjectFunctionsUtils.GetDateChangePassword();
            PrintLogWin.PrintLog(securityPassword);

            PrintPrivewButton.Enabled = false;
            PrintButton.Enabled = false;


            SetMyControls();
            if (s1 == "Add")
            {
                //DtDate.Enabled = false;
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
                txtEmpCode.Enabled = false;

                DtDate.EditValue = attendance_date;
                txtEmpCode.EditValue = employee_code;

                try
                {
                    SetFormValues(0, employee_code, attendance_date, 0);
                    //if (ComparisonUtils.IsNotNull_DataSet(dsMain))
                    //{
                    //gridControl_GatePassData.DataSource = dsMain.Tables[0];
                    //gridView_GatePassData.BestFitColumns();


                    //DtDate.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["AttendanceDate"]);
                    //txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                    //txtEmpCodeDesc.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    //txtStatusCode.Text = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                    //txtStatusCodeDesc.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                    //}

                }
                catch (Exception ex)
                {
                    PrintLogWin.PrintLog(ex);
                }



            }
        }

        private void SetFormValues(int rowIndex, string _employee_code, string _attendance_date, int _serial_id)
        {

            try
            {
                string str = "sp_GatePassData_Single '" + _employee_code + "', '" + ConvertTo.DateFormatDb(ConvertTo.DateTimeVal(_attendance_date)) + "', " + _serial_id + string.Empty;

                PrintLogWin.PrintLog(str);

                DataSet _ds = ProjectFunctionsUtils.GetDataSet(str);

                if (ComparisonUtils.IsNotNull_DataSet(_ds))
                {
                    DataRow dr = _ds.Tables[0].Rows[rowIndex];
                    DtDate.EditValue = Convert.ToDateTime(dr["AttendanceDate"]);
                    txtEmpCode.Text = dr["EmpCode"].ToString();
                    txtEmpCode.Tag = dr["SerialId"].ToString();

                    txtEmpCodeDesc.Text = dr["EmpName"].ToString();
                    txtEmpCodeDesc.Tag = dr["DeptDesc"].ToString();

                    txtStatusCode.Text = dr["StatusCode"].ToString();
                    txtStatusCode.Tag = dr["UnitName"].ToString();

                    txtStatusCodeDesc.Text = dr["Status"].ToString();

                    timeEdit_Time_Out.EditValue = dr["TimeOut"].ToString();
                    timeEdit_Time_In.EditValue = dr["TimeIn"].ToString();

                    pictureBox1.Image = ImageUtils.ConvertBinaryToImage((byte[])dr["EmpImage"]);

                    PrintLogWin.PrintLog("TimeOut " + dr["TimeOut"].ToString());
                    PrintLogWin.PrintLog("TimeIn " + dr["TimeIn"].ToString());

                    ////////////////////////
                    /*XtraReportGatePass report = new XtraReportGatePass(
                    dr["EmpCode"].ToString(),
                    ConvertTo.IntVal(dr["SerialId"].ToString()),
                    dr["EmpName"].ToString(),
                    dr["DeptDesc"].ToString() + "",
                    dr["UnitName"].ToString() + "",
                    "",
                    dr["Status"].ToString(),
                    timeEdit_Time_Out.EditValue + "",
                    timeEdit_Time_In.EditValue + "",
                    pictureBox1.Image
                    );*/

                }
                else
                {
                    //clear();
                }

            }
            catch (Exception ex)
            {
                PrintLogWin.PrintLog(ex);
                //                clear();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int serial_id = ConvertTo.IntVal(txtEmpCode.Tag);

                var str = "sp_GatePassData_AddEdit";
                RepGen reposGen = new RepGen();
                DynamicParameters param = new DynamicParameters();
                param.Add("@serial_id", serial_id);
                param.Add("@entry_date", ConvertTo.DateFormatDb(DateTime.Now));//Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd")
                param.Add("@status_id", txtStatusCode.Text);
                param.Add("@employee_code", txtEmpCode.Text);
                param.Add("@attendance_date", ConvertTo.DateFormatDb(ConvertTo.DateTimeVal(DtDate.Text)));//Convert.ToDateTime(DtDate.Text).ToString("yyyy-MM-dd")
                param.Add("@attendance_out", timeEdit_Time_Out.Text);
                param.Add("@attendance_in", timeEdit_Time_In.Text);

                param.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("@Returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                string intResult = reposGen.executeNonQuery_SP(str, param);
                if (intResult.Equals("0"))
                {
                    int outputVal = param.Get<int>("@output");
                    int returnVal = param.Get<int>("@Returnvalue");

                    PrintLogWin.PrintLog("outputVal => " + outputVal);
                    PrintLogWin.PrintLog("returnVal => " + returnVal);

                    txtEmpCode.Tag = outputVal;
                    ProjectFunctions.SpeakError("Record has been saved");
                    LoadGatePassDataGrid();

                }
                else
                {
                    ProjectFunctions.SpeakError("Error in save record.");
                    PrintLogWin.PrintLog(intResult);
                }
                //this.Close();
            }
            catch (Exception ex)
            {
                ProjectFunctions.SpeakError("Error in save record.");
                PrintLogWin.PrintLog(ex);
            }
        }

        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpCodeDesc.Text = string.Empty;

            if (txtEmpCode.Text.Length >= 4 && DtDate.Text.Length >= 8)
            {
                LoadGatePassDataGrid();
            }
        }

        private void DtDate_EditValueChanged(object sender, EventArgs e)
        {
            if (txtEmpCode.Text.Length >= 4 && DtDate.Text.Length >= 8)
            {
                LoadGatePassDataGrid();
            }

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
                        strQry = strQry + "select Empcode as Code,Empname as Description,EmpImage from EmpMst  order by Empname";
                        ds = ProjectFunctions.GetDataSet(strQry);
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGridView.BestFitColumns();
                        HelpGrid.Show();
                        HelpGrid.Focus();
                    }
                    else
                    {
                        strQry = strQry + "select empcode as Code,empname as Description,EmpImage from EmpMst wHERE  empcode= '" + txtEmpCode.Text.ToString().Trim() + "' ";

                        ds = ProjectFunctions.GetDataSet(strQry);
                        if (ds.Tables[0].Rows.Count > 0)

                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            txtEmpCode.Text = dr["Code"].ToString().Trim().ToUpper();
                            txtEmpCodeDesc.Text = dr["Description"].ToString().Trim().ToUpper();
                            pictureBox1.Image = ImageUtils.ConvertBinaryToImage((byte[])dr["EmpImage"]);
                            txtStatusCode.Focus();

                        }
                        else
                        {
                            var strQry1 = string.Empty;
                            strQry1 = strQry1 + "select empcode as Code,empname as Description,EmpImage from EmpMst  order by Empname";
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
                pictureBox1.Image = ImageUtils.ConvertBinaryToImage((byte[])row["EmpImage"]);

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

        }


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



        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (s1 == "Add")
            {
                if (txtPassword.Text == securityPassword)
                {


                }
            }

        }

        public void LoadGatePassDataGrid()
        {
            PrintLogWin.PrintLog("LoadGatePassDataGrid => GlobalVariables.ProgCode ******************** : " + GlobalVariables.ProgCode);
            try
            {
                gridView_GatePassData.Columns.Clear();

                string _storedProcedre = SQL_QUERIES.sp_GatePassData_Daily_List() + " '" + txtEmpCode.EditValue + "', '" + ConvertTo.DateFormatDb(DtDate.EditValue) + "'";
                //DataSet ds = ProgramMasterData.GetData(GlobalVariables.ProgCode, _params);
                DataSet _ds = ProjectFunctionsUtils.GetDataSet(_storedProcedre);

                if (_ds.Tables[0].Rows.Count > 0)
                {
                    gridControl_GatePassData.DataSource = _ds.Tables[0];
                    gridView_GatePassData.BestFitColumns();

                    ////////////////////


                    PrintPrivewButton.Enabled = true;
                    PrintButton.Enabled = true;

                }
                else
                {
                    gridControl_GatePassData.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString().Trim());
            }
        }

        private void gridControl_GatePassData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //int rowIndex = (gridControl_GatePassData.FocusedView as ColumnView).FocusedRowHandle;

                ColumnView detailView = (ColumnView)gridControl_GatePassData.FocusedView;

                int cellValue_serial_id = ConvertTo.IntVal(detailView.GetFocusedRowCellValue("SerialId"));
                string date_value = detailView.GetFocusedRowCellValue("Date") + string.Empty;


                SetFormValues(0, employee_code, date_value, cellValue_serial_id);
            }
            catch (Exception ex)
            {
                PrintLogWin.PrintLog(ex);

            }
        }

        private void PrintPrivewButton_Click(object sender, EventArgs e)
        {
            //DVPrintPreviewDialog.Document = DVPrintDocument;
            //DVPrintPreviewDialog.ShowDialog();

            XtraReportGatePass report = new XtraReportGatePass(
                txtEmpCode.Text,
                ConvertTo.IntVal(txtEmpCode.Tag),
                txtEmpCodeDesc.Text,
                txtEmpCodeDesc.Tag + string.Empty,
                txtStatusCode.Tag + string.Empty,
string.Empty,
                txtStatusCodeDesc.Text,
                timeEdit_Time_Out.EditValue + string.Empty,
                timeEdit_Time_In.EditValue + string.Empty,
                pictureBox1.Image
                );

            //report.Parameters["EmpCode"].Value = txtEmpCode.Text;
            //report.Parameters["employee_name"].Value = txtEmpCodeDesc.Text;
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }

        private void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fontStyle = new Font("Segoe UI", 8.25f, FontStyle.Regular);
            Brush colorBrush = Brushes.Black;

            e.Graphics.DrawString(lblDate.Text, fontStyle, colorBrush, new Point(lblDate.Location.X, lblDate.Location.Y));
            e.Graphics.DrawString(DtDate.Text, fontStyle, colorBrush, new Point(DtDate.Location.X, DtDate.Location.Y));

            e.Graphics.DrawString(lblEmpCode.Text, fontStyle, colorBrush, new Point(lblEmpCode.Location.X, lblEmpCode.Location.Y));
            e.Graphics.DrawString(txtEmpCode.Text, fontStyle, colorBrush, new Point(txtEmpCode.Location.X, txtEmpCode.Location.Y));
            e.Graphics.DrawString(txtEmpCodeDesc.Text, fontStyle, colorBrush, new Point(txtEmpCodeDesc.Location.X, txtEmpCodeDesc.Location.Y));

            e.Graphics.DrawString(lblStatusCode.Text, fontStyle, colorBrush, new Point(lblStatusCode.Location.X, lblStatusCode.Location.Y));
            e.Graphics.DrawString(txtStatusCode.Text, fontStyle, colorBrush, new Point(txtStatusCode.Location.X, txtStatusCode.Location.Y));
            e.Graphics.DrawString(txtStatusCodeDesc.Text, fontStyle, colorBrush, new Point(txtStatusCodeDesc.Location.X, txtStatusCodeDesc.Location.Y));

            e.Graphics.DrawString(lblTimeOut.Text, fontStyle, colorBrush, new Point(lblTimeOut.Location.X, lblTimeOut.Location.Y));
            e.Graphics.DrawString(timeEdit_Time_Out.Text, fontStyle, colorBrush, new Point(timeEdit_Time_Out.Location.X, timeEdit_Time_Out.Location.Y));

            e.Graphics.DrawString(lblTimeIn.Text, fontStyle, colorBrush, new Point(lblTimeIn.Location.X, lblTimeIn.Location.Y));
            e.Graphics.DrawString(timeEdit_Time_In.Text, fontStyle, colorBrush, new Point(timeEdit_Time_In.Location.X, timeEdit_Time_In.Location.Y));
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            XtraReportGatePass report = new XtraReportGatePass(
                txtEmpCode.Text,
                ConvertTo.IntVal(txtEmpCode.Tag),
                txtEmpCodeDesc.Text,
                txtEmpCodeDesc.Tag + string.Empty,
                txtStatusCode.Tag + string.Empty,
string.Empty,
                txtStatusCodeDesc.Text,
                timeEdit_Time_Out.EditValue + string.Empty,
                timeEdit_Time_In.EditValue + string.Empty,
                pictureBox1.Image
                );
            ReportPrintTool printTool = new ReportPrintTool(report);
            // Invoke the Print dialog.
            printTool.PrintDialog();
            // Send the report to the default printer.
            //printTool.Print();
        }
    }
}
