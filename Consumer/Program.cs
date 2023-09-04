
using Consumer.Consumer;
using MassTransit;

string rabbitMQUri = "amqps://jsdeqiyh:s74D08I87i7ctRg1GKE4SE8A7wIiHVRr@beaver.rmq.cloudamqp.com/jsdeqiyh";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);

    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();