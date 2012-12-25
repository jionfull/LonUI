namespace Lon.UI
{
    partial class FormTableWithTree
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.treeTableSelect = new System.Windows.Forms.TreeView();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvTable);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.treeTableSelect);
            this.splitMain.Size = new System.Drawing.Size(846, 491);
            this.splitMain.SplitterDistance = 281;
            this.splitMain.TabIndex = 0;
            // 
            // dgvTable
            // 
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(0, 0);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowTemplate.Height = 23;
            this.dgvTable.Size = new System.Drawing.Size(281, 491);
            this.dgvTable.TabIndex = 0;
            // 
            // treeTableSelect
            // 
            this.treeTableSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTableSelect.Location = new System.Drawing.Point(0, 0);
            this.treeTableSelect.Name = "treeTableSelect";
            this.treeTableSelect.Size = new System.Drawing.Size(561, 491);
            this.treeTableSelect.TabIndex = 0;
            this.treeTableSelect.Click += new System.EventHandler(this.treeTableSelect_Click);
            // 
            // FormTableWithTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 491);
            this.Controls.Add(this.splitMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormTableWithTree";
            this.Text = "FormTableWithTree";
            this.Load += new System.EventHandler(this.FormTableWithTree_Load);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvTable;
        public System.Windows.Forms.TreeView treeTableSelect;
        public System.Windows.Forms.SplitContainer splitMain;
    }
}