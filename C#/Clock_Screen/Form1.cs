using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock_Screen
{
    public partial class Form1 : Form
    {
        public static Label clock = new Label();
        public Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;

            //clock UI
            clock.AutoSize = false;
            clock.Dock = DockStyle.Fill;
            clock.Font = new Font(clock.Font.FontFamily, 150);
            clock.TextAlign = ContentAlignment.MiddleCenter;
            clock.Text = DateTime.Now.ToString("hh:mm:ss");
            clock.Location = new Point(0, 0);
            this.Controls.Add(clock);

            //set up timer
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
