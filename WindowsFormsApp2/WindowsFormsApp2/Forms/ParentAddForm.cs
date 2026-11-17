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
    public partial class ParentAddForm : Form
    {
        public ParentAddForm()
        {
            InitializeComponent();
            this.Paint += 테두리;
            this.저장버튼.Click += 저장버튼_Click;
            this.취소버튼.Click += 취소버튼_Click;

        }

        private void 테두리(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void 저장버튼_Click(object sender, EventArgs e)
        {
            ParentDepartmentDto pdept = new ParentDepartmentDto
            {
                ParentDeptName = 상위부서명박스.Text,
                ParentDeptCode = 상위부서코드박스.Text,
                ParentMemo = string.IsNullOrWhiteSpace(상위메모박스.Text) ? null : 상위메모박스.Text
            };

            if (string.IsNullOrWhiteSpace(pdept.ParentDeptName))
            {
                MessageBox.Show("상위부서명은 필수기재사항입니다.");
                return;
            }
            if (string.IsNullOrWhiteSpace(pdept.ParentDeptCode))
            {
                MessageBox.Show("상위부서코드는 필수기재사항입니다.");
                return;
            }
            try
            {
                new ParentDepartmentRepository().Save(pdept);
                this.DialogResult = DialogResult.OK;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                if (ex.Message.Contains("UQ_ParentDepartment"))
                {
                    MessageBox.Show("이미 존재하는 상위부서코드입니다.");
                    return;
                }
                else
                {
                    MessageBox.Show("중복된 값이 존재합니다.");
                    return;
                }
            }

            catch (Exception ex)
            {
                Logger.Instance.Error("상위부서 추가 실패 ParentDeptCode=" + 상위부서코드박스.Text, ex);
                MessageBox.Show("상위부서 추가 중 오류가 발생하였습니다.\n" + ex.Message);
            }

        }

        private void 취소버튼_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
