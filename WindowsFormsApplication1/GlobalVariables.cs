using System;
namespace WindowsFormsApplication1
{
    class GlobalVariables
    {
        public static String BarCodePreFix = "V";

        //public static String MasterCode;
        //public static String MainProgCode = "ACCOUNTS";

        public static int GlobalCustWindowCount = 0;

        public static String ProgCode = "MIS1";
        public static String ProgDesc = "Test";
#pragma warning disable CS0649 // Field 'GlobalVariables.s1' is never assigned to, and will always have its default value null
        public static String s1;
#pragma warning restore CS0649 // Field 'GlobalVariables.s1' is never assigned to, and will always have its default value null
        public static DateTime FinYearStartDate = Convert.ToDateTime("2020-04-01");
        public static DateTime FinYearEndDate = Convert.ToDateTime("2021-03-31");
        public static String CurrentUser = "000130";
        public static String LayoutLocation = @"C:\Application";
        public static String CompanyName = string.Empty;
        public static String CAddress1 = string.Empty;
        public static String CAddress2 = string.Empty;
        public static String CAddress3 = string.Empty;
        public static String CPlantAddress1 = string.Empty;
        public static String CashCode = "000279";
        public static String UserPwd = "Happy";
        public static String FinancialYear = "2020-2021";
        public static String SampleDealerCode = "000281";
        public static String CmpEmailID = "000281";
        public static String CmpWebSite = "000281";
        public static String CmpZipCode = "000281";
        public static String CmpGSTNo = string.Empty;
        public static String TelNo = string.Empty;
        public static String FSSAI = string.Empty;
        public static String CUnitID = string.Empty;

        public static DateTime LicenseToExpireDate = Convert.ToDateTime("2022-03-31");

        public static String PortNo = "COM5";

    }
}