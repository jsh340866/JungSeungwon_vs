namespace WindowsFormsApp2.Forms
{
    partial class ParentDeptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentDeptForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.닫기 = new System.Windows.Forms.ToolStripButton();
            this.삭제 = new System.Windows.Forms.ToolStripButton();
            this.수정 = new System.Windows.Forms.ToolStripButton();
            this.추가 = new System.Windows.Forms.ToolStripButton();
            this.자료변환 = new System.Windows.Forms.ToolStripButton();
            this.IblTitle = new System.Windows.Forms.ToolStripLabel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.그리드컨트롤 = new DevExpress.XtraGrid.GridControl();
            this.그리드뷰 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.상위부서코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.상위부서명 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.메모 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.그리드컨트롤)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.그리드뷰)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.닫기,
            this.삭제,
            this.수정,
            this.추가,
            this.자료변환,
            this.IblTitle});
            this.toolStrip1.Location = new System.Drawing.Point(1, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 8, 2);
            this.toolStrip1.Size = new System.Drawing.Size(498, 35);
            this.toolStrip1.TabIndex = 6;
            // 
            // 닫기
            // 
            this.닫기.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.닫기.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.닫기.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.닫기.Name = "닫기";
            this.닫기.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.닫기.Size = new System.Drawing.Size(50, 28);
            this.닫기.Text = "닫기";
            // 
            // 삭제
            // 
            this.삭제.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.삭제.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.삭제.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.삭제.Name = "삭제";
            this.삭제.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.삭제.Size = new System.Drawing.Size(50, 28);
            this.삭제.Text = "삭제";
            // 
            // 수정
            // 
            this.수정.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.수정.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.수정.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.수정.Name = "수정";
            this.수정.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.수정.Size = new System.Drawing.Size(50, 28);
            this.수정.Text = "수정";
            // 
            // 추가
            // 
            this.추가.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.추가.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.추가.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.추가.Name = "추가";
            this.추가.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.추가.Size = new System.Drawing.Size(50, 28);
            this.추가.Text = "추가";
            // 
            // 자료변환
            // 
            this.자료변환.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.자료변환.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.자료변환.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.자료변환.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.자료변환.Name = "자료변환";
            this.자료변환.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.자료변환.Size = new System.Drawing.Size(59, 28);
            this.자료변환.Text = "자료변환";
            // 
            // IblTitle
            // 
            this.IblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.IblTitle.Image = ((System.Drawing.Image)(resources.GetObject("IblTitle.Image")));
            this.IblTitle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IblTitle.Name = "IblTitle";
            this.IblTitle.Size = new System.Drawing.Size(76, 28);
            this.IblTitle.Text = "상위부서";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.그리드컨트롤);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(1, 1);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.pnlGrid.Size = new System.Drawing.Size(498, 348);
            this.pnlGrid.TabIndex = 7;
            // 
            // 그리드컨트롤
            // 
            this.그리드컨트롤.Location = new System.Drawing.Point(0, 50);
            this.그리드컨트롤.MainView = this.그리드뷰;
            this.그리드컨트롤.Name = "그리드컨트롤";
            this.그리드컨트롤.Size = new System.Drawing.Size(498, 264);
            this.그리드컨트롤.TabIndex = 0;
            this.그리드컨트롤.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.그리드뷰});
            // 
            // 그리드뷰
            // 
            this.그리드뷰.Appearance.FixedLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.그리드뷰.Appearance.FixedLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.그리드뷰.Appearance.FixedLine.Options.UseFont = true;
            this.그리드뷰.Appearance.FixedLine.Options.UseForeColor = true;
            this.그리드뷰.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.그리드뷰.Appearance.HeaderPanel.Options.UseFont = true;
            this.그리드뷰.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.그리드뷰.Appearance.Row.Options.UseFont = true;
            this.그리드뷰.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.그리드뷰.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.그리드뷰.AppearancePrint.Row.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.그리드뷰.AppearancePrint.Row.Options.UseFont = true;
            this.그리드뷰.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.상위부서코드,
            this.상위부서명,
            this.메모});
            this.그리드뷰.GridControl = this.그리드컨트롤;
            this.그리드뷰.Name = "그리드뷰";
            this.그리드뷰.OptionsBehavior.Editable = false;
            this.그리드뷰.OptionsBehavior.ReadOnly = true;
            this.그리드뷰.OptionsPrint.PrintFooter = false;
            this.그리드뷰.OptionsView.ShowGroupPanel = false;
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
            // 메모
            // 
            this.메모.Caption = "메모";
            this.메모.FieldName = "ParentMemo";
            this.메모.Name = "메모";
            this.메모.Visible = true;
            this.메모.VisibleIndex = 2;
            // 
            // ParentDeptForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ParentDeptForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ParentForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.그리드컨트롤)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.그리드뷰)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 닫기;
        private System.Windows.Forms.ToolStripButton 삭제;
        private System.Windows.Forms.ToolStripButton 수정;
        private System.Windows.Forms.ToolStripButton 추가;
        private System.Windows.Forms.ToolStripButton 자료변환;
        private System.Windows.Forms.ToolStripLabel IblTitle;
        private System.Windows.Forms.Panel pnlGrid;
        private DevExpress.XtraGrid.GridControl 그리드컨트롤;
        private DevExpress.XtraGrid.Views.Grid.GridView 그리드뷰;
        private DevExpress.XtraGrid.Columns.GridColumn 상위부서코드;
        private DevExpress.XtraGrid.Columns.GridColumn 상위부서명;
        private DevExpress.XtraGrid.Columns.GridColumn 메모;
    }
}