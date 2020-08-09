using System;
using System.Collections.Generic;

namespace SeqKartLibrary.Models
{
    public class EmployeeAttendanceDetails_Model
    {
        public DateTime AttendanceMonth { get; set; }
        public string CompanyName { get; set; }
        public List<EmpAttendanceModel> EmpAttendanceList { get; set; }
        public EmployeeSalary EmployeeMonthlySalaryDetails { get; set; }
    }
}