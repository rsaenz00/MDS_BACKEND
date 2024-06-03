﻿namespace MDS.DbContext.Entities
{
    public class Motivo
    {
        public long CMOT_ID { get; set; }
        public long NMOT_TIPO_ATENCION { get; set; }
        public long NMOT_TIPO_PASE { get; set; }
        public string SMOT_DESCRIPCION { get; set; }
        public Boolean FMOT_SKILL { get; set; }
        public int NMOT_USUARIO_CREACION { get; set; }
        public DateTime DMOT_FECHA_CREACION { get; set; }
        public int NMOT_USUARIO_MODIFICACION { get; set; }
        public DateTime DMOT_FECHA_MODIFICACION { get; set; }
    }
    public class MotivoCombo
    {
        public long CMOT_ID { get; set; }
        public string SMOT_DESCRIPCION { get; set; }
    }
}