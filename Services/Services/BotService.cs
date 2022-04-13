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
                 var stockQuote = await stooqRepository.getStockQuote(cleanBotQuery(query.MessageContent));
                 return GetValuePerShare(stockQuote, query.MessageContent);
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

        private string GetValuePerShare(string message, string expected)
        {   
            Thread.Sleep(2000);
            if (!validateResult(message, expected)) return "Can get StockQuote";
            string[] splits = message.Split(',');
            string[] splitsInside = splits[7].Split('\n');
            var messageContent = splitsInside[1] + " quote is $" + splits[13] + "per share";
                 
            return messageContent;
            
        }

        private bool validateResult(string message, string expected)
        {
            string[] splits = message.Split(',');
            string[] splitsInside = splits[7].Split('\n');
            string[] splitsExpected = expected.Split(' ');

            if (splitsInside[1].Length != splitsExpected[1].Length || splits[13].Contains('N')) return false;
            else return true;
        }
    }
        
}