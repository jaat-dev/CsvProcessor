using CsvProcessorApi.Models.Mappers;

namespace CsvProcessorApi.Models.Responses
{
    public class FileResponse
    {
        public FileModel FileModel { get; set; }
        public List<DetailMap> DetailList { get; set; }
    }
}
