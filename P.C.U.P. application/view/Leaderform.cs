using ClosedXML.Excel;
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
    public partial class Leaderform : Form
    {
        private UserSession userSession;
        public Leaderform(UserSession userSession)
        {
            InitializeComponent();
            this.userSession = userSession;
            this.userSession.SessionDataAvailable += UserSession_SessionDataAvailable;  
            LoadLeaderData();
            barangaylist.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            assoclist.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            programlist.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            //showFullRowCheckBox.CheckedChanged += ShowFullRowCheckBox_CheckedChanged;
        }

        //private void FilterDataGridView()
        //{
        //    string barangayFilter = barangaylist.Text.Trim().ToLower();
        //    string assocFilter = assoclist.Text.Trim().ToLower();
        //    string programFilter = programlist.Text.Trim().ToLower();

        //    foreach (DataGridViewRow row in dg_approve.Rows)
        //    {
        //        bool barangayMatches = string.IsNullOrEmpty(barangayFilter) || row.Cells["dataGridViewTextBoxColumn14"].Value.ToString().ToLower().Contains(barangayFilter);
        //        bool assocMatches = string.IsNullOrEmpty(assocFilter) || row.Cells["dataGridViewTextBoxColumn23"].Value.ToString().ToLower().Contains(assocFilter);
        //        bool programMatches = string.IsNullOrEmpty(programFilter) || row.Cells["dataGridViewTextBoxColumn22"].Value.ToString().ToLower().Contains(programFilter);

        //        row.Visible = barangayMatches && assocMatches && programMatches;
        //    }
        //}
        private void FilterDataGridView()
        {
            string barangayFilter = barangaylist.Text.Trim().ToLower();
            string assocFilter = assoclist.Text.Trim().ToLower();
            string programFilter = programlist.Text.Trim().ToLower();

            // Start by assuming all rows are visible
            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                row.Visible = true;
            }

            // Apply barangay filter first
            if (!string.IsNullOrEmpty(barangayFilter))
            {
                foreach (DataGridViewRow row in dg_approve.Rows)
                {
                    if (!row.Cells["dataGridViewTextBoxColumn14"].Value.ToString().ToLower().Contains(barangayFilter))
                    {
                        row.Visible = false;
                    }
                }
            }

            // Apply assoc filter next, only to rows that are still visible
            if (!string.IsNullOrEmpty(assocFilter))
            {
                foreach (DataGridViewRow row in dg_approve.Rows)
                {
                    if (row.Visible && !row.Cells["dataGridViewTextBoxColumn23"].Value.ToString().ToLower().Contains(assocFilter))
                    {
                        row.Visible = false;
                    }
                }
            }

            // Apply program filter last, only to rows that are still visible
            if (!string.IsNullOrEmpty(programFilter))
            {
                foreach (DataGridViewRow row in dg_approve.Rows)
                {
                    if (row.Visible && !row.Cells["dataGridViewTextBoxColumn22"].Value.ToString().ToLower().Contains(programFilter))
                    {
                        row.Visible = false;
                    }
                }
            }
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
                if (pcup_class.dbconnect.myconnect.State != ConnectionState.Open)
                    pcup_class.dbconnect.Openconnection();

                using (MySqlCommand logCmd = new MySqlCommand(logQuery, pcup_class.dbconnect.myconnect))
                {
                    logCmd.Parameters.AddWithValue("@username", username);
                    logCmd.Parameters.AddWithValue("@content", logContent);
                    logCmd.Parameters.AddWithValue("@date", DateTime.Now);

                    int rowsAffected = logCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Log entry successful!");
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
                if (pcup_class.dbconnect.myconnect.State == ConnectionState.Open)
                    pcup_class.dbconnect.Closeconnection();
            }
        }

        public void RefreshData()
        {
            LoadLeaderData();
        }
        private void LoadLeaderData()
        {
            dg_approve.Rows.Clear();
            dg_pending.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand("SELECT leader_id, leader_lname,leader_name,leader_mname, leader_position, leader_sex, leader_age, leader_barangay,leader_civilstatus, leader_num_family_members, leader_total_male, leader_total_female, leader_totalpwd_physical_male, leader_senior_male, leader_below_18_male ,leader_program,leader_association,leader_remarks, leader_state FROM tbl_leaders", pcup_class.dbconnect.myconnect);

            pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

            while (pcup_class.Myreader.Read())
            {

                string leaderremarks = pcup_class.Myreader["leader_remarks"].ToString();           
                string householdState = pcup_class.Myreader["leader_state"].ToString();

                if (householdState != "hidden")
                {
                    pcup_class.dgrec = new string[]
                    {

                            pcup_class.Myreader["leader_id"].ToString(),
                            pcup_class.Myreader["leader_lname"].ToString(),
                            pcup_class.Myreader["leader_name"].ToString(),
                            pcup_class.Myreader["leader_mname"].ToString(),
                            pcup_class.Myreader["leader_position"].ToString(),
                            pcup_class.Myreader["leader_sex"].ToString(),
                            pcup_class.Myreader["leader_age"].ToString(),
                            pcup_class.Myreader["leader_barangay"].ToString(),
                            pcup_class.Myreader["leader_civilstatus"].ToString(),
                            pcup_class.Myreader["leader_num_family_members"].ToString(),
                            pcup_class.Myreader["leader_total_male"].ToString(),
                            pcup_class.Myreader["leader_total_female"].ToString(),
                            pcup_class.Myreader["leader_totalpwd_physical_male"].ToString(),
                            pcup_class.Myreader["leader_senior_male"].ToString(),
                            pcup_class.Myreader["leader_below_18_male"].ToString(),
                            pcup_class.Myreader["leader_program"].ToString(),
                            pcup_class.Myreader["leader_association"].ToString(),
                            leaderremarks,
                            householdState,


                    };

                    DataGridViewRow row = new DataGridViewRow();

                    // Create a new checkbox cell and set its value to false (unchecked)
                    DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
                    checkBoxCell.Value = false; // Unchecked by default
                    checkBoxCell.ReadOnly = false; // Allow checking and unchecking
                    row.Cells.Add(checkBoxCell);

                    // Populate the rest of the columns with corresponding data
                    for (int i = 0; i < pcup_class.dgrec.Length; i++)
                    {
                        DataGridViewCell cell = new DataGridViewTextBoxCell();
                        cell.Value = pcup_class.dgrec[i];
                        row.Cells.Add(cell);
                    }
                    if (leaderremarks == "NEW")
                    {
                        dg_pending.Rows.Add(row); // Add to dg_approve
                    }
                    else if (leaderremarks == "APPROVED")
                    {
                        dg_approve.Rows.Add(row); // Add to dg_approve
                    }
                    else
                    {
                        dg_pending.Rows.Add(row); // Add to dg_pending
                    }
                }
            }

            pcup_class.dbconnect.Closeconnection();
        }

        private void OpenTestForm(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string leader_id = selectedRow.Cells[1].Value.ToString();
                string leader_lname = selectedRow.Cells[2].Value.ToString();
                string leader_name = selectedRow.Cells[3].Value.ToString();
                string leader_mname = selectedRow.Cells[4].Value.ToString();
                string leader_position = selectedRow.Cells[5].Value.ToString();
                string leader_sex = selectedRow.Cells[6].Value.ToString();
                string leader_age = selectedRow.Cells[7].Value.ToString(); // Assuming index 7 contains the date string
                string leader_barangay = selectedRow.Cells[8].Value.ToString();
                string leader_civilstatus = selectedRow.Cells[9].Value.ToString();
                string leader_num_family_members = selectedRow.Cells[10].Value.ToString();
                string leader_total_male = selectedRow.Cells[11].Value.ToString();
                string leader_total_female = selectedRow.Cells[12].Value.ToString();
                string leader_totalpwd_physical_male = selectedRow.Cells[13].Value.ToString();
                string leader_senior_male = selectedRow.Cells[14].Value.ToString();
                string leader_below_18_male = selectedRow.Cells[15].Value.ToString();
                string leader_program = selectedRow.Cells[16].Value.ToString();
                string leader_association = selectedRow.Cells[17].Value.ToString();
                string leader_remarks = selectedRow.Cells[18].Value.ToString();

                // Create a new instance of the Officeradd form
                Leaderadd userAddForm = new Leaderadd(this, userSession);

                // Populate the controls in the Officeradd form with data from the selected row
                userAddForm.number.Text = leader_id;
                userAddForm.lastname.Text = leader_lname;
                userAddForm.firstname.Text = leader_name;
                userAddForm.midname.Text = leader_mname;
                userAddForm.position.Text = leader_position;
                userAddForm.sex.Text = leader_sex;

                DateTime parsedDate;
                if (DateTime.TryParse(leader_age, out parsedDate))
                {
                    userAddForm.Birthdate.Value = parsedDate;
                }
                else
                {

                    // Handle the case when the date format is correct
                    MessageBox.Show("Date format is valid. Proceed with the operation.", "Valid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                userAddForm.barangaylist.Text = leader_barangay;
                userAddForm.civilstatus.Text = leader_civilstatus;
                userAddForm.family.Text = leader_num_family_members;
                userAddForm.totalmale.Text = leader_total_male;
                userAddForm.totalfemale.Text = leader_total_female;
                userAddForm.totalmalepwd.Text = leader_totalpwd_physical_male;
                userAddForm.seniormale.Text = leader_senior_male;
                userAddForm.below18.Text = leader_below_18_male;
                userAddForm.programs.Text = leader_program;
                userAddForm.association.Text = leader_association;
                userAddForm.Remarks.Text = leader_remarks;

                userAddForm.btnSave.Visible = false;
                userAddForm.update.Visible = true;
                userAddForm.ShowDialog();
                LoadLeaderData();
            }
        }
        private void DeleteSelectedRowspending()
        {
            List<DataGridViewRow> rowsToUpdate = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_pending.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string leaderId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete row with ID: {leaderId}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Perform deletion from the database here using the accreditationId
                        // For example:
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_leaders SET leader_state = 'hidden' WHERE leader_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", leaderId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Deleted User's Information");
                        // Assuming update is successful, add the row to update in DataGridView
                        rowsToUpdate.Add(row);
                    }
                }
            }

            // Remove the selected rows from the DataGridView
            foreach (DataGridViewRow row in rowsToUpdate)
            {
                // Assuming there's a column index for household_state, change the value in the DataGridView directly
                row.Cells["Column21"].Value = "hidden";
            }
            LoadLeaderData();
        }
        private void DeleteSelectedRows()
        {
            List<DataGridViewRow> rowsToUpdate = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string householdId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to Delete row with ID: {householdId}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Perform update in the database here using the householdId
                        // For example:
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_leaders SET leader_state = 'hidden' WHERE leader_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", householdId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Deleted User's Information");
                        // Assuming update is successful, add the row to update in DataGridView
                        rowsToUpdate.Add(row);
                    }
                }
            }

            // Update the selected rows in the DataGridView
            foreach (DataGridViewRow row in rowsToUpdate)
            {
                // Assuming there's a column index for household_state, change the value in the DataGridView directly
                row.Cells["Column18"].Value = "hidden";
            }
            LoadLeaderData();
        }

        
        private void ApproveSelectedRows(DataGridView dataGridView)
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string leaderId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to approve row with ID: {leaderId}?", "Approval Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        // Update accreditation_remarks to 'APPROVED' in the database for dg_pending tab
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_leaders SET leader_remarks = 'APPROVED' WHERE leader_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", leaderId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Approved Leader's Information");
                        // Assuming update is successful, mark the row for removal
                        rowsToRemove.Add(row);
                    }
                }
            }

            // Remove the selected rows from the DataGridView
            foreach (DataGridViewRow row in rowsToRemove)
            {
                if (!row.IsNewRow)
                {
                    dataGridView.Rows.Remove(row);
                }
            }

            LoadLeaderData();// Refresh the data in the DataGridView after removing the approved rows
        }


        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
        private void population()
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
        private void assoclists()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT accreditation_name FROM tbl_accreditations", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the RegionComboBox
                assoclist.Items.Clear();

                // Add each region_id and region_name to the ComboBox
                while (pcup_class.Myreader.Read())
                {
                    string barangayName = pcup_class.Myreader.GetString("accreditation_name");
                    string displayText = $"{barangayName}";
                    assoclist.Items.Add(displayText);
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
        private void programlists()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT report_name FROM tbl_reports", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the RegionComboBox
                programlist.Items.Clear();

                // Add each region_id and region_name to the ComboBox
                while (pcup_class.Myreader.Read())
                {
                    string barangayName = pcup_class.Myreader.GetString("report_name");
                    string displayText = $"{barangayName}";
                    programlist.Items.Add(displayText);
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

        private void Leaderform_Load(object sender, EventArgs e)
        {
            population();
            assoclists();
            programlists();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Leaderadd leaderadd = new Leaderadd(this,userSession);
            leaderadd.btnSave.Visible = true;
            leaderadd.update.Visible = false;
            leaderadd.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int checkedRowCount = 0;
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    checkedRowCount++;
                    selectedRow = row;
                }
            }

            if (checkedRowCount == 1 && selectedRow != null) // Only proceed if exactly one row is checked
            {
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)selectedRow.Cells[0]; // Assuming the checkbox column index is 0

                if (Convert.ToBoolean(chkCell.Value))
                {
                    OpenTestForm(dg_approve);
                }
                else
                {
                    MessageBox.Show("Please check the checkbox in the row you want to edit.", "No Checkbox Checked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (checkedRowCount == 0)
            {
                MessageBox.Show("Please select a row to edit.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select only one row at a time for editing.", "Multiple Rows Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    DataTable dt = GetDataTableFromDataGridView(dg_approve); // Change dg_pending to your DataGridView name

                    if (dt != null)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel File|*.xlsx";
                        saveFileDialog1.Title = "Save Excel File";
                        saveFileDialog1.ShowDialog();

                        if (saveFileDialog1.FileName != "")
                        {
                            var worksheet = workbook.Worksheets.Add("Sheet1");
                            worksheet.Cell(1, 1).InsertTable(dt);
                            workbook.SaveAs(saveFileDialog1.FileName);
                            MessageBox.Show("Data exported to Excel successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data available for export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data to Excel: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0)
            {
                DataTable dt = new DataTable();

                // Create columns in DataTable (starting from index 1)
                for (int i = 1; i < dataGridView.Columns.Count; i++) // Start from index 1
                {
                    dt.Columns.Add(dataGridView.Columns[i].HeaderText);
                }

                // Add rows to DataTable
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    DataRow dataRow = dt.NewRow();
                    for (int i = 1; i < dataGridView.Columns.Count; i++) // Start from index 1
                    {
                        dataRow[i - 1] = row.Cells[i].Value; // Adjust index to match DataTable columns
                    }
                    dt.Rows.Add(dataRow);
                }

                return dt;
            }
            else
            {
                return null;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox1
            bool isChecked = checkBox4.Checked;

            // Iterate through rows in your DataGridView to set the checkbox value
            foreach (DataGridViewRow row in dg_pending.Rows) // Change dg_approve to your DataGridView name
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                // Update the value of the checkbox cell based on checkbox1's state
                checkBoxCell.Value = isChecked;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = metroTextBox1.Text.Trim().ToLower(); // Get the search text and trim any leading/trailing spaces

            // Iterate through the rows of the dg_approve DataGridView
            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                bool rowVisible = false;

                // Iterate through the cells of the row and check if any cell contains the searchValue
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue))
                    {
                        rowVisible = true;
                        break; // If a cell contains the searchValue, no need to check other cells
                    }
                }

                // Set the row's visibility based on whether it matches the search criteria
                row.Visible = rowVisible;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApproveSelectedRows(dg_pending);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int checkedRowCount = 0;
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in dg_pending.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    checkedRowCount++;
                    selectedRow = row;
                }
            }

            if (checkedRowCount == 1 && selectedRow != null) // Only proceed if exactly one row is checked
            {
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)selectedRow.Cells[0]; // Assuming the checkbox column index is 0

                if (Convert.ToBoolean(chkCell.Value))
                {
                    OpenTestForm(dg_pending);
                }
                else
                {
                    MessageBox.Show("Please check the checkbox in the row you want to edit.", "No Checkbox Checked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (checkedRowCount == 0)
            {
                MessageBox.Show("Please select a row to edit.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select only one row at a time for editing.", "Multiple Rows Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            DeleteSelectedRowspending();
        }

        private void checkBox4_TextChanged(object sender, EventArgs e)
        {
            string searchValue = checkBox4.Text.Trim().ToLower(); // Get the search text and trim any leading/trailing spaces

            // Check which DataGridView you want to search (e.g., dg_approve or dg_pending)
            DataGridView dataGridViewToSearch = (metroTabControl1.SelectedTab == metroTabControl1.TabPages["tabPage2"]) ? dg_approve : dg_pending;

            // Iterate through the rows of the selected DataGridView
            foreach (DataGridViewRow row in dataGridViewToSearch.Rows)
            {
                bool rowVisible = false;

                // Iterate through the cells of the row and check if any cell contains the searchValue
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue))
                    {
                        rowVisible = true;
                        break; // If a cell contains the searchValue, no need to check other cells
                    }
                }

                // Set the row's visibility based on whether it matches the search criteria
                row.Visible = rowVisible;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox3
            bool isChecked = checkBox3.Checked;

            // Iterate through rows in your DataGridView to set the checkbox value
            foreach (DataGridViewRow row in dg_approve.Rows) // Change dg_approve to your DataGridView name
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                // Update the value of the checkbox cell based on checkbox1's state
                checkBoxCell.Value = isChecked;
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            string searchValue = comboBox.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                bool rowVisible = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue))
                    {
                        rowVisible = true;
                        break;
                    }
                }

                row.Visible = rowVisible;
            }
        }
        private void barangaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void assoclist_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void programlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }
        //private void ShowFullRowCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool showEmptyRows = showFullRowCheckBox.Checked;
        //    string barangayFilter = barangaylist.Text.Trim().ToLower();
        //    string assocFilter = assoclist.Text.Trim().ToLower();
        //    string programFilter = programlist.Text.Trim().ToLower();

        //    foreach (DataGridViewRow row in dg_approve.Rows)
        //    {
        //        bool shouldShowRow = true; // By default, show the row

        //        // Check if the row matches the filter criteria
        //        if (!string.IsNullOrEmpty(barangayFilter) && !row.Cells["dataGridViewTextBoxColumn14"].Value.ToString().ToLower().Contains(barangayFilter))
        //        {
        //            shouldShowRow = false; // Hide the row if it doesn't match the barangay filter
        //        }
        //        else if (!string.IsNullOrEmpty(assocFilter) && !row.Cells["dataGridViewTextBoxColumn23"].Value.ToString().ToLower().Contains(assocFilter))
        //        {
        //            shouldShowRow = false; // Hide the row if it doesn't match the assoc filter
        //        }
        //        else if (!string.IsNullOrEmpty(programFilter) && !row.Cells["dataGridViewTextBoxColumn22"].Value.ToString().ToLower().Contains(programFilter))
        //        {
        //            shouldShowRow = false; // Hide the row if it doesn't match the program filter
        //        }

        //        // Apply showEmptyRows logic
        //        if (!showEmptyRows && (row.Cells["dataGridViewTextBoxColumn22"].Value == null ||
        //            string.IsNullOrEmpty(row.Cells["dataGridViewTextBoxColumn22"].Value.ToString())))
        //        {
        //            shouldShowRow = false; // Hide the row if showEmptyRows is not checked and dataGridViewTextBoxColumn22 is empty
        //        }

        //        row.Visible = shouldShowRow;
        //    }
        //}

        private void ShowFullRowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //bool showEmptyRows = showFullRowCheckBox.Checked;

            //foreach (DataGridViewRow row in dg_approve.Rows)
            //{
            //    bool shouldShowRow = !showEmptyRows; // By default, hide the row if showEmptyRows is checked

            //    // Check if dataGridViewTextBoxColumn22 is empty
            //    if (showEmptyRows && (row.Cells["dataGridViewTextBoxColumn22"].Value == null ||
            //        string.IsNullOrEmpty(row.Cells["dataGridViewTextBoxColumn22"].Value.ToString())))
            //    {
            //        shouldShowRow = true; // Show the row if showEmptyRows is checked and dataGridViewTextBoxColumn22 is empty
            //    }

            //    row.Visible = shouldShowRow;
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadLeaderData();
        }

        private void showFullRowCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
