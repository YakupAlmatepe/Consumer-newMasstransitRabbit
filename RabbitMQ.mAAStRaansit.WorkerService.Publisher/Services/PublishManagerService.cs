using MassTransit;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.mAAStRaansit.WorkerService.Publisher.Services
{
    //backgrounService olacak 


   
    public class PublishManagerService : BackgroundService
    {
        readonly IPublishEndpoint _publishEndpoint;

        public PublishManagerService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;
            while (true)
            {
                ExampleMessage message = new()
                {
                    Text = $"{++i}. mesaj"
                };

                await _publishEndpoint.Publish(message);
            }
        }
    }
}