using MassTransit;
using Microsoft.Extensions.Logging;

namespace App2;

public class App1StartedConsumer : 
    IConsumer<Messages.App1Started>
{
    readonly ILogger<App1StartedConsumer> _logger;

    public App1StartedConsumer(ILogger<App1StartedConsumer> logger)
    {
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<Messages.App1Started> context)
    {
        _logger.LogInformation("Received App1Started");
        await context.Publish(new Messages.CarEvents.CarEngineStarted());
    }
}