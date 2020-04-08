using System;
using System.IO;
using static System.Console;

namespace Broom
{
    public static class BroomConsole
    {
        public static void PrintWelcome()
        {
            Title = "Broom (Метла)";
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("*******************************************************");
            WriteLine("Broom (Метла)");
            WriteLine("Очистка кэша и Корзины, удаление временных файлов");
            WriteLine();
            WriteLine("(c) Starinin Andrey (An.St.), Март 2018");
            WriteLine("(c) Автономное учреждение Воронежской области 'Многофункциональный центр предоставления государственных и муниципальных услуг'. 2018");
            WriteLine("(c) Компьютерная Академия ШАГ. 2020");
            WriteLine();
            WriteLine("License: GNU General Public License v3.0");
            WriteLine();
            WriteLine("Version: 0.9");
            WriteLine("");
            WriteLine("Language: C#");
            WriteLine();
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("***");
            WriteLine("GitHub - https://github.com/anst-foto/Broom-csharp");
            WriteLine();
            WriteLine("***");
            WriteLine("Основано на коде  - https://github.com/anst-foto/Broom");
            WriteLine("(c) Starinin Andrey (AnSt). 2017");
            WriteLine("(c) Автономное учреждение Воронежской области 'Многофункциональный центр предоставления государственных и муниципальных услуг'. 2017");
            WriteLine();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("*******************************************************");
            WriteLine();

            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine();
            WriteLine("Изменения:");
            WriteLine("v0.9 (Апрель 2020):   Изменение консольного меню. Fix anst-foto/Broom-csharp#4");
            WriteLine("v0.8 (Апрель 2020):   Изменение доступности методов в классах, добавление очистки браузеров Microsoft Edge, Vivaldi");
            WriteLine("v0.7 (Март 2020):   Переработка программы под .Net Core, изменение лицензирования");
            WriteLine("v0.6 (Апрель 2019):   Добавление 'тихого' режима");
            WriteLine("v0.5 (Апрель 2019):   Добавление логгирования");
            WriteLine("v0.4 (Апрель 2019):   Добавление параметров командной строки");
            WriteLine("v0.3 (Апрель 2019):   Обработка исключений при удалении директорий, цветовое оформление");
            WriteLine("v0.2 (Апрель 2019):   Добавление в ввыод информации о лицензии");
            WriteLine("v0.1 (Март 2018):   Создание программы");
            WriteLine();
        }
        public static void PrintLicense()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("*******************************************************");
            WriteLine();
            // TO-DO
            // Вывод лицензии
            // чтение из файла
            try
            {
                using var license = new StreamReader(@"C:\AnSt\Programming\Broom-cs_2\Broom\LICENSE");
                WriteLine(license.ReadToEnd());
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
            WriteLine("*******************************************************");
        }
        public static void PrintMenu()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine("Выберите режим очистки:");
            WriteLine("1. Очистить только кэши браузеров");
            WriteLine("2. Очитстить только Корзину и временные файлы (RecycleBin & Temp)");
            WriteLine("3. Очитстить только папку Загрузки (Downloads)");
            WriteLine("4. Очитстить кэши браузеров и Корзину с временными файлами (RecycleBin & Temp)");
            WriteLine("5. Очитстить кэши браузеров и папку Загрузки (Downloads)");
            WriteLine("6. Очитстить Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)");
            WriteLine("7. Очитстить кэши браузеров, Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)");
            WriteLine("0. Выход");
            WriteLine();
            ResetColor();
        }
        public static void InfoMessage(string message)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine("----------");
            WriteLine("Info");
            WriteLine(message);
            WriteLine("----------");
            WriteLine();
            ResetColor();
        }
        public static void ErrorMessage(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine();
            WriteLine("!!!!!!!!!!");
            WriteLine("ERROR");
            WriteLine(message);
            WriteLine("!!!!!!!!!!");
            WriteLine();
            ResetColor();
        }
        public static void SuccessfullyMessage(string message)
        {
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine();
            WriteLine("**********");
            WriteLine("Successfully");
            WriteLine(message);
            WriteLine("**********");
            WriteLine();
            ResetColor();
        }
    }
}
