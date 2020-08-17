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
    public class ChallanData
    {
        public static object GetScalarValue(string sql_query, DynamicParameters param)
        {
            RepList<object> repList = new RepList<object>();
            object returnScalar = repList.returnScalar(sql_query, param);

            return returnScalar;
        }
    }

}