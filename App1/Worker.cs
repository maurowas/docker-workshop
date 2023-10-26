using App2;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace App1;

public class Worker : IHostedService
{
    readonly IBus _bus;
    readonly ILogger _logger;

    public Worker(IBus bus, ILogger<Worker> logger)
    {
        _bus = bus;
        _logger = logger;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    { 
        await Task.Delay(5000);
        _logger.LogInformation("App1 started");
        await _bus.Publish(new Messages.App1Started(), cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("App1 stopping");
    }
}