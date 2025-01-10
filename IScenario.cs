using RetailCorrector.API.Data;

namespace RetailCorrector.API
{
    /// <summary>
    /// Сценарий изменения чеков
    /// </summary>
    public interface IScenario : IAddonEntity
    {
        public bool HasCancelling { get; }

        public Task<List<Receipt>> Edit(List<Receipt> origin);
    }
}
