using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class LoadingModule : Form
    {
        public LoadingModule()
        {
            InitializeComponent();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        
                private void LoadingModule_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                label3.Text = progressBar1.Value.ToString() + "%";


            }
            else
            {
                timer1.Stop();
                Login login = new Login();
                login.Show();
                this.Hide();

            }
        }
    }
}
