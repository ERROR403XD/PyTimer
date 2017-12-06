using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using IronPython;
using IronPython.Hosting;
using IronPython.Modules;
using System.Xml;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;




namespace PyTimer
{
    public partial class PyTimer : Form
    {
        private Random rd;
        private static DirectoryInfo m_PysPath;
        public static ScriptEngine pyEngine; 

        public static DirectoryInfo PysPath
        {
            get
            {
                return m_PysPath;
            }
        }
        public static PyTimer instance;
        private string configPath;
        private XmlDocument configXml;
        private XmlNode rootNode;

        public PyTimer()
        {
            if(PyTimer.instance == null)
            {
                PyTimer.instance = this;
            }
            else if(PyTimer.instance!=this)
            {
                this.Close();
            }
            InitializeComponent();

            runPyButton.Enabled = false;
            rd = new Random();
            m_PysPath = new DirectoryInfo(@"Pys\");
            m_PysPath.Create();
            pyEngine = Python.CreateEngine();

            InitConfig();
            InitPys();
        }
        private void InitConfig()
        {
            configPath = "config.xml";
            configXml = new XmlDocument();
            if (!File.Exists(configPath))
            {
                rootNode = configXml.CreateElement("PyObjects");
                configXml.AppendChild(rootNode);

                configXml.Save(configPath);
            }
            else
            {
                configXml.Load(configPath);
                rootNode = configXml.SelectSingleNode("PyObjects");
            }
        }
        private void InitPys()
        {
            List<XmlNode> waitRemove = new List<XmlNode>();
            foreach(XmlNode pyObj in rootNode.ChildNodes)
            {
                if(File.Exists(m_PysPath.ToString()+pyObj.Attributes["Name"].Value))
                {                                                        
                    PyObject tempPyObj = new PyObject(pyObj.Attributes["Name"].Value,rd.Next());
                    tempPyObj.repeatingTime = Int32.Parse(pyObj.Attributes["RptTime"].Value);
                    tempPyObj.autoRun = (pyObj.Attributes["AutoRun"].Value == "1") ? true : false;
                    pyList.Items.Add(tempPyObj);
                    if(tempPyObj.autoRun)
                    {
                        tempPyObj.StartRepeatRunning();
                    }                  
                }
                else
                {
                    waitRemove.Add(pyObj);
                }
            }//将xml中保存的信息对照文件后写入pyList
            foreach(XmlNode i in waitRemove)
            {
                rootNode.RemoveChild(i);
                configXml.Save(configPath);
            }

            
            FileInfo[] pys = m_PysPath.GetFiles();
            for(int i = 0;i<pys.Length;i++)
            {
                if (pys[i].Name.Substring(pys[i].Name.Length - 3, 3) != ".py")
                {
                    continue;
                }
                bool exists = false;
                foreach(XmlNode pyObj in rootNode.ChildNodes)
                {
                    if(pys[i].Name.Equals(pyObj.Attributes["Name"].Value))
                    {
                        exists = true;
                    }
                }
                if (exists) continue;
                PyObject tempPyObj = new PyObject(pys[i].Name, rd.Next());
                pyList.Items.Add(tempPyObj);
                AddToConfig(tempPyObj);    
            }  
        }

        private void pyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGUI();      
        }  
        private void UpdateGUI()
        {
            if (pyList.SelectedItem != null)
            {
                runPyButton.Enabled = true;
                repeatTimeText.Text = (pyList.SelectedItem as PyObject).repeatingTime.ToString();
                autoRunCheck.Checked = (pyList.SelectedItem as PyObject).autoRun;
            }
            else
            {
                repeatTimeText.Text = "";
                runPyButton.Enabled = false;
                autoRunCheck.Checked = false;
            }
            
        }                     
        private void addPyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog originalFile = new OpenFileDialog();
            originalFile.ShowDialog();
            FileInfo copyFile;

            try
            {
                copyFile = new FileInfo(originalFile.FileName);
            }
            catch(Exception)
            {
                return;
            }
            
            if(originalFile.SafeFileName.Substring(originalFile.SafeFileName.Length-3,3) != ".py")
            {
                MessageBox.Show("只接受.py文件");
                return;
            }

            try
            {
                copyFile.CopyTo(m_PysPath + originalFile.SafeFileName);
            }
            catch(Exception)
            {
                MessageBox.Show("存在同名脚本");
                return;
            }
            PyObject tempPyObj = new PyObject(originalFile.SafeFileName, rd.Next());   
            pyList.Items.Add(tempPyObj);
            AddToConfig(tempPyObj);
        }

