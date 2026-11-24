using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class LoginInfo : Form
    {
        private readonly int EmpId;
        public LoginInfo(string loginId, string password, int EmpId)
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;
            this.저장.Click += 저장btn_Click;


            // 수정 전 기존값 텍스트박스에 담기
            로그인ID.Text = loginId;
            비밀번호.Text = password;
            this.EmpId = EmpId;
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }


        // 로그인정보 저장
        private async void 저장btn_Click(object sender, EventArgs e)
        {
            string loginid = 로그인ID.Text;
            string password = 비밀번호.Text;
            int empId = this.EmpId;

            // 수정한 로그인정보 db에 저장
            저장.Enabled = false;
            try
            {
                await new EmpService().LoginInfoEditAsync(loginid, password, empId);
                MessageBox.Show("로그인 정보가 저장되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch(BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 에러 발생시 예외처리 및 로그
            catch
            {
                MessageBox.Show("로그인 정보 업데이트 중 오류가 발생했습니다. ");
               
            }
            finally { 저장.Enabled = false; }
        }
    }
}
