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
    public partial class Namaz : Form
    {
        public Namaz()
        {
            InitializeComponent();
            comboBox1.Visible = false;
            textBox1.Visible = false;
            button2.Visible = false;
        }
        ClockVSDataContext db;

        private void Namaz_Load(object sender, EventArgs e)
        {
            try
            {
                db = new ClockVSDataContext();

                var namazTimers = db.Namaz_Timers.ToList();

                if (namazTimers != null && namazTimers.Count > 0)
                {
                    int counter = 0;

                    foreach (var namazTimer in namazTimers)
                    {
                        switch (counter)
                        {
                            case 0:
                                label1.Text = namazTimer.Namaz_Name;
                                label8.Text = namazTimer.Timing;
                                break;
                            case 1:
                                label2.Text = namazTimer.Namaz_Name;
                                label7.Text = namazTimer.Timing;
                                break;
                            case 2:
                                label4.Text = namazTimer.Namaz_Name;
                                label10.Text = namazTimer.Timing;
                                break;
                            case 3:
                                label3.Text = namazTimer.Namaz_Name;
                                label9.Text = namazTimer.Timing;
                                break;
                            case 4:
                                label6.Text = namazTimer.Namaz_Name;
                                label12.Text = namazTimer.Timing;
                                break;
                            case 5:
                                label5.Text = namazTimer.Namaz_Name;
                                label11.Text = namazTimer.Timing;
                                break;
                            default:
                                break;
                        }

                        counter++;
                        if (counter > 5) 
                        {
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Namaz timings found in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Namaz timings: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            textBox1.Visible = true;
            button2.Visible = true;
            var namazTimers = db.Namaz_Timers.ToList();

            if (namazTimers != null && namazTimers.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (var namazTimer in namazTimers)
                {
                    comboBox1.Items.Add(namazTimer.Namaz_Name);
                }
            }


            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    string selectedNamazName = comboBox1.SelectedItem.ToString();
                    string newTiming = textBox1.Text;

                    var selectedNamaz = db.Namaz_Timers.FirstOrDefault(n => n.Namaz_Name == selectedNamazName);

                    if (selectedNamaz != null)
                    {
                        selectedNamaz.Timing = newTiming;
                        db.SubmitChanges();

                        MessageBox.Show("Namaz timing updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Selected Namaz not found in the database.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Namaz to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Namaz timing: " + ex.Message);
            }
        }
    }
}
