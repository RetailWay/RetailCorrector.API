using System;
using Newtonsoft.Json;
using RetailCorrector.API.Converters;

namespace RetailCorrector.API.Types
{

    /// <summary>
    /// Тип данных "Количество"
    /// </summary>
    [JsonConverter(typeof(QuantityConverter))]
    public readonly struct Quantity
    {
        /// <summary>
        /// Целая часть (рубли)
        /// </summary>
        public int @Integer => _integer;

        /// <summary>
        /// Дробная часть (копейки)
        /// </summary>
        public ushort @Decimal => _decimal;

        private readonly int _integer;
        private readonly ushort _decimal;

        private Quantity(int @integer = 0, ushort @decimal = 0)
        {
            _integer = @integer;
            _decimal = @decimal;
        }

        /// <summary>Неявное преобразование из <see cref="int"/></summary>
        public static implicit operator Quantity(int @int) =>
            new Quantity(@int / 100, (ushort)(@int % 1000));

        /// <summary>Неявное преобразование из <see cref="decimal"/></summary>
        public static implicit operator Quantity(decimal @decimal) =>
            new Quantity((int)Math.Floor(@decimal), (ushort)Math.Round(@decimal % 1 * 1000));

        /// <summary>Неявное преобразование из <see cref="double"/></summary>
        public static implicit operator Quantity(double @double) =>
            new Quantity((int)Math.Floor(@double), (ushort)Math.Round(@double % 1 * 1000));

        /// <summary>Неявное преобразование из <see cref="float"/></summary>
        public static implicit operator Quantity(float @float) =>
            new Quantity((int)Math.Floor(@float), (ushort)Math.Round(@float % 1 * 1000));

        /// <summary>Неявное преобразование в <see cref="double"/></summary>
        public static implicit operator double(Quantity quantity) =>
            quantity._integer + ((double)quantity._decimal) / 1000;

        /// <summary>Неявное преобразование в <see cref="int"/></summary>
        public static implicit operator int(Quantity quantity) =>
            quantity._integer * 1000 + quantity._decimal;
    }
}
