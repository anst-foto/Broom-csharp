using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class Mozilla
    {
        private static string path = @"AppData\Local\Mozilla\Firefox\Profiles\*.default\";
        private static List<string> subdir = new List<string>()
        {
            @"OfflineCache",
            @"cache2\entries",
            @"thumbnails"
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
