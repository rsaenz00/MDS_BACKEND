using System.ComponentModel.DataAnnotations;

namespace MDS.DbContext.Entities
{
    //ConsultaAsegNom
    public class Request_Asegurado
    {
        public string? CodTipoDocumentoAfiliado { get; set; }
        public string? NumeroDocumentoAfiliado { get; set; }
        [Required]
        public string RUC { get; set; }
        [Required]
        public string SUNASA { get; set; }
        [Required]
        public string IAFAS { get; set; }
        public string? NombresAfiliado { get; set; }
        public string? ApellidoPaternoAfiliado { get; set; }
        public string? ApellidoMaternoAfiliado { get; set; }
        public string? CodEspecialidad { get; set; }
    }

    //"ConsultaAsegCod", "ConsultaObservacion", "ConsultaDatosAdicionales", "ConsultaCondicionMedica"
    public class Request_AsegCod_Obs_DatAdic_CondMed
    {
        public string? SUNASA { get; set; }
        public string? IAFAS { get; set; }
        public string? RUC { get; set; }
        public string? NombresAfiliado { get; set; }
        public string? ApellidoPaternoAfiliado { get; set; }
        public string? ApellidoMaternoAfiliado { get; set; }
        public string? CodigoAfiliado { get; set; }
        public string? CodTipoDocumentoAfiliado { get; set; }
        public string? NumeroDocumentoAfiliado { get; set; }
        public string? CodEspecialidad { get; set; }
        public string? CodProducto { get; set; }
        public string? DesProducto { get; set; }
        public string? NumeroPlan { get; set; }
        public string? CodTipoDocumentoContratante { get; set; }
        public string? NumeroDocumentoContratante { get; set; }
        public string? NombreContratante { get; set; }
        public string? CodParentesco { get; set; }
        public string? TipoCalificadorContratante { get; set; }
        public string? NumeroCobertura { get; set; }
        public string? BeneficioMaximoInicial { get; set; }
        public string? CodigoTipoCobertura { get; set; }
        public string? CodigoSubTipoCobertura { get; set; }
    }

    //ConsultaNumeroAutorizacion
    public class Request_NumeroAutorizacion
    {
        public string? ApellidoMaternoAfiliado { get; set; }
        public string? ApellidoPaternoAfiliado { get; set; }
        public string? BeneficioMaximoInicial { get; set; }
        public string? CodigoAfiliado { get; set; }
        public string? CodigoTitular { get; set; }
        public string? CodCalificacionServicio { get; set; }
        public string? CodEstado { get; set; }
        public string? CodEspecialidad { get; set; }
        public string? CodMoneda { get; set; }
        public string? CodCopagoFijo { get; set; }
        public string? CodCopagoVariable { get; set; }
        public string? CodParentesco { get; set; }
        public string? CodProducto { get; set; }
        public string? NumeroDocumentoContratante { get; set; }
        public string? CodSubTipoCobertura { get; set; }
        public string? CodTipoCobertura { get; set; }
        public string? CodTipoAfiliacion { get; set; }
        public string? DesProducto { get; set; }
        public string? CodEstadoMarital { get; set; }
        public string? CodFechaFinCarencia { get; set; }
        public string? CodFechaAfiliacion { get; set; }
        public string? CodFechaInicioVigencia { get; set; }
        public string? CodFechaNacimiento { get; set; }
        public string? CodGenero { get; set; }
        public string? SUNASA { get; set; }
        public string? IAFAS { get; set; }
        public string? CondicionesEspeciales { get; set; }
        public string? ApellidoMaternoTitular { get; set; }
        public string? NombreContratante { get; set; }
        public string? ApellidoPaternoTitular { get; set; }
        public string? NombresAfiliado { get; set; }
        public string? NombresTitular { get; set; }
        public string? NumeroCertificado { get; set; }
        public string? NumeroContrato { get; set; }
        public string? NumeroDocumentoAfiliado { get; set; }
        public string? NumeroDocumentoTitular { get; set; }
        public string? NumeroPlan { get; set; }
        public string? NumeroPoliza { get; set; }
        public string? RUC { get; set; }
        public string? CodTipoDocumentoContratante { get; set; }
        public string? CodTipoDocumentoAfiliado { get; set; }
        public string? CodTipoDocumentoTitular { get; set; }
        public string? CodTipoPlan { get; set; }
        public string? CodIndicadorRestriccion { get; set; }
    }

    //"ObtenerFoto"
    public class Request_ObtenerFoto
    {
        public string Iafas { get; set; }
        public string CodigoAfiliado { get; set; }
        public string CodFechaActualizacionFoto { get; set; }
    }

    public class Response_Siteds
    {
        public DatosAfiliado DatosAfiliado { get; set; }
        public List<Coberturas> Coberturas { get; set; }
    }

    public class Coberturas
    {
        public string CodigoTipoCobertura { get; set; }
        public string CodigoSubTipoCobertura { get; set; }
        public string CodigoCobertura { get; set; }
        public string Beneficios { get; set; }
        public string CodIndicadorRestriccion { get; set; }
        public string Restricciones { get; set; }
        public string CodCopagoFijo { get; set; }
        public string DesCopagoFijo { get; set; }
        public string CodCopagoVariable { get; set; }
        public string DesCopagoVariable { get; set; }
        public string CodFechaFinCarencia { get; set; }
        public string FechaFinCarencia { get; set; }
        public string CondicionesEspeciales { get; set; }
        public string Observaciones { get; set; }
        public string CodCalificacionServicio { get; set; }
        public string DesCalificacionServicio { get; set; }
        public string BeneficioMaximoInicial { get; set; }
        public string NumeroCobertura { get; set; }
        public string CodTipoMoneda { get; set; }
        public string DesTipoMoneda { get; set; }
    }

