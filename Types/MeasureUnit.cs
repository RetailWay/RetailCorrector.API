using RetailCorrector.API.Converters;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Types
{
    /// <summary>
    /// Структура "Единица измерения"
    /// </summary>
    [JsonConverter(typeof(MeasureConverter))]
    public readonly struct MeasureUnit
    {
        /// <summary>
        /// Значение тега 2108
        /// </summary>
        public readonly byte Id;
        /// <summary>
        /// Значение тега 1197
        /// </summary>
        public readonly string Name;

        private static readonly byte[] ids = [
            0, 10, 11, 12, 20, 21, 22, 30, 31, 
            32, 40, 41, 42, 50, 51, 70, 71, 72, 
            73, 80, 81, 82, 83
            ];

        private static readonly string[] names = [
            "шт.", "г", "кг", "т", "см", "дм", "м", 
            "кв. см", "кв. дм", "кв. м", "мл", "л", 
            "куб. м", "кВт * ч", "Гкал", "сутки", 
            "час", "мин", "с", "Кбайт", "Мбайт", 
            "Гбайт", "Тбайт"
            ];

        /// <summary>
        /// Получить все известные единицы измерений
        /// </summary>
        /// <returns>Наименования единиц измерений</returns>
        public static string[] GetNames() => names;

        private MeasureUnit(byte id, string name)
        {
            Id = id;
            Name = name;
        }

        private MeasureUnit(string name) : this(255, name) { }

        public MeasureUnit() : this("-") { }

        /// <summary>
        /// Получение <see cref="MeasureUnit"/> по значению тега 1197
        /// </summary>
        /// <param name="name">Значение тега 1197</param>
        public static MeasureUnit Parse(string name)
        {
            for (var i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                    return new MeasureUnit(ids[i], names[i]);
            }
            return new MeasureUnit(name);
        }

        /// <summary>
        /// Получение <see cref="MeasureUnit"/> по значению тега 2108
        /// </summary>
        /// <param name="id">Значение тега 2108</param>
        public static MeasureUnit Parse(byte id)
        {
            for (var i = 0; i < names.Length; i++)
            {
                if (ids[i] == id)
                    return new MeasureUnit(ids[i], names[i]);
            }
            return new MeasureUnit();
        }
    }
}
