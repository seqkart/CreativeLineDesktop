using System.Windows.Forms;

public class ComparisonUtilsWin
{
    public static bool PictureBox_IsNullOrEmpty(PictureBox pb)
    {
        return pb == null || pb.Image == null;
    }
}