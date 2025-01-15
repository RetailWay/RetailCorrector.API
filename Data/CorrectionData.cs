using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data;

/// <summary>
/// Структура "Основание коррекции"
/// </summary>
public struct CorrectionData
{
    /// <summary>
    /// Дата отбития оригинального чека
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Фискальный признак оригинального чека
    /// </summary>
    [JsonPropertyName("sign")]
    public string FiscalSign { get; set; }

    /// <summary>
    /// Номер приложенного документа
    /// </summary>
    /// <remarks>
    /// Используется в двух случаях:<br/>
    /// 1. При использовании коррекционного чека на ФФД 1.05 => номер подготовленного акта<br/>
    /// 2. При запросе исправить чек от ФНС => номер предписания
    /// </remarks>
    [JsonPropertyName("orderId")]
    public string DocId { get; set; }
}
