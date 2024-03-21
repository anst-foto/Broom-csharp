using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL
{
    public class Temp : Item
    {
        private static List<string> subdir = new List<string>()
        {
            @"\AppData\Local\Temp",
            @"\AppData\Local\Microsoft\Windows\AppCache",
        };

        public override void Clear(string dir)
        {
            foreach (var item in subdir)
            {
                Broom.ClearItem("Очистка", "временной папки",
                    (dir) => Broom.DeleteFoldersFiles($@"{dir}{item}"));
            }
            Broom.ClearItem("Очистка", "временной папки",
                (c) => Broom.DeleteFoldersFiles($@"C:\Windows\Temp"));
        }
    }
}
