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
    public partial class HandOrgForm : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();

        //Form2 f = new Form2;
       
        string userID;
        public HandOrgForm(Form f,string userID)
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            this.userID = userID;
            //this.f;
            showdetails();
        }

        private void showdetails()
        {
            string query = "SELECT * FROM organization";
            RSDBCommand = new MySqlCommand(query, RSDBConnect);
            RSDBConnect.Open();
            RSBDReader = RSDBCommand.ExecuteReader();

            while (RSBDReader.Read())
            {
                
                label15.Text = RSBDReader["h_orgName"].ToString();
                label16.Text = RSBDReader["h_orgPurok"].ToString();
                label17.Text = RSBDReader["h_orgBaranggay"].ToString();
                label18.Text = RSBDReader["h_orgMunicipality"].ToString();
                label19.Text = RSBDReader["h_orgProvince"].ToString();
                label20.Text = RSBDReader["h_orgRegion"].ToString();

                textBox7.Text = RSBDReader["intake_lastName"].ToString();
                textBox8.Text = RSBDReader["intake_firstName"].ToString();
                textBox9.Text = RSBDReader["intake_middleName"].ToString();
                textBox10.Text = RSBDReader["intake_Position"].ToString();

                textBox11.Text = RSBDReader["casemanager_lastName"].ToString();
                textBox12.Text = RSBDReader["casemanager_firstName"].ToString();
                textBox13.Text = RSBDReader["casemanager_middleName"].ToString();


            }

            RSBDReader.Close();
            RSDBConnect.Close();
        }


        private void btn_saveInfo_Click(object sender, EventArgs e)
        {
            // Display SFnewform
            SFHandOrg newForm = new SFHandOrg(userID);
           //if correct tong credentials sa SFHandOrg then diritso
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are you sure you want to update Organization Details?", "Organization Information Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "UPDATE organization SET intake_lastName = @intake_lastName, intake_firstName = @intake_firstName, intake_middleName = @intake_middleName, intake_Position = @intake_Position, casemanager_lastName = @casemanager_lastName, casemanager_firstName = @casemanager_firstName, casemanager_middleName = @casemanager_middleName";

                    using (MySqlCommand RSDBCommand = new MySqlCommand(query, RSDBConnect))
                    {
                        RSDBCommand.Parameters.AddWithValue("@intake_lastName", string.IsNullOrEmpty(textBox7.Text) ? (object)DBNull.Value : textBox7.Text);
                        RSDBCommand.Parameters.AddWithValue("@intake_firstName", string.IsNullOrEmpty(textBox8.Text) ? (object)DBNull.Value : textBox8.Text);
                        RSDBCommand.Parameters.AddWithValue("@intake_middleName", string.IsNullOrEmpty(textBox9.Text) ? (object)DBNull.Value : textBox9.Text);
                        RSDBCommand.Parameters.AddWithValue("@intake_Position", string.IsNullOrEmpty(textBox10.Text) ? (object)DBNull.Value : textBox10.Text);
                        RSDBCommand.Parameters.AddWithValue("@casemanager_lastName", string.IsNullOrEmpty(textBox11.Text) ? (object)DBNull.Value : textBox11.Text);
                        RSDBCommand.Parameters.AddWithValue("@casemanager_firstName", string.IsNullOrEmpty(textBox12.Text) ? (object)DBNull.Value : textBox12.Text);
                        RSDBCommand.Parameters.AddWithValue("@casemanager_middleName", string.IsNullOrEmpty(textBox13.Text) ? (object)DBNull.Value : textBox13.Text);

                        RSDBConnect.Open();
                        RSDBCommand.ExecuteNonQuery();
                        RSDBConnect.Close();
                    }

                    MessageBox.Show("Organization Details Updated Successfully!", "Organization Information Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

    }
}
