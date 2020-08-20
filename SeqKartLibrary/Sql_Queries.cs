using System;

namespace SeqKartLibrary
{
    public class SQL_QUERIES
    {
        public static class _frm_Chng_Pswd
        {
            public static string SQL_UserMaster(object UserName, object UserPwd)
            {
                return "SELECT UserName FROM UserMaster Where UserName='" + UserName + "' AND UserPwd='" + UserPwd + "'";
            }
            public static string SQL_UserMaster_Update_Pass(object UserName, object UserPwd)
            {
                return String.Format("Update UserMaster Set UserPwd='{0}' where UserName='{1}'", UserPwd, UserName);
            }
        }
        public static class _frmEmployeeMstAddEdit
        {
            public static string _GetNewEmpCode(bool hasRtnCol = true)
            {
                //string sql = "SELECT"
                //+ " CASE"
                //+ " WHEN (isnull(max(Cast(REPLACE(EmpCode, 'emp', '') as int)), 00000) + 1) < 10 THEN ('emp0'+CAST(isnull(max(Cast(REPLACE(EmpCode, 'emp', '') as int)), 00000) + 1 as varchar(10)))"
                //+ " ELSE ('emp'+CAST(isnull(max(Cast(REPLACE(EmpCode, 'emp', '') as int)), 00000) + 1 as varchar(10)))"
                //+ " END AS NewEmpCode"
                //+ " FROM EmpMst;";

                //string sql = "";
                if (!hasRtnCol)
                {
                    string sql1 = "SELECT RIGHT('0000' + CAST((ISNULL(MAX(CAST(EmpCode AS INT)), 0) + 1) AS VARCHAR(4)), 4) FROM EmpMst";
                    return sql1;
                }

                string sql = "SELECT RIGHT('0000' + CAST((ISNULL(MAX(CAST(EmpCode AS INT)), 0) + 1) AS VARCHAR(4)), 4) AS NewCode FROM EmpMst";

                return sql;
            }

            public static string sp_LoadEmpMstFEditing()
            {
                return "sp_LoadEmpMstFEditing";
            }
        }

        public static class _frmDepartmentAddUpdate
        {
            public static string _GetNewDeptCode()
            {
                //string sql1 = "SELECT"
                //+ " CASE"
                //+ " WHEN (isnull(max(Cast(REPLACE(DeptCode, 'dp', '') as int)), 00000) + 1) < 10 THEN ('dp0'+CAST(isnull(max(Cast(REPLACE(DeptCode, 'dp', '') as int)), 00000) + 1 as varchar(10)))"
                //+ " ELSE ('dp'+CAST(isnull(max(Cast(REPLACE(DeptCode, 'dp', '') as int)), 00000) + 1 as varchar(10)))"
                //+ " END AS NewDeptCode"
                //+ " FROM DeptMSt;";

                string sql = "SELECT RIGHT('0000' + CAST((ISNULL(MAX(CAST(DeptCode AS INT)), 0) + 1) AS VARCHAR(4)), 4) AS NewCode FROM DeptMSt";
                return sql;
            }
        }

        public static class _frmDesignationAddUpdate
        {
            public static string _GetNewDesgCode()
            {
                //string sql = "SELECT"
                //+ " CASE"
                //+ " WHEN (isnull(max(Cast(REPLACE(DesgCode, 'ds', '') as int)), 00000) + 1) < 10 THEN ('ds0'+CAST(isnull(max(Cast(REPLACE(DesgCode, 'ds', '') as int)), 00000) + 1 as varchar(10)))"
                //+ " ELSE ('ds'+CAST(isnull(max(Cast(REPLACE(DesgCode, 'ds', '') as int)), 00000) + 1 as varchar(10)))"
                //+ " END AS NewDesgCode"
                //+ " FROM DesgMst;";

                string sql = "SELECT RIGHT('0000' + CAST((ISNULL(MAX(CAST(DesgCode AS INT)), 0) + 1) AS VARCHAR(4)), 4) AS NewCode FROM DesgMst";

                return sql;

            }
        }

        public static string SP_LoadUserAllocatedWork2(object UserName)
        {
            return "sp_LoadUserAllocatedWork2 '" + UserName + "'";
        }
        /// <summary>
        /// ////////////////
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        public static string SQL_USERMASTER(object UserName, object UserPwd)
        {
            return "Select UserName,UserPwd from UserMaster WHere UserName='" + UserName.ToString().Trim() + "' And UserPwd='" + UserPwd.ToString().Trim() + "'";
        }

        public static string SQL_USERMASTER_BY_USER(object UserName)
        {
            return "Select UserName from UserMaster WHere UserName='" + UserName.ToString().Trim() + "'";
        }

        public static string SQL_COMCONF_ALL()
        {
            return "Select * from COMCONF";
        }

        public static string SQL_COMCONF()
        {
            return "SELECT COMSYSID,COMNAME FROM COMCONF";
        }

        public static string SQL_FN_YEAR(object FNYear)
        {
            return "select * from FNYear Where FNYearCode='" + FNYear + "'";
        }

        public static string SQL_FN_YEAR_ACTIVE(object active)
        {
            return "Select * from FNYear WHERE Active ='" + active + "'";
        }

        public static string SQL_UNITS(object CUnitID)
        {
            return "Select isnull(BarCodePreFix,'V') as BarCodePreFix from UNITS where UNITID='" + CUnitID + "'";
        }

        public static string SQL_UNITS_BY_USER(object UserName)
        {
            return "SELECT UNITS.UNITID, UNITS.UNITNAME FROM  UNITS INNER JOIN UserUnitAccess ON UNITS.UNITID = UserUnitAccess.UnitCode Where UserName='" + UserName + "'";
        }

        public static string SQL_USER_FN_ACCESS_BY_USER(object UserName)
        {
            return "SELECT FNYear.FNYearCode FROM  UserFNAccess INNER JOIN FNYear ON UserFNAccess.FNTransID = FNYear.TransID  Where UserName='" + UserName + "'";
        }

        public static string _sp_EmployeesList()
        {
            //return "SELECT * FROM EmpMST";//
            return "sp_EmployeesList";
            //sp_EmployeesList";
        }

        public static string _sp_EmployeeDetails(object EmpCode)
        {
            return _sp_EmployeeDetails() + " " + EmpCode + "'";
        }

        public static string _sp_EmployeeDetails()
        {
            return "sp_EmployeeDetails";
        }

        public static string sp_GatePassData_Daily_List()
        {
            return "sp_GatePassData_Daily_List";
        }
    }
}
