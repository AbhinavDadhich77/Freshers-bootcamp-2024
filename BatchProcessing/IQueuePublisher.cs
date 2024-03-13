using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;

namespace BlobTriggerForConverting
{
    public interface IQueuePublisher
    {
        Task PublishToQueue(List<string> jsonString, FunctionContext context);
    }
}
