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
    }
}