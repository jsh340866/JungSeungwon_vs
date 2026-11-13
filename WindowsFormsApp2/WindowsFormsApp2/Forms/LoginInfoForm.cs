using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
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

            if (!Rule.isPasswordCheck(PasswordTextbox.Text)) 
            {
                MessageBox.Show("비밀번호는 영문, 숫자 포함 8자 이상입니다.");
                return;
            }

            try
            {
                new EmployeeRepository().UpdateLoginInfo(loginid, password, empId);
                this.DialogResult = DialogResult.OK;
            }
            catch(SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("이미 사용중인 로그인ID 입니다.");
            }

            catch (Exception ex)
            {
                MessageBox.Show("로그인 정보 업데이트 중 오류가 발생했습니다: " + ex.Message);
               
            }
        }
    }
}
