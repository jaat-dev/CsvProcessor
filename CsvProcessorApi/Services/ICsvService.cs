using CsvProcessorApi.Models.Responses;

namespace CsvProcessorApi.Services
{
    public interface ICsvService
    {
        FileResponse ReadCsvFile(IFormFile file);
    }
}
