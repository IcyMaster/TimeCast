using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Tulpep.NotificationWindow;
using Microsoft;
using System.Threading;
using RestSharp;
using Newtonsoft.Json;

namespace TimeCast
{
    public partial class Form2 : Form
    {
        public static Form2 form;
        public string Option1;
        public string zero;
        public string zeroMinute;
        public string zeroHoure;
        public string Option2;
        public string Option3;
        public static int X;
        public static int Y;
        public String Locked = "False";
        static int Houre;
        static int minute;
        static int secend;
        static string Event;
        private bool mouseDown;
        private Point lastLocation;
        public Form2()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"Config.txt"))
            {
                X = Convert.ToInt32(File.ReadLines(@"Config.txt").Skip(1).Take(1).First());
                Y = Convert.ToInt32(File.ReadLines(@"Config.txt").Skip(2).Take(1).First());
                this.SetDesktopLocation(X, Y);
            }
            form = this;
            LoadCheck();
            StartAPP();
        }
        public void StartAPP()
        {
            try
            {
                if (Option2 == "True")
                {
                    base.TopMost = true;
                }
                else
                {
                    base.TopMost = false;
                }

                this.ControlBox = false;
                this.Text = String.Empty;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var client = new RestClient("http://api.keybit.ir/time/");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                IRestResponse response = client.Execute(request);
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content);
                label1.Text = myDeserializedClass.date.weekday.name + " " + myDeserializedClass.date.day.number.en + " " + myDeserializedClass.date.month.name;
                Houre = Convert.ToInt32(myDeserializedClass.time24.hour.en);
                minute = Convert.ToInt32(myDeserializedClass.time24.minute.en);
                secend = Convert.ToInt32(myDeserializedClass.time24.second.en);
                label2.Text = Houre + " : " + minute + " : " + secend;
                timer1.Start();

                if (myDeserializedClass.date.day.events.holy == null)
                {
                }
                else
                {
                    if (Option3 == "True")
                    {
                        Event = myDeserializedClass.date.day.events.holy.text.ToString();
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Information;
                        notifyIcon1.BalloonTipTitle = "مناسبت " + myDeserializedClass.date.weekday.name + " " + myDeserializedClass.date.day.number.en + " " + myDeserializedClass.date.month.name.ToString() + " :";
                        notifyIcon1.BalloonTipText = Event.ToString();
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                }
                if (myDeserializedClass.date.day.events.local == null)
                { 
                }
                else
                {
                    if (Option3 == "True")
                    {
                        Event = myDeserializedClass.date.day.events.local.text.ToString();
                        notifyIcon1.Visible = true;
                        notifyIcon1.Icon = SystemIcons.Information;
                        notifyIcon1.BalloonTipTitle = "مناسبت " + myDeserializedClass.date.weekday.name + " " + myDeserializedClass.date.day.number.en + " " + myDeserializedClass.date.month.name.ToString() + " :";
                        notifyIcon1.BalloonTipText = Event.ToString();
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                }
                if(myDeserializedClass.date.day.events.global == null)
                {
                }
                else
                {
                    Event = myDeserializedClass.date.day.events.global.text.ToString();
                    notifyIcon1.Visible = true;
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.BalloonTipTitle = "مناسبت " + myDeserializedClass.date.weekday.name + " " + myDeserializedClass.date.day.number.en + " " + myDeserializedClass.date.month.name.ToString() + " :";
                    notifyIcon1.BalloonTipText = Event.ToString();
                    notifyIcon1.ShowBalloonTip(3000);
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(20000);
                StartAPP();
            }
        }
        public void LoadCheck()
        {
            if (File.Exists(@"Config.txt"))
            {
                Option1 = File.ReadLines(@"Config.txt").Skip(2).Take(1).First();
                Option2 = File.ReadLines(@"Config.txt").Skip(3).Take(1).First();
                Option3 = File.ReadLines(@"Config.txt").Skip(4).Take(1).First();
                Locked = File.ReadLines(@"Config.txt").Skip(5).Take(1).First();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            secend++;
            zero = "";
            zeroMinute = "";
            zeroHoure = "";
            switch (secend)
            {
                case 0:
                    zero = "0";
                    break;
                case 1:
                    zero = "0";
                    break;
                case 2:
                    zero = "0";
                    break;
                case 3:
                    zero = "0";
                    break;
                case 4:
                    zero = "0";
                    break;
                case 5:
                    zero = "0";
                    break;
                case 6:
                    zero = "0";
                    break;
                case 7:
                    zero = "0";
                    break;
                case 8:
                    zero = "0";
                    break;
                case 9:
                    zero = "0";
                    break;
                case 60:
                    minute++;
                    secend = 0;
                    zero = "0";
                    break;
            }
            switch (minute)
            {
                case 0:
                    zeroMinute = "0";
                    break;
                case 1:
                    zeroMinute = "0";
                    break;
                case 2:
                    zeroMinute = "0";
                    break;
                case 3:
                    zeroMinute = "0";
                    break;
                case 4:
                    zeroMinute = "0";
                    break;
                case 5:
                    zeroMinute = "0";
                    break;
                case 6:
                    zeroMinute = "0";
                    break;
                case 7:
                    zeroMinute = "0";
                    break;
                case 8:
                    zeroMinute = "0";
                    break;
                case 9:
                    zeroMinute = "0";
                    break;
                case 60:
                    Houre++;
                    minute = 0;
                    zeroMinute = "0";
                    break;
            }
            switch (Houre)
            {
                case 0:
                    zeroHoure = "0";
                    break;
                case 1:
                    zeroHoure = "0";
                    break;
                case 2:
                    zeroHoure = "0";
                    break;
                case 3:
                    zeroHoure = "0";
                    break;
                case 4:
                    zeroHoure = "0";
                    break;
                case 5:
                    zeroHoure = "0";
                    break;
                case 6:
                    zeroHoure = "0";
                    break;
                case 7:
                    zeroHoure = "0";
                    break;
                case 8:
                    zeroHoure = "0";
                    break;
                case 9:
                    zeroHoure = "0";
                    break;
                case 24:
                    Houre = 0;
                    zeroHoure = "0";
                    var client = new RestClient("https://api.keybit.ir/time/");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    IRestResponse response = client.Execute(request);
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content);
                    label1.Text = myDeserializedClass.date.weekday.name + " " + myDeserializedClass.date.day.number.en + " " + myDeserializedClass.date.month.name;
                    break;
            }
            label2.Text = zeroHoure + Houre + " : " + zeroMinute + minute + " : " + zero + secend;
        }
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Locked == "False")
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Locked == "False")
            {
                if (mouseDown)
                {
                    this.Location = new Point(
                        (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                    this.Update();
                }
            }
        }
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (Locked == "False")
            {
                mouseDown = false;
            }
        }
        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Visible = true;
        }
    }
}
