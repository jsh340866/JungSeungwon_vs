namespace WindowsFormsApp2.Forms
{
    partial class Login
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
            this.닫기 = new System.Windows.Forms.Button();
            this.저장 = new System.Windows.Forms.Button();
            this.bdrPassword = new System.Windows.Forms.Panel();
            this.inPassword = new System.Windows.Forms.Panel();
            this.비밀번호 = new System.Windows.Forms.TextBox();
            this.bdrLogin = new System.Windows.Forms.Panel();
            this.inLogin = new System.Windows.Forms.Panel();
            this.로그인ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.아이디기억 = new System.Windows.Forms.CheckBox();
            this.bdrPassword.SuspendLayout();
            this.inPassword.SuspendLayout();
            this.bdrLogin.SuspendLayout();
            this.inLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 닫기
            // 
            this.닫기.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.닫기.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.닫기.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.닫기.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.닫기.ForeColor = System.Drawing.Color.White;
            this.닫기.Location = new System.Drawing.Point(285, 105);
            this.닫기.Name = "닫기";
            this.닫기.Size = new System.Drawing.Size(120, 30);
            this.닫기.TabIndex = 21;
            this.닫기.Text = "닫기";
            this.닫기.UseVisualStyleBackColor = false;
            // 
            // 저장
            // 
            this.저장.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.저장.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.저장.Cursor = System.Windows.Forms.Cursors.Default;
            this.저장.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.저장.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.저장.ForeColor = System.Drawing.Color.White;
            this.저장.Location = new System.Drawing.Point(150, 105);
            this.저장.Name = "저장";
            this.저장.Size = new System.Drawing.Size(120, 30);
            this.저장.TabIndex = 19;
            this.저장.Text = "저장";
            this.저장.UseVisualStyleBackColor = false;
            // 
            // bdrPassword
            // 
            this.bdrPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrPassword.Controls.Add(this.inPassword);
            this.bdrPassword.Location = new System.Drawing.Point(182, 64);
            this.bdrPassword.Name = "bdrPassword";
            this.bdrPassword.Padding = new System.Windows.Forms.Padding(1);
            this.bdrPassword.Size = new System.Drawing.Size(154, 23);
            this.bdrPassword.TabIndex = 22;
            // 
            // inPassword
            // 
            this.inPassword.BackColor = System.Drawing.Color.White;
            this.inPassword.Controls.Add(this.비밀번호);
            this.inPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inPassword.Location = new System.Drawing.Point(1, 1);
            this.inPassword.Name = "inPassword";
            this.inPassword.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inPassword.Size = new System.Drawing.Size(152, 21);
            this.inPassword.TabIndex = 0;
            // 
            // 비밀번호
            // 
            this.비밀번호.BackColor = System.Drawing.Color.White;
            this.비밀번호.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.비밀번호.Dock = System.Windows.Forms.DockStyle.Fill;
            this.비밀번호.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.비밀번호.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.비밀번호.Location = new System.Drawing.Point(3, 3);
            this.비밀번호.Name = "비밀번호";
            this.비밀번호.PasswordChar = '*';
            this.비밀번호.Size = new System.Drawing.Size(149, 16);
            this.비밀번호.TabIndex = 13;
            // 
            // bdrLogin
            // 
            this.bdrLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrLogin.Controls.Add(this.inLogin);
            this.bdrLogin.Location = new System.Drawing.Point(13, 64);
            this.bdrLogin.Name = "bdrLogin";
            this.bdrLogin.Padding = new System.Windows.Forms.Padding(1);
            this.bdrLogin.Size = new System.Drawing.Size(154, 23);
            this.bdrLogin.TabIndex = 20;
            // 
            // inLogin
            // 
            this.inLogin.BackColor = System.Drawing.Color.White;
            this.inLogin.Controls.Add(this.로그인ID);
            this.inLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inLogin.Location = new System.Drawing.Point(1, 1);
            this.inLogin.Name = "inLogin";
            this.inLogin.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inLogin.Size = new System.Drawing.Size(152, 21);
            this.inLogin.TabIndex = 0;
            // 
            // 로그인ID
            // 
            this.로그인ID.BackColor = System.Drawing.Color.White;
            this.로그인ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.로그인ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.로그인ID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.로그인ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.로그인ID.Location = new System.Drawing.Point(3, 3);
            this.로그인ID.Multiline = true;
            this.로그인ID.Name = "로그인ID";
            this.로그인ID.Size = new System.Drawing.Size(149, 18);
            this.로그인ID.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "로그인ID";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label4.Location = new System.Drawing.Point(182, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "비밀번호";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 35);
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
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "로그인";
            // 
            // 아이디기억
            // 
            this.아이디기억.AutoSize = true;
            this.아이디기억.Location = new System.Drawing.Point(17, 112);
            this.아이디기억.Name = "아이디기억";
            this.아이디기억.Size = new System.Drawing.Size(100, 19);
            this.아이디기억.TabIndex = 23;
            this.아이디기억.Text = "로그인ID 저장";
            this.아이디기억.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AcceptButton = this.저장;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(421, 156);
            this.Controls.Add(this.아이디기억);
            this.Controls.Add(this.닫기);
            this.Controls.Add(this.저장);
            this.Controls.Add(this.bdrPassword);
            this.Controls.Add(this.bdrLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.bdrPassword.ResumeLayout(false);
            this.inPassword.ResumeLayout(false);
            this.inPassword.PerformLayout();
            this.bdrLogin.ResumeLayout(false);
            this.inLogin.ResumeLayout(false);
            this.inLogin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 닫기;
        private System.Windows.Forms.Button 저장;
        private System.Windows.Forms.Panel bdrPassword;
        private System.Windows.Forms.Panel inPassword;
        private System.Windows.Forms.TextBox 비밀번호;
        private System.Windows.Forms.Panel bdrLogin;
        private System.Windows.Forms.Panel inLogin;
        private System.Windows.Forms.TextBox 로그인ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox 아이디기억;
    }
}