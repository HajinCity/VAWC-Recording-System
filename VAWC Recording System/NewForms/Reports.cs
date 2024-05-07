using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
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

            // Set up the chart
            SetupChart();

            // Populate the chart with data from the database
            PopulateChartWithData();
        }

        private void SetupChart()
        {
            // Assuming you have a chart control named "chart1" on your form
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("MainChartArea");

            // Add a series to the chart
            var series = chart1.Series.Add("DataSeries");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            // Customize x-axis labels to show month names
            chart1.ChartAreas["MainChartArea"].AxisX.Interval = 1;
            chart1.ChartAreas["MainChartArea"].AxisX.Minimum = 1;
            chart1.ChartAreas["MainChartArea"].AxisX.Maximum = 12;

            // Set the custom property to display month names
            for (int i = 1; i <= 12; i++)
            {
                chart1.ChartAreas["MainChartArea"].AxisX.CustomLabels.Add(i - 0.5, i + 0.5, GetMonthName(i));
            }
        }

        private void PopulateChartWithData()
        {
            try
            {

                // Open the connection
                RSDBConnect.Open();

                // Get the current year
                int currentYear = DateTime.Now.Year;

                // Query to fetch data from the database for the current year
                string query = $"SELECT MONTH(case_ComplaintDate) AS month, COUNT(*) AS records_count FROM caselist WHERE YEAR(case_ComplaintDate) = {currentYear} GROUP BY MONTH(case_ComplaintDate)";

                RSDBCommand.CommandText = query;
                RSDBCommand.Connection = RSDBConnect;

                // Execute the query
                RSBDReader = RSDBCommand.ExecuteReader();

                // Populate the chart with data
                while (RSBDReader.Read())
                {
                    int month = RSBDReader.GetInt32("month");
                    int recordsCount = RSBDReader.GetInt32("records_count");

                    // Assuming your series is named "DataSeries"
                    chart1.Series["DataSeries"].Points.AddXY(month, recordsCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the reader and connection
                RSBDReader.Close();
                RSDBConnect.Close();
            }
        }

        private string GetMonthName(int monthNumber)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(monthNumber);
        }
    }
}
