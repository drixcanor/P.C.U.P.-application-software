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
    public partial class Orgadd : Form
    {

        private Orgform orgform;
        private UserSession userSession;
        public Orgadd(Orgform orgform, UserSession userSession)
        {
            InitializeComponent();
            this.orgform = orgform; 
            this.userSession = userSession;
            this.userSession.SessionDataAvailable += UserSession_SessionDataAvailable;
        }
        private void UserSession_SessionDataAvailable(object sender, EventArgs e)
        {
            // Retrieve username from UserSession
            string username = userSession.Usirname;

            // Use the username as needed in the Memberadd form
            // For example, log the username to the database
            LogToDatabase(username, "Saved Organization's information");
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
        private void PerformDatabaseOperation(string query, bool isUpdate)
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

            if (isUpdate)
            {
                pcup_class.cmd.Parameters.AddWithValue("@accreditation_id", label14.Text);
            }

            pcup_class.cmd.Parameters.AddWithValue("@accreditation_name", name.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_barangay", barangaylist.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_address", address.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_contactperson", contactperson.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_phone", phone.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_number", accnumber.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_issued", issued.Value.ToString("MMMM dd yyyy"));
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_expired", bunifuDatePicker2.Value.ToString("MMMM dd yyyy"));
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_president", president.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_members", members.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_family", families.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_population",population.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_below18",minors.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_belowm",maleminor.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_belowf",femaleminor.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_area", size.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_class", comboBox1.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_programs", programs.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_problems", bunifuTextBox9.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_coordinator", officer.Text);
            pcup_class.cmd.Parameters.AddWithValue("@accreditation_remarks", Remarks.Text);

            int rowsAffected = pcup_class.cmd.ExecuteNonQuery();

            pcup_class.dbconnect.Closeconnection();

            if (rowsAffected > 0)
            {
                string successMessage = isUpdate ? "Record updated successfully!" : "Accreditation information saved successfully!";
                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                orgform.RefreshData();
            }
            else
            {
                string errorMessage = isUpdate ? "Failed to update record. Please try again." : "Failed to save accreditation information. Please try again.";
                MessageBox.Show(errorMessage, "re", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void brgydropdownn(object sender, EventArgs e)
        {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Define the SQL query to insert a new record
            string query = "INSERT INTO tbl_accreditations (accreditation_name, accreditation_barangay, accreditation_address, accreditation_contactperson, accreditation_phone, accreditation_number, accreditation_issued, accreditation_expired, accreditation_president, accreditation_members,accreditation_family, accreditation_population,accreditation_below18,accreditation_belowm,accreditation_belowf, accreditation_area, accreditation_class, accreditation_programs, accreditation_problems, accreditation_coordinator, accreditation_remarks) " +
                            "VALUES (@accreditation_name, @accreditation_barangay, @accreditation_address, @accreditation_contactperson, @accreditation_phone, @accreditation_number, @accreditation_issued, @accreditation_expired, @accreditation_president, @accreditation_members,@accreditation_family, @accreditation_population,@accreditation_below18,@accreditation_belowm,@accreditation_below1f, @accreditation_area, @accreditation_class, @accreditation_programs, @accreditation_problems, @accreditation_coordinator, @accreditation_remarks)";

            // Check if the accreditation already exists in the database
            string checkQuery = "SELECT COUNT(*) FROM tbl_accreditations WHERE accreditation_name = @accreditation_name AND accreditation_barangay = @accreditation_barangay";
            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, pcup_class.dbconnect.myconnect)) // Replace yourConnection with your actual MySqlConnection object
            {
                checkCommand.Parameters.AddWithValue("@accreditation_name", name.Text);
                checkCommand.Parameters.AddWithValue("@accreditation_barangay", barangaylist.Text);

                int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (count > 0)
                {
                    DialogResult result = MessageBox.Show("This accreditation already exists. Do you want to update the existing record?", "Accreditation Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        // User chose not to update, so return
                        return;
                    }
                    // User chose to update, so proceed with update logic
                    string updateQuery = "UPDATE tbl_accreditations SET accreditation_address = @accreditation_address, accreditation_contactperson = @accreditation_contactperson, accreditation_phone = @accreditation_phone, accreditation_number = @accreditation_number, accreditation_issued = @accreditation_issued, accreditation_expired = @accreditation_expired, accreditation_president = @accreditation_president, accreditation_members = @accreditation_members,accreditation_family = @accreditation_family, accreditation_population = @accreditation_population,accreditation_below18 = @accreditation_below18,accreditation_belowm = @accreditation_belowm,accreditation_belowf = @accreditation_belowf, accreditation_area = @accreditation_area, accreditation_class = @accreditation_class, accreditation_programs = @accreditation_programs, accreditation_problems = @accreditation_problems, accreditation_coordinator = @accreditation_coordinator, accreditation_remarks = @accreditation_remarks WHERE accreditation_name = @accreditation_name AND accreditation_barangay = @accreditation_barangay";
                    PerformDatabaseOperation(updateQuery, isUpdate: true);
                    this.Close();
                }
                else
                {
                    // Accreditation does not exist, proceed with inserting the new record
                    LogToDatabase(userSession.Usirname, "Added new Organization's information");
                    PerformDatabaseOperation(query, isUpdate: false);
                    this.Close();
                }
            }

            userSession.OnSessionDataAvailable();
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            string query = "UPDATE tbl_accreditations " +
                           "SET accreditation_name = @accreditation_name, " +
                           "accreditation_barangay = @accreditation_barangay, " +
                           "accreditation_address = @accreditation_address, " +
                           "accreditation_contactperson = @accreditation_contactperson, " +
                           "accreditation_phone = @accreditation_phone, " +
                           "accreditation_number = @accreditation_number, " +
                           "accreditation_issued = @accreditation_issued, " +
                           "accreditation_expired = @accreditation_expired, " +
                           "accreditation_president = @accreditation_president, " +
                           "accreditation_members = @accreditation_members, " +
                           "accreditation_family = @accreditation_family, " +
                           "accreditation_population = @accreditation_population, " +
                           "accreditation_below18 = @accreditation_below18, " +
                           "accreditation_belowm = @accreditation_belowm, " +
                           "accreditation_belowf = @accreditation_belowf, " +
                           "accreditation_area = @accreditation_area, " +
                           "accreditation_class = @accreditation_class, " +
                           "accreditation_programs = @accreditation_programs, " +
                           "accreditation_problems = @accreditation_problems, " +
                           "accreditation_coordinator = @accreditation_coordinator, " +
                           "accreditation_remarks = @accreditation_remarks " +
                           "WHERE accreditation_id = @accreditation_id";
            this.Close();
            PerformDatabaseOperation(query, isUpdate: true);
            LogToDatabase(userSession.Usirname, "Updated Organization's information");
        }
        private void SetupAutoCompletecoordinator()
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            // Create a MySqlCommand to fetch user names from the tbl_users table.
            pcup_class.cmd = new MySqlCommand("SELECT user_fullname FROM tbl_users", pcup_class.dbconnect.myconnect);

            using (MySqlDataReader reader = pcup_class.cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        // Add user names to the AutoCompleteStringCollection.
                        autoCompleteCollection.Add(reader["user_fullname"].ToString());
                    }

                    // Assign the AutoCompleteCustomSource to the TextBox.
                    officer.AutoCompleteCustomSource = autoCompleteCollection;
                }
            }

            pcup_class.dbconnect.Closeconnection();
        }

        private void Orgadd_Load(object sender, EventArgs e)
        {
            brgydropdownn(sender, e);

            SetupAutoCompletecoordinator();
            programdropdown();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void members_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
