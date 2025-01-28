using RetailCorrector.API.Types;
using Newtonsoft.Json;

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
        [JsonProperty("cash")]
        public Currency CashSum { get; set; }

        /// <summary>
        /// Безналичная оплата
        /// </summary>
        [JsonProperty("ecash")]
        public Currency EcashSum { get; set; }

        /// <summary>
        /// Предоплата (аванс)
        /// </summary>
        [JsonProperty("prepaid")]
        public Currency PrepaidSum { get; set; }

        /// <summary>
        /// Постоплата (кредит)
        /// </summary>
        [JsonProperty("postpaid")]
        public Currency PostpaidSum { get; set; }

        /// <summary>
        /// Встречное предоставление
        /// </summary>
        [JsonProperty("provision")]
        public Currency ProvisionSum { get; set; }
    }
}