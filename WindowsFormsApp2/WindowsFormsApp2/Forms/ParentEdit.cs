using System;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class ParentEditForm : Form
    {
        private readonly int ParentDeptId;
        public ParentEditForm(DepartmentDto dept)
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.저장btn.Click += 저장btn_Click;
            this.취소btn.Click += 취소btn_Click;

            // 수정 전 기존 값 텍스트박스에 담기
            this.ParentDeptId = dept.DeptId;
            상위부서코드txt.Text = dept.DeptCode;
            상위부서명txt.Text = dept.DeptName;
            상위메모txt.Text = dept.Memo;
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

        // 저장
        private async void 저장btn_Click(object sender, EventArgs e)
        {
            // 수정값 메모리에 담기
            DepartmentDto dept = new DepartmentDto
            {
                DeptId = this.ParentDeptId,
                DeptCode = 상위부서코드txt.Text,
                DeptName = 상위부서명txt.Text,
                Memo = string.IsNullOrWhiteSpace(상위메모txt.Text) ? null : 상위메모txt.Text
            };
            // 수정값 db에 저장 
            저장btn.Enabled = false;
            try
            {
                await new DeptService().EditAsync(dept);
                MessageBox.Show("상위부서가 수정되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 에러 발생시 예외처리 및 로그
            catch (Exception)
            {
                MessageBox.Show("상위부서 수정 중 오류가 발생하였습니다.");
            }
            finally { 저장btn.Enabled = true; }

        }
    }
}
