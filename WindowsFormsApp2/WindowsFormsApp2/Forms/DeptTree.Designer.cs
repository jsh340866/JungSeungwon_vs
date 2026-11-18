namespace WindowsFormsApp2.Forms
{
    partial class DeptTree
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
            this.트리판넬 = new System.Windows.Forms.Panel();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListBand1 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.treeListBand2 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.treeListBand3 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.treeListBand4 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.panel1.SuspendLayout();
            this.트리판넬.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 35);
            this.panel1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "트리";
            // 
            // 트리판넬
            // 
            this.트리판넬.BackColor = System.Drawing.Color.White;
            this.트리판넬.Controls.Add(this.treeList1);
            this.트리판넬.Dock = System.Windows.Forms.DockStyle.Fill;
            this.트리판넬.Location = new System.Drawing.Point(0, 35);
            this.트리판넬.Name = "트리판넬";
            this.트리판넬.Padding = new System.Windows.Forms.Padding(20);
            this.트리판넬.Size = new System.Drawing.Size(536, 547);
            this.트리판넬.TabIndex = 54;
            // 
            // treeList1
            // 
            this.treeList1.Bands.AddRange(new DevExpress.XtraTreeList.Columns.TreeListBand[] {
            this.treeListBand1,
            this.treeListBand2,
            this.treeListBand3,
            this.treeListBand4});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeList1.Location = new System.Drawing.Point(20, 20);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(496, 507);
            this.treeList1.TabIndex = 53;
            // 
            // treeListBand1
            // 
            this.treeListBand1.Caption = "treeListBand1";
            this.treeListBand1.Name = "treeListBand1";
            // 
            // treeListBand2
            // 
            this.treeListBand2.Caption = "treeListBand2";
            this.treeListBand2.Name = "treeListBand2";
            // 
            // treeListBand3
            // 
            this.treeListBand3.Caption = "treeListBand3";
            this.treeListBand3.Name = "treeListBand3";
            // 
            // treeListBand4
            // 
            this.treeListBand4.Caption = "treeListBand4";
            this.treeListBand4.Name = "treeListBand4";
            // 
            // DeptTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 582);
            this.Controls.Add(this.트리판넬);
            this.Controls.Add(this.panel1);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeptTree";
            this.Text = "DeptTree";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.트리판넬.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel 트리판넬;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand1;
        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand2;
        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand3;
        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand4;
    }
}