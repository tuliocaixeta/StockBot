using Repositories.Models;

namespace Services.Services.Interfaces
{
    public interface IBotService
    {
        Task<string> GetStockQuote(BotQuery query);
    }
}