using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class Yandex
    {
        private static string[] path = { @"\AppData\Local\Yandex\YandexBrowser\User Data\Default\",
                                        @"\AppData\Local\Yandex\YandexBrowser\Temp"};
        private static List<string> subdir = new List<string>()
        {
            @"Cache",
            @"Media Cache",
            @"GPUCache",
            @"Pepper Data",
            @"Application Cache",
            @"ShaderCache",
            @"Cookies",
            @"Cookies-Journal"
        };
        public static void Clear(string dir)
        {
            foreach (var item in subdir)
            {
                Broom.DeleteFoldersFiles($@"{dir}{path[0]}{item}");
            }
            Broom.DeleteFoldersFiles($@"{dir}{path[1]}");
        }
    }
}
