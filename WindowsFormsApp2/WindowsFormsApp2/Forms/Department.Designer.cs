namespace WindowsFormsApp2.Forms
{
    partial class Department
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Department));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.닫기버튼 = new System.Windows.Forms.ToolStripButton();
            this.삭제버튼 = new System.Windows.Forms.ToolStripButton();
            this.수정버튼 = new System.Windows.Forms.ToolStripButton();
            this.추가버튼 = new System.Windows.Forms.ToolStripButton();
            this.차트버튼 = new System.Windows.Forms.ToolStripButton();
            this.트리버튼 = new System.Windows.Forms.ToolStripButton();
            this.상위부서버튼 = new System.Windows.Forms.ToolStripButton();
            this.IblTitle = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.상위부서그리드컨트롤 = new DevExpress.XtraGrid.GridControl();
            this.상위부서그리드 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.상위부서코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.상위부서명 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.상위메모 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.부서그리드컨트롤 = new DevExpress.XtraGrid.GridControl();
            this.부서그리드 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.부서코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.부서명 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.메모 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel1)).BeginInit();
            this.splitContainerControl3.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel2)).BeginInit();
            this.splitContainerControl3.Panel2.SuspendLayout();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.상위부서그리드컨트롤)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.상위부서그리드)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서그리드컨트롤)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서그리드)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.닫기버튼,
            this.삭제버튼,
            this.수정버튼,
            this.추가버튼,
            this.차트버튼,
            this.트리버튼,
            this.상위부서버튼,
            this.IblTitle});
            this.toolStrip1.Location = new System.Drawing.Point(1, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 8, 2);
            this.toolStrip1.Size = new System.Drawing.Size(798, 35);
            this.toolStrip1.TabIndex = 1;
            // 
            // 닫기버튼
            // 
            this.닫기버튼.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.닫기버튼.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.닫기버튼.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.닫기버튼.Name = "닫기버튼";
            this.닫기버튼.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.닫기버튼.Size = new System.Drawing.Size(50, 28);
            this.닫기버튼.Text = "닫기";
            // 
            // 삭제버튼
            // 
            this.삭제버튼.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.삭제버튼.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.삭제버튼.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.삭제버튼.Name = "삭제버튼";
            this.삭제버튼.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.삭제버튼.Size = new System.Drawing.Size(50, 28);
            this.삭제버튼.Text = "삭제";
            // 
            // 수정버튼
            // 
            this.수정버튼.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.수정버튼.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.수정버튼.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.수정버튼.Name = "수정버튼";
            this.수정버튼.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.수정버튼.Size = new System.Drawing.Size(50, 28);
            this.수정버튼.Text = "수정";
            // 
            // 추가버튼
            // 
            this.추가버튼.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.추가버튼.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.추가버튼.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.추가버튼.Name = "추가버튼";
            this.추가버튼.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.추가버튼.Size = new System.Drawing.Size(50, 28);
            this.추가버튼.Text = "추가";
            // 
            // 차트버튼
            // 
            this.차트버튼.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.차트버튼.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.차트버튼.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.차트버튼.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.차트버튼.Name = "차트버튼";
            this.차트버튼.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.차트버튼.Size = new System.Drawing.Size(50, 28);
            this.차트버튼.Text = "차트";
            // 
            // 트리버튼
            // 
            this.트리버튼.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.트리버튼.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.트리버튼.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.트리버튼.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.트리버튼.Name = "트리버튼";
            this.트리버튼.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.트리버튼.Size = new System.Drawing.Size(50, 28);
            this.트리버튼.Text = "트리";
            // 
            // 상위부서버튼
            // 
            this.상위부서버튼.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.상위부서버튼.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.상위부서버튼.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.상위부서버튼.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.상위부서버튼.Name = "상위부서버튼";
            this.상위부서버튼.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.상위부서버튼.Size = new System.Drawing.Size(59, 28);
            this.상위부서버튼.Text = "상위부서";
            // 
            // IblTitle
            // 
            this.IblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.IblTitle.Image = ((System.Drawing.Image)(resources.GetObject("IblTitle.Image")));
            this.IblTitle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IblTitle.Name = "IblTitle";
            this.IblTitle.Size = new System.Drawing.Size(50, 28);
            this.IblTitle.Text = "부서";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl3.Location = new System.Drawing.Point(1, 36);
            this.splitContainerControl3.Name = "splitContainerControl3";
            // 
            // splitContainerControl3.Panel1
            // 
            this.splitContainerControl3.Panel1.Controls.Add(this.상위부서그리드컨트롤);
            this.splitContainerControl3.Panel1.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            // 
            // splitContainerControl3.Panel2
            // 
            this.splitContainerControl3.Panel2.Controls.Add(this.부서그리드컨트롤);
            this.splitContainerControl3.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(798, 313);
            this.splitContainerControl3.SplitterPosition = 399;
            this.splitContainerControl3.TabIndex = 7;
            // 
            // 상위부서그리드컨트롤
            // 
            this.상위부서그리드컨트롤.Dock = System.Windows.Forms.DockStyle.Fill;
            this.상위부서그리드컨트롤.Location = new System.Drawing.Point(20, 20);
            this.상위부서그리드컨트롤.MainView = this.상위부서그리드;
            this.상위부서그리드컨트롤.Name = "상위부서그리드컨트롤";
            this.상위부서그리드컨트롤.Size = new System.Drawing.Size(359, 269);
            this.상위부서그리드컨트롤.TabIndex = 1;
            this.상위부서그리드컨트롤.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.상위부서그리드});
            // 
            // 상위부서그리드
            // 
            this.상위부서그리드.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.상위부서코드,
            this.상위부서명,
            this.상위메모});
            this.상위부서그리드.GridControl = this.상위부서그리드컨트롤;
            this.상위부서그리드.Name = "상위부서그리드";
            this.상위부서그리드.OptionsBehavior.Editable = false;
            this.상위부서그리드.OptionsPrint.PrintFooter = false;
            this.상위부서그리드.OptionsPrint.PrintGroupFooter = false;
            this.상위부서그리드.OptionsPrint.PrintHeader = false;
            this.상위부서그리드.OptionsView.ShowGroupPanel = false;
            // 
            // 상위부서코드
            // 
            this.상위부서코드.Caption = "상위부서코드";
            this.상위부서코드.FieldName = "ParentDeptCode";
            this.상위부서코드.Name = "상위부서코드";
            this.상위부서코드.Visible = true;
            this.상위부서코드.VisibleIndex = 0;
            // 
            // 상위부서명
            // 
            this.상위부서명.Caption = "상위부서명";
            this.상위부서명.FieldName = "ParentDeptName";
            this.상위부서명.Name = "상위부서명";
            this.상위부서명.Visible = true;
            this.상위부서명.VisibleIndex = 1;
            // 
            // 상위메모
            // 
            this.상위메모.Caption = "메모";
            this.상위메모.FieldName = "ParentMemo";
            this.상위메모.Name = "상위메모";
            this.상위메모.Visible = true;
            this.상위메모.VisibleIndex = 2;
            // 
            // 부서그리드컨트롤
            // 
            this.부서그리드컨트롤.Dock = System.Windows.Forms.DockStyle.Fill;
            this.부서그리드컨트롤.Location = new System.Drawing.Point(20, 20);
            this.부서그리드컨트롤.MainView = this.부서그리드;
            this.부서그리드컨트롤.Name = "부서그리드컨트롤";
            this.부서그리드컨트롤.Size = new System.Drawing.Size(345, 269);
            this.부서그리드컨트롤.TabIndex = 0;
            this.부서그리드컨트롤.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.부서그리드});
            // 
            // 부서그리드
            // 
            this.부서그리드.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.부서코드,
            this.부서명,
            this.메모});
            this.부서그리드.GridControl = this.부서그리드컨트롤;
            this.부서그리드.Name = "부서그리드";
            this.부서그리드.OptionsBehavior.Editable = false;
            this.부서그리드.OptionsPrint.PrintFooter = false;
            this.부서그리드.OptionsPrint.PrintGroupFooter = false;
            this.부서그리드.OptionsPrint.PrintHeader = false;
            this.부서그리드.OptionsView.ShowGroupPanel = false;
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
            // 메모
            // 
            this.메모.Caption = "메모";
            this.메모.FieldName = "Memo";
            this.메모.Name = "메모";
            this.메모.Visible = true;
            this.메모.VisibleIndex = 2;
            // 
            // DepartmentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.splitContainerControl3);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DepartmentForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DepartmentForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel1)).EndInit();
            this.splitContainerControl3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel2)).EndInit();
            this.splitContainerControl3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.상위부서그리드컨트롤)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.상위부서그리드)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서그리드컨트롤)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서그리드)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 닫기버튼;
        private System.Windows.Forms.ToolStripButton 삭제버튼;
        private System.Windows.Forms.ToolStripButton 수정버튼;
        private System.Windows.Forms.ToolStripButton 추가버튼;
        private System.Windows.Forms.ToolStripLabel IblTitle;
        private System.Windows.Forms.ToolStripButton 상위부서버튼;
        private System.Windows.Forms.ToolStripButton 차트버튼;
        private System.Windows.Forms.ToolStripButton 트리버튼;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraGrid.GridControl 부서그리드컨트롤;
        private DevExpress.XtraGrid.Views.Grid.GridView 부서그리드;
        private DevExpress.XtraGrid.GridControl 상위부서그리드컨트롤;
        private DevExpress.XtraGrid.Views.Grid.GridView 상위부서그리드;
        private DevExpress.XtraGrid.Columns.GridColumn 부서코드;
        private DevExpress.XtraGrid.Columns.GridColumn 부서명;
        private DevExpress.XtraGrid.Columns.GridColumn 메모;
        private DevExpress.XtraGrid.Columns.GridColumn 상위부서코드;
        private DevExpress.XtraGrid.Columns.GridColumn 상위부서명;
        private DevExpress.XtraGrid.Columns.GridColumn 상위메모;
    }
}