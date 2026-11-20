using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class ParentEditForm : Form
    {
        private readonly int ParentDeptId;
        public ParentEditForm(ParentDepartmentDto pdept)
        {
            InitializeComponent();

            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.취소.Click += 취소btn_Click;

            // 수정 전 기존 값 텍스트박스에 담기
            this.ParentDeptId = pdept.ParentDeptId;
            상위부서코드박스.Text = pdept.ParentDeptCode;
            상위부서명박스.Text = pdept.ParentDeptName;
            상위메모박스.Text = pdept.ParentMemo;
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

        // 저장
        private void 저장btn_Click(object sender, EventArgs e)
        {
            // 필수값 지정
            if (string.IsNullOrWhiteSpace(상위부서명박스.Text)){MessageBox.Show("상위부서명은 필수기재사항입니다.");return;}
            if (string.IsNullOrWhiteSpace(상위부서코드박스.Text)){MessageBox.Show("상위부서코드는 필수기재사항입니다.");return;}

            // 수정값 메모리에 담기
            ParentDepartmentDto pdept = new ParentDepartmentDto
            {
                ParentDeptId = this.ParentDeptId,
                ParentDeptCode = 상위부서코드박스.Text,
                ParentDeptName = 상위부서명박스.Text,
                ParentMemo = string.IsNullOrWhiteSpace(상위메모박스.Text) ? null : 상위메모박스.Text
            };
            // 수정값 db에 저장 
            try
            {
                new ParentDepartmentRepository().Update(pdept);
                this.DialogResult = DialogResult.OK;
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (SqlException ex) when (ex.Number == 2627)
            {
                // 상위부서코드가 중복값일 경우 메시지 띄움
                if (ex.Message.Contains("UQ_ParentDeptCode"))
                {
                    MessageBox.Show("이미 존재하는 상위부서코드입니다.");
                    return;
                }
                // 그 외 중복값이 있을 경우 메시지 띄움
                else
                {
                    MessageBox.Show("중복된 값이 존재합니다.");
                    return;
                }
            }
            // 나머지 에러 발생시 예외처리 및 로그
            catch (Exception ex)
            {
                Logger.Instance.Error("상위부서 수정 실패 ParentDeptId=" + this.ParentDeptId, ex);
                MessageBox.Show("상위부서 수정 중 오류가 발생하였습니다.\n" + ex.Message);
            }

        }
    }
}
