using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Services;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Forms
{
    public partial class DeptForm : Form
    {
       
        private DepartmentDto Row => 부서그리드.GetFocusedRow() as DepartmentDto;

        public DeptForm()
        {
            InitializeComponent();
            this.Load += 부서폼_Load;
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;
            this.수정.Click += 수정btn_Click;
            this.추가.Click += 추가btn_Click;
            this.삭제.Click += 삭제btn_Click;
            this.상위부서.Click += 상위부서btn_Click;
            this.트리.Click += 트리btn_Click;
            this.차트.Click += 차트btn_Click;
        }


        // 부서폼 Load
        private async void 부서폼_Load(object sender, EventArgs e)
        {
            await GridUpdateAsync();
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 그리드 갱신
        private async Task GridUpdateAsync()
        {
            try
            {
                상위부서그리드컨트롤.DataSource = await new ParentService().GetAllAsync();
                부서그리드컨트롤.DataSource = await new DeptService().GetAllAsync();
            }
            catch
            {
                MessageBox.Show("목록 갱신을 실패하였습니다.");
            }
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 부서 삭제
        private async void 삭제btn_Click(object sender, EventArgs e)
        {
            if (Row == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }

            string title = "부서 삭제";
            string msg = "부서코드: " + Row.DeptCode + "\n" +
                         "부서명: " + Row.DeptName + "\n\n" +
                         "삭제하시겠습니까?";
            DeleteForm D = new DeleteForm(title, msg);
            D.ShowDialog();

            if (D.DialogResult == DialogResult.OK)
            {
                // 서비스 호출후 삭제, 두 번 연속으로 클릭 방지
                삭제.Enabled = false;
                try
                {
                    await new DeptService().DeleteAsync(Row.DeptId);
                    MessageBox.Show("삭제되었습니다.");
                    await GridUpdateAsync();
                }
                // 서비스에 예외처리한 BusinessException에 걸리면 메시지 출력
                catch (BusinessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // 나머지 제약조건 위반시 메시지 출력
                catch 
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다.");
                }
                // 클릭 다시 허용
                finally { 삭제.Enabled = true; }

            }

        }

        // 부서 추가 
        private async void 추가btn_Click(object sender, EventArgs e)
        {
            DeptAdd A = new DeptAdd();
            A.ShowDialog();

            if (A.DialogResult == DialogResult.OK)
            {
                await GridUpdateAsync();
            }
        }

        // 부서 수정
        private async void 수정btn_Click(object sender, EventArgs e)
        {
            if (Row == null)
            {
                MessageBox.Show("수정할 부서를 선택해주세요.");
                return;
            }

            DeptEdit E = new DeptEdit(Row);
            E.ShowDialog();

            if (E.DialogResult == DialogResult.OK)
            {
                await GridUpdateAsync();
            }

        }

        // 상위부서
        private async void 상위부서btn_Click(object sender, EventArgs e)
        {
            ParentDeptForm P = new ParentDeptForm();
            P.ShowDialog();

            // 상위부서가 추가,삭제,수정 될 경우 그리드갱신
            if (P.DialogResult == DialogResult.OK) 
            {
                await GridUpdateAsync();
            }
        }

        // 트리
        private void 트리btn_Click(object sender, EventArgs e)
        {
            DeptTree T = new DeptTree();
            T.ShowDialog();
        }
        // 차트
        private void 차트btn_Click(object sender, EventArgs e)
        {
            DeptChart C = new DeptChart();
            C.ShowDialog();
        }
    }
}
