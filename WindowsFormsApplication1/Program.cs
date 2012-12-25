using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lon.UI;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Object form = (object)(new FormDataGridView());
            if (form is IPrint) 
            {
                MessageBox.Show("Yes");
                ((IPrint)form).Print();
            }
            Application.Run(new FormDataGridView());
        }
    }
}
