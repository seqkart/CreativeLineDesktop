using Dapper;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public static List<EmployeeAttendance_Get_Model> EmployeeAttendance_Get(string sp_query, DynamicParameters param)
        {
            RepList<EmployeeAttendance_Get_Model> repList = new RepList<EmployeeAttendance_Get_Model>();
            List<EmployeeAttendance_Get_Model> empAttendanceModels = repList.returnListClass_SP(sp_query, param);

            return empAttendanceModels;
        }

        public static List<EmployeeMasterModel> GetEmployeeMasterDataList(string sp_query, DynamicParameters param)
        {
            RepList<EmployeeMasterModel> repList = new RepList<EmployeeMasterModel>();
            List<EmployeeMasterModel> employeeMaster_List = repList.returnListClass_SP(sp_query, param);

            return employeeMaster_List;
        }

        public static async Task<List<EmployeeMasterModel>> GetEmployeeMasterDataList_Async(string sp_query, DynamicParameters param)
        {
            RepList<EmployeeMasterModel> repList = new RepList<EmployeeMasterModel>();
            List<EmployeeMasterModel> employeeMaster_List = await repList.returnListClass_SP_Async(sp_query, param);

            return employeeMaster_List;
        }


        //public static bool IsSalaryLocked(string sql_query, DynamicParameters param)
        //{
        //    RepList<EmployeeSalary> repList = new RepList<EmployeeSalary>();
        //    EmployeeSalary employeeSalary = repList.returnClass_SP(sql_query, param);

        //    return employeeSalary;
        //}
    }
}