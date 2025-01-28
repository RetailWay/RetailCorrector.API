namespace RetailCorrector.API.Exceptions;

/// <summary>
/// Исключение, которое вызывается при ошибке ККТ
/// </summary>
/// <param name="code">Код ошибки</param>
/// <param name="message">Описание ошибки</param>
public class DeviceException(int code, string message): Exception($"Ошибка {code}: {message}") { }

/// <summary>
/// Исключение, которое вызывается при критической ошибке ККТ
/// </summary>
/// <param name="code">Код ошибки</param>
/// <param name="message">Описание ошибки</param>
public class DeviceFatalException(int code, string message) : DeviceException(code, message) { }

/// <summary>
/// Исключение, которое вызывается ошибке в чеке
/// </summary>
/// <param name="code">Код ошибки</param>
/// <param name="message">Описание ошибки</param>
public class ReceiptFormatException(int code, string message) : DeviceException(code, message) { }