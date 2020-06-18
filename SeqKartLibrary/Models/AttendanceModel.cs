using System;

public class AttendanceModel
{
    public int serial_id { get; set; }
    public DateTime entry_date { get; set; }
    public DateTime attendance_date { get; set; }
    public string employee_code { get; set; }
    public int status_id { get; set; }
    public DateTime attendance_in { get; set; }
    public DateTime attendance_out { get; set; }
    public int shift_id { get; set; }
    public int attendance_source { get; set; }
    public DateTime gate_pass_time { get; set; }
    public int ot_deducton_time { get; set; }
    public int over_time { get; set; }
}