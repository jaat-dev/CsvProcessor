using CsvProcessorApi.Models;
using CsvProcessorApi.Models.Responses;
using CsvProcessorApi.Persistence;
using CsvProcessorApi.Persistence.Entities;
using CsvProcessorApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace CsvProcessorApi.Services
{
    public class CsvServiceDb : ICsvServiceDb
    {
        private readonly DataContext _db;

        public CsvServiceDb(DataContext db)
        {
            _db = db;
        }

        public async Task<DataCollection<DetailModel>?> GetAllAsync(int page, int take)
        {
            var collection = await _db.FileDetails
                .OrderBy(x => x.LastName)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<DetailModel>>();
        }

        public async Task<int> Insert(FileResponse csvFile)
        {
            List<FileDetailEntity> detailList = new();

            foreach (var detail in csvFile.DetailList)
            {
                var fileDetail = new FileDetailEntity
                {
                    Identification = detail.Identification,
                    FirstNasme = detail.FirstNasme,
                    LastName = detail.LastName,
                    Direction = detail.Direction,
                    Neighborhood = detail.Neighborhood,
                    PhoneNumber = detail.PhoneNumber,
                    Age = detail.Age,
                    Gender = detail.Gender,
                    Profession = detail.Profession
                };
                detailList.Add(fileDetail);
            }

            FileEntity fileEntity = new()
            {
                FileName = csvFile.FileModel.FileName,
                TotalRows = csvFile.FileModel.TotalRows,
                FileDetail = detailList
            };

            await _db.AddAsync(fileEntity);
            return await _db.SaveChangesAsync();
        }

    }
}
