using Newtonsoft.Json;

namespace RetailCorrector.API.Data
{

    /// <summary>
    /// Структура "Тип чека"
    /// </summary>
    public struct Operation
    {
        /// <summary>
        /// Является документ - чеком прихода?
        /// </summary>
        [JsonProperty("income")]
        public bool IsIncome { get; set; }

        /// <summary>
        /// Является документ - чеком возврата?
        /// </summary>
        [JsonProperty("refund")]
        public bool IsRefund { get; set; }

        /// <summary>
        /// Конвертация в числовую форму (для коррекционного чека)
        /// </summary>
        [JsonIgnore]
        public int CorrectionType =>
            7 + (IsIncome ? 0 : 2) + (IsRefund ? 1 : 0);

        /// <summary>
        /// Конвертация в числовую форму
        /// </summary>
        [JsonIgnore]
        public int ReceiptType =>
            1 + (IsIncome ? 0 : 3) + (IsRefund ? 1 : 0);
    }
}