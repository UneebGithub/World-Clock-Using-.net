using System;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WORLDCLOCKVS;

namespace Loading
{
    public partial class WorldClock : Form
    {
        public string CurrentHour => label4.Text;
        public string CurrentMinute => label5.Text;
        public string CurrentSecond => label6.Text;
        private ClockVSDataContext db;
        private DateTime currentTime;
        public string country;

        public WorldClock()
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

                var latestTime = db.World_Clocks.OrderByDescending(h => h.Country == country).FirstOrDefault();
                if (latestTime != null)
                {

                    label4.Text = ((int)latestTime.H).ToString("D2");
                    label5.Text = ((int)latestTime.M).ToString("D2");
                    label6.Text = ((int)latestTime.S).ToString("D2");


                    currentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (int)latestTime.H, (int)latestTime.M, (int)latestTime.S);
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
                comboBox1.Items.Clear();

                var countryNames = (from h in db.World_Clocks
                                    select h.Country).Distinct().ToList();

                comboBox1.Items.AddRange(countryNames.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching country names: " + ex.Message);
            }
        }

        private void WorldClock_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = comboBox1.SelectedItem.ToString();


            var countryTime = db.World_Clocks.FirstOrDefault(h => h.Country == selectedCountry);
            country = countryTime.Country;
            if (countryTime != null)
            {

                label4.Text = ((int)countryTime.H).ToString("D2");
                label5.Text = ((int)countryTime.M).ToString("D2");
                label6.Text = ((int)countryTime.S).ToString("D2");
            }
        }
    }
}

