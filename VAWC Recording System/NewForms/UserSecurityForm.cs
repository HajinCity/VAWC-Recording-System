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
        string userID;
        public UserSecurityForm(string userID)
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            this.userID = userID;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        /*
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
        */
        private void loadrecordaccounts()
        {
            try
            {
                RSDBConnect.Open();
                string query = "SELECT * FROM users WHERE user_id >= @startUserId";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                RSDBCommand.Parameters.AddWithValue("@startUserId", 4100);

                RSBDReader = RSDBCommand.ExecuteReader();
                {
                    dataGridView1.Rows.Clear();

                    while (RSBDReader.Read())
                    {
                        string column1Value = RSBDReader["user_id"]?.ToString() ?? "";
                        string column2Value = RSBDReader["user"]?.ToString() ?? "";
                        string column3Value = RSBDReader["lastName"]?.ToString() ?? "";
                        string column4Value = RSBDReader["firstName"]?.ToString() ?? "";
                        string column5Value = RSBDReader["middleName"]?.ToString() ?? "";
                        string column6Value = RSBDReader["status"]?.ToString() ?? "";

                        dataGridView1.Rows.Add(column1Value, column2Value, column3Value, column4Value, column5Value, column6Value);
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

        private void btn_addusers_Click(object sender, EventArgs e)
        {
            AddAccountDetails openthis = new AddAccountDetails(userID);
            openthis.FormClosed += new FormClosedEventHandler(AddAccountDetails_FormClosed);
            openthis.ShowDialog();
        }
        private void AddAccountDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadrecordaccounts();
        }
        private void btn_editusers_Click(object sender, EventArgs e)
        {
            SFEditInfos newForm = new SFEditInfos(userID);
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are you sure you want to Edit this user?", "Edit User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        RSDBConnect.Open();
                        string query = "UPDATE users SET lastName = @lastName, firstName = @firstName, middleName = @middleName WHERE user_id = @userId";
                        RSDBCommand = new MySqlCommand(query, RSDBConnect);
                        RSDBCommand.Parameters.AddWithValue("@lastName", lastNametxtb.Text);
                        RSDBCommand.Parameters.AddWithValue("@firstName", firstNametxtb.Text);
                        RSDBCommand.Parameters.AddWithValue("@middleName", midNametxtb.Text);
                        RSDBCommand.Parameters.AddWithValue("@userId", label6.Text);
                        RSDBCommand.ExecuteNonQuery();
                        MessageBox.Show("User details updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to update user: " + ex.Message);
                    }
                    finally
                    {
                        if (RSDBConnect != null && RSDBConnect.State == ConnectionState.Open)
                        {
                            RSDBConnect.Close();
                        }
                    }
                    clear();
                    loadrecordaccounts();
                }
            }
        }

        public void clear()
        {
            label6.Text= "";
            lastNametxtb.Clear();
            firstNametxtb.Clear();
            midNametxtb.Clear();

        }

        private void btn_voidaccess_Click(object sender, EventArgs e)
        {
            SFvoid newForm = new SFvoid(userID);
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RSDBConnect.Open();

                    string query = "UPDATE users SET status = 'inactive' WHERE user_id = @userId";

                    RSDBCommand = new MySqlCommand(query, RSDBConnect);
                    RSDBCommand.Parameters.AddWithValue("@userId", label6.Text);
                    RSDBCommand.ExecuteNonQuery();

                    MessageBox.Show("User access set to inactive successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to set user access to inactive: " + ex.Message);
                }
                finally
                {
                    if (RSDBConnect != null && RSDBConnect.State == ConnectionState.Open)
                    {
                        RSDBConnect.Close();
                    }
                }
            }

            loadrecordaccounts();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                lastNametxtb.Text = row.Cells["Column3"].Value.ToString();
                firstNametxtb.Text = row.Cells["Column4"].Value.ToString();
                midNametxtb.Text = row.Cells["Column5"].Value.ToString();
                label6.Text = row.Cells["Column1"].Value.ToString();
            }
        }

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            SFChangePass newForm = new SFChangePass(userID);
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                frmChangePass openform = new frmChangePass(userID);
                openform.ShowDialog();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
