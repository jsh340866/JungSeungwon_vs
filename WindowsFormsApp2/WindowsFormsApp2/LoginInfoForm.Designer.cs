namespace WindowsFormsApp2
{
    partial class LoginInfoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoginTextbox = new System.Windows.Forms.TextBox();
            this.bdrLogin = new System.Windows.Forms.Panel();
            this.inLogin = new System.Windows.Forms.Panel();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.bdrPassword = new System.Windows.Forms.Panel();
            this.inPassword = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.bdrLogin.SuspendLayout();
            this.inLogin.SuspendLayout();
            this.bdrPassword.SuspendLayout();
            this.inPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 35);
            this.panel1.TabIndex = 8;
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 9;
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
            this.label4.TabIndex = 11;
            this.label4.Text = "비밀번호";
            // 
            // LoginTextbox
            // 
            this.LoginTextbox.BackColor = System.Drawing.Color.White;
            this.LoginTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginTextbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.LoginTextbox.Location = new System.Drawing.Point(3, 3);
            this.LoginTextbox.Multiline = true;
            this.LoginTextbox.Name = "LoginTextbox";
            this.LoginTextbox.Size = new System.Drawing.Size(149, 18);
            this.LoginTextbox.TabIndex = 12;
            // 
            // bdrLogin
            // 
            this.bdrLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrLogin.Controls.Add(this.inLogin);
            this.bdrLogin.Location = new System.Drawing.Point(13, 64);
            this.bdrLogin.Name = "bdrLogin";
            this.bdrLogin.Padding = new System.Windows.Forms.Padding(1);
            this.bdrLogin.Size = new System.Drawing.Size(154, 23);
            this.bdrLogin.TabIndex = 14;
            // 
            // inLogin
            // 
            this.inLogin.BackColor = System.Drawing.Color.White;
            this.inLogin.Controls.Add(this.LoginTextbox);
            this.inLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inLogin.Location = new System.Drawing.Point(1, 1);
            this.inLogin.Name = "inLogin";
            this.inLogin.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inLogin.Size = new System.Drawing.Size(152, 21);
            this.inLogin.TabIndex = 0;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.BackColor = System.Drawing.Color.White;
            this.PasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTextbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PasswordTextbox.Location = new System.Drawing.Point(3, 3);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(149, 16);
            this.PasswordTextbox.TabIndex = 13;
            // 
            // bdrPassword
            // 
            this.bdrPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.bdrPassword.Controls.Add(this.inPassword);
            this.bdrPassword.Location = new System.Drawing.Point(182, 64);
            this.bdrPassword.Name = "bdrPassword";
            this.bdrPassword.Padding = new System.Windows.Forms.Padding(1);
            this.bdrPassword.Size = new System.Drawing.Size(154, 23);
            this.bdrPassword.TabIndex = 15;
            // 
            // inPassword
            // 
            this.inPassword.BackColor = System.Drawing.Color.White;
            this.inPassword.Controls.Add(this.PasswordTextbox);
            this.inPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inPassword.Location = new System.Drawing.Point(1, 1);
            this.inPassword.Name = "inPassword";
            this.inPassword.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.inPassword.Size = new System.Drawing.Size(152, 21);
            this.inPassword.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(150, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(285, 105);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(120, 30);
            this.btnCancle.TabIndex = 15;
            this.btnCancle.Text = "닫기";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LoginInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(421, 156);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bdrPassword);
            this.Controls.Add(this.bdrLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginInfoForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoginInfoForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginInfoForm_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.bdrLogin.ResumeLayout(false);
            this.inLogin.ResumeLayout(false);
            this.inLogin.PerformLayout();
            this.bdrPassword.ResumeLayout(false);
            this.inPassword.ResumeLayout(false);
            this.inPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LoginTextbox;
        private System.Windows.Forms.Panel bdrLogin;
        private System.Windows.Forms.Panel inLogin;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Panel bdrPassword;
        private System.Windows.Forms.Panel inPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancle;
    }
}