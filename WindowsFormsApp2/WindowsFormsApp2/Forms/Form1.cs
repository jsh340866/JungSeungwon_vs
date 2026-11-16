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


            // 삭제폼에서 DialogResult.OK를 받아 데이터 삭제 후 조회 갱신
            if (deleteForm.DialogResult == DialogResult.OK)
            {
                var emp = DataGridView.SelectedRows[0].DataBoundItem as EmployeeDto;
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
                var emp = DataGridView.SelectedRows[0].DataBoundItem as EmployeeDto;
                string LoginId = emp.LoginId;
                string Password = emp.Password;
                LoginInfoForm logininfoForm = new LoginInfoForm(LoginId, Password, emp.EmpId);
                logininfoForm.ShowDialog();

                // 로그인정보폼에서 DialogResult.OK를 받고 다시 조회 갱신
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

        // 비밀번호 "***"로 보이게
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
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
            EmployeeDto emp = DataGridView.SelectedRows[0].DataBoundItem as EmployeeDto;
            EmployeeEditForm editForm = new EmployeeEditForm(emp);
            editForm.ShowDialog();

            // 사원 수정폼 DialogResult.OK 확인 후 조회 갱신
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
        

        // 사원 추가폼 연결
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddForms addForm = new EmployeeAddForms();
            addForm.ShowDialog();

            // 사원 추가폼 DialogResult.OK 확인 후 조회 갱신
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


        // 부서폼 연결
        private void btnDept_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentForm = new DepartmentForm();
            departmentForm.ShowDialog();
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}