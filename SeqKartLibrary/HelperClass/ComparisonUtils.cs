public class ComparisonUtils
{
    public static bool IsEqualTo_String(object val1, object val2)
    {
        if (!(val1 + "").Equals(val2 + ""))
        {
            return false;
        }
        return true;
    }

    public static bool IsEmpty(object val)
    {
        if (!(val + "").Equals(""))
        {
            return false;
        }
        return true;
    }
}