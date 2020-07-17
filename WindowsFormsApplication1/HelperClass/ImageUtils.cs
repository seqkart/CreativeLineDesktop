using System.Drawing;
using System.IO;

public class ImageUtils
{
    public static Image ConvertBinaryToImage(byte[] data)
    {
        using (MemoryStream ms = new MemoryStream(data))
        {
            return Image.FromStream(ms);
        }
    }
}