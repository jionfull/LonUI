using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Lon.Cmd;
using System.Diagnostics;

namespace Lon.UI
{
    public class StripCfgLoad
    {
       
        private void DoRun(String cmdStr)
        {
            CmdManager.RunCmd(cmdStr);
        
        }
        public void LoadBtnToolStrip(ToolStrip ts, String fileName)
        {
            ts.SuspendLayout();
            if (fileName != null)
            {
                try
                {
                    String tempStr;
                    tempStr = fileName.Split(new char[] { '.' })[fileName.Split(new char[] { '.' }).Length - 1];
                    if (tempStr.ToUpper() == "XML" && File.Exists(fileName))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fileName);
                        XmlNode root = doc.SelectSingleNode("/root/buttons");
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {
                            XmlElement elem = (XmlElement)root.ChildNodes[i];
                            ToolStripButton btn = new ToolStripButton();
                            btn.Text = elem.Attributes["Text"].InnerText;
                            btn.Name = elem.Attributes["Name"].InnerText;
                            try
                            {
                                btn.Image = Image.FromFile(elem.Attributes["Image"].InnerText);
                            }
                            catch 
                            {
                                Trace.WriteLine("Error:加载工具栏按钮错误\""+btn.Name+"\" Image 加载错误");
                            }
                            
                            btn.Tag = elem.Attributes["Function"].InnerText;
                            try
                            {
                                string visibleStr = elem.Attributes["visible"].InnerText;
                                btn.Visible = bool.Parse(visibleStr);
                            }
                            catch
                            {
                                Trace.WriteLine("Error:加载工具栏按钮错误,按钮\""+btn.Name+"\" visble 解析错误");
                            }

                            try
                            {
                                string imgFileName = elem.Attributes["Image"].InnerText;
                                if (imgFileName != "" && File.Exists(imgFileName))
                                {
                                    btn.Image = Image.FromFile(imgFileName);
                                    
                                }
                            }
                            catch
                            {

                            }
                          
                            btn.TextImageRelation = TextImageRelation.ImageAboveText;
                            btn.Click += new EventHandler(menu_Click);
                            ts.Items.Add(btn);
                        }

                    }
                }
                catch (System.Exception ex)
                {
                    //ToDo:Log Message
                    Trace.WriteLine("Error:" + ex.Message + ex.StackTrace);
                }
            }


            ts.ResumeLayout(false);
            ts.PerformLayout();


        }

   
        public void LoadMenuStrip(MenuStrip ms, String fileName)
        {
            ms.SuspendLayout();
            if (fileName != null)
            {
                try
                {
                    String tempStr;
                    tempStr = fileName.Split(new char[] { '.' })[fileName.Split(new char[] { '.' }).Length - 1];
                    if (tempStr.ToUpper() == "XML" && File.Exists(fileName))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fileName);
                        XmlNode root = doc.SelectSingleNode("/root/Menus");
                        for (int i = 0; i < root.ChildNodes.Count; i++)
                        {
                            XmlElement elem = (XmlElement)root.ChildNodes[i];
                            ToolStripMenuItem tempMenu;
                            AddToolStripMenu(out tempMenu, elem);
                            ms.Items.Add(tempMenu);
                        }

                    }
                }
                catch (System.Exception ex)
                {
                    Trace.WriteLine("Error:加载菜单栏错误"+ex.Message);
                }
            }

            ms.ResumeLayout(false);
            ms.PerformLayout();

        }

        public void AddToolStripMenu(out ToolStripMenuItem menu, XmlElement elem)
        {
            menu = new ToolStripMenuItem(elem.Attributes["Text"].InnerText);
            menu.Name = elem.Attributes["Name"].InnerText;
            menu.Tag = elem.Attributes["Function"].InnerText;
            menu.Click += new EventHandler(menu_Click);
            try
            {
                string visibleStr = elem.Attributes["visible"].InnerText;
                menu.Visible = bool.Parse(visibleStr);
            }
            catch 
            {
                Trace.WriteLine("Error:加载菜单错误,菜单\"" + menu.Name + "\" visble 解析错误");
            }

            try
            {
                string imgFileName = elem.Attributes["Image"].InnerText;
                if (imgFileName != "" && File.Exists(imgFileName))
                {
                    menu.Image = Image.FromFile(imgFileName);
                }
            }
            catch 
            {
                Trace.WriteLine("Error:加载菜单栏错误， \"" + menu.Name + "\" Image 加载错误");
            }
            for (int i = 0; i < elem.ChildNodes.Count; i++)
            {
                XmlElement tempElem = (XmlElement)elem.ChildNodes[i];
                ToolStripMenuItem tempMenu;
                AddToolStripMenu(out tempMenu, tempElem);
                menu.DropDownItems.Add(tempMenu);
            }

        }

        void menu_Click(object sender, EventArgs e)
        {
            String cmdStr = (String)(((ToolStripItem)sender).Tag);
            DoRun(cmdStr);
        }
    }
}
