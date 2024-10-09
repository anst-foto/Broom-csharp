﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using Broom.Core.Exceptions;
using NLog;

namespace Broom.Core;

/// <summary>
/// Класс очистки
/// </summary>
public static class Cleaner
{
    public static ILogger? Logger { get; set; }

    /// <summary>
    /// Очистка корзины
    /// </summary>
    [Obsolete("Этот метод нельзя использовать")]
    public static void CleaningRecycleBin() //FIXME
    {
        var drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            var recyclePath = Path.Combine(drive.RootDirectory.FullName,"$Recycle.Bin");

            DeleteService.DeleteDirectoryAndFiles(recyclePath);
            Logger?.Info($"Deleted {recyclePath}");
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

    /// <summary>
    /// Очистка корзины через WinApi
    /// </summary>
    public static void CleaningRecycleBinWinApi()
    {
        var result = SHEmptyRecycleBin(IntPtr.Zero, "",
            RecycleFlags.SHERB_NOCONFIRMATION + (int)RecycleFlags.SHERB_NOPROGRESSUI + (int)RecycleFlags.SHERB_NOSOUND);
        if (result == 0)
        {
            Logger?.Info("Корзина очищена");
        }
        else
        {
            Logger?.Error("Ошибка при очистке корзины");
            throw new CleaningRecycleBinException();
        }
    }

    /// <summary>
    /// Очистка временных файлов
    /// </summary>
    public static void CleaningTemp()
    {

    }
}
