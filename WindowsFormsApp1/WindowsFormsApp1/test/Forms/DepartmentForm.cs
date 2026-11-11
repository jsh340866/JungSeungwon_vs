using System.Drawing;
using System.Windows.Forms;

// ───────────── 부서 목록 창 ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class DepartmentForm : Form
{
    private readonly DepartmentRepository _repo;
    private readonly DataGridView _grid = Ui.MakeGrid("부서코드", "부서명", "메모");

    public DepartmentForm(DepartmentRepository repo)
    {
        _repo = repo;
        Text = "부서";
        Font = Ui.BaseFont;
        ForeColor = Ui.Text;
        Size = new Size(640, 420);
        StartPosition = FormStartPosition.CenterParent;

        var top = Ui.MakeTopBar("부서",
            Ui.MenuBtn("추가", AddDept),
            Ui.MenuBtn("수정", EditDept),
            Ui.MenuBtn("삭제", DeleteDept),
            Ui.MenuBtn("닫기", Close));

        Controls.Add(_grid);    // Fill 컨트롤을 먼저 추가
        Controls.Add(Ui.MakeGap());
        Controls.Add(top);

        Shown += (s, e) => LoadData();
        _grid.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditDept(); };
    }

    private void LoadData()
    {
        Ui.Try(() =>
        {
            var list = _repo.GetAll();
            _grid.Rows.Clear();
            foreach (var d in list)
            {
                int i = _grid.Rows.Add(d.DeptCode, d.DeptName, d.Memo);
                _grid.Rows[i].Tag = d;
            }
        });
    }

    private Department Selected()
    {
        var dept = _grid.CurrentRow == null ? null : _grid.CurrentRow.Tag as Department;
        if (dept == null) Ui.Warn("부서를 선택하세요.");
        return dept;
    }

    private void AddDept()
    {
        using (var dlg = new DeptEditDialog(_repo, null))
        {
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadData();
        }
    }

    private void EditDept()
    {
        var dept = Selected();
        if (dept == null) return;
        using (var dlg = new DeptEditDialog(_repo, dept))
        {
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadData();
        }
    }

    private void DeleteDept()
    {
        var dept = Selected();
        if (dept == null) return;
        using (var dlg = new DeleteDialog("부서 삭제",
            "부서코드: " + dept.DeptCode, "부서명: " + dept.DeptName,
            () => _repo.Delete(dept.DeptId)))
        {
            if (dlg.ShowDialog(this) == DialogResult.OK) LoadData();
        }
    }
}
