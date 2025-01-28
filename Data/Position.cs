using RetailCorrector.API.Types;
using Newtonsoft.Json;

namespace RetailCorrector.API.Data
{

    /// <summary>
    /// Структура "Позиция чека"
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [JsonProperty("quantity")]
        public Quantity Quantity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        [JsonProperty("price")]
        public Currency Price { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        [JsonProperty("total")]
        public Currency Sum { get; set; }

        /// <summary>
        /// Ставка НДС
        /// </summary>
        [JsonProperty("tax")]
        public TaxRate TaxRate { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        [JsonProperty("measure")]
        public MeasureUnit MeasureUnit { get; set; }

        /// <summary>
        /// Тип позиции
        /// </summary>
        [JsonProperty("type")]
        public byte ItemType { get; set; }

        /// <summary>
        /// Способ оплаты
        /// </summary>
        [JsonProperty("payment")]
        public byte PayMethod { get; set; }
    }
}