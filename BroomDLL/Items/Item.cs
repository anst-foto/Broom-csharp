using System;
using System.Collections.Generic;
using System.Text;

namespace BroomDLL
{
    public abstract class Item
    {
        public static string dir = @"C:\USERS\" + Environment.UserName;
        public static List<Item> items = new List<Item>()
        {
            new Browser(),
            new Trash(),
            new Temp(),
            new Download()
        };
        public abstract void Clear(string dir);
        public static void ClearAll()
        {
            foreach (var item in items)
            {
                item.Clear(dir);
            }
        }
    }
}
