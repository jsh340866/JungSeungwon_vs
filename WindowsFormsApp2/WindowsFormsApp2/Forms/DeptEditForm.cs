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
    public partial class DeptEditForm : Form
    {
        private int deptId;


        public DeptEditForm(Department dept)
        {
            InitializeComponent();
            txtDeptCode.Text = dept.DeptCode;
            txtDeptName.Text = dept.DeptName; 
            txtMemo.Text = dept.Memo;

            this.deptId = dept.DeptId;

        }

        private void DeptEditForm_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.FromArgb(171,171,171),1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // 부서 수정 저장 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeptCode.Text) || string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("부서코드, 부서명은 필수기재사항입니다.");
                return;
            }

            Department dept = new Department();
            dept.DeptId = this.deptId;
            dept.DeptCode = txtDeptCode.Text;
            dept.DeptName = txtDeptName.Text;
            dept.Memo = string.IsNullOrWhiteSpace(txtMemo.Text) ? null : txtMemo.Text;


            try
            {
                new DepartmentRepository().Update(dept);
                this.DialogResult = DialogResult.OK;
            }
            catch(SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("이미 존재하는 부서코드입니다.");
            }

            catch (Exception ex)
            {
                Logger.Instance.Error("부서 수정 실패 DeptId=" + dept.DeptId, ex);
                MessageBox.Show("수정 중 오류가 발생했습니다.\n" + ex.Message);
            }


        }
    }
}
