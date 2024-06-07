using pcup.app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P.C.U.P.application
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserSession userSession = new UserSession(25, "drix", "drixmayor@gmail.com");

            Application.Run(new login());
            //Application.Run(new Leaderform(userSession));
        }
    }
}
