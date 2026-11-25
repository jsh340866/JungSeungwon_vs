using DevExpress.Spreadsheet;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;


namespace WindowsFormsApp2.Forms
{
    public partial class EmpMultiAdd : Form
    {
        
        private Worksheet Sheet => spreadsheetControl1.ActiveWorksheet;

        public EmpMultiAdd()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.취소.Click += 취소btn_Click;


            // 엑셀시트에서 헤더로 사용할 사원컬럼 목록
            string[] head = { "부서코드", "사원코드", "사원명", "로그인ID", "비밀번호", "직위",
                              "고용형태", "성별", "휴대전화", "이메일", "메신저ID", "메모"};
           
            // 반복문으로 헤드에 하나씩 넣기
            int i = 0;
            foreach ( string s in head)
            {
                Sheet.Cells[0, i].Value = s;
                i += 1;
            }

            // 엑셀시트 헤더 디자인
            CellRange header = Sheet.Range.FromLTRB(0, 0, head.Length - 1, 0);
            header.Borders.SetAllBorders(Color.Empty, BorderLineStyle.None);
            header.FillColor = Color.FromArgb(171, 171, 171);
            header.Font.Color = Color.White;
            header.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            header.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            Sheet.Columns[8].NumberFormat = "@";
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
        private async void 저장btn_Click(object sender, EventArgs e)
        {

            // db에 입력한 사원정보 저장
            저장.Enabled = false;
            try
            {
                await new EmpService().MultiAddAsync(Sheet);
                MessageBox.Show("사원 정보가 저장되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 서비스에 BusinessException 예외처리에 걸리는 경우 메시지 출력
            catch(BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 에러 발생시 메시지 출력
            catch 
            {
                MessageBox.Show("사원 추가 중 오류가 발생하였습니다.");
            }
            finally { 저장.Enabled = true; }
        }
    }
}
