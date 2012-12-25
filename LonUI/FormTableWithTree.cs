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
    public partial class FormTableWithTree : DockContent
    {
        public FormTableWithTree()
        {
            InitializeComponent();
        }

        private void FormTableWithTree_Load(object sender, EventArgs e)
        {
            dgvTable.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvTable.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            splitMain.SplitterDistance=(int)((this.Width * 0.8));
            
        }

        private void treeTableSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
