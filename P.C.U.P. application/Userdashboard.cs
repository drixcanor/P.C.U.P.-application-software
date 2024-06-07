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
    public partial class Userdashboard : Form
    {
        private const int TransitionIncrement = 10;
        bool sidebarExpand;
        bool settingscontainer;
        private UserSession session;
        public Userdashboard(UserSession session)
        {
            InitializeComponent();
            this.session = session;
            MaximizeForm();

            label2.Text = $" {session.Usirname}";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void MaximizeForm()
        {
            // Get the working area of the screen
            Rectangle workingArea = Screen.GetWorkingArea(this);

            // Set the form's size and location to fit the working area
            this.Size = new Size(workingArea.Width, workingArea.Height);
            this.Location = new Point(workingArea.Left, workingArea.Top);

            // Adjust the size and location of panel5 to fit the remaining area after the navigation bar
            int navigationBarHeight = flowLayoutPanel1.Height; // Assuming panel4 is the navigation bar
            panel5.Size = new Size(panel5.Width, workingArea.Height - navigationBarHeight);
            panel5.Location = new Point(panel5.Left, navigationBarHeight);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            timer3.Start();
            Loadform(new frontpage());
            label14.Text = "Dashboard";
        }
        private void Loadform(object Form)
        {
            if (this.panel5.Controls.Count > 0)
                this.panel5.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel5.Controls.Add(f);
            this.panel5.Tag = f;
            f.Show();
        }
        private void program_Click(object sender, EventArgs e)
        {
            Loadform(new Programform(session));
            label14.Text = "Program Chart";
        }

        private void Crimes_Click(object sender, EventArgs e)
        {
            Loadform(new Crimeform(session));
            label14.Text = "Crime Chart";
        }

        private void pregnancy_Click(object sender, EventArgs e)
        {
            Loadform(new Pregnantform());
            label14.Text = "Pregnant Chart";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Loadform(new Orgform(session));
            label14.Text = "Organization Form";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loadform(new Leaderform(session));
            label14.Text = "Leader Form";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loadform(new Householdform(session));
            label14.Text = "Household Form";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                if (flowLayoutPanel1.Width > flowLayoutPanel1.MinimumSize.Width)
                {
                    flowLayoutPanel1.Width -= TransitionIncrement;
                }
                else
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                if (flowLayoutPanel1.Width < flowLayoutPanel1.MaximumSize.Width)
                {
                    flowLayoutPanel1.Width += TransitionIncrement;
                }
                else
                {
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                if (panel6.Height > panel6.MinimumSize.Height)
                {
                    panel6.Height -= TransitionIncrement;
                }
                else
                {
                    sidebarExpand = false;
                    timer3.Stop();
                }
            }
            else
            {
                if (panel6.Height < panel6.MaximumSize.Height)
                {
                    panel6.Height += TransitionIncrement;
                }
                else
                {
                    sidebarExpand = true;
                    timer3.Stop();
                }
            }
        }

        private void Userdashboard_Load(object sender, EventArgs e)
        {
            MaximizeForm();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Optionally, you can show a confirmation dialog before logging out
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Perform logout actions
                // For example, close the current form and show the login form

                // Close the maindashboard form
                this.Close();

                // Show the login form (assuming LoginForm is the name of your login form)
                login loginForm = new  login();
                loginForm.Show();
            }
            // else block is empty, which means no action is taken if the user clicks No
        }
    }
}
