using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //  Application.EnableVisualStyles();

            //  //Application.SetCompatibleTextRenderingDefault(false);

            //DevExpress.LookAndFeel.DefaultLookAndFeel = false
            //  DevExpress.Skins.SkinManager.EnableFormSkins();

            //  //System.Diagnostics.Process.Start(@"D:\New folder\Foxit Reader 720\FoxitReader720.0722_enu_Setup.exe");

            //  DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin; 

            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();


            //
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Sharp");

            //System.Diagnostics.Process.Start(@"D:\New folder\IsoBuster 2.8.5\isobuster_all_lang.exe");

            Application.Run(new frmLogincs());
        }
    }
}
