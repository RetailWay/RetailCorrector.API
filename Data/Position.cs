using RetailCorrector.API.Types;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data;

/// <summary>
/// Структура "Позиция чека"
/// </summary>
public struct Position
{
    /// <summary>
    /// Наименование
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    [JsonPropertyName("quantity")]
    public Quantity Quantity { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    [JsonPropertyName("price")]
    public Currency Price { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    [JsonPropertyName("total")]
    public Currency Sum { get; set; }

    /// <summary>
    /// Ставка НДС
    /// </summary>
    [JsonPropertyName("tax")]
    public TaxRate TaxRate { get; set; }

    /// <summary>
    /// Единица измерения
    /// </summary>
    [JsonPropertyName("measure")]
    public MeasureUnit MeasureUnit { get; set; }

    /// <summary>
    /// Тип позиции
    /// </summary>
    [JsonPropertyName("type")]
    public byte ItemType { get; set; }

    /// <summary>
    /// Способ оплаты
    /// </summary>
    [JsonPropertyName("payment")]
    public byte PayMethod { get; set; }
}
