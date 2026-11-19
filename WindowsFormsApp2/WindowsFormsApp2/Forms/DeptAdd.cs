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
    public partial class DeptAdd : Form
    {
        private readonly DepartmentDto dept = new DepartmentDto();
        public DeptAdd()
        {
            InitializeComponent();
            this.Paint += 테두리_Paint;
            this.저장.Click += 저장btn_Click;
            this.취소.Click += 취소btn_Click;
            this.cbo상위부서코드.SelectedIndexChanged += 상위부서코드_SelectedIndexChanged;

            // 상위부서코드 콤보박스 드롭리스트
            cbo상위부서코드.DisplayMember = nameof(ParentDepartmentDto.ParentDeptCode);
            cbo상위부서코드.ValueMember = nameof(ParentDepartmentDto.ParentDeptId);
            cbo상위부서코드.DataSource = new ParentDepartmentRepository().GetAll();
        }

        // 폼 테두리
        private void 테두리_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(171, 171, 171), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        // 취소
        private void 취소btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 상위부서코드 콤보박스 선택에 따라 상위부서명 변경
        private void 상위부서코드_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentDepartmentDto p = cbo상위부서코드.SelectedItem as ParentDepartmentDto;
            상위부서명.Text = p?.ParentDeptName;
        }

        // 부서 추가 저장 버튼
        private void 저장btn_Click(object sender, EventArgs e)
        {
            // 필수값 체크
            if (string.IsNullOrWhiteSpace(cbo상위부서코드.Text)){MessageBox.Show("상위부서코드를 선택해주세요.");return;}
            if (string.IsNullOrWhiteSpace(부서코드.Text)){MessageBox.Show("부서코드는 필수기재사항입니다");return;}
            if( string.IsNullOrWhiteSpace(부서명.Text)){MessageBox.Show("부서명은 필수기재사항입니다.");return;}
            // 수정 값 메모리 저장
            dept.DeptName = 부서명.Text;
            dept.DeptCode = 부서코드.Text;
            dept.ParentDeptId = (int?)cbo상위부서코드.SelectedValue;
            dept.Memo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text;

            try
            {
                new DepartmentRepository().Save(dept);
                this.DialogResult = DialogResult.OK;
            }
            // 사원 추가 저장시 유니크키 중복 발생으로 Sql에로 발생할시 실패처리
            catch (SqlException ex) when (ex.Number == 2627) 
            {
                MessageBox.Show("중복된 부서코드 입니다. 다시 입력해주세요.");
            }
            // 나머지 예외 발생시 메시지 출력 및 로그
            catch (Exception ex)
            {
                Logger.Instance.Error("부서 추가 실패 DeptCode=" + dept.DeptCode, ex);
                MessageBox.Show("부서 추가 중 오류가 발생하였습니다.\n" + ex.Message);

            }
        }

        
    }
}
