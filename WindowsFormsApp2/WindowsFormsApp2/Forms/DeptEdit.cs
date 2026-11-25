using System;
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
            this.취소btn.Click += 취소btn_Click;
            this.저장btn.Click += 저장btn_Click;
            this.상위부서코드cbo.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;
            
            // 수정 전 기존값 박스에 담기
            부서코드txt.Text = dept.DeptCode;
            부서명txt.Text = dept.DeptName; 
            메모txt.Text = dept.Memo;
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
                상위부서코드cbo.DisplayMember = nameof(DepartmentDto.DeptCode);
                상위부서코드cbo.ValueMember = nameof(DepartmentDto.DeptId);
                상위부서코드cbo.DataSource = await new DeptService().GetParentAsync();

                // 기존값으로 상위부서가 있는경우 상위부서를 선택
                if (this.pdeptId != 0)
                {
                    상위부서코드cbo.SelectedValue = this.pdeptId;
                }
                // 기존값에 상위부서가 없으면 선택을 비워둠
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

        // 상위부서코드에 따라 상위부서명 변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentDto P = 상위부서코드cbo.SelectedItem as DepartmentDto;
            상위부서명txt.Text = P?.DeptName;
        }

        // 부서 수정 저장 
        private async void 저장btn_Click(object sender, EventArgs e)
        { 
            // 수정 값 메모리에 담기
            DepartmentDto dept = new DepartmentDto
            {
                DeptId = this.deptId,
                DeptCode = 부서코드txt.Text,
                DeptName = 부서명txt.Text,
                ParentDeptId = (int?)상위부서코드cbo.SelectedValue,
                Memo = string.IsNullOrWhiteSpace(메모txt.Text) ? null : 메모txt.Text
            };

            // 수정 값 DB에 저장, 연속 클릭방지 Enabled = false;
            저장btn.Enabled = false;
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
            // 마지막에 다시 true로 변경
            finally { 저장btn.Enabled = true; }
        }
    }
}
