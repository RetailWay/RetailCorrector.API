namespace RetailCorrector.API
{
    /// <summary>
    /// Тип отчета
    /// </summary>
    public interface IReport : IAddonEntity
    {
        /// <summary>
        /// Идентификатор отчета
        /// </summary>
        public virtual static string Type => throw new NotImplementedException();
        /// <summary>
        /// Настройка отчёта
        /// </summary>
        /// <param name="args">Параметры отчета</param>
        public void Instance(Dictionary<string, object> args);
        /// <summary>
        /// Отправка отчета
        /// </summary>
        public Task Send();

        /// <summary>
        /// Получить значение из параметров отчета или выдать исключение
        /// </summary>
        /// <typeparam name="T">Тип значения параметра отчета</typeparam>
        /// <param name="dict">Параметры отчета</param>
        /// <param name="key">Наименование параметра отчета</param>
        /// <returns>Значение параметра отчета</returns>
        /// <exception cref="ArgumentNullException">Параметр отсутствует</exception>
        /// <exception cref="FormatException">Параметр не подходящего типа</exception>
        protected static T GetOrThrow<T>(Dictionary<string, object> dict, string key)
        {
            if (!dict.TryGetValue(key, out var raw))
                throw new ArgumentNullException(key);
            if (raw is T result)
                return result;
            throw new FormatException();
        }
    }
}
