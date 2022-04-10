using CsvHelper.Configuration.Attributes;

namespace CsvProcessorApi.Models
{
    public class Details
    {
        [Name("identificacion")]
        public string Identification { get; set; }

        [Name("nombre")]
        public string FirstNasme { get; set; }

        [Name("apellido")]
        public string LastName { get; set; }

        [Name("direccion")]
        public string Direction { get; set; }

        [Name("barrio")]
        public string Neighborhood { get; set; }

        [Name("telefono")]
        public string PhoneNumber { get; set; }

        [Name("genero")]
        public string Gender { get; set; }

        [Name("edad")]
        public string Age { get; set; }

        [Name("profesion")]
        public string Profession { get; set; }
    }
}
