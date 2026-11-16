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
        private static readonly List<DepartmentDto> dept = new DepartmentRepository().GetAll();

        public EmployeeAddForms()
        {
            InitializeComponent();


            // 콤보박스에 DeptCode만 보이고 실제 값은 DeptId로 확인
            cboDeptCode.DataSource = dept;
            cboDeptCode.DisplayMember = nameof(DepartmentDto.DeptCode);
            cboDeptCode.ValueMember = nameof(DepartmentDto.DeptId);



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
            if (string.IsNullOrWhiteSpace(cboDeptCode.Text)) { MessageBox.Show("부서코드를 입력해주세요"); return; }
            if (string.IsNullOrWhiteSpace(txtEmpCode.Text)) { MessageBox.Show("사원코드를 입력해주세요.");  return; }
            if (string.IsNullOrWhiteSpace(txtEmpName.Text)) { MessageBox.Show("사원명을 입력해주세요."); return;}
            if (string.IsNullOrWhiteSpace(txtLoginId.Text)) { MessageBox.Show("로그인ID를 입력해주세요"); return;}
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) {MessageBox.Show("비밀번호를 입력해주세요"); return;}
            

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
                EmployeeDto emp = new EmployeeDto
                {
                    DeptCode = cboDeptCode.Text,
                    DeptId = (int)cboDeptCode.SelectedValue,
                    EmpCode = txtEmpCode.Text,
                    EmpName = txtEmpName.Text,
                    LoginId = txtLoginId.Text,
                    Password = txtPassword.Text,
                    Gender = man.Checked ? "남" : woman.Checked ? "여" : null,
                    Position = string.IsNullOrWhiteSpace(txtPosition.Text) ? null : txtPosition.Text,
                    EmpType = string.IsNullOrWhiteSpace(txtEmpType.Text) ? null : txtEmpType.Text,
                    Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
                    MessengerId = string.IsNullOrWhiteSpace(txtMessengerId.Text) ? null : txtMessengerId.Text,
                    Memo = string.IsNullOrWhiteSpace(txtMemo.Text) ? null : txtMemo.Text
                };

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
            var d = cboDeptCode.SelectedItem as DepartmentDto;
            txtDeptName.Text = d.DeptName;
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
