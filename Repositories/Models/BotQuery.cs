namespace Repositories.Models
{
    public class BotQuery
    {
        public int Id { get; set; }
    
        public string MessageContent { get; set; }

        public DateTime MessageSendingTime { get; set; } = DateTime.Now;

        public string User { get; set; } = String.Empty;
    }
}
