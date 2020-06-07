using System;
using System.Linq;
using System.Windows.Forms;

namespace SEQKARTBIO
{
    static class Program
    {
        public static int gMachineNumber;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
