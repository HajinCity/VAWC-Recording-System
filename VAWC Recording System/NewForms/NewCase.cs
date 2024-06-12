using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VAWC_Recording_System.NewForms
{
    public partial class NewCase : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        // RSDBConnect.ConnectionString = MyConnect();
        public NewCase()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            CompAutoID = CompGenerateAutoID();
            ResAutoID = ResGenerateAutoID();
            CaseAutoID = CaseGenerateAutoID();
            cmbxRA.SelectedIndexChanged += cmbxVS_SelectedIndexChanged;

            complaintDate.MinDate = DateTime.Today;
            complaintDate.MaxDate = DateTime.Today;
            complaintDate.Value = DateTime.Today;
        }


        private void NewCase_Load(object sender, EventArgs e)
        {
            //Carlos code
            //label58.Text = CompGenerateAutoID().ToString();
            //label59.Text = ResGenerateAutoID().ToString();
            //label60.Text = CaseGenerateAutoID().ToString();

            //semi edited as per mali
            label58.Text = CaseGenerateAutoID().ToString(); 
            label59.Text = CompGenerateAutoID().ToString();
            label60.Text = ResGenerateAutoID().ToString();

            compContactNotxtb.TextChanged += compContactNotxtb_TextChanged;
            respoContactNotxtb.TextChanged += respoContactNotxtb_TextChanged;
            compAgetxtb.TextChanged += compAgetxtb_TextChanged;
            respoAgetxtb.TextChanged += respoAgetxtb_TextChanged;

        }
        private int CompGenerateAutoID()
        {
            int autoID = 160001;
            try
            {
                RSDBConnect.Open();
                string query = "SELECT MAX(comp_ID) FROM complainant";
                MySqlCommand command = new MySqlCommand(query, RSDBConnect);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    autoID = Convert.ToInt32(result) + 1;

                }
                RSDBConnect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating auto ID: " + ex.Message);
            }
            return autoID;
        }
        public int CompAutoID
        {
            get { return CompGenerateAutoID(); }
            private set { }
        }


        private int ResGenerateAutoID()
        {
            int autoID = 190001;
            try
            {
                RSDBConnect.Open();
                string query = "SELECT MAX(respo_ID) FROM respondent";
                MySqlCommand command = new MySqlCommand(query, RSDBConnect);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    autoID = Convert.ToInt32(result) + 1;
                }
                RSDBConnect.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating auto ID: " + ex.Message);
            }
            return autoID;
        }

        public int ResAutoID
        {
            get { return ResGenerateAutoID(); }
            private set { }
        }

        private int CaseGenerateAutoID()
        {
            int autoID = 220001;
            try
            {
                RSDBConnect.Open();
                string query = "SELECT MAX(caseNo) FROM caselist";
                MySqlCommand command = new MySqlCommand(query, RSDBConnect);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    autoID = Convert.ToInt32(result) + 1;
                }
                RSDBConnect.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating auto ID: " + ex.Message);
            }
            return autoID;
        }

        public int CaseAutoID
        {
            get { return CaseGenerateAutoID(); }
            private set { }
        }

        private void ClearTextBox()
        {
            //Clear Text Boxes
            // compIDtxtb.Clear();
            label58.Text = "";
            compLNtxtb.Clear();
            compFNtxtb.Clear();
            compMNtxtb.Clear();
            cmbxcSex.SelectedItem = null;
            compAgetxtb.Clear();
            cmbxcompCStatus.SelectedItem = null;
            cmbxcomp_EdAtt.SelectedItem = null;
            compReligiontxtb.Clear();
            compContactNotxtb.Clear();
            compPuroktxtb.Clear();
            compBarangaytxtb.Clear();
            compCitytxtb.Clear();
            compProvincetxtb.Clear();
            compRegiontxtb.Clear();
            compNationalityTxtbx.Clear();
            compOccupationTxtbx.Clear();
            compPassportTxtbx.Clear();

            // respoIDtxtb.Clear();
            label59.Text = "";
            respoLNtxtb.Clear();
            respoFNtxtb.Clear();
            respoMNtxtb.Clear();
            respoAliastxtb.Clear();
            cmbxRSex.SelectedItem = null;
            respoAgetxtb.Clear();
            respocmbx_CStatus.SelectedItem = null;
            respocmbx_EdAtt.SelectedItem = null;
            respoReligiontxtb.Clear();
            respoContactNotxtb.Clear();
            respoPuroktxtb.Clear();
            respoBarangaytxtb.Clear();
            respoCitytxtb.Clear();
            respoProvincetxtb.Clear();
            respoRegiontxtb.Clear();
            respoNationalityTxtbx.Clear();
            respoOccupationTxtbx.Clear();
            respoPassportTxtbx.Clear();
            respoCmbRelationship.SelectedItem = null;

            // caseNotxtb.Clear();
            label60.Text = "";
            cmbxRA.SelectedItem = null;
            cmbxVS.SelectedItem = null;
            referralTo_cmbx.SelectedItem = null;
            casestatuscmbx.SelectedItem = null;
            description_txtbx.Clear();
            plcofIncident_cmbx.SelectedItem = null;
            incidentPuroktxtb.Clear();
            incidentBarangaytxtb.Clear();
            incidentCitytxtb.Clear();
            incidentProvince.Clear();
            incidentRegiontxtb.Clear();


            //.Clear();
        }

        private void FileCase()
        {

            try
            {
                //Carlos Code
                //int compID = CompGenerateAutoID(); // Get the updated auto-generated ID
                //int respoID = ResGenerateAutoID(); // Get the updated auto-generated ID
                //int caseNo = CaseGenerateAutoID(); // Get the updated auto-generated ID

                //Edited as per switch
                int compID = CompGenerateAutoID(); // Get the updated auto-generated ID
                int respoID = ResGenerateAutoID(); // Get the updated auto-generated ID
                int caseNo = CaseGenerateAutoID(); // Get the updated auto-generated ID

                //label58.Text = CaseGenerateAutoID().ToString();
                //label59.Text = CompGenerateAutoID().ToString();
                //label60.Text = ResGenerateAutoID().ToString();

                using (MySqlConnection RSDBConnect = new MySqlConnection(dbcon.MyConnect()))
                {
                    RSDBConnect.Open();

                    using (MySqlCommand RSDBCommand1 = new MySqlCommand("INSERT INTO complainant(comp_ID, caseNo, comp_LastName, comp_FirstName, comp_MiddleName, comp_Sex, comp_Age, comp_CivilStatus, comp_EducationalAttainmaent, comp_Religion, comp_ContactNo, comp_Purok, comp_Barangay, comp_City, comp_Province, comp_Region, comp_Nationality, comp_Occupation, comp_PassportId) VALUES (@comp_ID, @caseNo, @comp_LastName, @comp_FirstName, @comp_MiddleName, @comp_Sex, @comp_Age, @comp_CivilStatus, @comp_EducationalAttainmaent, @comp_Religion, @comp_ContactNo, @comp_Purok, @comp_Barangay, @comp_City, @comp_Province, @comp_Region, @comp_Nationality, @comp_Occupation, @comp_PassportId)", RSDBConnect))
                    {
                        RSDBCommand1.Parameters.AddWithValue("@comp_ID", CompGenerateAutoID());
                        RSDBCommand1.Parameters.AddWithValue("@caseNo", CaseGenerateAutoID());
                        RSDBCommand1.Parameters.AddWithValue("@comp_LastName", string.IsNullOrEmpty(compLNtxtb.Text) ? (object)DBNull.Value : compLNtxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_FirstName", string.IsNullOrEmpty(compFNtxtb.Text) ? (object)DBNull.Value : compFNtxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_MiddleName", string.IsNullOrEmpty(compMNtxtb.Text) ? (object)DBNull.Value : compMNtxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_Sex", cmbxcSex.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        RSDBCommand1.Parameters.AddWithValue("@comp_Age", string.IsNullOrEmpty(compAgetxtb.Text) ? DBNull.Value : (object)Convert.ToInt32(compAgetxtb.Text));
                        RSDBCommand1.Parameters.AddWithValue("@comp_CivilStatus", cmbxcompCStatus.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        RSDBCommand1.Parameters.AddWithValue("@comp_EducationalAttainmaent", cmbxcomp_EdAtt.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        RSDBCommand1.Parameters.AddWithValue("@comp_Religion", string.IsNullOrEmpty(compReligiontxtb.Text) ? (object)DBNull.Value : compReligiontxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_ContactNo", string.IsNullOrEmpty(compContactNotxtb.Text) ? DBNull.Value : (object)Convert.ToInt64(compContactNotxtb.Text));
                        RSDBCommand1.Parameters.AddWithValue("@comp_Purok", string.IsNullOrEmpty(compPuroktxtb.Text) ? (object)DBNull.Value : compPuroktxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_Barangay", string.IsNullOrEmpty(compBarangaytxtb.Text) ? (object)DBNull.Value : compBarangaytxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_City", string.IsNullOrEmpty(compCitytxtb.Text) ? (object)DBNull.Value : compCitytxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_Province", string.IsNullOrEmpty(compProvincetxtb.Text) ? (object)DBNull.Value : compProvincetxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_Region", string.IsNullOrEmpty(compRegiontxtb.Text) ? (object)DBNull.Value : compRegiontxtb.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_Nationality", string.IsNullOrEmpty(compNationalityTxtbx.Text) ? (object)DBNull.Value : compNationalityTxtbx.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_Occupation", string.IsNullOrEmpty(compOccupationTxtbx.Text) ? (object)DBNull.Value : compOccupationTxtbx.Text);
                        RSDBCommand1.Parameters.AddWithValue("@comp_PassportId", string.IsNullOrEmpty(compPassportTxtbx.Text) ? (object)DBNull.Value : compPassportTxtbx.Text);


                        RSDBCommand1.ExecuteNonQuery();
                    }

                    using (MySqlCommand RSDBCommand2 = new MySqlCommand("INSERT INTO respondent(respo_ID, caseNo, respo_LastName, respo_FirstName, respo_MiddleName, respo_Alias, respo_Sex, respo_Age, respo_CivilStatus, respo_EducationalAttainment, respo_Religion, respo_ContactNo, respo_Purok, respo_Barangay, respo_City, respo_Province, respo_Region, respo_RelationshipToVictim, respo_Nationality, respo_Occupation, respo_PassportID) VALUES (@respo_ID, @caseNo, @respo_LastName, @respo_FirstName, @respo_MiddleName, @respo_Alias, @respo_Sex, @respo_Age, @respo_CivilStatus, @respo_EducationalAttainment, @respo_Religion, @respo_ContactNo, @respo_Purok, @respo_Barangay, @respo_City, @respo_Province, @respo_Region, @respo_RelationshipToVictim, @respo_Nationality, @respo_Occupation, @respo_PassportID)", RSDBConnect))
                    {
                        RSDBCommand2.Parameters.AddWithValue("@respo_ID", ResGenerateAutoID());
                        RSDBCommand2.Parameters.AddWithValue("@caseNo", CaseGenerateAutoID());
                        RSDBCommand2.Parameters.AddWithValue("@respo_LastName", string.IsNullOrEmpty(respoLNtxtb.Text) ? (object)DBNull.Value : respoLNtxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_FirstName", string.IsNullOrEmpty(respoFNtxtb.Text) ? (object)DBNull.Value : respoFNtxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_MiddleName", string.IsNullOrEmpty(respoMNtxtb.Text) ? (object)DBNull.Value : respoMNtxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_Alias", string.IsNullOrEmpty(respoAliastxtb.Text) ? (object)DBNull.Value : respoAliastxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_Sex", cmbxRSex.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        RSDBCommand2.Parameters.AddWithValue("@respo_Age", string.IsNullOrEmpty(respoAgetxtb.Text) ? DBNull.Value : (object)Convert.ToInt32(respoAgetxtb.Text));
                        RSDBCommand2.Parameters.AddWithValue("@respo_Religion", string.IsNullOrEmpty(respoReligiontxtb.Text) ? (object)DBNull.Value : respoReligiontxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_CivilStatus", respocmbx_CStatus.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        RSDBCommand2.Parameters.AddWithValue("@respo_EducationalAttainment", respocmbx_EdAtt.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        RSDBCommand2.Parameters.AddWithValue("@respo_ContactNo", string.IsNullOrEmpty(respoContactNotxtb.Text) ? DBNull.Value : (object)Convert.ToInt64(respoContactNotxtb.Text));
                        RSDBCommand2.Parameters.AddWithValue("@respo_Purok", string.IsNullOrEmpty(respoPuroktxtb.Text) ? (object)DBNull.Value : respoPuroktxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_Barangay", string.IsNullOrEmpty(respoBarangaytxtb.Text) ? (object)DBNull.Value : respoBarangaytxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_City", string.IsNullOrEmpty(respoCitytxtb.Text) ? (object)DBNull.Value : respoCitytxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_Province", string.IsNullOrEmpty(respoProvincetxtb.Text) ? (object)DBNull.Value : respoProvincetxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_Region", string.IsNullOrEmpty(respoRegiontxtb.Text) ? (object)DBNull.Value : respoRegiontxtb.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_Nationality", string.IsNullOrEmpty(respoNationalityTxtbx.Text) ? (object)DBNull.Value : respoNationalityTxtbx.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_Occupation", string.IsNullOrEmpty(respoOccupationTxtbx.Text) ? (object)DBNull.Value : respoOccupationTxtbx.Text);
                        RSDBCommand2.Parameters.AddWithValue("@respo_PassportID", string.IsNullOrEmpty(respoPassportTxtbx.Text) ? (object)DBNull.Value : respoPassportTxtbx.Text);



                        RSDBCommand2.Parameters.AddWithValue("@respo_RelationshipToVictim", respoCmbRelationship.SelectedItem?.ToString() ?? DBNull.Value.ToString());


                        RSDBCommand2.ExecuteNonQuery();
                        using (MySqlCommand RSDBCommand = new MySqlCommand("INSERT INTO caselist(caseNo, case_cLastName, case_cFirstName, case_cAge, case_ComplaintDate, case_rLastName, case_rFirstName, case_rAlias, case_Violation, case_SubViolation, case_ReferredTo, case_Status, case_Description, case_incidentDate, case_plcofincident, case_purok, case_barangay, case_municipality, case_province, case_region,case_respoIdentifyingMarks) VALUES (@caseNo, @case_cLastName, @case_cFirstName, @case_cAge, @case_ComplaintDate, @case_rLastName, @case_rFirstName, @case_rAlias, @case_Violation, @case_SubViolation, @case_ReferredTo, @case_Status, @case_Description, @case_incidentDate, @case_plcofincident, @case_purok, @case_barangay, @case_municipality, @case_province, @case_region, @case_respoIdentifyingMarks)", RSDBConnect))
                        {
                            RSDBCommand.Parameters.AddWithValue("@caseNo", CaseGenerateAutoID());
                            RSDBCommand.Parameters.AddWithValue("@case_cLastName", string.IsNullOrEmpty(compLNtxtb.Text) ? (object)DBNull.Value : compLNtxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_cFirstName", string.IsNullOrEmpty(compFNtxtb.Text) ? (object)DBNull.Value : compFNtxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_cAge", string.IsNullOrEmpty(compAgetxtb.Text) ? DBNull.Value : (object)Convert.ToInt32(compAgetxtb.Text));

                            DateTime CaseDateReported = complaintDate.Value;
                            RSDBCommand.Parameters.AddWithValue("@case_ComplaintDate", CaseDateReported);

                            RSDBCommand.Parameters.AddWithValue("@case_rLastName", string.IsNullOrEmpty(respoLNtxtb.Text) ? (object)DBNull.Value : respoLNtxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_rFirstName", string.IsNullOrEmpty(respoFNtxtb.Text) ? (object)DBNull.Value : respoFNtxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_rAlias", string.IsNullOrEmpty(respoAliastxtb.Text) ? (object)DBNull.Value : respoAliastxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_Violation", cmbxRA.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                            RSDBCommand.Parameters.AddWithValue("@case_SubViolation", cmbxVS.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                            RSDBCommand.Parameters.AddWithValue("@case_ReferredTo", referralTo_cmbx.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                            RSDBCommand.Parameters.AddWithValue("@case_Status", casestatuscmbx.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                            RSDBCommand.Parameters.AddWithValue("@case_Description", string.IsNullOrEmpty(description_txtbx.Text) ? (object)DBNull.Value : description_txtbx.Text);

                            DateTime IncidentCaseDate = incidentDate.Value;
                            RSDBCommand.Parameters.AddWithValue("@case_incidentDate", IncidentCaseDate);

                            RSDBCommand.Parameters.AddWithValue("@case_plcofincident", plcofIncident_cmbx.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                            RSDBCommand.Parameters.AddWithValue("@case_purok", string.IsNullOrEmpty(incidentPuroktxtb.Text) ? (object)DBNull.Value : incidentPuroktxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_barangay", string.IsNullOrEmpty(incidentBarangaytxtb.Text) ? (object)DBNull.Value : incidentBarangaytxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_municipality", string.IsNullOrEmpty(incidentCitytxtb.Text) ? (object)DBNull.Value : incidentCitytxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_province", string.IsNullOrEmpty(incidentProvince.Text) ? (object)DBNull.Value : incidentProvince.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_region", string.IsNullOrEmpty(incidentRegiontxtb.Text) ? (object)DBNull.Value : incidentRegiontxtb.Text);
                            RSDBCommand.Parameters.AddWithValue("@case_respoIdentifyingMarks", string.IsNullOrEmpty(respo_IdentifyingMarks.Text) ? (object)DBNull.Value : respo_IdentifyingMarks.Text);

                            RSDBCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Successfully Added a Case");
                        ClearTextBox();
                        CompAutoID = CompGenerateAutoID();
                        ResAutoID = ResGenerateAutoID();
                        CaseAutoID = CaseGenerateAutoID();
                        RSDBConnect.Close();

                        //Carlos Code
                        //label58.Text = CompAutoID.ToString();
                        //label59.Text = ResAutoID.ToString();
                        //label60.Text = CaseAutoID.ToString();

                        label58.Text = CaseAutoID.ToString();
                        label59.Text = CompAutoID.ToString();
                        label60.Text = ResAutoID.ToString();


                        //Referenceto Load Method
                        //label58.Text = CaseGenerateAutoID().ToString();
                        //label59.Text = CompGenerateAutoID().ToString();
                        //label60.Text = ResGenerateAutoID().ToString();

                    }

                }
            }



            catch (Exception ex)
            {
                MessageBox.Show("Error: hhhhhhhh" + ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FileCase();
        }

        private void compContactNotxtb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(compContactNotxtb.Text))
                return;


            long number;
            if (!long.TryParse(compContactNotxtb.Text, out number))
            {
                compContactNotxtb.Text = compContactNotxtb.Text.Remove(compContactNotxtb.Text.Length - 1);
                compContactNotxtb.SelectionStart = compContactNotxtb.Text.Length;
            }


            if (compContactNotxtb.Text.Length > 11)
            {
                compContactNotxtb.Text = compContactNotxtb.Text.Substring(0, 11);
                compContactNotxtb.SelectionStart = compContactNotxtb.Text.Length;
            }
        }

        private void respoContactNotxtb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(respoContactNotxtb.Text))
                return;


            long number;
            if (!long.TryParse(respoContactNotxtb.Text, out number))
            {
                respoContactNotxtb.Text = respoContactNotxtb.Text.Remove(respoContactNotxtb.Text.Length - 1);
                respoContactNotxtb.SelectionStart = respoContactNotxtb.Text.Length;
            }


            if (respoContactNotxtb.Text.Length > 11)
            {
                respoContactNotxtb.Text = respoContactNotxtb.Text.Substring(0, 11);
                respoContactNotxtb.SelectionStart = respoContactNotxtb.Text.Length;
            }
        }

        private void compAgetxtb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(compAgetxtb.Text))
                return;


            long number;
            if (!long.TryParse(compAgetxtb.Text, out number))
            {
                compAgetxtb.Text = compAgetxtb.Text.Remove(compAgetxtb.Text.Length - 1);
                compAgetxtb.SelectionStart = compAgetxtb.Text.Length;
            }


            if (compAgetxtb.Text.Length > 2)
            {
                compAgetxtb.Text = compAgetxtb.Text.Substring(0, 2);
                compAgetxtb.SelectionStart = compAgetxtb.Text.Length;
            }
        }

        private void respoAgetxtb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(respoAgetxtb.Text))
                return;


            long number;
            if (!long.TryParse(respoAgetxtb.Text, out number))
            {
                respoAgetxtb.Text = respoAgetxtb.Text.Remove(respoAgetxtb.Text.Length - 1);
                respoAgetxtb.SelectionStart = respoAgetxtb.Text.Length;
            }


            if (respoAgetxtb.Text.Length > 2)
            {
                respoAgetxtb.Text = respoAgetxtb.Text.Substring(0, 2);
                respoAgetxtb.SelectionStart = respoAgetxtb.Text.Length;
            }
        }

        private void PopulatecmbxVS(string selectedCategory)
        {

            cmbxVS.Items.Clear();

            switch (selectedCategory)
            {
                case "R.A. 9262: Anti Violence Against Women and their Children Act":
                    cmbxVS.Items.Add("Sexual Abuse");
                    cmbxVS.Items.Add("Psychological");
                    cmbxVS.Items.Add("Physical");
                    cmbxVS.Items.Add("Economic");
                    cmbxVS.Items.Add("Others");
                    break;
                case "R.A. 8353: Anti-Rape Law of 1995":
                    cmbxVS.Items.Add("Rape by Sexual Intercourse");
                    cmbxVS.Items.Add("Rape by Sexual Assault");
                    break;
                case "R.A. 7877: Anti-Sexual Harassment Act":
                    cmbxVS.Items.Add("Verbal");
                    cmbxVS.Items.Add("Physical");
                    cmbxVS.Items.Add("Use of Object: Pictures, Letters or Notes with Sexual under-pinnings");
                    break;
                case "R.A. 7610: Special Protection of Children Against Child Abuse, Exploitation and Discrimination Act":
                    cmbxVS.Items.Add("Engage, Facilitate, Promote or Attempt to commit Child Prostitution");
                    cmbxVS.Items.Add("Sexual Intercourse or Lascivious Conduct");
                    break;
                case "R.A. 9208: Anti-Trafficking in Person Act of 2003":

                    break;
                case "R.A. 9775: Anti-Child Pornography Act":

                    break;
                case "R.A. 9995: Anti-Photo and Video Voyeurism Act of 2009":

                    break;
                case "Revised Penal Code":
                    cmbxVS.Items.Add("Art 336: Acts of Lasciviousness");
                    cmbxVS.Items.Add("Others");
                    break;
                default:
                    break;
            }
        }

        private void cmbxRA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxRA.SelectedItem != null)
            {
                string selectedCategory = cmbxRA.SelectedItem.ToString();

                cmbxVS.SelectedIndexChanged -= cmbxVS_SelectedIndexChanged;

                PopulatecmbxVS(selectedCategory);

                cmbxVS.SelectedIndexChanged += cmbxVS_SelectedIndexChanged;
            }
        }

        private void cmbxVS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}

    
