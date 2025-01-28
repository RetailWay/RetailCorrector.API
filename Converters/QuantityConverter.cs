using System;
using RetailCorrector.API.Types;
using Newtonsoft.Json;

namespace RetailCorrector.API.Converters
{
    internal class QuantityConverter : JsonConverter<Quantity>
    {
        public override void WriteJson(JsonWriter writer, Quantity value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Integer * 1000 + value.Decimal);
        }

        public override Quantity ReadJson(JsonReader reader, Type objectType, Quantity existingValue, bool hasExistingValue,
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