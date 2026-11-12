using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EmployeeEditForm : Form
    {

        int Empid;
        public EmployeeEditForm(Employee emp)
        {
            InitializeComponent();
            // emp 객체의 데이터를 폼 컨트롤에 표시


            var deptCodes = new EmployeeRepository().GetAll().Select(e => e.DeptCode).Distinct().ToList();

            foreach (var v in deptCodes)
            {
                cboDeptCode.Items.Add(v);
            }

            cboDeptCode.Text = emp.DeptCode;
            txtDeptName.Text = emp.DeptName;
            txtEmpCode.Text = emp.EmpCode;
            txtEmpName.Text = emp.EmpName;
            txtPosition.Text = emp.Position;
            txtEmpType.Text = emp.EmpType;
            txtPhone.Text = emp.Phone;
            txtEmail.Text = emp.Email;
            txtMessengerId.Text = emp.MessengerId;
            txtMemo.Text = emp.Memo;
            this.Empid = emp.EmpId;

            if (emp.Gender == "남")
            {
                man.Checked = true;
                
            }
            else if (emp.Gender == "여")
            {
                woman.Checked = true;
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeEditForm_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void man_CheckedChanged(object sender, EventArgs e)
        {
            if (man.Checked) { woman.Checked = false; }
        }

        private void woman_CheckedChanged(object sender, EventArgs e)
        {
            if (woman.Checked) { man.Checked = false; }
        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpCode.Text) || string.IsNullOrWhiteSpace(txtEmpName.Text) || string.IsNullOrWhiteSpace(cboDeptCode.Text))
            {
                MessageBox.Show("사원코드, 사원이름, 부서코드는 필수 입력 항목입니다.");
                return;
            }
            else
            {

                try
                {
                    Employee emp = new Employee();
                    emp.DeptCode = cboDeptCode.Text;
                    emp.EmpCode = txtEmpCode.Text;
                    emp.EmpName = txtEmpName.Text;
                    emp.Gender = man.Checked ? "남" : woman.Checked ? "여" : null;
                    emp.Position = string.IsNullOrWhiteSpace(txtPosition.Text) ? null : txtPosition.Text;
                    emp.EmpType = string.IsNullOrWhiteSpace(txtEmpType.Text) ? null : txtEmpType.Text; 
                    emp.Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text; 
                    emp.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;
                    emp.MessengerId = string.IsNullOrWhiteSpace(txtMessengerId.Text) ? null : txtMessengerId.Text;
                    emp.Memo = string.IsNullOrWhiteSpace(txtMemo.Text) ? null : txtMemo.Text;
                    emp.EmpId = this.Empid;

                    new EmployeeRepository().UpdateEmployee(emp);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("사원 정보 저장 중 오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }

        private void cboDeptCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dict = new EmployeeRepository().DeptCodeName();
            txtDeptName.Text = dict[cboDeptCode.Text];

        }
    }
}
