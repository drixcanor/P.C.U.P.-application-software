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
    public partial class Crimeform : Form
    {
        private UserSession session;
        public Crimeform(UserSession session)
        {
            InitializeComponent();
            Loadcrime();
            this.session = session;
            this.session.SessionDataAvailable += UserSession_SessionDataAvailable;
            CustomizeChart();
        }
        private void CustomizeChart()
        {
            // Assuming you have a Chart control named 'chart1'
            ChartArea chartArea = crimechart.ChartAreas[0];

            // Disable major and minor grid lines on the Y axis
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.MinorGrid.Enabled = false;
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

            Loadcrime();
        }
       

        private void addcrime_Click(object sender, EventArgs e)
        {
            Crimeadd crimeadd = new Crimeadd(this);
            crimeadd.btnSave.Visible = true;
            crimeadd.update.Visible = false;
            crimeadd.ShowDialog();
        }
        private void Loadcrime()
        {
            crimedg.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand("SELECT crime_id, crime_violation, crime_date, crime_victim,crime_perpetrator, crime_barangay,crime_remark,crime_state FROM tbl_crime", pcup_class.dbconnect.myconnect);

            pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

            while (pcup_class.Myreader.Read())
            {
                string crimdate = pcup_class.Myreader["crime_date"].ToString();
                string crimestate = pcup_class.Myreader["crime_state"].ToString();

                DateTime cdate;

                if (crimestate != "hidden")
                {   

                    if (DateTime.TryParse(crimdate, out cdate))
                    {
                        pcup_class.dgrec = new string[]
                        {
                                pcup_class.Myreader["crime_id"].ToString(),
                                pcup_class.Myreader["crime_violation"].ToString(),
                                cdate.ToString("MMMM dd, yyyy"),
                                pcup_class.Myreader["crime_victim"].ToString(),
                                pcup_class.Myreader["crime_perpetrator"].ToString(),
                                pcup_class.Myreader["crime_barangay"].ToString(),
                                pcup_class.Myreader["crime_remark"].ToString(),
                                crimestate,
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

                        crimedg.Rows.Add(row);
                    }
                }

            }

                // Close the reader and connection here, outside the loop
        }


        private void editcrime_Click(object sender, EventArgs e)
        {
            int checkedRowCount = 0;
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in crimedg.Rows)
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
                    Opencrime(crimedg);
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

        private void deletecrime_Click(object sender, EventArgs e)
        {
            DeleteSelectedRowscrime();
        }
        private void Opencrime(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string crimeid = selectedRow.Cells[1].Value.ToString();
                string crimeviolation = selectedRow.Cells[2].Value.ToString();
                string crimedate = selectedRow.Cells[3].Value.ToString();
                string crimevictim = selectedRow.Cells[4].Value.ToString();
                string crimeperpetrator = selectedRow.Cells[5].Value.ToString();
                string crimebarangay = selectedRow.Cells[6].Value.ToString();
                string crimeremark = selectedRow.Cells[7].Value.ToString();

                // Create a new instance of the test form
                Crimeadd testForm = new Crimeadd(this);

                // Populate the controls in the test form with data from the selected row
                testForm.bunifuLabel2.Text = crimeid; // Replace "name" with your control name
                testForm.violation.Text = crimeviolation; // Replace "name" with your control name
                testForm.date.Text = crimedate; // Replace "barangaylist" with your control name
                testForm.victim.Text = crimevictim; // Replace "address" with your control name
                testForm.suspect.Text = crimeperpetrator; // Replace "contactperson" with your control name
                testForm.barangaylist.Text = crimebarangay; // Replace "phone" with your control name
                testForm.remark.Text = crimeremark; // Replace "phone" with your control name



                testForm.btnSave.Visible = false;
                testForm.update.Visible = true;
                testForm.ShowDialog();
                Loadcrime();

            }
        }
        private void PopulateChart()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT crime_violation, COUNT(*) AS TotalCrimes FROM tbl_crime GROUP BY crime_violation ", pcup_class.dbconnect.myconnect);

                MySqlDataAdapter adapter = new MySqlDataAdapter(pcup_class.cmd);
                DataTable dataTable = new DataTable();


                adapter.Fill(dataTable);

                // Clearing existing data in the chart, if needed
                crimechart.Series.Clear();
                crimechart.Series.Add("Crimes");
                crimechart.Series["Crimes"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;

                // Bind datatable to the chart
                crimechart.DataSource = dataTable;

                // Set X and Y values
                crimechart.Series["Crimes"].XValueMember = "crime_violation";
                crimechart.Series["Crimes"].YValueMembers = "TotalCrimes";

                // Set chart properties (if required)
                crimechart.Series["Crimes"].IsValueShownAsLabel = true; // Show labels with values

                // Customize the appearance of the X-axis labels to be slightly vertical
                crimechart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                // Refreshing the chart to display the updated data
                crimechart.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection after use
                pcup_class.dbconnect.Closeconnection();
            }
        }
        private void DeleteSelectedRowscrime()
        {
            List<DataGridViewRow> rowsToUpdate = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in crimedg.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)) // Assuming the checkbox column is at index 0
                {
                    string reportId = row.Cells[1].Value.ToString(); // Change index to the column holding the ID

                    DialogResult result = MessageBox.Show($"Are you sure you want to Delete row with ID: {reportId}?", "Hide Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Update the database column "crime_state" to "hidden"
                        pcup_class.dbconnect = new dbconn();
                        pcup_class.dbconnect.Openconnection();
                        pcup_class.cmd = new MySqlCommand("UPDATE tbl_crime SET crime_state = 'hidden' WHERE crime_id = @id", pcup_class.dbconnect.myconnect);
                        pcup_class.cmd.Parameters.AddWithValue("@id", reportId);
                        int rowsAffected = pcup_class.cmd.ExecuteNonQuery();
                        pcup_class.dbconnect.Closeconnection();
                        LogToDatabase(session.Usirname, "Deleted User's Information");

                        // Assuming update is successful, add the row to update in DataGridView
                        rowsToUpdate.Add(row);
                    }
                }
            }

            // Update the DataGridView to reflect the changes
            foreach (DataGridViewRow row in rowsToUpdate)
            {
                // Update the value of the "crime_state" column in the DataGridView
                row.Cells["Column1"].Value = "hidden";
            }
            Loadcrime();

        }

        private void Crimeform_Load(object sender, EventArgs e)
        {

            PopulateChart();

            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT Name FROM barangays", pcup_class.dbconnect.myconnect);
                pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

                // Clear existing items in the selectcrime ComboBox
                selectcrime.Items.Clear();

                // Add each distinct crime violation to the ComboBox
                while (pcup_class.Myreader.Read())
                {
                    string crimeViolation = pcup_class.Myreader.GetString("Name");
                    selectcrime.Items.Add(crimeViolation);
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

        private void searchcrime_Click(object sender, EventArgs e)
        {
            string searchValue = searchcrime.Text.Trim().ToLower(); // Get the search text and trim any leading/trailing spaces

            // Iterate through the rows of the dg_approve DataGridView
            foreach (DataGridViewRow row in crimedg.Rows)
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checked state of checkbox1
            bool isChecked = checkBox2.Checked;

            // Iterate through rows in your DataGridView to set the checkbox value
            foreach (DataGridViewRow row in crimedg.Rows) // Change dg_approve to your DataGridView name
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell; // Assuming the checkbox column is at index 0

                // Update the value of the checkbox cell based on checkbox1's state
                checkBoxCell.Value = isChecked;
            }
        }
       
        

        private void selectcrime_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                pcup_class.dbconnect = new dbconn(); // Creating an instance of the database connection
                pcup_class.dbconnect.Openconnection(); // Opening the database connection

                // Assuming the selected crime is stored in selectcrime.SelectedItem.ToString()
                string selectedCrime = selectcrime.SelectedItem.ToString();

                // Modify the query to count occurrences of crime_violation for the selected crime
                pcup_class.cmd = new MySqlCommand("SELECT crime_violation,crime_barangay, COUNT(*) AS TotalCrimes FROM tbl_crime WHERE crime_barangay = @SelectedCrime GROUP BY crime_violation , crime_barangay", pcup_class.dbconnect.myconnect);

                // Add a parameter to the query for the selected crime
                pcup_class.cmd.Parameters.AddWithValue("@SelectedCrime", selectedCrime);


                MySqlDataAdapter adapter = new MySqlDataAdapter(pcup_class.cmd);
                DataTable dataTable = new DataTable();


                adapter.Fill(dataTable);

                // Clearing existing data in the chart, if needed
                crimechart.Series.Clear();
                crimechart.Series.Add("Crimes");
                crimechart.Series["Crimes"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;

                // Bind datatable to the chart
                crimechart.DataSource = dataTable;

                // Set X and Y values
                crimechart.Series["Crimes"].XValueMember = "crime_violation";
                crimechart.Series["Crimes"].YValueMembers = "TotalCrimes";

                // Set chart properties (if required)
                crimechart.Series["Crimes"].IsValueShownAsLabel = true; // Show labels with values

                // Customize the appearance of the X-axis labels to be slightly vertical
                crimechart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                // Refreshing the chart to display the updated data
                crimechart.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                pcup_class.dbconnect.Closeconnection(); // Closing the database connection after using it
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loadcrime();
        }
    }
}
