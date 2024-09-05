using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WORLDCLOCKVS
{
    public partial class TIMERcs : Form
    {
        private Timer timer;
        private int remainingSeconds;

        public TIMERcs()
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
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                UpdateTimerDisplay();
            }
            else
            {
                timer.Stop();
                PlayAlertSound();
                MessageBox.Show("Time's up!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int minutes = Convert.ToInt32(textBox2.Text);
                int seconds = Convert.ToInt32(textBox3.Text);
                remainingSeconds = minutes * 60 + seconds;

                UpdateTimerDisplay();
                timer.Start();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for minutes and seconds.");
            }
        }

        private void UpdateTimerDisplay()
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            label4.Text = $"{minutes:D2}:{seconds:D2}";
        }

        private void PlayAlertSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(@"C:\path\to\your\alert.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing alert sound: " + ex.Message);
            }
        }

        private void TIMERcs_Load(object sender, EventArgs e)
        {
            label4.Text = "00:00";
        }

        private void TIMERcs_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int minutes = Convert.ToInt32(textBox2.Text);
                int seconds = Convert.ToInt32(textBox3.Text);
                remainingSeconds = minutes * 60 + seconds;

                UpdateTimerDisplay();
                timer.Start();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for minutes and seconds.");
            }
        }
    }
}
