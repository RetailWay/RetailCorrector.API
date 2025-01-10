using System.Text.Json.Serialization;

namespace RetailCorrector.API.Data
{
    public struct CorrectionData
    {
        [JsonPropertyName("date")]
        public DateTime CreatedDate { get; set; }
        [JsonPropertyName("sign")]
        public string FiscalSign { get; set; }
        /// <summary>
        /// Используется в двух случаях:<br/>
        /// 1. При использовании ФФД 1.05 => вводится номер подготовленного акта<br/>
        /// 2. Если налоговая запросила исправить => номер предписания
        /// </summary>
        [JsonPropertyName("orderId")]
        public string DocId { get; set; }
    }
}
