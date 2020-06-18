using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqKartLibrary
{
    public class SQL_COLUMNS
    {
        public static class COMCONF
        {
            public const string _COMADD = "COMADD";
            public const string _COMADD1 = "COMADD1";
            public const string _COMADD2 = "COMADD2";
            public const string _COMGST = "COMGST";
            public const string _COMNAME = "COMNAME";
            public const string _COMPHONE = "COMPHONE";
            public const string _COMEID = "COMEID";
            public const string _COMZIP = "COMZIP";
            public const string _COMWEBSITE = "COMWEBSITE";
            public const string _COMSYSID = "COMSYSID";
        }

        public static class FN_YEAR
        {
            public const string _FNYearCode = "FNYearCode";
            public const string _FNStartDate = "FNStartDate";
            public const string _FNEndDate = "FNEndDate";
        }

        public static class UNITS
        {
            public const string _UNITID = "UNITID";
            public const string _UNITNAME = "UNITNAME";
            
        }

        public static class USER_MASTER
        {
            public const string _UserName = "UserName";
            public const string _LoginAs = "Login_As";
            public const string _UserActive = "UserActive";

        }

        public static class _AttendanceStatus
        {
            public const string _status_id = "status_id";
            public const string _status = "status";
            

        }

        public static class _DailyShifts
        {
            public const string _shift_id = "shift_id";
            public const string _shift_name = "shift_name";


        }
    }

}
