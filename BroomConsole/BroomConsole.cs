using System;
using System.Collections.Generic;
using System.IO;
using BroomDLL;
using static System.Console;

namespace BroomConsole
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
            WriteLine("Version: 0.11");
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
            WriteLine("v0.11 (Апрель 2020): Выделение функций очистки в DLL");
            WriteLine("v0.10 (Апрель 2020): Добавление GUI");
            WriteLine("v0.9 (Апрель 2020):  Изменение консольного меню. Fix anst-foto/Broom-csharp#4");
            WriteLine("v0.8 (Апрель 2020):  Изменение доступности методов в классах, добавление очистки браузеров Microsoft Edge, Vivaldi");
            WriteLine("v0.7 (Март 2020):    Переработка программы под .Net Core, изменение лицензирования");
            WriteLine("v0.6 (Апрель 2019):  Добавление 'тихого' режима");
            WriteLine("v0.5 (Апрель 2019):  Добавление логгирования");
            WriteLine("v0.4 (Апрель 2019):  Добавление параметров командной строки");
            WriteLine("v0.3 (Апрель 2019):  Обработка исключений при удалении директорий, цветовое оформление");
            WriteLine("v0.2 (Апрель 2019):  Добавление в ввыод информации о лицензии");
            WriteLine("v0.1 (Март 2018):    Создание программы");
            WriteLine();
        }
        public static void PrintLicense()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("*******************************************************");
            WriteLine();
            // TODO Вывод лицензии чтение из файла
            try
            {
                using var license = new StreamReader(@"D:\AnSt\Programming\Broom-csharp\LICENSE");
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
            WriteLine("1. Очистить кэши браузеров");
            WriteLine("2. Очистить Корзину (Trash)");
            WriteLine("3. Очистить временные файлы (Temp)");
            WriteLine("4. Очистить папку Загрузки (Downloads)");
            WriteLine("5. Очистить всё");
            WriteLine("0. Выход");
            WriteLine();
            ResetColor();
        }
        public static void WriteMessage(object sender, string message, ConsoleColor color)
        {
            var name = (InfoEvents)sender;
            ForegroundColor = color;
            Write("{0} : ", name);
            WriteLine(message);
            ResetColor();
        }

        public static void InfoMessage(string message)
        {
            WriteMessage(InfoEvents.Info, message, ConsoleColor.Blue);
        }
        public static void ErrorMessage(string message)
        {
             WriteMessage(InfoEvents.Error, message, ConsoleColor.Red);
        }

        public static void SuccessfullyMessage(string message)
        {
            WriteMessage(InfoEvents.Successfully, message, ConsoleColor.DarkGreen);
        }

        public static void ExceptionMessage(string message)
        {
            WriteMessage(InfoEvents.Exception, message, ConsoleColor.DarkRed);
        }
    }
}
