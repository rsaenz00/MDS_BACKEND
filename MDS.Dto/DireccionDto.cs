namespace MDS.Dto
{
    public class DireccionDto
    {
        public long id_direccion { get; set; }
        public long id_persona { get; set; }
        public int tipo_direccion { get; set; }
        public string descripcion { get; set; }
        public string cod_departamento { get; set; }
        public string cod_provincia { get; set; }
        public string cod_distrito { get; set; }
        public string anexo { get; set; }
        public string celular { get; set; }
        public string telefono_fijo { get; set; }
        public string nro_mz_lote { get; set; }
        public string urbanizacion { get; set; }
        public string referencia { get; set; }
        public string dpto_interior { get; set; }
        //public char SDIR_LONGITUD { get; set; }
        //public char SDIR_LATITUD { get; set; }
        //public Boolean FDIR_ELIMINADO { get; set; }
        //public DateTime DDIR_FECHA_ELIMINACION { get; set; }
        public int usuario_creacion { get; set; }
        //public DateTime DDIR_FECHA_CREACION { get; set; }
        public int usuario_modificacion { get; set; }
        //public DateTime DDIR_FECHA_MODIFICACION { get; set; }
    }
}
