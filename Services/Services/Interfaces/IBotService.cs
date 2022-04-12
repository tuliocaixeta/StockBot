using Repositories.Models;

namespace Services.Services.Interfaces
{
    public interface IBotService
    {
        Task GetStockQuote(BotQuery query);
    }
}