namespace WindowsFormsApp2.Forms
{
    partial class DeptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.닫기btn = new System.Windows.Forms.ToolStripButton();
            this.삭제btn = new System.Windows.Forms.ToolStripButton();
            this.수정btn = new System.Windows.Forms.ToolStripButton();
            this.추가btn = new System.Windows.Forms.ToolStripButton();
            this.차트btn = new System.Windows.Forms.ToolStripButton();
            this.트리btn = new System.Windows.Forms.ToolStripButton();
            this.상위부서btn = new System.Windows.Forms.ToolStripButton();
            this.IblTitle = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.상위부서gridcontrol = new DevExpress.XtraGrid.GridControl();
            this.상위부서gridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.상위부서코드 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.상위부서명 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.상위메모 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.부서gridcontrol = new DevExpress.XtraGrid.GridControl();
            this.부서view = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.상위부서gridcontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.상위부서gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서gridcontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서view)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.닫기btn,
            this.삭제btn,
            this.수정btn,
            this.추가btn,
            this.차트btn,
            this.트리btn,
            this.상위부서btn,
            this.IblTitle});
            this.toolStrip1.Location = new System.Drawing.Point(1, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 8, 2);
            this.toolStrip1.Size = new System.Drawing.Size(800, 35);
            this.toolStrip1.TabIndex = 1;
            // 
            // 닫기btn
            // 
            this.닫기btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.닫기btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.닫기btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.닫기btn.Name = "닫기btn";
            this.닫기btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.닫기btn.Size = new System.Drawing.Size(50, 28);
            this.닫기btn.Text = "닫기";
            // 
            // 삭제btn
            // 
            this.삭제btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.삭제btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.삭제btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.삭제btn.Name = "삭제btn";
            this.삭제btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.삭제btn.Size = new System.Drawing.Size(50, 28);
            this.삭제btn.Text = "삭제";
            // 
            // 수정btn
            // 
            this.수정btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.수정btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.수정btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.수정btn.Name = "수정btn";
            this.수정btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.수정btn.Size = new System.Drawing.Size(50, 28);
            this.수정btn.Text = "수정";
            // 
            // 추가btn
            // 
            this.추가btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.추가btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.추가btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.추가btn.Name = "추가btn";
            this.추가btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.추가btn.Size = new System.Drawing.Size(50, 28);
            this.추가btn.Text = "추가";
            // 
            // 차트btn
            // 
            this.차트btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.차트btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.차트btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.차트btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.차트btn.Name = "차트btn";
            this.차트btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.차트btn.Size = new System.Drawing.Size(50, 28);
            this.차트btn.Text = "차트";
            // 
            // 트리btn
            // 
            this.트리btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.트리btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.트리btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.트리btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.트리btn.Name = "트리btn";
            this.트리btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.트리btn.Size = new System.Drawing.Size(50, 28);
            this.트리btn.Text = "트리";
            // 
            // 상위부서btn
            // 
            this.상위부서btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.상위부서btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.상위부서btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.상위부서btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.상위부서btn.Name = "상위부서btn";
            this.상위부서btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.상위부서btn.Size = new System.Drawing.Size(59, 28);
            this.상위부서btn.Text = "상위부서";
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
            this.splitContainerControl3.Panel1.Controls.Add(this.상위부서gridcontrol);
            this.splitContainerControl3.Panel1.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            // 
            // splitContainerControl3.Panel2
            // 
            this.splitContainerControl3.Panel2.Controls.Add(this.부서gridcontrol);
            this.splitContainerControl3.Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(800, 313);
            this.splitContainerControl3.SplitterPosition = 401;
            this.splitContainerControl3.TabIndex = 7;
            // 
            // 상위부서gridcontrol
            // 
            this.상위부서gridcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.상위부서gridcontrol.Location = new System.Drawing.Point(20, 20);
            this.상위부서gridcontrol.MainView = this.상위부서gridview;
            this.상위부서gridcontrol.Name = "상위부서gridcontrol";
            this.상위부서gridcontrol.Size = new System.Drawing.Size(361, 269);
            this.상위부서gridcontrol.TabIndex = 1;
            this.상위부서gridcontrol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.상위부서gridview});
            // 
            // 상위부서gridview
            // 
            this.상위부서gridview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.상위부서코드,
            this.상위부서명,
            this.상위메모});
            this.상위부서gridview.GridControl = this.상위부서gridcontrol;
            this.상위부서gridview.Name = "상위부서gridview";
            this.상위부서gridview.OptionsBehavior.Editable = false;
            this.상위부서gridview.OptionsPrint.PrintFooter = false;
            this.상위부서gridview.OptionsPrint.PrintGroupFooter = false;
            this.상위부서gridview.OptionsPrint.PrintHeader = false;
            this.상위부서gridview.OptionsView.ShowGroupPanel = false;
            // 
            // 상위부서코드
            // 
            this.상위부서코드.Caption = "상위부서코드";
            this.상위부서코드.Name = "상위부서코드";
            this.상위부서코드.Visible = true;
            this.상위부서코드.VisibleIndex = 0;
            // 
            // 상위부서명
            // 
            this.상위부서명.Caption = "상위부서명";
            this.상위부서명.Name = "상위부서명";
            this.상위부서명.Visible = true;
            this.상위부서명.VisibleIndex = 1;
            // 
            // 상위메모
            // 
            this.상위메모.Caption = "메모";
            this.상위메모.Name = "상위메모";
            this.상위메모.Visible = true;
            this.상위메모.VisibleIndex = 2;
            // 
            // 부서gridcontrol
            // 
            this.부서gridcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.부서gridcontrol.Location = new System.Drawing.Point(20, 20);
            this.부서gridcontrol.MainView = this.부서view;
            this.부서gridcontrol.Name = "부서gridcontrol";
            this.부서gridcontrol.Size = new System.Drawing.Size(345, 269);
            this.부서gridcontrol.TabIndex = 0;
            this.부서gridcontrol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.부서view});
            // 
            // 부서view
            // 
            this.부서view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.부서코드,
            this.부서명,
            this.메모});
            this.부서view.GridControl = this.부서gridcontrol;
            this.부서view.Name = "부서view";
            this.부서view.OptionsBehavior.Editable = false;
            this.부서view.OptionsPrint.PrintFooter = false;
            this.부서view.OptionsPrint.PrintGroupFooter = false;
            this.부서view.OptionsPrint.PrintHeader = false;
            this.부서view.OptionsView.ShowGroupPanel = false;
            // 
            // 부서코드
            // 
            this.부서코드.Caption = "부서코드";
            this.부서코드.Name = "부서코드";
            this.부서코드.Visible = true;
            this.부서코드.VisibleIndex = 0;
            // 
            // 부서명
            // 
            this.부서명.Caption = "부서명";
            this.부서명.Name = "부서명";
            this.부서명.Visible = true;
            this.부서명.VisibleIndex = 1;
            // 
            // 메모
            // 
            this.메모.Caption = "메모";
            this.메모.Name = "메모";
            this.메모.Visible = true;
            this.메모.VisibleIndex = 2;
            // 
            // DeptForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 350);
            this.Controls.Add(this.splitContainerControl3);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeptForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "부서";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel1)).EndInit();
            this.splitContainerControl3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3.Panel2)).EndInit();
            this.splitContainerControl3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.상위부서gridcontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.상위부서gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서gridcontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.부서view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 닫기btn;
        private System.Windows.Forms.ToolStripButton 삭제btn;
        private System.Windows.Forms.ToolStripButton 수정btn;
        private System.Windows.Forms.ToolStripButton 추가btn;
        private System.Windows.Forms.ToolStripLabel IblTitle;
        private System.Windows.Forms.ToolStripButton 상위부서btn;
        private System.Windows.Forms.ToolStripButton 차트btn;
        private System.Windows.Forms.ToolStripButton 트리btn;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraGrid.GridControl 부서gridcontrol;
        private DevExpress.XtraGrid.Views.Grid.GridView 부서view;
        private DevExpress.XtraGrid.GridControl 상위부서gridcontrol;
        private DevExpress.XtraGrid.Views.Grid.GridView 상위부서gridview;
        private DevExpress.XtraGrid.Columns.GridColumn 부서코드;
        private DevExpress.XtraGrid.Columns.GridColumn 부서명;
        private DevExpress.XtraGrid.Columns.GridColumn 메모;
        private DevExpress.XtraGrid.Columns.GridColumn 상위부서코드;
        private DevExpress.XtraGrid.Columns.GridColumn 상위부서명;
        private DevExpress.XtraGrid.Columns.GridColumn 상위메모;
    }
}