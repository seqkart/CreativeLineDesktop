using SeqKartLibrary;
using System;
using System.Linq;

namespace WindowsFormsApplication1.HRMS
{
    class GlobalClass
    {
        internal static string EmpID;
        internal static string conn;
        internal static string hostIP;
        //internal static HRDepartment hrd;
        static GlobalClass()
        {

            conn = ProjectFunctionsUtils.ConnectionString;
            GlobalClass.hostIP = string.Empty;

        }
    }
}
