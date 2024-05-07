namespace MDS.DbContext.Entities
{
    public class Ubigeos
    {
        public string CUBI_UBIGEO { get; set; }
        public string SUBI_COD_DPTO { get; set; }
        public string SUBI_DEPARTAMENTO { get; set; }
        public string SUBI_COD_PROV { get; set; }
        public string SUBI_PROVINCIA { get; set; }
        public string SUBI_COD_DIST { get; set; }
        public string SUBI_DISTRITO { get; set; }
    }
    public class Departamento
    {
        public string SUBI_COD_DPTO { get; set; }
        public string SUBI_DEPARTAMENTO { get; set; }
    }
    public class Provincia
    {
        public string SUBI_COD_PROV { get; set; }
        public string SUBI_PROVINCIA { get; set; }
    }
    public class Distrito
    {
        public string SUBI_COD_DIST { get; set; }
        public string SUBI_DISTRITO { get; set; }
    }
}
