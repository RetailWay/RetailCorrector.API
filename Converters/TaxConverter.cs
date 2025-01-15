using RetailCorrector.API.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Converters;

internal class TaxConverter : JsonConverter<TaxRate>
{
    public override TaxRate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!reader.TryGetSByte(out var value)) throw new FormatException();
        return TaxRate.ParseJson(value);
    }

    public override void Write(Utf8JsonWriter writer, TaxRate value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(value.Value);
}
