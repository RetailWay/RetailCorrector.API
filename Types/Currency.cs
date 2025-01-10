using RetailCorrector.API.Converters;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Types
{
    /// <summary>
    /// Тип данных "Валюта"
    /// </summary>
    /// <param name="rubles"></param>
    /// <param name="pennies"></param>
    [JsonConverter(typeof(CurrencyConverter))]
    public readonly struct Currency(long rubles = 0, byte pennies = 0)
    {
        /// <summary>
        /// Целая часть (рубли)
        /// </summary>
        public readonly long Rubles => _rubles;
        /// <summary>
        /// Дробная часть (копейки)
        /// </summary>
        public readonly byte Pennies => _pennies;

        private readonly long _rubles = rubles;
        private readonly byte _pennies = pennies;

        public static implicit operator Currency(int @int) =>
            new(@int / 100, (byte)(@int % 100));

        public static implicit operator double(Currency currency) =>
            currency._rubles + ((double)currency._pennies) / 100;
    }
}
