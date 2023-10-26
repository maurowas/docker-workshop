using App1;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

await Host.CreateDefaultBuilder(args)
    .UseSerilog((context, loggerConfig) =>
    {
        loggerConfig.ReadFrom.Configuration(context.Configuration);
    })
    .ConfigureServices((hostContext, sc) =>
    {
        sc.AddHostedService<Worker>();
        var config = hostContext.Configuration;

        sc.AddMassTransit(x =>
        {
            x.AddConsumer<CarEventConsumer>();
            
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(config["RabbitMq:Host"], "/",host =>
                {
                    host.Username(config["RabbitMq:username"]);
                    host.Password(config["RabbitMq:password"]);
                });
                
                cfg.ReceiveEndpoint(config["RabbitMq:queue"]!, configurator =>
                {
                    configurator.ConfigureConsumer<CarEventConsumer>(ctx);
                });

                cfg.ConfigureEndpoints(ctx);
            });
        });
    })
    .Build()
    .RunAsync();
    