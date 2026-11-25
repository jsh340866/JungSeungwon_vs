using System;
using System.Windows.Forms;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class DeleteForm : Form
    {
        // title,msg를 받아 제목, 메시지로 담아 공통 삭제폼으로 사용
        public DeleteForm(string title, string msg)
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.취소btn.Click += 취소btn_Click;
            this.삭제btn.Click += 삭제btn_Click;

            제목label.Text = title;
            메시지label.Text = msg;
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            FormDesign.Line(e, Width, Height);
        }

        // 삭제
        private void 삭제btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
