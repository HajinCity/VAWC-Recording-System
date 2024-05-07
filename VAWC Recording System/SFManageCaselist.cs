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
    public partial class SFManageCaselist : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        public SFManageCaselist()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
        }

        private void SecurityMLL()
        {
            try
            {
                RSDBConnect.Open();
                string query = "SELECT * FROM users WHERE user = @user AND password = @password";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                RSDBCommand.Parameters.AddWithValue("@user", username_txtbx.Text);
                RSDBCommand.Parameters.AddWithValue("@password", password_txtbx.Text);
                RSBDReader = RSDBCommand.ExecuteReader();

                if (RSBDReader.HasRows)
                {
                    MessageBox.Show("Officer found!");
                    DialogResult = DialogResult.OK; // Set DialogResult to OK if login successful
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Officer not found");
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


        private void button1_Click(object sender, EventArgs e)
        {
            SecurityMLL();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

