using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(1106, 303);

            // 자동으로 열을 만들지 않고, 디자이너에서 만든 열 12개만 쓴다
            DataGridView.AutoGenerateColumns = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView.DataSource = new EmployeeRepository().GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("조회 중 오류가 발생했습니다.\n" + ex.Message);
            }
        }


        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (DataGridView.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("삭제할 사원을 선택하세요.");
        //        return;
        //    }
        //    var row = DataGridView.SelectedRows[0];
        //    int empId = (int)row.Cells[0].Value;
        //    var result = MessageBox.Show("선택한 사원을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo);
        //    if (result == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            new EmployeeRepository().Delete(empId);
        //            MessageBox.Show("사원이 삭제되었습니다.");
        //            btnSearch_Click(sender, e); // 삭제 후 목록 갱신
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("삭제 중 오류가 발생했습니다.\n" + ex.Message);
        //        }
        //    }
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 사원을 선택하세요.");
                return;
            }
            string msg = "사원코드: " + DataGridView.SelectedRows[0].Cells[2].Value.ToString() + "\n" +
                         "사원명: " + DataGridView.SelectedRows[0].Cells[3].Value.ToString() + "\n" + "\n" +
                         "삭제하시겠습니까?";
            DeleteForm deleteForm = new DeleteForm("사원 삭제", msg);
            deleteForm.ShowDialog();
        }

        private void DataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    class MyPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // 패널의 배경색을 변경합니다.
            this.BackColor = Color.LightBlue;
        }
    }
}
