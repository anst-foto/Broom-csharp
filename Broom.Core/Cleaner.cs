using System;
using System.IO;
using System.Runtime.InteropServices;
using NLog;

namespace Broom.Core;

public static class Cleaner
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    [Obsolete("Этот метод нельзя использовать")]
    public static void CleaningRecycleBin() //FIXME
    {
        var drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            var recyclePath = Path.Combine(drive.RootDirectory.FullName,"$Recycle.Bin");

            DeleteService.DeleteFiles(recyclePath);
            Logger.Info($"Deleted {recyclePath}");
        }
    }


    private enum RecycleFlags : int
    {
        SHERB_NOCONFIRMATION = 0x00000001,
        SHERB_NOPROGRESSUI = 0x00000002,
        SHERB_NOSOUND = 0x00000004
    }
    [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
    private static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

    public static void CleaningRecycleBinWinApi()
    {
        var result = SHEmptyRecycleBin(IntPtr.Zero, null,
            RecycleFlags.SHERB_NOCONFIRMATION + (int)RecycleFlags.SHERB_NOPROGRESSUI + (int)RecycleFlags.SHERB_NOSOUND);
        if (result == 0)
        {
            Logger.Info("Recycle bin is empty");
        }
        else
        {
            Logger.Error("Recycle bin is not empty");
        }
    }

    public static void CleaningTemp()
    {

    }
}
