using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace VAWC_Recording_System.NewForms
{
    public partial class Reports : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();

        public Reports()
        {
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            InitializeComponent();
        }

        private void LoadDataIntoLabel()
        {
            string query = @"
                SELECT 
                    case_Violation, 
                    COUNT(*) as ViolationCount 
                FROM 
                    caselist 
                WHERE 
                    case_ComplaintDate BETWEEN @startDate AND @endDate 
                GROUP BY 
                    case_Violation";

            using (MySqlConnection conn = new MySqlConnection(dbcon.MyConnect()))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@endDate", dateTimePicker2.Value.ToString("yyyy-MM-dd"));

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            StringBuilder sb = new StringBuilder();
                            while (reader.Read())
                            {
                                string violation = reader["case_Violation"].ToString();
                                int count = Convert.ToInt32(reader["ViolationCount"]);
                                sb.AppendLine($"{violation}: {count}");
                            }

                            cnt_9262.Text = sb.ToString();
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataIntoLabel();
        }
    }
}
