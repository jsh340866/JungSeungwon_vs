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
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();

            // 컬럼 자동 증가 끄기
            DataGridView.AutoGenerateColumns = false;

            // DataGridView 데이터 조회
            DataGridView.DataSource = new DepartmentRepository().GetAll();
        }

        // 테두리
        private void DepartmentForm_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 부서 삭제
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }


            string title = "부서 삭제";
            string msg = "부서코드: " + DataGridView.SelectedCells[0].Value.ToString() + "\n" +
                         "부서명: " + DataGridView.SelectedCells[1].Value.ToString() + "\n\n" +
                         "삭제하시겠습니까?";
            DeleteForm deleteForm = new DeleteForm(title, msg);
            deleteForm.ShowDialog();

            if (deleteForm.DialogResult == DialogResult.OK)
            {
                
                try
                {
                    var dept = DataGridView.SelectedRows[0].DataBoundItem as Department;
                    new DepartmentRepository().Delete(dept.DeptId);
                    MessageBox.Show("삭제되었습니다.");
                    DataGridView.DataSource = new DepartmentRepository().GetAll();
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

        
        // DataGridView 테두리
        private void DataGridView_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }


        // 부서 추가 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DeptAddForm daf = new DeptAddForm();
            daf.ShowDialog();

            if (DialogResult.OK == daf.DialogResult)
            {
                DataGridView.DataSource = new DepartmentRepository().GetAll();
            }
        }

        // 부서 수정
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("부서를 선택해주세요.");
                return;
            }

            Department dept = DataGridView.SelectedRows[0].DataBoundItem as Department;
            DeptEditForm edit = new DeptEditForm(dept);
            edit.ShowDialog();

            if (edit.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("부서가 변경 되었습니다.");
                DataGridView.DataSource = new DepartmentRepository().GetAll();
                return;
            }

            



            


        }
    }
}
