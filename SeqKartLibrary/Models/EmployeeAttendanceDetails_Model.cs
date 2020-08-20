using System;
using System.Collections.Generic;

namespace SeqKartLibrary.Models
{
    public class EmployeeAttendanceDetails_Model
    {
        public DateTime AttendanceMonth { get; set; }
        public string EmpCode { get; set; }
        public string CompanyName { get; set; }

        public List<EmployeeMasterModel> EmployeeMasterDataList { get; set; }

        public List<EmployeeAttendance_Get_Model> EmployeeAttendance_Get_List { get; set; }


        public List<EmployeeSalary> EmployeesSalaryList { get; set; }
    }
}