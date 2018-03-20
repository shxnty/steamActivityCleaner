using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace steamActivityCleaner
{
    static class Program
    {
        static int x = 0;
        static void Main(string[] args)
        {
            Console.Title = "Steam Activity Cleaner";
            Console.WriteLine("Starting program");
            Console.WriteLine();
            Console.WriteLine("Starting AppID 635240");
            var process = Process.Start("steam://run/635240/");
            while (!IsRunning("html5app_steam"))
                Thread.Sleep(10);
            Console.WriteLine("Starting AppID 635241");
            process = Process.Start("steam://run/635241/");
            while (!IsRunning("html5app_steam"))
                Thread.Sleep(10);
            Console.WriteLine("Starting AppID 635242");
            process = Process.Start("steam://run/635242/");
            while (!IsRunning("html5app_steam"))
                Thread.Sleep(10);
            Console.WriteLine();
            Console.Write("Activity cleared.");
            Console.Read();
        }

        static bool IsRunning(string proc)
        {
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.MainWindowTitle == "Steam Video Player")
                {
                    process.Kill();
                    return true;
                }
            }
            return false;
        }
    }
}
