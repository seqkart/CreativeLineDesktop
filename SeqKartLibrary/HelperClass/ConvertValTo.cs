using System;

namespace SeqKartLibrary.HelperClass
{
    public class ConvertTo
    {
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
    }
}