using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Services;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptTree : Form
    {


        public DeptTree()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;


            treeList1.DataSource = new DeptService().TreeDataTable();
        }

        // 폼 테두리
        public void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using(var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);
            }
        }
        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
