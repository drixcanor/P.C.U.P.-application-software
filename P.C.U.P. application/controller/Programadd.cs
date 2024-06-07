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
    public partial class Programadd : Form
    {
        private UserSession userSession;
        public Programform programform;
        public Programadd(Programform programform, UserSession userSession)
        {
            InitializeComponent();
            this.programform = programform;
            this.userSession = userSession;
                    
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if required fields are empty
            if (string.IsNullOrEmpty(facilitator.Text) || string.IsNullOrEmpty(facilitator.Text) ||
                string.IsNullOrEmpty(Date.Text) || string.IsNullOrEmpty(objective.Text) ||
                string.IsNullOrEmpty(barangaylist.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PerformDatabaseOperation("INSERT INTO tbl_reports (report_name, report_facilitator, report_date, report_objective, report_barangay,report_remark) VALUES (@reportName, @reportFacilitator, @reportDate, @reportObjective, @reportBarangay,@report_remark)");
            LogToDatabase(userSession.Usirname, "Added new Program");
            
            this.Close();
        }
        private void PerformDatabaseOperation(string query)
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

            // Set parameter values
            pcup_class.cmd.Parameters.AddWithValue("@reportId", bunifuLabel2.Text);
            pcup_class.cmd.Parameters.AddWithValue("@reportName", facilitator.Text);
            pcup_class.cmd.Parameters.AddWithValue("@reportFacilitator", facilitator.Text);
            pcup_class.cmd.Parameters.AddWithValue("@reportDate", Date.Value.ToString("MMMM dd yyyy"));
            pcup_class.cmd.Parameters.AddWithValue("@reportObjective", objective.Text);
            pcup_class.cmd.Parameters.AddWithValue("@reportBarangay", barangaylist.Text);
            
            pcup_class.cmd.Parameters.AddWithValue("@report_remark", remarks.Text);

            if (query.StartsWith("INSERT"))
            {
                pcup_class.cmd.ExecuteReader();
                MessageBox.Show("Recorded Successfully!", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogToDatabase(userSession.Usirname, "Added new Program");
                
            }
            else if (query.StartsWith("UPDATE"))
            {
                int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    programform.RefreshData();
                }
                else
                {
                    MessageBox.Show("Failed to update record. Please try again.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            pcup_class.dbconnect.Closeconnection();
            programform.RefreshData();
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            PerformDatabaseOperation("UPDATE tbl_reports SET report_name = @reportName, report_facilitator = @reportFacilitator, report_date = @reportDate, report_objective = @reportObjective, report_barangay = @reportBarangay , report_remark= @report_remark WHERE report_id = @reportId");
             LogToDatabase(userSession.Usirname, "Added new Leader's information");
            LogToDatabase(userSession.Usirname, "Updated Program");
            this.Close();
        }

        private void Programadd_Load(object sender, EventArgs e)
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

        private void remarks_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
