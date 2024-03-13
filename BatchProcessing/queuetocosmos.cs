using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos;
using Azure.Storage.Queues.Models;
using System.Text.Json;
using BlobTriggerForConverting;

namespace Company.Function
{
    public class queuetocosmos
    {
        private readonly string _databaseName;
        private readonly string _containerName;
        private readonly ILogger<queuetocosmos> _logger;
        private readonly CosmosClient _cosmosClient;

        public queuetocosmos(ILogger<queuetocosmos> logger)
        {
            _logger = logger;
            _databaseName = "feature-store"; // Replace with your actual database name
            _containerName = "Feature"; // Replace with your actual container name
            
            var cosmosConnectionString = Environment.GetEnvironmentVariable("CosmosDBConnectionString");
            _cosmosClient = new CosmosClient(cosmosConnectionString);
        }

        [Function(nameof(queuetocosmos))]
        public async Task Run([QueueTrigger("features", Connection = "featuremeshstorage_STORAGE")] QueueMessage message)
        {
            try
            {
                var cosmosContainer = _cosmosClient.GetContainer(_databaseName, _containerName);
                var jsonString = message.MessageText;
                //var feature = JsonSerializer.Deserialize<FeatureModel>(jsonString);

                // Create item in Cosmos DB
                //await cosmosContainer.CreateItemAsync<FeatureModel>(feature);

                _logger.LogInformation($"Data uploaded to Cosmos DB: {jsonString}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error uploading data to Cosmos DB: {ex.Message}");
                throw;
            }
        }
    }
}