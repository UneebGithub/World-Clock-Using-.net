using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WORLDCLOCKVS;

namespace Loading
{

    public partial class Form1 : Form
    {
        static int ck;
        int s = 0;





        public Form1()
        {
            InitializeComponent();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(30);
                s += 1;
                ck = s;
                backgroundWorker1.ReportProgress(i);
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                e.Result = s;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;


        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {

            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
            }
            else
            {
                Clock c = new Clock();
                c.ShowDialog();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                cck();
            }
        }
        public void cck()
        {
            MessageBox.Show(" " + ck);
            progressBar1.Value = ck;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //button1.Visible = false;
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(30);
                s += 1;
                ck = s;
                backgroundWorker1.ReportProgress(i);
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                e.Result = s;
            }
        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {

            }
            else if (e.Error != null)
            {

            }
            else
            {
                LOGIN a = new LOGIN();
                this.Hide();
                a.ShowDialog();
                
                //   button1.Visible = true;
                // Form1 fm=new Form1();


                // LogIn lg=new LogIn();
                //Clock c = new Clock();
                //c.ShowDialog();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            
        }
    }
}
