using System;
using System.Diagnostics;
using System.Threading;

namespace steamActivityCleaner
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Steam Activity Cleaner";
            Console.Write("Starting AppID 635240");
            run("steam://run/635240/");;
            Console.Write("\nStarting AppID 635241");
            run("steam://run/635241/");
            Console.Write("\nStarting AppID 635242");
            run("steam://run/635242/");
            Console.Write("\nYour activity should be cleared, if it has not been run the program again.");
            Thread.Sleep(10000);
            Environment.Exit(0);
        }

        static void run(string proc)
        {
            Process.Start(proc);
            bool isRunning = false;
            while (!isRunning)
            {
                Process[] processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    if (process.MainWindowTitle == "Steam Video Player")
                    {
                        process.Kill();
                        isRunning = true;
                        break;
                    }
                }
                Thread.Sleep(10);
            } 
        }
    }
}
