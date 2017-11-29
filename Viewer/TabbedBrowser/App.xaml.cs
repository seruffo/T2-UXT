using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Reflection;
using System.IO;

namespace Lades.WebTracer
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

        public static ViewerFull vieweFull;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Splash splash = new Splash();
            splash.Show();
        }
    }
}
