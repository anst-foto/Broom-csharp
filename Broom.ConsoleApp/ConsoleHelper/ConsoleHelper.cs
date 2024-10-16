using static System.Console;

namespace Broom.ConsoleApp.ConsoleHelper;

/// <summary>
///     Класс для вывода информации в консоль
/// </summary>
public static partial class ConsoleHelper
{
    /// <summary>
    ///     Вывод приветствия в консоль
    /// </summary>
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

    /// <summary>
    ///     Вывод лицензии в консоль
    /// </summary>
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

    /// <summary>
    ///     Вывод меню в консоль
    /// </summary>
    public static void PrintMenu()
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine();
        WriteLine("Выберите режим очистки:");
        WriteLine("1. Очистить только кэши браузеров");
        WriteLine("2. Очистить только Корзину (RecycleBin)");
        WriteLine("3. Очистить только папку Загрузки (Downloads)");
        WriteLine("4. Очистить только временные файлы (Temp)");
        WriteLine();

        ResetColor();
    }
}
