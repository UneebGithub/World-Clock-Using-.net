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
    public partial class Add_Reg : Form
    {
        public int a;
        public Add_Reg(int a)
        {
            this.a = a;
            InitializeComponent();
        }
        ClockVSDataContext db;
        private void button1_Click(object sender, EventArgs e)
        {
            db = new ClockVSDataContext();
            try
            {
                string user_reg = textBox1.Text;
                int user_pass = Convert.ToInt32(textBox2.Text);

                //var insert = from it in db.loginns select it;
                loginn lg = new loginn {
                    USER_REG = user_reg,
                    userpass = user_pass,

                };
                db.loginns.InsertOnSubmit(lg);
                db.SubmitChanges();
                MessageBox.Show("ADMIN ADD SUCCESSFULLY :) ");
                this.Close();
            }
            catch (Exception ex) { 
            
            }
        }
    }
}
