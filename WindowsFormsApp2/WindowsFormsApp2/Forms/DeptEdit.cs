using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptEdit : Form
    {
        private readonly int deptId;
        private readonly int pdeptId;

        public DeptEdit(DepartmentDto dept)
        {
            InitializeComponent();
            this.Load += 부서수정폼_Load;
            this.Paint += 테두리_Paint;
            this.취소.Click += 취소btn_Click;
            this.저장.Click += 저장btn_Click;
            this.cbo상위부서코드.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;
            
            // 수정 전 기존값 박스에 담기
            부서코드.Text = dept.DeptCode;
            부서명.Text = dept.DeptName; 
            메모.Text = dept.Memo;
            this.deptId = dept.DeptId;
            this.pdeptId = (int?)dept.ParentDeptId == null? 0 : (int)dept.ParentDeptId ;
        }

        // 부서수정폼 Load
        private async void 부서수정폼_Load(object sender, EventArgs e)
        {
            // 서비스로 호출해 상위부서코드 데이터소스에 상위부서전체 조회 담기
            try
            {
                // 콤보박스 드롭리스트
                cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
                cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
                cbo상위부서코드.DataSource = await new ParentService().GetAllAsync();

                // 기존값으로 상위부서가 있는경우 상위부서를 선택
                if (this.pdeptId != 0)
                {
                    cbo상위부서코드.SelectedValue = this.pdeptId;
                }
                // 기존값에 상위부서가 없으면 선택을 비워둠
                else
                {
                    cbo상위부서코드.SelectedIndex = -1;
                }
            }
            catch
            {
                MessageBox.Show("부서 정보를 불러오지 못했습니다.");
            }
            
        }
        
        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.FromArgb(171,171,171),1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 상위부서코드에 따라 상위부서명 변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentDepartmentDto P = cbo상위부서코드.SelectedItem as ParentDepartmentDto;
            상위부서명.Text = P?.ParentDeptName;
        }

        // 부서 수정 저장 
        private async void 저장btn_Click(object sender, EventArgs e)
        { 
            // 수정 값 메모리에 담기
            DepartmentDto dept = new DepartmentDto
            {
                DeptId = this.deptId,
                DeptCode = 부서코드.Text,
                DeptName = 부서명.Text,
                ParentDeptId = (int?)cbo상위부서코드.SelectedValue,
                Memo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text
            };
            // 수정 값 DB에 저장
            저장.Enabled = false;
            try
            {
                await new DeptService().EditAsync(dept);
                MessageBox.Show("부서가 수정되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 서비스에 예외처리한 BusinessException 걸리면 메시지 출력
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 에러 발생시 메시지 출력
            catch
            {
                MessageBox.Show("부서 수정 중 오류가 발생했습니다.");
            }
            finally { 저장.Enabled = true; }
        }
    }
}
