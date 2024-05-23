namespace MDS.DbContext.Entities
{
    public class Paciente
    {
        public string? CPAC_IDPACIENTE { get; set; }

        public int CPER_IDPERSONA { get; set; }

        public int CSER_IDSERVICIO { get; set; }

        public bool FPAC_ESTADO { get; set; }

    }

    public class MantenimientoPaciente
    {

        public int CPER_IDPERSONA { get; set; }

        public int CSER_IDSERVICIO { get; set; }

        public DateTime DPAC_FINC { get; set; }

        public string SPAC_COD_PAR { get; set; }

        public DateTime DPAC_FCRE { get; set; }

        public bool FPAC_BOL_ACT { get; set; }

        public string SPAC_OBS { get; set; }

        public bool FPAC_FLG_CORREO { get; set; }

        public string SPAC_USUCRE_EMAIL { get; set; }

        public string SPAC_USUMODIF_EMAIL { get; set; }

        public string SPAC_FLAG_FICHA { get; set; }

        public bool FPAC_FLAG_BLOQ { get; set; }

        public bool FPAC_FLAG_VIP { get; set; }

        public int NPAC_CLASIFICACION { get; set; }

        public string SPAC_VIP { get; set; }
        public int NPAC_COD_SUBCLASIF { get; set; }

        public DateTime DPAC_FECHA_VIGENCIA { get; set; }

        public bool FPAC_FLG_REGISTRAR_PAC_TABLET { get; set; }

        public bool FPAC_CLAVE { get; set; }

        public string SPAC_TIPO_CLAVE { get; set; }

        public string SPAC_OBS_CLAVE { get; set; }

        public bool FPAC_CONSENT_INFORMADO { get; set; }

        public bool FPAC_CONSENT_RECIBIR_INFO { get; set; }

        public bool FPAC_CONSENT_FIRMA_CONST { get; set; }

        public bool FPAC_CONSMT_RI { get; set; }

        public bool FPAC_FLG_CONFLICTIVO_CALLMED { get; set; }

        public bool FPAC_FLG_ACTIVO_FARMACIA { get; set; }

        public int NPAC_NORDEN_OBS { get; set; }

        public string SPAC_GRUPO_CRONICOS { get; set; }

        public bool FPAC_FLG_PAQUETE_SALUD { get; set; }
        public bool FPAC_ESTADO { get; set; }

        public int NPAC_USUARIO_CREACION { get; set; }

        public DateTime DPAC_FECHA_CREACION { get; set; }

        public int NPAC_USUARIO_MODIFICACION { get; set; }

        public DateTime DPAC_FECHA_MODIFICACION { get; set; }

    }
}
