using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Lon.UI
{
    public partial class FormDataGridView : DockContent
    {
        public FormDataGridView()
        {
            InitializeComponent();
        }
        public virtual bool Print()
        {
            MessageBox.Show("不能打印");
            return true;
        }
        public virtual bool Save()
        {
            MessageBox.Show("保存未实现");
            return true;
        }
        public virtual bool SaveAs()
        {
            MessageBox.Show("保存未实现");
            return true;
        }
        private void FormSourceGrid_Load(object sender, EventArgs e)
        {
            dgvTable.RowsDefaultCellStyle.BackColor=Color.Bisque;
            dgvTable.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            //DataGridViewColumn column = new DataGridViewColumn();
            //column.HeaderText = "测试列1";
            //column.CellType = typeof(string);
            //DataGridViewColumn column2 = new DataGridViewColumn();
            //column2.HeaderText = "测试列2";
            //column2.CellType = typeof(string);
            //DataGridViewRow row = new DataGridViewRow();
            //dgvTable.Columns.Add(column);
            ////dgvTable.Columns.Add(column2);
            //dgvTable.ColumnCount = 5;
            //dgvTable.Columns[2].Name = "B";
            //dgvTable.Columns[1].Name = "A";
            //dgvTable.Rows.Add(row);
            //dgvTable.Rows.Add(row.Clone());
            //dgvTable.Rows.Add(row.Clone());

        }
    }
}
