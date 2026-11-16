using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class EmployeeEditForm : Form
    {

        private readonly int Empid;

        private static readonly List<DepartmentDto> dept = new DepartmentRepository().GetAll();


        // 생성자
        public EmployeeEditForm(EmployeeDto emp)
        {
            InitializeComponent();


            
            // DeptCodeName 부서코드, 부서명 사전을 드롭박스에 추가
            
            cboDeptCode.DataSource = dept;
            cboDeptCode.DisplayMember = nameof(DepartmentDto.DeptCode);
            cboDeptCode.ValueMember = nameof(DepartmentDto.DeptId);
                
            

            cboDeptCode.Text = emp.DeptCode;
            txtDeptName.Text = emp.DeptName;
            txtEmpCode.Text = emp.EmpCode;
            txtEmpName.Text = emp.EmpName;
            txtPosition.Text = emp.Position;
            txtEmpType.Text = emp.EmpType;
            txtPhone.Text = emp.Phone;
            txtEmail.Text = emp.Email;
            txtMessengerId.Text = emp.MessengerId;
            txtMemo.Text = emp.Memo;
            this.Empid = emp.EmpId;

            if (emp.Gender == "남")
            {
                man.Checked = true;

            }
            else if (emp.Gender == "여")
            {
                woman.Checked = true;
            }



        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeeEditForm_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void man_CheckedChanged(object sender, EventArgs e)
        {
            if (man.Checked) { woman.Checked = false; }
        }

        private void woman_CheckedChanged(object sender, EventArgs e)
        {
            if (woman.Checked) { man.Checked = false; }
        }


        // 사원 수정 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpCode.Text) || string.IsNullOrWhiteSpace(txtEmpName.Text) || string.IsNullOrWhiteSpace(cboDeptCode.Text))
            {
                MessageBox.Show("사원코드, 사원이름, 부서코드는 필수 입력 항목입니다.");
                return;
            }

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
                    EmpCode = txtEmpCode.Text,
                    EmpName = txtEmpName.Text,
                    Gender = man.Checked ? "남" : woman.Checked ? "여" : null,
                    Position = string.IsNullOrWhiteSpace(txtPosition.Text) ? null : txtPosition.Text,
                    EmpType = string.IsNullOrWhiteSpace(txtEmpType.Text) ? null : txtEmpType.Text,
                    Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
                    MessengerId = string.IsNullOrWhiteSpace(txtMessengerId.Text) ? null : txtMessengerId.Text,
                    Memo = string.IsNullOrWhiteSpace(txtMemo.Text) ? null : txtMemo.Text,
                    EmpId = this.Empid
                };

                new EmployeeRepository().UpdateEmployee(emp);
                this.DialogResult = DialogResult.OK;
            }


            // SQL Server 오류 2627 UNIQUE 제약조건 위반(중복값)
            catch (SqlException ex) when (ex.Number == 2627)
            {
                if (ex.Message.Contains("UQ_Employee_EmpCode"))
                {
                    MessageBox.Show("이미 사용중인 사원코드 입니다.");
                }
                else
                {
                    MessageBox.Show("중복된 값이 있습니다.");
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("사원 수정 실패 EmpId=" + this.Empid, ex);
                MessageBox.Show("사원 정보 저장 중 오류가 발생했습니다.\n" + ex.Message);
            }
        }

        // 부서코드, 부서명 자동 매칭
        private void cboDeptCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = cboDeptCode.SelectedItem as DepartmentDto;
            txtDeptName.Text = d?.DeptName;

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            cboDeptCode.Focus(); // 콤보박스에 입력 포커스 이동하고
            cboDeptCode.DroppedDown = true; // 드롭다운 리스트 열기
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

