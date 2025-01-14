namespace RetailCorrector.API.Exceptions;

public class DeviceFatalException(int code, string message) : DeviceException(code, message) { }
