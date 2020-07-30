using System;

public class ThresholdReachedEventArgs : EventArgs
{
    public string EmpCode { get; set; }
    public DateTime AttendanceDate { get; set; }
}