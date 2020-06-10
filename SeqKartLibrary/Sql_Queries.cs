using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
