using static System.Console;

namespace Broom.ConsoleApp;

public static class ConsoleHelper
{
    public static void PrintWelcome()
    {
        Title = "Broom (Метла)";

        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("*******************************************************");
        WriteLine("Broom (Метла)");
        WriteLine("Очистка кэша и Корзины, удаление временных файлов");
        WriteLine();
        WriteLine("(c) Старинин Андрей (An.St.), 2024");
        WriteLine("(c) ООО \"ОМК-ИТ\", 2024");
        WriteLine();
        WriteLine("License: GNU General Public License v3.0");
        WriteLine();
        WriteLine("Version: 0.1");
        WriteLine();
        WriteLine("Language: C#");
        WriteLine();

        ForegroundColor = ConsoleColor.Gray;
        WriteLine("***");
        WriteLine("GitHub - https://github.com/anst-foto/Broom-csharp");
        WriteLine();
        WriteLine("***");
        WriteLine();

        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("*******************************************************");
        WriteLine();

        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine();
        WriteLine("Версии:");
        WriteLine("v0.1 (Октябрь 2024)");
        WriteLine();

        ResetColor();
    }

    public static void PrintLicense()
    {
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("*******************************************************");
        WriteLine();
        try
        {
            using var license = new StreamReader("");
            WriteLine(license.ReadToEnd());
        }
        catch (Exception e)
        {
            WriteLine(e.Message);
        }

        WriteLine();
        WriteLine("*******************************************************");

        ResetColor();
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
        WriteLine(
            "7. Очитстить кэши браузеров, Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)");
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
