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
            Console.Title = "Broom";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            PathUsers = @"C:\Users\";
            TempPath = @"C:\Windows\Temp";
        }
        #endregion

        #region Delete Folder & File
        static void DeleteFolder(string directory)
        {
            try
            {
                var dir = new DirectoryInfo(path: $@"{directory}");
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(recursive: true);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine($"{directory} успешно удалено");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("***********************");
                Console.WriteLine("Директория не найдена! Ошибка: " + ex.Message);
                Console.WriteLine("***********************");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("***********************");
                Console.WriteLine("Отсутствует доступ! Ошибка: " + ex.Message);
                Console.WriteLine("***********************");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("***********************");
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("***********************");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }
        #endregion

        #region Clear Browser
        static void Clear_Mozilla(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\OfflineCache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\cache2\entries");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\thumbnails");
        }
        static void Clear_Chrome(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache2\entries");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Media Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\ChromeDWriteFontCache");
        }
        static void Clear_Chromium(string dir)
        {

            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\GPUCache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Media Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Pepper Data");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Application Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");

        }
        static void Clear_Yandex(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\GPUCache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Media Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Pepper Data");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Application Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\Temp");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cookies");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cookies-Journal");
        }
        static void Clear_IE(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\Temporary Internet Files");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\WER");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\INetCache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\WebCache");
        }
        static void Clear_Opera(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Opera Software\Opera Stable\Cache");
        }
        #endregion

        #region Clear RecileBin & Temp
        public void Clear_Temp(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Temp");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\AppCache");
            DeleteFolder(directory: TempPath);
        }
        public void Clear_RecileBin()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                string RecyclePath = $@"{drive}$Recycle.Bin";
                DeleteFolder(directory: RecyclePath);
            }
        }
        public void Clear_Download(string dir)
        {
            DeleteFolder(directory: $@"{dir}\Downloads");
        }
        #endregion

        #region Cleaner Browser
        public void CleanerChrome()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                Console.WriteLine("Очистка кэша Google Chrome...");
                Console.WriteLine();
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
                Console.WriteLine("Очистка кэша Chromium...");
                Console.WriteLine();
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
                Console.WriteLine("Очистка кэша Яндекс.Браузер...");
                Console.WriteLine();
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
                Console.WriteLine("Очистка кэша Internet Explorer...");
                Console.WriteLine();
                foreach (string s in PathUser)
                {
                    Clear_IE(dir: s);
                }
                Console.WriteLine("Очистка кэша Internet Explorer завершена");
            }
        }
        public void CleannerMozilla()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                Console.WriteLine("Очистка кэша Mozilla...");
                Console.WriteLine();
                foreach (string s in PathUser)
                {
                    Clear_Mozilla(dir: s);
                }
                Console.WriteLine("Очистка кэша Mozilla завершена");
            }
        }
        public void CleannerOpera()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                Console.WriteLine("Очистка кэша Opera...");
                Console.WriteLine();
                foreach (string s in PathUser)
                {
                    Clear_Opera(dir: s);
                }
                Console.WriteLine("Очистка кэша Opera завершена");
            }
        }
        #endregion

        #region Cleaner RecileBin & Temp
        public void CleanerRecileBinTemp()
        {
            Console.WriteLine("Очистка Корзины...");
            Console.WriteLine();
            Clear_RecileBin();
            Console.WriteLine("Очистка Корзины завершена");

            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                Console.WriteLine("Удаление временных файлов...");
                Console.WriteLine();
                foreach (string s in PathUser)
                {
                    Clear_Temp(dir: s);
                }
                Console.WriteLine("Удаление временных файлов завершено");
            }
        }
        public void CleannerDownload()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                Console.WriteLine("Очистка папки Загрузка...");
                Console.WriteLine();
                foreach (string s in PathUser)
                {
                    Clear_Download(dir: s);
                }
                Console.WriteLine("Очистка папки Загрузка завершена");
            }
        }
        #endregion

        #region Cleaner
        public void CleanerBrowser()
        {
            CleanerChrome();
            CleanerChromium();
            CleanerYandex();
            CleanerIE();
            CleannerMozilla();
            CleannerOpera();
        }
        public void CleanerRecile()
        {
            CleanerRecileBinTemp();
        }
        public void CleannerDownloads()
        {
            CleannerDownload();
        }
        public void CleanerAll()
        {
            CleanerBrowser();
            CleanerRecile();
            CleannerDownloads();
        }
        #endregion
    }
}
