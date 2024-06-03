using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateDireccionViewModel
    {
        [Required]
        public long CPER_ID { get; set; }
        public int NDIR_TIPO_DIRECCION { get; set; }
        [Required]
        public string SDIR_DESCRIPCION { get; set; }
        [Required]
        public string SDIR_COD_DPTO { get; set; }
        [Required]
        public string SDIR_COD_PROV { get; set; }
        [Required]
        public string SDIR_COD_DIST { get; set; }
        public string SDIR_ANEXO { get; set; }
        [Required]
        public string SDIR_TLF_CELULAR { get; set; }
        public string SDIR_TLF_FIJO { get; set; }
        public string SDIR_NRO_LOTE { get; set; }
        public string SDIR_URBANIZACION { get; set; }
        public string SDIR_REFERENCIA { get; set; }
        public string SDIR_INTERIOR { get; set; }
        public char SDIR_LONGITUD { get; set; }
        public char SDIR_LATITUD { get; set; }
        public Boolean FDIR_ELIMINADO { get; set; }
        public DateTime DDIR_FECHA_ELIMINACION { get; set; }
        public int NDIR_USUARIO_CREACION { get; set; }
    }
    public class UpdateDireccionViewModel
    {
        [Required]
        public long CDIR_ID { get; set; }
        [Required]
        public long CPER_ID { get; set; }
        public int NDIR_TIPO_DIRECCION { get; set; }
        [Required]
        public string SDIR_DESCRIPCION { get; set; }
        [Required]
        public string SDIR_COD_DPTO { get; set; }
        [Required]
        public string SDIR_COD_PROV { get; set; }
        [Required]
        public string SDIR_COD_DIST { get; set; }
        public string SDIR_ANEXO { get; set; }
        [Required]
        public string SDIR_TLF_CELULAR { get; set; }
        public string SDIR_TLF_FIJO { get; set; }
        public string SDIR_NRO_LOTE { get; set; }
        public string SDIR_URBANIZACION { get; set; }
        public string SDIR_REFERENCIA { get; set; }
        public string SDIR_INTERIOR { get; set; }
        public char SDIR_LONGITUD { get; set; }
        public char SDIR_LATITUD { get; set; }
        public Boolean FDIR_ELIMINADO { get; set; }
        public DateTime DDIR_FECHA_ELIMINACION { get; set; }
        public int NDIR_USUARIO_MODIFICACION { get; set; }
    }
    public class DeleteDireccionViewModel
    {
        [Required]
        public long CDIR_ID { get; set; }
        [Required]
        public long CPER_ID { get; set; }
    }
}
