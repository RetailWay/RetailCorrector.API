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
    /// Параметры отчёта
    /// </summary>
    public abstract Dictionary<string, string> Properties { get; }

    /// <summary>
    /// Инициализация отчёта
    /// </summary>
    /// <param name="args">Параметры отчета</param>
    public void Init(Dictionary<string, string> args)
    {
        foreach(var arg in args)
        {
            if (!Properties.ContainsKey(arg.Key)) continue;
            Properties[arg.Key] = arg.Value;
        }
    }

    /// <summary>
    /// Отправка отчета
    /// </summary>
    public abstract Task Send();
}
