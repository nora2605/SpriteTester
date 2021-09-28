using System;
using System.Windows.Forms;

namespace SpriteTester
{
    static class Program
    {
        /// <summary>
        /// Main Entry Point for the Application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpriteSetupForm());
        }
    }
}
