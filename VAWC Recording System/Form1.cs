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
                RSDBConnect.Open();
                string query = "SELECT * FROM users WHERE user = @user AND password = @password";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                RSDBCommand.Parameters.AddWithValue("@user", username_txtbx.Text);
                RSDBCommand.Parameters.AddWithValue("@password", password_txtbx.Text);
                RSBDReader = RSDBCommand.ExecuteReader();

                if (RSBDReader.HasRows)
                {
                    MessageBox.Show("User found!");

                    Form2 newForm = new Form2();
                    
                    newForm.StartPosition = FormStartPosition.CenterScreen; 
                    newForm.Size = Screen.PrimaryScreen.WorkingArea.Size;
                 //   newForm.WindowState = FormWindowState.Maximized; 
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



    }
}
