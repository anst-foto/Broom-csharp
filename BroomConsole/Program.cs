using System;
using BroomDLL;
using static System.Console;

namespace BroomConsole
{
    internal static class Program
    {
        private static void Main()
        {
            #region Event
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

            var choice = Convert.ToInt32(ReadLine());

            switch (choice)
            {
                case 1: // 1. Очистить только кэши браузеров
                    Broom.CleanerBrowser();
                    break;
                case 2: // 2. Очитстить только Корзину и временные файлы (RecycleBin & Temp)
                    Broom.CleanerRecile();
                    break;
                case 3: // 3. Очитстить только папку Загрузки (Downloads)
                    Broom.CleanerDownloads();
                    break;
                case 4: // 4. Очитстить кэши браузеров и Корзину с временными файлами (RecycleBin & Temp)
                    Broom.CleanerBrowser();
                    Broom.CleanerRecile();
                    break;
                case 5: // 5. Очитстить кэши браузеров и папку Загрузки (Downloads)
                    Broom.CleanerBrowser();
                    Broom.CleanerDownloads();
                    break;
                case 6: // 6. Очитстить Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)
                    Broom.CleanerRecile();
                    Broom.CleanerDownloads();
                    break;
                case 7: // 7. Очитстить кэши браузеров, Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)
                    Broom.CleanerAll();
                    break;
                case 0: // 0. Выход
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
