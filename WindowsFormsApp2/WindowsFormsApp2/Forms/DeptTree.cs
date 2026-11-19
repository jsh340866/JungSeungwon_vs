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


            treeList1.DataSource = new DepartmentRepository().GetAll();
        }

        public void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);
            }
        }


    }
}
