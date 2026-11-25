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
    public partial class EmpEdit : Form
    {

        private readonly int EmpId;
        private readonly int DeptId;
        private List<DepartmentDto> dept;
        
        public EmpEdit(EmployeeDto emp)
        {
            InitializeComponent();
            this.Load += 사원수정폼_Load;
            this.Paint += 테두리_Paint;
            this.취소btn.Click += 취소btn_Click;
            this.저장btn.Click += 저장btn_Click;
            this.상위부서코드cbo.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;
            this.부서코드cbo.SelectedIndexChanged += 부서코드_SelectedIndexChanged;
            this.남check.Click += 남자체크_Check;
            this.여check.Click += 여자체크_Check;
            this.휴대전화txt.Leave += 휴대전화_하이픈규칙_Leave;

            // 수정 전 기존 값 박스에 담기
            사원코드txt.Text = emp.EmpCode;
            사원명txt.Text = emp.EmpName;
            직위txt.Text = emp.Position;
            고용형태txt.Text = emp.EmpType;
            휴대전화txt.Text = emp.Phone;
            이메일txt.Text = emp.Email;
            메신저IDtxt.Text = emp.MessengerId;
            메모txt.Text = emp.Memo;
            this.EmpId = emp.EmpId;
            this.DeptId = emp.DeptId;
            if (emp.Gender == "남")
            {
                남check.Checked = true;
            }
            else if (emp.Gender == "여")
            {
                여check.Checked = true;
            }

            // Byte로 db에 저장된 Photo를 Image로 받기
            if(emp.Photo != null)
            {
                // ImageHelper에서 만든 메서드로 db에 저장된 Byte, Image로 변환
                이미지image.Image = ImageHelper.ByteToImage(emp.Photo);
            }

        }
        
        // 사원수정폼 Load
        private async void 사원수정폼_Load(object sender, EventArgs e)
        {
            try
            {
                // 상위부서코드 데이터소스를 넣으면 SelectedIndexChanged가 바로 실행되므로 그 전에 dept를 미리 담기
                dept = await new DeptService().GetAllAsync();

                // 상위부서코드 -> 부서코드 콤보박스 드랍다운리스트 연동
                // 부서코드 콤보박스 보일값, 실제값 미리 지정
                부서코드cbo.DisplayMember = nameof(DepartmentDto.DeptCode);
                부서코드cbo.ValueMember = nameof(DepartmentDto.DeptId);

                // 상위부서코드 콤보박스 보일값, 실제값 지정
                상위부서코드cbo.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
                상위부서코드cbo.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
                상위부서코드cbo.DataSource = await new ParentService().GetAllAsync();

                // 수정 선택한 사원Id로 부서dto 값 찾기
                DepartmentDto dto = dept.FirstOrDefault(d => d.DeptId == this.DeptId);

                if (dto?.ParentDeptId != null)
                {
                    // 찾은 부서dto로 상위부서코드 실제값 표기
                    상위부서코드cbo.SelectedValue = dto.ParentDeptId.Value;
                    // 부서코드 실제값 표기
                    부서코드cbo.SelectedValue = this.DeptId;
                }
                // 상위부서가 없을시 빈값으로 지정
                else
                {
                    상위부서코드cbo.SelectedIndex = -1;
                }
            }
            catch   
            {
                MessageBox.Show("부서 정보를 불러오지 못했습니다.");
            }
        }

        // 상위부서코드 콤보박스 변경시 상위부서명 자동변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentDepartmentDto p = 상위부서코드cbo.SelectedItem as ParentDepartmentDto;
            상위부서명txt.Text = p?.ParentDeptName;

            // 부서코드 콤보박스 드랍다운리스트
            // 상위부서코드 콤보박스에 따라 부서코드 콤보박스 리스트를 변경
            부서코드cbo.DataSource = dept.Where(d => p != null && d.ParentDeptId == p.ParentDeptId).ToList();
        }

        // 부서코드 콤보박스 변경시 부서명 자동변경
        private void 부서코드_SelectedIndexChanged(object sender, EventArgs e)
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

        // 남자체크
        private void 남자체크_Check(object sender, EventArgs e)
        {
            if (남check.Checked) { 여check.Checked = false; }
        }

        // 여자체크
        private void 여자체크_Check(object sender, EventArgs e)
        {
            if (여check.Checked) { 남check.Checked = false; }
        }


        // 사원 수정 저장
        private async void 저장btn_Click(object sender, EventArgs e)
        {
            // 수정값 메모리에 담기
            EmployeeDto emp = new EmployeeDto
            {
                DeptId = (int?)부서코드cbo.SelectedValue == null ? 0 : (int)부서코드cbo.SelectedValue,
                EmpCode = 사원코드txt.Text,
                EmpName = 사원명txt.Text,
                Gender = 남check.Checked ? "남" : 여check.Checked ? "여" : null,
                Position = string.IsNullOrWhiteSpace(직위txt.Text) ? null : 직위txt.Text,
                EmpType = string.IsNullOrWhiteSpace(고용형태txt.Text) ? null : 고용형태txt.Text,
                Phone = string.IsNullOrWhiteSpace(휴대전화txt.Text) ? null : 휴대전화txt.Text,
                Email = string.IsNullOrWhiteSpace(이메일txt.Text) ? null : 이메일txt.Text,
                MessengerId = string.IsNullOrWhiteSpace(메신저IDtxt.Text) ? null : 메신저IDtxt.Text,
                Memo = string.IsNullOrWhiteSpace(메모txt.Text) ? null : 메모txt.Text,
                Photo = 이미지image.Image == null ? null : ImageHelper.ImageToByte(이미지image.Image),
                EmpId = this.EmpId
            };

            // 서비스 호출해 수정값 저장, 연속클릭방지로 Enabled = false
            저장btn.Enabled = false;
            try
            {
                await new EmpService().EditAsync(emp);
                MessageBox.Show("사원 정보가 저장되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 서비스에 예외처리한 BusinessException 걸리면 메시지 출력
            catch (BusinessException ex) 
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 에러 발생시 예외처리
            catch 
            {
                MessageBox.Show("사원 정보 저장 중 오류가 발생했습니다.");
            }
            // 마지막에 클릭 다시 true
            finally { 저장btn.Enabled = true; }

        }

        // 휴대전화 번호 하이픈 규칙
        private void 휴대전화_하이픈규칙_Leave(object sender, EventArgs e)
        {
            휴대전화txt.Text = ValidationRule.PhoneRule(휴대전화txt.Text);
        }
    }
}

