using RetailCorrector.API.Data;
using RetailCorrector.API.Exceptions;

namespace RetailCorrector.API;

/// <summary>
/// Интеграция с драйвером ККТ
/// </summary>
public interface IFiscalDriver : IDisposable
{
    /// <summary>
    /// Количество неотправленных документов
    /// </summary>
    public int CountUnsendDocs { get; }

    /// <summary>
    /// Версия формата фискальных документов
    /// </summary>
    public int FiscalFormat { get; }

    /// <summary>
    /// Исправление ошибки
    /// </summary>
    /// <exception cref="DeviceException">Вызывается при незначительной ошибке ККТ</exception>
    /// <exception cref="DeviceFatalException">Вызывается при критической ошибке ККТ</exception>
    /// <exception cref="ReceiptFormatException">Вызывается при ошибке в записе формата чека</exception>
    public void FixError();

    /// <summary>
    /// Подключение к ККТ
    /// </summary>
    public void Connect();

    /// <summary>
    /// Отключение от ККТ
    /// </summary>
    public void Disconnect();

    /// <summary>
    /// Закрытие смены
    /// </summary>
    public void CloseSession();

    /// <summary>
    /// Открытие смены
    /// </summary>
    public void OpenSession();

    /// <summary>
    /// Открытие фискального документа
    /// </summary>
    /// <param name="receipt">Информация о документе</param>
    public void OpenReceipt(Receipt receipt);

    /// <summary>
    /// Регистрация позиции
    /// </summary>
    /// <param name="item">Информация о позиции</param>
    public void RegisterItem(Position item);

    /// <summary>
    /// Закрытие фискального документа
    /// </summary>
    /// <param name="receipt">Информация о документе</param>
    public void CloseReceipt(Receipt receipt);

    /// <summary>
    /// Отмена фискального документа
    /// </summary>
    public void CancelReceipt();

    /// <summary>
    /// Освобождение драйвера
    /// </summary>
    public void Free();

    /// <summary>
    /// Оплата фискального документа
    /// </summary>
    /// <param name="type">Вид оплаты</param>
    /// <param name="sum">Сумма оплаты</param>
    public void Payment(byte type, double sum);

    void IDisposable.Dispose()
    {
        Disconnect();
        Free();
        GC.SuppressFinalize(this);
    }
}
