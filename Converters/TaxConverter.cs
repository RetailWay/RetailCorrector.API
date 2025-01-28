using System;
using RetailCorrector.API.Types;
using Newtonsoft.Json;

namespace RetailCorrector.API.Converters
{
    internal class TaxConverter : JsonConverter<TaxRate>
    {
        public override void WriteJson(JsonWriter writer, TaxRate value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override TaxRate ReadJson(JsonReader reader, Type objectType, TaxRate existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var value = reader.ReadAsInt32();
            if (!(value is sbyte sb)) throw new FormatException();
            return TaxRate.ParseJson(sb);
        }
    }
}