using System;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace WinFormsmedia_tech
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Core.Initialize();
            ApplicationConfiguration.Initialize();
            Application.Run(new AccueilForm());
        }
    }
}
  
           