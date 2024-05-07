using System.Data.SqlTypes;

namespace MDS.DbContext.Entities
{
    public class Atencion
    {
        public long CATE_ID { get; set; }
        public long CPER_ID { get; set; }
        public long CEMP_ID { get; set; }
        public long CCLI_ID { get; set; }
        public long CMOT_ID { get; set; }
        public long CPLA_ID { get; set; }
        public string SATE_TELEFONO { get; set; }
        public string SATE_ANEXO { get; set; }
        public string SATE_HORARIO_TRABAJO { get; set; }
        public string SATE_CARGO { get; set; }
        public string SATE_RELATO { get; set; }
        public string DATE_FECHA_ACCIDENTE { get; set; }
        public string DATE_HORA_ACCIDENTE { get; set; }
        public string SATE_OBSERVACION { get; set; }
        public string SATE_PRIMERA_ATENCION { get; set; }
        public string SATE_METODO_VALIDACION { get; set; }
        public string SATE_HOJA_ATENCION { get; set; }
        public string CUBI_UBIGEO { get; set; }
        public int NATE_SKILL { get; set; }
        public int NATE_MOTIVO_SKILL { get; set; }
        public Boolean FATE_CENTRO_CLINICO { get; set; }
        public Boolean FATE_EMPRESA { get; set; }
        public Boolean FATE_CORREDOR_SEGURO { get; set; }
        public Boolean FATE_PACIENTE_ASEGURADO { get; set; }
        public string SATE_PERSONA_REPORTA_CLINICA { get; set; }
        public string SATE_PERSONA_REPORTA_EMPRESA { get; set; }
        public string SATE_PERSONA_REPORTA_SEGURO { get; set; }
        public string SATE_PERSONA_REPORTA_ASEGURADO { get; set; }
        public Boolean FATE_ESTADO { get; set; }
        //public int NATE_USUARIO_CREACION { get; set; }
        //public DateTime DATE_FECHA_CREACION { get; set; }
        //public int NATE_USUARIO_MODIFICACION { get; set; }
        //public DateTime DATE_FECHA_MODIFICACION { get; set; }
    }
    public class AtencionBandeja
    {
        public long cod_atencion { get; set; }
        public string tipo_atencion { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string documento_identidad { get; set; }
        public string numero { get; set; }
        public string paciente { get; set; }
        public string fecha_nacimiento { get; set; }
        public string clinica { get; set; }
        public string empresa { get; set; }
        public string empresa_ruc { get; set; }
        public string usuario_creacion { get; set; }
        public string motivo { get; set; }
        public string plan { get; set; }
        public string skill { get; set; }
    }
}