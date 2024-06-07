using ClosedXML.Excel;
using MetroFramework.Controls;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace P.C.U.P.application
{
    public partial class Householdform : Form
    {
        private UserSession userSession;
        public Householdform(UserSession userSession)
        {
            InitializeComponent();
            LoadUserData();
            this.userSession = userSession;
            this.userSession.SessionDataAvailable += UserSession_SessionDataAvailable;
           
        }
        

        private void UserSession_SessionDataAvailable(object sender, EventArgs e)
        {
            // Retrieve username from UserSession
            string username = userSession.Usirname;

            // Use the username as needed in the Memberadd form
            // For example, log the username to the database
            LogToDatabase(username, "Saved User's information");
        }


        private void crimepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void editpending_Click(object sender, EventArgs e)
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Householdadd householdadd = new Householdadd(this, userSession);
            householdadd.btnSave.Visible = true;
            householdadd.update.Visible = false;
            householdadd.ShowDialog();
        }

        private void DeleteSelectedRows()
        {
            List<DataGridViewRow> rowsToUpdate = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string householdId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to update row with ID: {householdId}?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Perform update in the database here using the householdId
                        // For example:
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_households SET household_state = 'hidden' WHERE household_id = @id", pcup_class.dbconnect.myconnect);
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
                row.Cells["Column2"].Value = "hidden";
            }
            LoadUserData();
        }

        private void LoadUserData()
        {
            // Clear existing data in the DataGridView
            dg_approve.Rows.Clear();
            dg_pending.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand("SELECT household_id, household_lastname, household_firstname, household_middlename, household_suffix, household_birthdate, " +
                "household_sex, pregnant, last_preg, children, household_education,household_school, employment, source, household_type, " +
                "household_leader, household_relation,household_barangay,household_remarks,household_association,household_state FROM tbl_households", pcup_class.dbconnect.myconnect);

            pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

            while (pcup_class.Myreader.Read())
            {

                string formattedLastPreg = pcup_class.Myreader["last_preg"].ToString();
                string householdBarangay = pcup_class.Myreader["household_barangay"].ToString();
                string householdremarks = pcup_class.Myreader["household_remarks"].ToString();
                string householdassoc = pcup_class.Myreader["household_association"].ToString();
                string householdtype = pcup_class.Myreader["household_type"].ToString();
                string householdState = pcup_class.Myreader["household_state"].ToString();


                DateTime lastpreg;

                if (householdState != "hidden")
                {
                    if (DateTime.TryParse(formattedLastPreg, out lastpreg))
                    {


                        pcup_class.dgrec = new string[]
                        {
                            pcup_class.Myreader["household_id"].ToString(),
                            pcup_class.Myreader["household_lastname"].ToString(),
                            pcup_class.Myreader["household_firstname"].ToString(),
                            pcup_class.Myreader["household_middlename"].ToString(),
                            pcup_class.Myreader["household_suffix"].ToString(),
                            householdBarangay,
                            householdassoc,
                            pcup_class.Myreader["household_birthdate"].ToString(),
                            pcup_class.Myreader["household_sex"].ToString(),
                            pcup_class.Myreader["pregnant"].ToString(),
                            lastpreg.ToString("MMMM dd, yyyy"),
                            pcup_class.Myreader["children"].ToString(),
                            pcup_class.Myreader["household_education"].ToString(),
                            pcup_class.Myreader["household_school"].ToString(),
                            pcup_class.Myreader["source"].ToString(),
                            pcup_class.Myreader["employment"].ToString(),
                            householdtype,
                            pcup_class.Myreader["household_leader"].ToString(),
                            pcup_class.Myreader["household_relation"].ToString(),
                            householdremarks,
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


                        if (householdremarks == "NEW")
                        {
                            dg_pending.Rows.Add(row); // Add to dg_approve
                        }
                        else if (householdremarks == "APPROVED")
                        {

                            dg_approve.Rows.Add(row); // Add to dg_approve
                        }
                        else
                        {
                            dg_pending.Rows.Add(row); // Add to dg_pending
                        }

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
                string household_id = selectedRow.Cells[1].Value.ToString();
                string household_lastname = selectedRow.Cells[2].Value.ToString();
                string household_firstname = selectedRow.Cells[3].Value.ToString();
                string household_middlename = selectedRow.Cells[4].Value.ToString();
                string household_suffix = selectedRow.Cells[5].Value.ToString();
                string household_barangay = selectedRow.Cells[6].Value.ToString();
                string household_association = selectedRow.Cells[7].Value.ToString();
                string household_birthdate = selectedRow.Cells[8].Value.ToString();
                string household_sex = selectedRow.Cells[9].Value.ToString();
                string pregnant = selectedRow.Cells[10].Value.ToString();
                string last_preg = selectedRow.Cells[11].Value.ToString();
                string children = selectedRow.Cells[12].Value.ToString();
                string household_education = selectedRow.Cells[13].Value.ToString();
                string household_schoool = selectedRow.Cells[14].Value.ToString();
                string source = selectedRow.Cells[15].Value.ToString();
                string employment = selectedRow.Cells[16].Value.ToString();
                string household_type = selectedRow.Cells[17].Value.ToString();
                string household_leader = selectedRow.Cells[18].Value.ToString();
                string household_relation = selectedRow.Cells[19].Value.ToString();
                string household_remarks = selectedRow.Cells[20].Value.ToString();


                // Create a new instance of the Useradd form
                Householdadd userAddForm = new Householdadd(this,userSession);
                //Memberadd userAddForm = new Memberadd(this, userSession);
                // Populate the controls in the Useradd form with data from the selected row
                userAddForm.bunifuLabel2.Text = household_id;
                userAddForm.lastnametxt.Text = household_lastname;
                userAddForm.firstnametxt.Text = household_firstname;
                userAddForm.middlenametxt.Text = household_middlename;
                userAddForm.suffixtxt.Text = household_suffix;
                userAddForm.barangaylist.Text = household_barangay;
                userAddForm.assocdrop.Text = household_association;

                DateTime parsedDate;
                if (DateTime.TryParse(household_birthdate, out parsedDate))
                {
                    userAddForm.birthdate.Value = parsedDate;
                }
                else
                {

                    // Handle the case when the date format is correct
                    MessageBox.Show("Date format is valid. Proceed with the operation.", "Valid Date Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                userAddForm.sextxt.Text = household_sex;
                bool isCheckBox1Checked = pregnant == checkBox3.Text;
                bool isCheckBox2Checked = pregnant == checkBox2.Text;
                if (isCheckBox1Checked)
                    userAddForm.checkBox1.Checked = true;
                else if (isCheckBox2Checked)
                    userAddForm.checkBox2.Checked = true;
                    
                userAddForm.last_preg.Text = last_preg;
                userAddForm.children.Text = children;
                userAddForm.educationtxt.Text = household_education;
                userAddForm.graduated.Text = household_schoool;
                userAddForm.source.Text = source;
                userAddForm.employment.Text = employment;
                userAddForm.type.Text = household_type;
                userAddForm.leader.Text = household_leader;
                userAddForm.relationvisible.Text = household_relation;
                userAddForm.Remarks.Text = household_remarks;


                // You may need to split and set household_relation based on your specific requirements



                userAddForm.btnSave.Visible = false;
                userAddForm.update.Visible = true;
                userAddForm.ShowDialog();
                // Reload data after closing the Useradd form if needed

                // Refresh data after the form is closed
                LoadUserData();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void RefreshData()
        {
            LoadUserData();
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
                pcup_class.dbconnect.Closeconnection();
            }
        }
        private void btn_Click(object sender, EventArgs e)
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
        private void DeleteSelectedRowspending()
        {
            List<DataGridViewRow> rowsToUpdate = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_pending.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string householdId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to update row with ID: {householdId}?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Perform update in the database here using the householdId
                        // For example:
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_households SET household_state = 'hidden' WHERE household_id = @id", pcup_class.dbconnect.myconnect);
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
                row.Cells["Column1"].Value = "hidden";
            }
            LoadUserData();
        }

        

        private void deleteapproveclick_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }
        private void ApproveSelectedRows(DataGridView dataGridView)
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string householdId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to approve row with ID: {householdId}?", "Approval Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        // Update accreditation_remarks to 'APPROVED' in the database for dg_pending tab
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_households SET household_remarks = 'APPROVED' WHERE household_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", householdId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        //LogToDatabase(userSession.Usirname, "Approved Household's information");
                        pcup_class.dbconnect.Closeconnection();

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

            LoadUserData(); // Refresh the data in the DataGridView after removing the approved rows
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApproveSelectedRows(dg_pending);
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            DeleteSelectedRowspending();
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
                // Get the checked state of checkbox1
                bool isChecked = checkBox3.Checked;

                // Iterate through rows in your DataGridView to set the checkbox value
                foreach (DataGridViewRow row in dg_approve.Rows) // Change dg_approve to your DataGridView name
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                    // Update the value of the checkbox cell based on checkbox1's state
                    checkBoxCell.Value = isChecked;
                }
            
        }

        

        private void Householdform_Load(object sender, EventArgs e)
        {

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

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            string searchValue = metroTextBox2.Text.Trim().ToLower(); // Get the search text and trim any leading/trailing spaces

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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void dg_approve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
