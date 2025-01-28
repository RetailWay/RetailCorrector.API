using RetailCorrector.API.Converters;
using System.Text.Json.Serialization;

namespace RetailCorrector.API.Types;

/// <summary>
/// Тип данных "Количество"
/// </summary>
[JsonConverter(typeof(QuantityConverter))]
public readonly struct Quantity
{
    /// <summary>
    /// Целая часть (рубли)
    /// </summary>
    public readonly int @Integer => _integer;
    /// <summary>
    /// Дробная часть (копейки)
    /// </summary>
    public readonly ushort @Decimal => _decimal;

    private readonly int _integer;
    private readonly ushort _decimal;

    private Quantity(int @integer = 0, ushort @decimal = 0)
    {
        _integer = @integer;
        _decimal = @decimal;
    }

    /// <summary>Неявное преобразование из <see cref="int"/></summary>
    public static implicit operator Quantity(int @int) =>
        new(@int / 100, (ushort)(@int % 1000));

    /// <summary>Неявное преобразование из <see cref="decimal"/></summary>
    public static implicit operator Quantity(decimal @decimal) =>
        new((int)Math.Floor(@decimal), (ushort)Math.Round(@decimal % 1 * 1000));

    /// <summary>Неявное преобразование из <see cref="double"/></summary>
    public static implicit operator Quantity(double @double) =>
        new((int)Math.Floor(@double), (ushort)Math.Round(@double % 1 * 1000));

    /// <summary>Неявное преобразование из <see cref="float"/></summary>
    public static implicit operator Quantity(float @float) =>
        new((int)Math.Floor(@float), (ushort)Math.Round(@float % 1 * 1000));

    /// <summary>Неявное преобразование в <see cref="double"/></summary>
    public static implicit operator double(Quantity quantity) =>
        quantity._integer + ((double)quantity._decimal) / 1000;

    /// <summary>Неявное преобразование в <see cref="int"/></summary>
    public static implicit operator int(Quantity quantity) =>
        quantity._integer * 1000 + quantity._decimal;
}
