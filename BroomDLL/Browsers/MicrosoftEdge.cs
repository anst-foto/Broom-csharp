using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class MicrosoftEdge
    {
        private static string[] path = { @"\AppData\Local\Microsoft\Edge\User Data\",
                                        @"\AppData\Local\Microsoft\Edge SxS\User Data\"};
        private static List<string> subdir = new List<string>()
        {
            @"Default\Cache",
            @"Default\Media Cache",
            @"Default\GPUCache",
            @"Default\Storage\ext",
            @"Default\Service Worker",
            @"ShaderCache"
        };
        public static void Clear(string dir)
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in subdir)
                {
                    Broom.DeleteFoldersFiles($@"{dir}{path[i]}{item}");
                }
            }
        }
    }
}
