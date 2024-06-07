using MySql.Data.MySqlClient;
using pcup.app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace P.C.U.P.application
{
    public partial class Pregnantform : Form
    {
        public Pregnantform()
        {
            InitializeComponent();
            CustomizeCharts();
        }
        private void CustomizeCharts()
        {
            // Customize the first chart
            CustomizeChart(chart1);

            // Customize the second chart
            CustomizeChart(chart2);
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
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Pregnantform_Load(object sender, EventArgs e)
        {
            pregnancy();
            LastPregnancyChart();
        }
        private void pregnancy()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT household_barangay, SUM(children) AS ChildrenCount, SUM(CASE WHEN pregnant = 'YES' THEN 1 ELSE 0 END) AS PregnantCount FROM tbl_households GROUP BY household_barangay", pcup_class.dbconnect.myconnect);

                // Create a data adapter
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(pcup_class.cmd);

                // Create a DataTable to hold the data
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query results
                dataAdapter.Fill(dataTable);

                // Clear existing series
                chart1.Series.Clear();

                // Set chart titles and axes labels
                chart1.Titles.Clear();
                chart1.Titles.Add("Pregnancy Data");

                // Create a new series for children count in the chart
                Series childrenSeries = new Series("ChildrenCount");
                childrenSeries.ChartType = SeriesChartType.StackedColumn;

                // Create a new series for pregnant count in the chart
                Series pregnantSeries = new Series("PregnantCount");
                pregnantSeries.ChartType = SeriesChartType.StackedColumn;

                // Loop through each row in the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    string barangay = row["household_barangay"].ToString();
                    int childrenCount = Convert.ToInt32(row["ChildrenCount"]);
                    int pregnantCount = Convert.ToInt32(row["PregnantCount"]);

                    // Add data points to the series
                    childrenSeries.Points.AddXY(barangay, childrenCount);
                    pregnantSeries.Points.AddXY(barangay, pregnantCount);
                }

                // Add the series to the chart
                chart1.Series.Add(childrenSeries);
                chart1.Series.Add(pregnantSeries);

                // Set X-axis and Y-axis labels (if required)
                chart1.ChartAreas[0].AxisX.Title = "Household Barangay";
                chart1.ChartAreas[0].AxisY.Title = "Count";

                // Refresh the chart
                chart1.DataBind();
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

        private void LastPregnancyChart()
        {
            try
            {
                pcup_class.dbconnect = new dbconn();
                pcup_class.dbconnect.Openconnection();

                pcup_class.cmd = new MySqlCommand("SELECT last_preg FROM tbl_households WHERE household_state <> 'hidden'", pcup_class.dbconnect.myconnect);

                // Create a data adapter
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(pcup_class.cmd);

                // Create a DataTable to hold the data
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query results
                dataAdapter.Fill(dataTable);

                // Create a dictionary to store date counts
                Dictionary<DateTime, int> dateCounts = new Dictionary<DateTime, int>();

                // Loop through each row in the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    string lastPregnancyStr = row["last_preg"].ToString();
                    DateTime lastPregnancy;

                    // Attempt to parse the date, handling invalid formats gracefully
                    if (DateTime.TryParseExact(lastPregnancyStr, "MMMM dd, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastPregnancy))
                    {
                        // Increment the count for each date occurrence in the dictionary
                        if (dateCounts.ContainsKey(lastPregnancy))
                        {
                            dateCounts[lastPregnancy]++;
                        }
                        else
                        {
                            dateCounts[lastPregnancy] = 1;
                        }
                    }
                    else
                    {
                        // Handle invalid date format or empty strings here
                        // You can log the error or take appropriate action
                        Console.WriteLine("Invalid date format: " + lastPregnancyStr);
                    }
                }

                // Clear existing series in the chart
                chart2.Series.Clear();

                // Set chart titles and axes labels
                chart2.Titles.Clear();
                chart2.Titles.Add("Last Pregnancy Data");

                // Create a new series for the chart
                Series series = new Series("LastPregnancy");
                series.ChartType = SeriesChartType.SplineArea;

                // Add the date counts to the series as data points
                foreach (var dateCount in dateCounts)
                {
                    series.Points.AddXY(dateCount.Key, dateCount.Value);
                }

                // Add the series to the chart
                chart2.Series.Add(series);

                // Set X-axis and Y-axis labels (if required)
                chart2.ChartAreas[0].AxisX.Title = "Last Pregnancy Date";
                chart2.ChartAreas[0].AxisY.Title = "Occurrences"; // Replace with an appropriate label

                // Bind the data to the chart
                chart2.DataBind();
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

    }

}
