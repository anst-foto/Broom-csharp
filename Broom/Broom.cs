using System;
using System.Collections.Generic;
using System.Text;
using Broom_lib;

namespace Broom
{
    class Broom
    {
        static void Main(string[] args)
        {
            Clean broom = new Clean();
            broom.PrintWelcome();
            do
            {
                broom.PrintSwith();
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
                Console.WriteLine("Хотите продолжить?");
                Console.WriteLine("Y - да");
                Console.WriteLine("N - нет");
            } while (Console.ReadLine() == "Y" || Console.ReadLine() == "y");
        }
    }
}
