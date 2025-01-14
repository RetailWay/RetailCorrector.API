namespace RetailCorrector.API.Exceptions;

public class DeviceException(int code, string message): Exception($"Ошибка {code}: {message}") { }
