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
    public partial class EmpAdd : Form
    {
        private readonly List<DepartmentDto> dept = new DepartmentRepository().GetAll();

        public EmpAdd()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.취소.Click += 취소btn_Click;
            this.저장.Click += 저장btn_Click;
            this.남.Click += 남자체크_Check;
            this.여.Click += 여자체크_Check;
            this.휴대전화.Leave += 휴대전화_하이폰규칙_Leave;
            this.cbo상위부서코드.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;
            this.cbo부서코드.SelectedIndexChanged += 부서코드_SelectedIndexChanged;


            // 상위부서코드 -> 부서코드 콤보박스 드롭박스리스트 연동
            cbo부서코드.DisplayMember = nameof(DepartmentDto.DeptCode);
            cbo부서코드.ValueMember = nameof(DepartmentDto.DeptId);

            cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
            cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
            cbo상위부서코드.DataSource = new ParentDepartmentRepository().GetAll();
                        
        }

        // 부서코드에 매칭되는 부서명 자동입력
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentDepartmentDto p = cbo상위부서코드.SelectedItem as ParentDepartmentDto;
            상위부서명.Text = p?.ParentDeptName;

            cbo부서코드.DataSource = dept.Where(d => p != null && d.ParentDeptId == p.ParentDeptId).ToList();
            
        }
        private void 부서코드_SelectedIndexChanged(Object sender, EventArgs e)
        {
            DepartmentDto d = cbo부서코드.SelectedItem as DepartmentDto;
            부서명.Text = d?.DeptName;
        }

        private void 테두리_Paint(object sender, PaintEventArgs e)
        {   
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

        }

        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 사원 추가 저장
        private void 저장btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbo상위부서코드.Text)) { MessageBox.Show("상위부서를 선택해주세요."); return; }
            if (string.IsNullOrWhiteSpace(cbo부서코드.Text)) { MessageBox.Show("부서코드를 선택해주세요"); return; }
            if (string.IsNullOrWhiteSpace(사원코드.Text)) { MessageBox.Show("사원코드를 입력해주세요.");  return; }
            if (string.IsNullOrWhiteSpace(사원명.Text)) { MessageBox.Show("사원명을 입력해주세요."); return; }
            if (string.IsNullOrWhiteSpace(로그인ID.Text)) { MessageBox.Show("로그인ID를 입력해주세요"); return;}
            if (string.IsNullOrWhiteSpace(비밀번호.Text)) {MessageBox.Show("비밀번호를 입력해주세요"); return;}
            

            if (!Rule.isPasswordCheck(비밀번호.Text))
            {
                MessageBox.Show("비밀번호는 영문,숫자 포함 8자 이상입니다.");
                return;
            }

            // 이메일이 비어있지 않고 Rule에서 만든 이메일 규칙이 false일때 메시지 박스 띄움
            if (!string.IsNullOrWhiteSpace(이메일.Text) && !Rule.isEmailCheck(이메일.Text))
            {
                MessageBox.Show("이메일을 다시 입력해주세요.");
                return;
            }

            EmployeeDto emp = new EmployeeDto
            {
                DeptId = (int)cbo부서코드.SelectedValue,
                EmpCode = 사원코드.Text,
                EmpName = 사원명.Text,
                LoginId = 로그인ID.Text,
                Password = 비밀번호.Text,
                Gender = 남.Checked ? "남" : 여.Checked ? "여" : null,
                Position = string.IsNullOrWhiteSpace(직위.Text) ? null : 직위.Text,
                EmpType = string.IsNullOrWhiteSpace(고용형태.Text) ? null : 고용형태.Text,
                Phone = string.IsNullOrWhiteSpace(휴대전화.Text) ? null : 휴대전화.Text,
                Email = string.IsNullOrWhiteSpace(이메일.Text) ? null : 이메일.Text,
                MessengerId = string.IsNullOrWhiteSpace(메신저ID.Text) ? null : 메신저ID.Text,
                Memo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text
            };

            try
            {
                new EmployeeRepository().Save(emp);
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
                Logger.Instance.Error("사원 추가 실패 EmpCode=" + 사원코드.Text, ex);
                MessageBox.Show("사원 추가 중 오류가 발생했습니다.\n\n" + ex.Message);
            }
        }

        private void 남자체크_Check(object sender, EventArgs e)
        {
            if (남.Checked == true)
            {
                여.Checked = false;
            }
        }

        private void 여자체크_Check(object sender, EventArgs e)
        {
            if (여.Checked == true)
            {
                남.Checked = false;
            }

        }

        // 휴대폰번호 하이폰 규칙
        private void 휴대전화_하이폰규칙_Leave(object sender, EventArgs e)
        {
            string digits = new string(휴대전화.Text.Where(char.IsDigit).ToArray());
            if (digits.Length >= 11)
            {
                휴대전화.Text = digits.Insert(7, "-").Insert(3, "-");
            }
        }
    }
}
