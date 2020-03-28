using System;
using System.IO;

namespace Broom
{
    public static class Broom
    {
        #region event
        public delegate void Message(string message);
        public static event Message Info;
        public static event Message Error;
        public static event Message Successfully;
        #endregion

        private static string PathUsers = @"C:\Users\";

        public static void DeleteFolder(string directory)
        {
            try
            {
                var dir = new DirectoryInfo($@"{directory}");
                dir.Attributes &= ~FileAttributes.ReadOnly;
                dir.Delete(true);

                Successfully?.Invoke($"{directory} успешно удалено");
            }
            catch (DirectoryNotFoundException ex)
            {
                Error?.Invoke("Директория не найдена! Ошибка: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Error?.Invoke("Отсутствует доступ! Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Error?.Invoke("Ошибка: " + ex.Message);
            }
        }

        #region Clear Browser
        public static void Clear_Mozilla(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\OfflineCache");
            DeleteFolder($@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\cache2\entries");
            DeleteFolder($@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\thumbnails");
        }
        public static void Clear_Chrome(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache2\entries");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Media Cache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\ChromeDWriteFontCache");
        }
        public static void Clear_Chromium(string dir)
        {

            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\GPUCache");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Media Cache");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Pepper Data");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Application Cache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");

        }
        public static void Clear_Yandex(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\GPUCache");
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Media Cache");
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Pepper Data");
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Application Cache");
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\Temp");
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cookies");
            DeleteFolder($@"{dir}\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cookies-Journal");
        }
        public static void Clear_IE(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\Temporary Internet Files");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\WER");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\INetCache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\WebCache");
        }
        public static void Clear_Opera(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Opera Software\Opera Stable\Cache");
        }
        #endregion

        #region Clear RecileBin & Temp
        public static void Clear_Temp(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Temp");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\AppCache");
            DeleteFolder(@"C:\Windows\Temp");
        }
        public static void Clear_RecileBin()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                string RecyclePath = $@"{drive}$Recycle.Bin";
                DeleteFolder(RecyclePath);
            }
        }
        public static void Clear_Download(string dir)
        {
            DeleteFolder($@"{dir}\Downloads");
        }
        #endregion

        #region Cleaner Browser
        public static void CleanerChrome()
        {
            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Google Chrome...");
                
                foreach (string s in PathUser)
                {
                    Clear_Chrome(s);
                }
                Successfully?.Invoke("Очистка кэша Google Chrome завершена");
            }
        }
        public static void CleanerChromium()
        {
            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Chromium...");

                foreach (string s in PathUser)
                {
                    Clear_Chromium(s);
                }
                Successfully?.Invoke("Очистка кэша Chromium завершена");
            }
        }
        public static void CleanerYandex()
        {
            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Яндекс.Браузер...");
                
                foreach (string s in PathUser)
                {
                    Clear_Yandex(s);
                }
                Successfully?.Invoke("Очистка кэша Яндекс.Браузер завершена");
            }
        }
        public static void CleanerIE()
        {
            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Internet Explorer...");

                foreach (string s in PathUser)
                {
                    Clear_IE(s);
                }
                Successfully?.Invoke("Очистка кэша Internet Explorer завершена");
            }
        }
        public static void CleannerMozilla()
        {
            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Mozilla...");

                foreach (string s in PathUser)
                {
                    Clear_Mozilla(s);
                }
                Successfully?.Invoke("Очистка кэша Mozilla завершена");
            }
        }
        public static void CleannerOpera()
        {
            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Opera...");

                foreach (string s in PathUser)
                {
                    Clear_Opera(s);
                }
                Successfully?.Invoke("Очистка кэша Opera завершена");
            }
        }
        #endregion

        #region Cleaner RecileBin & Temp
        public static void CleanerRecileBinTemp()
        {
            Info?.Invoke("Очистка Корзины...");
            
            Clear_RecileBin();

            Successfully?.Invoke("Очистка Корзины завершена");

            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);

                Info?.Invoke("Удаление временных файлов...");

                foreach (string s in PathUser)
                {
                    Clear_Temp(s);
                }

                Successfully?.Invoke("Удаление временных файлов завершено");
            }
        }
        public static void CleannerDownload()
        {
            if (Directory.Exists(PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(PathUsers);

                Info?.Invoke("Очистка папки Загрузка...");

                foreach (string s in PathUser)
                {
                    Clear_Download(s);
                }

                Successfully?.Invoke("Очистка папки Загрузка завершена");
            }
        }
        #endregion

        #region Cleaner
        public static void CleanerBrowser()
        {
            CleanerChrome();
            CleanerChromium();
            CleanerYandex();
            CleanerIE();
            CleannerMozilla();
            CleannerOpera();
        }
        public static void CleanerRecile()
        {
            CleanerRecileBinTemp();
        }
        public static void CleannerDownloads()
        {
            CleannerDownload();
        }
        public static void CleanerAll()
        {
            CleanerBrowser();
            CleanerRecile();
            CleannerDownloads();
        }
        #endregion
    }
}
