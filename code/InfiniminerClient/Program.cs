using System;
using System.Diagnostics;

namespace Infiniminer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //InfiniminerMessageBox.Show("Test :)");
            if (Debugger.IsAttached)
            {
                using (InfiniminerGame game = new InfiniminerGame(args))
                {
                    game.Run();
                }
            }
            else
            {
                using (InfiniminerGame game = new InfiniminerGame(args))
                {
                    try
                    {
                        game.Run();
                    }
                    catch (Exception e)
                    {
                        //System.Windows.Forms.MessageBox.Show(e.Message + "\r\n\r\n" + e.StackTrace);
                        InfiniminerMessageBox.Show(e.Message + "\r\n\r\n" + e.StackTrace);
                    }
                }
            }
            
        }
    }
}

