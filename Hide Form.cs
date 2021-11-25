using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace TimeCast
{
    public partial class Hide_Form : Form
    {

        public Hide_Form()
        {
            InitializeComponent();
        }
        // Section Hide Form on Form Load
        // Go to InitializeComponent(); and past This Code
        // this.Activated += new System.EventHandler(this.Form1_Activated);
        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }
        private static void TaskSchedulerCommand(string args)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "schtasks.exe";
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
        private void Hide_Form_Load(object sender, EventArgs e)
        {
            TaskSchedulerCommand($"/create /f /sc ONLOGON /RL HIGHEST /tn \"Time Cast\" /tr \"{Application.ExecutablePath}\"");
            Form2 f2 = new Form2();
            f2.Show();
            Form1 f1 = new Form1();
            f1.Show();
            if (File.Exists(@"Config.txt"))
            {
                f1.Hide();
            }
        }
    }
}
