using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WORLDCLOCKVS
{
    public partial class StopWatch : Form
    {
        private Timer timer;
        private int elapsedSeconds;
        public StopWatch()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            UpdateStopWatchDisplay();
        }

        private void UpdateStopWatchDisplay()
        {
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;
            label4.Text = $"{minutes:D2}:{seconds:D2}";
        }







        private void StopWatch_Load(object sender, EventArgs e)
        {
            label4.Text = "00:00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //timer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            timer.Stop();
            elapsedSeconds = 0;
            UpdateStopWatchDisplay();
        }
    }
}
