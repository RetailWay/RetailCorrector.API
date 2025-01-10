using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace RetailCorrector.API.Static
{
    public static class ParserData
    {
        public static string Token { get; internal set; }
        public static string Vatin { get; set; }
        public static string DeviceId { get; internal set; }
        public static string RegId { get; set; }
        public static string StorageId { get; internal set; }
        public static string StorageSerial { get; set; }

        public static JsonSerializerOptions JsonCyrillicPatch => jsonSerializerOptions;

        private readonly static JsonSerializerOptions jsonSerializerOptions = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        };
    }
}
