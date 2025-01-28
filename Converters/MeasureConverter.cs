using System;
using RetailCorrector.API.Types;
using Newtonsoft.Json;

namespace RetailCorrector.API.Converters
{

    internal class MeasureConverter : JsonConverter<MeasureUnit>
    {
        public override void WriteJson(JsonWriter writer, MeasureUnit value, JsonSerializer serializer)
        {
            if (value.Id == 255) writer.WriteValue(value.Name);
            else writer.WriteValue(value.Id);
        }

        public override MeasureUnit ReadJson(JsonReader reader, Type objectType, MeasureUnit existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var id = reader.ReadAsInt32();
            if (id is byte) MeasureUnit.Parse((byte)id);
            var text = reader.ReadAsString();
            if (!(text is null)) MeasureUnit.Parse(text);
            return new MeasureUnit();
        }
    }
}