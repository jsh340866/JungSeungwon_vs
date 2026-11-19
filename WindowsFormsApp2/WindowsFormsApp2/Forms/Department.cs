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

        private DepartmentDto Dept => 부서그리드.GetFocusedRow() as DepartmentDto;

        private readonly ParentDepartment P = new ParentDepartment();

        public Department()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;
            this.수정.Click += 수정btn_Click;
            this.추가.Click += 추가btn_Click;
            this.삭제.Click += 삭제btn_Click;
            this.상위부서.Click += 상위부서btn_Click;
            this.트리.Click += 트리btn_Click;
            this.차트.Click += 차트btn_Click;

            GridUpdate();
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void GridUpdate()
        {
            상위부서그리드컨트롤.DataSource = new ParentDepartmentRepository().GetAll();
            부서그리드컨트롤.DataSource = new DepartmentRepository().GetAll();
        }
        
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 부서 삭제
        private void 삭제btn_Click(object sender, EventArgs e)
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
                    GridUpdate();
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
        private void 추가btn_Click(object sender, EventArgs e)
        {
            DeptAdd daf = new DeptAdd();
            daf.ShowDialog();

            if (DialogResult.OK == daf.DialogResult)
            {
                GridUpdate();
            }
        }

        // 부서 수정
        private void 수정btn_Click(object sender, EventArgs e)
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
                GridUpdate();
                return;
            }

        }

        private void 상위부서btn_Click(object sender, EventArgs e)
        {
            P.ShowDialog();

            if (DialogResult.OK == P.DialogResult) 
            {
                GridUpdate();
            }

        }

        private void 트리btn_Click(object sender, EventArgs e)
        {
            DeptTree T = new DeptTree();
            T.ShowDialog();
        }
        
        private void 차트btn_Click(object sender, EventArgs e)
        {
            DeptChart C = new DeptChart();
            C.ShowDialog();
        }
    }
}
