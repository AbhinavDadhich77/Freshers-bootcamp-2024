using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;

namespace BlobTriggerForConverting
{
    public interface IExcelToJsonConversion
    {
        List<string> ConvertExcelToJson(Stream excelContent, ILogger log);
    }
}