using DevExpress.XtraEditors;
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
        private readonly int deptId;

        // 매개변수를 클래스 형태로 받을 생성자
        public DeptEditForm(DepartmentDto dept)
        {
            InitializeComponent();
            this.Paint += 테두리;
            this.취소클릭.Click += 취소_Click;
            this.저장클릭.Click += 저장_Click;



            // 수정 전 기존 값
            부서코드.Text = dept.DeptCode;
            부서명.Text = dept.DeptName; 
            메모.Text = dept.Memo;
            this.deptId = dept.DeptId;

            cbo상위부서코드.DataSource = new ParentDepartmentRepository().GetAll();
            cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
            cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
        }

        

        private void 테두리(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.FromArgb(171,171,171),1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        

        private void 취소_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // 부서 수정 저장 
        private void 저장_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(부서코드.Text)) 
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(부서명.Text))
            {
                MessageBox.Show("부서명을 입력해주세요.");
                return;
            }

            DepartmentDto dept = new DepartmentDto
            {
                DeptId = this.deptId,
                DeptCode = 부서코드.Text,
                DeptName = 부서명.Text,
                Memo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text
            };


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
        
        private void cbo상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
