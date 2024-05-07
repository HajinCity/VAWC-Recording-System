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
    public partial class CaseList : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        public CaseList()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
        }

        private void LoadRecords(string filter)
        {
            try
            {
                RSDBConnect.Open();
                string query = "SELECT * FROM caselist";

               
                if (!string.IsNullOrEmpty(filter))
                {
                    query += $" WHERE case_cLastName LIKE '%{filter}%' OR case_cFirstName LIKE '%{filter}%' OR case_rLastName LIKE '%{filter}%' OR case_rFirstName LIKE '%{filter}%' OR case_rAlias LIKE '%{filter}%'";
                }

                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                RSBDReader = RSDBCommand.ExecuteReader();

                dataGridView1.Rows.Clear();

                while (RSBDReader.Read())
                {
                    string column1Value = RSBDReader["caseNo"].ToString();
                    DateTime complaintDate = Convert.ToDateTime(RSBDReader["case_ComplaintDate"]);
                    string column2Value = complaintDate.ToString("MM-dd-yyyy");
                    string column3Value = RSBDReader["case_cLastName"].ToString();
                    string column4Value = RSBDReader["case_cFirstName"].ToString();
                    string column5Value = RSBDReader["case_cAge"].ToString();
                    string column6Value = RSBDReader["case_rLastName"].ToString();
                    string column7Value = RSBDReader["case_rFirstName"].ToString();
                    string column8Value = RSBDReader["case_rAlias"].ToString();
                    string column9Value = RSBDReader["case_Violation"].ToString();
                    string column10Value = RSBDReader["case_SubViolation"].ToString();
                    string column11Value = RSBDReader["case_ReferredTo"].ToString();
                    string column12Value = RSBDReader["case_Status"].ToString();

                    dataGridView1.Rows.Add(column1Value, column2Value, column3Value, column4Value, column5Value, column6Value, column7Value, column8Value, column9Value, column10Value, column11Value, column12Value);
                }

                RSBDReader.Close();
                RSDBConnect.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Database Error");
            }
        }

        private void CaseList_Load(object sender, EventArgs e)
        {
            LoadRecords("");
         //   dataGridView1.ScrollBars = ScrollBars.Vertical;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text.Trim();
            LoadRecords(filter);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
