using MetroFramework.Controls;
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
    public partial class logs : Form
    {
        public logs()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            crimedg.Rows.Clear();

            pcup_class.dbconnect = new dbconn();
            pcup_class.dbconnect.Openconnection();

            pcup_class.cmd = new MySqlCommand("SELECT *, DATE_FORMAT(logs_date, '%M %d, %Y %H:%i:%s') AS formatted_date FROM tbl_logs ORDER BY logs_date DESC", pcup_class.dbconnect.myconnect);
            pcup_class.Myreader = pcup_class.cmd.ExecuteReader();

            while (pcup_class.Myreader.Read())
            {
                pcup_class.dgrec = new string[]
                {
                pcup_class.Myreader["ID"].ToString(),
                pcup_class.Myreader["logs_username"].ToString(),
                pcup_class.Myreader["logs_content"].ToString(),
                pcup_class.Myreader["formatted_date"].ToString(), // Use the formatted date
                };

                crimedg.Rows.Add(pcup_class.dgrec);
            }

            pcup_class.Myreader.Close(); // Close the reader after using it
        }
        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            string searchValue = metroTextBox2.Text.Trim().ToLower(); // Get the search text and trim any leading/trailing spaces

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
    }
}
