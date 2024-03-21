using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class Chromium
    {
        private static string[] path = { @"\AppData\Local\Chromium\User Data\Default\",
                                        @"\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal",
                                        @"\AppData\Local\Google\Chrome\User Data\Default\Cookies"};
        private static List<string> subdir = new List<string>()
        {
            @"Cache",
            @"GPUCache",
            @"Media Cache",
            @"Pepper Data",
            @"Application Cache"
        };
        public static void Clear(string dir)
        {
            foreach (var item in subdir)
            {
                Broom.DeleteFoldersFiles($@"{dir}{path[0]}{item}");
            }
            Broom.DeleteFoldersFiles($@"{dir}{path[1]}");
            Broom.DeleteFoldersFiles($@"{dir}{path[2]}");
        }
    }
}
