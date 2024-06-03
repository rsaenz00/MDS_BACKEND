namespace MDS.Dto
{
    public class AtencionDto
    {
        public long cod_atencion { get; set; }
        public string paciente { get; set; }
        public string fecha_nacimiento { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }
        public string celular { get; set; }
        public string documento_identidad { get; set; }
        public string numero_documento_id { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_atencion { get; set; }
        public string descripcion_ipress { get; set; }
        public string ipress_telefono { get; set; }
        public string ipress_anexo { get; set; }
        public string empresa { get; set; }
        public string empresa_ruc { get; set; }
        public string horario_trabajo { get; set; }
        public string puesto_cargo { get; set; }
        public string relato { get; set; }
        public string fecha_accidente { get; set; }
        public string hora_accidente { get; set; }
        public string tipo_atencion { get; set; }
        public string tipo_pase_atencion { get; set; }
        public string motivo { get; set; }
        public string observacion { get; set; }
        public string ipress_primera_ate { get; set; }
        public long id_clinica { get; set; }
        public string persona_reporta { get; set; }
        public long id_cliente { get; set; }
        public int? id_motivo { get; set; }
        public string numero_atencion { get; set; }
        public string metodo_validacion { get; set; }
        public Boolean hoja_atencion { get; set; }
        public string id_plan { get; set; }
        public int skill { get; set; }
        public int motivo_skill { get; set; }
    }

    public class AtencionMtoDto
    {
        public long id_atencion { get; set; }
        public long id_persona { get; set; }
        public long id_empresa { get; set; }
        public long id_clinica { get; set; }
        public long id_motivo { get; set; }
        public string id_plan { get; set; }
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
        public string hoja_atencion { get; set; }
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
        public int usuario_creacion { get; set; }
        public int usuario_eliminacion { get; set; }
        //public DateTime DATE_FECHA_CREACION { get; set; }
        //public int usuario_modificacion { get; set; }
        //public DateTime DATE_FECHA_MODIFICACION { get; set; }
    }

    public class AtencionBandejaDto
    {
        public long cod_atencion { get; set; }
        public string? tipo_atencion { get; set; }
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
        public string? persona_reporta { get; set; }
        public string? motivo_de_llamada { get; set; }
    }
}
