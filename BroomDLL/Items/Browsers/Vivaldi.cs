using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class Vivaldi
    {
        private static string path = @"\AppData\Local\Vivaldi\User Data\Default\";
        private static List<string> subdir = new List<string>()
        {
            @"Cache",
            @"GPUCache",
            @"Application Cache",
            @"Cookies",
            @"Cookies-Journal"
        };

        public static void Clear(string dir)
        {
            foreach (var item in subdir)
            {
                Broom.DeleteFoldersFiles($@"{dir}{path}{item}");
            }
        }
    }
}
