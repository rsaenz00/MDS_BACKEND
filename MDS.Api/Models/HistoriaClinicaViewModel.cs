using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{
    public class CreateHistoriaClinicaViewModel
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
        public int id_plan { get; set; }
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
        public int? hoja_atencion { get; set; }
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
        public int pase_atencion { get; set; }
        public int? id_clinica_primera_atencion { get; set; }
        public int estado { get; set; }

        //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
        public int? CPAR_ID_MOTIVO_CALLMEDICO { get; set; }
        public int? CPAR_ID_REFERENCIA_AMBULANCIA { get; set; }
        public int? CCEN_ID { get; set; }
        public int? CECM_ID { get; set; }
        public int? CPAR_ID_SOLICITUD { get; set; }

        //TBLMDS_HISTORIA_CLINICA
        public string? SHIS_CM_ESTADO { get; set; }
        public int? NHIS_COD_ESTADO { get; set; }
        public Boolean? FHIS_FLG_CM_NUEVA { get; set; }
        public int? NHIS_CM_ORDEN { get; set; }
        public string? SHIS_REF_DIR { get; set; }
        public int? NHIS_EDAD_ATE { get; set; }
        public string? SHIS_CEL_PAC { get; set; }
        public string? SHIS_NOM_EMP { get; set; }
        public string? SHIS_CM_REF_DIR { get; set; }
        public Boolean? FHIS_FLAG_PROGRAMADA { get; set; }
        public int? NHIS_COD_TARIFA { get; set; }
        public string? SHIS_F_PROG { get; set; }
        public string? SHIS_COD_TIPO_PROG { get; set; }
        public string? SHIS_COD_DR_SOLICITADO { get; set; }
        public string? SHIS_COD_DEP { get; set; }
        public Boolean? FHIS_CM_DIRECTA { get; set; }
        public string? SHIS_FLG_DIRECTO { get; set; }
        public Boolean? FHIS_CM_DATOS_COMPLETOS { get; set; }
        public int? NHIS_COD_PRIORIDAD_CALLMED { get; set; }
        public int? NHIS_COD_MOTIVO_ATE_CALLMED { get; set; }
        public int? NHIS_TAR_ATE { get; set; }
        public string? DHIS_FEC_ATE { get; set; }
        public string? SHIS_TIPO_SERVAMB_DRMAS { get; set; }
        public string? SHIS_COD_AMB_TIPO_SERV { get; set; }
        public int? NHIS_COASEGURO { get; set; }
        public string? SHIS_FLAGMONE { get; set; }
        public int? NHIS_CAMBIO { get; set; }
        public string? SHIS_FOR_ATE { get; set; }
        public string? SHIS_CM_MONEDA_DEN { get; set; }
        public int? NHIS_CM_DEN_CAMBIO { get; set; }
        public string? SHIS_CM_DENOMINACION { get; set; }
        public string? SHIS_CONTACTO_PAC { get; set; }
        public string? SHIS_CONTACTO_ASEG { get; set; }
        public string? SHIS_AMB_DIR_ORIGEN { get; set; }
        public string? SHIS_AMB_DES_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_COD_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_REF_DIR_ORIGEN { get; set; }
        public string? DHIS_AMB_FECHA_INI { get; set; }
        public string? DHIS_AMB_HORA_INI { get; set; }
        public string? DHIS_AMB_FECHA_FIN { get; set; }
        public string? DHIS_AMB_HORA_FIN { get; set; }
        public string? SHIS_AMB_COD_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DES_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DIR_DESTINO { get; set; }
        public string? SHIS_AMB_REF_DIR_DESTINO { get; set; }
        public string? SHIS_TIPO_SERVICIO { get; set; }
        public int? NHIS_CLASIFICACION_PAC { get; set; }
        public string? SHIS_TIPO_DOC_PAGO { get; set; }
        public string? SHIS_DESCRP_ZONA { get; set; }
        public string? DHIS_HOR_ATE { get; set; }
        public string? SHIS_COD_EMP { get; set; }
        public string? SHIS_USULLA_ATE { get; set; }
        public int? CPAC_ID { get; set; }
        public int? CPER_ID { get; set; }
        public int? CCLI_ID { get; set; }
        public string? DHIS_OBS_CM { get; set; }
        public int? NHIS_CLASIFICACION_PAC_CALLMED { get; set; }
        public int? NHIS_ID_TIPO_TRASLADO_CALLMED { get; set; }
        public string? SHIS_COD_AUT_PRESTACION { get; set; }
        public string? SHIS_CONTRATANTE_CITRIX { get; set; }
        public string? SHIS_COD_ASEGURADO { get; set; }
        public string? SHIS_CM_ASEG_PRODUCTO { get; set; }
        public string? SHIS_POLIZA_ASEGURADO { get; set; }
        public string? SHIS_POLIZA_CERTIFICADO { get; set; }
        public Boolean? FHIS_AMB_SERVICIO_PLAYA { get; set; }
        public Boolean? FHIS_FUERA_COBERTURA { get; set; }
        public string? SHIS_DIRECCION_ORIGEN { get; set; }
        public string? SHIS_DIRECCION_DESTINO { get; set; }
        public int? CCLI_ID_ORIGEN { get; set; }
        public int? CCLI_ID_DESTINO { get; set; }
        public string? SHIS_ALERGIA_MEDICA { get; set; }
        public string? SHIS_ATENCEDENTE { get; set; }
        public int? CTAM_ID { get; set; }
        public string? SHIS_RUC_EVENTO { get; set; }
        public string? SHIS_RAZON_SOCIAL_EVENTO { get; set; }
        public string? SHIS_DIRECCION_FISCAL_EVENTO { get; set; }
        public int? CPOL_ID { get; set; }
        public string? SHIS_NRO_PLACA { get; set; }
        public string? SHIS_NRO_POLIZA { get; set; }
        public string? SHIS_SINIESTRO { get; set; }
        public string? SHIS_AHUTORIZA_CORTESIA { get; set; }
        public string? SHIS_REGLA_ORO { get; set; }
        public Boolean? FHIS_AMB_RESPIRATORIA { get; set; }
        public int? CPAR_ID_SOLICITANTE { get; set; }
        public string? SHIS_UBIC_DENTRO_CLINICA_ORIGEN { get; set; }
        public string? SHIS_UBIC_DENTRO_CLINICA_DESTINO { get; set; }
        public int? NPRV_ID { get; set; }
        public string? DHIS_FECHA_EVENTO_ADVERSO { get; set; }
        public Boolean? FHIS_CITRIX { get; set; }
    }

    public class UpdateHistoriaClinicaViewModel
    {
        [Required]
        public long cod_historia_clinica { get; set; }
        //[Required]
        public long id_persona { get; set; }
        //[Required]
        public long id_empresa { get; set; }
        //[Required]
        public long id_clinica { get; set; }
        //[Required]
        public long id_motivo { get; set; }
        //[Required]
        public int id_plan { get; set; }
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
        public int? hoja_atencion { get; set; }
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
        public int? pase_atencion { get; set; }
        public int estado { get; set; }
    }

    public class DeleteHistoriaClinicaViewModel
    {
        [Required]
        public long cod_historia_clinica { get; set; }
        public long? id_motivo { get; set; }
        public int usuario_eliminacion { get; set; }
    }
}
