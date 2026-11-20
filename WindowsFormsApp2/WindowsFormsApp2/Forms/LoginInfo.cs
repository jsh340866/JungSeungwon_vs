using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Repository;
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
        private void 저장btn_Click(object sender, EventArgs e)
        {
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(로그인ID.Text)) { MessageBox.Show("로그인ID를 입력해주세요."); return;} 
            if (string.IsNullOrWhiteSpace(비밀번호.Text)) { MessageBox.Show("비밀번호를 입력해주세요."); return;}

            // Rule에서 만든 비밀번호 규칙 넣기
            if (!Rule.isPasswordCheck(비밀번호.Text)) { MessageBox.Show("비밀번호는 영문, 숫자 포함 8자 이상입니다."); return;}

            string loginid = 로그인ID.Text;
            string password = 비밀번호.Text;
            int empId = this.EmpId;

            // 수정한 로그인정보 db에 저장
            try
            {
                new EmployeeRepository().UpdateLoginInfo(loginid, password, empId);
                this.DialogResult = DialogResult.OK;
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch(SqlException ex) when (ex.Number == 2627)
            {
                // 수정한 로그인ID가 중복일 경우 메시지 띄움
                if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    MessageBox.Show("이미 사용중인 로그인ID 입니다.");
                    return;
                }
                // 그 외의 중복에러가 발생시 메시지 띄움
                else
                {
                    MessageBox.Show("중복된 값이 있습니다.");
                    return;
                }
            }
            // 나머지 에러 발생시 예외처리 및 로그
            catch (Exception ex)
            {
                Logger.Instance.Error("로그인 정보 수정 실패 EmpId=" + empId, ex);
                MessageBox.Show("로그인 정보 업데이트 중 오류가 발생했습니다: " + ex.Message);
               
            }
        }
    }
}
