using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broom_lib;

namespace Broom
{
    class Broom
    {
        #region Console
        static void PrintWelcome()
        {
            StreamReader License = new StreamReader(@"D:\Programming\Broom\C#\LICENSE");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Broom (Метла)");
            Console.WriteLine("Очистка кэша и Корзины, удаление временных файлов");
            Console.WriteLine();
            Console.WriteLine("(c) Starinin Andrey (An.St.), Март 2018");
            Console.WriteLine("(c) Автономное учреждение Воронежской области 'Многофункциональный центр предоставления государственных и муниципальных услуг'. 2018");
            Console.WriteLine();
            Console.WriteLine("Version: 0.3");
            Console.WriteLine("MIT License");
            Console.WriteLine("Language: C#");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("***");
            Console.WriteLine("GitHub - https://github.com/anst-foto/Broom-csharp");
            Console.WriteLine();
            Console.WriteLine("***");
            Console.WriteLine("Основано на коде  - https://github.com/anst-foto/Broom");
            Console.WriteLine("(c) Starinin Andrey (AnSt). 2017");
            Console.WriteLine("(c) Автономное учреждение Воронежской области 'Многофункциональный центр предоставления государственных и муниципальных услуг'. 2017");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*******************************************************");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("*******************************************************");
            Console.WriteLine();
            Console.Write(License.ReadToEnd());
            Console.WriteLine();
            Console.WriteLine("*******************************************************");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine("Изменения:");
            Console.WriteLine("v0.3 (Апрель 2019):   Обработка исключений при удалении директорий, цветовое оформление");
            Console.WriteLine("v0.2 (Апрель 2019):   Добавление в выод информации о лицензии");
            Console.WriteLine("v0.1 (Март 2018):   Создание программы");
            Console.WriteLine();

            License.Close();
        }
        static void PrintSwith()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***********************");
            Console.WriteLine("Закройте все браузеры!");
            Console.WriteLine("***********************");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine("Выберите режим очистки:");
            Console.WriteLine("1. Очистить только кэши браузеров");
            Console.WriteLine("2. Очитстить только Корзину и временные файлы (RecycleBin & Temp)");
            Console.WriteLine("3. Очитстить только папку Загрузки (Downloads)");
            Console.WriteLine("4. Очитстить кэши браузеров и Корзину с временными файлами (RecycleBin & Temp)");
            Console.WriteLine("5. Выход");
            Console.WriteLine();
        }
        #endregion

        static void Program(Clean broom)
        {
            PrintSwith();
            int Key = Int32.Parse(Console.ReadLine());
            switch (Key)
            {
                case 1:
                    broom.CleanerBrowser();
                    break;
                case 2:
                    broom.CleanerRecile();
                    break;
                case 3:
                    broom.CleannerDownloads();
                    break;
                case 4:
                    broom.CleanerAll();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильный режим");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Clean broom = new Clean();
            PrintWelcome();
            var YesNo = "";
            do
            {
                Program(broom);
                Console.WriteLine();
                Console.WriteLine("Хотите продолжить");
                Console.WriteLine("Y - да");
                Console.WriteLine("Любой другой символ - нет");
                YesNo = Console.ReadLine();
            } while (YesNo == "Y");
            Environment.Exit(0);
        }
    }
}
