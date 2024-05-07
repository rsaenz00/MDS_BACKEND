using MDS.Infrastructure.DbUtility;

namespace MDS.DbContext.Entities
{
    public class Cliente
    {
        public string SCLI_IDCLIENTE { get; set; }
        public string SCLI_NOMBRE { get; set; }
        public string SCLI_DESCRIPCION { get; set; }
        public string SCLI_DIRECCION { get; set; }
        public string SCLI_DISTRITO { get; set; }
        public string SCLI_RUC { get; set; }
        public Boolean FCLI_ESTADO { get; set; }
    }
}
