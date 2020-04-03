using System;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using static System.Console;

namespace Broom
{
    public static class BroomLogFile
    {
        private const string logFilePath = @"broom.log";

        private static void WriteLogFile(string message)
        {
            try
            {
                using var logFile = new StreamWriter(logFilePath, true, Encoding.Default);
                logFile.WriteLine(message);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public static void LogFileStart()
        {
            var msg = "=============== " + DateTime.Today.ToString() + " ===============";
            WriteLogFile(msg);
        }
        public static void LogFileEnd()
        {
            const string msg = "=============== END ===============";
            WriteLogFile(msg);
        }
        public static void SuccessfullyMessage(string message)
        {
            var msg = DateTime.Now.ToString();
            msg += " - Successfully : ";
            msg += message;
            WriteLogFile(msg);
        }
        public static void ErrorMessage(string message)
        {
            var msg = DateTime.Now.ToString();
            msg += " - Error : ";
            msg += message;
            WriteLogFile(msg);
        }
        public static void InfoMessage(string message)
        {
            var msg = DateTime.Now.ToString();
            msg += " - Info : ";
            msg += message;
            WriteLogFile(msg);
        }
    }
}
