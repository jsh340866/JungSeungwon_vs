using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class EmployeeAddForms : Form
    {
        public EmployeeAddForms()
        {
            InitializeComponent();

            // EmployeeRepository에서 만든 DeptCodeName 사전을 deptcode에 넣기
            foreach (var deptcode in new EmployeeRepository().DeptCodeName())
            {
                // deptcode.key값을 cboDeptCode 드롭박스에 넣음
                cboDeptCode.Items.Add(deptcode.Key);
            }
        }

        private void EmployeeAddForms_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 사원 추가 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDeptCode.Text) ||
                string.IsNullOrWhiteSpace(txtEmpCode.Text) ||
                string.IsNullOrWhiteSpace(txtEmpName.Text) ||
                string.IsNullOrWhiteSpace(txtLoginId.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("부서코드, 사원코드, 사원명, 로그인ID, 비밀번호는 필수기재사항입니다.");
                return;

            }

            if (!Rule.isPasswordCheck(txtPassword.Text))
            {
                MessageBox.Show("비밀번호는 영문,숫자 포함 8자 이상입니다.");
                return;
            }

            // 이메일이 비어있지 않고 Rule에서 만든 이메일 규칙이 false일때 메시지 박스 띄움
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Rule.isEmailCheck(txtEmail.Text))
            {
                MessageBox.Show("이메일을 다시 입력해주세요.");
                return;
            }

            try
            {
                Employee emp = new Employee();
                emp.DeptCode = cboDeptCode.Text;
                emp.EmpCode = txtEmpCode.Text;
                emp.EmpName = txtEmpName.Text;
                emp.LoginId = txtLoginId.Text;
                emp.Password = txtPassword.Text;
                emp.Gender = man.Checked ? "남" : woman.Checked ? "여" : null;
                emp.Position = string.IsNullOrWhiteSpace(txtPosition.Text) ? null : txtPosition.Text;
                emp.EmpType = string.IsNullOrWhiteSpace(txtEmpType.Text) ? null : txtEmpType.Text;
                emp.Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text;
                emp.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;
                emp.MessengerId = string.IsNullOrWhiteSpace(txtMessengerId.Text) ? null : txtMessengerId.Text;
                emp.Memo = string.IsNullOrWhiteSpace(txtMemo.Text) ? null : txtMemo.Text;

                new EmployeeRepository().EmployeeAddSave(emp);
                this.DialogResult = DialogResult.OK;
            }
            // Sql server 오류 발생시 처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // unique 제약조건 위반 될시(중복값) 메세지 박스 띄움
                if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    MessageBox.Show("이미 사용중인 로그인ID 입니다.");
                    return;
                }
                // unique 제약조건 위반 될시(중복값) 메세지 박스 띄움
                else if (ex.Message.Contains("UQ_Employee_EmpCode")){
                    MessageBox.Show("이미 사용중인 사원코드 입니다.");
                    return; 
                }
                else
                {
                    MessageBox.Show("중복된 값이 있습니다.");
                    return;
                }
               

                
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("사원 추가 실패 EmpCode=" + txtEmpCode.Text, ex);
                MessageBox.Show("사원 추가 중 오류가 발생했습니다.\n" + ex.Message);
            }
        }


        // 부서코드에 매칭되는 부서명 자동입력
        private void cboDeptCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dict = new EmployeeRepository().DeptCodeName();
            txtDeptName.Text = dict[cboDeptCode.Text];
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            cboDeptCode.Focus(); // 콤보박스에 입력 포커스 이동하고
            cboDeptCode.DroppedDown = true; // 드롭다운 리스트 열기
        }

        private void man_CheckedChanged(object sender, EventArgs e)
        {
            if (man.Checked == true)
            {
                woman.Checked = false;
            }
        }

        private void woman_CheckedChanged(object sender, EventArgs e)
        {
            if (woman.Checked == true)
            {
                man.Checked = false;
            }

        }

        // 휴대폰번호 하이폰 규칙
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            string digits = new string(txtPhone.Text.Where(char.IsDigit).ToArray());
            if (digits.Length >= 11)
            {
                txtPhone.Text = digits.Insert(7, "-").Insert(3, "-");
            }
        }
    }
}
