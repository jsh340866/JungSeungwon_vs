using System.Windows.Forms;

// ───────────── 로그인정보 팝업 ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class LoginInfoDialog : DialogBase
{
    private readonly EmployeeRepository _repo;
    private readonly Employee _emp;
    private readonly TextBox _loginId, _password;

    public LoginInfoDialog(EmployeeRepository repo, Employee emp) : base("로그인정보 - " + emp.EmpName)
    {
        _repo = repo;
        _emp = emp;

        _loginId = AddField("로그인ID", new BorderTextBox { Text = emp.LoginId, MaxLength = 30 }, 12, 10, 154, false);
        _password = AddField("비밀번호", new BorderTextBox { Text = emp.Password, PasswordChar = '*', MaxLength = 50 }, 181, 10, 154, false);
        UseCloseStyle();
        SetLayout(421, 156, 16, 21);
    }

    protected override bool OnSave()
    {
        if (!Require(_loginId, "로그인ID") || !Require(_password, "비밀번호")) return false;

        if (!Ui.IsValidPassword(_password.Text))
        {
            Ui.Warn("비밀번호는 영문과 숫자를 모두 포함해 8자리 이상이어야 합니다.");
            _password.Focus();
            return false;
        }
        return Ui.Try(() => { _repo.UpdateLogin(_emp.EmpId, _loginId.Text.Trim(), _password.Text); });
    }
}
