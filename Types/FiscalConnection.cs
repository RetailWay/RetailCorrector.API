using RetailCorrector.API.Enums;
using System.Text.RegularExpressions;

namespace RetailCorrector.API.Types;

/// <summary>
/// Настройка подключения ККТ
/// </summary>
public readonly partial struct FiscalConnection
{
    /// <summary>
    /// Тип подключения
    /// </summary>
    public FiscalConnType Type { get; init; }

    /// <summary>
    /// Адрес устройства
    /// </summary>
    public readonly string Address
    {
        get
        {
            if (Type != FiscalConnType.TCP_IP) 
                return _address;
            return _address.Split(':')[0];
        }
    }

    /// <summary>
    /// TCP-порт устройства (для TCP/IP-подключения)
    /// </summary>
    public readonly ushort Port 
    { 
        get
        {
            if (Type != FiscalConnType.TCP_IP) return 0;
            return ushort.Parse(Address.Split(':')[1]);
        }
    }

    private readonly string _address;

    private FiscalConnection(FiscalConnType type, string address)
    {
        Type = type; 
        _address = address;
    }

    /// <summary>
    /// Преобразование <see cref="string"/> в <see cref="FiscalConnection"/>
    /// </summary>
    /// <param name="address">Адрес устройства</param>
    /// <exception cref="FormatException">Вызывается, если не удалось определить тип подключения</exception>
    public static FiscalConnection Parse(string address)
    {
        FiscalConnType? type = null;
        if (ComRegex().IsMatch(address)) type = FiscalConnType.COM;
        if (TcpRegex().IsMatch(address)) type = FiscalConnType.TCP_IP;
        if (MacRegex().IsMatch(address)) type = FiscalConnType.Bluetooth;
        if (UsbRegex().IsMatch(address)) type = FiscalConnType.USB;
        if (type is null) throw new FormatException();
        return new FiscalConnection(type.Value, address);
    }

    [GeneratedRegex(@"(\d{1,3}\.){3}\d{1,3}:\d{1,5}")]
    public static partial Regex TcpRegex();

    [GeneratedRegex(@"([0-9a-fA-F]:){5}[0-9a-fA-F]")]
    public static partial Regex MacRegex();

    [GeneratedRegex(@"COM\d{1,3}")]
    public static partial Regex ComRegex();

    [GeneratedRegex(@"VID_[0-9A-F]{4}&PID_[0-9A-F]{4}.+")]
    public static partial Regex UsbRegex();
}
