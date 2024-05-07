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
    public partial class UserSecurityForm : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        public UserSecurityForm()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TogglePasswordVisibility(TextBox textBox, PictureBox pictureBox)
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox7, pictureBox12);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox8, pictureBox13);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(textBox9, pictureBox14);
        }

        private void loadrecordaccounts()
        {
            try
            {
                RSDBConnect.Open();
                string query = "SELECT * FROM users";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                {
                    RSBDReader = RSDBCommand.ExecuteReader();
                    {
                        dataGridView1.Rows.Clear();

                        while (RSBDReader.Read())
                        {
                            string column1Value = RSBDReader["user_id"]?.ToString() ?? "";
                            string column2Value = RSBDReader["user"]?.ToString() ?? "";
                            string column3Value = RSBDReader["lastName"]?.ToString() ?? "";
                            string column4Value = RSBDReader["firstName"]?.ToString() ?? "";

                            dataGridView1.Rows.Add(column1Value, column2Value, column3Value, column4Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load records: " + ex.Message);
            }
            finally
            {
                if (RSDBConnect != null && RSDBConnect.State == ConnectionState.Open)
                {
                    RSDBConnect.Close();
                }
            }
        }


        private void UserSecurityForm_Load(object sender, EventArgs e)
        {
            loadrecordaccounts();
        }
    }
}
