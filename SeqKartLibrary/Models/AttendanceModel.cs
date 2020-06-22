using System;

public class AttendanceModel
{
    public int serial_id { get; set; }
    public Nullable<System.DateTime> entry_date { get; set; }
    public Nullable<System.DateTime> attendance_date { get; set; }
    public string employee_code { get; set; }
    //public Nullable<int> status_id { get; set; }
    public string status { get; set; }
    public string attendance_in { get; set; }
    public string attendance_out { get; set; }
    public string shift_name { get; set; }
    public string source_name { get; set; }
    //public Nullable<int> shift_id { get; set; }
    //public Nullable<int> attendance_source { get; set; }
    public string gate_pass_time { get; set; }
    public Nullable<int> ot_deducton_time { get; set; }
    //public int over_time { get; set; }
}