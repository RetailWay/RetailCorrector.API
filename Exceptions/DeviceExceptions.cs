using System;

namespace RetailCorrector.API.Exceptions
{

    /// <summary>
    /// Исключение, которое вызывается при ошибке ККТ
    /// </summary>
    /// <param name="code">Код ошибки</param>
    /// <param name="message">Описание ошибки</param>
    public class DeviceException : Exception
    {
        public DeviceException(int code, string message) : base($"Ошибка {code}: {message}")
        {

        }
    }

    /// <summary>
    /// Исключение, которое вызывается при критической ошибке ККТ
    /// </summary>
    /// <param name="code">Код ошибки</param>
    /// <param name="message">Описание ошибки</param>
    public class DeviceFatalException : DeviceException
    {
        public DeviceFatalException(int code, string message) : base(code, message)
        {

        }
    }

    /// <summary>
    /// Исключение, которое вызывается ошибке в чеке
    /// </summary>
    /// <param name="code">Код ошибки</param>
    /// <param name="message">Описание ошибки</param>
    public class ReceiptFormatException : DeviceException
    {
        public ReceiptFormatException(int code, string message) : base(code, message)
        {

        }
    }
}