using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.Utils.MVVM;
using DevExpress.XtraCharts;
using DevExpress.XtraSpreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            //엑셀시트에서 헤더로 사용할 사원컬럼 목록
            string[] head = { "부서코드", "사원코드", "사원명", "로그인ID", "비밀번호", "직위",
                              "고용형태", "성별", "휴대전화", "이메일", "메신저ID", "메모"};
           
            // 반복문으로 헤드에 하나씩 넣기
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
            // 시트에 입력한 컬럼 구조 데이트테이블에 넣기
            DataTable dt = Sheet.CreateDataTable(range, true);
            // 만들어진 데이터테이블에 시트에 입력된 데이터 넣기
            DataTableExporter exporter = Sheet.CreateDataTableExporter(range, dt, true);
            exporter.Export();


            // 아무값도 입력하지 않을시 메시지 출력
            if(dt.Rows.Count == 0 ) { MessageBox.Show("입력된 데이터가 없습니다."); return; }

            // 필수값 지정, dt에 받은 행을 한줄씩 확인
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int row = i + 2;

                if (string.IsNullOrWhiteSpace(dr["부서코드"].ToString())) { MessageBox.Show(row + "행의 부서코드를 입력해주세요."); return; };
                if (string.IsNullOrWhiteSpace(dr["사원코드"].ToString())) { MessageBox.Show(row + "행의 사원코드를 입력해주세요."); return; };
                if (string.IsNullOrWhiteSpace(dr["사원명"].ToString())) { MessageBox.Show(row + "행의 사원명을 입력해주세요."); return; };
                if (string.IsNullOrWhiteSpace(dr["로그인ID"].ToString())) { MessageBox.Show(row + "행의 로그인ID를 입력해주세요."); return; };
                if (string.IsNullOrWhiteSpace(dr["비밀번호"].ToString())) { MessageBox.Show(row + "행의 비밀번호를 입력해주세요."); return; }
            }

            // db에 입력한 사원정보 저장
            try
            {
                new EmployeeRepository().SaveSheet(dt);
                MessageBox.Show("사원 정보가 저장됐습니다.");
                Sheet.Clear(range);
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch(SqlException ex) when (ex.Number == 2627)
            {
                // 로그인ID 중복시 메시지 출력
                if (ex.Message.Contains("UQ_Employee_LoginId"))
                {
                    MessageBox.Show("이미 존재하는 로그인ID가 있습니다");
                    return;
                }
                // 사원코드 중복시 메시지 출력
                else if (ex.Message.Contains("UQ_Employee_EmpCode"))
                {
                    MessageBox.Show("이미 존재하는 사원코드가 있습니다.");
                    return;
                }
                // 그 외 중복값 발생시 메시지 출력
                else
                {
                    MessageBox.Show("중복된 값이 존재합니다.");
                    return;
                }
            }
            // 나머지 에러 발생시 예외처리 및 로그
            catch (Exception ex)
            {
                Logger.Instance.Error("다중 사원 추가 저장 실패", ex);
                MessageBox.Show("사원 추가 중 오류가 발생하였습니다.");
            }








        }

    }
}
