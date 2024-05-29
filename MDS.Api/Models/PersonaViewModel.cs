using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreatePersonaViewModel
    {
        //[Required]
        public int? CPER_IDPERSONA { get; set; }
        //[Required]
        public int? CPAI_IDPAIS { get; set; }
        //[Required]
        public int? CUBI_IDUBIGEO { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellido_paterno { get; set; }
        [Required]
        public string apellido_materno { get; set; }
        [Required]
        public string dni { get; set; }
        //[Required]
        public DateTime fecha_nacimiento { get; set; }
        //[Required]
        public string sexo { get; set; }
        //[Required]
        public string? SPER_DEPARTAMENTO { get; set; }
        //[Required]
        public string? SPER_PROVINCIA { get; set; }
        //[Required]
        public string? SPER_DISTRITO { get; set; }
        //[Required]
        public string? SPER_DIRECCION { get; set; }
        //[Required]
        public string? SPER_EMAIL1 { get; set; }
        //[Required]
        public string? SPER_EMAIL2 { get; set; }
        //[Required]
        public string? SPER_TELEFONO_CASA { get; set; }
        //[Required]
        public string celular { get; set; }
        //[Required]
        public string? SPER_TELEFONO_CORPORATIVO { get; set; }
        //[Required]
        public bool? FPER_ESTADO { get; set; }
        //[Required]
        public int usuario_creacion { get; set; }
        //[Required]
        public DateTime? DPER_FECHA_CREACION { get; set; }
        //[Required]
        public int? NPER_USUARIO_MODIFICACION { get; set; }
        //[Required]
        public DateTime? DPER_FECHA_MODIFICACION { get; set; }
    }
}
