using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;
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
        private void 저장btn_Click(object sender, EventArgs e)
        {
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(상위부서코드.Text)) { MessageBox.Show("상위부서코드는 필수기재사항입니다."); return; }
            if (string.IsNullOrWhiteSpace(상위부서명.Text)) { MessageBox.Show("상위부서명은 필수기재사항입니다."); return; }

            // 입력한 상위부서 메모리에 담기
            ParentDepartmentDto pdept = new ParentDepartmentDto
            {
                ParentDeptName = 상위부서명.Text,
                ParentDeptCode = 상위부서코드.Text,
                ParentMemo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text
            };
          
            // 상위부서값 db에 저장
            try
            {
                new ParentDepartmentRepository().Save(pdept);
                this.DialogResult = DialogResult.OK;
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 추가시 상위부서코드 중복일 경우 메시지 띄움
                if (ex.Message.Contains("UQ_ParentDepartment"))
                {
                    MessageBox.Show("이미 존재하는 상위부서코드입니다.");
                    return;
                }
                // 나머지 중복값 에러시 메시지 띄움
                else
                {
                    MessageBox.Show("중복된 값이 존재합니다.");
                    return;
                }
            }
            // 나머지 에러 예외처리 및 로그
            catch (Exception ex)
            {
                Logger.Instance.Error("상위부서 추가 실패 ParentDeptCode=" + 상위부서코드.Text, ex);
                MessageBox.Show("상위부서 추가 중 오류가 발생하였습니다.\n" + ex.Message);
            }
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
