using DevExpress.XtraExport.Helpers;
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
    public partial class ParentDepartment : Form
    {
        ParentDepartmentDto Pdept => 그리드뷰.GetFocusedRow() as ParentDepartmentDto;
        public ParentDepartment()
        {
            InitializeComponent();
            this.닫기.Click += 닫기btn_Click;
            this.삭제.Click += 삭제btn_Click;
            this.수정.Click += 수정btn_Click;
            this.추가.Click += 추가btn_Click;
            this.자료변환.Click += 자료변환btn_Click;
            this.Paint += 테두리_Paint;

            GridUpdate();
        }

        private void GridUpdate()
        {
            그리드컨트롤.DataSource = new ParentDepartmentRepository().GetAll();
        }

        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            // 폼 테두리
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }



        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void 삭제btn_Click(object sender, EventArgs e)
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

            Delete D = new Delete(title, msg);
            D.ShowDialog();

            if (D.DialogResult == DialogResult.OK)
            {
                try
                {
                    new ParentDepartmentRepository().Delete(Pdept.ParentDeptId);
                    MessageBox.Show("삭제가 완료되었습니다.");
                    GridUpdate();
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

        private void 수정btn_Click(object sender, EventArgs e)
        {
            if (그리드뷰.GetFocusedRow() == null)
            {
                MessageBox.Show("수정할 상위부서를 선택해주세요.");
                return;
            }


            ParentEditForm E = new ParentEditForm(Pdept);
            E.ShowDialog();

            if (E.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("상위부서가 수정되었습니다.");
                GridUpdate();
                return;
            }


        }

        private void 추가btn_Click(object sender, EventArgs e)
        {
            ParentAdd A = new ParentAdd();
            A.ShowDialog();

            if (A.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("상위부서가 추가되었습니다.");
                GridUpdate();
                return;
            }
        }

        private void 자료변환btn_Click(object sender, EventArgs e)
        {
            new ExcelTransfer().ExportExcel("상위부서", 그리드뷰);
        }
    }
}


