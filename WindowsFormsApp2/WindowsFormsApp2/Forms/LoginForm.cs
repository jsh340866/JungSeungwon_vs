using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;

namespace WindowsFormsApp2.Forms
{
    public partial class LoginForm : Form
    {

        private readonly List<EmployeeDto> Emp = new EmployeeRepository().Login();
        private readonly Form1 F = new Form1();

        public LoginForm()
        {
            InitializeComponent();
            this.Paint += 로그인폼_테두리;
            this.저장버튼.Click += 로그인;
            this.닫기버튼.Click += 닫기;
            

        }

        private void 로그인폼_테두리(object sensor, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        

        private void 닫기(object sensor, EventArgs e)
        {
            this.Close();
        }

        private void 로그인(object sensor, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(로그인텍스트박스.Text))
            {
                MessageBox.Show("ID를 입력해주세요.");
                return;
            }
            var user = Emp.FirstOrDefault(u => u.LoginId == 로그인텍스트박스.Text);
            if (user == null)
            {
                MessageBox.Show("존재하지않는 ID입니다.");
                return;
            }

            if (user.Password != 비밀번호텍스트박스.Text)
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            

        }



    }

}

