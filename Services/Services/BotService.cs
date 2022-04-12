using Repositories.Models;
using Repositories.Repositories.Interfaces;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class BotService : IBotService
    {
        public readonly IStooqRepository stooqRepository;
        public BotService(IStooqRepository stooqRepository)
        {
            this.stooqRepository = stooqRepository;
        }
        public async Task GetStockQuote(BotQuery query)
        {
            try
            {
                 await stooqRepository.getStockQuote(query.MessageContent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
     
    }
        
}