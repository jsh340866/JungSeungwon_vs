using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.Utils.MVVM;
using DevExpress.XtraCharts;
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
using WindowsFormsApp2.Utils;


namespace WindowsFormsApp2.Forms
{


    public partial class EmpMutiAdd : Form
    {
        private Worksheet Sheet => spreadsheetControl1.ActiveWorksheet;

        public EmpMutiAdd()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.취소.Click += 취소btn_Click;


            // spreadsheet에서 헤더로 사용할 사원컬럼 목록
            string[] head = { "부서코드", "사원코드", "사원명", "로그인ID", "비밀번호", "직위",
                              "고용형태", "성별", "휴대전화", "이메일", "메신저ID", "메모"};
           
            // 반복문으로 헤드 컬럼에 하나씩 넣기
            int i = 0;
            foreach ( string s in head)
            {
                Sheet.Cells[0, i].Value = s;
                i += 1;
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
            // 데이터입력 범위지정, 처음부터 입력한 행까지
            CellRange range = Sheet.GetDataRange();
            // 시트에 입력한 범위까지 데이터테이블 컬럼 만들기
            DataTable dt = Sheet.CreateDataTable(range, true);
            // 만들어진 데이터테이블에 시트에 입력된 데이터 넣기
            DataTableExporter exporter = Sheet.CreateDataTableExporter(range, dt, true);
            exporter.Export();

            try
            {
                new EmployeeRepository().SaveSheet(dt);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("다중 사원 추가 저장 실패", ex);
                MessageBox.Show("사원 추가가 실패했습니다.");
            }








        }

    }
}
