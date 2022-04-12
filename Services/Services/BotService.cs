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
        public async Task<string> GetStockQuote(BotQuery query)
        {
            try
            {
                 ValidateBotQuery(query.MessageContent);
                 return await stooqRepository.getStockQuote(cleanBotQuery(query.MessageContent));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string cleanBotQuery(string messageContent)
        {
            string[] splits = messageContent.Split(' ');

            if (splits[0] == "/stock")
            {
                return splits[1];
            } else
            {
                throw new InvalidDataException("stock quote cannot be found, sorry");

            }

        }

        private void ValidateBotQuery(string messageContent)
        {

            if (string.IsNullOrWhiteSpace(messageContent)) throw new InvalidDataException("stock quote cannot be found, sorry");
        }
    }
        
}