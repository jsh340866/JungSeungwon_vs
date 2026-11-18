using DevExpress.Utils.VisualEffects;
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
    public partial class Employee : Form
    {

        EmployeeDto Emp => 그리드뷰.GetFocusedRow() as EmployeeDto;

        public Employee()
        {
            InitializeComponent();

            this.Paint += 테두리;
            this.조회.Click += 조회_Click;
            this.닫기.Click += 닫기_Click;
            this.로그인정보.Click += 로그인정보_Click;
            this.추가.Click += 추가_Click;
            this.부서.Click += 부서_Click;
            this.삭제.Click += 삭제_Click;
            this.수정.Click += 수정_Click;
            this.자료변환.Click += 자료변환_Click;
            
        }

        private void 테두리(object sender, PaintEventArgs e)
        {
            // 폼 테두리 
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void 그리드갱신()
        {
            그리드컨트롤.DataSource = new EmployeeRepository().GetAll();
        }


        private void 닫기_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 조회_Click(object sender, EventArgs e)
        {
            try
            {
                그리드갱신();
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("사원 조회 실패", ex);
                MessageBox.Show("조회 중 오류가 발생했습니다.\n" + ex.Message);
            }
        }

        private void 삭제_Click(object sender, EventArgs e)
        {
            if (그리드뷰.GetFocusedRow() == null)
            {
                MessageBox.Show("삭제할 사원을 선택하세요.");
                return;
            }
            string msg = "사원코드: " + Emp.EmpCode + "\n" +
                         "사원명: " + Emp.EmpName + "\n\n" +
                         "삭제하시겠습니까?";
            Delete deleteForm = new Delete("사원 삭제", msg);
            deleteForm.ShowDialog();


            // 삭제폼에서 DialogResult.OK를 받아 데이터 삭제 후 조회 갱신
            if (deleteForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    new EmployeeRepository().Delete(Emp.EmpId);
                    MessageBox.Show("삭제되었습니다.");
                    그리드갱신();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("사원 삭제 실패 EmpId=" + Emp.EmpId, ex);
                    MessageBox.Show("삭제 중 오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }


        
        private void 로그인정보_Click(object sender, EventArgs e)
        {

            if (그리드뷰.GetFocusedRow() == null)
            {
                MessageBox.Show("로그인 정보를 확인할 사원을 선택하세요.");
                return;
            }
            else
            {
                string LoginId = Emp.LoginId;
                string Password = Emp.Password;
                LoginInfo logininfoForm = new LoginInfo(LoginId, Password, Emp.EmpId);
                logininfoForm.ShowDialog();

                // 로그인정보폼에서 DialogResult.OK를 받고 다시 조회 갱신
                if (logininfoForm.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        MessageBox.Show("로그인 정보가 저장되었습니다.");
                        그리드갱신();
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Error("로그인정보 저장 후 목록 갱신 실패 EmpId=" + Emp.EmpId, ex);
                        MessageBox.Show("로그인 정보 저장 중 오류가 발생했습니다.\n" + ex.Message);
                    }
                }
            }

        }


        private void 수정_Click(object sender, EventArgs e)
        {
            if (그리드뷰.GetFocusedRow() == null)
            {
                MessageBox.Show("수정할 사원을 선택하세요.");
                return;
            }
            EmployeeEdit editForm = new EmployeeEdit(Emp);
            editForm.ShowDialog();

            // 사원 수정폼 DialogResult.OK 확인 후 조회 갱신
            if (editForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show("사원 정보가 저장되었습니다.");
                    그리드갱신();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("사원 수정 후 목록 갱신 실패 EmpId=" + Emp.EmpId, ex);
                    MessageBox.Show("사원 정보 저장 중 오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }
        

        // 사원 추가폼 연결
        private void 추가_Click(object sender, EventArgs e)
        {
            EmployeeAdd addForm = new EmployeeAdd();
            addForm.ShowDialog();

            // 사원 추가폼 DialogResult.OK 확인 후 조회 갱신
            if (addForm.DialogResult == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show("사원 정보가 추가 되었습니다.");
                    그리드갱신();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("사원 추가 후 목록 갱신 실패", ex);
                    MessageBox.Show("사원 정보 추가 중 오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }

        // 부서폼 연결
        private void 부서_Click(object sender, EventArgs e)
        {
            Department departmentForm = new Department();
            departmentForm.ShowDialog();
        }

        // GridView -> 엑셀파일로 자료변환
        private void 자료변환_Click(object sender, EventArgs e)
        {
            new ExcelTransfer().ExportExcel("사원 정보", 그리드뷰);
        }
    }
}