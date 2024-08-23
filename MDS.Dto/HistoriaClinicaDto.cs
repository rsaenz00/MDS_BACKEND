namespace MDS.Dto
{
    public class HistoriaClinicaDto
    {
        public long cod_historia_clinica { get; set; }//MAD - SCTR
        public string paciente { get; set; }//MAD - SCTR
        public string fecha_creacion { get; set; }//MAD - SCTR
        public string fecha_nacimiento { get; set; }//MAD - SCTR
        public int edad { get; set; }//MAD - SCTR
        public string hora_atencion { get; set; }//MAD - SCTR
        public string celular { get; set; }//MAD - SCTR
        public string pais { get; set; }//MAD - SCTR
        public string id_cliente { get; set; }//MAD - SCTR
        public string? id_paciente { get; set; }//MAD
        public string? id_medico { get; set; }//MAD
        public string? vip { get; set; }//MAD
        public string? medico { get; set; }//MAD
        public string? aseguradora { get; set; }//MAD
        public string? especialidad { get; set; }//MAD
        public string? sintomas { get; set; }//MAD
        public string? tipo_atencion { get; set; }//MAD
        public string? programacion { get; set; }//MAD
        public string? nro_descanso_medico { get; set; }//MAD
        public string? cambio_realizar { get; set; }//MAD
        public string? moneda_deducible { get; set; }//MAD
        public string? monto_deducible { get; set; }//MAD
        public string? coaseguro { get; set; }//MAD
        public string? tipo_documento_pago { get; set; }//MAD
        public string? numero_documento_pago { get; set; }//MAD
        public string? forma_pago { get; set; }//MAD
        public string? moneda_denominacion { get; set; }//MAD
        public string? monto_denominacion { get; set; }//MAD
        public string? telefono { get; set; }//MAD
        public string? anexo { get; set; }//MAD
        public string? referencia { get; set; }//MAD
        public string? direccion { get; set; }//MAD
        public string? provincia { get; set; }//MAD
        public string? distrito { get; set; }//MAD
        public string? sexo { get; set; }//SCTR
        public string? documento_identidad { get; set; }//SCTR
        public string? numero_documento_id { get; set; }//SCTR
        public string? descripcion_ipress { get; set; }//SCTR
        public string? ipress_telefono { get; set; }//SCTR
        public string? ipress_anexo { get; set; }//SCTR
        public string? empresa { get; set; }//SCTR
        public string? empresa_ruc { get; set; }//SCTR
        public string? horario_trabajo { get; set; }//SCTR
        public string? puesto_cargo { get; set; }//SCTR
        public string? relato { get; set; }//SCTR
        public string? fecha_accidente { get; set; }//SCTR
        public string? hora_accidente { get; set; }//SCTR
        public string? tipo_historia_clinica { get; set; }//SCTR
        public string? pase_atencion { get; set; }//SCTR
        public string? motivo { get; set; }//SCTR
        public string? observacion { get; set; }//SCTR
        public string? ipress_primera_ate { get; set; }//SCTR
        public int? id_clinica { get; set; }//SCTR
        public string? persona_reporta { get; set; }//SCTR
        public int? id_motivo { get; set; }//SCTR
        public int? id_clinica_primera_atencion { get; set; }//SCTR
        public int? numero_atencion { get; set; }//SCTR
        public int? metodo_validacion { get; set; }//SCTR
        public Boolean? hoja_atencion { get; set; }//SCTR
        public int? id_plan { get; set; }//SCTR
        public int? skill { get; set; }//SCTR
        public int? motivo_skill { get; set; }//SCTR
    }

    public class HistoriaClinicaMtoDto
    {
        public long cod_historia_clinica { get; set; }
        public long id_persona { get; set; }
        public long id_empresa { get; set; }
        public long id_clinica { get; set; }
        public long id_motivo { get; set; }
        public int id_plan { get; set; }
        public string telefono { get; set; }
        public string anexo { get; set; }
        public string horario_trabajo { get; set; }
        public string cargo { get; set; }
        public string relato { get; set; }
        public string fecha_accidente { get; set; }
        public string hora_accidente { get; set; }
        public string observacion { get; set; }
        public string primera_atencion { get; set; }
        public string metodo_validacion { get; set; }
        public int? hoja_atencion { get; set; }
        public string ubigeo { get; set; }
        public int skill { get; set; }
        public int motivo_skill { get; set; }
        public int centro_clinico { get; set; }
        public int empresa { get; set; }
        public int corredor_seguro { get; set; }
        public int paciente_asegurado { get; set; }
        public string persona_reporta_clinica { get; set; }
        public string persona_reporta_empresa { get; set; }
        public string persona_reporta_seguro { get; set; }
        public string persona_reporta_asegurado { get; set; }
        public int? id_clinica_primera_atencion { get; set; }
        public int estado { get; set; }
        public int? pase_atencion { get; set; }
        public int usuario_creacion { get; set; }
        public int usuario_eliminacion { get; set; }
        //public DateTime DATE_FECHA_CREACION { get; set; }
        //public int usuario_modificacion { get; set; }
        //public DateTime DATE_FECHA_MODIFICACION { get; set; }

        //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
        public int? CPAR_ID_MOTIVO_CALLMEDICO { get; set; }
        public int? CPAR_ID_REFERENCIA_AMBULANCIA { get; set; }
        public int? CCEN_ID { get; set; }
        public int? CECM_ID { get; set; }
        public int? CPAR_ID_SOLICITUD { get; set; }

        //TBLMDS_HISTORIA_CLINICA
        public string? SHIS_ESTADO { get; set; }
        public string? SHIS_CM_ESTADO { get; set; }
        public int? NHIS_COD_ESTADO { get; set; }
        public Boolean? FHIS_FLG_CM_NUEVA { get; set; }
        public int? NHIS_CM_ORDEN { get; set; }
        public string? SHIS_REF_DIR { get; set; }
        public string? SHIS_NOM_EMP { get; set; }
        public string? NHIS_EDAD_ATE { get; set; }
        public string? SHIS_CEL_PAC { get; set; }
        public string? SHIS_CM_REF_DIR { get; set; }
        public Boolean? FHIS_FLAG_PROGRAMADA { get; set; }
        public string? NHIS_COD_TARIFA { get; set; }
        public string? SHIS_F_PROG { get; set; }
        public string? SHIS_COD_TIPO_PROG { get; set; }
        public string? SHIS_COD_DR_SOLICITADO { get; set; }
        public string? SHIS_COD_DEP { get; set; }
        public Boolean? FHIS_CM_DIRECTA { get; set; }
        public string? SHIS_FLG_DIRECTO { get; set; }
        public Boolean? FHIS_CM_DATOS_COMPLETOS { get; set; }
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
        public string? SHIS_TIPO_SERVICIO { get; set; }
        public int? NHIS_COD_PRIORIDAD_CALLMED { get; set; }
        public int? NHIS_COD_MOTIVO_ATE_CALLMED { get; set; }
        public int? NHIS_CLASIFICACION_PAC { get; set; }
        public string? SHIS_TIPO_DOC_PAGO { get; set; }
        public string? SHIS_DESCRP_ZONA { get; set; }
        public string? SHIS_PERSONAL_CONTACTO { get; set; }
        public string? DHIS_HOR_ATE { get; set; }
        public string? SHIS_COD_EMP { get; set; }
        public string? SHIS_AMB_COD_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_DES_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_DIR_ORIGEN { get; set; }
        public string? SHIS_AMB_REF_DIR_ORIGEN { get; set; }
        public string? DHIS_AMB_FECHA_INI { get; set; }
        public string? DHIS_AMB_HORA_INI { get; set; }
        public string? DHIS_AMB_FECHA_FIN { get; set; }
        public string? DHIS_AMB_HORA_FIN { get; set; }
        public string? SHIS_AMB_COD_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DES_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DIR_DESTINO { get; set; }
        public string? SHIS_AMB_REF_DIR_DESTINO { get; set; }
        public string? SHIS_USULLA_ATE { get; set; }
        public int? CPAC_ID { get; set; }
        public int? CPER_ID { get; set; }
        public int? CCLI_ID { get; set; }
        public string? DHIS_OBS_CM { get; set; }
        public int? NHIS_CLASIFICACION_PAC_CALLMED { get; set; }
        public string? NHIS_ID_TIPO_TRASLADO_CALLMED { get; set; }
        public string? SHIS_COD_AUT_PRESTACION { get; set; }
        public string? SHIS_CONTRATANTE_CITRIX { get; set; }
        public string? SHIS_COD_ASEGURADO { get; set; }
        public string? SHIS_CM_ASEG_PRODUCTO { get; set; }
        public string? SHIS_POLIZA_ASEGURADO { get; set; }
        public string? SHIS_POLIZA_CERTIFICADO { get; set; }
        public string? FHIS_AMB_SERVICIO_PLAYA { get; set; }
    }

    public class HistoriaClinicaBandejaDto
    {
        public long cod_historia_clinica { get; set; }
        public string? tipo_historia_clinica { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string? documento_identidad { get; set; }
        public string? numero { get; set; }
        public string? paciente { get; set; }
        public string? fecha_nacimiento { get; set; }
        public string clinica { get; set; }
        public string? empresa { get; set; }
        public string? empresa_ruc { get; set; }
        public string usuario_creacion { get; set; }
        public string motivo { get; set; }
        public string? plan { get; set; }
        public string skill { get; set; }
        public string? procedencia { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
        public string? hoja_atencion { get; set; }
        public string? medio_validacion { get; set; }
        public string? pase_atencion { get; set; }
        public string? observacion { get; set; }
        public string? persona_reporta { get; set; }
        public string? motivo_de_llamada { get; set; }
    }

    /*INICIO MAD*/
    public class ClienteAseguradoraDto
    {
        public string id_cliente { get; set; }
        public string? nombre { get; set; }

    }
    /*FIN MAD*/
}
