using Consumer.Consumer;
using MassTransit;
using RabbitMQ.mAAStRaansit.WorkerService.Consumer;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(configurator =>
        {
            configurator.AddConsumer<ExampleMessageConsumer>();

            configurator.UsingRabbitMq((context, _configurator) =>
            {
                _configurator.Host("amqps://jsdeqiyh:s74D08I87i7ctRg1GKE4SE8A7wIiHVRr@beaver.rmq.cloudamqp.com/jsdeqiyh");

                _configurator.ReceiveEndpoint("example-message-queue", e => e.ConfigureConsumer<ExampleMessageConsumer>(context));
            });
        });
    })
    .Build();

await host.RunAsync();

//MASSTEANSİTDE Publish .
//event tabanlı mesaj bildirim yöntemini ifade eder. özünde publiah/subscribe patterni uygulamaktadır. event publish edildiğinde, o evente subscribe olan tüm queuelere mesaj iletilecektir ayıca masstransitte ıpublisher referansıyla kullanılabilmektedir




// Send Fonksiyonu ise;
// command tabanlı mesaj iletim yöntemini ifade eder. herhangi kuyruğa mesaj iletimii olacaksa endpoint olarak bildirilmesi gereklemtedir.