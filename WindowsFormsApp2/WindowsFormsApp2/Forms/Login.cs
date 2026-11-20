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
    public partial class Login : Form
    {
        private readonly List<EmployeeDto> Emp = new EmployeeRepository().Login();
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
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(로그인ID.Text)){ MessageBox.Show("ID를 입력해주세요."); return; }
            if (string.IsNullOrWhiteSpace(비밀번호.Text)){ MessageBox.Show("비밀번호를 입력해주세요."); return; }

            // 입력한 로그인ID의 사원dto를 가져와 로그인ID와 비밀번호 확인
            var user = Emp.FirstOrDefault(u => u.LoginId == 로그인ID.Text);
            if (user == null)
            {
                MessageBox.Show("존재하지않는 ID입니다.");
                return;
            }
            if (user.Password != 비밀번호.Text)
            {
                MessageBox.Show("비밀번호가 정확하지 않습니다, 다시 시도해주세요");
                return;
            }
            // 맞다면 DialogResult.OK
            this.DialogResult = DialogResult.OK;
            

        }



    }

}

