using System;
using System.IO;
using Broom.Core.Exceptions;
using NLog;

namespace Broom.Core;

/// <summary>
///     Класс для удаления файлов и папок
/// </summary>
/// <remarks>Работа с файлами и папками через FileInfo и DirectoryInfo</remarks>
public static partial class DeleteService
{
    /// <summary>
    ///     Логгер
    /// </summary>
    public static ILogger? Logger { get; set; }

    /// <summary>
    ///     Проверка на существование директории
    /// </summary>
    /// <param name="directory">Директория</param>
    /// <exception cref="NotFoundException">Исключение, если директория не существует</exception>
    private static void ThrowIfNotFoundDirectory(DirectoryInfo directory)
    {
        if (directory.Exists) return;

        Logger?.Error($"Директория ({directory.FullName}) не существует");
        throw new NotFoundException(directory.FullName);
    }

    /// <summary>
    ///     Проверка на существование файла
    /// </summary>
    /// <param name="file">Файл</param>
    /// <exception cref="NotFoundException">Исключение, если файл не существует</exception>
    private static void ThrowIfNotFoundFile(FileInfo file)
    {
        if (file.Exists) return;

        Logger?.Error($"Файл ({file.FullName}) не существует");
        throw new NotFoundException(file.FullName);
    }

    /// <summary>
    ///     Удаление атрибута ReadOnly у директории
    /// </summary>
    /// <param name="directory">Директория</param>
    /// <exception cref="NotFoundException">Исключение, если директория не существует</exception>
    /// <exception cref="ReadOnlyAttributeException">Исключение, если у директории не удалось удалить атрибут ReadOnly</exception>
    public static void RemovingReadOnlyAttributeDirectory(DirectoryInfo directory)
    {
        ThrowIfNotFoundDirectory(directory);

        directory.Attributes &= ~FileAttributes.ReadOnly;
        if (directory.Attributes != FileAttributes.Normal)
        {
            Logger?.Error($"Directory {directory.FullName} attributes are not normal");
            throw new ReadOnlyAttributeException(directory.FullName);
        }

        Logger?.Info($"Set {directory.FullName} attributes to normal");
    }

    /// <summary>
    ///     Удаление атрибута ReadOnly у файла
    /// </summary>
    /// <param name="file">Файл</param>
    /// <exception cref="NotFoundException">Исключение, если файл не существует</exception>
    /// <exception cref="ReadOnlyAttributeException">Исключение, если у файла не удалось удалить атрибут ReadOnly</exception>
    public static void RemovingReadOnlyAttributeFile(FileInfo file)
    {
        ThrowIfNotFoundFile(file);

        file.Attributes = FileAttributes.Normal;
        if (file.Attributes != FileAttributes.Normal)
        {
            Logger?.Error($"File {file.FullName} attributes are not normal");
            throw new ReadOnlyAttributeException(file.FullName);
        }

        Logger?.Info($"Set {file.FullName} attributes to normal");
    }

    /// <summary>
    ///     Удаление файла
    /// </summary>
    /// <param name="file">Файл</param>
    /// <exception cref="NotFoundException">Исключение, если файл не существует</exception>
    /// <exception cref="DeleteException">Исключение, если не удалось удалить файл</exception>
    public static void DeleteFile(FileInfo file)
    {
        ThrowIfNotFoundFile(file);

        try
        {
            file.Delete();
        }
        catch (Exception e)
        {
            Logger?.Error(e, $"Delete file {file.FullName} error");
            throw new DeleteException(file.FullName, e);
        }
    }
}
