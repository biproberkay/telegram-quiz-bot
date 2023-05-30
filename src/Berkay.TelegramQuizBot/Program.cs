using Berkay.TelegramQuizBot.Services;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using Telegram.Bot;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "Quiz Bot Service";
    })
    .ConfigureServices((hostContext,services) =>
    {
        LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(services);
        
        services.Configure<BotConfiguration>(hostContext.Configuration.GetSection(BotConfiguration.Configuration));

        services.AddHttpClient("telegram_bot_client")
        .AddTypedClient<ITelegramBotClient>((httpClient,sp)=>{
            BotConfiguration? botConfig = sp.GetConfiguration<BotConfiguration>();
            TelegramBotClientOptions options = new(botConfig.BotToken);
            return new TelegramBotClient(options, httpClient);
        });
        
        services.AddScoped<UpdateHandler>();
        services.AddScoped<ReceiverService>();
        services.AddHostedService<PollingService>();

        services.AddLogging(builder =>{
            builder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
        });

    });

IHost host = builder.Build();

await host.RunAsync();

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable RCS1110 // Declare type inside namespace.
public class BotConfiguration
#pragma warning restore RCS1110 // Declare type inside namespace.
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static readonly string Configuration = "BotConfiguration";

    public string BotToken { get; set; } = "";
}