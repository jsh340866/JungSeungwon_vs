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
            this.Load += 부서트리폼_Load;
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;
        }
        
        // 부서트리폼 Load
        private async void 부서트리폼_Load(object sender, EventArgs e)
        {
            // 서비스 호출해 트리 데이터소스 담기
            try
            {
                treeList1.DataSource = await new DeptService().TreeDataTableAsync();
            }
            // 문제 생기면 메시지 출력
            catch
            {
                MessageBox.Show("부서 정보를 불러오지 못했습니다.");
            }
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
