using MDS.Infrastructure.DbUtility;

namespace MDS.DbContext.Entities
{
    public class Cliente
    {
        public int NCLI_IDCLIENTE { get; set; }
        public string SCLI_NOMBRE { get; set; }
        public string SCLI_DESCRIPCION { get; set; }
        public string SCLI_DIRECCION { get; set; }
        public string SCLI_DISTRITO { get; set; }
        public string SCLI_RUC { get; set; }
        public string FCLI_ESTADO { get; set; }
    }
}
