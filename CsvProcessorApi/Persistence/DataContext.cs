using CsvProcessorApi.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsvProcessorApi.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<FileEntity> Files { get; set; }
        public DbSet<FileDetailEntity> FileDetails { get; set; }
    }
}
