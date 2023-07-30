using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Car_Rental_System
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\cs\2 nd year\2nd sem\CSCI 22042 - Visual Programming\Actual Project\Car-Rental-System\CarRental.mdf"";Integrated Security=True");

        private void gunaTransfarantPictureBox3_Click(object sender, EventArgs e)
        {
            //to the cancel this interface
            Application.Exit();
        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void binding()
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (idTxt.Text == "" || nameTxt.Text == "" || pwTxt.Text =="" )
            {
                MessageBox.Show("Missing Infromation");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO UserTbl (Id, Uname, Upass) VALUES (@id, @name, @password)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(idTxt.Text));
                    cmd.Parameters.AddWithValue("@name", nameTxt.Text);
                    cmd.Parameters.AddWithValue("@password", pwTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added!!!");
                    

                }catch(Exception myex) { 
                    MessageBox.Show(myex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void idTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
