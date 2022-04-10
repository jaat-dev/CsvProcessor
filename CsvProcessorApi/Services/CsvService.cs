using CsvHelper;
using CsvHelper.Configuration;
using CsvProcessorApi.Models;
using CsvProcessorApi.Models.Mappers;
using CsvProcessorApi.Models.Responses;
using System.Globalization;

namespace CsvProcessorApi.Services
{
    public class CsvService : ICsvService
    {
        public FileResponse ReadCsvFile(IFormFile file)
        {
            try
            {
                string fullPathFile = GetFullPathFile(file);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using var reader = new StreamReader(fullPathFile);
                using var csv = new CsvReader(reader, config);
                var records = csv.GetRecords<DetailMap>().ToList();
                var response = new FileResponse
                {
                    DetailList = records,
                    FileModel = new FileModel
                    {
                        FileName = file.FileName,
                        TotalRows = records.Count
                    }
                };
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string GetFullPathFile(IFormFile file)
        {
            string filePath = Environment.CurrentDirectory + $"\\Files\\" + file.FileName;
            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return filePath;
        }
    }
}
