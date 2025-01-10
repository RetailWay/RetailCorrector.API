namespace RetailCorrector.API.Enums
{
    public enum FiscalAction
    {
        /// <summary>Принудительная остановка коррекции</summary>
        StopCorrection,
        /// <summary>Повторение попытки</summary>
        TryAgain,
        /// <summary>Регистрация ошибки в документе</summary>
        WriteToFail
    }
}
