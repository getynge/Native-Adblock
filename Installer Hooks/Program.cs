using System;
using System.Diagnostics;

namespace Installer_Hooks
{
    class Program
    {

        static void UninstallHook()
        {
            Console.WriteLine("beginning uninstall hook");

            if (!EventLog.SourceExists("NativeAdblock", "."))
            {
                return;
            }

            EventLog.DeleteEventSource("NativeAdblock", ".");
        }

        static void InstallHook()
        {
            Console.WriteLine("beginning install hook");

            if (EventLog.SourceExists("NativeAdblock", "."))
            {
                return;
            }

            var sourceData = new EventSourceCreationData("NativeAdblock", "Native Adblock");
            sourceData.MachineName = ".";
            Console.WriteLine("creating event source");

            EventLog.CreateEventSource(sourceData);
        }
        static int Main(string[] args)
        {
            switch (args[0])
            {
                case "i":
                    InstallHook();
                    break;
                case "u":
                    UninstallHook();
                    break;
                default:
                    Console.WriteLine("Command run with invalid arguments, exiting...");
                    return 1;
            }
            Console.WriteLine("done");
            return 0;
        }
    }
}
