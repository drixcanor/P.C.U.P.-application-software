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
    public partial class Leaderadd : Form
    {
        private Leaderform leaderform;
        private UserSession userSession;
        public Leaderadd(Leaderform  leaderform, UserSession userSession)
        {
            InitializeComponent();
            this.leaderform = leaderform;
            this.userSession = userSession;
            this.userSession.SessionDataAvailable += UserSession_SessionDataAvailable;
        }
        private void UserSession_SessionDataAvailable(object sender, EventArgs e)
        {
            // Retrieve username from UserSession
            string username = userSession.Usirname;

            // Use the username as needed in the Memberadd form
            // For example, log the username to the database
            LogToDatabase(username, "Saved Leaders's information");
        }
        private void LogToDatabase(string username, string logContent)
        {
            string logQuery = "INSERT INTO tbl_logs (logs_username, logs_content, logs_date) VALUES (@username, @content, @date)";

            try
            {
                pcup_class.dbconnect.Openconnection();
                using (MySqlCommand logCmd = new MySqlCommand(logQuery, pcup_class.dbconnect.myconnect))
                {
                    logCmd.Parameters.AddWithValue("@username", username);
                    logCmd.Parameters.AddWithValue("@content", logContent);
                    logCmd.Parameters.AddWithValue("@date", DateTime.Now);

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
        private void orayt()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT accreditation_name FROM tbl_accreditations", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the RegionComboBox
                association.Items.Clear();

                // Add each region_id and region_name to the ComboBox
                while (pcup_class.Myreader.Read())
                {

                    string barangayName = pcup_class.Myreader.GetString("accreditation_name");
                    string displayText = $"{barangayName}";
                    association.Items.Add(displayText);
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
        private void PerformDatabaseOperation(string query, bool isUpdate)
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

            if (isUpdate)
            {
                pcup_class.cmd.Parameters.AddWithValue("@leader_id", number.Text); // Add leader_id for update
            }

            pcup_class.cmd.Parameters.AddWithValue("@leader_lname", lastname.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_name", firstname.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_mname", midname.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_position", position.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_sex", sex.Text);

            DateTime birthdateValue = Birthdate.Value;
            TimeSpan age = DateTime.Now - birthdateValue;
            int ageInYears = (int)(age.Days / 365.25); // Approximate age in years

            pcup_class.cmd.Parameters.AddWithValue("@leader_age", ageInYears);

            pcup_class.cmd.Parameters.AddWithValue("@leader_barangay", barangaylist.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_civilstatus", civilstatus.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_num_family_members", family.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_total_male", totalmale.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_total_female", totalfemale.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_totalpwd_physical_male", totalmalepwd.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_senior_male", seniormale.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_below_18_male", below18.Text);

            string leaderProgramValue = string.IsNullOrEmpty(programs.Text) ? "0" : programs.Text;
            pcup_class.cmd.Parameters.AddWithValue("@leader_program", leaderProgramValue);

            pcup_class.cmd.Parameters.AddWithValue("@leader_association", association.Text);
            pcup_class.cmd.Parameters.AddWithValue("@leader_remarks", Remarks.Text);


            int rowsAffected = pcup_class.cmd.ExecuteNonQuery();

            pcup_class.dbconnect.Closeconnection();

            if (rowsAffected > 0)
            {
                string successMessage = isUpdate ? "Record updated successfully!" : "Officer information saved successfully!";
                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                leaderform.RefreshData(); // Refresh the data on the main form error
            }
            else
            {
                string errorMessage = isUpdate ? "Failed to update record. Please try again." : "Failed to save officer information. Please try again.";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            pcup_class.btnResult = MessageBox.Show("Are you sure you want to save this officer's information?", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (pcup_class.btnResult == DialogResult.No)
            {
                return;
            }

            // Check if you have valid input data here
            if (string.IsNullOrEmpty(lastname.Text) || string.IsNullOrEmpty(position.Text))
            {
                MessageBox.Show("Please fill all the required fields", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the officer already exists in the database
            string checkQuery = "SELECT COUNT(*) FROM tbl_leaders WHERE leader_lname = @leader_lname AND leader_position = @leader_position";
            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, pcup_class.dbconnect.myconnect)) // Replace yourConnection with your actual MySqlConnection object
            {
                checkCommand.Parameters.AddWithValue("@leader_lname", lastname.Text);
                checkCommand.Parameters.AddWithValue("@leader_position", position.Text);

                int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (count > 0)
                {
                    DialogResult result = MessageBox.Show("This officer already exists. Do you want to update the existing record?", "Officer Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        // User chose not to update, so return
                        return;
                    }
                    // User chose to update, so proceed with update logic
                    string updateQuery = "UPDATE tbl_leaders SET leader_name = @leader_name, leader_mname = @leader_mname, leader_sex = @leader_sex, leader_age = @leader_age, leader_barangay = @leader_barangay, leader_civilstatus = @leader_civilstatus, leader_num_family_members = @leader_num_family_members, leader_total_male = @leader_total_male, leader_total_female = @leader_total_female, leader_totalpwd_physical_male = @leader_totalpwd_physical_male, leader_senior_male = @leader_senior_male, leader_below_18_male = @leader_below_18_male, leader_program = @leader_program, leader_association = @leader_association, leader_remarks = @leader_remarks WHERE leader_lname = @leader_lname AND leader_position = @leader_position";
                    PerformDatabaseOperation(updateQuery, isUpdate: true);
                    this.Close();
                }
                else
                {
                    // Officer does not exist, proceed with inserting the new record
                    string insertQuery = "INSERT INTO tbl_leaders (leader_lname, leader_name, leader_mname, leader_position, leader_sex, leader_age, leader_barangay, leader_civilstatus, leader_num_family_members, leader_total_male, leader_total_female, leader_totalpwd_physical_male, leader_senior_male, leader_below_18_male, leader_program, leader_association, leader_remarks) " +
                               "VALUES (@leader_lname, @leader_name, @leader_mname, @leader_position, @leader_sex, @leader_age, @leader_barangay, @leader_civilstatus, @leader_num_family_members, @leader_total_male, @leader_total_female, @leader_totalpwd_physical_male, @leader_senior_male, @leader_below_18_male, @leader_program, @leader_association, @leader_remarks)";
                    LogToDatabase(userSession.Usirname, "Added new Leader's information");
                    PerformDatabaseOperation(insertQuery, isUpdate: false);
                    this.Close();
                }
            }

            programs.Text = "0";
            userSession.OnSessionDataAvailable();
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            pcup_class.btnResult = MessageBox.Show("Are you sure you want to update this officer's information?", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (pcup_class.btnResult == DialogResult.No)
            {
                return;
            }

            // Define the SQL query to update the record
            string query = "UPDATE tbl_leaders " +
                "SET leader_lname = @leader_lname, " +
                "leader_name = @leader_name, " +
                "leader_mname = @leader_mname, " +
                "leader_position = @leader_position, " +
                "leader_sex = @leader_sex, " +
                "leader_age = @leader_age, " +
                "leader_barangay = @leader_barangay, " +
                "leader_civilstatus = @leader_civilstatus, " +
                "leader_num_family_members = @leader_num_family_members, " +
                "leader_total_male = @leader_total_male, " +
                "leader_total_female = @leader_total_female, " +
                "leader_totalpwd_physical_male = @leader_totalpwd_physical_male, " +
                "leader_senior_male = @leader_senior_male, " +
                "leader_below_18_male = @leader_below_18_male, " +
                "leader_program = @leader_program, " +
                "leader_association = @leader_association, " + // Add the missing comma here
                "leader_remarks = @leader_remarks " + // Ensure the comma is correctly placed
                "WHERE leader_id = @leader_id";


            this.Close();
            PerformDatabaseOperation(query, isUpdate: true);
            LogToDatabase(userSession.Usirname, "Updated Leader's information");
        }

        private void Leaderadd_Load(object sender, EventArgs e)
        {
            orayt();
            programdropdown();
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
        private void programdropdown()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT report_name, report_barangay FROM tbl_reports", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the RegionComboBox
                programs.Items.Clear();

                // Add each report_name and report_barangay to the ComboBox
                while (pcup_class.Myreader.Read())
                {
                    string reportName = pcup_class.Myreader.GetString("report_name");
                    string reportBarangay = pcup_class.Myreader.GetString("report_barangay");
                    string displayText = $"{reportName} - {reportBarangay}";
                    programs.Items.Add(displayText);
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


        private void programs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected item is null
            if (programs.SelectedItem == null)
            {
                // Set the default value
                programs.SelectedItem = "NOT AVAILED";
            }
        }

        private void addprogram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
