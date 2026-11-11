using System.Windows.Forms;

// ───────────── 부서 추가/수정 팝업 ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class DeptEditDialog : DialogBase
{
    private readonly DepartmentRepository _repo;
    private readonly Department _existing;
    private readonly TextBox _code, _name, _memo;

    public DeptEditDialog(DepartmentRepository repo, Department existing)
        : base(existing == null ? "부서 추가" : "부서 수정")
    {
        _repo = repo;
        _existing = existing;

        _code = AddField("부서코드", new BorderTextBox { MaxLength = 10 }, 9, 12, 147, true);
        _name = AddField("부서명", new BorderTextBox { MaxLength = 50 }, 174, 12, 147, true);
        _memo = AddField("메모", new BorderTextBox { MaxLength = 200 }, 9, 65, 310);

        if (existing != null)
        {
            _code.Text = existing.DeptCode;
            _name.Text = existing.DeptName;
            _memo.Text = existing.Memo ?? "";
            UseCloseStyle();
        }
        SetLayout(332, 206, 12, 16);
    }

    protected override bool OnSave()
    {
        if (!Require(_code, "부서코드") || !Require(_name, "부서명")) return false;

        var dept = new Department
        {
            DeptId = _existing == null ? 0 : _existing.DeptId,
            DeptCode = _code.Text.Trim(),
            DeptName = _name.Text.Trim(),
            Memo = Ui.NullIfEmpty(_memo.Text)
        };
        return Ui.Try(() =>
        {
            if (_existing != null) _repo.Update(dept); else _repo.Add(dept);
        });
    }
}
