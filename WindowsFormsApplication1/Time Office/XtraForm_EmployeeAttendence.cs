using Dapper;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using SeqKartLibrary;
using SeqKartLibrary.CrudTask;
using SeqKartLibrary.HelperClass;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Forms_Master;

namespace WindowsFormsApplication1.Time_Office
{
    public partial class XtraForm_EmployeeAttendence : DevExpress.XtraEditors.XtraForm
    {
        //public event EventHandler<ThresholdReachedEventArgs> ChildWantedSomething;        

        private frmAttendenceLaoding _frmAttendenceLaoding = null;

        //private string selected_employee_code = "";
        public int selected_serial_id = 0;// { get; set; }
        public string come_from = "";// { get; set; }

        public string selected_employee_code = "";
        public string selected_attendance_date = "";

        private bool next_date_after_save = false;

        private bool input_fields_empty = false;

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

        private void ReloadDataGrid_Parent()
        {
            ThresholdReachedEventArgs eventArgs = new ThresholdReachedEventArgs
            {
                EmpCode = GetEditValue(txtEmpID) + "",
                AttendanceDate = dateAttendance.Value
            };

            _frmAttendenceLaoding.ReloadDataGrid(null, eventArgs);
            /*
            // Instead of new ParentForm().SomeMethod()
            EventHandler<ThresholdReachedEventArgs> eh = ChildWantedSomething;
            if (eh != null)
            {
                ThresholdReachedEventArgs eventArgs = new ThresholdReachedEventArgs();
                eventArgs.EmpCode = GetEditValue(txtEmpID) + "";
                eventArgs.AttendanceDate = dateAttendance.Value;

                eh(this, eventArgs);
            }
            */
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


            dateAttendance.ValueChanged -= dateAttendance_ValueChanged;
            dateAttendance.Value = ConvertTo.DateTimeVal(selected_attendance_date);
            dateAttendance.ValueChanged += dateAttendance_ValueChanged;

            DateTime today = dateAttendance.Value;
            lblDayName.Text = today.ToString("dddd");

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
        }

        public void SetComboSelectedValue(System.Windows.Forms.ComboBox combo, object newEditValue)
        {
            try
            {
                combo.Tag = 0;
                ControllerUtils.SelectItemByValue(combo, newEditValue + "");
            }
            finally
            {
                combo.Tag = null;
            }
        }

        public void SetComboSelectedValue_NullTag(System.Windows.Forms.ComboBox combo, object newEditValue)
        {
            try
            {
                ControllerUtils.SelectItemByValue(combo, newEditValue + "");
            }
            finally
            {

            }
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
            PrintLogWin.PrintLog("********************* _DailyWageMinutes : " + _DailyWageMinutes);
            PrintLogWin.PrintLog("********************* _DailyWageRate : " + _DailyWageRate);

            SetEditValue(textEmpType, ((_DailyWage == true) ? "Daily Wager" : "Regular"));
            SetEditValue(txtDailyWager, _DailyWage);
            /*
            if (_DailyWage)
            {
                grpBoxDailyWager.Enabled = true;
                grpBoxEmployee.Enabled = false;

                grpBoxDailyWager.Visible = true;
                grpBoxEmployee.Visible = false;


                SetEditValue_NullTag(txtDutyHours_DW, _DailyWageMinutes);

                SetEditValue(timeEdit_Time_In_First, null);
                SetEditValue(timeEdit_Time_Out_First, null);
                SetEditValue(timeEdit_Time_In_Last, null);
                SetEditValue(timeEdit_Time_Out_Last, null);

                SetEditValue_NullTag(totalWorkingHours_Text, null);
                SetEditValue_NullTag(txtOvertimeHours, null);
            }
            else
            {
                grpBoxDailyWager.Visible = false;
                grpBoxEmployee.Visible = true;

                grpBoxDailyWager.Enabled = false;
                grpBoxEmployee.Enabled = true;


                SetEditValue_NullTag(txtDutyHours_DW, null);
                SetEditValue(timeEdit_Time_In_DW, null);
                SetEditValue(timeEdit_Time_Out_DW, null);
                SetEditValue_NullTag(totalWorkingHours_Text_DW, null);
                SetEditValue_NullTag(txtOvertimeHours, null);
            }
            */
        }

        private void SetProfilePicture(byte[] data)
        {
            try
            {
                if (data != null)
                {
                    pictureBox1.Image = ImageUtils.ConvertBinaryToImage(data);
                }
            }
            catch (Exception ex)
            {

            }

        }
        private void employeeFormData_Load(string EmpCode)
        {
            windowsUIButtonPanelMain.Enabled = false;

            PrintLogWin.PrintLog("********************* 2");

            RepList<EmployeeMasterModel> lista = new RepList<EmployeeMasterModel>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmpCode", EmpCode);


            EmployeeMasterModel empData = lista.returnClass_SP(SQL_QUERIES._sp_EmployeeDetails(), param);

            PrintLogWin.PrintLog("employeeFormData_Load 1 => SQL => ******************** sp_EmployeeDetails '" + EmpCode + "'");

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
                SetEditValue(txtTeaBreakTime, empData.TeaBreakTime);

                SetProfilePicture(empData.EmpImage);

                SetDailyWageControls(empData.DailyWage, empData.DailyWageMinutes, empData.DailyWageRate);

                PrintLogWin.PrintLog("employeeFormData_Load 2 => ********************");


                LoadAttendanceData();
            }
            else
            {
                SetEditValue(timeEdit_Time_In_First_Main, null);
                SetEditValue(timeEdit_Time_Out_First_Main, null);
                SetEditValue(timeEdit_Time_In_Last_Main, null);
                SetEditValue(timeEdit_Time_Out_Last_Main, null);

                SetEditValue(totalWorkingHours_Text_Main, null);

                SetEditValue(txtFName, null);
                SetEditValue(txtEmpID, null);
                SetEditValue_NullTag(txtLunchBreak, null);
                SetEditValue(txtDepartment, null);
                SetEditValue(txtDesignation, null);
                SetEditValue(textUnit, null);

                SetProfilePicture(null);

                SetDailyWageControls(false, null, null);

                PrintLogWin.PrintLog("employeeFormData_Load 3 => ********************");

                windowsUIButtonPanelMain.Enabled = true;
            }

        }

