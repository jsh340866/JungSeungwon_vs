using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class EmpAdd : Form
    {
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
            // 부서코드 콤보박스에 보일 값, 실제 값을 미리지정
            cbo부서코드.DisplayMember = nameof(DepartmentDto.DeptCode);
            cbo부서코드.ValueMember = nameof(DepartmentDto.DeptId);

            // 상위부서코드 콤보박스에 값 지정
            cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
            cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
            cbo상위부서코드.DataSource = new ParentService().GetAll();
            
        }

        // 상위부서코드 콤보박스에 따라 상위부서명과 부서코드 콤보박스 리스트 변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentDepartmentDto p = cbo상위부서코드.SelectedItem as ParentDepartmentDto;
            상위부서명.Text = p?.ParentDeptName;

            // 부서코드 콤보박스 리스트 상위부서코드에 따라 변경
            List<DepartmentDto> dept = new DeptService().GetAll();
            cbo부서코드.DataSource = dept.Where(d => p != null && d.ParentDeptId == p.ParentDeptId).ToList();
        }

        // 부서코드 콤보박스에 따라 부서명 변경
        private void 부서코드_SelectedIndexChanged(Object sender, EventArgs e)
        {
            DepartmentDto d = cbo부서코드.SelectedItem as DepartmentDto;
            부서명.Text = d?.DeptName;
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {   
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 사원 추가 저장
        private void 저장btn_Click(object sender, EventArgs e)
        {

            // 사원정보 메모리에 담기
            EmployeeDto emp = new EmployeeDto
            {
                // 부서ID를 선택하지않으면 null 대신 0을 넣어서 null 대신 사용
                // DeptId는 not null 이라 null이 들어가면 에러발생
                DeptId = (int?)cbo부서코드.SelectedValue == null ? 0 : (int)cbo부서코드.SelectedValue,
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
            // 사원정보 db에 저장
            try
            {
                new EmpService().Add(emp);
                MessageBox.Show("사원 정보가 저장되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 서비스에 예외처리한 BusinessException 걸리면 메시지 출력
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 에러발생시 메시지 출력
            catch 
            {
                MessageBox.Show("사원 추가 중 오류가 발생했습니다.");
            }
        }

        // 남자체크
        private void 남자체크_Check(object sender, EventArgs e)
        {
            if (남.Checked == true)
            {
                여.Checked = false;
            }
        }

        // 여자체크
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
            휴대전화.Text = Rule.PhoneRule(휴대전화.Text);
        }
    }
}
