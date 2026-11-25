using DevExpress.XtraGrid.Views.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class EmpForm : Form
    {
        private EmployeeDto Row => gridView.GetFocusedRow() as EmployeeDto;
        public EmpForm()
        {
            InitializeComponent();
            this.Load += 사원폼_Load;
            this.Paint += 테두리_Paint;
            this.조회btn.Click += 조회btn_Click;
            this.닫기btn.Click += 닫기btn_Click;
            this.로그인정보btn.Click += 로그인정보btn_Click;
            this.추가btn.Click += 추가btn_Click;
            this.부서btn.Click += 부서btn_Click;
            this.삭제btn.Click += 삭제btn_Click;
            this.수정btn.Click += 수정btn_Click;
            this.자료변환btn.Click += 자료변환btn_Click;
            this.다중추가btn.Click += 다중추가btn_Click;
            this.gridView.CustomColumnDisplayText += gridView_CustomColumnDisplayText;
        }
        
        // 사원폼 Load
        private async void 사원폼_Load(object sender, EventArgs e)
        {
            await GridUpdateAsync();
        }


        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            FormDesign.Line(e, Width, Height);
        }

        // 비밀번호 컬럼은 실제 길이와 상관없이 별 8개로 고정 표시
        private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == 비밀번호)
            {
                e.DisplayText = new string('*', 8);
            }
        }

        // 그리드 갱신
        private async Task GridUpdateAsync()
        {
            try
            {
                gridControl.DataSource = await new EmpService().GetAllAsync();
            }
            catch
            {
                MessageBox.Show("목록 갱신에 실패하였습니다.");
            }
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 조회
        private async void 조회btn_Click(object sender, EventArgs e)
        {
            try
            {
                await GridUpdateAsync();
            }
            // 조회 실패시 예외처리
            catch
            {
                MessageBox.Show("조회 중 오류가 발생했습니다.");
            }
        }

        // 삭제
        private async void 삭제btn_Click(object sender, EventArgs e)
        {
            // 선택한 행이 없을경우 메시지 띄움
            if (Row == null)
            {
                MessageBox.Show("삭제할 사원을 선택하세요.");
                return;
            }
            // 삭제폼에서 사용할 제목과, 메시지 작성
            string msg = "사원코드: " + Row.EmpCode + "\n" +
                         "사원명: " + Row.EmpName + "\n\n" +
                         "삭제하시겠습니까?";
            DeleteForm D = new DeleteForm("사원 삭제", msg);
            D.ShowDialog();

            // 삭제폼에서 DialogResult.OK를 받아 데이터 삭제 후 조회 갱신
            if (D.DialogResult == DialogResult.OK)
            {
                try
                {
                    await new EmpService().DeleteAsync(Row.EmpId);
                    MessageBox.Show("삭제되었습니다.");
                    await GridUpdateAsync();
                }
                // 에러 발생시 메시지 출력
                catch
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다.");
                }
            }
        }


        // 로그인정보
        private async void 로그인정보btn_Click(object sender, EventArgs e)
        {
            // 선택한 행이 없을 경우 메시지 띄움
            if (Row == null)
            {
                MessageBox.Show("로그인 정보를 확인할 사원을 선택하세요.");
                return;
            }
            string LoginId = Row.LoginId;
            string Password = Row.Password;
            LoginInfo L = new LoginInfo(LoginId, Password, Row.EmpId);
            L.ShowDialog();

            // 로그인정보폼에서 DialogResult.OK를 받고 다시 조회 갱신
            if (L.DialogResult == DialogResult.OK)
            {
                await GridUpdateAsync();
            }
        }

        // 사원 수정
        private async void 수정btn_Click(object sender, EventArgs e)
        {
            if (Row == null)
            {
                MessageBox.Show("수정할 사원을 선택하세요.");
                return;
            }
            EmpEdit E = new EmpEdit(Row);
            E.ShowDialog();

            // 사원 수정폼 DialogResult.OK 확인 후 조회 갱신
            if (E.DialogResult == DialogResult.OK)
            {
                await GridUpdateAsync();
            }
        }


        // 사원 추가
        private async void 추가btn_Click(object sender, EventArgs e)
        {
            EmpAdd A = new EmpAdd();
            A.ShowDialog();

            // 사원 추가폼 DialogResult.OK 확인 후 조회 갱신
            if (A.DialogResult == DialogResult.OK)
            {
                await GridUpdateAsync();
            }
        
        }

        // 부서폼 연결
        private void 부서btn_Click(object sender, EventArgs e)
        {
            DeptForm D = new DeptForm();
            D.ShowDialog();
        }

        // GridView -> 엑셀파일로 자료변환
        private void 자료변환btn_Click(object sender, EventArgs e)
        {
            new ExcelTransfer().ExportExcel("사원 정보", gridView);
        }

        // 다중추가
        private async void 다중추가btn_Click(object sender, EventArgs e)
        {
            EmpMultiAdd M = new EmpMultiAdd();
            M.ShowDialog();

            if(M.DialogResult == DialogResult.OK)
            {
                await GridUpdateAsync();
            }
        }
    }
}