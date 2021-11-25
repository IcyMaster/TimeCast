using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TimeCast
{
    public partial class Form1 : Form
    {
        public static bool selectCordinate;
        public static Form2 form;
        public static int X;
        public static int Y;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }
        public void Form1_Load(object sender, EventArgs e)
        {
                if (File.Exists(@"Config.txt"))
                {
                    string Location = File.ReadLines(@"Config.txt").Skip(5).Take(1).First();
                    if (Location == "True")
                    {
                        checkBox4.Checked = true;
                    }
                    string option2 = File.ReadLines(@"Config.txt").Skip(3).Take(1).First();
                    if (option2 == "True")
                    {
                        checkBox2.Checked = true;
                    }
                    string option3 = File.ReadLines(@"Config.txt").Skip(4).Take(1).First();
                    if (option3 == "True")
                    {
                        checkBox3.Checked = true;
                    }
                }
                timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            X = Form2.form.Location.X;
            Y = Form2.form.Location.Y;
            label3.Text = X.ToString();
            label2.Text = Y.ToString();
        }
        public void CreateConfig()
        {
            if (File.Exists(@"Config.txt"))
            {
                File.Delete(@"Config.txt");
            }
            StreamWriter wr = new StreamWriter(@"Config.txt");
            wr.WriteLine("");
            wr.WriteLine(Form2.form.Location.X);
            wr.WriteLine(Form2.form.Location.Y);
            if (checkBox2.Checked)
            {
                wr.WriteLine("True");
            }
            else
            {
                wr.WriteLine("False");
            }
            if (checkBox3.Checked)
            {
                wr.WriteLine("True");
                notifyIcon1.Visible = true;
                notifyIcon1.Icon = SystemIcons.Information;
                notifyIcon1.BalloonTipTitle = "تست اعلان";
                notifyIcon1.BalloonTipText = "نوتیفیکیشن برنامه فعال شد";
                notifyIcon1.ShowBalloonTip(1000);
            }
            else
            {
                wr.WriteLine("False");
            }
            if (checkBox4.Checked)
            {
                wr.WriteLine("True");
            }
            else
            {

                wr.WriteLine("False");
            }
            wr.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CreateConfig();
            Form2.form.Close();
            Form2 f2 = new Form2();
            f2.Show();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
