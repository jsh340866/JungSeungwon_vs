namespace WindowsFormsApp2.Forms
{
    partial class ParentAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.취소 = new System.Windows.Forms.Button();
            this.저장 = new System.Windows.Forms.Button();
            this.pnlPhone = new System.Windows.Forms.Panel();
            this.bdrPhone = new System.Windows.Forms.Panel();
            this.inPhone = new System.Windows.Forms.Panel();
            this.상위부서코드 = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.Label();
            this.pnlMemo = new System.Windows.Forms.Panel();
            this.bdrMemo = new System.Windows.Forms.Panel();
            this.inMemo = new System.Windows.Forms.Panel();
            this.메모 = new System.Windows.Forms.TextBox();
            this.memo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.상위부서명 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlPhone.SuspendLayout();
            this.bdrPhone.SuspendLayout();
            this.inPhone.SuspendLayout();
            this.pnlMemo.SuspendLayout();
            this.bdrMemo.SuspendLayout();
            this.inMemo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 35);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "상위 부서 추가";
            // 
            // 취소
            // 
            this.취소.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.취소.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(80)))), ((int)(((byte)(59)))));
            this.취소.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.취소.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.취소.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.취소.Location = new System.Drawing.Point(229, 180);
            this.취소.Name = "취소";
            this.취소.Size = new System.Drawing.Size(120, 30);
            this.취소.TabIndex = 49;
            this.취소.Text = "취소";
            this.취소.UseVisualStyleBackColor = false;
            // 
            // 저장
            // 
            this.저장.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.저장.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.저장.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.저장.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.저장.ForeColor = System.Drawing.Color.White;
            this.저장.Location = new System.Drawing.Point(94, 180);
            this.저장.Name = "저장";
            this.저장.Size = new System.Drawing.Size(120, 30);
            this.저장.TabIndex = 48;
            this.저장.Text = "저장";
            this.저장.UseVisualStyleBackColor = false;
            // 
            // pnlPhone
            // 
            this.pnlPhone.Controls.Add(this.bdrPhone);
            this.pnlPhone.Controls.Add(this.phone);
            this.pnlPhone.Location = new System.Drawing.Point(11, 56);
            this.pnlPhone.Name = "pnlPhone";
            this.pnlPhone.Size = new System.Drawing.Size(154, 41);
            this.pnlPhone.TabIndex = 45;
            // 
            // bdrPhone
            // 
            this.bdrPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrPhone.Controls.Add(this.inPhone);
            this.bdrPhone.Location = new System.Drawing.Point(0, 18);
            this.bdrPhone.Name = "bdrPhone";
            this.bdrPhone.Padding = new System.Windows.Forms.Padding(1);
            this.bdrPhone.Size = new System.Drawing.Size(154, 23);
            this.bdrPhone.TabIndex = 33;
            // 
            // inPhone
            // 
            this.inPhone.BackColor = System.Drawing.Color.White;
            this.inPhone.Controls.Add(this.상위부서코드);
            this.inPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inPhone.Location = new System.Drawing.Point(1, 1);
            this.inPhone.Name = "inPhone";
            this.inPhone.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inPhone.Size = new System.Drawing.Size(152, 21);
            this.inPhone.TabIndex = 0;
            // 
            // 상위부서코드
            // 
            this.상위부서코드.BackColor = System.Drawing.Color.White;
            this.상위부서코드.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.상위부서코드.Dock = System.Windows.Forms.DockStyle.Fill;
            this.상위부서코드.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.상위부서코드.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.상위부서코드.Location = new System.Drawing.Point(3, 3);
            this.상위부서코드.Multiline = true;
            this.상위부서코드.Name = "상위부서코드";
            this.상위부서코드.Size = new System.Drawing.Size(149, 18);
            this.상위부서코드.TabIndex = 19;
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.phone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(80)))), ((int)(((byte)(59)))));
            this.phone.Location = new System.Drawing.Point(0, -1);
            this.phone.Margin = new System.Windows.Forms.Padding(0);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(93, 17);
            this.phone.TabIndex = 18;
            this.phone.Text = "상위부서코드";
            // 
            // pnlMemo
            // 
            this.pnlMemo.Controls.Add(this.bdrMemo);
            this.pnlMemo.Controls.Add(this.memo);
            this.pnlMemo.Location = new System.Drawing.Point(13, 109);
            this.pnlMemo.Name = "pnlMemo";
            this.pnlMemo.Size = new System.Drawing.Size(337, 41);
            this.pnlMemo.TabIndex = 44;
            // 
            // bdrMemo
            // 
            this.bdrMemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrMemo.Controls.Add(this.inMemo);
            this.bdrMemo.Location = new System.Drawing.Point(0, 18);
            this.bdrMemo.Name = "bdrMemo";
            this.bdrMemo.Padding = new System.Windows.Forms.Padding(1);
            this.bdrMemo.Size = new System.Drawing.Size(337, 23);
            this.bdrMemo.TabIndex = 33;
            // 
            // inMemo
            // 
            this.inMemo.BackColor = System.Drawing.Color.White;
            this.inMemo.Controls.Add(this.메모);
            this.inMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inMemo.Location = new System.Drawing.Point(1, 1);
            this.inMemo.Name = "inMemo";
            this.inMemo.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inMemo.Size = new System.Drawing.Size(335, 21);
            this.inMemo.TabIndex = 0;
            // 
            // 메모
            // 
            this.메모.BackColor = System.Drawing.Color.White;
            this.메모.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.메모.Dock = System.Windows.Forms.DockStyle.Fill;
            this.메모.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.메모.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.메모.Location = new System.Drawing.Point(3, 3);
            this.메모.Multiline = true;
            this.메모.Name = "메모";
            this.메모.Size = new System.Drawing.Size(332, 18);
            this.메모.TabIndex = 19;
            // 
            // memo
            // 
            this.memo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.memo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.memo.Location = new System.Drawing.Point(0, -1);
            this.memo.Margin = new System.Windows.Forms.Padding(0);
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(77, 17);
            this.memo.TabIndex = 18;
            this.memo.Text = "메모";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(196, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 41);
            this.panel2.TabIndex = 50;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(0, 18);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(154, 23);
            this.panel3.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.상위부서명);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.panel4.Size = new System.Drawing.Size(152, 21);
            this.panel4.TabIndex = 0;
            // 
            // 상위부서명
            // 
            this.상위부서명.BackColor = System.Drawing.Color.White;
            this.상위부서명.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.상위부서명.Dock = System.Windows.Forms.DockStyle.Fill;
            this.상위부서명.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.상위부서명.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.상위부서명.Location = new System.Drawing.Point(3, 3);
            this.상위부서명.Multiline = true;
            this.상위부서명.Name = "상위부서명";
            this.상위부서명.Size = new System.Drawing.Size(149, 18);
            this.상위부서명.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(80)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(0, -1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "상위부서명";
            // 
            // ParentAdd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 225);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.취소);
            this.Controls.Add(this.저장);
            this.Controls.Add(this.pnlPhone);
            this.Controls.Add(this.pnlMemo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ParentAdd";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "상위 부서 추가";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPhone.ResumeLayout(false);
            this.bdrPhone.ResumeLayout(false);
            this.inPhone.ResumeLayout(false);
            this.inPhone.PerformLayout();
            this.pnlMemo.ResumeLayout(false);
            this.bdrMemo.ResumeLayout(false);
            this.inMemo.ResumeLayout(false);
            this.inMemo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 취소;
        private System.Windows.Forms.Button 저장;
        private System.Windows.Forms.Panel pnlPhone;
        private System.Windows.Forms.Panel bdrPhone;
        private System.Windows.Forms.Panel inPhone;
        private System.Windows.Forms.TextBox 상위부서코드;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Panel pnlMemo;
        private System.Windows.Forms.Panel bdrMemo;
        private System.Windows.Forms.Panel inMemo;
        private System.Windows.Forms.TextBox 메모;
        private System.Windows.Forms.Label memo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox 상위부서명;
        private System.Windows.Forms.Label label2;
    }
}