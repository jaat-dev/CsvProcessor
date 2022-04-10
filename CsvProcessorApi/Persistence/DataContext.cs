using CsvProcessorApi.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsvProcessorApi.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CsvProcessorApi.Persistence.Entities.File> Files { get; set; }
        public DbSet<FileDetail> FileDetails { get; set; }
    }
}
