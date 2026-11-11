using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// ───────────── 화면 전체를 직접 그리는 ComboBox (화살표는 이미지) ─────────────
// 목록 열기/닫기/선택은 기존 ComboBox가 처리하고, 닫혀 있을 때의 모습만 직접 그린다.
[System.ComponentModel.DesignerCategory("Code")]
class ImageComboBox : ComboBox
{
    private const int WM_PAINT = 0x000F;
    private const int WM_ERASEBKGND = 0x0014;
    private readonly Image _arrow;

    [DllImport("user32.dll")]
    private static extern bool ValidateRect(IntPtr hWnd, IntPtr lpRect);

    public ImageComboBox(Image arrow)
    {
        _arrow = arrow;
        DropDownStyle = ComboBoxStyle.DropDownList;
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_ERASEBKGND)
        {
            m.Result = (IntPtr)1;   // 배경 지우기 생략 (지속적인 깜빡임 방지)
            return;
        }

        if (m.Msg == WM_PAINT && _arrow != null)
        {
            // base.WndProc을 부르지 않으므로 기본 그림은 그려지지 않는다.
            // 대신 메모리 그림에 전부 그린 뒤 한 번에 화면으로 옮긴다.
            using (var buffer = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            {
                using (var g = Graphics.FromImage(buffer))
                {
                    g.Clear(BackColor);

                    // 선택된 글자 (화살표 자리를 뺀 왼쪽)
                    var textRect = new Rectangle(3, 0, Width - _arrow.Width - 6, Height);
                    string text = SelectedItem == null ? "" : GetItemText(SelectedItem);
                    // 배경색(BackColor) 인자를 빼면 글자가 굵고 뭉개져서 보인다 (실행해서 확인함). 반드시 같이 넘길 것.
                    TextRenderer.DrawText(g, text, Font, textRect, ForeColor, BackColor,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                    g.DrawImage(_arrow, Width - _arrow.Width - 1, 1, _arrow.Width, _arrow.Height);

                    using (var pen = new Pen(Ui.Gray))
                    {
                        g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                    }
                }

                using (var screen = Graphics.FromHwnd(Handle))
                {
                    screen.DrawImageUnscaled(buffer, 0, 0);
                }
            }
            ValidateRect(Handle, IntPtr.Zero);   // "다 그렸다"고 알림 (안 하면 그리기 메시지가 계속 옴)
            return;
        }

        base.WndProc(ref m);
    }
}
