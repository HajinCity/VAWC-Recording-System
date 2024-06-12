using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VAWC_Recording_System.NewForms
{
    public partial class ManageCaseList : Form
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlCommand RSDBCommand1 = new MySqlCommand();
        MySqlCommand RSDBCommand2 = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();

        Form2 f;
        public ManageCaseList()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
            upcmbx_caseViolation.SelectedIndexChanged += upcmbx_caseSubcase_SelectedIndexChanged;
            
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

        private void loadtoUpdatetheCases()
        {
            string typedCaseNo = textBox1.Text;
            string caseNoFromDB = caseno; 

            if (typedCaseNo == caseNoFromDB)
            {
                textBox1.Text = typedCaseNo;
                try
                {
                    string query = "SELECT * FROM caselist WHERE caseNo = @caseNo";
                    string query1 = "SELECT * FROM complainant WHERE caseNo = @caseNo";
                    string query2 = "SELECT * FROM respondent WHERE caseNo = @caseNo";

                    RSDBConnect.Open();

                    RSDBCommand = new MySqlCommand(query, RSDBConnect);
                    RSDBCommand.Parameters.AddWithValue("@caseNo", typedCaseNo);
                    MySqlDataReader RSBDReader = RSDBCommand.ExecuteReader();

                    if (RSBDReader.Read())
                    {
                        DateTime incidentDate = RSBDReader.GetDateTime("case_incidentDate");
                        upcmbx_caseDate.Value = incidentDate;

                        uptxtbx_comLN.Text = RSBDReader["case_cLastName"].ToString();
                        uptxtbx_comFN.Text = RSBDReader["case_cFirstName"].ToString();
                        uptxtbx_resLN.Text = RSBDReader["case_rLastName"].ToString();
                        uptxtbx_resFN.Text = RSBDReader["case_rFirstName"].ToString();
                        uptxtbx_resAlias.Text = RSBDReader["case_rAlias"].ToString();

                        upcmbx_caseViolation.SelectedItem = RSBDReader["case_Violation"].ToString();
                        upcmbx_caseSubcase.SelectedItem = RSBDReader["case_SubViolation"].ToString();
                        uptxtb_caseDescription.Text = RSBDReader["case_Description"].ToString();
                        upcmbx_caseStatus.SelectedItem = RSBDReader["case_Status"].ToString();
                        upcmbx_caseReferral.SelectedItem = RSBDReader["case_ReferredTo"].ToString();
                      //  upcmbx_caseDate.MinDate = RSBDReader.GetDateTime("case_incidentDate");
                        upcmbx_casePlcIncident.SelectedItem = RSBDReader["case_plcofincident"].ToString();
                        uptxtb_casePurok.Text = RSBDReader["case_purok"].ToString();
                        uptxtb_caseBarangay.Text = RSBDReader["case_barangay"].ToString();
                        uptxtb_caseCity.Text = RSBDReader["case_municipality"].ToString();
                        uptxtb_caseProvince.Text = RSBDReader["case_province"].ToString();
                        uptxtb_caseRegion.Text = RSBDReader["case_region"].ToString();
                    }
                    RSBDReader.Close();

                    RSDBCommand1 = new MySqlCommand(query1, RSDBConnect);
                    RSDBCommand1.Parameters.AddWithValue("@caseNo", typedCaseNo);
                    MySqlDataReader RSBDReader1 = RSDBCommand1.ExecuteReader();

                    if (RSBDReader1.Read())
                    {
                        c_IDlbl.Text = RSBDReader1["comp_ID"].ToString();
                        uptxtbx_comLN.Text = RSBDReader1["comp_LastName"].ToString();
                        uptxtbx_comFN.Text = RSBDReader1["comp_FirstName"].ToString();
                        uptxtbx_comMN.Text = RSBDReader1["comp_MiddleName"].ToString();
                        upcmbx_comSx.SelectedItem = RSBDReader1["comp_Sex"].ToString();
                        uptxtbx_comAge.Text = RSBDReader1["comp_Age"].ToString();

                        upcmbx_compCStatus.SelectedItem = RSBDReader1["comp_CivilStatus"].ToString();
                        upcmbx_compEdAtt.SelectedItem = RSBDReader1["comp_EducationalAttainmaent"].ToString();

                        uptxtbx_comRelgion.Text = RSBDReader1["comp_Religion"].ToString();
                        uptxtbx_comContact.Text = RSBDReader1["comp_ContactNo"].ToString();
                        uptxtbx_comPurok.Text = RSBDReader1["comp_Purok"].ToString();
                        uptxtbx_comBarangay.Text = RSBDReader1["comp_Barangay"].ToString();
                        uptxtbx_comCity.Text = RSBDReader1["comp_City"].ToString();
                        uptxtbx_comProvince.Text = RSBDReader1["comp_Province"].ToString();
                        uptxtbx_comRegion.Text = RSBDReader1["comp_Region"].ToString();

                        uptxtbx_compNation.Text = RSBDReader1["comp_Nationality"].ToString();
                        uptxtbx_compOccupation.Text = RSBDReader1["comp_Occupation"].ToString();
                        uptxtbx_compPassportId.Text = RSBDReader1["comp_PassportId"].ToString();

                    }
                    RSBDReader1.Close();

                    RSDBCommand2 = new MySqlCommand(query2, RSDBConnect);
                    RSDBCommand2.Parameters.AddWithValue("@caseNo", typedCaseNo);
                    MySqlDataReader RSBDReader2 = RSDBCommand2.ExecuteReader();

                    if (RSBDReader2.Read())
                    {
                        r_IDlbl.Text = RSBDReader2["respo_ID"].ToString();
                        uptxtbx_resLN.Text = RSBDReader2["respo_LastName"].ToString();
                        uptxtbx_resFN.Text = RSBDReader2["respo_FirstName"].ToString();
                        uptxtbx_resMN.Text = RSBDReader2["respo_MiddleName"].ToString();
                        uptxtbx_resAlias.Text = RSBDReader2["respo_Alias"].ToString();
                        upcmbx_resSx.SelectedItem = RSBDReader2["respo_Sex"].ToString();
                        uptxtbx_resAge.Text = RSBDReader2["respo_Age"].ToString();

                        upcmbx_resCstatus.SelectedItem = RSBDReader2["respo_CivilStatus"].ToString();
                        upcmbx_resEdAtt.SelectedItem = RSBDReader2["respo_EducationalAttainment"].ToString();

                        uptxtbx_resRelgion.Text = RSBDReader2["respo_Religion"].ToString();
                        uptxtbx_resContact.Text = RSBDReader2["respo_ContactNo"].ToString();
                        uptxtbx_resPurok.Text = RSBDReader2["respo_Purok"].ToString();
                        uptxtbx_resBarangay.Text = RSBDReader2["respo_Barangay"].ToString();
                        uptxtbx_resCity.Text = RSBDReader2["respo_City"].ToString();
                        uptxtbx_resProvince.Text = RSBDReader2["respo_Province"].ToString();
                        uptxtbx_resRegion.Text = RSBDReader2["respo_Region"].ToString();
                        upcmbx_resRelationship.SelectedItem = RSBDReader2["respo_RelationshipToVictim"].ToString();

                        uptxtbx_resNationality.Text = RSBDReader2["respo_Nationality"].ToString();
                        uptxtbx_resOccupation.Text = RSBDReader2["respo_Occupation"].ToString();
                        uptxtbx_resPassportId.Text = RSBDReader2["respo_PassportID"].ToString();

                    }

                        RSDBConnect.Close();

                    MessageBox.Show("The Case Filed Successfully Retrieve");
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    RSDBConnect.Close(); 
                }
            }
            else
            {
                MessageBox.Show("The case number does not exist in the database.");
               
                textBox1.Focus();
            }
        }
        private void ManageCaseList_Load(object sender, EventArgs e)
        {
            uptxtbx_comAge.TextChanged += uptxtbx_comAge_TextChanged;
            uptxtbx_comContact.TextChanged += uptxtbx_comContact_TextChanged;
            uptxtbx_resAge.TextChanged += uptxtbx_resAge_TextChanged;
            uptxtbx_resContact.TextChanged += uptxtbx_resContact_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadtoUpdatetheCases();
        }

        private void uptxtbx_comAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uptxtbx_comAge.Text))
                return;

            long number;
            if (!long.TryParse(uptxtbx_comAge.Text, out number))
            {
                uptxtbx_comAge.Text = uptxtbx_comAge.Text.Remove(uptxtbx_comAge.Text.Length - 1);
                uptxtbx_comAge.SelectionStart = uptxtbx_comAge.Text.Length;
            }

            if (uptxtbx_comAge.Text.Length > 2)
            {
                uptxtbx_comAge.Text = uptxtbx_comAge.Text.Substring(0, 2);
                uptxtbx_comAge.SelectionStart = uptxtbx_comAge.Text.Length;
            }
        }

        private void uptxtbx_comContact_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uptxtbx_comContact.Text))
                return;

            long number;
            if (!long.TryParse(uptxtbx_comContact.Text, out number))
            {
                uptxtbx_comContact.Text = uptxtbx_comContact.Text.Remove(uptxtbx_comContact.Text.Length - 1);
                uptxtbx_comContact.SelectionStart = uptxtbx_comContact.Text.Length;
            }

            if (uptxtbx_comContact.Text.Length > 11)
            {
                uptxtbx_comContact.Text = uptxtbx_comContact.Text.Substring(0, 11);
                uptxtbx_comContact.SelectionStart = uptxtbx_comContact.Text.Length;
            }
        }

        private void uptxtbx_resAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uptxtbx_resAge.Text))
                return;

            long number;
            if (!long.TryParse(uptxtbx_resAge.Text, out number))
            {
                uptxtbx_resAge.Text = uptxtbx_resAge.Text.Remove(uptxtbx_resAge.Text.Length - 1);
                uptxtbx_resAge.SelectionStart = uptxtbx_resAge.Text.Length;
            }

            if (uptxtbx_resAge.Text.Length > 2)
            {
                uptxtbx_resAge.Text = uptxtbx_resAge.Text.Substring(0, 2);
                uptxtbx_resAge.SelectionStart = uptxtbx_resAge.Text.Length;
            }
        }

        private void uptxtbx_resContact_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uptxtbx_resContact.Text))
                return;

            long number;
            if (!long.TryParse(uptxtbx_resContact.Text, out number))
            {
                uptxtbx_resContact.Text = uptxtbx_resContact.Text.Remove(uptxtbx_resContact.Text.Length - 1);
                uptxtbx_resContact.SelectionStart = uptxtbx_resContact.Text.Length;
            }

            if (uptxtbx_resContact.Text.Length > 11)
            {
                uptxtbx_resContact.Text = uptxtbx_resContact.Text.Substring(0, 11);
                uptxtbx_resContact.SelectionStart = uptxtbx_resContact.Text.Length;
            }
        }

        private void upcmbx_caseSubcase_SelectedIndexChanged(object sender, EventArgs e)
        {

         

        }

        private void PopulatecmbxVS(string selectedCategory)
        {

            upcmbx_caseSubcase.Items.Clear();

            switch (selectedCategory)
            {
                case "R.A. 9262: Anti Violence Against Women and their Children Act":
                    upcmbx_caseSubcase.Items.Add("Sexual Abuse");
                    upcmbx_caseSubcase.Items.Add("Psychological");
                    upcmbx_caseSubcase.Items.Add("Physical");
                    upcmbx_caseSubcase.Items.Add("Economic");
                    upcmbx_caseSubcase.Items.Add("Others");
                    break;
                case "R.A. 8353: Anti-Rape Law of 1995":
                    upcmbx_caseSubcase.Items.Add("Rape by Sexual Intercourse");
                    upcmbx_caseSubcase.Items.Add("Rape by Sexual Assault");
                    break;
                case "R.A. 7877: Anti-Sexual Harassment Act":
                    upcmbx_caseSubcase.Items.Add("Verbal");
                    upcmbx_caseSubcase.Items.Add("Physical");
                    upcmbx_caseSubcase.Items.Add("Use of Object: Pictures, Letters or Notes with Sexual under-pinnings");
                    break;
                case "R.A. 7610: Special Protection of Children Against Child Abuse, Exploitation and Discrimination Act":
                    upcmbx_caseSubcase.Items.Add("Engage, Facilitate, Promote or Attempt to commit Child Prostitution");
                    upcmbx_caseSubcase.Items.Add("Sexual Intercourse or Lascivious Conduct");
                    break;
                case "R.A. 9208: Anti-Trafficking in Person Act of 2003":

                    break;
                case "R.A. 9775: Anti-Child Pornography Act":

                    break;
                case "R.A. 9995: Anti-Photo and Video Voyeurism Act of 2009":

                    break;
                case "Revised Penal Code":
                    upcmbx_caseSubcase.Items.Add("Art 336: Acts of Lasciviousness");
                    upcmbx_caseSubcase.Items.Add("Others");
                    break;
                default:
                    break;
            }
        }

        private void updateCaseFile()
        {
            string caseNo = textBox1.Text;
            string complainantID = c_IDlbl.Text;
            string respondentID = r_IDlbl.Text;

            try
            {
                if (MessageBox.Show("Are you sure you want to update this Case File?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RSDBConnect.Open();

                   
                    string updateCaseQuery = "UPDATE caselist SET ";
                    updateCaseQuery += "case_cLastName = @cLastName, ";
                    updateCaseQuery += "case_cFirstName = @cFirstName, ";
                    updateCaseQuery += "case_rLastName = @rLastName, ";
                    updateCaseQuery += "case_rFirstName = @rFirstName, ";
                    updateCaseQuery += "case_rAlias = @rAlias, ";
                    updateCaseQuery += "case_Violation = @Violation, ";
                    updateCaseQuery += "case_SubViolation = @SubViolation, ";
                    updateCaseQuery += "case_Description = @Description, ";
                    updateCaseQuery += "case_Status = @Status, ";
                    updateCaseQuery += "case_ReferredTo = @ReferredTo, ";
                    updateCaseQuery += "case_plcofincident = @PlaceOfIncident, ";
                    updateCaseQuery += "case_purok = @Purok, ";
                    updateCaseQuery += "case_barangay = @Barangay, ";
                    updateCaseQuery += "case_municipality = @City, ";
                    updateCaseQuery += "case_province = @Province, ";
                    updateCaseQuery += "case_region = @Region ";
                    updateCaseQuery += "WHERE caseNo = @CaseNo";

                    MySqlCommand updateCaseCommand = new MySqlCommand(updateCaseQuery, RSDBConnect);

                    updateCaseCommand.Parameters.AddWithValue("@cLastName", !string.IsNullOrWhiteSpace(uptxtbx_comLN.Text) ? uptxtbx_comLN.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@cFirstName", !string.IsNullOrWhiteSpace(uptxtbx_comFN.Text) ? uptxtbx_comFN.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@rLastName", !string.IsNullOrWhiteSpace(uptxtbx_resLN.Text) ? uptxtbx_resLN.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@rFirstName", !string.IsNullOrWhiteSpace(uptxtbx_resFN.Text) ? uptxtbx_resFN.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@rAlias", !string.IsNullOrWhiteSpace(uptxtbx_resAlias.Text) ? uptxtbx_resAlias.Text : (object)DBNull.Value);

                    updateCaseCommand.Parameters.AddWithValue("@Violation", upcmbx_caseViolation.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@SubViolation", upcmbx_caseSubcase.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@Description", !string.IsNullOrWhiteSpace(uptxtb_caseDescription.Text) ? uptxtb_caseDescription.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@Status", upcmbx_caseStatus.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@ReferredTo", upcmbx_caseReferral.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@PlaceOfIncident", upcmbx_casePlcIncident.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@Purok", !string.IsNullOrWhiteSpace(uptxtb_casePurok.Text) ? uptxtb_casePurok.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@Barangay", !string.IsNullOrWhiteSpace(uptxtb_caseBarangay.Text) ? uptxtb_caseBarangay.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@City", !string.IsNullOrWhiteSpace(uptxtb_caseCity.Text) ? uptxtb_caseCity.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@Province", !string.IsNullOrWhiteSpace(uptxtb_caseProvince.Text) ? uptxtb_caseProvince.Text : (object)DBNull.Value);
                    updateCaseCommand.Parameters.AddWithValue("@Region", !string.IsNullOrWhiteSpace(uptxtb_caseRegion.Text) ? uptxtb_caseRegion.Text : (object)DBNull.Value);
                   
                    updateCaseCommand.Parameters.AddWithValue("@CaseNo", caseNo);

                    
                    int caseRowsAffected = updateCaseCommand.ExecuteNonQuery();

                    string updateComplainantQuery = "UPDATE complainant SET ";
                    updateComplainantQuery += "comp_LastName = @LastName, ";
                    updateComplainantQuery += "comp_FirstName = @FirstName, ";
                    updateComplainantQuery += "comp_MiddleName = @MiddleName, ";
                    updateComplainantQuery += "comp_Sex = @Sex, ";
                    updateComplainantQuery += "comp_Age = @Age, ";

                    updateComplainantQuery += "comp_CivilStatus = @CivilStatus, ";
                    updateComplainantQuery += "comp_EducationalAttainmaent = @EducationalAttainmaent, ";

                    updateComplainantQuery += "comp_Religion = @Religion, ";
                    updateComplainantQuery += "comp_ContactNo = @ContactNo, ";
                    updateComplainantQuery += "comp_Purok = @Purok, ";
                    updateComplainantQuery += "comp_Barangay = @Barangay, ";
                    updateComplainantQuery += "comp_City = @City, ";
                    updateComplainantQuery += "comp_Province = @Province, ";
                    updateComplainantQuery += "comp_Region = @Region, ";

                    updateComplainantQuery += "comp_Nationality = @Nationality, ";
                    updateComplainantQuery += "comp_Occupation = @Occupationion, ";
                    updateComplainantQuery += "comp_PassportId = @PassportId ";

                    updateComplainantQuery += "WHERE comp_ID = @ComplainantID";

                    MySqlCommand updateComplainantCommand = new MySqlCommand(updateComplainantQuery, RSDBConnect);


                    updateComplainantCommand.Parameters.AddWithValue("@LastName", !string.IsNullOrWhiteSpace(uptxtbx_comLN.Text) ? uptxtbx_comLN.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@FirstName", !string.IsNullOrWhiteSpace(uptxtbx_comFN.Text) ? uptxtbx_comFN.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@MiddleName", !string.IsNullOrWhiteSpace(uptxtbx_comMN.Text) ? uptxtbx_comMN.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@Sex", upcmbx_comSx.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@Age", !string.IsNullOrWhiteSpace(uptxtbx_comAge.Text) ? uptxtbx_comAge.Text : (object)DBNull.Value);

                    updateComplainantCommand.Parameters.AddWithValue("@CivilStatus", upcmbx_compCStatus.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@EducationalAttainmaent", upcmbx_compEdAtt.SelectedItem?.ToString() ?? (object)DBNull.Value);

                    updateComplainantCommand.Parameters.AddWithValue("@Religion", !string.IsNullOrWhiteSpace(uptxtbx_comRelgion.Text) ? uptxtbx_comRelgion.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@ContactNo", !string.IsNullOrWhiteSpace(uptxtbx_comContact.Text) ? uptxtbx_comContact.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@Purok", !string.IsNullOrWhiteSpace(uptxtbx_comPurok.Text) ? uptxtbx_comPurok.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@Barangay", !string.IsNullOrWhiteSpace(uptxtbx_comBarangay.Text) ? uptxtbx_comBarangay.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@City", !string.IsNullOrWhiteSpace(uptxtbx_comCity.Text) ? uptxtbx_comCity.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@Province", !string.IsNullOrWhiteSpace(uptxtbx_comProvince.Text) ? uptxtbx_comProvince.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@Region", !string.IsNullOrWhiteSpace(uptxtbx_comRegion.Text) ? uptxtbx_comRegion.Text : (object)DBNull.Value);

                    updateComplainantCommand.Parameters.AddWithValue("@Nationality", !string.IsNullOrWhiteSpace(uptxtbx_compNation.Text) ? uptxtbx_compNation.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@Occupationion", !string.IsNullOrWhiteSpace(uptxtbx_compOccupation.Text) ? uptxtbx_compOccupation.Text : (object)DBNull.Value);
                    updateComplainantCommand.Parameters.AddWithValue("@PassportId", !string.IsNullOrWhiteSpace(uptxtbx_compPassportId.Text) ? uptxtbx_compPassportId.Text : (object)DBNull.Value);

                    updateComplainantCommand.Parameters.AddWithValue("@ComplainantID", complainantID);

                   
                    int complainantRowsAffected = updateComplainantCommand.ExecuteNonQuery();

                    string updateRespondentQuery = "UPDATE respondent SET ";
                    updateRespondentQuery += "respo_LastName = @LastName, ";
                    updateRespondentQuery += "respo_FirstName = @FirstName, ";
                    updateRespondentQuery += "respo_MiddleName = @MiddleName, ";
                    updateRespondentQuery += "respo_Alias = @Alias, ";
                    updateRespondentQuery += "respo_Sex = @Sex, ";
                    updateRespondentQuery += "respo_Age = @Age, ";

                    updateRespondentQuery += "respo_CivilStatus = @CivilStatus, ";
                    updateRespondentQuery += "respo_EducationalAttainment = @EducationalAttainment, ";

                    updateRespondentQuery += "respo_Religion = @Religion, ";
                    updateRespondentQuery += "respo_ContactNo = @ContactNo, ";
                    updateRespondentQuery += "respo_Purok = @Purok, ";
                    updateRespondentQuery += "respo_Barangay = @Barangay, ";
                    updateRespondentQuery += "respo_City = @City, ";
                    updateRespondentQuery += "respo_Province = @Province, ";
                    updateRespondentQuery += "respo_Region = @Region, ";
                    updateRespondentQuery += "respo_RelationshipToVictim = @RelationshipToVictim, ";

                    updateRespondentQuery += "respo_Nationality = @Nationality, ";
                    updateRespondentQuery += "respo_Occupation = @Occupation, ";
                    updateRespondentQuery += "respo_PassportID = @PassportID ";

                    updateRespondentQuery += "WHERE respo_ID = @RespondentID";

                    MySqlCommand updateRespondentCommand = new MySqlCommand(updateRespondentQuery, RSDBConnect);


                    updateRespondentCommand.Parameters.AddWithValue("@LastName", !string.IsNullOrWhiteSpace(uptxtbx_resLN.Text) ? uptxtbx_resLN.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@FirstName", !string.IsNullOrWhiteSpace(uptxtbx_resFN.Text) ? uptxtbx_resFN.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@MiddleName", !string.IsNullOrWhiteSpace(uptxtbx_resMN.Text) ? uptxtbx_resMN.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Alias", !string.IsNullOrWhiteSpace(uptxtbx_resAlias.Text) ? uptxtbx_resAlias.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Sex", upcmbx_resSx.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Age", !string.IsNullOrWhiteSpace(uptxtbx_resAge.Text) ? uptxtbx_resAge.Text : (object)DBNull.Value);

                    updateRespondentCommand.Parameters.AddWithValue("@CivilStatus", upcmbx_resCstatus.SelectedItem?.ToString() ?? (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@EducationalAttainment", upcmbx_resEdAtt.SelectedItem?.ToString() ?? (object)DBNull.Value);

                    updateRespondentCommand.Parameters.AddWithValue("@Religion", !string.IsNullOrWhiteSpace(uptxtbx_resRelgion.Text) ? uptxtbx_resRelgion.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@ContactNo", !string.IsNullOrWhiteSpace(uptxtbx_resContact.Text) ? uptxtbx_resContact.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Purok", !string.IsNullOrWhiteSpace(uptxtbx_resPurok.Text) ? uptxtbx_resPurok.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Barangay", !string.IsNullOrWhiteSpace(uptxtbx_resBarangay.Text) ? uptxtbx_resBarangay.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@City", !string.IsNullOrWhiteSpace(uptxtbx_resCity.Text) ? uptxtbx_resCity.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Province", !string.IsNullOrWhiteSpace(uptxtbx_resProvince.Text) ? uptxtbx_resProvince.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Region", !string.IsNullOrWhiteSpace(uptxtbx_resRegion.Text) ? uptxtbx_resRegion.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@RelationshipToVictim", upcmbx_resRelationship.SelectedItem?.ToString() ?? (object)DBNull.Value);

                    updateRespondentCommand.Parameters.AddWithValue("@Nationality", !string.IsNullOrWhiteSpace(uptxtbx_resNationality.Text) ? uptxtbx_resNationality.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@Occupation", !string.IsNullOrWhiteSpace(uptxtbx_resOccupation.Text) ? uptxtbx_resOccupation.Text : (object)DBNull.Value);
                    updateRespondentCommand.Parameters.AddWithValue("@PassportID", !string.IsNullOrWhiteSpace(uptxtbx_resPassportId.Text) ? uptxtbx_resPassportId.Text : (object)DBNull.Value);

                    updateRespondentCommand.Parameters.AddWithValue("@RespondentID", respondentID);

                    int respondentRowsAffected = updateRespondentCommand.ExecuteNonQuery();

                    RSDBConnect.Close();

                    if (caseRowsAffected > 0 && complainantRowsAffected > 0 && respondentRowsAffected > 0)
                    {
                        MessageBox.Show("Case File Updated Successfully.");
                        cleartextboxes();
                    }
                    else
                    {
                        MessageBox.Show("No records were updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                RSDBConnect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateCaseFile();
        }


        public void cleartextboxes()
        {
            //Clear Text Boxes
            c_IDlbl.Text = string.Empty;
            uptxtbx_comLN.Clear();
            uptxtbx_comFN.Clear();
            uptxtbx_comMN.Clear();
            upcmbx_comSx.SelectedItem = null;
            uptxtbx_comAge.Clear();

            upcmbx_compCStatus.SelectedItem = null;
            upcmbx_compEdAtt.SelectedItem = null;


            uptxtbx_comRelgion.Clear();
            uptxtbx_comContact.Clear();
            uptxtbx_comPurok.Clear();
            uptxtbx_comBarangay.Clear();
            uptxtbx_comCity.Clear();
            uptxtbx_comProvince.Clear();
            uptxtbx_comRegion.Clear();

            uptxtbx_compNation.Clear();
            uptxtbx_compOccupation.Clear();
            uptxtbx_compPassportId.Clear();

            r_IDlbl.Text= string.Empty;
            uptxtbx_resLN.Clear();
            uptxtbx_resFN.Clear();
            uptxtbx_resMN.Clear();
            uptxtbx_resAlias.Clear();
            upcmbx_resSx.SelectedItem = null;
            uptxtbx_resAge.Clear();

            upcmbx_resCstatus.SelectedItem = null;
            upcmbx_resEdAtt.SelectedItem = null;

            uptxtbx_resRelgion.Clear();
            uptxtbx_resContact.Clear();
            uptxtbx_resPurok.Clear();
            uptxtbx_resBarangay.Clear();
            uptxtbx_resCity.Clear();
            uptxtbx_resProvince.Clear();
            uptxtbx_resRegion.Clear();
            upcmbx_resRelationship.SelectedItem = null;

            uptxtbx_resNationality.Clear();
            uptxtbx_resOccupation.Clear();
            uptxtbx_resPassportId.Clear();

            textBox1.Clear();
            upcmbx_caseViolation.SelectedItem = null;
            upcmbx_caseSubcase.SelectedItem = null;
            upcmbx_caseStatus.SelectedItem = null;
            upcmbx_caseReferral.SelectedItem = null;
            uptxtb_caseDescription.Clear();
            upcmbx_casePlcIncident.SelectedItem = null;
            uptxtb_casePurok.Clear();
            uptxtb_caseBarangay.Clear();
            uptxtb_caseCity.Clear();
            uptxtb_caseProvince.Clear();
            uptxtb_caseRegion.Clear();
        }

        private void upcmbx_caseViolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (upcmbx_caseViolation.SelectedItem != null)
            {
                string selectedCategory = upcmbx_caseViolation.SelectedItem.ToString();

                upcmbx_caseViolation.SelectedIndexChanged -= upcmbx_caseViolation_SelectedIndexChanged;

                PopulatecmbxVS(selectedCategory);

                upcmbx_caseViolation.SelectedIndexChanged += upcmbx_caseViolation_SelectedIndexChanged;
            }
        }
    }
}
