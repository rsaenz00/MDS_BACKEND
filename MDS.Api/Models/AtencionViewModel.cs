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
        public string? id_plan { get; set; }
        //[Required]
        public string? horario_trabajo { get; set; }
        //[Required]
        public string? cargo { get; set; }
        public string? relato { get; set; }
        public string? fecha_accidente { get; set; }
        public string? hora_accidente { get; set; }
        public string observacion { get; set; }
        public string? primera_atencion { get; set; }
        //[Required]
        public string? metodo_validacion { get; set; }
        //[Required]
        public string? hoja_atencion { get; set; }
        //[Required]
        public string? ubigeo { get; set; }
        //[Required]
        public int skill { get; set; }
        //[Required]
        public int motivo_skill { get; set; }
        public int centro_clinico { get; set; }
        public int empresa { get; set; }
        public int corredor_seguro { get; set; }
        public int paciente_asegurado { get; set; }
        public string? persona_reporta_clinica { get; set; }
        public string? persona_reporta_empresa { get; set; }
        public string? persona_reporta_seguro { get; set; }
        public string? persona_reporta_asegurado { get; set; }
        public int usuario_creacion { get; set; }
        public int? id_clinica_primera_atencion { get; set; }
        public int estado { get; set; }
    }

    public class UpdateAtencionViewModel
    {
        [Required]
        public long id_atencion { get; set; }
        //[Required]
        public long id_persona { get; set; }
        //[Required]
        public long id_empresa { get; set; }
        //[Required]
        public long id_clinica { get; set; }
        //[Required]
        public long id_motivo { get; set; }
        //[Required]
        public string id_plan { get; set; }
        //[Required]
        public string? horario_trabajo { get; set; }
        //[Required]
        public string? cargo { get; set; }
        public string? relato { get; set; }
        public string? fecha_accidente { get; set; }
        public string? hora_accidente { get; set; }
        public string observacion { get; set; }
        public string? primera_atencion { get; set; }
        //[Required]
        public string? metodo_validacion { get; set; }
        //[Required]
        public string? hoja_atencion { get; set; }
        //[Required]
        public string? ubigeo { get; set; }
        //[Required]
        public int skill { get; set; }
        //[Required]
        public int motivo_skill { get; set; }
        public int centro_clinico { get; set; }
        public int empresa { get; set; }
        public int corredor_seguro { get; set; }
        public int paciente_asegurado { get; set; }
        public string? persona_reporta_clinica { get; set; }
        public string? persona_reporta_empresa { get; set; }
        public string? persona_reporta_seguro { get; set; }
        public string? persona_reporta_asegurado { get; set; }
        public int usuario_modificacion { get; set; }
        public int? id_clinica_primera_atencion { get; set; }
        public int estado { get; set; }
    }

    public class DeleteAtencionViewModel
    {
        [Required]
        public long id_atencion { get; set; }
        public int usuario_eliminacion{ get; set; }
    }
}
