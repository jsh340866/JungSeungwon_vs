using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// ───────────── 테두리 색을 시안(#ABABAB)으로 덧칠하는 TextBox ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class BorderTextBox : TextBox
{
    private const int WM_PAINT = 0x000F;
    private const int WM_NCPAINT = 0x0085;
    public static readonly Color BorderColor = Ui.Gray;   // 시안 입력칸 테두리 #ABABAB

    [DllImport("user32.dll")] private static extern IntPtr GetWindowDC(IntPtr hWnd);
    [DllImport("user32.dll")] private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        // 기본 테두리를 그린 직후, 같은 자리에 1px 테두리를 원하는 색으로 덮어 그림.
        // WM_NCPAINT 뒤에 기본 테두리가 다시 그려지는 경우가 있어 WM_PAINT 뒤에도 한 번 더 그림
        if ((m.Msg == WM_NCPAINT || m.Msg == WM_PAINT) && BorderStyle == BorderStyle.FixedSingle)
        {
            IntPtr hdc = GetWindowDC(Handle);
            if (hdc == IntPtr.Zero) return;
            try
            {
                using (var g = Graphics.FromHdc(hdc))
                using (var pen = new Pen(BorderColor))
                {
                    g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                }
            }
            finally { ReleaseDC(Handle, hdc); }
        }
    }
}
