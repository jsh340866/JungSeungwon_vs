using System.IO;
using System.Drawing;

namespace WindowsFormsApp2.Utils
{
    public class ImageHelper
    {
        // 이미지를 바이트로 변환
        public static byte[] ImageToByte(Image img)
        {
            using(var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        // 바이트를 이미지로 변환
        public static Image ByteToImage(byte[] data)
        {
            using(var ms = new MemoryStream(data))
            {
                using (var img = Image.FromStream(ms))
                {
                    return new Bitmap(img);
                }
            }
        }
    }
}
