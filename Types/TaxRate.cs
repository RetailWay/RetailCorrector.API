using System;
using RetailCorrector.API.Converters;
using Newtonsoft.Json;

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

        private static readonly sbyte[] values = new sbyte[]
        {
            20, 10, 120, 110, 0, -1, 5, 7, 105, 107
        };

        private TaxRate(byte id, sbyte value)
        {
            Id = id;
            Value = value;
        }

        /// <summary>
        /// Преобразование значения тега 1199 в объект <see cref="TaxRate"/>
        /// </summary>
        /// <param name="id">Значение тега 1199</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static TaxRate Parse(byte id)
        {
            if (id < 1 || id > 10) throw new ArgumentOutOfRangeException(nameof(id));
            return new TaxRate(id, values[id - 1]);
        }

        internal static TaxRate ParseJson(int value)
        {
            for (var i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                    return new TaxRate((byte)(i + 1), (sbyte)value);
            }

            throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}