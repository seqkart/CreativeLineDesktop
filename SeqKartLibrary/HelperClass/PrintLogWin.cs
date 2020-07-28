public class PrintLogWinForms
{
    public static void PrintLog(object msg)
    {
        System.Diagnostics.Debug.WriteLine("PrintLog => " + msg);
    }
}