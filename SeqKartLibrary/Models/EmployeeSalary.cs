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
        public double SalaryEarned { get; set; }
        public string OT_Time { get; set; }

        public int OT_Time_1 { get; set; }
        public double OT_Salary { get; set; }
        public string DeductionTime { get; set; }

        public int DeductionTime_1 { get; set; }
        public double DeductionSalary { get; set; }
        public double SalaryGenerateBasic { get; set; }
        public double AdvanceSalary { get; set; }
        public double Loan { get; set; }
        public double SalaryCalculated { get; set; }
        public double SalaryPaid { get; set; }
        public double Arrears { get; set; }
        public double Balance { get; set; }
        public int SalaryLocked { get; set; }
        public string CatgCode { get; set; }
        public string CatgDesc { get; set; }
        public string DeptCode { get; set; }
        public string DeptDesc { get; set; }


    }
}