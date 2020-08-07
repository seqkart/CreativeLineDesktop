using System;

namespace SeqKartLibrary.Models
{
    public class EmployeeSalary
    {
        public string EmpCategory { get; set; }
        public string EmpDepartment { get; set; }
        public DateTime SalaryMonth { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public int WorkingDays { get; set; }
        public int WorkingHours { get; set; }
        public double EmpSalary { get; set; }
        public double SalaryPerDay { get; set; }
        public double SalaryPerHour { get; set; }
        public int AttendanceDays { get; set; }
        public int EmployeeLeaves { get; set; }
        public int OT_Time { get; set; }
        public double OT_Salary { get; set; }
        public int DeductionTime { get; set; }
        public double DeductionSalary { get; set; }
        public double SalaryGenerationBasic { get; set; }
        public double AdvanceSalary { get; set; }
        public double Loan { get; set; }
        public double SalaryCalculated { get; set; }
        public double SalaryPaid { get; set; }
        public double Arrears { get; set; }
        public int SalaryLocked { get; set; }      


    }
}