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
            return await reposGen.executeNonQuery("users_Insert_Update", param);
        }
    }
}