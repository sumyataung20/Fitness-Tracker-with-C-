// namespace FitnessTracker;

// static class Program
// {
//     /// <summary>
//     ///  The main entry point for the application.
//     /// </summary>
//     [STAThread]
//     static void Main()
//     {
//         // To customize application configuration such as set high DPI settings or default font,
//         // see https://aka.ms/applicationconfiguration.
//         ApplicationConfiguration.Initialize();
//         Application.Run(new Form1());
//     }    
// }

// using System;
// using System.Windows.Forms;
// using MySql.Data.MySqlClient;
// using FitnessTracker.Class;

// namespace FitnessTracker
// {
//     static class Program
//     {
//         [STAThread]
//         static void Main()
//         {
//             try
//             {
//                 using (var conn = Database.GetConnection())
//                 {
//                     conn.Open();
//                     MessageBox.Show("Database connection successful!");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 MessageBox.Show("Database connection failed: " + ex.Message);
//             }

//             Application.EnableVisualStyles();
//             Application.SetCompatibleTextRenderingDefault(false);
//             Application.Run(new Form1());
//         }
//     }
// }

using System;
using System.Windows.Forms;
using FitnessTracker.Forms;

namespace FitnessTracker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new RegisterForm()); // Start with Register
        }
    }
}
