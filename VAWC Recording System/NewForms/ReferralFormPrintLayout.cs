using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class ReferralFormPrintLayout : UserControl
    {

        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlCommand RSDBCommand1 = new MySqlCommand();
        MySqlCommand RSDBCommand2 = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        public ReferralFormPrintLayout()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
        }

        private string GetCaseNumberFromDB(string typedCaseNo)
        {
            string casenumber = "";
            try
            {
                RSDBConnect.Open();
                string query = "SELECT caseNo FROM caselist WHERE caseNo = @caseNo";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                RSDBCommand.Parameters.AddWithValue("@caseNo", typedCaseNo);
                RSBDReader = RSDBCommand.ExecuteReader();
                if (RSBDReader.Read())
                {
                    casenumber = RSBDReader["caseNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                RSDBConnect.Close();
            }
            return casenumber;
        }

        private string caseno
        {
            get
            {
                return GetCaseNumberFromDB(textBox1.Text);
            }
            set
            {

            }
        }

        private void loadtheinfo()
        {
            string typedCaseNo = textBox1.Text;
            string caseNoFromDB = caseno;
            try
            {
                RSDBConnect.Open();
                if (typedCaseNo == caseNoFromDB)
                {
                    string query1 = "SELECT * FROM complainant WHERE caseNo = @caseNo";

                    RSDBCommand1 = new MySqlCommand(query1, RSDBConnect);
                    RSDBCommand1.Parameters.AddWithValue("@caseNo", typedCaseNo);
                    MySqlDataReader RSBDReader1 = RSDBCommand1.ExecuteReader();

                    if (RSBDReader1.Read())
                    {
                        //Complainanat 
                        comp_lastname.Text = RSBDReader1["comp_LastName"].ToString();
                        comp_firstname.Text = RSBDReader1["comp_FirstName"].ToString();
                        comp_middlename.Text = RSBDReader1["comp_MiddleName"].ToString();
                        comp_age.Text = RSBDReader1["comp_Age"].ToString();
                        comp_sex.Text = RSBDReader1["comp_Sex"].ToString();
                        // comp_contactNo.Text = RSBDReader1["comp_ContactNo"].ToString();
                        comp_purok.Text = RSBDReader1["comp_Purok"].ToString();
                        comp_Barangay.Text = RSBDReader1["comp_Barangay"].ToString();
                        comp_Muni.Text = RSBDReader1["comp_City"].ToString();
                        comp_Province.Text = RSBDReader1["comp_Province"].ToString();
                       // comp_Region.Text = RSBDReader1["comp_Region"].ToString();

                       
                    }
                    RSDBConnect.Close();
                }
            }
            catch
            {

            }
        }

       

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadtheinfo();
            }
        }
    }
}
