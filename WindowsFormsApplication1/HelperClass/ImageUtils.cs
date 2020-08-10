using System;
using System.Drawing;
using System.IO;

public class ImageUtils
{
    public static Image ConvertBinaryToImage(byte[] data)
    {
        try
        {
            if (data != null)
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
        }
        catch (Exception ex)
        {

        }
        return null;
    }
}