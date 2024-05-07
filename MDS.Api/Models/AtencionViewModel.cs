using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateAtencionViewModel
    {
        //[Required]
        public long id_persona { get; set; }
        //[Required]
        public long id_empresa { get; set; }
        //[Required]
        public long id_clinica { get; set; }
        //[Required]
        public long id_motivo { get; set; }
        //[Required]
        public long id_plan { get; set; }
        //[Required]
        public string? telefono { get; set; }
        //[Required]
        public string? anexo { get; set; }
        //[Required]
        public string? horario_trabajo { get; set; }
        //[Required]
        public string? cargo { get; set; }
        public string? relato { get; set; }
        public string? fecha_accidente { get; set; }
        public string? hora_accidente { get; set; }
        public string observacion { get; set; }
        public string primera_atencion { get; set; }
        //[Required]
        public string? metodo_validacion { get; set; }
        //[Required]
        public string hoja_atencion { get; set; }
        //[Required]
        public string? ubigeo { get; set; }
        //[Required]
        public int skill { get; set; }
        //[Required]
        public int motivo_skill { get; set; }
        public Boolean centro_clinico { get; set; }
        public Boolean empresa { get; set; }
        public Boolean corredor_seguro { get; set; }
        public Boolean paciente_asegurado { get; set; }
        public string? persona_reporta_clinica { get; set; }
        public string? persona_reporta_empresa { get; set; }
        public string? persona_reporta_seguro { get; set; }
        public string? persona_reporta_asegurado { get; set; }
        public int usuario_creacion { get; set; }
    }
    public class UpdateAtencionViewModel
    {
        [Required]
        public long CATE_ID { get; set; }
        [Required]
        public long CPER_ID { get; set; }
        [Required]
        public long CEMP_ID { get; set; }
        [Required]
        public long CCLI_ID { get; set; }
        [Required]
        public long CMOT_ID { get; set; }
        [Required]
        public long CPLA_ID { get; set; }
        [Required]
        public string SATE_TELEFONO { get; set; }
        [Required]
        public string SATE_ANEXO { get; set; }
        [Required]
        public string SATE_HORARIO_TRABAJO { get; set; }
        [Required]
        public string SATE_CARGO { get; set; }
        [Required]
        public string SATE_RELATO { get; set; }
        [Required]
        public DateOnly DATE_FECHA_ACCIDENTE { get; set; }
        [Required]
        public TimeOnly DATE_HORA_ACCIDENTE { get; set; }
        public string SATE_OBSERVACION { get; set; }
        public string SATE_PRIMERA_ATENCION { get; set; }
        [Required]
        public string SATE_METODO_VALIDACION { get; set; }
        [Required]
        public Boolean SATE_HOJA_ATENCION { get; set; }
        [Required]
        public string CUBI_UBIGEO { get; set; }
        [Required]
        public int NATE_SKILL { get; set; }
        [Required]
        public string NATE_MOTIVO_SKILL { get; set; }
        public Boolean FATE_CENTRO_CLINICO { get; set; }
        public Boolean FATE_EMPRESA { get; set; }
        public Boolean FATE_CORREDOR_SEGURO { get; set; }
        public Boolean FATE_PACIENTE_ASEGURADO { get; set; }
        public string SATE_PERSONA_REPORTA_CLINICA { get; set; }
        public string SATE_PERSONA_REPORTA_EMPRESA { get; set; }
        public string SATE_PERSONA_REPORTA_SEGURO { get; set; }
        public string SATE_PERSONA_REPORTA_ASEGURADO { get; set; }
        public int NATE_USUARIO_MODIFICACION { get; set; }
    }
    public class DeleteAtencionViewModel
    {
        [Required]
        public long CATE_ID { get; set; }
    }
}
