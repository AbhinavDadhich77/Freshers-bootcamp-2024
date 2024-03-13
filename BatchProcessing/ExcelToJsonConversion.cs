using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace BlobTriggerForConverting
{
    public class ExcelToJsonConversion : IExcelToJsonConversion
    {
        public List<string> ConvertExcelToJson(Stream excelContent, ILogger log)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<string> jsonList = new List<string>();

            using (var excelPackage = new ExcelPackage(excelContent))
            {
                var worksheet = excelPackage.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++) // Start from row 2 to skip headers
                {
                    var rowData = new Dictionary<string, string>();

                    for (int col = 1; col <= colCount; col++)
                    {
                        var cellValue = worksheet.Cells[row, col].Text;
                        var columnName = worksheet.Cells[1, col].Text;
                        rowData.Add(columnName, cellValue);
                    }

                    var jsonString = JsonConvert.SerializeObject(rowData, Formatting.Indented); // Indent for readability
                    jsonList.Add(jsonString);

                    log.LogInformation($"Generated JSON data:\n{jsonString}");
                }

                return jsonList;
            }
        }

    }
}