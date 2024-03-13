using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace BlobTriggerForConverting
{
    public class QueuePublisher : IQueuePublisher
    {
        public async Task PublishToQueue(List<string> jsonStrings, FunctionContext context)
        {
            var log = context.GetLogger("QueuePublisher");
            var queueConnectionString = Environment.GetEnvironmentVariable("QueueConnectionString");
            var featuresQueue = new QueueClient(queueConnectionString, "features", new QueueClientOptions
            {
                MessageEncoding = QueueMessageEncoding.Base64
            });

            foreach (var jsonString in jsonStrings)
            {
                await featuresQueue.SendMessageAsync(jsonString);
                log.LogInformation("JSON data published to the queue.");
            }
        }
    }
}