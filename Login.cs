using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\cs\2 nd year\2nd sem\CSCI 22042 - Visual Programming\Actual Project\Car-Rental-System\CarRental.mdf"";Integrated Security=True");
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
                
                con.Open();
                string query = "SELECT COUNT(*) FROM UserTbl WHERE Uname = @name AND Upass = @password";
                SqlCommand cmd = new SqlCommand(query, con);
                // Add parameters for the query.
                cmd.Parameters.AddWithValue("@name", userTxt.Text);
                cmd.Parameters.AddWithValue("@password", pwTxt.Text);

                // Execute the query and get the count of rows returned.
                int userCount = (int)cmd.ExecuteScalar();

                // Now you can use 'userCount' to check if the user exists in the database or not.
                if (userCount > 0)
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("wrong username or password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            userTxt.Text = string.Empty;
            pwTxt.Text = string.Empty;
        }

        private void gunaTransfarantPictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
