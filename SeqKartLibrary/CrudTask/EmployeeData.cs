using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;

namespace SeqKartLibrary.CrudTask
{
    public class EmployeeData
    {
        public async Task<string> insertUpdate(EmployeeItem _employee)
        {
            RepGen reposGen = new Repository.RepGen();
            DynamicParameters param = new DynamicParameters();
            //param.Add("@id", _user.id);
            //param.Add("@name", _user.name);
            //param.Add("@address", _user.address);
            //param.Add("@status", _user.status);
            return await reposGen.executeNonQuery_Async("users_Insert_Update", param);
        }

        public static EmployeeSalary GetEmployeeSalary(string sp_query, DynamicParameters param)
        {
            RepList<EmployeeSalary> repList = new RepList<EmployeeSalary>();
            EmployeeSalary employeeSalary = repList.returnClass_SP(sp_query, param);

            return employeeSalary;
        }

        public static List<EmployeeSalary> GetEmployeesSalaryList(string sp_query, DynamicParameters param)
        {
            RepList<EmployeeSalary> repList = new RepList<EmployeeSalary>();
            List<EmployeeSalary> employeeSalaryList = repList.returnListClass_SP(sp_query, param);

            return employeeSalaryList;
        }

        public static List<EmpAttendanceModel> GetEmpAttendanceList(string sp_query, DynamicParameters param)
        {
            RepList<EmpAttendanceModel> repList = new RepList<EmpAttendanceModel>();
            List<EmpAttendanceModel> empAttendanceModels = repList.returnListClass_SP(sp_query, param);

            return empAttendanceModels;
        }
    }
}