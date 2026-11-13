using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 자동으로 열을 만들지 않고, 디자이너에서 만든 열 12개만 쓴다
            DataGridView.AutoGenerateColumns = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView.DataSource = new EmployeeRepository().GetAll();
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("사원 조회 실패", ex);
                MessageBox.Show("조회 중 오류가 발생했습니다.\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 사원을 선택하세요.");
                return;
            }
            string msg = "사원코드: " + DataGridView.SelectedRows[0].Cells[2].Value.ToString() + "\n" +
                         "사원명: " + DataGridView.SelectedRows[0].Cells[3].Value.ToString() + "\n" + "\n" +
                         "삭제하시겠습니까?";
            DeleteForm deleteForm = new DeleteForm("사원 삭제", msg);
            deleteForm.ShowDialog();

            if (deleteForm.DialogResult == DialogResult.OK)
            {
                var emp = DataGridView.SelectedRows[0].DataBoundItem as Employee;
                int empId = emp.EmpId;
                try
                {
                    new EmployeeRepository().Delete(empId);
                    MessageBox.Show("삭제되었습니다.");
                    DataGridView.DataSource = new EmployeeRepository().GetAll();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("사원 삭제 실패 EmpId=" + empId, ex);
                    MessageBox.Show("삭제 중 오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }


        private void btnLoginInfo_Click(object sender, EventArgs e)
        {

            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("로그인 정보를 확인할 사원을 선택하세요.");
                return;
            }
            else
            {
                var emp = DataGridView.SelectedRows[0].DataBoundItem as Employee;
                string LoginId = emp.LoginId;
                string Password = emp.Password;
                LoginInfoForm logininfoForm = new LoginInfoForm(LoginId, Password, emp.EmpId);
                logininfoForm.ShowDialog();

                if (logininfoForm.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        MessageBox.Show("로그인 정보가 저장되었습니다.");
                        DataGridView.DataSource = new EmployeeRepository().GetAll();
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Error("로그인정보 저장 후 목록 갱신 실패 EmpId=" + emp.EmpId, ex);
                        MessageBox.Show("로그인 정보 저장 중 오류가 발생했습니다.\n" + ex.Message);
                    }
                }
            }

        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 폼 테두리 
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 비밀번호 "*******" 처리
            if (e.ColumnIndex == colPassword.Index && e.Value != null)
            {
                e.Value = new string('*', 8);
                e.FormattingApplied = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("수정할 사원을 선택하세요.");
                return;
            }
            Employee emp = DataGridView.SelectedRows[0].DataBoundItem as Employee;
            EmployeeEditForm editForm = new EmployeeEditForm(emp);
            editForm.ShowDialog();

            if (editForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show("사원 정보가 저장되었습니다.");
                    DataGridView.DataSource = new EmployeeRepository().GetAll();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("사원 수정 후 목록 갱신 실패 EmpId=" + emp.EmpId, ex);
                    MessageBox.Show("사원 정보 저장 중 오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }
        class MyPanel : Panel
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                // 패널의 배경색을 변경합니다.
                this.BackColor = Color.LightBlue;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddForms addForm = new EmployeeAddForms();
            addForm.ShowDialog();

            if (addForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show("사원 정보가 추가 되었습니다.");
                    DataGridView.DataSource = new EmployeeRepository().GetAll();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("사원 추가 후 목록 갱신 실패", ex);
                    MessageBox.Show("사원 정보 추가 중 오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentForm = new DepartmentForm();
            departmentForm.ShowDialog();
        }
    }
}