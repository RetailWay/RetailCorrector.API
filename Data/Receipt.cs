using RetailCorrector.API.Types;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data
{
    public struct Receipt
    {
        [JsonIgnore]
        public int DocId { get; set; }
        [JsonPropertyName("operation")]
        public Operation Operation { get; set; }
        [JsonPropertyName("items")]
        public Position[] Items { get; set; }
        [JsonPropertyName("correction")]
        public CorrectionData Correction { get; set; }
        [JsonPropertyName("payment")]
        public Payment Payment { get; set; }
        [JsonPropertyName("total")]
        public Currency Total { get; set; }
    }
}
