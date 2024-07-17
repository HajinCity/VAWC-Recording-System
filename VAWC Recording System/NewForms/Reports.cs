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

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            try
            {
                RSDBConnect.Open();
                RSDBCommand = RSDBConnect.CreateCommand();
                RSDBCommand.CommandText = @"
                    SELECT case_Violation, case_SubViolation, COUNT(*) AS violation_count
                    FROM caselist
                    WHERE case_ComplaintDate BETWEEN @startDate AND @endDate
                    AND (case_Violation = 'R.A. 9262: Anti Violence Against Women and their Children Act'
                    OR case_Violation = 'R.A. 8353: Anti-Rape Law of 1995'
                    OR case_Violation = 'R.A. 7877: Anti-Sexual Harrassment Act'
                    OR case_Violation = 'R.A. 9208: Anti-Trafficking in Person Act of 2003'
                    OR case_Violation = 'R.A. 9775: Anti-Child Pornography Act'
                    OR case_Violation = 'R.A. 9995: Anti-Photo and Video Act 2009'
                    OR case_Violation = 'Revised Penal Code'
                    OR case_Violation = 'R.A. 7610: Special Protection of Children Against Child Abuse, Exploitation and Discrimination Act')
                    GROUP BY case_Violation, case_SubViolation";

                RSDBCommand.Parameters.AddWithValue("@startDate", startDate);
                RSDBCommand.Parameters.AddWithValue("@endDate", endDate);

                RSBDReader = RSDBCommand.ExecuteReader();

                int ra9262Count = 0;
                int ra8353Count = 0;
                int ra7877Count = 0;
                int ra9208Count = 0;
                int combinedCount = 0;

                int ra9262SexualCount = 0;
                int ra9262PsychologicalCount = 0;
                int ra9262PhysicalCount = 0;
                int ra9262EconomicCount = 0;

                while (RSBDReader.Read())
                {
                    string violation = RSBDReader["case_Violation"].ToString();
                    int count = Convert.ToInt32(RSBDReader["violation_count"]);
                    string subViolation = RSBDReader["case_SubViolation"].ToString();

                    switch (violation)
                    {
                        case "R.A. 9262: Anti Violence Against Women and their Children Act":
                            ra9262Count += count;

                            switch (subViolation)
                            {
                                case "Sexual Abuse":
                                    ra9262SexualCount += count;
                                    break;
                                case "Psychological":
                                    ra9262PsychologicalCount += count;
                                    break;
                                case "Physical":
                                    ra9262PhysicalCount += count;
                                    break;
                                case "Economic":
                                    ra9262EconomicCount += count;
                                    break;
                            }
                            break;
                        case "R.A. 8353: Anti-Rape Law of 1995":
                            ra8353Count = count;
                            break;
                        case "R.A. 7877: Anti-Sexual Harrassment Act":
                            ra7877Count = count;
                            break;
                        case "R.A. 9208: Anti-Trafficking in Person Act of 2003":
                            ra9208Count = count;
                            break;
                        case "R.A. 9775: Anti-Child Pornography Act":
                        case "R.A. 9995: Anti-Photo and Video Act 2009":
                        case "Revised Penal Code":
                        case "R.A. 7610: Special Protection of Children Against Child Abuse, Exploitation and Discrimination Act":
                            combinedCount += count;
                            break;
                    }
                }

                cnt_9262.Text = ra9262Count.ToString();
                cnt_8353.Text = ra8353Count.ToString();
                cnt_7877.Text = ra7877Count.ToString();
                cnt_9208.Text = ra9208Count.ToString();
                cnt_remaining.Text = combinedCount.ToString();

                // sub-violation counts for R.A. 9262
                cnt_9262_Sexual.Text = ra9262SexualCount.ToString();
                cnt_9262_Psychological.Text = ra9262PsychologicalCount.ToString();
                cnt_9262_Physical.Text = ra9262PhysicalCount.ToString();
                cnt_9262_Economic.Text = ra9262EconomicCount.ToString();

                RSBDReader.Close();

                // Display success message
                MessageBox.Show("Counted cases successfully retrieved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                RSDBConnect.Close();
            }
        }
    }
}
