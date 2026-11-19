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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.트리판넬 = new System.Windows.Forms.Panel();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.panel1.SuspendLayout();
            this.트리판넬.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 36);
            this.panel1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(9, 10);
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
            this.트리판넬.Location = new System.Drawing.Point(1, 37);
            this.트리판넬.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.트리판넬.Name = "트리판넬";
            this.트리판넬.Padding = new System.Windows.Forms.Padding(20, 25, 20, 25);
            this.트리판넬.Size = new System.Drawing.Size(534, 570);
            this.트리판넬.TabIndex = 54;
            // 
            // treeList1
            // 
            this.treeList1.ChildListFieldName = "사원";
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeList1.KeyFieldName = "";
            this.treeList1.Location = new System.Drawing.Point(20, 25);
            this.treeList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "";
            this.treeList1.Size = new System.Drawing.Size(494, 520);
            this.treeList1.TabIndex = 53;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // DeptTree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 608);
            this.Controls.Add(this.트리판넬);
            this.Controls.Add(this.panel1);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeptTree";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "DeptTree";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.트리판넬.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel 트리판넬;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraTreeList.TreeList treeList1;
    }
}