using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mono.Options;

namespace NativeAdblock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        void AppStartup(object sender, StartupEventArgs e)
        {
            bool work = false;
            bool update = false;
            
            var options = new OptionSet
            {
                { "w|work", "replace hosts file with pre-generated file.  This flag should never be set by the user.", w => work = true },
                { "u|update", "silently checks for update and then exits, should be called via task scheduler.", u => update = true }
            };

            var admin = SystemUtils.IsAdmin();

            if ( work && !admin)
            {
                Logger.Fatal("application attempted to enter worker mode without elevating, exiting");
                Current.Shutdown();
            }
            else if(work)
            {
                Logger.Info("application starting in worker mode");
                StartCopy();
                Current.Shutdown();
            }

            Logger.Info("application starting in graphical mode");

            var window = new MainWindow();
            window.Show();

        }

        void StartCopy()
        {
            var sources = 
        }
    }
}
