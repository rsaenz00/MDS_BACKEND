using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreatePersonaViewModel
    {
        [Required]
        public int CPAI_IDPAIS { get; set; }
        [Required]
        public int CUBI_IDUBIGEO { get; set; }
        [Required]
        public string SPER_NOMBRES { get; set; }
        [Required]
        public string SPER_APELLIDO_PATERNO { get; set; }
        [Required]
        public string SPER_APELLIDO_MATERNO { get; set; }
        [Required]
        public string SPER_DNI { get; set; }
        [Required]
        public DateTime DPER_FECHA_NACIMIENTO { get; set; }
        [Required]
        public string SPER_GENERO { get; set; }
        [Required]
        public string SPER_DEPARTAMENTO { get; set; }
        [Required]
        public string SPER_PROVINCIA { get; set; }
        [Required]
        public string SPER_DISTRITO { get; set; }
        [Required]
        public string SPER_DIRECCION { get; set; }
        [Required]
        public string SPER_EMAIL1 { get; set; }
        [Required]
        public string SPER_EMAIL2 { get; set; }
        [Required]
        public string SPER_TELEFONO_CASA { get; set; }
        [Required]
        public string SPER_TELEFONO_CELULAR { get; set; }
        [Required]
        public string SPER_TELEFONO_CORPORATIVO { get; set; }
        [Required]
        public bool FPER_ESTADO { get; set; }
        [Required]
        public int NPER_USUARIO_CREACION { get; set; }
        [Required]
        public DateTime DPER_FECHA_CREACION { get; set; }
        [Required]
        public int NPER_USUARIO_MODIFICACION { get; set; }
        [Required]
        public DateTime DPER_FECHA_MODIFICACION { get; set; }

    }
}
