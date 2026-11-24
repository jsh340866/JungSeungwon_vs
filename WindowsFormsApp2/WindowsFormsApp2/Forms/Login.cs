using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.닫기.Click += 닫기btn_Click;
        }

        // 폼 테두리
        private void 테두리_Paint(object sensor, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 닫기
        private void 닫기btn_Click(object sensor, EventArgs e)
        {
            this.Close();
        }

        // 저장(로그인)
        private void 저장btn_Click(object sensor, EventArgs e)
        {
            try
            {
                new EmpService().Login(로그인ID.Text, 비밀번호.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch(BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }

}

