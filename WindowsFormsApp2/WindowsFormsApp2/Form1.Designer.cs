namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnConvert = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnLoginInfo = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnDept = new System.Windows.Forms.ToolStripButton();
            this.IblTitle = new System.Windows.Forms.ToolStripLabel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.colDeptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessesgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnConvert,
            this.btnDelete,
            this.btnLoginInfo,
            this.btnEdit,
            this.btnAdd,
            this.btnSearch,
            this.btnDept,
            this.IblTitle});
            this.toolStrip1.Location = new System.Drawing.Point(1, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 8, 2);
            this.toolStrip1.Size = new System.Drawing.Size(1104, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(65, 28);
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConvert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnConvert.Size = new System.Drawing.Size(89, 28);
            this.btnConvert.Text = "자료변환";
            // 
            // btnDelete
            // 
            this.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(65, 28);
            this.btnDelete.Text = "삭제";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoginInfo
            // 
            this.btnLoginInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLoginInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnLoginInfo.Name = "btnLoginInfo";
            this.btnLoginInfo.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnLoginInfo.Size = new System.Drawing.Size(101, 28);
            this.btnLoginInfo.Text = "로그인정보";
            this.btnLoginInfo.Click += new System.EventHandler(this.btnLoginInfo_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnEdit.Size = new System.Drawing.Size(65, 28);
            this.btnEdit.Text = "수정";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(65, 28);
            this.btnAdd.Text = "추가";
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(65, 28);
            this.btnSearch.Text = "조회";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDept
            // 
            this.btnDept.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnDept.Name = "btnDept";
            this.btnDept.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnDept.Size = new System.Drawing.Size(65, 28);
            this.btnDept.Text = "부서";
            // 
            // IblTitle
            // 
            this.IblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.IblTitle.Image = ((System.Drawing.Image)(resources.GetObject("IblTitle.Image")));
            this.IblTitle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IblTitle.Name = "IblTitle";
            this.IblTitle.Size = new System.Drawing.Size(76, 28);
            this.IblTitle.Text = "부서사원";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.DataGridView);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(1, 36);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.pnlGrid.Size = new System.Drawing.Size(1104, 266);
            this.pnlGrid.TabIndex = 4;
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.ColumnHeadersHeight = 31;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeptCode,
            this.colDeptName,
            this.colEmpcode,
            this.colEmpName,
            this.colLoginId,
            this.colPassword,
            this.colPosition,
            this.colEmployType,
            this.colMobile,
            this.colEmail,
            this.colMessesgerId,
            this.colMemo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.EnableHeadersVisualStyles = false;
            this.DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.DataGridView.Location = new System.Drawing.Point(0, 18);
            this.DataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView.RowHeadersWidth = 20;
            this.DataGridView.RowTemplate.Height = 24;
            this.DataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(1104, 248);
            this.DataGridView.TabIndex = 4;
            this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
            // 
            // colDeptCode
            // 
            this.colDeptCode.DataPropertyName = "DeptCode";
            this.colDeptCode.HeaderText = "부서코드";
            this.colDeptCode.Name = "colDeptCode";
            this.colDeptCode.ReadOnly = true;
            // 
            // colDeptName
            // 
            this.colDeptName.DataPropertyName = "DeptName";
            this.colDeptName.HeaderText = "부서명";
            this.colDeptName.Name = "colDeptName";
            this.colDeptName.ReadOnly = true;
            // 
            // colEmpcode
            // 
            this.colEmpcode.DataPropertyName = "EmpCode";
            this.colEmpcode.HeaderText = "사원코드";
            this.colEmpcode.Name = "colEmpcode";
            this.colEmpcode.ReadOnly = true;
            // 
            // colEmpName
            // 
            this.colEmpName.DataPropertyName = "EmpName";
            this.colEmpName.HeaderText = "사원명";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            // 
            // colLoginId
            // 
            this.colLoginId.DataPropertyName = "LoginId";
            this.colLoginId.HeaderText = "로그인ID";
            this.colLoginId.Name = "colLoginId";
            this.colLoginId.ReadOnly = true;
            // 
            // colPassword
            // 
            this.colPassword.DataPropertyName = "Password";
            this.colPassword.HeaderText = "비밀번호";
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "Position";
            this.colPosition.HeaderText = "직위";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colEmployType
            // 
            this.colEmployType.DataPropertyName = "EmpType";
            this.colEmployType.HeaderText = "고용형태";
            this.colEmployType.Name = "colEmployType";
            this.colEmployType.ReadOnly = true;
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "Phone";
            this.colMobile.HeaderText = "휴대전화";
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "이메일";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colMessesgerId
            // 
            this.colMessesgerId.DataPropertyName = "MessengerId";
            this.colMessesgerId.HeaderText = "메신저ID";
            this.colMessesgerId.Name = "colMessesgerId";
            this.colMessesgerId.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.DataPropertyName = "Memo";
            this.colMemo.HeaderText = "메모";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1106, 303);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서사원";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDept;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnLoginInfo;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnConvert;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ToolStripLabel IblTitle;
        internal System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessesgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
    }
}

