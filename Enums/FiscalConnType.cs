namespace RetailCorrector.API.Enums;

/// <summary>
/// Тип подключения к ККТ
/// </summary>
public enum FiscalConnType
{
    /// <summary>
    /// Через последовательный порт COM
    /// </summary>
    COM,

    /// <summary>
    /// Через последовательный порт USB
    /// </summary>
    USB, 
    
    /// <summary>
    /// Через протокол TCP/IP
    /// </summary>
    TCP_IP, 
    
    /// <summary>
    /// Через протокол Bluetooth
    /// </summary>
    Bluetooth
}
