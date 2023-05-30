using Telegram.Bot;
using Berkay.TelegramQuizBot.Abstract;

namespace Berkay.TelegramQuizBot.Services;

// Compose Polling and ReceiverService implementations
public class PollingService : PollingServiceBase<ReceiverService>
{
    public PollingService(ITelegramBotClient botClient, IServiceProvider serviceProvider, ILogger<PollingService> logger)
        : base(botClient, serviceProvider, logger)
    {
    }
}
