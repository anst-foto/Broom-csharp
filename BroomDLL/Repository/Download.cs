using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL
{
    public class Download : Item
    {
        public override void Clear(string dir)
        {
            Broom.ClearItem("Очистка","папки Загрузка",
                (dir) => Broom.DeleteFoldersFiles($@"{dir}\Downloads"));
        }
    }
}
