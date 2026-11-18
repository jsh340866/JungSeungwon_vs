using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.ViewInfo;

namespace WindowsFormsApp2.Utils
{
    public class ImageHelper
    {
        public static byte[] ImageToByte(Image img)
        {
            using(var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
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
