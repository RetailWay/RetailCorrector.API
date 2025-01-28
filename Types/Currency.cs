using System;
using RetailCorrector.API.Converters;
using Newtonsoft.Json;

namespace RetailCorrector.API.Types
{

    /// <summary>
    /// Тип данных "Валюта"
    /// </summary>
    [JsonConverter(typeof(CurrencyConverter))]
    public readonly struct Currency
    {
        /// <summary>
        /// Целая часть (рубли)
        /// </summary>
        public int Rubles => _rubles;

        /// <summary>
        /// Дробная часть (копейки)
        /// </summary>
        public byte Pennies => _pennies;

        private readonly int _rubles;
        private readonly byte _pennies;

        private Currency(int rubles = 0, byte pennies = 0)
        {
            _rubles = rubles;
            _pennies = pennies;
        }

        /// <summary>Неявное преобразование из <see cref="int"/></summary>
        public static implicit operator Currency(int @int) =>
            new Currency(@int / 100, (byte)(@int % 100));

        /// <summary>Неявное преобразование из <see cref="decimal"/></summary>
        public static implicit operator Currency(decimal @decimal) =>
            new Currency((int)Math.Floor(@decimal), (byte)Math.Round(@decimal % 1 * 100));

        /// <summary>Неявное преобразование из <see cref="double"/></summary>
        public static implicit operator Currency(double @double) =>
            new Currency((int)Math.Floor(@double), (byte)Math.Round(@double % 1 * 100));

        /// <summary>Неявное преобразование из <see cref="float"/></summary>
        public static implicit operator Currency(float @float) =>
            new Currency((int)Math.Floor(@float), (byte)Math.Round(@float % 1 * 100));

        /// <summary>Неявное преобразование в <see cref="double"/></summary>
        public static implicit operator double(Currency currency) =>
            currency._rubles + ((double)currency._pennies) / 100;

        /// <summary>Неявное преобразование в <see cref="int"/></summary>
        public static implicit operator int(Currency currency) =>
            currency._rubles * 100 + currency._pennies;
    }
}