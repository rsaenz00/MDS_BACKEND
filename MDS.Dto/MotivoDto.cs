namespace MDS.Dto
{
    public class MotivoDto
    {
        public long id_motivo { get; set; }
        public long tipo_atencion { get; set; }
        public long tipo_pase { get; set; }
        public string descripcion { get; set; }
        public Boolean skill { get; set; }
        //public int usuario_creacion { get; set; }
        //public DateTime DMOT_FECHA_CREACION { get; set; }
        //public int usuario_modificacion { get; set; }
        //public DateTime DMOT_FECHA_MODIFICACION { get; set; }
    }
    public class MotivoComboDto
    {
        public long id_motivo { get; set; }
        public string descripcion { get; set; }
    }
}
