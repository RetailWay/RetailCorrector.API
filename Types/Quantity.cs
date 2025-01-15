using RetailCorrector.API.Converters;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Types
{
    /// <summary>
    /// Тип данных "Количество"
    /// </summary>
    /// <param name="integer">Целая часть</param>
    /// <param name="decimal">Дробная часть</param>
    [JsonConverter(typeof(QuantityConverter))]
    public readonly struct Quantity(int @integer = 0, ushort @decimal = 0)
    {
        /// <summary>
        /// Целая часть (рубли)
        /// </summary>
        public readonly int @Integer => _integer;
        /// <summary>
        /// Дробная часть (копейки)
        /// </summary>
        public readonly ushort @Decimal => _decimal;

        private readonly int _integer = @integer;
        private readonly ushort _decimal = @decimal;

        public static implicit operator Quantity(int @int) =>
            new(@int / 100, (ushort)(@int % 1000));

        public static implicit operator Quantity(decimal @decimal) =>
            new((int)Math.Floor(@decimal), (ushort)Math.Round(@decimal % 1 * 1000));

        public static implicit operator Quantity(double @double) =>
            new((int)Math.Floor(@double), (ushort)Math.Round(@double % 1 * 1000));

        public static implicit operator Quantity(float @float) =>
            new((int)Math.Floor(@float), (ushort)Math.Round(@float % 1 * 1000));

        public static implicit operator double(Quantity quantity) =>
            quantity._integer + ((double)quantity._decimal) / 1000;
    }
}
