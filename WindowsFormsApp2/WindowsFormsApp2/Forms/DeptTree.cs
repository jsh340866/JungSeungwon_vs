using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Repository;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptTree : Form
    {

        private readonly List<ParentDepartmentDto> pdept = new ParentDepartmentRepository().GetAll();
        private readonly List<DepartmentDto> dept = new DepartmentRepository().GetAll();
        private readonly List<EmployeeDto> emp = new EmployeeRepository().GetAll();


        public DeptTree()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;


            DataTable dt = new DataTable();
            dt.Columns.Add("NodeId", typeof(string));
            dt.Columns.Add("PartendId", typeof(string));
            dt.Columns.Add("NodeType", typeof(string));
            dt.Columns.Add("NodeName", typeof(string));

            foreach (var p in pdept)
                dt.Rows.Add("P" + p.ParentDeptId, DBNull.Value, "상위부서", p.ParentDeptName);

            foreach (var d in dept)
                dt.Rows.Add("D" + d.DeptId,
                               d.ParentDeptId == null ? (object)DBNull.Value : "P" + d.ParentDeptId,
                               "부서", d.DeptName);

            foreach (var e in emp)
                dt.Rows.Add("E" + e.EmpId, "D" + e.DeptId, "사원", e.EmpName);

            treeList1.KeyFieldName = "NodeId";
            treeList1.ParentFieldName = "ParentId";
            treeList1.DataSource = dt;


        }

        public void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }
    }
}
