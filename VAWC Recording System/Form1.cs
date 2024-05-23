using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAWC_Recording_System
{
    public partial class Form1 : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        public Form1()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = "";
                string Role = "";
                string users = "";

                RSDBConnect.Open();
                string query = "SELECT * FROM users WHERE user = @user AND password = @password AND status = 'active'";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                RSDBCommand.Parameters.AddWithValue("@user", username_txtbx.Text);
                RSDBCommand.Parameters.AddWithValue("@password", password_txtbx.Text);
                RSBDReader = RSDBCommand.ExecuteReader();

                if (RSBDReader.Read())
                {
                    Name = RSBDReader["firstName"].ToString();
                    Role = RSBDReader["role"].ToString();
                    users = RSBDReader["user_id"].ToString();
                    MessageBox.Show("User found!");

                    Form2 newForm = new Form2();
                    newForm.StartPosition = FormStartPosition.CenterScreen;
                    newForm.Size = Screen.PrimaryScreen.WorkingArea.Size;
                    newForm.accountname = Name;
                    newForm.accountrole = Role;
                    newForm.accountID = users;
                    newForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RSDBConnect.Close();
                RSBDReader.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void close_button_Click(object sender, EventArgs e)
        {
            DialogResult userChoice;
            userChoice = MessageBox.Show("Confirm if you want to close the app", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (userChoice == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
