using System;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class ParentAdd : Form
    {
        public ParentAdd()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.저장btn.Click += 저장btn_Click;
            this.취소btn.Click += 취소btn_Click;
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            FormDesign.Line(e, Width, Height);
        }

        // 저장
        private async void 저장btn_Click(object sender, EventArgs e)
        {
            // 입력한 상위부서 메모리에 담기
            ParentDepartmentDto pdept = new ParentDepartmentDto
            {
                ParentDeptName = 상위부서명txt.Text,
                ParentDeptCode = 상위부서코드txt.Text,
                ParentMemo = string.IsNullOrWhiteSpace(메모txt.Text) ? null : 메모txt.Text
            };
          
            // 입력값 db에 저장
            저장btn.Enabled = false;
            try
            {
                await new ParentService().AddAsync(pdept);
                MessageBox.Show("상위부서가 추가되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 서비스에 예외처리한 BusinessException 걸리면 메시지 출력
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            // 나머지 에러 발생시 메시지 출력
            catch (Exception)
            {
                MessageBox.Show("상위부서 추가 중 오류가 발생하였습니다.");
            }
            finally { 저장btn.Enabled = true; }
        }
        
        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
