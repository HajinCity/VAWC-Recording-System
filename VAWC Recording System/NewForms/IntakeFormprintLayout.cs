using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;

namespace VAWC_Recording_System.NewForms
{
    public partial class IntakeFormprintLayout : UserControl
    {
        MySqlConnection RSDBConnect = new MySqlConnection();
        MySqlCommand RSDBCommand = new MySqlCommand();
        MySqlCommand RSDBCommand1 = new MySqlCommand();
        MySqlCommand RSDBCommand2 = new MySqlCommand();
        MySqlDataReader RSBDReader;
        RSBDConnection dbcon = new RSBDConnection();
        public IntakeFormprintLayout()
        {
            InitializeComponent();
            RSDBConnect = new MySqlConnection(dbcon.MyConnect());
        }

        private void PrintPanelContents(Panel panel1, Panel panel60)
        {
            PrintDocument pd = new PrintDocument();
            int pageNumber = 0;

            pd.PrintPage += (sender, e) =>
            {
                if (pageNumber == 0)
                {
                    Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
                    panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
                    e.Graphics.DrawImage(bmp, Point.Empty);
                }
                else if (pageNumber == 1)
                {
                    Bitmap bmp = new Bitmap(panel60.Width, panel60.Height);
                    panel60.DrawToBitmap(bmp, new Rectangle(0, 0, panel60.Width, panel60.Height));
                    e.Graphics.DrawImage(bmp, Point.Empty);
                }

                pageNumber++;
                e.HasMorePages = pageNumber < 2; // Set to the number of pages you have
            };

            pd.BeginPrint += (sender, e) =>
            {
                pageNumber = 0; // Reset the page number when printing starts
            };

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pd;
            printPreviewDialog.ShowDialog();
        }

