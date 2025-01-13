using RetailCorrector.API.Converters;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Types
{
    /// <summary>
    /// Структура "Ставка НДС"
    /// </summary>
    [JsonConverter(typeof(TaxConverter))]
    public readonly struct TaxRate
    {
        /// <summary>
        /// Значение реквизита 1199
        /// </summary>
        public readonly byte Id;
        /// <summary>
        /// Значение в json
        /// </summary>
        public readonly sbyte Value;

        private static readonly sbyte[] values = [
            20, 10, 120, 110, 0, -1, 5, 7, 105, 107
            ];

        private TaxRate(byte id, sbyte value)
        {
            Id = id;
            Value = value;
        }

        public static TaxRate Parse(byte id)
        {
            if (id < 1 || id > 10) throw new ArgumentOutOfRangeException(nameof(id));
            return new TaxRate(id, values[id - 1]);
        }

        internal static TaxRate Parse(sbyte value)
        {
            for(var i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                    return new TaxRate((byte)(i + 1), value);
            }
            throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}
