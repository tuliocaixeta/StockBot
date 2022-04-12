namespace Repositories.Repositories.Interfaces
{
    public interface IStooqRepository
    {
        Task<string> getStockQuote(string messageContent);
    }
}
