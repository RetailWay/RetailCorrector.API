using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailCorrector.API
{

    /// <summary>
    /// Тип отчета
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Идентификатор отчета
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Параметры отчёта
        /// </summary>
        Dictionary<string, string> Properties { get; }

        /// <summary>
        /// Отправка отчета
        /// </summary>
        Task Send();
    }
}
