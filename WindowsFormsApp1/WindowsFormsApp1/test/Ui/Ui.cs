using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// ───────────── UI 공통 도우미 ─────────────
static class Ui
{
    public static readonly Color Blue = ColorTranslator.FromHtml("#0072C6");
    public static readonly Color Red = ColorTranslator.FromHtml("#F4503B");
    public static readonly Color Gray = ColorTranslator.FromHtml("#ABABAB");   // 회색 버튼, 모든 테두리/선
    public static readonly Color Bar = ColorTranslator.FromHtml("#F3F3F3");   // 상단 바, 읽기 전용 칸
    public static readonly Color Text = ColorTranslator.FromHtml("#333333");   // 기본 글자색
    public static readonly Font BaseFont = new Font("Segoe UI", 9f);           // 12px
    public static readonly Font TitleFont = new Font("Segoe UI", 9.75f);       // 13px (창 제목, 삭제 안내문)

    public static void Info(string text)
    {
        MessageBox.Show(text, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void Warn(string text)
    {
        MessageBox.Show(text, "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    // DB 작업을 안전하게 실행: 오류가 나면 메시지 박스로 알리고 false 반환
    public static bool Try(Action action)
    {
        try
        {
            action();
            return true;
        }
        catch (SqlException ex)
        {
            string msg;
            switch (ex.Number)
            {
                case 547:
                    msg = "삭제할 수 없습니다. 이 데이터를 사용하는 다른 데이터(예: 소속 사원)가 있습니다.";
                    break;
                case 2627:
                case 2601:
                    msg = "이미 존재하는 코드(또는 로그인ID)입니다.";
                    break;
                default:
                    msg = "DB 오류 " + ex.Number + ": " + ex.Message;
                    break;
            }
            MessageBox.Show(msg, "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    public static string NullIfEmpty(string s)
    {
        return string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }

    // 이메일 형식 검사: 글자@글자.글자 (공백 불가)
    public static bool IsValidEmail(string s)
    {
        return Regex.IsMatch(s, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    // 비밀번호 규칙: 영문과 숫자를 모두 포함, 8자리 이상 (한글/공백 불가)
    public static bool IsValidPassword(string s)
    {
        return Regex.IsMatch(s, @"^(?=.*[A-Za-z])(?=.*[0-9])[\x21-\x7E]{8,}$");
    }

    // 시안: 헤더 높이 31, 행 높이 24, 행 머리글 폭 20, 열 폭 100, 선 #ABABAB
    public static DataGridView MakeGrid(params string[] headers)
    {
        var g = new DataGridView();
        g.Dock = DockStyle.Fill;
        g.ReadOnly = true;
        g.AllowUserToAddRows = false;
        g.AllowUserToDeleteRows = false;
        g.AllowUserToResizeRows = false;
        g.MultiSelect = false;
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        g.BackgroundColor = Color.White;
        g.BorderStyle = BorderStyle.None;
        g.GridColor = Gray;

        g.EnableHeadersVisualStyles = false;   // 헤더 색을 직접 지정하기 위해 끔
        g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        g.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        g.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Text;
        g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        g.RowHeadersDefaultCellStyle.BackColor = Color.White;
        g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        g.ColumnHeadersHeight = 31;
        g.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        g.RowHeadersWidth = 20;
        g.RowTemplate.Height = 24;

        foreach (var h in headers) g.Columns.Add(h, h);
        foreach (DataGridViewColumn c in g.Columns) c.Width = 100;
        return g;
    }

    // 상단 바와 그리드 사이 18px 여백 (시안 간격)
    public static Panel MakeGap()
    {
        return new Panel { Dock = DockStyle.Top, Height = 18, BackColor = Color.White };
    }

    // 팝업 아래쪽 색 버튼 (저장/취소/삭제 등)
    public static Button MakeButton(string text, Color back)
    {
        var b = new Button();
        b.Text = text;
        b.BackColor = back;
        b.ForeColor = Color.White;
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.Size = new Size(90, 32);
        return b;
    }

    // 상단 메뉴 버튼: 시안처럼 테두리·배경 없이 글자만 보이게
    public static Button MenuBtn(string text, Action click)
    {
        var b = new Button();
        b.Text = text;
        b.AutoSize = true;
        b.AutoSizeMode = AutoSizeMode.GrowAndShrink;   // 기본 최소폭(75px) 없이 글자 폭에 맞춤
        b.FlatStyle = FlatStyle.Flat;
        b.FlatAppearance.BorderSize = 0;
        b.TabStop = false;                              // 포커스 테두리가 그려지지 않게
        b.BackColor = Bar;
        b.ForeColor = Text;
        b.Margin = new Padding(10, 6, 10, 6);           // 높이 23 버튼을 35 바 가운데에
        b.Click += (s, e) => click();
        return b;
    }

    // 아이콘 PNG는 Resources 폴더 → Properties.Resources(exe에 포함)에서 가져온다
    public static Image PersonIcon()
    {
        return WindowsFormsApp1.Properties.Resources.ic_person;
    }

    public static Image DropArrowIcon()
    {
        return WindowsFormsApp1.Properties.Resources.drop_arrow;
    }

    // 상단 바: 왼쪽에 아이콘+제목, 오른쪽에 메뉴 컨트롤들 (Panel + FlowLayoutPanel)
    public static Panel MakeTopBar(string title, params Control[] items)
    {
        var bar = new Panel();
        bar.Dock = DockStyle.Top;
        bar.Height = 35;
        bar.BackColor = Bar;

        // 사람 아이콘 (ic_person_24px)
        var icon = new Label();
        icon.Image = PersonIcon();
        icon.AutoSize = false;
        icon.Size = new Size(16, 16);
        icon.Location = new Point(14, 10);

        // 제목 글자
        var lbl = new Label();
        lbl.Text = title;
        lbl.AutoSize = true;
        lbl.Font = TitleFont;                      // 13px, 굵지 않게
        lbl.Location = new Point(35, 9);

        // 오른쪽 메뉴
        var flow = new FlowLayoutPanel();
        flow.Dock = DockStyle.Right;
        flow.AutoSize = true;
        flow.WrapContents = false;
        flow.Controls.AddRange(items);

        bar.Controls.Add(icon);
        bar.Controls.Add(lbl);
        bar.Controls.Add(flow);
        return bar;
    }

    // 숫자만 남기고 010-1234-5678 형태로 변환 (최대 11자리)
    public static string FormatPhone(string s)
    {
        string d = Regex.Replace(s, @"\D", "");
        if (d.Length > 11) d = d.Substring(0, 11);

        if (d.Length <= 3) return d;
        if (d.Length <= 7) return d.Substring(0, 3) + "-" + d.Substring(3);
        return d.Substring(0, 3) + "-" + d.Substring(3, 4) + "-" + d.Substring(7);
    }
}
