namespace RetailCorrector.API;

/// <summary>
/// Тип отчета
/// </summary>
public interface IReport
{
    /// <summary>
    /// Идентификатор отчета
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Инициализация отчёта
    /// </summary>
    /// <param name="args">Параметры отчета</param>
    public void Init(Dictionary<string, object> args);

    /// <summary>
    /// Отправка отчета
    /// </summary>
    public Task Send();

    /// <summary>
    /// Получить значение из параметров отчета или выдать исключение
    /// </summary>
    /// <typeparam name="T">Тип значения параметра отчета</typeparam>
    /// <param name="dict">Параметры отчета</param>
    /// <param name="key">Наименование параметра отчета</param>
    /// <returns>Значение параметра отчета</returns>
    /// <exception cref="ArgumentNullException">Параметр отсутствует</exception>
    /// <exception cref="FormatException">Параметр не подходящего типа</exception>
    protected static T GetOrThrow<T>(Dictionary<string, object> dict, string key)
    {
        if (!dict.TryGetValue(key, out var raw))
            throw new ArgumentNullException(key);
        if (raw is T result)
            return result;
        throw new FormatException();
    }

    /// <summary>
    /// Получить значение из параметров отчета или использовать значение по умолчанию
    /// </summary>
    /// <typeparam name="T">Тип значения параметра отчета</typeparam>
    /// <param name="dict">Параметры отчета</param>
    /// <param name="key">Наименование параметра отчета</param>
    /// <param name="defaultValue">Значение параметра по-умолчанию</param>
    /// <returns>Значение параметра отчета</returns>
    protected static T GetOrDefault<T>(Dictionary<string, object> dict, string key, T defaultValue)
    {
        if (!dict.TryGetValue(key, out var raw))
            return defaultValue;
        if (raw is T result)
            return result;
        return defaultValue;
    }
}
