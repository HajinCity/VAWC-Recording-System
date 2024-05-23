using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace VAWC_Recording_System.NewForms
{
    public partial class frmChangePass : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        string userID;
        public frmChangePass(string userID)
        {
            InitializeComponent();

            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            this.userID = userID;
        }

        private void ChangePassword()
        {
            string currentPassword = textBox1.Text;
            string newPassword = textBox2.Text;
            string confirmPassword = textBox3.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            RSDBCommand.Connection = RSDBConnect;
            RSDBCommand.CommandText = "SELECT password FROM users WHERE user_id = @userID";
            RSDBCommand.Parameters.AddWithValue("@userID", userID);

            RSDBConnect.Open();
            RSBDReader = RSDBCommand.ExecuteReader();

            if (RSBDReader.Read())
            {
                string storedPassword = RSBDReader["password"].ToString();

                if (storedPassword != currentPassword)
                {
                    MessageBox.Show("Current password is incorrect.");
                }
                else
                {
                    RSBDReader.Close();
                    RSDBCommand.CommandText = "UPDATE users SET password = @newPassword WHERE user_id = @userID";
                    RSDBCommand.Parameters.AddWithValue("@newPassword", newPassword);
                    RSDBCommand.ExecuteNonQuery();
                    MessageBox.Show("Password changed successfully.");
                }
            }

            RSDBConnect.Close();
            this.Close();
        }


        private void TogglePasswordVisibility(TextBox textBox, PictureBox pictureBox)
        {
            textBox.UseSystemPasswordChar = !textBox.UseSystemPasswordChar;
            pictureBox.Image = textBox.UseSystemPasswordChar ? Properties.Resources.Invisible : Properties.Resources.Eye;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox1, pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox2, pictureBox4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox3, pictureBox6);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                ChangePassword();
           
        }
    }
}
