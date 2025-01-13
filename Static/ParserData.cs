using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace RetailCorrector.API.Static
{
    /// <summary>
    /// Информация парсера
    /// </summary>
    public static class ParserData
    {
        /// <summary>
        /// Аутентификационный токен ОФД
        /// </summary>
        public static string Token { get; set; } = string.Empty;

        /// <summary>
        /// ИНН организации
        /// </summary>
        public static string Vatin { get; set; } = string.Empty;

        /// <summary>
        /// Внутренний идентификатор ККТ в ОФД
        /// </summary>
        public static string DeviceId { get; set; } = string.Empty;

        /// <summary>
        /// Регистрационный номер ККТ
        /// </summary>
        public static string RegId { get; set; } = string.Empty;

        /// <summary>
        /// Внутренний идентификатор ФН в ОФД
        /// </summary>
        public static string StorageId { get; set; } = string.Empty;

        /// <summary>
        /// Заводской номер ФН
        /// </summary>
        public static string StorageSerial { get; set; } = string.Empty;

        /// <summary>
        /// Настройка JSON-сериализации для получения кириллицы
        /// </summary>
        public static JsonSerializerOptions JsonCyrillicPatch => jsonSerializerOptions;

        private readonly static JsonSerializerOptions jsonSerializerOptions = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        };
    }
}
