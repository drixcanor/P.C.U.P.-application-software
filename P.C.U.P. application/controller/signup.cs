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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
            login loginForm = new login();
            loginForm.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            signup signupForm = new signup();
            signupForm.Show();
            
        }

        private void btnSign_up_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(user_name.Text) ||
                string.IsNullOrWhiteSpace(user_password.Text) ||
                string.IsNullOrWhiteSpace(user_email.Text) ||
                string.IsNullOrWhiteSpace(user_phone.Text) ||
                string.IsNullOrWhiteSpace(full_name.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(user_email.Text))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Register the user with "remarks" set to "NEW"
            string username = user_name.Text;
            string password = user_password.Text;
            string email = user_email.Text;
            string phone = user_phone.Text;
            string fullName = full_name.Text;
            string remarks = "NEW";

            if (RegisterUser(username, password, email, phone, fullName, remarks))
            {
                MessageBox.Show("WAIT FOR ADMIN APPROVAL AND CHECK YOUR EMAIL!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Clear all input fields
                user_name.Text = "";
                user_password.Text = "";
                user_email.Text = "";
                user_phone.Text = "";
                full_name.Text = "";
            }
            else
            {
                MessageBox.Show("Error registering the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Clear all input fields
                user_name.Text = "";
                user_password.Text = "";
                user_email.Text = "";
                user_phone.Text = "";
                full_name.Text = "";
            }
        }

        private bool RegisterUser(string username, string password, string email, string phone, string fullName, string userRemarks)
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                // Check if the username or email already exists
                pcup_class.cmd = new MySqlCommand("SELECT COUNT(*) FROM tbl_users WHERE user_name = @Username OR user_email = @Email", pcup_class.dbconnect.myconnect);
                pcup_class.cmd.Parameters.AddWithValue("@Username", username);
                pcup_class.cmd.Parameters.AddWithValue("@Email", email);

                int userCount = Convert.ToInt32(pcup_class.cmd.ExecuteScalar());

                if (userCount > 0)
                {
                    return false; // Username or email already exists
                }

                // Insert the new user
                pcup_class.cmd = new MySqlCommand("INSERT INTO tbl_users (user_name, user_password, user_email, user_phone, user_fullname, user_remarks) VALUES (@Username, @Password, @Email, @Phone, @FullName, @UserRemarks)", pcup_class.dbconnect.myconnect);

                pcup_class.cmd.Parameters.AddWithValue("@Username", username);
                pcup_class.cmd.Parameters.AddWithValue("@Password", password);
                pcup_class.cmd.Parameters.AddWithValue("@Email", email);
                pcup_class.cmd.Parameters.AddWithValue("@Phone", phone);
                pcup_class.cmd.Parameters.AddWithValue("@FullName", fullName);
                pcup_class.cmd.Parameters.AddWithValue("@UserRemarks", userRemarks);

                int rowsAffected = pcup_class.cmd.ExecuteNonQuery();

                pcup_class.dbconnect.Closeconnection();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Checkbox is checked, show the password characters
                user_password.PasswordChar = '\0'; // Set to '\0' to show the actual characters
            }
            else
            {
                // Checkbox is unchecked, hide the password characters
                user_password.PasswordChar = '*'; // Set to '*' to display '*' characters
            }
        }
    }
}
