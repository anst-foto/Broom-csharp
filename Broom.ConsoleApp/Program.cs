using Broom.ConsoleApp;
using Broom.Core;

ConsoleHelper.PrintWelcome();
ConsoleHelper.PrintMenu();

var select = Console.ReadLine();

switch (select)
{
    case "1": // 1. Очистить только кэши браузеров

        break;
    case "2": // 2. Очитстить только Корзину и временные файлы (RecycleBin & Temp)
        Cleaner.CleaningRecycleBinWinApi();
        Cleaner.CleaningTemp();
        break;

    case "3": // 3. Очитстить только папку Загрузки (Downloads)

        break;

    case "4": // 4. Очитстить кэши браузеров и Корзину с временными файлами (RecycleBin & Temp)

        break;

    case "5": // 5. Очитстить кэши браузеров и папку Загрузки (Downloads)

        break;

    case "6": // 6. Очитстить Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)

        break;

    case "7": // 7. Очитстить кэши браузеров, Корзину с временными файлами (RecycleBin & Temp) и папку Загрузки (Downloads)

        break;

    case "0": // 0. Выход
        break;

    default:
        Console.WriteLine("Неверный режим работы");
        break;
}

Console.ReadLine();
