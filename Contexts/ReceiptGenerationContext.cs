using RetailCorrector.API.Data;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Contexts
{
    [JsonSourceGenerationOptions(WriteIndented = false)]
    [JsonSerializable(typeof(List<Receipt>))]
    public partial class ReceiptGenerationContext : JsonSerializerContext { }
}
