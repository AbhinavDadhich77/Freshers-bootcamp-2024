using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlobTriggerForConverting;
//using BlobTriggerForConverting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<IExcelToJsonConversion, ExcelToJsonConversion>();
        services.AddSingleton<IQueuePublisher, QueuePublisher>();
    })
    .Build();

host.Run();
