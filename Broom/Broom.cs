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
                    broom.CleanerAll();
                    break;
                case 4:                    
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильный режим");
                    break;
            }

            Console.ReadKey();
        }
    }
}
