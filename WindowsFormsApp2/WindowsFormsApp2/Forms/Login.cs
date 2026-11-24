using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Load += 로그인_Load;
            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.닫기.Click += 닫기btn_Click;
        }

        // 저장된 로그인ID를 불러와 박스에 담기
        private void 로그인_Load(object sender, EventArgs e)
        {
            로그인ID.Text = Properties.Settings.Default.SavedLoginId;
            아이디기억.Checked = !string.IsNullOrWhiteSpace(로그인ID.Text);

            // 체크박스 체크되있으면 비밀번호, 아니라면 로그인ID에 커서 위치       
            ActiveControl = 아이디기억.Checked ? 비밀번호 : 로그인ID;
        }


        // 폼 테두리
        private void 테두리_Paint(object sensor, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 닫기
        private void 닫기btn_Click(object sensor, EventArgs e)
        {
            this.Close();
        }

        // 저장(로그인)
        private async void 저장btn_Click(object sensor, EventArgs e)
        {
            
            저장.Enabled = false;
            try
            {
                await new EmpService().LoginAsync(로그인ID.Text, 비밀번호.Text);

                // 아이디기억.체크박스 체크시 입력한 로그인ID 저장
                Properties.Settings.Default.SavedLoginId = 아이디기억.Checked ? 로그인ID.Text : "";
                Properties.Settings.Default.Save();

                this.DialogResult = DialogResult.OK;
            }
            catch(BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch
            {
                MessageBox.Show("로그인 중 오류가 발생했습니다.");
            }
            finally { 저장.Enabled = true; }

        }



    }

}

