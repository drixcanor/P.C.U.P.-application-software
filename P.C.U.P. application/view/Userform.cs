using MySql.Data.MySqlClient;
using pcup.app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace P.C.U.P.application
{
    public partial class Userform : Form
    {
        private UserSession userSession;
        public Userform(UserSession userSession)
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

        public void RefreshData()
        {
            // Clear existing data in the DataGridView

            // Reload the data from your data source
            LoadUserData();
        }

        private void LoadUserData()
        {
            dg_approve.Rows.Clear();
            dg_pending.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand("SELECT user_id, user_fullname, user_name, user_password, user_email, user_phone, user_type,  user_barangay, user_remarks, user_state FROM tbl_users", pcup_class.dbconnect.myconnect);

            pcup_class.Myreader = pcup_class.cmd.ExecuteReader();


            while (pcup_class.Myreader.Read())
            {
                string userBarangay = pcup_class.Myreader["user_barangay"].ToString();
                string userRemarks = pcup_class.Myreader["user_remarks"].ToString();
                string userstate = pcup_class.Myreader["user_state"].ToString();

                if (userstate != "hidden")
                {
                    pcup_class.dgrec = new string[]
                    {
                        pcup_class.Myreader["user_id"].ToString(),
                        pcup_class.Myreader["user_fullname"].ToString(),
                        pcup_class.Myreader["user_name"].ToString(),
                        pcup_class.Myreader["user_password"].ToString(),
                        pcup_class.Myreader["user_email"].ToString(),
                        pcup_class.Myreader["user_phone"].ToString(),
                        pcup_class.Myreader["user_type"].ToString(),
                        userBarangay,
                        userRemarks,
                        userstate
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
                    if (userRemarks == "NEW")
                    {
                        dg_pending.Rows.Add(row); // Add to dg_approve
                    }
                    else if (userRemarks == "APPROVED")
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
                string user_id = selectedRow.Cells[1].Value.ToString();
                string user_fullname = selectedRow.Cells[2].Value.ToString();
                string user_name = selectedRow.Cells[3].Value.ToString();
                string user_password = selectedRow.Cells[4].Value.ToString();
                string user_email = selectedRow.Cells[5].Value.ToString();
                string user_phone = selectedRow.Cells[6].Value.ToString();
                string user_type = selectedRow.Cells[7].Value.ToString();
                string user_barangay = selectedRow.Cells[8].Value.ToString();
                string user_remarks = selectedRow.Cells[9].Value.ToString();

                // Create a new instance of the Useradd form
                Useradd userAddForm = new Useradd(this, userSession);

                // Populate the controls in the Useradd form with data from the selected row
                userAddForm.bunifuLabel2.Text = user_id;
                userAddForm.fname.Text = user_fullname;
                userAddForm.username.Text = user_name;
                userAddForm.password.Text = user_password;
                userAddForm.email.Text = user_email;
                userAddForm.phone.Text = user_phone;
                userAddForm.role.Text = user_type;
                userAddForm.barangaylist.Text = user_barangay;
                userAddForm.Remarks.Text = user_remarks;


                userAddForm.btnSave.Visible = false;
                userAddForm.update.Visible = true;
                userAddForm.ShowDialog();
                LoadUserData();
            }
        }

        private void ApproveSelectedRows(DataGridView dataGridView)
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string userId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID
                    string userEmail = row.Cells[5].Value.ToString(); // Replace "ColumnName" with the actual column name
                                                                      // Change "user_email" to the actual column name

                    DialogResult result = MessageBox.Show($"Are you sure you want to approve row with ID: {userId}?", "Approval Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        // Update accreditation_remarks to 'APPROVED' in the database for dg_pending tab
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_users SET user_remarks = 'APPROVED' WHERE user_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", userId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Approved User's Information");

                        if (rowsAffected > 0)
                        {
                            // Send an email notification
                            SendApprovalNotification(userEmail);

                            // Assuming update is successful, mark the row for removal
                            rowsToRemove.Add(row);
                        }
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

        // Method to send an email notification
        private void SendApprovalNotification(string userEmail)
        {
            // Sender's email credentials (replace with your actual credentials)
            string senderEmail = "mayordrix@gmail.com";
            string appSpecificPassword = "rpqlvykkqmqgapws"; // Replace with your app-specific password

            // Configure SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, appSpecificPassword);

            // Create the email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(userEmail); // Set recipient's email address
            mailMessage.Subject = "User Approval Notification";
            mailMessage.Body = "Your account has been approved.";

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                MessageBox.Show("Approval notification sent via email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send approval notification: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Useradd useradd = new Useradd(this,userSession);    
            useradd.ShowDialog();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveSelectedRows(dg_pending);
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
        private void DeleteSelectedRowspending()
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_pending.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string userId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete row with ID: {userId}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Perform deletion from the database here using the accreditationId
                        // For example:
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_users SET user_status = 'hidden' WHERE user_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", userId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Deleted User's Information");

                        // Assuming deletion is successful, add the row to delete from DataGridView
                        rowsToDelete.Add(row);
                    }
                }
            }

            foreach (DataGridViewRow row in rowsToDelete)
            {
                // Assuming there's a column index for household_state, change the value in the DataGridView directly
                row.Cells["Column3"].Value = "hidden";
            }
            LoadUserData();
        }
        private void deletepending_Click(object sender, EventArgs e)
        {
            DeleteSelectedRowspending();
        }

        private void checkBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox1
            bool isChecked = checkBox1.Checked;

            // Iterate through rows in your DataGridView to set the checkbox value
            foreach (DataGridViewRow row in dg_approve.Rows) // Change dg_approve to your DataGridView name
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                // Update the value of the checkbox cell based on checkbox1's state
                checkBoxCell.Value = isChecked;
            }
        }

        private void Userform_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Useradd useradd = new Useradd(this, userSession); // Pass a reference to Form1
            useradd.btnSave.Visible = true;
            useradd.update.Visible = false;
            useradd.ShowDialog();
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
        private void DeleteSelectedRows()
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_approve.Rows)
            {
                if(Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string userId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete row with ID: {userId}?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Perform deletion from the database here using the accreditationId
                        // For example:
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_users SET user_state = 'hidden' WHERE user_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", userId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(userSession.Usirname, "Deleted User's Information");

                        // Assuming deletion is successful, add the row to delete from DataGridView
                        rowsToDelete.Add(row);
                    }
                }
            }

            foreach (DataGridViewRow row in rowsToDelete)
            {
                // Assuming there's a column index for household_state, change the value in the DataGridView directly
                row.Cells["Column1"].Value = "hidden";
            }
            LoadUserData();
        }

        private void deleteapprove_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox1
            bool isChecked = checkBox2.Checked;

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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
