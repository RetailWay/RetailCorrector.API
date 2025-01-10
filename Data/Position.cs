using RetailCorrector.API.Types;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data
{
    public struct Position
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }
        [JsonPropertyName("price")]
        public Currency Price { get; set; }
        [JsonPropertyName("total")]
        public Currency Sum { get; set; }
        [JsonPropertyName("tax")]
        public int TaxRate { get; set; }
        [JsonPropertyName("measure")]
        public int? MeasureUnit { get; set; }
        [JsonPropertyName("type")]
        public int ItemType { get; set; }
        [JsonPropertyName("payment")]
        public int PayMethod { get; set; }
    }
}
