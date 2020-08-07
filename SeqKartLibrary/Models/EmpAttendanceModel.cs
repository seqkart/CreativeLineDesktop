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
}