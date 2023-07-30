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

        private void dataBinding()
        {
            con.Open();
            String Query = "Select * from UserTbl";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            usergrid.DataSource = dt;
            con.Close();
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
                    
                    

                }
                catch(Exception myex) { 
                    MessageBox.Show(myex.Message);
                }finally
                { 
                    con.Close();
                    dataBinding();
                    idTxt.ResetText();
                    nameTxt.ResetText();
                    pwTxt.ResetText();
                }
                

            }
        }

        private void idTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            dataBinding();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            if(idTxt.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }else
            {
                try
                {
                    con.Open(); // Open the database connection

                    // Define the SQL query to delete a user based on their id
                    string query = "DELETE FROM UserTbl WHERE Id = @id";

                    SqlCommand cmd = new SqlCommand(query, con); // Create a new SqlCommand object with the query and connection

                    // Add a parameter to the SqlCommand to represent the 'id' value using the text from idTxt.Text
                    cmd.Parameters.AddWithValue("@id", int.Parse(idTxt.Text));

                    cmd.ExecuteNonQuery(); // Execute the DELETE query

                    MessageBox.Show("User Successfully Deleted!!!"); // Show a success message to the user

                   



                }
                catch (Exception myex)
                {
                    MessageBox.Show(myex.Message);
                }
                finally
                {
                    con.Close(); // Close the database connection
                    dataBinding();
                    idTxt.ResetText();
                    nameTxt.ResetText();
                    pwTxt.ResetText();
                }
                
            }
        }

        private void usergrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //click and add to the value
            //This accesses the first selected row in the usergrid DataGridView.
            //If you have multiple selection enabled, you might need to handle
            //multiple selected rows differently.
            idTxt.Text = usergrid.SelectedRows[0].Cells[0].Value.ToString();
            nameTxt.Text = usergrid.SelectedRows[0].Cells[1].Value.ToString();
            pwTxt.Text = usergrid.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            if (idTxt.Text == "" || nameTxt.Text == "" || pwTxt.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    con.Open(); // Open the database connection

                    // Define the SQL query to delete a user based on their id
                    string query = "update UserTbl set Uname = @name,Upass=@password where Id = @id";

                    SqlCommand cmd = new SqlCommand(query, con); // Create a new SqlCommand object with the query and connection

                    // Add a parameter to the SqlCommand to represent the 'id' value using the text from idTxt.Text
                    cmd.Parameters.AddWithValue("@id", int.Parse(idTxt.Text));
                    cmd.Parameters.AddWithValue("@name", nameTxt.Text);
                    cmd.Parameters.AddWithValue("@password", pwTxt.Text);

                    cmd.ExecuteNonQuery(); // Execute the update query

                    MessageBox.Show("User Successfully Updated!!!"); // Show a success message to the user





                }
                catch (Exception myex)
                {
                    MessageBox.Show(myex.Message);
                }
                finally
                {
                    con.Close(); // Close the database connection
                    dataBinding();
                    idTxt.ResetText();
                    nameTxt.ResetText();
                    pwTxt.ResetText();
                }

            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            Dashboard mainForm = new Dashboard();
            mainForm.Show();
            this.Hide();
        }
    }
}
