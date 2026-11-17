namespace WindowsFormsApp2.Forms
{
    partial class LoginForm
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
            this.닫기버튼 = new System.Windows.Forms.Button();
            this.저장버튼 = new System.Windows.Forms.Button();
            this.bdrPassword = new System.Windows.Forms.Panel();
            this.inPassword = new System.Windows.Forms.Panel();
            this.비밀번호텍스트박스 = new System.Windows.Forms.TextBox();
            this.bdrLogin = new System.Windows.Forms.Panel();
            this.inLogin = new System.Windows.Forms.Panel();
            this.로그인텍스트박스 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bdrPassword.SuspendLayout();
            this.inPassword.SuspendLayout();
            this.bdrLogin.SuspendLayout();
            this.inLogin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 닫기버튼
            // 
            this.닫기버튼.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.닫기버튼.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.닫기버튼.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.닫기버튼.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.닫기버튼.ForeColor = System.Drawing.Color.White;
            this.닫기버튼.Location = new System.Drawing.Point(285, 115);
            this.닫기버튼.Name = "닫기버튼";
            this.닫기버튼.Size = new System.Drawing.Size(120, 30);
            this.닫기버튼.TabIndex = 21;
            this.닫기버튼.Text = "닫기";
            this.닫기버튼.UseVisualStyleBackColor = false;
            // 
            // 저장버튼
            // 
            this.저장버튼.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.저장버튼.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.저장버튼.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.저장버튼.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.저장버튼.ForeColor = System.Drawing.Color.White;
            this.저장버튼.Location = new System.Drawing.Point(150, 115);
            this.저장버튼.Name = "저장버튼";
            this.저장버튼.Size = new System.Drawing.Size(120, 30);
            this.저장버튼.TabIndex = 19;
            this.저장버튼.Text = "저장";
            this.저장버튼.UseVisualStyleBackColor = false;
            // 
            // bdrPassword
            // 
            this.bdrPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrPassword.Controls.Add(this.inPassword);
            this.bdrPassword.Location = new System.Drawing.Point(182, 74);
            this.bdrPassword.Name = "bdrPassword";
            this.bdrPassword.Padding = new System.Windows.Forms.Padding(1);
            this.bdrPassword.Size = new System.Drawing.Size(154, 23);
            this.bdrPassword.TabIndex = 22;
            // 
            // inPassword
            // 
            this.inPassword.BackColor = System.Drawing.Color.White;
            this.inPassword.Controls.Add(this.비밀번호텍스트박스);
            this.inPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inPassword.Location = new System.Drawing.Point(1, 1);
            this.inPassword.Name = "inPassword";
            this.inPassword.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inPassword.Size = new System.Drawing.Size(152, 21);
            this.inPassword.TabIndex = 0;
            // 
            // 비밀번호텍스트박스
            // 
            this.비밀번호텍스트박스.BackColor = System.Drawing.Color.White;
            this.비밀번호텍스트박스.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.비밀번호텍스트박스.Dock = System.Windows.Forms.DockStyle.Fill;
            this.비밀번호텍스트박스.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.비밀번호텍스트박스.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.비밀번호텍스트박스.Location = new System.Drawing.Point(3, 3);
            this.비밀번호텍스트박스.Name = "비밀번호텍스트박스";
            this.비밀번호텍스트박스.PasswordChar = '*';
            this.비밀번호텍스트박스.Size = new System.Drawing.Size(149, 16);
            this.비밀번호텍스트박스.TabIndex = 13;
            // 
            // bdrLogin
            // 
            this.bdrLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrLogin.Controls.Add(this.inLogin);
            this.bdrLogin.Location = new System.Drawing.Point(13, 74);
            this.bdrLogin.Name = "bdrLogin";
            this.bdrLogin.Padding = new System.Windows.Forms.Padding(1);
            this.bdrLogin.Size = new System.Drawing.Size(154, 23);
            this.bdrLogin.TabIndex = 20;
            // 
            // inLogin
            // 
            this.inLogin.BackColor = System.Drawing.Color.White;
            this.inLogin.Controls.Add(this.로그인텍스트박스);
            this.inLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inLogin.Location = new System.Drawing.Point(1, 1);
            this.inLogin.Name = "inLogin";
            this.inLogin.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inLogin.Size = new System.Drawing.Size(152, 21);
            this.inLogin.TabIndex = 0;
            // 
            // 로그인텍스트박스
            // 
            this.로그인텍스트박스.BackColor = System.Drawing.Color.White;
            this.로그인텍스트박스.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.로그인텍스트박스.Dock = System.Windows.Forms.DockStyle.Fill;
            this.로그인텍스트박스.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.로그인텍스트박스.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.로그인텍스트박스.Location = new System.Drawing.Point(3, 3);
            this.로그인텍스트박스.Multiline = true;
            this.로그인텍스트박스.Name = "로그인텍스트박스";
            this.로그인텍스트박스.Size = new System.Drawing.Size(149, 18);
            this.로그인텍스트박스.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(13, 55);
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
            this.label4.Location = new System.Drawing.Point(182, 55);
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
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "로그인정보";
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(421, 156);
            this.Controls.Add(this.닫기버튼);
            this.Controls.Add(this.저장버튼);
            this.Controls.Add(this.bdrPassword);
            this.Controls.Add(this.bdrLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인폼";
            this.bdrPassword.ResumeLayout(false);
            this.inPassword.ResumeLayout(false);
            this.inPassword.PerformLayout();
            this.bdrLogin.ResumeLayout(false);
            this.inLogin.ResumeLayout(false);
            this.inLogin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button 닫기버튼;
        private System.Windows.Forms.Button 저장버튼;
        private System.Windows.Forms.Panel bdrPassword;
        private System.Windows.Forms.Panel inPassword;
        private System.Windows.Forms.TextBox 비밀번호텍스트박스;
        private System.Windows.Forms.Panel bdrLogin;
        private System.Windows.Forms.Panel inLogin;
        private System.Windows.Forms.TextBox 로그인텍스트박스;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}