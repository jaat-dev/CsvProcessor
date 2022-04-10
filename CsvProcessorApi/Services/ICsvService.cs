using CsvProcessorApi.Models;

namespace CsvProcessorApi.Services
{
    public interface ICsvService
    {
        List<Details> ReadCsvFileToEmployeeModel(string fullPathFile);
    }
}
