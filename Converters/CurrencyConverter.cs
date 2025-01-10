using RetailCorrector.API.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Converters
{
    internal class CurrencyConverter : JsonConverter<Currency>
    {
        public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TryGetInt16(out var @short)) return new Currency(@short / 100, (byte)(@short % 100));
            if(reader.TryGetInt32(out var @int)) return new Currency(@int / 100, (byte)(@int % 100));
            if(reader.TryGetInt64(out var @long)) return new Currency(@long / 100, (byte)(@long % 100));
            if(reader.TryGetDouble(out var @double)) 
                return new Currency((long)Math.Floor(@double), (byte)Math.Round(@double % 1 * 100));
            if(reader.TryGetDecimal(out var @decimal))
                return new Currency((long)Math.Floor(@decimal), (byte)Math.Round(@decimal % 1 * 100));
            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value.Rubles * 100 + value.Pennies);
    }
}
