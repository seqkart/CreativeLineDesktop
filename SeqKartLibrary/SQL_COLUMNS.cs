namespace SeqKartLibrary
{
    public class SQL_COLUMNS
    {
        public static class COMCONF
        {
            public const string _COMADD = "COMADD";
            public const string _COMADD1 = "COMADD1";
            public const string _COMADD2 = "COMADD2";
            public const string _COMGST = "COMGST";
            public const string _COMNAME = "COMNAME";
            public const string _COMPHONE = "COMPHONE";
            public const string _COMEID = "COMEID";
            public const string _COMZIP = "COMZIP";
            public const string _COMWEBSITE = "COMWEBSITE";
            public const string _COMSYSID = "COMSYSID";
        }

        public static class FN_YEAR
        {
            public const string _FNYearCode = "FNYearCode";
            public const string _FNStartDate = "FNStartDate";
            public const string _FNEndDate = "FNEndDate";
        }

        public static class UNITS
        {
            public const string _UNITID = "UNITID";
            public const string _UNITNAME = "UNITNAME";

        }

        public static class USER_MASTER
        {
            public const string _UserName = "UserName";
            public const string _LoginAs = "Login_As";
            public const string _UserActive = "UserActive";

        }

        public static class _AttendanceStatus
        {
            public const string _status_id = "status_id";
            public const string _status = "status";
            public const string _status_type = "status_type";

        }

        public static class _DailyShifts
        {
            public const string _shift_id = "shift_id";
            public const string _shift_name = "shift_name";
        }

        public static class _EmployeeAttendance
        {
            public const string _serial_id = "serial_id";
            public const string _entry_date = "entry_date";
            public const string _employee_code = "employee_code";
            public const string _attendance_date = "attendance_date";
            public const string _attendance_in = "attendance_in";
            public const string _eattendance_out = "attendance_out";
            public const string _gate_pass_time = "gate_pass_time";
            public const string _ot_deducton_time = "ot_deducton_time";
        }

        public static class _AttendanceSource
        {
            public const string _source_name = "source_name";
        }


    }

    public class Col
    {
        public static class AttendanceStatus
        {
            public const string status_id = "status_id";
            public const string status = "status";

        }

        public static class DailyShifts
        {
            public const string shift_id = "shift_id";
            public const string shift_name = "shift_name";
        }

        public static class EmployeeAttendance
        {
            public const string serial_id = "serial_id";
            public const string entry_date = "entry_date";
            public const string employee_code = "employee_code";
            public const string attendance_date = "attendance_date";
            public const string attendance_in_first = "attendance_in_first";
            public const string attendance_out_first = "attendance_out_first";
            public const string attendance_in_last = "attendance_in_last";
            public const string attendance_out_last = "attendance_out_last";
            public const string working_hours = "working_hours";
            public const string working_hours_1 = "working_hours_1";
            public const string gate_pass_time = "gate_pass_time";
            public const string gate_pass_time_1 = "gate_pass_time_1";
            public const string ot_deducton_time = "ot_deducton_time";
            public const string ot_deducton_time_1 = "ot_deducton_time_1";
        }

        public static class AttendanceSource
        {
            public const string source_name = "source_name";
        }

        public static class GridStyle
        {
            public const string Row_Style = "Row_Style";
        }
    }
}
