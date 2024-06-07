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
    public partial class Useradd : Form
    {
        private Userform form;
        private UserSession userSession;
        public Useradd(Userform form, UserSession userSession)
        {
            InitializeComponent();
            this.userSession = userSession;
            this.form = form;   
        }
        private void UserSession_SessionDataAvailable(object sender, EventArgs e)
        {
            // Retrieve username from UserSession
            string username = userSession.Usirname;

            // Use the username as needed in the Memberadd form
            // For example, log the username to the database
            LogToDatabase(username, "Saved User's information");
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
        private void PerformDatabaseAction(string query, bool isUpdate)
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

                if (isUpdate)
                {
                    pcup_class.cmd.Parameters.AddWithValue("@user_id", bunifuLabel2.Text);
                }

                pcup_class.cmd.Parameters.AddWithValue("@user_fullname", fname.Text);
                pcup_class.cmd.Parameters.AddWithValue("@user_name", username.Text);
                pcup_class.cmd.Parameters.AddWithValue("@user_password", password.Text);
                pcup_class.cmd.Parameters.AddWithValue("@user_email", email.Text);
                pcup_class.cmd.Parameters.AddWithValue("@user_phone", phone.Text);
                pcup_class.cmd.Parameters.AddWithValue("@user_type", role.Text);
                pcup_class.cmd.Parameters.AddWithValue("@user_barangay", barangaylist.Text);
                pcup_class.cmd.Parameters.AddWithValue("@user_remarks", Remarks.Text);

                int rowsAffected = pcup_class.cmd.ExecuteNonQuery();

                pcup_class.dbconnect.Closeconnection();

                if (rowsAffected > 0)
                {
                    string successMessage = isUpdate ? "Record updated successfully!" : "Record added successfully!";
                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Userform.RefreshData(this); error
                }
                else
                {
                    string errorMessage = isUpdate ? "Failed to update record. Please try again." : "Failed to add record. Please try again.";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Useradd_Load(object sender, EventArgs e)
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT Name FROM barangays", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                barangaylist.Items.Clear();

                while (pcup_class.Myreader.Read())
                {
                    string barangayName = pcup_class.Myreader.GetString("Name");
                    barangaylist.Items.Add(barangayName);
                }

                pcup_class.Myreader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                pcup_class.dbconnect.Closeconnection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("All entries are correct?", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            if (string.IsNullOrEmpty(username.Text) ||
                string.IsNullOrEmpty(password.Text) ||
                string.IsNullOrEmpty(email.Text) ||
                string.IsNullOrEmpty(phone.Text) ||
                string.IsNullOrEmpty(fname.Text) ||
                string.IsNullOrEmpty(barangaylist.Text))
            {
                MessageBox.Show("Please fill all the empty fields", "P.C.U.P. MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the user already exists in the database
            string checkQuery = "SELECT COUNT(*) FROM tbl_users WHERE user_name = @user_name";
            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, pcup_class.dbconnect.myconnect)) // Replace yourConnection with your actual MySqlConnection object
            {
                checkCommand.Parameters.AddWithValue("@user_name", username.Text);

                int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (count > 0)
                {
                    DialogResult overwriteResult = MessageBox.Show("This user already exists. Do you want to overwrite the existing record?", "User Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (overwriteResult == DialogResult.No)
                    {
                        // User chose not to overwrite, so return
                        return;
                    }
                    // User chose to overwrite, so proceed with update logic
                    string updateQuery = "UPDATE tbl_users SET user_fullname = @user_fullname, user_password = @user_password, user_email = @user_email, user_phone = @user_phone, user_type = @user_type, user_barangay = @user_barangay, user_remarks = @user_remarks WHERE user_name = @user_name";
                    PerformDatabaseAction(updateQuery, isUpdate: true);
                    this.Close();
                }
                else
                {
                    // User does not exist, proceed with inserting the new record
                    string insertQuery = "INSERT INTO tbl_users (user_fullname, user_name, user_password, user_email, user_phone, user_type, user_barangay, user_remarks) " +
                                         "VALUES (@user_fullname, @user_name, @user_password, @user_email, @user_phone, @user_type, @user_barangay, @user_remarks)";
                    PerformDatabaseAction(insertQuery, isUpdate: false);
                    this.Close();
                }
                this.Close();
            }

            userSession.OnSessionDataAvailable();
        }

        private void update_Click(object sender, EventArgs e)
        {
            string query = "UPDATE tbl_users " +
                "SET user_fullname = @user_fullname, " +
                "user_name = @user_name, " +
                "user_password = @user_password, " +
                "user_email = @user_email, " +
                "user_phone = @user_phone, " +
                "user_type = @user_type, " +
                "user_barangay = @user_barangay, " +
                "user_remarks = @user_remarks " +
                "WHERE user_id = @user_id";

            this.Close();
            PerformDatabaseAction(query, isUpdate: true);
            LogToDatabase(userSession.Usirname, "Updated User's information");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
