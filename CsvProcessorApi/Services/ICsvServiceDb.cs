using CsvProcessorApi.Models;
using CsvProcessorApi.Models.Responses;
using CsvProcessorApi.Utils;

namespace CsvProcessorApi.Services
{
    public interface ICsvServiceDb
    {

        Task<DataCollection<DetailModel>?> GetAllAsync(int page, int take);
        Task<int> Insert(FileResponse csvFile);
    }
}
