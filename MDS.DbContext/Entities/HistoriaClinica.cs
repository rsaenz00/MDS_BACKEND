using System.Data.SqlTypes;

namespace MDS.DbContext.Entities
{
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
        public long id_cliente { get; set; }//MAD - SCTR
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
        public string? tipo_pase_atencion { get; set; }//SCTR
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
    
    public class HistoriaClinicaMad
    {
        public long cod_historia_clinica { get; set; }//MAD - SCTR
        public string paciente { get; set; }//MAD - SCTR
        public string fecha_creacion { get; set; }//MAD - SCTR
        public string fecha_nacimiento { get; set; }//MAD - SCTR
        public int edad { get; set; }//MAD - SCTR
        public string hora_atencion { get; set; }//MAD - SCTR
        public string celular { get; set; }//MAD - SCTR
        public long id_cliente { get; set; }//MAD - SCTR
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
}