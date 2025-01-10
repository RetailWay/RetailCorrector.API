using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data
{
    public struct Operation
    {
        [JsonPropertyName("income")]
        public bool IsIncome { get; set; }
        [JsonPropertyName("refund")]
        public bool IsRefund { get; set; }

        [JsonIgnore]
        public readonly int CorrectionType => 
            7 + (IsIncome ? 0 : 2) + (IsRefund ? 1 : 0);
        [JsonIgnore]
        public readonly int ReceiptType => 
            1 + (IsIncome ? 0 : 3) + (IsRefund ? 1 : 0);

        public static Operation operator !(Operation source)
        {
            source.IsRefund = !source.IsRefund;
            return source;
        }
    }
}