    public class DatosAfiliado
    {
        public string CodigoAfiliado { get; set; }
        public string NumeroPoliza { get; set; }
        public string NumeroContrato { get; set; }
        public string NumeroCertificado { get; set; }
        public string CodProducto { get; set; }
        public string DesProducto { get; set; }
        public string ApellidoPaternoAfiliado { get; set; }
        public string ApellidoMaternoAfiliado { get; set; }
        public string NombresAfiliado { get; set; }
        public string CodGenero { get; set; }
        public string DesGenero { get; set; }
        public string CodFechaNacimiento { get; set; }
        public string FechaNacimiento { get; set; }
        public string CodParentesco { get; set; }
        public string DesParentesco { get; set; }
        public string CodTipoDocumentoAfiliado { get; set; }
        public string DesTipoDocumentoAfiliado { get; set; }
        public string NumeroDocumentoAfiliado { get; set; }
        public string Edad { get; set; }
        public string CodFechaInicioVigencia { get; set; }
        public string FechaInicioVigencia { get; set; }
        public string CodFechaFinVigencia { get; set; }
        public string FechaFinVigencia { get; set; }
        public string CodEstadoCivil { get; set; }
        public string DesEstadoCivil { get; set; }
        public string CodTipoPlan { get; set; }
        public string DesTipoPlan { get; set; }
        public string NumeroPlan { get; set; }
        public string CodEstado { get; set; }
        public string DesEstado { get; set; }
        public string CodFechaActualizacionFoto { get; set; }
        public string FechaActualizacionFoto { get; set; }
        public string ApellidoPaternoTitular { get; set; }
        public string ApellidoMaternoTitular { get; set; }
        public string NombresTitular { get; set; }
        public string CodigoTitular { get; set; }
        public string CodTipoDocumentoTitular { get; set; }
        public string DesTipoDocumentoTitular { get; set; }
        public string NumeroDocumentoTitular { get; set; }
        public string CodMoneda { get; set; }
        public string DesMoneda { get; set; }
        public string NombreContratante { get; set; }
        public string CodTipoDocumentoContratante { get; set; }
        public string DesTipoDocumentoContratante { get; set; }
        public string CodTipoAfiliacion { get; set; }
        public string DesTipoAfiliacion { get; set; }
        public string CodFechaAfiliacion { get; set; }
        public string FechaAfiliacion { get; set; }
        public string NumeroDocumentoContratante { get; set; }
        public string NumeroContratoAfiliado { get; set; }
        public string TipoCalificadorContratante { get; set; }
        public string CodSubTipoCobertura { get; set; }
        public string CodTipoCobertura { get; set; }
        public string CodEstadoMarital { get; set; }
        public string NumeroSCTR { get; set; }
    }

    public class Response_cod_autorizacion
    {
        public string NumeroAutorizacion { get; set; }
        public string Documento { get; set; }
    }

    public class Response_observaciones
    {
        public string IndObservacionAsegurado { get; set; }
        public string IndObservacionesEspeciales { get; set; }
        public string Observaciones { get; set; }
    }

    public class Response_datos_adicionales
    {
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Ubigeo { get; set; }
        public string Contacto { get; set; }
        public string Calificador { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
    }

    public class Response_condicion_medica
    {
        public Preexistencia Preexistencia { get; set; }
        public Exclusiones Exclusiones { get; set; }
        public Carencia Carencia { get; set; }
        public Antecedentes Antecedentes { get; set; }
        public Enfermedad Enfermedad { get; set; }
    }

    public class Response_procedimientos_especiales
    {
        public Procedimiento Procedimiento { get; set; }
        public TiempoEspera TiempoEspera { get; set; }
        public ExcepcionCarencia ExcepcionCarencia { get; set; }
    }

    public class Procedimiento
    {
        public string Descripcion { get; set; }
        public Detalle Detalle { get; set; }
    }

    public class TiempoEspera
    {
        public string Descripcion { get; set; }
        public Detalle Detalle { get; set; }
    }

    public class ExcepcionCarencia
    {
        public string Descripcion { get; set; }
        public Detalle Detalle { get; set; }
    }

    public class Detalle
    {
        public string Codigo { get; set; }
        public string Procedimiento { get; set; }
        public string Genero { get; set; }
        public string CodCopagoFijo { get; set; }
        public string DesCopagoFijo { get; set; }
        public string CodCopagoVariable { get; set; }
        public string DesCopagoVariable { get; set; }
        public string Frecuencia { get; set; }
        public string Tiempo { get; set; }
        public string Observaciones { get; set; }
    }

    public class Response_ObtenerFoto
    {
        public string Foto { get; set; }
    }

    public class Preexistencia
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Exclusiones
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Carencia
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Antecedentes
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Enfermedad
    {
        public string CodRestriccion { get; set; }
        public string DesRestriccion { get; set; }
        public List<Condicion> Condicion { get; set; }
    }

    public class Condicion
    {
        public string Codigo { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }
    }

}