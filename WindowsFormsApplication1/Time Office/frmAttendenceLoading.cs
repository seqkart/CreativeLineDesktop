using Dapper;
using DevExpress.Charts.Native;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using HumanResourceManagementSystem;
using SeqKartLibrary;
using SeqKartLibrary.CrudTask;
using SeqKartLibrary.HelperClass;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1;
using WindowsFormsApplication1.Models;
using WindowsFormsApplication1.Time_Office;

namespace BNPL.Forms_Master
{

    public partial class frmAttendenceLaoding : XtraForm
    {
        private DataTable dt = new DataTable();
        public frmAttendenceLaoding()
        {
            InitializeComponent();

            btnRefresh.Visible = false;
            btnLoad.Visible = false;
            btnSave.Visible = false;
            btnAdd2.Visible = false;
            btnQuit.Visible = false;
            toolStripButton1.Visible = false;

            //gridView_AttendanceData.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            gridView_AttendanceData.OptionsBehavior.Editable = false;

            dt.Columns.Add("MonthYear", typeof(String));
            dt.Columns.Add("EmpCode", typeof(String));
            dt.Columns.Add("EmpName", typeof(String));
            dt.Columns.Add("EmpDW", typeof(Decimal));
            dt.Columns.Add("EmpPH", typeof(Decimal));
            dt.Columns.Add("EmpEL", typeof(Decimal));
            dt.Columns.Add("EmpCL", typeof(Decimal));
            dt.Columns.Add("EmpSL", typeof(Decimal));
            dt.Columns.Add("EmpPymtMode", typeof(String));



        }

