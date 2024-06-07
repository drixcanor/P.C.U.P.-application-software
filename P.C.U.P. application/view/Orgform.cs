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
    public partial class Orgform : Form
    {
        private UserSession userSession;
        public Orgform(UserSession userSession)
        {
            InitializeComponent();
            this.userSession = userSession;
            LoadData2();
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
        private void LoadData2()
        {
            dg_approve.Rows.Clear();
            dg_pending.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand("SELECT accreditation_id, accreditation_name, accreditation_barangay, accreditation_address, accreditation_contactperson, accreditation_phone, accreditation_number, accreditation_issued, accreditation_expired, accreditation_president, accreditation_members,accreditation_family, accreditation_population,accreditation_below18,accreditation_belowm,accreditation_belowf, accreditation_area, accreditation_class, accreditation_programs, accreditation_problems, accreditation_coordinator, accreditation_remarks, association_state FROM tbl_accreditations", pcup_class.dbconnect.myconnect);

            pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

            while (pcup_class.Myreader.Read())
            {
                string accreditationRemarks = pcup_class.Myreader["accreditation_remarks"].ToString();
                //string accreditationbarangay = pcup_class.myreader["accreditation_barangay"].tostring();
                string accreditation_issued = pcup_class.Myreader["accreditation_issued"].ToString();
                string accreditation_expired = pcup_class.Myreader["accreditation_expired"].ToString();
                string association_stAte = pcup_class.Myreader["association_state"].ToString();

                DateTime issuedDate;
                DateTime expiredDate;

                if (association_stAte != "hidden")
                {
                    if (DateTime.TryParse(accreditation_issued, out issuedDate) && DateTime.TryParse(accreditation_expired, out expiredDate))
                    {
                        pcup_class.dgrec = new string[]
                        {
                            pcup_class.Myreader["accreditation_id"].ToString(),
                            pcup_class.Myreader["accreditation_name"].ToString(),
                            pcup_class.Myreader["accreditation_barangay"].ToString(),             
                            pcup_class.Myreader["accreditation_address"].ToString(),
                            pcup_class.Myreader["accreditation_contactperson"].ToString(),
                            pcup_class.Myreader["accreditation_phone"].ToString(),
                            pcup_class.Myreader["accreditation_number"].ToString(),
                            issuedDate.ToString("MMMM dd, yyyy"), // Format the issued date
                            expiredDate.ToString("MMMM dd, yyyy"),
                            pcup_class.Myreader["accreditation_president"].ToString(),
                            pcup_class.Myreader["accreditation_members"].ToString(),
                            pcup_class.Myreader["accreditation_family"].ToString(),
                            pcup_class.Myreader["accreditation_population"].ToString(),
                            pcup_class.Myreader["accreditation_below18"].ToString(),
                            pcup_class.Myreader["accreditation_belowm"].ToString(),
                            pcup_class.Myreader["accreditation_belowf"].ToString(),
                            pcup_class.Myreader["accreditation_area"].ToString(),
                            pcup_class.Myreader["accreditation_class"].ToString(),
                            pcup_class.Myreader["accreditation_programs"].ToString(),
                            pcup_class.Myreader["accreditation_problems"].ToString(),
                            pcup_class.Myreader["accreditation_coordinator"].ToString(),
                            accreditationRemarks,
                            association_stAte,
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
                        if (accreditationRemarks == "NEW")
                        {
                            dg_pending.Rows.Add(row); // Add to dg_approve
                        }
                        else if (accreditationRemarks == "APPROVED")
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

        public void RefreshData()
        {
            // Clear existing data in the DataGridView

            // Reload the data from your data source
            LoadData2();
        }
        private void DeleteSelectedRows()
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string accreditationId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete row with ID: {accreditationId}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {

                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_accreditations SET association_state = 'hidden' WHERE accreditation_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", accreditationId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Deleted Organization's information");


                        // Assuming deletion is successful, add the row to delete from DataGridView
                        rowsToDelete.Add(row);
                    }
                }
            }

            // Remove the selected rows from the DataGridView
            foreach (DataGridViewRow row in rowsToDelete)
            {
                // Assuming there's a column index for household_state, change the value in the DataGridView directly
                row.Cells["Column20"].Value = "hidden";
            }
            LoadData2();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Orgadd orgadd = new Orgadd(this, userSession);
            orgadd.btnSave.Visible = true;
            orgadd.update.Visible = false;
            orgadd.ShowDialog();
        }
        private void OpenTestForm(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Retrieve data from the selected row (adjust column indices accordingly)
                string accreditationId = selectedRow.Cells[1].Value?.ToString();
                string accreditationName = selectedRow.Cells[2].Value?.ToString();
                string accreditationBarangay = selectedRow.Cells[3].Value?.ToString();
                string accreditationAddress = selectedRow.Cells[4].Value?.ToString();
                string accreditationContactPerson = selectedRow.Cells[5].Value?.ToString();
                string accreditationPhone = selectedRow.Cells[6].Value?.ToString();
                string accreditationNumber = selectedRow.Cells[7].Value?.ToString();
                string accreditationIssued = selectedRow.Cells[8].Value?.ToString();
                string accreditationExpired = selectedRow.Cells[9].Value?.ToString();
                string accreditationPresident = selectedRow.Cells[10].Value?.ToString();
                string accreditationMembers = selectedRow.Cells[11].Value?.ToString();
                string accreditationFamily = selectedRow.Cells[12].Value?.ToString();
                string accreditationPopulation = selectedRow.Cells[13].Value?.ToString();
                string accreditationBelow18 = selectedRow.Cells[14].Value?.ToString();
                string accreditationBelowM = selectedRow.Cells[15].Value?.ToString();
                string accreditationBelowF = selectedRow.Cells[16].Value?.ToString();
                string accreditationArea = selectedRow.Cells[17].Value?.ToString();
                string accreditationClass = selectedRow.Cells[18].Value?.ToString();
                string accreditationPrograms = selectedRow.Cells[19].Value?.ToString();
                string accreditationProblems = selectedRow.Cells[20].Value?.ToString();
                string accreditationCoordinator = selectedRow.Cells[21].Value?.ToString();
                string accreditationRemarks = selectedRow.Cells[22].Value?.ToString();

                // Handle date parsing
                DateTime? issuedDate = null;
                DateTime? expiredDate = null;

                if (!string.IsNullOrEmpty(accreditationIssued) && DateTime.TryParse(accreditationIssued, out DateTime tempIssuedDate))
                {
                    issuedDate = tempIssuedDate;
                }

                if (!string.IsNullOrEmpty(accreditationExpired) && DateTime.TryParse(accreditationExpired, out DateTime tempExpiredDate))
                {
                    expiredDate = tempExpiredDate;
                }

                // Create a new instance of the Orgadd form   
                Orgadd orgaddForm = new Orgadd(this, userSession);

                // Populate the controls in the Orgadd form with data from the selected row
                orgaddForm.label14.Text = accreditationId;
                orgaddForm.name.Text = accreditationName;
                orgaddForm.barangaylist.Text = accreditationBarangay;
                orgaddForm.address.Text = accreditationAddress;
                orgaddForm.contactperson.Text = accreditationContactPerson;
                orgaddForm.phone.Text = accreditationPhone;
                orgaddForm.accnumber.Text = accreditationNumber;
                orgaddForm.issued.Value = issuedDate ?? DateTime.Now;
                orgaddForm.bunifuDatePicker2.Value = expiredDate ?? DateTime.Now;
                orgaddForm.president.Text = accreditationPresident;
                orgaddForm.members.Text = accreditationMembers;
                orgaddForm.families.Text = accreditationFamily;
                orgaddForm.population.Text = accreditationPopulation;
                orgaddForm.minors.Text = accreditationBelow18;
                orgaddForm.maleminor.Text = accreditationBelowM;
                orgaddForm.femaleminor.Text = accreditationBelowF;
                orgaddForm.size.Text = accreditationArea;
                orgaddForm.comboBox1.Text = accreditationClass;
                orgaddForm.programs.Text = accreditationPrograms;
                orgaddForm.bunifuTextBox9.Text = accreditationProblems;
                orgaddForm.officer.Text = accreditationCoordinator;
                orgaddForm.Remarks.Text = accreditationRemarks;

                orgaddForm.btnSave.Visible = false;
                orgaddForm.update.Visible = true;
                orgaddForm.ShowDialog();

                // Adjust controls visibility as needed in Orgadd form


                // Refresh data after the form is closed
                LoadData2();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_pending.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string accreditationId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete row with ID: {accreditationId}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_accreditations SET association_state = 'hidden' WHERE accreditation_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", accreditationId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Deleted Organization's information");
                        

                        // Assuming deletion is successful, add the row to delete from DataGridView
                        rowsToDelete.Add(row);
                    }
                }
            }

            // Remove the selected rows from the DataGridView
            foreach (DataGridViewRow row in rowsToDelete)
            {
                // Assuming there's a column index for household_state, change the value in the DataGridView directly
                row.Cells["Column21"].Value = "hidden";
            }
            LoadData2();
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

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            ApproveSelectedRows(dg_pending);
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = metroTextBox1.Text.Trim().ToLower(); // Get the search text and trim any leading/trailing spaces

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

        private void metroTextBox1_Click(object sender, EventArgs e)
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

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void deletepending_Click(object sender, EventArgs e)
        {
            DeleteSelectedRowspending();
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
        private void ApproveSelectedRows(DataGridView dataGridView)
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string accreditationId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to approve row with ID: {accreditationId}?", "Approval Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        // Update accreditation_remarks to 'APPROVED' in the database for dg_pending tab
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_accreditations SET accreditation_remarks = 'APPROVED' WHERE accreditation_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", accreditationId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Approved Organization's information");
                        

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

            LoadData2(); // Refresh the data in the DataGridView after removing the approved rows
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox1
            bool isChecked = checkBox1.Checked;

            // Iterate through rows in your DataGridView to set the checkbox value
            foreach (DataGridViewRow row in dg_pending.Rows) // Change dg_approve to your DataGridView name
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                // Update the value of the checkbox cell based on checkbox1's state
                checkBoxCell.Value = isChecked;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox1
            bool isChecked = checkBox2.Checked;

            // Iterate through rows in your DataGridView to set the checkbox value
            foreach (DataGridViewRow row in dg_approve.Rows) // Change dg_approve to your DataGridView name
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                // Update the value of the checkbox cell based on checkbox1's state
                checkBoxCell.Value = isChecked;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData2();
        }

        private void dg_approve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
