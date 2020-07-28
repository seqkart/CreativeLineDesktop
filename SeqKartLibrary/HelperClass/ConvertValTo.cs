using System;

namespace SeqKartLibrary.HelperClass
{
    public class ConvertTo
    {
        public static bool BooleanVal(object val)
        {
            try
            {
                return Convert.ToBoolean(val);
            }
            catch { }

            return false;
        }
        public static int IntVal(object val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch { }

            return 0;
        }

        public static decimal DecimalVal(object val)
        {
            try
            {
                return Convert.ToDecimal(val);
            }
            catch { }

            return 0;
        }

        public static double DoubleVal(object val)
        {
            try
            {
                return Convert.ToDouble(val);
            }
            catch { }

            return 0;
        }

        public static DateTime DateTimeVal(object val)
        {
            try
            {
                return Convert.ToDateTime(val);
            }
            catch { }

            return DateTime.Now;
        }

        public static DateTime Date_NullableToNon(DateTime? val)
        {
            try
            {
                DateTime date_null = val.GetValueOrDefault(DateTime.Now);
                return date_null;

            }
            catch { }

            return DateTime.Now;
        }

        public static DateTime TimeToDate(string time_In)
        {
            try
            { 
                TimeSpan timeSpan_In = TimeSpan.Parse(time_In);
                DateTime dateTime_In = DateTime.Today.Add(timeSpan_In);

                return dateTime_In;
            }
            catch { }

            return DateTime.Now;
        }

        public static TimeSpan TimeSpanVal(object val)
        {
            try
            {
                return TimeSpan.Parse(val + "");
            }
            catch { }

            return TimeSpan.Parse("00:00");
        }

        public static TimeSpan? TimeSpanVal_Null(object val)
        {
            try
            {
                if (val != null)
                {
                    return TimeSpan.Parse(val + "");
                }
                else
                {
                    PrintLogWinForms.PrintLog("ConvertValueTo.TimeSpanVal_Null : val is NULL");
                    return null;
                }
            }
            catch(Exception ex)
            {
                PrintLogWinForms.PrintLog("ConvertValueTo.TimeSpanVal_Null => Exception => val " +
                    ": " + val + "" + "");
                PrintLogWinForms.PrintLog("ConvertValueTo.TimeSpanVal_Null => Exception : " + ex.Message + "");
            }

            return null;
        }

        public static string DateFormatApp(DateTime dateTime)
        {
            try
            {
                return dateTime.ToString("dd-MM-yyyy");
            }
            catch { }

            return dateTime.ToString();
        }

        public static string DateFormatApp(object dateTime)
        {
            try
            {
                return DateTimeVal(dateTime).ToString("dd-MM-yyyy");
            }
            catch { }

            return dateTime.ToString();
        }

        public static string DateFormatDb(DateTime dateTime)
        {
            try
            {
                return dateTime.ToString("yyyy-MM-dd");
            }
            catch { }

            return dateTime.ToString();
        }

        public static string DateFormatDb(object dateTime)
        {
            try
            {
                return DateTimeVal(dateTime).ToString("yyyy-MM-dd");
            }
            catch { }

            return dateTime.ToString();
        }

        public static string MinutesToHours(object _totalMinute)
        {
            string sign = "";
            Int32 totalMinute = IntVal(_totalMinute);
            if (totalMinute == 0)
            {
                return "";
            }
            Int32 Minute = default(Int32);
            Int32 Hour = default(Int32);
            {
                if (totalMinute < 0)
                {
                    totalMinute = totalMinute * -1;
                    sign = "-";
                }
                totalMinute = totalMinute % 1440;


                Hour = totalMinute / 60;
                Minute = totalMinute % 60;
                return FormatTwoDigits(Hour, sign) + " : " + FormatTwoDigits(Minute, "") + " ";
            }
            //return _totalMinute + "";
        }
        public static string FormatTwoDigits(Int32 i, string sign)
        {
            string functionReturnValue = null;
            if (10 > i)

            {
                functionReturnValue = sign + "0" + i.ToString();
            }            
            else
            {
                functionReturnValue = sign + i.ToString();
            }
            return functionReturnValue;
        }
    }
}