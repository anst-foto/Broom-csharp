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
        private string LogPath;
        static StreamWriter LogFile;
        private bool Visible;
        #endregion       

        #region Constructor
        public Clean()
        {
            Console.Title = "Broom";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            PathUsers = @"C:\Users\";
            TempPath = @"C:\Windows\Temp";
            LogPath = @"C:\broom.log";

            if (!File.Exists(LogPath)) File.Create(LogPath);           

            LogFile = new StreamWriter(path: LogPath, true, Encoding.Default);

            LogFile.WriteLine("------------------------------");
            LogFile.WriteLine("");
            LogFile.WriteLine(DateTime.Now);
            LogFile.WriteLine("");
        }
        #endregion

        public void SetVisible(bool visible)
        {
            Visible = visible;
        }

        #region Output
        public void OutputConsole(string str, bool visible)
        {
            if (visible)
            {
                Console.WriteLine();
                Console.WriteLine(str);
                Console.WriteLine();
            }            
        }
        public void OutputConsoleError(string str, bool visible)
        {
            if (visible)
            {
                Console.WriteLine();
                Console.WriteLine("***********************");
                Console.WriteLine(str);
                Console.WriteLine("***********************");
                Console.WriteLine();
            }
        }
        public void OutputLogFile(string str)
        {

        }
        #endregion

        #region Delete Folder & File
        public void DeleteFolder(string directory)
        {
            try
            {
                var dir = new DirectoryInfo(path: $@"{directory}");
                dir.Attributes &= ~FileAttributes.ReadOnly;
                dir.Delete(recursive: true);

                Console.ForegroundColor = ConsoleColor.Blue;
                OutputConsole(str: $"{directory} успешно удалено", visible: Visible);

                LogFile.WriteLine($"{directory} успешно удалено");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                OutputConsoleError("Директория не найдена! Ошибка: " + ex.Message, Visible);                
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                LogFile.WriteLine("Директория не найдена! Ошибка: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                OutputConsoleError("Отсутствует доступ! Ошибка: " + ex.Message, Visible);
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                LogFile.WriteLine("Отсутствует доступ! Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                OutputConsoleError("Ошибка: " + ex.Message, Visible);
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                LogFile.WriteLine("Ошибка: " + ex.Message);
            }
        }
        #endregion

        #region Clear Browser
        public void Clear_Mozilla(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\OfflineCache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\cache2\entries");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\thumbnails");
        }
        public void Clear_Chrome(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache2\entries");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Media Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\ChromeDWriteFontCache");
        }
        public void Clear_Chromium(string dir)
        {

            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\GPUCache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Media Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Pepper Data");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Chromium\User Data\Default\Application Cache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");

        }
        public void Clear_Yandex(string dir)
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
        public void Clear_IE(string dir)
        {
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\Temporary Internet Files");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\WER");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\INetCache");
            DeleteFolder(directory: $@"{dir}\AppData\Local\Microsoft\Windows\WebCache");
        }
        public void Clear_Opera(string dir)
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
                OutputConsole("Очистка кэша Google Chrome...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Google Chrome...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_Temp(dir: s);
                }
                OutputConsole("Очистка кэша Google Chrome завершена", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Google Chrome завершена");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
            }
        }
        public void CleanerChromium()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                OutputConsole("Очистка кэша Chromium...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Chromium...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_Chromium(dir: s);
                }
                OutputConsole("Очистка кэша Chromium завершена", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Chromium завершена");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
            }
        }
        public void CleanerYandex()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                OutputConsole("Очистка кэша Яндекс.Браузер...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Яндекс.Браузер...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_Yandex(dir: s);
                }
                OutputConsole("Очистка кэша Яндекс.Браузер завершена", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Яндекс.Браузер завершена");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
            }
        }
        public void CleanerIE()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                OutputConsole("Очистка кэша Internet Explorer...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Internet Explorer...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_IE(dir: s);
                }
                OutputConsole("Очистка кэша Internet Explorer завершена", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Internet Explorer завершена");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
            }
        }
        public void CleannerMozilla()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                OutputConsole("Очистка кэша Mozilla...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Mozilla...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_Mozilla(dir: s);
                }
                OutputConsole("Очистка кэша Mozilla завершена", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Mozilla завершена");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
            }
        }
        public void CleannerOpera()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);
                OutputConsole("Очистка кэша Opera...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Opera...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_Opera(dir: s);
                }
                OutputConsole("Очистка кэша Opera завершена", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка кэша Opera завершена");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
            }
        }
        #endregion

        #region Cleaner RecileBin & Temp
        public void CleanerRecileBinTemp()
        {
            OutputConsole("Очистка Корзины...", Visible);

            LogFile.WriteLine("");
            LogFile.WriteLine("Очистка Корзины...");
            LogFile.WriteLine("---------------");

            Clear_RecileBin();

            OutputConsole("Очистка Корзины завершена", Visible);

            LogFile.WriteLine("");
            LogFile.WriteLine("Очистка Корзины завершена");
            LogFile.WriteLine("---------------");
            LogFile.WriteLine("");

            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);

                OutputConsole("Удаление временных файлов...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Удаление временных файлов...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_Temp(dir: s);
                }

                OutputConsole("Удаление временных файлов завершено", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Удаление временных файлов завершено");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
            }
        }
        public void CleannerDownload()
        {
            if (Directory.Exists(path: PathUsers))
            {
                string[] PathUser = Directory.GetDirectories(path: PathUsers);

                OutputConsole("Очистка папки Загрузка...", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка папки Загрузка...");
                LogFile.WriteLine("---------------");

                foreach (string s in PathUser)
                {
                    Clear_Download(dir: s);
                }

                OutputConsole("Очистка папки Загрузка завершена", Visible);

                LogFile.WriteLine("");
                LogFile.WriteLine("Очистка папки Загрузка завершена");
                LogFile.WriteLine("---------------");
                LogFile.WriteLine("");
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

        public void LogFileClose()
        {
            LogFile.Close();
        }
    }
}
