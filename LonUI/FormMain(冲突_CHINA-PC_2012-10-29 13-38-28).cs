using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Lon.IO;
using Lon.Cmd;

namespace Lon.UI
{
    public partial class FormMain : Form
    {
        public bool enExit=true;
        public StripCfgLoad stripCfg = new StripCfgLoad();
        public CmdDict dict=null;
        
        public FormMain()
        {
            InitializeComponent();
            dict = new CmdDict(this);
            CmdManager.runCmd += dict.DoCmd;
           
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            stripCfg.LoadMenuStrip(msMain, "menu.Xml");
            stripCfg.LoadBtnToolStrip(tsMain, "menu.Xml");
            ChangeDefaultDisplay();
          
        }
        private void ChangeDefaultDisplay()
        {
            IniFile cfg = new IniFile(".\\MainForm.ini");
            cfg.Load();
            string tempText = cfg.GetString("显示文本", "标题");
            if(tempText!=null)
            {
                this.Text = tempText;
            }
            ChangeVisible(msMain, cfg.GetBool("显示控制", "菜单", true));
            ChangeVisible(tsMain, cfg.GetBool("显示控制", "工具栏", true));
            enExit = cfg.GetBool("功能", "允许关闭",true);
            if(!cfg.GetBool("显示控制", "标题栏", true))
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            if(cfg.GetBool("显示控制","最大化",true))
            {
                this.WindowState = FormWindowState.Maximized;
            }

        }
        public delegate void ShowTextDelegate(Control ctl, String text);
        public void ShowText(Control ctl, String txt)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ShowTextDelegate(ShowText), new object[] { ctl, txt });
            }
            else
            {
                ctl.Text = txt;
            }
        }

        public delegate void DisplayDelegate(Control ctl,bool display);

        public void ChangeVisible(Control ctl,bool visible)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new DisplayDelegate(ChangeVisible), new object[] { ctl, visible });
            }
            else
            {
                ctl.Visible = visible;
            }
        }

        public void HideMenu()
        {
           ChangeVisible(msMain,false);
        }
        [Cmd]
        public void HideMenu(String[] argsStr)
        {
            ChangeVisible(msMain, false);
        }

        public void ShowMenu()
        {
            ChangeVisible(msMain, true);
        }

        [Cmd]
        public void ShowMenu(String[] argsStr)
        {
            ChangeVisible(msMain, true);
        }

        public void HideToolBar()
        {
            ChangeVisible(tsMain, false);
        }

        [Cmd]
        public void HideToolBar(String[] argsStr)
         {
            ChangeVisible(tsMain, false);
         }

        public void ShowToolBar()
        {
            ChangeVisible(tsMain, true);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!enExit)
            {
                e.Cancel = true;
            }
        }



    }
}
