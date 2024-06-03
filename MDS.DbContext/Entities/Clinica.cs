namespace MDS.DbContext.Entities
{
    public class Clinica
    {
        public long CCLI_ID { get; set; }
        public string CCLI_DESCRIPCION { get; set; }
        public string CUBI_UBIGEO { get; set; }
        public string SCLI_DIRECCION { get; set; }
        public string SCLI_TELEFONO { get; set; }
        public string SCLI_ANEXO { get; set; }
        public string SUBI_DEPARTAMENTO { get; set; }
        public string SUBI_PROVINCIA { get; set; }
        public string SUBI_DISTRITO { get; set; }
        public string FCLI_AFILIADO { get; set; }
        public Boolean FCLI_PLAN_HUERFANO_ILIMITADO { get; set; }
        public Boolean FCLI_ESTADO { get; set; }
        //public int NCLI_USUARIO_CREACION { get; set; }
        //public DateTime DCLI_FECHA_CREACION { get; set; }
        //public int NCLI_USUARIO_MODIFICACION { get; set; }
        //public DateTime DCLI_FECHA_MODIFICACION { get; set; }
        //public DateTime DCLI_FECHA_ELIMINACION { get; set; }
    }
    public class ClinicaMto
    {
        public long CCLI_ID { get; set; }
        public string CCLI_DESCRIPCION { get; set; }
        public string CUBI_UBIGEO { get; set; }
        public string SCLI_DIRECCION { get; set; }
        public string SCLI_TELEFONO { get; set; }
        public int FCLI_AFILIADO { get; set; }
        public int FCLI_PLAN_HUERFANO_ILIMITADO { get; set; }
        public int FCLI_ESTADO { get; set; }
        public string SUBI_DEPARTAMENTO { get; set; }
        public string SUBI_PROVINCIA { get; set; }
        public string SUBI_DISTRITO { get; set; }
    }

    public class ClinicaFiltro
    {
        public long CCLI_ID { get; set; }
        public string CUBI_UBIGEO { get; set; }
        public string SUBI_DEPARTAMENTO { get; set; }
        public string SUBI_PROVINCIA { get; set; }
        public string SUBI_DISTRITO { get; set; }
        public string CCLI_DESCRIPCION { get; set; }
        public string SCLI_DIRECCION { get; set; }
        public string SCLI_TELEFONO { get; set; }
        public string SCLI_ANEXO { get; set; }
        public string FCLI_AFILIADO { get; set; }
    }
}