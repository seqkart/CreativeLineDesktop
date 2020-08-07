using System;
using System.Collections.Generic;

namespace SeqKartLibrary.Models
{
    public class MonthlySalaryDetails_Model
    {
        public DateTime SalaryMonth { get; set; }
        public string CompanyName { get; set; }
        public List<EmployeeSalary> EmployeesSalaryList { get; set; }
    }
}