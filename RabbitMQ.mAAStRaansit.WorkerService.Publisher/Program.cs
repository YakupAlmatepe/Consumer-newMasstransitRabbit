using MassTransit;
using RabbitMQ.mAAStRaansit.WorkerService.Publisher;
using RabbitMQ.mAAStRaansit.WorkerService.Publisher.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((context, _configurator) =>
            {
                _configurator.Host("amqps://jsdeqiyh:s74D08I87i7ctRg1GKE4SE8A7wIiHVRr@beaver.rmq.cloudamqp.com/jsdeqiyh");
            });
        });
        // bu sýnýf(ýnstance ) providerden elde edilecek þekilde yazýlmalý ksi halde proje partalar
        services.AddHostedService<PublishManagerService>(provider =>
        {
            using IServiceScope scope = provider.CreateScope();
            IPublishEndpoint publishEndpoint = scope.ServiceProvider.GetService<IPublishEndpoint>();
            return new(publishEndpoint);
        });
    })
    .Build();

await host.RunAsync();