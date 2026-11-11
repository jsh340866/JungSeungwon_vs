using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// ───────────── 사원 추가/수정 팝업 ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class EmployeeEditDialog : DialogBase
{
    private readonly EmployeeRepository _repo;
    private readonly Employee _existing;
    private readonly bool _isEdit;
    private readonly ComboBox _dept;
    private readonly TextBox _deptName, _code, _name, _loginId, _password, _position, _type, _phone, _email, _messenger, _memo;
    private readonly GenderBox _gender;

    public EmployeeEditDialog(EmployeeRepository repo, List<Department> depts, Employee existing)
        : base(existing == null ? "사원 추가" : "사원 수정")
    {
        _repo = repo;
        _existing = existing;
        _isEdit = existing != null;

        int y = 11;
        const int X1 = 9, X2 = 178, X3 = 347, W = 154, ROW = 53;   // 3열, 시안 값 (열 간격 15)

        // 1행: 부서코드(콤보박스) | 부서명(읽기 전용)
        _dept = AddField("부서코드", new ImageComboBox(Ui.DropArrowIcon()) { DisplayMember = "DeptCode" }, X1, y, W, true);
        _deptName = AddField("부서명", new BorderTextBox { ReadOnly = true, BackColor = Ui.Bar }, X2, y, W);
        y += ROW;

        // 2행: 사원코드 | 사원명
        _code = AddField("사원코드", new BorderTextBox { MaxLength = 10 }, X1, y, W, true);
        _name = AddField("사원명", new BorderTextBox { MaxLength = 50 }, X2, y, W, true);
        y += ROW;

        // 3행: 로그인ID | 비밀번호 (추가 화면에만 표시, 입력 시 *로 표시)
        _loginId = new BorderTextBox { MaxLength = 30 };
        _password = new BorderTextBox { PasswordChar = '*', MaxLength = 50 };
        if (!_isEdit)
        {
            AddField("로그인ID", _loginId, X1, y, W, true);
            AddField("비밀번호", _password, X2, y, W, true);
            y += ROW;
        }

        // 4행: 직위 | 고용형태 | 성별(체크박스)
        _position = AddField("직위", new BorderTextBox { MaxLength = 30 }, X1, y, W);
        _type = AddField("고용형태", new BorderTextBox { MaxLength = 20 }, X2, y, W);
        _gender = new GenderBox();
        AddField("성별", _gender, X3, y, W);
        y += ROW;

        // 5행: 휴대전화 | 이메일 | 메신저ID
        _phone = AddField("휴대전화", new BorderTextBox { MaxLength = 13 }, X1, y, W);
        _phone.TextChanged += (s, e) =>
        {
            string formatted = Ui.FormatPhone(_phone.Text);
            if (_phone.Text != formatted)
            {
                _phone.Text = formatted;
                _phone.SelectionStart = _phone.Text.Length;   // 커서를 맨 뒤로
            }
        };
        _email = AddField("이메일", new BorderTextBox { MaxLength = 100 }, X2, y, W);
        _messenger = AddField("메신저ID", new BorderTextBox { MaxLength = 50 }, X3, y, W);
        y += ROW;

        // 6행: 메모 (전체 폭)
        _memo = AddField("메모", new BorderTextBox { MaxLength = 200 }, X1 + 2, y, 489);   // 시안: 메모만 2px 안쪽

        foreach (var d in depts) _dept.Items.Add(d);
        _dept.SelectedIndexChanged += (s, e) =>
        {
            var sel = _dept.SelectedItem as Department;
            _deptName.Text = sel != null ? sel.DeptName : "";
        };

        if (existing == null)
        {
            if (_dept.Items.Count > 0) _dept.SelectedIndex = 0;
        }
        else
        {
            _dept.SelectedItem = depts.FirstOrDefault(x => x.DeptId == existing.DeptId);
            _code.Text = existing.EmpCode;
            _name.Text = existing.EmpName;
            _gender.Value = existing.Gender;
            _position.Text = existing.Position ?? "";
            _type.Text = existing.EmpType ?? "";
            _phone.Text = existing.Phone ?? "";
            _email.Text = existing.Email ?? "";
            _messenger.Text = existing.MessengerId ?? "";
            _memo.Text = existing.Memo ?? "";
            UseCloseStyle();
        }

        SetLayout(515, y + 139, 14, 15);   // 추가 515x415, 수정 515x362
    }

    protected override bool OnSave()
    {
        // 필수값(빨간 라벨) 확인
        if (!Require(_dept, "부서코드") || !Require(_code, "사원코드") || !Require(_name, "사원명")) return false;

        if (!_isEdit)
        {
            if (!Require(_loginId, "로그인ID") || !Require(_password, "비밀번호")) return false;

            // 비밀번호 규칙: 영문, 숫자 포함 8자리 이상
            if (!Ui.IsValidPassword(_password.Text))
            {
                Ui.Warn("비밀번호는 영문과 숫자를 모두 포함해 8자리 이상이어야 합니다.");
                _password.Focus();
                return false;
            }
        }

        // 이메일 규칙 (입력했을 때만)
        string email = _email.Text.Trim();
        if (email != "" && !Ui.IsValidEmail(email))
        {
            Ui.Warn("이메일 형식이 올바르지 않습니다. (예: hong@test.com)");
            _email.Focus();
            return false;
        }

        var dept = (Department)_dept.SelectedItem;
        var emp = new Employee
        {
            EmpId = _existing == null ? 0 : _existing.EmpId,
            DeptId = dept.DeptId,
            EmpCode = _code.Text.Trim(),
            EmpName = _name.Text.Trim(),
            Gender = _gender.Value,
            LoginId = _loginId.Text.Trim(),
            Password = _password.Text,
            Position = Ui.NullIfEmpty(_position.Text),
            EmpType = Ui.NullIfEmpty(_type.Text),
            Phone = Ui.NullIfEmpty(_phone.Text),
            Email = Ui.NullIfEmpty(email),
            MessengerId = Ui.NullIfEmpty(_messenger.Text),
            Memo = Ui.NullIfEmpty(_memo.Text)
        };

        return Ui.Try(() =>
        {
            if (_isEdit) _repo.Update(emp); else _repo.Add(emp);
        });
    }
}
