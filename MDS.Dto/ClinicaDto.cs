namespace MDS.Dto
{
    public class ClinicaDto
    {
        public long id_clinica { get; set; }
        public string clinica { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string anexo { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string afiliado { get; set; }
        public Boolean plan_huerfano_ilimitado { get; set; }
        public Boolean estado { get; set; }
    }
    public class ClinicaMtoDto
    {
        public long id_clinica { get; set; }
        public string clinica { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string anexo { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string? afiliado { get; set; }
        public int? plan_huerfano_ilimitado { get; set; }
        public int? estado { get; set; }
        public int? usuario_creacion { get; set; }
        public int? usuario_modificacion { get; set; }
    }
}
