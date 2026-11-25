using DevExpress.XtraCharts;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptChart : Form
    {
        public DeptChart()
        {
            InitializeComponent();
            this.Load += 부서차트폼_Load;
            this.Paint += 테두리_Paint;
            this.닫기btn.Click += 닫기btn_Click;
        }

        // 부서차트폼 Load
        private async void 부서차트폼_Load(object sender, EventArgs e)
        {
            // 서비스 호출해 차트 데이터소스에 데이터 담기
            try
            {
                chartControl1.SeriesTemplate.ArgumentDataMember = "ParentDeptName_X";   // X축
                chartControl1.SeriesTemplate.ValueDataMembers.AddRange("Count_Y");      // Y축
                chartControl1.SeriesTemplate.SeriesDataMember = "DeptName_S";           // 시리즈
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
            FormDesign.Line(e, Width, Height);
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
