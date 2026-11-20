using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
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
    public partial class ParentDepartment : Form
    {
        private readonly List<DepartmentDto> dept = new DepartmentRepository().GetAll();
        private ParentDepartmentDto Row => 그리드뷰.GetFocusedRow() as ParentDepartmentDto;
        public ParentDepartment()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.닫기.Click += 닫기btn_Click;
            this.삭제.Click += 삭제btn_Click;
            this.수정.Click += 수정btn_Click;
            this.추가.Click += 추가btn_Click;
            this.자료변환.Click += 자료변환btn_Click;

            GridUpdate();
        }

        // 그리드 갱신
        private void GridUpdate()
        {
            try 
            {
                그리드컨트롤.DataSource = new ParentDepartmentRepository().GetAll();
            }
            catch (Exception ex) 
            {
                Logger.Instance.Error("목록 갱신 실패", ex);
                MessageBox.Show("목록 갱신 실패하였습니다.");
            }
            
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 닫기
        private void 닫기btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        // 삭제
        private void 삭제btn_Click(object sender, EventArgs e)
        {
            if (Row == null)
            {
                MessageBox.Show("삭제할 상위부서를 선택해주세요.");
                return;
            }

            string title = "상위 부서 삭제";
            string msg = "상위부서코드: " + Row.ParentDeptCode + "\n" +
                      "상위부서명: " + Row.ParentDeptName + "\n\n" +
                      "삭제하시겠습니까?";

            Delete D = new Delete(title, msg);
            D.ShowDialog();

            if (D.DialogResult == DialogResult.OK)
            {
                // 선택한 행 Row에 소속된 부서가 존재한다면 메시지 띄움
                if (dept.Any(d => d.ParentDeptId == Row.ParentDeptId))
                {
                    MessageBox.Show("소속 부서가 존재하는 상위부서는 삭제할 수 없습니다.");
                    return;
                }
                // 소속된 부서가 없으면 삭제 후 그리드갱신
                try
                {
                    new ParentDepartmentRepository().Delete(Row.ParentDeptId);
                    MessageBox.Show("삭제가 완료되었습니다.");
                    GridUpdate();
                }
                // 삭제 중 에러발생시 예외처리 및 로그
                catch (Exception ex)
                {
                    Logger.Instance.Error("상위부서 삭제 실패 ParentDeptId =" + Row.ParentDeptId);
                    MessageBox.Show("상위부서 삭제 중 오류가 발생하였습니다.\n", ex.Message);
                }
            }
        }

        // 수정
        private void 수정btn_Click(object sender, EventArgs e)
        {
            if (Row == null)
            {
                MessageBox.Show("수정할 상위부서를 선택해주세요.");
                return;
            }
            ParentEditForm E = new ParentEditForm(Row);
            E.ShowDialog();

            if (E.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("상위부서가 수정되었습니다.");
                GridUpdate();
                return;
            }
        }

        // 추가
        private void 추가btn_Click(object sender, EventArgs e)
        {
            ParentAdd A = new ParentAdd();
            A.ShowDialog();

            if (A.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("상위부서가 추가되었습니다.");
                GridUpdate();
                return;
            }
        }

        // 자료변환
        private void 자료변환btn_Click(object sender, EventArgs e)
        {
            // ExcelTransfer에서 만든 메서드로 제목, gridview를 받아 엑셀파일로 변환
            new ExcelTransfer().ExportExcel("상위부서", 그리드뷰);
        }
    }
}