        private void runPyButton_Click(object sender, EventArgs e)
        {
            (pyList.SelectedItem as PyObject).Run();
            UpdatePyList(pyList.Items.IndexOf(pyList.SelectedItem));
        }

        private void pyMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 开始运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo deleteFile = new FileInfo(m_PysPath + pyList.SelectedItem.ToString());
            deleteFile.Delete();
            foreach(XmlNode i in rootNode.ChildNodes)
            {
                if(i.Attributes["Name"].Value.Equals((pyList.SelectedItem as PyObject).m_PyName))
                {
                    rootNode.RemoveChild(i);
                    configXml.Save(configPath);
                    break;
                }
            }
            pyList.Items.Remove(pyList.SelectedItem);
        }

        private void PyTimer_Load(object sender, EventArgs e)
        {

        }

        public void UpdatePyList()
        {
            for(int i = 0;i < pyList.Items.Count;i++)
            {
                pyList.Items[i] = pyList.Items[i];
            }
        }
        private void UpdatePyList(int index)
        {
            pyList.Items[index] = pyList.Items[index];
        }

        private void applyRepeatTimeButton_Click(object sender, EventArgs e)
        {
            if(pyList.SelectedItem == null)
            {
                return;
            }
            int repeatingTime;
            if(repeatTimeText.Text == null)
            {
                repeatingTime = 0;
            }
            else
            {
                repeatingTime = Int32.Parse(repeatTimeText.Text);
            }
            (pyList.SelectedItem as PyObject).repeatingTime = repeatingTime;
            UpdateConfig(pyList.SelectedItem as PyObject);
        }

        private void startRunButton_Click(object sender, EventArgs e)
        {
            (pyList.SelectedItem as PyObject).StartRepeatRunning();
            UpdatePyList(pyList.Items.IndexOf(pyList.SelectedItem));
        }

        private void pauseRunButton_Click(object sender, EventArgs e)
        {
            (pyList.SelectedItem as PyObject).PauseRepeatRunning();
            UpdatePyList(pyList.SelectedIndex);
        }

        private void cancelRunButton_Click(object sender, EventArgs e)
        {
            (pyList.SelectedItem as PyObject).CancelRepeatRunning();
            UpdatePyList(pyList.Items.IndexOf(pyList.SelectedItem));
        }

        private void startAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pyList.Items.Count; i++)
            {
                (pyList.Items[i] as PyObject).StartRepeatRunning();   
            }
            UpdatePyList();
        }

        private void pauseAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pyList.Items.Count; i++)
            {
                (pyList.Items[i] as PyObject).PauseRepeatRunning();
            }
            UpdatePyList();
        }

        private void cancelAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pyList.Items.Count; i++)
            {
                (pyList.Items[i] as PyObject).CancelRepeatRunning();
            }
            UpdatePyList();                   
        }

        private void autoRunCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(pyList.SelectedItem!=null)
            {
                (pyList.SelectedItem as PyObject).autoRun = autoRunCheck.Checked;
            }

            UpdateConfig(pyList.SelectedItem as PyObject);
        }

        private void AddToConfig(PyObject target)
        {
            XmlElement pyObj = configXml.CreateElement("PyObject");
            rootNode.AppendChild(pyObj);
            pyObj.SetAttribute("Name", target.m_PyName);
            pyObj.SetAttribute("RptTime", target.repeatingTime.ToString());
            pyObj.SetAttribute("AutoRun", (target.autoRun) ? "1" : "0");
            /*
            XmlElement configName = configXml.CreateElement("Name");
            XmlElement configRptTime = configXml.CreateElement("RepeatingTime");
            XmlElement configAutoRun = configXml.CreateElement("AutoRun");
            configName.InnerText = target.m_PyName;
            configRptTime.InnerText = target.repeatingTime.ToString();
            configAutoRun.InnerText = (target.autoRun) ? "1" : "0";
            pyObj.AppendChild(configName);
            pyObj.AppendChild(configRptTime);
            pyObj.AppendChild(configAutoRun);    */
            configXml.Save(configPath);
        }
        private void UpdateConfig(PyObject target)
        {
            XmlNode targetNode = configXml.FirstChild;  
            foreach(XmlNode i in rootNode.ChildNodes)
            {                                                        
                if(i.Attributes["Name"].Value.Equals(target.m_PyName))
                {         
                    targetNode = i;
                    break;
                }
            }
            try
            {
                targetNode.Attributes["RptTime"].Value = target.repeatingTime.ToString();
                targetNode.Attributes["AutoRun"].Value = (target.autoRun) ? "1" : "0";
            }
            catch(Exception x)
            {
                MessageBox.Show("Config更新错误", x.ToString());
            }    
            configXml.Save(configPath);

        }
    }
}
