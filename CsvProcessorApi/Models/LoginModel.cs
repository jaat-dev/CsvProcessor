using System.ComponentModel.DataAnnotations;

namespace CsvProcessorApi.Models
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage ="Formato no corresponde a un Email")]
        [Required(ErrorMessage ="Campo Email es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Password es obligatorio")]
        public string Password { get; set; }
    }
}
