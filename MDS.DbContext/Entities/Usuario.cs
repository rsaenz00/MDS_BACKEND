using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities
{
    public  class Usuario
    {
        public int CUSR_ID { get; set; }
        public string? SUSR_NOMBRE { get; set; }
        public string? SUSR_CONTRASENA { get; set; }
        public string? SPER_NOMBRES { get; set; }
        public string? SPER_APELLIDO_PATERNO { get; set; }
        public string? SPER_APELLIDO_MATERNO { get; set; }
        public string? SUSR_EMAIL_CORP { get; set; }
        public string? SUSR_TLF_CELULAR_CORP { get; set; }
        public bool FUSR_DOBLE_FACTOR { get; set; }
        public bool FUSR_EMAIL_CONFIRMACION { get; set; }
        public int NUSR_INTENTOS_FALLIDOS { get; set; }
        public bool FUSR_ESTADO { get; set; }
        public int NUSR_USUARIO_CREACION { get; set; }
        public long DUSR_FECHA_CREACION { get; set; }
        public int NUSR_USUARIO_MODIFICACION { get; set; }
        public long DUSR_FECHA_MODIFICACION { get; set; }
    }
}
