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

namespace VAWC_Recording_System.NewForms
{
    public partial class AddAccountDetails : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        RSBDConnection dbcon = new RSBDConnection();
        private int currentUserId;
        string userID;
        public AddAccountDetails(string userID)
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            currentUserId = accountaddusers();
            this.userID = userID;
        }

        private void AddAccountDetails_Load(object sender, EventArgs e)
        {
            label11.Text = accountaddusers().ToString();
        }

        private int accountaddusers()
        {
            int autoID = 4100;
            try
            {
                RSDBConnect.Open();
                string query = "SELECT MAX(user_ID) FROM users";
                MySqlCommand command = new MySqlCommand(query, RSDBConnect);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    autoID = Convert.ToInt32(result) + 1;

                }
                RSDBConnect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating auto ID: " + ex.Message);
            }
            return autoID;
        }
     
        private void TogglePasswordVisibility(System.Windows.Forms.TextBox textBox, PictureBox pictureBox)
        {
            textBox.UseSystemPasswordChar = !textBox.UseSystemPasswordChar;

            if (textBox.UseSystemPasswordChar)
            {
                pictureBox.Image = Properties.Resources.Invisible;
            }
            else
            {
                pictureBox.Image = Properties.Resources.Eye;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addusersnow_Click(object sender, EventArgs e)
        {
            try
            {
                SFAddingAcc newForm = new SFAddingAcc(userID);
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                    {
                        MessageBox.Show("Please fill in all required fields!");
                        return;
                    }

                   
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("Passwords do not match!");
                        return;
                    }

                    if (MessageBox.Show("Are you sure you want to add new user?", "New User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RSDBConnect.Open();
                        string insertQuery = "INSERT INTO users (user_ID, user, password, role, firstName, middleName, lastName, status) VALUES (@userID, @username, @password, @role, @firstname, @middlename, @lastname, @status)";
                        MySqlCommand RSDBCommand = new MySqlCommand(insertQuery, RSDBConnect);
                        RSDBCommand.Parameters.AddWithValue("@userID", currentUserId++);
                        RSDBCommand.Parameters.AddWithValue("@username", textBox1.Text);
                        RSDBCommand.Parameters.AddWithValue("@password", textBox2.Text);
                        RSDBCommand.Parameters.AddWithValue("@role", "Administrator");
                        RSDBCommand.Parameters.AddWithValue("@firstname", textBox4.Text);
                        RSDBCommand.Parameters.AddWithValue("@middlename", string.IsNullOrEmpty(textBox5.Text) ? (object)DBNull.Value : textBox5.Text);
                        RSDBCommand.Parameters.AddWithValue("@lastname", textBox6.Text);
                        RSDBCommand.Parameters.AddWithValue("@status", "active");
                        RSDBCommand.ExecuteNonQuery();
                        RSDBConnect.Close();
                        MessageBox.Show("New user added successfully!");

                        clearalltextbox();
                        this.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding new user: " + ex.Message);
            }
        }

        public void clearalltextbox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox2, pictureBox9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox3, pictureBox10);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 5)
            {
                label2.Text = "Your password is too short!";
            }
            else
            {
                label2.Text = "";
            }
        }
    }
}
