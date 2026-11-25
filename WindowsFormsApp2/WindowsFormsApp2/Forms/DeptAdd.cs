using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptAdd : Form
    {
        private readonly DepartmentDto dept = new DepartmentDto();
        public DeptAdd()
        {
            InitializeComponent();
            this.Load += 부서추가폼_Load;
            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.취소.Click += 취소btn_Click;
            this.cbo상위부서코드.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;
        }

        // 부서추가폼 Load 이벤트 
        private async void 부서추가폼_Load(object sender, EventArgs e)
        {
            // 폼이 열릴때 서비스를 호출해 상위부서코드 콤보박스 데이터소스를 받음
            try
            {
                // 상위부서코드 콤보박스 드롭리스트
                cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
                cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
                cbo상위부서코드.DataSource = await new ParentService().GetAllAsync();

                // 기본은 빈값
                cbo상위부서코드.SelectedIndex = -1;
            }
            // 서비스 조회 실패시 예외처리
            catch
            {
                MessageBox.Show("부서 정보를 불러오지 못했습니다.");
            }
            
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

        // 상위부서코드 콤보박스 선택에 따라 상위부서명 변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentDepartmentDto p = cbo상위부서코드.SelectedItem as ParentDepartmentDto;
            상위부서명.Text = p?.ParentDeptName;
        }

        // 부서 추가 저장 버튼
        private async void 저장btn_Click(object sender, EventArgs e)
        {
            // 수정 값 메모리 저장
            dept.DeptName = 부서명.Text;
            dept.DeptCode = 부서코드.Text;
            dept.ParentDeptId = (int?)cbo상위부서코드.SelectedValue;
            dept.Memo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text;

            // 서비스 호출, 비동기처리로 버튼 두번 눌리는 것 방지
            저장.Enabled = false;
            try
            {
                await new DeptService().AddAsync(dept);
                MessageBox.Show("부서 정보가 저장되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 서비스에 예외처리한 BusinessException 걸리면 메시지 출력
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 예외 발생시 메시지 출력
            catch 
            {
                MessageBox.Show("부서 추가 중 오류가 발생하였습니다.");
            }
            // 마지막에 저장버튼 다시 허용
            finally { 저장.Enabled = true; }
        }

        
    }
}
