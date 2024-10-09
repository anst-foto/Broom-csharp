using System;
using System.Collections.Generic;

namespace Broom.Core;

/// <summary>
/// Класс для очистки. Выполняет все операции, которые были добавлены в список.
/// </summary>
public class Cleaner
{
    /// <summary>
    /// Набор действий для очистки
    /// </summary>
    private readonly IList<Action> _actions = new List<Action>();

    /// <summary>
    /// Список ошибок
    /// </summary>
    public readonly IList<Exception> Errors = new List<Exception>();

    /// <summary>
    /// Добавляет действие в очередь
    /// </summary>
    /// <param name="action">Операция по очистке</param>
    /// <returns>Ссылка на самого себя</returns>
    public Cleaner Add(Action action)
    {
        _actions.Add(action);
        return this;
    }

    /// <summary>
    /// Выполняет все действия в очереди
    /// </summary>
    public void Clean()
    {
        foreach (var action in _actions)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Errors.Add(e);
            }
        }
    }
}
