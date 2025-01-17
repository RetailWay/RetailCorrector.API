namespace RetailCorrector.API;

/// <summary>
/// Тип отчета
/// </summary>
public abstract class Report
{
    /// <summary>
    /// Идентификатор отчета
    /// </summary>
    public abstract string Id { get; }

    /// <summary>
    /// Инициализация отчёта
    /// </summary>
    /// <param name="args">Параметры отчета</param>
    public abstract void Init(Dictionary<string, object> args);

    /// <summary>
    /// Отправка отчета
    /// </summary>
    public abstract Task Send();

    /// <summary>
    /// Присвоить значение параметру
    /// </summary>
    /// <param name="key">Название параметра</param>
    /// <param name="value">Значение параметра</param>
    /// <exception cref="Exception"></exception>
    public void SetProperty(string key, object value)
    {
        var property = GetType().GetField(key) ?? throw new Exception();
        property.SetValue(this, value);
    }

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
