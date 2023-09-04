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

//MASSTEANS�TDE Publish .
//event tabanl� mesaj bildirim y�ntemini ifade eder. �z�nde publiah/subscribe patterni uygulamaktad�r. event publish edildi�inde, o evente subscribe olan t�m queuelere mesaj iletilecektir ay�ca masstransitte �publisher referans�yla kullan�labilmektedir




// Send Fonksiyonu ise;
// command tabanl� mesaj iletim y�ntemini ifade eder. herhangi kuyru�a mesaj iletimii olacaksa endpoint olarak bildirilmesi gereklemtedir.