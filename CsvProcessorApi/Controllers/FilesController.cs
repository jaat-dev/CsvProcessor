using CsvHelper;
using CsvHelper.Configuration;
using CsvProcessorApi.Mappers;
using CsvProcessorApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CsvProcessorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post(IFormFile file)
        {
            string fullPathFile = GetFullPathFile(file);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                //PrepareHeaderForMatch = args => args.Header.ToLower(),
                Delimiter = ";"
            };
            using (var reader = new StreamReader(fullPathFile))
            using (var csv = new CsvReader(reader, config))
            {
                //csv.Context.RegisterClassMap<DetailsMap>();
                var records = csv.GetRecords<Details>().ToList();
            }

            return Ok();
        }

        private string GetFullPathFile(IFormFile file)
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
