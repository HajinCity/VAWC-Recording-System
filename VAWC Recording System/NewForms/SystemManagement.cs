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
    public partial class SystemManagement : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        Form2 f;
        string userID;

        public SystemManagement(Form2 frm,string userID)
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            this.userID = userID; 
            f = frm;
            lbl_userID.Text= userID;
            DisplayUserID();

        }
        public void DisplayUserID()
        {
            string query = "SELECT firstName, lastName, middleName FROM users WHERE user_id = @user_id";
            RSDBCommand = new MySqlCommand(query, RSDBConnect);
            RSDBCommand.Parameters.AddWithValue("@user_id", userID);
            RSDBConnect.Open();
            RSBDReader = RSDBCommand.ExecuteReader();

            if (RSBDReader.Read())
            {
                lbl_FullName.Text = RSBDReader["firstName"].ToString() + " " + RSBDReader["middleName"].ToString() + "." + " " + RSBDReader["lastName"].ToString();
            }

            RSDBConnect.Close();
        }


        private void label7_Click(object sender, EventArgs e)
        {
            UserSecurityForm userSecurityForm = new UserSecurityForm(userID);
            userSecurityForm.TopLevel = false;
            userSecurityForm.FormBorderStyle = FormBorderStyle.None;
            userSecurityForm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userSecurityForm);
            userSecurityForm.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
            HandOrgForm handOrgForm = new HandOrgForm(f,userID);
            handOrgForm.TopLevel = false;
            handOrgForm.FormBorderStyle = FormBorderStyle.None;
            handOrgForm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(handOrgForm);
            handOrgForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            HandOrgForm handOrgForm = new HandOrgForm(f, userID);
            handOrgForm.TopLevel = false;
            handOrgForm.FormBorderStyle = FormBorderStyle.None;
            handOrgForm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(handOrgForm);
            handOrgForm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            UserSecurityForm userSecurityForm = new UserSecurityForm(userID);
            userSecurityForm.TopLevel = false;
            userSecurityForm.FormBorderStyle = FormBorderStyle.None;
            userSecurityForm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userSecurityForm);
            userSecurityForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SystemManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
