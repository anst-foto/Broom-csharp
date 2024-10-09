using System;
using System.IO;
using Broom.Core.Exceptions;

namespace Broom.Core;

/// <summary>
/// Класс для удаления файлов и папок
/// </summary>
/// <remarks>Работа с файлами и папками через путь к файлу/директории</remarks>
public static partial class DeleteService
{
    /// <summary>
    /// Проверка на существование директории
    /// </summary>
    /// <param name="path">Путь к директории</param>
    /// <exception cref="NotFoundException">Исключение, если директория не существует</exception>
    private static void ThrowIfNotFoundDirectory(string path)
    {
        if (Directory.Exists(path)) return;

        Logger?.Error($"Директория ({path}) не существует");
        throw new NotFoundException(path);
    }

    /// <summary>
    /// Проверка на существование файла
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <exception cref="NotFoundException">Исключение, если файл не существует</exception>
    private static void ThrowIfNotFoundFile(string path)
    {
        if (File.Exists(path)) return;

        Logger?.Error($"Файл ({path}) не существует");
        throw new NotFoundException(path);
    }

    /// <summary>
    /// Удаление атрибута ReadOnly у директории
    /// </summary>
    /// <param name="path">Путь к директории</param>
    /// <exception cref="NotFoundException">Исключение, если директория не существует</exception>
    /// <exception cref="ReadOnlyAttributeException">Исключение, если у директории не удалось удалить атрибут ReadOnly</exception>
    public static void RemovingReadOnlyAttributeDirectory(string path)
    {
        ThrowIfNotFoundDirectory(path);

        var directory = new DirectoryInfo(path);
        directory.Attributes &= ~FileAttributes.ReadOnly;
        if (directory.Attributes != FileAttributes.Normal)
        {
            Logger?.Error($"Directory {directory.FullName} attributes are not normal");
            throw new ReadOnlyAttributeException(path);
        }
        Logger?.Info($"Set {directory.FullName} attributes to normal");
    }

    /// <summary>
    /// Удаление атрибута ReadOnly у файла
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <exception cref="NotFoundException">Исключение, если файл не существует</exception>
    /// <exception cref="ReadOnlyAttributeException">Исключение, если у файла не удалось удалить атрибут ReadOnly</exception>
    public static void RemovingReadOnlyAttributeFile(string path)
    {
        ThrowIfNotFoundFile(path);

        var file = new FileInfo(path)
        {
            Attributes = FileAttributes.Normal
        };

        if (file.Attributes != FileAttributes.Normal)
        {
            Logger?.Error($"Файлу {file.FullName} не удалось удалить атрибут ReadOnly");
            throw new ReadOnlyAttributeException(path);
        }

        Logger?.Info($"У файла {file.FullName} удалось удалить атрибут ReadOnly");
    }

    /// <summary>
    /// Удаление файлов и директории
    /// </summary>
    /// <param name="path">Путь к директории</param>
    public static void DeleteDirectoryAndFiles(string path)
    {
        ThrowIfNotFoundDirectory(path);

        var directory = new DirectoryInfo(path);
        var files = directory.GetFiles();
        foreach (var file in files)
        {
            DeleteFile(file);
        }

        directory.Delete(true); //FIXME  ??? recursive ???
        Logger?.Info($"Директория {directory.FullName} удалена");
    }

    /// <summary>
    /// Удаление файла
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <exception cref="NotFoundException">Исключение, если файл не существует</exception>
    /// <exception cref="DeleteException">Исключение, если не удалось удалить файл</exception>
    public static void DeleteFile(string path)
    {
        ThrowIfNotFoundFile(path);

        try
        {
            var file = new FileInfo(path);
            file.Delete();
        }
        catch (Exception e)
        {
            Logger?.Error($"Ошибка удаления файла {path}", e);
            throw new DeleteException(path, e);
        }
    }
}
