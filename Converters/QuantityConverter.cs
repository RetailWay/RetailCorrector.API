using RetailCorrector.API.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Converters;

internal class QuantityConverter : JsonConverter<Quantity>
{
    public override Quantity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if(reader.TryGetInt32(out var @int)) return @int;
        if(reader.TryGetDecimal(out var @decimal)) return @decimal;
        throw new FormatException();
    }

    public override void Write(Utf8JsonWriter writer, Quantity value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(value.Integer * 1000 + value.Decimal);
}
