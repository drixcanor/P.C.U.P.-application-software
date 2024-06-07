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
    public partial class Programform : Form
    {
        private UserSession session;
        public Programform(UserSession session)
        {
            InitializeComponent();
            LoadReport();
            chart3population();
            this.session = session;
            this.session.SessionDataAvailable += UserSession_SessionDataAvailable;
            CustomizeCharts();
        }
        private void CustomizeCharts()
        {
            // Customize the first chart
            CustomizeChart(chart3);

            // Customize the second chart
          
        }

        private void CustomizeChart(Chart chart)
        {
            if (chart.ChartAreas.Count > 0)
            {
                ChartArea chartArea = chart.ChartAreas[0];

                // Disable major and minor grid lines on the Y axis
                chartArea.AxisY.MajorGrid.Enabled = false;
                chartArea.AxisY.MinorGrid.Enabled = false;

                // Optionally, you can also disable grid lines on the X axis
                // chartArea.AxisX.MajorGrid.Enabled = false;
                // chartArea.AxisX.MinorGrid.Enabled = false;
            }
        }
        private void UserSession_SessionDataAvailable(object sender, EventArgs e)
        {
            // Retrieve username from UserSession
            string username = session.Usirname;

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
        public void RefreshData()
        {
            LoadReport();
        }
        private void LoadReport()
        {
            dg_programs.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand("SELECT report_id,report_name,report_facilitator, report_date, report_objective, report_barangay,report_remark ,report_state FROM tbl_reports", pcup_class.dbconnect.myconnect);

            pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

            while (pcup_class.Myreader.Read())
            {
                string date = pcup_class.Myreader["report_date"].ToString();
                string programState = pcup_class.Myreader["report_state"].ToString();

                DateTime Date;
                if (programState != "hidden")
                {
                    if (DateTime.TryParse(date, out Date))
                    {
                        pcup_class.dgrec = new string[]
                        {
                            pcup_class.Myreader["report_id"].ToString(),
                            pcup_class.Myreader["report_name"].ToString(),
                            pcup_class.Myreader["report_facilitator"].ToString(),
                            Date.ToString("MMMM dd, yyyy"),
                            pcup_class.Myreader["report_objective"].ToString(),
                            pcup_class.Myreader["report_barangay"].ToString(),
                            pcup_class.Myreader["report_remark"].ToString(),
                            programState,
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

                        dg_programs.Rows.Add(row);
                    }

                }
            }

            pcup_class.dbconnect.Closeconnection(); // Close the reader and connection here, outside the loop
        }
        private void Openreport(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string reportid = selectedRow.Cells[1].Value.ToString();
                string reportname = selectedRow.Cells[2].Value.ToString();
                string reportfacilitator = selectedRow.Cells[3].Value.ToString();
                string reportdate = selectedRow.Cells[4].Value.ToString();
                string reportobjective = selectedRow.Cells[5].Value.ToString();
                string reportbarangay = selectedRow.Cells[6].Value.ToString();
                string reportremarks = selectedRow.Cells[7].Value.ToString();



                // Create a new instance of the test form
                Programadd testForm = new Programadd(this, session);

                // Populate the controls in the test form with data from the selected row
                testForm.bunifuLabel2.Text = reportid; // Replace "name" with your control name
                testForm.facilitator.Text = reportname; // Replace "name" with your control name
                testForm.textBox1.Text = reportfacilitator; // Replace "barangaylist" with your control name
                testForm.Date.Value = DateTime.Parse(reportdate);
                testForm.objective.Text = reportobjective; // Replace "contactperson" with your control name
                testForm.barangaylist.Text = reportbarangay; // Replace "phone" with your control name
                testForm.remarks.Text = reportremarks;


                testForm.btnSave.Visible = false;
                testForm.update.Visible = true;
                testForm.ShowDialog();
                LoadReport();

            }
        }

        private void chart3population()
        {
            try
            {
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




        private void Programform_Load(object sender, EventArgs e)
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT Name FROM barangays", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the selectcrime ComboBox
                select.Items.Clear();

                // Add each distinct crime violation to the ComboBox
                while (pcup_class.Myreader.Read())
                {
                    string crimeViolation = pcup_class.Myreader.GetString("Name");
                    select.Items.Add(crimeViolation);
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

        private void btnAddreport_Click(object sender, EventArgs e)
        {
            Programadd memberadd = new Programadd(this, session);
            memberadd.btnSave.Visible = true;
            memberadd.update.Visible = false;
            memberadd.ShowDialog();
        }

        private void btneditreport_Click(object sender, EventArgs e)
        {
            int checkedRowCount = 0;
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in dg_programs.Rows)
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
                    Openreport(dg_programs);
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

        private void btndeletereport_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox1
            bool isChecked = checkBox1.Checked;

            // Iterate through rows in your DataGridView to set the checkbox value
            foreach (DataGridViewRow row in dg_programs.Rows) // Change dg_approve to your DataGridView name
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                // Update the value of the checkbox cell based on checkbox1's state
                checkBoxCell.Value = isChecked;
            }
        }
        private void DeleteSelectedRows()
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dg_programs.Rows)
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
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_reports SET report_state = 'hidden' WHERE report_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", householdId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(session.Usirname, "Deleted User's Information");
                        // Assuming update is successful, add the row to update in DataGridView
                        rowsToDelete.Add(row);
                    }
                }
            }

            // Update the selected rows in the DataGridView
            foreach (DataGridViewRow row in rowsToDelete)
            {
                // Assuming there's a column index for household_state, change the value in the DataGridView directly
                row.Cells["Column1"].Value = "hidden";
            }
            LoadReport();

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string searchValue = search.Text.Trim().ToLower(); // Get the search text and trim any leading/trailing spaces

            // Iterate through the rows of the dg_approve DataGridView
            foreach (DataGridViewRow row in dg_programs.Rows)
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

        private void select_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pcup_class.dbconnect = new dbconn(); // Creating an instance of the database connection
                pcup_class.dbconnect.Openconnection(); // Opening the database connection

                // Assuming the selected barangay is stored in barangaylist.SelectedItem.ToString()
                string selectedBarangay = select.SelectedItem.ToString();

                // Modify the query to include a WHERE clause based on the selected barangay
                pcup_class.cmd = new MySqlCommand("SELECT leader_program, leader_barangay, COUNT(*) AS TotalLeaders FROM tbl_leaders WHERE leader_barangay = @SelectedBarangay GROUP BY leader_program, leader_barangay", pcup_class.dbconnect.myconnect);

                // Add a parameter to the query for the selected barangay
                pcup_class.cmd.Parameters.AddWithValue("@SelectedBarangay", selectedBarangay);

                MySqlDataAdapter adapter = new MySqlDataAdapter(pcup_class.cmd);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                // Clearing existing data in the chart, if needed
                chart3.Series.Clear();
                chart3.Series.Add("Leaders");
                chart3.Series["Leaders"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;

                // Bind datatable to the chart
                chart3.DataSource = dataTable;

                // Set X and Y values
                chart3.Series["Leaders"].XValueMember = "leader_program";
                chart3.Series["Leaders"].YValueMembers = "TotalLeaders";

                // Set chart properties (if required)
                chart3.Series["Leaders"].IsValueShownAsLabel = true; // Show labels with values

                // Customize the appearance of the X-axis labels to be slightly vertical
                chart3.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
