using System;

namespace SeqKartLibrary.Models
{
    public class EmpAttendanceModel
    {
        public string EmpCategory { get; set; }
        public string EmpDepartment { get; set; }
        public int SerialId { get; set; }
        public string AttendanceDate { get; set; }
        public string EmployeeCode { get; set; }
        public int Status { get; set; }
        public int TimeIn_First { get; set; }
        public double TimeOut_First { get; set; }
        public double TimeIn_Last { get; set; }
        public double TimeOut_Last { get; set; }
        public int WorkingHours { get; set; }
        public int OverTime { get; set; }
        public int GatePassTime { get; set; }
        public double Source { get; set; }


    }

    public class EmployeeAttendance_Get_Model
    {
        public int serial_id { get; set; }
        public DateTime entry_date { get; set; }
        public string shift_name { get; set; }
        public string status { get; set; }
        public string employee_code { get; set; }
        public DateTime attendance_date { get; set; }
        public TimeSpan attendance_in_first { get; set; }
        public TimeSpan attendance_out_first { get; set; }
        public TimeSpan attendance_in_last { get; set; }
        public TimeSpan attendance_out_last { get; set; }
        public string working_hours { get; set; }
        public int working_hours_1 { get; set; }
        public string source_name { get; set; }
        public string gate_pass_time { get; set; }
        public int gate_pass_time_1 { get; set; }
        public string ot_deducton_time { get; set; }
        public int ot_deducton_time_1 { get; set; }
        public string Row_Style { get; set; }


    }
}