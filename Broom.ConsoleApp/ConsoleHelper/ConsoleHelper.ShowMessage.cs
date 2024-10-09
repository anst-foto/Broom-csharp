using static System.Console;

namespace Broom.ConsoleApp.ConsoleHelper;

public static partial class ConsoleHelper
{
    /// <summary>
    /// Вывод информационного сообщения в консоль
    /// </summary>
    /// <param name="message">Текст сообщения</param>
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

    /// <summary>
    /// Вывод сообщения об ошибке в консоль
    /// </summary>
    /// <param name="message">Текст сообщения</param>
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

    /// <summary>
    /// Вывод сообщения об успешном завершении в консоль
    /// </summary>
    /// <param name="message">Текст сообщения</param>
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
