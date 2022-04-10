using System.ComponentModel.DataAnnotations;

namespace CsvProcessorApi.Persistence.Entities
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public int TotalRows { get; set; }
        public int TotalColumns { get; set; }
        public string FilePath { get; set; }
        public List<FileDetail> FileDetail { get; set; }
    }
}
