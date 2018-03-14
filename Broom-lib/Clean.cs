using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Broom_lib
{
    public class Clean
    {
        #region Переменные
        private string PathUsers;
        private string TempPath;
        #endregion

        #region Constructor
        public Clean()
        {            
            Console.Title = "BroomMFC";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            PathUsers = @"C:\Users\";
            TempPath = @"C:\Windows\Temp";
        }
        #endregion

        #region Console
        public void PrintWelcome()
        {
            Console.WriteLine("Программа очистки кеша");
            Console.WriteLine("© Starinin Andrey (An.St.), Март 2018");
            Console.WriteLine("Version: 0.1");
            Console.WriteLine("Language: C#");
            Console.WriteLine("MIT License");
            Console.WriteLine();
            Console.WriteLine("Изменения:");
            Console.WriteLine("v0.1:   Создание скрипта");
            Console.WriteLine();
        }
        public void PrintSwith()
        {
            Console.WriteLine("Закройте все браузеры!");
            Console.WriteLine();
            Console.WriteLine("Выберите режим очистки:");
            Console.WriteLine("1. Очистить только кэши браузеров");
            Console.WriteLine("2. Очитстить только Корзину и временные файлы (RecycleBin & Temp)");
            Console.WriteLine("3. Очитстить кэши браузеров и Корзину с временными файлами (RecycleBin & Temp)");
            Console.WriteLine("4. Выход");
            Console.WriteLine();
        }
        #endregion

        #region Clear Browser
        private void Clear_Chrome(string dir)
        {
            string dir1 = $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache";
            string dir2 = $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache2\entries";
            string dir3 = $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies";
            string dir4 = $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Media Cache";
            string dir5 = $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal";
            string dir6 = $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\ChromeDWriteFontCache";

            try
            {
                if (Directory.Exists(path: dir1))
                {
                    Directory.Delete(path: dir1, recursive: true);
                }

                if (Directory.Exists(path: dir2))
                {
                    Directory.Delete(path: dir2, recursive: true);
                }

                if (Directory.Exists(path: dir3))
                {
                    Directory.Delete(path: dir3, recursive: true);
                }

                if (Directory.Exists(path: dir4))
                {
                    Directory.Delete(path: dir4, recursive: true);
                }

                if (Directory.Exists(path: dir5))
                {
                    Directory.Delete(path: dir5, recursive: true);
                }

                if (Directory.Exists(path: dir6))
                {
                    Directory.Delete(path: dir6, recursive: true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        static void Clear_Chromium(string dir)
        {
            string dir1 = $@"{dir}\AppData\Local\Chromium\User Data\Default\Cache";
            string dir2 = $@"{dir}\AppData\Local\Chromium\User Data\Default\GPUCache";
            string dir3 = $@"{dir}\AppData\Local\Chromium\User Data\Default\Media Cache";
            string dir4 = $@"{dir}\AppData\Local\Chromium\User Data\Default\Pepper Data";
            string dir5 = $@"{dir}\AppData\Local\Chromium\User Data\Default\Application Cache";

            try
            {
                if (Directory.Exists(path: dir1))
                {
                    Directory.Delete(path: dir1, recursive: true);
                }

                if (Directory.Exists(path: dir2))
                {
                    Directory.Delete(path: dir2, recursive: true);
                }

                if (Directory.Exists(path: dir3))
                {
                    Directory.Delete(path: dir3, recursive: true);
                }

                if (Directory.Exists(path: dir4))
                {
                    Directory.Delete(path: dir4, recursive: true);
                }

                if (Directory.Exists(path: dir5))
                {
                    Directory.Delete(path: dir5, recursive: true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        static void Clear_Yandex(string dir)
        {
            string dir1 = $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cache";
            string dir2 = $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\GPUCache";
            string dir3 = $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Media Cache";
            string dir4 = $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Pepper Data";
            string dir5 = $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Application Cache";
            string dir6 = $@"{dir}\AppData\Local\Yandex\YandexBrowser\Temp";

            try
            {
                if (Directory.Exists(path: dir1))
                {
                    Directory.Delete(path: dir1, recursive: true);
                }

                if (Directory.Exists(path: dir2))
                {
                    Directory.Delete(path: dir2, recursive: true);
                }

                if (Directory.Exists(path: dir3))
                {
                    Directory.Delete(path: dir3, recursive: true);
                }

                if (Directory.Exists(path: dir4))
                {
                    Directory.Delete(path: dir4, recursive: true);
                }

                if (Directory.Exists(path: dir5))
                {
                    Directory.Delete(path: dir5, recursive: true);
                }

                if (Directory.Exists(path: dir6))
                {
                    Directory.Delete(path: dir6, recursive: true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        static void Clear_IE(string dir)
        {
            string dir1 = $@"{dir}\AppData\Local\Microsoft\Windows\Temporary Internet Files";
            string dir2 = $@"{dir}\AppData\Local\Microsoft\Windows\WER";
            string dir3 = $@"{dir}\AppData\Local\Microsoft\Windows\INetCache";
            string dir4 = $@"{dir}\AppData\Local\Microsoft\Windows\WebCache";

            try
            {
                if (Directory.Exists(path: dir1))
                {
                    Directory.Delete(path: dir1, recursive: true);
                }

                if (Directory.Exists(path: dir2))
                {
                    Directory.Delete(path: dir2, recursive: true);
                }

                if (Directory.Exists(path: dir3))
                {
                    Directory.Delete(path: dir3, recursive: true);
                }

                if (Directory.Exists(path: dir4))
                {
                    Directory.Delete(path: dir4, recursive: true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        #endregion

        #region Clear RecileBin & Temp
        public void Clear_Temp(string dir)
        {
            string dir1 = $@"{dir}\AppData\Local\Temp";
            string dir2 = $@"{dir}\AppData\Local\Microsoft\Windows\AppCache";

            try
            {
                if (Directory.Exists(path: dir1))
                {
                    Directory.Delete(path: dir1, recursive: true);
                }

                if (Directory.Exists(path: dir2))
                {
                    Directory.Delete(path: dir2, recursive: true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        public void Clear_RecileBin()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    string RecyclePath = $@"{drive}$Recycle.Bin";
                    if (Directory.Exists(RecyclePath))
                    {
                        Directory.Delete(path: RecyclePath, recursive: true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        #endregion

        #region Cleaner Browser
        public void CleanerChrome()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                foreach (string s in PathUser)
                {
                    Clear_Temp(dir: s);
                }
                Console.WriteLine("Очистка кэша Google Chrome завершена");
                Console.WriteLine();
            }
        }
        public void CleanerChromium()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                foreach (string s in PathUser)
                {
                    Clear_Chromium(dir: s);
                }
                Console.WriteLine("Очистка кэша Chromium завершена");
            }
        }
        public void CleanerYandex()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                foreach (string s in PathUser)
                {
                    Clear_Yandex(dir: s);
                }
                Console.WriteLine("Очистка кэша Яндекс.Браузер завершена");
            }
        }
        public void CleanerIE()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                foreach (string s in PathUser)
                {
                    Clear_IE(dir: s);
                }
                Console.WriteLine("Очистка кэша Internet Explorer завершена");
            }
        }
        #endregion

        #region Cleaner RecileBin & Temp
        public void CleanerRecileBinTemp()
        {
            Clear_RecileBin();

            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                foreach (string s in PathUser)
                {
                    Clear_Temp(dir: s);
                }                
            }
            try
            {
                Directory.Delete(path: TempPath, recursive: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            
            Console.WriteLine("Очистка Корзины и удаление временных файлов завершена");
        }
        #endregion

        #region Cleaner
        public void CleanerBrowser()
        {
            CleanerChrome();
            CleanerChromium();
            CleanerYandex();
            CleanerIE();
        }
        public void CleanerRecile()
        {
            CleanerRecileBinTemp();
        }
        public void CleanerAll()
        {
            CleanerBrowser();
            CleanerRecile();
        }
        #endregion
    }
}
