using RetailCorrector.API.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Converters
{
    internal class MeasureConverter : JsonConverter<MeasureUnit>
    {
        public override MeasureUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TryGetByte(out var id)) MeasureUnit.Parse(id);
            if(reader.GetString() is string text) MeasureUnit.Parse(text);
            return new MeasureUnit();
        }

        public override void Write(Utf8JsonWriter writer, MeasureUnit value, JsonSerializerOptions options)
        {
            if(value.Id == 255) writer.WriteStringValue(value.Name);
            else writer.WriteNumberValue(value.Id);
        }
    }
}
