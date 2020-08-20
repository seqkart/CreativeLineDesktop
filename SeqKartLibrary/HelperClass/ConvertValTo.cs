using System;

namespace SeqKartLibrary.HelperClass
{
    public enum EmptyReturn
    {
        Zero,
        DbNull,
        Empty
    }
    public class ConvertTo
    {
        public static bool BooleanVal(object val)
        {
            try
            {
                return Convert.ToBoolean((val + "").ToLower());
            }
            catch { }

            return false;
        }
        public static string StringVal(object val)
        {
            try
            {
                return val + "";
            }
            catch { }

            return "";
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

        public static string TimeSpanString(object val)
        {
            try
            {
                if (val == DBNull.Value)
                {
                    return ("");
                }
                if (val == null)
                {
                    return ("");
                }
                if ((val + "").Equals(""))
                {
                    return ("");
                }
                if ((val + "").Equals("0"))
                {
                    return ("");
                }
                return ConvertTo.TimeSpanVal(val).ToString(@"hh\:mm");
            }
            catch (Exception ex)
            {
                PrintLogWinForms.PrintLog("ConvertTo => TimeSpanString => Exception : " + ex);

            }

            return ("");
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
            catch (Exception ex)
            {
                PrintLogWinForms.PrintLog("ConvertValueTo.TimeSpanVal_Null => Exception => val " +
                    ": " + val + "" + "");
                PrintLogWinForms.PrintLog("ConvertValueTo.TimeSpanVal_Null => Exception : " + ex.Message + "");
            }

            return null;
        }

        public static string DateFormatMonthYear(object dateTime)
        {
            try
            {
                return DateTimeVal(dateTime).ToString("MMMM-yyyy");
            }
            catch { }

            return dateTime.ToString();
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
        public static int MinutesToHours_DB(object _totalMinute)
        {
            Int32 totalMinute = IntVal(_totalMinute);
            if (totalMinute == 0)
            {
                return 0;
            }
            Int32 Hour = default(Int32);
            {
                Hour = totalMinute / 60;
                return Hour;
            }
        }
        public static string MinutesToHours(object _totalMinute)
        {
            string sign = "";
            Int32 totalMinute = IntVal(_totalMinute);
            if (totalMinute == 0)
            {
                return "0";
            }
            Int32 Minute = default(Int32);
            Int32 Hour = default(Int32);
            {
                if (totalMinute < 0)
                {
                    totalMinute = totalMinute * -1;
                    sign = "-";
                }

                Hour = totalMinute / 60;
                Minute = totalMinute % 60;
                return FormatTwoDigits(Hour, sign) + ":" + FormatTwoDigits(Minute, "") + " ";
            }
            //return _totalMinute + "";
        }

        public static object MinutesToHours(object _totalMinute, EmptyReturn _zeroReturn)
        {
            string sign = "";
            Int32 totalMinute = IntVal(_totalMinute);
            if (totalMinute == 0)
            {
                if (_zeroReturn == EmptyReturn.DbNull)
                {
                    return DBNull.Value;
                }
                if (_zeroReturn == EmptyReturn.Zero)
                {
                    return "0";
                }
                if (_zeroReturn == EmptyReturn.Empty)
                {
                    return "";
                }
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

                Hour = totalMinute / 60;
                Minute = totalMinute % 60;
                return FormatTwoDigits(Hour, sign) + ":" + FormatTwoDigits(Minute, "") + " ";
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