using RetailCorrector.API.Types;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data
{
    /// <summary>
    /// Структура "Чек"
    /// </summary>
    public struct Receipt
    {
        /// <summary>
        /// Номер чека
        /// </summary>
        [JsonIgnore]
        public int DocId { get; set; }

        /// <summary>
        /// Операция чека
        /// </summary>
        [JsonPropertyName("operation")]
        public Operation Operation { get; set; }

        /// <summary>
        /// Позиции чека
        /// </summary>
        [JsonPropertyName("items")]
        public Position[] Items { get; set; }

        /// <summary>
        /// Основание коррекции чека
        /// </summary>
        [JsonPropertyName("correction")]
        public CorrectionData Correction { get; set; }

        /// <summary>
        /// Оплата чека
        /// </summary>
        [JsonPropertyName("payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// Итоговая сумма чека
        /// </summary>
        [JsonPropertyName("total")]
        public Currency Total { get; set; }
    }
}
