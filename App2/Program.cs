using App2;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Serilog;

await Host.CreateDefaultBuilder(args)
    .UseSerilog((context, loggerConf) =>
    {
        loggerConf.ReadFrom.Configuration(context.Configuration);
    })
    .ConfigureServices((hostContext, sc) =>
    {
        var config = hostContext.Configuration;

        sc.AddMassTransit(x =>
        {
            x.AddConsumer<App1StartedConsumer>();
            x.AddConsumer<CarEventsConsumer>();
            
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(config["RabbitMq:Host"], "/",host =>
                {
                    host.Username(config["RabbitMq:username"]);
                    host.Password(config["RabbitMq:password"]);
                });
                
                cfg.ReceiveEndpoint(config["RabbitMq:queue"]!, configurator =>
                {
                    configurator.ConfigureConsumer<App1StartedConsumer>(ctx);
                });

                cfg.ReceiveEndpoint(config["RabbitMq:car-events-queue"]!, configurator =>
                {
                    configurator.ConfigureConsumer<CarEventsConsumer>(ctx);
                });
                
                cfg.ConfigureEndpoints(ctx);
            });
        });
    })
    .Build()
    .RunAsync();