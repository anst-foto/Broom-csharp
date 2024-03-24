using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class GoogleChrome
    {
        private static string[] path = { @"\AppData\Local\Google\Chrome\User Data\Default\",
                                        @"\AppData\Local\Google\Chrome\User Data\ShaderCache"};
        private static List<string> subdir = new List<string>()
        {
            @"Cache",
            @"Cache2\entries",
            @"Cookies",
            @"Media Cache",
            @"Cookies-Journal",
            @"ChromeDWriteFontCache",
            @"GPUCache",
            @"Storage\ext",
            @"Service Worker"
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
