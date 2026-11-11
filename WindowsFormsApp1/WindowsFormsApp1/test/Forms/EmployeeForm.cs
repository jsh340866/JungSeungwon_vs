using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// ───────────── 메인: 부서사원 (사원 조회) ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class EmployeeForm : Form
{
    private readonly DepartmentRepository _deptRepo = new DepartmentRepository(Config.ConnStr);
    private readonly EmployeeRepository _empRepo = new EmployeeRepository(Config.ConnStr);
    private readonly DataGridView _grid = Ui.MakeGrid(
        "부서코드", "부서명", "사원코드", "사원명", "성별", "로그인ID", "비밀번호",
        "직위", "고용형태", "휴대전화", "이메일", "메신저ID", "메모");
    private readonly ComboBox _cmbDept = new ImageComboBox(Ui.DropArrowIcon())
    {
        DisplayMember = "DeptName",
        Width = 150,
        Margin = new Padding(2, 6, 10, 0)
    };

    public EmployeeForm()
    {
        Text = "부서사원";
        Font = Ui.BaseFont;
        ForeColor = Ui.Text;
        Size = new Size(1360, 600);   // 열 13개 x 100 + 행 머리글 20이 다 보이도록
        StartPosition = FormStartPosition.CenterScreen;

        var top = Ui.MakeTopBar("부서사원",
            Ui.MenuBtn("부서", OpenDepartments),
            new Label { Text = "부서 선택", AutoSize = true, Margin = new Padding(12, 10, 2, 0) },
            _cmbDept,
            Ui.MenuBtn("조회", LoadEmployees),
            Ui.MenuBtn("추가", AddEmployee),
            Ui.MenuBtn("수정", EditEmployee),
            Ui.MenuBtn("로그인정보", EditLogin),
            Ui.MenuBtn("삭제", DeleteEmployee),
            Ui.MenuBtn("자료변환", () => { }),     // 댓글: 자료변환 버튼은 무시 (버튼만 존재)
            Ui.MenuBtn("닫기", Close));

        Controls.Add(_grid);
        Controls.Add(Ui.MakeGap());
        Controls.Add(top);

        Shown += (s, e) => { LoadDepartments(); LoadEmployees(); };
        _grid.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditEmployee(); };
    }

    // 부서 필터 콤보박스 채우기 ('(전체)' + 부서들)
    private void LoadDepartments()
    {
        var current = _cmbDept.SelectedItem as Department;
        int prevId = current != null ? current.DeptId : 0;

        Ui.Try(() =>
        {
            var list = _deptRepo.GetAll();
            _cmbDept.Items.Clear();
            _cmbDept.Items.Add(new Department { DeptId = 0, DeptCode = "", DeptName = "(전체)" });
            foreach (var d in list) _cmbDept.Items.Add(d);

            var match = _cmbDept.Items.Cast<Department>().FirstOrDefault(x => x.DeptId == prevId);
            _cmbDept.SelectedItem = match ?? _cmbDept.Items[0];
        });
    }

    // 사원 표 채우기 (부서/사원 JOIN 결과, 콤보박스에서 선택한 부서만)
    private void LoadEmployees()
    {
        var sel = _cmbDept.SelectedItem as Department;
        int? deptId = (sel != null && sel.DeptId > 0) ? (int?)sel.DeptId : null;

        Ui.Try(() =>
        {
            var list = _empRepo.GetAll(deptId);
            _grid.Rows.Clear();
            foreach (var emp in list)
            {
                int i = _grid.Rows.Add(emp.DeptCode, emp.DeptName, emp.EmpCode, emp.EmpName, emp.Gender,
                    emp.LoginId, "********", emp.Position, emp.EmpType, emp.Phone, emp.Email, emp.MessengerId, emp.Memo);
                _grid.Rows[i].Tag = emp;
            }
        });
    }

    private Employee Selected()
    {
        var emp = _grid.CurrentRow == null ? null : _grid.CurrentRow.Tag as Employee;
        if (emp == null) Ui.Warn("사원을 선택하세요.");
        return emp;
    }

    private List<Department> GetDepartments()
    {
        List<Department> list = null;
        return Ui.Try(() => { list = _deptRepo.GetAll(); }) ? list : null;
    }

    private void OpenDepartments()
    {
        using (var dlg = new DepartmentForm(_deptRepo))
        {
            dlg.ShowDialog(this);
        }
        LoadDepartments();
        LoadEmployees();
    }

    private void AddEmployee()
    {
        var depts = GetDepartments();
        if (depts == null) return;
        if (depts.Count == 0)
        {
            Ui.Warn("먼저 부서를 등록하세요. (상단 '부서' 메뉴)");
            return;
        }
        using (var dlg = new EmployeeEditDialog(_empRepo, depts, null))
        {
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadEmployees();
        }
    }

    private void EditEmployee()
    {
        var emp = Selected();
        if (emp == null) return;
        var depts = GetDepartments();
        if (depts == null) return;
        using (var dlg = new EmployeeEditDialog(_empRepo, depts, emp))
        {
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadEmployees();
        }
    }

    private void EditLogin()
    {
        var emp = Selected();
        if (emp == null) return;
        using (var dlg = new LoginInfoDialog(_empRepo, emp))
        {
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadEmployees();
        }
    }

    private void DeleteEmployee()
    {
        var emp = Selected();
        if (emp == null) return;
        using (var dlg = new DeleteDialog("사원 삭제",
            "사원코드: " + emp.EmpCode, "사원명: " + emp.EmpName,
            () => _empRepo.Delete(emp.EmpId)))
        {
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadEmployees();
        }
    }
}
