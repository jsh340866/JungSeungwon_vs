using System;
using System.Drawing;
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
            this.저장.Click += 저장btn_Click;
            this.취소.Click += 취소btn_Click;
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 저장
        private async void 저장btn_Click(object sender, EventArgs e)
        {
            // 입력한 상위부서 메모리에 담기
            ParentDepartmentDto pdept = new ParentDepartmentDto
            {
                ParentDeptName = 상위부서명.Text,
                ParentDeptCode = 상위부서코드.Text,
                ParentMemo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text
            };
          
            // 입력값 db에 저장
            저장.Enabled = false;
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
            finally { 저장.Enabled = true; }
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
