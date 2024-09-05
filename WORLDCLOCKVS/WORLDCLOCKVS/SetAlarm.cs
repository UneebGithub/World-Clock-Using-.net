using Loading;
using System;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Windows.Forms;

namespace WORLDCLOCKVS
{
    public partial class SetAlarm : Form
    {
        private Clock clockForm;
        private ClockVSDataContext db;
        private bool alarmActive = false;

        [Table(Name = "SetAlarm1")]
        public class SetAlarm1
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int ID { get; set; }

            [Column]
            public int H { get; set; }

            [Column]
            public int M { get; set; }

            [Column]
            public int S { get; set; }

            [Column]
            public int YesNo { get; set; }

            [Column]
            public string AM_Pm { get; set; }
        }

        public SetAlarm(Clock clockForm)
        {
            InitializeComponent();
            this.clockForm = clockForm;
            db = new ClockVSDataContext();
        }

        private void SetAlarm_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            var alarms = from a in db.SetAlarms
                         select new
                         {
                             a.ID,
                             a.H,
                             a.M,
                             a.S,
                             a.AM_Pm
                         };

            dataGridView1.DataSource = alarms.ToList();
        }

        private void StartAlarm()
        {
            alarmActive = true;

            Timer alarmTimer = new Timer();
            alarmTimer.Interval = 1000;
            alarmTimer.Tick += AlarmTimer_Tick;
            alarmTimer.Start();
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            int currentH = Convert.ToInt32(clockForm.CurrentHour);
            int currentM = Convert.ToInt32(clockForm.CurrentMinute);
            int currentS = Convert.ToInt32(clockForm.CurrentSecond);

            var activeAlarm = db.SetAlarms.FirstOrDefault(a => a.H == currentH && a.M == currentM && a.S == currentS);
            if (activeAlarm != null && alarmActive)
            {
                PlayAlarmSound();
                alarmActive = false;
            }
        }

        private void PlayAlarmSound()
        {
            string alarmSoundPath = @"C:\Users\UNEEB\Downloads\converted_audio.wav";
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(alarmSoundPath);
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing alarm sound: " + ex.Message);
            }
        }

        private void Set_Click(object sender, EventArgs e)
        {
            
        }

        private void SetAlarm_Load_1(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void Set_Click_1(object sender, EventArgs e)
        {
            try
            {
                int hour = Convert.ToInt32(textBox2.Text);
                int minute = Convert.ToInt32(textBox3.Text);
                int second = Convert.ToInt32(textBox4.Text);
                string am_pm = textBox5.Text;
                int id = Convert.ToInt32(textBox1.Text);
                SetAlarm newAlarm = new SetAlarm
                {

                    ID = id,
                    H = hour,
                    M = minute,
                    S = second,
                    AM_Pm = am_pm
                };

                db.SetAlarms.InsertOnSubmit(newAlarm);
                db.SubmitChanges();

                RefreshDataGridView();
                StartAlarm();
                MessageBox.Show("Alarm set successfully.");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var alarmToDelete = db.SetAlarms.FirstOrDefault(a => a.ID == id);
            if (alarmToDelete != null)
            {
                db.SetAlarms.DeleteOnSubmit(alarmToDelete);
                db.SubmitChanges();
                RefreshDataGridView();
                MessageBox.Show("Alarm deleted successfully.");
            }
            else
            {
                MessageBox.Show("Alarm not found.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                int hour = Convert.ToInt32(textBox2.Text);
                int minute = Convert.ToInt32(textBox3.Text);
                int second = Convert.ToInt32(textBox4.Text);
                string am_pm = textBox5.Text;

                var alarmToUpdate = db.SetAlarms.FirstOrDefault(a => a.ID == id);
                if (alarmToUpdate != null)
                {
                    alarmToUpdate.ID = id;  
                    alarmToUpdate.H = hour;
                    alarmToUpdate.M = minute;
                    alarmToUpdate.S = second;
                    alarmToUpdate.AM_Pm = am_pm;

                    db.SubmitChanges();
                    RefreshDataGridView();
                    MessageBox.Show("Alarm updated successfully.");
                }
                else
                {
                    MessageBox.Show("Alarm not found.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
