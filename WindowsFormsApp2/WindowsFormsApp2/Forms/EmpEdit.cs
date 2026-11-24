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
        private readonly List<DepartmentDto> dept = new DeptService().GetAll();
        
        public EmpEdit(EmployeeDto emp)
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.취소.Click += 취소btn_Click;
            this.저장.Click += 저장btn_Click;
            this.cbo상위부서코드.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;
            this.cbo부서코드.SelectedIndexChanged += 부서코드_SelectedIndexChanged;
            this.남.Click += 남자체크_Check;
            this.여.Click += 여자체크_Check;
            this.휴대전화.Leave += 휴대전화_하이폰규칙_Leave;

            // 수정 전 기존 값 박스에 담기
            사원코드.Text = emp.EmpCode;
            사원명.Text = emp.EmpName;
            직위.Text = emp.Position;
            고용형태.Text = emp.EmpType;
            휴대전화.Text = emp.Phone;
            이메일.Text = emp.Email;
            메신저ID.Text = emp.MessengerId;
            메모.Text = emp.Memo;
            this.EmpId = emp.EmpId;
            if (emp.Gender == "남")
            {
                남.Checked = true;
            }
            else if (emp.Gender == "여")
            {
                여.Checked = true;
            }

            // Byte로 db에 저장된 Photo를 Image로 받기
            if(emp.Photo != null)
            {
                // ImageHelper에서 만든 메서드로 db에 저장된 Byte, Image로 변환
                이미지.Image = ImageHelper.ByteToImage(emp.Photo);
            }

            // 상위부서코드 -> 부서코드 콤보박스 드랍다운리스트 연동
            // 부서코드 콤보박스 보일값, 실제값 미리 지정
            cbo부서코드.DisplayMember = nameof(DepartmentDto.DeptCode);
            cbo부서코드.ValueMember = nameof(DepartmentDto.DeptId);

            // 상위부서코드 콤보박스 보일값, 실제값 지정
            cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
            cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
            cbo상위부서코드.DataSource = new ParentService().GetAll();

            // 수정 선택한 사원Id로 부서dto 값 찾기
            DepartmentDto department = dept.FirstOrDefault(d => d.DeptId == emp.DeptId);

            if (department?.ParentDeptId != null)
            {
                // 찾은 부서dto로 상위부서코드 실제값 표기
                cbo상위부서코드.SelectedValue = department.ParentDeptId.Value;
                // 부서코드 실제값 표기
                cbo부서코드.SelectedValue = emp.DeptId;
            }
            // 상위부서가 없을시 빈값으로 지정
            else
            {
                cbo상위부서코드.SelectedIndex = -1;
            }
        }

        // 상위부서코드 콤보박스 변경시 상위부서명 자동변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentDepartmentDto p = cbo상위부서코드.SelectedItem as ParentDepartmentDto;
            상위부서명.Text = p?.ParentDeptName;

            // 부서코드 콤보박스 드랍다운리스트
            // 상위부서코드 콤보박스에 따라 부서코드 콤보박스 리스트를 변경
            cbo부서코드.DataSource = dept.Where(d => p != null && d.ParentDeptId == p.ParentDeptId).ToList();
        }

        // 부서코드 콤보박스 변경시 부서명 자동변경
        private void 부서코드_SelectedIndexChanged(object sender, EventArgs e)
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

        // 남자체크
        private void 남자체크_Check(object sender, EventArgs e)
        {
            if (남.Checked) { 여.Checked = false; }
        }

        // 여자체크
        private void 여자체크_Check(object sender, EventArgs e)
        {
            if (여.Checked) { 남.Checked = false; }
        }


        // 사원 수정 저장
        private void 저장btn_Click(object sender, EventArgs e)
        {
            // 수정값 메모리에 담기
            EmployeeDto emp = new EmployeeDto
            {
                DeptId = (int?)cbo부서코드.SelectedValue == null ? 0 : (int)cbo부서코드.SelectedValue,
                EmpCode = 사원코드.Text,
                EmpName = 사원명.Text,
                Gender = 남.Checked ? "남" : 여.Checked ? "여" : null,
                Position = string.IsNullOrWhiteSpace(직위.Text) ? null : 직위.Text,
                EmpType = string.IsNullOrWhiteSpace(고용형태.Text) ? null : 고용형태.Text,
                Phone = string.IsNullOrWhiteSpace(휴대전화.Text) ? null : 휴대전화.Text,
                Email = string.IsNullOrWhiteSpace(이메일.Text) ? null : 이메일.Text,
                MessengerId = string.IsNullOrWhiteSpace(메신저ID.Text) ? null : 메신저ID.Text,
                Memo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text,
                Photo = 이미지.Image == null ? null : ImageHelper.ImageToByte(이미지.Image),
                EmpId = this.EmpId
            };
            // 수정값 서비스에 요청
            try
            {
                new EmpService().Edit(emp);
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
        }

        // 휴대전화 번호 하이폰 규칙
        private void 휴대전화_하이폰규칙_Leave(object sender, EventArgs e)
        {
            휴대전화.Text = Rule.PhoneRule(휴대전화.Text);
        }
    }
}

