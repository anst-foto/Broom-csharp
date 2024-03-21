using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL.Browsers
{
    public class Test 
    {
        private static string path = @"Temp\";
        private static List<string> subdir = new List<string>()
        {
            @"SubDirectory\"
        };
        public static void Clear(string dir)
        {
            for(int i = 0; i < 2 ; i++)
            {
                foreach (var item in subdir)
                {
                    Broom.DeleteFoldersFiles($@"{dir}{path}{item}");
                }
                subdir.Clear();
                subdir.Add(path);
                path = "";
            }
        }
    }
}
