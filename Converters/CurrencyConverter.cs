using System;
using RetailCorrector.API.Types;
using Newtonsoft.Json;

namespace RetailCorrector.API.Converters
{
    internal class CurrencyConverter : JsonConverter<Currency>
    {
        public override void WriteJson(JsonWriter writer, Currency value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Rubles * 100 + value.Pennies);
        }

        public override Currency ReadJson(JsonReader reader, Type objectType, Currency existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var @int = reader.ReadAsInt32();
            if (!(@int is null)) return @int.Value;
            var @decimal = reader.ReadAsDecimal();
            if (!(@decimal is null)) return @decimal.Value;
            throw new FormatException();
        }
    }
}