namespace WindowsFormsApp2.Forms
{
    partial class DeleteForm
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
            this.EmployeeDelete = new System.Windows.Forms.ToolStrip();
            this.제목label = new System.Windows.Forms.Label();
            this.메시지label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.삭제btn = new System.Windows.Forms.Button();
            this.취소btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeDelete
            // 
            this.EmployeeDelete.AutoSize = false;
            this.EmployeeDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.EmployeeDelete.Dock = System.Windows.Forms.DockStyle.None;
            this.EmployeeDelete.Location = new System.Drawing.Point(522, 72);
            this.EmployeeDelete.Name = "EmployeeDelete";
            this.EmployeeDelete.Size = new System.Drawing.Size(111, 25);
            this.EmployeeDelete.TabIndex = 0;
            this.EmployeeDelete.Text = "toolStrip1";
            // 
            // 제목label
            // 
            this.제목label.AutoSize = true;
            this.제목label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.제목label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.제목label.Location = new System.Drawing.Point(9, 8);
            this.제목label.Margin = new System.Windows.Forms.Padding(0);
            this.제목label.Name = "제목label";
            this.제목label.Size = new System.Drawing.Size(34, 17);
            this.제목label.TabIndex = 1;
            this.제목label.Text = "제목";
            // 
            // 메시지label
            // 
            this.메시지label.AutoSize = true;
            this.메시지label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.메시지label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.메시지label.Location = new System.Drawing.Point(10, 43);
            this.메시지label.Name = "메시지label";
            this.메시지label.Size = new System.Drawing.Size(47, 17);
            this.메시지label.TabIndex = 5;
            this.메시지label.Text = "메시지";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.제목label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 35);
            this.panel1.TabIndex = 7;
            // 
            // 삭제btn
            // 
            this.삭제btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.삭제btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(80)))), ((int)(((byte)(59)))));
            this.삭제btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.삭제btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.삭제btn.ForeColor = System.Drawing.Color.White;
            this.삭제btn.Location = new System.Drawing.Point(68, 123);
            this.삭제btn.Name = "삭제btn";
            this.삭제btn.Size = new System.Drawing.Size(120, 30);
            this.삭제btn.TabIndex = 8;
            this.삭제btn.Text = "삭제";
            this.삭제btn.UseVisualStyleBackColor = false;
            // 
            // 취소btn
            // 
            this.취소btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.취소btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.취소btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.취소btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.취소btn.ForeColor = System.Drawing.Color.White;
            this.취소btn.Location = new System.Drawing.Point(203, 123);
            this.취소btn.Name = "취소btn";
            this.취소btn.Size = new System.Drawing.Size(120, 30);
            this.취소btn.TabIndex = 9;
            this.취소btn.Text = "취소";
            this.취소btn.UseVisualStyleBackColor = false;
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(332, 163);
            this.Controls.Add(this.취소btn);
            this.Controls.Add(this.삭제btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.메시지label);
            this.Controls.Add(this.EmployeeDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "삭제";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip EmployeeDelete;
        private System.Windows.Forms.Label 제목label;
        private System.Windows.Forms.Label 메시지label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button 삭제btn;
        private System.Windows.Forms.Button 취소btn;
    }
}