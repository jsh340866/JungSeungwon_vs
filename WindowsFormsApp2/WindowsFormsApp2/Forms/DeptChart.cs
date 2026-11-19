using DevExpress.Charts.Native;
using DevExpress.XtraEditors.TextEditController.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptChart : Form
    {
        private readonly List<ParentDepartmentDto> pdept = new ParentDepartmentRepository().GetAll();
        private readonly List<DepartmentDto> dept = new DepartmentRepository().GetAll();
        private readonly List<EmployeeDto> emp = new EmployeeRepository().GetAll();


        public DeptChart()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;



            // 누적막대차트 데이터소스
            // 부서를 시리즈 기준으로 상위부서, 부서명, 사원수 값을 list에 담음
            var list = dept.Select(d => new
            {   
                // 차트 x축, 상위부서의 ParentDeptId 와 부서의 ParentDeptId가 같은 pdept의 ParentDeptName을 표시, 상위부서가 없으면 null
                ParentDeptName_X = pdept.FirstOrDefault(p => p.ParentDeptId == d.ParentDeptId)?.ParentDeptName,
                // 차트의 시리즈 기준, 부서명으로 표시
                DeptName_S = d.DeptName,
                // 차트 y축, 부서의 사원수, 같은 상위부서끼리 쌓임
                Count_Y = emp.Where(e => e.DeptId == d.DeptId).Count()
            });

            chartControl1.DataSource = list;



        }



        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
