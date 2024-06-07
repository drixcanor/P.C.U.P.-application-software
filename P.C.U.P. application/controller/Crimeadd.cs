using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using pcup.app;

namespace P.C.U.P.application
{
    public partial class Crimeadd : Form
    {
        public Crimeform crimeform;
        public Crimeadd(Crimeform crimeform)
        {
            InitializeComponent();
            this.crimeform = crimeform;
        }
        private void PerformDatabaseOperation(string query)
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

            // Set parameter values
            pcup_class.cmd.Parameters.AddWithValue("@crimeId", bunifuLabel2.Text);
            pcup_class.cmd.Parameters.AddWithValue("@crimeViolation", violation.Text);
            pcup_class.cmd.Parameters.AddWithValue("@crimeDate", date.Value.ToString("MMMM dd yyyy"));
            pcup_class.cmd.Parameters.AddWithValue("@crimeVictim", victim.Text);
            pcup_class.cmd.Parameters.AddWithValue("@crimePerpetrator", suspect.Text);
            pcup_class.cmd.Parameters.AddWithValue("@crimeBarangay", barangaylist.Text);
            pcup_class.cmd.Parameters.AddWithValue("@crime_remark", remark.Text);

            if (query.StartsWith("INSERT"))
            {
                pcup_class.cmd.ExecuteReader();
                
                MessageBox.Show("Record saved successfully!", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else if (query.StartsWith("UPDATE"))
            {
                int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    MessageBox.Show("Record updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    crimeform.RefreshData();
                    
                }
                else
                {
                    MessageBox.Show("Failed to update record. Please try again.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            pcup_class.dbconnect.Closeconnection();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if required fields are empty
            if (string.IsNullOrEmpty(violation.Text) || string.IsNullOrEmpty(date.Text) ||
                string.IsNullOrEmpty(victim.Text) || string.IsNullOrEmpty(suspect.Text) ||
                string.IsNullOrEmpty(barangaylist.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PerformDatabaseOperation("INSERT INTO tbl_crime (crime_violation, crime_date, crime_victim, crime_perpetrator, crime_barangay,crime_remark) VALUES (@crimeViolation, @crimeDate, @crimeVictim, @crimePerpetrator, @crimeBarangay,@crime_remark)");
            

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
                    victim.AutoCompleteCustomSource = autoCompleteCollection;
                }
            }

            pcup_class.dbconnect.Closeconnection();
        }
        private void SetupAutoComplete2()
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
                    suspect.AutoCompleteCustomSource = autoCompleteCollection;
                }
            }

            pcup_class.dbconnect.Closeconnection();
        }

        private void update_Click(object sender, EventArgs e)
        {
            PerformDatabaseOperation("UPDATE tbl_crime SET crime_violation = @crimeViolation, crime_date = @crimeDate, crime_victim = @crimeVictim, crime_perpetrator = @crimePerpetrator, crime_barangay = @crimeBarangay,crime_remark = @crime_remark WHERE crime_id = @crimeId");

            //Dashboard dashboard = new Dashboard();
            //dashboard.RefreshData();update dashboard
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Crimeadd_Load(object sender, EventArgs e)
        {
            SetupAutoComplete2();
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
    }
}
