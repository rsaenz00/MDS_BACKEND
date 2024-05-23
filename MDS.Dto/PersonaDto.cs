namespace MDS.Dto
{
    public class PersonaDto
    {

        public int id_persona { get; set; }

        public string paterno { get; set; }

        public string materno { get; set; }

        public string nombre { get; set; }

        public string dni { get; set; }

        public string genero { get; set; }

        public bool estado { get; set; }


    }

    public class MantenimientoPersonaDto
    {
        public long Id { get; set; }
        public int CPAI_IDPAIS { get; set; }

        public int CUBI_IDUBIGEO { get; set; }

        public string SPER_NOMBRES { get; set; }

        public string SPER_APELLIDO_PATERNO { get; set; }
        public string SPER_APELLIDO_MATERNO { get; set; }

        public string SPER_DNI { get; set; }

        public DateTime DPER_FECHA_NACIMIENTO { get; set; }

        public string SPER_GENERO { get; set; }

        public string SPER_DEPARTAMENTO { get; set; }

        public string SPER_PROVINCIA { get; set; }

        public string SPER_DISTRITO { get; set; }

        public string SPER_DIRECCION { get; set; }

        public string SPER_EMAIL1 { get; set; }

        public string SPER_EMAIL2 { get; set; }

        public string SPER_TELEFONO_CASA { get; set; }

        public string SPER_TELEFONO_CELULAR { get; set; }

        public string SPER_TELEFONO_CORPORATIVO { get; set; }

        public bool FPER_ESTADO { get; set; }

        public int NPER_USUARIO_CREACION { get; set; }

        public DateTime DPER_FECHA_CREACION { get; set; }

        public int NPER_USUARIO_MODIFICACION { get; set; }

        public DateTime DPER_FECHA_MODIFICACION { get; set; }

    }


}
