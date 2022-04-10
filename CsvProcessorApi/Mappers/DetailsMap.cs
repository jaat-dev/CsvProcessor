using CsvHelper.Configuration;
using CsvProcessorApi.Models;

namespace CsvProcessorApi.Mappers
{
    public class DetailsMap : ClassMap<Details>
    {
        public DetailsMap()
        {
            Map(m => m.Identification).Name("identificacion");
            Map(m => m.FirstNasme).Name("nombre");
            Map(m => m.LastName).Name("apellido");
            Map(m => m.Direction).Name("direccion");
            Map(m => m.Neighborhood).Name("barrio");
            Map(m => m.PhoneNumber).Name("telefono");
            Map(m => m.Gender).Name("genero");
            Map(m => m.Age).Name("edad");
            Map(m => m.Profession).Name("profesion");
        }


    }
}
