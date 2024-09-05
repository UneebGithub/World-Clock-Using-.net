using Loading;
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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }
        ClockVSDataContext db;
        private void button1_Click(object sender, EventArgs e)
        {
            db = new ClockVSDataContext();
            try
            {
                string user_reg=textBox1.Text;
                int user_pass = Convert.ToInt32(textBox2.Text);
                var check_PASSUSER = db.loginns.FirstOrDefault(s=>s.userpass==user_pass && s.USER_REG.Equals(user_reg));
                if(check_PASSUSER != null)
                {

                    Clock c = new Clock();
                    this.Hide();
                    c.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User or Password Is Wrong\nTry Again!");
                }
            
            
            
            
            
            }catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
