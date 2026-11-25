using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Diagram.Core.Native.Either;

namespace WindowsFormsApp2.Utils
{
    internal class FormDesign
    {
        public static void Line(PaintEventArgs e, int Width, int Height)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }
        
    }
}
