using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Services;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptChart : Form
    {
        public DeptChart()
        {
            InitializeComponent();
            this.Load += 부서차트폼_Load;
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;
        }

        // 부서차트폼 Load
        private async void 부서차트폼_Load(object sender, EventArgs e)
        {
            // 서비스 호출해 차트 데이터소스에 데이터 담기
            try
            {
                chartControl1.DataSource = await new DeptService().ChartAsync();
            }
            catch
            {
                MessageBox.Show("부서 정보를 불러오지 못했습니다.");
            }
            
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
