using System;
using RetailCorrector.API.Data;
using RetailCorrector.API.Exceptions;
using RetailCorrector.API.Types;

namespace RetailCorrector.API
{

    /// <summary>
    /// Интеграция с драйвером ККТ
    /// </summary>
    public abstract class Fiscal : IDisposable
    {
        /// <summary>
        /// Количество неотправленных документов
        /// </summary>
        public abstract int CountUnsendDocs { get; }

        /// <summary>
        /// Версия формата фискальных документов
        /// </summary>
        public abstract int FiscalFormat { get; }

        /// <summary>
        /// Исправление ошибки
        /// </summary>
        /// <exception cref="DeviceException">Вызывается при незначительной ошибке ККТ</exception>
        /// <exception cref="DeviceFatalException">Вызывается при критической ошибке ККТ</exception>
        /// <exception cref="ReceiptFormatException">Вызывается при ошибке в записе формата чека</exception>
        public abstract void FixError();

        /// <summary>
        /// Подключение к ККТ
        /// </summary>
        /// <param name="data">Параметры подключения</param>
        public abstract void Connect(FiscalConnection data);

        /// <summary>
        /// Отключение от ККТ
        /// </summary>
        public abstract void Disconnect();

        /// <summary>
        /// Закрытие смены
        /// </summary>
        public abstract void CloseSession();

        /// <summary>
        /// Открытие смены
        /// </summary>
        public abstract void OpenSession();

        /// <summary>
        /// Открытие фискального документа
        /// </summary>
        /// <param name="receipt">Информация о документе</param>
        public abstract void OpenReceipt(Receipt receipt);

        /// <summary>
        /// Регистрация позиции
        /// </summary>
        /// <param name="item">Информация о позиции</param>
        public abstract void RegisterItem(Position item);

        /// <summary>
        /// Закрытие фискального документа
        /// </summary>
        /// <param name="payment">Информация о оплате</param>
        /// <param name="total">Итоговая сумма</param>
        public abstract void CloseReceipt(Payment payment, Currency total);

        /// <summary>
        /// Отмена фискального документа
        /// </summary>
        public abstract void CancelReceipt();

        /// <summary>
        /// Освобождение драйвера
        /// </summary>
        public abstract void Free();

        /// <summary>
        /// Оплата фискального документа
        /// </summary>
        /// <param name="type">Вид оплаты</param>
        /// <param name="sum">Сумма оплаты</param>
        public abstract void Payment(byte type, double sum);

        void IDisposable.Dispose()
        {
            Disconnect();
            Free();
            GC.SuppressFinalize(this);
        }
    }
}