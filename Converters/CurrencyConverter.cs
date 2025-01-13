using RetailCorrector.API.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Converters
{
    internal class CurrencyConverter : JsonConverter<Currency>
    {
        public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TryGetInt64(out var @long)) return new Currency(@long / 100, (byte)(@long % 100));
            if(reader.TryGetDecimal(out var @decimal))
                return new Currency((long)Math.Floor(@decimal), (byte)Math.Round(@decimal % 1 * 100));
            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value.Rubles * 100 + value.Pennies);
    }
}
