using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2.Forms
{
    public partial class Delete : Form
    {
        // title,msg를 받아 제목, 메시지로 사용해 공통 삭제폼으로 사용
        public Delete(string title, string msg)
        {
            InitializeComponent();
            this.취소.Click += 취소btn_Click;
            this.삭제.Click += 삭제btn_Click;
            this.Paint += 테두리_Paint;

            제목.Text = title;
            메시지.Text = msg;

        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1); 
            }
        }

        // 삭제
        private void 삭제btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