        //private EmployeeAttendance query_attendance;
        private void Load_Status_Shift_Data()
        {
            RepList<object> repObj = new RepList<object>();
            attendanceStatu_List = repObj.returnListClass_1<AttendanceStatu>("SELECT * FROM AttendanceStatus", null);

            if (ComparisonUtils.IsNotNull_List(attendanceStatu_List))
            {
                comboBox_Status.SelectedValueChanged -= comboBox_Status_SelectedValueChanged;

                comboBox_Status.DataSource = attendanceStatu_List;
                comboBox_Status.ValueMember = SQL_COLUMNS._AttendanceStatus._status_id;
                comboBox_Status.DisplayMember = SQL_COLUMNS._AttendanceStatus._status;

                comboBox_Status.SelectedValueChanged += comboBox_Status_SelectedValueChanged;
            }

            List<DailyShift> dailyShifts_List = new List<DailyShift>();

            DailyShift dailyShift = new DailyShift
            {
                shift_id = 1,
                shift_name = "Daily Shift"
            };
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
            PrintLogWin.PrintLog("%%%%%%%%%%% => LoadAttendanceData()");

            RepList<EmployeeAttendance> lista = new RepList<EmployeeAttendance>();
            DynamicParameters param = new DynamicParameters();
            param.Add("@serial_id", selected_serial_id);

            //string sql = "SELECT ea.*, em.DailyWage, em.LunchBreak, em.OT_Extra FROM EmployeeAttendance ea, EmpMST em WHERE ea.employee_code = '" + GetEditValue(txtEmpID) + "' AND CONVERT(varchar, CAST( ea.attendance_date AS Date ), 23) = CONVERT(varchar, CAST( '" + ConvertTo.DateFormatDb(dateAttendance.Value) + "' AS Date ), 23) AND ea.employee_code = em.EmpCode";
            string sql = "SELECT ea.*, ats.status_type, em.DailyWage, em.LunchBreak, em.OT_Extra FROM EmployeeAttendance ea, EmpMST em, AttendanceStatus ats WHERE ea.employee_code = '" + GetEditValue(txtEmpID) + "' AND CONVERT(varchar, CAST( ea.attendance_date AS Date ), 23) = CONVERT(varchar, CAST( '" + ConvertTo.DateFormatDb(dateAttendance.Value) + "' AS Date ), 23) AND ea.employee_code = em.EmpCode AND ea.status_id = ats.status_id";
            PrintLogWin.PrintLog(sql);
            EmployeeAttendance query_attendance = lista.returnClass(sql, param);

            if (query_attendance != null)
            {
                form_loaded = true;

                SetEditValue(txtSerial_ID, query_attendance.serial_id);
                SetEditValue(txtEmpID, query_attendance.employee_code);
                SetEditValue(txtLunchBreak, query_attendance.LunchBreak);

                var sql1 = query_attendance.ToString();

                PrintLogWin.PrintLog("query_attendance => " + sql1);
                PrintLogWin.PrintLog("selected_serial_id => " + selected_serial_id);
                PrintLogWin.PrintLog("status_id => " + query_attendance.status_id);

                SetComboSelectedValue_NullTag(comboBox_Status, query_attendance.status_id);
                SetComboSelectedValue(comboBox_Shift, query_attendance.shift_id);

                //////////////////////////////////////
                SetEditValue(timeEdit_Time_In_First, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_first));
                SetEditValue(timeEdit_Time_Out_First, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_first));
                SetEditValue(timeEdit_Time_In_Last, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_in_last));
                SetEditValue(timeEdit_Time_Out_Last, ConvertTo.TimeSpanVal_Null(query_attendance.attendance_out_last));

                PrintLogWin.PrintLog("timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue));
                PrintLogWin.PrintLog("timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue));
                PrintLogWin.PrintLog("timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue));
                PrintLogWin.PrintLog("timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue));

                SetEditValue(txtStatusType, query_attendance.status_type);
                //////////////////////////////////////

                SetEditValue_NullTag(totalWorkingHours_Text, query_attendance.working_hours);
                SetEditValue(timeEdit_GatePassTime, query_attendance.gate_pass_time);
                SetEditValue_NullTag(txtOvertimeHours, query_attendance.ot_deducton_time);

                //ControllerUtils.SelectItemByValue(comboBox_Status, "2");
                //ControllerUtils.SelectItemByValue(comboBox_Status, query_attendance.status_id + "");


                //ControllerUtils.SelectItemByValue(comboBox_Shift, query_attendance.shift_id + "");

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


                if (query_attendance.DailyWage)
                {
                    //////////////
                    CalculateDUtyHours("calculate_on_load");
                }
                else
                {
                    CalculateDUtyHours("calculate_on_load");
                }

            }
            else
            {
                form_loaded = true;

                SetEditValue(txtSerial_ID, 0);


                labelDate_Current.Text = ConvertTo.DateFormatApp(DateTime.Now);//culture                

                SetEditValue_NullTag(totalWorkingHours_Text, 0);
                SetEditValue(timeEdit_GatePassTime, 0);
                SetEditValue_NullTag(txtOvertimeHours, 0);

                if (next_date_after_save)
                {
                    CalculateDUtyHours("last_out");
                }
                else
                {
                    SetEditValue(timeEdit_Time_In_First, null);
                    SetEditValue(timeEdit_Time_Out_First, null);
                    SetEditValue(timeEdit_Time_In_Last, null);
                    SetEditValue(timeEdit_Time_Out_Last, null);

                    //SetEditValue(txtDutyHours_DW, null);
                    SetEditValue(timeEdit_Time_In_DW, null);
                    SetEditValue(timeEdit_Time_Out_DW, null);
                    SetEditValue(totalWorkingHours_Text_DW, null);
                }

                /////////////////////////
                //ControllerUtils.SelectItemByValue(comboBox_Status, "2");
                //Thread.Sleep(1000);
                //ControllerUtils.SelectItemByValue(comboBox_Status, "1");
                //ControllerUtils.SelectItemByValue(comboBox_Shift, "1");

                SetStatusByWeekdays();
                SetComboSelectedValue(comboBox_Shift, "1");


            }
            PrintLogWin.PrintLog("********************* 1 ");

            ReloadDataGrid_Parent();

            windowsUIButtonPanelMain.Enabled = true;

        }

        private void SetStatusByWeekdays()
        {
            int status_id = 1;
            DateTime today = dateAttendance.Value;

            if (IsString.IsEqualTo(today.ToString("dddd"), "Sunday"))
            {
                foreach (var item in attendanceStatu_List)
                {
                    if (IsString.IsEqualTo(item.status_code, "RR"))
                    {
                        status_id = item.status_id;
                        break;
                    }
                }

                if (next_date_after_save)
                {
                    SetComboSelectedValue_NullTag(comboBox_Status, status_id);
                }
                else
                {
                    SetComboSelectedValue_NullTag(comboBox_Status, 1);
                    Thread.Sleep(100);
                    SetComboSelectedValue_NullTag(comboBox_Status, status_id);
                }
                SetEditValue(txtStatusType, "0000");
            }
            else
            {
                if (next_date_after_save)
                {
                    //if (IsString.IsEqualTo(today.ToString("dddd"), "Monday"))
                    if (input_fields_empty)
                    {
                        SetComboSelectedValue_NullTag(comboBox_Status, "1");
                    }
                    else
                    {
                        SetComboSelectedValue(comboBox_Status, "1");
                    }
                }
                else
                {
                    SetComboSelectedValue_NullTag(comboBox_Status, "10");
                    Thread.Sleep(100);
                    SetComboSelectedValue_NullTag(comboBox_Status, "1");
                }
                SetEditValue(txtStatusType, "1111");
            }
            PrintLogWin.PrintLog("SetStatusByWeekdays => " + today);
            PrintLogWin.PrintLog("SetStatusByWeekdays => " + today.ToString("dddd"));

            //Console.WriteLine(today.ToString("dddd"));      // Outputs "Thursday"
            //Console.WriteLine(today.ToString("ddd"));       // Outputs "Thu"
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


            ProjectFunctions.TimeSpanVisualize
                (grpBoxEmployee);
            ProjectFunctions.TimeSpanVisualize(grpBoxDailyWager);



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

                    //selected_serial_id = 0;
                    //LoadAttendanceData();

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
                        ExecuteResult result = DeleteEmployeeAttendanceDetails();

                        if (result.Status == ExecuteStatus.OK)
                        {
                            _frmAttendenceLaoding.LoadAttendanceDataGrid();

                            dateAttendance.Value = dateAttendance.Value.AddDays(-1);

                        }
                    }

                    break;
                case "add_new":
                    /* Navigate to page C*/

                    //selected_serial_id = 0;
                    //LoadAttendanceData();

                    break;
                case "close":
                    /* Navigate to page E */
                    this.Close();

                    break;

            }
        }
        private ExecuteResult DeleteEmployeeAttendanceDetails()
        {
            ExecuteResult executeResult = new ExecuteResult();

            if (ConvertTo.IntVal(GetEditValue(txtSerial_ID)) != 0)
            {
                executeResult = AttendanceData.DeleteAttendance(ConvertTo.IntVal(GetEditValue(txtSerial_ID)));
            }


            if (executeResult.Status == ExecuteStatus.OK)
            {
                ProjectFunctions.SpeakError("Record has been deleted");
                //.Close();
            }
            else
            {
                PrintLogWin.PrintLog("DeleteEmployeeAttendanceDetails => " + executeResult.ExceptionMessage);
                ProjectFunctions.SpeakError("There is some problem in deleting record. Please try again.");
            }
            return executeResult;
        }


        private async Task CallAsyn_SaveEmployeeAttendanceDetails()
        {
            //var result = Task.Run(() => SaveEmployeeAttendanceDetails().Result).Result;
            //Task.Run(() => SaveEmployeeAttendanceDetails());
            await SaveEmployeeAttendanceDetails();
        }

        private async Task SaveEmployeeAttendanceDetails()
        {
            //if (selected_serial_id == 0)
            if (ConvertTo.IntVal(GetEditValue(txtSerial_ID)) == 0)
            {
                RepList<EmployeeAttendance> repList = new RepList<EmployeeAttendance>();

                DynamicParameters param = new DynamicParameters();

                string sql_chk = "SELECT* FROM EmployeeAttendance WHERE employee_code = '" + txtEmpID.Text + "' AND YEAR(attendance_date)='" + dateAttendance.Value.Year + "' AND MONTH(attendance_date)='" + dateAttendance.Value.Month + "' AND DAY(attendance_date)='" + dateAttendance.Value.Day + "'";


                PrintLogWin.PrintLog("SaveEmployeeAttendanceDetails => " + sql_chk);

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
                        SetEditValue(txtSerial_ID, existing_serial_id);

                        crudAction = CrudAction.Update;

                        //MessageBox.Show("Update 1");
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
                //MessageBox.Show("Update 2");
                await SaveEmployeeAttendanceDetails_OR_Update();
            }

        }

        private async Task SaveEmployeeAttendanceDetails_OR_Update()
        {
            bool isDebug = false;
            bool isValidate = Validate_Form();


            //MessageBox.Show(isValidate + "");

            if (isValidate && !isDebug)
            {

                //await Task.Delay(100);
                //ProjectFunctions.SpeakError("Record has been saved");

                bool isDailyWager = ConvertTo.BooleanVal(txtDailyWager.EditValue);

                //if (crudAction == CrudAction.Create)
                if (ConvertTo.IntVal(GetEditValue(txtSerial_ID)) == 0)
                {

                    //MessageBox.Show("Create");

                    EmployeeAttendance employeeAttendance = new EmployeeAttendance
                    {
                        entry_date = DateTime.Now,
                        attendance_date = dateAttendance.Value,
                        employee_code = txtEmpID.Text
                    };

                    if (isDailyWager)
                    {
                        /*
                        employeeAttendance.status_id = 1;
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.Text);
                        employeeAttendance.attendance_in_last = TimeSpan.Zero;
                        employeeAttendance.attendance_out_last = TimeSpan.Zero;
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text_DW.Text);
                        */

                        employeeAttendance.status_id = ConvertTo.IntVal(comboBox_Status.SelectedValue);
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.Text);
                        employeeAttendance.attendance_in_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.Text);
                        employeeAttendance.attendance_out_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.Text);
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text.Text);
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
                    next_date_after_save = true;
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
                //if (crudAction == CrudAction.Update)
                if (ConvertTo.IntVal(GetEditValue(txtSerial_ID)) != 0)
                {

                    string str = "sp_EmployeeAttendance_AddEdit";

                    EmployeeAttendance employeeAttendance = new EmployeeAttendance
                    {
                        attendance_date = dateAttendance.Value,
                        serial_id = ConvertTo.IntVal(GetEditValue(txtSerial_ID))
                    };

                    if (isDailyWager)
                    {
                        /*
                        employeeAttendance.status_id = 1;
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_DW.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_DW.Text);
                        employeeAttendance.attendance_in_last = TimeSpan.Zero;
                        employeeAttendance.attendance_out_last = TimeSpan.Zero;
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text_DW.Text);
                        */
                        employeeAttendance.status_id = ConvertTo.IntVal(comboBox_Status.SelectedValue);
                        employeeAttendance.attendance_in_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.Text);
                        employeeAttendance.attendance_out_first = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.Text);
                        employeeAttendance.attendance_in_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.Text);
                        employeeAttendance.attendance_out_last = ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.Text);
                        employeeAttendance.working_hours = ConvertTo.IntVal(totalWorkingHours_Text.Text);
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

                    param.Add("@serial_id", employeeAttendance.serial_id);
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
                    next_date_after_save = true;
                    dateAttendance.Value = dateAttendance.Value.AddDays(1);

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

            if (ComparisonUtils.IsEmpty(txtEmpID.Text))
            {
                //MessageBox.Show("Please select an Employee ID first");
                ProjectFunctionsUtils.SpeakError("Please Enter an Employee ID first");
                txtEmpID.Focus();

                PrintLogWin.PrintLog("+++++++++++++ A");
                return false;
            }

            bool disableDailyWagerCode = true;

            //if (ConvertTo.BooleanVal(txtDailyWager.EditValue))
            if (!disableDailyWagerCode)
            {
                PrintLogWin.PrintLog("+++++++++++++ B");
                if (ComparisonUtils.IsEmpty(timeEdit_Time_In_DW.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_DW.EditValue))
                {
                    ProjectFunctionsUtils.SpeakError("Please Enter Time In and Time Out");
                    timeEdit_Time_In_DW.Focus();

                    PrintLogWin.PrintLog("+++++++++++++ C");

                    return false;
                }
            }
            else
            {
                if (IsString.IsEqualTo(txtStatusType.EditValue, "1111"))
                {
                    PrintLogWin.PrintLog("+++++++++++++ D");

                    if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0)
                    {
                        if (ComparisonUtils.IsEmpty(timeEdit_Time_In_First.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_Last.EditValue))
                        {
                            ProjectFunctionsUtils.SpeakError("Please Enter Time In and Time Out Inputs");
                            timeEdit_Time_In_First.Focus();

                            PrintLogWin.PrintLog("+++++++++++++ E");

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

                            PrintLogWin.PrintLog("+++++++++++++ F");

                            return false;
                        }
                    }

                }

                if (IsString.IsEqualTo(txtStatusType.EditValue, "1100"))
                {
                    PrintLogWin.PrintLog("+++++++++++++ G");

                    if (ComparisonUtils.IsEmpty(timeEdit_Time_In_First.EditValue) ||
                        ComparisonUtils.IsEmpty(timeEdit_Time_Out_First.EditValue))
                    {
                        //timeEdit_Time_In_Last.EditValue = null;
                        //timeEdit_Time_Out_Last.EditValue = null;
                        SetEditValue(timeEdit_Time_In_Last, null);
                        SetEditValue(timeEdit_Time_Out_Last, null);
                        ProjectFunctionsUtils.SpeakError("Please Enter Time In First and Time Out First");
                        timeEdit_Time_In_First.Focus();

                        PrintLogWin.PrintLog("+++++++++++++ H");

                        return false;
                    }
                }
                if (IsString.IsEqualTo(txtStatusType.EditValue, "0011"))
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

                        PrintLogWin.PrintLog("+++++++++++++ I");

                        return false;
                    }
                }

                //////////////////////////////////////////////
                //////////////////////////////////////////////
                ///

                PrintLogWin.PrintLog("/////////////////////////////////////////");

                PrintLogWin.PrintLog("Validate_Form() => timeEdit_Time_In_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue));
                PrintLogWin.PrintLog("Validate_Form() => timeEdit_Time_Out_First : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue));
                PrintLogWin.PrintLog("Validate_Form() => timeEdit_Time_In_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue));
                PrintLogWin.PrintLog("Validate_Form() => timeEdit_Time_Out_Last : " + ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue));

                PrintLogWin.PrintLog("/////////////////////////////////////////");
                PrintLogWin.PrintLog("1 => " + TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_In_Last.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_Out_First.EditValue)));
                PrintLogWin.PrintLog("2 => " + TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_In_Last.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_Out_Last.EditValue)));
                PrintLogWin.PrintLog("3 => " + TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_Out_First.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_In_Last.EditValue)));


                if (ComparisonUtils.IsNotEmpty(timeEdit_Time_In_First.EditValue) &&
                        ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_First.EditValue))
                {
                    PrintLogWin.PrintLog("A-1-1");
                    if (TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_In_First.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_Out_First.EditValue)) > -1)
                    {
                        PrintLogWin.PrintLog("A-1-2");

                        ProjectFunctionsUtils.SpeakError("Time Out First should be greater than Time In First");

                        timeEdit_Time_Out_First.Focus();
                        return false;
                    }
                }

                if (ComparisonUtils.IsNotEmpty(timeEdit_Time_In_Last.EditValue) &&
                        ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_Last.EditValue))
                {
                    PrintLogWin.PrintLog("b-1-1");
                    if (TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_In_Last.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_Out_Last.EditValue)) > -1)
                    {
                        PrintLogWin.PrintLog("b-1-2");

                        ProjectFunctionsUtils.SpeakError("Time Out Last should be greater than Time In Last");

                        timeEdit_Time_Out_Last.Focus();
                        return false;
                    }
                }

                if (ComparisonUtils.IsNotEmpty(timeEdit_Time_In_First.EditValue) &&
                        ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_First.EditValue) &&
                        ComparisonUtils.IsNotEmpty(timeEdit_Time_In_Last.EditValue) &&
                        ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_Last.EditValue))
                {
                    PrintLogWin.PrintLog("c-1-1");
                    if (TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_Out_First.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_In_Last.EditValue)) == 1)

                    {
                        PrintLogWin.PrintLog("c-1-2");
                        ProjectFunctionsUtils.SpeakError("Time In Last should be greater than Time Out First");

                        timeEdit_Time_In_Last.Focus();
                        return false;
                    }
                }
                /*
                  if (ComparisonUtils.IsNotEmpty(timeEdit_Time_In_First.EditValue) &&
                          ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_First.EditValue) &&
                          ComparisonUtils.IsNotEmpty(timeEdit_Time_In_Last.EditValue) &&
                          ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_Last.EditValue))
                  {
                      if (TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_Out_First.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_Out_First_Main.EditValue)) == 1)
                      {
                          ProjectFunctionsUtils.SpeakError("Time Out First should be less than " + GetEditValue(timeEdit_Time_Out_First_Main) + "");

                          timeEdit_Time_Out_First.Focus();
                          return false;
                      }

                      if (TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_In_Last.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_In_Last_Main.EditValue)) == -1)
                      {
                          ProjectFunctionsUtils.SpeakError("Time In Last should be greater than " + GetEditValue(timeEdit_Time_In_Last_Main) + "");

                          timeEdit_Time_In_Last.Focus();
                          return false;
                      }
                  }

                  if (ComparisonUtils.IsNotEmpty(timeEdit_Time_In_First.EditValue) && ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_First.EditValue) &&
                          (ComparisonUtils.IsEmpty(timeEdit_Time_In_Last.EditValue) || ComparisonUtils.IsEmpty(timeEdit_Time_Out_Last.EditValue)))
                  {
                      if (TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_Out_First.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_Out_First_Main.EditValue)) == 1)
                      {
                          ProjectFunctionsUtils.SpeakError("Time Out First should be less than " + GetEditValue(timeEdit_Time_Out_First_Main) + "");

                          timeEdit_Time_Out_First.Focus();
                          return false;
                      }

                  }

                  if ((ComparisonUtils.IsEmpty(timeEdit_Time_In_First.EditValue) || ComparisonUtils.IsEmpty(timeEdit_Time_Out_First.EditValue)) &&
                          (ComparisonUtils.IsNotEmpty(timeEdit_Time_In_Last.EditValue) && ComparisonUtils.IsNotEmpty(timeEdit_Time_Out_Last.EditValue)))
                  {
                      if (TimeSpan.Compare(ConvertTo.TimeSpanVal(timeEdit_Time_In_Last.EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_In_Last_Main.EditValue)) == -1)
                      {
                          ProjectFunctionsUtils.SpeakError("Time In Last should be greater than " + GetEditValue(timeEdit_Time_In_Last_Main) + "");

                          timeEdit_Time_In_Last.Focus();
                          return false;
                      }
                  }
                */
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
                        SetEditValue_NullTag(txtOvertimeHours, 0);

                        PrintLogWin.PrintLog("========= txtOvertimeHours A : " + txtOvertimeHours.EditValue);
                    }
                    else
                    {
                        if (totalHrs_First > 0)
                        {

                            //txtOvertimeHours.EditValue = ConvertTo.IntVal(totalWorkingHours_Text_DW.EditValue) - ConvertTo.IntVal(txtDutyHours_DW.EditValue);
                            SetEditValue_NullTag(txtOvertimeHours, ConvertTo.IntVal(totalWorkingHours_Text_DW.EditValue) - ConvertTo.IntVal(txtDutyHours_DW.EditValue));

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
        private void CalculateDUtyHours(string entry)
        {

            PrintLogWin.PrintLog("************* CalculateDUtyHours => entry : " + entry);


            try
            {
                string firstChar = "";
                string clearStr = "";
                if (ComparisonUtils.IsNotEmpty(GetEditValue(txtStatusType)))
                {
                    firstChar = GetEditValue(txtStatusType).ToString().Substring(0, 1);

                    clearStr = GetEditValue(txtStatusType).ToString().Replace("-", "").Replace("+", "");
                }

                PrintLogWin.PrintLog("************* form_loaded => " + form_loaded + "");



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
                    PrintLogWin.PrintLog("%%%%%%%%%%%%%%%% totalHrs_FullDay => A : " + totalHrs_FullDay);
                    /*
                    if (ConvertTo.BooleanVal(GetEditValue(txtDailyWager)))
                    {
                        PrintLogWin.PrintLog("%%%%%%%%%%%%%%%% totalHrs_FullDay => B");
                        if (totalHrs_First > 0 && totalHrs_Last > 0)
                        {
                            
                            DateTime dateTime_In_First_DailyWager = ConvertTo.TimeToDate(timeEdit_Time_In_First.Text + "");
                            DateTime dateTime_Out_Last_DailyWager = ConvertTo.TimeToDate(timeEdit_Time_Out_Last.Text + "");

                            totalHrs_FullDay = (dateTime_Out_Last_DailyWager - dateTime_In_First_DailyWager).TotalMinutes;

                            PrintLogWin.PrintLog("%%%%%%%%%%%%%%%% totalHrs_FullDay => C : " + totalHrs_FullDay);
                        }
                    }
                    */
                    PrintLogWin.PrintLog("%%%%%%%%%%%%%%%% totalHrs_FullDay => D");

                    PrintLogWin.PrintLog("========= D-1 : clearStr : " + clearStr);
                    PrintLogWin.PrintLog("========= D-2 : totalHrs_FullDay : " + totalHrs_FullDay);

                    if (IsString.IsEqualTo(clearStr, "0000"))
                    {
                        SetEditValue_NullTag(totalWorkingHours_Text, 0);
                    }
                    else
                    {
                        PrintLogWin.PrintLog("========= D-3 : clearStr : " + clearStr);
                        //////////////////////////////////////////////
                        /////////////////////////////////////////////////
                        double lunch_no_tea_no_add_minutes = 60;
                        double lunch_no_tea_yes_add_minutes = ConvertTo.DoubleVal(txtTeaBreakTime.EditValue);
                        double lunch_yes_tea_no_add_minutes = 30;
                        //  double lunch_yes_tea_no_add_minutes = 30;
                        ///////////////////////////////
                        /***DAILY WAGER ALSO CHECK***************************/
                        ///////////////////////////////
                        if (totalHrs_First > 0 && totalHrs_Last > 0)// && !ConvertTo.BooleanVal(GetEditValue(txtDailyWager))
                        {
                            PrintLogWin.PrintLog("========= D-4");

                            if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0 && ConvertTo.IntVal(txtTeaBreakTime.EditValue) == 0)
                            {
                                totalHrs_FullDay = totalHrs_FullDay + lunch_no_tea_no_add_minutes;
                                PrintLogWin.PrintLog("========= D-5");
                            }

                            if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0 && ConvertTo.IntVal(txtTeaBreakTime.EditValue) > 0)
                            {
                                totalHrs_FullDay = totalHrs_FullDay + lunch_no_tea_yes_add_minutes;
                                PrintLogWin.PrintLog("========= D-6");
                            }

                            if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 1 && ConvertTo.IntVal(txtTeaBreakTime.EditValue) == 0)
                            {
                                totalHrs_FullDay = totalHrs_FullDay + lunch_yes_tea_no_add_minutes;
                                PrintLogWin.PrintLog("========= D-7");
                            }
                        }
                        //////////////////////////////////////////////
                        /////////////////////////////////////////////////
                        PrintLogWin.PrintLog("========= D-8 : totalHrs_FullDay : " + totalHrs_FullDay);
                        //totalWorkingHours_Text.Text = (totalHrs_FullDay).ToString();
                        SetEditValue_NullTag(totalWorkingHours_Text, totalHrs_FullDay);
                    }

                    PrintLogWin.PrintLog("========= totalHrs_First : " + totalHrs_First);
                    PrintLogWin.PrintLog("========= totalHrs_Last : " + totalHrs_Last);

                    if (ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_First.EditValue) == null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_First.EditValue) == null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_In_Last.EditValue) == null &&
                        ConvertTo.TimeSpanVal_Null(timeEdit_Time_Out_Last.EditValue) == null)
                    {
                        //txtOvertimeHours.EditValue = 0;
                        SetEditValue_NullTag(txtOvertimeHours, 0);

                        PrintLogWin.PrintLog("========= txtOvertimeHours A : " + txtOvertimeHours.EditValue);
                    }
                    else
                    {
                        if (totalHrs_First > 0 || totalHrs_Last > 0)
                        {
                            //DateTime dateTime_In_Last_GP = ConvertTo.TimeToDate(timeEdit_Time_In_Last.Text + "");
                            //DateTime dateTime_Out_GP = ConvertTo.TimeToDate(timeEdit_Time_Out_First.Text + "");

                            //timeEdit_GatePassTime.EditValue = (dateTime_In_Last_GP - dateTime_Out_GP).TotalHours;

                            //txtOvertimeHours.EditValue = ConvertTo.IntVal(totalWorkingHours_Text.EditValue) - (ConvertTo.IntVal(totalWorkingHours_Text_Main.EditValue) * 60);

                            PrintLogWin.PrintLog("========= DDDD-4 => " + comboBox_Status.SelectedValue);

                            if (IsString.IsEqualTo(clearStr, "0000"))
                            {
                                SetEditValue_NullTag(txtOvertimeHours, totalHrs_FullDay);
                            }
                            else
                            {
                                //DAILY WAGER
                                if (ConvertTo.BooleanVal(GetEditValue(txtDailyWager)))
                                {

                                }
                                else
                                {

                                }
                                SetEditValue_NullTag(txtOvertimeHours, ConvertTo.IntVal(totalWorkingHours_Text.EditValue) - (ConvertTo.IntVal(totalWorkingHours_Text_Main.EditValue) * 60));
                            }

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

        //private void comboBox_Status_DropDownClosed(object sender, EventArgs e)
        //{

        //}
        private void Reset_comboBox_Status(string action_on)
        {
            if (action_on.Equals("BackColor"))
            {
                timeEdit_Time_In_First.BackColor = Color.FromArgb(255, 255, 192);
                timeEdit_Time_Out_First.BackColor = Color.FromArgb(255, 255, 192);
                timeEdit_Time_In_Last.BackColor = Color.FromArgb(255, 255, 192);
                timeEdit_Time_Out_Last.BackColor = Color.FromArgb(255, 255, 192);
            }
            if (action_on.Equals("Enabled"))
            {
                timeEdit_Time_In_First.Enabled = true;
                timeEdit_Time_Out_First.Enabled = true;
                timeEdit_Time_In_Last.Enabled = true;
                timeEdit_Time_Out_Last.Enabled = true;
            }
        }

        private void comboBox_Status_SelectedValueChanged(object sender, EventArgs e)
        {
            PrintLogWin.PrintLog("--------------- comboBox_Status : " + comboBox_Status.SelectedValue);

            Reset_comboBox_Status("BackColor");
            Reset_comboBox_Status("Enabled");

            if ((sender as System.Windows.Forms.ComboBox).Tag == null)
            {
                SetEditValue_NullTag(totalWorkingHours_Text, null);
                SetEditValue_NullTag(txtOvertimeHours, null);
                SetEditValue(timeEdit_GatePassTime, null);

                timeEdit_Time_Out_First.Enabled = true;
                timeEdit_Time_In_Last.Enabled = true;

                string status_type = "";
                string status_code = "";
                foreach (AttendanceStatu item in attendanceStatu_List)
                {
                    if (item.status_id == ConvertTo.IntVal(comboBox_Status.SelectedValue))
                    {
                        status_type = item.status_type;
                        status_code = item.status_code;
                        break;
                    }
                }

                PrintLogWin.PrintLog("--------------- comboBox_Status => status_code : " + status_code);

                if (!status_type.Equals(""))
                {
                    string firstChar = status_type.Substring(0, 1);
                    string clearStr = status_type.Replace("-", "").Replace("+", "");

                    SetEditValue(txtStatusType, status_type);

                    PrintLogWin.PrintLog("--------------- status_code : " + status_code);


                    if (IsString.IsEqualTo(clearStr, "0000"))
                    {
                        if (status_code.Equals("RR") || status_code.Equals("RR", StringComparison.InvariantCultureIgnoreCase))
                        {

                            if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0)
                            {
                                timeEdit_Time_In_First.Enabled = true;
                                timeEdit_Time_Out_First.Enabled = false;
                                timeEdit_Time_In_Last.Enabled = false;
                                timeEdit_Time_Out_Last.Enabled = true;

                                timeEdit_Time_In_First.BackColor = Color.FromArgb(255, 255, 192);
                                timeEdit_Time_Out_First.BackColor = Color.FromArgb(232, 232, 232);
                                timeEdit_Time_In_Last.BackColor = Color.FromArgb(232, 232, 232);
                                timeEdit_Time_Out_Last.BackColor = Color.FromArgb(255, 255, 192);
                            }
                            else
                            {
                                timeEdit_Time_In_First.Enabled = true;
                                timeEdit_Time_Out_First.Enabled = true;
                                timeEdit_Time_In_Last.Enabled = false;
                                timeEdit_Time_Out_Last.Enabled = false;

                                timeEdit_Time_In_First.BackColor = Color.FromArgb(255, 255, 192);
                                timeEdit_Time_Out_First.BackColor = Color.FromArgb(255, 255, 192);
                                timeEdit_Time_In_Last.BackColor = Color.FromArgb(232, 232, 232);
                                timeEdit_Time_Out_Last.BackColor = Color.FromArgb(232, 232, 232);
                            }
                        }
                        else
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
                        }

                        SetEditValue(timeEdit_Time_In_First, null);
                        SetEditValue(timeEdit_Time_Out_First, null);
                        SetEditValue(timeEdit_Time_In_Last, null);
                        SetEditValue(timeEdit_Time_Out_Last, null);
                        PrintLogWin.PrintLog("--------------- A " + clearStr);

                        CalculateDUtyHours("comboBox_Status_SelectedValueChanged => 0000");

                        input_fields_empty = true;
                    }
                    if (IsString.IsEqualTo(clearStr, "1100"))
                    {
                        SetEditValue(timeEdit_Time_In_First, timeEdit_Time_In_First_Main.EditValue);
                        SetEditValue(timeEdit_Time_Out_First, timeEdit_Time_Out_First_Main.EditValue);
                        SetEditValue(timeEdit_Time_In_Last, null);
                        SetEditValue(timeEdit_Time_Out_Last, null);

                        timeEdit_Time_In_First.Enabled = true;
                        timeEdit_Time_Out_First.Enabled = true;

                        timeEdit_Time_In_Last.Enabled = false;
                        timeEdit_Time_Out_Last.Enabled = false;

                        PrintLogWin.PrintLog("--------------- B " + clearStr);

                        CalculateDUtyHours("comboBox_Status_SelectedValueChanged => 1100");

                        input_fields_empty = false;
                    }
                    if (IsString.IsEqualTo(clearStr, "0011"))
                    {
                        SetEditValue(timeEdit_Time_In_First, null);
                        SetEditValue(timeEdit_Time_Out_First, null);
                        SetEditValue(timeEdit_Time_In_Last, timeEdit_Time_In_Last_Main.EditValue);
                        SetEditValue(timeEdit_Time_Out_Last, timeEdit_Time_Out_Last_Main.EditValue);

                        timeEdit_Time_In_First.Enabled = false;
                        timeEdit_Time_Out_First.Enabled = false;

                        timeEdit_Time_In_Last.Enabled = true;
                        timeEdit_Time_Out_Last.Enabled = true;

                        PrintLogWin.PrintLog("--------------- C " + clearStr);

                        CalculateDUtyHours("comboBox_Status_SelectedValueChanged => 0011");

                        input_fields_empty = false;
                    }
                    if (IsString.IsEqualTo(clearStr, "1111"))
                    {
                        if (ConvertTo.IntVal(txtLunchBreak.EditValue) == 0)
                        {
                            timeEdit_Time_In_First.Enabled = true;

                            timeEdit_Time_Out_First.Enabled = false;
                            timeEdit_Time_In_Last.Enabled = false;

                            timeEdit_Time_Out_Last.Enabled = true;
                        }
                        else
                        {
                            timeEdit_Time_In_First.Enabled = true;
                            timeEdit_Time_Out_First.Enabled = true;
                            timeEdit_Time_In_Last.Enabled = true;
                            timeEdit_Time_Out_Last.Enabled = true;
                        }

                        SetEditValue(timeEdit_Time_In_First, timeEdit_Time_In_First_Main.EditValue);
                        SetEditValue(timeEdit_Time_Out_First, timeEdit_Time_Out_First_Main.EditValue);
                        SetEditValue(timeEdit_Time_In_Last, timeEdit_Time_In_Last_Main.EditValue);
                        SetEditValue(timeEdit_Time_Out_Last, timeEdit_Time_Out_Last_Main.EditValue);

                        PrintLogWin.PrintLog("--------------- D " + clearStr);

                        CalculateDUtyHours("comboBox_Status_SelectedValueChanged => 1111");

                        input_fields_empty = false;
                    }

                }
                else
                {


                    txtStatusType.EditValue = null;

                    PrintLogWin.PrintLog("--------------- E");

                    CalculateDUtyHours("comboBox_Status_SelectedValueChanged => txtStatusType = null");

                    input_fields_empty = false;
                }
            }

        }

        private void txtLunchBreak_EditValueChanged(object sender, EventArgs e)
        {
            string clearStr = "";
            if (GetEditValue(txtStatusType) != null)
            {
                clearStr = GetEditValue(txtStatusType).ToString().Replace("-", "").Replace("+", "");
            }

            PrintLogWin.PrintLog("========= txtLunchBreak_EditValueChanged => clearStr : " + clearStr);

            if (IsString.IsEqualTo(clearStr, "1111"))
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

                    PrintLogWin.PrintLog("========= txtLunchBreak_EditValueChanged => txtLunchBreak : A");
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

                PrintLogWin.PrintLog("========= txtLunchBreak_EditValueChanged => txtLunchBreak : B");
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

        private void dateAttendance_Leave(object sender, EventArgs e)
        {

        }

        private void dateAttendance_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = dateAttendance.Value;
            lblDayName.Text = today.ToString("dddd");

            txtEmpCode_EditValueChanged(txtEmpID, EventArgs.Empty);
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

        private void totalWorkingHours_Text_DW_EditValueChanged(object sender, EventArgs e)
        {
            totalWorkingHours_Label_DW.Text = ConvertTo.MinutesToHours(totalWorkingHours_Text_DW.EditValue);
        }

        private void txtDutyHours_DW_EditValueChanged(object sender, EventArgs e)
        {
            txtDutyHours_Label_DW.Text = ConvertTo.MinutesToHours(txtDutyHours_DW.EditValue);
        }

        private void txtTeaBreakTime_EditValueChanged(object sender, EventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                CalculateDUtyHours("edit_tea_time");
            }
        }

        private void timeEdit_Time_Out_First_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as BaseEdit).Tag == null)
            {
                //PrintLogWin.PrintLog("timeEdit_Time_Out_First_Validating => A => " + (sender as TimeEdit).EditValue);
                //if (TimeSpan.Compare(ConvertTo.TimeSpanVal((sender as TimeEdit).EditValue), ConvertTo.TimeSpanVal(timeEdit_Time_Out_First_Main.EditValue)) == 1)
                //{
                //    e.Cancel = true;
                //}
                //PrintLogWin.PrintLog("timeEdit_Time_Out_First_Validating => B => " + (sender as TimeEdit).EditValue);
            }
        }


        private void timeEdit_Time_Out_First_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            //e.ErrorText = "The value should be greater than Time Out First Main";
            //if ((sender as BaseEdit).Tag == null)
            //{

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