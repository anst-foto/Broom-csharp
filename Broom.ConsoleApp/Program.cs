using Broom.ConsoleApp.ConsoleHelper;
using Broom.Core;

ConsoleHelper.PrintWelcome();

var cleaner = new Cleaner();

bool @continue;
do
{
    ConsoleHelper.PrintMenu();
    var select = Console.ReadLine();
    switch (select)
    {
        case "1": // 1. Очистить только кэши браузеров

            break;
        case "2": // 2. Очистить только Корзину (RecycleBin)
            cleaner.Add(Cleaning.RecycleBinWinApi);
            break;

        case "3": // 3. Очистить только папку Загрузки (Downloads)
            cleaner.Add(Cleaning.Downloads);
            break;

        case "4": // 4. Очистить только временные файлы (Temp)
            cleaner.Add(Cleaning.Temp);
            break;

        case "0": // 0. Выход
            break;

        default:
            Console.WriteLine("Неверный режим работы");
            break;
    }

    Console.Write("Хотите продолжить? (д/Д - да, продолжить): ");
    var input = Console.ReadLine();
    @continue = input is "д" or "Д";
} while (@continue);

if (!@continue)
{
    ConsoleHelper.InfoMessage("Выход...");
    return;
}

try
{
    cleaner.Clean();
}
catch (Exception e)
{
    ConsoleHelper.ErrorMessage(e.Message);
}
