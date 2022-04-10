using System.ComponentModel.DataAnnotations;

namespace CsvProcessorApi.Persistence.Entities
{
    public class FileEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public int TotalRows { get; set; }
        public List<FileDetailEntity> FileDetail { get; set; }
    }
}
