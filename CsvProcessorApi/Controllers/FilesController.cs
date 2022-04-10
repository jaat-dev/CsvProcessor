using CsvProcessorApi.Models;
using CsvProcessorApi.Models.Responses;
using CsvProcessorApi.Services;
using CsvProcessorApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CsvProcessorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ICsvService _csvServices;
        private readonly ICsvServiceDb _csvServiceDb;

        public FilesController(
            ICsvService csvServices,
            ICsvServiceDb csvServiceDb)
        {
            _csvServices = csvServices;
            _csvServiceDb = csvServiceDb;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<DetailModel>?>> Get(
            int page = 1, 
            int take = 10, 
            string? ids = null)
        {
            try
            {
                return Ok(await _csvServiceDb.GetAllAsync(page, take, ids));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(IFormFile file)
        {
            try
            {
                FileResponse csvFile = _csvServices.ReadCsvFile(file);
                await _csvServiceDb.Insert(csvFile);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
