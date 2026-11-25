namespace WindowsFormsApp2.Forms
{
    partial class EmpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.닫기btn = new System.Windows.Forms.ToolStripButton();
            this.자료변환btn = new System.Windows.Forms.ToolStripButton();
            this.삭제btn = new System.Windows.Forms.ToolStripButton();
            this.로그인정보btn = new System.Windows.Forms.ToolStripButton();
            this.수정btn = new System.Windows.Forms.ToolStripButton();
            this.추가btn = new System.Windows.Forms.ToolStripButton();
            this.다중추가btn = new System.Windows.Forms.ToolStripButton();
            this.조회btn = new System.Windows.Forms.ToolStripButton();
            this.부서btn = new System.Windows.Forms.ToolStripButton();
            this.IblTitle = new System.Windows.Forms.ToolStripLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.부서코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.부서명 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.사원코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.사원명 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.로그인ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.비밀번호 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoPassword = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.직위 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.고용형태 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.성별 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.휴대전화 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.이메일 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.메신저ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.메모 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.판넬그리드 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoPassword)).BeginInit();
            this.판넬그리드.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.닫기btn,
            this.자료변환btn,
            this.삭제btn,
            this.로그인정보btn,
            this.수정btn,
            this.추가btn,
            this.다중추가btn,
            this.조회btn,
            this.부서btn,
            this.IblTitle});
            this.toolStrip1.Location = new System.Drawing.Point(1, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 8, 2);
            this.toolStrip1.Size = new System.Drawing.Size(1104, 35);
            this.toolStrip1.TabIndex = 0;
            // 
            // 닫기btn
            // 
            this.닫기btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.닫기btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.닫기btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.닫기btn.Name = "닫기btn";
            this.닫기btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.닫기btn.Size = new System.Drawing.Size(65, 28);
            this.닫기btn.Text = "닫기";
            // 
            // 자료변환btn
            // 
            this.자료변환btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.자료변환btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.자료변환btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.자료변환btn.Name = "자료변환btn";
            this.자료변환btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.자료변환btn.Size = new System.Drawing.Size(89, 28);
            this.자료변환btn.Text = "자료변환";
            // 
            // 삭제btn
            // 
            this.삭제btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.삭제btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.삭제btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.삭제btn.Name = "삭제btn";
            this.삭제btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.삭제btn.Size = new System.Drawing.Size(65, 28);
            this.삭제btn.Text = "삭제";
            // 
            // 로그인정보btn
            // 
            this.로그인정보btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.로그인정보btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.로그인정보btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.로그인정보btn.Name = "로그인정보btn";
            this.로그인정보btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.로그인정보btn.Size = new System.Drawing.Size(101, 28);
            this.로그인정보btn.Text = "로그인정보";
            // 
            // 수정btn
            // 
            this.수정btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.수정btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.수정btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.수정btn.Name = "수정btn";
            this.수정btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.수정btn.Size = new System.Drawing.Size(65, 28);
            this.수정btn.Text = "수정";
            // 
            // 추가btn
            // 
            this.추가btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.추가btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.추가btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.추가btn.Name = "추가btn";
            this.추가btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.추가btn.Size = new System.Drawing.Size(65, 28);
            this.추가btn.Text = "추가";
            // 
            // 다중추가btn
            // 
            this.다중추가btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.다중추가btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.다중추가btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.다중추가btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.다중추가btn.Name = "다중추가btn";
            this.다중추가btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.다중추가btn.Size = new System.Drawing.Size(89, 28);
            this.다중추가btn.Text = "다중추가";
            this.다중추가btn.ToolTipText = "다중추가";
            // 
            // 조회btn
            // 
            this.조회btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.조회btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.조회btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.조회btn.Name = "조회btn";
            this.조회btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.조회btn.Size = new System.Drawing.Size(65, 28);
            this.조회btn.Text = "조회";
            // 
            // 부서btn
            // 
            this.부서btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.부서btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.부서btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.부서btn.Name = "부서btn";
            this.부서btn.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.부서btn.Size = new System.Drawing.Size(65, 28);
            this.부서btn.Text = "부서";
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
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gridControl.Location = new System.Drawing.Point(1, 20);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoPassword});
            this.gridControl.Size = new System.Drawing.Size(1102, 245);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.gridView.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView.AppearancePrint.Row.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.gridView.AppearancePrint.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.부서코드,
            this.부서명,
            this.사원코드,
            this.사원명,
            this.로그인ID,
            this.비밀번호,
            this.직위,
            this.고용형태,
            this.성별,
            this.휴대전화,
            this.이메일,
            this.메신저ID,
            this.메모});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // 부서코드
            // 
            this.부서코드.Caption = "부서코드";
            this.부서코드.FieldName = "DeptCode";
            this.부서코드.Name = "부서코드";
            this.부서코드.Visible = true;
            this.부서코드.VisibleIndex = 0;
            // 
            // 부서명
            // 
            this.부서명.Caption = "부서명";
            this.부서명.FieldName = "DeptName";
            this.부서명.Name = "부서명";
            this.부서명.Visible = true;
            this.부서명.VisibleIndex = 1;
            // 
            // 사원코드
            // 
            this.사원코드.Caption = "사원코드";
            this.사원코드.FieldName = "EmpCode";
            this.사원코드.Name = "사원코드";
            this.사원코드.Visible = true;
            this.사원코드.VisibleIndex = 2;
            // 
            // 사원명
            // 
            this.사원명.Caption = "사원명";
            this.사원명.FieldName = "EmpName";
            this.사원명.Name = "사원명";
            this.사원명.Visible = true;
            this.사원명.VisibleIndex = 3;
            // 
            // 로그인ID
            // 
            this.로그인ID.Caption = "로그인ID";
            this.로그인ID.FieldName = "LoginId";
            this.로그인ID.Name = "로그인ID";
            this.로그인ID.Visible = true;
            this.로그인ID.VisibleIndex = 4;
            // 
            // 비밀번호
            // 
            this.비밀번호.Caption = "비밀번호";
            this.비밀번호.ColumnEdit = this.repoPassword;
            this.비밀번호.FieldName = "Password";
            this.비밀번호.Name = "비밀번호";
            this.비밀번호.Visible = true;
            this.비밀번호.VisibleIndex = 5;
            // 
            // repoPassword
            // 
            this.repoPassword.AutoHeight = false;
            this.repoPassword.Name = "repoPassword";
            this.repoPassword.PasswordChar = '*';
            // 
            // 직위
            // 
            this.직위.Caption = "직위";
            this.직위.FieldName = "Position";
            this.직위.Name = "직위";
            this.직위.Visible = true;
            this.직위.VisibleIndex = 6;
            // 
            // 고용형태
            // 
            this.고용형태.Caption = "고용형태";
            this.고용형태.FieldName = "EmpType";
            this.고용형태.Name = "고용형태";
            this.고용형태.Visible = true;
            this.고용형태.VisibleIndex = 7;
            // 
            // 성별
            // 
            this.성별.Caption = "성별";
            this.성별.FieldName = "Gender";
            this.성별.Name = "성별";
            this.성별.Visible = true;
            this.성별.VisibleIndex = 8;
            // 
            // 휴대전화
            // 
            this.휴대전화.Caption = "휴대전화";
            this.휴대전화.FieldName = "Phone";
            this.휴대전화.Name = "휴대전화";
            this.휴대전화.Visible = true;
            this.휴대전화.VisibleIndex = 9;
            // 
            // 이메일
            // 
            this.이메일.Caption = "이메일";
            this.이메일.FieldName = "Email";
            this.이메일.Name = "이메일";
            this.이메일.Visible = true;
            this.이메일.VisibleIndex = 10;
            // 
            // 메신저ID
            // 
            this.메신저ID.Caption = "메신저ID";
            this.메신저ID.FieldName = "MessengerId";
            this.메신저ID.Name = "메신저ID";
            this.메신저ID.Visible = true;
            this.메신저ID.VisibleIndex = 11;
            // 
            // 메모
            // 
            this.메모.Caption = "메모";
            this.메모.FieldName = "Memo";
            this.메모.Name = "메모";
            this.메모.Visible = true;
            this.메모.VisibleIndex = 12;
            // 
            // 판넬그리드
            // 
            this.판넬그리드.Controls.Add(this.gridControl);
            this.판넬그리드.Dock = System.Windows.Forms.DockStyle.Fill;
            this.판넬그리드.Location = new System.Drawing.Point(1, 36);
            this.판넬그리드.Name = "판넬그리드";
            this.판넬그리드.Padding = new System.Windows.Forms.Padding(1, 20, 1, 1);
            this.판넬그리드.Size = new System.Drawing.Size(1104, 266);
            this.판넬그리드.TabIndex = 2;
            // 
            // EmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1106, 303);
            this.Controls.Add(this.판넬그리드);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmpForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "부서사원";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoPassword)).EndInit();
            this.판넬그리드.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 부서btn;
        private System.Windows.Forms.ToolStripButton 조회btn;
        private System.Windows.Forms.ToolStripButton 추가btn;
        private System.Windows.Forms.ToolStripButton 수정btn;
        private System.Windows.Forms.ToolStripButton 로그인정보btn;
        private System.Windows.Forms.ToolStripButton 삭제btn;
        private System.Windows.Forms.ToolStripButton 자료변환btn;
        private System.Windows.Forms.ToolStripButton 닫기btn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripLabel IblTitle;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn 부서코드;
        private DevExpress.XtraGrid.Columns.GridColumn 부서명;
        private DevExpress.XtraGrid.Columns.GridColumn 사원코드;
        private DevExpress.XtraGrid.Columns.GridColumn 사원명;
        private DevExpress.XtraGrid.Columns.GridColumn 로그인ID;
        private DevExpress.XtraGrid.Columns.GridColumn 비밀번호;
        private DevExpress.XtraGrid.Columns.GridColumn 직위;
        private DevExpress.XtraGrid.Columns.GridColumn 고용형태;
        private DevExpress.XtraGrid.Columns.GridColumn 성별;
        private DevExpress.XtraGrid.Columns.GridColumn 휴대전화;
        private DevExpress.XtraGrid.Columns.GridColumn 이메일;
        private DevExpress.XtraGrid.Columns.GridColumn 메신저ID;
        private DevExpress.XtraGrid.Columns.GridColumn 메모;
        private System.Windows.Forms.ToolStripButton 다중추가btn;
        private System.Windows.Forms.Panel 판넬그리드;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repoPassword;
    }
}

