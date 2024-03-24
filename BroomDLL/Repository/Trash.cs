using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BroomDLL
{
    public class Trash : Item
    {
        public override void Clear(string dir)
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                var RecyclePath = $@"{drive}$Recycle.Bin";
                Broom.ClearItem("Очистка", "Корзины",
                    (RecyclePath) => Broom.DeleteFoldersFiles(RecyclePath));
            }
        }
    }
}
