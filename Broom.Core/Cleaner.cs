using System;
using System.Collections.Generic;

namespace Broom.Core;

/// <summary>
/// Класс для очистки. Выполняет все операции, которые были добавлены в список.
/// </summary>
public class Cleaner
{
    private readonly IList<Action> _actions = new List<Action>();

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
    public void Clean() //TODO Добавить агрегацию ошибок
    {
        foreach (var action in _actions)
        {
            action();
        }
    }
}
