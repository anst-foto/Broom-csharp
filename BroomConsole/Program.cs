using System;
using BroomDLL;
using static System.Console;

namespace BroomConsole
{
    public delegate void BrowserCleaner();
    internal static class Program
    {
        private static void Main()
        {
            #region Event
            Broom.Info += BroomConsole.InfoMessage;
            Broom.Error += BroomConsole.ErrorMessage;
            Broom.Successfully += BroomConsole.SuccessfullyMessage;
            CommonBrowsers.Error += BroomConsole.ErrorMessage;

            Broom.Info += BroomLogFile.InfoMessage;
            Broom.Error += BroomLogFile.ErrorMessage;
            Broom.Successfully += BroomLogFile.SuccessfullyMessage;
            BroomLogFile.WriteLogException += BroomConsole.ExceptionMessage;
            #endregion

            BroomConsole.PrintWelcome();
            BroomLogFile.LogFileStart();
            int choice = 0;
            Action[] actions = new Action[5]
            {
                () => { },
                () => CommonBrowsers.CleanerBrowsers(),
                () => Broom.CleanerRecile(),
                () => Broom.CleanerDownload(),
                () => Broom.CleanerAll()
            };
            do
            {
                BroomConsole.PrintMenu();
                choice = Convert.ToInt32(ReadLine());
                actions[choice].Invoke();
                BroomLogFile.LogFileEnd();
            } while (choice != 0);
            ReadKey();
        }
    }
}
