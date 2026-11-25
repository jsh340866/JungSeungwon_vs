using System;
using System.Windows.Forms;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

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
                treeList1.KeyFieldName = "NodeId";
                treeList1.ParentFieldName = "ParentId";
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
            FormDesign.Line(e, Width, Height);
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
