using System;
using System.Collections.Generic;
using System.IO;

namespace BroomDLL
{
    public delegate void BrowserCleaner(string path);
    public delegate void Message(string message);
    public static class Broom
    {
        #region Event
        public static event Message Info;
        public static event Message Error;
        public static event Message Successfully;
        #endregion

        private const string PathUsers = @"C:\Users\";

        #region Delete folder and file
        private static void DeleteFolder(string dir)
        {
            try
            {
                var path = new DirectoryInfo($@"{dir}");
                path.Attributes &= ~FileAttributes.ReadOnly;
                path.Delete(true);

                Successfully?.Invoke($"{dir} успешно удалено");
            }
            catch
            {
                throw;  // проброс исключения 
            }
        }

        private static void DeleteFile(string file)
        {
            try
            {
                File.Delete(file);

                Successfully?.Invoke($"{file} успешно удалён");
            }
            catch
            {
                throw; // проброс исключения 
            }
        }

        public static void DeleteFoldersFiles(string directory)
        {
            if (!Directory.Exists(directory)) return;
            try
            {
                var dirs = Directory.GetDirectories(directory);
                foreach (var dir in dirs)
                {
                    DeleteFolder(dir);
                }

                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    DeleteFile(file);
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
        #endregion

        #region Clear 

        private static void ClearTemp(string dir)
        {
            DeleteFoldersFiles($@"{dir}\AppData\Local\Temp");
            DeleteFoldersFiles($@"{dir}\AppData\Local\Microsoft\Windows\AppCache");
            DeleteFoldersFiles(@"C:\Windows\Temp");
        }

        private static void ClearRecileBin()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                var RecyclePath = $@"{drive}$Recycle.Bin";
                DeleteFoldersFiles(RecyclePath);
            }
        }

        public static void ClearDownload(string dir)
        {
            DeleteFoldersFiles($@"{dir}\Downloads");
        }

        public static void ClearItem(string name, BrowserCleaner browser, string startMessage = "Очистка кэша")
        {
            if (!Directory.Exists(PathUsers)) return;
            var PathUser = Directory.GetDirectories(PathUsers);
            Info?.Invoke($"{startMessage} {name}...");

            foreach (var path in PathUser)
            {
                browser(path);
            }
            Successfully?.Invoke($"{startMessage} {name} завершена");
        }

        public static void CleanerRecile()
        {
            Info?.Invoke("Очистка ...");

            ClearRecileBin();

            Successfully?.Invoke("Очистка Корзины завершена");

            ClearItem("временных файлов", ClearTemp, "Очистка");
        }

        public static void CleanerDownload()
        {
            ClearItem("папки Загрузка", ClearDownload, "Очистка");
        }

        public static void CleanerAll()
        {
            CommonBrowsers.CleanerBrowsers();
            CleanerRecile();
            CleanerDownload();
        }
        #endregion
    }
}
