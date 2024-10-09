using Broom.ConsoleApp.ConsoleHelper;
using Broom.Core;
using NLog;

ConsoleHelper.PrintWelcome();

Cleaning.Logger = LogManager.GetLogger(nameof(Cleaning)); //FIXME
DeleteService.Logger = LogManager.GetLogger(nameof(DeleteService)); //FIXME

var cleaner = new Cleaner(); //TODO

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

        default:
            Console.WriteLine("Неверный режим работы");
            break;
    }

    Console.Write("Хотите продолжить? (д/Д - да, продолжить): ");
    var input = Console.ReadLine();
    @continue = input is "д" or "Д";
} while (@continue);

cleaner.Clean();
if (cleaner.Errors.Count == 0)
{
    ConsoleHelper.SuccessfullyMessage("Очистка завершена успешно");
}
else
{
    ConsoleHelper.ErrorMessage("Ошибки при очистке");
    foreach (var error in cleaner.Errors)
    {
        ConsoleHelper.ErrorMessage(error.Message);
    }
}

ConsoleHelper.InfoMessage("Выход...");
