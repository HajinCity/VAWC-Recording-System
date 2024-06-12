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
using VAWC_Recording_System.NewForms;

namespace VAWC_Recording_System
{
    public partial class Form2 : Form
    {
        private const string Format = "dddd, MMMM dd, yyyy";
        private Form activeForm;


        public string accountname
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string accountrole
        {
            get { return label2.Text; }
            set { label2.Text = value;}
        }

        public string accountID
        {
            get { return label5.Text; }
            set { label5.Text = value; }
        }

        public Form2()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString(Format);
            label6.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void openingForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
           
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void newCase_btn_Click(object sender, EventArgs e)
        {
            openingForm(new NewForms.NewCase());
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            openingForm(new NewForms.HomeForm());
        }

        private void caseList_btn_Click(object sender, EventArgs e)
        {
            openingForm(new NewForms.CaseList());
        }
        private void inTakeForm_btn_Click(object sender, EventArgs e)
        {
            openingForm(new NewForms.IntakeForm());
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
             openingForm(new NewForms.Reports());
        }

        private void manageCaselist_btn_Click(object sender, EventArgs e)
        {
            string currentUser = label5.Text; 
            SFManageCaselist loginForm = new SFManageCaselist(this, currentUser);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                panel4.Controls.Clear();
                openingForm(new NewForms.ManageCaseList());
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult userChoice;
            userChoice = MessageBox.Show("Confirm if you want to log out", "Confirmation",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (userChoice == DialogResult.Yes)
            {
                this.Hide();
                Form1 loginForm = new Form1();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            home_btn_Click(sender, e);
        }

        private void systemManagement_btn_Click(object sender, EventArgs e)
        {
            string userID = label5.Text; 
            openingForm(new NewForms.SystemManagement(this, userID));
        }

        public void balikmode()
        {
            string userID = label5.Text;
            openingForm(new NewForms.SystemManagement(this, userID));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            DialogResult userChoice;
            userChoice = MessageBox.Show("Note : This will also log out your account\n\nConfirm if you want to close the app", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (userChoice == DialogResult.Yes)
            {

                Application.Exit();
            }
        }
    }
}
