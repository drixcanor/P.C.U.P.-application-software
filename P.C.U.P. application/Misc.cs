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
    public partial class Misc : Form
    {
        public Misc()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Initialize and open the database connection
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            // Declare and initialize the query
            string query = "INSERT INTO Barangays (BarangayID,Name) VALUES (@BarangayID,@Name)";

            // Create a new MySqlCommand
            pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

            // Add parameter to the query
            pcup_class.cmd.Parameters.AddWithValue("@BarangayID", idtxt.Text);
            pcup_class.cmd.Parameters.AddWithValue("@Name", brgy.Text);

            try
            {
                // Execute the query
                pcup_class.cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted successfully.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                pcup_class.dbconnect.Closeconnection();
            }
        }
        private void LoadUserData()
        {
            // Clear existing data in the DataGridView
            dg_approve.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            string query = "SELECT BarangayID, Name FROM barangays";
            pcup_class.cmd = new MySqlCommand(query, pcup_class.dbconnect.myconnect);

            using (pcup_class.Myreader = pcup_class.cmd.ExecuteReader())
            {
                while (pcup_class.Myreader.Read())
                {
                    string[] row = new string[]
                    {
                        pcup_class.Myreader["BarangayID"].ToString(),
                        pcup_class.Myreader["Name"].ToString()
                    };

                    dg_approve.Rows.Add(row);
                }
            }

            pcup_class.dbconnect.Closeconnection();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void Misc_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void brgy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}