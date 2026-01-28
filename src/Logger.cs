using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.accounts
{
    internal static class Logger
    {
        private static readonly string LogFile = Path.Combine(AppContext.BaseDirectory, "log.txt");
        private static readonly object _lock = new object();

        public static void Log(string message)
        {
            lock (_lock)
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                Console.WriteLine(logEntry);
                File.AppendAllText(LogFile, logEntry + Environment.NewLine);
            }
        }
    }
}
