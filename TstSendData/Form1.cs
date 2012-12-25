using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lon.UI;

namespace TstSendData
{
    public partial class Form1 : Form
    {
        public delegate void DelegateShow(byte[] buf);
        FormDataShow formSendData = null;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(formSendData==null||formSendData.IsDisposed)
            {
                formSendData = new FormDataShow();
            }
            formSendData.Show();
            dataShow += formSendData.ShowData;
            formSendData.FormClosing += new FormClosingEventHandler(formSendData_FormClosing);
        }

        void formSendData_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataShow -= formSendData.ShowData;
        }
       
        event DelegateShow dataShow;
        private void button2_Click(object sender, EventArgs e)
        {
            DelegateShow tempdelegate = dataShow;
            if (tempdelegate == null) return;
            tempdelegate(new byte[] { 1, 2, 3 });
        }
    }
}
