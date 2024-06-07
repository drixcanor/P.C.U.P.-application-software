using MySql.Data.MySqlClient;
using pcup.app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P.C.U.P.application
{
    public partial class Householdadd : Form
    {
        private Householdform householdform;
        private UserSession userSession;
        public Householdadd(Householdform householdform, UserSession userSession)
        {
            InitializeComponent();
            this.householdform = householdform;
            this.userSession = userSession;
            SetupAutoComplete();
            this.userSession.SessionDataAvailable += UserSession_SessionDataAvailable;
        }
        private void UserSession_SessionDataAvailable(object sender, EventArgs e)
        {
            // Retrieve username from UserSession
            string username = userSession.Usirname;

            // Use the username as needed in the Memberadd form
            // For example, log the username to the database
            LogToDatabase(username, "Saved member's information");
        }
        private void LogToDatabase(string username, string logContent)
        {
            string logQuery = "INSERT INTO tbl_logs (logs_username, logs_content, logs_date) VALUES (@logs_username, @logs_content, @logs_date)";

            try
            {
                pcup_class.dbconnect.Openconnection();
                using (MySqlCommand logCmd = new MySqlCommand(logQuery, pcup_class.dbconnect.myconnect))
                {

                    logCmd.Parameters.AddWithValue("@logs_username", username);
                    logCmd.Parameters.AddWithValue("@logs_content", "Successfully login");
                    logCmd.Parameters.AddWithValue("@logs_date", DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss"));

                    int rowsAffected = logCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Log entry failed!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging: " + ex.Message);
            }
            finally
            {
                pcup_class.dbconnect.Closeconnection();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                pcup_class.btnResult = MessageBox.Show("Are you sure you want to save this member's information?", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (pcup_class.btnResult == DialogResult.No)
                {
                    return;
                }

                // Check if you have valid input data here
                if (string.IsNullOrEmpty(lastnametxt.Text) || string.IsNullOrEmpty(firstnametxt.Text))
                {
                    MessageBox.Show("Please fill all the required fields", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();
                // Check if the user already exists in the database
                string checkQuery = "SELECT COUNT(*) FROM tbl_households WHERE household_lastname = @household_lastname AND household_firstname = @household_firstname";
                using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, pcup_class.dbconnect.myconnect)) // Replace yourConnection with your actual MySqlConnection object
                {
                    checkCommand.Parameters.AddWithValue("@household_lastname", lastnametxt.Text);
                    checkCommand.Parameters.AddWithValue("@household_firstname", firstnametxt.Text);

                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (count > 0)
                    {
                        DialogResult result = MessageBox.Show("This user already exists. Do you want to update the existing record?", "User Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            // User chose not to update, so return
                            return;
                        }
                        // User chose to update, so proceed with update logic
                        string updateQuery = "UPDATE tbl_households SET ... WHERE household_lastname = @household_lastname AND household_firstname = @household_firstname";
                        PerformDatabaseOperation(updateQuery, isUpdate: true);
                        
                        LogToDatabase(userSession.Usirname, "Updated member's information");
                        this.Close();
                    }
                    else
                    {
                        // User does not exist, proceed with inserting the new record
                        string insertQuery = "INSERT INTO tbl_households (household_lastname, household_firstname, household_middlename, household_suffix," +
                            "household_birthdate,household_sex, pregnant, last_preg, children, household_education, " +
                            "household_school, employment, source, household_type, household_leader, household_relation, " +
                            "household_barangay, household_remarks, household_association) " +
                            "VALUES (@household_lastname, @household_firstname, @household_middlename, @household_suffix, " +
                            "@household_birthdate, @household_sex, @pregnant, @last_preg, @children, @household_education, " +
                            "@household_school, @employment, @source, @household_type, @household_leader, @household_relation, " +
                            "@household_barangay, @household_remarks, @household_association)";

                        PerformDatabaseOperation(insertQuery, isUpdate: false);
                        LogToDatabase(userSession.Usirname, "Added new member's information");
                        this.Close();
                    }
                }
                pcup_class.dbconnect.Closeconnection();
                // Trigger the event to notify Memberadd form about session data availability
                userSession.OnSessionDataAvailable();
                this.Close();
               
                // Log the operation into tbl_logs
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            pcup_class.btnResult = MessageBox.Show("Are you sure you want to update this member's information?", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (pcup_class.btnResult == DialogResult.No)
            {
                return;
            }

            // Define the SQL query to update the record
            string query = "UPDATE tbl_households " +
                            "SET household_lastname = @household_lastname, " +
                            "household_firstname = @household_firstname, " +
                            "household_middlename = @household_middlename, " +
                            "household_suffix = @household_suffix, " +
                            "household_birthdate = @household_birthdate, " +
                            "household_sex = @household_sex, " +
                            "pregnant = @pregnant, " +
                            "last_preg = @last_preg, " +
                            "children = @children, " +
                            "household_education = @household_education, " +
                            "household_school = @household_school, " +
                            "employment = @employment, " +
                            "source = @source, " +
                            "household_type = @household_type, " +
                            "household_leader = @household_leader, " +
                            "household_relation = @household_relation, " +
                            "household_barangay = @household_barangay, " +
                            "household_remarks = @household_remarks, " +
                            "household_association = @household_association " +
                            "WHERE household_id = @household_id";
            this.Close();
            PerformDatabaseOperation(query, isUpdate: true);
            LogToDatabase(userSession.Usirname, "Updated member's information");

        }
        private void PerformDatabaseOperation(string query, bool isUpdate)
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

            if (isUpdate)
            {
                pcup_class.cmd.Parameters.AddWithValue("@household_id", bunifuLabel2.Text); // Add household_id for update
            }

            pcup_class.cmd.Parameters.AddWithValue("@household_lastname", lastnametxt.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_firstname", firstnametxt.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_middlename", middlenametxt.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_suffix", suffixtxt.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_barangay", barangaylist.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_association", assocdrop.Text);

            DateTime birthdateValue = birthdate.Value;
            TimeSpan age = DateTime.Now - birthdateValue;
            int ageInYears = (int)(age.Days / 365.25); // Approximate age in years

            pcup_class.cmd.Parameters.AddWithValue("@household_birthdate", ageInYears);

            pcup_class.cmd.Parameters.AddWithValue("@household_sex", sextxt.Text);
            if (checkBox1.Checked)
            {
                pcup_class.cmd.Parameters.AddWithValue("@pregnant", checkBox1.Text);
            }
            else if (checkBox2.Checked)
            {
                pcup_class.cmd.Parameters.AddWithValue("@pregnant", checkBox2.Text);
            }
            else
            {
                pcup_class.cmd.Parameters.AddWithValue("@pregnant", ""); // If neither checkbox is checked, set an appropriate default value
            }



            pcup_class.cmd.Parameters.AddWithValue("@last_preg", last_preg.Text);
            pcup_class.cmd.Parameters.AddWithValue("@children", children.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_education", educationtxt.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_school", graduated.Text);
            pcup_class.cmd.Parameters.AddWithValue("@employment", employment.Text);
            pcup_class.cmd.Parameters.AddWithValue("@source", source.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_type", type.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_leader", leader.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_relation", relationvisible.Text);
            pcup_class.cmd.Parameters.AddWithValue("@household_remarks", Remarks.Text);



            int rowsAffected = pcup_class.cmd.ExecuteNonQuery();

            pcup_class.dbconnect.Closeconnection();

            if (rowsAffected > 0)
            {
                string successMessage = isUpdate ? "Record updated successfully!" : "Member information saved successfully!";
                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                householdform.RefreshData(); // Refresh the data on the main form
            }
            else
            {
                string errorMessage = isUpdate ? "Failed to update record. Please try again." : "Failed to save member information. Please try again.";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void orayt()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT accreditation_name FROM tbl_accreditations", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the RegionComboBox
                assocdrop.Items.Clear();

                // Add each region_id and region_name to the ComboBox
                while (pcup_class.Myreader.Read())
                {

                    string barangayName = pcup_class.Myreader.GetString("accreditation_name");
                    string displayText = $"{barangayName}";
                    assocdrop.Items.Add(displayText);
                }

                pcup_class.Myreader.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, e.g., d  isplay an error message
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                pcup_class.dbconnect.Closeconnection(); // Close the database connection
            }
        }
        private void SetupAutoComplete()
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            // Create a MySqlCommand to fetch leader names from the tbl_leaders table.
            pcup_class.cmd = new MySqlCommand("SELECT leader_lname, leader_name, leader_mname FROM tbl_leaders", pcup_class.dbconnect.myconnect);

            using (MySqlDataReader reader = pcup_class.cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        // Combine lname, name, and mname in the desired format and add to AutoCompleteStringCollection.
                        string lastName = reader["leader_lname"].ToString();
                        string firstName = reader["leader_name"].ToString();
                        string middleName = reader["leader_mname"].ToString();

                        string fullName = $"{lastName}, {firstName}, {middleName}";
                        autoCompleteCollection.Add(fullName);
                    }

                    // Assign the AutoCompleteCustomSource to the TextBox.
                    leader.AutoCompleteCustomSource = autoCompleteCollection;
                }
            }

            pcup_class.dbconnect.Closeconnection();
        }
        private void Householdadd_Load(object sender, EventArgs e)
        {
            orayt();
            SetupAutoComplete();
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT Name FROM barangays", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the RegionComboBox
                barangaylist.Items.Clear();

                // Add each region_id and region_name to the ComboBox
                while (pcup_class.Myreader.Read())
                {

                    string barangayName = pcup_class.Myreader.GetString("Name");
                    string displayText = $"{barangayName}";
                    barangaylist.Items.Add(displayText);
                }

                pcup_class.Myreader.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, e.g., display an error message
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                pcup_class.dbconnect.Closeconnection(); // Close the database connection
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // CheckBox1 is checked, uncheck CheckBox2
                checkBox2.Checked = false;
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }
            else
            {
                // CheckBox1 is unchecked

                checkBox1.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // CheckBox2 is checked, uncheck CheckBox1
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox1.Checked = false;
                last_preg.Visible = false;
                last_preg.Enabled = false;
            }
            else
            {
                // CheckBox2 is unchecked

                checkBox2.Checked = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
