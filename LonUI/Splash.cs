using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lon.IO;
using System.Threading;
using System.IO;
using Lon.Util;
using System.Diagnostics;

namespace Lon.UI
{
    public partial class Splash : Form
    {
        private static readonly  Splash instance=new Splash();
        static Thread showThread = null;
        private Splash()
        {
            InitializeComponent();
            
            try
            {
                IniFile cfg = new IniFile("SplashCfg.ini");
                cfg.Load();
                String backImgFileName = cfg.GetString("配置", "背景图片");
                this.BackgroundImage = Image.FromFile(backImgFileName);
                String progTile = cfg.GetString("配置", "程序名称");
                this.lblProgName.Text = progTile;
               
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Error:" + ex.Message + ex.Source + ex.StackTrace);
            }
           
        }

        public static void ShowSplash()
        {
            if(showThread==null||!showThread.IsAlive)
            {
                showThread = new Thread(new ThreadStart(ShowThread));
                showThread.IsBackground = true;
                showThread.Start();
            }         
        }
        public static void ShowSplashMess(String txt)
        {
              instance.ShowMess(txt);
        }

        public static void ShowThread()
        {
            instance.ShowDialog();
        }

        public static void CloseSplash()
        {
              instance.ThreadClose();
        }

        public delegate void ShowMessDelegate(String txt);
        
        public void ShowMess(String txt)
        {
            try
            {
                if (InvokeRequired)
                 {
                     this.Invoke(new ShowMessDelegate(ShowMess), new object[] { txt });
                 }
                 else
                 {
                     instance.lblMess.Text = txt;
                 }
            }
            catch(Exception ex)
            {
                Trace.WriteLine("Error:Splash窗口显示信息出错"+ex.Message+ex.Source+ex.TargetSite+ex.InnerException);
            }
               
        }

        public delegate void ThreadCloseDelegate();
        
        public void ThreadClose()
        {
           if(this.InvokeRequired)
           {
               this.Invoke(new ThreadCloseDelegate(ThreadClose));

           }
           else
           {
               this.Close();
           }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            SetBounds((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2, Width, Height, BoundsSpecified.Location);
            try
            {
                IniFile cfg = new IniFile("SplashCfg.ini");
                cfg.Load();
                String backImgFileName =".\\"+cfg.GetString("配置", "背景图片");
                
                if(File.Exists(backImgFileName))
                {
                    this.BackgroundImage = Image.FromFile(backImgFileName);
                }
                
                String progTile = cfg.GetString("配置", "程序名称");
                this.lblProgName.Text = progTile;
                this.lblMess.BackColor = Color.Transparent;
                this.lblProgName.BackColor = Color.Transparent;

            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Error:" + ex.Message + ex.Source + ex.StackTrace);
            }
        }
    }

}
