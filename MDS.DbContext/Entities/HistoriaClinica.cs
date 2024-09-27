using System.Data.SqlTypes;

namespace MDS.DbContext.Entities
{
    public class HistoriaClinicaMad
    {
        public long cod_historia_clinica { get; set; }//MAD - SCTR
        public string paciente { get; set; }//MAD - SCTR
        public string fecha_creacion { get; set; }//MAD - SCTR
        public string fecha_nacimiento { get; set; }//MAD - SCTR
        public int edad { get; set; }//MAD - SCTR
        public string hora_atencion { get; set; }//MAD - SCTR
        public string celular { get; set; }//MAD - SCTR
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
    }

    /*INICIO SCTR*/
    public class HistoriaClinicaSctr
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

    public class HistoriaClinicaBandejaSctr
    {
        public long cod_historia_clinica { get; set; }
        public string tipo_historia_clinica { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string documento_identidad { get; set; }
        public string numero { get; set; }
        public string paciente { get; set; }
        public string fecha_nacimiento { get; set; }
        public string clinica { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string hoja_atencion { get; set; }
        public string medio_validacion { get; set; }
        public string pase_atencion { get; set; }
        public string observacion { get; set; }
        public string empresa { get; set; }
        public string empresa_ruc { get; set; }
        public string usuario_creacion { get; set; }
        public string motivo { get; set; }
        public string plan { get; set; }
        public string skill { get; set; }
    }

    public class HistoriaClinicaBandejaOtrasLlamadas
    {
        public long cod_historia_clinica { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string clinica { get; set; }
        public string usuario_creacion { get; set; }
        public string motivo { get; set; }
        public string skill { get; set; }
        public string procedencia { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string persona_reporta { get; set; }
        public string motivo_de_llamada { get; set; }
    }
    /*FIN SCTR*/

    /*INICIO AMBULANCIA*/
    public class HistoriaClinicaBandejaAmbulancia
    {
        public int cod_historia_clinica { get; set; }
        public string cod_siteds { get; set; }
        public string cotizado { get; set; }
        public string estado { get; set; }
        public string estado_sm { get; set; }
        public string tipo_servicio { get; set; }
        public string cod_amb_tipo_serv { get; set; }
        public string servicio { get; set; }
        public int? id_paciente { get; set; }
        public int? id_persona { get; set; }
        public Boolean? servicio_playa { get; set; }
        public string? deducible { get; set; }
        public string? coaseguro { get; set; }
        public int? cod_prioridad { get; set; }
        public int? cod_motivo { get; set; }
        public string? cod_asegurado { get; set; }
        public string poliza_asegurado { get; set; }
        public string poliza_certificado { get; set; }
        public string numero_documento_id { get; set; }
        public string correo_electronico { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string documento_identidad { get; set; }
        public string id_cliente { get; set; }
        public string empresa { get; set; }
        public int? cod_proveedor { get; set; }
        public string proveedor { get; set; }
        public string centro_medico_derivado { get; set; }
        public string especialidad { get; set; }
        public string paciente { get; set; }
        public string prioridad { get; set; }
        public string direccion { get; set; }
        public string direccion_destino { get; set; }
        public int? id_clinica_origen { get; set; }
        public int? id_clinica_destino { get; set; }
        public string alergia_medica { get; set; }
        public string antecedente { get; set; }
        //public string solicitud { get; set; }
        public string regla_oro { get; set; }
        public string ubicacion_dentro_clinica_origen { get; set; }
        public string ubicacion_dentro_clinica_destino { get; set; }
        public string fecha_evento_adverso { get; set; }
        public Boolean? contratante_citrix { get; set; }
        public Boolean? fuera_cobertura { get; set; }
        public string nro_placa_vehicular_poliza { get; set; }
        public string nro_poliza { get; set; }
        public string nro_siniestro_poliza { get; set; }
        public Boolean? flg_ambulancia_respiratoria { get; set; }
        public string ambulancia_respiratoria { get; set; }
        public int? id_tipo_ambulancia { get; set; }
        public int? id_solicitud { get; set; }
        public int? id_solicitante { get; set; }
        public string motivo { get; set; }
        public string motivo_atencion { get; set; }
        public string clasificacion { get; set; }
        public string usuario_creacion { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string observacion { get; set; }
    }

    public class HistoriaClinicaAmbulancia
    {
        //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
        public int CPAR_ID_MOTIVO_CALLMEDICO { get; set; }
        public int CPAR_ID_REFERENCIA_AMBULANCIA { get; set; }
        public int CCEN_ID { get; set; }
        public int CECM_ID { get; set; }
        public int CPAR_ID_SOLICITUD { get; set; }
        public int CHIS_ID { get; set; }

        //TBLMDS_HISTORIA_CLINICA
        public string SHIS_ESTADO { get; set; }
        public string SHIS_CM_ESTADO { get; set; }
        public string NHIS_COD_ESTADO { get; set; }
        public string FHIS_FLG_CM_NUEVA { get; set; }
        public string NHIS_CM_ORDEN { get; set; }
        public string SHIS_REF_DIR { get; set; }
        public string SHIS_CM_REF_DIR { get; set; }
        public string FHIS_FLAG_PROGRAMADA { get; set; }
        public string SHIS_F_PROG { get; set; }
        public string SHIS_COD_TIPO_PROG { get; set; }
        public string SHIS_COD_DR_SOLICITADO { get; set; }
        public string SHIS_COD_DEP { get; set; }
        public string FHIS_CM_DIRECTA { get; set; }
        public string SHIS_FLG_DIRECTO { get; set; }
        public string FHIS_CM_DATOS_COMPLETOS { get; set; }
        public string NHIS_TAR_ATE { get; set; }
        public string SHIS_TIPO_SERVAMB_DRMAS { get; set; }
        public string SHIS_COD_AMB_TIPO_SERV { get; set; }
        public string NHIS_COASEGURO { get; set; }
        public string SHIS_FLAGMONE { get; set; }
        public string NHIS_CAMBIO { get; set; }
        public string SHIS_FOR_ATE { get; set; }
        public string SHIS_CM_MONEDA_DEN { get; set; }
        public string NHIS_CM_DEN_CAMBIO { get; set; }
        public string SHIS_CM_DENOMINACION { get; set; }
        public string SHIS_CONTACTO_PAC { get; set; }
        public string SHIS_CONTACTO_ASEG { get; set; }
        public string SHIS_TIPO_SERVICIO { get; set; }
        public string NHIS_CLASIFICACION_PAC { get; set; }
        public string SHIS_TIPO_DOC_PAGO { get; set; }
        public string SHIS_DESCRP_ZONA { get; set; }
        public string SHIS_COD_EMP { get; set; }
        public string SHIS_USULLA_ATE { get; set; }
        public string CPAC_ID { get; set; }
        public string CPER_ID { get; set; }
        public string CCLI_ID { get; set; }
        public string SHIS_NOM_EMP { get; set; }
        public string DHIS_OBS_CM { get; set; }
        public string NHIS_CLASIFICACION_PAC_CALLMED { get; set; }
        public string SHIS_COD_AUT_PRESTACION { get; set; }
        public string SHIS_COD_ASEGURADO { get; set; }
        public string SHIS_CM_ASEG_PRODUCTO { get; set; }
        public string SHIS_POLIZA_ASEGURADO { get; set; }
        public string SHIS_POLIZA_CERTIFICADO { get; set; }
    }
    /*FIN AMBULANCIA*/

    /*INICIO MAD*/
    public class ClienteAseguradora
    {
        //public string CCLT_ID { get; set; }
        public string SIAF_FINANCIAMIENTO { get; set; }
        public string? SCLT_NOMBRE { get; set; }

    }
    /*FIN MAD*/
}