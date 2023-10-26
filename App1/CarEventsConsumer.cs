using App2;
using MassTransit;
using Microsoft.Extensions.Logging;

// ReSharper disable ClassNeverInstantiated.Global

namespace App1;

public class CarEventConsumer : 
    IConsumer<Messages.CarEvents.CarEngineStarted>,
    IConsumer<Messages.CarEvents.CarStartedDriving>,
    IConsumer<Messages.CarEvents.CarDroveOverSpeedLimit>,
    IConsumer<Messages.CarEvents.CarCrashed>
{
    readonly ILogger<CarEventConsumer> _logger;

    public CarEventConsumer(ILogger<CarEventConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<Messages.CarEvents.CarEngineStarted> context)
    {
        _logger.LogInformation("Car engine started at {At}", context.Message.At);
        return Task.CompletedTask;
    }

    public Task Consume(ConsumeContext<Messages.CarEvents.CarStartedDriving> context)
    {
        _logger.LogInformation("Car started driving at {At}", context.Message.At);
        return Task.CompletedTask;
    }

    public Task Consume(ConsumeContext<Messages.CarEvents.CarDroveOverSpeedLimit> context)
    {
        _logger.LogInformation("Car drove over {SpeedLimit}km/h at {At}", context.Message.SpeedLimit, context.Message.At);
        return Task.CompletedTask;
    }

    public Task Consume(ConsumeContext<Messages.CarEvents.CarCrashed> context)
    {
        _logger.LogInformation("Car crashed at {At}", context.Message.At);
        return Task.CompletedTask;
    }
}