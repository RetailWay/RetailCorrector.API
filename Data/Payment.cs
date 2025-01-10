using RetailCorrector.API.Types;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data
{
    public struct Payment
    {
        [JsonPropertyName("cash")]
        public Currency CashSum { get; set; }
        [JsonPropertyName("ecash")]
        public Currency EcashSum { get; set; }
        [JsonPropertyName("prepaid")]
        public Currency PrepaidSum { get; set; }
        [JsonPropertyName("credit")]
        public Currency PostpaidSum { get; set; }
        [JsonPropertyName("provision")]
        public Currency ProvisionSum { get; set; }

        [JsonIgnore]
        public readonly Currency this[int index] => 
            index switch
            {
                0 => CashSum,
                1 => EcashSum,
                2 => PrepaidSum,
                3 => PostpaidSum,
                4 => ProvisionSum,
                _ => 0
            };
    }
}
