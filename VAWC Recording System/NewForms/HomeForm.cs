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
    public partial class HomeForm : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();

        private RA9262uc u9262; // Declare as class-level field
        private RA8353uc u8353; // Declare as class-level field
        private RA7877uc u7877; // Declare as class-level field
        private RA7610 u7610;
        private RA9208 u9208;
        private RA9775 u9775;
        private RA9995 u9995;
        private RPC uRPC;

        public HomeForm()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());

            // Initialize user controls
            u9262 = new RA9262uc();
            u8353 = new RA8353uc();
            u7877 = new RA7877uc();
            u7610 = new RA7610();
            u9208 = new RA9208();
            u9775 = new RA9775();
            u9995 = new RA9995();
            uRPC = new RPC();
            loadCountsToday();
            loadCountsThisWeek();
            loadCountsThisMonth();

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            panel1.Size = new Size(1200, 6700);

            u9262.Dock = DockStyle.Fill;

            u9262.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(u9262);

            u9262.Show();
        }

        private void RA9262_Button_Click(object sender, EventArgs e)
        {
            u8353.Hide(); // Hide the other user control
            u7877.Hide();
            u7610.Hide();
            u9208.Hide();
            u9775.Hide();
            u9995.Hide();
            uRPC.Hide();

            panel1.Size = new Size(1200, 6700);

            u9262.Dock = DockStyle.Fill;

            u9262.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(u9262);

            u9262.Show();
        }

        private void RA8353_Button_Click(object sender, EventArgs e)
        {
            u9262.Hide(); // Hide the other user control
            u7877.Hide();
            u7610.Hide();
            u9208.Hide();
            u9775.Hide();
            u9995.Hide();
            uRPC.Hide();

            // Set the desired size for u8353 (adjust as needed)
            panel1.Size = new Size(1200, 1520);

            // Set the Dock and Anchor properties
            u8353.Dock = DockStyle.Fill;
            u8353.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Add u8353 to the panel
            panel1.Controls.Add(u8353);

            // Show u8353
            u8353.Show();
        }

        private void RA7877_Button_Click(object sender, EventArgs e)
        {
            u9262.Hide(); // Hide the other user control
            u8353.Hide();
            u7610.Hide();
            u9208.Hide();
            u9775.Hide();
            u9995.Hide();
            uRPC.Hide();

            panel1.Size = new Size(1200, 2250);

            // Set the Dock and Anchor properties
            u7877.Dock = DockStyle.Fill;
            u7877.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(u7877);

            u7877.Show();
        }

        private void RA7610_Button_Click(object sender, EventArgs e)
        {
            u9262.Hide(); // Hide the other user control
            u8353.Hide();
            u7877.Hide();
            u9208.Hide();
            u9775.Hide();
            u9995.Hide();
            uRPC.Hide();

            panel1.Size = new Size(1200, 2150);

            // Set the Dock and Anchor properties
            u7610.Dock = DockStyle.Fill;
            u7610.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(u7610);

            u7610.Show();
        }

        private void RA9208_Button_Click(object sender, EventArgs e)
        {
            u9262.Hide(); // Hide the other user control
            u8353.Hide();
            u7877.Hide();
            u7610.Hide();
            u9775.Hide();
            u9995.Hide();
            uRPC.Hide();

            panel1.Size = new Size(1200, 3400);

            // Set the Dock and Anchor properties
            u9208.Dock = DockStyle.Fill;
            u9208.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(u9208);

            u9208.Show();
        }

        private void RA9775_Button_Click(object sender, EventArgs e)
        {
            u9262.Hide(); // Hide the other user control
            u8353.Hide();
            u7877.Hide();
            u7610.Hide();
            u9208.Hide();
            u9995.Hide();
            uRPC.Hide();

            panel1.Size = new Size(1200, 10400);

            // Set the Dock and Anchor properties
            u9775.Dock = DockStyle.Fill;
            u9775.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(u9775);

            u9775.Show();
        }

        private void RA9995_Button_Click(object sender, EventArgs e)
        {
            u9262.Hide(); // Hide the other user control
            u8353.Hide();
            u7877.Hide();
            u7610.Hide();
            u9208.Hide();
            u9775.Hide();
            uRPC.Hide();

            panel1.Size = new Size(1200, 2000);

            // Set the Dock and Anchor properties
            u9995.Dock = DockStyle.Fill;
            u9995.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(u9995);

            u9995.Show();
        }

        private void RPC_Button_Click(object sender, EventArgs e)
        {
            u9262.Hide(); // Hide the other user control
            u8353.Hide();
            u7877.Hide();
            u7610.Hide();
            u9208.Hide();
            u9775.Hide();
            u9995.Hide();

            panel1.Size = new Size(1200, 13800);

            // Set the Dock and Anchor properties
            uRPC.Dock = DockStyle.Fill;
            uRPC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel1.Controls.Add(uRPC);

            uRPC.Show();
        }



        private void loadCountsToday()
        {
            try
            {
                RSDBConnect.ConnectionString = dbcon.MyConnect();
                RSDBConnect.Open();

                string query = "SELECT COUNT(*) FROM caselist WHERE DATE(case_ComplaintDate) = CURDATE()";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                int countToday = Convert.ToInt32(RSDBCommand.ExecuteScalar());

                // Display or use the countToday as needed
                label8.Text = countToday.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's counts: " + ex.Message);
            }
            finally
            {
                RSDBConnect.Close();
            }
        }

        private void loadCountsThisWeek()
        {
            try
            {
                RSDBConnect.ConnectionString = dbcon.MyConnect();
                RSDBConnect.Open();

                string query = "SELECT COUNT(*) FROM caselist WHERE WEEK(case_ComplaintDate, 1) = WEEK(CURDATE(), 1) AND YEAR(case_ComplaintDate) = YEAR(CURDATE())";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                int countThisWeek = Convert.ToInt32(RSDBCommand.ExecuteScalar());

                // Convert the count to string and set it as the label's text
                label9.Text =  countThisWeek.ToString();
            }
            catch (Exception ex)
            {
                label9.Text = "Error loading this week's counts: " + ex.Message;
            }
            finally
            {
                RSDBConnect.Close();
            }
        }

        private void loadCountsThisMonth()
        {
            try
            {
                RSDBConnect.ConnectionString = dbcon.MyConnect();
                RSDBConnect.Open();

                string query = "SELECT COUNT(*) FROM caselist WHERE MONTH(case_ComplaintDate) = MONTH(CURDATE()) AND YEAR(case_ComplaintDate) = YEAR(CURDATE())";
                RSDBCommand = new MySqlCommand(query, RSDBConnect);
                int countThisMonth = Convert.ToInt32(RSDBCommand.ExecuteScalar());

                // Convert the count to string and set it as the label's text
                label10.Text = countThisMonth.ToString();
            }
            catch (Exception ex)
            {
                label10.Text = "Error loading this month's counts: " + ex.Message;
            }
            finally
            {
                RSDBConnect.Close();
            }
        }

    }
}
