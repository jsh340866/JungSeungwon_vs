using DevExpress.XtraEditors.TextEditController.Win32;
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
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class EmpEdit : Form
    {

        private readonly int EmpId;
 
        private readonly List<DepartmentDto> dept = new DepartmentRepository().GetAll();
        
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
                // ImageHelper에서 만든 메서드로 db에 저장된 바이트 이미지, 이미지로 변환
                이미지.Image = ImageHelper.ByteToImage(emp.Photo);
            }

            // 상위부서코드 -> 부서코드 콤보박스 드랍다운리스트 연동
            // 부서코드 콤보박스 보일값, 실제값 미리 지정
            cbo부서코드.DisplayMember = nameof(DepartmentDto.DeptCode);
            cbo부서코드.ValueMember = nameof(DepartmentDto.DeptId);
            // 상위부서코드 콤보박스 보일값, 실제값 지정
            cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
            cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
            cbo상위부서코드.DataSource = new ParentDepartmentRepository().GetAll();

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
            // 상위부서의 ParentDeptId와 부서DB의 외래키로 받은 ParentDeptId가 같은 부서만 List로 DataSource에 담음
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
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(cbo상위부서코드.Text)) { MessageBox.Show("상위부서코드를 선택해주세요."); return; }
            if (string.IsNullOrWhiteSpace(cbo부서코드.Text)) { MessageBox.Show("부서코드를 선택해주세요."); return; }
            if (string.IsNullOrWhiteSpace(사원코드.Text)) { MessageBox.Show("사원코드를 입력해주세요."); return; }
            if (string.IsNullOrWhiteSpace(사원명.Text)) { MessageBox.Show("사원명을 입력해주세요."); return; }
            // 이메일 규칙
            if (!string.IsNullOrWhiteSpace(이메일.Text) && !Rule.isEmailCheck(이메일.Text))
            {
                MessageBox.Show("이메일을 다시 입력해주세요.");
                return;
            }

            // 수정값 메모리에 담기
            EmployeeDto emp = new EmployeeDto
            {
                DeptId = (int)cbo부서코드.SelectedValue,
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

            try
            {
                new EmployeeRepository().Update(emp);
                this.DialogResult = DialogResult.OK;
            }


            // 유니크키 중복으로 Sql 에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 사원코드 중복시 메시지 박스 띄움
                if (ex.Message.Contains("UQ_Employee_EmpCode"))
                {
                    MessageBox.Show("이미 사용중인 사원코드입니다.");
                    return;
                }
                // 로그인Id 중복시 메시지 박스 띄움
                else if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    MessageBox.Show("이미 존재하는 로그인ID입니다.");
                    return;
                }
                // 그 외 중복 에러시 메시지 박스 띄움
                else
                {
                    MessageBox.Show("중복된 값이 존재합니다.");
                    return;
                }
            }
            // 나머지 에러 발생시 예외처리 및 로그
            catch (Exception ex)
            {
                Logger.Instance.Error("사원 수정 실패 EmpId=" + this.EmpId, ex);
                MessageBox.Show("사원 정보 저장 중 오류가 발생했습니다.\n\n" + ex.Message);
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

