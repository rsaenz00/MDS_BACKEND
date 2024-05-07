namespace MDS.Dto
{
    public class UsuarioDto
    {
        public int codigoUsuario { get; set; }
        public string? ip { get; set; }
        public string? usuario { get; set; }
        public string? contrasena { get; set; }
        public string? nombres { get; set; }
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public string? email { get; set; }
        public string? telefonoMovil { get; set; }
        public string? latitud { get; set; }
        public string? longitud { get; set; }
        public bool estado { get; set; }
        public bool dobleFactor { get; set; }
        public bool emailConfirmacion { get; set; }
        public int intentosFallidos { get; set; }
    }
}
