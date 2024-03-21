using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class InternetExplorer
    {
        private static string path = @"\AppData\Local\Microsoft\Windows\";
        private static List<string> subdir = new List<string>()
        {
            @"Temporary Internet Files",
            @"WER",
            @"WebCache",
            @"INetCache"
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
