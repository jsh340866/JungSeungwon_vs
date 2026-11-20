using DevExpress.Spreadsheet;
using DevExpress.Utils.MVVM;
using DevExpress.XtraSpreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Repository;

namespace WindowsFormsApp2.Forms
{

    
    public partial class EmpMutiAdd : Form
    {

        public EmpMutiAdd()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.취소.Click += 취소btn_Click;


            var sheet = spreadsheetControl1.ActiveWorksheet;

            string[] head = { "부서코드", "사원코드", "사원명", "로그인ID", "비밀번호", "직위", "고용형태", "성별", "휴대전화", "이메일", "메신저ID", "메모" };
            int c = 0;
            foreach( string s in head)
            {
                sheet.Cells[0, c].Value = s;
                c += 1;
            }
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen,0,0,Width-1,Height-1);
            }
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 저장
        private void 저장btn_Click(object sender, EventArgs e)
        {
            var sheet = spreadsheetControl1.ActiveWorksheet;

            //필수값 지정
            sheet.GetDataRange();



        }

    }
}
