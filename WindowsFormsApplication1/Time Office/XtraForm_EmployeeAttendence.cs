﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using DevExpress.XtraBars.Docking2010;
using System.Data.SqlClient;
using HumanResourceManagementSystem;
using SeqKartLibrary;
using SeqKartLibrary.CrudTask;
using System.Globalization;
using SeqKartLibrary.HelperClass;
using SeqKartLibrary.Models;
using static SeqKartLibrary.CrudTask.CrudAction;
using BNPL.Forms_Master;
using SeqKartLibrary.Repository;
using Dapper;
using System.Threading;
using DevExpress.XtraEditors.Mask;
using DevExpress.CodeParser;

namespace WindowsFormsApplication1.Time_Office
{
    public partial class XtraForm_EmployeeAttendence : DevExpress.XtraEditors.XtraForm
    {
        private frmAttendenceLaoding _frmAttendenceLaoding = null;

        //private string selected_employee_code = "";
        public int selected_serial_id = 0;// { get; set; }
        public string come_from = "";// { get; set; }

        public string selected_employee_code = "";
        public string selected_attendance_date = "";

        

        public XtraForm_EmployeeAttendence(frmAttendenceLaoding parent, int _selected_serial_id, string _come_from, string _selected_employee_code, string _selected_attendance_date)
        {
            InitializeComponent();

            this._frmAttendenceLaoding = parent;
            this.selected_serial_id = _selected_serial_id;
            this.selected_employee_code = _selected_employee_code;
            this.selected_attendance_date = _selected_attendance_date;            

            this.come_from = _come_from;
            

            PrintLogWin.PrintLog("selected_serial_id 1 => " + selected_serial_id);

        }

        private CrudAction crudAction = new CrudAction();

        private bool form_loaded = false;
        private void XtraForm_EmployeeAttendence_Load(object sender, EventArgs e)
        {
            //timeEdit_Time_In_First_1.Properties.Mask.MaskType = MaskType.DateTime;
            //timeEdit_Time_In_First_1.Properties.Mask.EditMask = "HH:mm";
            //timeEdit_Time_In_First_1.MaskBox.Mask.UseMaskAsDisplayFormat = true;
            //timeEdit_Time_In_First_Testing.EditValue = null;

            //timeEdit_Time_In_First.EditValue = TimeSpan.Zero;
            //PrintLogWin.PrintLog("************ : " + timeEdit_Time_In_First.EditValue);

            //timeEdit_Time_In_First.EditValue = null;
            //PrintLogWin.PrintLog("************ : " + timeEdit_Time_In_First.EditValue);

            LoadControls();

            Load_Status_Shift_Data();

            dateAttendance.Value = ConvertTo.DateTimeVal(selected_attendance_date);


            employeeFormData_Load(selected_employee_code);


        }

