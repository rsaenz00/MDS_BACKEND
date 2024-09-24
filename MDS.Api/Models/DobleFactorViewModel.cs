using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class ValidateDobleFactorViewModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Text)]
        public string email { get; set; }
    }
}
