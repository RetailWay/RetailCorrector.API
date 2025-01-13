using RetailCorrector.API.Types;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data
{
    /// <summary>
    /// Структура "Оплата чека"
    /// </summary>
    public struct Payment
    {
        /// <summary>
        /// Наличная оплата
        /// </summary>
        [JsonPropertyName("cash")]
        public Currency CashSum { get; set; }

        /// <summary>
        /// Безналичная оплата
        /// </summary>
        [JsonPropertyName("ecash")]
        public Currency EcashSum { get; set; }

        /// <summary>
        /// Предоплата (аванс)
        /// </summary>
        [JsonPropertyName("prepaid")]
        public Currency PrepaidSum { get; set; }

        /// <summary>
        /// Постоплата (кредит)
        /// </summary>
        [JsonPropertyName("credit")]
        public Currency PostpaidSum { get; set; }

        /// <summary>
        /// Встречное предоставление
        /// </summary>
        [JsonPropertyName("provision")]
        public Currency ProvisionSum { get; set; }
    }
}
