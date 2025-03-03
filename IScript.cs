﻿using RetailCorrector.API.Data;

namespace RetailCorrector.API;

/// <summary>
/// Сценарий изменения чеков
/// </summary>
public interface IScript
{
    /// <summary>
    /// Необходимо ли отменять чеки?
    /// </summary>
    public bool NeedCancel { get; }

    /// <summary>
    /// Фильтр чеков, которые будут откорректированы
    /// </summary>
    public bool Filter(Receipt receipt);

    /// <summary>
    /// Действие сценария
    /// </summary>
    /// <param name="origin">Список оригинальных чеков</param>
    /// <returns>Список исправленных чеков</returns>
    public Task<List<Receipt>> Edit(List<Receipt> origin);
}
