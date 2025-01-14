namespace RetailCorrector.API.Exceptions;

public class ReceiptFormatException(int code, string message) : DeviceException(code, message) { }
