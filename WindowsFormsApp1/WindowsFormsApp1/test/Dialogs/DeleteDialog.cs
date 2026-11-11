using System;
using System.Drawing;
using System.Windows.Forms;

// ───────────── 삭제 확인 팝업 (빨간 삭제 / 회색 취소) ─────────────
[System.ComponentModel.DesignerCategory("Code")]
class DeleteDialog : DialogBase
{
    private readonly Action _delete;

    public DeleteDialog(string title, string line1, string line2, Action delete) : base(title)
    {
        _delete = delete;

        BtnSave.Text = "삭제";
        BtnSave.BackColor = Ui.Red;
        BtnCancel.Text = "취소";
        BtnCancel.BackColor = Ui.Gray;
        AcceptButton = BtnCancel;   // 실수로 Enter를 눌러도 삭제되지 않게

        // 시안: 13px 한 덩어리 글자 (두 줄 + 빈 줄 + 질문)
        Body.Controls.Add(new Label
        {
            Text = line1 + "\n" + line2 + "\n\n삭제하시겠습니까?",
            Font = Ui.TitleFont,
            AutoSize = true,
            Location = new Point(9, 7)
        });
        SetLayout(332, 163, 9, 10);
    }

    protected override bool OnSave()
    {
        return Ui.Try(_delete);
    }
}
