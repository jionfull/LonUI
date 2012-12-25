using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;
using System.Diagnostics;

namespace Lon.UI
{
    public partial class FormOut : DockContent
    {
        private static FormOut instance = new FormOut();
        Queue<string> showTextQuene = null;
        AutoResetEvent haveTxtToShow = new AutoResetEvent(false);
        private bool outRangeTaced = false;
        Thread txtShowThread = null;
        public int maxCount;

        private FormOut()
        {
            InitializeComponent();
            showTextQuene = new Queue<string>(maxCount);
            txtShowThread = new Thread(new ThreadStart(TxtShowProc));
            txtShowThread.IsBackground = true;
            txtShowThread.Start();
        }

        public static FormOut GetInstance()
        {
            return instance;
        }

        void TxtShowProc()
        {
            String txt = null;
            haveTxtToShow.WaitOne(-1, true);
            lock (showTextQuene)
            {
                if (showTextQuene.Count > 0) txt = showTextQuene.Dequeue();
                if (showTextQuene.Count > 0) haveTxtToShow.Set();

            }
            if (txt != null) AppendText(txtMessage, txt);
        }

        delegate void DelegateShowText(TextBox ctl, String txt);

        public void AppendText(TextBox ctl, string txt)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateShowText(AppendText), new object[] { ctl, txt });
            }
            else
            {
                ctl.AppendText(txt);
            }
        }

        public void ShowText(String txt)
        {
            lock (showTextQuene)
            {
                if (showTextQuene.Count > maxCount)
                {
                    if (outRangeTaced) return;
                    Trace.WriteLine("Waring:" + DateTime.Now.ToLongTimeString() + "\r\n"
                                     + "调试数据显示窗口由于数据条数过多有部分未显示" + this.Text);
                    outRangeTaced = true;
                    return;
                }
                showTextQuene.Enqueue(txt);

            }


        }

        private void FormOut_Load(object sender, EventArgs e)
        {

        }
    }
}
