using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class LoginInfoForm : Form
    {
        int EmpId;

        public LoginInfoForm(string loginId, string password, int EmpId)
        {
            InitializeComponent();
            LoginTextbox.Text = loginId;
            PasswordTextbox.Text = password;
            this.EmpId = EmpId;
        }

        private void LoginInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginInfoForm_Paint(object sender, PaintEventArgs e)
        {
            // 폼 테두리
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 로그인정보 저장 버튼 클릭 시, EmployeeRespository의 UpdateLoginInfo 메서드를 호출하여 로그인 정보 업데이트
            string loginid = LoginTextbox.Text;
            string password = PasswordTextbox.Text;
            int empId = this.EmpId;

            try
            {
                new EmployeeRepository().UpdateLoginInfo(loginid, password, empId);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인 정보 업데이트 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}
