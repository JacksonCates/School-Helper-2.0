using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Author: Jackson Cates
 * 
 * Last Update: 6/10/2020
 * 
 * Description:
 * This program is an upgrade from my previous school helper. The main upgrade I have implemented is storing the information via a database,
 * to allow the data to be store within a mobile app. There are other quality of life features that I have added such as allowing to edit the
 * course more freely, shorter loading times, and more error handling.
 * 
 */ 

namespace SchoolHelper2._0
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Adds the sync event
            Application.ApplicationExit += new EventHandler(SchoolHelperDatabase.Sync);

            // Loads the courses
            if (Courses.DatabaseLoad() == false)
            {
                // If it fails, load via filesystem
                Courses.FileSystemLoad();
            }

            // Runs the application
            Application.Run(new MainMenu());
        }

        
    }
}
