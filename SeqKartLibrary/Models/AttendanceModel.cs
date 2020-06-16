using System;

public class AttendanceModel
{
    public int serial_id { get; set; }
    public DateTime entry_date { get; set; }
    public DateTime attendance_date { get; set; }
    public string employee_code { get; set; }
    public string attendance_status { get; set; }
    public DateTime attendance_in { get; set; }
    public DateTime attendance_out { get; set; }
    public string duty_shift { get; set; }
    public int attendance_source { get; set; }
    public DateTime gate_pass_time { get; set; }
    public int deducton_time { get; set; }
    public int night_duty_hours { get; set; }
}