using Newtonsoft.Json;
using Repositories.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class StooqRepository : IStooqRepository
    {

        private readonly string URL_INIT = "https://stooq.com/q/l/?s=";
        private string URL_PARAM = "aapl.us";
        private readonly string URL_DEFAULT_PARAM = "&f=sd2t2ohlcv&h&e=csv";
        public async Task getStockQuote(string messageContent)
        {
    
            try
            {
                if (messageContent != null)
                {
                    var json = JsonConvert.SerializeObject(messageContent);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    using var client = new HttpClient();
                    var response =  await client.GetAsync(URL_INIT);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
