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
    /// Параметры отчёта
    /// </summary>
    public Dictionary<string, string> Properties { get; }

    /// <summary>
    /// Отправка отчета
    /// </summary>
    public Task Send();
}
