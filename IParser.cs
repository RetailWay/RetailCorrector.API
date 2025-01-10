using RetailCorrector.API.Data;
using RetailCorrector.API.Static;

namespace RetailCorrector.API
{
    /// <summary>
    /// Интеграция с ОФД
    /// </summary>
    public interface IParser: IAddonEntity
    {
        protected Task<List<Receipt>> ParseReceipts(DateOnly day);
        protected virtual Task<string> Auth(params string[] data)
            => Task.FromResult(string.Join(' ', data));
        protected virtual Task<(string, string)> GetDevice() 
            => Task.FromResult((ParserData.RegId, ParserData.StorageSerial));

        public async Task Auth(string data) => 
            ParserData.Token = await Auth(data.Split(' '));
        public async Task SelectDevice()
        {
            (ParserData.DeviceId, ParserData.StorageId) = await GetDevice();
        }
        public async Task<List<Receipt>> ParseReceipts(DateOnly begin, DateOnly end)
        {
            var receipts = new List<Receipt>();
            for (var date = begin; date <= end; date = date.AddDays(1))
            {
                for (var i = 0; i < 3; i++)
                {
                    await Task.Delay(1500);
                    Console.WriteLine($"Выгрузка {date:yyyy'/'MM'/'dd}");
                    try
                    {
                        var r = await ParseReceipts(date);
                        receipts.AddRange(r);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            receipts.Sort((p, n) => n.DocId.CompareTo(p.DocId));
            return receipts;
        }
    }
}
