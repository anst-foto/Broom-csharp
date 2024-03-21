using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class Opera
    {
        private static string[] path = { @"\AppData\Roaming\Opera Software\Opera Stable\",
                                        @"\AppData\Local\Opera Software\Opera Stable\Cache"};
        private static List<string> subdir = new List<string>()
        {
            @"GPUCache",
            @"ShaderCache",
            @"Jump List Icons",
            @"Jump List IconsOld\Jump List Icons"
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
