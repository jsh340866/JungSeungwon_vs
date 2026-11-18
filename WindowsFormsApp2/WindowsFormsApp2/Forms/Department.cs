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
    public partial class Department : Form
    {

        // DataGridView 현재행 가져오기
        private DepartmentDto Dept => 부서그리드.GetFocusedRow() as DepartmentDto;
        private ParentDepartmentDto Pdept => 상위부서그리드.GetFocusedRow() as ParentDepartmentDto;

        private readonly ParentDepartment P = new ParentDepartment();

        public Department()
        {
            InitializeComponent();
            this.닫기버튼.Click += 닫기;
            this.수정버튼.Click += 부서수정;
            this.추가버튼.Click += 부서추가;
            this.삭제버튼.Click += 부서삭제;
            this.Paint += 부서폼_테두리;
            this.상위부서버튼.Click += 상위부서버튼_Click;

            그리드갱신();
        }

        // 폼 테두리
        private void 부서폼_테두리(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void 그리드갱신()
        {
            상위부서그리드컨트롤.DataSource = new ParentDepartmentRepository().GetAll();
            부서그리드컨트롤.DataSource = new DepartmentRepository().GetAll();
        }
        
        private void 닫기(object sender, EventArgs e)
        {
            this.Close();
        }

        // 부서 삭제
        private void 부서삭제(object sender, EventArgs e)
        {
            if (부서그리드.GetFocusedRow() == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }

            

            string title = "부서 삭제";
            string msg = "부서코드: " + Dept.DeptCode + "\n" +
                         "부서명: " + Dept.DeptName + "\n\n" +
                         "삭제하시겠습니까?";
            Delete deleteForm = new Delete(title, msg);
            deleteForm.ShowDialog();

            if (deleteForm.DialogResult == DialogResult.OK)
            {
                
                try
                {
                    new DepartmentRepository().Delete(Dept.DeptId);
                    MessageBox.Show("삭제되었습니다.");
                    그리드갱신();
                }
                catch(SqlException ex) when (ex.Number == 547)
                {
                    MessageBox.Show("소속 사원이 있는 부서는 삭제할 수 없습니다.");
                }

                catch (Exception ex) 
                {
                    Logger.Instance.Error("부서 삭제 실패", ex);
                    MessageBox.Show("삭제 중 오류가 발생했습니다.\n" + ex.Message);
                }
                          
            }

        }

      

        // 부서 추가 
        private void 부서추가(object sender, EventArgs e)
        {
            DeptAdd daf = new DeptAdd();
            daf.ShowDialog();

            if (DialogResult.OK == daf.DialogResult)
            {
                그리드갱신();
            }
        }

        // 부서 수정
        private void 부서수정(object sender, EventArgs e)
        {
            if (부서그리드.GetFocusedRow() == null)
            {
                MessageBox.Show("수정할 부서를 선택해주세요.");
                return;
            }


            DeptEdit edit = new DeptEdit(Dept);
            edit.ShowDialog();

            if (edit.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("부서가 변경 되었습니다.");
                그리드갱신();
                return;
            }

        }

        private void 상위부서버튼_Click(object sender, EventArgs e)
        {
            P.ShowDialog();

            if (DialogResult.OK == P.DialogResult) 
            {
                그리드갱신();
            }

        }

        private void 트리_Click(Object sender, EventArgs e)
        {

        }

    }
}
