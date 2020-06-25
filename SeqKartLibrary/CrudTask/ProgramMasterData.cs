using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using SeqKartLibrary.Models;
using SeqKartLibrary.Repository;

namespace SeqKartLibrary.CrudTask
{
    public class ProgramMasterData
    {
        public static ProgramMasterModel GetProgramMasterModel(string _ProgCode)
        {
            RepList<ProgramMasterModel> repObj = new RepList<ProgramMasterModel>();

            DynamicParameters param = new DynamicParameters();
            param.Add("@ProgCode", _ProgCode);
            ProgramMasterModel programMaster = repObj.returnClass_SP("sp_ProgramMaster", param);

            return programMaster;

        }

        //public static List<T> GetData<T>(string _ProgCode)
        //{
        //    return GetData<T>(_ProgCode, null);
        //}
        public static List<T> GetData<T>(string _ProgCode, DynamicParameters param = null)
        {
            try
            {

                RepList<object> repObj = new RepList<object>();
                ProgramMasterModel storedProcObj = GetProgramMasterModel(_ProgCode);
                List<T> list = repObj.returnListClass_SP_1<T>(storedProcObj.ProgProcName, param);                

                return list;
            }
            catch (Exception)
            {
                //throw;
            }

            return null;
        }

        public static DataSet GetData(string _ProgCode)
        {
            DataSet dsMaster = null;
            try
            {
                //DataSet ds = ProjectFunctionsUtils.GetDataSet("sp_ProgramMaster '" + _ProgCode + "'");
                //string ProcedureName = ds.Tables[0].Rows[0]["ProgProcName"].ToString();
                ProgramMasterModel storedProcObj = GetProgramMasterModel(_ProgCode);
                string ProcedureName = storedProcObj.ProgProcName;

                dsMaster = ProjectFunctionsUtils.GetDataSet(ProcedureName);                
            }
            catch (Exception)
            {
                //throw;
            }

            return dsMaster;
        }
    }
}