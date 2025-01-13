namespace RetailCorrector.API
{
    /// <summary>
    /// Элемент дополнения
    /// </summary>
    public interface IAddonEntity
    {
        /// <summary>
        /// Наименование элемента
        /// </summary>
        public virtual static string DisplayName => throw new NotImplementedException();
    }
}
