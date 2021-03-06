namespace CsvProcessorApi.Models
{
    public class DetailModel
    {
        public Guid Id { get; set; }
        public string Identification { get; set; }
        public string FirstNasme { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public string Neighborhood { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Profession { get; set; }
        public FileModel File { get; set; }
    }
}
