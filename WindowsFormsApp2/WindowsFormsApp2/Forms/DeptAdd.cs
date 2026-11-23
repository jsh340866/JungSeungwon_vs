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
using WindowsFormsApp2.Services;
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
            cbo상위부서코드.DataSource = new ParentService().GetAll();
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
            // 수정 값 메모리 저장
            dept.DeptName = 부서명.Text;
            dept.DeptCode = 부서코드.Text;
            dept.ParentDeptId = (int?)cbo상위부서코드.SelectedValue;
            dept.Memo = string.IsNullOrWhiteSpace(메모.Text) ? null : 메모.Text;

            try
            {
                new DeptService().Add(dept);
                MessageBox.Show("부서 정보가 저장되었습니다.");
                this.DialogResult = DialogResult.OK;
            }
            // 유니크키 중복으로 Sql에러 발생시 예외처리
            catch (BusinessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 나머지 예외 발생시 메시지 출력
            catch 
            {
                MessageBox.Show("부서 추가 중 오류가 발생하였습니다.");
            }
        }

        
    }
}
