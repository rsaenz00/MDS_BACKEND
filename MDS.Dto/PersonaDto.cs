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
        public string nombre { get; set; }

        public string paterno { get; set; }
        public string materno { get; set; }

        public string dni { get; set; }

        public DateTime fecha_naciemiento { get; set; }

        public string genero { get; set; }
        public string telefono_celular { get; set; }
        public int usuario_creacion { get; set; }
    }


}