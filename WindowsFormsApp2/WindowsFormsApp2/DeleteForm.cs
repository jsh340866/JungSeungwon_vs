using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class DeleteForm : Form
    {
        public DeleteForm(string title, string msg)
        {
            InitializeComponent();
            label1.Text = title;
            label2.Text = msg;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeDeleteForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteForm_Paint(object sender, PaintEventArgs e)
        {
            // 폼 테두리
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1); 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 삭제 버튼 클릭 시, form1에서 처리하도록 DialogResult를 OK로 설정
            this.DialogResult = DialogResult.OK;

        }
    }
}
