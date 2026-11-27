using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class EmpAdd : Form
    {

        private List<DepartmentDto> dept;
        public EmpAdd()
        {
            InitializeComponent();
            this.Load += 사원추가폼_Load;
            this.Paint += 테두리_Paint;
            this.취소btn.Click += 취소btn_Click;
            this.저장btn.Click += 저장btn_Click;
            this.남.Click += 남자체크_Check;
            this.여.Click += 여자체크_Check;
            this.휴대전화txt.Leave += 휴대전화_하이픈규칙_Leave;
            this.상위부서코드cbo.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;
            this.부서코드cbo.SelectedIndexChanged += 부서코드_SelectedIndexChanged;
        }

        // 사원추가폼 Load
        private async void 사원추가폼_Load(object sender, EventArgs e)
        {
            try
            {
                // 상위부서코드 데이터소스를 넣으면 SelecteIndexChanged가 바로 실행되므로 그 전에 dept를 먼저 담기
                dept = await new DeptService().GetAllAsync();

                // 상위부서코드 -> 부서코드 콤보박스 드롭박스리스트 연동
                // 부서코드 콤보박스에 보일 값, 실제 값을 미리지정
                부서코드cbo.DisplayMember = nameof(DepartmentDto.DeptCode);
                부서코드cbo.ValueMember = nameof(DepartmentDto.DeptId);

                // 상위부서코드 콤보박스에 값 지정
                상위부서코드cbo.DisplayMember = nameof(DepartmentDto.DeptCode);
                상위부서코드cbo.ValueMember = nameof(DepartmentDto.DeptId);
                상위부서코드cbo.DataSource = await new DeptService().GetAllAsync();
            }
            catch
            {
                MessageBox.Show("부서 정보를 불러오지 못했습니다.");
            }
        }


        // 상위부서코드 콤보박스에 따라 상위부서명과 부서코드 콤보박스 리스트 변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentDto p = 상위부서코드cbo.SelectedItem as DepartmentDto;
            상위부서명txt.Text = p?.DeptName;

            // 부서코드 콤보박스 리스트 상위부서코드에 따라 변경
            부서코드cbo.DataSource = dept.Where(d => p != null && d.ParentDeptId == p.ParentDeptId ).ToList();
        }

        // 부서코드 콤보박스에 따라 부서명 변경
        private void 부서코드_SelectedIndexChanged(Object sender, EventArgs e)
        {
            DepartmentDto d = 부서코드cbo.SelectedItem as DepartmentDto;
            부서명txt.Text = d?.DeptName;
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            FormDesign.Line(e, Width, Height);
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 사원 추가 저장
        private async void 저장btn_Click(object sender, EventArgs e)
        {
            // 사원정보 메모리에 담기
            EmployeeDto emp = new EmployeeDto
            {
                // 부서ID를 선택하지않으면 null 대신 0을 넣어서 null 대신 사용
                // DeptId는 not null 이라 null이 들어가면 에러발생
                DeptId = (int?)부서코드cbo.SelectedValue == null ? 0 : (int)부서코드cbo.SelectedValue,
                EmpCode = 사원코드txt.Text,
                EmpName = 사원명txt.Text,
                LoginId = 로그인IDtxt.Text,
                Password = 비밀번호txt.Text,
                Gender = 남.Checked ? "남" : 여.Checked ? "여" : null,
                Position = string.IsNullOrWhiteSpace(직위txt.Text) ? null : 직위txt.Text,
                EmpType = string.IsNullOrWhiteSpace(고용형태txt.Text) ? null : 고용형태txt.Text,
                Phone = string.IsNullOrWhiteSpace(휴대전화txt.Text) ? null : 휴대전화txt.Text,
                Email = string.IsNullOrWhiteSpace(이메일txt.Text) ? null : 이메일txt.Text,
                MessengerId = string.IsNullOrWhiteSpace(메신저IDtxt.Text) ? null : 메신저IDtxt.Text,
                Memo = string.IsNullOrWhiteSpace(메모txt.Text) ? null : 메모txt.Text
            };

            // 사원정보 db에 저장, 연속클릭방지 Enabled = false;
            저장btn.Enabled = false;
            try
            {
                await new EmpService().AddAsync(emp);
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
            // 마지막 true로 다시 허용
            finally{ 저장btn.Enabled = true; }
        }

        // 남자체크
        private void 남자체크_Check(object sender, EventArgs e)
        {
            if (남.Checked == true){ 여.Checked = false; }
        }

        // 여자체크
        private void 여자체크_Check(object sender, EventArgs e)
        {
            if (여.Checked == true){ 남.Checked = false; }
        }

        // 휴대폰번호 하이픈 규칙
        private void 휴대전화_하이픈규칙_Leave(object sender, EventArgs e)
        {
            휴대전화txt.Text = ValidationRule.PhoneRule(휴대전화txt.Text);
        }
    }
}