        private void PrintNow_Click(object sender, EventArgs e)
        {
            PrintPanelContents(panel1, panel60);
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

        private void loadthesecase()
        {
            string typedCaseNo = textBox1.Text;
            string caseNoFromDB = caseno;

            try
            {
                // Ensure RSDBConnect is properly initialized and opened
                RSDBConnect.Open();

                // Check if the connection is open
                if (RSDBConnect.State == ConnectionState.Open)
                {
                    if (typedCaseNo == caseNoFromDB)
                    {
                        textBox1.Text = typedCaseNo;
                        try
                        {
                            string query1 = "SELECT * FROM complainant WHERE caseNo = @caseNo";

                            RSDBCommand1 = new MySqlCommand(query1, RSDBConnect);
                            RSDBCommand1.Parameters.AddWithValue("@caseNo", typedCaseNo);
                            MySqlDataReader RSBDReader1 = RSDBCommand1.ExecuteReader();

                            if (RSBDReader1.Read())
                            {
                                //Complainanat 
                                comp_lastname.Text = RSBDReader1["comp_LastName"].ToString();
                                comp_firstname.Text = RSBDReader1["comp_FirstName"].ToString();
                                comp_middlename.Text = RSBDReader1["comp_MiddleName"].ToString();
                                comp_age.Text = RSBDReader1["comp_Age"].ToString();
                                comp_contactNo.Text = RSBDReader1["comp_ContactNo"].ToString();
                                comp_purok.Text = RSBDReader1["comp_Purok"].ToString();
                                comp_Barangay.Text = RSBDReader1["comp_Barangay"].ToString();
                                comp_Muni.Text = RSBDReader1["comp_City"].ToString();
                                comp_Province.Text = RSBDReader1["comp_Province"].ToString();
                                comp_Region.Text = RSBDReader1["comp_Region"].ToString();

                                lblcomp_Nationality.Text = RSBDReader1["comp_Nationality"].ToString();
                                lblcomp_Occupation.Text = RSBDReader1["comp_Occupation"].ToString();
                                lblcomp_PassportID.Text = RSBDReader1["comp_PassportId"].ToString();

                                string gender = RSBDReader1["comp_Sex"].ToString();
                                if (gender.ToLower() == "male")
                                {
                                    chkComp_Male.Checked = true;
                                    chkComp_Female.Checked = false;
                                }
                                else if (gender.ToLower() == "female")
                                {
                                    chkComp_Male.Checked = false;
                                    chkComp_Female.Checked = true;
                                }

                                string civilStatus = RSBDReader1["comp_CivilStatus"].ToString();

                                if (civilStatus.Equals("Single", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_StSingle.Checked = true;
                                }
                                else if (civilStatus.Equals("Married", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_StMarried.Checked = true;
                                }
                                else if (civilStatus.Equals("Live-in", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_StLivein.Checked = true;
                                }
                                else if (civilStatus.Equals("Widowed", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_StWidowed.Checked = true;
                                }
                                else if (civilStatus.Equals("Separated", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_StSeparated.Checked = true;
                                }

                                string religion = RSBDReader1["comp_Religion"].ToString();

                                if (religion.Equals("Roman Catholic", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_Religion1.Checked = true;
                                }
                                else if (religion.Equals("Islam", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_Religion2.Checked = true;
                                }
                                else if (religion.Equals("Protestant", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_Religion3.Checked = true;
                                }
                                else if (religion.Equals("Iglisia ni Kristo", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_Religion4.Checked = true;
                                }
                                else if (religion.Equals("Aglipayan", StringComparison.OrdinalIgnoreCase))
                                {
                                    comp_Religion5.Checked = true;
                                }
                                else
                                {
                                    comp_Religion6.Checked = true;
                                    textBox21.Text = religion;
                                }

                                string educationalAttainment = RSBDReader1["comp_EducationalAttainmaent"].ToString();

                                if (educationalAttainment.Equals("No. Formal Education", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd1.Checked = true;
                                }
                                else if (educationalAttainment.Equals("No Response", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd2.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Vocational", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd3.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Elementary Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd4.Checked = true;
                                }
                                else if (educationalAttainment.Equals("High School Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd5.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Senior High Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd6.Checked = true;
                                }
                                else if (educationalAttainment.Equals("College Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd7.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Post Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd8.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Others", StringComparison.OrdinalIgnoreCase))
                                {
                                    compEd9.Checked = true;
                                }
                            }
                            RSBDReader1.Close();

                            string query2 = "SELECT * FROM respondent WHERE caseNo = @caseNo";

                            RSDBCommand2 = new MySqlCommand(query2, RSDBConnect);
                            RSDBCommand2.Parameters.AddWithValue("@caseNo", typedCaseNo);
                            MySqlDataReader RSBDReader2 = RSDBCommand2.ExecuteReader();

                            if (RSBDReader2.Read())
                            {
                                //Respondent
                                lbl_respoLN.Text = RSBDReader2["respo_LastName"].ToString();
                                lbl_respoFN.Text = RSBDReader2["respo_FirstName"].ToString();
                                lbl_respoMN.Text = RSBDReader2["respo_MiddleName"].ToString();
                                lbl_respoAlias.Text = RSBDReader2["respo_Alias"].ToString();
                                lbl_respoAge.Text = RSBDReader2["respo_Age"].ToString();
                                // comp_contactNo.Text = RSBDReader2["respo_ContactNo"].ToString();
                                lblrespo_Purok.Text = RSBDReader2["respo_Purok"].ToString();
                                lblrespo_Barangay.Text = RSBDReader2["respo_Barangay"].ToString();
                                lblrespo_Province.Text = RSBDReader2["respo_Province"].ToString();
                                lblrespo_City.Text = RSBDReader2["respo_City"].ToString();
                                lblrespo_Region.Text = RSBDReader2["respo_Region"].ToString();

                                lbl_respoNationality.Text = RSBDReader2["respo_Nationality"].ToString();
                                lbl_respoOccupation.Text = RSBDReader2["respo_Occupation"].ToString();
                                lbl_respoPassportID.Text = RSBDReader2["respo_PassportID"].ToString();

                                string gender = RSBDReader2["respo_Sex"].ToString();
                                if (gender.ToLower() == "male")
                                {
                                    chkRespo_Male.Checked = true;
                                    chkRespo_Female.Checked = false;
                                }
                                else if (gender.ToLower() == "female")
                                {
                                    chkRespo_Male.Checked = false;
                                    chkRespo_Female.Checked = true;
                                }

                                string civilStatus = RSBDReader2["respo_CivilStatus"].ToString();

                                if (civilStatus.Equals("Single", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_StSingle.Checked = true;
                                }
                                else if (civilStatus.Equals("Married", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_StMarried.Checked = true;
                                }
                                else if (civilStatus.Equals("Live-in", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_StLivein.Checked = true;
                                }
                                else if (civilStatus.Equals("Widowed", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_StWidowed.Checked = true;
                                }
                                else if (civilStatus.Equals("Separated", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_StSeparated.Checked = true;
                                }

                                string religion = RSBDReader2["respo_Religion"].ToString();

                                if (religion.Equals("Roman Catholic", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Religion1.Checked = true;
                                }
                                else if (religion.Equals("Islam", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Religion2.Checked = true;
                                }
                                else if (religion.Equals("Protestant", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Religion3.Checked = true;
                                }
                                else if (religion.Equals("Iglisia ni Kristo", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Religion4.Checked = true;
                                }
                                else if (religion.Equals("Aglipayan", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Religion5.Checked = true;
                                }
                                else
                                {
                                    respo_Religion6.Checked = true;
                                    textBox12.Text = religion;
                                }

                                string educationalAttainment = RSBDReader2["respo_EducationalAttainment"].ToString();

                                if (educationalAttainment.Equals("No. Formal Education", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed1.Checked = true;
                                }
                                else if (educationalAttainment.Equals("No Response", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed2.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Vocational", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed3.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Elementary Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed4.Checked = true;
                                }
                                else if (educationalAttainment.Equals("High School Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed5.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Senior High Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed6.Checked = true;
                                }
                                else if (educationalAttainment.Equals("College Level/Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed7.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Post Graduate", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed8.Checked = true;
                                }
                                else if (educationalAttainment.Equals("Others", StringComparison.OrdinalIgnoreCase))
                                {
                                    respo_Ed9.Checked = true;
                                }


                               string relationshipToTheVictim = RSBDReader2["respo_RelationshipToVictim"].ToString();

                                if (relationshipToTheVictim.Equals("Current Spouse/Partner", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv1.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Former Fiance/Dating Relationship", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv2.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Teacher/Instructor/Professor", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv3.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Neighbors/Peers/Co-Workers/Classmates", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv4.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Former Spouse/Partner", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv5.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Employer/Manager/Supervisor", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv6.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Coach/Trainer", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv7.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Stranger", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv8.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Current Fiance/Dating Relationship", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv9.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Agent of the Employer", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv10.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("People of Authority/Service Provider", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv11.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Family", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv12.Checked = true;
                                }
                                else if (relationshipToTheVictim.Equals("Ohter Relatives", StringComparison.OrdinalIgnoreCase))
                                {
                                    ropv13.Checked = true;
                                }
                          
                            }
                            RSBDReader2.Close();

                            string query3 = "SELECT * FROM caselist WHERE caseNo = @caseNo";

                            MySqlCommand RSDBCommand3 = new MySqlCommand(query3, RSDBConnect);
                            RSDBCommand3.Parameters.AddWithValue("@caseNo", typedCaseNo);
                            MySqlDataReader RSBDReader3 = RSDBCommand3.ExecuteReader();

                            if (RSBDReader3.Read())
                            {
                                DateTime complaintDate = RSBDReader3.GetDateTime("case_ComplaintDate");

                           
                                string formattedDate = complaintDate.ToString("MM-dd-yyyy"); 

    
                                label143.Text = formattedDate;
                                label129.Text= formattedDate;

                                DateTime incidentDate = RSBDReader3.GetDateTime("case_incidentDate");
                                dateTimePicker1.Value = incidentDate;

                                caseDescription.Text = RSBDReader3["case_Description"].ToString();
                                caseBarangay.Text = RSBDReader3["case_barangay"].ToString();
                                caseCity.Text = RSBDReader3["case_municipality"].ToString();
                                caseProvince.Text = RSBDReader3["case_province"].ToString();
                                caseRegion.Text = RSBDReader3["case_region"].ToString();
                                lblRespoIdentifyingMarks.Text = RSBDReader3["case_respoIdentifyingMarks"].ToString();



                                string placeofIncident = RSBDReader3["case_plcofincident"].ToString();

                                if (placeofIncident.Equals("Home", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc1.Checked = true;
                                }
                             
                                else if (placeofIncident.Equals("Religious Institutions", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc2.Checked = true;
                                }
                                else if (placeofIncident.Equals("Brothels and Similar Establishments", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc3.Checked = true;
                                }
                                else if (placeofIncident.Equals("Work", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc4.Checked = true;
                                }
                                else if (placeofIncident.Equals("Place of Medical Treatment", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc5.Checked = true;
                                }
                                else if (placeofIncident.Equals("School", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc6.Checked = true;
                                }
                                else if (placeofIncident.Equals("Transportation & Connecting Sites", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc7.Checked = true;
                                }
                                else if (placeofIncident.Equals("Commercial Places", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc8.Checked = true;
                                }
                                else if (placeofIncident.Equals("No Response", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc9.Checked = true;
                                }
                                else if (placeofIncident.Equals("Others", StringComparison.OrdinalIgnoreCase))
                                {
                                    plc10.Checked = true;
                                }

                                string RAviolations = RSBDReader3["case_Violation"].ToString();
                                string subViolations = RSBDReader3["case_SubViolation"].ToString();

                                if (RAviolations.Equals("R.A. 9262: Anti Violence Against Women and their Children Act", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA1.Checked = true;
                                   if(subViolations.Equals("Sexual Abuse", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA9262sub1.Checked = true;
                                    }

                                   else if(subViolations.Equals("Psychological", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA9262sub2.Checked = true;
                                    }

                                    else if (subViolations.Equals("Physical", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA9262sub3.Checked = true;
                                    }

                                    else if (subViolations.Equals("Economic", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA9262sub4.Checked = true;
                                    }

                                    else if (subViolations.Equals("Others", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA9262sub5.Checked = true;
                                    }
                                }

                                else if (RAviolations.Equals("R.A. 8353: Anti-Rape Law of 1995", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA2.Checked = true;
                                    if (subViolations.Equals("Sexual Abuse", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA8353sub1.Checked = true;
                                    }

                                    else if (subViolations.Equals("Psychological", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA8353sub2.Checked = true;
                                    }
                                }
                                else if (RAviolations.Equals("R.A. 7877: Anti-Sexual Harrassment Act", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA3.Checked = true;
                                    if (subViolations.Equals("Sexual Abuse", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA7877sub1.Checked = true;
                                    }

                                    else if (subViolations.Equals("Psychological", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA7877sub2.Checked = true;
                                    }

                                    else if (subViolations.Equals("Physical", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA7877sub3.Checked = true;
                                    }

                                }
                                else if (RAviolations.Equals("R.A. 7610: Special Protection of Children Against Child Abuse, Exploitation and Discrimination Act", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA4.Checked = true;
                                    if (subViolations.Equals("Sexual Abuse", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA7610sub1.Checked = true;
                                    }

                                    else if (subViolations.Equals("Psychological", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RA7610sub2.Checked = true;
                                    }

                                }
                                else if (RAviolations.Equals("R.A. 9208: Anti-Trafficking in Person Act of 2003", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA5.Checked = true;
                                }
                                else if (RAviolations.Equals("R.A. 9775: Anti-Child Pornography Act", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA6.Checked = true;
                                }
                                else if (RAviolations.Equals("R.A. 9995: Anti-Photo and Video Act 2009", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA7.Checked = true;
                                }
                                else if (RAviolations.Equals("Revised Penal Code", StringComparison.OrdinalIgnoreCase))
                                {
                                    RA8.Checked = true;
                                    if (subViolations.Equals("Sexual Abuse", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RPCsub1.Checked = true;
                                    }

                                    else if (subViolations.Equals("Psychological", StringComparison.OrdinalIgnoreCase))
                                    {
                                        RPCsub2.Checked = true;
                                    }

                                }


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The case number does not exist in the database.");
                        textBox1.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Database connection is not open.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection in the finally block to ensure it's always closed
                RSDBConnect.Close();
            }
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadthesecase();
            }
        }

       
    }
}


    
