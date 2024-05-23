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
    public partial class SFAddingAcc : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        string userID;
        public SFAddingAcc(string userID)
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            this.userID = userID;
        }
        private void SecurityPassage()
        {
            try
            {
                RSDBConnect.Open();

                string query = "SELECT * FROM users WHERE user = @user AND password = @password";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                RSDBCommand.Parameters.AddWithValue("@user", textBox1.Text);
                RSDBCommand.Parameters.AddWithValue("@password", textBox2.Text);
                RSBDReader = RSDBCommand.ExecuteReader();

                if (RSBDReader.HasRows)
                {
                    RSBDReader.Read();
                    string actualUserIdentifier = RSBDReader["user_id"].ToString();
                    if (actualUserIdentifier == userID)
                    {
                        MessageBox.Show("Officer found!");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unauthorized access attempt.");
                    }
                }
                else
                {
                    MessageBox.Show("Officer not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RSDBConnect.Close();
                RSBDReader?.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecurityPassage();
        }
    }
}
