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
    public partial class SetClock : Form
    {
        public SetClock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void SetClock_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var db = new ClockVSDataContext())
                {
                    string country = textBox1.Text;
                    int H = Convert.ToInt32(textBox2.Text);
                    int M = Convert.ToInt32(textBox3.Text);
                    int S = Convert.ToInt32(textBox4.Text);
                    string AP = textBox5.Text;


                    HM newHMS = new HM
                    {
                        Country = country,
                        H = H,
                        M = M,
                        S = S,
                        AM_Pm = AP
                    };

                    db.HMs.InsertOnSubmit(newHMS);


                    World_Clock newWC = new World_Clock
                    {
                        Country = country,
                        H = H,
                        M = M,
                        S = S
                    };

                    db.World_Clocks.InsertOnSubmit(newWC);

                    db.SubmitChanges();

                    MessageBox.Show("Data saved successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
