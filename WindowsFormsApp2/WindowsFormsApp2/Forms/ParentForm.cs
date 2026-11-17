using DevExpress.XtraGrid;
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
    public partial class ParentForm : Form
    {
        ParentDepartmentDto Pdept => gridView1.GetFocusedRow() as ParentDepartmentDto;
        public ParentForm()
        {
            InitializeComponent();
            this.닫기버튼.Click += 닫기버튼_Click;
            this.삭제버튼.Click += 삭제버튼_Click;
            this.수정버튼.Click += 수정버튼_Click;
            this.추가버튼.Click += 추가버튼_Click;
            this.상위부서버튼.Click += 상위부서버튼_Click;
            this.Paint += 테두리;

            그리드갱신();
        }

        private void 그리드갱신()
        {
            gridControl1.DataSource = new ParentDepartmentRepository().GetAll();
        }

        private void 테두리(object sender, PaintEventArgs e)
        {
            // 폼 테두리
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }



        private void 닫기버튼_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void 삭제버튼_Click(object sender, EventArgs e)
        {
            if (Pdept == null)
            {
                MessageBox.Show("삭제할 상위부서를 선택해주세요.");
                return;
            }


            string title = "상위 부서 삭제";
            string msg = "상위부서코드: " + Pdept.ParentDeptCode + "\n" +
                      "상위부서명: " + Pdept.ParentDeptName + "\n\n" +
                      "삭제하시겠습니까?";

            DeleteForm D = new DeleteForm(title, msg);
            D.ShowDialog();

            if (D.DialogResult == DialogResult.OK)
            {
                try
                {
                    new ParentDepartmentRepository().Delete(Pdept.ParentDeptId);
                    MessageBox.Show("삭제가 완료되었습니다.");
                    그리드갱신();
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    MessageBox.Show("소속 부서가 있는 상위부서는 삭제할 수 없습니다.");
                }

                catch (Exception ex)
                {
                    Logger.Instance.Error("상위부서 삭제 실패 ParentDeptId =" + Pdept.ParentDeptId);
                    MessageBox.Show("상위부서 삭제 중 오류가 발생하였습니다.\n", ex.Message);
                }

            }

        }

        private void 수정버튼_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("수정할 상위부서를 선택해주세요.");
                return;
            }


            ParentEditForm F = new ParentEditForm(Pdept);
            F.ShowDialog();

            if (F.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("상위부서가 수정되었습니다.");
                그리드갱신();
                return;
            }


        }

        private void 추가버튼_Click(object sender, EventArgs e)
        {
            ParentAddForm F = new ParentAddForm();
            F.ShowDialog();

            if (F.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("상위부서가 추가되었습니다.");
                그리드갱신();
                return;
            }
        }

        private void 상위부서버튼_Click(object sender, EventArgs e)
        {

        }




    }
}