        private void editor_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                //My event handler  
            }
        }

        public object GetEditValue(BaseEdit editor)
        {
            try
            {
                return editor.EditValue;
            }
            finally
            {
                
            }
            return null;
        }

        public void SetEditValue(BaseEdit editor, object newEditValue)
        {
            try
            {
                editor.Tag = 0;
                editor.EditValue = newEditValue;
            }
            finally
            {
                editor.Tag = null;
            }
        }

        public void SetEditValue_NullTag(BaseEdit editor, object newEditValue)
        {
            try
            {                
                editor.EditValue = newEditValue;
            }
            finally
            {
                
            }
        }

        private void SetDailyWageControls(bool _DailyWage, int? _DailyWageMinutes, decimal? _DailyWageRate)
        {
            

            SetEditValue(textEmpType, ((_DailyWage == true) ? "Daily Wager" : "Regular"));
            SetEditValue(txtDailyWager, _DailyWage);

            if (_DailyWage)
            {
                grpBoxDailyWager.Enabled = true;
                grpBoxEmployee.Enabled = false;

                grpBoxDailyWager.Visible = true;
                grpBoxEmployee.Visible = false;


                SetEditValue(txtDutyHours_DW, _DailyWageMinutes);

                SetEditValue(timeEdit_Time_In_First, null);
                SetEditValue(timeEdit_Time_Out_First, null);
                SetEditValue(timeEdit_Time_In_Last, null);
                SetEditValue(timeEdit_Time_Out_Last, null);

                SetEditValue(totalWorkingHours_Text, null);
                SetEditValue(txtOvertimeHours, null);
            }
            else
            {
                grpBoxDailyWager.Visible = false;
                grpBoxEmployee.Visible = true;

                grpBoxDailyWager.Enabled = false;
                grpBoxEmployee.Enabled = true;


                SetEditValue(txtDutyHours_DW, null);
                SetEditValue(timeEdit_Time_In_DW, null);
                SetEditValue(timeEdit_Time_Out_DW, null);
                SetEditValue(totalWorkingHours_Text_DW, null);
            }
            //
        }
        private void employeeFormData_Load(string EmpCode)
        {
            PrintLogWin.PrintLog("********************* 2");
            PrintLogWin.PrintLog("employeeFormData_Load 1 => ********************");

            RepList<EmployeeMasterModel> lista = new RepList<EmployeeMasterModel>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmpCode", EmpCode);

           
            EmployeeMasterModel empData = lista.returnClass_SP(SQL_QUERIES._sp_EmployeeDetails(), param);

            if (empData != null)
            {
              

                SetEditValue(timeEdit_Time_In_First_Main, empData.TimeInFirst);
                SetEditValue(timeEdit_Time_Out_First_Main, empData.TimeOutFirst);
                SetEditValue(timeEdit_Time_In_Last_Main, empData.TimeInLast);
                SetEditValue(timeEdit_Time_Out_Last_Main, empData.TimeOutLast);

                SetEditValue(totalWorkingHours_Text_Main, empData.WorkingHours);

                SetEditValue(txtFName, empData.EmpName);
                SetEditValue(txtEmpID, empData.EmpCode);
                SetEditValue_NullTag(txtLunchBreak, empData.LunchBreak);
                SetEditValue(txtDepartment, empData.DeptDesc);
                SetEditValue(txtDesignation, empData.DesgDesc);
                SetEditValue(textUnit, empData.UnitName);

                pictureBox1.Image = ImageUtils.ConvertBinaryToImage(empData.EmpImage);

                SetDailyWageControls(empData.DailyWage, empData.DailyWageMinutes, empData.DailyWageRate);

                PrintLogWin.PrintLog("employeeFormData_Load 2 => ********************");

                //textEmpType_EditValueChanged(textEmpType, EventArgs.Empty);

                LoadAttendanceData();
            }
            

        }

        //private EmployeeAttendance query_attendance;
        private void Load_Status_Shift_Data()
        {
            RepList<object> repObj = new RepList<object>();
            attendanceStatu_List = repObj.returnListClass_1<AttendanceStatu>("SELECT * FROM AttendanceStatus", null);

            if (ComparisonUtils.IsNotNull_List(attendanceStatu_List))
            {
                comboBox_Status.DataSource = attendanceStatu_List;
                comboBox_Status.ValueMember = SQL_COLUMNS._AttendanceStatus._status_id;
                comboBox_Status.DisplayMember = SQL_COLUMNS._AttendanceStatus._status;

            }

            List<DailyShift> dailyShifts_List = new List<DailyShift>();

            DailyShift dailyShift = new DailyShift();
            dailyShift.shift_id = 1;
            dailyShift.shift_name = "Daily Shift";
            dailyShifts_List.Add(dailyShift);
            
            if (ComparisonUtils.IsNotNull_List(dailyShifts_List))
            {
                comboBox_Shift.DataSource = dailyShifts_List;
                comboBox_Shift.ValueMember = SQL_COLUMNS._DailyShifts._shift_id;
                comboBox_Shift.DisplayMember = SQL_COLUMNS._DailyShifts._shift_name;
            }

            comboBox_Shift.SelectedValue = 1;
        }
        List<AttendanceStatu> attendanceStatu_List;

        private void LoadAttendanceData()
        {
            RepList<EmployeeAttendance> lista = new RepList<EmployeeAttendance>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@serial_id", selected_serial_id);

            string sql = "SELECT ea.*, em.DailyWage, em.LunchBreak, em.OT_Extra FROM EmployeeAttendance ea, EmpMST em WHERE ea.employee_code = '" + GetEditValue(txtEmpID) + "' AND CONVERT(varchar, CAST( ea.attendance_date AS Date ), 23) = CONVERT(varchar, CAST( '" + ConvertTo.DateFormatDb(dateAttendance.Value) + "' AS Date ), 23) AND ea.employee_code = em.EmpCode";
            PrintLogWin.PrintLog(sql);
            EmployeeAttendance query_attendance = lista.returnClass(sql, param);

            if (query_attendance != null)
            {
                SetEditValue(txtSerial_ID, query_attendance.serial_id);
                SetEditValue(txtEmpID, query_attendance.employee_code);
                SetEditValue(txtLunchBreak, query_attendance.LunchBreak);

                var sql1 = query_attendance.ToString();

                PrintLogWin.PrintLog("query_attendance => " + sql1);
                PrintLogWin.PrintLog("selected_serial_id => " + selected_serial_id);
                PrintLogWin.PrintLog("status_id => " + query_attendance.status_id);

                ControllerUtils.SelectItemByValue(comboBox_Status, query_attendance.status_id + "");
                ControllerUtils.SelectItemByValue(comboBox_Shift, query_attendance.shift_id + "");


                if (query_attendance.DailyWage)
                {
                    SetEditValue(timeEdit_Time_In_DW, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_first));
                    SetEditValue(timeEdit_Time_Out_DW, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_first));

                    PrintLogWin.PrintLog("timeEdit_Time_In_DW : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.EditValue));
                    PrintLogWin.PrintLog("timeEdit_Time_Out_DW : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.EditValue));
                }
                else
                {
                    SetEditValue(timeEdit_Time_In_First, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_first));
                    SetEditValue(timeEdit_Time_Out_First, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_first));
                    SetEditValue(timeEdit_Time_In_Last, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_last));
                    SetEditValue(timeEdit_Time_Out_Last, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_last));


                    PrintLogWin.PrintLog("timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue));
                    PrintLogWin.PrintLog("timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue));
                    PrintLogWin.PrintLog("timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue));
                    PrintLogWin.PrintLog("timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue));
                }

                SetEditValue_NullTag(totalWorkingHours_Text, query_attendance.working_hours);
                SetEditValue(timeEdit_GatePassTime, query_attendance.gate_pass_time);
                SetEditValue_NullTag(txtOvertimeHours, query_attendance.ot_deducton_time);


                if (query_attendance.attendance_date != null)
                {
                    DateTime dd = query_attendance.attendance_date.GetValueOrDefault(DateTime.Now);
                    labelDate_Current.Text = ConvertTo.DateFormatApp(dd);
                }

                if (query_attendance.attendance_source == 1)
                {
                    radioButtonManual.Checked = true;
                    radioButtonMachine.Checked = false;
                }
                else
                {
                    radioButtonManual.Checked = false;
                    radioButtonMachine.Checked = true;
                }
            }
            else
            {
                SetEditValue(txtSerial_ID, 0);

                labelDate_Current.Text = ConvertTo.DateFormatApp(DateTime.Now);//culture                
                
                SetEditValue_NullTag(totalWorkingHours_Text, 0);
                SetEditValue(timeEdit_GatePassTime, 0);
                SetEditValue_NullTag(txtOvertimeHours, 0);


                SetEditValue(timeEdit_Time_In_First, null);
                SetEditValue(timeEdit_Time_Out_First, null);
                SetEditValue(timeEdit_Time_In_Last, null);
                SetEditValue(timeEdit_Time_Out_Last, null);

                SetEditValue(txtDutyHours_DW, null);
                SetEditValue(timeEdit_Time_In_DW, null);
                SetEditValue(timeEdit_Time_Out_DW, null);
                SetEditValue(totalWorkingHours_Text_DW, null);


            }
            PrintLogWin.PrintLog("********************* 1 ");
            form_loaded = true;
            //CalculateDUtyHours("all");

        }
        

       
        //private 
        private void LoadControls()
        {
            txtFName.Properties.ReadOnly = true;
            txtEmpID.Properties.ReadOnly = false;
            txtDepartment.Properties.ReadOnly = true;
            txtDesignation.Properties.ReadOnly = true;
            textUnit.Properties.ReadOnly = true;            

            radioButtonManual.Checked = true;
            radioButtonMachine.Checked = false;
            panelControl_Manual_In.BackColor = Color.FromArgb(232, 232, 232);
            panelControl_Machine_In.BackColor = Color.White;

            timeEdit_Time_In_First.ReadOnly = false;
            timeEdit_Time_Out_First.ReadOnly = false;
            timeEdit_Time_In_Last.ReadOnly = false;
            timeEdit_Time_Out_Last.ReadOnly = false;

            timeEdit_Time_In_First.BackColor = Color.FromArgb(255, 255, 192);
            timeEdit_Time_Out_First.BackColor = Color.FromArgb(255, 255, 192);
            timeEdit_Time_In_Last.BackColor = Color.FromArgb(255, 255, 192);
            timeEdit_Time_Out_Last.BackColor = Color.FromArgb(255, 255, 192);

            //timeEdit_Time_In_First.EditValue = null;
            //timeEdit_Time_Out_First.EditValue = null;
            //timeEdit_Time_In_Last.EditValue = null;
            //timeEdit_Time_Out_Last.EditValue = null;

            SetEditValue(timeEdit_Time_In_First, null);
            SetEditValue(timeEdit_Time_Out_First, null);
            SetEditValue(timeEdit_Time_In_Last, null);
            SetEditValue(timeEdit_Time_Out_Last, null);


            //radioButtonMachine.
        }

        //private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        //{
        //    //txtEmpCodeDesc.Text = string.Empty;

        //    //if (txtEmpCode.Text.Length >= 4 && DtDate.Text.Length >= 8)
        //    //{
        //    //    LoadGatePassDataGrid();
        //    //}

            
        //}

        private void cbEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbEmpID.SelectedItem != null)
            //{
            //    employeeFormData_Load(cbEmpID.SelectedItem.ToString());

            //}
            
        }
        

        async void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();

            //MessageBox.Show(tag);
            switch (tag)
            {
                case "save":
                    /* Navigate to page A */
                    await CallAsyn_SaveEmployeeAttendanceDetails();
                    _frmAttendenceLaoding.LoadAttendanceDataGrid();

                    break;
                case "save_close":
                    /* Navigate to page B */
                    await CallAsyn_SaveEmployeeAttendanceDetails();
                    _frmAttendenceLaoding.LoadAttendanceDataGrid();

                    this.Close();
                    break;
                case "save_new":
                    /* Navigate to page C*/
                    await CallAsyn_SaveEmployeeAttendanceDetails();
                    _frmAttendenceLaoding.LoadAttendanceDataGrid();

                    selected_serial_id = 0;
                    LoadAttendanceData();

                    break;                
                case "reset":
                    /* Navigate to page D */
                    form_loaded = false;
                    LoadAttendanceData();


                    break;
                case "delete":
                    /* Navigate to page E */
                    if (XtraMessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        int result = await DeleteEmployeeAttendanceDetails();

                        if (result > -1)
                        {
                            _frmAttendenceLaoding.LoadAttendanceDataGrid();

                            selected_serial_id = 0;
                            LoadAttendanceData();
                        }
                    }

                    break;
                case "add_new":
                    /* Navigate to page C*/

                    selected_serial_id = 0;
                    LoadAttendanceData();

                    break;
                case "close":
                    /* Navigate to page E */
                    this.Close();

                    break;

            }
        }
        private async Task<int> DeleteEmployeeAttendanceDetails()
        {
            int result = -1;
            if (crudAction == CrudAction.Update)
            {
                using (SEQKARTNewEntities db = new SEQKARTNewEntities())
                {
                    EmployeeAttendance query_attendance =
                            (from data in db.EmployeeAttendances
                             where data.serial_id == selected_serial_id
                             orderby data.entry_date
                             select data).SingleOrDefault();

                    db.EmployeeAttendances.Remove(query_attendance);
                    result = await db.SaveChangesAsync();

                    
                }
            }

            if (result > -1)
            {
                ProjectFunctions.SpeakError("Record has been deleted");
            }
            else
            {
                ProjectFunctions.SpeakError("There is some problem in deleting record. Please try again.");
            }
            return result;
        }


        private async Task CallAsyn_SaveEmployeeAttendanceDetails()
        {
            //var result = Task.Run(() => SaveEmployeeAttendanceDetails().Result).Result;
            //Task.Run(() => SaveEmployeeAttendanceDetails());
           await SaveEmployeeAttendanceDetails();
        }

        private async Task SaveEmployeeAttendanceDetails()
        {
            if (selected_serial_id == 0)
            {
                RepList<EmployeeAttendance> repList = new RepList<EmployeeAttendance>();

                DynamicParameters param = new DynamicParameters();

                string sql_chk = "SELECT* FROM EmployeeAttendance WHERE employee_code = '" + txtEmpID.Text + "' AND YEAR(attendance_date)='" + dateAttendance.Value.Year + "' AND MONTH(attendance_date)='" + dateAttendance.Value.Month + "' AND DAY(attendance_date)='" + dateAttendance.Value.Day + "'";


                PrintLogWin.PrintLog(sql_chk);

                EmployeeAttendance employeeAttendance = repList.returnClass(sql_chk, param);

                int existing_serial_id = 0;
                if (employeeAttendance != null)
                {
                    if (employeeAttendance.serial_id != 0)
                    {
                        existing_serial_id = employeeAttendance.serial_id;
                        //MessageBox.Show("Update");
                    }
                    else
                    {
                        //MessageBox.Show("Insert 1");
                    }
                }
                else
                {
                    //MessageBox.Show("Insert 2");
                }

                if (existing_serial_id != 0)
                {
                    
                    //selected_serial_id = 0;
                    //crudAction = CrudAction.Create;
                    if (XtraMessageBox.Show("Attendance already entered on this date. Do you want to update this record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        selected_serial_id = existing_serial_id;
                        crudAction = CrudAction.Update;
                        await SaveEmployeeAttendanceDetails_OR_Update();

                        //MessageBox.Show("selected_serial_id : " + selected_serial_id);
                        //MessageBox.Show("crudAction : " + crudAction);
                        //this.Close();
                    }
                }
                else
                {
                    //MessageBox.Show("New 1");
                    await SaveEmployeeAttendanceDetails_OR_Update();
                }
            }
            else
            {
                //await Task.Delay(1);
                await SaveEmployeeAttendanceDetails_OR_Update();
                //MessageBox.Show("Update");
            }

        }

        private async Task SaveEmployeeAttendanceDetails_OR_Update()
        {
            
            if (Validate_Form())
            {
                bool isDailyWager = ConvertTo.BooleanVal(txtDailyWager.EditValue);

                if (crudAction == CrudAction.Create)
                {

                    //MessageBox.Show("Create");

                    EmployeeAttendance employeeAttendance = new EmployeeAttendance();
                    employeeAttendance.entry_date = DateTime.Now;
                    employeeAttendance.attendance_date = dateAttendance.Value;
                    employeeAttendance.employee_code = txtEmpID.Text;

                    if (isDailyWager)
                    {
                        employeeAttendance.status_id = 1;
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.Text);
                        employeeAttendance.attendance_in_last = TimeSpan.Zero;
                        employeeAttendance.attendance_out_last = TimeSpan.Zero;
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text_DW.Text);
                    }
                    else
                    {
                        employeeAttendance.status_id = ConvertTo.IntVal(comboBox_Status.SelectedValue);
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.Text);
                        employeeAttendance.attendance_in_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.Text);
                        employeeAttendance.attendance_out_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.Text);
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text.Text);
                    }

                    
                    employeeAttendance.shift_id = ConvertTo.IntVal(comboBox_Shift.SelectedValue);
                    int att_source = AttendanceSource(radioButtonManual.Checked, radioButtonMachine.Checked);
                    employeeAttendance.attendance_source = att_source;
                    employeeAttendance.gate_pass_time = ConvertTo.IntVal(timeEdit_GatePassTime.EditValue);
                    employeeAttendance.ot_deducton_time = ConvertTo.IntVal(txtOvertimeHours.EditValue);

                    
                    string str = "sp_EmployeeAttendance_AddEdit";
                    RepGen reposGen = new RepGen();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@serial_id", 0);
                    param.Add("@entry_date", employeeAttendance.entry_date);
                    param.Add("@attendance_date", employeeAttendance.attendance_date);
                    param.Add("@employee_code", employeeAttendance.employee_code);
                    param.Add("@status_id", employeeAttendance.status_id);
                    param.Add("@attendance_in_first", employeeAttendance.attendance_in_first);
                    param.Add("@attendance_out_first", employeeAttendance.attendance_out_first);
                    param.Add("@attendance_in_last", employeeAttendance.attendance_in_last);
                    param.Add("@attendance_out_last", employeeAttendance.attendance_out_last);
                    param.Add("@working_hours", employeeAttendance.working_hours);
                    param.Add("@shift_id", employeeAttendance.shift_id);
                    param.Add("@attendance_source", employeeAttendance.attendance_source);
                    param.Add("@gate_pass_time", employeeAttendance.gate_pass_time);
                    param.Add("@ot_deducton_time", employeeAttendance.ot_deducton_time);

                    param.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    param.Add("@Returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    string intResult = await reposGen.executeNonQuery_SP_Async(str, param);
                    if (intResult.Equals("0"))
                    {
                        int outputVal = param.Get<int>("@output");
                        int returnVal = param.Get<int>("@Returnvalue");

                        PrintLogWin.PrintLog("outputVal => " + outputVal);
                        PrintLogWin.PrintLog("returnVal => " + returnVal);

                        ProjectFunctions.SpeakError("Record has been saved");
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Error in save record.");
                        PrintLogWin.PrintLog(intResult);
                    }                   
                    dateAttendance.Value = dateAttendance.Value.AddDays(1);
                    
                    PrintLogWin.PrintLog("Insert => attendance_in_first : " + employeeAttendance.attendance_in_first);
                    PrintLogWin.PrintLog("Insert => attendance_out_first : " + employeeAttendance.attendance_out_first);
                    PrintLogWin.PrintLog("Insert => attendance_in_last : " + employeeAttendance.attendance_in_last);
                    PrintLogWin.PrintLog("UpInsertdate => attendance_out_last : " + employeeAttendance.attendance_out_last);

                    PrintLogWin.PrintLog("Insert => timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.Text));
                    PrintLogWin.PrintLog("Insert => timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.Text));
                    PrintLogWin.PrintLog("Insert => timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.Text));
                    PrintLogWin.PrintLog("Insert => timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.Text));

                    PrintLogWin.PrintLog("Insert => timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue));
                    PrintLogWin.PrintLog("Insert => timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue));
                    PrintLogWin.PrintLog("Insert => timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue));
                    PrintLogWin.PrintLog("Insert => timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue));

                }
                if (crudAction == CrudAction.Update)
                {

                    string str = "sp_EmployeeAttendance_AddEdit";                    

                    EmployeeAttendance employeeAttendance = new EmployeeAttendance();

                    employeeAttendance.attendance_date = dateAttendance.Value;

                    if (isDailyWager)
                    {
                        employeeAttendance.status_id = 1;
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.Text);
                        employeeAttendance.attendance_in_last = TimeSpan.Zero;
                        employeeAttendance.attendance_out_last = TimeSpan.Zero;
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text_DW.Text);
                    }
                    else
                    {
                        employeeAttendance.status_id = ConvertTo.IntVal(comboBox_Status.SelectedValue);
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.Text);
                        employeeAttendance.attendance_in_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.Text);
                        employeeAttendance.attendance_out_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.Text);
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text.Text);
                    }

                    employeeAttendance.shift_id = ConvertTo.IntVal(comboBox_Shift.SelectedValue);
                    int att_source = AttendanceSource(radioButtonManual.Checked, radioButtonMachine.Checked);
                    employeeAttendance.attendance_source = att_source;
                    employeeAttendance.gate_pass_time = ConvertTo.IntVal(timeEdit_GatePassTime.EditValue);
                    employeeAttendance.ot_deducton_time = ConvertTo.IntVal(txtOvertimeHours.EditValue);

                    RepGen reposGen = new RepGen();
                    DynamicParameters param = new DynamicParameters();

                    param.Add("@serial_id", selected_serial_id);
                    param.Add("@entry_date", employeeAttendance.entry_date);
                    param.Add("@attendance_date", employeeAttendance.attendance_date);
                    param.Add("@employee_code", employeeAttendance.employee_code);
                    param.Add("@status_id", employeeAttendance.status_id);
                    param.Add("@attendance_in_first", employeeAttendance.attendance_in_first);
                    param.Add("@attendance_out_first", employeeAttendance.attendance_out_first);
                    param.Add("@attendance_in_last", employeeAttendance.attendance_in_last);
                    param.Add("@attendance_out_last", employeeAttendance.attendance_out_last);
                    param.Add("@working_hours", employeeAttendance.working_hours);
                    param.Add("@shift_id", employeeAttendance.shift_id);
                    param.Add("@attendance_source", employeeAttendance.attendance_source);
                    param.Add("@gate_pass_time", employeeAttendance.gate_pass_time);
                    param.Add("@ot_deducton_time", employeeAttendance.ot_deducton_time);

                    param.Add("@output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    param.Add("@Returnvalue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    
                    string intResult = await reposGen.executeNonQuery_SP_Async(str, param);
                    if (intResult.Equals("0"))
                    {
                        int outputVal = param.Get<int>("@output");
                        int returnVal = param.Get<int>("@Returnvalue");

                        PrintLogWin.PrintLog("outputVal => " + outputVal);
                        PrintLogWin.PrintLog("returnVal => " + returnVal);

                        ProjectFunctions.SpeakError("Record has been updated");
                    }
                    else
                    {
                        ProjectFunctions.SpeakError("Error in save record.");
                        PrintLogWin.PrintLog(intResult);
                    }
                    
                    PrintLogWin.PrintLog("Update => attendance_in_first : " + employeeAttendance.attendance_in_first);
                    PrintLogWin.PrintLog("Update => attendance_out_first : " + employeeAttendance.attendance_out_first);
                    PrintLogWin.PrintLog("Update => attendance_in_last : " + employeeAttendance.attendance_in_last);
                    PrintLogWin.PrintLog("Update => attendance_out_last : " + employeeAttendance.attendance_out_last);

                    PrintLogWin.PrintLog("Update => timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.Text));
                    PrintLogWin.PrintLog("Update => timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.Text));
                    PrintLogWin.PrintLog("Update => timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.Text));
                    PrintLogWin.PrintLog("Update => timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.Text));

                    PrintLogWin.PrintLog("Update => timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue));
                    PrintLogWin.PrintLog("Update => timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue));
                    PrintLogWin.PrintLog("Update => timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue));
                    PrintLogWin.PrintLog("Update => timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue));
                    //////////////////////////////////////////
                }
            }

            //MessageBox.Show(result == true ? "added" : "failed");
        }

        private int AttendanceSource(bool radioManual, bool radioMachine)
        {
            if (radioManual)
            {
                return 1;
            }
            if (radioMachine)
            {
                return 2;
            }
            return 1;
        }

        private bool Validate_Form()
        {           

            if (txtEmpID.Text == "")
            {
                //MessageBox.Show("Please select an Employee ID first");
                ProjectFunctionsUtils.SpeakError("Please Enter an Employee ID first");
                txtEmpID.Focus();

                return false;
            }

            if (ConvertTo.BooleanVal(txtDailyWager.EditValue))
            {
                if (ComparisonUtils.IsEmpty(timeEdit_Time_In_DW.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_DW.EditValue))
                {
                    ProjectFunctionsUtils.SpeakError("Please Enter Time In and Time Out");
                    timeEdit_Time_In_DW.Focus();

                    return false;
                }
            }
            else
            {
                if (txtStatusType.EditValue.Equals("1111"))
                {
                    if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0)
                    {
                        if (ComparisonUtils.IsEmpty(timeEdit_Time_In_First.EditValue) ||                        
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_Last.EditValue))
                        {
                            ProjectFunctionsUtils.SpeakError("Please Enter Time In and Time Out Inputs");
                            timeEdit_Time_In_First.Focus();

                            return false;
                        }
                    }
                    else
                    {
                        if (ComparisonUtils.IsEmpty(timeEdit_Time_In_First.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_First.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_In_Last.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_Last.EditValue))
                        {
                            ProjectFunctionsUtils.SpeakError("Please Enter All 4 Time Inputs");
                            timeEdit_Time_In_First.Focus();

                            return false;
                        }
                    }
                    
                }
                if (txtStatusType.EditValue.Equals("1100"))
                {
                    if (ComparisonUtils.IsEmpty(timeEdit_Time_In_First.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_First.EditValue))
                    {
                        //timeEdit_Time_In_Last.EditValue = null;
                        //timeEdit_Time_Out_Last.EditValue = null;
                        SetEditValue(timeEdit_Time_In_Last, null);
                        SetEditValue(timeEdit_Time_Out_Last, null);
                        ProjectFunctionsUtils.SpeakError("Please Enter Time In First and Time Out First");
                        timeEdit_Time_In_First.Focus();

                        return false;
                    }
                }
                if (txtStatusType.EditValue.Equals("0011"))
                {
                    if (ComparisonUtils.IsEmpty(timeEdit_Time_In_Last.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_Last.EditValue))
                    {
                        //timeEdit_Time_In_First.EditValue = null;
                        //timeEdit_Time_Out_First.EditValue = null;
                        SetEditValue(timeEdit_Time_In_First, null);
                        SetEditValue(timeEdit_Time_Out_First, null);
                        ProjectFunctionsUtils.SpeakError("Please Enter Time In Last and Time Out Last");
                        timeEdit_Time_In_Last.Focus();

                        return false;
                    }
                }
            }

            return true;
        }
              

        private void windowsUIButtonPanelCloseButton_Click(object sender, ButtonEventArgs e)
        {
            string tag = ((WindowsUIButton)e.Button).Tag.ToString();

            this.Close();            

        }

        private void radioButtonManual_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonManual.Checked)
            {
                radioButtonMachine.Checked = false;
                panelControl_Manual_In.BackColor = Color.FromArgb(232, 232, 232);
                panelControl_Machine_In.BackColor = Color.White;

                /////////////////////////////////////////
                
                timeEdit_Time_In_First.ReadOnly = false;
                timeEdit_Time_Out_First.ReadOnly = false;
                timeEdit_Time_In_Last.ReadOnly = false;
                timeEdit_Time_Out_Last.ReadOnly = false;
                
                timeEdit_Time_In_First.BackColor = Color.FromArgb(255, 255, 192);
                timeEdit_Time_Out_First.BackColor = Color.FromArgb(255, 255, 192);
                timeEdit_Time_In_Last.BackColor = Color.FromArgb(255, 255, 192);
                timeEdit_Time_Out_Last.BackColor = Color.FromArgb(255, 255, 192);
                
                //timeEdit_Time_In_First.EditValue = null;
                //timeEdit_Time_Out_First.EditValue = null;
                //timeEdit_Time_In_Last.EditValue = null;
                //timeEdit_Time_Out_Last.EditValue = null;

                SetEditValue(timeEdit_Time_In_First, null);
                SetEditValue(timeEdit_Time_Out_First, null);
                SetEditValue(timeEdit_Time_In_Last, null);
                SetEditValue(timeEdit_Time_Out_Last, null);

            }
        }

        private void radioButtonMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMachine.Checked)
            {
                radioButtonManual.Checked = false;
                panelControl_Manual_In.BackColor = Color.White;
                panelControl_Machine_In.BackColor = Color.FromArgb(232, 232, 232);


                timeEdit_Time_In_First.ReadOnly = true;
                timeEdit_Time_Out_First.ReadOnly = true;
                timeEdit_Time_In_Last.ReadOnly = true;
                timeEdit_Time_Out_Last.ReadOnly = true;

                timeEdit_Time_In_First.BackColor = Color.WhiteSmoke;
                timeEdit_Time_Out_First.BackColor = Color.WhiteSmoke;
                timeEdit_Time_In_Last.BackColor = Color.WhiteSmoke;
                timeEdit_Time_Out_Last.BackColor = Color.WhiteSmoke;

                //timeEdit_Time_In_First.EditValue = null;
                //timeEdit_Time_Out_First.EditValue = null;
                //timeEdit_Time_In_Last.EditValue = null;
                //timeEdit_Time_Out_Last.EditValue = null;

                SetEditValue(timeEdit_Time_In_First, null);
                SetEditValue(timeEdit_Time_Out_First, null);
                SetEditValue(timeEdit_Time_In_Last, null);
                SetEditValue(timeEdit_Time_Out_Last, null);
            }
        }

        private void timeEdit_Time_In_DW_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                CalculateDutyHours_DailyWager();
            }
        }

        private void timeEdit_Time_Out_DW_EditValueChanged(object sender, EventArgs e)
        {            
            if ((sender as BaseEdit).Tag == null)
            {
                CalculateDutyHours_DailyWager();
            }
        }

        private void timeEdit_Time_In_First_1_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                PrintLogWin.PrintLog("========= TimeEditSpan => EditValue " + timeEdit_Time_In_First_Testing.EditValue);
                PrintLogWin.PrintLog("========= TimeEditSpan => Text " + timeEdit_Time_In_First_Testing.Text);
            }            
        }

        private void timeEdit_Time_In_First_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                CalculateDUtyHours("first_in");
            }            
        }

        private void timeEdit_Time_Out_First_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                CalculateDUtyHours("first_out");
            }  
        }
        private void timeEdit_Time_In_Last_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                CalculateDUtyHours("last_in");
            }            
        }

        private void timeEdit_Time_Out_Last_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                PrintLogWin.PrintLog("--------------- X " + timeEdit_Time_Out_Last.EditValue);
                CalculateDUtyHours("last_out");
            }            
        }

        private bool hasInputTime(object input)
        {
            if ((input + "").Equals(""))
            {

            }
            return false;
        }

        bool first_in = false;
        bool first_out = false;
        bool last_in = false;
        bool last_out = false;

        private void CalculateDutyHours_DailyWager()
        {
            PrintLogWin.PrintLog("************* CalculateDutyHours_DailyWager");

            try
            {
                if (!form_loaded)
                {

                }
                else
                {
                    double totalHrs_First = 0;

                    if (ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.EditValue) != null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.EditValue) != null)
                    {
                        DateTime dateTime_In_2 = ConvertTo.TimeToDate(timeEdit_Time_In_DW.Text + "");
                        DateTime dateTime_Out_2 = ConvertTo.TimeToDate(timeEdit_Time_Out_DW.Text + "");

                        PrintLogWin.PrintLog("========= A");
                        if (dateTime_Out_2 < dateTime_In_2)
                        {
                            PrintLogWin.PrintLog("========= B");
                            //ProjectFunctions.SpeakError("Time Out First cannot be less than Time In First in Day Shift");
                            //timeEdit_Time_Out_First.EditValue = null;
                        }
                        else
                        {
                            PrintLogWin.PrintLog("========= C");
                            totalHrs_First = (dateTime_Out_2 - dateTime_In_2).TotalMinutes;
                            if (totalHrs_First < 0)
                            {
                                totalHrs_First = totalHrs_First * -1;
                            }
                        }
                    }
                    else
                    {
                        PrintLogWin.PrintLog("========= XX");
                    }

                    double totalHrs_FullDay = totalHrs_First;

                    SetEditValue(totalWorkingHours_Text_DW, totalHrs_FullDay);

                    //totalWorkingHours_Text_DW.Text = (totalHrs_FullDay).ToString();

                    PrintLogWin.PrintLog("========= totalHrs_First : " + totalHrs_First);                    

                    if (ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.EditValue) == null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.EditValue) == null)
                    {
                        //txtOvertimeHours.EditValue = 0;
                        SetEditValue(txtOvertimeHours, 0);

                        PrintLogWin.PrintLog("========= txtOvertimeHours A : " + txtOvertimeHours.EditValue);
                    }
                    else
                    {
                        if (totalHrs_First > 0)
                        {

                            //txtOvertimeHours.EditValue = ConvertTo.IntVal(totalWorkingHours_Text_DW.EditValue) - ConvertTo.IntVal(txtDutyHours_DW.EditValue);
                            SetEditValue(txtOvertimeHours, ConvertTo.IntVal(totalWorkingHours_Text_DW.EditValue) - ConvertTo.IntVal(txtDutyHours_DW.EditValue));

                            PrintLogWin.PrintLog("========= txtOvertimeHours B : " + txtOvertimeHours.EditValue);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(timeEdit_Time_In_First.EditValue + "\n\n" + ex + "");
            }
        }
        private void CalculateDUtyHours(string entry)
        {
            //DateTime.ParseExact(Eval("aeStart").ToString(), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToShortTimeString()
            int shift_id = 1;

            PrintLogWin.PrintLog("************* CalculateDUtyHours => CalculateDUtyHours");

            try
            {

                PrintLogWin.PrintLog("************* form_loaded => " + form_loaded + "");

                PrintLogWin.PrintLog("************* timeEdit_Time_In_First.EditValue => " + timeEdit_Time_In_First.EditValue + "");
                PrintLogWin.PrintLog("************* timeEdit_Time_Out_First.EditValue => " + timeEdit_Time_Out_First.EditValue + "");
                PrintLogWin.PrintLog("************* timeEdit_Time_In_Last.EditValue => " + timeEdit_Time_In_Last.EditValue + "");
                PrintLogWin.PrintLog("************* timeEdit_Time_Out_Last.EditValue => " + timeEdit_Time_Out_Last.EditValue + "");

                PrintLogWin.PrintLog("############ timeEdit_Time_In_First.Text => " + timeEdit_Time_In_First.Text + "");
                PrintLogWin.PrintLog("############ timeEdit_Time_Out_First.Text => " + timeEdit_Time_Out_First.Text + "");
                PrintLogWin.PrintLog("############ timeEdit_Time_In_Last.Text => " + timeEdit_Time_In_Last.Text + "");
                PrintLogWin.PrintLog("############ timeEdit_Time_Out_Last.Text => " + timeEdit_Time_Out_Last.Text + "");


                if (!form_loaded)
                {

                }
                else
                {
                    double totalHrs_First = 0;
                    double totalHrs_Last = 0;

                    //ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue)
                    if (ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue) != null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue) != null)
                    {
                        DateTime dateTime_In_2 = ConvertTo.TimeToDate(timeEdit_Time_In_First.Text + "");
                        DateTime dateTime_Out_2 = ConvertTo.TimeToDate(timeEdit_Time_Out_First.Text + "");

                        PrintLogWin.PrintLog("========= A");

                        if (dateTime_Out_2 < dateTime_In_2)
                        {
                            PrintLogWin.PrintLog("========= B");
                            //ProjectFunctions.SpeakError("Time Out First cannot be less than Time In First in Day Shift");
                            //timeEdit_Time_Out_First.EditValue = null;
                        }
                        else
                        {
                            PrintLogWin.PrintLog("========= C");
                            totalHrs_First = (dateTime_Out_2 - dateTime_In_2).TotalMinutes;
                            if (totalHrs_First < 0)
                            {
                                totalHrs_First = totalHrs_First * -1;
                            }
                        }
                    }
                    else
                    {
                        PrintLogWin.PrintLog("========= XX");
                    }

                    if (ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue) != null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue) != null)
                    {
                        DateTime dateTime_In_Last = ConvertTo.TimeToDate(timeEdit_Time_In_Last.Text + "");
                        DateTime dateTime_Out_Last = ConvertTo.TimeToDate(timeEdit_Time_Out_Last.Text + "");

                        PrintLogWin.PrintLog("========= D");

                        if (ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue) != null)
                        {
                            PrintLogWin.PrintLog("========= E");

                            DateTime dateTime_Out_1 = ConvertTo.TimeToDate(timeEdit_Time_Out_First.Text + "");

                            if (dateTime_In_Last < dateTime_Out_1)
                            {
                                PrintLogWin.PrintLog("========= F");
                                //ProjectFunctions.SpeakError("Time In Last cannot be less than Time Out First in Day Shift");
                                //timeEdit_Time_In_Last.EditValue = null;
                            }
                            else
                            {
                                PrintLogWin.PrintLog("========= G");

                                if (dateTime_Out_Last < dateTime_In_Last)
                                {
                                    PrintLogWin.PrintLog("========= H");
                                    //ProjectFunctions.SpeakError("Time Out Last cannot be less than Time In Last in Day Shift");
                                    //timeEdit_Time_Out_Last.EditValue = null;
                                }
                                else
                                {
                                    PrintLogWin.PrintLog("========= I");
                                    totalHrs_Last = (dateTime_Out_Last - dateTime_In_Last).TotalMinutes;
                                    if (totalHrs_Last < 0)
                                    {
                                        totalHrs_Last = totalHrs_Last * -1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            PrintLogWin.PrintLog("========= J");

                            if (dateTime_Out_Last < dateTime_In_Last)
                            {
                                PrintLogWin.PrintLog("========= K");
                                //ProjectFunctions.SpeakError("Time Out Last cannot be less than Time In Last in Day Shift");
                                //timeEdit_Time_Out_Last.EditValue = null;
                            }
                            else
                            {
                                PrintLogWin.PrintLog("========= L");
                                totalHrs_Last = (dateTime_Out_Last - dateTime_In_Last).TotalMinutes;
                                if (totalHrs_Last < 0)
                                {
                                    PrintLogWin.PrintLog("========= M");
                                    totalHrs_Last = totalHrs_Last * -1;
                                }
                            }
                        }

                    }
                    else
                    {
                        PrintLogWin.PrintLog("========= ZZ");
                    }

                    double totalHrs_FullDay = totalHrs_First + totalHrs_Last;
                    double no_lunch_add_minutes = 60;
                    if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0)
                    {
                        if (totalHrs_First > 0 && totalHrs_Last > 0)
                        {
                            totalHrs_FullDay = totalHrs_FullDay + no_lunch_add_minutes;
                        }
                    }

                    //totalWorkingHours_Text.Text = (totalHrs_FullDay).ToString();
                    SetEditValue(totalWorkingHours_Text, totalHrs_FullDay);

                    PrintLogWin.PrintLog("========= totalHrs_First : " + totalHrs_First);
                    PrintLogWin.PrintLog("========= totalHrs_Last : " + totalHrs_Last);

                    if (ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue) == null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue) == null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue) == null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue) == null)
                    {
                        //txtOvertimeHours.EditValue = 0;
                        SetEditValue(txtOvertimeHours, 0);

                        PrintLogWin.PrintLog("========= txtOvertimeHours A : " + txtOvertimeHours.EditValue);
                    }
                    else
                    {
                        if (totalHrs_First > 0 || totalHrs_Last > 0)
                        {
                            DateTime dateTime_In_Last_GP = ConvertTo.TimeToDate(timeEdit_Time_In_Last.Text + "");
                            DateTime dateTime_Out_GP = ConvertTo.TimeToDate(timeEdit_Time_Out_First.Text + "");

                            //timeEdit_GatePassTime.EditValue = (dateTime_In_Last_GP - dateTime_Out_GP).TotalHours;

                            //txtOvertimeHours.EditValue = ConvertTo.IntVal(totalWorkingHours_Text.EditValue) - (ConvertTo.IntVal(totalWorkingHours_Text_Main.EditValue) * 60);
                            SetEditValue(txtOvertimeHours, ConvertTo.IntVal(totalWorkingHours_Text.EditValue) - (ConvertTo.IntVal(totalWorkingHours_Text_Main.EditValue) * 60));

                            PrintLogWin.PrintLog("========= txtOvertimeHours B : " + txtOvertimeHours.EditValue);
                        }
                    }
                       
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(timeEdit_Time_In_First.EditValue + "\n\n" + ex + "");
            }
        }

        private void comboBox_Status_DropDownClosed(object sender, EventArgs e)
        {
            //totalWorkingHours_Text.EditValue = null;
            //txtOvertimeHours.EditValue = null;
            //timeEdit_GatePassTime.EditValue = null;

            SetEditValue(totalWorkingHours_Text, null);
            SetEditValue(txtOvertimeHours, null);
            SetEditValue(timeEdit_GatePassTime, null);

            timeEdit_Time_Out_First.Enabled = true;
            timeEdit_Time_In_Last.Enabled = true;            

            string status_type = "";
            foreach (AttendanceStatu item in attendanceStatu_List)
            {
                if (item.status_id == ConvertTo.IntVal(comboBox_Status.SelectedValue))
                {
                    status_type = item.status_type;
                    break;
                }
            }
            if (!status_type.Equals(""))
            {
                string firstChar = status_type.Substring(0, 1);
                string clearStr = status_type.Replace("-", "").Replace("+", "");

                //txtStatusType.EditValue = status_type;
                SetEditValue(txtStatusType, status_type);

                if (firstChar.Equals("-"))
                {
                    
                }

                if (clearStr.Equals("0000"))
                {
                    //timeEdit_Time_In_First.EditValue = null;
                    //timeEdit_Time_Out_First.EditValue = null;
                    //timeEdit_Time_In_Last.EditValue = null;
                    //timeEdit_Time_Out_Last.EditValue = null;

                    SetEditValue(timeEdit_Time_In_First, null);
                    SetEditValue(timeEdit_Time_Out_First, null);
                    SetEditValue(timeEdit_Time_In_Last, null);
                    SetEditValue(timeEdit_Time_Out_Last, null);
                    PrintLogWin.PrintLog("--------------- A " + clearStr);

                }
                if (clearStr.Equals("1100"))
                {
                    //timeEdit_Time_In_First.EditValue = timeEdit_Time_In_First_Main.EditValue;
                    //timeEdit_Time_Out_First.EditValue = timeEdit_Time_Out_First_Main.EditValue;
                    //timeEdit_Time_In_Last.EditValue = null;
                    //timeEdit_Time_Out_Last.EditValue = null;

                    SetEditValue(timeEdit_Time_In_First, timeEdit_Time_In_First_Main.EditValue);
                    SetEditValue(timeEdit_Time_Out_First, timeEdit_Time_Out_First_Main.EditValue);
                    SetEditValue(timeEdit_Time_In_Last, null);
                    SetEditValue(timeEdit_Time_Out_Last, null);

                    PrintLogWin.PrintLog("--------------- B " + clearStr);
                }
                if (clearStr.Equals("0011"))
                {
                    //timeEdit_Time_In_First.EditValue = null;
                    //timeEdit_Time_Out_First.EditValue = null;
                    //timeEdit_Time_In_Last.EditValue = timeEdit_Time_In_Last_Main.EditValue;
                    //timeEdit_Time_Out_Last.EditValue = timeEdit_Time_Out_Last_Main.EditValue;

                    SetEditValue(timeEdit_Time_In_First, null);
                    SetEditValue(timeEdit_Time_Out_First, null);
                    SetEditValue(timeEdit_Time_In_Last, timeEdit_Time_In_Last_Main.EditValue);
                    SetEditValue(timeEdit_Time_Out_Last, timeEdit_Time_Out_Last_Main.EditValue);

                    PrintLogWin.PrintLog("--------------- C " + clearStr);
                }
                if (clearStr.Equals("1111"))
                {
                    if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0)
                    {
                        timeEdit_Time_Out_First.Enabled = false;
                        timeEdit_Time_In_Last.Enabled = false;
                    }
                    else
                    {
                        timeEdit_Time_Out_First.Enabled = true;
                        timeEdit_Time_In_Last.Enabled = true;
                    }
                    //timeEdit_Time_In_First.EditValue = timeEdit_Time_In_First_Main.EditValue;
                    //timeEdit_Time_Out_First.EditValue = timeEdit_Time_Out_First_Main.EditValue;
                    //timeEdit_Time_In_Last.EditValue = timeEdit_Time_In_Last_Main.EditValue;
                    //timeEdit_Time_Out_Last.EditValue = timeEdit_Time_Out_Last_Main.EditValue;

                    SetEditValue(timeEdit_Time_In_First, timeEdit_Time_In_First_Main.EditValue);
                    SetEditValue(timeEdit_Time_Out_First, timeEdit_Time_Out_First_Main.EditValue);
                    SetEditValue(timeEdit_Time_In_Last, timeEdit_Time_In_Last_Main.EditValue);
                    SetEditValue(timeEdit_Time_Out_Last, timeEdit_Time_Out_Last_Main.EditValue);

                    PrintLogWin.PrintLog("--------------- D " + clearStr);
                }
            }
            else
            {
                txtStatusType.EditValue = null;

                PrintLogWin.PrintLog("--------------- E");
            }
            
            //if (status_type)
        }

        private void txtLunchBreak_EditValueChanged(object sender, EventArgs e)
        {
            string clearStr = "";
            if (GetEditValue(txtStatusType) != null)
            {
                clearStr = GetEditValue(txtStatusType).ToString().Replace("-", "").Replace("+", "");
            }

            PrintLogWin.PrintLog("========= txtLunchBreak_EditValueChanged => clearStr : " + clearStr);

            if (clearStr.Equals("1111"))
            {
                if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0)
                {
                    timeEdit_Time_Out_First.Enabled = false;
                    timeEdit_Time_In_Last.Enabled = false;
                    PrintLogWin.PrintLog("========= txtLunchBreak_EditValueChanged => txtLunchBreak : " + 0);
                }
                else
                {
                    timeEdit_Time_Out_First.Enabled = true;
                    timeEdit_Time_In_Last.Enabled = true;

                    PrintLogWin.PrintLog("========= txtLunchBreak_EditValueChanged => txtLunchBreak : " + 1);
                }

                SetEditValue(timeEdit_Time_In_First, timeEdit_Time_In_First_Main.EditValue);
                SetEditValue(timeEdit_Time_Out_First, timeEdit_Time_Out_First_Main.EditValue);
                SetEditValue(timeEdit_Time_In_Last, timeEdit_Time_In_Last_Main.EditValue);
                SetEditValue(timeEdit_Time_Out_Last, timeEdit_Time_Out_Last_Main.EditValue);

                PrintLogWin.PrintLog("--------------- D " + clearStr);
            }
            else
            {
                timeEdit_Time_In_First.Enabled = true;
                timeEdit_Time_Out_First.Enabled = true;
                timeEdit_Time_In_Last.Enabled = true;
                timeEdit_Time_Out_Last.Enabled = true;

                PrintLogWin.PrintLog("========= txtLunchBreak_EditValueChanged => txtLunchBreak : " + 2);
            }

        }

        private void textEmpType_EditValueChanged(object sender, EventArgs e)
        {
            

        }

        private void totalWorkingHours_Text_EditValueChanged(object sender, EventArgs e)
        {
            
            if ((sender as BaseEdit).Tag == null)
            {
                totalWorkingHours_Label.Text = ConvertTo.MinutesToHours(totalWorkingHours_Text.EditValue);
            }

        }

        private void txtOvertimeHours_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                lblOvertimeHours.Text = ConvertTo.MinutesToHours(txtOvertimeHours.EditValue);
            }
            
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

        private void txtEmpCode_EditValueChanged(object sender, EventArgs e)
        {            

            if ((sender as BaseEdit).Tag == null)
            {
                if (txtEmpID.Text.Length >= 4)
                {
                    employeeFormData_Load(txtEmpID.Text);
                }
            }

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
                    if (txtEmpID.Text.Length == 0)
                    {
                        strQry = strQry + "select Empcode as Code,Empname as Description,EmpImage, DailyWage, DailyWageRate, DailyWageMinutes from EmpMst  order by Empname";
                        ds = ProjectFunctions.GetDataSet(strQry);
                        HelpGrid.DataSource = ds.Tables[0];
                        HelpGridView.BestFitColumns();
                        HelpGrid.Show();
                        HelpGrid.Focus();
                    }
                    else
                    {
                        strQry = strQry + "select empcode as Code,empname as Description,EmpImage, DailyWage, DailyWageRate, DailyWageMinutes from EmpMst wHERE  empcode= '" + txtEmpID.Text.ToString().Trim() + "' ";

                        ds = ProjectFunctions.GetDataSet(strQry);
                        if (ds.Tables[0].Rows.Count > 0)

                        {
                            DataRow dr = ds.Tables[0].Rows[0];
                            //txtEmpID.Text = dr["Code"].ToString().Trim().ToUpper();
                            //txtFName.Text = dr["Description"].ToString().Trim().ToUpper();

                            SetEditValue(txtEmpID, dr["Code"]);
                            SetEditValue(txtFName, dr["Description"]);

                            pictureBox1.Image = ImageUtils.ConvertBinaryToImage((byte[])dr["EmpImage"]);

                            

                            SetDailyWageControls(Convert.ToBoolean(dr["DailyWage"]), ConvertTo.IntVal(dr["DailyWageMinutes"]), Convert.ToDecimal(dr["DailyWageRate"]));


                            comboBox_Status.Focus();

                        }
                        else
                        {
                            var strQry1 = string.Empty;
                            strQry1 = strQry1 + "select empcode as Code,empname as Description,EmpImage, DailyWage, DailyWageRate, DailyWageMinutes from EmpMst  order by Empname";
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
            var dr = HelpGridView.GetDataRow(HelpGridView.FocusedRowHandle);
            if (HelpGrid.Text == "txtEmpCode")
            {
                //txtEmpID.Text = dr["Code"].ToString().Trim();
                //txtFName.Text = dr["Description"].ToString().Trim();

                SetEditValue(txtEmpID, dr["Code"]);
                SetEditValue(txtFName, dr["Description"]);

                pictureBox1.Image = ImageUtils.ConvertBinaryToImage((byte[])dr["EmpImage"]);
               

                SetDailyWageControls(Convert.ToBoolean(dr["DailyWage"]), ConvertTo.IntVal(dr["DailyWageMinutes"]), Convert.ToDecimal(dr["DailyWageRate"]));

                HelpGrid.Visible = false;
                comboBox_Status.Focus();
            }
            //if (HelpGrid.Text == "txtStatusCode")
            //{
            //    txtStatusCode.Text = row["Code"].ToString().Trim();
            //    txtStatusCodeDesc.Text = row["Description"].ToString().Trim();
            //    HelpGrid.Visible = false;
            //    timeEdit_Time_Out.Focus();
            //}

        }

        




        /*
        static List<Employee> GetDataSource()
        {
            List<Employee> result = new List<Employee>();
            Employee employee = new Employee();

            employee.AddressLine1 = "527 W 7th St, Los Angeles, CA";
            employee.AddressLine2 = "3800 Homer St, Los Angeles, CA";
            employee.BirthDate = new DateTime(1983, 11, 19);
            employee.Email = "ameliah@dx-email.com";
            employee.Skype = "ameliah_DX_skype";
            employee.FirstName = "Amelia";
            employee.Gender = Gender.Female;
            employee.Group = "IT";
            employee.Image = Base64ToImage(ImageBase64String);
            employee.HireDate = new DateTime(2011, 10, 2);
            employee.LastName = "Harper";
            employee.Phone = "(213)555-3792";
            employee.Salary = 25400;
            employee.Title = "Manager";
            employee.Description = @"Amelia is on probation for failure to follow-up on tasks.  We hope to see her back at her desk shortly. Please remember negligence of assigned tasks is not something we tolerate.";

            result.Add(employee);
            return result;
        }
        public static Image Base64ToImage(string base64Image)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64Image)))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public enum Gender { Male, Female }
        public class Employee
        {
            const string RootGroup = "<Root>";
            const string Photo = RootGroup + "/" + "<Photo->";
            const string FirstNameAndLastName = Photo + "/" + "<FirstAndLastName>";
            const string TabbedGroup = FirstNameAndLastName + "/" + "{Tabs}";
            const string ContactGroup = TabbedGroup + "/" + "Contact";
            const string BDateAndGender = ContactGroup + "/" + "<BDateAndGender->";
            const string HomeAddressAndPhone = ContactGroup + "/" + "<HomeAddressAndPhone->";
            const string JobGroup = TabbedGroup + "/" + "Job";
            const string HDateAndSalary = JobGroup + "/" + "<HDateAndSalary->";
            const string EmailAndSkype = JobGroup + "/" + "<EmailAndSkype->";
            const string GroupAndTitle = JobGroup + "/" + "<GroupAndTitle->";

            [Key, Display(AutoGenerateField = false)]
            public int ID { get; set; }
            [Display(Name = "Last name", GroupName = FirstNameAndLastName, Order = 2)]
            public string LastName { get; set; }
            [Display(Name = "First name", GroupName = FirstNameAndLastName, Order = 1)]
            public string FirstName { get; set; }
            [Display(Name = "", GroupName = Photo, Order = 0)]
            public Image Image { get; set; }
            [Display(Name = "Phone", GroupName = HomeAddressAndPhone)]
            public string Phone { get; set; }
            [Display(Name = "E-Mail", GroupName = EmailAndSkype, Order = 5)]
            public string Email { get; set; }
            [Display(Name = "Skype", GroupName = EmailAndSkype)]
            public string Skype { get; set; }
            [Display(Name = "Home address", GroupName = HomeAddressAndPhone)]
            public string AddressLine1 { get; set; }
            [Display(Name = "Work address", GroupName = JobGroup)]
            public string AddressLine2 { get; set; }
            [Display(Name = "About", GroupName = RootGroup), DataType(DataType.MultilineText)]
            public string Description { get; set; }
            [Range(typeof(DateTime), "1/1/1900", "1/1/2000", ErrorMessage = "Birthday is out of Range")]
            [Display(Name = "Birthday", GroupName = BDateAndGender, Order = 3)]
            public DateTime BirthDate { get; set; }
            [Display(Name = "Gender", GroupName = BDateAndGender)]
            public Gender Gender { get; set; }
            [Display(Name = "Group", GroupName = GroupAndTitle, Order = 6)]
            public string Group { get; set; }
            [Display(Name = "Hire date", GroupName = HDateAndSalary, Order = 4)]
            public DateTime HireDate { get; set; }
            [Display(Name = "Salary", GroupName = HDateAndSalary)]
            public decimal Salary { get; set; }
            [Display(Name = "Title", GroupName = GroupAndTitle)]
            public string Title { get; set; }
        }
        public const string ImageBase64String = "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";

        private void labelControl_Click(object sender, EventArgs e)
        {
            if (s1 == "&Add")
            {

            }
        }
        */


        /*
         
         private void LoadAttendanceData_OLD()
        {

            if (selected_serial_id != 0)
            {
                crudAction = CrudAction.Update;

                labelControl.Text = "Update Attendance";

                RepList<EmployeeAttendance> lista = new RepList<EmployeeAttendance>();
                DynamicParameters param = new DynamicParameters();
                param.Add("@serial_id", selected_serial_id);
                EmployeeAttendance query_attendance = lista.returnClass("SELECT ea.*, em.DailyWage, em.LunchBreak, em.OT_Extra FROM EmployeeAttendance ea, EmpMST em WHERE serial_id=@serial_id AND ea.employee_code = em.EmpCode", param);

                //using (SEQKARTNewEntities db = new SEQKARTNewEntities())
                if (query_attendance != null)
                {

                    
                   //txtEmpID.Text = query_attendance.employee_code;
                    //txtLunchBreak.EditValue = query_attendance.LunchBreak;

                    SetEditValue(txtEmpID, query_attendance.employee_code);
                    SetEditValue(txtLunchBreak, query_attendance.LunchBreak);

                    var sql1 = query_attendance.ToString();

                    PrintLogWin.PrintLog("query_attendance => " + sql1);
                    PrintLogWin.PrintLog("selected_serial_id => " + selected_serial_id);
                    PrintLogWin.PrintLog("status_id => " + query_attendance.status_id);

                    ControllerUtils.SelectItemByValue(comboBox_Status, query_attendance.status_id + "");
                    ControllerUtils.SelectItemByValue(comboBox_Shift, query_attendance.shift_id + "");

                    //DateTime time_in = employeeAttendance.attendance_in.GetValueOrDefault(DateTime.Now);

                    //timeAttIn_First_Manual.EditValue = query_attendance.attendance_in_first;// new DateTime(time_in.Year, time_in.Month, time_in.Day, 23, 59, 00); ;
                    //timeAttOut_First_Manual.EditValue = query_attendance.attendance_out_first;
                    //DateTime att_date = query_attendance.attendance_date ? 

                    //dateAttendance.Value = (DateTime)((query_attendance.attendance_date == null) ? DateTime.Now : query_attendance.attendance_date);

                    if (query_attendance.DailyWage)
                    {
                        //timeEdit_Time_In_DW.EditValue = ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_first);//(TimeSpan)((query_attendance.attendance_in_first == null) ? null : query_attendance.attendance_in_first); 
                        //timeEdit_Time_Out_DW.EditValue = ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_first);// (TimeSpan)((query_attendance.attendance_out_first == null) ? null : query_attendance.attendance_out_first);                    

                        SetEditValue(timeEdit_Time_In_DW, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_first));
                        SetEditValue(timeEdit_Time_Out_DW, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_first));

                        PrintLogWin.PrintLog("timeEdit_Time_In_DW : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.EditValue));
                        PrintLogWin.PrintLog("timeEdit_Time_Out_DW : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.EditValue));

                    }
                    else
                    {
                        
                        timeEdit_Time_In_First.EditValue = ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_first);//(TimeSpan)((query_attendance.attendance_in_first == null) ? null : query_attendance.attendance_in_first); 
                        timeEdit_Time_Out_First.EditValue = ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_first);// (TimeSpan)((query_attendance.attendance_out_first == null) ? null : query_attendance.attendance_out_first);                    
                        timeEdit_Time_In_Last.EditValue = ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_last);//(TimeSpan)((query_attendance.attendance_in_last == null) ? null : query_attendance.attendance_in_last);
                        timeEdit_Time_Out_Last.EditValue = ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_last);//(TimeSpan)((query_attendance.attendance_out_last == null) ? null : query_attendance.attendance_out_last);

                        SetEditValue(timeEdit_Time_In_First, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_first));
                        SetEditValue(timeEdit_Time_Out_First, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_first));
                        SetEditValue(timeEdit_Time_In_Last, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_last));
                        SetEditValue(timeEdit_Time_Out_Last, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_last));


                        PrintLogWin.PrintLog("timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue));
                        PrintLogWin.PrintLog("timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue));
                        PrintLogWin.PrintLog("timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue));
                        PrintLogWin.PrintLog("timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue));
                    }


                    SetEditValue(totalWorkingHours_Text, query_attendance.working_hours);
                    SetEditValue(timeEdit_GatePassTime, query_attendance.gate_pass_time);
                    SetEditValue(txtOvertimeHours, query_attendance.ot_deducton_time);

                    //totalWorkingHours_Text.EditValue = query_attendance.working_hours;
                    //timeEdit_GatePassTime.EditValue = query_attendance.gate_pass_time;
                    //txtOvertimeHours.EditValue = query_attendance.ot_deducton_time;

                    //pictureBox1.Image
                    
                    if (query_attendance.attendance_date != null)
                    {
                        DateTime dd = query_attendance.attendance_date.GetValueOrDefault(DateTime.Now);                        
                        labelDate_Current.Text = ConvertTo.DateFormatApp(dd);
                    }

                    if (query_attendance.attendance_source == 1)
                    {
                        radioButtonManual.Checked = true;
                        radioButtonMachine.Checked = false;
                    }
                    else
                    {
                        radioButtonManual.Checked = false;
                        radioButtonMachine.Checked = true;
                    }                    
                }

            }
            else
            {
                crudAction = CrudAction.Create;

                labelDate_Current.Text = ConvertTo.DateFormatApp(DateTime.Now);//culture
                //txtOvertimeHours.Text = "0";
                SetEditValue(txtOvertimeHours, 0);

                SetEditValue(timeEdit_Time_In_First, null);
                SetEditValue(timeEdit_Time_Out_First, null);
                SetEditValue(timeEdit_Time_In_Last, null);
                SetEditValue(timeEdit_Time_Out_Last, null);

                SetEditValue(txtDutyHours_DW, null);
                SetEditValue(timeEdit_Time_In_DW, null);
                SetEditValue(timeEdit_Time_Out_DW, null);
                SetEditValue(totalWorkingHours_Text_DW, null);

                //timeEdit_Time_In_First.EditValue = null;
                //timeEdit_Time_Out_First.EditValue = null;
                //timeEdit_Time_In_Last.EditValue = null;
                //timeEdit_Time_Out_Last.EditValue = null;

                //Daily Wager
                //txtDutyHours_DW.EditValue = null;
                //timeEdit_Time_In_DW.EditValue = null;
                //timeEdit_Time_Out_DW.EditValue = null;
                //totalWorkingHours_Text_DW.EditValue = null;

            }
            PrintLogWin.PrintLog("********************* 1 ");
            form_loaded = true;
            //CalculateDUtyHours("all");
        }
         */
    }
}