        private void SetMyControls1()
        {
            //panelControl1.Location = new Point(ClientSize.Width / 2 - panelControl1.Size.Width / 2, ClientSize.Height / 2 - panelControl1.Size.Height / 2);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.DatePickerVisualize(this);
            ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            ProjectFunctions.TextBoxVisualize(this);
            ProjectFunctions.ButtonVisualize(this);
            //ProjectFunctions.GroupCtrlVisualize(panelControl1);
            ProjectFunctions.XtraFormVisualize(this);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmExcelDataLoading_Load(object sender, EventArgs e)
        {
            PrintLogWin.PrintLog("*[ frmExcelDataLoading_Load ]*");
            //SetMyControls();
            SetMyControls2();

            LoadAttendanceDataGrid();

        }


        public void LoadAttendanceDataGrid()
        {
            //ProgramMasterModel programMaster = ProgramMasterData.GetProgramMasterModel(GlobalVariables.ProgCode);

            //DataSet ds = ProjectFunctions.GetDataSet("Select ProgProcName,ProgDesc from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'");
            //string ProcedureName = ds.Tables[0].Rows[0]["ProgProcName"].ToString();

            PrintLogWin.PrintLog("LoadAttendanceDataGrid => GlobalVariables.ProgCode ******************** " + GlobalVariables.ProgCode);
            //PrintLogWin.PrintLog("LoadAttendanceDataGrid => ProcedureName Dapper ******************** " + programMaster.ProgProcName);
            //PrintLogWin.PrintLog("LoadAttendanceDataGrid => ProcedureName B ******************** " + ProcedureName);


            //List<AttendanceModel> att = ProgramMasterData.GetData<AttendanceModel>(GlobalVariables.ProgCode);
            //PrintLogWin.PrintLog("LoadAttendanceDataGrid => att ******************** " + att.Count);


            gridView_AttendanceData.Columns.Clear();

            string _params = "'" + txtEmpCode.EditValue + "', '" + ConvertTo.DateTimeVal(DtStartDate.EditValue).ToString("yyyy-MM-dd") + "'";
            DataSet att_ds = ProgramMasterData.GetData(GlobalVariables.ProgCode, _params);

            if (ComparisonUtils.IsNotNull_DataSet(att_ds))
            {
                BindingList<object> binding_list = new BindingList<object>();

                foreach (DataRow dr in att_ds.Tables[0].Rows)
                {
                    var employeeAttendance = new
                    {
                        SerialId = dr[Col.EmployeeAttendance.serial_id],
                        //EntryDate = dr[Col.EmployeeAttendance.entry_date],
                        AttendanceDate = ConvertTo.DateFormatApp(dr[Col.EmployeeAttendance.attendance_date]),
                        EmployeeCode = dr[Col.EmployeeAttendance.employee_code],
                        //Shift = dr[Col.DailyShifts.shift_name],
                        Status = dr[Col.AttendanceStatus.status],
                        TimeIn_First = dr[Col.EmployeeAttendance.attendance_in_first],
                        TimeOut_First = dr[Col.EmployeeAttendance.attendance_out_first],
                        TimeIn_Last = dr[Col.EmployeeAttendance.attendance_in_last],
                        TimeOut_Last = dr[Col.EmployeeAttendance.attendance_out_last],
                        WorkingHours = ConvertTo.MinutesToHours(dr[Col.EmployeeAttendance.working_hours]),                        
                        OverTime = ConvertTo.MinutesToHours(dr[Col.EmployeeAttendance.ot_deducton_time]),
                        GatePassTime = dr[Col.EmployeeAttendance.gate_pass_time],
                        Source = dr[Col.AttendanceSource.source_name],
                        RowStyle = dr[Col.GridStyle.Row_Style]
                    };
                    //ConvertTo.DateTimeVal(dr[Col.EmployeeAttendance.attendance_in_first]).ToString("hh:mm tt")

                    binding_list.Add(employeeAttendance);
                }

                gridControl_AttendanceData.DataSource = binding_list;
                if (gridView_AttendanceData.Columns["SerialId"] != null)
                {
                    gridView_AttendanceData.Columns["SerialId"].Visible = false;
                }
                if (gridView_AttendanceData.Columns["RowStyle"] != null)
                {
                    gridView_AttendanceData.Columns["RowStyle"].Visible = false;
                }
                
                
            }
            
        }

        private void OpenAttendanceForm(int _serial_id, string _employee_code, string _attendance_date)
        {

            XtraForm_EmployeeAttendence xtraForm_EmployeeAttendence = new XtraForm_EmployeeAttendence(this, _serial_id, "frmAttendenceLoading => Add Button", _employee_code, _attendance_date);
            xtraForm_EmployeeAttendence.StartPosition = FormStartPosition.CenterScreen;

            xtraForm_EmployeeAttendence.ShowDialog(Parent);

            //xtraForm_EmployeeAttendence.ChildWantedSomething += ReloadDataGrid;
        }

        public void ReloadDataGrid(object sender, ThresholdReachedEventArgs e)
        {
            if (ConvertTo.DateTimeVal(DtStartDate.EditValue) == e.AttendanceDate && IsString.IsEqualTo(txtEmpCode.EditValue, e.EmpCode))
            {

            }
            else
            {
                DtStartDate.EditValue = e.AttendanceDate;
                txtEmpCode.EditValue = e.EmpCode;


                var ds = ProjectFunctions.GetDataSet("SELECT     empmst.EmpCode, empmst.EmpName, DeptMst.DeptDesc FROM         empmst LEFT OUTER JOIN DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode Where EmpCode='" + txtEmpCode.Text.Trim() + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                    txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();

                    //Thread.Sleep(1000);

                    btnLoad_Data.PerformClick();//.Focus();
                }
            }
            

            //LoadAttendanceDataGrid();
            PrintLogWin.PrintLog("---------------------------------");
        }

        private void OnClickRow()
        {
            //DataRow CurrentRow = gridView_AttendanceData.GetDataRow(gridView_AttendanceData.FocusedRowHandle);
            int row = (gridControl_AttendanceData.FocusedView as ColumnView).FocusedRowHandle;
            ColumnView detailView = (ColumnView)gridControl_AttendanceData.FocusedView;
            int cellValue_serial_id = ConvertTo.IntVal(detailView.GetFocusedRowCellValue("SerialId"));//.GetRowCellValue(row, "Edit_Link").ToString();
            //
            string employee_code = detailView.GetFocusedRowCellValue("EmployeeCode").ToString();
            string attendance_date = ConvertTo.DateFormatDb(detailView.GetFocusedRowCellValue("AttendanceDate").ToString());

            PrintLogWin.PrintLog("%%%%%%%%%%%%%%%%" + cellValue_serial_id);
            PrintLogWin.PrintLog("%%%%%%%%%%%%%%%%" + row
                );

            //MessageBox.Show(CurrentRow[0] + "");


            OpenAttendanceForm(cellValue_serial_id, employee_code, attendance_date);
        }

        private void gridControl_AttendanceData_DoubleClick(object sender, EventArgs e)
        {
            gridView_AttendanceData.SetMasterRowExpanded(0, false);
            gridView_AttendanceData.SetMasterRowExpanded(1, true);
            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(gridControl_AttendanceData, e).Handled = true;

            PrintLogWin.PrintLog("*[ gridControl_AttendanceData_DoubleClick ]*");

            OnClickRow();
        }

        private void gridView_AttendanceData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    GridColumn clumn = View.Columns["RowStyle"];
                    if (clumn != null)
                    {
                        string row_style = View.GetRowCellDisplayText(e.RowHandle, clumn);
                        if (ComparisonUtils.IsNotEmpty(row_style))
                        {
                            string[] arr = row_style.Split('-');

                            if (arr.Length == 1)
                            {
                                Color color_1 = System.Drawing.ColorTranslator.FromHtml(arr[0]);
                                e.Appearance.BackColor = color_1;
                            }
                            if (arr.Length == 2)
                            {
                                Color color_1 = System.Drawing.ColorTranslator.FromHtml(arr[0]);
                                Color color_2 = System.Drawing.ColorTranslator.FromHtml(arr[1]);

                                e.Appearance.BackColor = color_1;
                                e.Appearance.BackColor2 = color_2;
                            }

                            e.HighPriority = true;
                        }
                    }
                    //GridColumn clumn = View.Columns["Status"];
                    //if (clumn != null)
                    //{
                    //    string category = View.GetRowCellDisplayText(e.RowHandle, clumn);
                    //    if (category == "RR - Sunday")
                    //    {
                    //        e.Appearance.BackColor = Color.Salmon;
                    //        e.Appearance.BackColor2 = Color.SeaShell;
                    //        e.HighPriority = true;
                    //    }
                    //}
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenAttendanceForm(0, "", "");
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            //XtraForm_EmployeeAttendence xtraForm_EmployeeAttendence = new XtraForm_EmployeeAttendence() { s1 = btnAdd.Text, Text = "User Addition" }; ;


            AddAttendanceDetails addAttendanceDetails = new AddAttendanceDetails() { s1 = btnAdd2.Text, Text = "Add Addendance Details" }; ;
            addAttendanceDetails.StartPosition = FormStartPosition.CenterScreen;

            addAttendanceDetails.ShowDialog(Parent);

        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {
            //txtEmpName.Text = string.Empty;
            //txtDept.Text = string.Empty;

            //txtPreviousInstlmnt.Text = "0";

            
        }

        private void txtEmpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGridView.Columns.Clear();
                HelpGrid.Text = "EmpCode";
                if (txtEmpCode.Text.Length == 0)
                {
                    var ds = ProjectFunctions.GetDataSet("SELECT     empmst.EmpCode, empmst.EmpName, DeptMst.DeptDesc FROM         empmst LEFT OUTER JOIN DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode ");
                    HelpGrid.DataSource = ds.Tables[0];
                    HelpGridView.BestFitColumns();
                    HelpGrid.Show();
                    HelpGrid.Focus();
                }
                else
                {
                    var ds = ProjectFunctions.GetDataSet("SELECT     empmst.EmpCode, empmst.EmpName, DeptMst.DeptDesc FROM         empmst LEFT OUTER JOIN DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode Where EmpCode='" + txtEmpCode.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtEmpCode.Text = ds.Tables[0].Rows[0]["EmpCode"].ToString();
                        txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                        //txtDept.Text = ds.Tables[0].Rows[0]["DeptDesc"].ToString();

                        //LastInstlmnt();
                        //txtLoanAmount.Focus();
                        btnLoad_Data.Focus();
                    }
                    else
                    {
                        var ds1 = ProjectFunctions.GetDataSet("SELECT  empmst.EmpCode, empmst.EmpName, DeptMst.DeptDesc FROM  empmst LEFT OUTER JOIN DeptMst ON empmst.EmpDeptCode = DeptMst.DeptCode");
                        HelpGrid.DataSource = ds1.Tables[0];
                        HelpGridView.BestFitColumns();
                        HelpGrid.Show();
                        HelpGrid.Focus();
                    }
                }
            }
            e.Handled = true;
        }

