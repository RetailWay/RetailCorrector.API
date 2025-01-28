using RetailCorrector.API.Types;
using Newtonsoft.Json;

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
        [JsonProperty("operation")]
        public Operation Operation { get; set; }

        /// <summary>
        /// Позиции чека
        /// </summary>
        [JsonProperty("items")]
        public Position[] Items { get; set; }

        /// <summary>
        /// Основание коррекции чека
        /// </summary>
        [JsonProperty("correction")]
        public CorrectionData Correction { get; set; }

        /// <summary>
        /// Оплата чека
        /// </summary>
        [JsonProperty("payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// Итоговая сумма чека
        /// </summary>
        [JsonProperty("total")]
        public Currency Total { get; set; }
    }
}