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
            this.닫기.Click += 닫기btn_Click;

            // TreeList 데이터소스에 넣을 데이터테이블 제작
            // 테이블 내 컬럼
            DataTable dt = new DataTable();
            dt.Columns.Add("NodeId", typeof(string));   // 노드ID
            dt.Columns.Add("ParentId", typeof(string)); // 부모노드ID
            dt.Columns.Add("NodeCode", typeof(string)); // 노드코드
            dt.Columns.Add("NodeName", typeof(string)); // 노드명

            // 컬럼에 넣을 로우값 상위부서,부서,사원 순서
            // db의 각 Id들은 identity 자동증가로 겹칠수 있음 "P,D,E" 접두사를 붙여구분
            foreach (var p in pdept) 
            { 
                // P+Id, null(상위부서라 더 상위가 없음), 상위부서코드, 상위부서명
                dt.Rows.Add("P" + p.ParentDeptId, DBNull.Value, p.ParentDeptCode, p.ParentDeptName);
            }
            foreach (var d in dept)
            {
                // D+Id, null(상위가 없는경우 체크) + P+상위부서ID, 부서코드, 부서명
                dt.Rows.Add("D" + d.DeptId, d.ParentDeptId == null ? (object)DBNull.Value : "P" + d.ParentDeptId, d.DeptCode, d.DeptName);
            }
            foreach (var e in emp)
            {
                // E+Id, D+부서Id, 사원코드, 사원명
                dt.Rows.Add("E" + e.EmpId, "D" + e.DeptId, e.EmpCode, e.EmpName); 
            }

            treeList1.DataSource = dt;


        }

        public void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);
            }
        }

        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
