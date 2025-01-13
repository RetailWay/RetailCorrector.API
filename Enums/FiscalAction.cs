namespace RetailCorrector.API.Enums
{
    /// <summary>
    /// Действие на ошибку ККТ
    /// </summary>
    public enum FiscalAction
    {
        /// <summary>
        /// Игнорирование
        /// </summary>
        Ignore,

        /// <summary>
        /// Принудительная остановка коррекции
        /// </summary>
        StopCorrection,

        /// <summary>
        /// Повторение попытки
        /// </summary>
        TryAgain,

        /// <summary>
        /// Регистрация ошибки в документе
        /// </summary>
        WriteToFail
    }
}
