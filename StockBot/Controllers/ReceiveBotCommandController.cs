using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Services.Services.Interfaces;
using Repositories.Models;
using System.Text;

namespace StockBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiveBotCommandController : ControllerBase
    {
        private readonly ConnectionFactory _connectionFac;
        private readonly IBotService _botService;

        private readonly string QUEUE_INFO = "stock";
        public ReceiveBotCommandController(IBotService botService)
        {
            _botService = botService;
            _connectionFac = new ConnectionFactory { HostName = "localhost"};
        }

        [HttpPost(Name = "PostBotQuery")]
        public async Task ReceiveBotCommand(BotQuery query )
        {

            var stockQuote = await _botService.GetStockQuote(query);
            using (var connection = _connectionFac.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: QUEUE_INFO,false, false, false, null);

                    var body = Encoding.UTF8.GetBytes(stockQuote);

                    channel.BasicPublish(exchange: "",
                        routingKey: QUEUE_INFO,
                        basicProperties: null,
                        body: body);
                }
            }
        }
    }
}
