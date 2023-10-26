using MassTransit;

namespace App2;

public class CarEventsConsumer : 
    IConsumer<Messages.CarEvents.CarEngineStarted>,
    IConsumer<Messages.CarEvents.CarStartedDriving>,
    IConsumer<Messages.CarEvents.CarDroveOverSpeedLimit>
{
    public async Task Consume(ConsumeContext<Messages.CarEvents.CarEngineStarted> context)
    {
        await Task.Delay(2000);
        await context.Publish(new Messages.CarEvents.CarStartedDriving { At = DateTimeOffset.Now });
    }

    public async Task Consume(ConsumeContext<Messages.CarEvents.CarStartedDriving> context)
    {
        await Task.Delay(3000);
        await context.Publish(new Messages.CarEvents.CarDroveOverSpeedLimit { At = DateTimeOffset.Now, SpeedLimit = 100 });
    }

    public async Task Consume(ConsumeContext<Messages.CarEvents.CarDroveOverSpeedLimit> context)
    {
        await Task.Delay(1000);
        await context.Publish(new Messages.CarEvents.CarCrashed { At = DateTimeOffset.Now });
    }
}