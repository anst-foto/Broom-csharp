using System;

namespace Broom.Core.Exceptions;

/// <summary>
/// Исключение, возникающее если не удалось установить режим доступа к файлу/папке.
/// </summary>
/// <param name="path">Путь к файлу/папке</param>
/// <param name="innerException">Вложенное исключение</param>
public class ReadOnlyAttributeException(string path, Exception? innerException = null)
    : Exception($"Не удалось установить режим доступа у {path}", innerException);

/// <summary>
/// Исключение, возникающее если не найден файл/папка.
/// </summary>
/// <param name="path">Путь к файлу/папке</param>
/// <param name="innerException">Вложенное исключение</param>
public class NotFoundException(string path, Exception? innerException = null)
    : Exception($"Не найдено {path}", innerException);

/// <summary>
/// Исключение, возникающее если не удалось удалить файл/папку.
/// </summary>
/// <param name="path">Путь к файлу/папке</param>
/// <param name="innerException">Вложенное исключение</param>
public class DeleteException(string path, Exception? innerException = null)
    : Exception($"Не удалось удалить {path}", innerException);

/// <summary>
/// Исключение, возникающее если не удалось очистить корзину.
/// </summary>
public class CleaningRecycleBinException()
    : Exception($"Не удалось очистить корзину");

/// <summary>
/// Исключение, возникающее если не удалось очистить временные файлы.
/// </summary>
public class CleaningTempException()
    : Exception($"Не удалось очистить временные файлы");
