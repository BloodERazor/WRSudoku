using System;
using System.Windows.Forms;

namespace WRSudokuRedo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run User Preference Check
            Application.Run(new Sudoku_User_Prefs());
        }
    }
}
