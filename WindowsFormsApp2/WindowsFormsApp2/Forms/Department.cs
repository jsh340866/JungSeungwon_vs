using DevExpress.CodeParser;
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
        
        private DepartmentDto Row => 부서그리드.GetFocusedRow() as DepartmentDto;

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
        // 그리드 갱신
        private void GridUpdate()
        {
            try
            {
                상위부서그리드컨트롤.DataSource = new ParentDepartmentRepository().GetAll();
                부서그리드컨트롤.DataSource = new DepartmentRepository().GetAll();
            }
            catch (Exception ex) 
            {
                Logger.Instance.Error("목록 갱신 실패", ex);
                MessageBox.Show("목록 갱신을 실패하였습니다.");
            }
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 부서 삭제
        private void 삭제btn_Click(object sender, EventArgs e)
        {
            if (Row == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }

            string title = "부서 삭제";
            string msg = "부서코드: " + Row.DeptCode + "\n" +
                         "부서명: " + Row.DeptName + "\n\n" +
                         "삭제하시겠습니까?";
            Delete D = new Delete(title, msg);
            D.ShowDialog();

            if (D.DialogResult == DialogResult.OK)
            {
                try
                {
                    new DepartmentRepository().Delete(Row.DeptId);
                    MessageBox.Show("삭제되었습니다.");
                    GridUpdate();
                }
                // 외래키 제약조건 위반시 예외처리
                catch (SqlException ex) when (ex.Number == 547)
                {
                    // 상위부서가 존재하는 부서는 외래키 제약조건위반으로 메시지띄움
                    if (ex.Message.Contains("fk_department_parent"))
                    {
                        MessageBox.Show("소속 사원이 존재하는 부서는 삭제할 수 없습니다.");
                        return;
                    }
                }
                // 나머지 제약조건 위반시 예외처리 및 로그
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
            DeptAdd A = new DeptAdd();
            A.ShowDialog();

            if (A.DialogResult == DialogResult.OK)
            {
                GridUpdate();
            }
        }

        // 부서 수정
        private void 수정btn_Click(object sender, EventArgs e)
        {
            if (Row == null)
            {
                MessageBox.Show("수정할 부서를 선택해주세요.");
                return;
            }

            DeptEdit E = new DeptEdit(Row);
            E.ShowDialog();

            if (E.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("부서가 변경 되었습니다.");
                GridUpdate();
                return;
            }

        }

        // 상위부서
        private void 상위부서btn_Click(object sender, EventArgs e)
        {
            ParentDepartment P = new ParentDepartment();
            P.ShowDialog();

            // 상위부서가 추가,삭제,수정 될 경우 그리드갱신
            if (P.DialogResult == DialogResult.OK) 
            {
                GridUpdate();
            }

        }
        // 트리
        private void 트리btn_Click(object sender, EventArgs e)
        {
            DeptTree T = new DeptTree();
            T.ShowDialog();
        }
        // 차트
        private void 차트btn_Click(object sender, EventArgs e)
        {
            DeptChart C = new DeptChart();
            C.ShowDialog();
        }
    }
}
