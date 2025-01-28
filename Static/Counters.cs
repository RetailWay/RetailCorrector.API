namespace RetailCorrector.API.Static;

/// <summary>
/// Счетчики агента
/// </summary>
public static class Counters
{
    /// <summary>
    /// Количество успешных отправок
    /// </summary>
    public static int SuccessCount { get; set; }

    /// <summary>
    /// Количество всех отправок
    /// </summary>
    public static int TotalCount { get; set; }

    /// <summary>
    /// Обнуление счетчиков
    /// </summary>
    public static void Reset() => SuccessCount = TotalCount = 0;
}
