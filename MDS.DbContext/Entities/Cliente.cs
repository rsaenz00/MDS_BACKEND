using MDS.Infrastructure.DbUtility;

namespace MDS.DbContext.Entities
{
    public class Cliente
    {        
        public long NCLI_ID { get; set; }
        public string? SCLI_NOMBRE { get; set; }
        public string? SCLI_DESCRIPCION { get; set; }
        public string? SCLI_DIRECCION { get; set; }
        public string? SCLI_DISTRITO { get; set; }
        public string? SCLI_RUC { get; set; }
        public bool FCLI_ESTADO { get; set; }
    }


    public class MantenimientoCliente
    {
        public bool FCLI_ESTADO { get; set; }
        public long NCLI_ID { get; set; }
        public string? SCLI_NOMBRE { get; set; }
        public string? SCLI_DESCRIPCION { get; set; }
        public string? SCLI_DIRECCION { get; set; }
        public string? SCLI_DISTRITO { get; set; }
        public string? SCLI_RUC { get; set; }
        public int NCLI_DSCTO_PED { get; set; }
        public decimal NCLI_FACTOR_LAB { get; set; }
        public int NCLI_DSCTO_LAB { get; set; }
        public decimal NCLI_COSTO { get; set; }
        public string? CCLI_CONV_EMP { get; set; }
        public decimal NCLI_COSTO_ALT { get; set; }
        public string? SCLI_FLAG_TIPO { get; set; }
        public bool FCLI_ACTIVI_OPERACIONES { get; set; }
        public decimal NCLI_FACTOR_LAB_PROV { get; set; }
        public string? SCLI_COD_GRU_FACT { get; set; }
        public bool FCLI_ACTIVO_FACT { get; set; }
        public int NCLI_RELACIONADO { get; set; }
        public bool FCLI_ACTIVO_LAB { get; set; }
        public bool FCLI_ACTIVO_AMB { get; set; }
        public bool FCLI_CLIENTE_PLAYA { get; set; }
        public string? SCLI_EMAIL { get; set; }
        public string? SCLI_URBANIZACION { get; set; }
        public int NCLI_DIAS_PLAZO { get; set; }
        public string SCLI_COD_TIPO_DOC_ID { get; set; }
        public string SCLI_EMAIL_CON_COPIA { get; set; }
        public string SCLI_PERSONAL_CONTACTO { get; set; }
        public string SCLI_TLF_CONTACTO { get; set; }
        public int NCLI_ID_DOC_ID { get; set; }
        public bool FCLI_SAP_FLG_REGISTRADO { get; set; }
        public bool FCLI_ACTIVO_DRONLINE { get; set; }
        public bool FCLI_FLG_CARGAR_BD { get; set; }
        public string? SCLI_NOM_ASEG_ONBASE { get; set; }
        public bool SCLI_VISIBLE_MELCHORITA { get; set; }
        public bool SCLI_VISIBLE_CALLMEDICO { get; set; }
        public int NCLI_DIAS_CREDITO { get; set; }
        public bool FCLI_FLG_CAPITADO { get; set; }
        public bool FCLI_VISIBLE_HOME_CARE { get; set; }
        public int NCLI_USUARIO_CREACION { get; set; }
        public DateTime DCLI_FECHA_CREACION { get; set; }
        public int NCLI_USUARIO_MODIFICACION { get; set; }
        public DateTime DCLI_FECHA_MODIFICACION { get; set; }
    }
}
