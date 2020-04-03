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

        private const string PathUsers = @"C:\Users\";

        private static void DeleteFolder(string directory)
        {
            if (Directory.Exists(directory))
            {
                try
                {
                    var dirs = Directory.GetDirectories(directory);
                    foreach (var dir in dirs)
                    {
                        try
                        {
                            var path = new DirectoryInfo($@"{dir}");
                            path.Attributes &= ~FileAttributes.ReadOnly;
                            path.Delete(true);

                            Successfully?.Invoke($"{directory} успешно удалено");
                        }
                        catch (DirectoryNotFoundException ex)
                        {
                            Error?.Invoke("Директория не найдена! Ошибка: " + ex.Message);
                        }
                        catch (IOException ex)
                        {
                            Error?.Invoke("Директория уже используется! Ошибка: " + ex.Message);
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

                    var files = Directory.GetFiles(directory);
                    foreach (var file in files)
                    {
                        try
                        {
                            File.Delete(file);

                            Successfully?.Invoke($"{file} успешно удалён");
                        }
                        catch (DirectoryNotFoundException ex)
                        {
                            Error?.Invoke("Директория не найдена! Ошибка: " + ex.Message);
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            Error?.Invoke("Отсутствует доступ! Ошибка: " + ex.Message);
                        }
                        catch (IOException ex)
                        {
                            Error?.Invoke("Указанный файл используется! Ошибка: " + ex.Message);
                        }
                        catch (NotSupportedException ex)
                        {
                            Error?.Invoke("Параметр 'path' задан в недопустимом формате! Ошибка: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Error?.Invoke("Ошибка: " + ex.Message);
                        }
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    Error?.Invoke("Директория не найдена! Ошибка: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Error?.Invoke("Директория уже используется! Ошибка: " + ex.Message);
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
        }

        #region Clear Browser
        private static void Clear_Edge(string dir)
        {
            // Edge
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge\User Data\Default\Media Cache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge\User Data\Default\GPUCache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge\User Data\Default\Storage\ext");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge\User Data\Default\Service Worker");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge\User Data\ShaderCache");

            // Edge SxS
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge SxS\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge SxS\User Data\Default\Media Cache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge SxS\User Data\Default\GPUCache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge SxS\User Data\Default\Storage\ext");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge SxS\User Data\Default\Service Worker");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Edge SxS\User Data\ShaderCache");
        }

        private static void Clear_Vivaldi(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Vivaldi\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Vivaldi\User Data\Default\GPUCache");
            DeleteFolder($@"{dir}\AppData\Local\Vivaldi\User Data\Default\Application Cache");
            DeleteFolder($@"{dir}\AppData\Local\Vivaldi\User Data\Default\Cookies");
            DeleteFolder($@"{dir}\AppData\Local\Vivaldi\User Data\Default\Cookies-Journal");
        }

        private static void Clear_Mozilla(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\OfflineCache");
            DeleteFolder($@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\cache2\entries");
            DeleteFolder($@"{dir}\AppData\Local\Mozilla\Firefox\Profiles\*.default\thumbnails");
        }

        private static void Clear_Chrome(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cache2\entries");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Media Cache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\ChromeDWriteFontCache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\GPUCache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Storage\ext");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Service Worker");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\ShaderCache");
        }

        private static void Clear_Chromium(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Cache");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\GPUCache");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Media Cache");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Pepper Data");
            DeleteFolder($@"{dir}\AppData\Local\Chromium\User Data\Default\Application Cache");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal");
            DeleteFolder($@"{dir}\AppData\Local\Google\Chrome\User Data\Default\Cookies");
        }

        private static void Clear_Yandex(string dir)
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

        private static void Clear_IE(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\Temporary Internet Files");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\WER");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\INetCache");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\WebCache");
        }

        private static void Clear_Opera(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Roaming\Opera Software\Opera Stable\GPUCache");
            DeleteFolder($@"{dir}\AppData\Roaming\Opera Software\Opera Stable\ShaderCache");
            DeleteFolder($@"{dir}\AppData\Roaming\Opera Software\Opera Stable\Jump List Icons");
            DeleteFolder($@"{dir}\AppData\Roaming\Opera Software\Opera Stable\Jump List IconsOld\Jump List Icons");
            DeleteFolder($@"{dir}\AppData\Local\Opera Software\Opera Stable\Cache");
        }
        #endregion

        #region Clear RecileBin & Temp

        private static void Clear_Temp(string dir)
        {
            DeleteFolder($@"{dir}\AppData\Local\Temp");
            DeleteFolder($@"{dir}\AppData\Local\Microsoft\Windows\AppCache");
            DeleteFolder(@"C:\Windows\Temp");
        }

        private static void Clear_RecileBin()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                var RecyclePath = $@"{drive}$Recycle.Bin";
                DeleteFolder(RecyclePath);
            }
        }

        private static void Clear_Download(string dir)
        {
            DeleteFolder($@"{dir}\Downloads");
        }
        #endregion

        #region Cleaner Browser

        private static void CleanerChrome()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Google Chrome...");
                
                foreach (var path in PathUser)
                {
                    Clear_Chrome(path);
                }
                Successfully?.Invoke("Очистка кэша Google Chrome завершена");
            }
        }

        private static void CleanerChromium()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Chromium...");

                foreach (var path in PathUser)
                {
                    Clear_Chromium(path);
                }
                Successfully?.Invoke("Очистка кэша Chromium завершена");
            }
        }

        private static void CleanerYandex()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Яндекс.Браузер...");
                
                foreach (var path in PathUser)
                {
                    Clear_Yandex(path);
                }
                Successfully?.Invoke("Очистка кэша Яндекс.Браузер завершена");
            }
        }

        private static void CleanerIE()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Internet Explorer...");

                foreach (var path in PathUser)
                {
                    Clear_IE(path);
                }
                Successfully?.Invoke("Очистка кэша Internet Explorer завершена");
            }
        }

        private static void CleanerEdge()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Edge...");

                foreach (var path in PathUser)
                {
                    Clear_Edge(path);
                }
                Successfully?.Invoke("Очистка кэша Edge завершена");
            }
        }

        private static void CleanerVivaldi()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Vivaldi...");

                foreach (var path in PathUser)
                {
                    Clear_Vivaldi(path);
                }
                Successfully?.Invoke("Очистка кэша Vivaldi завершена");
            }
        }

        private static void CleanerMozilla()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Mozilla...");

                foreach (var path in PathUser)
                {
                    Clear_Mozilla(path);
                }
                Successfully?.Invoke("Очистка кэша Mozilla завершена");
            }
        }

        private static void CleanerOpera()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);
                Info?.Invoke("Очистка кэша Opera...");

                foreach (var path in PathUser)
                {
                    Clear_Opera(path);
                }
                Successfully?.Invoke("Очистка кэша Opera завершена");
            }
        }
        #endregion

        #region Cleaner RecileBin & Temp

        private static void CleanerRecileBinTemp()
        {
            Info?.Invoke("Очистка Корзины...");
            
            Clear_RecileBin();

            Successfully?.Invoke("Очистка Корзины завершена");

            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);

                Info?.Invoke("Удаление временных файлов...");

                foreach (var path in PathUser)
                {
                    Clear_Temp(path);
                }

                Successfully?.Invoke("Удаление временных файлов завершено");
            }
        }

        private static void CleanerDownload()
        {
            if (Directory.Exists(PathUsers))
            {
                var PathUser = Directory.GetDirectories(PathUsers);

                Info?.Invoke("Очистка папки Загрузка...");

                foreach (var path in PathUser)
                {
                    Clear_Download(path);
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
            CleanerEdge();
            CleanerVivaldi();
            CleanerMozilla();
            CleanerOpera();
        }
        public static void CleanerRecile()
        {
            CleanerRecileBinTemp();
        }
        public static void CleanerDownloads()
        {
            CleanerDownload();
        }
        public static void CleanerAll()
        {
            CleanerBrowser();
            CleanerRecile();
            CleanerDownloads();
        }
        #endregion
    }
}
