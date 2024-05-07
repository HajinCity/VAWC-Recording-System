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

namespace VAWC_Recording_System
{
    public partial class Form2 : Form
    {
        private Form activeForm;
       
        public Form2()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;
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
            openingForm(new NewForms.EmptyForms());
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
             openingForm(new NewForms.Reports());
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
          //  openingForm(new NewForms.NewCase);
        }

        private void manageCaselist_btn_Click(object sender, EventArgs e)
        {
            SFManageCaselist loginForm = new SFManageCaselist();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                openingForm(new NewForms.ManageCaseList());
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult userChoice;
            userChoice = MessageBox.Show("Confirm if you want to Log Out", "Confirmation",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (userChoice == DialogResult.Yes)
            {
              
                Application.Exit();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            home_btn_Click(sender, e);
        }

        private void systemManagement_btn_Click(object sender, EventArgs e)
        {
            openingForm(new NewForms.SystemManagement());
        }
    }
}
