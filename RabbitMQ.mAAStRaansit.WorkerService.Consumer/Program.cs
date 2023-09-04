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

//MASSTEANSÝTDE Publish .
//event tabanlý mesaj bildirim yöntemini ifade eder. özünde publiah/subscribe patterni uygulamaktadýr. event publish edildiðinde, o evente subscribe olan tüm queuelere mesaj iletilecektir ayýca masstransitte ýpublisher referansýyla kullanýlabilmektedir




// Send Fonksiyonu ise;
// command tabanlý mesaj iletim yöntemini ifade eder. herhangi kuyruða mesaj iletimii olacaksa endpoint olarak bildirilmesi gereklemtedir.