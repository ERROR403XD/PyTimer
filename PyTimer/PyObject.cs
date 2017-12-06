using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Threading;
using IronPython;
using IronPython.Hosting;
using IronPython.Modules;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting; 
using System.Diagnostics;
namespace PyTimer
{
    class PyObject
    {
        public string m_PyName;
        private int m_num;
        private state m_state;
        public int repeatingTime;
        private System.Timers.Timer m_Timer;
        private System.Windows.Forms.Timer f_Timer;
        private System.Threading.Timer t_Timer; 

        public bool autoRun;
        enum state
        {
            stop,running,pause
        };
        

        public int State
        {
            get
            {
                return (int)m_state;
            }
        }
        public int Num
        {
            get
            {
                return m_num;
            }
        }

        public PyObject(string name,int num)
        {
            m_PyName = name;
            m_num = num;
            m_state = state.stop;
            repeatingTime = 60000;
            autoRun = false;
        }

        public void Run()
        {      
            //DirectoryInfo pyDir = new DirectoryInfo(PyTimer.PysPath+"\"" + m_PyName+"\"");
            string dir = "\""+PyTimer.PysPath.FullName+ m_PyName+"\"";   
            Process CMD = new Process();
            CMD.StartInfo.FileName = "cmd.exe";
            CMD.StartInfo.UseShellExecute = false;
            CMD.StartInfo.RedirectStandardError = true;
            CMD.StartInfo.RedirectStandardInput = true;
            CMD.StartInfo.RedirectStandardOutput = true;
            CMD.StartInfo.CreateNoWindow = true;
            CMD.Start();

            CMD.StandardInput.WriteLine("python " + dir);

            CMD.StandardInput.AutoFlush = true;
            CMD.StandardInput.WriteLine("exit");
            CMD.WaitForExit();
            CMD.Close();
            //CMD.StandardInput.WriteLine("exit");
            //CMD.WaitForExit();
            //CMD.Close();
            //PyTimer.pyEngine.ExecuteFile(pyDir.FullName);
            //PyTimer.pyEngine.ExecuteFile(pyDir.FullName);
            /*
            try
            {
               // ScriptScope pySc = PyTimer.pyEngine.ExecuteFile(pyDir.FullName);
                ScriptSource pySo = PyTimer.pyEngine.CreateScriptSourceFromFile(pyDir.FullName);
                pySo.Execute();
            }
            catch(Exception)
            {
                MessageBox.Show("脚本执行不正确","运行错误");
                if(m_state == state.running)
                {
                    CancelRepeatRunning();
                    PyTimer.instance.UpdatePyList();
                }
            }*/
        }

        public override string ToString()
        {
            switch(m_state)
            {
                case state.stop:
                    {
                        return m_PyName; 
                    }
                case state.pause:
                    {
                        return m_PyName + "[暂停]";
                    }
                case state.running:
                    {
                        return m_PyName + "[运行中]"; 
                    }
                default:
                    {
                        return m_PyName;     
                    }
            }

            
        }

        public void StartRepeatRunning()
        {
            m_state = state.running;
            /*
            if(f_Timer == null)
            {
                f_Timer = new System.Windows.Forms.Timer();
                f_Timer.Interval = repeatingTime;
                f_Timer.Tick += m_Py_delegate;
                f_Timer.Enabled = true;
                f_Timer.Start();
            }
            
            else
            {
                f_Timer.Enabled = true;
                f_Timer.Start();
            }
            */
            if (m_Timer == null)
            {
                m_Timer = new System.Timers.Timer(repeatingTime);
                m_Timer.Elapsed += m_Py_delegate;
                m_Timer.AutoReset = true;
                m_Timer.Enabled = true;
                Control.CheckForIllegalCrossThreadCalls = false;
            }
            else
            {
                m_Timer.Enabled = true;
            }   
            Run();
        }
        public void PauseRepeatRunning()
        {
            if (m_state == state.running)
            {
                m_state = state.pause;
            }
            
            if(m_Timer!=null)
            {
                m_Timer.Enabled = false;
            }/*
            if(f_Timer!=null)
            {
                f_Timer.Enabled = false;
            }*/

        }
        public void CancelRepeatRunning()
        {
            m_state = state.stop;
            
            if(m_Timer!=null)
            {
                m_Timer.Close();
            }
            /*
            if(f_Timer!=null)
            {
                f_Timer.Stop();
                f_Timer.Dispose();
            }*/
            
        }
        private void m_Py_delegate(object sender, System.Timers.ElapsedEventArgs e)
        {
            Run();               
        }
        private void m_Py_delegate(object sender,EventArgs e)
        {
            Run();
        }
        private void m_Py_delegate(object sender)
        {
            Run();
        }
    }
}
