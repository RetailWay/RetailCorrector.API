using RetailCorrector.API.Data;
using RetailCorrector.API.Static;

namespace RetailCorrector.API
{
    /// <summary>
    /// Интеграция с ОФД
    /// </summary>
    public interface IParser: IAddonEntity
    {
        /// <summary>
        /// Загрузка чеков за определённый день
        /// </summary>
        /// <returns>Список чеков</returns>
        public Task<List<Receipt>> ParseReceipts(DateOnly day);

        /// <summary>
        /// Получение токена для работы парсера
        /// </summary>
        /// <param name="data">Данные авторизации</param>
        /// <returns>Аутентификационный токен</returns>
        public virtual Task<string> Auth(params string[] data)
            => Task.FromResult(string.Join(' ', data));

        /// <summary>
        /// Получение внутренних идентификаторов в ОФД
        /// </summary>
        /// <returns>Идентификаторы ККТ и ФН</returns>
        public virtual Task<(string, string)> GetDevice() 
            => Task.FromResult((ParserData.RegId, ParserData.StorageSerial));
    }
}
