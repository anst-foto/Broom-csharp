using System;
using System.IO;

using static System.Console;

namespace Broom
{
    class Program
    {
        static void Main(string[] args)
        {
            #region event
            Broom.Info += BroomConsole.InfoMessage;
            Broom.Error += BroomConsole.ErrorMessage;
            Broom.Successfully += BroomConsole.SuccessfullyMessage;

            Broom.Info += BroomLogFile.InfoMessage;
            Broom.Error += BroomLogFile.ErrorMessage;
            Broom.Successfully += BroomLogFile.SuccessfullyMessage;
            #endregion

            BroomConsole.PrintWelcome();
            BroomConsole.PrintMenu();

            BroomLogFile.LogFileStart();
            
            int choice;
            choice = Convert.ToInt32(ReadLine());
            
            switch(choice)
            {
                case 1:
                    Broom.CleanerBrowser();
                    break;
                case 2:
                    Broom.CleanerRecile();
                    break;
                case 3:
                    Broom.CleannerDownloads();
                    break;
                case 4:
                    Broom.CleanerAll();
                    break;
                case 5:
                    break;
                default:
                    WriteLine("Неверный режим работы");
                    break;
            }

            BroomLogFile.LogFileEnd();
            ReadKey();
        }
    }
}
