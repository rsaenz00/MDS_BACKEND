using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class LoginUsuarioViewModel
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe tener mínimo 3 caracteres y máximo 50 caracteres")]
        [DataType(DataType.Text)]
        public string usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }
    }
}
