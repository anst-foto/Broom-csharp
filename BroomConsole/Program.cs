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
            Browser.Error += BroomConsole.ErrorMessage;

            Broom.Info += BroomLogFile.InfoMessage;
            Broom.Error += BroomLogFile.ErrorMessage;
            Broom.Successfully += BroomLogFile.SuccessfullyMessage;
            BroomLogFile.WriteLogException += BroomConsole.ExceptionMessage;
            #endregion

            BroomConsole.PrintWelcome();
            BroomLogFile.LogFileStart();
            int choice = 0;
            do
            {
                BroomConsole.PrintMenu();
                choice = Convert.ToInt32(ReadLine());
                if (choice < 5)
                    Item.items[choice].Clear(Item.dir);
                else if (choice == 5)
                    Item.ClearAll();
                else
                    BroomConsole.ErrorMessage("неверный ввод");
                BroomLogFile.LogFileEnd();
            } while (choice != 0);
            ReadKey();
        }
    }
}
