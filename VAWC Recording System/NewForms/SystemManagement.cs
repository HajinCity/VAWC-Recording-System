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
    public partial class SystemManagement : Form
    {

        public SystemManagement()
        {
            InitializeComponent();


        }

        private void label7_Click(object sender, EventArgs e)
        {
           
                
                UserSecurityForm userSecurityForm = new UserSecurityForm();

                userSecurityForm.TopLevel = false;

                userSecurityForm.FormBorderStyle = FormBorderStyle.None;

                userSecurityForm.Dock = DockStyle.Fill;

                panel2.Controls.Clear();

                panel2.Controls.Add(userSecurityForm);

                userSecurityForm.Show();
            

        }

        private void label6_Click(object sender, EventArgs e)
        {
            HandOrgForm handOrgForm = new HandOrgForm();

            handOrgForm.TopLevel = false;

            handOrgForm.FormBorderStyle = FormBorderStyle.None;

            handOrgForm.Dock = DockStyle.Fill;

            panel2.Controls.Clear();

            panel2.Controls.Add(handOrgForm);

            handOrgForm.Show();
        }
    }
}
