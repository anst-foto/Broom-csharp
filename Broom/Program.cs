using System;
using BroomDLL;

using static System.Console;

namespace Broom
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            #region event
            BroomDLL.Broom.Info += BroomConsole.InfoMessage;
            BroomDLL.Broom.Error += BroomConsole.ErrorMessage;
            BroomDLL.Broom.Successfully += BroomConsole.SuccessfullyMessage;

            BroomDLL.Broom.Info += BroomLogFile.InfoMessage;
            BroomDLL.Broom.Error += BroomLogFile.ErrorMessage;
            BroomDLL.Broom.Successfully += BroomLogFile.SuccessfullyMessage;
            #endregion

            BroomConsole.PrintWelcome();
            BroomConsole.PrintMenu();

            BroomLogFile.LogFileStart();

            var choice = Convert.ToInt32(ReadLine());

            switch (choice)
            {
                case 1: // 1. Очистить только кэши браузеров
                    BroomDLL.Broom.CleanerBrowser();
                    break;
                case 2: // 2. Очитстить только Корзину и временные файлы (RecycleBin & Temp)
                    BroomDLL.Broom.CleanerRecile();
                    break;
                case 3: // 3. Очитстить только папку Загрузки (Downloads)
                    BroomDLL.Broom.CleanerDownloads();
                    break;
                case 4: // 4. Очитстить кэши браузеров и Корзину с временными файлами (RecycleBin & Temp)
                    BroomDLL.Broom.CleanerBrowser();
                    BroomDLL.Broom.CleanerRecile();
                    break;
                case 5: // 5. Очитстить кэши браузеров и папку Загрузки (Downloads)
                    BroomDLL.Broom.CleanerBrowser();
                    BroomDLL.Broom.CleanerDownloads();
                    break;
                case 6: // 6. Очитстить Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)
                    BroomDLL.Broom.CleanerRecile();
                    BroomDLL.Broom.CleanerDownloads();
                    break;
                case 7: // 7. Очитстить кэши браузеров, Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)
                    BroomDLL.Broom.CleanerAll();
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
