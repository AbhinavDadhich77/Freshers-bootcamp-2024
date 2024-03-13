using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using Newtonsoft.Json;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace BlobTriggerForConverting
{
    public class BlobTriggerForConverting
    {
        private readonly IExcelToJsonConversion _excelToJsonConversion;
        private readonly IQueuePublisher _queuePublisher;

        public BlobTriggerForConverting(IExcelToJsonConversion excelToJsonConversion, IQueuePublisher queuePublisher)
        {
            _excelToJsonConversion = excelToJsonConversion;
            _queuePublisher = queuePublisher;
        }

        [Function("Run")]
        public async Task Run(
            [BlobTrigger("featuremeshcontainer/{name}", Connection = "AzureWebJobsStorage")] Stream excelContent,
            string name,
            FunctionContext context)
        {
            var log = context.GetLogger("ExcelToJsonFunction");
            log.LogInformation($"Blob trigger function processed blob\n Name: {name}");

            try
            {
                // Convert Excel to JSON
                var jsonString = _excelToJsonConversion.ConvertExcelToJson(excelContent, log);

                // Push JSON to the queue
                await _queuePublisher.PublishToQueue(jsonString, context);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                log.LogError($"Error processing blob '{name}': {ex.Message}");
                throw;
            }
        }
    }
}