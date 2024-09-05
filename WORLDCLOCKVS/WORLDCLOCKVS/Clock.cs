using System;
using System.Windows.Forms;
using System.Linq;
using System.Reflection.Emit;
using WORLDCLOCKVS;

namespace Loading
{

    public partial class Clock : Form
    {
        public string CurrentHour => label4.Text;
        public string CurrentMinute => label5.Text;
        public string CurrentSecond => label6.Text;
        private ClockVSDataContext db;
        private DateTime currentTime;
        public string country;

        public Clock()
        {
            InitializeComponent();


            db = new ClockVSDataContext();


            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();


            PopulateCountryComboBox();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {

                var latestTime = db.HMs.OrderByDescending(h => h.Country).FirstOrDefault();
                if (latestTime != null)
                {

                    label4.Text = latestTime.H.ToString("D2");
                    label5.Text = latestTime.M.ToString("D2");
                    label6.Text = latestTime.S.ToString("D2");


                    currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, latestTime.H, latestTime.M, latestTime.S);


                    currentTime = currentTime.AddSeconds(1);


                    label4.Text = currentTime.Hour.ToString("D2");
                    label5.Text = currentTime.Minute.ToString("D2");
                    label6.Text = currentTime.Second.ToString("D2");


                    latestTime.H = currentTime.Hour;
                    latestTime.M = currentTime.Minute;
                    latestTime.S = currentTime.Second;


                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating time: " + ex.Message);
            }
        }

        private void PopulateCountryComboBox()
        {
            try
            {

                // comboBox1.Items.Clear();


                var countryNames = (from h in db.HMs
                                    select h.Country).Distinct().ToList();


                //  comboBox1.Items.AddRange(countryNames.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching country names: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //string selectedCountry = comboBox1.SelectedItem.ToString();


                //var countryTime = db.HMs.FirstOrDefault(h => h.Country == selectedCountry);
                //country= countryTime.Country;
                //if (countryTime != null)
                //{

                //  label4.Text = countryTime.H.ToString("D2");
                //label5.Text = countryTime.M.ToString("D2");
                //label6.Text = countryTime.S.ToString("D2");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching country time: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
   //         SetClock c = new SetClock();
     //       c.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
       //     SetClock setClock = new SetClock();
         //   setClock.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
//            SetAlarm setAlarm = new SetAlarm(this);

           // setAlarm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
  //          WorldClock wc = new WorldClock();
    //        wc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
      //      TIMERcs t = new TIMERcs();
        //    t.ShowDialog();
        }

        private void Clock_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WorldClock clock = new WorldClock();
            clock.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SetAlarm setAlarm = new SetAlarm(this);
            setAlarm.ShowDialog();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            SetClock clock = new SetClock();
            clock.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            TIMERcs tIMERcs = new TIMERcs();
            tIMERcs.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StopWatch stopWatch = new StopWatch();
            stopWatch.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Namaz n=    new Namaz();    
            n.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int add = 0;
            Add_Reg add_Reg = new Add_Reg(add);
            add_Reg.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
