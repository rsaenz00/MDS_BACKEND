﻿namespace MDS.DbContext.Entities
{
    public class Direccion
    {
        public long CDIR_ID { get; set; }
        public long CPER_ID { get; set; }
        public int NDIR_TIPO_DIRECCION { get; set; }
        public string SDIR_DESCRIPCION { get; set; }
        public string SDIR_COD_DPTO { get; set; }
        public string SDIR_COD_PROV { get; set; }
        public string SDIR_COD_DIST { get; set; }
        public string SDIR_ANEXO { get; set; }
        public string SDIR_TLF_CELULAR { get; set; }
        public string SDIR_TLF_FIJO { get; set; }
        public string SDIR_NRO_LOTE { get; set; }
        public string SDIR_URBANIZACION { get; set; }
        public string SDIR_REFERENCIA { get; set; }
        public string SDIR_INTERIOR { get; set; }

        //public char SDIR_LONGITUD { get; set; }
        //public char SDIR_LATITUD { get; set; }
        //public Boolean FDIR_ELIMINADO { get; set; }
        //public DateTime DDIR_FECHA_ELIMINACION { get; set; }
        //public int NDIR_USUARIO_CREACION { get; set; }
        //public DateTime DDIR_FECHA_CREACION { get; set; }
        //public int NDIR_USUARIO_MODIFICACION { get; set; }
        //public DateTime DDIR_FECHA_MODIFICACION { get; set; }
    }
}