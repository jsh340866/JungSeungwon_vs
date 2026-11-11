using System.Windows.Forms;

// ───────────── 성별 체크박스 (하나만 선택 가능) ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class GenderBox : FlowLayoutPanel
{
    private readonly CheckBox _male = new CheckBox { Text = "남", AutoSize = true };
    private readonly CheckBox _female = new CheckBox { Text = "여", AutoSize = true };



    public GenderBox()
    {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;   // 기본 높이(100)가 남아 아래 행(메신저ID)을 덮지 않게
        WrapContents = false;
        Controls.Add(_male);
        Controls.Add(_female);

        // 한쪽을 체크하면 다른 쪽은 자동으로 해제
        _male.CheckedChanged += (s, e) => { if (_male.Checked) _female.Checked = false; };
        _female.CheckedChanged += (s, e) => { if (_female.Checked) _male.Checked = false; };
    }

    // "남" / "여" / null(선택 안 함)
    public string Value
    {
        get { return _male.Checked ? "남" : (_female.Checked ? "여" : null); }
        set
        {
            _male.Checked = (value == "남");
            _female.Checked = (value == "여");
        }
    }
}
