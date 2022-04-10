using CsvHelper;
using CsvHelper.Configuration;
using CsvProcessorApi.Models;
using System.Globalization;

namespace CsvProcessorApi.Services
{
    public class CsvService : ICsvService
    {
        public List<Details> ReadCsvFileToEmployeeModel(string fullPathFile)
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var reader = new StreamReader(fullPathFile))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<Details>().ToList();
                    return records;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
