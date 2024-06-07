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
    public partial class frontpage : Form
    {
        public frontpage()
        {
            InitializeComponent();
            loadnumber();
            loadcrime();
            loadprogram();
            loaduser();
            chart3population();
        }
        private void chart3population()
        {
            try
            {
                ChartArea chartArea = chart3.ChartAreas[0];
                pcup_class.dbconnect = new dbconn(); // Creating an instance of the database connection
                pcup_class.dbconnect.Openconnection(); // Opening the database connection

                pcup_class.cmd = new MySqlCommand("SELECT leader_program, COUNT(*) AS TotalLeaders FROM tbl_leaders GROUP BY leader_program", pcup_class.dbconnect.myconnect);

                MySqlDataAdapter adapter = new MySqlDataAdapter(pcup_class.cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                // Clearing existing data in the chart, if needed
                chart3.Series.Clear();
                chart3.Series.Add("LeadersByBarangay");
                chart3.Series["LeadersByBarangay"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
                chartArea.AxisY.MajorGrid.Enabled = false;
                chartArea.AxisY.MinorGrid.Enabled = false;
                // Bind datatable to the chart
                chart3.DataSource = dataTable;

                // Set X and Y values
                chart3.Series["LeadersByBarangay"].XValueMember = "leader_program";
                chart3.Series["LeadersByBarangay"].YValueMembers = "TotalLeaders";

                // Set chart properties (if required)
                chart3.Series["LeadersByBarangay"].IsValueShownAsLabel = true; // Show labels with values

                // Update X-axis labels for NULL values
                foreach (var point in chart3.Series["LeadersByBarangay"].Points)
                {
                    if (point.XValue.ToString() == DBNull.Value.ToString())
                    {
                        point.AxisLabel = "No Programs Availed"; // Rename the label for NULL values
                    }
                }

                // Refreshing the chart to display the updated data
                chart3.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Displaying an error message if an exception occurs
            }
            finally
            {
                pcup_class.dbconnect.Closeconnection(); // Closing the database connection after using it
            }
        }
        private void loadnumber()
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            // Create a MySqlCommand to count accreditation_name in tbl_accreditations.
            pcup_class.cmd = new MySqlCommand("SELECT COUNT(accreditation_name) FROM tbl_accreditations", pcup_class.dbconnect.myconnect);

            // Execute the command and get the result.
            int count = Convert.ToInt32(pcup_class.cmd.ExecuteScalar());

            // Close the database connection.
            pcup_class.dbconnect.Closeconnection();

            // Display the count in label10.

            label5.Text = "" + count.ToString();


        }
        private void loadprogram()
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            // Create a MySqlCommand to count accreditation_name in tbl_accreditations.
            pcup_class.cmd = new MySqlCommand("SELECT COUNT(report_name) FROM tbl_reports", pcup_class.dbconnect.myconnect);

            // Execute the command and get the result.
            int count = Convert.ToInt32(pcup_class.cmd.ExecuteScalar());

            // Close the database connection.
            pcup_class.dbconnect.Closeconnection();

            // Display the count in label10.

            label6.Text = "" + count.ToString();

        }
        private void loadcrime()
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            // Create a MySqlCommand to count accreditation_name in tbl_accreditations.
            pcup_class.cmd = new MySqlCommand("SELECT COUNT(crime_violation) FROM tbl_crime", pcup_class.dbconnect.myconnect);

            // Execute the command and get the result.
            int count = Convert.ToInt32(pcup_class.cmd.ExecuteScalar());

            // Close the database connection.
            pcup_class.dbconnect.Closeconnection();

            // Display the count in label10.

            label10.Text = "" + count.ToString();
        }
        private void loaduser()
        {
            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            // Create a MySqlCommand to count accreditation_name in tbl_accreditations.
            pcup_class.cmd = new MySqlCommand("SELECT COUNT(user_name) FROM tbl_users", pcup_class.dbconnect.myconnect);

            // Execute the command and get the result.
            int count = Convert.ToInt32(pcup_class.cmd.ExecuteScalar());

            // Close the database connection.
            pcup_class.dbconnect.Closeconnection();

            // Display the count in label10.

            label8.Text = "" + count.ToString();
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
