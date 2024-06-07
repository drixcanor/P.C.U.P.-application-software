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
    public partial class login : Form
    {
        private maindashboard maindashboard;
        private UserSession session;
        public login()
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
            
            signup signupForm = new signup();
            signupForm.Show(); ;
            
        }

        private void btnSign_in_Click(object sender, EventArgs e)
        {
            string username = user_name.Text;
            string password = user_password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            else
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                string query = "SELECT user_id, user_name, user_email, user_password, user_remarks, user_type FROM tbl_users WHERE user_name = @username AND user_password = @password";

                pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

                pcup_class.cmd.Parameters.AddWithValue("@username", username);
                pcup_class.cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = pcup_class.cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32("user_id");
                        string userName = reader.GetString("user_name");
                        string userEmail = reader.GetString("user_email");
                        string userRemarks = reader.GetString("user_remarks");
                        string userType = reader.GetString("user_type");

                        if (userRemarks == "APPROVED")
                        {
                            pcup_class.dbconnect = new dbconn();
                            pcup_class.dbconnect.Openconnection();

                            string query2 = "INSERT INTO tbl_logs (logs_username, logs_content, logs_date)" +
                                            "VALUES (@logs_username, @logs_content, @logs_date)";

                            pcup_class.cmd = new MySqlCommand(query2, pcup_class.dbconnect.myconnect);
                            pcup_class.cmd.Parameters.AddWithValue("@logs_username", userName);
                            pcup_class.cmd.Parameters.AddWithValue("@logs_content", "Successfully login");
                            pcup_class.cmd.Parameters.AddWithValue("@logs_date", DateTime.Now);
                            pcup_class.cmd.ExecuteNonQuery(); // Use ExecuteNonQuery for INSERT

                            MessageBox.Show("Login Successful!", "WELCOME USER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            

                            if (userType == "CLIENT")
                            {
                                UserSession userSession = new UserSession(userId, username, userEmail);
                                Userdashboard userForm = new Userdashboard(userSession);
                                userForm.Show();
                            }
                            else
                            {
                                UserSession userSession = new UserSession(userId, username, userEmail);
                                maindashboard mainForm = new maindashboard(userSession);
                                mainForm.Show();
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("WAIT FOR ADMIN APPROVAL!", "USER NOT APPROVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
                
                // Close the connection when done
                pcup_class.dbconnect.Closeconnection();
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

        private void user_password_Enter(object sender, EventArgs e)
        {
           
        }

        private void user_password_Click(object sender, EventArgs e)
        {

        }

        private void user_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Call the btnSign_in_Click method when Enter key is pressed
                btnSign_in_Click(sender, e);
            }
        }
    }
}
