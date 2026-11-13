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
    public partial class DeptAddForm : Form
    {
        public DeptAddForm()
        {
            InitializeComponent();
        }

        private void DeptAddForm_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 부서 추가 저장 버튼
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeptCode.Text) || string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("부서코드, 부서명은 필수기재사항입니다");
                return;
            }

            Department dept = new Department();
            dept.DeptName = txtDeptName.Text;
            dept.DeptCode = txtDeptCode.Text;
            dept.Memo = string.IsNullOrWhiteSpace(txtMemo.Text) ? null : txtMemo.Text;

            try
            {
                new DepartmentRepository().Save(dept);
                this.DialogResult = DialogResult.OK;

            }
            catch (SqlException ex) when (ex.Number == 2627) 
            {
                MessageBox.Show("중복된 부서코드 입니다. 다시 입력해주세요.");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("부서 추가 실패 DeptCode=" + dept.DeptCode, ex);
                MessageBox.Show("부서 추가 중 오류가 발생하였습니다.\n" + ex.Message);

            }
        }
    }
}
