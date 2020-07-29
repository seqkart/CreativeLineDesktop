﻿using System;
using System.Collections.Generic;
using System.Data;

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

    public static bool IsNumeric(object val)
    {
        try
        {
            int v = Convert.ToInt32(val);
            return true;
        }
        catch { }

        return false;
    }

    public static bool IsDecimal(object val)
    {
        try
        {
            decimal v = Convert.ToDecimal(val);
            return true;
        }
        catch { }

        return false;
    }

    public static bool IsEmpty(object val)
    {
        if (!(val + "").Equals(""))
        {
            return false;
        }
        return true;
    }

    public static bool IsNotEmpty(object val)
    {
        if (!(val + "").Equals(""))
        {
            return true;
        }
        return false;
    }

    public static bool IsNotNull_DataSet(DataSet ds)
    {
        try
        {
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
        }
        catch
        {

        }
        
        return false;
    }

    public static bool IsNotNull_List<T>(List<T> list)
    {
        try
        {
            if (list != null)
            {
                if (list.Count > 0)
                {
                    return true;
                }
            }
        }
        catch
        {

        }

        return false;
    }
}