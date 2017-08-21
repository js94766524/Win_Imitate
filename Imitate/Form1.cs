using ImitateLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imitate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://huodong.37.com/zt/publish/pc/275/cqfg2017021620170216/index.html?refer=baidu_tg&ad_param=35483cqhuaijiu&bid=&wd=JUU0JUI4JTgwJUU1JTg4JTgwOTk5JUU3JUJBJUE3JUU0JUJDJUEwJUU1JUE1JTg3&landingpage=http%3A%2F%2Fbdtg.37.com%2Fs%2F1%2F296%2F28108.html%3Fuid%3D2738335&ext=1%7C296%7C28108%7C2738335%7C0&uid=2738335");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var p = PointToScreen(webBrowser1.Location);
            webBrowser1.Focus();
            Mouse.MoveTo(p.X + 400, p.Y + 310);
            Mouse.LeftClick();
            Keyboard.InputByClipboard("what are you 弄啥咧");
            Mouse.WheelRoll(10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripProgressBar1.Maximum = 1000;
            webBrowser1.StatusTextChanged += (s, arg) => { toolStripStatusLabel1.Text = webBrowser1.StatusText; };
            webBrowser1.ProgressChanged += (s, arg) =>
            {
                var c = 1.0 * arg.CurrentProgress / arg.MaximumProgress;
                if (c < 0) c = 0;
                if (c > 1) c = 1;
                if (arg.MaximumProgress == 0) c = 0;
                toolStripProgressBar1.Value = (int)(c * 1000);
            };

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += (s, args) =>
            {
                var l = webBrowser1.Location;
                var p = PointToClient(MousePosition);
                toolStripStatusLabel2.Text = (p.X - l.X) + " , " + (p.Y - l.Y);
            };
            timer.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text.Trim());
        }
    }
}
