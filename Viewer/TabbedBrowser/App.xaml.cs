using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Reflection;
using System.IO;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ExeDir { get; private set; }
        public static string CurrentTrace { get; set; }

        public static List<string> CurrentTraceList = new List<string>();
        public static string CurrentTraceFolder { get; set; }

        public static int maxClicks = 0;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Get the main exe folder
            string exePath = Assembly.GetExecutingAssembly().GetName().CodeBase;
            exePath = new Uri(exePath).LocalPath;
            ExeDir = Path.GetDirectoryName(exePath);
            Console.WriteLine("exedir "+ExeDir);
            //Clean up cache folders for older versions
            EO.WebEngine.Engine.CleanUpCacheFolders(WebEngine.CacheFolderCleanUpPolicy.OlderVersionOnly);

            //Set remote debugging port. You only need this line if you
            //wish to use the remote debugging feature. You may need to
            //use a different port if this port is already in use on your
            //system
            EO.WebEngine.Engine.Default.Options.RemoteDebugPort = 1234;

            //Register custom schemes
            EO.WebEngine.Engine.Default.Options.RegisterCustomSchemes("sample");

            Splash splash = new Splash();
            splash.Show();
        }
    }
}
