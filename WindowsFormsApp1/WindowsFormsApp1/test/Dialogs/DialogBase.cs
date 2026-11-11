using System.Drawing;
using System.Windows.Forms;

// ───────────── 팝업 공통 틀 (Panel 위에 Label+입력칸 배치, 아래에 버튼) ─────────────
[System.ComponentModel.DesignerCategory("Code")]
abstract class DialogBase : Form
{
    protected readonly Panel Body = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
    protected readonly Button BtnSave = Ui.MakeButton("저장", Ui.Blue);
    protected readonly Button BtnCancel = Ui.MakeButton("취소", Ui.Red);
    private readonly Panel _title = new Panel { Dock = DockStyle.Top, Height = 34, BackColor = Ui.Bar };
    private readonly Panel _bottom = new Panel { Dock = DockStyle.Bottom, BackColor = Color.White };
    private readonly FlowLayoutPanel _buttons = new FlowLayoutPanel();
    private Point _dragStart;

    protected DialogBase(string title)
    {
        AutoScaleMode = AutoScaleMode.None;           // 화면 배율 때문에 칸이 잘리는 것 방지
        Font = Ui.BaseFont;
        ForeColor = Ui.Text;
        BackColor = Ui.Gray;                          // 1px 테두리 색 (#ABABAB)
        Padding = new Padding(1);
        FormBorderStyle = FormBorderStyle.None;       // 시안처럼 팝업 안쪽에 제목 표시
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;

        // 회색 제목 띠 (드래그로 이동 가능)
        var lblTitle = new Label();
        lblTitle.Text = title;
        lblTitle.AutoSize = true;
        lblTitle.Font = Ui.TitleFont;
        lblTitle.Location = new Point(9, 8);
        _title.Controls.Add(lblTitle);
        foreach (Control c in new Control[] { _title, lblTitle })
        {
            c.MouseDown += (s, e) => { _dragStart = e.Location; };
            c.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    Location = new Point(Left + e.X - _dragStart.X, Top + e.Y - _dragStart.Y);
            };
        }

        // 아래 버튼: 오른쪽 정렬, 시안 120x30, 버튼 사이 15
        BtnSave.Size = new Size(120, 30);
        BtnCancel.Size = new Size(120, 30);
        BtnCancel.Margin = new Padding(0);
        BtnSave.Margin = new Padding(0, 0, 15, 0);
        _buttons.Dock = DockStyle.Fill;
        _buttons.FlowDirection = FlowDirection.RightToLeft;
        _buttons.Controls.Add(BtnCancel);   // RightToLeft: 먼저 넣은 것이 오른쪽
        _buttons.Controls.Add(BtnSave);
        _bottom.Controls.Add(_buttons);

        Controls.Add(Body);      // Fill 컨트롤을 먼저 추가
        Controls.Add(_bottom);
        Controls.Add(_title);

        BtnCancel.DialogResult = DialogResult.Cancel;
        CancelButton = BtnCancel;
        AcceptButton = BtnSave;
        BtnSave.Click += (s, e) => { if (OnSave()) DialogResult = DialogResult.OK; };
    }

    // 저장 버튼 동작. true면 창이 닫히고, false면 그대로 열려 있음
    protected abstract bool OnSave();

    // 팝업 전체 크기(테두리 포함)와 버튼의 오른쪽/아래 여백을 시안 값 그대로 지정.
    // 본문(Body) 좌표 = 시안 팝업 기준 좌표 - (1, 35)  ← 테두리 1 + 제목 띠 34
    protected void SetLayout(int width, int height, int btnRight, int btnBottom)
    {
        ClientSize = new Size(width, height);
        _bottom.Height = 30 + btnBottom - 1;
        _buttons.Padding = new Padding(0, 0, btnRight - 1, 0);
    }

    // 라벨(위) + 입력칸(아래, 19px 아래, 높이 22) 배치. 필수 항목은 라벨을 빨간색으로 표시
    protected T AddField<T>(string label, T control, int x, int y, int width, bool required = false) where T : Control
    {
        var lbl = new Label();
        lbl.Text = label;
        lbl.AutoSize = true;
        lbl.Location = new Point(x, y);
        lbl.ForeColor = required ? Ui.Red : Ui.Text;

        var tb = control as TextBox;
        if (tb != null)
        {
            tb.BorderStyle = BorderStyle.FixedSingle;   // 시안처럼 얇은 사각 테두리 박스
            tb.AutoSize = false;                        // 글꼴 기준 자동 높이 대신 시안 높이 22
            tb.Height = 22;
        }

        control.Location = new Point(x, y + 19);
        control.Width = width;

        Body.Controls.Add(lbl);
        Body.Controls.Add(control);
        return control;
    }

    // 와이어프레임의 '저장 / 닫기'(회색) 형태
    protected void UseCloseStyle()
    {
        BtnCancel.Text = "닫기";
        BtnCancel.BackColor = Ui.Gray;
    }

    // 필수 입력 검사: 비어 있으면 안내 후 false
    protected bool Require(Control control, string name)
    {
        if (string.IsNullOrWhiteSpace(control.Text))
        {
            Ui.Warn(name + "을(를) 입력하세요.");
            control.Focus();
            return false;
        }
        return true;
    }
}
