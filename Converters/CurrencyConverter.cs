using RetailCorrector.API.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Converters;

internal class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if(reader.TryGetInt32(out var @int)) return @int;
        if(reader.TryGetDecimal(out var @decimal)) return @decimal;
        throw new FormatException();
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(value.Rubles * 100 + value.Pennies);
}