        private void HelpGrid_DoubleClick(object sender, EventArgs e)
        {
            var row = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "EmpCode")
            {
                txtEmpCode.Text = row["EmpCode"].ToString();
                txtEmpName.Text = row["EmpName"].ToString();
                //txtDept.Text = row["DeptDesc"].ToString();
                HelpGrid.Visible = false;
                btnLoad_Data.Focus();

                //LastInstlmnt();
            }


        }

        private void HelpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HelpGrid_DoubleClick(null, e);
            }
        }

        private void HelpGrid_Click(object sender, EventArgs e)
        {
        }
        /////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SFeedingGrid.DataSource = null;
            dt.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " .xlsx files(*.xlsx)|*.xlsx";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SFeedingGrid.Refresh();
            var xlConn = string.Empty;
            xlConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openFileDialog1.FileName + ";Extended Properties=\"Excel 12.0;\";";
            using (var myCommand = new OleDbDataAdapter("SELECT MonthYear,EmpCode,EmpName,EmpDW,EmpPH,EmpEL,EmpCL,EmpSL,EmpPymtMode FROM [Sheet1$]", xlConn))
            {
                myCommand.Fill(dt);
                SFeedingGrid.DataSource = dt;
                SFeedingGridView.BestFitColumns();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var ds1 = new DataSet();
            var ds2 = new DataSet();
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((SFeedingGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            for (var i = 0; i < MaxRow; i++)
            {
                var currentrow = SFeedingGridView.GetDataRow(i);
                var str1 = "Select EmpCode,EmpName from EmpMst where   EmpCode='" + currentrow["EmpCode"].ToString().PadLeft(5, '0') + "'";
                ds1 = ProjectFunctions.GetDataSet(str1);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpName"], ds1.Tables[0].Rows[0]["EmpName"].ToString());

                }
                else
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpCode"], "XXXXXXXXXXXXXXXXXXX");
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpName"], "XXXXXXXXXXXXXXXXXXX");
                    XtraMessageBox.Show("Invalid Dept ");
                }

            }
            SFeedingGridView.BestFitColumns();
        }

        private bool ValidateData()
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((SFeedingGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'

            for (var i = 0; i < MaxRow; i++)
            {
                var currentrow = SFeedingGridView.GetDataRow(i);
                if (currentrow["EmpName"].ToString().Contains("x") || currentrow["EmpName"].ToString() == string.Empty)
                {
                    XtraMessageBox.Show("Invalid Employee Name");
                    return false;
                }
                if (currentrow["EmpDW"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpDW"], "0");
                }
                if (currentrow["EmpPH"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpPH"], "0");
                }
                if (currentrow["EmpEL"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpEL"], "0");
                }
                if (currentrow["EmpCL"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpCL"], "0");
                }
                if (currentrow["EmpSL"].ToString() == string.Empty)
                {
                    SFeedingGridView.SetRowCellValue(i, SFeedingGridView.Columns["EmpSL"], "0");
                }

                if (currentrow["EmpPymtMode"].ToString() == string.Empty)
                {
                    XtraMessageBox.Show("Invalid Payment Mode");
                    return false;
                }
                if (currentrow["MonthYear"].ToString() == string.Empty)
                {
                    XtraMessageBox.Show("Invalid Month Year");
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            var MaxRow = ((SFeedingGrid.KeyboardFocusView as GridView).RowCount);
#pragma warning restore CS0618 // 'GridControl.KeyboardFocusView' is obsolete: 'Use the FocusedView property instead.'
            if (ValidateData())
            {
                using (var con = new SqlConnection(ProjectFunctions.ConnectionString))
                {
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;

                    for (var i = 0; i < MaxRow; i++)
                    {
                        var currentrow = SFeedingGridView.GetDataRow(i);
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "Insert into AtnData(MonthYear,EmpCode,EmpDW,EmpPH,EmpEL,EmpCL,EmpSL,EmpPymtMode)values(@MonthYear,@EmpCode,@EmpDW,@EmpPH,@EmpEL,@EmpCL,@EmpSL,@EmpPymtMode)";
                        cmd.Parameters.Add("@MonthYear", SqlDbType.NVarChar).Value = currentrow["MonthYear"].ToString();
                        cmd.Parameters.Add("@EmpCode", SqlDbType.NVarChar).Value = currentrow["EmpCode"].ToString().PadLeft(5, '0');
                        cmd.Parameters.Add("@EmpDW", SqlDbType.NVarChar).Value = currentrow["EmpDW"].ToString();
                        cmd.Parameters.Add("@EmpPH", SqlDbType.NVarChar).Value = currentrow["EmpPH"].ToString();
                        cmd.Parameters.Add("@EmpEL", SqlDbType.NVarChar).Value = currentrow["EmpEL"].ToString();
                        cmd.Parameters.Add("@EmpCL", SqlDbType.NVarChar).Value = currentrow["EmpCL"].ToString();
                        cmd.Parameters.Add("@EmpSL", SqlDbType.NVarChar).Value = currentrow["EmpSL"].ToString();
                        cmd.Parameters.Add("@EmpPymtMode", SqlDbType.NVarChar).Value = currentrow["EmpPymtMode"].ToString();

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
            }
            SFeedingGrid.DataSource = null;
        }



        private void gridControl_AttendanceData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("show");
        }

        ////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////
        private void gridControl_AttendanceData_Load(object sender, EventArgs e)
        {

            //ProjectFunctions.ToolstripVisualize(Menu_ToolStrip);
            //ProjectFunctions.GirdViewVisualize(gridView_UserMaster);
            //FillDataToGrid();
        }

        private void SetMyControls2()
        {
            DtStartDate.EditValue = DateTime.Now;
            ProjectFunctions.GirdViewVisualize(gridView_AttendanceData);
            GridEvents();
        }
        private void FillDataToGrid()
        {
            PrintLogWin.PrintLog("FillGrid ******************** " + GlobalVariables.ProgCode);
            try
            {
                DataSet ds = ProjectFunctions.GetDataSet("Select ProgProcName,ProgDesc from ProgramMaster Where ProgCode='" + GlobalVariables.ProgCode + "'");
                string ProcedureName = ds.Tables[0].Rows[0]["ProgProcName"].ToString();

                PrintLogWin.PrintLog("FillGrid => ProcedureName ******************** " + ProcedureName);

                DataSet dsMaster = ProjectFunctionsUtils.GetDataSet(ProcedureName);
                FillTable(dsMaster);
                AddUnboundColumn();
                AddButtonToGrid();

                //toolStrip_lbl.Text = ds.Tables[0].Rows[0]["ProgDesc"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox_Debug.ShowBox("frmMaster => FillGrid() => " + ex);
            }
        }

        private void FillTable(DataSet dsMaster)
        {
            gridView_AttendanceData.Columns.Clear();

            using (SEQKARTNewEntities db = new SEQKARTNewEntities())
            {
                BindingList<EmployeeAttendance> binding_list = new BindingList<EmployeeAttendance>();

                List<EmployeeAttendance> employeeAttendances_List = db.EmployeeAttendances.OrderByDescending(s => s.entry_date).ToList();
                gridControl_AttendanceData.DataSource = employeeAttendances_List;
                gridView_AttendanceData.BestFitColumns();

                foreach (var item in employeeAttendances_List)
                {
                    EmployeeAttendance employeeAttendance = new EmployeeAttendance();
                    employeeAttendance.serial_id = item.serial_id;
                    employeeAttendance.shift_id = item.shift_id;
                    employeeAttendance.status_id = item.status_id;
                    employeeAttendance.employee_code = item.employee_code;
                    employeeAttendance.attendance_date = item.attendance_date;
                    employeeAttendance.attendance_in_first = item.attendance_in_first;
                    employeeAttendance.attendance_out_first = item.attendance_out_first;
                    employeeAttendance.attendance_source = item.attendance_source;

                    employeeAttendances_List.Add(employeeAttendance);
                }
                gridControl_AttendanceData.DataSource = binding_list;

            }
        }

        private void AddUnboundColumn()
        {
            GridColumn unbColumn = gridView_AttendanceData.Columns.AddField("Action");
            unbColumn.VisibleIndex = gridView_AttendanceData.Columns.Count;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
        }


        private void GridEvents()
        {
            PrintLogWin.PrintLog("*[ GridEvents ]*");


            //Disableed

            //gridControl_AttendanceData.Load += gridControl_AttendanceData_Load;
            //In Non-Editable Mode
            gridView_AttendanceData.ShowingEditor += gridView_UserMaster_ShowingEditor;
            //gridView_UserMaster.DoubleClick += gridView_DoubleClick;

            //gridControl_AttendanceData.DoubleClick += gridControl_AttendanceData_DoubleClick;
            gridView_AttendanceData.DoubleClick += gridControl_AttendanceData_DoubleClick;


        }

        private void AddButtonToGrid()
        {
            PrintLogWin.PrintLog("*[ AddButtonToGrid ]*");

            //In Editable Mode
            //gridView_UserMaster.ShownEditor += gridView_ShownEditor;

            RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit();
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            edit.ButtonClick += edit_ButtonClick;
            edit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

            EditorButton button = edit.Buttons[0];

            button.ImageOptions.Image = WindowsFormsApplication1.Properties.Resources.Edit_16x16;
            button.ImageOptions.Location = ImageLocation.MiddleCenter;
            button.Caption = "Edit";
            button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            button.Appearance.BackColor = Color.Red;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.BorderColor = Color.Transparent;
            //edit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            button.Appearance.Options.UseBackColor = true;
            button.Appearance.BackColor = Color.Transparent;

            GridColumn actionColumn = gridView_AttendanceData.Columns["Action"];
            actionColumn.ColumnEdit = edit;
            actionColumn.OptionsColumn.AllowEdit = true;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }
        }

        //https://supportcenter.devexpress.com/ticket/details/a2934/how-to-handle-a-double-click-on-a-grid-row-or-cell
        void gridView_UserMaster_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView_AttendanceData.FocusedColumn == gridView_AttendanceData.Columns["Action"])
            {
                PrintLogWin.PrintLog("********************* A ");
                return;
            }
            if (gridView_AttendanceData.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                PrintLogWin.PrintLog("********************* B ");
                e.Cancel = false;
            }
            else
            {
                PrintLogWin.PrintLog("********************* C ");
                e.Cancel = true;
            }
        }

        BaseEdit editor;
        private void gridView_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            editor = view.ActiveEditor;
            editor.DoubleClick += editor_DoubleClick;
        }

        void gridView_HiddenEditor(object sender, EventArgs e)
        {
            editor.DoubleClick -= editor_DoubleClick;
            editor = null;
        }

        void editor_DoubleClick(object sender, EventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            GridControl grid = editor.Parent as GridControl;
            GridView view = grid.FocusedView as GridView;
            Point pt = grid.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            }
        }

        void edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PrintLogWin.PrintLog("*[ edit_ButtonClick ]*");
            OnClickRow();

        }

        private void btnLoad_Data_Click(object sender, EventArgs e)
        {
            if (ValidateData_GridLoad())
            {
                LoadAttendanceDataGrid();

            }
            
        }

        private bool ValidateData_GridLoad()
        {
            if (txtEmpCode.Text.Trim().Length == 0)
            {
                //XtraMessageBox.Show("Invalid Emp Code", "Inalid value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectFunctions.SpeakError("Enter Employee Code");
                txtEmpCode.Focus();
                return false;
            }
            return true;
        }
    }
}
