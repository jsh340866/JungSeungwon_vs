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

namespace WindowsFormsApp2.Forms
{
    public partial class Delete : Form
    {
        // 생성자
        public Delete(string title, string msg)
        {
            InitializeComponent();
            this.취소.Click += 취소btn_Click;
            this.삭제.Click += 삭제btn_Click;
            this.Paint += 테두리_Paint;


            제목.Text = title;
            메시지.Text = msg;

        }

        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            // 폼 테두리
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1); 
            }
        }

        private void 삭제btn_Click(object sender, EventArgs e)
        {
            // 삭제 버튼 클릭 시, form1에서 처리하도록 DialogResult를 OK로 설정
            this.DialogResult = DialogResult.OK;

        }
    }
}
